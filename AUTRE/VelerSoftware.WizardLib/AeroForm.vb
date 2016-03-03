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
Public Class AeroForm

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
    <ComponentModel.Category("Propriétés de AeroForm"), ComponentModel.Description("Détermine si on doit utiliser le style Aero."), ComponentModel.DefaultValue(True)> _
    Public Property UseAero() As Boolean
        Get
            Return _UseAero
        End Get
        Set(ByVal value As Boolean)
            _UseAero = value
        End Set
    End Property

#End Region

#End Region







    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then
            If (VelerSoftware.WizardLib.Core.RunningOnWinVistaOr7Or8) Then
                If VelerSoftware.WizardLib.DWM.DwmIsCompositionEnabled() Then
                    If UseAero Then
                        ' Activer le style Aero Glass (RibbonProfesionalRendererColorTableBlueGlass)
                        Me.BackColor = Drawing.Color.Black
                        Me.HostPanel.BackColor = Drawing.SystemColors.Control
                        Dim af As VelerSoftware.WizardLib.DWM.Margins = New VelerSoftware.WizardLib.DWM.Margins(Me.HostPanel.Location.X, Me.Width - (Me.HostPanel.Location.X + Me.HostPanel.Width + 16), Me.HostPanel.Location.Y, Me.Height - (Me.HostPanel.Location.Y + Me.HostPanel.Height + 38))
                        VelerSoftware.WizardLib.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                        AeroEnabled = True
                    Else
                        Me.BackColor = Drawing.SystemColors.Control
                        Me.HostPanel.BackColor = Drawing.SystemColors.Control
                        AeroEnabled = False
                    End If
                Else
                    Me.BackColor = Drawing.SystemColors.Control
                    Me.HostPanel.BackColor = Drawing.SystemColors.Control
                    AeroEnabled = False
                End If
            Else
                Me.BackColor = Drawing.SystemColors.Control
                Me.HostPanel.BackColor = Drawing.SystemColors.Control
                AeroEnabled = False
            End If
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
                            Me.HostPanel.BackColor = Drawing.SystemColors.Control
                            Dim af As VelerSoftware.WizardLib.DWM.Margins = New VelerSoftware.WizardLib.DWM.Margins(Me.HostPanel.Location.X, Me.Width - (Me.HostPanel.Location.X + Me.HostPanel.Width + 16), Me.HostPanel.Location.Y, Me.Height - (Me.HostPanel.Location.Y + Me.HostPanel.Height + 38))
                            VelerSoftware.WizardLib.DWM.DwmExtendFrameIntoClientArea(Me.Handle, af)
                            AeroEnabled = True
                        End If
                    Else
                        If AeroEnabled Then
                            ' Activer le style Normal (RibbonProfesionalRendererColorTable)
                            Me.BackColor = Drawing.SystemColors.Control
                            Me.HostPanel.BackColor = Drawing.SystemColors.Control
                            AeroEnabled = False
                        End If
                    End If
                End If
            Else
                ' Activer le style Normal (RibbonProfesionalRendererColorTable)
                Me.BackColor = Drawing.SystemColors.Control
                Me.HostPanel.BackColor = Drawing.SystemColors.Control
                AeroEnabled = False
            End If
        End If
    End Sub

End Class