// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public interface IToolTipProvider
    {
        string GetToolTip(TreeNodeAdv node, NodeControl nodeControl);
    }
}