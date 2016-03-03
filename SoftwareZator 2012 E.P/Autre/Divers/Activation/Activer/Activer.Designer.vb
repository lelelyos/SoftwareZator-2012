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
Partial Class Activer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Activer))
        Me.CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_No_Facture = New System.Windows.Forms.NumericUpDown()
        Me.TextBox_Postal = New System.Windows.Forms.TextBox()
        Me.TextBox_Pays = New System.Windows.Forms.TextBox()
        Me.TextBox_Email = New System.Windows.Forms.TextBox()
        Me.TextBox_Prenom = New System.Windows.Forms.TextBox()
        Me.TextBox_Nom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_Code = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        CType(Me.NumericUpDown_No_Facture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label10)
        Me.Center_Panel.Controls.Add(Me.TextBox_Code)
        Me.Center_Panel.Controls.Add(Me.ComboBox1)
        Me.Center_Panel.Controls.Add(Me.Label9)
        Me.Center_Panel.Controls.Add(Me.NumericUpDown_No_Facture)
        Me.Center_Panel.Controls.Add(Me.TextBox_Postal)
        Me.Center_Panel.Controls.Add(Me.TextBox_Pays)
        Me.Center_Panel.Controls.Add(Me.TextBox_Email)
        Me.Center_Panel.Controls.Add(Me.TextBox_Prenom)
        Me.Center_Panel.Controls.Add(Me.TextBox_Nom)
        Me.Center_Panel.Controls.Add(Me.Label6)
        Me.Center_Panel.Controls.Add(Me.Label5)
        Me.Center_Panel.Controls.Add(Me.Label4)
        Me.Center_Panel.Controls.Add(Me.Label3)
        Me.Center_Panel.Controls.Add(Me.Label7)
        Me.Center_Panel.Controls.Add(Me.Label8)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.Label2)
        Me.Center_Panel.Controls.Add(Me.CommandLink1)
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
        'NumericUpDown_No_Facture
        '
        resources.ApplyResources(Me.NumericUpDown_No_Facture, "NumericUpDown_No_Facture")
        Me.NumericUpDown_No_Facture.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.NumericUpDown_No_Facture.Name = "NumericUpDown_No_Facture"
        Me.ToolTip1.SetToolTip(Me.NumericUpDown_No_Facture, resources.GetString("NumericUpDown_No_Facture.ToolTip"))
        '
        'TextBox_Postal
        '
        resources.ApplyResources(Me.TextBox_Postal, "TextBox_Postal")
        Me.TextBox_Postal.Name = "TextBox_Postal"
        Me.ToolTip1.SetToolTip(Me.TextBox_Postal, resources.GetString("TextBox_Postal.ToolTip"))
        '
        'TextBox_Pays
        '
        resources.ApplyResources(Me.TextBox_Pays, "TextBox_Pays")
        Me.TextBox_Pays.Name = "TextBox_Pays"
        Me.ToolTip1.SetToolTip(Me.TextBox_Pays, resources.GetString("TextBox_Pays.ToolTip"))
        '
        'TextBox_Email
        '
        resources.ApplyResources(Me.TextBox_Email, "TextBox_Email")
        Me.TextBox_Email.Name = "TextBox_Email"
        Me.ToolTip1.SetToolTip(Me.TextBox_Email, resources.GetString("TextBox_Email.ToolTip"))
        '
        'TextBox_Prenom
        '
        resources.ApplyResources(Me.TextBox_Prenom, "TextBox_Prenom")
        Me.TextBox_Prenom.Name = "TextBox_Prenom"
        Me.ToolTip1.SetToolTip(Me.TextBox_Prenom, resources.GetString("TextBox_Prenom.ToolTip"))
        '
        'TextBox_Nom
        '
        resources.ApplyResources(Me.TextBox_Nom, "TextBox_Nom")
        Me.TextBox_Nom.Name = "TextBox_Nom"
        Me.ToolTip1.SetToolTip(Me.TextBox_Nom, resources.GetString("TextBox_Nom.ToolTip"))
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2")})
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'TextBox_Code
        '
        Me.TextBox_Code.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.TextBox_Code, "TextBox_Code")
        Me.TextBox_Code.Name = "TextBox_Code"
        Me.ToolTip1.SetToolTip(Me.TextBox_Code, resources.GetString("TextBox_Code.ToolTip"))
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Activer
        '
        Me.AcceptButton = Nothing
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButton = Nothing
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.KeyPreview = True
        Me.Name = "Activer"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        CType(Me.NumericUpDown_No_Facture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown_No_Facture As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBox_Postal As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Pays As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Email As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Prenom As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Nom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Code As System.Windows.Forms.TextBox

End Class
