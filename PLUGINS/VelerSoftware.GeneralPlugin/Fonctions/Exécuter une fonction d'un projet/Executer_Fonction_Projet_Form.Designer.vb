<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Executer_Fonction_Projet_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Executer_Fonction_Projet_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PropertyGrids1 = New VelerSoftware.SZVB.PropertyGrids.PropertyGrids()
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
        Me.Controls_Panel.Controls.Add(Me.PropertyGrids1)
        Me.Controls_Panel.Controls.Add(Me.ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Label3)
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
        Me.PropertyGrids1.DocCommentDescription.ImeMode = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentDescription.Location = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentDescription.Name = ""
        Me.PropertyGrids1.DocCommentDescription.Size = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentDescription.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentImage = Nothing
        '
        '
        '
        Me.PropertyGrids1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentTitle.Font = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentTitle.ImeMode = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentTitle.Location = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentTitle.Name = ""
        Me.PropertyGrids1.DocCommentTitle.Size = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentTitle.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.TabIndex"), Integer)
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
        Me.PropertyGrids1.ToolStrip.AutoSize = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.AutoSize"), Boolean)
        Me.PropertyGrids1.ToolStrip.CanOverflow = False
        Me.PropertyGrids1.ToolStrip.Dock = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PropertyGrids1.ToolStrip.Location = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Location"), System.Drawing.Point)
        Me.PropertyGrids1.ToolStrip.Name = ""
        Me.PropertyGrids1.ToolStrip.Padding = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PropertyGrids1.ToolStrip.Size = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Size"), System.Drawing.Size)
        Me.PropertyGrids1.ToolStrip.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.TabIndex"), Integer)
        Me.PropertyGrids1.ToolStrip.TabStop = True
        Me.PropertyGrids1.ToolStrip.Text = resources.GetString("PropertyGrids1.ToolStrip.Text")
        Me.PropertyGrids1.ToolStrip.Visible = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Visible"), Boolean)
        Me.ToolTip1.SetToolTip(Me.PropertyGrids1, resources.GetString("PropertyGrids1.ToolTip"))
        '
        'Executer_Fonction_Projet_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.execute_function
        Me.Name = "Executer_Fonction_Projet_Form"
        Me.Title = "Exécuter une fonction d'un projet"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PropertyGrids1 As VelerSoftware.SZVB.PropertyGrids.PropertyGrids
End Class
