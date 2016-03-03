<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FonctionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FonctionForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_Fonction_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Sub_RadioButton = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RennomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.supprimer_Button2 = New System.Windows.Forms.Button()
        Me.ajouter_Button = New System.Windows.Forms.Button()
        Me.descendre_Button3 = New System.Windows.Forms.Button()
        Me.monter_Button4 = New System.Windows.Forms.Button()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.descendre_Button3)
        Me.Controls_Panel.Controls.Add(Me.monter_Button4)
        Me.Controls_Panel.Controls.Add(Me.supprimer_Button2)
        Me.Controls_Panel.Controls.Add(Me.ajouter_Button)
        Me.Controls_Panel.Controls.Add(Me.ListView1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.RadioButton1)
        Me.Controls_Panel.Controls.Add(Me.Sub_RadioButton)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Nom_Fonction_ActionTextBox)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Nom_Fonction_ActionTextBox
        '
        resources.ApplyResources(Me.Nom_Fonction_ActionTextBox, "Nom_Fonction_ActionTextBox")
        Me.Nom_Fonction_ActionTextBox.IsReadOnly = False
        Me.Nom_Fonction_ActionTextBox.Multiline = False
        Me.Nom_Fonction_ActionTextBox.Name = "Nom_Fonction_ActionTextBox"
        Me.Nom_Fonction_ActionTextBox.SpellCheck = False
        Me.Nom_Fonction_ActionTextBox.Tools = Nothing
        Me.Nom_Fonction_ActionTextBox.WordWrap = True
        '
        'Sub_RadioButton
        '
        resources.ApplyResources(Me.Sub_RadioButton, "Sub_RadioButton")
        Me.Sub_RadioButton.Name = "Sub_RadioButton"
        Me.Sub_RadioButton.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LabelEdit = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RennomerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'RennomerToolStripMenuItem
        '
        Me.RennomerToolStripMenuItem.Name = "RennomerToolStripMenuItem"
        resources.ApplyResources(Me.RennomerToolStripMenuItem, "RennomerToolStripMenuItem")
        '
        'supprimer_Button2
        '
        Me.supprimer_Button2.Image = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.delete
        resources.ApplyResources(Me.supprimer_Button2, "supprimer_Button2")
        Me.supprimer_Button2.Name = "supprimer_Button2"
        Me.ToolTip1.SetToolTip(Me.supprimer_Button2, resources.GetString("supprimer_Button2.ToolTip"))
        Me.supprimer_Button2.UseVisualStyleBackColor = True
        '
        'ajouter_Button
        '
        Me.ajouter_Button.Image = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.add_ctrl
        resources.ApplyResources(Me.ajouter_Button, "ajouter_Button")
        Me.ajouter_Button.Name = "ajouter_Button"
        Me.ToolTip1.SetToolTip(Me.ajouter_Button, resources.GetString("ajouter_Button.ToolTip"))
        Me.ajouter_Button.UseVisualStyleBackColor = True
        '
        'descendre_Button3
        '
        Me.descendre_Button3.Image = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.down_1
        resources.ApplyResources(Me.descendre_Button3, "descendre_Button3")
        Me.descendre_Button3.Name = "descendre_Button3"
        Me.ToolTip1.SetToolTip(Me.descendre_Button3, resources.GetString("descendre_Button3.ToolTip"))
        Me.descendre_Button3.UseVisualStyleBackColor = True
        '
        'monter_Button4
        '
        Me.monter_Button4.Image = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.up_1
        resources.ApplyResources(Me.monter_Button4, "monter_Button4")
        Me.monter_Button4.Name = "monter_Button4"
        Me.ToolTip1.SetToolTip(Me.monter_Button4, resources.GetString("monter_Button4.ToolTip"))
        Me.monter_Button4.UseVisualStyleBackColor = True
        '
        'FonctionForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.Fonction
        Me.Name = "FonctionForm"
        Me.Title = "Fonction"
        Me.Controls.SetChildIndex(Me.Center_Panel, 0)
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nom_Fonction_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Sub_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents descendre_Button3 As System.Windows.Forms.Button
    Friend WithEvents monter_Button4 As System.Windows.Forms.Button
    Friend WithEvents supprimer_Button2 As System.Windows.Forms.Button
    Friend WithEvents ajouter_Button As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RennomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
