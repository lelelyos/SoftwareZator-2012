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
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Diagnostics;
using VelerSoftware.Design.Toolkit;
using VelerSoftware.Design.Navigator;
using VelerSoftware.Design.Workspace;

namespace VelerSoftware.Design.Docking
{
    /// <summary>
    /// Extends the KryptonSeparator so work between dockspace entries on a control edge.
    /// </summary>
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [DesignTimeVisible(false)]
    public class KryptonDockspaceSeparator : KryptonSeparator
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonDockspaceSeparator class.
        /// </summary>
        /// <param name="edge">Docking edge the separator is against.</param>
        /// <param name="opposite">Should the separator be docked against the opposite edge.</param>
        public KryptonDockspaceSeparator(DockingEdge edge, bool opposite)
        {
            // Setup docking specific settings for the separator
            Dock = DockingHelper.DockStyleFromDockEdge(edge, opposite); 
            Orientation = DockingHelper.OrientationFromDockEdge(edge);
            SeparatorStyle = SeparatorStyle.LowProfile;
        }

        /// <summary>
        /// Gets a string representation of the class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "KryptonDockspaceSeparator " + Dock.ToString() + " " + Orientation.ToString();
        }
        #endregion
    }
}
