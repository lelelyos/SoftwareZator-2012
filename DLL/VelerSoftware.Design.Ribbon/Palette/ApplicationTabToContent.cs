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
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using VelerSoftware.Design.Toolkit;

namespace VelerSoftware.Design.Ribbon
{
    internal class ApplicationTabToContent : RibbonToContent
    {
        #region Instance Fields
        private KryptonRibbon _ribbon;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ApplicationTabToContent class.
        /// </summary>
        /// <param name="ribbon">Reference to owning ribbon control..</param>
        /// <param name="ribbonGeneral">Source for general ribbon settings.</param>
        public ApplicationTabToContent(KryptonRibbon ribbon,
                                       PaletteRibbonGeneral ribbonGeneral)
            : base(ribbonGeneral)
        {
            _ribbon = ribbon;
        }
        #endregion
        
        #region IPaletteContent
        /// <summary>
        /// Gets the first color for the short text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentShortTextColor1(PaletteState state)
        {
            return _ribbon.RibbonAppButton.AppButtonTextColor;
        }

        /// <summary>
        /// Gets the second color for the short text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentShortTextColor2(PaletteState state)
        {
            return _ribbon.RibbonAppButton.AppButtonTextColor;
        }

        /// <summary>
        /// Gets the first color for the long text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentLongTextColor1(PaletteState state)
        {
            return _ribbon.RibbonAppButton.AppButtonTextColor;
        }

        /// <summary>
        /// Gets the second color for the long text.
        /// </summary>
        /// <param name="state">Palette value should be applicable to this state.</param>
        /// <returns>Color value.</returns>
        public override Color GetContentLongTextColor2(PaletteState state)
        {
            return _ribbon.RibbonAppButton.AppButtonTextColor;
        }
        #endregion
    }
}
