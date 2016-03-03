Imports System.Drawing
Imports System.Windows.Forms



''' <summary>
''' The VistaMessageBox form.
''' </summary>
Friend Class VistaMessageBoxForm

	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		SuspendLayouts()

		Font = SystemFonts.MessageBoxFont
		LabelTitle.Font = New Font(Font.FontFamily, Font.Size * 1.5!, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)

		'TableLayoutPanel.RowStyles(2) = New RowStyle(SizeType.Absolute, 0.0!)
		'TableLayoutPanel.RowStyles(3) = New RowStyle(SizeType.Absolute, 0.0!)

		'TableLayoutPanelButtons.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
		'VButtons = Nothing
		'FlowLayoutPanelButtonsLeft.Visible = False

		'TableLayoutPanelContent.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
		'LabelIcon.Visible = False
		'TableLayoutPanelContent.RowStyles(0) = New RowStyle(SizeType.Absolute, 0.0!)
		'LabelTitle.Visible = False
		'TableLayoutPanelContent.RowStyles(1) = New RowStyle(SizeType.Absolute, 0.0!) ' content
		'LabelContent.Visible = False
		'TableLayoutPanelContent.RowStyles(2) = New RowStyle(SizeType.Absolute, 0.0!) ' expanded content
		'LabelExpandedContent.Visible = False
		'TableLayoutPanelContent.RowStyles(3) = New RowStyle(SizeType.Absolute, 0.0!) ' reszta

		'TableLayoutPanelContents.Visible = False
		'CheckBox.Visible = False
		'ButtonExpander.Visible = False

		'TableLayoutPanelFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
		'TableLayoutPanelExpanderFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)

		ResumeLayouts()

	End Sub

	Public Sub SuspendLayouts()
		Me.TableLayoutPanelContent.SuspendLayout()
		Me.PanelExpandedFooter.SuspendLayout()
		Me.TableLayoutPanelExpanderFooter.SuspendLayout()
		Me.PanelFooter.SuspendLayout()
		Me.TableLayoutPanelFooter.SuspendLayout()
		Me.PanelButtons.SuspendLayout()
		Me.TableLayoutPanelButtons.SuspendLayout()
		Me.FlowLayoutPanelButtons.SuspendLayout()
		Me.FlowLayoutPanelButtonsLeft.SuspendLayout()
		Me.TableLayoutPanel.SuspendLayout()
		Me.SuspendLayout()
	End Sub

	Public Sub ResumeLayouts()
		Me.TableLayoutPanelContent.ResumeLayout(False)
		Me.TableLayoutPanelContent.PerformLayout()
		Me.PanelExpandedFooter.ResumeLayout(False)
		Me.PanelExpandedFooter.PerformLayout()
		Me.TableLayoutPanelExpanderFooter.ResumeLayout(False)
		Me.TableLayoutPanelExpanderFooter.PerformLayout()
		Me.PanelFooter.ResumeLayout(False)
		Me.PanelFooter.PerformLayout()
		Me.TableLayoutPanelFooter.ResumeLayout(False)
		Me.TableLayoutPanelFooter.PerformLayout()
		Me.PanelButtons.ResumeLayout(False)
		Me.PanelButtons.PerformLayout()
		Me.TableLayoutPanelButtons.ResumeLayout(False)
		Me.TableLayoutPanelButtons.PerformLayout()
		Me.FlowLayoutPanelButtons.ResumeLayout(False)
		Me.FlowLayoutPanelButtons.PerformLayout()
		Me.FlowLayoutPanelButtonsLeft.ResumeLayout(False)
		Me.FlowLayoutPanelButtonsLeft.PerformLayout()
		Me.TableLayoutPanel.ResumeLayout(False)
		Me.TableLayoutPanel.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub

	Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
		Get
			Dim cp As CreateParams = MyBase.CreateParams
			If Not CanCancel Then
				cp.ClassStyle = cp.ClassStyle Or &H200 ' CS_NOCLOSE
			End If
			Return cp
		End Get
	End Property

#Region " Fields and Properties "

	Private _buttons() As Button
	Private ReadOnly Property Buttons() As Button()
		Get
			If _buttons Is Nothing Then
				_buttons = New Button() {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button10, Button11}
			End If
			Return _buttons
		End Get
	End Property

	Private _sound As ISound
	Public Property Sound() As ISound
		Get
			If (_sound IsNot Nothing) Then
				Return _sound
			End If
			Return VistaMessageBoxSound.Default
		End Get
		Set(ByVal value As ISound)
			_sound = value
		End Set
	End Property

	Public Property Content() As String
		Get
			Return LabelContent.Text()
		End Get
		Set(ByVal value As String)
			LabelContent.Text = value
			If String.IsNullOrEmpty(value) Then
				LabelContent.Visible = False
				TableLayoutPanelContent.RowStyles(1) = New RowStyle(SizeType.Absolute, 0.0!)
			Else
				TableLayoutPanelContent.RowStyles(1) = New RowStyle(SizeType.AutoSize)
				LabelContent.Visible = True
			End If
		End Set
	End Property

	Public Property Title() As String
		Get
			Return LabelTitle.Text
		End Get
		Set(ByVal value As String)
			LabelTitle.Text = value
			If String.IsNullOrEmpty(value) Then
				LabelTitle.Visible = False
				TableLayoutPanelContent.RowStyles(0) = New RowStyle(SizeType.Absolute, 0.0!)
			Else
				TableLayoutPanelContent.RowStyles(0) = New RowStyle(SizeType.AutoSize)
				LabelTitle.Visible = True
			End If
		End Set
	End Property

	Public Property Caption() As String
		Get
			Return Text
		End Get
		Set(ByVal value As String)
			Text = value
		End Set
	End Property

	Public Property FooterText() As String
		Get
			Return LabelFooter.Text
		End Get
		Set(ByVal value As String)
			LabelFooter.Text = value
			If (value Is Nothing) Then
				TableLayoutPanelFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
				TableLayoutPanel.RowStyles(2) = New RowStyle(SizeType.Absolute, 0.0!)
			Else
				TableLayoutPanelFooter.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				TableLayoutPanel.RowStyles(2) = New RowStyle(SizeType.AutoSize)
			End If
		End Set
	End Property

	Private CanCancel As Boolean
	Private _vButtons() As VistaMessageBoxButton
	Public Property VButtons() As VistaMessageBoxButton()
		Get
			Return _vButtons
		End Get
		Set(ByVal value As VistaMessageBoxButton())
			If value Is Nothing Then
				value = New VistaMessageBoxButton() {}
			End If
			_vButtons = value
			If value.Length = 0 Then
				TableLayoutPanelButtons.ColumnStyles(1) = New ColumnStyle(SizeType.Absolute, 0.0!)
				If TableLayoutPanelButtons.ColumnStyles(0).SizeType = SizeType.Absolute Then
					TableLayoutPanel.RowStyles(1) = New RowStyle(SizeType.Absolute, 0.0!)
				End If
			Else
				TableLayoutPanel.RowStyles(1) = New RowStyle(SizeType.AutoSize)
				TableLayoutPanelButtons.ColumnStyles(1) = New ColumnStyle(SizeType.AutoSize)
			End If
			For i As Integer = 0 To Buttons.Length - 1
				With Buttons(i)
					.Visible = i < value.Length
					'.Enabled = i < value.Length
					If i < value.Length Then
						If value(i).VistaMessageBoxResult = VistaMessageBoxResult.Cancel Then
							CanCancel = True
							CancelButton = Buttons(i)
						End If
						If value(i).UseCustomText Then
							.Text = value(i).Text
						Else
							.Text = GetButtonName(value(i).VistaMessageBoxResult)
						End If
						If value(i).ShowElevationIcon Then
							.Image = My.Resources.SmallSecurity
						Else
							.Image = Nothing
						End If
						.Tag = value(i)
					End If
				End With
			Next
			If value.Length = 1 Then
				CanCancel = True
				CancelButton = Buttons(0)
				AcceptButton = Buttons(0)
			End If
		End Set
	End Property

	Public Property Image() As Image
		Get
			Return LabelIcon.Image
		End Get
		Set(ByVal value As Image)
			LabelIcon.Image = value
			If value Is Nothing Then
				'LabelIcon.Visible = False
				TableLayoutPanelContent.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
			Else
				TableLayoutPanelContent.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				'LabelIcon.Visible = True
			End If
		End Set
	End Property

	Public Property FooterImage() As Image
		Get
			Return LabelIconFooter.Image
		End Get
		Set(ByVal value As Image)
			LabelIconFooter.Image = value
			If value Is Nothing Then
				TableLayoutPanelFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
				LabelFooter.Margin = New Padding(16, LabelFooter.Margin.Top, LabelFooter.Margin.Right, LabelFooter.Margin.Bottom)
			Else
				TableLayoutPanelFooter.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				LabelFooter.Margin = New Padding(4, LabelFooter.Margin.Top, LabelFooter.Margin.Right, LabelFooter.Margin.Bottom)
			End If
		End Set
	End Property

	Private _drawGradient As Boolean
	Private _gradientBegin As Color
	Private _gradientEnd As Color

	Private _mainIcon As VistaMessageBoxIcon
	Public Property MainIcon() As VistaMessageBoxIcon
		Get
			Return _mainIcon
		End Get
		Set(ByVal value As VistaMessageBoxIcon)
			_mainIcon = value
			TableLayoutPanelContent.SetRowSpan(LabelIcon, 2)
			LabelTitle.ForeColor = SystemColors.HotTrack
			_drawGradient = False
			Sound = VistaMessageBoxSound.Default

			Select Case _mainIcon
				Case VistaMessageBoxIcon.Information
					Image = VistaMessageBoxBigIcon.Information
					Sound = VistaMessageBoxSound.Information

				Case VistaMessageBoxIcon.Question
					Image = VistaMessageBoxBigIcon.Question
					Sound = VistaMessageBoxSound.Question

				Case VistaMessageBoxIcon.Warning
					Image = VistaMessageBoxBigIcon.Warning
					Sound = VistaMessageBoxSound.Warning

				Case VistaMessageBoxIcon.Error
					Image = VistaMessageBoxBigIcon.Error
					Sound = VistaMessageBoxSound.Error

				Case VistaMessageBoxIcon.SecuritySuccess
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.SecuritySuccess
					_drawGradient = True
					_gradientBegin = Color.FromArgb(21, 118, 21)
					_gradientEnd = Color.FromArgb(57, 150, 63)
					LabelTitle.ForeColor = Color.White
					Sound = VistaMessageBoxSound.Information

				Case VistaMessageBoxIcon.SecurityQuestion
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.SecurityQuestion
					_drawGradient = True
					_gradientBegin = Color.FromArgb(0, 177, 242)
					_gradientEnd = Color.FromArgb(72, 205, 254)
					LabelTitle.ForeColor = Color.White
					Sound = VistaMessageBoxSound.Question

				Case VistaMessageBoxIcon.SecurityWarning
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.SecurityWarning
					_drawGradient = True
					_gradientBegin = Color.FromArgb(242, 177, 0)
					_gradientEnd = Color.FromArgb(254, 205, 72)
					LabelTitle.ForeColor = Color.Black
					Sound = VistaMessageBoxSound.Warning

				Case VistaMessageBoxIcon.SecurityError
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.SecurityError
					_drawGradient = True
					_gradientBegin = Color.FromArgb(172, 1, 0)
					_gradientEnd = Color.FromArgb(227, 1, 0)
					LabelTitle.ForeColor = Color.White
					Sound = VistaMessageBoxSound.Error

				Case VistaMessageBoxIcon.SecurityShield
					Image = VistaMessageBoxBigIcon.Security
					Sound = VistaMessageBoxSound.Security

				Case VistaMessageBoxIcon.SecurityShieldBlue
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.Security
					_drawGradient = True
					_gradientBegin = Color.FromArgb(4, 80, 130)
					_gradientEnd = Color.FromArgb(28, 120, 133)
					LabelTitle.ForeColor = Color.White
					Sound = VistaMessageBoxSound.Security

				Case VistaMessageBoxIcon.SecurityShieldGray
					TableLayoutPanelContent.SetRowSpan(LabelIcon, 1)
					Image = VistaMessageBoxBigIcon.Security
					_drawGradient = True
					_gradientBegin = Color.FromArgb(157, 143, 133)
					_gradientEnd = Color.FromArgb(164, 152, 144)
					LabelTitle.ForeColor = Color.White
					Sound = VistaMessageBoxSound.Security

				Case Else
					Image = Nothing
			End Select

		End Set
	End Property

	Private _footerIcon As VistaMessageBoxIcon
	Public Property FooterIcon() As VistaMessageBoxIcon
		Get
			Return _footerIcon
		End Get
		Set(ByVal value As VistaMessageBoxIcon)
			_footerIcon = value
			Select Case _footerIcon
				Case VistaMessageBoxIcon.Information
					FooterImage = VistaMessageBoxSmallIcon.Information
				Case VistaMessageBoxIcon.Question
					FooterImage = VistaMessageBoxSmallIcon.Question
				Case VistaMessageBoxIcon.Warning
					FooterImage = VistaMessageBoxSmallIcon.Warning
				Case VistaMessageBoxIcon.Error
					FooterImage = VistaMessageBoxSmallIcon.Error
				Case VistaMessageBoxIcon.SecuritySuccess
					FooterImage = VistaMessageBoxSmallIcon.SecuritySuccess
				Case VistaMessageBoxIcon.SecurityQuestion
					FooterImage = VistaMessageBoxSmallIcon.SecurityQuestion
				Case VistaMessageBoxIcon.SecurityWarning
					FooterImage = VistaMessageBoxSmallIcon.SecurityWarning
				Case VistaMessageBoxIcon.SecurityError
					FooterImage = VistaMessageBoxSmallIcon.SecurityError
				Case VistaMessageBoxIcon.SecurityShield
					FooterImage = VistaMessageBoxSmallIcon.Security
				Case VistaMessageBoxIcon.SecurityShieldBlue
					FooterImage = VistaMessageBoxSmallIcon.Security
				Case VistaMessageBoxIcon.SecurityShieldGray
					FooterImage = VistaMessageBoxSmallIcon.Security
				Case Else
					FooterImage = Nothing
			End Select

		End Set
	End Property

	Private _defaultButton As VistaMessageBoxDefaultButton
	Public Property DefaultButton() As VistaMessageBoxDefaultButton
		Get
			Return _defaultButton
		End Get
		Set(ByVal value As VistaMessageBoxDefaultButton)
			_defaultButton = value
		End Set
	End Property

	Private Property ShowCheckBox() As Boolean
		Get
			Return CheckBox.Visible
		End Get
		Set(ByVal value As Boolean)
			If value Then
				TableLayoutPanelButtons.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				FlowLayoutPanelButtonsLeft.Visible = True
				CheckBox.Visible = True
			Else
				CheckBox.Visible = False
				If Not ShowButtonExpander Then
					FlowLayoutPanelButtonsLeft.Visible = False
					TableLayoutPanelButtons.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
				End If
			End If
		End Set
	End Property

	Public Property ShowButtonExpander() As Boolean
		Get
			Return ButtonExpander.Visible
		End Get
		Set(ByVal value As Boolean)
			If value Then
				SetExpanderText()
				TableLayoutPanelButtons.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				FlowLayoutPanelButtonsLeft.Visible = True
				ButtonExpander.Visible = True
			Else
				ButtonExpander.Visible = False
				If Not ShowCheckBox Then
					FlowLayoutPanelButtonsLeft.Visible = False
					TableLayoutPanelButtons.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
				End If
			End If
		End Set
	End Property

	Public Property ExpandedInformation() As String
		Get
			Return LabelExpandedContent.Text
		End Get
		Set(ByVal value As String)
			LabelExpandedContent.Text = value
			LabelExpandedFooter.Text = value
			ShowButtonExpander = Not String.IsNullOrEmpty(value)
			Expanded = Not String.IsNullOrEmpty(value)
		End Set
	End Property

	Private _expandFooterArea As Boolean
	Public Property ExpandFooterArea() As Boolean
		Get
			Return _expandFooterArea
		End Get
		Set(ByVal value As Boolean)
			_expandFooterArea = value
		End Set
	End Property

	Private _expanded As Boolean
	Public Property Expanded() As Boolean
		Get
			Return _expanded
		End Get
		Set(ByVal value As Boolean)
			_expanded = value
			ButtonExpander.Expanded = value
			SetExpanderText()
			If (ExpandFooterArea) Then
				TableLayoutPanelContent.RowStyles(2) = New RowStyle(SizeType.Absolute, 0.0!)
				LabelExpandedContent.Visible = False
				If (Not value) Then
					TableLayoutPanelExpanderFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
					TableLayoutPanel.RowStyles(3) = New RowStyle(SizeType.Absolute, 0.0!)
				Else
					TableLayoutPanel.RowStyles(3) = New RowStyle(SizeType.AutoSize)
					TableLayoutPanelExpanderFooter.ColumnStyles(0) = New ColumnStyle(SizeType.AutoSize)
				End If
			Else
				TableLayoutPanelExpanderFooter.ColumnStyles(0) = New ColumnStyle(SizeType.Absolute, 0.0!)
				TableLayoutPanel.RowStyles(3) = New RowStyle(SizeType.Absolute, 0.0!)
				If (value) Then
					LabelExpandedContent.Visible = True
					TableLayoutPanelContent.RowStyles(2) = New RowStyle(SizeType.AutoSize)
				Else
					TableLayoutPanelContent.RowStyles(2) = New RowStyle(SizeType.Absolute, 0.0!)
					LabelExpandedContent.Visible = False
				End If
			End If
		End Set
	End Property

	Private Sub SetExpanderText()
		If (Expanded) Then
			ButtonExpander.Text = ExpandedControlText
		Else
			ButtonExpander.Text = CollapsedControlText
		End If
	End Sub

	Private _expandedControlText As String
	Public Property ExpandedControlText() As String
		Get
			If (String.IsNullOrEmpty(_expandedControlText)) Then Return My.Resources.ExpandedText
			Return _expandedControlText
		End Get
		Set(ByVal value As String)
			_expandedControlText = value
			SetExpanderText()
		End Set
	End Property

	Private _collapsedControlText As String
	Public Property CollapsedControlText() As String
		Get
			If (String.IsNullOrEmpty(_collapsedControlText)) Then Return My.Resources.CollapsedText
			Return _collapsedControlText
		End Get
		Set(ByVal value As String)
			_collapsedControlText = value
			SetExpanderText()
		End Set
	End Property

	Public Property CheckBoxState() As CheckState
		Get
			Return CheckBox.CheckState
		End Get
		Set(ByVal value As CheckState)
			CheckBox.CheckState = value
		End Set
	End Property

	Public Property CheckBoxText() As String
		Get
			Return CheckBox.Text
		End Get
		Set(ByVal value As String)
			CheckBox.Text = value
			ShowCheckBox = Not String.IsNullOrEmpty(value)
		End Set
	End Property

	Private _control As Control
	Public Property CustomControl() As Control
		Get
			Return _control
		End Get
		Set(ByVal value As Control)
			Me.TableLayoutPanelContents.Controls.Clear()
			If value Is Nothing Then
				TableLayoutPanelContents.Visible = False
				TableLayoutPanelContent.RowStyles(3) = New RowStyle(SizeType.Absolute, 0.0!)
			Else
				Me.TableLayoutPanelContents.Controls.Add(value, 0, 0)
				value.Dock = DockStyle.Fill
				TableLayoutPanelContent.RowStyles(3) = New RowStyle(SizeType.AutoSize)
				TableLayoutPanelContents.Visible = True
			End If
			_control = value
		End Set
	End Property
#End Region

	Private Sub VistaMessageBoxForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Visible = False
		If Me.Tag Is Nothing Then
			If (CancelButton Is Nothing) OrElse (Not (TypeOf CancelButton Is Button)) OrElse (TryCast(CancelButton, Button).Tag Is Nothing) Then
				Me.Tag = New VistaMessageBoxButton(VistaMessageBoxResult.Cancel)
			Else
				Me.Tag = DirectCast(TryCast(CancelButton, Button).Tag, VistaMessageBoxButton)
			End If
		End If
	End Sub

	Private Sub VistaMessageBox_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If _control IsNot Nothing Then
			Me.TableLayoutPanelContents.Controls.Remove(_control)
			_control = Nothing
		End If
	End Sub

	Private Sub VistaMessageBoxForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
		Dim X As Integer = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)
		Dim Y As Integer = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)
		Me.Location = New Point(X, Y)

		Tag = Nothing
		Dim i As Integer = DirectCast(DefaultButton, Integer)
		If i > 0 AndAlso i <= VButtons.Length Then
			AcceptButton = Buttons(i - 1)
			Buttons(i - 1).Focus()
		Else
			LabelContent.Focus()
		End If
		If LabelTitle.Visible AndAlso LabelContent.Visible Then
			LabelTitle.Margin = New Padding(LabelTitle.Margin.Left, LabelTitle.Margin.Top, LabelTitle.Margin.Right, 0)
			LabelContent.Margin = New Padding(LabelContent.Margin.Left, [If](_drawGradient, 16, LabelContent.Margin.Top), LabelContent.Margin.Right, 16)
		End If

		If Not String.IsNullOrEmpty(ExpandedInformation) AndAlso Expanded Then
			Expanded = True
		End If

		If Sound IsNot Nothing Then
			Sound.Play()
		End If
	End Sub

	Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click
		Dim button As Button = TryCast(sender, Button)
		Dim vButton As VistaMessageBoxButton = DirectCast(button.Tag, VistaMessageBoxButton)
		Tag = vButton
		vButton.RaiseClickEvent(sender, e)
		If vButton.VistaMessageBoxResult <> VistaMessageBoxResult.None Then
			DialogResult = DialogResult.OK
		End If
	End Sub

	Private Sub TableLayoutPanelContent_CellPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs) Handles TableLayoutPanelContent.CellPaint
		If _drawGradient AndAlso e.Row = 0 AndAlso e.Column = 1 Then
			Dim bounds As Rectangle = New Rectangle(0, 0, TableLayoutPanel.Width, e.CellBounds.Height)
			Using b As New System.Drawing.Drawing2D.LinearGradientBrush(bounds, _gradientBegin, _gradientEnd, Drawing2D.LinearGradientMode.Horizontal)
				e.Graphics.FillRectangle(b, bounds)
			End Using
		End If
	End Sub

	Private Sub LabelIcon_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles LabelIcon.Paint
		If _drawGradient Then
			Dim bounds As Rectangle = New Rectangle(0, 0, TableLayoutPanel.Width, LabelIcon.Height)
			Using b As New System.Drawing.Drawing2D.LinearGradientBrush(bounds, _gradientBegin, _gradientEnd, Drawing2D.LinearGradientMode.Horizontal)
				bounds.X -= LabelIcon.Left
				e.Graphics.FillRectangle(b, bounds)
			End Using
			e.Graphics.DrawImage(LabelIcon.Image, 0, 0)
		End If
	End Sub

	Private Sub ButtonExpander_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExpander.Click
		Expanded = Expanded Xor True
	End Sub

	Private Sub RaiseLinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LabelFooter.LinkClicked, LabelExpandedFooter.LinkClicked, LabelExpandedContent.LinkClicked, LabelContent.LinkClicked
		RaiseEvent LinkClicked(sender, e)
	End Sub

	Public Event LinkClicked As LinkLabelLinkClickedEventHandler

	Private Sub VistaMessageBoxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim X As Integer = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)
		Dim Y As Integer = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)
		Me.Location = New Point(X, Y)
	End Sub
End Class

