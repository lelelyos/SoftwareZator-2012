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
Partial Class BoxProprietes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxProprietes))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.PropertyGrids1 = New VelerSoftware.SZVB.PropertyGrids.PropertyGrids()
        Me.KryptonRichTextBox1 = New VelerSoftware.Design.Toolkit.KryptonRichTextBox()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.PropertyGrids1)
        Me.kryptonPanel.Controls.Add(Me.KryptonRichTextBox1)
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'PropertyGrids1
        '
        resources.ApplyResources(Me.PropertyGrids1, "PropertyGrids1")
        Me.PropertyGrids1.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PropertyGrids1.CategoryForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.PropertyGrids1.CommandsForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        '
        '
        '
        Me.PropertyGrids1.DocCommentDescription.AccessibleDescription = resources.GetString("PropertyGrids1.DocCommentDescription.AccessibleDescription")
        Me.PropertyGrids1.DocCommentDescription.AccessibleName = resources.GetString("PropertyGrids1.DocCommentDescription.AccessibleName")
        Me.PropertyGrids1.DocCommentDescription.Anchor = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrids1.DocCommentDescription.AutoEllipsis = True
        Me.PropertyGrids1.DocCommentDescription.AutoSize = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.AutoSize"), Boolean)
        Me.PropertyGrids1.DocCommentDescription.BackgroundImageLayout = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PropertyGrids1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentDescription.Dock = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.DocCommentDescription.Font = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.PropertyGrids1.DocCommentDescription.ImageAlign = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PropertyGrids1.DocCommentDescription.ImageIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.ImageIndex"), Integer)
        Me.PropertyGrids1.DocCommentDescription.ImageKey = resources.GetString("PropertyGrids1.DocCommentDescription.ImageKey")
        Me.PropertyGrids1.DocCommentDescription.ImeMode = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentDescription.Location = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentDescription.Name = ""
        Me.PropertyGrids1.DocCommentDescription.RightToLeft = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.DocCommentDescription.Size = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentDescription.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentDescription.TextAlign = DirectCast(resources.GetObject("PropertyGrids1.DocCommentDescription.TextAlign"), System.Drawing.ContentAlignment)
        Me.PropertyGrids1.DocCommentImage = Nothing
        '
        '
        '
        Me.PropertyGrids1.DocCommentTitle.AccessibleDescription = resources.GetString("PropertyGrids1.DocCommentTitle.AccessibleDescription")
        Me.PropertyGrids1.DocCommentTitle.AccessibleName = resources.GetString("PropertyGrids1.DocCommentTitle.AccessibleName")
        Me.PropertyGrids1.DocCommentTitle.Anchor = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrids1.DocCommentTitle.AutoSize = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.AutoSize"), Boolean)
        Me.PropertyGrids1.DocCommentTitle.BackgroundImageLayout = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PropertyGrids1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PropertyGrids1.DocCommentTitle.Dock = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.DocCommentTitle.Font = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PropertyGrids1.DocCommentTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.PropertyGrids1.DocCommentTitle.ImageAlign = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PropertyGrids1.DocCommentTitle.ImageIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.ImageIndex"), Integer)
        Me.PropertyGrids1.DocCommentTitle.ImageKey = resources.GetString("PropertyGrids1.DocCommentTitle.ImageKey")
        Me.PropertyGrids1.DocCommentTitle.ImeMode = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.DocCommentTitle.Location = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PropertyGrids1.DocCommentTitle.Name = ""
        Me.PropertyGrids1.DocCommentTitle.RightToLeft = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.DocCommentTitle.Size = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PropertyGrids1.DocCommentTitle.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.TabIndex"), Integer)
        Me.PropertyGrids1.DocCommentTitle.TextAlign = DirectCast(resources.GetObject("PropertyGrids1.DocCommentTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.PropertyGrids1.DocCommentTitle.UseMnemonic = False
        Me.PropertyGrids1.HelpBackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PropertyGrids1.HelpForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.PropertyGrids1.LineColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PropertyGrids1.Name = "PropertyGrids1"
        Me.PropertyGrids1.SelectedObject = DirectCast(resources.GetObject("PropertyGrids1.SelectedObject"), Object)
        Me.PropertyGrids1.ShowCustomProperties = True
        Me.PropertyGrids1.Tag = " "
        '
        '
        '
        Me.PropertyGrids1.ToolStrip.AccessibleDescription = resources.GetString("PropertyGrids1.ToolStrip.AccessibleDescription")
        Me.PropertyGrids1.ToolStrip.AccessibleName = resources.GetString("PropertyGrids1.ToolStrip.AccessibleName")
        Me.PropertyGrids1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PropertyGrids1.ToolStrip.AllowMerge = False
        Me.PropertyGrids1.ToolStrip.Anchor = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrids1.ToolStrip.AutoSize = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.AutoSize"), Boolean)
        Me.PropertyGrids1.ToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.PropertyGrids1.ToolStrip.BackgroundImage = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.BackgroundImage"), System.Drawing.Image)
        Me.PropertyGrids1.ToolStrip.BackgroundImageLayout = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PropertyGrids1.ToolStrip.CanOverflow = False
        Me.PropertyGrids1.ToolStrip.Dock = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PropertyGrids1.ToolStrip.Font = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Font"), System.Drawing.Font)
        Me.PropertyGrids1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PropertyGrids1.ToolStrip.ImeMode = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PropertyGrids1.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.PropertyGrids1.ToolStrip.Location = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Location"), System.Drawing.Point)
        Me.PropertyGrids1.ToolStrip.Name = ""
        Me.PropertyGrids1.ToolStrip.Padding = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PropertyGrids1.ToolStrip.RightToLeft = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PropertyGrids1.ToolStrip.Size = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.Size"), System.Drawing.Size)
        Me.PropertyGrids1.ToolStrip.TabIndex = DirectCast(resources.GetObject("PropertyGrids1.ToolStrip.TabIndex"), Integer)
        Me.PropertyGrids1.ToolStrip.TabStop = True
        Me.PropertyGrids1.ToolStrip.Text = resources.GetString("PropertyGrids1.ToolStrip.Text")
        Me.PropertyGrids1.ViewBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.PropertyGrids1.ViewForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        '
        'KryptonRichTextBox1
        '
        resources.ApplyResources(Me.KryptonRichTextBox1, "KryptonRichTextBox1")
        Me.KryptonRichTextBox1.DetectUrls = False
        Me.KryptonRichTextBox1.Name = "KryptonRichTextBox1"
        Me.KryptonRichTextBox1.ReadOnly = True
        '
        'BoxProprietes
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxProprietes"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents PropertyGrids1 As VelerSoftware.SZVB.PropertyGrids.PropertyGrids
    Friend WithEvents KryptonRichTextBox1 As VelerSoftware.Design.Toolkit.KryptonRichTextBox

End Class
