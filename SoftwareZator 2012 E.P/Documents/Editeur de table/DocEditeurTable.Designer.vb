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
Partial Class DocEditeurTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocEditeurTable))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonDataGridView1 = New VelerSoftware.Design.Toolkit.KryptonDataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        DirectCast(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.KryptonDataGridView1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonPanel.Name = "kryptonPanel"
        Me.kryptonPanel.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'KryptonDataGridView1
        '
        Me.KryptonDataGridView1.AllowUserToOrderColumns = True
        Me.KryptonDataGridView1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonDataGridView1, "KryptonDataGridView1")
        Me.KryptonDataGridView1.Name = "KryptonDataGridView1"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'DocEditeurTable
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "DocEditeurTable"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        DirectCast(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonDataGridView1 As VelerSoftware.Design.Toolkit.KryptonDataGridView

End Class
