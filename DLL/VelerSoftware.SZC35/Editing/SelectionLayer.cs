// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision: 5234 $</version>
// </file>

using System;
using System.Windows;
using System.Windows.Media;

using VelerSoftware.SZC35.Rendering;

namespace VelerSoftware.SZC35.Editing
{
	sealed class SelectionLayer : Layer, IWeakEventListener
	{
		readonly TextArea textArea;
		
		public SelectionLayer(TextArea textArea) : base(textArea.TextView, KnownLayer.Selection)
		{
			this.IsHitTestVisible = false;
			
			this.textArea = textArea;
			TextViewWeakEventManager.VisualLinesChanged.AddListener(textView, this);
			TextViewWeakEventManager.ScrollOffsetChanged.AddListener(textView, this);
		}
		
		bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
		{
			if (managerType == typeof(TextViewWeakEventManager.VisualLinesChanged)
			    || managerType == typeof(TextViewWeakEventManager.ScrollOffsetChanged))
			{
				InvalidateVisual();
				return true;
			}
			return false;
		}
		
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			
			BackgroundGeometryBuilder geoBuilder = new BackgroundGeometryBuilder();
			geoBuilder.AlignToMiddleOfPixels = true;
			geoBuilder.CornerRadius = textArea.SelectionCornerRadius;
			foreach (var segment in textArea.Selection.Segments) {
				geoBuilder.AddSegment(textView, segment);
			}
			Geometry geometry = geoBuilder.CreateGeometry();
			if (geometry != null) {
				drawingContext.DrawGeometry(textArea.SelectionBrush, textArea.SelectionBorder, geometry);
			}
		}
	}
}
