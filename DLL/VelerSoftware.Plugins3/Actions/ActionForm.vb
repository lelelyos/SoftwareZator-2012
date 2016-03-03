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
Public Class ActionForm

    Private IsFormBeingDragged As Boolean = False 'Used for custom move code, scroll down to see the actual code.
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Friend WithEvents CodeEditor As New VelerSoftware.SZC35.TextEditor

    Public Sub New()
        If Not CurrentCulture Is Nothing Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = CurrentCulture
            RM = New System.Resources.ResourceManager("VelerSoftware.Plugins3.Custom", GetType(ActionForm).Assembly)
        End If

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        With Me
            ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
            If Not CurrentCulture Is Nothing Then .CodeEditor_Text = RM.GetString("CodeEditorDefaultText")
            .Foot_Panel.Height = 48
            If .CodeEditor_Shown Then
                .CodeEditor_Shown = False
                .CodeEditor_Shown = True
            Else
                .CodeEditor_Shown = True
                .CodeEditor_Shown = False
            End If
            With .CodeEditor
                .ShowLineNumbers = True
                .FontFamily = New System.Windows.Media.FontFamily("Consolas")
                .FontSize = 12
                .IsReadOnly = True
                .isLineSingle = True
                .SpellCheck = False
                .SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("VBNET")
                '.SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("Action")
            End With
            .CodeEditorHost.Child = .CodeEditor

        End With
    End Sub

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
    <ComponentModel.Category("Propriétés de ActionForm"), ComponentModel.Description("Détermine si on doit utiliser le style Aero."), ComponentModel.DefaultValue(True)> _
    Public Property UseAero() As Boolean
        Get
            Return _UseAero
        End Get
        Set(ByVal value As Boolean)
            _UseAero = value
        End Set
    End Property

#End Region

#Region "OKButtonText"

    Private _OKButtonText As String = "OK"
    <ComponentModel.Category("Propriétés de ActionForm"), ComponentModel.Description("Texte du bouton 'OK'"), ComponentModel.DefaultValue("")> _
    Public Property OKButtonText() As String
        Get
            Return _OKButtonText
        End Get
        Set(ByVal value As String)
            _OKButtonText = value
            RaiseEvent OnOKButtonTextChanged(Me.OK_Button, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "CancelButtonText"

    Private _CancelButtonText As String = "Annuler"
    <ComponentModel.Category("Propriétés de ActionForm"), ComponentModel.Description("Texte du bouton 'Annuler'"), ComponentModel.DefaultValue("")> _
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

#Region "Title"

    Private _Title As String = "Sans titre"
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Texte du titre de la fenêtre."), System.ComponentModel.DefaultValue("Sans Titre")> _
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            RaiseEvent OnTitleChanged(Me.LabelTitle, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "Icon"

    Private _Icon As Drawing.Image
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Icône de la fenêtre."), System.ComponentModel.DefaultValue("")> _
    Public Property Icon_Windows() As Drawing.Image
        Get
            Return _Icon
        End Get
        Set(ByVal value As Drawing.Image)
            _Icon = value
            Me.Icon_PictureBox.Image = _Icon
        End Set
    End Property

#End Region

#Region "Help_Button"

    Private _Help_Button_Visible As Boolean = True
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si le bouton d'aide en bas à gauche est visible ou pas."), System.ComponentModel.DefaultValue(True)> _
    Public Property Help_Button_Visible() As Boolean
        Get
            Return _Help_Button_Visible
        End Get
        Set(ByVal value As Boolean)
            _Help_Button_Visible = value
            Me.Help_Button.Visible = value
        End Set
    End Property

    Private _Help_File As String
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Définit le fichier HTML devant être ouvert dans le logiciel 'Aide' de SoftwareZator lorsqu'on clic sur le bouton d'aide."), System.ComponentModel.DefaultValue("")> _
    Public Property Help_File() As String
        Get
            Return _Help_File
        End Get
        Set(ByVal value As String)
            _Help_File = value
        End Set
    End Property

#End Region

#Region "ShowHideCodeEditor_Button"

    Private _ShowHideCodeEditor_Button_Visible As Boolean = True
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si le bouton d'affichage de l'éditeur de code, en bas à gauche, est visible ou pas."), System.ComponentModel.DefaultValue(True)> _
    Public Property ShowHideCodeEditor_Button_Visible() As Boolean
        Get
            Return _ShowHideCodeEditor_Button_Visible
        End Get
        Set(ByVal value As Boolean)
            _ShowHideCodeEditor_Button_Visible = value
            RaiseEvent OnShowHideCodeEditorButtonVisibleChanged(Me.ShowHideCodeEditor_Button, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "RefreshCode_Button"

    Private _RefreshCode_Button_Visible As Boolean = True
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si le bouton permettant de rafraichir le code généré, en bas à droite de l'éditeur de code, est visible ou pas."), System.ComponentModel.DefaultValue(True)> _
    Public Property RefreshCode_Button_Visible() As Boolean
        Get
            Return _RefreshCode_Button_Visible
        End Get
        Set(ByVal value As Boolean)
            _RefreshCode_Button_Visible = value
            RaiseEvent OnRefreshCodeButtonVisibleChanged(Me.RefreshCodeButton, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "ParseCode_Button"

    Private _ParseCode_Button_Visible As Boolean = True
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si le bouton permettant de rafraichir les paramètres de l'action en fonction du code, en bas à droite de l'éditeur de code, est visible ou pas."), System.ComponentModel.DefaultValue(True)> _
    Public Property ParseCode_Button_Visible() As Boolean
        Get
            Return _ParseCode_Button_Visible
        End Get
        Set(ByVal value As Boolean)
            _ParseCode_Button_Visible = value
            RaiseEvent OnParseCodeButtonVisibleChanged(Me.ParseCodeButton, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "CodeEditor_Shown"

    Private _CodeEditor_Shown As Boolean = False
    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si l'éditeur de code est actuellement affiché ou pas."), System.ComponentModel.DefaultValue(False)> _
    Public Property CodeEditor_Shown() As Boolean
        Get
            Return _CodeEditor_Shown
        End Get
        Set(ByVal value As Boolean)
            _CodeEditor_Shown = value
            If value Then
                Me.ShowCodeEditor()
                Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronLess
            Else
                Me.HideCodeEditor()
                Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronMore
            End If
            RaiseEvent OnCodeEditorShownChanged(Me.CodeEditor, New System.EventArgs)
        End Set
    End Property

#End Region

#Region "CodeEditor_Used"

    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Détermine si la case à coché 'Editer le code VB.Net' est coché ou pas."), System.ComponentModel.DefaultValue(False)> _
    Public Property CodeEditor_Used() As Boolean
        Get
            Return Me.EditCode_CheckBox.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.EditCode_CheckBox.Checked = value
            Me.CodeEditor.IsReadOnly = If(value, False, True)
        End Set
    End Property

#End Region

#Region "CodeEditor_Text"

    <System.ComponentModel.Category("Propriétés de ActionForm"), System.ComponentModel.Description("Est égale au texte affiché dans l'éditeur de code."), System.ComponentModel.DefaultValue("")> _
    Public Property CodeEditor_Text() As String
        Get
            Return Me.CodeEditor.Document.Text
        End Get
        Set(ByVal value As String)
            If Not Me.CodeEditor.Document.Text = value Then Me.CodeEditor.Document.Text = value
            RaiseEvent OnCodeEditorTextChanged(Me.CodeEditor, New System.EventArgs)
        End Set
    End Property

#End Region







    Private _Tools As VelerSoftware.Plugins3.Tools
    Public Property Tools As VelerSoftware.Plugins3.Tools
        Get
            Return Me._Tools
        End Get
        Set(ByVal value As VelerSoftware.Plugins3.Tools)
            _Tools = value
        End Set
    End Property

#End Region

#Region "Events"

#Region "OnOKButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnOKButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'OKButtonText' change.")> _
    Public Event OnOKButtonTextChanged As OnOKButtonTextChangedEventHandler

#End Region

#Region "OnCancelButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCancelButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'CancelButtonText' change.")> _
    Public Event OnCancelButtonTextChanged As OnCancelButtonTextChangedEventHandler

#End Region

#Region "OnOKButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnOKButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Suivant'.")> _
    Public Event OnOKButtonClicked As OnOKButtonClickedEventHandler

#End Region

#Region "OnCancelButtonClicked"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCancelButtonClickedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Annuler'.")> _
    Public Event OnCancelButtonClicked As OnCancelButtonClickedEventHandler

#End Region

#Region "OnTitleChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnTitleChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété Title de la fenêtre change.")> _
    Public Event OnTitleChanged As OnTitleChangedEventHandler
#End Region

#Region "OnShowHideCodeEditorButtonVisibleChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnShowHideCodeEditorButtonVisibleEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété ShowHideCodeEditor_Button_Visible de la fenêtre change.")> _
    Public Event OnShowHideCodeEditorButtonVisibleChanged As OnShowHideCodeEditorButtonVisibleEventHandler
#End Region

#Region "OnRefreshCodeButtonVisibleChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnRefreshCodeButtonVisibleEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété RefreshCode_Button_Visible de la fenêtre change.")> _
    Public Event OnRefreshCodeButtonVisibleChanged As OnRefreshCodeButtonVisibleEventHandler
#End Region

#Region "OnParseCodeButtonVisibleChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnParseCodeButtonVisibleEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété ParseCode_Button_Visible de la fenêtre change.")> _
    Public Event OnParseCodeButtonVisibleChanged As OnParseCodeButtonVisibleEventHandler
#End Region

#Region "OnCodeEditorShownChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCodeEditorShownChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété CodeEditor_Shown de la fenêtre change.")> _
    Public Event OnCodeEditorShownChanged As OnCodeEditorShownChangedEventHandler
#End Region

#Region "OnShowHideCodeEditorButtonClick"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnShowHideCodeEditorButtonClickEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche après un clic sur le bouton ShowHideCodeEditor_Button.")> _
    Public Event OnShowHideCodeEditorButtonClick As OnShowHideCodeEditorButtonClickEventHandler
#End Region

#Region "OnTitleChanged"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCodeEditorTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche lorsque la valeur de la propriété CodeEditor_Text change.")> _
    Public Event OnCodeEditorTextChanged As OnCodeEditorTextChangedEventHandler
#End Region

#Region "OnRefreshCodeButtonClick"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnRefreshCodeButtonClickEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche d'un clic sur le bouton 'Cliquez-ici pour mettre à jour le code Visual Basic.Net en fonction des paramètres de l'action.', en bas à droite de l'éditeur de code.")> _
    Public Event OnRefreshCodeButtonClick As OnRefreshCodeButtonClickEventHandler
#End Region

#Region "OnParseCodeButtonClick"
    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnParseCodeButtonClickEventHandler(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ActionForm"), ComponentModel.Description("Se déclenche d'un clic sur le bouton 'Cliquez-ici pour mettre à jour ls paramètres de l'action en fonction du code Visual Basic.Net ci-dessus.', en bas à droite de l'éditeur de code.")> _
    Public Event OnParseCodeButtonClick As OnParseCodeButtonClickEventHandler
#End Region

#End Region

#Region "Method Events"

    Private Sub CancelButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnCancelButtonTextChanged
        Me.Cancel_Button.Text = CancelButtonText
    End Sub

    Private Sub okButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnOKButtonTextChanged
        Me.OK_Button.Text = OKButtonText
    End Sub

    Private Sub Title_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnTitleChanged
        Me.LabelTitle.Text = Title
    End Sub

    Private Sub ShowHideCodeEditorButtonVisible_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnShowHideCodeEditorButtonVisibleChanged
        Me.ShowHideCodeEditor_Button.Visible = Me.ShowHideCodeEditor_Button_Visible
    End Sub

    Private Sub RefreshCodeButtonVisible_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnRefreshCodeButtonVisibleChanged
        Me.RefreshCodeButton.Visible = Me.RefreshCode_Button_Visible
    End Sub

    Private Sub ParseCodeButtonVisible_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnParseCodeButtonVisibleChanged
        Me.ParseCodeButton.Visible = Me.ParseCode_Button_Visible
    End Sub

#End Region





    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.Anchor = Me.OK_Button.Anchor

        If Not Me.DesignMode Then
            If (VelerSoftware.Plugins3.Windows.Cores.RunningOnWinVistaOr7Or8) Then
                If VelerSoftware.Plugins3.Windows.DWM.DwmIsCompositionEnabled() Then
                    If UseAero Then
                        ' Activer le style Aero Glass (RibbonProfesionalRendererColorTableBlueGlass)
                        Me.BackColor = Drawing.Color.Black
                        Dim af As VelerSoftware.Plugins3.Windows.DWM.Margins = New VelerSoftware.Plugins3.Windows.DWM.Margins(Me.Header_Panel.Location.X, 0, Me.Header_Panel.Location.Y + Me.Header_Panel.Height, 0)
                        VelerSoftware.Plugins3.Windows.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
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
                If AeroEnabled Then
                    Me.BackColor = System.Drawing.Color.FromArgb(185, 209, 234)
                    AeroEnabled = False
                End If
            End If
        End If

        Me.Header_Panel.Refresh()

        okButtonText_Changed(Nothing, Nothing)
        CancelButtonText_Changed(Nothing, Nothing)
    End Sub

    Private Sub WizardForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove, Header_Panel.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Drawing.Point = New Drawing.Point()
            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub WizardForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown, Header_Panel.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub WizardForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp, Header_Panel.MouseUp
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not Me.DesignMode Then
            If UseAero Then
                If (VelerSoftware.Plugins3.Windows.Cores.RunningOnWinVistaOr7Or8) Then
                    If VelerSoftware.Plugins3.Windows.DWM.DwmIsCompositionEnabled() Then
                        If Not AeroEnabled Then
                            ' Activer le style Aero Glass (RibbonProfesionalRendererColorTableBlueGlass)
                            Me.BackColor = Drawing.Color.Black
                            Dim af As VelerSoftware.Plugins3.Windows.DWM.Margins = New VelerSoftware.Plugins3.Windows.DWM.Margins(Me.Header_Panel.Location.X, 0, Me.Header_Panel.Location.Y + Me.Header_Panel.Height, 0)
                            VelerSoftware.Plugins3.Windows.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                            AeroEnabled = True
                        End If
                    Else
                        If AeroEnabled Then
                            AeroEnabled = False
                        End If
                    End If
                End If
            Else
                If AeroEnabled Then
                    AeroEnabled = False
                End If
            End If

            'Select Case Variables.SZ_Edition
            '    Case 0
            '        If Me.ShowHideCodeEditor_Button_Visible Then Me.ShowHideCodeEditor_Button_Visible = False
            '        If Me.ShowHideCodeEditor_Button.Visible Then Me.ShowHideCodeEditor_Button.Visible = False
            '        If Me.EditCode_CheckBox.Visible Then Me.EditCode_CheckBox.Visible = False
            '        If Me.RefreshCode_Button_Visible Then Me.RefreshCode_Button_Visible = False
            '        If Me.RefreshCodeButton.Visible Then Me.RefreshCodeButton.Visible = False
            '        If Me.ParseCode_Button_Visible Then Me.ParseCode_Button_Visible = False
            '        If Me.ParseCodeButton.Visible Then Me.ParseCodeButton.Visible = False
            '    Case 1
            '        If Me.EditCode_CheckBox.Enabled Then Me.EditCode_CheckBox.Enabled = False
            '        If Me.ParseCodeButton.Enabled Then Me.ParseCodeButton.Enabled = False
            '    Case 2
            '        If Me.EditCode_CheckBox.Enabled Then Me.EditCode_CheckBox.Enabled = False
            '        If Me.ParseCodeButton.Enabled Then Me.ParseCodeButton.Enabled = False
            'End Select
        End If
    End Sub















    Public Sub DisableOKButton()
        Me.OK_Button.Enabled = False
    End Sub

    Public Sub EnableOKButton()
        Me.OK_Button.Enabled = True
    End Sub

    Public Sub HideOKButton()
        Me.OK_Button.Visible = False
    End Sub

    Public Sub ShowOKButton()
        Me.OK_Button.Visible = True
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

    Public Sub ShowCodeEditor()
        With Me
            If Not .Foot_Panel.Height = 150 Then
                .Height += 102
                .Foot_Panel.Height = 150
                .CodeEditorPanel.Visible = True
                .CodeEditor_Shown = True
                Me.ActionForm_Shown(Nothing, Nothing)
                If (.Location.Y + .Height) >= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height Then
                    .Location = New Drawing.Point(.Location.X, (.Location.Y) - ((.Location.Y + .Height) - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height))
                End If
            End If
        End With
    End Sub

    Public Sub HideCodeEditor()
        With Me
            If Not .Foot_Panel.Height = 48 Then
                .Height -= 102
                .Foot_Panel.Height = 48
                .CodeEditorPanel.Visible = False
                .CodeEditor_Shown = False
            End If
        End With
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        RaiseEvent OnCancelButtonClicked(Me.Cancel_Button, New System.EventArgs)
    End Sub

    Private Sub Next_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        RaiseEvent OnOKButtonClicked(Me.OK_Button, New System.EventArgs)
    End Sub

    Declare Function GetActiveWindow Lib "user32" () As System.IntPtr

    Private Sub Header_Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Header_Panel.Paint, Me.Paint
        If (VelerSoftware.Plugins3.Windows.Cores.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.SZVB.Windows.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                If Me.Handle = GetActiveWindow() Then
                    Form1_Form_Activated(Nothing, Nothing)
                Else
                    Form1_Form_Deactivate(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

    Private Sub Header_Panel_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header_Panel.SizeChanged, Me.SizeChanged
        Me.Header_Panel.Refresh()
    End Sub

    Private Sub Form1_Form_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If (VelerSoftware.Plugins3.Windows.Cores.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.SZVB.Windows.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                Me.BackColor = System.Drawing.Color.FromArgb(215, 227, 241)
            End If
        End If
    End Sub

    Private Sub Form1_Form_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If (VelerSoftware.Plugins3.Windows.Cores.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.SZVB.Windows.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
                Me.BackColor = System.Drawing.Color.FromArgb(185, 208, 232)
            End If
        End If
    End Sub

    Private Sub ShowHideCodeEditor_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideCodeEditor_Button.Click
        If Me.CodeEditor_Shown Then
            Me.CodeEditor_Shown = False
        Else
            Me.CodeEditor_Shown = True
        End If
        RaiseEvent OnShowHideCodeEditorButtonClick(Me.ShowHideCodeEditor_Button, New System.EventArgs)
    End Sub

    Private Sub ShowHideCodeEditor_Button_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideCodeEditor_Button.MouseEnter
        If Me.CodeEditor_Shown Then
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronLessHovered
        Else
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronMoreHovered
        End If
    End Sub

    Private Sub ShowHideCodeEditor_Button_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHideCodeEditor_Button.MouseLeave
        If Me.CodeEditor_Shown Then
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronLess
        Else
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronMore
        End If
    End Sub

    Private Sub ShowHideCodeEditor_Button_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ShowHideCodeEditor_Button.MouseDown
        If Me.CodeEditor_Shown Then
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronLessPressed
        Else
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronMorePressed
        End If
    End Sub

    Private Sub ShowHideCodeEditor_Button_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ShowHideCodeEditor_Button.MouseUp
        If Me.CodeEditor_Shown Then
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronLessHovered
        Else
            Me.ShowHideCodeEditor_Button.Image = My.Resources.ChevronMoreHovered
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCode_CheckBox.CheckedChanged
        If Not Variables.SZ_Edition = 3 Then
            If Me.EditCode_CheckBox.Checked = False Then Exit Sub
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Me
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                .Content = RM.GetString("Should_Professional")
                .MainInstruction = RM.GetString("MainInstruction")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            Me.EditCode_CheckBox.Checked = False
        End If

        With Me
            If .EditCode_CheckBox.Checked Then
                .CodeEditor.IsReadOnly = False
                .Controls_Panel.Enabled = False
                .RefreshCodeButton.Enabled = False
            Else
                .CodeEditor.IsReadOnly = True
                .Controls_Panel.Enabled = True
                .RefreshCodeButton.Enabled = True
            End If
        End With
    End Sub

    Private Sub Help_Button_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help_Button.MouseEnter
        Me.Help_Button.Image = My.Resources.help2
    End Sub

    Private Sub Help_Button_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help_Button.MouseLeave
        Me.Help_Button.Image = My.Resources.help
    End Sub

    Private Sub Help_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help_Button.Click
        If Not Help_File = Nothing Then
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(VelerSoftware.Plugins3.Other.AppPath & "Help\" & VelerSoftware.Plugins3.CurrentCulture.Name & "\Plugins\", Help_File)) Then
                If My.Computer.FileSystem.FileExists(VelerSoftware.Plugins3.Other.AppPath & "Help.exe") Then
                    System.Diagnostics.Process.Start(VelerSoftware.Plugins3.Other.AppPath & "Help.exe", ChrW(34) & My.Computer.FileSystem.CombinePath(VelerSoftware.Plugins3.Other.AppPath & "Help\" & VelerSoftware.Plugins3.CurrentCulture.Name & "\Plugins\", Help_File) & ChrW(34))
                End If
            End If
        End If
    End Sub

    Private Sub CodeEditor_TextChanged() Handles CodeEditor.TextChanged
        Me.CodeEditor_Text = Me.CodeEditor.Document.Text
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        With Me
            If .CodeEditor.IsReadOnly Then
                .CouperToolStripMenuItem.Enabled = False
                .CollerToolStripMenuItem.Enabled = False
                .AnnulerToolStripMenuItem.Enabled = False
                .RétablirToolStripMenuItem.Enabled = False
            Else
                .CouperToolStripMenuItem.Enabled = True
                .CollerToolStripMenuItem.Enabled = True
                .AnnulerToolStripMenuItem.Enabled = True
                .RétablirToolStripMenuItem.Enabled = True
            End If
        End With
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripMenuItem.Click
        Me.CodeEditor.Copy()
    End Sub

    Private Sub CouperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouperToolStripMenuItem.Click
        Me.CodeEditor.Cut()
    End Sub

    Private Sub CollerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollerToolStripMenuItem.Click
        Me.CodeEditor.Paste()
    End Sub

    Private Sub SélectionnerToutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SélectionnerToutToolStripMenuItem.Click
        Me.CodeEditor.SelectAll()
    End Sub

    Private Sub AnnulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerToolStripMenuItem.Click
        Me.CodeEditor.Undo()
    End Sub

    Private Sub RétablirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RétablirToolStripMenuItem.Click
        Me.CodeEditor.Redo()
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshCodeButton.MouseEnter
        Me.RefreshCodeButton.Image = My.Resources.show_code2
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshCodeButton.MouseLeave
        Me.RefreshCodeButton.Image = My.Resources.show_code
    End Sub

    Private Sub RefreshCodeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshCodeButton.Click
        If Variables.SZ_Edition = 0 Then
            Dim vd2 As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd2
                .Owner = Me
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                .Content = RM.GetString("Should_Standard")
                .MainInstruction = RM.GetString("MainInstruction")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            Exit Sub
        End If
        RaiseEvent OnRefreshCodeButtonClick(sender, e)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles ParseCodeButton.Click
        If Not Variables.SZ_Edition = 3 Then
            Dim vd2 As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd2
                .Owner = Me
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                .Content = RM.GetString("Should_Professional")
                .MainInstruction = RM.GetString("MainInstruction")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            Exit Sub
        End If

        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Me
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
            .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Question
            .Content = RM.GetString("ParserQuestion")
            .MainInstruction = RM.GetString("MainInstruction")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With
        If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then ' Si l'utilisateur veux ajouter le projet à la solution
            Dim Visit As New VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
            Dim Parser As VelerSoftware.SZC.VBNetParser.IParser = VelerSoftware.SZC.VBNetParser.ParserFactory.CreateParser(New System.IO.StringReader("Namespace Parse" & Environment.NewLine & "Class Parse" & Environment.NewLine & "Sub Main" & Environment.NewLine & Me.CodeEditor.Document.Text & Environment.NewLine & "End Sub" & Environment.NewLine & "End Class" & Environment.NewLine & "End Namespace"))
            Parser.Parse()
            If Parser.Errors.Count = 0 Then
                Visit.VisitCompilationUnit(Parser.CompilationUnit, Nothing)
                RaiseEvent OnParseCodeButtonClick(Visit.codeCompileUnit, e)
            Else
                MsgBox("Unable to parse the code : " & Environment.NewLine & Parser.Errors.ErrorOutput)
            End If
            Parser.Dispose()
        End If
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParseCodeButton.MouseEnter
        Me.ParseCodeButton.Image = My.Resources.refresh2
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParseCodeButton.MouseLeave
        Me.ParseCodeButton.Image = My.Resources.refresh
    End Sub





#Region "PARAMETRES"

    Private _Param1 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 1 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param1 As String
        Get
            Return _Param1
        End Get
        Set(ByVal value As String)
            Me._Param1 = value
        End Set
    End Property

    Private _Param2 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 2 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param2 As String
        Get
            Return _Param2
        End Get
        Set(ByVal value As String)
            Me._Param2 = value
        End Set
    End Property

    Private _Param3 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 3 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param3 As String
        Get
            Return _Param3
        End Get
        Set(ByVal value As String)
            Me._Param3 = value
        End Set
    End Property

    Private _Param4 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 4 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param4 As String
        Get
            Return _Param4
        End Get
        Set(ByVal value As String)
            Me._Param4 = value
        End Set
    End Property

    Private _Param5 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 5 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param5 As String
        Get
            Return _Param5
        End Get
        Set(ByVal value As String)
            Me._Param5 = value
        End Set
    End Property

    Private _Param6 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 6 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param6 As String
        Get
            Return _Param6
        End Get
        Set(ByVal value As String)
            Me._Param6 = value
        End Set
    End Property

    Private _Param7 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 7 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param7 As String
        Get
            Return _Param7
        End Get
        Set(ByVal value As String)
            Me._Param7 = value
        End Set
    End Property

    Private _Param8 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 8 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param8 As String
        Get
            Return _Param8
        End Get
        Set(ByVal value As String)
            Me._Param8 = value
        End Set
    End Property

    Private _Param9 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 9 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param9 As String
        Get
            Return _Param9
        End Get
        Set(ByVal value As String)
            Me._Param9 = value
        End Set
    End Property

    Private _Param10 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 10 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param10 As String
        Get
            Return _Param10
        End Get
        Set(ByVal value As String)
            Me._Param10 = value
        End Set
    End Property

    Private _Param11 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 11 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param11 As String
        Get
            Return _Param11
        End Get
        Set(ByVal value As String)
            Me._Param11 = value
        End Set
    End Property

    Private _Param12 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 12 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param12 As String
        Get
            Return _Param12
        End Get
        Set(ByVal value As String)
            Me._Param12 = value
        End Set
    End Property

    Private _Param13 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 13 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param13 As String
        Get
            Return _Param13
        End Get
        Set(ByVal value As String)
            Me._Param13 = value
        End Set
    End Property

    Private _Param14 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 14 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param14 As String
        Get
            Return _Param14
        End Get
        Set(ByVal value As String)
            Me._Param14 = value
        End Set
    End Property

    Private _Param15 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 15 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param15 As String
        Get
            Return _Param15
        End Get
        Set(ByVal value As String)
            Me._Param15 = value
        End Set
    End Property

    Private _Param16 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 16 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param16 As String
        Get
            Return _Param16
        End Get
        Set(ByVal value As String)
            Me._Param16 = value
        End Set
    End Property

    Private _Param17 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 17 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param17 As String
        Get
            Return _Param17
        End Get
        Set(ByVal value As String)
            Me._Param17 = value
        End Set
    End Property

    Private _Param18 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 18 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param18 As String
        Get
            Return _Param18
        End Get
        Set(ByVal value As String)
            Me._Param18 = value
        End Set
    End Property

    Private _Param19 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 19 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param19 As String
        Get
            Return _Param19
        End Get
        Set(ByVal value As String)
            Me._Param19 = value
        End Set
    End Property

    Private _Param20 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 20 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param20 As String
        Get
            Return _Param20
        End Get
        Set(ByVal value As String)
            Me._Param20 = value
        End Set
    End Property

    Private _Param21 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 21 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param21 As String
        Get
            Return _Param21
        End Get
        Set(ByVal value As String)
            Me._Param21 = value
        End Set
    End Property

    Private _Param22 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 22 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param22 As String
        Get
            Return _Param22
        End Get
        Set(ByVal value As String)
            Me._Param22 = value
        End Set
    End Property

    Private _Param23 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 23 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param23 As String
        Get
            Return _Param23
        End Get
        Set(ByVal value As String)
            Me._Param23 = value
        End Set
    End Property

    Private _Param24 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 24 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param24 As String
        Get
            Return _Param24
        End Get
        Set(ByVal value As String)
            Me._Param24 = value
        End Set
    End Property

    Private _Param25 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 25 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param25 As String
        Get
            Return _Param25
        End Get
        Set(ByVal value As String)
            Me._Param25 = value
        End Set
    End Property

    Private _Param26 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 26 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param26 As String
        Get
            Return _Param26
        End Get
        Set(ByVal value As String)
            Me._Param26 = value
        End Set
    End Property

    Private _Param27 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 27 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param27 As String
        Get
            Return _Param27
        End Get
        Set(ByVal value As String)
            Me._Param27 = value
        End Set
    End Property

    Private _Param28 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 28 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param28 As String
        Get
            Return _Param28
        End Get
        Set(ByVal value As String)
            Me._Param28 = value
        End Set
    End Property

    Private _Param29 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 29 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param29 As String
        Get
            Return _Param29
        End Get
        Set(ByVal value As String)
            Me._Param29 = value
        End Set
    End Property

    Private _Param30 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 30 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param30 As String
        Get
            Return _Param30
        End Get
        Set(ByVal value As String)
            Me._Param30 = value
        End Set
    End Property

    Private _Param31 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 31 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param31 As String
        Get
            Return _Param31
        End Get
        Set(ByVal value As String)
            Me._Param31 = value
        End Set
    End Property

    Private _Param32 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 32 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param32 As String
        Get
            Return _Param32
        End Get
        Set(ByVal value As String)
            Me._Param32 = value
        End Set
    End Property

    Private _Param33 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 33 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param33 As String
        Get
            Return _Param33
        End Get
        Set(ByVal value As String)
            Me._Param33 = value
        End Set
    End Property

    Private _Param34 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 34 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param34 As String
        Get
            Return _Param34
        End Get
        Set(ByVal value As String)
            Me._Param34 = value
        End Set
    End Property

    Private _Param35 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 35 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param35 As String
        Get
            Return _Param35
        End Get
        Set(ByVal value As String)
            Me._Param35 = value
        End Set
    End Property

    Private _Param36 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 36 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param36 As String
        Get
            Return _Param36
        End Get
        Set(ByVal value As String)
            Me._Param36 = value
        End Set
    End Property

    Private _Param37 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 37 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param37 As String
        Get
            Return _Param37
        End Get
        Set(ByVal value As String)
            Me._Param37 = value
        End Set
    End Property

    Private _Param38 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 38 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param38 As String
        Get
            Return _Param38
        End Get
        Set(ByVal value As String)
            Me._Param38 = value
        End Set
    End Property

    Private _Param39 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 39 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param39 As String
        Get
            Return _Param39
        End Get
        Set(ByVal value As String)
            Me._Param39 = value
        End Set
    End Property

    Private _Param40 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 40 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param40 As String
        Get
            Return _Param40
        End Get
        Set(ByVal value As String)
            Me._Param40 = value
        End Set
    End Property

#End Region

    Private Sub ActionForm_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        If Not Me.DesignMode Then
            If Me.Height > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height AndAlso Me.Header_Panel.Visible Then
                Me.Header_Panel.Visible = False
                Me.Height = Me.Height - 40
                Me.UseAero = False
                If (VelerSoftware.SZVB.Windows.Core.RunningOnWinVistaOr7Or8) Then
                    Dim af As VelerSoftware.Plugins3.Windows.DWM.Margins = New VelerSoftware.Plugins3.Windows.DWM.Margins(Me.Header_Panel.Location.X, 0, 0, 0)
                    VelerSoftware.Plugins3.Windows.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                End If
            End If
        End If
    End Sub

End Class