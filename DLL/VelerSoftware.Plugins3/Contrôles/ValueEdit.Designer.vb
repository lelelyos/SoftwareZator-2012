''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValueEdit
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValueEdit))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Resources_Panel = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Resources_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Variables_Panel = New System.Windows.Forms.Panel()
        Me.Variables_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Variables_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Text_Panel = New System.Windows.Forms.Panel()
        Me.Text_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Other_Panel = New System.Windows.Forms.Panel()
        Me.PropertyGrids1 = New VelerSoftware.SZVB.PropertyGrids.PropertyGrids()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Constructor_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Type_TextBox = New System.Windows.Forms.TextBox()
        Me.Type_Button = New System.Windows.Forms.Button()
        Me.Color_Panel = New System.Windows.Forms.Panel()
        Me.TrueFalse_Panel = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Vrai_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Faux_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Num_Panel = New System.Windows.Forms.Panel()
        Me.Number_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.VB_Panel = New System.Windows.Forms.Panel()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CouperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SélectionnerToutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AnnulerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RétablirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.VB_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Text_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Number_CheckBox = New System.Windows.Forms.CheckBox()
        Me.TrueFalse_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Color_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Other_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Variable_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Ressource_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Resources_Panel.SuspendLayout()
        Me.Variables_Panel.SuspendLayout()
        Me.Text_Panel.SuspendLayout()
        Me.Other_Panel.SuspendLayout()
        Me.TrueFalse_Panel.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Num_Panel.SuspendLayout()
        Me.VB_Panel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.SplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Resources_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Variables_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Text_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Other_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Color_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TrueFalse_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Num_Panel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.VB_Panel)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel1, "SplitContainer1.Panel1")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel2, "SplitContainer1.Panel2")
        '
        'Resources_Panel
        '
        resources.ApplyResources(Me.Resources_Panel, "Resources_Panel")
        Me.Resources_Panel.Controls.Add(Me.Label5)
        Me.Resources_Panel.Controls.Add(Me.Resources_ComboBox)
        Me.Resources_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Resources_Panel.Name = "Resources_Panel"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.AutoEllipsis = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Name = "Label5"
        '
        'Resources_ComboBox
        '
        resources.ApplyResources(Me.Resources_ComboBox, "Resources_ComboBox")
        Me.Resources_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Resources_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Resources_ComboBox.FormattingEnabled = True
        Me.Resources_ComboBox.Name = "Resources_ComboBox"
        '
        'Variables_Panel
        '
        resources.ApplyResources(Me.Variables_Panel, "Variables_Panel")
        Me.Variables_Panel.Controls.Add(Me.Variables_ActionTextBox)
        Me.Variables_Panel.Controls.Add(Me.Label4)
        Me.Variables_Panel.Controls.Add(Me.Variables_ComboBox)
        Me.Variables_Panel.Controls.Add(Me.Label6)
        Me.Variables_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Variables_Panel.Name = "Variables_Panel"
        '
        'Variables_ActionTextBox
        '
        Me.Variables_ActionTextBox.AllowDrop = True
        resources.ApplyResources(Me.Variables_ActionTextBox, "Variables_ActionTextBox")
        Me.Variables_ActionTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Variables_ActionTextBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Variables_ActionTextBox.IsReadOnly = False
        Me.Variables_ActionTextBox.Multiline = False
        Me.Variables_ActionTextBox.Name = "Variables_ActionTextBox"
        Me.Variables_ActionTextBox.Tools = Nothing
        Me.Variables_ActionTextBox.WordWrap = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.AutoEllipsis = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Name = "Label4"
        '
        'Variables_ComboBox
        '
        resources.ApplyResources(Me.Variables_ComboBox, "Variables_ComboBox")
        Me.Variables_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Variables_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Variables_ComboBox.FormattingEnabled = True
        Me.Variables_ComboBox.Name = "Variables_ComboBox"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.AutoEllipsis = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Name = "Label6"
        '
        'Text_Panel
        '
        Me.Text_Panel.Controls.Add(Me.Text_ActionTextBox)
        Me.Text_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Text_Panel, "Text_Panel")
        Me.Text_Panel.Name = "Text_Panel"
        '
        'Text_ActionTextBox
        '
        Me.Text_ActionTextBox.AllowDrop = True
        Me.Text_ActionTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Text_ActionTextBox.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Text_ActionTextBox, "Text_ActionTextBox")
        Me.Text_ActionTextBox.IsReadOnly = False
        Me.Text_ActionTextBox.Multiline = True
        Me.Text_ActionTextBox.Name = "Text_ActionTextBox"
        Me.Text_ActionTextBox.Tools = Nothing
        Me.Text_ActionTextBox.WordWrap = False
        '
        'Other_Panel
        '
        resources.ApplyResources(Me.Other_Panel, "Other_Panel")
        Me.Other_Panel.Controls.Add(Me.PropertyGrids1)
        Me.Other_Panel.Controls.Add(Me.Panel1)
        Me.Other_Panel.Controls.Add(Me.Label1)
        Me.Other_Panel.Controls.Add(Me.Label3)
        Me.Other_Panel.Controls.Add(Me.Constructor_ComboBox)
        Me.Other_Panel.Controls.Add(Me.Label2)
        Me.Other_Panel.Controls.Add(Me.Type_TextBox)
        Me.Other_Panel.Controls.Add(Me.Type_Button)
        Me.Other_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Other_Panel.Name = "Other_Panel"
        '
        'PropertyGrids1
        '
        resources.ApplyResources(Me.PropertyGrids1, "PropertyGrids1")
        Me.PropertyGrids1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.PropertyGrids1.Cursor = System.Windows.Forms.Cursors.Default
        '
        '
        '
        Me.PropertyGrids1.DocCommentDescription.AutoEllipsis = True
        Me.PropertyGrids1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentDescription.Font = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentDescription.ImeMode = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentDescription.Location = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentDescription.Name = ""
        Me.PropertyGrids1.DocCommentDescription.RightToLeft = CType(resources.GetObject("PropertyGrids1.DocCommentDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
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
        Me.PropertyGrids1.DocCommentTitle.RightToLeft = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.DocCommentTitle.Size = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentTitle.TabIndex = CType(resources.GetObject("PropertyGrids1.DocCommentTitle.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentTitle.UseMnemonic = False
        Me.PropertyGrids1.Name = "PropertyGrids1"
        Me.PropertyGrids1.PropertySort = System.Windows.Forms.PropertySort.NoSort
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
        Me.PropertyGrids1.ToolStrip.Font = CType(resources.GetObject("PropertyGrids1.ToolStrip.Font"), System.Drawing.Font)
        Me.PropertyGrids1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PropertyGrids1.ToolStrip.ImeMode = CType(resources.GetObject("PropertyGrids1.ToolStrip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.PropertyGrids1.ToolStrip.Location = CType(resources.GetObject("PropertyGrids1.ToolStrip.Location"), System.Drawing.Point)
        Me.PropertyGrids1.ToolStrip.Name = ""
        Me.PropertyGrids1.ToolStrip.Padding = CType(resources.GetObject("PropertyGrids1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PropertyGrids1.ToolStrip.RightToLeft = CType(resources.GetObject("PropertyGrids1.ToolStrip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.ToolStrip.Size = CType(resources.GetObject("PropertyGrids1.ToolStrip.Size"), System.Drawing.Size)
        Me.PropertyGrids1.ToolStrip.TabIndex = CType(resources.GetObject("PropertyGrids1.ToolStrip.TabIndex"), Integer)
        Me.PropertyGrids1.ToolStrip.TabStop = True
        Me.PropertyGrids1.ToolStrip.Text = resources.GetString("PropertyGrids1.ToolStrip.Text")
        Me.PropertyGrids1.ToolStrip.Visible = CType(resources.GetObject("PropertyGrids1.ToolStrip.Visible"), Boolean)
        '
        'Panel1
        '
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.AutoEllipsis = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Name = "Label1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.AutoEllipsis = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'Constructor_ComboBox
        '
        resources.ApplyResources(Me.Constructor_ComboBox, "Constructor_ComboBox")
        Me.Constructor_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Constructor_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Constructor_ComboBox.FormattingEnabled = True
        Me.Constructor_ComboBox.Name = "Constructor_ComboBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.AutoEllipsis = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Type_TextBox
        '
        resources.ApplyResources(Me.Type_TextBox, "Type_TextBox")
        Me.Type_TextBox.BackColor = System.Drawing.SystemColors.Window
        Me.Type_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Type_TextBox.Name = "Type_TextBox"
        Me.Type_TextBox.ReadOnly = True
        '
        'Type_Button
        '
        resources.ApplyResources(Me.Type_Button, "Type_Button")
        Me.Type_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Type_Button.Name = "Type_Button"
        Me.Type_Button.UseVisualStyleBackColor = True
        '
        'Color_Panel
        '
        Me.Color_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Color_Panel, "Color_Panel")
        Me.Color_Panel.Name = "Color_Panel"
        '
        'TrueFalse_Panel
        '
        Me.TrueFalse_Panel.Controls.Add(Me.FlowLayoutPanel2)
        Me.TrueFalse_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TrueFalse_Panel, "TrueFalse_Panel")
        Me.TrueFalse_Panel.Name = "TrueFalse_Panel"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Vrai_RadioButton)
        Me.FlowLayoutPanel2.Controls.Add(Me.Faux_RadioButton)
        Me.FlowLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.FlowLayoutPanel2, "FlowLayoutPanel2")
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        '
        'Vrai_RadioButton
        '
        resources.ApplyResources(Me.Vrai_RadioButton, "Vrai_RadioButton")
        Me.Vrai_RadioButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.Vrai_RadioButton.Name = "Vrai_RadioButton"
        Me.Vrai_RadioButton.TabStop = True
        Me.Vrai_RadioButton.UseVisualStyleBackColor = True
        '
        'Faux_RadioButton
        '
        resources.ApplyResources(Me.Faux_RadioButton, "Faux_RadioButton")
        Me.Faux_RadioButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.Faux_RadioButton.Name = "Faux_RadioButton"
        Me.Faux_RadioButton.TabStop = True
        Me.Faux_RadioButton.UseVisualStyleBackColor = True
        '
        'Num_Panel
        '
        Me.Num_Panel.Controls.Add(Me.Number_ActionTextBox)
        Me.Num_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Num_Panel, "Num_Panel")
        Me.Num_Panel.Name = "Num_Panel"
        '
        'Number_ActionTextBox
        '
        Me.Number_ActionTextBox.AllowDrop = True
        Me.Number_ActionTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Number_ActionTextBox.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Number_ActionTextBox, "Number_ActionTextBox")
        Me.Number_ActionTextBox.IsReadOnly = False
        Me.Number_ActionTextBox.Multiline = True
        Me.Number_ActionTextBox.Name = "Number_ActionTextBox"
        Me.Number_ActionTextBox.Tools = Nothing
        Me.Number_ActionTextBox.WordWrap = False
        '
        'VB_Panel
        '
        Me.VB_Panel.Controls.Add(Me.ElementHost1)
        Me.VB_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.VB_Panel, "VB_Panel")
        Me.VB_Panel.Name = "VB_Panel"
        '
        'ElementHost1
        '
        Me.ElementHost1.BackColorTransparent = True
        Me.ElementHost1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ElementHost1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ElementHost1, "ElementHost1")
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopierToolStripMenuItem, Me.CouperToolStripMenuItem, Me.CollerToolStripMenuItem, Me.ToolStripSeparator1, Me.SélectionnerToutToolStripMenuItem, Me.ToolStripSeparator2, Me.AnnulerToolStripMenuItem, Me.RétablirToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'CopierToolStripMenuItem
        '
        Me.CopierToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.copy_small
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        '
        'CouperToolStripMenuItem
        '
        Me.CouperToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.cut
        Me.CouperToolStripMenuItem.Name = "CouperToolStripMenuItem"
        resources.ApplyResources(Me.CouperToolStripMenuItem, "CouperToolStripMenuItem")
        '
        'CollerToolStripMenuItem
        '
        Me.CollerToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.paste_sma
        Me.CollerToolStripMenuItem.Name = "CollerToolStripMenuItem"
        resources.ApplyResources(Me.CollerToolStripMenuItem, "CollerToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'SélectionnerToutToolStripMenuItem
        '
        Me.SélectionnerToutToolStripMenuItem.Name = "SélectionnerToutToolStripMenuItem"
        resources.ApplyResources(Me.SélectionnerToutToolStripMenuItem, "SélectionnerToutToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'AnnulerToolStripMenuItem
        '
        Me.AnnulerToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.undo
        Me.AnnulerToolStripMenuItem.Name = "AnnulerToolStripMenuItem"
        resources.ApplyResources(Me.AnnulerToolStripMenuItem, "AnnulerToolStripMenuItem")
        '
        'RétablirToolStripMenuItem
        '
        Me.RétablirToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.redo
        Me.RétablirToolStripMenuItem.Name = "RétablirToolStripMenuItem"
        resources.ApplyResources(Me.RétablirToolStripMenuItem, "RétablirToolStripMenuItem")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.VB_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Text_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Number_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.TrueFalse_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Color_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Other_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Variable_CheckBox)
        Me.FlowLayoutPanel1.Controls.Add(Me.Ressource_CheckBox)
        Me.FlowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'VB_CheckBox
        '
        resources.ApplyResources(Me.VB_CheckBox, "VB_CheckBox")
        Me.VB_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.VB_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.code
        Me.VB_CheckBox.Name = "VB_CheckBox"
        Me.ToolTip1.SetToolTip(Me.VB_CheckBox, resources.GetString("VB_CheckBox.ToolTip"))
        Me.VB_CheckBox.UseVisualStyleBackColor = True
        '
        'Text_CheckBox
        '
        resources.ApplyResources(Me.Text_CheckBox, "Text_CheckBox")
        Me.Text_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Text_CheckBox.Name = "Text_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Text_CheckBox, resources.GetString("Text_CheckBox.ToolTip"))
        Me.Text_CheckBox.UseVisualStyleBackColor = True
        '
        'Number_CheckBox
        '
        resources.ApplyResources(Me.Number_CheckBox, "Number_CheckBox")
        Me.Number_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Number_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.Numeric
        Me.Number_CheckBox.Name = "Number_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Number_CheckBox, resources.GetString("Number_CheckBox.ToolTip"))
        Me.Number_CheckBox.UseVisualStyleBackColor = True
        '
        'TrueFalse_CheckBox
        '
        resources.ApplyResources(Me.TrueFalse_CheckBox, "TrueFalse_CheckBox")
        Me.TrueFalse_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.TrueFalse_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.Vrai_Faux
        Me.TrueFalse_CheckBox.Name = "TrueFalse_CheckBox"
        Me.ToolTip1.SetToolTip(Me.TrueFalse_CheckBox, resources.GetString("TrueFalse_CheckBox.ToolTip"))
        Me.TrueFalse_CheckBox.UseVisualStyleBackColor = True
        '
        'Color_CheckBox
        '
        resources.ApplyResources(Me.Color_CheckBox, "Color_CheckBox")
        Me.Color_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Color_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.Couleur
        Me.Color_CheckBox.Name = "Color_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Color_CheckBox, resources.GetString("Color_CheckBox.ToolTip"))
        Me.Color_CheckBox.UseVisualStyleBackColor = True
        '
        'Other_CheckBox
        '
        resources.ApplyResources(Me.Other_CheckBox, "Other_CheckBox")
        Me.Other_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Other_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.cog
        Me.Other_CheckBox.Name = "Other_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Other_CheckBox, resources.GetString("Other_CheckBox.ToolTip"))
        Me.Other_CheckBox.UseVisualStyleBackColor = True
        '
        'Variable_CheckBox
        '
        resources.ApplyResources(Me.Variable_CheckBox, "Variable_CheckBox")
        Me.Variable_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Variable_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.gest_var
        Me.Variable_CheckBox.Name = "Variable_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Variable_CheckBox, resources.GetString("Variable_CheckBox.ToolTip"))
        Me.Variable_CheckBox.UseVisualStyleBackColor = True
        '
        'Ressource_CheckBox
        '
        resources.ApplyResources(Me.Ressource_CheckBox, "Ressource_CheckBox")
        Me.Ressource_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ressource_CheckBox.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.resx
        Me.Ressource_CheckBox.Name = "Ressource_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Ressource_CheckBox, resources.GetString("Ressource_CheckBox.ToolTip"))
        Me.Ressource_CheckBox.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ValueEdit
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ValueEdit"
        resources.ApplyResources(Me, "$this")
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Resources_Panel.ResumeLayout(False)
        Me.Variables_Panel.ResumeLayout(False)
        Me.Text_Panel.ResumeLayout(False)
        Me.Other_Panel.ResumeLayout(False)
        Me.Other_Panel.PerformLayout()
        Me.TrueFalse_Panel.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Num_Panel.ResumeLayout(False)
        Me.VB_Panel.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents VB_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Text_CheckBox As System.Windows.Forms.CheckBox
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Color_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TrueFalse_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Number_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Color_Panel As System.Windows.Forms.Panel
    Friend WithEvents TrueFalse_Panel As System.Windows.Forms.Panel
    Friend WithEvents Num_Panel As System.Windows.Forms.Panel
    Friend WithEvents Text_Panel As System.Windows.Forms.Panel
    Friend WithEvents VB_Panel As System.Windows.Forms.Panel
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CouperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SélectionnerToutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AnnulerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RétablirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Vrai_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Faux_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Number_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Text_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Other_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Other_Panel As System.Windows.Forms.Panel
    Friend WithEvents Type_Button As System.Windows.Forms.Button
    Friend WithEvents Type_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Constructor_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PropertyGrids1 As VelerSoftware.SZVB.PropertyGrids.PropertyGrids
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Variables_Panel As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Variables_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Variables_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Variable_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Resources_Panel As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Resources_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Ressource_CheckBox As System.Windows.Forms.CheckBox

End Class
