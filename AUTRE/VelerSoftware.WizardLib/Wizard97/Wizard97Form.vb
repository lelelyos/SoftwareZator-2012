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
Public Class Wizard97Form

#Region "Property"

#Region "NextButtonText"

    Private _NextButtonText As String = "Suivant"
    <ComponentModel.Category("Propriétés de Wizard97Form"), ComponentModel.Description("Texte du bouton 'Suivant'"), ComponentModel.DefaultValue("Suivant")> _
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
    <ComponentModel.Category("Propriétés de Wizard97Form"), ComponentModel.Description("Texte du bouton 'Terminer'"), ComponentModel.DefaultValue("Terminer")> _
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
    <ComponentModel.Category("Propriétés de Wizard97Form"), ComponentModel.Description("Texte du bouton 'Annuler'"), ComponentModel.DefaultValue("Annuler")> _
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

#Region "BackButtonText"

    Private _BackButtonText As String = "Précédent"
    <ComponentModel.Category("Propriétés de Wizard97Form"), ComponentModel.Description("Texte du bouton 'Précédent'."), ComponentModel.DefaultValue("Précédent")> _
    Public Property BackButtonText() As String
        Get
            Return _BackButtonText
        End Get
        Set(ByVal value As String)
            _BackButtonText = value
            RaiseEvent OnBackButtonTextChanged(Me, New System.EventArgs())
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche lorsque la propriété 'NextButtonText' change.")> _
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche lorsque la propriété 'FinishButtonText' change.")> _
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche lorsque la propriété 'CancelButtonText' change.")> _
    Public Event OnCancelButtonTextChanged As OnCancelButtonTextChangedEventHandler

#End Region

#Region "OnBackButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnBackButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche lorsque la propriété 'BackButtonText' change.")> _
    Public Event OnBackButtonTextChanged As OnBackButtonTextChangedEventHandler

#End Region

#Region "OnNextButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnNextButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Suivant'.")> _
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Terminer'.")> _
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Précédent'.")> _
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
    <ComponentModel.Category("Evènement de Wizard97Form"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Annuler'.")> _
    Public Event OnCancelButtonClicked As OnCancelButtonClickedEventHandler

#End Region

#End Region

#Region "Method Events"

    Private Sub CancelButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnCancelButtonTextChanged
        Me.Cancel_Button.Text = CancelButtonText
    End Sub

    Private Sub BackButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnBackButtonTextChanged
        Me.Back_Button.Text = BackButtonText
    End Sub

#End Region







    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Next_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        CancelButtonText_Changed(Nothing, Nothing)
        BackButtonText_Changed(Nothing, Nothing)

        If Me.WizardTabControl1.TabPages.Count > 0 Then
            GoToTab(Me.WizardTabControl1.TabPages(0))
        End If
    End Sub

    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        CheckTabPageAndUpdateButtons()
    End Sub









    Public Sub DisableBackButton()
        Me.Back_Button.Enabled = False
    End Sub

    Public Sub EnableBackButton()
        Back_Button.Enabled = True
    End Sub

    Public Sub HideBackButton()
        Back_Button.Visible = False
    End Sub

    Public Sub ShowBackButton()
        Back_Button.Visible = True
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
        If Back_Button.Enabled Then 'Only navigate if not diabled
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

    Private Sub Back_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back_Button.Click
        If Back_Button.Enabled Then 'Only navigate if not diabled
            GoToTab(-1)
        End If

        RaiseEvent OnBackButtonClicked(Me.Back_Button, New System.EventArgs)
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
            RaiseEvent OnNextButtonClicked(Me.Next_Button, New System.EventArgs)
            GoToTab()
        End If

    End Sub

End Class