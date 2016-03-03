// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using VelerSoftware.SZC.Debugger.Debugger.MetaData;
using VelerSoftware.SZC.Debugger.TreeModel.Visualizer.Utils;
using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    /// <summary>
    /// IEnumerable node in the variable tree.
    /// </summary>
    public class IEnumerableNode : TreeNode
    {
        Expression targetObject;
        Expression debugListExpression;

        public IEnumerableNode(Expression targetObject, DebugType itemType)
        {
            this.targetObject = targetObject;

            this.Name = "IEnumerable";
            this.Text = "Expanding will enumerate the IEnumerable";
            DebugType debugListType;
            this.debugListExpression = DebuggerHelpers.CreateDebugListExpression(targetObject, itemType, out debugListType);
            this.ChildNodes = Utils.LazyGetItemsOfIList(this.debugListExpression);
        }
    }
}