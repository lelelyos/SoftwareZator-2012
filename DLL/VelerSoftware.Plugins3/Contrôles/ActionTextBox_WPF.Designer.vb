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
Partial Class ActionTextBox
    Inherits System.Windows.Forms.UserControl

    'Control remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur de contrôles
    Private components As System.ComponentModel.IContainer

    ' REMARQUE : la procédure suivante est requise par le Concepteur de composants
    ' Elle peut être modifiée à l'aide du Concepteur de composants. Ne la modifiez pas
    ' à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActionTextBox))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Controls_Panel = New System.Windows.Forms.Panel()
        Me.CodeEditorHost = New System.Windows.Forms.Integration.ElementHost()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Copier_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Couper_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Coller_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Selectionner_Tout_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Annuler_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Retablir_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Projet_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Resources_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Parametres_Projet_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Parametres_Fonction_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropriétésDuDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropriétésDunContrôleToolStripMenuItem = New VelerSoftware.Plugins3.ToolStripButton()
        Me.Application_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Application_Path_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MY_DOCUMENTS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MY_MUSICS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MY_VIDEOS_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MY_PICTURES_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Environement_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Code_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParseCodeButton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Controls_Panel)
        Me.SplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel1, "SplitContainer1.Panel1")
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ParseCodeButton)
        Me.SplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.SplitContainer1.Panel2, "SplitContainer1.Panel2")
        '
        'Controls_Panel
        '
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        Me.Controls_Panel.BackColor = System.Drawing.SystemColors.Control
        Me.Controls_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls_Panel.Controls.Add(Me.CodeEditorHost)
        Me.Controls_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Controls_Panel.Name = "Controls_Panel"
        '
        'CodeEditorHost
        '
        Me.CodeEditorHost.ContextMenuStrip = Me.ContextMenuStrip1
        Me.CodeEditorHost.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CodeEditorHost, "CodeEditorHost")
        Me.CodeEditorHost.Name = "CodeEditorHost"
        Me.CodeEditorHost.Child = Nothing
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Copier_ToolStripMenuItem, Me.Couper_ToolStripMenuItem, Me.Coller_ToolStripMenuItem, Me.ToolStripSeparator2, Me.Selectionner_Tout_ToolStripMenuItem, Me.ToolStripSeparator1, Me.Annuler_ToolStripMenuItem, Me.Retablir_ToolStripMenuItem, Me.ToolStripSeparator3, Me.Projet_ToolStripMenuItem, Me.Resources_ToolStripMenuItem, Me.Parametres_Projet_ToolStripMenuItem, Me.Parametres_Fonction_ToolStripMenuItem, Me.PropriétésDuDocumentToolStripMenuItem, Me.PropriétésDunContrôleToolStripMenuItem, Me.Application_ToolStripMenuItem, Me.Environement_ToolStripMenuItem, Me.Code_ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'Copier_ToolStripMenuItem
        '
        Me.Copier_ToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.copy_small
        Me.Copier_ToolStripMenuItem.Name = "Copier_ToolStripMenuItem"
        resources.ApplyResources(Me.Copier_ToolStripMenuItem, "Copier_ToolStripMenuItem")
        '
        'Couper_ToolStripMenuItem
        '
        Me.Couper_ToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.cut
        Me.Couper_ToolStripMenuItem.Name = "Couper_ToolStripMenuItem"
        resources.ApplyResources(Me.Couper_ToolStripMenuItem, "Couper_ToolStripMenuItem")
        '
        'Coller_ToolStripMenuItem
        '
        Me.Coller_ToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.paste_sma
        Me.Coller_ToolStripMenuItem.Name = "Coller_ToolStripMenuItem"
        resources.ApplyResources(Me.Coller_ToolStripMenuItem, "Coller_ToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'Selectionner_Tout_ToolStripMenuItem
        '
        Me.Selectionner_Tout_ToolStripMenuItem.Name = "Selectionner_Tout_ToolStripMenuItem"
        resources.ApplyResources(Me.Selectionner_Tout_ToolStripMenuItem, "Selectionner_Tout_ToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'Annuler_ToolStripMenuItem
        '
        Me.Annuler_ToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.undo
        Me.Annuler_ToolStripMenuItem.Name = "Annuler_ToolStripMenuItem"
        resources.ApplyResources(Me.Annuler_ToolStripMenuItem, "Annuler_ToolStripMenuItem")
        '
        'Retablir_ToolStripMenuItem
        '
        Me.Retablir_ToolStripMenuItem.Image = Global.VelerSoftware.Plugins3.My.Resources.Resources.redo
        Me.Retablir_ToolStripMenuItem.Name = "Retablir_ToolStripMenuItem"
        resources.ApplyResources(Me.Retablir_ToolStripMenuItem, "Retablir_ToolStripMenuItem")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'Projet_ToolStripMenuItem
        '
        Me.Projet_ToolStripMenuItem.Name = "Projet_ToolStripMenuItem"
        resources.ApplyResources(Me.Projet_ToolStripMenuItem, "Projet_ToolStripMenuItem")
        '
        'Resources_ToolStripMenuItem
        '
        Me.Resources_ToolStripMenuItem.Name = "Resources_ToolStripMenuItem"
        resources.ApplyResources(Me.Resources_ToolStripMenuItem, "Resources_ToolStripMenuItem")
        '
        'Parametres_Projet_ToolStripMenuItem
        '
        Me.Parametres_Projet_ToolStripMenuItem.Name = "Parametres_Projet_ToolStripMenuItem"
        resources.ApplyResources(Me.Parametres_Projet_ToolStripMenuItem, "Parametres_Projet_ToolStripMenuItem")
        '
        'Parametres_Fonction_ToolStripMenuItem
        '
        Me.Parametres_Fonction_ToolStripMenuItem.Name = "Parametres_Fonction_ToolStripMenuItem"
        resources.ApplyResources(Me.Parametres_Fonction_ToolStripMenuItem, "Parametres_Fonction_ToolStripMenuItem")
        '
        'PropriétésDuDocumentToolStripMenuItem
        '
        Me.PropriétésDuDocumentToolStripMenuItem.Name = "PropriétésDuDocumentToolStripMenuItem"
        resources.ApplyResources(Me.PropriétésDuDocumentToolStripMenuItem, "PropriétésDuDocumentToolStripMenuItem")
        '
        'PropriétésDunContrôleToolStripMenuItem
        '
        Me.PropriétésDunContrôleToolStripMenuItem.Name = "PropriétésDunContrôleToolStripMenuItem"
        resources.ApplyResources(Me.PropriétésDunContrôleToolStripMenuItem, "PropriétésDunContrôleToolStripMenuItem")
        '
        'Application_ToolStripMenuItem
        '
        Me.Application_ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Application_Path_ToolStripMenuItem, Me.MY_DOCUMENTS_ToolStripMenuItem, Me.MY_MUSICS_ToolStripMenuItem, Me.MY_VIDEOS_ToolStripMenuItem, Me.MY_PICTURES_ToolStripMenuItem})
        Me.Application_ToolStripMenuItem.Name = "Application_ToolStripMenuItem"
        resources.ApplyResources(Me.Application_ToolStripMenuItem, "Application_ToolStripMenuItem")
        '
        'Application_Path_ToolStripMenuItem
        '
        Me.Application_Path_ToolStripMenuItem.Name = "Application_Path_ToolStripMenuItem"
        resources.ApplyResources(Me.Application_Path_ToolStripMenuItem, "Application_Path_ToolStripMenuItem")
        '
        'MY_DOCUMENTS_ToolStripMenuItem
        '
        Me.MY_DOCUMENTS_ToolStripMenuItem.Name = "MY_DOCUMENTS_ToolStripMenuItem"
        resources.ApplyResources(Me.MY_DOCUMENTS_ToolStripMenuItem, "MY_DOCUMENTS_ToolStripMenuItem")
        '
        'MY_MUSICS_ToolStripMenuItem
        '
        Me.MY_MUSICS_ToolStripMenuItem.Name = "MY_MUSICS_ToolStripMenuItem"
        resources.ApplyResources(Me.MY_MUSICS_ToolStripMenuItem, "MY_MUSICS_ToolStripMenuItem")
        '
        'MY_VIDEOS_ToolStripMenuItem
        '
        Me.MY_VIDEOS_ToolStripMenuItem.Name = "MY_VIDEOS_ToolStripMenuItem"
        resources.ApplyResources(Me.MY_VIDEOS_ToolStripMenuItem, "MY_VIDEOS_ToolStripMenuItem")
        '
        'MY_PICTURES_ToolStripMenuItem
        '
        Me.MY_PICTURES_ToolStripMenuItem.Name = "MY_PICTURES_ToolStripMenuItem"
        resources.ApplyResources(Me.MY_PICTURES_ToolStripMenuItem, "MY_PICTURES_ToolStripMenuItem")
        '
        'Environement_ToolStripMenuItem
        '
        Me.Environement_ToolStripMenuItem.Name = "Environement_ToolStripMenuItem"
        resources.ApplyResources(Me.Environement_ToolStripMenuItem, "Environement_ToolStripMenuItem")
        '
        'Code_ToolStripMenuItem
        '
        Me.Code_ToolStripMenuItem.Name = "Code_ToolStripMenuItem"
        resources.ApplyResources(Me.Code_ToolStripMenuItem, "Code_ToolStripMenuItem")
        '
        'ParseCodeButton
        '
        resources.ApplyResources(Me.ParseCodeButton, "ParseCodeButton")
        Me.ParseCodeButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.ParseCodeButton.Name = "ParseCodeButton"
        Me.ToolTip1.SetToolTip(Me.ParseCodeButton, resources.GetString("ParseCodeButton.ToolTip"))
        Me.ParseCodeButton.UseCompatibleTextRendering = True
        Me.ParseCodeButton.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 10
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 0
        '
        'ActionTextBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ActionTextBox"
        resources.ApplyResources(Me, "$this")
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Projet_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Application_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Environement_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Copier_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Couper_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Coller_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Selectionner_Tout_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Application_Path_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MY_DOCUMENTS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MY_MUSICS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MY_VIDEOS_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MY_PICTURES_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Annuler_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Retablir_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Parametres_Projet_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Parametres_Fonction_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Code_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Resources_ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CodeEditorHost As System.Windows.Forms.Integration.ElementHost
    Public WithEvents Controls_Panel As System.Windows.Forms.Panel
    Friend WithEvents ParseCodeButton As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PropriétésDuDocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropriétésDunContrôleToolStripMenuItem As VelerSoftware.Plugins3.ToolStripButton

End Class

