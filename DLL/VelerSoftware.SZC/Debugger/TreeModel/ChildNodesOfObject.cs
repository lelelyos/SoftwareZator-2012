// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using VelerSoftware.SZC.Debugger.Core;
using VelerSoftware.SZC.Debugger.Debugger;
using VelerSoftware.SZC.Debugger.Debugger.MetaData;
using VelerSoftware.SZC.Debugger.Visualizer.Utils;
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    public partial class Utils
    {
        public static IEnumerable<TreeNode> LazyGetChildNodesOfObject(Expression targetObject, DebugType shownType)
        {
            MemberInfo[] publicStatic = shownType.GetFieldsAndNonIndexedProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            MemberInfo[] publicInstance = shownType.GetFieldsAndNonIndexedProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MemberInfo[] nonPublicStatic = shownType.GetFieldsAndNonIndexedProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);
            MemberInfo[] nonPublicInstance = shownType.GetFieldsAndNonIndexedProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            DebugType baseType = (DebugType)shownType.BaseType;
            if (baseType != null)
            {
                if (Variables.Langue == "en")
                {
                    yield return new TreeNode(
                    Properties.Resources._namespace,
                    StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_BaseClass_EN),
                    baseType.Name,
                    baseType.FullName,
                    baseType.FullName == "System.Object" ? null : Utils.LazyGetChildNodesOfObject(targetObject, baseType)
                );
                }
                else
                {
                    yield return new TreeNode(
                    Properties.Resources._namespace,
                    StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_BaseClass),
                    baseType.Name,
                    baseType.FullName,
                    baseType.FullName == "System.Object" ? null : Utils.LazyGetChildNodesOfObject(targetObject, baseType)
                );
                }
            }

            // if (nonPublicInstance.Length > 0) {
            //     if (Variables.Langue == "en")
            //     {
            //         yield return new TreeNode(
            //             null,
            //             StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_NonPublicMembers_EN),
            //             string.Empty,
            //             string.Empty,
            //             Utils.LazyGetMembersOfObject(targetObject, nonPublicInstance)
            //         );
            //     }
            //     else
            //     {
            //         yield return new TreeNode(
            //             null,
            //             StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_NonPublicMembers),
            //             string.Empty,
            //             string.Empty,
            //             Utils.LazyGetMembersOfObject(targetObject, nonPublicInstance)
            //         );
            //     }
            // }
            //
            // if (publicStatic.Length > 0 || nonPublicStatic.Length > 0) {
            // 	IEnumerable<TreeNode> childs = Utils.LazyGetMembersOfObject(targetObject, publicStatic);
            // 	if (nonPublicStatic.Length > 0) {
            //         if (Variables.Langue == "en")
            //         {
            //             TreeNode nonPublicStaticNode = new TreeNode(
            //                 null,
            //                 StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_NonPublicStaticMembers_EN),
            //                 string.Empty,
            //                 string.Empty,
            //                 Utils.LazyGetMembersOfObject(targetObject, nonPublicStatic)
            //             );
            //             childs = Utils.PrependNode(nonPublicStaticNode, childs);
            //         }
            //         else
            //         {
            //             TreeNode nonPublicStaticNode = new TreeNode(
            //                 null,
            //                 StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_NonPublicStaticMembers),
            //                 string.Empty,
            //                 string.Empty,
            //                 Utils.LazyGetMembersOfObject(targetObject, nonPublicStatic)
            //             );
            //             childs = Utils.PrependNode(nonPublicStaticNode, childs);
            //         }
            // 	}
            //     if (Variables.Langue == "en")
            //     {
            //         yield return new TreeNode(
            //             null,
            //             StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_StaticMembers_EN),
            //             string.Empty,
            //             string.Empty,
            //             childs
            //         );
            //     }
            //     else
            //     {
            //         yield return new TreeNode(
            //             null,
            //             StringParser.Parse(VelerSoftware.SZC.Properties.Resources.MainWindow_Windows_Debug_LocalVariables_StaticMembers),
            //             string.Empty,
            //             string.Empty,
            //             childs
            //         );
            //     }
            // }

            DebugType iListType = (DebugType)shownType.GetInterface(typeof(IList).FullName);
            if (iListType != null)
            {
                yield return new IListNode(targetObject);
            }
            else
            {
                DebugType iEnumerableType, itemType;
                if (shownType.ResolveIEnumerableImplementation(out iEnumerableType, out itemType))
                {
                    yield return new IEnumerableNode(targetObject, itemType);
                }
            }

            foreach (TreeNode node in LazyGetMembersOfObject(targetObject, publicInstance))
            {
                yield return node;
            }
        }

        public static IEnumerable<TreeNode> LazyGetMembersOfObject(Expression expression, MemberInfo[] members)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (MemberInfo memberInfo in members)
            {
                nodes.Add(new ExpressionNode(ExpressionNode.GetImageForMember((IDebugMemberInfo)memberInfo), memberInfo.Name, expression.AppendMemberReference((IDebugMemberInfo)memberInfo)));
            }
            nodes.Sort();
            return nodes;
        }

        public static IEnumerable<TreeNode> LazyGetItemsOfIList(Expression targetObject)
        {
            // This is needed for expanding IEnumerable<T>
            targetObject = new CastExpression(
                new TypeReference(typeof(IList).FullName),
                targetObject,
                CastType.Cast
            );
            int count = 0;
            GetValueException error = null;
            try
            {
                count = GetIListCount(targetObject);
            }
            catch (GetValueException e)
            {
                // Cannot yield a value in the body of a catch clause (CS1631)
                error = e;
            }
            if (error != null)
            {
                yield return new TreeNode(null, "(error)", error.Message, null, null);
            }
            else if (count == 0)
            {
                yield return new TreeNode(null, "(empty)", null, null, null);
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    yield return new ExpressionNode(ExpressionNode.GetImageForArrayIndexer(), "[" + i + "]", targetObject.AppendIndexer(i));
                }
            }
        }

        /// <summary>
        /// Evaluates System.Collections.ICollection.Count property on given object.
        /// </summary>
        /// <exception cref="GetValueException">Evaluating System.Collections.ICollection.Count on targetObject failed.</exception>
        public static int GetIListCount(Expression targetObject)
        {
            Value list = targetObject.Evaluate(WindowsDebugger.CurrentProcess);
            var iCollectionInterface = list.Type.GetInterface(typeof(ICollection).FullName);
            if (iCollectionInterface == null)
                throw new GetValueException(targetObject, targetObject.PrettyPrint() + " does not implement System.Collections.ICollection");
            PropertyInfo countProperty = iCollectionInterface.GetProperty("Count");
            // Do not get string representation since it can be printed in hex
            return (int)list.GetPropertyValue(countProperty).PrimitiveValue;
        }

        public static IEnumerable<TreeNode> PrependNode(TreeNode node, IEnumerable<TreeNode> rest)
        {
            yield return node;
            if (rest != null)
            {
                foreach (TreeNode absNode in rest)
                {
                    yield return absNode;
                }
            }
        }
    }
}