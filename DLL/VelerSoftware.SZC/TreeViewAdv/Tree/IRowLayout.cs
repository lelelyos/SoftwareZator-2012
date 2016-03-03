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

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    internal interface IRowLayout
    {
        int PreferredRowHeight
        {
            get;
            set;
        }

        int PageRowCount
        {
            get;
        }

        int CurrentPageSize
        {
            get;
        }

        Rectangle GetRowBounds(int rowNo);

        int GetRowAt(Point point);

        int GetFirstRow(int lastPageRow);

        void ClearCache();
    }
}