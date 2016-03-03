<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Se_connecter_serveur_MySQL_Form
    Inherits VelerSoftware.Plugins3.ActionForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Se_connecter_serveur_MySQL_Form))
        Me.variable_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Hote_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Locale_RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Distance_RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Port_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Utilisateur_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Mot_de_passe_ActionTextBox4 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label6)
        Me.Controls_Panel.Controls.Add(Me.CheckBox1)
        Me.Controls_Panel.Controls.Add(Me.Mot_de_passe_ActionTextBox4)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Utilisateur_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.Port_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Distance_RadioButton2)
        Me.Controls_Panel.Controls.Add(Me.Locale_RadioButton1)
        Me.Controls_Panel.Controls.Add(Me.Hote_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.variable_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'variable_ComboBox
        '
        Me.variable_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.variable_ComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.variable_ComboBox, "variable_ComboBox")
        Me.variable_ComboBox.Name = "variable_ComboBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Hote_ActionTextBox1
        '
        Me.Hote_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Hote_ActionTextBox1, "Hote_ActionTextBox1")
        Me.Hote_ActionTextBox1.Multiline = False
        Me.Hote_ActionTextBox1.Name = "Hote_ActionTextBox1"
        Me.Hote_ActionTextBox1.SpellCheck = False
        Me.Hote_ActionTextBox1.Tools = Nothing
        Me.Hote_ActionTextBox1.WordWrap = True
        '
        'Locale_RadioButton1
        '
        resources.ApplyResources(Me.Locale_RadioButton1, "Locale_RadioButton1")
        Me.Locale_RadioButton1.Name = "Locale_RadioButton1"
        Me.Locale_RadioButton1.TabStop = True
        Me.Locale_RadioButton1.UseVisualStyleBackColor = True
        '
        'Distance_RadioButton2
        '
        resources.ApplyResources(Me.Distance_RadioButton2, "Distance_RadioButton2")
        Me.Distance_RadioButton2.Name = "Distance_RadioButton2"
        Me.Distance_RadioButton2.TabStop = True
        Me.Distance_RadioButton2.UseVisualStyleBackColor = True
        '
        'Port_ActionTextBox2
        '
        Me.Port_ActionTextBox2.IsReadOnly = False
        resources.ApplyResources(Me.Port_ActionTextBox2, "Port_ActionTextBox2")
        Me.Port_ActionTextBox2.Multiline = False
        Me.Port_ActionTextBox2.Name = "Port_ActionTextBox2"
        Me.Port_ActionTextBox2.SpellCheck = False
        Me.Port_ActionTextBox2.Tools = Nothing
        Me.Port_ActionTextBox2.WordWrap = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Utilisateur_ActionTextBox3
        '
        Me.Utilisateur_ActionTextBox3.IsReadOnly = False
        resources.ApplyResources(Me.Utilisateur_ActionTextBox3, "Utilisateur_ActionTextBox3")
        Me.Utilisateur_ActionTextBox3.Multiline = False
        Me.Utilisateur_ActionTextBox3.Name = "Utilisateur_ActionTextBox3"
        Me.Utilisateur_ActionTextBox3.SpellCheck = False
        Me.Utilisateur_ActionTextBox3.Tools = Nothing
        Me.Utilisateur_ActionTextBox3.WordWrap = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Mot_de_passe_ActionTextBox4
        '
        Me.Mot_de_passe_ActionTextBox4.IsReadOnly = False
        resources.ApplyResources(Me.Mot_de_passe_ActionTextBox4, "Mot_de_passe_ActionTextBox4")
        Me.Mot_de_passe_ActionTextBox4.Multiline = False
        Me.Mot_de_passe_ActionTextBox4.Name = "Mot_de_passe_ActionTextBox4"
        Me.Mot_de_passe_ActionTextBox4.SpellCheck = False
        Me.Mot_de_passe_ActionTextBox4.Tools = Nothing
        Me.Mot_de_passe_ActionTextBox4.WordWrap = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ActionTextBox1
        '
        Me.ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.ActionTextBox1, "ActionTextBox1")
        Me.ActionTextBox1.Multiline = False
        Me.ActionTextBox1.Name = "ActionTextBox1"
        Me.ActionTextBox1.SpellCheck = True
        Me.ActionTextBox1.Tools = Nothing
        Me.ActionTextBox1.WordWrap = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Se_connecter_serveur_MySQL_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.MySQLPlugin.My.Resources.Resources.connect
        Me.Name = "Se_connecter_serveur_MySQL_Form"
        Me.Title = "Démarrer un Minuteur"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents variable_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Hote_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Distance_RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Locale_RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Mot_de_passe_ActionTextBox4 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Utilisateur_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Port_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
