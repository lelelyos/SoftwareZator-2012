﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Modifier_Propriete_Donnee_Serialisable_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Modifier_Propriete_Donnee_Serialisable_Form))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.ComboBox3)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.ComboBox2)
        Me.Controls_Panel.Controls.Add(Me.Label6)
        Me.Controls_Panel.Controls.Add(Me.Button1)
        Me.Controls_Panel.Controls.Add(Me.ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'ComboBox1
        '
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2"), resources.GetString("ComboBox1.Items3"), resources.GetString("ComboBox1.Items4"), resources.GetString("ComboBox1.Items5"), resources.GetString("ComboBox1.Items6")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        resources.ApplyResources(Me.ComboBox2, "ComboBox2")
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {resources.GetString("ComboBox2.Items"), resources.GetString("ComboBox2.Items1"), resources.GetString("ComboBox2.Items2"), resources.GetString("ComboBox2.Items3"), resources.GetString("ComboBox2.Items4"), resources.GetString("ComboBox2.Items5"), resources.GetString("ComboBox2.Items6")})
        Me.ComboBox2.Name = "ComboBox2"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'ComboBox3
        '
        resources.ApplyResources(Me.ComboBox3, "ComboBox3")
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {resources.GetString("ComboBox3.Items"), resources.GetString("ComboBox3.Items1"), resources.GetString("ComboBox3.Items2"), resources.GetString("ComboBox3.Items3"), resources.GetString("ComboBox3.Items4"), resources.GetString("ComboBox3.Items5"), resources.GetString("ComboBox3.Items6")})
        Me.ComboBox3.Name = "ComboBox3"
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
        'Modifier_Propriete_Donnee_Serialisable_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.modifier_propriete_donne_serialisable
        Me.Name = "Modifier_Propriete_Donnee_Serialisable_Form"
        Me.Title = "Modifier une propriété d'une donnée sérialisable"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ValueEdit1 As VelerSoftware.Plugins3.ValueEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
