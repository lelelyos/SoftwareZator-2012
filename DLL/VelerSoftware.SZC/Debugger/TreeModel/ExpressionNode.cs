// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using VelerSoftware.SZC.Debugger.Base.Debugging;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.Debugger.Debugger;
using VelerSoftware.SZC.Debugger.Debugger.MetaData;
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    /// <summary>
    /// Node in the tree which can be defined by a debugger expression.
    /// The expression will be lazily evaluated when needed.
    /// </summary>
    public class ExpressionNode : TreeNode, ISetText
    {
        bool evaluated;

        Expression expression;
        bool canSetText;
        GetValueException error;

        string fullText;

        public Expression Expression
        {
            get { return expression; }
        }

        public bool CanSetText
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return canSetText;
            }
        }

        public GetValueException Error
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return error;
            }
        }

        public override string Text
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return base.Text;
            }
        }

        public override string Type
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return base.Type;
            }
        }

        public override IEnumerable<TreeNode> ChildNodes
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return base.ChildNodes;
            }
        }

        public override bool HasChildNodes
        {
            get
            {
                if (!evaluated) EvaluateExpression();
                return base.HasChildNodes;
            }
        }

        /// <summary> Used to determine available VisualizerCommands </summary>
        private DebugType expressionType;
        /// <summary> Used to determine available VisualizerCommands </summary>
        private bool valueIsNull = true;

        private IEnumerable<IVisualizerCommand> visualizerCommands;

        public override IEnumerable<IVisualizerCommand> VisualizerCommands
        {
            get
            {
                if (visualizerCommands == null)
                {
                    visualizerCommands = getAvailableVisualizerCommands();
                }
                return visualizerCommands;
            }
        }

        private IEnumerable<IVisualizerCommand> getAvailableVisualizerCommands()
        {
            if (!evaluated) EvaluateExpression();

            if (this.expressionType == null)
            {
                // no visualizers if EvaluateExpression failed
                yield break;
            }
            if (this.valueIsNull)
            {
                // no visualizers if evaluated value is null
                yield break;
            }
            if (this.expressionType.IsPrimitive)
            {
                // no visualizers for primitive types
                yield break;
            }

            // foreach (var descriptor in VisualizerDescriptors.GetAllDescriptors()) {
            // 	if (descriptor.IsVisualizerAvailable(this.expressionType)) {
            // 		yield return descriptor.CreateVisualizerCommand(this.Expression);
            // 	}
            // }
        }

        public ExpressionNode(Image image, string name, Expression expression)
        {
            this.Image = image;
            this.Name = name;
            this.expression = expression;
        }

        private void EvaluateExpression()
        {
            evaluated = true;

            Value val;
            try
            {
                val = expression.Evaluate(WindowsDebugger.DebuggedProcess);
            }
            catch (GetValueException e)
            {
                error = e;
                this.Text = e.Message;
                return;
            }

            this.canSetText = val.Type.IsPrimitive;

            this.expressionType = val.Type;
            this.Type = val.Type.FullName;
            this.valueIsNull = val.IsNull;

            // Note that these return enumerators so they are lazy-evaluated
            if (val.IsNull)
            {
            }
            else if (val.Type.IsPrimitive || val.Type.FullName == typeof(string).FullName)
            { // Must be before IsClass
            }
            else if (val.Type.IsArray)
            { // Must be before IsClass
                if (val.ArrayLength > 0)
                    this.ChildNodes = Utils.LazyGetChildNodesOfArray(this.Expression, val.ArrayDimensions);
            }
            else if (val.Type.IsClass || val.Type.IsValueType)
            {
                if (val.Type.FullNameWithoutGenericArguments == typeof(List<>).FullName)
                {
                    if ((int)val.GetMemberValue("_size").PrimitiveValue > 0)
                        this.ChildNodes = Utils.LazyGetItemsOfIList(this.expression);
                }
                else
                {
                    this.ChildNodes = Utils.LazyGetChildNodesOfObject(this.Expression, val.Type);
                }
            }
            else if (val.Type.IsPointer)
            {
                Value deRef = val.Dereference();
                if (deRef != null)
                {
                    this.ChildNodes = new ExpressionNode[] { new ExpressionNode(this.Image, "*" + this.Name, this.Expression.AppendDereference()) };
                }
            }

            //if (DebuggingOptions.Instance.ICorDebugVisualizerEnabled) {
            //TreeNode info = ICorDebug.GetDebugInfoRoot(val.AppDomain, val.CorValue);
            //this.ChildNodes = Utils.PrependNode(info, this.ChildNodes);
            //}

            // Do last since it may expire the object
            if (val.Type.IsInteger)
            {
                fullText = FormatInteger(val.PrimitiveValue);
            }
            else if (val.Type.IsPointer)
            {
                fullText = String.Format("0x{0:X}", val.PointerAddress);
            }
            else if ((val.Type.FullName == typeof(string).FullName ||
                      val.Type.FullName == typeof(char).FullName) && !val.IsNull)
            {
                try
                {
                    fullText = '"' + Escape(val.InvokeToString()) + '"';
                }
                catch (GetValueException e)
                {
                    error = e;
                    fullText = e.Message;
                    return;
                }
            }
            else if ((val.Type.IsClass || val.Type.IsValueType) && !val.IsNull)
            {
                try
                {
                    fullText = val.InvokeToString();
                }
                catch (GetValueException e)
                {
                    error = e;
                    fullText = e.Message;
                    return;
                }
            }
            else
            {
                fullText = val.AsString();
            }

            switch (fullText)
            {
                case "System.Object":
                    fullText = "Null";
                    break;
                default:
                    break;
            }

            this.Text = (fullText.Length > 256) ? fullText.Substring(0, 256) + "..." : fullText;
        }

        private string Escape(string source)
        {
            return source.Replace("\n", "\\n")
                .Replace("\t", "\\t")
                .Replace("\r", "\\r")
                .Replace("\0", "\\0")
                .Replace("\b", "\\b")
                .Replace("\a", "\\a")
                .Replace("\f", "\\f")
                .Replace("\v", "\\v")
                .Replace("\"", "\\\"");
        }

        private string FormatInteger(object i)
        {
            return i.ToString();
        }

        private bool ShowAsHex(object i)
        {
            ulong val;
            if (i is sbyte || i is short || i is int || i is long)
            {
                unchecked { val = (ulong)Convert.ToInt64(i); }
                if (val > (ulong)long.MaxValue)
                    val = ~val + 1;
            }
            else
            {
                val = Convert.ToUInt64(i);
            }
            if (val >= 0x10000)
                return true;

            int ones = 0; // How many 1s there is
            int runs = 0; // How many runs of 1s there is
            int size = 0; // Size of the integer in bits
            while (val != 0)
            { // There is at least one 1
                while ((val & 1) == 0)
                { // Skip 0s
                    val = val >> 1;
                    size++;
                }
                while ((val & 1) == 1)
                { // Skip 1s
                    val = val >> 1;
                    size++;
                    ones++;
                }
                runs++;
            }

            return size >= 7 && runs <= (size + 7) / 8;
        }

        public bool SetText(string newText)
        {
            Value val = null;
            try
            {
                val = this.Expression.Evaluate(WindowsDebugger.DebuggedProcess);
                if (val.Type.IsInteger && newText.StartsWith("0x"))
                {
                    try
                    {
                        val.PrimitiveValue = long.Parse(newText.Substring(2), NumberStyles.HexNumber);
                    }
                    catch (FormatException)
                    {
                        throw new NotSupportedException();
                    }
                    catch (OverflowException)
                    {
                        throw new NotSupportedException();
                    }
                }
                else
                {
                    val.PrimitiveValue = newText;
                }
                this.Text = newText;
                return true;
            }
            catch (NotSupportedException)
            {
                string format;
                if (Variables.Langue == "en")
                {
                    format = VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_BadFormat_EN;
                }
                else
                {
                    format = VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_BadFormat;
                }
                string msg = string.Format(format, newText, val.Type.PrimitiveType);
                if (Variables.Langue == "en")
                {
                    MessageService.ShowMessage(msg, VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_Title_EN);
                }
                else
                {
                    MessageService.ShowMessage(msg, VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_Title);
                }
            }
            catch (COMException)
            {
                // COMException (0x80131330): Cannot perfrom SetValue on non-leaf frames.
                // Happens if trying to set value after exception is breaked
                if (Variables.Langue == "en")
                {
                    MessageService.ShowMessage(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_UnknownError_EN,
                                           VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_Title_EN);
                }
                else
                {
                    MessageService.ShowMessage(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_UnknownError,
                                           VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_CannotSetValue_Title);
                }
            }
            return false;
        }

        public static Image GetImageForThis()
        {
            return Properties.Resources.SZW_Icon_16;
        }

        public static Image GetImageForParameter()
        {
            return Properties.Resources.gest_var;
        }

        public static Image GetImageForParameterOfProject()
        {
            return Properties.Resources.setting;
        }

        public static Image GetImageForLocalVariable()
        {
            return Properties.Resources.gest_var;
        }

        public static Image GetImageForArrayIndexer()
        {
            return Properties.Resources.assembly;
        }

        public static Image GetImageForMember(IDebugMemberInfo memberInfo)
        {
            if (memberInfo.IsPublic)
            {
            }
            else if (memberInfo.IsAssembly)
            {
                return Properties.Resources.assembly;
            }
            else if (memberInfo.IsFamily)
            {
                return Properties.Resources._namespace;
            }
            else if (memberInfo.IsPrivate)
            {
                return Properties.Resources._namespace;
            }
            if (memberInfo is FieldInfo)
            {
                return Properties.Resources.field;
            }
            else if (memberInfo is PropertyInfo)
            {
                return Properties.Resources.Propriété;
            }
            else if (memberInfo is MethodInfo)
            {
                return Properties.Resources.Fonction;
            }
            else
            {
                return Properties.Resources._namespace;
                throw new DebuggerException("Unknown member type " + memberInfo.GetType().FullName);
            }
        }

        public static WindowsDebugger WindowsDebugger
        {
            get
            {
                return (WindowsDebugger)DebuggerService.CurrentDebugger;
            }
        }
    }
}