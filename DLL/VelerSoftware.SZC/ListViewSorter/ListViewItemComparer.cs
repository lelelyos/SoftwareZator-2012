// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System.Windows.Forms;
using VelerSoftware.SZC.ListViewStored.Collections;

namespace VelerSoftware.SZC.ListViewStored
{
    /// <summary>
    /// Compares items of a the specified column of a ListView.
    /// </summary>
    internal class ListViewItemComparer : SortComparerBase
    {
        private int col = 0;
        private ISortComparer comparer = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ListViewItemComparer()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="comparer"></param>
        public ListViewItemComparer(ISortComparer comparer)
        {
            col = 0;
            this.comparer = comparer;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="column"></param>
        public ListViewItemComparer(int column)
        {
            col = column;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="comparer"></param>
        public ListViewItemComparer(int column, ISortComparer comparer)
        {
            col = column;
            this.comparer = comparer;
        }

        public ISortComparer Comparer
        {
            get { return comparer; }
            set { comparer = value; }
        }

        /// <summary>
        /// Compare!
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(object x, object y)
        {
            string x1 = ((ListViewItem)x).SubItems[col].Text;
            string y1 = ((ListViewItem)y).SubItems[col].Text;

            if (comparer == null)
            {
                // Default is the StringComparer
                ISortComparer c = new VelerSoftware.SZC.ListViewStored.Collections.NameComparer();
                c.SortOrder = sortorder;
                return c.Compare(x1, y1);
            }
            else
            {
                comparer.SortOrder = sortorder;
                return comparer.Compare(x1, y1);
            }
        }
    }
}