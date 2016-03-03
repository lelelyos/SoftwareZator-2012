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
Partial Class Wizard97Form
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Next_Button = New System.Windows.Forms.Button()
        Me.Foot_Panel = New System.Windows.Forms.Panel()
        Me.Back_Button = New System.Windows.Forms.Button()
        Me.LabelBevel = New System.Windows.Forms.Label()
        Me.WizardTabControl1 = New VelerSoftware.WizardLib.WizardTabControl()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Cancel_Button.Location = New System.Drawing.Point(495, 14)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancel_Button.Size = New System.Drawing.Size(87, 22)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel_Button"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'Next_Button
        '
        Me.Next_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Next_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Next_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Next_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Next_Button.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Next_Button.Location = New System.Drawing.Point(402, 14)
        Me.Next_Button.Name = "Next_Button"
        Me.Next_Button.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Next_Button.Size = New System.Drawing.Size(87, 22)
        Me.Next_Button.TabIndex = 2
        Me.Next_Button.Text = "Next_Button"
        Me.Next_Button.UseVisualStyleBackColor = True
        '
        'Foot_Panel
        '
        Me.Foot_Panel.BackColor = System.Drawing.SystemColors.Control
        Me.Foot_Panel.Controls.Add(Me.Back_Button)
        Me.Foot_Panel.Controls.Add(Me.LabelBevel)
        Me.Foot_Panel.Controls.Add(Me.Next_Button)
        Me.Foot_Panel.Controls.Add(Me.Cancel_Button)
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Foot_Panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Foot_Panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Foot_Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Foot_Panel.Location = New System.Drawing.Point(0, 374)
        Me.Foot_Panel.Name = "Foot_Panel"
        Me.Foot_Panel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Foot_Panel.Size = New System.Drawing.Size(594, 48)
        Me.Foot_Panel.TabIndex = 1
        '
        'Back_Button
        '
        Me.Back_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Back_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Back_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back_Button.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Back_Button.Location = New System.Drawing.Point(309, 14)
        Me.Back_Button.Name = "Back_Button"
        Me.Back_Button.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Back_Button.Size = New System.Drawing.Size(87, 22)
        Me.Back_Button.TabIndex = 3
        Me.Back_Button.Text = "Back_Button"
        Me.Back_Button.UseVisualStyleBackColor = True
        '
        'LabelBevel
        '
        Me.LabelBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelBevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelBevel.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelBevel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBevel.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.LabelBevel.Location = New System.Drawing.Point(0, 0)
        Me.LabelBevel.Name = "LabelBevel"
        Me.LabelBevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelBevel.Size = New System.Drawing.Size(594, 2)
        Me.LabelBevel.TabIndex = 0
        '
        'WizardTabControl1
        '
        Me.WizardTabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.WizardTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WizardTabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WizardTabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.WizardTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.WizardTabControl1.Multiline = True
        Me.WizardTabControl1.Name = "WizardTabControl1"
        Me.WizardTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WizardTabControl1.SelectedIndex = 0
        Me.WizardTabControl1.Size = New System.Drawing.Size(594, 374)
        Me.WizardTabControl1.TabIndex = 0
        '
        'Wizard97Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(594, 422)
        Me.Controls.Add(Me.WizardTabControl1)
        Me.Controls.Add(Me.Foot_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Wizard97Form"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Wizard97Form"
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents WizardTabControl1 As VelerSoftware.WizardLib.WizardTabControl
    Friend WithEvents LabelBevel As System.Windows.Forms.Label
    Public WithEvents Foot_Panel As System.Windows.Forms.Panel
    Public WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents Next_Button As System.Windows.Forms.Button
    Public WithEvents Back_Button As System.Windows.Forms.Button
End Class