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
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using VelerSoftware.Design.Toolkit;

namespace VelerSoftware.Design.Ribbon
{
	internal class KryptonRibbonGroupContainerCollectionEditor : CollectionEditor
	{
		/// <summary>
        /// Initialize a new instance of the KryptonRibbonGroupTopCollectionEditor class.
		/// </summary>
        public KryptonRibbonGroupContainerCollectionEditor()
            : base(typeof(KryptonRibbonGroupContainerCollection))
		{
		}

		/// <summary>
		/// Gets the data types that this collection editor can contain. 
		/// </summary>
		/// <returns>An array of data types that this collection can contain.</returns>
		protected override Type[] CreateNewItemTypes()
		{
            return new Type[] { typeof(KryptonRibbonGroupLines),
                                typeof(KryptonRibbonGroupTriple),
                                typeof(KryptonRibbonGroupSeparator) };
		}
	}
}
