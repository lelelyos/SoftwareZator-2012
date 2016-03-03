''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.ComponentModel

<System.Windows.Forms.Docking(System.Windows.Forms.DockingBehavior.Ask), ComponentModel.DefaultProperty("Caption")> _
Public Class AeroWizardForm

    Private IsFormBeingDragged As Boolean = False 'Used for custom move code, scroll down to see the actual code.
    Private MouseDownX As Integer
    Private MouseDownY As Integer

#Region "Property"

    Private _AeroEnabled As Boolean
    Private Property AeroEnabled() As Boolean
        Get
            Return _AeroEnabled
        End Get
        Set(ByVal value As Boolean)
            _AeroEnabled = value
        End Set
    End Property

#Region "UseAero"

    Private _UseAero As Boolean = True
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Détermine si on doit utiliser le style Aero."), ComponentModel.DefaultValue(True)> _
    Public Property UseAero() As Boolean
        Get
            Return _UseAero
        End Get
        Set(ByVal value As Boolean)
            _UseAero = value
        End Set
    End Property

#End Region

#Region "NextButtonText"

    Private _NextButtonText As String = "Suivant"
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Texte du bouton 'Suivant'"), ComponentModel.DefaultValue("Suivant")> _
    Public Property NextButtonText() As String
        Get
            Return _NextButtonText
        End Get
        Set(ByVal value As String)
            _NextButtonText = value
            RaiseEvent OnNextButtonTextChanged(Me.Next_Button, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "FinishButtonText"

    Private _FinishButtonText As String = "Terminer"
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Texte du bouton 'Terminer'"), ComponentModel.DefaultValue("Terminer")> _
    Public Property FinishButtonText() As String
        Get
            Return _FinishButtonText
        End Get
        Set(ByVal value As String)
            _FinishButtonText = value
            RaiseEvent OnFinishButtonTextChanged(Me.Next_Button, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "CancelButtonText"

    Private _CancelButtonText As String = "Annuler"
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Texte du bouton 'Annuler'"), ComponentModel.DefaultValue("Annuler")> _
    Public Property CancelButtonText() As String
        Get
            Return _CancelButtonText
        End Get
        Set(ByVal value As String)
            _CancelButtonText = value
            RaiseEvent OnCancelButtonTextChanged(Me.Cancel_Button, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "Caption"

    Private _Caption As String = "Titre de l'assistant"
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Titre de l'assistant, affiché en haut à gauche."), ComponentModel.DefaultValue("Titre de l'assistant")> _
    Public Property Caption() As String
        Get
            Return _Caption
        End Get
        Set(ByVal value As String)
            _Caption = value
            RaiseEvent OnCaptionChanged(Me, New System.EventArgs())
        End Set
    End Property

#End Region

#Region "BackCaption"

    Private _BackCaption As String = "Précédent"
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Texte affiché lors du passage de la souris sur le bouton Précédent."), ComponentModel.DefaultValue("Précédent")> _
    Public Property BackCaption() As String
        Get
            Return _BackCaption
        End Get
        Set(ByVal value As String)
            _BackCaption = value
            RaiseEvent OnBackCaptionChanged(Me, New System.EventArgs())
        End Set
    End Property

#End Region

#Region "WizardIcon"

    Private _WizardIcon As Drawing.Image = My.Resources.icone
    <ComponentModel.Category("Propriétés de AeroWizardForm"), ComponentModel.Description("Icon de l'assistant")> _
    Public Property WizardIcon() As Drawing.Image
        Get
            Return _WizardIcon
        End Get
        Set(ByVal value As Drawing.Image)
            _WizardIcon = value
            RaiseEvent OnWizardIconChanged(Me, New System.EventArgs())
        End Set
    End Property

#End Region

#End Region

#Region "Events"

#Region "OnNextButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnNextButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'NextButtonText' change.")> _
    Public Event OnNextButtonTextChanged As OnNextButtonTextChangedEventHandler

#End Region

#Region "OnFinishButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnFinishButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'FinishButtonText' change.")> _
    Public Event OnFinishButtonTextChanged As OnFinishButtonTextChangedEventHandler

#End Region

#Region "OnCancelButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCancelButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'CancelButtonText' change.")> _
    Public Event OnCancelButtonTextChanged As OnCancelButtonTextChangedEventHandler

#End Region

#Region "OnCaptionChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCaptionChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'Caption' change.")> _
    Public Event OnCaptionChanged As OnCaptionChangedEventHandler

#End Region

#Region "OnBackCaptionChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnBackCaptionChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'BackCaption' change.")> _
    Public Event OnBackCaptionChanged As OnBackCaptionChangedEventHandler

#End Region

#Region "OnWizardIconChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnWizardIconChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'WizardIcon' change.")> _
    Public Event OnWizardIconChanged As OnWizardIconChangedEventHandler

#End Region

#Region "OnNextButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnNextButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Suivant'.")> _
    Public Event OnNextButtonClicked As OnNextButtonClickedEventHandler

#End Region

#Region "OnFinishButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnFinishButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Terminer'.")> _
    Public Event OnFinishButtonClicked As OnFinishButtonClickedEventHandler

#End Region

#Region "OnBackButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnBackButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Précédent'.")> _
    Public Event OnBackButtonClicked As OnBackButtonClickedEventHandler

#End Region

#Region "OnCancelButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCancelButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de AeroWizardForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Annuler'.")> _
    Public Event OnCancelButtonClicked As OnCancelButtonClickedEventHandler

#End Region

#End Region

#Region "Method Events"

    Private Sub CancelButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnCancelButtonTextChanged
        Me.Cancel_Button.Text = CancelButtonText
    End Sub

    Private Sub Caption_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnCaptionChanged
        Me.Title_Label.Text = Me.Caption
    End Sub

    Private Sub BackCaption_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnBackCaptionChanged
        Me.ToolTip1.SetToolTip(Me.Back_PictureBox, BackCaption)
    End Sub

    Private Sub WizardIcon_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnWizardIconChanged
        Me.Icon_PictureBox.Image = Me.WizardIcon
    End Sub

#End Region







    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Back_PictureBox.Size = New Drawing.Size(25, 25)
        Me.Back_PictureBox.Location = New Drawing.Point(2, 7)
        Me.Icon_PictureBox.Location = New Drawing.Point(33, 11)
        Me.Title_Label.Location = New Drawing.Point(55, 11)

        Me.Next_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        If Not Me.DesignMode Then
            If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
                If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() Then
                    If UseAero Then
                        ' Activer le style Aero Glass (RibbonProfesionalRendererColorTableBlueGlass)
                        Me.BackColor = Drawing.Color.Black
                        Dim af As VelerSoftware.WizardLib.DWM.Margins = New VelerSoftware.WizardLib.DWM.Margins(Me.Header_Panel.Location.X, 0, Me.Header_Panel.Location.Y + Me.Header_Panel.Height, 0)
                        VelerSoftware.WizardLib.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                        AeroEnabled = True
                    Else
                        Me.BackColor = System.Drawing.Color.FromArgb(185, 209, 234)
                        AeroEnabled = False
                    End If
                Else
                    Me.BackColor = System.Drawing.Color.FromArgb(185, 209, 234)
                    AeroEnabled = False
                End If
            Else
                Me.BackColor = System.Drawing.Color.FromArgb(185, 209, 234)
                AeroEnabled = False
            End If
        End If

        Me.Header_Panel.Refresh()

        Caption_Changed(Nothing, Nothing)
        WizardIcon_Changed(Nothing, Nothing)
        BackCaption_Changed(Nothing, Nothing)
        CancelButtonText_Changed(Nothing, Nothing)

        If Me.WizardTabControl1.TabPages.Count > 0 Then
            GoToTab(Me.WizardTabControl1.TabPages(0))
        End If

        If Not Me.DesignMode Then
            Me.Next_Button.Focus()
        End If
    End Sub

    Private Sub WizardForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, Header_Panel.MouseMove, Icon_PictureBox.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Drawing.Point = New Drawing.Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub WizardForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, Header_Panel.MouseDown, Icon_PictureBox.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub WizardForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp, Header_Panel.MouseUp, Icon_PictureBox.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not Me.DesignMode Then
            If UseAero Then
                If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
                    If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() Then
                        If Not AeroEnabled Then
                            ' Activer le style Aero Glass (RibbonProfesionalRendererColorTableBlueGlass)
                            Me.BackColor = Drawing.Color.Black
                            Dim af As VelerSoftware.WizardLib.DWM.Margins = New VelerSoftware.WizardLib.DWM.Margins(Me.Header_Panel.Location.X, 0, Me.Header_Panel.Location.Y + Me.Header_Panel.Height, 0)
                            VelerSoftware.WizardLib.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                            AeroEnabled = True
                        End If
                    Else
                        If AeroEnabled Then
                            AeroEnabled = False
                        End If
                    End If
                End If
            Else
                AeroEnabled = False
            End If
        End If
    End Sub

    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        CheckTabPageAndUpdateButtons()
    End Sub









    Public Sub DisableBackButton()
        If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
            Back_PictureBox.Image = My.Resources.Win8_WizardButton_disabled
        Else
            Back_PictureBox.Image = My.Resources.WizardButton_disabled
        End If
        Back_PictureBox.Tag = "Disabled"
    End Sub

    Public Sub EnableBackButton()
        If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
            Back_PictureBox.Image = My.Resources.Win8_WizardButton_normal
        Else
            Back_PictureBox.Image = My.Resources.WizardButton_normal
        End If
        Back_PictureBox.Tag = "CanBack"
    End Sub

    Public Sub HideBackButton()
        Back_PictureBox.Visible = False
    End Sub

    Public Sub ShowBackButton()
        Back_PictureBox.Visible = True
    End Sub

    Public Sub DisableNextButton()
        Me.Next_Button.Enabled = False
    End Sub

    Public Sub EnableNextButton()
        Me.Next_Button.Enabled = True
    End Sub

    Public Sub HideNextButton()
        Me.Next_Button.Visible = False
    End Sub

    Public Sub ShowNextButton()
        Me.Next_Button.Visible = True
    End Sub

    Public Sub DisableCancelButton()
        Me.Cancel_Button.Enabled = False
    End Sub

    Public Sub EnableCancelButton()
        Me.Cancel_Button.Enabled = True
    End Sub

    Public Sub HideCancelButton()
        Me.Cancel_Button.Visible = False
    End Sub

    Public Sub ShowCancelButton()
        Me.Cancel_Button.Visible = True
    End Sub

    Public Sub SetNextButtonToFinish()
        Next_Button.Text = FinishButtonText
        Next_Button.Tag = "Finish"
    End Sub

    Public Sub SetNextButtonToNext()
        Next_Button.Text = NextButtonText
        Next_Button.Tag = "Next"
    End Sub

    Public Sub GoToNextStep()
        If Next_Button.Tag = "Finish" Then 'Close wizard when user clicks button when it says Finish.
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else 'Otherwise, go to the next tab.
            'If you want to navigate to another tab when a specific tab is the current tab, you can add some more complicated code here, too.
            'For example, if you want to navigate 2 tabs forward when the third tab is selected, you can add code with  'If...End If'  and  'GoToTab(2)'  here.
            GoToTab()
        End If
    End Sub

    Public Sub GoToBackStep()
        If Back_PictureBox.Tag = "CanBack" Then 'Only navigate if not diabled
            GoToTab(-1)
        End If
    End Sub

    ' Navigate to a tab by giving the amount of tabs to go forward or backward. Backward=negative number.
    Public Sub GoToTab(ByVal Nom As String)
        If Me.WizardTabControl1.TabPages.Count > 0 Then
            Me.WizardTabControl1.SelectedTab = Me.WizardTabControl1.TabPages(Nom)
            CheckTabPageAndUpdateButtons()
        End If
    End Sub

    Private Sub Back_PictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back_PictureBox.Click
        If Back_PictureBox.Tag = "CanBack" Then 'Only navigate if not diabled
            GoToTab(-1)
        End If

        RaiseEvent OnBackButtonClicked(Me.Back_PictureBox, New System.EventArgs)
    End Sub



    Private Sub Back_PictureBox_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back_PictureBox.MouseEnter
        If Back_PictureBox.Tag = "CanBack" Then
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_hot
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_hot
            End If
        Else
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_disabled
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_disabled
            End If
        End If
    End Sub

    Private Sub Back_PictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Back_PictureBox.MouseDown
        If Back_PictureBox.Tag = "CanBack" Then
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_pressed
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_pressed
            End If
        Else
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_disabled
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_disabled
            End If
        End If
    End Sub

    Private Sub Back_PictureBox_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back_PictureBox.MouseLeave
        If Back_PictureBox.Tag = "CanBack" Then
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_normal
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_normal
            End If
        Else
            If VelerSoftware.WizardLib.Core.RunningOnWin8 Then
                Back_PictureBox.Image = My.Resources.Win8_WizardButton_disabled
            Else
                Back_PictureBox.Image = My.Resources.WizardButton_disabled
            End If
        End If
    End Sub

    ' Navigate to a tab by giving the amount of tabs to go forward or backward. Backward=negative number.
    Public Sub GoToTab(Optional ByVal Aantal As Integer = 1)
        If Me.WizardTabControl1.TabPages.Count > 0 Then
            WizardTabControl1.SelectedIndex = WizardTabControl1.SelectedIndex + Aantal
            CheckTabPageAndUpdateButtons()
        End If
    End Sub

    ' Navigate to a tab by giving the tab.
    Public Sub GoToTab(ByVal Tab As System.Windows.Forms.TabPage)
        If Me.WizardTabControl1.TabPages.Count > 0 Then
            WizardTabControl1.SelectedTab = Tab
            CheckTabPageAndUpdateButtons()
        End If
    End Sub

    'Update the buttons, this means that when, for example, the first tab is selected, the back button should be disabled.
    Public Sub CheckTabPageAndUpdateButtons()
        If WizardTabControl1.SelectedIndex = 0 Then
            DisableBackButton()
        Else
            EnableBackButton()
        End If
        If WizardTabControl1.SelectedIndex = WizardTabControl1.TabCount - 1 Then
            SetNextButtonToFinish()
        Else
            SetNextButtonToNext()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

        RaiseEvent OnCancelButtonClicked(Me.Cancel_Button, New System.EventArgs)
    End Sub

    Private Sub Next_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Next_Button.Click
        If Next_Button.Tag = "Finish" Then 'Close wizard when user clicks button when it says Finish.   
            RaiseEvent OnFinishButtonClicked(Me.Next_Button, New System.EventArgs)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else 'Otherwise, go to the next tab.
            'If you want to navigate to another tab when a specific tab is the current tab, you can add some more complicated code here, too.
            'For example, if you want to navigate 2 tabs forward when the third tab is selected, you can add code with  'If...End If'  and  'GoToTab(2)'  here.
            GoToTab()
            RaiseEvent OnNextButtonClicked(Me.Next_Button, New System.EventArgs)
        End If

    End Sub

    Declare Function GetActiveWindow Lib "user32" () As System.IntPtr

    Private Sub Header_Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Header_Panel.Paint
        If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                Me.Title_Label.Visible = True
                If Me.Handle = GetActiveWindow() Then
                    Form1_Form_Activated(Nothing, Nothing)
                Else
                    Form1_Form_Deactivate(Nothing, Nothing)
                End If
            Else
                If Me.Title_Label.Text.Length > 0 Then
                    Me.Title_Label.Visible = False
                    VelerSoftware.WizardLib.DWM.DrawTextGlow(e.Graphics, Me.Title_Label.Text, Me.Title_Label.Font, Me.Title_Label.Bounds, Me.Title_Label.ForeColor, System.Windows.Forms.TextFormatFlags.VerticalCenter Or System.Windows.Forms.TextFormatFlags.HorizontalCenter Or System.Windows.Forms.TextFormatFlags.NoPrefix Or System.Windows.Forms.TextFormatFlags.SingleLine)
                End If
            End If
        End If
    End Sub

    Private Sub Header_Panel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header_Panel.SizeChanged
        Me.Header_Panel.Refresh()
    End Sub









    Private Sub Form1_Form_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                Me.BackColor = System.Drawing.Color.FromArgb(215, 227, 241)
            End If
        End If
    End Sub

    Private Sub Form1_Form_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                Me.BackColor = System.Drawing.Color.FromArgb(185, 208, 232)
            End If
        End If
    End Sub

End Class