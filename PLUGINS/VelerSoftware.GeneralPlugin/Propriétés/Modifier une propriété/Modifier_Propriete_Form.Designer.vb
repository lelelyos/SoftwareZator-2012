﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modifier_Propriete_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modifier_Propriete_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ValueEdit1 = New VelerSoftware.Plugins3.ValueEdit()
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
        Me.Controls_Panel.Controls.Add(Me.ValueEdit1)
        Me.Controls_Panel.Controls.Add(Me.Boutons_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label2)
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
        'ValueEdit1
        '
        Me.ValueEdit1.BackColor = System.Drawing.Color.Transparent
        Me.ValueEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ValueEdit1.ColorButtonVisible = True
        Me.ValueEdit1.Editor = VelerSoftware.Plugins3.ValueEdit.ValueType.Text
        resources.ApplyResources(Me.ValueEdit1, "ValueEdit1")
        Me.ValueEdit1.Name = "ValueEdit1"
        Me.ValueEdit1.NumberButtonVisible = True
        Me.ValueEdit1.OtherButtonVisible = True
        Me.ValueEdit1.ResourcesButtonVisible = True
        Me.ValueEdit1.TextButtonVisible = True
        Me.ValueEdit1.Tools = Nothing
        Me.ValueEdit1.TrueFalseButtonVisible = True
        Me.ValueEdit1.VariablesButtonVisible = True
        Me.ValueEdit1.VBNetButtonVisible = True
        '
        'Modifier_Propriete_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.modifier_propriete
        Me.Name = "Modifier_Propriete_Form"
        Me.Title = "Modifier une variable"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ValueEdit1 As VelerSoftware.Plugins3.ValueEdit
End Class
