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
//     <version>$Revision: 5544 $</version>
// </file>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

using VelerSoftware.SZC35.Rendering;
using VelerSoftware.SZC35.Utils;

namespace VelerSoftware.SZC35.Editing
{
	sealed class CaretLayer : Layer
	{
		bool isVisible;
		Rect caretRectangle;
		
		DispatcherTimer caretBlinkTimer = new DispatcherTimer();
		bool blink;
		
		public CaretLayer(TextView textView) : base(textView, KnownLayer.Caret)
		{
			this.IsHitTestVisible = false;
			caretBlinkTimer.Tick += new EventHandler(caretBlinkTimer_Tick);
		}

		void caretBlinkTimer_Tick(object sender, EventArgs e)
		{
			blink = !blink;
			InvalidateVisual();
		}
		
		public void Show(Rect caretRectangle)
		{
			this.caretRectangle = caretRectangle;
			this.isVisible = true;
			InvalidateVisual();
			StartBlinkAnimation();
		}
		
		public void Hide()
		{
			if (isVisible) {
				isVisible = false;
				StopBlinkAnimation();
				InvalidateVisual();
			}
		}
		
		void StartBlinkAnimation()
		{
			TimeSpan blinkTime = Win32.CaretBlinkTime;
			if (blinkTime.TotalMilliseconds >= 0) {
				blink = false;
				caretBlinkTimer_Tick(null, null);
				caretBlinkTimer.Interval = blinkTime;
				caretBlinkTimer.Start();
			}
		}
		
		void StopBlinkAnimation()
		{
			caretBlinkTimer.Stop();
		}
		
		internal Brush CaretBrush;
		
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (isVisible && blink) {
				Brush caretBrush = this.CaretBrush;
				if (caretBrush == null)
					caretBrush = (Brush)textView.GetValue(TextBlock.ForegroundProperty);
				Rect r = new Rect(caretRectangle.X - textView.HorizontalOffset,
				                  caretRectangle.Y - textView.VerticalOffset,
				                  caretRectangle.Width,
				                  caretRectangle.Height);
				drawingContext.DrawRectangle(caretBrush, null, PixelSnapHelpers.Round(r, PixelSnapHelpers.GetPixelSize(this)));
			}
		}
	}
}
