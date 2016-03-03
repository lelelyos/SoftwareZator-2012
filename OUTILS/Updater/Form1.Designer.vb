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
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lbSummary = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.Windows7ProgressBar1 = New VelerSoftware.SZC.ProgressBar.Windows7ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CommandLink2 = New VelerSoftware.SZVB.CommandLink()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        Me.Center_Panel.Controls.Add(Me.Panel5)
        Me.Center_Panel.Controls.Add(Me.Panel4)
        Me.Center_Panel.Controls.Add(Me.Panel3)
        Me.Center_Panel.Controls.Add(Me.Panel2)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.Panel1)
        Me.Center_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToolTip1.SetToolTip(Me.Center_Panel, resources.GetString("Center_Panel.ToolTip"))
        '
        'Foot_Panel
        '
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        Me.Foot_Panel.Controls.Add(Me.CheckBox1)
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToolTip1.SetToolTip(Me.Foot_Panel, resources.GetString("Foot_Panel.ToolTip"))
        Me.Foot_Panel.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Foot_Panel.Controls.SetChildIndex(Me.Cancel_Button, 0)
        Me.Foot_Panel.Controls.SetChildIndex(Me.OK_Button, 0)
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, resources.GetString("Cancel_Button.ToolTip"))
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.ToolTip1.SetToolTip(Me.OK_Button, resources.GetString("OK_Button.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Name = "Panel1"
        Me.ToolTip1.SetToolTip(Me.Panel1, resources.GetString("Panel1.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Name = "Panel2"
        Me.ToolTip1.SetToolTip(Me.Panel2, resources.GetString("Panel2.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'Panel3
        '
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Controls.Add(Me.CommandLink1)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.TextBox1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Name = "Panel3"
        Me.ToolTip1.SetToolTip(Me.Panel3, resources.GetString("Panel3.ToolTip"))
        '
        'CommandLink1
        '
        resources.ApplyResources(Me.CommandLink1, "CommandLink1")
        Me.CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink1.Name = "CommandLink1"
        Me.ToolTip1.SetToolTip(Me.CommandLink1, resources.GetString("CommandLink1.ToolTip"))
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.DetectUrls = False
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.ToolTip1.SetToolTip(Me.TextBox1, resources.GetString("TextBox1.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.ToolTip1.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
        '
        'Panel4
        '
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Controls.Add(Me.lbSummary)
        Me.Panel4.Controls.Add(Me.lbStatus)
        Me.Panel4.Controls.Add(Me.Windows7ProgressBar1)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Name = "Panel4"
        Me.ToolTip1.SetToolTip(Me.Panel4, resources.GetString("Panel4.ToolTip"))
        '
        'lbSummary
        '
        resources.ApplyResources(Me.lbSummary, "lbSummary")
        Me.lbSummary.AutoEllipsis = True
        Me.lbSummary.Name = "lbSummary"
        Me.ToolTip1.SetToolTip(Me.lbSummary, resources.GetString("lbSummary.ToolTip"))
        '
        'lbStatus
        '
        resources.ApplyResources(Me.lbStatus, "lbStatus")
        Me.lbStatus.Name = "lbStatus"
        Me.ToolTip1.SetToolTip(Me.lbStatus, resources.GetString("lbStatus.ToolTip"))
        '
        'Windows7ProgressBar1
        '
        resources.ApplyResources(Me.Windows7ProgressBar1, "Windows7ProgressBar1")
        Me.Windows7ProgressBar1.ContainerControl = Me
        Me.Windows7ProgressBar1.Name = "Windows7ProgressBar1"
        Me.Windows7ProgressBar1.ShowInTaskbar = True
        Me.ToolTip1.SetToolTip(Me.Windows7ProgressBar1, resources.GetString("Windows7ProgressBar1.ToolTip"))
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.ToolTip1.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
        '
        'Panel5
        '
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.Controls.Add(Me.CommandLink2)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Name = "Panel5"
        Me.ToolTip1.SetToolTip(Me.Panel5, resources.GetString("Panel5.ToolTip"))
        '
        'CommandLink2
        '
        resources.ApplyResources(Me.CommandLink2, "CommandLink2")
        Me.CommandLink2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink2.Name = "CommandLink2"
        Me.ToolTip1.SetToolTip(Me.CommandLink2, resources.GetString("CommandLink2.ToolTip"))
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        Me.ToolTip1.SetToolTip(Me.Label9, resources.GetString("Label9.ToolTip"))
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, resources.GetString("CheckBox1.ToolTip"))
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Cancel"
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.MinimizeBox = True
        Me.Name = "Form1"
        Me.OKButtonText = "OK"
        Me.ShowInTaskbar = True
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents lbSummary As System.Windows.Forms.Label
    Private WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents Windows7ProgressBar1 As VelerSoftware.SZC.ProgressBar.Windows7ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CommandLink2 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
