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
using System.Collections;

namespace VelerSoftware.SZC.TreeViewComparer
{
    public class TreeViewComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return String.Compare(((System.Windows.Forms.TreeNode)x).Text, ((System.Windows.Forms.TreeNode)y).Text);
        }
    }
}