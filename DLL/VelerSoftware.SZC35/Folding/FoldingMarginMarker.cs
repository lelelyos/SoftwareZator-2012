// *****************************************************************************
// 
//  � Veler Software 2012. All rights reserved.
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
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using VelerSoftware.SZC35.Rendering;
using VelerSoftware.SZC35.Utils;

namespace VelerSoftware.SZC35.Folding
{
	sealed class FoldingMarginMarker : UIElement
	{
		internal VisualLine VisualLine;
		internal FoldingSection FoldingSection;
		
		bool isExpanded;
		
		public bool IsExpanded {
			get { return isExpanded; }
			set {
				if (isExpanded != value) {
					isExpanded = value;
					InvalidateVisual();
				}
				if (FoldingSection != null)
					FoldingSection.IsFolded = !value;
			}
		}
		
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			base.OnMouseDown(e);
			if (!e.Handled) {
				if (e.ChangedButton == MouseButton.Left) {
					IsExpanded = !IsExpanded;
					e.Handled = true;
				}
			}
		}
		
		const double MarginSizeFactor = 0.7;
		
		protected override Size MeasureCore(Size availableSize)
		{
			double size = MarginSizeFactor * FoldingMargin.SizeFactor * (double)GetValue(TextBlock.FontSizeProperty);
			size = PixelSnapHelpers.RoundToOdd(size, PixelSnapHelpers.GetPixelSize(this).Width);
			return new Size(size, size);
		}
		
		protected override void OnRender(DrawingContext drawingContext)
		{
			Pen blackPen = new Pen(Brushes.Black, 1);
			blackPen.StartLineCap = PenLineCap.Square;
			blackPen.EndLineCap = PenLineCap.Square;
			Size pixelSize = PixelSnapHelpers.GetPixelSize(this);
			Rect rect = new Rect(pixelSize.Width / 2,
			                     pixelSize.Height / 2,
			                     this.RenderSize.Width - pixelSize.Width,
			                     this.RenderSize.Height - pixelSize.Height);
			drawingContext.DrawRectangle(Brushes.White,
			                             IsMouseDirectlyOver ? blackPen : new Pen(Brushes.Gray, 1),
			                             rect);
			double middleX = rect.Left + rect.Width / 2;
			double middleY = rect.Top + rect.Height / 2;
			double space = PixelSnapHelpers.Round(rect.Width / 8, pixelSize.Width) + pixelSize.Width;
			drawingContext.DrawLine(blackPen,
			                        new Point(rect.Left + space, middleY),
			                        new Point(rect.Right - space, middleY));
			if (!isExpanded) {
				drawingContext.DrawLine(blackPen,
				                        new Point(middleX, rect.Top + space),
				                        new Point(middleX, rect.Bottom - space));
			}
		}
		
		protected override void OnIsMouseDirectlyOverChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnIsMouseDirectlyOverChanged(e);
			InvalidateVisual();
		}
	}
}
