''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocParametresDuProjet

#Region "Propriétés"

#Region "Nom du projet"

    Private _Nom_Projet As String = Nothing

    Public Property Nom_Projet() As String
        Get
            Return _Nom_Projet
        End Get
        Set(ByVal value As String)
            _Nom_Projet = value
        End Set
    End Property

#End Region ' Nom du projet

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Parametre_Projet

    Public ReadOnly Property TypeFichier() As VelerSoftware.SZVB.Projet.Document.Types
        Get
            Return _TypeFichier
        End Get
    End Property

#End Region ' Type du document

#Region "Annuler"

    Private _Annuler As Boolean = False

    Public Property Annuler() As Boolean
        Get
            Return _Annuler
        End Get
        Set(ByVal value As Boolean)
            _Annuler = value
        End Set
    End Property

#End Region ' Détermine si l'on peu annuler ou pas

#Region "Rétablir"

    Private _Retablir As Boolean = False

    Public Property Retablir() As Boolean
        Get
            Return _Retablir
        End Get
        Set(ByVal value As Boolean)
            _Retablir = value
        End Set
    End Property

#End Region ' Détermine si l'on peu rétablir ou pas

#Region "Finit de se chargé"

    Private _FinishLoad As Boolean = False

    Public Property FinishLoad() As Boolean
        Get
            Return _FinishLoad
        End Get
        Set(ByVal value As Boolean)
            _FinishLoad = value
        End Set
    End Property

#End Region ' Détermine si l'éditeur a finit d'être chargé ou modifié

#Region "Modifié"

    Private _Modifier As Boolean = False

    Public Property Modifier() As Boolean
        Get
            Return _Modifier
        End Get
        Set(ByVal value As Boolean)
            _Modifier = value
        End Set
    End Property

#End Region ' Détermine si l'éditeur a été modifié ou pas

#End Region

    Public Sub DocumentModifier()
        If FinishLoad And Annuler And Retablir Then
            Modifier = True
            If (Not Me.Nom_Projet = "") AndAlso (Not SOLUTION.GetProject(Nom_Projet) Is Nothing) Then
                SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
            End If
        Else
        End If
        If Modifier Then
            If Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Nom_Projet & "*"
            End If
        End If
    End Sub

    Public Function Charger() As Boolean
        Dim ref_ok As Boolean = True
        Dim RESULTAT As Boolean = True

        With Me

            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
            If Not proj Is Nothing Then

                Dim ite As ListViewItem

                ' nom de projet
                .Nom_Projet_KryptonTextBox.Text = proj.Nom

                ' type de projet
                If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                    .Type_Projet_KryptonComboBox.SelectedIndex = 1
                ElseIf proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                    .Type_Projet_KryptonComboBox.SelectedIndex = 0
                ElseIf proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                    .Type_Projet_KryptonComboBox.SelectedIndex = 2
                End If

                ' Unité central cible
                If proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.x86 Then
                    .Unite_Central_Cible_KryptonComboBox.SelectedIndex = 0
                ElseIf proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.x64 Then
                    .Unite_Central_Cible_KryptonComboBox.SelectedIndex = 1
                ElseIf proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu Then
                    .Unite_Central_Cible_KryptonComboBox.SelectedIndex = 2
                End If

                ' Niveau d'obfuscation
                If proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Low Then
                    .Obfuscation_KryptonComboBox.SelectedIndex = 0
                ElseIf proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal Then
                    .Obfuscation_KryptonComboBox.SelectedIndex = 1
                ElseIf proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.High Then
                    .Obfuscation_KryptonComboBox.SelectedIndex = 2
                End If

                ' Formulaire de démarrage  
                .Formulaire_Demarrage_KryptonComboBox.Items.Clear()
                .Formulaire_Demarrage_KryptonComboBox.Text = Nothing
                .Ecran_Demarrage_KryptonComboBox.Items.Clear()
                .Ecran_Demarrage_KryptonComboBox.Text = Nothing
                .Ecran_Demarrage_KryptonComboBox.Items.Add("")
                For Each a As String In My.Computer.FileSystem.GetFiles(proj.Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                    If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                        If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                            .Formulaire_Demarrage_KryptonComboBox.Items.Add(ClassFichier.Ouvrir_Fichier(proj.Emplacement, a))
                            If proj.FormStart = ClassFichier.Ouvrir_Fichier(proj.Emplacement, a) Then .Formulaire_Demarrage_KryptonComboBox.SelectedIndex = .Formulaire_Demarrage_KryptonComboBox.Items.Count - 1
                        End If
                        .Ecran_Demarrage_KryptonComboBox.Items.Add(ClassFichier.Ouvrir_Fichier(proj.Emplacement, a))
                        If proj.SplashScreen = ClassFichier.Ouvrir_Fichier(proj.Emplacement, a) Then .Ecran_Demarrage_KryptonComboBox.SelectedIndex = .Ecran_Demarrage_KryptonComboBox.Items.Count - 1
                    ElseIf My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szc" Then
                        If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                            If Not a = proj.Emplacement & "\ApplicationEvents.szc" Then
                                .Formulaire_Demarrage_KryptonComboBox.Items.Add(ClassFichier.Ouvrir_Fichier(proj.Emplacement, a))
                                If proj.FormStart = ClassFichier.Ouvrir_Fichier(proj.Emplacement, a) Then .Formulaire_Demarrage_KryptonComboBox.SelectedIndex = .Formulaire_Demarrage_KryptonComboBox.Items.Count - 1
                            End If
                        End If
                    End If
                Next

                ' Style visuel
                .Style_Visuel_KryptonCheckBox.Checked = proj.StyleXP

                ' Instance unique
                .Instance_Unique_KryptonCheckBox.Checked = proj.Instance

                ' Enregistrer paramètres
                .MySettings_KryptonCheckBox.Checked = proj.MySettings

                ' Mode d'arrêt
                If proj.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses Then
                    .Mode_Arret_KryptonComboBox.SelectedIndex = 0
                ElseIf proj.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose Then
                    .Mode_Arret_KryptonComboBox.SelectedIndex = 1
                End If

                ' Icone du projet
                If My.Computer.FileSystem.FileExists(proj.Emplacement & "\icon.ico") Then
                    .Changer_Icone_KryptonButton.Tag = "icon.ico"
                    Dim fs As IO.FileStream = New IO.FileStream(proj.Emplacement & "\icon.ico", IO.FileMode.Open)
                    .PictureBox1.Image = VelerSoftware.SZVB.Windows.Core.GetBitmapFromIcon(New Icon(fs))
                    fs.Close()
                    fs.Dispose()
                End If

                .Titre_KryptonTextBox.Text = proj.Assembly_Title
                .Description_KryptonTextBox.Text = proj.Assembly_Description
                .Societe_KryptonTextBox.Text = proj.Assembly_Socity
                .Produit_KryptonTextBox.Text = proj.Assembly_Product
                .Copyright_KryptonTextBox.Text = proj.Assembly_Copyright
                .Marque_KryptonTextBox.Text = proj.Assembly_Mark
                .Guid_KryptonTextBox.Text = proj.Assembly_Guid
                .VF1_1_KryptonNumericUpDown.Value = proj.Assembly_FileVersion.Split(".")(0)
                .VF1_2_KryptonNumericUpDown.Value = proj.Assembly_FileVersion.Split(".")(1)
                .VF1_3_KryptonNumericUpDown.Value = proj.Assembly_FileVersion.Split(".")(2)
                .VF1_4_KryptonNumericUpDown.Value = proj.Assembly_FileVersion.Split(".")(3)
                .VF2_1_KryptonNumericUpDown.Value = proj.Assembly_AssemblyVersion.Split(".")(0)
                .VF2_2_KryptonNumericUpDown.Value = proj.Assembly_AssemblyVersion.Split(".")(1)
                .VF2_3_KryptonNumericUpDown.Value = proj.Assembly_AssemblyVersion.Split(".")(2)
                .VF2_4_KryptonNumericUpDown.Value = proj.Assembly_AssemblyVersion.Split(".")(3)
                .Generation_KryptonTextBox.Text = proj.GenerateDirectory
                .Optimiser_KryptonCheckBox.Checked = proj.Optimize

                ' Références
                .ListView1.Items.Clear()
                For Each a As VelerSoftware.SZVB.Projet.Reference In proj.References
                    If Not a Is Nothing Then
                        ite = New ListViewItem
                        With ite
                            .Text = a.Name
                            .SubItems.Add(a.Version)
                            .SubItems.Add(a.Copy.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                            .SubItems.Add(a.FullName)
                            .ToolTipText = a.Location
                            .Tag = a.IsProject
                            If (Not a.IsProject) AndAlso (a.Assembly Is Nothing) Then .ImageKey = "Warning"
                        End With
                        .ListView1.Items.Add(ite)
                    End If
                Next

                ' Paramètres
                .ListView2.Items.Clear()
                For Each a As String In proj.Parametres
                    If Not a = Nothing Then
                        ite = New ListViewItem
                        ite.Text = a
                        ite.Name = a
                        .ListView2.Items.Add(ite)
                    End If
                Next

                ' Fichiers VB.Net
                .ListView4.Items.Clear()
                For Each a As String In proj.Fichiers_VBNet
                    If Not a = Nothing Then
                        ite = New ListViewItem
                        ite.Text = a
                        ite.Name = a
                        .ListView4.Items.Add(ite)
                    End If
                Next

                ' Ressources
                .ListView3.Items.Clear()
                For Each a As VelerSoftware.SZVB.Projet.Ressource In proj.Ressources
                    If Not a Is Nothing Then
                        ite = New ListViewItem
                        ite.Text = a.Name
                        ite.Name = a.Name
                        ite.Tag = a.Value
                        If a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Texte Then
                            ite.ImageKey = "TXT"
                        ElseIf a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Image Then
                            ite.ImageKey = "IMG"
                        ElseIf a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Fichier Then
                            ite.ImageKey = "FILE"
                        End If
                        .ListView3.Items.Add(ite)
                    End If
                Next



                ' Cherche les problèmes dans le projet
                ClassProjet.Valider_Projet(proj, True)

            Else
                RESULTAT = False
            End If

        End With

        Return RESULTAT
    End Function

    Public Sub Enregistrer()
        Dim Old_Name As String = Me.Nom_Projet

        With Me

            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
            If Not proj Is Nothing Then
                For Each pro As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    If Not pro.Emplacement = proj.Emplacement AndAlso pro.Nom = Me.Nom_Projet_KryptonTextBox.Text.Replace(" ", "_") Then
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content29"), Me.Nom_Projet_KryptonTextBox.Text.Replace(" ", "_"))
                            .MainInstruction = RM.GetString("MainInstruction11")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                        Exit Sub
                    End If
                Next

                If Me.Nom_Projet_KryptonTextBox.Text = Nothing Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content30"), Me.Nom_Projet_KryptonTextBox.Text.Replace(" ", "_"))
                        .MainInstruction = RM.GetString("MainInstruction11")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Exit Sub
                End If

                'Assembly
                proj.Assembly_AssemblyVersion = .VF2_1_KryptonNumericUpDown.Value & "." & .VF2_2_KryptonNumericUpDown.Value & "." & .VF2_3_KryptonNumericUpDown.Value & "." & .VF2_4_KryptonNumericUpDown.Value
                proj.Assembly_FileVersion = .VF1_1_KryptonNumericUpDown.Value & "." & .VF1_2_KryptonNumericUpDown.Value & "." & .VF1_3_KryptonNumericUpDown.Value & "." & .VF1_4_KryptonNumericUpDown.Value
                proj.Assembly_Copyright = .Copyright_KryptonTextBox.Text
                proj.Assembly_Description = .Description_KryptonTextBox.Text
                proj.Assembly_Guid = .Guid_KryptonTextBox.Text
                proj.Assembly_Mark = .Marque_KryptonTextBox.Text
                proj.Assembly_Product = .Produit_KryptonTextBox.Text
                proj.Assembly_Socity = .Societe_KryptonTextBox.Text
                proj.Assembly_Title = .Titre_KryptonTextBox.Text

                ' CPU
                Select Case .Unite_Central_Cible_KryptonComboBox.SelectedIndex
                    Case 0
                        proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.x86
                    Case 1
                        proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.x64
                    Case 2
                        proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu
                End Select

                ' Obfuscation
                Select Case .Obfuscation_KryptonComboBox.SelectedIndex
                    Case 0
                        proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Low
                    Case 1
                        proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal
                    Case 2
                        proj.ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.High
                End Select

                ' formulaire de démarrage
                proj.FormStart = .Formulaire_Demarrage_KryptonComboBox.Text

                ' dossier de génération
                proj.GenerateDirectory = .Generation_KryptonTextBox.Text

                ' Instance
                proj.Instance = .Instance_Unique_KryptonCheckBox.Checked

                ' Paramètres
                proj.MySettings = .MySettings_KryptonCheckBox.Checked
                proj.Parametres.Clear()
                For Each ite As ListViewItem In Me.ListView2.Items
                    proj.Parametres.Add(ite.Text)
                Next

                ' Fichiers VB.Net
                proj.Fichiers_VBNet.Clear()
                For Each ite As ListViewItem In Me.ListView4.Items
                    proj.Fichiers_VBNet.Add(ite.Text)
                Next

                ' Optimiser
                proj.Optimize = .Optimiser_KryptonCheckBox.Checked

                ' Mode d'arrêt
                If .Mode_Arret_KryptonComboBox.SelectedIndex = 0 Then
                    proj.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses
                ElseIf .Mode_Arret_KryptonComboBox.SelectedIndex = 1 Then
                    proj.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose
                End If

                ' SplashScreen
                proj.SplashScreen = .Ecran_Demarrage_KryptonComboBox.Text

                ' Style XP
                proj.StyleXP = .Style_Visuel_KryptonCheckBox.Checked

                ' Type de projet
                Select Case .Type_Projet_KryptonComboBox.SelectedIndex
                    Case 0
                        proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                    Case 1
                        proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                    Case 2
                        proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                End Select

                ' Références
                proj.References.Clear()
                For Each ite As ListViewItem In Me.ListView1.Items
                    If CBool(ite.Tag) Then
                        proj.References.Add(New VelerSoftware.SZVB.Projet.Reference(True, Nothing, CBool(ite.SubItems(2).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False")), ite.Text, ite.SubItems(1).Text, ite.SubItems(3).Text))
                    Else
                        ClassProjet.Ajouter_Reference_Projet(ite.SubItems(3).Text, proj, CBool(ite.SubItems(2).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False")), ite.Text, ite.SubItems(1).Text)
                    End If
                Next

                ' Ressources
                proj.Ressources.Clear()
                For Each ite As ListViewItem In .ListView3.Items
                    Select Case ite.ImageKey
                        Case "TXT"
                            proj.Ressources.Add(New VelerSoftware.SZVB.Projet.Ressource(VelerSoftware.SZVB.Projet.Ressource.Types.Texte, ite.Text, ite.Tag))
                        Case "IMG"
                            proj.Ressources.Add(New VelerSoftware.SZVB.Projet.Ressource(VelerSoftware.SZVB.Projet.Ressource.Types.Image, ite.Text, ite.Tag))
                        Case "FILE"
                            proj.Ressources.Add(New VelerSoftware.SZVB.Projet.Ressource(VelerSoftware.SZVB.Projet.Ressource.Types.Fichier, ite.Text, ite.Tag))
                    End Select
                Next

                ' Explorateur de solution
                For Each ite As TreeNode In DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0).Nodes
                    If ite.Text = Old_Name Then
                        If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                            ite.ImageIndex = 1
                            ite.SelectedImageIndex = 1
                        Else
                            ite.ImageIndex = 2
                            ite.SelectedImageIndex = 2
                        End If
                    End If
                Next

                If Not Old_Name = .Nom_Projet_KryptonTextBox.Text.Replace(" ", "_") Then
                    ' Nom du projet
                    proj.Nom = .Nom_Projet_KryptonTextBox.Text.Replace(" ", "_")

                    If SOLUTION.ProjetDemarrage = Old_Name Then SOLUTION.ProjetDemarrage = proj.Nom

                    If Not SOLUTION.GenerationOrder.IndexOf(Old_Name) = -1 Then SOLUTION.GenerationOrder(SOLUTION.GenerationOrder.IndexOf(Old_Name)) = proj.Nom

                    For Each ite As TreeNode In DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0).Nodes
                        If ite.Text = Old_Name Then
                            ite.Text = proj.Nom
                            ite.Tag = proj.Nom
                            ite.Name = proj.Nom
                            ite.Collapse()
                            ite.Nodes.Add("factice")
                            ite.Expand()
                        End If
                    Next

                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                        If page.Controls.Count > 0 Then
                            If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = Old_Name Then
                                DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = proj.Nom
                            ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = Old_Name Then
                                DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = proj.Nom
                            ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = Old_Name Then
                                page.UniqueName = "Paramètres du projet " & proj.Nom
                                DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = proj.Nom
                            ElseIf TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = Old_Name Then
                                page.UniqueName = "Statistiques du projet " & proj.Nom
                                DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = proj.Nom
                                page.Text = proj.Nom
                            ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = Old_Name Then
                                DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = proj.Nom
                            End If
                        End If
                    Next

                    DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).UniqueName = "Paramètres du projet " & proj.Nom
                End If

                If Not SOLUTION.GetProject(SOLUTION.ProjetDemarrage) Is Nothing Then
                    If SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        Form1.Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                    Else
                        Form1.Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = True
                    End If
                End If

                ' Mise à jour des références Projet dans tous les projets et document "paramètres du projet" ouverts
                For Each projet As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    For Each ref As VelerSoftware.SZVB.Projet.Reference In projet.References
                        If ref.Name = Old_Name Then
                            ref.Name = proj.Nom
                            If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                                ref.FullName = ClassFichier.Ouvrir_Fichier(proj.Emplacement, My.Computer.FileSystem.CombinePath(projet.Emplacement, projet.GenerateDirectory & "\" & projet.Nom & ".dll"))
                            Else
                                ref.FullName = ClassFichier.Ouvrir_Fichier(proj.Emplacement, My.Computer.FileSystem.CombinePath(projet.Emplacement, projet.GenerateDirectory & "\" & projet.Nom & ".exe"))
                            End If
                            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocParametresDuProjet Then
                                    For Each ite As ListViewItem In DirectCast(page.Controls(0), DocParametresDuProjet).ListView1.Items
                                        If CBool(ite.Tag) AndAlso ite.Text = Old_Name Then
                                            ite.Text = proj.Nom
                                            ite.SubItems(3).Text = ref.FullName
                                            DirectCast(page.Controls(0), DocParametresDuProjet).DocumentModifier()
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                Next

                ClassProjet.Enregistrer_Projet(proj.Nom)

                ' Recharger les statistiques
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                    If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = proj.Nom Then DirectCast(page.Controls(0), DocStatistiques).Charger(False)
                Next

            End If

        End With

        ' Mise à jour de l'explorateur de projet car, le fichier etant inexistant, il est possible qu'il ai été enregistré dans le dossier du projet
        DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ActualiserToolStripMenuItem_Click(Nothing, Nothing)

        Modifier = False

        DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Me.Nom_Projet
    End Sub


    Private listviewsorter_lv1, listviewsorter_lv2, listviewsorter_lv3, listviewsorter_lv4 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Modifier = False
            .Annuler = False
            .Retablir = False

            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            .PictureBox1.AllowDrop = True
            .KryptonNavigator1.SelectedIndex = 0
            .Ressource_KryptonLabel.Dock = DockStyle.Fill
            .Ressource_KryptonTextBox.Dock = DockStyle.Fill
            .Ressource_PictureBox.Dock = DockStyle.Fill
            .Ressource_KryptonLabel.Visible = False
            .Ressource_KryptonTextBox.Visible = False
            .Ressource_PictureBox.Visible = False

            .ToolTip1.SetToolTip(.Nom_Projet_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Nom_Projet_KryptonTextBox))
            .ToolTip1.SetToolTip(.Type_Projet_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Type_Projet_KryptonComboBox))
            .ToolTip1.SetToolTip(.Formulaire_Demarrage_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Formulaire_Demarrage_KryptonComboBox))
            .ToolTip1.SetToolTip(.Ecran_Demarrage_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Ecran_Demarrage_KryptonComboBox))
            .ToolTip1.SetToolTip(.Mode_Arret_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Mode_Arret_KryptonComboBox))
            .ToolTip1.SetToolTip(.Titre_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Titre_KryptonTextBox))
            .ToolTip1.SetToolTip(.Description_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Description_KryptonTextBox))
            .ToolTip1.SetToolTip(.Societe_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Societe_KryptonTextBox))
            .ToolTip1.SetToolTip(.Produit_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Produit_KryptonTextBox))
            .ToolTip1.SetToolTip(.Copyright_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Copyright_KryptonTextBox))
            .ToolTip1.SetToolTip(.Marque_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Marque_KryptonTextBox))
            .ToolTip1.SetToolTip(.Guid_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Guid_KryptonTextBox))
            .ToolTip1.SetToolTip(.Generation_KryptonTextBox.TextBox, .ToolTip1.GetToolTip(Generation_KryptonTextBox))
            .ToolTip1.SetToolTip(.Unite_Central_Cible_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Unite_Central_Cible_KryptonComboBox))
            .ToolTip1.SetToolTip(.Obfuscation_KryptonComboBox.ComboBox, .ToolTip1.GetToolTip(Obfuscation_KryptonComboBox))

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView1.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView2.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView2.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView3.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView3.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView4.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView4.Handle, 4096 + 54, 65536, 65536)

            'LV 1
            listviewsorter_lv1.ListView = .ListView1
            listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(3).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.Sort(0)

            'LV 2
            listviewsorter_lv2.ListView = .ListView2
            listviewsorter_lv2.ColumnComparerCollection(.ListView2.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv2.Sort(0)

            'LV 2
            listviewsorter_lv3.ListView = .ListView3
            listviewsorter_lv3.ColumnComparerCollection(.ListView3.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv3.Sort(0)

            'LV 2
            listviewsorter_lv4.ListView = .ListView4
            listviewsorter_lv4.ColumnComparerCollection(.ListView4.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv4.Sort(0)

            .FinishLoad = True
            .Modifier = False
            .Annuler = True
            .Retablir = True
        End With
    End Sub

    Friend Function Page_Closing() As Boolean
        If Me.Modifier Then
            Using frm As New Fermer_Document
                frm.Label2.Text = frm.Label2.Text.Replace("{0}", Me.Nom_Projet)
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.Yes Then
                    ' Enregistrer
                    Me.Enregistrer()
                    Return True
                ElseIf result = DialogResult.No Then
                    ' Ne pas enregistrer
                    Return True
                ElseIf result = DialogResult.Cancel Then
                    ' Annuler
                    Return False
                End If
                frm.Dispose()
            End Using
        Else
            Return True
        End If
        Return True
    End Function

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

    Friend Sub Activate_Page()
        With Form1
            With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)
                .Vide_ToolBox.Visible = True
                .Concepteur_Fenetre_ToolBox.Visible = False
                .Fonctions_ToolBox.Visible = False
                .Classes_ToolBox.Visible = False
            End With

            With DirectCast(.Box_Proprietes.Controls(0), BoxProprietes)
                .PropertyGrids1.SelectedObjects = Nothing
                .PropertyGrids1.Item.Clear()
                .PropertyGrids1.ItemSet.Clear()
                .PropertyGrids1.ShowCustomProperties = True
                .KryptonRichTextBox1.Rtf = "{\rtf1" & Me.Nom_Projet & " {\b(" & RM.GetString("Document_Paramètres_Du_Projet") & ")}}"
            End With

            ' Configuration du ruban
            .Enregistrer_KryptonRibbonGroupButton.Enabled = True
            .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = False

            .VbNet_KryptonRibbonGroupButton.Enabled = False
            .CSharp_KryptonRibbonGroupButton.Enabled = False

            .Imprimer_KryptonRibbonGroupButton.Enabled = False
            .Impression_Rapide_KryptonRibbonGroupButton.Enabled = False
            .Apercu_Impression_KryptonRibbonGroupButton.Enabled = False

            .Coller_KryptonRibbonGroupButton.Enabled = False
            .Copier_KryptonRibbonGroupButton.Enabled = False
            .Couper_KryptonRibbonGroupButton.Enabled = False

            .Annuler_KryptonRibbonGroupButton.Enabled = False
            .Retablir_KryptonRibbonGroupButton.Enabled = False
            .Supprimer_KryptonRibbonGroupButton.Enabled = False
            .Selectionner_tout_KryptonRibbonGroupButton.Enabled = False

            .QAT_Annuler.Enabled = False
            .QAT_Coller.Enabled = False
            .QAT_Copier.Enabled = False
            .QAT_Couper.Enabled = False
            .QAT_Enregistrer_Sous.Enabled = False
            .QAT_Retablir.Enabled = False

            .KryptonRibbon1.SelectedContext = Nothing
        End With
    End Sub











    Private Sub Nom_Projet_KryptonTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Nom_Projet_KryptonTextBox.Validating
        With Me
            If .Nom_Projet_KryptonTextBox.Text = Nothing Then
                .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox, ToolTip1.GetToolTip(Nom_Projet_KryptonTextBox))
            Else
                Dim oki As Boolean = True
                For Each strr As String In Caractères_Interdit_Non_Numerique
                    If Me.Nom_Projet_KryptonTextBox.Text.Contains(strr) Then oki = False : Exit For
                Next
                If oki AndAlso (Me.Nom_Projet_KryptonTextBox.Text.StartsWith("0") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("1") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("2") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("3") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("4") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("5") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("6") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("7") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("8") OrElse Me.Nom_Projet_KryptonTextBox.Text.StartsWith("9")) Then
                    oki = False
                End If
                If Not oki OrElse .Nom_Projet_KryptonTextBox.Text.Contains(".") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("-") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains(":") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("/") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("\") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains(";") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("|") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("&") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("<") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains(">") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains("*") OrElse _
                    .Nom_Projet_KryptonTextBox.Text.Contains(" ") OrElse _
                    Mot_Cles_Interdit.Contains(Me.Nom_Projet_KryptonTextBox.Text) Then
                    .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox, ToolTip1.GetToolTip(.Nom_Projet_KryptonTextBox))
                Else
                    .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox, "")
                End If
            End If
        End With
    End Sub

    Private Sub Nom_Projet_KryptonTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nom_Projet_KryptonTextBox.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Type_Projet_KryptonComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Type_Projet_KryptonComboBox.Validating
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocParametresDuProjet))
        If Me.Type_Projet_KryptonComboBox.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.Type_Projet_KryptonComboBox, ToolTip1.GetToolTip(Type_Projet_KryptonComboBox))
        Else
            Me.ErrorProvider1.SetError(Me.Type_Projet_KryptonComboBox, "")
        End If
    End Sub

    Private Sub Mode_Arret_KryptonComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Mode_Arret_KryptonComboBox.Validating
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocParametresDuProjet))
        If Me.Mode_Arret_KryptonComboBox.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.Mode_Arret_KryptonComboBox, ToolTip1.GetToolTip(Mode_Arret_KryptonComboBox))
        Else
            Me.ErrorProvider1.SetError(Me.Mode_Arret_KryptonComboBox, "")
        End If
    End Sub

    Private Sub Formulaire_Demarrage_KryptonComboBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Formulaire_Demarrage_KryptonComboBox.Validating
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocParametresDuProjet))
        If (Me.Formulaire_Demarrage_KryptonComboBox.Text = Nothing) AndAlso (Not Me.Type_Projet_KryptonComboBox.SelectedIndex = 2) Then
            Me.ErrorProvider1.SetError(Me.Formulaire_Demarrage_KryptonComboBox, ToolTip1.GetToolTip(Formulaire_Demarrage_KryptonComboBox))
        Else
            Me.ErrorProvider1.SetError(Me.Formulaire_Demarrage_KryptonComboBox, "")
        End If
    End Sub

    Private Sub PictureBox3_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel1.DragEnter, PictureBox1.DragEnter
        If Me.Type_Projet_KryptonComboBox.SelectedIndex = 0 OrElse Me.Type_Projet_KryptonComboBox.SelectedIndex = 1 Then
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                    If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".ico" Then
                        e.Effect = DragDropEffects.Copy
                        Exit For
                    Else
                        e.Effect = DragDropEffects.None
                    End If
                Next
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub PictureBox3_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel1.DragDrop, PictureBox1.DragDrop
        If Me.Type_Projet_KryptonComboBox.SelectedIndex = 0 OrElse Me.Type_Projet_KryptonComboBox.SelectedIndex = 1 Then
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)
            For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".ico" Then
                    If Not a = proj.Emplacement & "\icon.ico" Then
                        My.Computer.FileSystem.CopyFile(a, proj.Emplacement & "\icon.ico", True)
                    End If
                    If My.Computer.FileSystem.FileExists(proj.Emplacement & "\icon.ico") Then
                        Me.Changer_Icone_KryptonButton.Tag = "icon.ico"
                        Dim fs As IO.FileStream = New IO.FileStream(proj.Emplacement & "\icon.ico", IO.FileMode.Open)
                        Me.PictureBox1.Image = VelerSoftware.SZVB.Windows.Core.GetBitmapFromIcon(New Icon(fs))
                        fs.Close()
                        DocumentModifier()
                    End If
                End If
            Next
        End If
    End Sub


    Private Sub Nom_Projet_KryptonTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_Projet_KryptonTextBox.TextChanged, Marque_KryptonTextBox.TextChanged, Copyright_KryptonTextBox.TextChanged, Produit_KryptonTextBox.TextChanged, Societe_KryptonTextBox.TextChanged, Description_KryptonTextBox.TextChanged, Titre_KryptonTextBox.TextChanged, VF2_4_KryptonNumericUpDown.ValueChanged, VF2_3_KryptonNumericUpDown.ValueChanged, VF2_2_KryptonNumericUpDown.ValueChanged, VF2_1_KryptonNumericUpDown.ValueChanged, VF1_1_KryptonNumericUpDown.ValueChanged, VF1_2_KryptonNumericUpDown.ValueChanged, VF1_3_KryptonNumericUpDown.ValueChanged, VF1_4_KryptonNumericUpDown.ValueChanged, Generation_KryptonTextBox.TextChanged, Guid_KryptonTextBox.TextChanged
        If Me.FinishLoad Then
            DocumentModifier()
        End If
    End Sub

    Private Sub Type_Projet_KryptonComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type_Projet_KryptonComboBox.SelectedIndexChanged
        With Me
            If .FinishLoad Then
                DocumentModifier()
            End If
            If .Type_Projet_KryptonComboBox.SelectedIndex = 0 Then
                .Formulaire_Demarrage_KryptonComboBox.Enabled = True
                .Ecran_Demarrage_KryptonComboBox.Enabled = True
                .Style_Visuel_KryptonCheckBox.Enabled = True
                .Instance_Unique_KryptonCheckBox.Enabled = True
                .Changer_Icone_KryptonButton.Enabled = True
                .MySettings_KryptonCheckBox.Enabled = True
                .Mode_Arret_KryptonComboBox.Enabled = True
                .KryptonButton3.Enabled = True
                .KryptonButton4.Enabled = True
                .ListView2.Enabled = True
                .Panel1.Enabled = True
                .PictureBox1.Enabled = True
                .KryptonButton10.Enabled = True
                ' Formulaire de démarrage  
                .Formulaire_Demarrage_KryptonComboBox.Items.Clear()
                .Formulaire_Demarrage_KryptonComboBox.Text = Nothing
                For Each a As String In My.Computer.FileSystem.GetFiles(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                    If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                        .Formulaire_Demarrage_KryptonComboBox.Items.Add(ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a))
                        If SOLUTION.GetProject(Me.Nom_Projet).FormStart = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a) Then
                            .Formulaire_Demarrage_KryptonComboBox.SelectedIndex = .Formulaire_Demarrage_KryptonComboBox.Items.Count - 1
                        End If
                    End If
                Next
            ElseIf .Type_Projet_KryptonComboBox.SelectedIndex = 1 Then
                .Formulaire_Demarrage_KryptonComboBox.Enabled = True
                .Ecran_Demarrage_KryptonComboBox.Enabled = False
                .Style_Visuel_KryptonCheckBox.Enabled = False
                .Instance_Unique_KryptonCheckBox.Enabled = False
                .Changer_Icone_KryptonButton.Enabled = True
                .MySettings_KryptonCheckBox.Enabled = False
                .Mode_Arret_KryptonComboBox.Enabled = False
                .KryptonButton3.Enabled = False
                .KryptonButton4.Enabled = False
                .ListView2.Enabled = False
                .Panel1.Enabled = True
                .PictureBox1.Enabled = True
                .KryptonButton10.Enabled = False
                ' Formulaire de démarrage  
                .Formulaire_Demarrage_KryptonComboBox.Items.Clear()
                .Formulaire_Demarrage_KryptonComboBox.Text = Nothing
                For Each a As String In My.Computer.FileSystem.GetFiles(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                    If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szc" Then
                        If Not a = SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ApplicationEvents.szc" Then
                            .Formulaire_Demarrage_KryptonComboBox.Items.Add(ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a))
                            If SOLUTION.GetProject(Me.Nom_Projet).FormStart = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a) Then
                                .Formulaire_Demarrage_KryptonComboBox.SelectedIndex = .Formulaire_Demarrage_KryptonComboBox.Items.Count - 1
                            End If
                        End If
                    End If
                Next
            ElseIf .Type_Projet_KryptonComboBox.SelectedIndex = 2 Then
                .Formulaire_Demarrage_KryptonComboBox.Enabled = False
                .Ecran_Demarrage_KryptonComboBox.Enabled = False
                .Style_Visuel_KryptonCheckBox.Enabled = False
                .Instance_Unique_KryptonCheckBox.Enabled = False
                .Changer_Icone_KryptonButton.Enabled = False
                .MySettings_KryptonCheckBox.Enabled = False
                .Mode_Arret_KryptonComboBox.Enabled = False
                .KryptonButton3.Enabled = False
                .KryptonButton4.Enabled = False
                .ListView2.Enabled = False
                .Panel1.Enabled = False
                .PictureBox1.Enabled = False
                .KryptonButton10.Enabled = False
            End If
        End With
    End Sub

    Private Sub Formulaire_Demarrage_KryptonComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Formulaire_Demarrage_KryptonComboBox.SelectedIndexChanged, Ecran_Demarrage_KryptonComboBox.SelectedIndexChanged, Mode_Arret_KryptonComboBox.SelectedIndexChanged, Unite_Central_Cible_KryptonComboBox.SelectedIndexChanged, Obfuscation_KryptonComboBox.SelectedIndexChanged
        If Me.FinishLoad Then
            DocumentModifier()
        End If
    End Sub

    Private Sub Style_Visuel_KryptonCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Style_Visuel_KryptonCheckBox.CheckedChanged, Instance_Unique_KryptonCheckBox.CheckedChanged, MySettings_KryptonCheckBox.CheckedChanged, Optimiser_KryptonCheckBox.CheckedChanged
        If Me.FinishLoad Then
            DocumentModifier()
        End If
    End Sub

    Private Sub Changer_Icone_KryptonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Changer_Icone_KryptonButton.Click
        Me.OpenFileDialog1.Title = "Ouvrir une icône"
        Me.OpenFileDialog1.Multiselect = False
        Me.OpenFileDialog1.Filter = "Fichier icône (*.ico)|*.ico"
        Me.OpenFileDialog1.FileName = Nothing
        Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)
        If My.Computer.FileSystem.DirectoryExists(proj.Emplacement) Then
            Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
        Else
            Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
        End If

        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(Me.OpenFileDialog1.FileName) Then
                If Not Me.OpenFileDialog1.FileName = proj.Emplacement & "\icon.ico" Then
                    My.Computer.FileSystem.CopyFile(Me.OpenFileDialog1.FileName, proj.Emplacement & "\icon.ico", True)
                End If
                If My.Computer.FileSystem.FileExists(proj.Emplacement & "\icon.ico") Then
                    Me.Changer_Icone_KryptonButton.Tag = "icon.ico"
                    Dim fs As IO.FileStream = New IO.FileStream(proj.Emplacement & "\icon.ico", IO.FileMode.Open)
                    Me.PictureBox1.Image = VelerSoftware.SZVB.Windows.Core.GetBitmapFromIcon(New Icon(fs))
                    fs.Close()
                    DocumentModifier()
                End If
            End If
        End If
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton2.Click
        If Me.ListView1.SelectedIndices.Count > 0 Then
            For Each a As ListViewItem In Me.ListView1.SelectedItems
                a.Remove()
            Next
            DocumentModifier()
        End If
    End Sub

    Private Sub KryptonButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton3.Click
        If Me.ListView2.SelectedIndices.Count > 0 Then
            For Each a As ListViewItem In Me.ListView2.SelectedItems
                a.Remove()
            Next
            DocumentModifier()
        End If
    End Sub

    Private Sub KryptonButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton4.Click
        Me.ListView2.SelectedItems.Clear()
        Dim ite As New ListViewItem
        ite.Selected = True
        Dim i As Integer = 1
        ite.Text = "New_Parameter" & i
        ite.Name = ite.Text
        Do
            If Me.ListView2.Items.ContainsKey(ite.Text) Then
                i += 1
                ite.Text = "New_Parameter" & i
                ite.Name = ite.Text
            Else
                ite.Text = "New_Parameter" & i
                ite.Name = ite.Text
                Exit Do
            End If
        Loop
        Me.ListView2.Items.Add(ite)
        ite.BeginEdit()
        DocumentModifier()
    End Sub

    Private Sub ListView2_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView2.AfterLabelEdit
        With e
            If Not .Label = Nothing Then
                Dim oki As Boolean = True
                For Each strr As String In Caractères_Interdit
                    If .Label.ToLower.Contains(strr) Then oki = False : Exit For
                Next
                If Not oki OrElse _
                (Mot_Cles_Interdit.Contains(.Label)) Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content6"))
                        .MainInstruction = RM.GetString("MainInstruction6")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    .CancelEdit = True
                Else
                    For Each ite As ListViewItem In Me.ListView2.Items
                        If ite.Text = .Label AndAlso Not ite.Index = .Item Then
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content7"), e.Label)
                                .MainInstruction = RM.GetString("MainInstruction7")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            .CancelEdit = True
                            Exit For
                        End If
                    Next
                End If

                If Not .CancelEdit Then
                    If .Label.StartsWith("0", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("1", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("2") OrElse .Label.StartsWith("3", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("4", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("5", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("6", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("7", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("8", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("9", StringComparison.OrdinalIgnoreCase) Then
                        Me.ListView2.Items(.Item).Name = "_" & .Label
                    Else
                        Me.ListView2.Items(.Item).Name = .Label
                    End If
                    DocumentModifier()
                End If
            Else
                .CancelEdit = True
            End If
        End With
    End Sub

    Private Sub KryptonButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton5.Click
        If Me.ListView3.SelectedIndices.Count > 0 Then
            For Each a As ListViewItem In Me.ListView3.SelectedItems
                a.Remove()
            Next
            DocumentModifier()
        End If
    End Sub

    Private Sub KryptonButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem1.Click, KryptonContextMenuItem2.Click, KryptonContextMenuItem3.Click
        If DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Tag = "TXT" Then
            Me.ListView3.SelectedItems.Clear()
            Dim ite As New ListViewItem
            ite.Selected = True
            Dim i As Integer = 1
            ite.Text = "New_Text" & i
            ite.Name = ite.Text
            ite.Tag = "Value"
            ite.ImageKey = "TXT"
            Do
                If Me.ListView3.Items.ContainsKey(ite.Text) Then
                    i += 1
                    ite.Text = "New_Text" & i
                    ite.Name = ite.Text
                Else
                    ite.Text = "New_Text" & i
                    ite.Name = ite.Text
                    Exit Do
                End If
            Loop
            Me.ListView3.Items.Add(ite)
            DocumentModifier()

        Else
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)
            Me.OpenFileDialog1.Title = RM.GetString("OpenFileDialog1_Ajouter_Ressource")
            Me.OpenFileDialog1.Multiselect = True
            Me.OpenFileDialog1.FileName = Nothing

            If DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Tag = "IMG" Then
                Me.OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_Ajouter_Ressource_Filtre")
            ElseIf DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Tag = "FILE" Then
                Me.OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_All_Filtre")
            End If
            If My.Computer.FileSystem.DirectoryExists(proj.Emplacement) Then
                Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
            Else
                Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
            End If
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.ListView3.SelectedItems.Clear()
                Dim ite As ListViewItem
                Dim exist As Boolean
                Dim tmp_name As String
                If Not My.Computer.FileSystem.DirectoryExists(proj.Emplacement & "\Ressources") Then
                    My.Computer.FileSystem.CreateDirectory(proj.Emplacement & "\Ressources")
                End If
                For Each a As String In Me.OpenFileDialog1.FileNames
                    If My.Computer.FileSystem.FileExists(a) Then
                        tmp_name = My.Computer.FileSystem.GetName(a).Split(".")(0).Replace(" ", "_").Replace("-", "_").Replace(":", "_").Replace(";", "_").Replace("?", "_").Replace(",", "_").Replace(".", "_").Replace("/", "_").Replace("\", "_").Replace("!", "_").Replace("$", "_").Replace("£", "_").Replace("^", "_").Replace("*", "_").Replace("<", "_").Replace(">", "_").Replace("&", "_").Replace(ChrW(34), "_")
                        If tmp_name.StartsWith("0", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("1", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("2", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("3", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("4", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("5", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("6", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("7", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("8", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("9", StringComparison.OrdinalIgnoreCase) Then tmp_name = "_" & tmp_name
                        For Each b As ListViewItem In Me.ListView3.Items
                            If b.Text = tmp_name Then
                                exist = True
                                Exit For
                            End If
                        Next
                        If Not exist Then
                            Try
                                If Not My.Computer.FileSystem.FileExists(proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)) Then
                                    My.Computer.FileSystem.CopyFile(a, proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a), True)
                                End If
                                ite = New ListViewItem
                                ite.Text = tmp_name
                                ite.Name = tmp_name
                                ite.ToolTipText = proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)
                                ite.Tag = ClassFichier.Ouvrir_Fichier(proj.Emplacement, proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a))
                                If DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Tag = "IMG" Then
                                    ite.ImageKey = "IMG"
                                ElseIf DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Tag = "FILE" Then
                                    ite.ImageKey = "FILE"
                                End If
                                ite.Selected = True
                                Me.ListView3.Items.Add(ite)
                                DocumentModifier()
                            Catch err As Exception
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content10"), My.Computer.FileSystem.GetName(a), proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)) & Environment.NewLine & err.Message
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End Try
                        End If
                    End If
                Next
                '  Form1.Explorateur_Projet.Actualiser_ToolStripButton_Click(Nothing, Nothing)
            End If


        End If
    End Sub

    Private Sub ListView3_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView3.AfterLabelEdit
        With e
            If Not .Label = Nothing Then
                Dim oki As Boolean = True
                For Each strr As String In Caractères_Interdit
                    If .Label.ToLower.Contains(strr) Then oki = False : Exit For
                Next
                If Not oki OrElse _
                (Mot_Cles_Interdit.Contains(.Label)) Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content8"))
                        .MainInstruction = RM.GetString("MainInstruction8")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    .CancelEdit = True
                Else
                    For Each ite As ListViewItem In Me.ListView3.Items
                        If ite.Text = .Label AndAlso Not ite.Index = .Item Then
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content9"), e.Label)
                                .MainInstruction = RM.GetString("MainInstruction9")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            .CancelEdit = True
                            Exit For
                        End If
                    Next
                End If

                If Not .CancelEdit Then
                    If .Label.StartsWith("0", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("1", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("2", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("3", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("4", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("5", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("6", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("7", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("8", StringComparison.OrdinalIgnoreCase) OrElse .Label.StartsWith("9", StringComparison.OrdinalIgnoreCase) Then
                        Me.ListView3.Items(.Item).Name = "_" & .Label
                    Else
                        Me.ListView3.Items(.Item).Name = .Label
                    End If
                    DocumentModifier()
                End If
            Else
                .CancelEdit = True
            End If
        End With
    End Sub

    Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView3.SelectedIndexChanged
        With Me
            If .ListView3.SelectedIndices.Count = 1 Then
                Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
                If .ListView3.SelectedItems(0).ImageKey = "TXT" Then
                    .Ressource_KryptonLabel.Visible = False
                    .Ressource_KryptonTextBox.Visible = True
                    .Ressource_PictureBox.Visible = False
                    .Ressource_KryptonTextBox.Text = .ListView3.SelectedItems(0).Tag
                ElseIf .ListView3.SelectedItems(0).ImageKey = "IMG" Then
                    .Ressource_KryptonLabel.Visible = False
                    .Ressource_KryptonTextBox.Visible = False
                    .Ressource_PictureBox.Visible = True
                    .Ressource_PictureBox.Image = Nothing
                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)) Then
                        .Ressource_PictureBox.Image = Drawing.Image.FromFile(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag))
                        If (.Ressource_PictureBox.Image.Size.Height > .Ressource_PictureBox.Size.Height) OrElse (.Ressource_PictureBox.Image.Size.Width > .Ressource_PictureBox.Size.Width) Then
                            .Ressource_PictureBox.SizeMode = PictureBoxSizeMode.Zoom
                        Else
                            .Ressource_PictureBox.SizeMode = PictureBoxSizeMode.CenterImage
                        End If
                    End If
                ElseIf .ListView3.SelectedItems(0).ImageKey = "FILE" Then
                    .Ressource_KryptonLabel.Visible = True
                    .Ressource_KryptonTextBox.Visible = False
                    .Ressource_PictureBox.Visible = False
                    .Ressource_KryptonLabel.Text = Nothing
                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)) Then
                        .Ressource_KryptonLabel.Text = "Nom complet du fichier : " & My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag) & Environment.NewLine & Environment.NewLine & _
                          "Nom : " & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)) & Environment.NewLine & Environment.NewLine & _
                          "Type : " & My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\" & My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\" & My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).Extension, "", "ExtensionNotFound"), "", "Fichier " & My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).Extension.Trim(".")) & Environment.NewLine & Environment.NewLine & _
                          "Date de création : " & System.IO.File.GetCreationTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortDateString & " - " & System.IO.File.GetCreationTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortTimeString & Environment.NewLine & Environment.NewLine & _
                          "Date de dernière modification : " & System.IO.File.GetLastWriteTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortDateString & " - " & System.IO.File.GetLastWriteTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortTimeString & Environment.NewLine & Environment.NewLine & _
                          "Date de dernier accès : " & System.IO.File.GetLastAccessTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortDateString & " - " & System.IO.File.GetLastAccessTime(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)).ToShortTimeString & Environment.NewLine & Environment.NewLine
                        If FileLen(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)) > 1024 Then
                            .Ressource_KryptonLabel.Text &= "Taille : " & Format(FileLen(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)) / 1024, "#,### KB")
                        Else
                            .Ressource_KryptonLabel.Text &= "Taille : " & Format(FileLen(My.Computer.FileSystem.CombinePath(proj.Emplacement, .ListView3.SelectedItems(0).Tag)), "##0 Bytes")
                        End If
                    End If
                End If
            Else
                .Ressource_KryptonLabel.Visible = False
                .Ressource_KryptonTextBox.Visible = False
                .Ressource_PictureBox.Visible = False
            End If
        End With
    End Sub

    Private Sub ButtonSpecAny1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpecAny1.Click
        If Me.ListView3.SelectedIndices.Count = 1 Then
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)
            If Me.ListView3.SelectedItems(0).ImageKey = "TXT" Then
                Me.ListView3.SelectedItems(0).Tag = Me.Ressource_KryptonTextBox.Text
                Me.DocumentModifier()
            End If
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes)
            .PropertyGrids1.SelectedObjects = Nothing
            .PropertyGrids1.Item.Clear()
            .PropertyGrids1.ItemSet.Clear()
            .PropertyGrids1.ShowCustomProperties = True
            .PropertyGrids1.Refresh()
            .KryptonRichTextBox1.Rtf = "{\rtf1}"

            If Me.ListView1.SelectedIndices.Count = 1 Then
                .KryptonRichTextBox1.Rtf = "{\rtf1" & Me.ListView1.SelectedItems(0).Text & " {\b(" & RM.GetString("Doc_Parametres_Du_Projet_1") & ")}}"
                .PropertyGrids1.Item.Add(RM.GetString("Doc_Parametres_Du_Projet_2"), Me.ListView1.SelectedItems(0).Text, True, RM.GetString("Doc_Parametres_Du_Projet_3"), RM.GetString("Doc_Parametres_Du_Projet_4"), True)
                .PropertyGrids1.Item.Add(RM.GetString("Doc_Parametres_Du_Projet_5"), Me.ListView1.SelectedItems(0).SubItems(1).Text, True, RM.GetString("Doc_Parametres_Du_Projet_3"), RM.GetString("Doc_Parametres_Du_Projet_6"), True)

                Dim valeur As String() = New String() {RM.GetString("Yes_Text"), RM.GetString("No_Text")}
                .PropertyGrids1.Item.Add(RM.GetString("Doc_Parametres_Du_Projet_7"), Me.ListView1.SelectedItems(0).SubItems(2).Text, False, RM.GetString("Doc_Parametres_Du_Projet_3"), RM.GetString("Doc_Parametres_Du_Projet_8"), True)
                .PropertyGrids1.Item(.PropertyGrids1.Item.Count - 1).Choices = New VelerSoftware.SZVB.PropertyGrids.CustomChoices(valeur, False)

                .PropertyGrids1.Refresh()
            End If
        End With
    End Sub





    Private Sub ListView1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".ocx" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".exe" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".dll" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".tlb" Then
                    e.Effect = DragDropEffects.Copy
                    Exit For
                Else
                    e.Effect = DragDropEffects.None
                End If
            Next
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
        Dim ite As ListViewItem
        Dim ass As Reflection.Assembly
        For Each a As String In e.Data.GetData(DataFormats.FileDrop)
            If My.Computer.FileSystem.FileExists(a) Then
                Try
                    ass = Reflection.Assembly.LoadFile(a)
                    Dim add As Boolean = True
                    For Each ite2 As ListViewItem In Me.ListView1.Items
                        If ite2.Text = ass.GetName.Name Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        ite = New ListViewItem
                        ite.Text = ass.GetName.Name
                        ite.SubItems.Add(ass.GetName.Version.ToString.Trim(" "))
                        ite.SubItems.Add(RM.GetString("Yes_Text"))
                        ite.SubItems.Add(ass.Location.Trim(" "))
                        Me.ListView1.Items.Add(ite)
                    End If
                    ass = Nothing
                Catch ex As Exception
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content11"), a, ex.Message)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                End Try
            End If
            DocumentModifier()
        Next
    End Sub

    Private Sub ListView3_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView3.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                e.Effect = DragDropEffects.Copy
                Exit For
            Next
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView3_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView3.DragDrop
        Dim ite As ListViewItem = Nothing
        Dim exist As Boolean
        Dim tmp_name As String
        Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)

        If Not My.Computer.FileSystem.DirectoryExists(proj.Emplacement & "\Ressources") Then
            My.Computer.FileSystem.CreateDirectory(proj.Emplacement & "\Ressources")
        End If

        For Each a As String In e.Data.GetData(DataFormats.FileDrop)
            tmp_name = My.Computer.FileSystem.GetName(a).Split(".")(0).Replace(" ", "_").Replace("-", "_").Replace(":", "_").Replace(";", "_").Replace("?", "_").Replace(",", "_").Replace(".", "_").Replace("/", "_").Replace("\", "_").Replace("!", "_").Replace("$", "_").Replace("£", "_").Replace("^", "_").Replace("*", "_").Replace("<", "_").Replace(">", "_").Replace("&", "_").Replace(ChrW(34), "_")
            If tmp_name.StartsWith("0", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("1", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("2", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("3", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("4", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("5", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("6", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("7", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("8", StringComparison.OrdinalIgnoreCase) OrElse tmp_name.StartsWith("9", StringComparison.OrdinalIgnoreCase) Then tmp_name = "_" & tmp_name
            For Each b As ListViewItem In Me.ListView3.Items
                If b.Text = tmp_name Then
                    exist = True
                    Exit For
                End If
            Next
            If Not exist Then
                Try
                    If Not My.Computer.FileSystem.FileExists(proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)) Then
                        My.Computer.FileSystem.CopyFile(a, proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a), True)
                    End If
                    ite = New ListViewItem
                    ite.Text = tmp_name
                    ite.Name = tmp_name
                    ite.ToolTipText = proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)
                    ite.Tag = ClassFichier.Ouvrir_Fichier(proj.Emplacement & proj.Nom_Fichier_Projet, proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a))
                    If a.ToLower.EndsWith(".bmp") OrElse a.ToLower.EndsWith(".png") OrElse a.ToLower.EndsWith(".jpg") OrElse a.ToLower.EndsWith(".gif") Then
                        ite.ImageKey = "IMG"
                    Else
                        ite.ImageKey = "FILE"
                    End If
                    ite.Selected = True
                    Me.ListView3.Items.Add(ite)
                    DocumentModifier()
                Catch err As Exception
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content10"), My.Computer.FileSystem.GetName(a), proj.Emplacement & "\Ressources\" & My.Computer.FileSystem.GetName(a)) & Environment.NewLine & err.Message
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                End Try
            End If
        Next
        'Form1.Explorateur_Projet.Actualiser_ToolStripButton_Click(Nothing, Nothing)
    End Sub

    Private Sub ListView4_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView4.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".vb" Then
                    e.Effect = DragDropEffects.Copy
                    Exit For
                Else
                    e.Effect = DragDropEffects.None
                End If
            Next
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView4_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView4.DragDrop
        If Not SOLUTION.GetProject(Me.Nom_Projet) Is Nothing Then
            Dim ite As ListViewItem
            For Each a As String In e.Data.GetData(DataFormats.FileDrop)
                If My.Computer.FileSystem.FileExists(a) Then
                    Dim add As Boolean = True
                    For Each ite2 As ListViewItem In Me.ListView4.Items
                        If ite2.Text = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a) Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        ite = New ListViewItem
                        ite.Text = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a)
                        ite.Name = ite.Text
                        Me.ListView4.Items.Add(ite)
                    End If
                End If
            Next
            DocumentModifier()
        End If
    End Sub



    Private Sub Gestionnaire_Variable_KryptonButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gestionnaire_Variable_KryptonButton.Click
        Using frm As New Gestionnaire_Variables
            frm.Nom_Projet = Me.Nom_Projet
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        If Not Add_Reference Is Nothing Then
            If Add_Reference.Ok Then
                Add_Reference.Nom_Projet = Me.Nom_Projet
                If Add_Reference.ShowDialog() = DialogResult.OK Then
                    Dim proc As New System.Diagnostics.Process
                    Dim ifo As New System.Diagnostics.ProcessStartInfo
                    Dim it As ListViewItem
                    Dim output As String = Nothing
                    For Each ite As ListViewItem In Add_Reference.Total_ListView.Items
                        If ite.SubItems(3).Text = "COM" Then
                            If Not SOLUTION.GetProject(Me.Nom_Projet) Is Nothing Then
                                If Not My.Computer.FileSystem.DirectoryExists(SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj") Then
                                    My.Computer.FileSystem.CreateDirectory(SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj")
                                End If
                                output = Nothing

                                If My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension.ToLower = ".tlb" Then

                                    'Instance de la classe Process
                                    'Nom de l'executable à lancer  
                                    ifo.FileName = Application.StartupPath & "\Tools\TlbImp"
                                    'Arguments à passer à l'éxécutable à lancer
                                    ifo.Arguments = ChrW(34) & ite.SubItems(2).Text & ChrW(34) & " /out:" & ChrW(34) & SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj\" & "Interop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & ".dll" & ChrW(34)
                                    ifo.UseShellExecute = False
                                    ifo.RedirectStandardOutput = True
                                    ifo.WindowStyle = ProcessWindowStyle.Hidden
                                    ifo.CreateNoWindow = True
                                    'Démarrage du processus
                                    proc.StartInfo = ifo
                                    proc.Start()
                                    proc.WaitForExit()
                                    output = proc.StandardOutput.ReadToEnd

                                    Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, output))

                                    If Not output = Nothing Then
                                        If output.Contains("TlbImp : Type library imported to ") Then
                                            Dim add As Boolean = True
                                            For Each ite2 As ListViewItem In Me.ListView1.Items
                                                If ite2.Text = "Interop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & ".dll" Then
                                                    add = False
                                                    Exit For
                                                End If
                                            Next
                                            If add Then
                                                it = New ListViewItem
                                                it.Text = "Interop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper
                                                it.SubItems.Add(ite.SubItems(1).Text)
                                                it.SubItems.Add(RM.GetString("Yes_Text"))
                                                it.SubItems.Add(SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj\" & "Interop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & ".dll")
                                                Me.ListView1.Items.Add(it)
                                            End If
                                        End If
                                    End If

                                Else

                                    'Instance de la classe Process
                                    'Nom de l'executable à lancer
                                    ifo.FileName = Application.StartupPath & "\Tools\AxImp"
                                    'Arguments à passer à l'éxécutable à lancer
                                    ifo.Arguments = ChrW(34) & ite.SubItems(2).Text & ChrW(34) & " /out:" & ChrW(34) & SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj\" & "AxInterop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & "Lib.dll" & ChrW(34)
                                    ifo.UseShellExecute = False
                                    ifo.RedirectStandardOutput = True
                                    ifo.WindowStyle = ProcessWindowStyle.Hidden
                                    ifo.CreateNoWindow = True
                                    'Démarrage du processus
                                    proc.StartInfo = ifo
                                    proc.Start()
                                    proc.WaitForExit()
                                    output = proc.StandardOutput.ReadToEnd

                                    Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, output))

                                    If Not output = Nothing Then
                                        If output.Contains("Generated Assembly:") Then
                                            Dim add As Boolean = True
                                            For Each ite2 As ListViewItem In Me.ListView1.Items
                                                If ite2.Text = "AxInterop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & "Lib.dll" Then
                                                    add = False
                                                    Exit For
                                                End If
                                            Next
                                            If add Then
                                                it = New ListViewItem
                                                it.Text = "AxInterop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & "Lib"
                                                it.SubItems.Add(ite.SubItems(1).Text)
                                                it.SubItems.Add(RM.GetString("Yes_Text"))
                                                it.SubItems.Add(SOLUTION.GetProject(Me.Nom_Projet).Emplacement & "\ActiveXObj\" & "AxInterop." & (My.Computer.FileSystem.GetName(ite.SubItems(2).Text).Replace(My.Computer.FileSystem.GetFileInfo(ite.SubItems(2).Text).Extension, "")).ToUpper & "Lib.dll")
                                                Me.ListView1.Items.Add(it)
                                            End If
                                            add = True
                                            For Each ite2 As ListViewItem In Me.ListView1.Items
                                                If ite2.Text = My.Computer.FileSystem.GetName(output.Replace("Generated Assembly:", Nothing).Split(Environment.NewLine)(0).Trim(" ")).Replace(My.Computer.FileSystem.GetFileInfo(output.Replace("Generated Assembly:", Nothing).Split(Environment.NewLine)(0).Trim(" ")).Extension, "") Then
                                                    add = False
                                                    Exit For
                                                End If
                                            Next
                                            If add Then
                                                it = New ListViewItem
                                                it.Text = (My.Computer.FileSystem.GetName(output.Replace("Generated Assembly:", Nothing).Split(Environment.NewLine)(0).Trim(" ")).Replace(My.Computer.FileSystem.GetFileInfo(output.Replace("Generated Assembly:", Nothing).Split(Environment.NewLine)(0).Trim(" ")).Extension, ""))
                                                it.SubItems.Add(ite.SubItems(1).Text)
                                                it.SubItems.Add(RM.GetString("Yes_Text"))
                                                it.SubItems.Add(output.Replace("Generated Assembly:", Nothing).Split(Environment.NewLine)(0).Trim(" "))
                                                it.Tag = False
                                                Me.ListView1.Items.Add(it)
                                            End If
                                        End If
                                    End If

                                End If

                            End If
                        ElseIf ite.SubItems(3).Text = "PROJECT" Then
                            Dim add As Boolean = True
                            For Each ite2 As ListViewItem In Me.ListView1.Items
                                If ite2.Text = ite.Text Then
                                    add = False
                                    Exit For
                                End If
                            Next
                            If add Then
                                it = New ListViewItem
                                it.Text = ite.Text
                                it.SubItems.Add(ite.SubItems(1))
                                it.Tag = True
                                it.SubItems.Add(ite.Tag.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                it.SubItems.Add(ite.SubItems(2))
                                Me.ListView1.Items.Add(it)
                            End If
                        Else
                            Dim add As Boolean = True
                            For Each ite2 As ListViewItem In Me.ListView1.Items
                                If ite2.Text = ite.Text Then
                                    add = False
                                    Exit For
                                End If
                            Next
                            If add Then
                                it = New ListViewItem
                                it.Text = ite.Text
                                it.SubItems.Add(ite.SubItems(1))
                                it.SubItems.Add(ite.Tag.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                it.SubItems.Add(ite.SubItems(2))
                                it.Tag = False
                                Me.ListView1.Items.Add(it)
                            End If
                        End If
                    Next

                    For Each node As TreeNode In DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0).Nodes
                        If node.Tag = Me.Nom_Projet Then
                            node.Collapse()
                            node.Expand()
                        End If
                    Next

                    Me.DocumentModifier()
                End If
            End If
        End If
    End Sub

    Private Sub KryptonButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton7.Click
        With Me
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
            If Not proj Is Nothing Then
                Me.FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.CombinePath(proj.Emplacement, Me.Generation_KryptonTextBox.Text)
                If Me.FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
                    Me.Generation_KryptonTextBox.Text = ClassFichier.Ouvrir_Fichier(proj.Emplacement, Me.FolderBrowserDialog1.SelectedPath)
                End If
            End If
        End With
    End Sub

    Private Sub KryptonButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton8.Click
        Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Me.Nom_Projet)
        Me.OpenFileDialog1.Title = RM.GetString("OpenFileDialog1_Ajouter_Fichier_VB")
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.FileName = Nothing

        Me.OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_Ajouter_Fichier_VB_Filtre")
        If My.Computer.FileSystem.DirectoryExists(proj.Emplacement) Then
            Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
        Else
            Me.OpenFileDialog1.InitialDirectory = proj.Emplacement
        End If
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim ite As ListViewItem
            For Each a As String In Me.OpenFileDialog1.FileNames
                If My.Computer.FileSystem.FileExists(a) Then
                    Dim add As Boolean = True
                    For Each ite2 As ListViewItem In Me.ListView4.Items
                        If ite2.Text = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a) Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        ite = New ListViewItem
                        ite.Text = ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Me.Nom_Projet).Emplacement, a)
                        ite.Name = ite.Text
                        Me.ListView4.Items.Add(ite)
                    End If
                End If
            Next
            DocumentModifier()
        End If
    End Sub

    Private Sub KryptonButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton9.Click
        If Me.ListView4.SelectedIndices.Count > 0 Then
            For Each a As ListViewItem In Me.ListView4.SelectedItems
                a.Remove()
            Next
            DocumentModifier()
        End If
    End Sub

    Private Sub KryptonButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton10.Click
        Dim files() As String = New String(-1) {}
        Dim Safefiles() As String = New String(-1) {}
        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

        ReDim Preserve files(files.Length)
        ReDim Preserve Safefiles(Safefiles.Length)
        ReDim Preserve projects(projects.Length)
        files(files.Length - 1) = "APPLICATIONEVENTS"
        Safefiles(Safefiles.Length - 1) = "APPLICATIONEVENTS"
        projects(projects.Length - 1) = SOLUTION.GetProject(Me.Nom_Projet)

        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
    End Sub

    Private Sub KryptonButton11_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton11.Click
        Me.Guid_KryptonTextBox.Text = System.Guid.NewGuid.ToString()
    End Sub
End Class
