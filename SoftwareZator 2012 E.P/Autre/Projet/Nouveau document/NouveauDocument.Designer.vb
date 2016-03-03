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
Partial Class NouveauDocument
    Inherits VelerSoftware.SZVB.AeroWizardForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NouveauDocument))
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CommandLink2 = New VelerSoftware.SZVB.CommandLink()
        Me.CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Fenetre_CommandLink = New VelerSoftware.SZVB.CommandLink()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.WizardTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'WizardTabControl1
        '
        Me.WizardTabControl1.Controls.Add(Me.TabPage1)
        Me.WizardTabControl1.Controls.Add(Me.TabPage2)
        Me.WizardTabControl1.Controls.Add(Me.TabPage3)
        Me.WizardTabControl1.Controls.Add(Me.TabPage5)
        resources.ApplyResources(Me.WizardTabControl1, "WizardTabControl1")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LabelTitle)
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LabelTitle
        '
        resources.ApplyResources(Me.LabelTitle, "LabelTitle")
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelTitle.Name = "LabelTitle"
        '
        'TreeView1
        '
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeView1.HideSelection = False
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowNodeToolTips = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = DirectCast(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Solution_Icon")
        Me.ImageList1.Images.SetKeyName(1, "Project_Application_16x16.png")
        Me.ImageList1.Images.SetKeyName(2, "Project_DLL_16x16.png")
        Me.ImageList1.Images.SetKeyName(3, "Dossier Fermer.png")
        Me.ImageList1.Images.SetKeyName(4, "Dossier Ouvert.png")
        Me.ImageList1.Images.SetKeyName(5, "Fichier BMP.png")
        Me.ImageList1.Images.SetKeyName(6, "Fichier Code.png")
        Me.ImageList1.Images.SetKeyName(7, "Fichier Fenetre.png")
        Me.ImageList1.Images.SetKeyName(8, "Fichier Inconnu.png")
        Me.ImageList1.Images.SetKeyName(9, "Fichier OCX.png")
        Me.ImageList1.Images.SetKeyName(10, "Fichier PNG.png")
        Me.ImageList1.Images.SetKeyName(11, "Fichier Ressource.png")
        Me.ImageList1.Images.SetKeyName(12, "Fichier Texte.png")
        Me.ImageList1.Images.SetKeyName(13, "Fichier Web.png")
        Me.ImageList1.Images.SetKeyName(14, "VB_File_Small.png")
        Me.ImageList1.Images.SetKeyName(15, "parametre.png")
        Me.ImageList1.Images.SetKeyName(16, "icone.png")
        Me.ImageList1.Images.SetKeyName(17, "Projet_Non_Charge.png")
        Me.ImageList1.Images.SetKeyName(18, "Chart_Small.png")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CommandLink2)
        Me.TabPage2.Controls.Add(Me.CommandLink1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Fenetre_CommandLink)
        Me.TabPage2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CommandLink2
        '
        resources.ApplyResources(Me.CommandLink2, "CommandLink2")
        Me.CommandLink2.AutoEllipsis = True
        Me.CommandLink2.Cursor = System.Windows.Forms.Cursors.Default
        Me.CommandLink2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink2.Name = "CommandLink2"
        Me.CommandLink2.Tag = "Code"
        Me.ToolTip1.SetToolTip(Me.CommandLink2, resources.GetString("CommandLink2.ToolTip"))
        '
        'CommandLink1
        '
        resources.ApplyResources(Me.CommandLink1, "CommandLink1")
        Me.CommandLink1.AutoEllipsis = True
        Me.CommandLink1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.CommandLink1.Name = "CommandLink1"
        Me.CommandLink1.Tag = "Class"
        Me.ToolTip1.SetToolTip(Me.CommandLink1, resources.GetString("CommandLink1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'Fenetre_CommandLink
        '
        resources.ApplyResources(Me.Fenetre_CommandLink, "Fenetre_CommandLink")
        Me.Fenetre_CommandLink.AutoEllipsis = True
        Me.Fenetre_CommandLink.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fenetre_CommandLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Fenetre_CommandLink.Name = "Fenetre_CommandLink"
        Me.Fenetre_CommandLink.Tag = "Window"
        Me.ToolTip1.SetToolTip(Me.Fenetre_CommandLink, resources.GetString("Fenetre_CommandLink.ToolTip"))
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.ListView1)
        Me.TabPage3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Name = "Label2"
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {DirectCast(resources.GetObject("ListView1.Groups"), System.Windows.Forms.ListViewGroup)})
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList2
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList2, "ImageList2")
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.KryptonTextBox1)
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.Label14)
        Me.TabPage5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage5, "TabPage5")
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'KryptonTextBox1
        '
        resources.ApplyResources(Me.KryptonTextBox1, "KryptonTextBox1")
        Me.KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1, resources.GetString("KryptonTextBox1.ToolTip"))
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Name = "Label15"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.Name = "Label14"
        '
        'OpenFileDialog1
        '
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'NouveauDocument
        '
        Me.BackCaption = "Précédent"
        Me.CancelButtonText = "Annuler"
        Me.Caption = "New document"
        resources.ApplyResources(Me, "$this")
        Me.FinishButtonText = "Terminer"
        Me.HelpButton = True
        Me.Name = "NouveauDocument"
        Me.NextButtonText = "Suivant"
        Me.WizardIcon = Global.SoftwareZator.My.Resources.Resources.Nouveau_Fichier_16x16
        Me.WizardTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Fenetre_CommandLink As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents CommandLink2 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
