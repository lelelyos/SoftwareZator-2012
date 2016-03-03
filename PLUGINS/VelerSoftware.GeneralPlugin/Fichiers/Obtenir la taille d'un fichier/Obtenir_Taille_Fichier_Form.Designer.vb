<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Obtenir_Taille_Fichier_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Obtenir_Taille_Fichier_Form))
        Me.Texte_Message_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Format_Specifié_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Automatique_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Ajouter_Unité_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Octect_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Ko_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Mo_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Go_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Go_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Mo_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Ko_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Octect_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Ajouter_Unité_CheckBox)
        Me.Controls_Panel.Controls.Add(Me.Automatique_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Format_Specifié_CheckBox)
        Me.Controls_Panel.Controls.Add(Me.ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Texte_Message_ActionTextBox)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Texte_Message_ActionTextBox
        '
        Me.Texte_Message_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Texte_Message_ActionTextBox, "Texte_Message_ActionTextBox")
        Me.Texte_Message_ActionTextBox.Multiline = False
        Me.Texte_Message_ActionTextBox.Name = "Texte_Message_ActionTextBox"
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
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Format_Specifié_CheckBox
        '
        resources.ApplyResources(Me.Format_Specifié_CheckBox, "Format_Specifié_CheckBox")
        Me.Format_Specifié_CheckBox.Name = "Format_Specifié_CheckBox"
        Me.Format_Specifié_CheckBox.UseVisualStyleBackColor = True
        '
        'Automatique_RadioButton
        '
        resources.ApplyResources(Me.Automatique_RadioButton, "Automatique_RadioButton")
        Me.Automatique_RadioButton.Name = "Automatique_RadioButton"
        Me.Automatique_RadioButton.UseVisualStyleBackColor = True
        '
        'Ajouter_Unité_CheckBox
        '
        resources.ApplyResources(Me.Ajouter_Unité_CheckBox, "Ajouter_Unité_CheckBox")
        Me.Ajouter_Unité_CheckBox.Checked = True
        Me.Ajouter_Unité_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Ajouter_Unité_CheckBox.Name = "Ajouter_Unité_CheckBox"
        Me.Ajouter_Unité_CheckBox.UseVisualStyleBackColor = True
        '
        'Octect_RadioButton
        '
        resources.ApplyResources(Me.Octect_RadioButton, "Octect_RadioButton")
        Me.Octect_RadioButton.Checked = True
        Me.Octect_RadioButton.Name = "Octect_RadioButton"
        Me.Octect_RadioButton.TabStop = True
        Me.Octect_RadioButton.UseVisualStyleBackColor = True
        '
        'Ko_RadioButton
        '
        resources.ApplyResources(Me.Ko_RadioButton, "Ko_RadioButton")
        Me.Ko_RadioButton.Name = "Ko_RadioButton"
        Me.Ko_RadioButton.UseVisualStyleBackColor = True
        '
        'Mo_RadioButton
        '
        resources.ApplyResources(Me.Mo_RadioButton, "Mo_RadioButton")
        Me.Mo_RadioButton.Name = "Mo_RadioButton"
        Me.Mo_RadioButton.UseVisualStyleBackColor = True
        '
        'Go_RadioButton
        '
        resources.ApplyResources(Me.Go_RadioButton, "Go_RadioButton")
        Me.Go_RadioButton.Name = "Go_RadioButton"
        Me.Go_RadioButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Obtenir_Taille_Fichier_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.Obtenir_Taille_Fichier
        Me.Name = "Obtenir_Taille_Fichier_Form"
        Me.Title = "Obtenir la taille d'un fichier"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Texte_Message_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Go_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Mo_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Ko_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Octect_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Ajouter_Unité_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Automatique_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Format_Specifié_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
