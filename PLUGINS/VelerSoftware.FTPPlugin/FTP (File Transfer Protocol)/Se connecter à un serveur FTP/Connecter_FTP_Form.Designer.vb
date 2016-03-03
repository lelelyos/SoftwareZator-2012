<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Connecter_FTP_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Connecter_FTP_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Hote_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Port_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Utilisateur_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MDP_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.MDP_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Utilisateur_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.Port_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Hote_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Boutons_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Boutons_ComboBox
        '
        Me.Boutons_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Boutons_ComboBox, "Boutons_ComboBox")
        Me.Boutons_ComboBox.FormattingEnabled = True
        Me.Boutons_ComboBox.Items.AddRange(New Object() {resources.GetString("Boutons_ComboBox.Items"), resources.GetString("Boutons_ComboBox.Items1"), resources.GetString("Boutons_ComboBox.Items2"), resources.GetString("Boutons_ComboBox.Items3"), resources.GetString("Boutons_ComboBox.Items4"), resources.GetString("Boutons_ComboBox.Items5")})
        Me.Boutons_ComboBox.Name = "Boutons_ComboBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Hote_ActionTextBox1
        '
        Me.Hote_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Hote_ActionTextBox1, "Hote_ActionTextBox1")
        Me.Hote_ActionTextBox1.Multiline = False
        Me.Hote_ActionTextBox1.Name = "Hote_ActionTextBox1"
        Me.Hote_ActionTextBox1.SpellCheck = True
        Me.Hote_ActionTextBox1.Tools = Nothing
        Me.Hote_ActionTextBox1.WordWrap = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Port_ActionTextBox1
        '
        Me.Port_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Port_ActionTextBox1, "Port_ActionTextBox1")
        Me.Port_ActionTextBox1.Multiline = False
        Me.Port_ActionTextBox1.Name = "Port_ActionTextBox1"
        Me.Port_ActionTextBox1.SpellCheck = True
        Me.Port_ActionTextBox1.Tools = Nothing
        Me.Port_ActionTextBox1.WordWrap = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Utilisateur_ActionTextBox2
        '
        Me.Utilisateur_ActionTextBox2.IsReadOnly = False
        resources.ApplyResources(Me.Utilisateur_ActionTextBox2, "Utilisateur_ActionTextBox2")
        Me.Utilisateur_ActionTextBox2.Multiline = False
        Me.Utilisateur_ActionTextBox2.Name = "Utilisateur_ActionTextBox2"
        Me.Utilisateur_ActionTextBox2.SpellCheck = True
        Me.Utilisateur_ActionTextBox2.Tools = Nothing
        Me.Utilisateur_ActionTextBox2.WordWrap = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'MDP_ActionTextBox3
        '
        Me.MDP_ActionTextBox3.IsReadOnly = False
        resources.ApplyResources(Me.MDP_ActionTextBox3, "MDP_ActionTextBox3")
        Me.MDP_ActionTextBox3.Multiline = False
        Me.MDP_ActionTextBox3.Name = "MDP_ActionTextBox3"
        Me.MDP_ActionTextBox3.SpellCheck = True
        Me.MDP_ActionTextBox3.Tools = Nothing
        Me.MDP_ActionTextBox3.WordWrap = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Connecter_FTP_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.FTPPlugin.My.Resources.Resources.connect
        Me.Name = "Connecter_FTP_Form"
        Me.Title = "Obtenir la description du projet"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Hote_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MDP_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Utilisateur_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Port_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
