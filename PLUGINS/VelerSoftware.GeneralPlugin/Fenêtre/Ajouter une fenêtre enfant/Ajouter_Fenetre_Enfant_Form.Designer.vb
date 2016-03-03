<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ajouter_Fenetre_Enfant_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ajouter_Fenetre_Enfant_Form))
        Me.Parent_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Enfant_ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
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
        Me.Controls_Panel.Controls.Add(Me.ComboBox2)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Enfant_ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Parent_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Parent_ComboBox
        '
        Me.Parent_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Parent_ComboBox, "Parent_ComboBox")
        Me.Parent_ComboBox.FormattingEnabled = True
        Me.Parent_ComboBox.Items.AddRange(New Object() {resources.GetString("Parent_ComboBox.Items"), resources.GetString("Parent_ComboBox.Items1"), resources.GetString("Parent_ComboBox.Items2"), resources.GetString("Parent_ComboBox.Items3"), resources.GetString("Parent_ComboBox.Items4"), resources.GetString("Parent_ComboBox.Items5")})
        Me.Parent_ComboBox.Name = "Parent_ComboBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Enfant_ComboBox1
        '
        Me.Enfant_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Enfant_ComboBox1, "Enfant_ComboBox1")
        Me.Enfant_ComboBox1.FormattingEnabled = True
        Me.Enfant_ComboBox1.Name = "Enfant_ComboBox1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ActionTextBox1
        '
        Me.ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.ActionTextBox1, "ActionTextBox1")
        Me.ActionTextBox1.Multiline = False
        Me.ActionTextBox1.Name = "ActionTextBox1"
        Me.ActionTextBox1.Tools = Nothing
        Me.ActionTextBox1.WordWrap = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox2, "ComboBox2")
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Name = "ComboBox2"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Ajouter_Fenetre_Enfant_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.ajouter_fenetre_enfant
        Me.Name = "Ajouter_Fenetre_Enfant_Form"
        Me.Title = "Ajouter une fenêtre enfant"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Parent_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Enfant_ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
