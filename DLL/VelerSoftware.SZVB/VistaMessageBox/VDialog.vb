''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Threading
Imports System.Windows.Forms
Imports System.Drawing

Namespace VistaDialog

	''' <summary>
	''' Displays a Vista-like message box or task dialog that can contain text, buttons, symbols and other elements that inform and instruct the user.
	''' </summary>
	Public NotInheritable Class VDialog

#Region " MessageBox "

		Private Shared ReadOnly NullWindow As IWin32Window = Nothing

		''' <summary>
		''' Displays a Vista-like message box with specified text.
		''' </summary>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal text As String) As DialogResult
			Return Show(NullWindow, text)
		End Function

		''' <summary>
		''' Displays a Vista-like message box in front of the specified object and with the specified text.
		''' </summary>
		''' <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String) As DialogResult
			Return Show(owner, text, My.Application.Info.Title)
		End Function

		''' <summary>
		''' Displays a Vista-like message box with specified text and caption.
		''' </summary>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal text As String, ByVal caption As String) As DialogResult
			Return Show(NullWindow, text, caption)
		End Function

		''' <summary>
		''' Displays a Vista-like message box in front of the specified object and with the specified text and caption.
		''' </summary>
		''' <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String) As DialogResult
			Return Show(owner, text, caption, MessageBoxButtons.OK)
		End Function

		''' <summary>
		''' Displays a Vista-like message box with specified text, caption, and buttons.
		''' </summary>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
			Return Show(NullWindow, text, caption, buttons)
		End Function

		''' <summary>
		''' Displays a Vista-like message box in front of the specified object and with the specified text, caption, and buttons.
		''' </summary>
		''' <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons) As DialogResult
			Return Show(owner, text, caption, buttons, MessageBoxIcon.None)
		End Function

		''' <summary>
		''' Displays a Vista-like message box with specified text, caption, buttons, and icon.
		''' </summary>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
			Return Show(NullWindow, text, caption, buttons, icon, MessageBoxDefaultButton.Button1)
		End Function

		''' <summary>
		''' Displays a Vista-like message box in front of the specified object and with the specified text, caption, buttons, and icon.
		''' </summary>
		''' <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon) As DialogResult
			Return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1)
		End Function

		''' <summary>
		''' Displays a Vista-like message box with specified text, caption, buttons, icon, and default button.
		''' </summary>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
		''' <param name="defaultButton">One of the MessageBoxDefaultButton values that specifies the default button for the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
			Return Show(NullWindow, text, caption, buttons, icon, defaultButton)
		End Function

		''' <summary>
		''' Displays a Vista-like message box in front of the specified object and with specified text, caption, buttons, icon, and default button.
		''' </summary>
		''' <param name="owner">An implementation of IWin32Window that will own the modal dialog box.</param>
		''' <param name="text">The text to display in the Vista-like message box.</param>
		''' <param name="caption">The text to display in the title bar of the Vista-like message box.</param>
		''' <param name="buttons">One of the MessageBoxButtons values that specifies which buttons to display in the Vista-like message box.</param>
		''' <param name="icon">One of the MessageBoxIcon values that specifies which icon to display in the Vista-like message box.</param>
		''' <param name="defaultButton">One of the MessageBoxDefaultButton values that specifies the default button for the Vista-like message box.</param>
		''' <returns>One of the DialogResult values.</returns>
		Public Shared Function Show(ByVal owner As IWin32Window, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal icon As MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
			Dim vd As New VDialog()
			vd.Content = text
			vd.WindowTitle = caption
			Select Case buttons
				Case MessageBoxButtons.AbortRetryIgnore
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.Abort), New VDialogButton(VDialogResult.Retry), New VDialogButton(VDialogResult.Ignore)}
				Case MessageBoxButtons.OKCancel
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.OK), New VDialogButton(VDialogResult.Cancel)}
				Case MessageBoxButtons.RetryCancel
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.Retry), New VDialogButton(VDialogResult.Cancel)}
				Case MessageBoxButtons.YesNo
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.Yes), New VDialogButton(VDialogResult.No)}
				Case MessageBoxButtons.YesNoCancel
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.Yes), New VDialogButton(VDialogResult.No), New VDialogButton(VDialogResult.Cancel)}
				Case Else
					vd.Buttons = New VDialogButton() {New VDialogButton(VDialogResult.OK)}
			End Select
			Select Case icon
				Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
					vd.MainIcon = VDialogIcon.Information
				Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
					vd.MainIcon = VDialogIcon.Warning
				Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
					vd.MainIcon = VDialogIcon.Error
				Case MessageBoxIcon.Question
					vd.MainIcon = VDialogIcon.Question
				Case Else
					vd.CustomMainIcon = Nothing
			End Select
			vd.DefaultButton = MakeVDialogDefaultButton(defaultButton)
			vd.Owner = owner
			vd.Show()
			Return MakeDialogResult(vd.Result)
		End Function

		Private Shared Sub SetStartPosition(ByVal f As Form, ByVal o As IWin32Window)
			If o Is Nothing Then
				f.StartPosition = FormStartPosition.CenterScreen
			Else
				f.StartPosition = FormStartPosition.CenterParent
			End If
		End Sub

#End Region

#Region " TaskDialog "

#Region " Methods "

		''' <summary>
		''' Shows the VDialog form as a modal dialog box.
		''' </summary>
		''' <returns>One of the VDialogResult values.</returns>
		Public Function Show() As VDialogResult
			If LockSystem Then
				Return LockSystemAndShow()
			Else
				Return ShowInternal(Owner)
            End If
		End Function

		Private Function ShowInternal(ByVal Owner As IWin32Window) As VDialogResult
			Using vdf As VDialogForm = New VDialogForm()
				_vdf = vdf
				AddHandler vdf.LinkClicked, AddressOf vdf_LinkClicked
				AddHandler vdf.Load, AddressOf vdf_Load
				vdf.RightToLeft = RightToLeft
				vdf.RightToLeftLayout = RightToLeftLayout
				SetStartPosition(_vdf, Owner)
				vdf.ShowDialog(Owner)
				_vdf = Nothing
				VerificationFlagChecked = vdf.CheckBoxState
                Result = DirectCast(vdf.Tag, VDialogButton).VDialogResult
                vdf.Dispose()
				Return Result
			End Using
		End Function

		Private Sub vdf_LinkClicked(ByVal sender As System.Object, ByVal e As LinkLabelLinkClickedEventArgs)
			RaiseEvent LinkClicked(sender, e)
		End Sub

		Private Sub vdf_Load(ByVal sender As Object, ByVal e As EventArgs)
			_vdf.SuspendLayouts()
			_vdf.Content = Content
			If (_contentLink IsNot Nothing AndAlso _contentLink IsNot _vdf.LabelContent) Then
				For Each link As LinkLabel.Link In ContentLinks
					_vdf.LabelContent.Links.Add(link)
				Next
				_contentLink.Dispose()
				_contentLink = _vdf.LabelContent
			End If
			_vdf.Caption = WindowTitle
			_vdf.Title = MainInstruction
			_vdf.VButtons = Buttons
			_vdf.MainIcon = MainIcon
			If (CustomMainIcon IsNot Nothing) Then _vdf.Image = CustomMainIcon
			_vdf.FooterIcon = FooterIcon
			If (CustomFooterIcon IsNot Nothing) Then _vdf.FooterImage = CustomFooterIcon
			_vdf.FooterText = FooterText
			If (_footer IsNot Nothing AndAlso _footer IsNot _vdf.LabelFooter) Then
				For Each link As LinkLabel.Link In FooterLinks
					_vdf.LabelFooter.Links.Add(link)
				Next
				_footer.Dispose()
				_footer = _vdf.LabelFooter
			End If
			_vdf.DefaultButton = DefaultButton
			_vdf.CheckBoxState = VerificationFlagChecked
			_vdf.CheckBoxText = VerificationText
			_vdf.ExpandFooterArea = ExpandFooterArea
			_vdf.ExpandedInformation = ExpandedInformation
			If (_expanded IsNot Nothing AndAlso _expanded IsNot [If](ExpandFooterArea, _vdf.LabelExpandedFooter, _vdf.LabelExpandedContent)) Then
				For Each link As LinkLabel.Link In ExpandedInformationLinks
					[If](ExpandFooterArea, _vdf.LabelExpandedFooter, _vdf.LabelExpandedContent).Links.Add(link)
				Next
				_expanded.Dispose()
				_expanded = [If](ExpandFooterArea, _vdf.LabelExpandedFooter, _vdf.LabelExpandedContent)
			End If
			_vdf.Expanded = ExpandedByDefault
			_vdf.ExpandedControlText = ExpandedControlText
			_vdf.CollapsedControlText = CollapsedControlText
			_vdf.CustomControl = CustomControl
			If (Sound IsNot Nothing) Then _vdf.Sound = Sound
			_vdf.ResumeLayouts()
		End Sub

		Private _vdf As VDialogForm

		''' <summary>
		''' Closes the VDialog form.
		''' </summary>
		''' <param name="result">A VDialogResult that represents the result of the form.</param>
		Public Sub Close(ByVal result As VDialogResult)
			If _vdf Is Nothing Then
				Throw New InvalidOperationException("Cannot invoke this method before the dialog is shown, or after it is closed.")
			End If
			Dim vButton As VDialogButton = New VDialogButton(result)
			_vdf.Tag = vButton
			If vButton.VDialogResult <> VDialogResult.None Then
				_vdf.DialogResult = DialogResult.OK
			End If
		End Sub

#End Region

#Region " Fields and Properties "

		Private _sound As ISound
		''' <summary>
		''' Gets or sets a sound played when the Vista-like task dialog is shown.
		''' </summary>
		Public Property Sound() As ISound
			Get
				If _lockSystem AndAlso _sound Is Nothing Then
					Return VDialogSound.Security
				End If
				Return _sound
			End Get
			Set(ByVal value As ISound)
				_sound = value
			End Set
		End Property

		Private _owner As IWin32Window
		''' <summary>
		''' Gets or sets an implementation of IWin32Window that will own the modal task dialog.
		''' </summary>
		Public Property Owner() As IWin32Window
			Get
				Return _owner
			End Get
			Set(ByVal value As IWin32Window)
				_owner = value
			End Set
		End Property

		Private _content As String
		''' <summary>
		''' Gets or sets the text to display in the Vista-like task dialog.
		''' </summary>
		Public Property Content() As String
			Get
				Return _content
			End Get
			Set(ByVal value As String)
				_content = value
			End Set
		End Property

		Private _contentLink As LinkLabel
		''' <summary>
		''' The collection of links contained within the Content LinkLabel.
		''' </summary>
		Public ReadOnly Property ContentLinks() As LinkLabel.LinkCollection
			Get
				If _contentLink Is Nothing Then
					If _vdf IsNot Nothing Then
						_contentLink = _vdf.LabelContent
					Else
						_contentLink = New LinkLabel()
					End If
				End If
				Return _contentLink.Links
			End Get
		End Property

		Private _windowTitle As String
		''' <summary>
		''' Gets or sets the text to display in the title bar of the Vista-like task dialog.
		''' </summary>
		Public Property WindowTitle() As String
			Get
				Return _windowTitle
			End Get
			Set(ByVal value As String)
				_windowTitle = value
			End Set
		End Property

		Private _mainInstruction As String
		''' <summary>
		''' Gets or sets the text to be used for the main instruction of the Vista-like task dialog.
		''' </summary>
		Public Property MainInstruction() As String
			Get
				Return _mainInstruction
			End Get
			Set(ByVal value As String)
				_mainInstruction = value
			End Set
		End Property

		Private _vButtons() As VDialogButton
		''' <summary>
		''' Gets or sets the array of the VDialogButtons that specifies which buttons to display in the Vista-like task dialog.
		''' </summary>
		Public Property Buttons() As VDialogButton()
			Get
				Return _vButtons
			End Get
			Set(ByVal value As VDialogButton())
				_vButtons = value
			End Set
		End Property

		Private _mainIcon As VDialogIcon
		''' <summary>
		''' Gets or sets the one of the VDialogIcon values that specifies which icon on what background to display in the Vista-like task dialog.
		''' </summary>
		Public Property MainIcon() As VDialogIcon
			Get
				Return _mainIcon
			End Get
			Set(ByVal value As VDialogIcon)
				_mainIcon = value
			End Set
		End Property

		Private _customMainIcon As Image
		''' <summary>
		''' Gets or sets the custom image to display in the Vista-like task dialog.
		''' </summary>
		Public Property CustomMainIcon() As Image
			Get
				Return _customMainIcon
			End Get
			Set(ByVal value As Image)
				_customMainIcon = value
			End Set
		End Property

		Private _footerIcon As VDialogIcon
		''' <summary>
		''' Gets or sets the one of the VDialogIcon values that specifies which icon to display in the footer of the Vista-like task dialog.
		''' </summary>
		Public Property FooterIcon() As VDialogIcon
			Get
				Return _footerIcon
			End Get
			Set(ByVal value As VDialogIcon)
				_footerIcon = value
			End Set
		End Property

		Private _customFooterIcon As Image
		''' <summary>
		''' Gets or sets the custom image to display in the footer of the Vista-like task dialog.
		''' </summary>
		Public Property CustomFooterIcon() As Image
			Get
				Return _customFooterIcon
			End Get
			Set(ByVal value As Image)
				_customFooterIcon = value
			End Set
		End Property

		Private _footerText As String
		''' <summary>
		''' Gets or sets the text to display in the footer of the Vista-like task dialog.
		''' </summary>
		Public Property FooterText() As String
			Get
				Return _footerText
			End Get
			Set(ByVal value As String)
				_footerText = value
			End Set
		End Property

		Private _footer As LinkLabel
		''' <summary>
		''' The collection of links contained within the Footer LinkLabel.
		''' </summary>
		Public ReadOnly Property FooterLinks() As LinkLabel.LinkCollection
			Get
				If _footer Is Nothing Then
					If _vdf IsNot Nothing Then
						_footer = _vdf.LabelFooter
					Else
						_footer = New LinkLabel()
					End If
				End If
				Return _footer.Links
			End Get
		End Property

		Private _defaultButton As VDialogDefaultButton = VDialogDefaultButton.Button1
		''' <summary>
		''' Gets or sets one of the VDialogDefaultButton values that specifies the default button for the Vista-like task dialog.
		''' </summary>
		Public Property DefaultButton() As VDialogDefaultButton
			Get
				Return _defaultButton
			End Get
			Set(ByVal value As VDialogDefaultButton)
				_defaultButton = value
			End Set
		End Property

		Private _rightToLeft As RightToLeft
		''' <summary>
		''' Gets or sets a value indicating whether the text appears from right to left, such as when using Hebrew or Arabic fonts.
		''' </summary>
		Public Property RightToLeft() As RightToLeft
			Get
				Return _rightToLeft
			End Get
			Set(ByVal value As RightToLeft)
				_rightToLeft = value
			End Set
		End Property

		Private _rightToLeftLayout As Boolean
		''' <summary>
		''' Gets or sets a value indicating whether right-to-left mirror placement is turned on.
		''' </summary>
		Public Property RightToLeftLayout() As Boolean
			Get
				Return _rightToLeftLayout
			End Get
			Set(ByVal value As Boolean)
				_rightToLeftLayout = value
			End Set
		End Property

		Private _result As VDialogResult
		''' <summary>
		''' Gets or sets the dialog result for the VDialog form.
		''' </summary>
		Public Property Result() As VDialogResult
			Get
				Return _result
			End Get
			Set(ByVal value As VDialogResult)
				_result = value
			End Set
		End Property

		Private _lockSystem As Boolean
		''' <summary>
		''' Determines whether to lock system while showing the Vista-like task dialog.
		''' </summary>
		Public Property LockSystem() As Boolean
			Get
				Return _lockSystem
			End Get
			Set(ByVal value As Boolean)
				_lockSystem = value
			End Set
		End Property

		Private _control As Control
		''' <summary>
		''' Gets or sets the custom control to display in the Vista-like task dialog.
		''' </summary>
		Public Property CustomControl() As Control
			Get
				Return _control
			End Get
			Set(ByVal value As Control)
				_control = value
			End Set
		End Property

		Private _verificationFlagChecked As CheckState
		''' <summary>
		''' Gets or sets a value indicating whether the verification checkbox in the dialog should be checked when the dialog is initially displayed.
		''' </summary>
		Public Property VerificationFlagChecked() As CheckState
			Get
				Return _verificationFlagChecked
			End Get
			Set(ByVal value As CheckState)
				_verificationFlagChecked = value
			End Set
		End Property

		Private _verificationText As String
		''' <summary>
		''' Gets or sets the string to be used to label the verification checkbox. If this parameter is Nothing (null), the verification checkbox is not displayed in the Vista-like task dialog.
		''' </summary>
		Public Property VerificationText() As String
			Get
				Return _verificationText
			End Get
			Set(ByVal value As String)
				_verificationText = value
			End Set
		End Property

		Private _expandFooterArea As Boolean
		''' <summary>
		''' Gets or sets a value indicating whether the the string specified by the ExpandedInformation property should be displayed at the bottom of the Vista-like task dialog's footer area instead of immediately after the Vista-like task dialog's content.
		''' </summary>
		Public Property ExpandFooterArea() As Boolean
			Get
				Return _expandFooterArea
			End Get
			Set(ByVal value As Boolean)
				_expandFooterArea = value
			End Set
		End Property

		Private _expandedByDefault As Boolean
		''' <summary>
		''' Gets or sets a value indicating whether the string specified by the ExpandedInformation property should be displayed when the Vista-like task dialog is initially displayed.
		''' </summary>
		Public Property ExpandedByDefault() As Boolean
			Get
				Return _expandedByDefault
			End Get
			Set(ByVal value As Boolean)
				_expandedByDefault = value
			End Set
		End Property

		Private _expandedInformation As String
		''' <summary>
		''' Gets or sets the string to be used for displaying additional information. The additional information is displayed either immediately below the content or below the footer text depending on whether the ExpandFooterArea property is set.
		''' </summary>
		Public Property ExpandedInformation() As String
			Get
				Return _expandedInformation
			End Get
			Set(ByVal value As String)
				_expandedInformation = value
			End Set
		End Property

		Private _expanded As LinkLabel
		''' <summary>
		''' The collection of links contained within the Footer LinkLabel.
		''' </summary>
		Public ReadOnly Property ExpandedInformationLinks() As LinkLabel.LinkCollection
			Get
				If _expanded Is Nothing Then
					If _vdf IsNot Nothing Then
						_expanded = [If](ExpandFooterArea, _vdf.LabelExpandedFooter, _vdf.LabelExpandedContent)
					Else
						_expanded = New LinkLabel()
					End If
				End If
				Return _expanded.Links
			End Get
		End Property

		Private _expandedControlText As String
		''' <summary>
		''' Gets or sets the string to be used to label the button for collapsing the expandable information.
		''' </summary>
		Public Property ExpandedControlText() As String
			Get
				Return _expandedControlText
			End Get
			Set(ByVal value As String)
				_expandedControlText = value
			End Set
		End Property

		Private _collapsedControlText As String
		''' <summary>
		''' Gets or sets the string to be used to label the button for expanding the expandable information.
		''' </summary>
		Public Property CollapsedControlText() As String
			Get
				Return _collapsedControlText
			End Get
			Set(ByVal value As String)
				_collapsedControlText = value
			End Set
		End Property
#End Region

#Region " System Locking Methods "

		Private Function LockSystemAndShow() As VDialogResult

			Dim owner As Control = TryCast(Me.Owner, Control)
			Dim screen As Screen
			If owner Is Nothing Then
				screen = screen.PrimaryScreen
			Else
				screen = screen.FromControl(owner)
			End If
			Dim background As Bitmap = New Bitmap(screen.Bounds.Width, screen.Bounds.Height)
			Using g As Graphics = Graphics.FromImage(background)

				g.CopyFromScreen(0, 0, 0, 0, screen.Bounds.Size)
				Using br As Brush = New SolidBrush(Color.FromArgb(192, Color.Black))
					g.FillRectangle(br, screen.Bounds)
				End Using

				If owner IsNot Nothing Then
					Dim form As Form = owner.FindForm()
					g.CopyFromScreen(form.Location, form.Location, form.Size)
					Using br As Brush = New SolidBrush(Color.FromArgb(128, Color.Black))
						g.FillRectangle(br, New Rectangle(form.Location, form.Size))
					End Using
				End If

				Dim originalThread As IntPtr
				Dim originalInput As IntPtr
				Dim newDesktop As IntPtr

				originalThread = GetThreadDesktop(Thread.CurrentThread.ManagedThreadId)
				originalInput = OpenInputDesktop(0, False, DESKTOP_SWITCHDESKTOP)

                newDesktop = CreateDesktop("Desktop" & Guid.NewGuid().ToString(), Nothing, Nothing, 0, GENERIC_ALL, Nothing)
				SetThreadDesktop(newDesktop)
				SwitchDesktop(newDesktop)

				Dim newThread As Thread = New Thread(AddressOf NewThreadMethod)
				newThread.CurrentCulture = Thread.CurrentThread.CurrentCulture
				newThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture
				newThread.Start(New VDialogLockSystemParameters(newDesktop, background))
				newThread.Join()

				SwitchDesktop(originalInput)
				SetThreadDesktop(originalThread)

				CloseDesktop(newDesktop)
				CloseDesktop(originalInput)

				Return Result
			End Using

		End Function

		Private Sub NewThreadMethod(ByVal params As Object)
			Dim v As VDialogLockSystemParameters = DirectCast(params, VDialogLockSystemParameters)
			SetThreadDesktop(v.NewDesktop)
			Using f As Form = New BackgroundForm(v.Background)
				f.Show()
				ShowInternal(f)
				f.BackgroundImage = Nothing
				Application.DoEvents()
				Thread.Sleep(250)
			End Using
		End Sub

#End Region

#Region " Events "

		Public Event LinkClicked As LinkLabelLinkClickedEventHandler

#End Region

#End Region

	End Class

End Namespace