// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Drawing;

namespace VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls
{
    public class NodeStateIcon : NodeIcon
    {
        private static Image MakeTransparent(Bitmap bitmap)
        {
            bitmap.MakeTransparent(bitmap.GetPixel(0, 0));
            return bitmap;
        }

        protected override Image GetIcon(TreeNodeAdv node)
        {
            Image icon = base.GetIcon(node);
            if (icon != null)
                return icon;
            else
                return new Bitmap(16, 16);
        }
    }
}