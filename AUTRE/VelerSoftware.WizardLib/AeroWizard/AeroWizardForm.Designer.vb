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
Partial Class AeroWizardForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Header_Panel = New System.Windows.Forms.Panel()
        Me.Title_Label = New System.Windows.Forms.Label()
        Me.Icon_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Back_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Next_Button = New System.Windows.Forms.Button()
        Me.Foot_Panel = New System.Windows.Forms.Panel()
        Me.LabelBevel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WizardTabControl1 = New VelerSoftware.WizardLib.WizardTabControl()
        Me.Header_Panel.SuspendLayout()
        CType(Me.Icon_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Back_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Header_Panel
        '
        Me.Header_Panel.BackColor = System.Drawing.Color.Transparent
        Me.Header_Panel.Controls.Add(Me.Title_Label)
        Me.Header_Panel.Controls.Add(Me.Icon_PictureBox)
        Me.Header_Panel.Controls.Add(Me.Back_PictureBox)
        Me.Header_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header_Panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header_Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Header_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Header_Panel.Margin = New System.Windows.Forms.Padding(0)
        Me.Header_Panel.Name = "Header_Panel"
        Me.Header_Panel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header_Panel.Size = New System.Drawing.Size(537, 40)
        Me.Header_Panel.TabIndex = 2
        '
        'Title_Label
        '
        Me.Title_Label.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Title_Label.AutoEllipsis = True
        Me.Title_Label.AutoSize = True
        Me.Title_Label.BackColor = System.Drawing.Color.Transparent
        Me.Title_Label.Cursor = System.Windows.Forms.Cursors.Default
        Me.Title_Label.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title_Label.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Title_Label.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Title_Label.Location = New System.Drawing.Point(55, 11)
        Me.Title_Label.Name = "Title_Label"
        Me.Title_Label.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Title_Label.Size = New System.Drawing.Size(113, 16)
        Me.Title_Label.TabIndex = 0
        Me.Title_Label.Text = "Titre de l'assistant"
        Me.Title_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Icon_PictureBox
        '
        Me.Icon_PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Icon_PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.Icon_PictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon_PictureBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon_PictureBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Icon_PictureBox.Location = New System.Drawing.Point(33, 11)
        Me.Icon_PictureBox.Name = "Icon_PictureBox"
        Me.Icon_PictureBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Icon_PictureBox.Size = New System.Drawing.Size(16, 16)
        Me.Icon_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon_PictureBox.TabIndex = 9
        Me.Icon_PictureBox.TabStop = False
        '
        'Back_PictureBox
        '
        Me.Back_PictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Back_PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.Back_PictureBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Back_PictureBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Back_PictureBox.Image = Global.VelerSoftware.WizardLib.My.Resources.Resources.WizardButton_disabled
        Me.Back_PictureBox.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Back_PictureBox.Location = New System.Drawing.Point(2, 7)
        Me.Back_PictureBox.Name = "Back_PictureBox"
        Me.Back_PictureBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Back_PictureBox.Size = New System.Drawing.Size(25, 25)
        Me.Back_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Back_PictureBox.TabIndex = 8
        Me.Back_PictureBox.TabStop = False
        Me.Back_PictureBox.Tag = "disabled"
        Me.ToolTip1.SetToolTip(Me.Back_PictureBox, "etape")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Cancel_Button.Location = New System.Drawing.Point(438, 14)
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
        Me.Next_Button.Location = New System.Drawing.Point(345, 14)
        Me.Next_Button.Name = "Next_Button"
        Me.Next_Button.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Next_Button.Size = New System.Drawing.Size(87, 22)
        Me.Next_Button.TabIndex = 0
        Me.Next_Button.Text = "Next_Button"
        Me.Next_Button.UseVisualStyleBackColor = True
        '
        'Foot_Panel
        '
        Me.Foot_Panel.BackColor = System.Drawing.SystemColors.Control
        Me.Foot_Panel.Controls.Add(Me.LabelBevel)
        Me.Foot_Panel.Controls.Add(Me.Next_Button)
        Me.Foot_Panel.Controls.Add(Me.Cancel_Button)
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Foot_Panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Foot_Panel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Foot_Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Foot_Panel.Location = New System.Drawing.Point(0, 309)
        Me.Foot_Panel.Name = "Foot_Panel"
        Me.Foot_Panel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Foot_Panel.Size = New System.Drawing.Size(537, 48)
        Me.Foot_Panel.TabIndex = 0
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
        Me.LabelBevel.Size = New System.Drawing.Size(537, 2)
        Me.LabelBevel.TabIndex = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'WizardTabControl1
        '
        Me.WizardTabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.WizardTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WizardTabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WizardTabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.WizardTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.WizardTabControl1.Multiline = True
        Me.WizardTabControl1.Name = "WizardTabControl1"
        Me.WizardTabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.WizardTabControl1.SelectedIndex = 0
        Me.WizardTabControl1.Size = New System.Drawing.Size(537, 269)
        Me.WizardTabControl1.TabIndex = 1
        '
        'AeroWizardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(537, 357)
        Me.Controls.Add(Me.WizardTabControl1)
        Me.Controls.Add(Me.Foot_Panel)
        Me.Controls.Add(Me.Header_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AeroWizardForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Header_Panel.ResumeLayout(False)
        Me.Header_Panel.PerformLayout()
        CType(Me.Icon_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Back_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LabelBevel As System.Windows.Forms.Label
    Public WithEvents WizardTabControl1 As VelerSoftware.WizardLib.WizardTabControl
    Public WithEvents Header_Panel As System.Windows.Forms.Panel
    Public WithEvents Foot_Panel As System.Windows.Forms.Panel
    Public WithEvents Icon_PictureBox As System.Windows.Forms.PictureBox
    Public WithEvents Back_PictureBox As System.Windows.Forms.PictureBox
    Public WithEvents Cancel_Button As System.Windows.Forms.Button
    Public WithEvents Next_Button As System.Windows.Forms.Button
    Public WithEvents Title_Label As System.Windows.Forms.Label
End Class