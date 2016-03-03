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
	internal class KryptonRibbonQATButtonCollectionEditor : CollectionEditor
	{
		/// <summary>
        /// Initialize a new instance of the KryptonRibbonQATButtonCollectionEditor class.
		/// </summary>
        public KryptonRibbonQATButtonCollectionEditor()
            : base(typeof(KryptonRibbonQATButtonCollection))
		{
		}

		/// <summary>
		/// Gets the data types that this collection editor can contain. 
		/// </summary>
		/// <returns>An array of data types that this collection can contain.</returns>
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[] { typeof(KryptonRibbonQATButton) };
		}

		/// <summary>
		/// Sets the specified array as the items of the collection.
		/// </summary>
		/// <param name="editValue">The collection to edit.</param>
		/// <param name="value">An array of objects to set as the collection items.</param>
		/// <returns>The newly created collection object.</returns>
		protected override object SetItems(object editValue, object[] value)
		{
			// Cast the context into the expected control type
            KryptonRibbon ribbon = (KryptonRibbon)Context.Instance;

			// Suspend changes until collection has been updated
            if (ribbon != null)
                ribbon.SuspendLayout();

			// Let base class update the collection
			object ret = base.SetItems(editValue, value);

            if (ribbon != null)
                ribbon.ResumeLayout(true);

			return ret;
		}
	}
}
