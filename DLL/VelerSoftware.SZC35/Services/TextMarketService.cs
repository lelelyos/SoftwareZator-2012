﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

using VelerSoftware.SZC35.Document;
using VelerSoftware.SZC35.Rendering;

namespace VelerSoftware.SZC35.Services
{
    
	/// <summary>
	/// Handles the text markers for a code editor.
	/// </summary>
	public sealed class TextMarkerService : DocumentColorizingTransformer, IBackgroundRenderer, ITextMarkerService
	{
		readonly TextEditor codeEditor;
		TextSegmentCollection<TextMarker> markers;

        public TextMarkerService(TextEditor codeEditor)
		{
			if (codeEditor == null)
				throw new ArgumentNullException("codeEditor");
			this.codeEditor = codeEditor;
			codeEditor.DocumentChanged += codeEditor_DocumentChanged;
			codeEditor_DocumentChanged(null, null);
		}
		
		#region Document Changed - recreate marker collection
		void codeEditor_DocumentChanged(object sender, EventArgs e)
		{
			if (markers != null) {
				foreach (TextMarker m in markers.ToArray()) {
					m.Delete();
				}
			}
			if (codeEditor.Document == null)
				markers = null;
			else
				markers = new TextSegmentCollection<TextMarker>(codeEditor.Document);
		}
		#endregion
		
		#region ITextMarkerService
		public ITextMarker Create(int startOffset, int length)
		{
			int textLength = codeEditor.Document.TextLength;
			if (startOffset < 0 || startOffset > textLength)
				throw new ArgumentOutOfRangeException("startOffset", startOffset, "Value must be between 0 and " + textLength);
			if (length < 0 || startOffset + length > textLength)
				throw new ArgumentOutOfRangeException("length", length, "length must not be negative and startOffset+length must not be after the end of the document");
			
			TextMarker m = new TextMarker(this, startOffset, length); 
			markers.Add(m);
			// no need to mark segment for redraw: the text marker is invisible until a property is set
			return m;
		}
		
		public IEnumerable<ITextMarker> GetMarkersAtOffset(int offset)
		{
			return markers.FindSegmentsContaining(offset);
		}
		
		public IEnumerable<ITextMarker> TextMarkers {
			get { return markers; }
		}
		
		public void RemoveAll(Predicate<ITextMarker> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException("predicate");
			foreach (TextMarker m in markers.ToArray()) {
				if (predicate(m))
					Remove(m);
			}
		}

        public void RemoveAll()
        {
            foreach (TextMarker m in markers.ToArray())
            {
                Remove(m);
            }
        }
		
		public void Remove(ITextMarker marker)
		{
			if (marker == null)
				throw new ArgumentNullException("marker");
			TextMarker m = marker as TextMarker;
			if (markers.Remove(m)) {
				Redraw(m);
				m.OnDeleted();
			}
		}
		
		/// <summary>
		/// Redraws the specified text segment.
		/// </summary>
		internal void Redraw(ISegment segment)
		{
			codeEditor.TextArea.TextView.Redraw(segment, DispatcherPriority.Normal);
		}
		#endregion
		
		#region DocumentColorizingTransformer
		protected override void ColorizeLine(DocumentLine line)
		{
			if (markers == null)
				return;
			int lineStart = line.Offset;
			int lineEnd = lineStart + line.Length;
			foreach (TextMarker marker in markers.FindOverlappingSegments(lineStart, line.Length)) {
				Brush foregroundBrush = null;
				if (marker.ForegroundColor != null) {
					foregroundBrush = new SolidColorBrush(marker.ForegroundColor.Value);
					foregroundBrush.Freeze();
				}
				ChangeLinePart(
					Math.Max(marker.StartOffset, lineStart),
					Math.Min(marker.EndOffset, lineEnd),
					element => {
						if (foregroundBrush != null) {
							element.TextRunProperties.SetForegroundBrush(foregroundBrush);
						}
					}
				);
			}
		}
		#endregion
		
		#region IBackgroundRenderer
		public KnownLayer Layer {
			get {
				// draw behind selection
				return KnownLayer.Selection;
			}
		}
		
		public void Draw(TextView textView, DrawingContext drawingContext)
		{
			if (textView == null)
				throw new ArgumentNullException("textView");
			if (drawingContext == null)
				throw new ArgumentNullException("drawingContext");
			if (markers == null || !textView.VisualLinesValid)
				return;
			var visualLines = textView.VisualLines;
			if (visualLines.Count == 0)
				return;
			int viewStart = visualLines.First().FirstDocumentLine.Offset;
			int viewEnd = visualLines.Last().LastDocumentLine.EndOffset;
			foreach (TextMarker marker in markers.FindOverlappingSegments(viewStart, viewEnd - viewStart)) {
				if (marker.BackgroundColor != null) {
					BackgroundGeometryBuilder geoBuilder = new BackgroundGeometryBuilder();
					geoBuilder.AlignToWholePixels = true;
					geoBuilder.CornerRadius = 3;
					geoBuilder.AddSegment(textView, marker);
					Geometry geometry = geoBuilder.CreateGeometry();
					if (geometry != null) {
						Color color = marker.BackgroundColor.Value;
						SolidColorBrush brush = new SolidColorBrush(color);
						brush.Freeze();
						drawingContext.DrawGeometry(brush, null, geometry);
					}
				}
				if (marker.MarkerType != TextMarkerType.None) {
					foreach (Rect r in BackgroundGeometryBuilder.GetRectsForSegment(textView, marker)) {
						Point startPoint = r.BottomLeft;
						Point endPoint = r.BottomRight;
						
						Pen usedPen = new Pen(new SolidColorBrush(marker.MarkerColor), 0.75);
						usedPen.Freeze();
						switch (marker.MarkerType) {
							case TextMarkerType.SquigglyUnderline:
								double offset = 2.5;
								
								int count = Math.Max((int)((endPoint.X - startPoint.X) / offset) + 1, 4);
								
								StreamGeometry geometry = new StreamGeometry();
								
								using (StreamGeometryContext ctx = geometry.Open()) {
									ctx.BeginFigure(startPoint, false, false);
									ctx.PolyLineTo(CreatePoints(startPoint, endPoint, offset, count).ToArray(), true, false);
								}
								
								geometry.Freeze();
								
								drawingContext.DrawGeometry(Brushes.Transparent, usedPen, geometry);
								break;
						}
					}
				}
			}
		}
		
		IEnumerable<Point> CreatePoints(Point start, Point end, double offset, int count)
		{
			for (int i = 0; i < count; i++)
				yield return new Point(start.X + i * offset, start.Y - ((i + 1) % 2 == 0 ? offset : 0));
		}
		#endregion
	}
	
	public sealed class TextMarker : TextSegment, ITextMarker
	{
		readonly TextMarkerService service;
		
		public TextMarker(TextMarkerService service, int startOffset, int length)
		{
			if (service == null)
				throw new ArgumentNullException("service");
			this.service = service;
			this.StartOffset = startOffset;
			this.Length = length;
			this.markerType = TextMarkerType.None;
		}
		
		public event EventHandler Deleted;
		
		public bool IsDeleted {
			get { return !this.IsConnectedToCollection; }
		}
		
		public void Delete()
		{
			service.Remove(this);
		}
		
		internal void OnDeleted()
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}
		
		void Redraw()
		{
			service.Redraw(this);
		}
		
		Color? backgroundColor;
		
		public Color? BackgroundColor {
			get { return backgroundColor; }
			set {
				if (backgroundColor != value) {
					backgroundColor = value;
					Redraw();
				}
			}
		}
		
		Color? foregroundColor;
		
		public Color? ForegroundColor {
			get { return foregroundColor; }
			set {
				if (foregroundColor != value) {
					foregroundColor = value;
					Redraw();
				}
			}
		}
		
		public object Tag { get; set; }
		
		TextMarkerType markerType;
		
		public TextMarkerType MarkerType {
			get { return markerType; }
			set {
				if (markerType != value) {
					markerType = value;
					Redraw();
				}
			}
		}
		
		Color markerColor;
		
		public Color MarkerColor {
			get { return markerColor; }
			set {
				if (markerColor != value) {
					markerColor = value;
					Redraw();
				}
			}
		}
		
		public object ToolTip { get; set; }
	}
}
