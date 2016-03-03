// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;
using VelerSoftware.SZC.Debugger.Debugger;
using VelerSoftware.SZC.Debugger.Debugger.MetaData;
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    public class StackFrameNode : TreeNode
    {
        StackFrame stackFrame;

        public StackFrame StackFrame
        {
            get { return stackFrame; }
        }

        VelerSoftware.SZVB.Projet.Projet project;

        public VelerSoftware.SZVB.Projet.Projet Project
        {
            get { return project; }
        }

        public StackFrameNode(StackFrame stackFrame, VelerSoftware.SZVB.Projet.Projet proj, VelerSoftware.SZC.Debugger.WindowsDebugger debugger)
        {
            this.stackFrame = stackFrame;
            this.project = proj;

            this.Name = stackFrame.MethodInfo.Name;
            this.ChildNodes = LazyGetChildNodes(debugger);
        }

        private IEnumerable<TreeNode> LazyGetChildNodes(VelerSoftware.SZC.Debugger.WindowsDebugger debugger)
        {
            foreach (DebugParameterInfo par in stackFrame.MethodInfo.GetParameters())
            {
                yield return new ExpressionNode(ExpressionNode.GetImageForParameter(), par.Name, par.GetExpression());
            }
            foreach (DebugLocalVariableInfo locVar in stackFrame.MethodInfo.GetLocalVariables(this.StackFrame.IP))
            {
                if (locVar.Name != "this")
                {
                    yield return new ExpressionNode(ExpressionNode.GetImageForLocalVariable(), locVar.Name, locVar.GetExpression());
                }
                else
                {
                    yield return new ExpressionNode(ExpressionNode.GetImageForThis(), "Me", locVar.GetExpression());
                }
            }
            if (this.project != null)
            {
                foreach (VelerSoftware.SZVB.Projet.Variable var in this.project.Variables)
                {
                    yield return new ExpressionNode(ExpressionNode.GetImageForLocalVariable(), var.Name, debugger.GetExpression(this.project.Nom + ".Variables." + var.Name));
                }
                foreach (string var in this.project.Parametres)
                {
                    yield return new ExpressionNode(ExpressionNode.GetImageForParameterOfProject(), var, debugger.GetExpression(this.project.Nom + ".My.MySettingsProperty.Settings." + var));
                }
            }
            if (stackFrame.Thread.CurrentException != null)
            {
                //yield return new ExpressionNode(null, "__exception", new IdentifierExpression("__exception"));
            }
        }
    }
}