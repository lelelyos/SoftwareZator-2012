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
Partial Class BoxReconnaissanceVocale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxReconnaissanceVocale))
        Me.KryptonSplitContainer1 = New VelerSoftware.Design.Toolkit.KryptonSplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Fonctions_ToolBox = New VelerSoftware.SZC.ToolBox.ToolBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonPanel1 = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        DirectCast(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        DirectCast(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1, "KryptonSplitContainer1")
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        '
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.TextBox1)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.KryptonSplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Panel1.Font = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel1.Font"), System.Drawing.Font)
        Me.KryptonSplitContainer1.Panel1.ImeMode = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel1.ImeMode"), System.Windows.Forms.ImeMode)
        Me.KryptonSplitContainer1.Panel1.RightToLeft = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel1.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        '
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.Fonctions_ToolBox)
        Me.KryptonSplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Panel2.Font = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel2.Font"), System.Drawing.Font)
        Me.KryptonSplitContainer1.Panel2.ImeMode = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel2.ImeMode"), System.Windows.Forms.ImeMode)
        Me.KryptonSplitContainer1.Panel2.RightToLeft = DirectCast(resources.GetObject("KryptonSplitContainer1.Panel2.RightToLeft"), System.Windows.Forms.RightToLeft)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Fonctions_ToolBox
        '
        Me.Fonctions_ToolBox.AllowDrop = True
        Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Fonctions_ToolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Fonctions_ToolBox.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Fonctions_ToolBox, "Fonctions_ToolBox")
        Me.Fonctions_ToolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.Fonctions_ToolBox.FullRowSelect = True
        Me.Fonctions_ToolBox.HideSelection = False
        Me.Fonctions_ToolBox.HotTracking = True
        Me.Fonctions_ToolBox.ImageList = Me.ImageList1
        Me.Fonctions_ToolBox.ItemHeight = 20
        Me.Fonctions_ToolBox.Name = "Fonctions_ToolBox"
        Me.Fonctions_ToolBox.ShowLines = False
        Me.Fonctions_ToolBox.ShowNodeToolTips = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = DirectCast(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "OTHER")
        Me.ImageList1.Images.SetKeyName(1, "Pointer")
        '
        'kryptonPanel
        '
        Me.kryptonPanel.Controls.Add(Me.KryptonPanel1)
        Me.kryptonPanel.Controls.Add(Me.KryptonSplitContainer1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonButton1)
        Me.KryptonPanel1.Controls.Add(Me.Label3)
        Me.KryptonPanel1.Controls.Add(Me.PictureBox1)
        Me.KryptonPanel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonPanel1, "KryptonPanel1")
        Me.KryptonPanel1.Name = "KryptonPanel1"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.AutoEllipsis = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = Global.SoftwareZator.My.Resources.Resources.ChuckNorris
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'BoxReconnaissanceVocale
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxReconnaissanceVocale"
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel1.PerformLayout()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        DirectCast(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        DirectCast(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents KryptonSplitContainer1 As VelerSoftware.Design.Toolkit.KryptonSplitContainer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Fonctions_ToolBox As VelerSoftware.SZC.ToolBox.ToolBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents KryptonPanel1 As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
