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
Partial Class BoxExplorateurSolutions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BoxExplorateurSolutions))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.TreeViewMultiSelect1 = New VelerSoftware.SZC.TreeViewMultiSelect.TreeViewMultiSelect()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OuvrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirAvecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AjouterUnÉlémentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauDossierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouveauDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AjouterUnDocumentExistantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.NouveauProjetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.AjouterUnProjetExistantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupprimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenommerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.DéfinirCommeLeProjetDeDémarrageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdreDeLaGénérationDeLaSolutionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirDansLexplorateurWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ActualiserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropriétéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Nouveau_Dossier_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.Nouveau_Fichier_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Proprietes_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualiser_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Reduire_Projet_ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.KryptonContextMenuHeading1 = New VelerSoftware.Design.Toolkit.KryptonContextMenuHeading()
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.TreeViewMultiSelect1)
        Me.kryptonPanel.Controls.Add(Me.ToolStrip1)
        Me.kryptonPanel.Name = "kryptonPanel"
        '
        'TreeViewMultiSelect1
        '
        resources.ApplyResources(Me.TreeViewMultiSelect1, "TreeViewMultiSelect1")
        Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.TreeViewMultiSelect1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewMultiSelect1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TreeViewMultiSelect1.FullRowSelect = True
        Me.TreeViewMultiSelect1.ImageList = Me.ImageList1
        Me.TreeViewMultiSelect1.LabelEdit = True
        Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.TreeViewMultiSelect1.Name = "TreeViewMultiSelect1"
        Me.TreeViewMultiSelect1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(108, Byte), Integer))
        Me.TreeViewMultiSelect1.SelectionMode = VelerSoftware.SZC.TreeViewMultiSelect.TreeViewSelectionMode.MultiSelect
        Me.TreeViewMultiSelect1.ShowLines = False
        Me.TreeViewMultiSelect1.ShowRootLines = False
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirToolStripMenuItem, Me.OuvrirAvecToolStripMenuItem, Me.ToolStripSeparator4, Me.AjouterUnÉlémentToolStripMenuItem, Me.ToolStripSeparator6, Me.CopierToolStripMenuItem, Me.CollerToolStripMenuItem, Me.SupprimerToolStripMenuItem, Me.RenommerToolStripMenuItem, Me.ToolStripSeparator7, Me.DéfinirCommeLeProjetDeDémarrageToolStripMenuItem, Me.OrdreDeLaGénérationDeLaSolutionToolStripMenuItem, Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem, Me.OuvrirDansLexplorateurWindowsToolStripMenuItem, Me.ToolStripSeparator9, Me.ActualiserToolStripMenuItem, Me.PropriétéToolStripMenuItem, Me.ToolStripSeparator8})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'OuvrirToolStripMenuItem
        '
        resources.ApplyResources(Me.OuvrirToolStripMenuItem, "OuvrirToolStripMenuItem")
        Me.OuvrirToolStripMenuItem.Name = "OuvrirToolStripMenuItem"
        '
        'OuvrirAvecToolStripMenuItem
        '
        resources.ApplyResources(Me.OuvrirAvecToolStripMenuItem, "OuvrirAvecToolStripMenuItem")
        Me.OuvrirAvecToolStripMenuItem.Name = "OuvrirAvecToolStripMenuItem"
        '
        'ToolStripSeparator4
        '
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        '
        'AjouterUnÉlémentToolStripMenuItem
        '
        resources.ApplyResources(Me.AjouterUnÉlémentToolStripMenuItem, "AjouterUnÉlémentToolStripMenuItem")
        Me.AjouterUnÉlémentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NouveauDossierToolStripMenuItem, Me.NouveauDocumentToolStripMenuItem, Me.ToolStripSeparator5, Me.AjouterUnDocumentExistantToolStripMenuItem, Me.ToolStripSeparator10, Me.NouveauProjetToolStripMenuItem, Me.ToolStripSeparator11, Me.AjouterUnProjetExistantToolStripMenuItem})
        Me.AjouterUnÉlémentToolStripMenuItem.Name = "AjouterUnÉlémentToolStripMenuItem"
        '
        'NouveauDossierToolStripMenuItem
        '
        resources.ApplyResources(Me.NouveauDossierToolStripMenuItem, "NouveauDossierToolStripMenuItem")
        Me.NouveauDossierToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.nouveau_dossier
        Me.NouveauDossierToolStripMenuItem.Name = "NouveauDossierToolStripMenuItem"
        '
        'NouveauDocumentToolStripMenuItem
        '
        resources.ApplyResources(Me.NouveauDocumentToolStripMenuItem, "NouveauDocumentToolStripMenuItem")
        Me.NouveauDocumentToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.Nouveau_Fichier_16x16
        Me.NouveauDocumentToolStripMenuItem.Name = "NouveauDocumentToolStripMenuItem"
        '
        'ToolStripSeparator5
        '
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        '
        'AjouterUnDocumentExistantToolStripMenuItem
        '
        resources.ApplyResources(Me.AjouterUnDocumentExistantToolStripMenuItem, "AjouterUnDocumentExistantToolStripMenuItem")
        Me.AjouterUnDocumentExistantToolStripMenuItem.Name = "AjouterUnDocumentExistantToolStripMenuItem"
        '
        'ToolStripSeparator10
        '
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        '
        'NouveauProjetToolStripMenuItem
        '
        resources.ApplyResources(Me.NouveauProjetToolStripMenuItem, "NouveauProjetToolStripMenuItem")
        Me.NouveauProjetToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.Nouveau_Projet_16x16
        Me.NouveauProjetToolStripMenuItem.Name = "NouveauProjetToolStripMenuItem"
        '
        'ToolStripSeparator11
        '
        resources.ApplyResources(Me.ToolStripSeparator11, "ToolStripSeparator11")
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        '
        'AjouterUnProjetExistantToolStripMenuItem
        '
        resources.ApplyResources(Me.AjouterUnProjetExistantToolStripMenuItem, "AjouterUnProjetExistantToolStripMenuItem")
        Me.AjouterUnProjetExistantToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.Ouvrir_Projet_16x16
        Me.AjouterUnProjetExistantToolStripMenuItem.Name = "AjouterUnProjetExistantToolStripMenuItem"
        '
        'ToolStripSeparator6
        '
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        '
        'CopierToolStripMenuItem
        '
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        Me.CopierToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.copy_small
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        '
        'CollerToolStripMenuItem
        '
        resources.ApplyResources(Me.CollerToolStripMenuItem, "CollerToolStripMenuItem")
        Me.CollerToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.paste_sma
        Me.CollerToolStripMenuItem.Name = "CollerToolStripMenuItem"
        '
        'SupprimerToolStripMenuItem
        '
        resources.ApplyResources(Me.SupprimerToolStripMenuItem, "SupprimerToolStripMenuItem")
        Me.SupprimerToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.delete
        Me.SupprimerToolStripMenuItem.Name = "SupprimerToolStripMenuItem"
        '
        'RenommerToolStripMenuItem
        '
        resources.ApplyResources(Me.RenommerToolStripMenuItem, "RenommerToolStripMenuItem")
        Me.RenommerToolStripMenuItem.Name = "RenommerToolStripMenuItem"
        '
        'ToolStripSeparator7
        '
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        '
        'DéfinirCommeLeProjetDeDémarrageToolStripMenuItem
        '
        resources.ApplyResources(Me.DéfinirCommeLeProjetDeDémarrageToolStripMenuItem, "DéfinirCommeLeProjetDeDémarrageToolStripMenuItem")
        Me.DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Name = "DéfinirCommeLeProjetDeDémarrageToolStripMenuItem"
        '
        'OrdreDeLaGénérationDeLaSolutionToolStripMenuItem
        '
        resources.ApplyResources(Me.OrdreDeLaGénérationDeLaSolutionToolStripMenuItem, "OrdreDeLaGénérationDeLaSolutionToolStripMenuItem")
        Me.OrdreDeLaGénérationDeLaSolutionToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.Ordre_Generation
        Me.OrdreDeLaGénérationDeLaSolutionToolStripMenuItem.Name = "OrdreDeLaGénérationDeLaSolutionToolStripMenuItem"
        '
        'OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem
        '
        resources.ApplyResources(Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem, "OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem")
        Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Name = "OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem"
        '
        'OuvrirDansLexplorateurWindowsToolStripMenuItem
        '
        resources.ApplyResources(Me.OuvrirDansLexplorateurWindowsToolStripMenuItem, "OuvrirDansLexplorateurWindowsToolStripMenuItem")
        Me.OuvrirDansLexplorateurWindowsToolStripMenuItem.Name = "OuvrirDansLexplorateurWindowsToolStripMenuItem"
        '
        'ToolStripSeparator9
        '
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        '
        'ActualiserToolStripMenuItem
        '
        resources.ApplyResources(Me.ActualiserToolStripMenuItem, "ActualiserToolStripMenuItem")
        Me.ActualiserToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.actualiser
        Me.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem"
        '
        'PropriétéToolStripMenuItem
        '
        resources.ApplyResources(Me.PropriétéToolStripMenuItem, "PropriétéToolStripMenuItem")
        Me.PropriétéToolStripMenuItem.Image = Global.SoftwareZator.My.Resources.Resources.Propriété
        Me.PropriétéToolStripMenuItem.Name = "PropriétéToolStripMenuItem"
        '
        'ToolStripSeparator8
        '
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
        Me.ImageList1.Images.SetKeyName(19, "lightning.png")
        Me.ImageList1.Images.SetKeyName(20, "Fichier Statistiques.png")
        Me.ImageList1.Images.SetKeyName(21, "database_access.png")
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Nouveau_Dossier_ToolStripButton, Me.Nouveau_Fichier_ToolStripButton, Me.ToolStripSeparator1, Me.Proprietes_ToolStripButton, Me.ToolStripSeparator3, Me.Actualiser_ToolStripButton, Me.ToolStripSeparator2, Me.Reduire_Projet_ToolStripButton})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'Nouveau_Dossier_ToolStripButton
        '
        resources.ApplyResources(Me.Nouveau_Dossier_ToolStripButton, "Nouveau_Dossier_ToolStripButton")
        Me.Nouveau_Dossier_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Nouveau_Dossier_ToolStripButton.Image = Global.SoftwareZator.My.Resources.Resources.nouveau_dossier
        Me.Nouveau_Dossier_ToolStripButton.Name = "Nouveau_Dossier_ToolStripButton"
        '
        'Nouveau_Fichier_ToolStripButton
        '
        resources.ApplyResources(Me.Nouveau_Fichier_ToolStripButton, "Nouveau_Fichier_ToolStripButton")
        Me.Nouveau_Fichier_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Nouveau_Fichier_ToolStripButton.Image = Global.SoftwareZator.My.Resources.Resources.Nouveau_Fichier_16x16
        Me.Nouveau_Fichier_ToolStripButton.Name = "Nouveau_Fichier_ToolStripButton"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'Proprietes_ToolStripButton
        '
        resources.ApplyResources(Me.Proprietes_ToolStripButton, "Proprietes_ToolStripButton")
        Me.Proprietes_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Proprietes_ToolStripButton.Image = Global.SoftwareZator.My.Resources.Resources.Propriété
        Me.Proprietes_ToolStripButton.Name = "Proprietes_ToolStripButton"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'Actualiser_ToolStripButton
        '
        resources.ApplyResources(Me.Actualiser_ToolStripButton, "Actualiser_ToolStripButton")
        Me.Actualiser_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Actualiser_ToolStripButton.Image = Global.SoftwareZator.My.Resources.Resources.actualiser
        Me.Actualiser_ToolStripButton.Name = "Actualiser_ToolStripButton"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'Reduire_Projet_ToolStripButton
        '
        resources.ApplyResources(Me.Reduire_Projet_ToolStripButton, "Reduire_Projet_ToolStripButton")
        Me.Reduire_Projet_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Reduire_Projet_ToolStripButton.Image = Global.SoftwareZator.My.Resources.Resources.Reduire_Projet
        Me.Reduire_Projet_ToolStripButton.Name = "Reduire_Projet_ToolStripButton"
        '
        'KryptonContextMenuHeading1
        '
        resources.ApplyResources(Me.KryptonContextMenuHeading1, "KryptonContextMenuHeading1")
        '
        'BoxExplorateurSolutions
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "BoxExplorateurSolutions"
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.kryptonPanel.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Actualiser_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TreeViewMultiSelect1 As VelerSoftware.SZC.TreeViewMultiSelect.TreeViewMultiSelect
    Friend WithEvents Nouveau_Dossier_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Nouveau_Fichier_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Proprietes_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Reduire_Projet_ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents KryptonContextMenuHeading1 As VelerSoftware.Design.Toolkit.KryptonContextMenuHeading
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OuvrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirAvecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterUnÉlémentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauDossierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NouveauDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterUnDocumentExistantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupprimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenommerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropriétéToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DéfinirCommeLeProjetDeDémarrageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdreDeLaGénérationDeLaSolutionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ActualiserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NouveauProjetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterUnProjetExistantToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirDansLexplorateurWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
