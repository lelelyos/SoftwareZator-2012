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
Partial Class BoxBoiteAOutils
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxBoiteAOutils))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonWrapLabel1 = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.Classes_ToolBox = New VelerSoftware.SZC.ToolBox.ToolBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Fonctions_ToolBox = New VelerSoftware.SZC.ToolBox.ToolBox()
        Me.Concepteur_Fenetre_ToolBox = New VelerSoftware.SZC.ToolBox.ToolBox()
        Me.Vide_ToolBox = New VelerSoftware.SZC.ToolBox.ToolBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        Me.kryptonPanel.Controls.Add(Me.KryptonWrapLabel1)
        Me.kryptonPanel.Controls.Add(Me.Classes_ToolBox)
        Me.kryptonPanel.Controls.Add(Me.ListBox1)
        Me.kryptonPanel.Controls.Add(Me.Fonctions_ToolBox)
        Me.kryptonPanel.Controls.Add(Me.Concepteur_Fenetre_ToolBox)
        Me.kryptonPanel.Controls.Add(Me.Vide_ToolBox)
        Me.kryptonPanel.Controls.Add(Me.ToolStrip1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'KryptonWrapLabel1
        '
        resources.ApplyResources(Me.KryptonWrapLabel1, "KryptonWrapLabel1")
        Me.KryptonWrapLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.KryptonWrapLabel1.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.KeyTip
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        '
        'Classes_ToolBox
        '
        Me.Classes_ToolBox.AllowDrop = True
        Me.Classes_ToolBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Classes_ToolBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Classes_ToolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        resources.ApplyResources(Me.Classes_ToolBox, "Classes_ToolBox")
        Me.Classes_ToolBox.FullRowSelect = True
        Me.Classes_ToolBox.HideSelection = False
        Me.Classes_ToolBox.HotTracking = True
        Me.Classes_ToolBox.ImageList = Me.ImageList1
        Me.Classes_ToolBox.ItemHeight = 20
        Me.Classes_ToolBox.Name = "Classes_ToolBox"
        Me.Classes_ToolBox.ShowLines = False
        Me.Classes_ToolBox.ShowNodeToolTips = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = DirectCast(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "OTHER")
        Me.ImageList1.Images.SetKeyName(1, "Pointer")
        '
        'ListBox1
        '
        Me.ListBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Name = "ListBox1"
        '
        'Fonctions_ToolBox
        '
        Me.Fonctions_ToolBox.AllowDrop = True
        Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Fonctions_ToolBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fonctions_ToolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        resources.ApplyResources(Me.Fonctions_ToolBox, "Fonctions_ToolBox")
        Me.Fonctions_ToolBox.FullRowSelect = True
        Me.Fonctions_ToolBox.HideSelection = False
        Me.Fonctions_ToolBox.HotTracking = True
        Me.Fonctions_ToolBox.ImageList = Me.ImageList1
        Me.Fonctions_ToolBox.ItemHeight = 20
        Me.Fonctions_ToolBox.Name = "Fonctions_ToolBox"
        Me.Fonctions_ToolBox.ShowLines = False
        Me.Fonctions_ToolBox.ShowNodeToolTips = True
        '
        'Concepteur_Fenetre_ToolBox
        '
        Me.Concepteur_Fenetre_ToolBox.AllowDrop = True
        Me.Concepteur_Fenetre_ToolBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Concepteur_Fenetre_ToolBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Concepteur_Fenetre_ToolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        resources.ApplyResources(Me.Concepteur_Fenetre_ToolBox, "Concepteur_Fenetre_ToolBox")
        Me.Concepteur_Fenetre_ToolBox.FullRowSelect = True
        Me.Concepteur_Fenetre_ToolBox.HideSelection = False
        Me.Concepteur_Fenetre_ToolBox.HotTracking = True
        Me.Concepteur_Fenetre_ToolBox.ImageList = Me.ImageList1
        Me.Concepteur_Fenetre_ToolBox.ItemHeight = 20
        Me.Concepteur_Fenetre_ToolBox.Name = "Concepteur_Fenetre_ToolBox"
        Me.Concepteur_Fenetre_ToolBox.ShowLines = False
        Me.Concepteur_Fenetre_ToolBox.ShowNodeToolTips = True
        '
        'Vide_ToolBox
        '
        Me.Vide_ToolBox.AllowDrop = True
        Me.Vide_ToolBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Vide_ToolBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Vide_ToolBox.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        resources.ApplyResources(Me.Vide_ToolBox, "Vide_ToolBox")
        Me.Vide_ToolBox.FullRowSelect = True
        Me.Vide_ToolBox.HideSelection = False
        Me.Vide_ToolBox.HotTracking = True
        Me.Vide_ToolBox.ImageList = Me.ImageList1
        Me.Vide_ToolBox.ItemHeight = 20
        Me.Vide_ToolBox.Name = "Vide_ToolBox"
        Me.Vide_ToolBox.ShowLines = False
        Me.Vide_ToolBox.ShowNodeToolTips = True
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        resources.ApplyResources(Me.ToolStripTextBox1, "ToolStripTextBox1")
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.SoftwareZator.My.Resources.Resources.find
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.SoftwareZator.My.Resources.Resources.add_ctrl
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'BoxBoiteAOutils
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxBoiteAOutils"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.kryptonPanel.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents Fonctions_ToolBox As VelerSoftware.SZC.ToolBox.ToolBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Concepteur_Fenetre_ToolBox As VelerSoftware.SZC.ToolBox.ToolBox
    Friend WithEvents Vide_ToolBox As VelerSoftware.SZC.ToolBox.ToolBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Classes_ToolBox As VelerSoftware.SZC.ToolBox.ToolBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonWrapLabel1 As VelerSoftware.Design.Toolkit.KryptonWrapLabel

End Class
