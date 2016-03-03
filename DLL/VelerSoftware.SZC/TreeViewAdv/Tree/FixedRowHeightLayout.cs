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
using System.Drawing;

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    internal class FixedRowHeightLayout : IRowLayout
    {
        private TreeViewAdv _treeView;

        public FixedRowHeightLayout(TreeViewAdv treeView, int rowHeight)
        {
            _treeView = treeView;
            PreferredRowHeight = rowHeight;
        }

        private int _rowHeight;

        public int PreferredRowHeight
        {
            get { return _rowHeight; }
            set { _rowHeight = value; }
        }

        public Rectangle GetRowBounds(int rowNo)
        {
            return new Rectangle(0, rowNo * _rowHeight, 0, _rowHeight);
        }

        public int PageRowCount
        {
            get
            {
                return Math.Max((_treeView.DisplayRectangle.Height - _treeView.ColumnHeaderHeight) / _rowHeight, 0);
            }
        }

        public int CurrentPageSize
        {
            get
            {
                return PageRowCount;
            }
        }

        public int GetRowAt(Point point)
        {
            point = new Point(point.X, point.Y + (_treeView.FirstVisibleRow * _rowHeight) - _treeView.ColumnHeaderHeight);
            return point.Y / _rowHeight;
        }

        public int GetFirstRow(int lastPageRow)
        {
            return Math.Max(0, lastPageRow - PageRowCount + 1);
        }

        public void ClearCache()
        {
        }
    }
}