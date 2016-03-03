// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.TreeModel
{
    public class IListNode : TreeNode
    {
        Expression targetObject;
        int count;

        public IListNode(Expression targetObject)
        {
            this.targetObject = targetObject;

            this.Name = "IList";
            this.count = Utils.GetIListCount(this.targetObject);
            this.ChildNodes = Utils.LazyGetItemsOfIList(this.targetObject);
        }

        public override bool HasChildNodes
        {
            get { return this.count > 0; }
        }
    }
}