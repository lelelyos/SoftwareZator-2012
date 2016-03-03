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
using System.Collections.Generic;
using System.Windows.Forms;
using VelerSoftware.SZC.ListViewStored.Collections;

namespace VelerSoftware.SZC.ListViewStored
{
    /// <summary>
    /// Sorts a ListView by arbitray columns.
    /// </summary>
    public class ListViewSorter : IDisposable
    {
        #region Members

        private Dictionary<string, ISortComparer> comparercollection = new Dictionary<string, ISortComparer>();
        private int lastsortcolumn = -1;
        private VelerSoftware.SZC.ListViewStored.Collections.SortOrder sortorder = VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Descending;
        private ListView listview = null;
        private string imagekeyup = "up";  // Default, but mostly not correct
        private string imagekeydown = "down"; // Default, but mostly not correct

        #endregion Members

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        public ListViewSorter()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="listView"></param>
        public ListViewSorter(ListView listView)
        {
            this.ListView = listView;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the ListView.
        /// </summary>
        public ListView ListView
        {
            get { return listview; }
            set
            {
                // Unregister previous EventHandler
                if (this.listview != null)
                    this.listview.ColumnClick -= this.listview_ColumnClick;

                listview = value;

                // Register EventHandler
                if (listview != null)
                    this.listview.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listview_ColumnClick);
            }
        }

        /// <summary>
        /// Gets or sets the Collection of ISortComparers.
        /// </summary>
        public Dictionary<string, ISortComparer> ColumnComparerCollection
        {
            get { return comparercollection; }
            set { comparercollection = value; }
        }

        /// <summary>
        /// Key of the arrow-up image in the ListViews SmallImageList.
        /// </summary>
        public string ImageKeyUp
        {
            get { return imagekeyup; }
            set { imagekeyup = value; }
        }

        /// <summary>
        /// Key of the arrow-down image in the ListViews SmallImageList.
        /// </summary>
        public string ImageKeyDown
        {
            get { return imagekeydown; }
            set { imagekeydown = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Handles the ListViews ColumnClick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sort(e.Column);
        }

        /// <summary>
        /// Sorts the ListView by the specified column.
        /// </summary>
        /// <param name="column"></param>
        public void Sort(int column)
        {
            // Toggle ASC and DESC
            if (column == lastsortcolumn)
            {
                if (sortorder == VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Ascending)
                    sortorder = VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Descending;
                else
                    sortorder = VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Ascending;
            }
            else
            {
                sortorder = VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Ascending;
            }

            lastsortcolumn = column;

            // Get the columns comparer (if the column ist registered use the StringComparer by default)
            ISortComparer c = null;
            if (comparercollection.ContainsKey(this.ListView.Columns[column].Text))
                c = comparercollection[this.ListView.Columns[column].Text];
            else
                c = new VelerSoftware.SZC.ListViewStored.Collections.NameComparer();

            // Initialize the ListViewItemComparer
            ListViewItemComparer lvc = new ListViewItemComparer(column, c);
            lvc.SortOrder = sortorder;
            this.ListView.ListViewItemSorter = lvc;

            // Sort!
            this.ListView.Sort();

            // Set ColumnHeaders image
            SetImage(column, sortorder);
        }

        /// <summary>
        /// Sets the image of the sorted ColumnHeader.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="sortorder"></param>
        protected void SetImage(int column, VelerSoftware.SZC.ListViewStored.Collections.SortOrder sortorder)
        {
            // Nothing to do
            if (this.listview.SmallImageList == null)
                return;

            string key = String.Empty;

            foreach (ColumnHeader ch in this.ListView.Columns)
            {
                ch.ImageKey = null;
            }

            if (sortorder == VelerSoftware.SZC.ListViewStored.Collections.SortOrder.Ascending)
                key = imagekeyup;
            else
                key = imagekeydown;

            if (key != null && this.listview.SmallImageList.Images.ContainsKey(key))
            {
                this.ListView.Columns[column].ImageKey = key;
            }
        }

        /// <summary>
        /// Clean up.
        /// </summary>
        public void Dispose()
        {
            // Make sure there is no registered EventHandler left
            if (this.listview != null)
                this.listview.ColumnClick -= this.listview_ColumnClick;

            comparercollection.Clear();
        }

        #endregion Methods
    }
}