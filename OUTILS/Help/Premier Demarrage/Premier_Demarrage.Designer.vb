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
Partial Class PremierDemarrage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremierDemarrage))
        Me.CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink2 = New VelerSoftware.SZVB.CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.CommandLink2)
        Me.Center_Panel.Controls.Add(Me.CommandLink1)
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'CommandLink1
        '
        Me.CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        resources.ApplyResources(Me.CommandLink1, "CommandLink1")
        Me.CommandLink1.Name = "CommandLink1"
        Me.CommandLink1.Tag = "Français"
        Me.ToolTip1.SetToolTip(Me.CommandLink1, resources.GetString("CommandLink1.ToolTip"))
        '
        'CommandLink2
        '
        Me.CommandLink2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        resources.ApplyResources(Me.CommandLink2, "CommandLink2")
        Me.CommandLink2.Name = "CommandLink2"
        Me.CommandLink2.Tag = "English"
        Me.ToolTip1.SetToolTip(Me.CommandLink2, resources.GetString("CommandLink2.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'PremierDemarrage
        '
        resources.ApplyResources(Me, "$this")
        Me.CancelButtonText = "Annuler"
        Me.ControlBox = False
        Me.Name = "PremierDemarrage"
        Me.OKButtonText = "OK"
        Me.ShowInTaskbar = True
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CommandLink2 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
