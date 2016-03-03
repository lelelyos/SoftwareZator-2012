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
Partial Class Fermer_Document
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fermer_Document))
        Me.CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink2 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink3 = New VelerSoftware.SZVB.CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.CommandLink3)
        Me.Center_Panel.Controls.Add(Me.CommandLink2)
        Me.Center_Panel.Controls.Add(Me.CommandLink1)
        Me.Center_Panel.Controls.Add(Me.Label2)
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
        'CommandLink1
        '
        Me.CommandLink1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink1, "CommandLink1")
        Me.CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink1.Name = "CommandLink1"
        Me.ToolTip1.SetToolTip(Me.CommandLink1, resources.GetString("CommandLink1.ToolTip"))
        '
        'CommandLink2
        '
        Me.CommandLink2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink2, "CommandLink2")
        Me.CommandLink2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink2.Name = "CommandLink2"
        Me.ToolTip1.SetToolTip(Me.CommandLink2, resources.GetString("CommandLink2.ToolTip"))
        '
        'CommandLink3
        '
        Me.CommandLink3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CommandLink3, "CommandLink3")
        Me.CommandLink3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink3.Name = "CommandLink3"
        Me.CommandLink3.ShowElevationIcon = True
        Me.ToolTip1.SetToolTip(Me.CommandLink3, resources.GetString("CommandLink3.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Fermer_Document
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "Fermer_Document"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CommandLink3 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink2 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
