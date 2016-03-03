''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxExplorateurSolutions

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.TreeViewMultiSelect1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeViewMultiSelect1.Handle, 4352 + 44, 64, 64)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeViewMultiSelect1.Handle, 4352 + 44, 32, 32)

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

#If DEBUG Then
        Me.TreeViewMultiSelect1.LabelEdit = False
#End If

    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.ToolStrip1.Font = font

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub








#Region "Select & Expand"

    Private Sub TreeViewMultiSelect1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeViewMultiSelect1.BeforeExpand
        If Not SOLUTION Is Nothing AndAlso (Not e.Node.Tag = "ROOT") Then ' Si l'élément sélectionné n'est pas le noeud de la solution, donc un dossier ou fichier ou projet
            'on efface les noeuds enfants pour le noeud selectionné
            e.Node.Nodes.Clear()

            If My.Computer.FileSystem.DirectoryExists(e.Node.ToolTipText) Then ' Si le dossier existe
                Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(e.Node.Tag)
                If proj.Loaded Then ' Et on ouvre le dossier
                    ClassProjet.AjouterRepertoire(e.Node, e.Node.ToolTipText, e.Node.Tag, proj)
                    ClassProjet.AjouterFichier(e.Node, e.Node.ToolTipText, e.Node.Tag, proj)
                End If
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMultiSelect1.AfterExpand
        If Not SOLUTION Is Nothing AndAlso e.Node.ImageIndex = 3 Then
            e.Node.ImageIndex = 4
            If e.Node.IsSelected Then
                e.Node.SelectedImageIndex = 4
            Else
                e.Node.SelectedImageIndex = 4
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMultiSelect1.AfterCollapse
        If Not SOLUTION Is Nothing AndAlso e.Node.ImageIndex = 4 Then
            e.Node.ImageIndex = 3
            If e.Node.IsSelected Then
                e.Node.SelectedImageIndex = 3
            Else
                e.Node.SelectedImageIndex = 3
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMultiSelect1.AfterSelect
        If e.Node.ImageIndex = 15 OrElse e.Node.ImageIndex = 18 OrElse e.Node.ImageIndex = 19 OrElse e.Node.ImageIndex = 17 OrElse e.Node.ImageIndex = 0 Then ' Si le noeud est "Paramètres du projet" ou bien un projet non chargé, alors on interdit l'édition du label
            Me.TreeViewMultiSelect1.LabelEdit = False
        Else
            Me.TreeViewMultiSelect1.LabelEdit = True
        End If
        If Me.TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
            If e.Node.ImageIndex = 3 OrElse e.Node.ImageIndex = 4 OrElse e.Node.ImageIndex = 1 OrElse e.Node.ImageIndex = 2 Then
                Me.Nouveau_Dossier_ToolStripButton.Enabled = True
                Me.Nouveau_Fichier_ToolStripButton.Enabled = True
            Else
                Me.Nouveau_Dossier_ToolStripButton.Enabled = False
                Me.Nouveau_Fichier_ToolStripButton.Enabled = False
            End If
        Else
            Me.Nouveau_Dossier_ToolStripButton.Enabled = False
            Me.Nouveau_Fichier_ToolStripButton.Enabled = False
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewMultiSelect1.NodeMouseDoubleClick
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 AndAlso Not SOLUTION Is Nothing AndAlso (Not e.Node.Tag = "ROOT") AndAlso (Not e.Node.ImageIndex = 1) AndAlso (Not e.Node.ImageIndex = 2) AndAlso (Not e.Node.ImageIndex = 17) Then ' Si l'élément sélectionné n'est pas le noeud de la solution, donc un dossier ou fichier ou projet
            Me.OuvrirToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_BeforeLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeViewMultiSelect1.BeforeLabelEdit

    End Sub

    Private Sub TreeViewMultiSelect1_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeViewMultiSelect1.AfterLabelEdit
        If Me.TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
            If Not e.Label = Nothing Then
                Dim nouvo_chemin As String = Nothing
                Dim ancien_chemin As String = Nothing
                If Not e.Label.Contains("/") OrElse Not e.Label.Contains("\") OrElse Not e.Label.Contains(":") OrElse Not e.Label.Contains("*") OrElse Not e.Label.Contains("?") OrElse Not e.Label.Contains(ChrW(34)) OrElse Not e.Label.Contains("<") OrElse Not e.Label.Contains(">") OrElse Not e.Label.Contains("|") Then

                    ancien_chemin = e.Node.ToolTipText
                    nouvo_chemin = My.Computer.FileSystem.GetParentPath(ancien_chemin) & "\" & e.Label

                    If e.Node.ImageIndex = 1 OrElse e.Node.ImageIndex = 2 Then
                        If e.Label.Contains(" ") Then GoTo _invalid_name
                        Dim ok As Boolean = True
                        For Each ite As TreeNode In Me.TreeViewMultiSelect1.Nodes(0).Nodes
                            If ite.Text = e.Label Then
                                ok = False
                                Exit For
                            End If
                        Next
                        If ok Then
                            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                If page.Controls.Count > 0 Then
                                    If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = e.Node.Tag Then
                                        DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = e.Label
                                    ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = e.Node.Tag Then
                                        DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = e.Label
                                    ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = e.Node.Tag Then
                                        page.UniqueName = "Paramètres du projet " & e.Label
                                        DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet_KryptonTextBox.Text = e.Label
                                        DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = e.Label
                                    ElseIf TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = e.Node.Tag Then
                                        page.UniqueName = "Statistiques du projet " & e.Label
                                        DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = e.Label
                                        page.Text = e.Label
                                    ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = e.Node.Tag Then
                                        DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = e.Label
                                    End If
                                End If
                            Next
                            If Not SOLUTION.GetProject(e.Node.Tag) Is Nothing Then
                                If IO.File.Exists(ancien_chemin & "\" & e.Node.Tag & ".szproj") Then
                                    My.Computer.FileSystem.RenameFile(ancien_chemin & "\" & e.Node.Tag & ".szproj", e.Label & ".szproj")
                                End If
                                e.Node.Name = e.Label
                                If Not SOLUTION.GenerationOrder.IndexOf(e.Node.Tag) = -1 Then SOLUTION.GenerationOrder(SOLUTION.GenerationOrder.IndexOf(e.Node.Tag)) = e.Label
                                If SOLUTION.ProjetDemarrage = e.Node.Tag Then SOLUTION.ProjetDemarrage = e.Label
                                SOLUTION.GetProject(e.Node.Tag).Nom_Fichier_Projet = e.Label & ".szproj"
                                SOLUTION.GetProject(e.Node.Tag).Nom = e.Label
                                e.Node.Tag = e.Label
                                For Each ite As TreeNode In e.Node.Nodes
                                    ite.Tag = e.Label
                                    If ite.Nodes.Count > 0 Then ite.Collapse()
                                Next

                                ' Recharger les statistiques
                                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                    If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = e.Node.Tag Then DirectCast(page.Controls(0), DocStatistiques).Charger(False)
                                Next
                                SOLUTION.GetProject(e.Label).ShouldCompileRelease = True
                            End If
                        Else
                            e.CancelEdit = True
                        End If
                    ElseIf e.Node.ImageIndex = 3 OrElse e.Node.ImageIndex = 4 Then
                        If IO.Directory.Exists(nouvo_chemin) = False AndAlso IO.File.Exists(nouvo_chemin) = False Then
                            If IO.Directory.Exists(ancien_chemin) Then
                                My.Computer.FileSystem.RenameDirectory(ancien_chemin, e.Label)
                                e.Node.ToolTipText = nouvo_chemin
                            End If
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content24"), e.Label)
                                .MainInstruction = RM.GetString("MainInstruction11")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            e.CancelEdit = True
                        End If
                    ElseIf IO.File.Exists(ancien_chemin) Then
                        If IO.Directory.Exists(nouvo_chemin) = False AndAlso IO.File.Exists(nouvo_chemin) = False Then
                            My.Computer.FileSystem.RenameFile(ancien_chemin, e.Label)
                            e.Node.ToolTipText = nouvo_chemin
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content25"), e.Label)
                                .MainInstruction = RM.GetString("MainInstruction11")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            e.CancelEdit = True
                        End If
                    Else
                        e.CancelEdit = True
                    End If

                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                        If page.Controls.Count > 0 Then
                            If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).NomCompletFichier = ancien_chemin Then
                                DirectCast(page.Controls(0), DocConcepteurFenetre).NomCompletFichier = nouvo_chemin
                                DirectCast(page.Controls(0), DocConcepteurFenetre).NomFichier = e.Label
                                If Not page.Text.EndsWith("*") Then
                                    page.Text = e.Label
                                Else
                                    page.Text = e.Label & "*"
                                End If
                            ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(page.Controls(0), DocEditeurFonctions).NomCompletFichier = ancien_chemin Then
                                DirectCast(page.Controls(0), DocEditeurFonctions).NomCompletFichier = nouvo_chemin
                                DirectCast(page.Controls(0), DocEditeurFonctions).NomFichier = e.Label
                                If Not page.Text.EndsWith("*") Then
                                    page.Text = e.Label
                                Else
                                    page.Text = e.Label & "*"
                                End If
                            ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(page.Controls(0), DocEditeurVisualBasic).NomCompletFichier = ancien_chemin Then
                                DirectCast(page.Controls(0), DocEditeurVisualBasic).NomCompletFichier = nouvo_chemin
                                DirectCast(page.Controls(0), DocEditeurVisualBasic).NomFichier = e.Label
                                If Not page.Text.EndsWith("*") Then
                                    page.Text = e.Label
                                Else
                                    page.Text = e.Label & "*"
                                End If
                            End If
                        End If
                    Next

                Else
_invalid_name:
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                        .Content = RM.GetString("Content26") & Environment.NewLine & "\ / : * ? " & ChrW(34) & " < > |"
                        .MainInstruction = RM.GetString("MainInstruction11")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    e.CancelEdit = True
                End If

                If Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 1 OrElse Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 2 AndAlso SOLUTION.GetProject(e.Label) Is Nothing Then
                    SOLUTION.GetProject(e.Label).ShouldCompileRelease = True
                End If
            Else
                e.CancelEdit = True
            End If
        End If
    End Sub

#End Region

#Region "Menu"

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        With Me

            If .TreeViewMultiSelect1.SelectedNodes.Count > 0 Then
                .OuvrirToolStripMenuItem.Enabled = True
                If .TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
                    .OuvrirAvecToolStripMenuItem.Enabled = True
                Else
                    .OuvrirAvecToolStripMenuItem.Enabled = False
                End If
                .CopierToolStripMenuItem.Enabled = True
                .NouveauDossierToolStripMenuItem.Enabled = True
                .NouveauDocumentToolStripMenuItem.Enabled = True
                .NouveauProjetToolStripMenuItem.Enabled = True
                .AjouterUnProjetExistantToolStripMenuItem.Enabled = True
                .AjouterUnDocumentExistantToolStripMenuItem.Enabled = True
                .Nouveau_Dossier_ToolStripButton.Enabled = True
                .Nouveau_Fichier_ToolStripButton.Enabled = True
                .CollerToolStripMenuItem.Enabled = True
                .RenommerToolStripMenuItem.Enabled = True
                .SupprimerToolStripMenuItem.Enabled = True
                .PropriétéToolStripMenuItem.Enabled = True
                .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = True
                .OrdreDeLaGénérationDeLaSolutionToolStripMenuItem.Enabled = True
                .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = True
                .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = True
                .AjouterUnÉlémentToolStripMenuItem.Enabled = True

                If .TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
                    If .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 15 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 18 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 19 Then ' Paramètre du projet
                        .OuvrirAvecToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .SupprimerToolStripMenuItem.Enabled = False
                        .RenommerToolStripMenuItem.Enabled = False
                        .CollerToolStripMenuItem.Enabled = False
                        .NouveauDossierToolStripMenuItem.Enabled = False
                        .NouveauDocumentToolStripMenuItem.Enabled = False
                        .NouveauProjetToolStripMenuItem.Enabled = False
                        .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                        .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                        .AjouterUnÉlémentToolStripMenuItem.Enabled = False
                    ElseIf .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 1 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 2 Then ' Projet
                        .OuvrirToolStripMenuItem.Enabled = False
                        .OuvrirAvecToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .NouveauProjetToolStripMenuItem.Enabled = False
                        .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                        If Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing AndAlso SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).RapportGeneration.ToString = Nothing Then .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                    ElseIf .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 17 Then ' Projet non chargé
                        .OuvrirToolStripMenuItem.Enabled = False
                        .OuvrirAvecToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .RenommerToolStripMenuItem.Enabled = False
                        .CollerToolStripMenuItem.Enabled = False
                        .NouveauDossierToolStripMenuItem.Enabled = False
                        .NouveauDocumentToolStripMenuItem.Enabled = False
                        .NouveauProjetToolStripMenuItem.Enabled = False
                        .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                        .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .AjouterUnÉlémentToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    ElseIf .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 0 Then ' Solution
                        .OuvrirToolStripMenuItem.Enabled = False
                        .OuvrirAvecToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .SupprimerToolStripMenuItem.Enabled = False
                        .CollerToolStripMenuItem.Enabled = False
                        .NouveauDossierToolStripMenuItem.Enabled = False
                        .NouveauDocumentToolStripMenuItem.Enabled = False
                        .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    ElseIf .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 3 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 4 Then ' Dossier
                        .OuvrirToolStripMenuItem.Enabled = False
                        .OuvrirAvecToolStripMenuItem.Enabled = False
                        .NouveauProjetToolStripMenuItem.Enabled = False
                        .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    Else ' Fichier
                        .NouveauDossierToolStripMenuItem.Enabled = False
                        .NouveauDocumentToolStripMenuItem.Enabled = False
                        .NouveauProjetToolStripMenuItem.Enabled = False
                        .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                        .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                        .AjouterUnÉlémentToolStripMenuItem.Enabled = False
                        .CollerToolStripMenuItem.Enabled = False
                    End If
                End If

                If Clipboard.GetFileDropList.Count = 0 Then .CollerToolStripMenuItem.Enabled = False

                If .TreeViewMultiSelect1.SelectedNodes.Count > 1 Then
                    Dim solution_ok, projet_ok, parametres_ok As Boolean
                    For Each ite As TreeNode In .TreeViewMultiSelect1.SelectedNodes
                        If ite.ImageIndex = 15 OrElse ite.ImageIndex = 18 Then parametres_ok = True
                        If ite.ImageIndex = 1 OrElse ite.ImageIndex = 2 OrElse ite.ImageIndex = 17 Then projet_ok = True
                        If ite.ImageIndex = 0 Then solution_ok = True
                    Next
                    If solution_ok Then
                        .OuvrirToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .SupprimerToolStripMenuItem.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    End If
                    If projet_ok Then
                        .OuvrirToolStripMenuItem.Enabled = False
                        .CopierToolStripMenuItem.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    End If
                    If parametres_ok Then
                        .CopierToolStripMenuItem.Enabled = False
                        .SupprimerToolStripMenuItem.Enabled = False
                        .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                        .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                        .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                    End If
                    .RenommerToolStripMenuItem.Enabled = False
                    .PropriétéToolStripMenuItem.Enabled = False
                    .AjouterUnÉlémentToolStripMenuItem.Enabled = False
                    .NouveauDossierToolStripMenuItem.Enabled = False
                    .NouveauDocumentToolStripMenuItem.Enabled = False
                    .NouveauProjetToolStripMenuItem.Enabled = False
                    .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                    .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                    .Nouveau_Dossier_ToolStripButton.Enabled = False
                    .Nouveau_Fichier_ToolStripButton.Enabled = False
                    .CollerToolStripMenuItem.Enabled = False
                End If
            Else
                .OuvrirToolStripMenuItem.Enabled = False
                .OuvrirAvecToolStripMenuItem.Enabled = False
                .CopierToolStripMenuItem.Enabled = False
                .SupprimerToolStripMenuItem.Enabled = False
                .RenommerToolStripMenuItem.Enabled = False
                .CollerToolStripMenuItem.Enabled = False
                .NouveauDossierToolStripMenuItem.Enabled = False
                .NouveauDocumentToolStripMenuItem.Enabled = False
                .NouveauProjetToolStripMenuItem.Enabled = False
                .AjouterUnProjetExistantToolStripMenuItem.Enabled = False
                .AjouterUnDocumentExistantToolStripMenuItem.Enabled = False
                .Nouveau_Dossier_ToolStripButton.Enabled = False
                .Nouveau_Fichier_ToolStripButton.Enabled = False
                .DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Enabled = False
                .OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
                .OuvrirDansLexplorateurWindowsToolStripMenuItem.Enabled = False
                .AjouterUnÉlémentToolStripMenuItem.Enabled = False
            End If

        End With
    End Sub

    Private Sub OuvrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirToolStripMenuItem.Click
        Dim ite As VelerSoftware.SZC.TreeViewMultiSelect.NodesCollection = Me.TreeViewMultiSelect1.SelectedNodes

        ' Ouverture du fichier
        Dim files() As String = New String(-1) {}
        Dim Safefiles() As String = New String(-1) {}
        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

        For Each it As TreeNode In ite
            Try
                Select Case it.ImageIndex
                    Case 15
                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = "PARAMETREDUPROJET"
                        Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
                        projects(projects.Length - 1) = SOLUTION.GetProject(it.Tag)
                    Case 18
                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = "STATISTIQUESDUPROJET"
                        Safefiles(Safefiles.Length - 1) = "STATISTIQUESDUPROJET"
                        projects(projects.Length - 1) = SOLUTION.GetProject(it.Tag)
                    Case 19
                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = "APPLICATIONEVENTS"
                        Safefiles(Safefiles.Length - 1) = "APPLICATIONEVENTS"
                        projects(projects.Length - 1) = SOLUTION.GetProject(it.Tag)
                End Select
                If (Not it.ImageIndex = 3) AndAlso (Not it.ImageIndex = 4) Then
                    ReDim Preserve files(files.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    files(files.Length - 1) = it.ToolTipText
                    Safefiles(Safefiles.Length - 1) = it.Text
                    projects(projects.Length - 1) = SOLUTION.GetProject(it.Tag)
                End If
            Catch
            End Try
        Next

        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
    End Sub


    Private Sub OuvrirAvecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirAvecToolStripMenuItem.Click
        If (Not SOLUTION Is Nothing) AndAlso (Me.TreeViewMultiSelect1.SelectedNodes.Count > 0) Then
            Process.Start("rundll32.exe", String.Format("shell32.dll,OpenAs_RunDLL {0}", Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText))
        End If
    End Sub

    Private Sub NouveauDossierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauDossierToolStripMenuItem.Click, Nouveau_Dossier_ToolStripButton.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 Then
            Dim i As Integer = 1
            While True
                If i = 1 AndAlso Not IO.Directory.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\New folder") Then
                    IO.Directory.CreateDirectory(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\New folder")
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add("factise")
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Collapse()
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
                    Exit While
                ElseIf Not IO.Directory.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\New folder (" & i & ")") Then
                    IO.Directory.CreateDirectory(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\New folder (" & i & ")")
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add("factise")
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Collapse()
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
                    Exit While
                End If
                i += 1
            End While
        End If
    End Sub

    Private Sub NouveauDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauDocumentToolStripMenuItem.Click, Nouveau_Fichier_ToolStripButton.Click
        Using frm As New NouveauDocument
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub AjouterUnDocumentExistantToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterUnDocumentExistantToolStripMenuItem.Click
        With Form1
            .OpenFileDialog1.Title = ""
            .OpenFileDialog1.Multiselect = True
            .OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_All_Filtre")
            .OpenFileDialog1.FileName = Nothing
            .OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            If .OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim list As New Specialized.StringCollection()
                For Each strrr As String In .OpenFileDialog1.FileNames
                    If My.Computer.FileSystem.FileExists(strrr) Then list.Add(strrr)
                Next
                Clipboard.SetFileDropList(list)
                CollerToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End With

    End Sub

    Private Sub NouveauProjetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauProjetToolStripMenuItem.Click
        Form1.Nouveau_Projet_KryptonRibbonGroupButton_Click(sender, e)
    End Sub

    Friend Sub AjouterUnProjetExistantToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterUnProjetExistantToolStripMenuItem.Click
        With Form1
            .OpenFileDialog1.Title = RM.GetString("OpenFileDialog1_Ajouter_Un_Projet")
            .OpenFileDialog1.Multiselect = False
            .OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_Ajouter_Un_Projet_Filtre")
            .OpenFileDialog1.FileName = Nothing
            If My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
                .OpenFileDialog1.InitialDirectory = My.Settings.Emplacement_Project_Par_Defaut
            Else
                .OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If

            If .OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK AndAlso _
                My.Computer.FileSystem.FileExists(.OpenFileDialog1.FileName) AndAlso _
                My.Computer.FileSystem.GetFileInfo(.OpenFileDialog1.FileName).Extension.ToUpper.EndsWith(".SZPROJ") AndAlso _
                Not SOLUTION Is Nothing Then ' Si une solution est déja ouverte

                Dim ok As Boolean = True
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    If proj IsNot Nothing AndAlso proj.Loaded AndAlso .OpenFileDialog1.FileName = proj.Emplacement & "\" & proj.Nom_Fichier_Projet Then
                        ok = False
                        Exit For
                    End If
                Next
                If ok Then ' Si le projet n'est pas déjà présent dans la solution
                    Dim proj As VelerSoftware.SZVB.Projet.Projet = ClassProjet.Ouvrir_Projet(.OpenFileDialog1.FileName)
                    If Not proj Is Nothing Then
                        SOLUTION.Projets.Add(proj)
                        SOLUTION.GenerationOrder.Insert(0, proj.Nom)
                        ClassProjet.Charger_Projet_Explorateur_Solutions(DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0), proj)
                    End If
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Me
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content1"), Form1.OpenFileDialog1.SafeFileName.Split(".")(0))
                        .MainInstruction = RM.GetString("MainInstruction1")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                End If
            End If

        End With
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 Then
            Dim str As New System.Collections.Specialized.StringCollection
            For Each ite As TreeNode In Me.TreeViewMultiSelect1.SelectedNodes
                If My.Computer.FileSystem.FileExists(ite.ToolTipText) OrElse My.Computer.FileSystem.DirectoryExists(ite.ToolTipText) Then str.Add(ite.ToolTipText)
            Next
            My.Computer.Clipboard.SetFileDropList(str)
        End If
    End Sub

    Private Sub CollerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollerToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 Then
            For i As Integer = 0 To Clipboard.GetFileDropList.Count - 1
                Dim Nom As String = My.Computer.FileSystem.GetName(Clipboard.GetFileDropList.Item(i))
                Dim tmp As String = Nothing
                Dim n As Integer = 0
                Dim ok As Boolean

                If My.Computer.FileSystem.DirectoryExists(Clipboard.GetFileDropList.Item(i)) AndAlso IO.Directory.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & Nom) Then
                    ok = True
                ElseIf My.Computer.FileSystem.FileExists(Clipboard.GetFileDropList.Item(i)) AndAlso IO.File.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & Nom) Then
                    ok = True
                End If

                If ok Then
                    While True
                        n += 1
                        tmp = "(Copy " & n & ") "
                        If My.Computer.FileSystem.DirectoryExists(Clipboard.GetFileDropList.Item(i)) AndAlso Not IO.Directory.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & tmp & Nom) Then
                            Exit While
                        ElseIf My.Computer.FileSystem.FileExists(Clipboard.GetFileDropList.Item(i)) AndAlso Not IO.File.Exists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & tmp & Nom) Then
                            Exit While
                        End If
                    End While

                    If My.Computer.FileSystem.FileExists(Clipboard.GetFileDropList.Item(i)) Then
                        My.Computer.FileSystem.CopyFile(Clipboard.GetFileDropList.Item(i), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & tmp & Nom)
                    ElseIf My.Computer.FileSystem.DirectoryExists(Clipboard.GetFileDropList.Item(i)) Then
                        My.Computer.FileSystem.CopyDirectory(Clipboard.GetFileDropList.Item(i), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & tmp & Nom)
                    End If
                Else
                    If My.Computer.FileSystem.FileExists(Clipboard.GetFileDropList.Item(i)) Then
                        My.Computer.FileSystem.CopyFile(Clipboard.GetFileDropList.Item(i), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & Nom)
                    ElseIf My.Computer.FileSystem.DirectoryExists(Clipboard.GetFileDropList.Item(i)) Then
                        My.Computer.FileSystem.CopyDirectory(Clipboard.GetFileDropList.Item(i), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & "\" & Nom)
                    End If
                End If
            Next

            ActualiserToolStripMenuItem_Click(Nothing, Nothing)
            If (Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing) AndAlso (SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Loaded) Then
                SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).ShouldCompileRelease = True
            End If

        End If
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 AndAlso VelerSoftware.SZVB.VistaDialog.VDialog.Show(RM.GetString("Content27"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            For Each a As TreeNode In Me.TreeViewMultiSelect1.SelectedNodes
                If (a.ImageIndex = 1 OrElse a.ImageIndex = 2 OrElse a.ImageIndex = 17) AndAlso (Not SOLUTION.GetProject(a.Tag) Is Nothing) Then
                    SOLUTION.Projets.Remove(SOLUTION.GetProject(a.Tag))
                    SOLUTION.GenerationOrder.Remove(a.Name)
                    Me.TreeViewMultiSelect1.Nodes(0).Nodes.RemoveByKey(a.Tag)
                    Me.TreeViewMultiSelect1.SelectedNodes.Clear()
                    Me.TreeViewMultiSelect1.SelectedNodes.Add(Me.TreeViewMultiSelect1.Nodes(0))
                    If a.Text = SOLUTION.ProjetDemarrage Then SOLUTION.ProjetDemarrage = Nothing

                    Me.TreeViewMultiSelect1.Nodes(0).Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
                Else
                    If IO.Directory.Exists(a.ToolTipText) Then My.Computer.FileSystem.DeleteDirectory(a.ToolTipText, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                    If IO.File.Exists(a.ToolTipText) Then My.Computer.FileSystem.DeleteFile(a.ToolTipText, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                    If (Not SOLUTION.GetProject(a.Tag) Is Nothing) AndAlso (SOLUTION.GetProject(a.Tag).Loaded) Then
                        SOLUTION.GetProject(a.Tag).ShouldCompileRelease = True
                    End If
                End If
            Next

            ActualiserToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub RenommerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenommerToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
            If Me.TreeViewMultiSelect1.SelectedNodes(0) Is Me.TreeViewMultiSelect1.Nodes(0) Then
                Dim old As String = Me.TreeViewMultiSelect1.SelectedNodes(0).Text.Replace(" -" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text.Split("-")(Me.TreeViewMultiSelect1.SelectedNodes(0).Text.Split("-").Length - 1), Nothing).Trim(" ")
                Dim str As String = Microsoft.VisualBasic.InputBox(RM.GetString("Solution_Node_Edit"), RM.GetString("Solution_Node_Edit"), old)
                If Not str.Trim(" ") = Nothing Then
                    SOLUTION.Nom = str.Trim(" ")
                    Me.TreeViewMultiSelect1.SelectedNodes(0).Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
                    Form1.Text = "[" & SOLUTION.Nom & "] " & My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName
                End If
            Else
                Me.TreeViewMultiSelect1.SelectedNodes(0).BeginEdit()
            End If
        End If
    End Sub

    Private Sub DéfinirCommeLeProjetDeDémarrageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DéfinirCommeLeProjetDeDémarrageToolStripMenuItem.Click
        If (Not SOLUTION Is Nothing) AndAlso (Me.TreeViewMultiSelect1.SelectedNodes.Count > 0) Then
            For Each it As TreeNode In Me.TreeViewMultiSelect1.Nodes(0).Nodes
                If it.Tag = Me.TreeViewMultiSelect1.SelectedNodes(0).Tag Then
                    it.NodeFont = New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)
                    SOLUTION.ProjetDemarrage = it.Tag
                Else
                    it.NodeFont = New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular)
                End If
            Next
            If Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).ShouldCompileRelease = True
                If SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                    Form1.Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                Else
                    Form1.Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub OrdreDeLaGénérationDeLaSolutionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdreDeLaGénérationDeLaSolutionToolStripMenuItem.Click
        Using frm As New OrdreGeneration
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Click
        If (Not SOLUTION Is Nothing) AndAlso (Me.TreeViewMultiSelect1.SelectedNodes.Count > 0) Then
            If Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                My.Computer.FileSystem.WriteAllText(SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Emplacement & "\Report.txt", SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).RapportGeneration.ToString, False)
                If My.Computer.FileSystem.FileExists(SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Emplacement & "\Report.txt") Then
                    System.Diagnostics.Process.Start(SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Emplacement & "\Report.txt")
                End If
                Me.ActualiserToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub OuvrirDansLexplorateurWindowsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OuvrirDansLexplorateurWindowsToolStripMenuItem.Click
        If (Not SOLUTION Is Nothing) AndAlso (Me.TreeViewMultiSelect1.SelectedNodes.Count > 0) Then
            If Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                System.Diagnostics.Process.Start("explorer.exe", SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Emplacement)
            End If
        End If
    End Sub

    Friend Sub ActualiserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualiserToolStripMenuItem.Click, Actualiser_ToolStripButton.Click
        If Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 Then
            If Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Count > 0 Then
                Me.TreeViewMultiSelect1.SelectedNodes(0).Collapse()
                Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
            ElseIf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent IsNot Nothing Then
                Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Collapse()
                Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
            End If
        End If
    End Sub

    Private Sub Reduire_Projet_ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reduire_Projet_ToolStripButton.Click
        Me.TreeViewMultiSelect1.CollapseAll()
        If Not SOLUTION Is Nothing Then Me.TreeViewMultiSelect1.Nodes(0).Expand()
    End Sub

    Private Sub PropriétéToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropriétéToolStripMenuItem.Click, Proprietes_ToolStripButton.Click
        If Not SOLUTION Is Nothing AndAlso Me.TreeViewMultiSelect1.SelectedNodes.Count > 0 Then

            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObjects = Nothing
            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Clear()
            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ItemSet.Clear()
            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ShowCustomProperties = True
            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()

            If Me.TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
                If Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 15 OrElse Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 18 OrElse Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 19 Then
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text & "}}"
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_3"), Me.TreeViewMultiSelect1.SelectedNodes(0).Text, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_2"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()
                ElseIf Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 0 Then
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & SOLUTION.Nom & " {\b(" & RM.GetString("Dock_Explorateur_Solution_Proprietes_12") & ")}}"
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_3"), SOLUTION.Nom, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_6"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_4"), SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_7"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_8"), SOLUTION.ProjetDemarrage, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_5"), RM.GetString("Dock_Explorateur_Solution_Proprietes_9"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_10"), SOLUTION.Projets.Count, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_5"), RM.GetString("Dock_Explorateur_Solution_Proprietes_11"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()
                ElseIf (Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 1 OrElse Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 2 OrElse Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 17) AndAlso Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & Me.TreeViewMultiSelect1.SelectedNodes(0).Tag & " {\b(" & RM.GetString("Dock_Explorateur_Solution_Proprietes_13") & ")}}"
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_3"), Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_14"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_4"), SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Emplacement & "\" & SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Nom_Fichier_Projet, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_15"), True)
                    If SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Loaded Then
                        If SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), RM.GetString("Dock_Explorateur_Solution_Proprietes_17"), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), True)
                        ElseIf SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), RM.GetString("Dock_Explorateur_Solution_Proprietes_18"), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), True)
                        Else
                            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), RM.GetString("Dock_Explorateur_Solution_Proprietes_19"), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_16"), True)
                        End If
                        DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_20"), SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag).GenerateDirectory, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_5"), RM.GetString("Dock_Explorateur_Solution_Proprietes_21"), True)
                    End If
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()
                ElseIf My.Computer.FileSystem.FileExists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) AndAlso Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & My.Computer.FileSystem.GetName(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) & " {\b(" & RM.GetString("Dock_Explorateur_Solution_Proprietes_22") & ")}}"
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_4"), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_23"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_3"), My.Computer.FileSystem.GetName(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_24"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_25"), My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\" & My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\" & My.Computer.FileSystem.GetFileInfo(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).Extension, "", "ExtensionNotFound"), "", RM.GetString("Dock_Explorateur_Solution_Proprietes_26") & " " & My.Computer.FileSystem.GetFileInfo(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).Extension.Trim(".")), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_28"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_29"), System.IO.File.GetCreationTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.File.GetCreationTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_32"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_30"), System.IO.File.GetLastWriteTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.File.GetLastWriteTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_33"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_31"), System.IO.File.GetLastAccessTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.File.GetLastAccessTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_34"), True)
                    If FileLen(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) > 1024 Then
                        DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_38"), Microsoft.VisualBasic.FormatNumber(FileLen(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) / 1024, 0, TriState.True, TriState.True, TriState.True) & " Ko", True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_39"), True)
                    Else
                        DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_38"), Format(FileLen(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText), "##0 Octets"), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_39"), True)
                    End If
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()
                ElseIf My.Computer.FileSystem.DirectoryExists(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) AndAlso Not SOLUTION.GetProject(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag) Is Nothing Then
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & My.Computer.FileSystem.GetName(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText) & " {\b(" & RM.GetString("Dock_Explorateur_Solution_Proprietes_40") & ")}}"
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_4"), Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_41"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_3"), My.Computer.FileSystem.GetName(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText), True, RM.GetString("Dock_Explorateur_Solution_Proprietes_1"), RM.GetString("Dock_Explorateur_Solution_Proprietes_42"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_29"), System.IO.Directory.GetCreationTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.Directory.GetCreationTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_35"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_30"), System.IO.Directory.GetLastWriteTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.Directory.GetLastWriteTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_36"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Item.Add(RM.GetString("Dock_Explorateur_Solution_Proprietes_31"), System.IO.Directory.GetLastAccessTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortDateString & " - " & System.IO.Directory.GetLastAccessTime(Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText).ToShortTimeString, True, RM.GetString("Dock_Explorateur_Solution_Proprietes_27"), RM.GetString("Dock_Explorateur_Solution_Proprietes_37"), True)
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.Refresh()
                End If
                If Not Form1.Box_Proprietes Is Nothing Then
                    If TypeOf Form1.Box_Proprietes.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                        DirectCast(Form1.Box_Proprietes.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Form1.Box_Proprietes
                    ElseIf TypeOf Form1.Box_Proprietes.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                        Form1.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Propriétés")
                    End If
                End If
            End If
        End If
    End Sub

#End Region

End Class
