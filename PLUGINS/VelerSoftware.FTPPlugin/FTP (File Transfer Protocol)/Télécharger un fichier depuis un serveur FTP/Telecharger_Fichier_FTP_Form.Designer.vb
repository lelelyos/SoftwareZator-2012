﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Telecharger_Fichier_FTP_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Telecharger_Fichier_FTP_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Hote_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.ActionTextBox1)
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
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Telecharger_Fichier_FTP_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.FTPPlugin.My.Resources.Resources.download
        Me.Name = "Telecharger_Fichier_FTP_Form"
        Me.Title = "Obtenir la description du projet"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Hote_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
