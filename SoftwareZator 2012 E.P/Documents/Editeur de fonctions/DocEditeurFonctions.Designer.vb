''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocEditeurFonctions
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocEditeurFonctions))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonNavigator2 = New VelerSoftware.Design.Navigator.KryptonNavigator()
        Me.TabONE_KryptonPage = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonSpecNavigator1 = New VelerSoftware.Design.Navigator.ButtonSpecNavigator()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        DirectCast(Me.KryptonNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator2.SuspendLayout()
        DirectCast(Me.TabONE_KryptonPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.KryptonNavigator2)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonPanel.Name = "kryptonPanel"
        Me.kryptonPanel.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'KryptonNavigator2
        '
        Me.KryptonNavigator2.Bar.BarMinimumHeight = 30
        Me.KryptonNavigator2.Button.ButtonDisplayLogic = VelerSoftware.Design.Navigator.ButtonDisplayLogic.ContextNextPrevious
        Me.KryptonNavigator2.Button.ButtonSpecs.AddRange(New VelerSoftware.Design.Navigator.ButtonSpecNavigator() {Me.ButtonSpecNavigator1})
        Me.KryptonNavigator2.Button.CloseButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonNavigator2, "KryptonNavigator2")
        Me.KryptonNavigator2.Name = "KryptonNavigator2"
        Me.KryptonNavigator2.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.BarCheckButtonGroupInside
        Me.KryptonNavigator2.Pages.AddRange(New VelerSoftware.Design.Navigator.KryptonPage() {Me.TabONE_KryptonPage})
        Me.KryptonNavigator2.SelectedIndex = 0
        Me.KryptonNavigator2.StateCommon.HeaderGroup.Border.DrawBorders = VelerSoftware.Design.Toolkit.PaletteDrawBorders.None
        '
        'TabONE_KryptonPage
        '
        Me.TabONE_KryptonPage.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.TabONE_KryptonPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabONE_KryptonPage.Flags = 65534
        Me.TabONE_KryptonPage.LastVisibleSet = True
        Me.TabONE_KryptonPage.MinimumSize = New System.Drawing.Size(50, 50)
        Me.TabONE_KryptonPage.Name = "TabONE_KryptonPage"
        resources.ApplyResources(Me.TabONE_KryptonPage, "TabONE_KryptonPage")
        Me.TabONE_KryptonPage.UniqueName = "TabONE"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ButtonSpecNavigator1
        '
        resources.ApplyResources(Me.ButtonSpecNavigator1, "ButtonSpecNavigator1")
        Me.ButtonSpecNavigator1.Image = Global.SoftwareZator.My.Resources.Resources.Fonction
        Me.ButtonSpecNavigator1.ToolTipImage = Global.SoftwareZator.My.Resources.Resources.Fonction
        Me.ButtonSpecNavigator1.UniqueName = "6F22E4674037441C19BC1BBF33DC0E37"
        '
        'DocEditeurFonctions
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "DocEditeurFonctions"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        DirectCast(Me.KryptonNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator2.ResumeLayout(False)
        DirectCast(Me.TabONE_KryptonPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonNavigator2 As VelerSoftware.Design.Navigator.KryptonNavigator
    Friend WithEvents TabONE_KryptonPage As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents ButtonSpecNavigator1 As VelerSoftware.Design.Navigator.ButtonSpecNavigator

End Class
