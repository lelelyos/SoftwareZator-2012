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

namespace VelerSoftware.SZC.TreeViewAdv.Tree
{
    public enum DrawSelectionMode
    {
        None, Active, Inactive, FullRowSelect
    }

    public enum TreeSelectionMode
    {
        Single, Multi, MultiSameParent
    }

    public enum NodePosition
    {
        Inside, Before, After
    }

    public enum VerticalAlignment
    {
        Top, Bottom, Center
    }

    public enum IncrementalSearchMode
    {
        None, Standard, Continuous
    }

    [Flags]
    public enum GridLineStyle
    {
        None = 0,
        Horizontal = 1,
        Vertical = 2,
        HorizontalAndVertical = 3
    }

    public enum ImageScaleMode
    {
        /// <summary>
        /// Don't scale
        /// </summary>
        Clip,
        /// <summary>
        /// Scales image to fit the display rectangle, aspect ratio is not fixed.
        /// </summary>
        Fit,
        /// <summary>
        /// Scales image down if it is larger than display rectangle, taking aspect ratio into account
        /// </summary>
        ScaleDown,
        /// <summary>
        /// Scales image up if it is smaller than display rectangle, taking aspect ratio into account
        /// </summary>
        ScaleUp,
        /// <summary>
        /// Scales image to match the display rectangle, taking aspect ratio into account
        /// </summary>
        AlwaysScale,
    }
}