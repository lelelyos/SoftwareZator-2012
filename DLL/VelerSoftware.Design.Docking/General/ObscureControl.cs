// *****************************************************************************
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
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using VelerSoftware.Design.Toolkit;

namespace VelerSoftware.Design.Docking
{
    internal class ObscureControl : Control
    {
        #region Protected
        /// <summary>
        /// Raises the PaintBackground event.
        /// </summary>
        /// <param name="e">An PaintEventArgs containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // We do nothing, so the area underneath shows through
        }

        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">An PaintEventArgs containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // We do nothing, so the area underneath shows through
        }
        #endregion
    }
}
