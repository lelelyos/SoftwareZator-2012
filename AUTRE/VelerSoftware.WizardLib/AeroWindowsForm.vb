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
Public Class AeroWindowsForm

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
    <ComponentModel.Category("Propriétés de AeroWindowsForm"), ComponentModel.Description("Détermine si on doit utiliser le style Aero."), ComponentModel.DefaultValue(True)> _
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
    <ComponentModel.Category("Propriétés de AeroWindowsForm"), ComponentModel.Description("Texte du bouton 'OK'"), ComponentModel.DefaultValue("")> _
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
    <ComponentModel.Category("Propriétés de AeroWindowsForm"), ComponentModel.Description("Texte du bouton 'Annuler'"), ComponentModel.DefaultValue("")> _
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
    <ComponentModel.Category("Evènement de AeroWindowsForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'OKButtonText' change.")> _
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
    <ComponentModel.Category("Evènement de AeroWindowsForm"), ComponentModel.Description("Se déclenche lorsque la propriété 'CancelButtonText' change.")> _
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
    <ComponentModel.Category("Evènement de AeroWindowsForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Suivant'.")> _
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
    <ComponentModel.Category("Evènement de AeroWindowsForm"), ComponentModel.Description("Se déclenche après un clique sur le bouton 'Annuler'.")> _
    Public Event OnCancelButtonClicked As OnCancelButtonClickedEventHandler

#End Region

#End Region

#Region "Method Events"

    Private Sub CancelButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnCancelButtonTextChanged
        Me.Cancel_Button.Text = CancelButtonText
    End Sub

    Private Sub okButtonText_Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.OnOKButtonTextChanged
        Me.OK_Button.Text = OKButtonText
    End Sub

#End Region







    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        RaiseEvent OnCancelButtonClicked(Me.Cancel_Button, New System.EventArgs)
    End Sub

    Private Sub Next_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        RaiseEvent OnOKButtonClicked(Me.OK_Button, New System.EventArgs)
    End Sub

    Declare Function GetActiveWindow Lib "user32" () As System.IntPtr

    Private Sub Header_Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Header_Panel.Paint, Me.Paint
        If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
            If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() = False OrElse Me.AeroEnabled = False Then
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

    Private Sub ActionForm_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        If Me.Height > System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height AndAlso Me.Header_Panel.Visible Then
            Me.Header_Panel.Visible = False
            Me.Height = Me.Height - 40
            Me.UseAero = False
            If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
                Dim af As VelerSoftware.WizardLib.DWM.Margins = New VelerSoftware.WizardLib.DWM.Margins(Me.Header_Panel.Location.X, 0, 0, 0)
                VelerSoftware.WizardLib.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
            End If
        End If
    End Sub

End Class