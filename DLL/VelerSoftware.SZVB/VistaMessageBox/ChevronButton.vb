''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Windows.Forms

Namespace VistaDialog

	''' <summary>
	''' Vista-like chevron button.
	''' </summary>
	Friend Class ChevronButton

		Public Sub New()

			InitializeComponent()
			Image = My.Resources.ChevronMore

		End Sub

		Private isHovered As Boolean
		Private isFocused As Boolean
		Private isFocusedByKey As Boolean
		Private isKeyDown As Boolean
		Private isMouseDown As Boolean
		Private ReadOnly Property isPressed() As Boolean
			Get
				Return isKeyDown OrElse (isMouseDown AndAlso isHovered)
			End Get
		End Property

		Private _expanded As Boolean
		Public Property Expanded() As Boolean
			Get
				Return _expanded
			End Get
			Set(ByVal value As Boolean)
				_expanded = value
				SetImage()
			End Set
		End Property

		Public Overrides ReadOnly Property Focused() As Boolean
			Get
				Return False
			End Get
		End Property

		Private Sub SetImage()
			If isPressed Then
				Image = [If](_expanded, My.Resources.ChevronLessPressed, My.Resources.ChevronMorePressed)
			ElseIf isHovered OrElse isFocused Then
				Image = [If](_expanded, My.Resources.ChevronLessHovered, My.Resources.ChevronMoreHovered)
			Else
				Image = [If](_expanded, My.Resources.ChevronLess, My.Resources.ChevronMore)
			End If
		End Sub

		Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
			isKeyDown = False
			isMouseDown = False
			_expanded = _expanded Xor True
			SetImage()
			MyBase.OnClick(e)
		End Sub

		Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
			isFocused = True
			isFocusedByKey = True
			SetImage()
			MyBase.OnEnter(e)
		End Sub

		Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
			MyBase.OnLeave(e)
			isFocused = False
			isFocusedByKey = False
			isKeyDown = False
			isMouseDown = False
			SetImage()
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal kevent As System.Windows.Forms.KeyEventArgs)
			If (kevent.KeyCode = Keys.Space) Then
				isKeyDown = True
				SetImage()
			End If
			MyBase.OnKeyDown(kevent)
		End Sub

		Protected Overrides Sub OnKeyUp(ByVal kevent As System.Windows.Forms.KeyEventArgs)
			If (isKeyDown AndAlso (kevent.KeyCode = Keys.Space)) Then
				isKeyDown = False
				SetImage()
			End If
			MyBase.OnKeyUp(kevent)
		End Sub

		Protected Overrides Sub OnMouseDown(ByVal mevent As System.Windows.Forms.MouseEventArgs)
			If (Not isMouseDown AndAlso (mevent.Button = MouseButtons.Left)) Then
				isMouseDown = True
				isFocusedByKey = False
				SetImage()
			End If
			MyBase.OnMouseDown(mevent)
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal mevent As System.Windows.Forms.MouseEventArgs)
			If (isMouseDown) Then
				isMouseDown = False
				SetImage()
			End If
			MyBase.OnMouseUp(mevent)
		End Sub

		Protected Overrides Sub OnMouseMove(ByVal mevent As System.Windows.Forms.MouseEventArgs)
			MyBase.OnMouseMove(mevent)
			If (mevent.Button <> MouseButtons.None) Then
				If (Not ClientRectangle.Contains(mevent.X, mevent.Y)) Then
					If (isHovered) Then
						isHovered = False
						SetImage()
					End If
				ElseIf (Not isHovered) Then
					isHovered = True
					SetImage()
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
			isHovered = True
			SetImage()
			MyBase.OnMouseEnter(e)
		End Sub

		Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
			isHovered = False
			SetImage()
			MyBase.OnMouseLeave(e)
		End Sub


	End Class

End Namespace