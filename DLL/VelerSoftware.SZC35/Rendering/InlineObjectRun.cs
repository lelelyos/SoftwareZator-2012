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
//     <version>$Revision: 4492 $</version>
// </file>

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

namespace VelerSoftware.SZC35.Rendering
{
	/// <summary>
	/// A inline UIElement in the document.
	/// </summary>
	public class InlineObjectElement : VisualLineElement
	{
		/// <summary>
		/// Gets the inline element that is displayed.
		/// </summary>
		public UIElement Element { get; private set; }
		
		/// <summary>
		/// Creates a new InlineObjectElement.
		/// </summary>
		/// <param name="documentLength">The length of the element in the document. Must be non-negative.</param>
		/// <param name="element">The element to display.</param>
		public InlineObjectElement(int documentLength, UIElement element)
			: base(1, documentLength)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			this.Element = element;
		}
		
		/// <inheritdoc/>
		public override TextRun CreateTextRun(int startVisualColumn, ITextRunConstructionContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			
			// remove inline object if its already added, can happen e.g. when recreating textrun for word-wrapping
			// TODO: certainly the text view should handle this internally? external code might want to use InlineObjectRun,
			// but doesn't have access to textLayer.RemoveInlineObject
			context.TextView.textLayer.RemoveInlineObject(this.Element);
			
			return new InlineObjectRun(1, this.TextRunProperties, this.Element);
		}
	}
	
	/// <summary>
	/// A text run with an embedded UIElement.
	/// </summary>
	public class InlineObjectRun : TextEmbeddedObject
	{
		UIElement element;
		int length;
		TextRunProperties properties;
		
		/// <summary>
		/// Creates a new InlineObjectRun instance.
		/// </summary>
		/// <param name="length">The length of the TextRun.</param>
		/// <param name="properties">The <see cref="TextRunProperties"/> to use.</param>
		/// <param name="element">The <see cref="UIElement"/> to display.</param>
		public InlineObjectRun(int length, TextRunProperties properties, UIElement element)
		{
			if (length <= 0)
				throw new ArgumentOutOfRangeException("length", length, "Value must be positive");
			if (properties == null)
				throw new ArgumentNullException("properties");
			if (element == null)
				throw new ArgumentNullException("element");
			
			this.length = length;
			this.properties = properties;
			this.element = element;
		}
		
		/// <summary>
		/// Gets the element displayed by the InlineObjectRun.
		/// </summary>
		public UIElement Element {
			get { return element; }
		}
		
		/// <summary>
		/// Gets the VisualLine that contains this object. This property is only available after the object
		/// was added to the text view.
		/// </summary>
		public VisualLine VisualLine { get; internal set; }
		
		/// <inheritdoc/>
		public override LineBreakCondition BreakBefore {
			get { return LineBreakCondition.BreakDesired; }
		}
		
		/// <inheritdoc/>
		public override LineBreakCondition BreakAfter {
			get { return LineBreakCondition.BreakDesired; }
		}
		
		/// <inheritdoc/>
		public override bool HasFixedSize {
			get { return true; }
		}
		
		/// <inheritdoc/>
		public override CharacterBufferReference CharacterBufferReference {
			get { return new CharacterBufferReference(); }
		}
		
		/// <inheritdoc/>
		public override int Length {
			get { return length; }
		}
		
		/// <inheritdoc/>
		public override TextRunProperties Properties {
			get { return properties; }
		}
		
		/// <inheritdoc/>
		public override TextEmbeddedObjectMetrics Format(double remainingParagraphWidth)
		{
			Size size = element.DesiredSize;
			double baseline = TextBlock.GetBaselineOffset(element);
			if (double.IsNaN(baseline))
				baseline = size.Height;
			return new TextEmbeddedObjectMetrics(size.Width, size.Height, baseline);
		}
		
		/// <inheritdoc/>
		public override Rect ComputeBoundingBox(bool rightToLeft, bool sideways)
		{
			if (this.element.IsArrangeValid) {
				double baseline = TextBlock.GetBaselineOffset(element);
				if (double.IsNaN(baseline))
					baseline = element.DesiredSize.Height;
				return new Rect(new Point(0, -baseline), element.DesiredSize);
			} else {
				return Rect.Empty;
			}
		}
		
		/// <inheritdoc/>
		public override void Draw(DrawingContext drawingContext, Point origin, bool rightToLeft, bool sideways)
		{
		}
	}
}
