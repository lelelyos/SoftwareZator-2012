<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Run_PowerShell_Command_Form
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Run_PowerShell_Command_Form))
        Me.Variable_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Fichier_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
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
        Me.Controls_Panel.Controls.Add(Me.CheckBox1)
        Me.Controls_Panel.Controls.Add(Me.Fichier_ActionTextBox)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Variable_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
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
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'Fichier_ActionTextBox
        '
        resources.ApplyResources(Me.Fichier_ActionTextBox, "Fichier_ActionTextBox")
        Me.Fichier_ActionTextBox.IsReadOnly = False
        Me.Fichier_ActionTextBox.Multiline = True
        Me.Fichier_ActionTextBox.Name = "Fichier_ActionTextBox"
        Me.Fichier_ActionTextBox.SpellCheck = False
        Me.Fichier_ActionTextBox.Tools = Nothing
        Me.ToolTip1.SetToolTip(Me.Fichier_ActionTextBox, resources.GetString("Fichier_ActionTextBox.ToolTip"))
        Me.Fichier_ActionTextBox.WordWrap = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, resources.GetString("CheckBox1.ToolTip"))
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Run_PowerShell_Command_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.Run_PowerShell_Command
        Me.Name = "Run_PowerShell_Command_Form"
        Me.Title = "Obtenir la version de Windows"
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Variable_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Fichier_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
