<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Executer_Fonction_Paramètre_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Executer_Fonction_Paramètre_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PropertyGrids1 = New VelerSoftware.SZVB.PropertyGrids.PropertyGrids()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Var1_ComboBox = New System.Windows.Forms.ComboBox()
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
        Me.Controls_Panel.Controls.Add(Me.Boutons_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Button1)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Var1_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.PropertyGrids1)
        Me.Controls_Panel.Controls.Add(Me.Label3)
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
        Me.Boutons_ComboBox.Sorted = True
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
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2"), resources.GetString("ComboBox1.Items3"), resources.GetString("ComboBox1.Items4"), resources.GetString("ComboBox1.Items5")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'PropertyGrids1
        '
        '
        '
        '
        Me.PropertyGrids1.DocCommentDescription.AutoEllipsis = True
        Me.PropertyGrids1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentDescription.ImeMode = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentDescription.Location = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentDescription.Name = ""
        Me.PropertyGrids1.DocCommentDescription.Size = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentDescription.TabIndex = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentImage = Nothing
        '
        '
        '
        Me.PropertyGrids1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentTitle.Font = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentTitle.ImeMode = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentTitle.Location = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentTitle.Name = ""
        Me.PropertyGrids1.DocCommentTitle.Size = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentTitle.TabIndex = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentTitle.UseMnemonic = False
        resources.ApplyResources(Me.PropertyGrids1, "PropertyGrids1")
        Me.PropertyGrids1.Name = "PropertyGrids1"
        Me.PropertyGrids1.ToolbarVisible = False
        '
        '
        '
        Me.PropertyGrids1.ToolStrip.AccessibleName = resources.GetString("PropertyGrids1.ToolStrip.AccessibleName")
        Me.PropertyGrids1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PropertyGrids1.ToolStrip.AllowMerge = False
        Me.PropertyGrids1.ToolStrip.AutoSize = CType(resources.GetObject("PropertyGrids1.ToolStrip.AutoSize"), Boolean)
        Me.PropertyGrids1.ToolStrip.CanOverflow = False
        Me.PropertyGrids1.ToolStrip.Dock = CType(resources.GetObject("PropertyGrids1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PropertyGrids1.ToolStrip.Location = CType(resources.GetObject("PropertyGrids1.ToolStrip.Location"), System.Drawing.Point)
        Me.PropertyGrids1.ToolStrip.Name = ""
        Me.PropertyGrids1.ToolStrip.Padding = CType(resources.GetObject("PropertyGrids1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PropertyGrids1.ToolStrip.Size = CType(resources.GetObject("PropertyGrids1.ToolStrip.Size"), System.Drawing.Size)
        Me.PropertyGrids1.ToolStrip.TabIndex = CType(resources.GetObject("PropertyGrids1.ToolStrip.TabIndex"), Integer)
        Me.PropertyGrids1.ToolStrip.TabStop = True
        Me.PropertyGrids1.ToolStrip.Text = resources.GetString("PropertyGrids1.ToolStrip.Text")
        Me.PropertyGrids1.ToolStrip.Visible = CType(resources.GetObject("PropertyGrids1.ToolStrip.Visible"), Boolean)
        Me.ToolTip1.SetToolTip(Me.PropertyGrids1, resources.GetString("PropertyGrids1.ToolTip"))
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'ActionTextBox1
        '
        Me.ActionTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.ActionTextBox1, "ActionTextBox1")
        Me.ActionTextBox1.Multiline = False
        Me.ActionTextBox1.Name = "ActionTextBox1"
        Me.ActionTextBox1.SpellCheck = False
        Me.ActionTextBox1.Tools = Nothing
        Me.ActionTextBox1.WordWrap = True
        '
        'Var1_ComboBox
        '
        Me.Var1_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Var1_ComboBox, "Var1_ComboBox")
        Me.Var1_ComboBox.FormattingEnabled = True
        Me.Var1_ComboBox.Name = "Var1_ComboBox"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Executer_Fonction_Paramètre_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.executer_fonction_variable
        Me.Name = "Executer_Fonction_Paramètre_Form"
        Me.Title = "Exécuter une fonction d'un projet"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PropertyGrids1 As VelerSoftware.SZVB.PropertyGrids.PropertyGrids
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Var1_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
