<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Supprimer_Fichier_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Supprimer_Fichier_Form))
        Me.Texte_Message_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Afficher_Boite_Dialogue_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Afficher_Erreur_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Supprimer_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Corbeille_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Panel2)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Texte_Message_ActionTextBox)
        Me.Controls_Panel.Controls.Add(Me.Panel1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Texte_Message_ActionTextBox
        '
        Me.Texte_Message_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Texte_Message_ActionTextBox, "Texte_Message_ActionTextBox")
        Me.Texte_Message_ActionTextBox.Multiline = False
        Me.Texte_Message_ActionTextBox.Name = "Texte_Message_ActionTextBox"
        Me.Texte_Message_ActionTextBox.SpellCheck = True
        Me.Texte_Message_ActionTextBox.Tools = Nothing
        Me.Texte_Message_ActionTextBox.WordWrap = True
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
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Afficher_Boite_Dialogue_RadioButton
        '
        resources.ApplyResources(Me.Afficher_Boite_Dialogue_RadioButton, "Afficher_Boite_Dialogue_RadioButton")
        Me.Afficher_Boite_Dialogue_RadioButton.AutoEllipsis = True
        Me.Afficher_Boite_Dialogue_RadioButton.Checked = True
        Me.Afficher_Boite_Dialogue_RadioButton.Name = "Afficher_Boite_Dialogue_RadioButton"
        Me.Afficher_Boite_Dialogue_RadioButton.TabStop = True
        Me.Afficher_Boite_Dialogue_RadioButton.UseVisualStyleBackColor = True
        '
        'Afficher_Erreur_RadioButton
        '
        resources.ApplyResources(Me.Afficher_Erreur_RadioButton, "Afficher_Erreur_RadioButton")
        Me.Afficher_Erreur_RadioButton.AutoEllipsis = True
        Me.Afficher_Erreur_RadioButton.Name = "Afficher_Erreur_RadioButton"
        Me.Afficher_Erreur_RadioButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Afficher_Erreur_RadioButton)
        Me.Panel1.Controls.Add(Me.Afficher_Boite_Dialogue_RadioButton)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Supprimer_RadioButton)
        Me.Panel2.Controls.Add(Me.Corbeille_RadioButton)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'Supprimer_RadioButton
        '
        resources.ApplyResources(Me.Supprimer_RadioButton, "Supprimer_RadioButton")
        Me.Supprimer_RadioButton.AutoEllipsis = True
        Me.Supprimer_RadioButton.Name = "Supprimer_RadioButton"
        Me.Supprimer_RadioButton.UseVisualStyleBackColor = True
        '
        'Corbeille_RadioButton
        '
        resources.ApplyResources(Me.Corbeille_RadioButton, "Corbeille_RadioButton")
        Me.Corbeille_RadioButton.AutoEllipsis = True
        Me.Corbeille_RadioButton.Checked = True
        Me.Corbeille_RadioButton.Name = "Corbeille_RadioButton"
        Me.Corbeille_RadioButton.TabStop = True
        Me.Corbeille_RadioButton.UseVisualStyleBackColor = True
        '
        'Supprimer_Fichier_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.Supprimer_Fichier
        Me.Name = "Supprimer_Fichier_Form"
        Me.Title = "Supprimer un fichier"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Texte_Message_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Afficher_Erreur_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Afficher_Boite_Dialogue_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Supprimer_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Corbeille_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
