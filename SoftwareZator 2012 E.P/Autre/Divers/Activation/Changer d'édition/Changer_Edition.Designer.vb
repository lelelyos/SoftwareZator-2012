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
Partial Class Changer_Edition
    Inherits VelerSoftware.SZVB.AeroWindowsForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Changer_Edition))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommandLink12 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink11 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink10 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink9 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink8 = New VelerSoftware.SZVB.CommandLink()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.CommandLink12)
        Me.Center_Panel.Controls.Add(Me.CommandLink11)
        Me.Center_Panel.Controls.Add(Me.CommandLink10)
        Me.Center_Panel.Controls.Add(Me.CommandLink9)
        Me.Center_Panel.Controls.Add(Me.CommandLink8)
        Me.Center_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'CommandLink12
        '
        Me.CommandLink12.AutoEllipsis = True
        Me.CommandLink12.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink12, "CommandLink12")
        Me.CommandLink12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink12.Name = "CommandLink12"
        Me.CommandLink12.Tag = "Débutant"
        '
        'CommandLink11
        '
        Me.CommandLink11.AutoEllipsis = True
        Me.CommandLink11.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink11, "CommandLink11")
        Me.CommandLink11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink11.Name = "CommandLink11"
        Me.CommandLink11.Tag = "Professionnelle"
        Me.ToolTip1.SetToolTip(Me.CommandLink11, resources.GetString("CommandLink11.ToolTip"))
        '
        'CommandLink10
        '
        Me.CommandLink10.AutoEllipsis = True
        Me.CommandLink10.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink10, "CommandLink10")
        Me.CommandLink10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink10.Name = "CommandLink10"
        Me.CommandLink10.Tag = "Education"
        Me.ToolTip1.SetToolTip(Me.CommandLink10, resources.GetString("CommandLink10.ToolTip"))
        '
        'CommandLink9
        '
        Me.CommandLink9.AutoEllipsis = True
        Me.CommandLink9.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink9, "CommandLink9")
        Me.CommandLink9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink9.Name = "CommandLink9"
        Me.CommandLink9.Tag = "Standard"
        Me.ToolTip1.SetToolTip(Me.CommandLink9, resources.GetString("CommandLink9.ToolTip"))
        '
        'CommandLink8
        '
        Me.CommandLink8.AutoEllipsis = True
        Me.CommandLink8.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink8, "CommandLink8")
        Me.CommandLink8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink8.Name = "CommandLink8"
        Me.CommandLink8.Tag = "Gratuite"
        Me.ToolTip1.SetToolTip(Me.CommandLink8, resources.GetString("CommandLink8.ToolTip"))
        '
        'Changer_Edition
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "Changer_Edition"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CommandLink12 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink11 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink10 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink9 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink8 As VelerSoftware.SZVB.CommandLink

End Class
