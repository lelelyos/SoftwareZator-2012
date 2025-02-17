﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2010. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 17/267 Nepean Hwy, 
//  Seaford, Vic 3198, Australia and are supplied subject to licence terms.
// 
//  Version 4.3.1.0 	www.ComponentFactory.com
// *****************************************************************************

using System;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel; 
using VelerSoftware.Design.Toolkit;
using VelerSoftware.Design.Navigator;
using VelerSoftware.Design.Workspace;

namespace VelerSoftware.Design.Docking
{
	/// <summary>
    /// Event arguments for events that need a page and context menu.
	/// </summary>
	public class ContextPageEventArgs : CancelEventArgs
	{
		#region Instance Fields
        private KryptonPage _page;
        private KryptonContextMenu _contextMenu;
		#endregion

		#region Identity
		/// <summary>
        /// Initialize a new instance of the ContextPageEventArgs class.
		/// </summary>
        /// <param name="page">Page associated with the context menu.</param>
        /// <param name="contextMenu">Context menu that can be customized.</param>
        /// <param name="cancel">Initial value for the cancel property.</param>
        public ContextPageEventArgs(KryptonPage page, 
                                    KryptonContextMenu contextMenu,
                                    bool cancel)
            : base(cancel)
		{
            _page = page;
            _contextMenu = contextMenu;
		}
        #endregion

		#region Public
        /// <summary>
        /// Gets access to page associated with the context menu.
        /// </summary>
        public KryptonPage Page
        {
            get { return _page; }
        }

        /// <summary>
        /// Gets access to context menu that can be customized.
        /// </summary>
        public KryptonContextMenu KryptonContextMenu
        {
            get { return _contextMenu; }
        }
        #endregion
	}
}
