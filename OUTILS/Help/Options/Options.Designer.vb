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
Partial Class Options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Langue_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.ComboBox1)
        Me.Center_Panel.Controls.Add(Me.Label7)
        Me.Center_Panel.Controls.Add(Me.Langue_ComboBox)
        Me.Center_Panel.Controls.Add(Me.Label2)
        Me.Center_Panel.Controls.Add(Me.Label1)
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
        'Langue_ComboBox
        '
        Me.Langue_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Langue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Langue_ComboBox, "Langue_ComboBox")
        Me.Langue_ComboBox.FormattingEnabled = True
        Me.Langue_ComboBox.Items.AddRange(New Object() {resources.GetString("Langue_ComboBox.Items"), resources.GetString("Langue_ComboBox.Items1")})
        Me.Langue_ComboBox.Name = "Langue_ComboBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'ComboBox1
        '
        Me.ComboBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Name = "Label7"
        '
        'Options
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "Options"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Langue_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
