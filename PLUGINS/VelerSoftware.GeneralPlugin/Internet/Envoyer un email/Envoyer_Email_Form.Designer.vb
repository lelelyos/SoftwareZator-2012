<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Envoyer_Email_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Envoyer_Email_Form))
        Me.Variable_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Texte_Message_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Expéditeur_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Destinataire_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.smtp_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.sujet_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fichier_ActionTextBox4 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.utilisateur_ActionTextBox5 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mdp_ActionTextBox6 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.mdp_ActionTextBox6)
        Me.Controls_Panel.Controls.Add(Me.Label10)
        Me.Controls_Panel.Controls.Add(Me.utilisateur_ActionTextBox5)
        Me.Controls_Panel.Controls.Add(Me.Label9)
        Me.Controls_Panel.Controls.Add(Me.Label8)
        Me.Controls_Panel.Controls.Add(Me.fichier_ActionTextBox4)
        Me.Controls_Panel.Controls.Add(Me.Label7)
        Me.Controls_Panel.Controls.Add(Me.sujet_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Label6)
        Me.Controls_Panel.Controls.Add(Me.smtp_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Destinataire_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Variable_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.Texte_Message_ActionTextBox)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Expéditeur_ActionTextBox)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Variable_ComboBox
        '
        Me.Variable_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Variable_ComboBox, "Variable_ComboBox")
        Me.Variable_ComboBox.FormattingEnabled = True
        Me.Variable_ComboBox.Name = "Variable_ComboBox"
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
        'Texte_Message_ActionTextBox
        '
        Me.Texte_Message_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Texte_Message_ActionTextBox, "Texte_Message_ActionTextBox")
        Me.Texte_Message_ActionTextBox.Multiline = True
        Me.Texte_Message_ActionTextBox.Name = "Texte_Message_ActionTextBox"
        Me.Texte_Message_ActionTextBox.SpellCheck = True
        Me.Texte_Message_ActionTextBox.Tools = Nothing
        Me.Texte_Message_ActionTextBox.WordWrap = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Expéditeur_ActionTextBox
        '
        Me.Expéditeur_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Expéditeur_ActionTextBox, "Expéditeur_ActionTextBox")
        Me.Expéditeur_ActionTextBox.Multiline = False
        Me.Expéditeur_ActionTextBox.Name = "Expéditeur_ActionTextBox"
        Me.Expéditeur_ActionTextBox.SpellCheck = False
        Me.Expéditeur_ActionTextBox.Tools = Nothing
        Me.Expéditeur_ActionTextBox.WordWrap = True
        '
        'Destinataire_ActionTextBox1
        '
        Me.Destinataire_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Destinataire_ActionTextBox1, "Destinataire_ActionTextBox1")
        Me.Destinataire_ActionTextBox1.Multiline = False
        Me.Destinataire_ActionTextBox1.Name = "Destinataire_ActionTextBox1"
        Me.Destinataire_ActionTextBox1.SpellCheck = False
        Me.Destinataire_ActionTextBox1.Tools = Nothing
        Me.Destinataire_ActionTextBox1.WordWrap = True
        '
        'smtp_ActionTextBox2
        '
        Me.smtp_ActionTextBox2.IsReadOnly = False
        resources.ApplyResources(Me.smtp_ActionTextBox2, "smtp_ActionTextBox2")
        Me.smtp_ActionTextBox2.Multiline = False
        Me.smtp_ActionTextBox2.Name = "smtp_ActionTextBox2"
        Me.smtp_ActionTextBox2.SpellCheck = False
        Me.smtp_ActionTextBox2.Tools = Nothing
        Me.smtp_ActionTextBox2.WordWrap = True
        '
        'sujet_ActionTextBox3
        '
        Me.sujet_ActionTextBox3.IsReadOnly = False
        resources.ApplyResources(Me.sujet_ActionTextBox3, "sujet_ActionTextBox3")
        Me.sujet_ActionTextBox3.Multiline = False
        Me.sujet_ActionTextBox3.Name = "sujet_ActionTextBox3"
        Me.sujet_ActionTextBox3.SpellCheck = True
        Me.sujet_ActionTextBox3.Tools = Nothing
        Me.sujet_ActionTextBox3.WordWrap = True
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'fichier_ActionTextBox4
        '
        Me.fichier_ActionTextBox4.IsReadOnly = False
        resources.ApplyResources(Me.fichier_ActionTextBox4, "fichier_ActionTextBox4")
        Me.fichier_ActionTextBox4.Multiline = False
        Me.fichier_ActionTextBox4.Name = "fichier_ActionTextBox4"
        Me.fichier_ActionTextBox4.SpellCheck = True
        Me.fichier_ActionTextBox4.Tools = Nothing
        Me.fichier_ActionTextBox4.WordWrap = True
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
        'utilisateur_ActionTextBox5
        '
        Me.utilisateur_ActionTextBox5.IsReadOnly = False
        resources.ApplyResources(Me.utilisateur_ActionTextBox5, "utilisateur_ActionTextBox5")
        Me.utilisateur_ActionTextBox5.Multiline = False
        Me.utilisateur_ActionTextBox5.Name = "utilisateur_ActionTextBox5"
        Me.utilisateur_ActionTextBox5.SpellCheck = False
        Me.utilisateur_ActionTextBox5.Tools = Nothing
        Me.utilisateur_ActionTextBox5.WordWrap = True
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'mdp_ActionTextBox6
        '
        Me.mdp_ActionTextBox6.IsReadOnly = False
        resources.ApplyResources(Me.mdp_ActionTextBox6, "mdp_ActionTextBox6")
        Me.mdp_ActionTextBox6.Multiline = False
        Me.mdp_ActionTextBox6.Name = "mdp_ActionTextBox6"
        Me.mdp_ActionTextBox6.SpellCheck = False
        Me.mdp_ActionTextBox6.Tools = Nothing
        Me.mdp_ActionTextBox6.WordWrap = True
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Envoyer_Email_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.envoyer_email
        Me.Name = "Envoyer_Email_Form"
        Me.Title = "Afficher un message"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Expéditeur_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Texte_Message_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Variable_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mdp_ActionTextBox6 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents utilisateur_ActionTextBox5 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents fichier_ActionTextBox4 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sujet_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents smtp_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Destinataire_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
End Class
