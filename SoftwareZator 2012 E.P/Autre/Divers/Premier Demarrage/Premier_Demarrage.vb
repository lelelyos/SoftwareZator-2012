''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class PremierDemarrage

    Private Level As String
    Private Edition As String

    Private Sub Premier_Demarrage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Caption = My.Application.Info.Title
        Me.LabelTitle.Text = My.Application.Info.Title

        Me.KryptonTextBox1.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOwner", Nothing)
        Me.KryptonTextBox2.Text = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "RegisteredOrganization", Nothing)

        Me.WizardTabControl1.Multiline = True
        Me.GoToTab(Me.TabPage1)
        Me.DisableNextButton()

        Me.BringToFront()
        Me.Focus()
        Me.Activate()
    End Sub

    Private Sub CommandLink2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandLink2.Click
        System.Threading.Thread.CurrentThread.CurrentUICulture = FrenchCulture

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremierDemarrage))
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox2.TextBox, resources.GetString("KryptonTextBox2.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1.TextBox, resources.GetString("KryptonTextBox1.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink8, resources.GetString("CommandLink8.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink9, resources.GetString("CommandLink9.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink10, resources.GetString("CommandLink10.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink11, resources.GetString("CommandLink11.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink12, resources.GetString("CommandLink12.ToolTip"))
        resources.ApplyResources(Me.Label3, "Label3")
        resources.ApplyResources(Me.Label2, "Label2")
        resources.ApplyResources(Me.Label1, "Label1")
        resources.ApplyResources(Me.Label4, "Label4")
        resources.ApplyResources(Me.Label5, "Label5")
        resources.ApplyResources(Me.Label6, "Label6")
        resources.ApplyResources(Me.Label7, "Label7")
        resources.ApplyResources(Me.Label8, "Label8")
        resources.ApplyResources(Me.Label9, "Label9")
        resources.ApplyResources(Me.Label10, "Label10")
        resources.ApplyResources(Me.CommandLink3, "CommandLink3")
        resources.ApplyResources(Me.CommandLink4, "CommandLink4")
        resources.ApplyResources(Me.CommandLink5, "CommandLink5")
        resources.ApplyResources(Me.CommandLink6, "CommandLink6")
        resources.ApplyResources(Me.CommandLink7, "CommandLink7")
        resources.ApplyResources(Me.CommandLink8, "CommandLink8")
        resources.ApplyResources(Me.CommandLink9, "CommandLink9")
        resources.ApplyResources(Me.CommandLink10, "CommandLink10")
        resources.ApplyResources(Me.CommandLink11, "CommandLink11")
        resources.ApplyResources(Me.CommandLink12, "CommandLink12")
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        resources.ApplyResources(Me, "$this")
        Me.NextButtonText = "Suivant"
        Me.BackCaption = "Précédent"
        Me.CancelButtonText = "Annuler"
        Me.FinishButtonText = "Terminer"

        Me.TabPage4.BackgroundImage = My.Resources.Didac_fr_1
        Me.TabPage7.BackgroundImage = My.Resources.Didac_fr_2
        Me.TabPage8.BackgroundImage = My.Resources.Didac_fr_3
        Me.TabPage9.BackgroundImage = My.Resources.Didac_fr_4
        Me.TabPage10.BackgroundImage = My.Resources.Didac_fr_5
        Me.TabPage11.BackgroundImage = My.Resources.Didac_fr_6
        Me.TabPage12.BackgroundImage = My.Resources.Didac_fr_7
        Me.TabPage13.BackgroundImage = My.Resources.Didac_fr_8
        Me.TabPage14.BackgroundImage = My.Resources.Didac_fr_9
        Me.TabPage15.BackgroundImage = My.Resources.Didac_fr_10
        Me.TabPage16.BackgroundImage = My.Resources.Didac_fr_11
        Me.TabPage17.BackgroundImage = My.Resources.Didac_fr_12
        Me.TabPage18.BackgroundImage = My.Resources.Didac_fr_13
        Me.TabPage19.BackgroundImage = My.Resources.Didac_fr_14
        Me.TabPage20.BackgroundImage = My.Resources.Didac_fr_15
        Me.TabPage21.BackgroundImage = My.Resources.Didac_fr_16
        Me.TabPage22.BackgroundImage = My.Resources.Didac_fr_17
        Me.TabPage23.BackgroundImage = My.Resources.Didac_fr_18
        Me.TabPage24.BackgroundImage = My.Resources.Didac_fr_19
        Me.TabPage25.BackgroundImage = My.Resources.Didac_fr_23
        Me.TabPage26.BackgroundImage = My.Resources.Didac_fr_20
        Me.TabPage27.BackgroundImage = My.Resources.Didac_fr_21
        Me.TabPage28.BackgroundImage = My.Resources.Didac_fr_22
        Me.TabPage29.BackgroundImage = My.Resources.Didac_fr_24
        Me.TabPage30.BackgroundImage = My.Resources.Didac_fr_25
        Me.TabPage31.BackgroundImage = My.Resources.Didac_fr_26

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\fr\Licence.rtf") Then
            Me.RichTextBox1.LoadFile(Application.StartupPath & "\Help\fr\Licence.rtf", RichTextBoxStreamType.RichText)
        End If

        My.Settings.Langue = "fr"
        Me.GoToNextStep()
        Me.EnableNextButton()
        Me.CheckBox1_CheckedChanged(Nothing, Nothing)

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Loading languages...")))

        ' Initialisation des ressources
        RM = New System.Resources.ResourceManager("SoftwareZator.Custom", System.Reflection.Assembly.GetExecutingAssembly())
        RM_Log = New System.Resources.ResourceManager("SoftwareZator.Custom_Log", System.Reflection.Assembly.GetExecutingAssembly())
    End Sub

    Private Sub CommandLink1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandLink1.Click
        System.Threading.Thread.CurrentThread.CurrentUICulture = EnglishCulture

        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremierDemarrage))
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox2.TextBox, resources.GetString("KryptonTextBox2.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1.TextBox, resources.GetString("KryptonTextBox1.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink8, resources.GetString("CommandLink8.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink9, resources.GetString("CommandLink9.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink10, resources.GetString("CommandLink10.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink11, resources.GetString("CommandLink11.ToolTip"))
        Me.ToolTip1.SetToolTip(Me.CommandLink12, resources.GetString("CommandLink12.ToolTip"))
        resources.ApplyResources(Me.Label3, "Label3")
        resources.ApplyResources(Me.Label2, "Label2")
        resources.ApplyResources(Me.Label1, "Label1")
        resources.ApplyResources(Me.Label4, "Label4")
        resources.ApplyResources(Me.Label5, "Label5")
        resources.ApplyResources(Me.Label6, "Label6")
        resources.ApplyResources(Me.Label7, "Label7")
        resources.ApplyResources(Me.Label8, "Label8")
        resources.ApplyResources(Me.Label9, "Label9")
        resources.ApplyResources(Me.Label10, "Label10")
        resources.ApplyResources(Me.CommandLink3, "CommandLink3")
        resources.ApplyResources(Me.CommandLink4, "CommandLink4")
        resources.ApplyResources(Me.CommandLink5, "CommandLink5")
        resources.ApplyResources(Me.CommandLink6, "CommandLink6")
        resources.ApplyResources(Me.CommandLink7, "CommandLink7")
        resources.ApplyResources(Me.CommandLink8, "CommandLink8")
        resources.ApplyResources(Me.CommandLink9, "CommandLink9")
        resources.ApplyResources(Me.CommandLink10, "CommandLink10")
        resources.ApplyResources(Me.CommandLink11, "CommandLink11")
        resources.ApplyResources(Me.CommandLink12, "CommandLink12")
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        resources.ApplyResources(Me, "$this")
        Me.NextButtonText = "Next"
        Me.BackCaption = "Back"
        Me.CancelButtonText = "Cancel"
        Me.FinishButtonText = "Finish"

        Me.TabPage4.BackgroundImage = My.Resources.Didac_en_1
        Me.TabPage7.BackgroundImage = My.Resources.Didac_en_2
        Me.TabPage8.BackgroundImage = My.Resources.Didac_en_3
        Me.TabPage9.BackgroundImage = My.Resources.Didac_en_4
        Me.TabPage10.BackgroundImage = My.Resources.Didac_en_5
        Me.TabPage11.BackgroundImage = My.Resources.Didac_en_6
        Me.TabPage12.BackgroundImage = My.Resources.Didac_en_7
        Me.TabPage13.BackgroundImage = My.Resources.Didac_en_8
        Me.TabPage14.BackgroundImage = My.Resources.Didac_en_9
        Me.TabPage15.BackgroundImage = My.Resources.Didac_en_10
        Me.TabPage16.BackgroundImage = My.Resources.Didac_en_11
        Me.TabPage17.BackgroundImage = My.Resources.Didac_en_12
        Me.TabPage18.BackgroundImage = My.Resources.Didac_en_13
        Me.TabPage19.BackgroundImage = My.Resources.Didac_en_14
        Me.TabPage20.BackgroundImage = My.Resources.Didac_en_15
        Me.TabPage21.BackgroundImage = My.Resources.Didac_en_16
        Me.TabPage22.BackgroundImage = My.Resources.Didac_en_17
        Me.TabPage23.BackgroundImage = My.Resources.Didac_en_18
        Me.TabPage24.BackgroundImage = My.Resources.Didac_en_19
        Me.TabPage25.BackgroundImage = My.Resources.Didac_en_23
        Me.TabPage26.BackgroundImage = My.Resources.Didac_en_20
        Me.TabPage27.BackgroundImage = My.Resources.Didac_en_21
        Me.TabPage28.BackgroundImage = My.Resources.Didac_en_22
        Me.TabPage29.BackgroundImage = My.Resources.Didac_en_24
        Me.TabPage30.BackgroundImage = My.Resources.Didac_en_25
        Me.TabPage31.BackgroundImage = My.Resources.Didac_en_26

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\en\Licence.rtf") Then
            Me.RichTextBox1.LoadFile(Application.StartupPath & "\Help\en\Licence.rtf", RichTextBoxStreamType.RichText)
        End If

        My.Settings.Langue = "en"
        Me.GoToNextStep()
        Me.EnableNextButton()
        Me.CheckBox1_CheckedChanged(Nothing, Nothing)

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Loading languages...")))

        ' Initialisation des ressources
        RM = New System.Resources.ResourceManager("SoftwareZator.Custom", System.Reflection.Assembly.GetExecutingAssembly())
        RM_Log = New System.Resources.ResourceManager("SoftwareZator.Custom_Log", System.Reflection.Assembly.GetExecutingAssembly())
    End Sub

    Private Sub KryptonTextBox1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles KryptonTextBox1.Validating
        If Me.KryptonTextBox1.Text = Nothing Then
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PremierDemarrage))
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, resources.GetString("KryptonTextBox2.ToolTip"))
            Me.DisableNextButton()
        Else
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, "")
            Me.EnableNextButton()
        End If
    End Sub

    Private Sub CommandLink3_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink3.Click, CommandLink5.Click, CommandLink4.Click
        Level = sender.Tag
        Me.EnableNextButton()

        Select Case Level
            Case "Débutant"
                Me.GoToNextStep()

            Case "Novice"
                Me.GoToTab(Me.TabPage18)

            Case "Confirmé"
                Me.GoToTab(Me.TabPage6)
        End Select

    End Sub

    Private Sub PremierDemarrage_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            With My.Settings
                .Nom_Utilisateur = Me.KryptonTextBox1.Text
                .Société = Me.KryptonTextBox2.Text
                If My.Settings.Langue = "fr" Then
                    .Emplacement_Project_Par_Defaut = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Mes Projets SoftwareZator"
                Else
                    .Emplacement_Project_Par_Defaut = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\My Projects SoftwareZator"
                End If
                VelerSoftware.Plugins3.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture
                .Afficher_La_Griller = False
                .Aimentation_Intelligente = True
                .Ouvrir_Page_De_Démarrage = True
                .Smart_Tags = True
                .Verifier_Mise_A_Jours = True
                .Barre_Acces_Rapide_Dessous = False
                .Barre_Etat = True
                .Numerotation_Lignes = True
                .Colorisation_Syntaxe = True
                .Activer_Aero = True
                .Suivre_Souris_Regle = True
                .Projets_Recents = New System.Collections.Specialized.StringCollection()
                .QAT_Annuler = True
                .QAT_Coller = True
                .QAT_Copier = True
                .QAT_Couper = True
                .QAT_Enregistrer_Tout = True
                .QAT_Retablir = True
                .WindowTheme = 0
                .Autoriser_Donnees_Reconnaissances_Vocale = True
                .Autoriser_Envoyer_Informations = True
                .Autoriser_Erreur_Generation = True
                .Activer_Significations_Sonores = True
                .Afficher_Zoom_Bar = True
                .Correcteur_Orthographe = True
                .Ecran_Demarrage = True
                .Temps_Pause = True

                Select Case Edition
                    Case "Gratuite"
                        .Edition = ClassApplication.Edition.Free
                    Case "Standard"
                        .Edition = ClassApplication.Edition.Standard
                    Case "Education"
                        .Edition = ClassApplication.Edition.Education
                    Case "Professionnelle"
                        .Edition = ClassApplication.Edition.Professional
                End Select

                Select Case Level
                    Case "Débutant"
                        .QAT_Enregistrer_Sous = False
                        .QAT_Fermer = False
                        .QAT_Generer = False
                        .QAT_Ouvrir = False
                        .Minimiser_Ruban = False
                        .Réduire_Panneau_Lateral_FunctionEditor = False
                        .Réduire_Panneau_Lateral_WindowsDesigner = False

                    Case "Novice"
                        .QAT_Enregistrer_Sous = True
                        .QAT_Fermer = True
                        .QAT_Generer = False
                        .QAT_Ouvrir = True
                        .Minimiser_Ruban = False
                        .Réduire_Panneau_Lateral_FunctionEditor = False
                        .Réduire_Panneau_Lateral_WindowsDesigner = False

                    Case "Confirmé"
                        .QAT_Enregistrer_Sous = True
                        .QAT_Fermer = True
                        .QAT_Generer = True
                        .QAT_Ouvrir = True
                        .Minimiser_Ruban = True
                        .Réduire_Panneau_Lateral_FunctionEditor = True
                        .Réduire_Panneau_Lateral_WindowsDesigner = True

                End Select
            End With

            ClassApplication.Associer_Fichier_Au_Logiciel()
            RM.ReleaseAllResources()
            RM_Log.ReleaseAllResources()
            RM = Nothing
            RM_Log = Nothing

        End If
    End Sub

    Private Sub CommandLink7_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink7.Click
        Me.GoToNextStep()
    End Sub

    Private Sub CommandLink6_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink6.Click
        Using frm As New ReconnaissanceVocale
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.GoToNextStep()
            End If
        End Using
    End Sub

    Private Sub WizardTabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles WizardTabControl1.SelectedIndexChanged
        If Me.WizardTabControl1.SelectedTab.Text = "TabPage1" Then
            Me.DisableNextButton()
        ElseIf Me.WizardTabControl1.SelectedTab.Text = "TabPage32" Then
            Me.DisableNextButton()
            Me.CheckBox1_CheckedChanged(Nothing, Nothing)
        ElseIf Me.WizardTabControl1.SelectedTab.Text = "TabPage3" Then
            Me.DisableNextButton()
        ElseIf Me.WizardTabControl1.SelectedTab.Text = "TabPage6" Then
            Me.DisableNextButton()
            If VelerSoftware.SZVB.Windows.Core.RunningOnXP Then
                CommandLink6.Enabled = False
                Label6.Visible = True
            End If
        ElseIf Me.WizardTabControl1.SelectedTab.Text = "TabPage33" Then
            Me.DisableNextButton()
        Else
            Me.EnableNextButton()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            Me.EnableNextButton()
        Else
            Me.DisableNextButton()
        End If
    End Sub

    Private Sub CommandLink8_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink8.Click, CommandLink9.Click, CommandLink11.Click, CommandLink10.Click
        Edition = sender.Tag
        Me.GoToNextStep()
    End Sub

    Private Sub CommandLink12_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink12.Click
         System.Diagnostics.Process.Start("http://softwarezator.velersoftware.com/#editions")
    End Sub
End Class
