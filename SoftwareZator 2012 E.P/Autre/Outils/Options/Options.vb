''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Options

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.TreeView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.TreeView1.Handle, 4352 + 44, 64, 64)
            VelerSoftware.SZC.Windows.User32.SendMessage(.TreeView1.Handle, 4352 + 44, 32, 32)

            .TreeView1.SelectedNode = .TreeView1.Nodes("General").Nodes("General")
            .TreeView1.ExpandAll()

            My.Settings.Minimiser_Ruban = Form1.KryptonRibbon1.MinimizedMode
            If Form1.KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Below Then
                My.Settings.Barre_Acces_Rapide_Dessous = True
            Else
                My.Settings.Barre_Acces_Rapide_Dessous = False
            End If

            .Nom_Utilisateur_TextBox.Text = My.Settings.Nom_Utilisateur
            .Nom_Societe_TextBox.Text = My.Settings.Société
            .Emplacement_Projet_TextBox.Text = My.Settings.Emplacement_Project_Par_Defaut
            .Panneaux_Lateral_WindowsDesigner_CheckBox.Checked = My.Settings.Réduire_Panneau_Lateral_WindowsDesigner
            .Panneau_Lateral_FunctionEditor_CheckBox.Checked = My.Settings.Réduire_Panneau_Lateral_FunctionEditor
            .Start_Page_CheckBox.Checked = My.Settings.Ouvrir_Page_De_Démarrage
            .Updates_CheckBox.Checked = My.Settings.Verifier_Mise_A_Jours
            .SmartTags_CheckBox.Checked = My.Settings.Smart_Tags
            .Barre_Acces_Rapide_En_Dessous_CheckBox.Checked = My.Settings.Barre_Acces_Rapide_Dessous
            .Barre_Etat_CheckBox.Checked = My.Settings.Barre_Etat
            .Minimiser_Ruban_CheckBox.Checked = My.Settings.Minimiser_Ruban
            .Activate_Voice_Recognition_CheckBox.Checked = My.Settings.Activer_Reconnaissance_Vocale
            .Sounds_Voice_Recognition_CheckBox.Checked = My.Settings.Activer_Significations_Sonores
            .Numerotation_Lignes_CheckBox.Checked = My.Settings.Numerotation_Lignes
            .Colorisation_Syntaxe_CheckBox.Checked = My.Settings.Colorisation_Syntaxe
            .Activer_Aero_CheckBox.Checked = My.Settings.Activer_Aero
            .Suivre_Souris_Regle_CheckBox.Checked = My.Settings.Suivre_Souris_Regle
            .ComboBox1.SelectedIndex = My.Settings.WindowTheme
            .Envoyer_Confidentiality_CheckBox.Checked = My.Settings.Autoriser_Envoyer_Informations
            .Vocale_Confidentiality_CheckBox.Checked = My.Settings.Autoriser_Donnees_Reconnaissances_Vocale
            .Erreurs_Generations_Confidentiality_CheckBox.Checked = My.Settings.Autoriser_Erreur_Generation
            .Zoom_Bar_CheckBox.Checked = My.Settings.Afficher_Zoom_Bar
            .Correcteur_Orthographique_CheckBox.Checked = My.Settings.Correcteur_Orthographe
            .Splash_Screen_CheckBox.Checked = My.Settings.Ecran_Demarrage
            .Pause_CheckBox1.Checked = My.Settings.Temps_Pause
            Select Case My.Settings.Edition
                Case ClassApplication.Edition.Free
                    .RadioButton1.Checked = True
                Case ClassApplication.Edition.Standard
                    .RadioButton2.Checked = True
                Case ClassApplication.Edition.Education
                    .RadioButton3.Checked = True
                Case ClassApplication.Edition.Professional
                    .RadioButton4.Checked = True
            End Select
            If My.Settings.Langue = "fr" Then
                .Langue_ComboBox.SelectedIndex = 1
            Else
                .Langue_ComboBox.SelectedIndex = 0
            End If
            If My.Settings.Afficher_La_Griller Then
                .Afficher_Grille_RadioButton.Checked = True
            Else
                .Aimentation_Intelligente_RadioButton.Checked = True
            End If

            If VelerSoftware.SZVB.Windows.Core.RunningOnXP Then
                .Activate_Voice_Recognition_CheckBox.Enabled = False
                .Configure_Voice_Recognition_Button.Enabled = False
                .Sounds_Voice_Recognition_CheckBox.Enabled = False
                .Label6.Visible = True
            Else
                .Label6.Visible = False
            End If

            .GroupBox1.Enabled = .Envoyer_Confidentiality_CheckBox.Checked
            .Sounds_Voice_Recognition_CheckBox.Enabled = .Activate_Voice_Recognition_CheckBox.Checked

            If SZ_Est_Activé Then
                .RadioButton1.Enabled = False
                .RadioButton2.Enabled = False
                .RadioButton3.Enabled = False
                .RadioButton4.Enabled = False
            End If

        End With
    End Sub

    Private Sub Options_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            Dim resultat As VelerSoftware.SZVB.VistaDialog.VDialogResult = VelerSoftware.SZVB.VistaDialog.VDialogResult.Continue
            Dim old_edition As ClassApplication.Edition = My.Settings.Edition
            If .RadioButton1.Checked Then
                My.Settings.Edition = ClassApplication.Edition.Free
            ElseIf .RadioButton2.Checked Then
                My.Settings.Edition = ClassApplication.Edition.Standard
            ElseIf .RadioButton3.Checked Then
                My.Settings.Edition = ClassApplication.Edition.Education
            ElseIf .RadioButton4.Checked Then
                My.Settings.Edition = ClassApplication.Edition.Professional
            End If

            If Not old_edition = My.Settings.Edition Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Cancel)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                    .Content = RM.GetString("Content50")
                    .MainInstruction = RM.GetString("MainInstruction14")
                    .WindowTitle = My.Application.Info.Title
                    resultat = .Show()
                End With
            End If

            If resultat = VelerSoftware.SZVB.VistaDialog.VDialogResult.Cancel Then
                My.Settings.Edition = old_edition
                Select Case old_edition
                    Case ClassApplication.Edition.Free
                        .RadioButton1.Checked = True
                    Case ClassApplication.Edition.Standard
                        .RadioButton2.Checked = True
                    Case ClassApplication.Edition.Education
                        .RadioButton3.Checked = True
                    Case ClassApplication.Edition.Professional
                        .RadioButton4.Checked = True
                End Select
                Exit Sub
            End If

            My.Settings.Afficher_La_Griller = .Afficher_Grille_RadioButton.Checked
            My.Settings.Aimentation_Intelligente = .Aimentation_Intelligente_RadioButton.Checked
            My.Settings.Emplacement_Project_Par_Defaut = .Emplacement_Projet_TextBox.Text
            My.Settings.Ouvrir_Page_De_Démarrage = .Start_Page_CheckBox.Checked
            My.Settings.Réduire_Panneau_Lateral_FunctionEditor = .Panneau_Lateral_FunctionEditor_CheckBox.Checked
            My.Settings.Réduire_Panneau_Lateral_WindowsDesigner = .Panneaux_Lateral_WindowsDesigner_CheckBox.Checked
            My.Settings.Smart_Tags = .SmartTags_CheckBox.Checked
            My.Settings.Verifier_Mise_A_Jours = Updates_CheckBox.Checked
            My.Settings.Barre_Acces_Rapide_Dessous = .Barre_Acces_Rapide_En_Dessous_CheckBox.Checked
            My.Settings.Barre_Etat = .Barre_Etat_CheckBox.Checked
            My.Settings.Minimiser_Ruban = .Minimiser_Ruban_CheckBox.Checked
            My.Settings.Activer_Reconnaissance_Vocale = .Activate_Voice_Recognition_CheckBox.Checked
            My.Settings.Activer_Significations_Sonores = .Sounds_Voice_Recognition_CheckBox.Checked
            My.Settings.Numerotation_Lignes = .Numerotation_Lignes_CheckBox.Checked
            My.Settings.Colorisation_Syntaxe = .Colorisation_Syntaxe_CheckBox.Checked
            My.Settings.Activer_Aero = .Activer_Aero_CheckBox.Checked
            My.Settings.Suivre_Souris_Regle = .Suivre_Souris_Regle_CheckBox.Checked
            My.Settings.WindowTheme = .ComboBox1.SelectedIndex
            My.Settings.Autoriser_Envoyer_Informations = .Envoyer_Confidentiality_CheckBox.Checked
            My.Settings.Autoriser_Erreur_Generation = .Erreurs_Generations_Confidentiality_CheckBox.Checked
            My.Settings.Autoriser_Donnees_Reconnaissances_Vocale = .Vocale_Confidentiality_CheckBox.Checked
            My.Settings.Afficher_Zoom_Bar = .Zoom_Bar_CheckBox.Checked
            My.Settings.Correcteur_Orthographe = .Correcteur_Orthographique_CheckBox.Checked
            My.Settings.Ecran_Demarrage = .Splash_Screen_CheckBox.Checked
            My.Settings.Temps_Pause = .Pause_CheckBox1.Checked

            If .Langue_ComboBox.SelectedIndex = 1 Then
                My.Settings.Langue = "fr"
            Else
                My.Settings.Langue = "en"
            End If

            My.Settings.Save()



            ' APPLIQUER LES OTPIONS


            Form1.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked = My.Settings.Activer_Reconnaissance_Vocale

            If resultat = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK Then
                ClassProjet.Fermer_Solution(True)
                Application.Restart()
            End If

            Select Case My.Settings.WindowTheme
                Case 0
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                    Form1.StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(Form1.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                Case 1
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                    Form1.StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(Form1.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                Case 2
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                    Form1.StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(Form1.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
            End Select
            Form1.StatusStrip1.Visible = My.Settings.Barre_Etat
            Form1.KryptonRibbon1.MinimizedMode = My.Settings.Minimiser_Ruban
            Form1.KryptonRibbon1.AllowFormIntegrate = My.Settings.Activer_Aero
            If My.Settings.Temps_Pause Then
                Form1.GenerationComponent1.Timer1.Interval = 3000
            Else
                Form1.GenerationComponent1.Timer1.Interval = 1000
            End If
            If My.Settings.Barre_Acces_Rapide_Dessous Then
                Form1.KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Below
            Else
                Form1.KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Above
            End If
            VelerSoftware.SZC35.Variables.SpellCheck = My.Settings.Correcteur_Orthographe

            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocParametresDuProjet Then

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques Then

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocEditeurVisualBasic Then
                    With DirectCast(page.Controls(0), DocEditeurVisualBasic)
                        .CodeEditor.ShowLineNumbers = My.Settings.Numerotation_Lignes
                        If My.Settings.Colorisation_Syntaxe Then
                            .CodeEditor.SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("VBNET")
                        Else
                            .CodeEditor.SyntaxHighlighting = Nothing
                        End If
                    End With

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocPageDeDemarrage Then

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocEditeurTable Then

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocEditeurFonctions Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(page.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                        If TAB.Controls.Count > 0 AndAlso Not DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
                            If My.Settings.Afficher_Zoom_Bar Then
                                DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.Zoom + System.Activities.Presentation.View.ShellBarItemVisibility.MiniMap
                            Else
                                DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.None
                            End If
                        End If
                    Next

                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocConcepteurFenetre Then
                    With DirectCast(page.Controls(0), DocConcepteurFenetre)
                        .RulerControl1.MouseTrackingOn = My.Settings.Suivre_Souris_Regle
                        .RulerControl2.MouseTrackingOn = My.Settings.Suivre_Souris_Regle
                        .Designer.designerOptionService.CompatibilityOptions.ShowGrid = My.Settings.Afficher_La_Griller
                        .Designer.designerOptionService.CompatibilityOptions.SnapToGrid = My.Settings.Afficher_La_Griller
                        .Designer.designerOptionService.CompatibilityOptions.UseSmartTags = My.Settings.Smart_Tags
                        .Designer.designerOptionService.CompatibilityOptions.UseSnapLines = My.Settings.Aimentation_Intelligente
                        .Designer._ServiceContainer.RemoveService(GetType(System.ComponentModel.Design.DesignerOptionService))
                        .Designer._ServiceContainer.AddService(GetType(System.ComponentModel.Design.DesignerOptionService), .Designer.designerOptionService)
                        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In .KryptonNavigator2.Pages
                            If TAB.Controls.Count > 0 AndAlso Not DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
                                If My.Settings.Afficher_Zoom_Bar Then
                                    DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.Zoom + System.Activities.Presentation.View.ShellBarItemVisibility.MiniMap
                                Else
                                    DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.None
                                End If
                            End If
                        Next
                    End With

                End If
            Next

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub Options_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not Me.TreeView1.SelectedNode Is Nothing Then
            Me.WizardTabControl1.SelectedTab = Me.WizardTabControl1.TabPages(Me.TreeView1.SelectedNode.Name)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_Utilisateur_TextBox.TextChanged
        If Me.Nom_Utilisateur_TextBox.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.Nom_Utilisateur_TextBox, Me.ToolTip1.GetToolTip(Me.Nom_Utilisateur_TextBox))
            Me.DisableOKButton()
        Else
            Me.EnableOKButton()
        End If
    End Sub

    Private Sub Nom_Societe_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_Societe_TextBox.TextChanged
        If Me.Nom_Societe_TextBox.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.Nom_Societe_TextBox, Me.ToolTip1.GetToolTip(Me.Nom_Societe_TextBox))
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        With Me
            .Nom_Utilisateur_TextBox.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", Nothing)
            .Nom_Societe_TextBox.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", Nothing)
            If .Langue_ComboBox.SelectedIndex = 1 Then
                .Emplacement_Projet_TextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Mes Projets SoftwareZator"
            Else
                .Emplacement_Projet_TextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\My Projects SoftwareZator"
            End If
            .Panneaux_Lateral_WindowsDesigner_CheckBox.Checked = False
            .Panneau_Lateral_FunctionEditor_CheckBox.Checked = False
            .Start_Page_CheckBox.Checked = True
            .Updates_CheckBox.Checked = True
            .SmartTags_CheckBox.Checked = True
            .Aimentation_Intelligente_RadioButton.Checked = True
            .Minimiser_Ruban_CheckBox.Checked = False
            .Barre_Acces_Rapide_En_Dessous_CheckBox.Checked = False
            .Barre_Etat_CheckBox.Checked = True
            .Activate_Voice_Recognition_CheckBox.Checked = True
            .Sounds_Voice_Recognition_CheckBox.Checked = True
            .Numerotation_Lignes_CheckBox.Checked = True
            .Colorisation_Syntaxe_CheckBox.Checked = True
            .Activer_Aero_CheckBox.Checked = True
            .Suivre_Souris_Regle_CheckBox.Checked = True
            .ComboBox1.SelectedIndex = 0
            .Envoyer_Confidentiality_CheckBox.Checked = True
            .Erreurs_Generations_Confidentiality_CheckBox.Checked = True
            .Vocale_Confidentiality_CheckBox.Checked = True
            .Zoom_Bar_CheckBox.Checked =
            .Correcteur_Orthographique_CheckBox.Checked = True
            .Splash_Screen_CheckBox.Checked = True
            .Pause_CheckBox1.Checked = True
        End With
    End Sub

    Private Sub Fichiers_Extension_Button_Click(sender As System.Object, e As System.EventArgs) Handles Fichiers_Extension_Button.Click
        ClassApplication.Associer_Fichier_Au_Logiciel()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        System.Diagnostics.Process.Start("http://softwarezator.velersoftware.com/#editions")
    End Sub

    Private Sub Activate_Voice_Recognition_CheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Activate_Voice_Recognition_CheckBox.CheckedChanged
        If My.Settings.Edition = ClassApplication.Edition.Free Then
            If Me.Activate_Voice_Recognition_CheckBox.Checked = False Then Exit Sub
            ClassApplication.Should_Standard_Edition()
            Me.Activate_Voice_Recognition_CheckBox.Checked = False
        End If

        Me.Sounds_Voice_Recognition_CheckBox.Enabled = Me.Activate_Voice_Recognition_CheckBox.Checked
    End Sub

    Private Sub Envoyer_Confidentiality_CheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Envoyer_Confidentiality_CheckBox.CheckedChanged
        Me.GroupBox1.Enabled = Me.Envoyer_Confidentiality_CheckBox.Checked
    End Sub

    Private Sub Configure_Voice_Recognition_Button_Click(sender As System.Object, e As System.EventArgs) Handles Configure_Voice_Recognition_Button.Click
        Using frm As New ReconnaissanceVocale
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
            frm.Dispose()
        End Using
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Using frm As New Licence
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub Form_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        e.Cancel = True
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\introduction.html") Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help.exe") Then
                System.Diagnostics.Process.Start(Application.StartupPath & "\Help.exe", ChrW(34) & Application.StartupPath & "\Help\" & My.Settings.Langue & "\introduction.html" & ChrW(34))
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Help.exe", My.Application.Info.Title)
                    .MainInstruction = RM.GetString("MainInstruction10")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content18"), My.Application.Info.Title)
                .MainInstruction = RM.GetString("MainInstruction10")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
        End If
    End Sub

End Class
