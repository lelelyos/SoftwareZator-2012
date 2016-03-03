<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remplacer_Texte_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Remplacer_Texte_Form))
        Me.Variable_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Texte_Message_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Titre_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        Me.ToolTip1.SetToolTip(Me.Center_Panel, resources.GetString("Center_Panel.ToolTip"))
        '
        'Controls_Panel
        '
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        Me.Controls_Panel.Controls.Add(Me.ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Variable_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.Texte_Message_ActionTextBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Titre_ActionTextBox)
        Me.ToolTip1.SetToolTip(Me.Controls_Panel, resources.GetString("Controls_Panel.ToolTip"))
        '
        'Variable_ComboBox
        '
        resources.ApplyResources(Me.Variable_ComboBox, "Variable_ComboBox")
        Me.Variable_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Variable_ComboBox.FormattingEnabled = True
        Me.Variable_ComboBox.Name = "Variable_ComboBox"
        Me.ToolTip1.SetToolTip(Me.Variable_ComboBox, resources.GetString("Variable_ComboBox.ToolTip"))
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTip1.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.ToolTip1.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
        '
        'Texte_Message_ActionTextBox
        '
        resources.ApplyResources(Me.Texte_Message_ActionTextBox, "Texte_Message_ActionTextBox")
        Me.Texte_Message_ActionTextBox.IsReadOnly = False
        Me.Texte_Message_ActionTextBox.Multiline = True
        Me.Texte_Message_ActionTextBox.Name = "Texte_Message_ActionTextBox"
        Me.Texte_Message_ActionTextBox.Tools = Nothing
        Me.ToolTip1.SetToolTip(Me.Texte_Message_ActionTextBox, resources.GetString("Texte_Message_ActionTextBox.ToolTip"))
        Me.Texte_Message_ActionTextBox.WordWrap = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Titre_ActionTextBox
        '
        resources.ApplyResources(Me.Titre_ActionTextBox, "Titre_ActionTextBox")
        Me.Titre_ActionTextBox.IsReadOnly = False
        Me.Titre_ActionTextBox.Multiline = True
        Me.Titre_ActionTextBox.Name = "Titre_ActionTextBox"
        Me.Titre_ActionTextBox.Tools = Nothing
        Me.ToolTip1.SetToolTip(Me.Titre_ActionTextBox, resources.GetString("Titre_ActionTextBox.ToolTip"))
        Me.Titre_ActionTextBox.WordWrap = False
        '
        'ActionTextBox1
        '
        resources.ApplyResources(Me.ActionTextBox1, "ActionTextBox1")
        Me.ActionTextBox1.IsReadOnly = False
        Me.ActionTextBox1.Multiline = True
        Me.ActionTextBox1.Name = "ActionTextBox1"
        Me.ActionTextBox1.Tools = Nothing
        Me.ToolTip1.SetToolTip(Me.ActionTextBox1, resources.GetString("ActionTextBox1.ToolTip"))
        Me.ActionTextBox1.WordWrap = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'Remplacer_Texte_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.texte_replace
        Me.Name = "Remplacer_Texte_Form"
        Me.Title = "Supprimer un caractère au début d'un texte"
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Titre_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Texte_Message_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Variable_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
