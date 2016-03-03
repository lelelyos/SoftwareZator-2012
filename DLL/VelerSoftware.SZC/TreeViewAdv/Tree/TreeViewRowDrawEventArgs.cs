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
using System.Windows.Forms;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public class TreeViewRowDrawEventArgs : PaintEventArgs
    {
        TreeNodeAdv _node;
        DrawContext _context;
        int _row;
        Rectangle _rowRect;

        public TreeViewRowDrawEventArgs(Graphics graphics, Rectangle clipRectangle, TreeNodeAdv node, DrawContext context, int row, Rectangle rowRect)
            : base(graphics, clipRectangle)
        {
            _node = node;
            _context = context;
            _row = row;
            _rowRect = rowRect;
        }

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public DrawContext Context
        {
            get { return _context; }
        }

        public int Row
        {
            get { return _row; }
        }

        public Rectangle RowRect
        {
            get { return _rowRect; }
        }
    }
}