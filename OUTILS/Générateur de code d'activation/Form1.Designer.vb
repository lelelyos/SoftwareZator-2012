<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_Nom = New System.Windows.Forms.TextBox()
        Me.TextBox_Prenom = New System.Windows.Forms.TextBox()
        Me.TextBox_Pays = New System.Windows.Forms.TextBox()
        Me.TextBox_Code_Postal = New System.Windows.Forms.TextBox()
        Me.TextBox_Email = New System.Windows.Forms.TextBox()
        Me.NumericUpDown_No_Facture = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox_Code = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.NumericUpDown_No_Facture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Prénom :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Pays :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Code postal :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Numéro de facture :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(214, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Adresse de messagerie :"
        '
        'TextBox_Nom
        '
        Me.TextBox_Nom.Location = New System.Drawing.Point(12, 25)
        Me.TextBox_Nom.Name = "TextBox_Nom"
        Me.TextBox_Nom.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Nom.TabIndex = 1
        '
        'TextBox_Prenom
        '
        Me.TextBox_Prenom.Location = New System.Drawing.Point(12, 64)
        Me.TextBox_Prenom.Name = "TextBox_Prenom"
        Me.TextBox_Prenom.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Prenom.TabIndex = 3
        '
        'TextBox_Pays
        '
        Me.TextBox_Pays.Location = New System.Drawing.Point(12, 103)
        Me.TextBox_Pays.Name = "TextBox_Pays"
        Me.TextBox_Pays.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Pays.TabIndex = 5
        '
        'TextBox_Code_Postal
        '
        Me.TextBox_Code_Postal.Location = New System.Drawing.Point(217, 25)
        Me.TextBox_Code_Postal.Name = "TextBox_Code_Postal"
        Me.TextBox_Code_Postal.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Code_Postal.TabIndex = 7
        '
        'TextBox_Email
        '
        Me.TextBox_Email.Location = New System.Drawing.Point(217, 64)
        Me.TextBox_Email.Name = "TextBox_Email"
        Me.TextBox_Email.Size = New System.Drawing.Size(179, 20)
        Me.TextBox_Email.TabIndex = 9
        '
        'NumericUpDown_No_Facture
        '
        Me.NumericUpDown_No_Facture.Location = New System.Drawing.Point(217, 104)
        Me.NumericUpDown_No_Facture.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.NumericUpDown_No_Facture.Name = "NumericUpDown_No_Facture"
        Me.NumericUpDown_No_Facture.Size = New System.Drawing.Size(179, 20)
        Me.NumericUpDown_No_Facture.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(384, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Générer le code d'activation"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox_Code
        '
        Me.TextBox_Code.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox_Code.Location = New System.Drawing.Point(12, 198)
        Me.TextBox_Code.MaxLength = 0
        Me.TextBox_Code.Multiline = True
        Me.TextBox_Code.Name = "TextBox_Code"
        Me.TextBox_Code.ReadOnly = True
        Me.TextBox_Code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox_Code.Size = New System.Drawing.Size(384, 89)
        Me.TextBox_Code.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Edition :"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Standard", "Education", "Professionnelle"})
        Me.ComboBox1.Location = New System.Drawing.Point(12, 142)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(384, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 303)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox_Code)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDown_No_Facture)
        Me.Controls.Add(Me.TextBox_Email)
        Me.Controls.Add(Me.TextBox_Code_Postal)
        Me.Controls.Add(Me.TextBox_Pays)
        Me.Controls.Add(Me.TextBox_Prenom)
        Me.Controls.Add(Me.TextBox_Nom)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Générateur de code pour SoftwareZator 2012"
        CType(Me.NumericUpDown_No_Facture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Nom As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Prenom As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Pays As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Code_Postal As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Email As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown_No_Facture As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox_Code As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
