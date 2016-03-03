''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ClassProjet

#Region "Ouvrir"

    ' Permet d'ouvrir une solution
    ' Fichier = fichier .szsl à ouvrir
    Shared Sub Ouvrir_Solution(ByVal Fichier As String)
        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML

        If Fermer_Solution(True) AndAlso My.Computer.FileSystem.FileExists(Fichier) Then

            ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status4"), Fichier), True, 0)

            If My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToUpper = ".SZSL" Then ' Si c'est une solution
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Solution"), Fichier)))

                ' Teste de la version de la solution
                XmlRead = New Xml.XmlTextReader(Fichier)
                If XmlRead IsNot Nothing Then
                    Do While XmlRead.Read()
                        Select Case XmlRead.NodeType
                            Case Xml.XmlNodeType.Element
                                Select Case XmlRead.Name
                                    Case "SZSolution" ' Solution
                                        If Not XmlRead.GetAttribute("ToolsVersion") = "3.0" Then
                                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                            With vd
                                                .Owner = Nothing
                                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityWarning
                                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content3"), XmlRead.GetAttribute("ToolsVersion"), Application.ProductVersion, My.Application.Info.Title, XmlRead.GetAttribute("Name"))
                                                .MainInstruction = RM.GetString("MainInstruction3")
                                                .WindowTitle = My.Application.Info.Title
                                                .Show()
                                            End With
                                            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Solution_Incompatible"))))
                                            XmlRead.Close()
                                            Exit Sub
                                        Else
                                            Exit Do
                                        End If
                                End Select
                        End Select
                    Loop
                    XmlRead.Close()
                End If

                Form1.SuspendLayout()

                ' Fermeture de la solution
                SOLUTION = Nothing

                ' Création d'une nouvelle solution
                SOLUTION = Nothing
                SOLUTION = New VelerSoftware.SZVB.Projet.Solution
                SOLUTION.Emplacement = My.Computer.FileSystem.GetParentPath(Fichier)
                SOLUTION.Nom_Fichier_Projet = My.Computer.FileSystem.GetName(Fichier)


                ' Ouverture de la solution
                XmlRead = New Xml.XmlTextReader(Fichier)
                If XmlRead IsNot Nothing Then
                    Do While XmlRead.Read()
                        Select Case XmlRead.NodeType
                            Case Xml.XmlNodeType.Element
                                Select Case XmlRead.Name
                                    Case "SZSolution" ' Solution
                                        SOLUTION.Nom = XmlRead.GetAttribute("Name")
                                        SOLUTION.ProjetDemarrage = XmlRead.GetAttribute("MainProject")
                                    Case "Project" ' Projet
                                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(SOLUTION.Emplacement, XmlRead.GetAttribute("File"))) Then
                                            SOLUTION.Projets.Add(Ouvrir_Projet(My.Computer.FileSystem.CombinePath(SOLUTION.Emplacement, XmlRead.GetAttribute("File"))))
                                        Else
                                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                            With vd
                                                .Owner = Nothing
                                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content4"), My.Computer.FileSystem.CombinePath(SOLUTION.Emplacement, XmlRead.GetAttribute("File")), XmlRead.GetAttribute("Name"))
                                                .MainInstruction = RM.GetString("MainInstruction4")
                                                .WindowTitle = My.Application.Info.Title
                                                .Show()
                                            End With
                                            SOLUTION.Projets.Add(New VelerSoftware.SZVB.Projet.Projet(XmlRead.GetAttribute("Name"), My.Computer.FileSystem.CombinePath(SOLUTION.Emplacement, XmlRead.GetAttribute("File"))))
                                            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Projet_Introuvable"), XmlRead.GetAttribute("Name"), XmlRead.GetAttribute("File"))))
                                        End If
                                    Case "GenerationOrder" ' Ordre de génération
                                        SOLUTION.GenerationOrder.Add(XmlRead.GetAttribute("Name"))
                                End Select
                        End Select
                    Loop
                    XmlRead.Close()
                End If


                ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status4"), Fichier), True, 0)

                ' Eventuel projet manquant dans l'ordre de génération
                For i As Integer = 0 To SOLUTION.Projets.Count - 1
                    If Not SOLUTION.GenerationOrder.Contains(SOLUTION.Projets(i).Nom) Then SOLUTION.GenerationOrder.Add(SOLUTION.Projets(i).Nom)
                Next

                ClassApplication.Status_Application(Nothing, True, 10)


                With DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1
                    ' On vide l'explorateur de solution
                    .Nodes.Clear()

                    ' On créer le noeud de la solution
                    Dim RootNode As New System.Windows.Forms.TreeNode()
                    With RootNode
                        .Name = "ROOT"
                        .Tag = "ROOT"
                        .ToolTipText = SOLUTION.Emplacement
                        .Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
                        .ImageIndex = 0
                        .SelectedImageIndex = 0
                    End With
                    .Nodes.Add(RootNode)
                    .SelectedNodes.Clear()
                    .SelectedNodes.Add(RootNode)

                    ClassApplication.Status_Application(Nothing, True, 20)

                    ' On ajoute les projets à la solution
                    For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                        Charger_Projet_Explorateur_Solutions(RootNode, proj)
                    Next
                End With

                ClassApplication.Status_Application(Nothing, True, 50)

                With Form1
                    ' Configuration du ruban
                    .Enregistrer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Exporter_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Fermer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Enregistrer_Tout_KryptonRibbonGroupButton.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 60)

                    .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = True
                    .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = True
                    .Statistiques_KryptonRibbonGroupButton.Enabled = True
                    .Ordre_Generation_KryptonRibbonGroupButton.Enabled = True
                    .Ajouter_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Nouveau_Document_KryptonRibbonGroupButton.Enabled = True
                    .Generer_KryptonRibbonGroupButton.Enabled = True
                    If Not SOLUTION.GetProject(SOLUTION.ProjetDemarrage) Is Nothing Then
                        If SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                        Else
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = True
                        End If
                    End If
                    .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = True
                    .Demarrer_Le_Debogage_KryptonRibbonGroupButton1.Enabled = True
                    .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = False
                    .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
                    .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = False
                    .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

                    ClassApplication.Status_Application(Nothing, True, 70)

                    .QAT_Enregistrer_Tout.Enabled = True
                    .QAT_Fermer.Enabled = True
                    .QAT_Generer.Enabled = True

                    With DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions)
                        .Actualiser_ToolStripButton.Enabled = True
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .Proprietes_ToolStripButton.Enabled = True
                        .Reduire_Projet_ToolStripButton.Enabled = True
                        .TreeViewMultiSelect1.Enabled = True
                    End With

                    DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStripButton1.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 80)

                    With My.Settings.Projets_Recents
                        If Not .Contains(SOLUTION.Nom & "|" & Fichier) Then
                            If .Count >= 10 Then
                                .RemoveAt(9)
                                .Insert(0, SOLUTION.Nom & "|" & Fichier)
                            ElseIf .Count = 0 Then
                                .Add(SOLUTION.Nom & "|" & Fichier)
                            Else
                                .Insert(0, SOLUTION.Nom & "|" & Fichier)
                            End If
                        Else
                            .Remove(SOLUTION.Nom & "|" & Fichier)
                            .Insert(0, SOLUTION.Nom & "|" & Fichier)
                        End If
                    End With
                    If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                        If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocPageDeDemarrage Then
                            With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocPageDeDemarrage).KryptonListBox2.Items
                                .Clear()
                                For Each recent As String In My.Settings.Projets_Recents
                                    If Not recent = Nothing AndAlso recent.Contains("|") Then .Add(recent.Split("|")(0))
                                Next
                            End With
                        End If
                    End If


                    .Text = "[" & SOLUTION.Nom & "] " & My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName


                    ClassApplication.Status_Application(Nothing, True, 100)

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Solution_Chargé"), SOLUTION.Nom)))
                End With


                ' Ouverture des fichiers
                Dim files() As String = New String(-1) {}
                Dim Safefiles() As String = New String(-1) {}
                Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    For Each fi As String In proj.Doc_Ouverts
                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(proj.Emplacement, fi)) Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = My.Computer.FileSystem.CombinePath(proj.Emplacement, fi)
                            Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(proj.Emplacement, fi))
                            projects(projects.Length - 1) = proj
                        ElseIf fi = "PARAMETREDUPROJET" Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = "PARAMETREDUPROJET"
                            Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
                            projects(projects.Length - 1) = proj
                        ElseIf fi = "STATISTIQUESDUPROJET" Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = "STATISTIQUESDUPROJET"
                            Safefiles(Safefiles.Length - 1) = "STATISTIQUESDUPROJET"
                            projects(projects.Length - 1) = proj
                        End If
                    Next
                Next
                ClassProjet.Ouvrir_Document(files, Safefiles, projects)

                Form1.ResumeLayout()





            ElseIf My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToUpper = ".SZPROJ" Then ' Si c'est un projet
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Solution"), Fichier)))

                ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status4"), Fichier), True, 0)

                Form1.SuspendLayout()

                ' créer une solution vide et y ajouter le projet
                Generation_En_Cours_Projet = Nothing
                SOLUTION = Nothing
                SOLUTION = New VelerSoftware.SZVB.Projet.Solution
                With SOLUTION
                    .Emplacement = Nothing
                    .Nom_Fichier_Projet = Nothing
                    .Nom = "Solution 1"

                    ClassApplication.Status_Application(Nothing, True, 10)

                    ' On ajoute le projet
                    .Projets.Add(Ouvrir_Projet(Fichier))

                    ClassApplication.Status_Application(Nothing, True, 15)

                    ' On vide l'explorateur de solution
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes.Clear()

                    ' On créer le noeud de la solution
                    Dim RootNode As New System.Windows.Forms.TreeNode()
                    With RootNode
                        .Name = "ROOT"
                        .Tag = "ROOT"
                        .ToolTipText = SOLUTION.Emplacement
                        .Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
                        .ImageIndex = 0
                        .SelectedImageIndex = 0
                    End With
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes.Add(RootNode)

                    .ProjetDemarrage = .Projets(0).Nom
                    .GenerationOrder.Add(.Projets(0).Nom)

                    ClassApplication.Status_Application(Nothing, True, 20)

                    ' On ajoute les projets à la solution
                    For Each proj As VelerSoftware.SZVB.Projet.Projet In .Projets
                        Charger_Projet_Explorateur_Solutions(RootNode, proj)
                    Next

                End With

                ClassApplication.Status_Application(Nothing, True, 40)

                ' Chargement de la boîte à outils
                ClassApplication.Charger_ToolBox_Concepteur_Fenetre(Nothing)

                With Form1
                    ' Configuration du ruban
                    .Enregistrer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Exporter_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Fermer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Enregistrer_Tout_KryptonRibbonGroupButton.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 50)

                    .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = True
                    .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = True
                    .Statistiques_KryptonRibbonGroupButton.Enabled = True
                    .Ordre_Generation_KryptonRibbonGroupButton.Enabled = True
                    .Generer_KryptonRibbonGroupButton.Enabled = True
                    If Not SOLUTION.GetProject(SOLUTION.ProjetDemarrage) Is Nothing Then
                        If SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                        Else
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = True
                        End If
                    End If
                    .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 60)

                    .QAT_Enregistrer_Tout.Enabled = True
                    .QAT_Fermer.Enabled = True
                    .QAT_Generer.Enabled = True

                    With DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions)
                        .Actualiser_ToolStripButton.Enabled = True
                        .Nouveau_Dossier_ToolStripButton.Enabled = True
                        .Nouveau_Fichier_ToolStripButton.Enabled = True
                        .Proprietes_ToolStripButton.Enabled = True
                        .Reduire_Projet_ToolStripButton.Enabled = True
                        .TreeViewMultiSelect1.Enabled = True
                    End With

                    .Text = "[" & SOLUTION.Nom & "] " & My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName

                    ClassApplication.Status_Application(Nothing, True, 100)

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Solution_Chargé"), SOLUTION.Nom)))
                End With

                Form1.ResumeLayout()

            End If

        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)


        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

    ' Permet d'ouvrir un projet
    ' Fichier = fichier .szproj à ouvrir
    Shared Function Ouvrir_Projet(ByVal Fichier As String) As VelerSoftware.SZVB.Projet.Projet
        ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status5"), Fichier), True, 0)

        Dim ref_ok As Boolean = True
        Dim RESULTAT As New VelerSoftware.SZVB.Projet.Projet
        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML 
        Dim problem_reference As Boolean = False

        If My.Computer.FileSystem.FileExists(Fichier) Then
            If My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToUpper = ".SZPROJ" Then ' Si c'est un projet
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Projet"), Fichier)))

                ' Teste de la version de la solution
                XmlRead = New Xml.XmlTextReader(Fichier)
                If XmlRead IsNot Nothing Then
                    Do While XmlRead.Read()
                        Select Case XmlRead.NodeType
                            Case Xml.XmlNodeType.Element
                                Select Case XmlRead.Name
                                    Case "SZProject" ' Solution
                                        If XmlRead.GetAttribute("ToolsVersion") = "4.0" Then ' Projet plus récent que SZ 2012
                                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                            With vd
                                                .Owner = Nothing
                                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityWarning
                                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content5"), XmlRead.GetAttribute("ToolsVersion"), Application.ProductVersion, My.Application.Info.Title, XmlRead.GetAttribute("Name"))
                                                .MainInstruction = RM.GetString("MainInstruction5")
                                                .WindowTitle = My.Application.Info.Title
                                                .Show()
                                            End With
                                            RESULTAT = New VelerSoftware.SZVB.Projet.Projet(XmlRead.GetAttribute("Name"), Fichier)
                                            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Projet_Incompatible"))))
                                            XmlRead.Close()
                                            Return RESULTAT
                                            Exit Function
                                        ElseIf XmlRead.GetAttribute("ToolsVersion") = "2.0" OrElse XmlRead.GetAttribute("ToolsVersion") = "1.0" Then ' Projet Trop ancien ' Projet Trop ancien
                                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                            With vd
                                                .Owner = Nothing
                                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityWarning
                                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content5"), XmlRead.GetAttribute("ToolsVersion"), Application.ProductVersion, My.Application.Info.Title, My.Computer.FileSystem.GetName(Fichier).TrimEnd(My.Computer.FileSystem.GetFileInfo(Fichier).Extension))
                                                .MainInstruction = RM.GetString("MainInstruction5")
                                                .WindowTitle = My.Application.Info.Title
                                                .Show()
                                            End With
                                            RESULTAT = New VelerSoftware.SZVB.Projet.Projet(My.Computer.FileSystem.GetName(Fichier).TrimEnd(My.Computer.FileSystem.GetFileInfo(Fichier).Extension), Fichier)
                                            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Projet_Incompatible"))))
                                            XmlRead.Close()
                                            Return RESULTAT
                                            Exit Function
                                        Else ' Projet SZ 2012
                                            Exit Do
                                        End If
                                End Select
                        End Select
                    Loop
                    XmlRead.Close()
                End If

                ClassApplication.Status_Application(Nothing, True, 5)

                ' Création d'un nouveau projet
                RESULTAT = Nothing
                RESULTAT = New VelerSoftware.SZVB.Projet.Projet()
                With RESULTAT
                    .Emplacement = My.Computer.FileSystem.GetParentPath(Fichier)
                    .Nom_Fichier_Projet = My.Computer.FileSystem.GetName(Fichier)

                    ' Ouverture de la solution
                    XmlRead = New Xml.XmlTextReader(Fichier)
                    If XmlRead IsNot Nothing Then
                        Do While XmlRead.Read()
                            Select Case XmlRead.NodeType
                                Case Xml.XmlNodeType.Element
                                    Select Case XmlRead.Name
                                        Case "SZProject" ' Solution
                                            .Nom = XmlRead.GetAttribute("Name")
                                        Case "Type" ' Type de projet
                                            .Type = CInt(XmlRead.GetAttribute("value"))
                                        Case "ShutMode" ' Mode d'arrêt
                                            .ShutMode = CInt(XmlRead.GetAttribute("value"))
                                            ClassApplication.Status_Application(Nothing, True, 10)
                                        Case "FormStart" ' fenêtre de démarrage du projet
                                            .FormStart = XmlRead.GetAttribute("value")
                                        Case "SplashScreen" ' écran de démarrage du projet
                                            .SplashScreen = XmlRead.GetAttribute("value")
                                        Case "StyleXP" ' StyleXP
                                            .StyleXP = CBool(XmlRead.GetAttribute("value"))
                                            ClassApplication.Status_Application(Nothing, True, 20)
                                        Case "Instance" ' Instance
                                            .Instance = CBool(XmlRead.GetAttribute("value"))
                                        Case "MySettings" ' Enregistrer les paramètres
                                            .MySettings = CBool(XmlRead.GetAttribute("value"))
                                        Case "Assembly.Title" ' Assembly.Title
                                            .Assembly_Title = XmlRead.GetAttribute("value")
                                            ClassApplication.Status_Application(Nothing, True, 30)
                                        Case "Assembly.Description" ' Assembly.Description
                                            .Assembly_Description = XmlRead.GetAttribute("value")
                                        Case "Assembly.Socity" ' Assembly.Socity
                                            .Assembly_Socity = XmlRead.GetAttribute("value")
                                        Case "Assembly.Product" ' Assembly.Product
                                            .Assembly_Product = XmlRead.GetAttribute("value")
                                        Case "Assembly.Copyright" ' Assembly.Copyright
                                            .Assembly_Copyright = XmlRead.GetAttribute("value")
                                        Case "Assembly.FileVersion" ' Assembly.FileVersion
                                            .Assembly_FileVersion = XmlRead.GetAttribute("value")
                                            ClassApplication.Status_Application(Nothing, True, 40)
                                        Case "Assembly.AssemblyVersion" ' Assembly.AssemblyVersion
                                            .Assembly_AssemblyVersion = XmlRead.GetAttribute("value")
                                        Case "Assembly.Mark" ' Assembly.Mark
                                            .Assembly_Mark = XmlRead.GetAttribute("value")
                                        Case "Assembly.Guid" ' Assembly.Mark
                                            .Assembly_Guid = XmlRead.GetAttribute("value")
                                        Case "GenerateDirectory" ' GenerateDirectory
                                            .GenerateDirectory = XmlRead.GetAttribute("value")
                                            ClassApplication.Status_Application(Nothing, True, 50)
                                        Case "Optimize" ' Optimize  
                                            .Optimize = CBool(XmlRead.GetAttribute("value"))
                                        Case "Cpu" ' Cpu
                                            .Cpu = CInt(XmlRead.GetAttribute("value"))
                                        Case "ObfuscationLevel" ' ObfuscationLevel
                                            .ObfuscationLevel = CInt(XmlRead.GetAttribute("value"))
                                        Case "ShouldCompile" ' ShouldCompile
                                            .ShouldCompileRelease = CBool(XmlRead.GetAttribute("value"))
                                            ClassApplication.Status_Application(Nothing, True, 60)
                                        Case "Setting" ' Paramètres
                                            .Parametres.Add(XmlRead.GetAttribute("name"))
                                        Case "VBNet_File" ' Fichier VB.Net
                                            .Fichiers_VBNet.Add(XmlRead.GetAttribute("name"))
                                        Case "Open" ' Document à ouvrir
                                            .Doc_Ouverts.Add(XmlRead.GetAttribute("name"))
                                            ClassApplication.Status_Application(Nothing, True, 70)
                                        Case "Variable" ' Variable   
                                            If String.IsNullOrEmpty(XmlRead.GetAttribute("null")) Then
                                                .Variables.Add(New VelerSoftware.SZVB.Projet.Variable(XmlRead.GetAttribute("name"), CBool(XmlRead.GetAttribute("array")), XmlRead.GetAttribute("description"), XmlRead.GetAttribute("group"), False))
                                            Else
                                                .Variables.Add(New VelerSoftware.SZVB.Projet.Variable(XmlRead.GetAttribute("name"), CBool(XmlRead.GetAttribute("array")), XmlRead.GetAttribute("description"), XmlRead.GetAttribute("group"), CBool(XmlRead.GetAttribute("null"))))
                                            End If
                                        Case "Resource" ' Ressource
                                            .Ressources.Add(New VelerSoftware.SZVB.Projet.Ressource(XmlRead.GetAttribute("type"), XmlRead.GetAttribute("name"), XmlRead.GetAttribute("value")))
                                        Case "Statistic" ' Statistique
                                            .Statistiques.Add(New VelerSoftware.SZVB.Projet.Statistique(XmlRead.GetAttribute("xvalue"), XmlRead.GetAttribute("yvalue"), XmlRead.GetAttribute("type")))
                                        Case "Reference" ' Référence
                                            If Not XmlRead.GetAttribute("value") = Nothing Then
                                                ' Chargement des références   
                                                If CBool(XmlRead.GetAttribute("isproject")) Then
                                                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(True, Nothing, CBool(XmlRead.GetAttribute("copy")), XmlRead.GetAttribute("name"), XmlRead.GetAttribute("version"), XmlRead.GetAttribute("value")))
                                                ElseIf Ajouter_Reference_Projet(XmlRead.GetAttribute("value"), RESULTAT, XmlRead.GetAttribute("copy"), XmlRead.GetAttribute("name"), XmlRead.GetAttribute("version")) Then
                                                    problem_reference = True
                                                End If
                                            End If
                                    End Select
                            End Select
                        Loop
                        XmlRead.Close()
                    End If

                    ClassApplication.Status_Application(Nothing, True, 90)

                    If Not My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CombinePath(.Emplacement, .GenerateDirectory)) Then My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.CombinePath(.Emplacement, .GenerateDirectory))

                    .Loaded = True

                    ' Cherche les problèmes dans le projet
                    Valider_Projet(RESULTAT, True)


                    ClassApplication.Status_Application(Nothing, True, 100)

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Projet_Chargé"), .Nom)))
                End With

            End If
        Else ' Si le projet est introuvable, on le garde tout de même dans la solution
            ' Création d'un nouveau projet
            RESULTAT = Nothing
            RESULTAT = New VelerSoftware.SZVB.Projet.Projet
            RESULTAT.Emplacement = My.Computer.FileSystem.GetParentPath(Fichier)
            RESULTAT.Nom_Fichier_Projet = My.Computer.FileSystem.GetName(Fichier)
            RESULTAT.Loaded = False
        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return RESULTAT
    End Function

#End Region

#Region "Fermer"

    Shared Function Fermer_Solution(ByVal Enregistrer_Projets As Boolean) As Boolean
        ClassApplication.Status_Application(RM.GetString("Status6"), False, 0)

        Dim resultat As Boolean = True

        ' Enregistrer la solution
        If Not SOLUTION Is Nothing Then
            If Status_SZ = statu.Debuggage_En_Cours Then
                If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Form1, RM.GetString("Content39"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return False
                    Exit Function
                Else
                    Form1.Débogueur.Stop()
                End If
            End If

            If Enregistrer_Projets Then ClassProjet.Enregistrer_Solution(Enregistrer_Projets)

            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                For Each pag As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockingManager1.Pages
                    If pag.Controls.Count > 0 Then
                        If TypeOf pag.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet = proj.Nom Then
                            If DirectCast(pag.Controls(0), DocConcepteurFenetre).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocConcepteurFenetre).NomFichier)))
                                Form1.KryptonDockingManager1.RemovePage(pag, True)
                            Else
                                resultat = False
                                Return resultat
                                Exit Function
                            End If
                        ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet = proj.Nom Then
                            If DirectCast(pag.Controls(0), DocEditeurFonctions).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocEditeurFonctions).NomFichier)))
                                Form1.KryptonDockingManager1.RemovePage(pag, True)
                            Else
                                resultat = False
                                Return resultat
                                Exit Function
                            End If
                        ElseIf TypeOf pag.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(pag.Controls(0), DocParametresDuProjet).Nom_Projet = proj.Nom Then
                            If DirectCast(pag.Controls(0), DocParametresDuProjet).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocParametresDuProjet).Nom_Projet)))
                                Form1.KryptonDockingManager1.RemovePage(pag, True)
                            Else
                                resultat = False
                                Return resultat
                                Exit Function
                            End If
                        ElseIf TypeOf pag.Controls(0) Is DocStatistiques AndAlso DirectCast(pag.Controls(0), DocStatistiques).Nom_Projet = proj.Nom Then
                            If DirectCast(pag.Controls(0), DocStatistiques).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocStatistiques).Nom_Projet)))
                                Form1.KryptonDockingManager1.RemovePage(pag, True)
                            Else
                                resultat = False
                                Return resultat
                                Exit Function
                            End If
                        ElseIf TypeOf pag.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(pag.Controls(0), DocEditeurVisualBasic).Nom_Projet = proj.Nom Then
                            If DirectCast(pag.Controls(0), DocEditeurVisualBasic).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocEditeurVisualBasic).Nom_Projet)))
                                Form1.KryptonDockingManager1.RemovePage(pag, True)
                            Else
                                resultat = False
                                Return resultat
                                Exit Function
                            End If
                        End If
                    End If
                Next
            Next

            If resultat Then
                With Form1
                    ' Configuration du ruban
                    .Enregistrer_Projet_KryptonRibbonGroupButton.Enabled = False
                    .Exporter_Projet_KryptonRibbonGroupButton.Enabled = False
                    .Fermer_Projet_KryptonRibbonGroupButton.Enabled = False
                    .Enregistrer_Tout_KryptonRibbonGroupButton.Enabled = False

                    .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = False
                    .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = False
                    .Statistiques_KryptonRibbonGroupButton.Enabled = False
                    .Ordre_Generation_KryptonRibbonGroupButton.Enabled = False
                    .Ajouter_Projet_KryptonRibbonGroupButton.Enabled = False
                    .Nouveau_Document_KryptonRibbonGroupButton.Enabled = False
                    .Generer_KryptonRibbonGroupButton.Enabled = False
                    .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                    .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = False
                    .Demarrer_Le_Debogage_KryptonRibbonGroupButton1.Enabled = False
                    .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = False
                    .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
                    .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = False
                    .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

                    .QAT_Enregistrer_Tout.Enabled = False
                    .QAT_Fermer.Enabled = False
                    .QAT_Generer.Enabled = False

                    .Info_Bar1.Hide()

                    With DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions)
                        .Actualiser_ToolStripButton.Enabled = False
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .Proprietes_ToolStripButton.Enabled = False
                        .Reduire_Projet_ToolStripButton.Enabled = False
                        .TreeViewMultiSelect1.Enabled = False
                        .TreeViewMultiSelect1.Nodes.Clear()
                    End With

                    With DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration)
                        .ToolStripButton1.Enabled = False
                        .ListView1.Items.Clear()
                    End With

                    If .KryptonDockableWorkspace1.AllPages.Length = 0 Then
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
                            .KryptonRichTextBox1.Rtf = "{\rtf1}}"
                        End With
                    End If

                    .Text = My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Solution_Fermé"), SOLUTION.Nom)))

                    SOLUTION.Projets.Clear()
                    SOLUTION.GenerationOrder.Clear()
                    SOLUTION = Nothing
                    Generation_En_Cours_Projet = Nothing
                End With
            End If

        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        ' libérer de la mémoire RAM                          
        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)

        Return resultat
    End Function

#End Region

#Region "Validation"

    Shared Function Valider_Projet(ByVal proj As VelerSoftware.SZVB.Projet.Projet, ByVal ShowInfoBar As Boolean) As Boolean

        With proj

            If proj IsNot Nothing AndAlso .Loaded Then
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Validation_Projet"), .Nom)))

                Dim pres_system, pres_system_core, pres_system_windows, pres_system_drawing, pres_system_xml, ref_ok As Boolean

                ref_ok = True
                For Each a As VelerSoftware.SZVB.Projet.Reference In .References
                    If a IsNot Nothing Then
                        Select Case a.Name
                            Case "System"
                                pres_system = True
                            Case "System.Core"
                                pres_system_core = True
                            Case "System.Drawing"
                                pres_system_drawing = True
                            Case "System.Windows.Forms"
                                pres_system_windows = True
                            Case "System.Xml"
                                pres_system_xml = True
                        End Select
                    End If
                Next
                If pres_system = False OrElse pres_system_core = False OrElse pres_system_drawing = False OrElse pres_system_windows = False OrElse pres_system_xml = False Then ref_ok = False


                If Not ref_ok Then
                    If ShowInfoBar AndAlso Not Form1.Info_Bar1.Visible Then Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Errors, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_1_Description"), .Nom), RM.GetString("InfoBar_1_Button"), True, "Bibliotheques_Necessaire_Au_Projet_Ont_Ete_Supprimer", proj)
                    Return False
                End If

                If (.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse .Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) AndAlso Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(.Emplacement, .FormStart)) Then
                    If ShowInfoBar AndAlso Not Form1.Info_Bar1.Visible Then Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Errors, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_2_Description"), .Nom), RM.GetString("InfoBar_2_Button"), True, "Formulaire_De_Demarrage_Introuvable", proj)
                    Return False
                End If
                If .Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows AndAlso Not .SplashScreen = Nothing AndAlso Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(.Emplacement, .SplashScreen)) Then
                    If ShowInfoBar AndAlso Not Form1.Info_Bar1.Visible Then Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_3_Description"), .Nom), RM.GetString("InfoBar_3_Button"), True, "Ecran_De_Demarrage_Introuvable", proj)
                    Return False
                End If

                For Each ref As VelerSoftware.SZVB.Projet.Reference In .References
                    If ref IsNot Nothing AndAlso (Not ref.IsProject) AndAlso (ref.Assembly Is Nothing) Then
                        If ShowInfoBar AndAlso Not Form1.Info_Bar1.Visible Then Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_4_Description"), .Nom), RM.GetString("InfoBar_4_Button"), True, "Bibliothèque_Fonctions_Réutilisables_Dans_Projet_Pas_Pu_Etre_Chargées", proj)
                        Return False
                        Exit For
                    End If
                Next

                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Validation_Projet_Terminé"), .Nom)))
            End If

        End With
        Return True
    End Function

#End Region

#Region "Enregistrer"

    ' Permet d'enregistrer une solution
    ' Enregistrer_Projets = Si True, enregistre tous les projets de la solution
    Shared Function Enregistrer_Solution(ByVal Enregistrer_Projets As Boolean) As Boolean
        ClassApplication.Status_Application(RM.GetString("Status7"), True, 0)

        Dim resultat As Boolean
        Dim i_progress, i2_progress As Integer

        If Not SOLUTION Is Nothing Then

            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Solution"), SOLUTION.Nom)))

            If SOLUTION.Emplacement = Nothing Then
                With Form1.SaveFileDialog1
                    .Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Enregistrer_Solution"), SOLUTION.Nom)
                    .Filter = RM.GetString("SaveFileDialog1_Enregistrer_Solution_Filtre")
                    .FilterIndex = 0
                    .FileName = SOLUTION.Nom
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        SOLUTION.Nom_Fichier_Projet = My.Computer.FileSystem.GetName(.FileName)
                        SOLUTION.Emplacement = My.Computer.FileSystem.GetParentPath(.FileName)
                    Else
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Solution_Annulé"), SOLUTION.Nom)))
                        Return False
                        Exit Function
                    End If
                End With
            End If

            ClassApplication.Status_Application(Nothing, True, 10)

            Dim XmlDoc As System.Xml.XmlDocument
            Dim elemBox As System.Xml.XmlElement
            Dim elemSub As System.Xml.XmlElement
            Dim XmlAttribut As System.Xml.XmlAttribute

            XmlDoc = New System.Xml.XmlDocument()
            XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

            ' SZProj
            elemBox = XmlDoc.CreateElement("SZSolution")
            XmlAttribut = XmlDoc.CreateAttribute("ToolsVersion")
            XmlAttribut.Value = "3.0"
            elemBox.Attributes.Append(XmlAttribut)
            XmlAttribut = XmlDoc.CreateAttribute("Name")
            XmlAttribut.Value = SOLUTION.Nom
            elemBox.Attributes.Append(XmlAttribut)
            XmlAttribut = XmlDoc.CreateAttribute("MainProject")
            XmlAttribut.Value = SOLUTION.ProjetDemarrage
            elemBox.Attributes.Append(XmlAttribut)

            ClassApplication.Status_Application(Nothing, True, 20)

            ' Projets
            i_progress = SOLUTION.Projets.Count
            i2_progress = 0
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                elemSub = XmlDoc.CreateElement("Project")
                XmlAttribut = XmlDoc.CreateAttribute("Name")
                XmlAttribut.Value = proj.Nom
                elemSub.Attributes.Append(XmlAttribut)
                XmlAttribut = XmlDoc.CreateAttribute("File")
                XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(SOLUTION.Emplacement, proj.Emplacement & "\" & proj.Nom_Fichier_Projet)
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)
                i2_progress = +1
                ClassApplication.Status_Application(Nothing, True, (i2_progress \ i_progress) * 50)
            Next

            ClassApplication.Status_Application(Nothing, True, 50)

            ' Ordre de génération 
            i_progress = SOLUTION.GenerationOrder.Count
            i2_progress = 0
            For Each proj As String In SOLUTION.GenerationOrder
                elemSub = XmlDoc.CreateElement("GenerationOrder")
                XmlAttribut = XmlDoc.CreateAttribute("Name")
                XmlAttribut.Value = proj
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)
                i2_progress += 1
                ClassApplication.Status_Application(Nothing, True, ((i2_progress \ i_progress) * 50) + 50)
            Next

            XmlDoc.AppendChild(elemBox)

            ClassApplication.Status_Application(Nothing, True, 100)

            ' Enregistrer les projets
            If Enregistrer_Projets Then
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    Enregistrer_Projet(proj.Nom)
                Next
            End If

            If Not ClassFichier.IsReadOnly(SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet) Then
                'Ecriture du Xml
                XmlDoc.Save(SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet)
                resultat = True
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Solution_Terminé"), SOLUTION.Nom)))
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content23"), SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet)
                    .MainInstruction = RM.GetString("MainInstruction10")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                resultat = False
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Solution_Annulé"), SOLUTION.Nom)))
            End If

        Else
            resultat = False
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Solution_Annulé"), SOLUTION.Nom)))
        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return resultat
    End Function

    ' Permet d'enregistrer un projet
    ' Nom_Projet = Nom du projet à enregistrer
    Shared Function Enregistrer_Projet(ByVal Nom_Projet As String) As Boolean
        ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status8"), Nom_Projet), True, 0)

        Dim resultat As Boolean

        If Not SOLUTION Is Nothing Then


            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Nom_Projet)
            Dim XmlDoc As System.Xml.XmlDocument
            Dim elemBox As System.Xml.XmlElement
            Dim elemSub As System.Xml.XmlElement
            Dim XmlAttribut As System.Xml.XmlAttribute

            If Not proj Is Nothing AndAlso proj.Loaded Then

                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Projet"), Nom_Projet)))

                XmlDoc = New System.Xml.XmlDocument()
                XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

                ' SZProj
                elemBox = XmlDoc.CreateElement("SZProject")
                XmlAttribut = XmlDoc.CreateAttribute("ToolsVersion")
                XmlAttribut.Value = "3.0"
                elemBox.Attributes.Append(XmlAttribut)
                XmlAttribut = XmlDoc.CreateAttribute("Name")
                XmlAttribut.Value = proj.Nom
                elemBox.Attributes.Append(XmlAttribut)

                ClassApplication.Status_Application(Nothing, True, 10)

                ' Type
                elemSub = XmlDoc.CreateElement("Type")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Type
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Shut Mode
                elemSub = XmlDoc.CreateElement("ShutMode")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.ShutMode
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 20)

                ' FormStart
                elemSub = XmlDoc.CreateElement("FormStart")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.FormStart
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' SplashScreen
                elemSub = XmlDoc.CreateElement("SplashScreen")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.SplashScreen
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 30)

                ' Style XP
                elemSub = XmlDoc.CreateElement("StyleXP")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.StyleXP
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Instance unique
                elemSub = XmlDoc.CreateElement("Instance")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Instance
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' MySettings
                elemSub = XmlDoc.CreateElement("MySettings")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.MySettings
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 40)

                ' Assembly.Title
                elemSub = XmlDoc.CreateElement("Assembly.Title")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Title
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Description
                elemSub = XmlDoc.CreateElement("Assembly.Description")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Description
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Socity
                elemSub = XmlDoc.CreateElement("Assembly.Socity")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Socity
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 50)

                ' Assembly.Product
                elemSub = XmlDoc.CreateElement("Assembly.Product")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Product
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Copyright
                elemSub = XmlDoc.CreateElement("Assembly.Copyright")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Copyright
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.FileVersion
                elemSub = XmlDoc.CreateElement("Assembly.FileVersion")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_FileVersion
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.AssemblyVersion
                elemSub = XmlDoc.CreateElement("Assembly.AssemblyVersion")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_AssemblyVersion
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Mark
                elemSub = XmlDoc.CreateElement("Assembly.Mark")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Mark
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 60)

                ' Assembly.Guid
                elemSub = XmlDoc.CreateElement("Assembly.Guid")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Guid
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' GenerateDirectory
                elemSub = XmlDoc.CreateElement("GenerateDirectory")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.GenerateDirectory
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Optimize
                elemSub = XmlDoc.CreateElement("Optimize")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Optimize
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Cpu
                elemSub = XmlDoc.CreateElement("Cpu")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Cpu
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' ObfuscationLevel
                elemSub = XmlDoc.CreateElement("ObfuscationLevel")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.ObfuscationLevel
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ClassApplication.Status_Application(Nothing, True, 70)

                ' ShouldCompile
                elemSub = XmlDoc.CreateElement("ShouldCompile")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.ShouldCompileRelease
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Parametres
                For Each strs As String In proj.Parametres
                    elemSub = XmlDoc.CreateElement("Setting")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = strs
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Fichier VB.Net
                For Each strs As String In proj.Fichiers_VBNet
                    elemSub = XmlDoc.CreateElement("VBNet_File")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = strs
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Open
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                    If page.Controls.Count > 0 Then
                        If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = proj.Nom Then
                            elemSub = XmlDoc.CreateElement("Open")
                            XmlAttribut = XmlDoc.CreateAttribute("name")
                            XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(proj.Emplacement, DirectCast(page.Controls(0), DocConcepteurFenetre).NomCompletFichier)
                            elemSub.Attributes.Append(XmlAttribut)
                            elemBox.AppendChild(elemSub)
                        ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = proj.Nom Then
                            elemSub = XmlDoc.CreateElement("Open")
                            XmlAttribut = XmlDoc.CreateAttribute("name")
                            XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(proj.Emplacement, DirectCast(page.Controls(0), DocEditeurFonctions).NomCompletFichier)
                            elemSub.Attributes.Append(XmlAttribut)
                            elemBox.AppendChild(elemSub)
                        ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = proj.Nom Then
                            elemSub = XmlDoc.CreateElement("Open")
                            XmlAttribut = XmlDoc.CreateAttribute("name")
                            XmlAttribut.Value = "PARAMETREDUPROJET"
                            elemSub.Attributes.Append(XmlAttribut)
                            elemBox.AppendChild(elemSub)
                        ElseIf TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = proj.Nom Then
                            elemSub = XmlDoc.CreateElement("Open")
                            XmlAttribut = XmlDoc.CreateAttribute("name")
                            XmlAttribut.Value = "STATISTIQUESDUPROJET"
                            elemSub.Attributes.Append(XmlAttribut)
                            elemBox.AppendChild(elemSub)
                        ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = proj.Nom Then
                            elemSub = XmlDoc.CreateElement("Open")
                            XmlAttribut = XmlDoc.CreateAttribute("name")
                            XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(proj.Emplacement, DirectCast(page.Controls(0), DocEditeurVisualBasic).NomCompletFichier)
                            elemSub.Attributes.Append(XmlAttribut)
                            elemBox.AppendChild(elemSub)
                        End If
                    End If
                Next

                ClassApplication.Status_Application(Nothing, True, 80)

                ' Variables
                For Each var As VelerSoftware.SZVB.Projet.Variable In proj.Variables
                    elemSub = XmlDoc.CreateElement("Variable")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("array")
                    XmlAttribut.Value = var.Array
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("description")
                    XmlAttribut.Value = var.Description
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("group")
                    XmlAttribut.Value = var.Group
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("null")
                    XmlAttribut.Value = var.NullAtStart
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Ressources
                For Each var As VelerSoftware.SZVB.Projet.Ressource In proj.Ressources
                    elemSub = XmlDoc.CreateElement("Resource")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("type")
                    XmlAttribut.Value = var.Type
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("value")
                    XmlAttribut.Value = var.Value
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ClassApplication.Status_Application(Nothing, True, 90)

                ' Statistiques
                For Each var As VelerSoftware.SZVB.Projet.Statistique In proj.Statistiques
                    elemSub = XmlDoc.CreateElement("Statistic")
                    XmlAttribut = XmlDoc.CreateAttribute("xvalue")
                    XmlAttribut.Value = var.XValue
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("yvalue")
                    XmlAttribut.Value = var.YValue
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("type")
                    XmlAttribut.Value = var.TypeValue
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Références
                For Each var As VelerSoftware.SZVB.Projet.Reference In proj.References
                    elemSub = XmlDoc.CreateElement("Reference")
                    XmlAttribut = XmlDoc.CreateAttribute("isproject")
                    XmlAttribut.Value = var.IsProject
                    elemSub.Attributes.Append(XmlAttribut)
                    If My.Computer.FileSystem.FileExists(var.FullName) Then
                        XmlAttribut = XmlDoc.CreateAttribute("value")
                        XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(proj.Emplacement, var.FullName)
                        elemSub.Attributes.Append(XmlAttribut)
                    Else
                        XmlAttribut = XmlDoc.CreateAttribute("value")
                        XmlAttribut.Value = var.FullName
                        elemSub.Attributes.Append(XmlAttribut)
                    End If
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("copy")
                    XmlAttribut.Value = var.Copy
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("version")
                    XmlAttribut.Value = var.Version
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                XmlDoc.AppendChild(elemBox)

                ClassApplication.Status_Application(Nothing, True, 100)

                If Not ClassFichier.IsReadOnly(proj.Emplacement & "\" & proj.Nom_Fichier_Projet) Then
                    'Ecriture du Xml
                    XmlDoc.Save(proj.Emplacement & "\" & proj.Nom_Fichier_Projet)
                    resultat = True

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Projet_Terminé"), Nom_Projet)))
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content23"), proj.Emplacement & "\" & proj.Nom_Fichier_Projet)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    resultat = False
                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Projet_Annulé"), Nom_Projet)))
                End If
            Else
                resultat = False
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Projet_Annulé"), Nom_Projet)))
            End If
        Else
            resultat = False
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Projet_Annulé"), Nom_Projet)))
        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return resultat
    End Function

    ' Permet d'enregistrer les statistiques d'un projet
    ' Nom_Projet = Nom du projet à enregistrer
    Shared Function Enregistrer_Statistiques_Projet(ByVal Nom_Projet As String, ByVal Nom_Complet_Fichier As String, ByVal Composition_Controles As Double, ByVal Composition_Fonctions As Double) As Boolean
        Dim resultat As Boolean

        If Not SOLUTION Is Nothing Then

            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(Nom_Projet)
            Dim XmlDoc As System.Xml.XmlDocument
            Dim elemBox As System.Xml.XmlElement
            Dim elemSub As System.Xml.XmlElement
            Dim XmlAttribut As System.Xml.XmlAttribute

            If Not proj Is Nothing AndAlso proj.Loaded Then

                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Stat"), Nom_Projet)))

                XmlDoc = New System.Xml.XmlDocument()
                XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

                ' SZStatistic
                elemBox = XmlDoc.CreateElement("SZStatistic")
                XmlAttribut = XmlDoc.CreateAttribute("ToolsVersion")
                XmlAttribut.Value = "3.0"
                elemBox.Attributes.Append(XmlAttribut)
                XmlAttribut = XmlDoc.CreateAttribute("Name")
                XmlAttribut.Value = proj.Nom
                elemBox.Attributes.Append(XmlAttribut)

                ' Type
                elemSub = XmlDoc.CreateElement("Type")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Type
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Shut Mode
                elemSub = XmlDoc.CreateElement("ShutMode")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.ShutMode
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' FormStart
                elemSub = XmlDoc.CreateElement("FormStart")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.FormStart
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' SplashScreen
                elemSub = XmlDoc.CreateElement("SplashScreen")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.SplashScreen
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Style XP
                elemSub = XmlDoc.CreateElement("StyleXP")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.StyleXP
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Instance unique
                elemSub = XmlDoc.CreateElement("Instance")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Instance
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' MySettings
                elemSub = XmlDoc.CreateElement("MySettings")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.MySettings
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Title
                elemSub = XmlDoc.CreateElement("Assembly.Title")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Title
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Description
                elemSub = XmlDoc.CreateElement("Assembly.Description")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Description
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Socity
                elemSub = XmlDoc.CreateElement("Assembly.Socity")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Socity
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Product
                elemSub = XmlDoc.CreateElement("Assembly.Product")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Product
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Copyright
                elemSub = XmlDoc.CreateElement("Assembly.Copyright")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Copyright
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.FileVersion
                elemSub = XmlDoc.CreateElement("Assembly.FileVersion")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_FileVersion
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.AssemblyVersion
                elemSub = XmlDoc.CreateElement("Assembly.AssemblyVersion")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_AssemblyVersion
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Assembly.Mark
                elemSub = XmlDoc.CreateElement("Assembly.Mark")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Assembly_Mark
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' GenerateDirectory
                elemSub = XmlDoc.CreateElement("GenerateDirectory")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.GenerateDirectory
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Optimize
                elemSub = XmlDoc.CreateElement("Optimize")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Optimize
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Cpu
                elemSub = XmlDoc.CreateElement("Cpu")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.Cpu
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' ObfuscationLevel
                elemSub = XmlDoc.CreateElement("ObfuscationLevel")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = proj.ObfuscationLevel
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Composition_Controles
                elemSub = XmlDoc.CreateElement("Composition_Controls")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = Composition_Controles
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Composition_Fonctions
                elemSub = XmlDoc.CreateElement("Composition_Functions")
                XmlAttribut = XmlDoc.CreateAttribute("value")
                XmlAttribut.Value = Composition_Fonctions
                elemSub.Attributes.Append(XmlAttribut)
                elemBox.AppendChild(elemSub)

                ' Parametres
                For Each strs As String In proj.Parametres
                    elemSub = XmlDoc.CreateElement("Setting")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = strs
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Fichier VB.Net
                For Each strs As String In proj.Fichiers_VBNet
                    elemSub = XmlDoc.CreateElement("VBNet_File")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = strs
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Variables
                For Each var As VelerSoftware.SZVB.Projet.Variable In proj.Variables
                    elemSub = XmlDoc.CreateElement("Variable")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("array")
                    XmlAttribut.Value = var.Array
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("description")
                    XmlAttribut.Value = var.Description
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("group")
                    XmlAttribut.Value = var.Group
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("null")
                    XmlAttribut.Value = var.NullAtStart
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Ressources
                For Each var As VelerSoftware.SZVB.Projet.Ressource In proj.Ressources
                    elemSub = XmlDoc.CreateElement("Resource")
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("type")
                    XmlAttribut.Value = var.Type
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("value")
                    XmlAttribut.Value = var.Value
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Statistiques
                For Each var As VelerSoftware.SZVB.Projet.Statistique In proj.Statistiques
                    elemSub = XmlDoc.CreateElement("Statistic")
                    XmlAttribut = XmlDoc.CreateAttribute("xvalue")
                    XmlAttribut.Value = var.XValue
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("yvalue")
                    XmlAttribut.Value = var.YValue
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("type")
                    XmlAttribut.Value = var.TypeValue
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                ' Références
                For Each var As VelerSoftware.SZVB.Projet.Reference In proj.References
                    elemSub = XmlDoc.CreateElement("Reference")
                    XmlAttribut = XmlDoc.CreateAttribute("isproject")
                    XmlAttribut.Value = var.IsProject
                    elemSub.Attributes.Append(XmlAttribut)
                    If My.Computer.FileSystem.FileExists(var.FullName) Then
                        XmlAttribut = XmlDoc.CreateAttribute("value")
                        XmlAttribut.Value = var.FullName
                        elemSub.Attributes.Append(XmlAttribut)
                    Else
                        XmlAttribut = XmlDoc.CreateAttribute("value")
                        XmlAttribut.Value = var.FullName
                        elemSub.Attributes.Append(XmlAttribut)
                    End If
                    XmlAttribut = XmlDoc.CreateAttribute("name")
                    XmlAttribut.Value = var.Name
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("copy")
                    XmlAttribut.Value = var.Copy
                    elemSub.Attributes.Append(XmlAttribut)
                    XmlAttribut = XmlDoc.CreateAttribute("version")
                    XmlAttribut.Value = var.Version
                    elemSub.Attributes.Append(XmlAttribut)
                    elemBox.AppendChild(elemSub)
                Next

                XmlDoc.AppendChild(elemBox)

                If Not ClassFichier.IsReadOnly(Nom_Complet_Fichier) Then
                    'Ecriture du Xml
                    XmlDoc.Save(Nom_Complet_Fichier)
                    resultat = True
                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Stat_Terminé"), Nom_Projet)))
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content23"), Nom_Complet_Fichier)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    resultat = False
                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Stat_Annulé"), Nom_Projet)))
                End If
            Else
                resultat = False
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Stat_Annulé"), Nom_Projet)))
            End If
        Else
            resultat = False
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Enregistrement_Stat_Annulé"), Nom_Projet)))
        End If

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return resultat
    End Function

#End Region

#Region "Références"

    ' Ajoute une référence au projet spécifié
    ' value = Chemin complet de la référence
    ' projet = Le Projet
    ' copy = Détermine s'il faut copier la référence
    ' name = Nom de la référence
    ' version = Version de la référence
    Shared Function Ajouter_Reference_Projet(ByVal value As String, ByRef projet As VelerSoftware.SZVB.Projet.Projet, ByVal copy As Boolean, ByVal name As String, ByVal version As String) As Boolean
        Dim asms() As Reflection.Assembly = Nothing
        Dim problem_reference As Boolean = False
        Dim oki As Boolean = True

        With projet

            ' Chargement des références
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value)) Then
                Try
                    asms = AppDomain.CurrentDomain.GetAssemblies
                    oki = True
                    For Each ass As Reflection.Assembly In asms
                        Try
                            If ass.Location = value Then oki = False : Exit For
                        Catch : End Try
                    Next
                    If oki Then
                        AppDomain.CurrentDomain.Load(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value))
                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value)), copy, name, version, value))
                    Else
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then
                                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, copy, name, version, value))
                                    Exit For
                                End If
                            Catch : End Try
                        Next
                    End If
                Catch
                    problem_reference = True
                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, copy, name, version, value))
                End Try

            ElseIf My.Computer.FileSystem.FileExists(value) Then
                Try
                    asms = AppDomain.CurrentDomain.GetAssemblies
                    oki = True
                    For Each ass As Reflection.Assembly In asms
                        Try
                            If ass.Location = value Then oki = False : Exit For
                        Catch : End Try
                    Next
                    If oki Then
                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value)) Then
                            AppDomain.CurrentDomain.Load(Application.StartupPath & "\" & value)
                            .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value)), copy, name, version, My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value)))
                        ElseIf My.Computer.FileSystem.FileExists(value) Then
                            AppDomain.CurrentDomain.Load(value)
                            .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(value), copy, name, version, value))
                        End If
                    Else
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then
                                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, copy, name, version, value))
                                    Exit For
                                End If
                            Catch : End Try
                        Next
                    End If
                Catch
                    problem_reference = True
                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, copy, name, version, value))
                End Try

            ElseIf My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(.Emplacement, value)) Then
                Try
                    asms = AppDomain.CurrentDomain.GetAssemblies
                    oki = True
                    For Each ass As Reflection.Assembly In asms
                        Try
                            If ass.Location = value Then oki = False : Exit For
                        Catch : End Try
                    Next
                    If oki Then
                        AppDomain.CurrentDomain.Load(My.Computer.FileSystem.CombinePath(.Emplacement, value))
                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(My.Computer.FileSystem.CombinePath(.Emplacement, value)), copy, name, version, My.Computer.FileSystem.CombinePath(.Emplacement, value)))
                    Else
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then
                                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, copy, name, version, value))
                                    Exit For
                                End If
                            Catch : End Try
                        Next
                    End If
                Catch
                    problem_reference = True
                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, copy, name, version, My.Computer.FileSystem.CombinePath(.Emplacement, value)))
                End Try
            Else
                Try
                    AppDomain.CurrentDomain.Load(value)
                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.Load(value), copy, name, version, value))
                Catch ex As Exception
                    problem_reference = True
                    .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, copy, name, version, value))
                End Try
            End If

            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = .Nom Then
                    With DirectCast(page.Controls(0), DocConcepteurFenetre).CodeDomHostLoader
                        .Ass = projet.References
                        .codeCompileUnit = .ReloadAssemblys(.GetCodeCompileUnit)
                    End With
                End If
            Next

        End With

        If problem_reference Then
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ajout_Reference_Echec"), value, projet.Nom)))
        Else
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ajout_Reference_Succes"), value, projet.Nom)))
        End If

        Return problem_reference
    End Function

    ' Ajoute une référence au projet spécifié
    ' value = Chemin complet de la référence
    ' projet = Le Projet
    Shared Function Ajouter_Reference_Projet(ByVal value As String, ByRef projet As VelerSoftware.SZVB.Projet.Projet) As Boolean
        Dim asms() As Reflection.Assembly = Nothing
        Dim asm As Reflection.Assembly = Nothing
        Dim problem_reference As Boolean = False
        Dim oki As Boolean = True

        Dim ass_valid As Reflection.Assembly = Nothing
        Dim ass_copy As Boolean = False

        With projet
            If .Loaded Then

                ' Chargement des références
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value)) Then
                    Try
                        asms = AppDomain.CurrentDomain.GetAssemblies
                        oki = True
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then oki = False : Exit For
                            Catch : End Try
                        Next
                        If oki Then
                            asm = AppDomain.CurrentDomain.Load(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value))
                            ass_valid = asm
                            ass_copy = True
                            .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value)), True, asm.GetName.Name, asm.GetName.Version.ToString, value))
                        Else
                            For Each ass As Reflection.Assembly In asms
                                Try
                                    If ass.Location = value Then
                                        ass_valid = ass
                                        ass_copy = True
                                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, True, ass.GetName.Name, ass.GetName.Version.ToString, value))
                                        Exit For
                                    End If
                                Catch : End Try
                            Next
                        End If
                        .ShouldCompileRelease = True
                    Catch
                        problem_reference = True
                    End Try

                ElseIf My.Computer.FileSystem.FileExists(value) Then
                    Try
                        asms = AppDomain.CurrentDomain.GetAssemblies
                        oki = True
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then oki = False : Exit For
                            Catch : End Try
                        Next
                        If oki Then
                            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & value) Then
                                asm = AppDomain.CurrentDomain.Load(Application.StartupPath & "\" & value)
                                ass_valid = asm
                                ass_copy = True
                                .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(Application.StartupPath & "\" & value), True, asm.GetName.Name, asm.GetName.Version.ToString, Application.StartupPath & "\" & value))
                            ElseIf My.Computer.FileSystem.FileExists(value) Then
                                asm = AppDomain.CurrentDomain.Load(value)
                                ass_valid = asm
                                ass_copy = True
                                .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(value), True, asm.GetName.Name, asm.GetName.Version.ToString, value))
                            End If
                        Else
                            For Each ass As Reflection.Assembly In asms
                                Try
                                    If ass.Location = value Then
                                        ass_valid = ass
                                        ass_copy = True
                                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, True, ass.GetName.Name, ass.GetName.Version.ToString, value))
                                        Exit For
                                    End If
                                Catch : End Try
                            Next
                        End If
                        .ShouldCompileRelease = True
                    Catch
                        problem_reference = True
                    End Try

                ElseIf My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(.Emplacement & "\", value)) Then
                    Try
                        asms = AppDomain.CurrentDomain.GetAssemblies
                        oki = True
                        For Each ass As Reflection.Assembly In asms
                            Try
                                If ass.Location = value Then oki = False : Exit For
                            Catch : End Try
                        Next
                        If oki Then
                            asm = AppDomain.CurrentDomain.Load(My.Computer.FileSystem.CombinePath(.Emplacement & "\", value))
                            ass_valid = asm
                            ass_copy = True
                            .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.LoadFile(My.Computer.FileSystem.CombinePath(.Emplacement & "\", value)), True, asm.GetName.Name, asm.GetName.Version.ToString, My.Computer.FileSystem.CombinePath(.Emplacement, value)))
                        Else
                            For Each ass As Reflection.Assembly In asms
                                Try
                                    If ass.Location = value Then
                                        ass_valid = ass
                                        ass_copy = True
                                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, ass, True, ass.GetName.Name, ass.GetName.Version.ToString, value))
                                        Exit For
                                    End If
                                Catch : End Try
                            Next
                        End If
                        .ShouldCompileRelease = True
                    Catch
                        problem_reference = True
                    End Try

                Else
                    Try
                        asm = AppDomain.CurrentDomain.Load(value)
                        ass_valid = asm
                        ass_copy = False
                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Reflection.Assembly.Load(value), False, asm.GetName.Name, asm.GetName.Version.ToString, value))
                        .ShouldCompileRelease = True
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        problem_reference = True
                        .References.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, False, value.Split(",")(0), "0.0.0.0", value))
                    End Try
                End If

                Try
                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                        If page.Controls.Count > 0 Then
                            If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = .Nom Then
                                DirectCast(page.Controls(0), DocConcepteurFenetre).CodeDomHostLoader.Ass = .References
                                DirectCast(page.Controls(0), DocConcepteurFenetre).CodeDomHostLoader.codeCompileUnit = DirectCast(page.Controls(0), DocConcepteurFenetre).CodeDomHostLoader.ReloadAssemblys(DirectCast(page.Controls(0), DocConcepteurFenetre).CodeDomHostLoader.GetCodeCompileUnit)
                            ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = .Nom AndAlso Not ass_valid Is Nothing Then
                                Dim ite As New ListViewItem
                                ite.Text = ass_valid.GetName.Name
                                ite.SubItems.Add(ass_valid.GetName.Version.ToString)
                                ite.SubItems.Add(ass_copy.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                ite.SubItems.Add(value)
                                ite.Tag = False
                                DirectCast(page.Controls(0), DocParametresDuProjet).ListView1.Items.Add(ite)
                                DirectCast(page.Controls(0), DocParametresDuProjet).DocumentModifier()
                            ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = .Nom AndAlso Not ass_valid Is Nothing Then
                                Dim ite As New ListViewItem
                                ite.Text = ass_valid.GetName.Name
                                ite.SubItems.Add(ass_valid.GetName.Version.ToString)
                                ite.SubItems.Add(ass_copy.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                ite.SubItems.Add(value)
                                ite.Tag = False
                                DirectCast(page.Controls(0), DocStatistiques).References_ListView1.Items.Add(ite)
                            End If
                        End If
                    Next
                Catch
                    ' Pour la génération, on ignore l'erreur de Thread STA
                End Try

            End If
        End With

        If problem_reference Then
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ajout_Reference_Echec"), value, projet.Nom)))
        Else
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ajout_Reference_Succes"), value, projet.Nom)))
        End If

        Return problem_reference
    End Function

#End Region

#Region "Projet"

    Shared Function Creer_Nouveau_Projet(ByVal Emplacement As String, ByVal Nom_Projet As String, ByVal Nom_Solution As String, ByVal Ajouter_Solution_Active As Boolean, ByVal Fichier_Template As String, ByVal Tip_projet As String) As Boolean
        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML
        Dim List_Fichier_Template As New Generic.List(Of String)
        Dim PROJET As VelerSoftware.SZVB.Projet.Projet

        With My.Computer.FileSystem
            If Not .DirectoryExists(Emplacement) Then .CreateDirectory(Emplacement)
            If Ajouter_Solution_Active Then
                If Not .DirectoryExists(Emplacement & "\" & Nom_Projet) Then .CreateDirectory(Emplacement & "\" & Nom_Projet)
                If Not .DirectoryExists(Emplacement & "\" & Nom_Projet & "\Bin") Then .CreateDirectory(Emplacement & "\" & Nom_Projet & "\Bin")
                PROJET = New VelerSoftware.SZVB.Projet.Projet(Nom_Projet, Emplacement & "\" & Nom_Projet & "\" & Nom_Projet & ".szproj")
                PROJET.Emplacement = Emplacement & "\" & Nom_Projet
            Else
                If Not .DirectoryExists(Emplacement & "\" & Nom_Solution) Then .CreateDirectory(Emplacement & "\" & Nom_Solution)
                If Not .DirectoryExists(Emplacement & "\" & Nom_Solution & "\" & Nom_Projet) Then .CreateDirectory(Emplacement & "\" & Nom_Solution & "\" & Nom_Projet)
                If Not .DirectoryExists(Emplacement & "\" & Nom_Solution & "\" & Nom_Projet & "\Bin") Then .CreateDirectory(Emplacement & "\" & Nom_Solution & "\" & Nom_Projet & "\Bin")
                PROJET = New VelerSoftware.SZVB.Projet.Projet(Nom_Projet, Emplacement & "\" & Nom_Solution & "\" & Nom_Projet & "\" & Nom_Projet & ".szproj")
                PROJET.Emplacement = Emplacement & "\" & Nom_Solution & "\" & Nom_Projet
            End If
        End With

        With PROJET
            .Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu
            .SplashScreen = Nothing
            .ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses
            .ObfuscationLevel = VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal
            With .References
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), False, "mscorlib", "4.0.0.0", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"))
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), False, "System", "4.0.0.0", "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"))
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), False, "System.Core", "4.0.0.0", "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"))
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), False, "System.Drawing", "4.0.0.0", "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"))
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), False, "System.Windows.Forms", "4.0.0.0", "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"))
                .Add(New VelerSoftware.SZVB.Projet.Reference(False, System.Reflection.Assembly.Load("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), False, "System.Xml", "4.0.0.0", "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"))
            End With
            .Assembly_AssemblyVersion = "1.0.0.0"
            .Assembly_FileVersion = "1.0.0.0"
            .Assembly_Copyright = "Copyright © " & My.Settings.Société & " " & Date.Now.Year
            .Assembly_Description = ""
            .Assembly_Guid = System.Guid.NewGuid.ToString()
            .Assembly_Mark = Nom_Projet & "™"
            .Assembly_Product = Nom_Projet
            .Assembly_Socity = My.Settings.Société
            .Assembly_Title = Nom_Projet
            .GenerateDirectory = "Bin"
            .Instance = False
            .MySettings = True
            .Optimize = True
            .ShouldCompileRelease = True
            .StyleXP = True
            Select Case Tip_projet
                Case "Window"
                    .Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                Case "Console"
                    .Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                Case "DLL"
                    .Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
            End Select

            If My.Computer.FileSystem.FileExists(Fichier_Template) AndAlso My.Computer.FileSystem.GetFileInfo(Fichier_Template).Extension.ToLower = ".sztemplate" Then
                XmlRead = New Xml.XmlTextReader(Fichier_Template)
                Do While XmlRead.Read()
                    Select Case XmlRead.NodeType
                        Case Xml.XmlNodeType.Element
                            Select Case XmlRead.Name
                                Case "SZTemplate" ' Template
                                    If XmlRead.GetAttribute("version") = "3.0" AndAlso XmlRead.GetAttribute("type") = Tip_projet Then
                                        If Not XmlRead.GetAttribute("files") = Nothing Then List_Fichier_Template.AddRange(XmlRead.GetAttribute("files").Split(";"))
                                        .FormStart = XmlRead.GetAttribute("start_file")
                                        .Doc_Ouverts.Add(.FormStart)
                                    End If
                                Case "SplashScreen"
                                    .SplashScreen = XmlRead.GetAttribute("value")
                                Case "CPU"
                                    .Cpu = CInt(XmlRead.GetAttribute("value"))
                                Case "FormStart"
                                    .FormStart = XmlRead.GetAttribute("value")
                                    .Doc_Ouverts.Clear()
                                    .Doc_Ouverts.Add(.FormStart)
                                Case "ShutMode"
                                    .ShutMode = CInt(XmlRead.GetAttribute("value"))
                                Case "Variable" ' Variable
                                    .Variables.Add(New VelerSoftware.SZVB.Projet.Variable(XmlRead.GetAttribute("name"), CBool(XmlRead.GetAttribute("array")), XmlRead.GetAttribute("description"), XmlRead.GetAttribute("group"), CBool(XmlRead.GetAttribute("null"))))
                                Case "Reference" ' Références
                                    Dim ok As Boolean = False
                                    For Each ref As VelerSoftware.SZVB.Projet.Reference In .References
                                        If ref.FullName = XmlRead.GetAttribute("value") OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", XmlRead.GetAttribute("value")) OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", XmlRead.GetAttribute("value")) Then
                                            ok = True
                                            Exit For
                                        End If
                                    Next
                                    If Not ok Then ClassProjet.Ajouter_Reference_Projet(XmlRead.GetAttribute("value"), PROJET, XmlRead.GetAttribute("copy"), XmlRead.GetAttribute("name"), XmlRead.GetAttribute("version"))
                            End Select
                    End Select
                Loop
                XmlRead.Close()
            End If
        End With

        With My.Computer.FileSystem
            If Ajouter_Solution_Active Then
                If .DirectoryExists(.GetParentPath(Fichier_Template)) Then
                    For Each strrr As String In List_Fichier_Template
                        If .FileExists(.GetParentPath(Fichier_Template) & "\" & strrr) Then .CopyFile(.GetParentPath(Fichier_Template) & "\" & strrr, Emplacement & "\" & Nom_Projet & "\" & strrr, True)
                    Next
                End If
                If .FileExists(Application.StartupPath & "\Templates\Project\icon.ico") Then .CopyFile(Application.StartupPath & "\Templates\Project\icon.ico", Emplacement & "\" & Nom_Projet & "\icon.ico", True)
            Else
                If .DirectoryExists(.GetParentPath(Fichier_Template)) Then
                    For Each strrr As String In List_Fichier_Template
                        If .FileExists(.GetParentPath(Fichier_Template) & "\" & strrr) Then .CopyFile(.GetParentPath(Fichier_Template) & "\" & strrr, Emplacement & "\" & Nom_Solution & "\" & Nom_Projet & "\" & strrr, True)
                    Next
                End If
                If .FileExists(Application.StartupPath & "\Templates\Project\icon.ico") Then .CopyFile(Application.StartupPath & "\Templates\Project\icon.ico", Emplacement & "\" & Nom_Solution & "\" & Nom_Projet & "\icon.ico", True)
            End If
        End With



        ' Cherche les problèmes dans le projet
        PROJET.Loaded = True
        Valider_Projet(PROJET, True)




        If Ajouter_Solution_Active Then
            SOLUTION.GenerationOrder.Insert(0, Nom_Projet)
            SOLUTION.Projets.Add(PROJET)

            ' Enregistrement de la solution
            Enregistrer_Solution(True)

            ClassProjet.Charger_Projet_Explorateur_Solutions(DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0), PROJET)
            ' Ouverture des fichiers
            Dim files() As String = New String(-1) {}
            Dim Safefiles() As String = New String(-1) {}
            Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
            For Each fi As String In PROJET.Doc_Ouverts
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi)) Then
                    ReDim Preserve files(files.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    files(files.Length - 1) = My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi)
                    Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi))
                    projects(projects.Length - 1) = PROJET
                ElseIf fi = "PARAMETREDUPROJET" Then
                    ReDim Preserve files(files.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    files(files.Length - 1) = "PARAMETREDUPROJET"
                    Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
                    projects(projects.Length - 1) = PROJET
                ElseIf fi = "STATISTIQUESDUPROJET" Then
                    ReDim Preserve files(files.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    files(files.Length - 1) = "STATISTIQUESDUPROJET"
                    Safefiles(Safefiles.Length - 1) = "STATISTIQUESDUPROJET"
                    projects(projects.Length - 1) = PROJET
                End If
            Next
            ClassProjet.Ouvrir_Document(files, Safefiles, projects)





        Else
            If Fermer_Solution(True) Then
                ' Création d'une nouvelle solution
                SOLUTION = Nothing
                SOLUTION = New VelerSoftware.SZVB.Projet.Solution
                With SOLUTION
                    .Nom = Nom_Solution
                    .Emplacement = Emplacement & "\" & Nom_Solution
                    .Nom_Fichier_Projet = My.Computer.FileSystem.GetName(Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                    .GenerationOrder.Add(Nom_Projet)
                    .ProjetDemarrage = Nom_Projet
                    .Projets.Add(PROJET)
                End With

                ' Enregistrement de la solution
                Enregistrer_Solution(True)

                ' On créer le noeud de la solution
                Dim RootNode As New System.Windows.Forms.TreeNode()
                With RootNode
                    .Name = "ROOT"
                    .Tag = "ROOT"
                    .ToolTipText = SOLUTION.Emplacement
                    .Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
                    .ImageIndex = 0
                    .SelectedImageIndex = 0
                End With
                With DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1
                    .Nodes.Add(RootNode)
                    .SelectedNodes.Clear()
                    .SelectedNodes.Add(RootNode)
                End With

                ClassApplication.Status_Application(Nothing, True, 20)

                ' On ajoute les projets à la solution
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    Charger_Projet_Explorateur_Solutions(RootNode, proj)
                Next

                With Form1
                    ' Configuration du ruban
                    .Enregistrer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Exporter_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Fermer_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Enregistrer_Tout_KryptonRibbonGroupButton.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 60)

                    .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = True
                    .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = True
                    .Statistiques_KryptonRibbonGroupButton.Enabled = True
                    .Ordre_Generation_KryptonRibbonGroupButton.Enabled = True
                    .Ajouter_Projet_KryptonRibbonGroupButton.Enabled = True
                    .Nouveau_Document_KryptonRibbonGroupButton.Enabled = True
                    .Generer_KryptonRibbonGroupButton.Enabled = True
                    If Not SOLUTION.GetProject(SOLUTION.ProjetDemarrage) Is Nothing Then
                        If SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
                        Else
                            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = True
                        End If
                    End If
                    .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = True
                    .Demarrer_Le_Debogage_KryptonRibbonGroupButton1.Enabled = True
                    .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = False
                    .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
                    .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = False
                    .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

                    ClassApplication.Status_Application(Nothing, True, 70)

                    .QAT_Enregistrer_Tout.Enabled = True
                    .QAT_Fermer.Enabled = True
                    .QAT_Generer.Enabled = True

                    With DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions)
                        .Actualiser_ToolStripButton.Enabled = True
                        .Nouveau_Dossier_ToolStripButton.Enabled = False
                        .Nouveau_Fichier_ToolStripButton.Enabled = False
                        .Proprietes_ToolStripButton.Enabled = True
                        .Reduire_Projet_ToolStripButton.Enabled = True
                        .TreeViewMultiSelect1.Enabled = True
                    End With

                    DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStripButton1.Enabled = True

                    ClassApplication.Status_Application(Nothing, True, 80)

                    With My.Settings.Projets_Recents
                        If Not .Contains(SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl") Then
                            If .Count >= 10 Then
                                .RemoveAt(9)
                                .Insert(0, SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                            ElseIf .Count = 0 Then
                                .Add(SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                            Else
                                .Insert(0, SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                            End If
                        Else
                            .Remove(SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                            .Insert(0, SOLUTION.Nom & "|" & Emplacement & "\" & Nom_Solution & "\" & Nom_Solution & ".szsl")
                        End If
                    End With

                    If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                        If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocPageDeDemarrage Then
                            With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocPageDeDemarrage).KryptonListBox2.Items
                                .Clear()
                                For Each recent As String In My.Settings.Projets_Recents
                                    If Not recent = Nothing AndAlso recent.Contains("|") Then .Add(recent.Split("|")(0))
                                Next
                            End With
                        End If
                    End If


                    .Text = "[" & SOLUTION.Nom & "] " & My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName


                    ClassApplication.Status_Application(Nothing, True, 100)

                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Solution_Chargé"), SOLUTION.Nom)))
                End With


                ' Ouverture des fichiers
                Dim files() As String = New String(-1) {}
                Dim Safefiles() As String = New String(-1) {}
                Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    For Each fi As String In proj.Doc_Ouverts
                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(proj.Emplacement, fi)) Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = My.Computer.FileSystem.CombinePath(proj.Emplacement, fi)
                            Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(proj.Emplacement, fi))
                            projects(projects.Length - 1) = proj
                        ElseIf fi = "PARAMETREDUPROJET" Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = "PARAMETREDUPROJET"
                            Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
                            projects(projects.Length - 1) = proj
                        ElseIf fi = "STATISTIQUESDUPROJET" Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = "STATISTIQUESDUPROJET"
                            Safefiles(Safefiles.Length - 1) = "STATISTIQUESDUPROJET"
                            projects(projects.Length - 1) = proj
                        End If
                    Next
                Next
                ClassProjet.Ouvrir_Document(files, Safefiles, projects)
            End If
        End If

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)

        Return True
    End Function

#End Region

#Region "Explorateur de solution"

    ' Permet de charger un projet dans l'Explorateur de projet
    ' Root = Node dans lequel doit être ajouté le projet
    ' Proj = Projet
    Shared Function Charger_Projet_Explorateur_Solutions(ByVal Root As System.Windows.Forms.TreeNode, ByVal proj As VelerSoftware.SZVB.Projet.Projet, Optional ByVal Allow_Bold_Font As Boolean = True) As System.Windows.Forms.TreeNode
        ' On créer le noeud du projet
        Dim RootNode As New System.Windows.Forms.TreeNode()
        With RootNode
            .Name = proj.Nom
            .Tag = proj.Nom
            .ToolTipText = proj.Emplacement
            .Text = proj.Nom
            If Allow_Bold_Font AndAlso SOLUTION.ProjetDemarrage = proj.Nom Then .NodeFont = New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Bold)

            If proj.Loaded Then  ' Si le projet a été chargé correctement
                If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                    .ImageIndex = 1
                    .SelectedImageIndex = 1
                Else
                    .ImageIndex = 2
                    .SelectedImageIndex = 2
                End If
                .Nodes.Add("factice")
                .Expand()
            Else
                .ImageIndex = 17
                .SelectedImageIndex = 17
                .NodeFont = New Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Italic)
                .Text = proj.Nom & RM.GetString("Project_Not_Loaded_Node_Text")
            End If
        End With

        If Not Root Is Nothing Then
            Root.Nodes.Add(RootNode)
            Root.Expand()

            ' On met à jour le nombre de projet dans le noeud de la solution
            Root.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Solution_Node_Text"), SOLUTION.Nom, SOLUTION.Projets.Count)
        End If

        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Projet_Chargé_Explorateur"), proj.Nom)))

        Return RootNode
    End Function

    ' Permet de récupérer la liste des répertoires et de les ajouter au treeview
    ' LeNod = TreeNode sélectionné
    ' Dossier = Dossier depuis lequel on doit récupérer la liste des dossiers
    Shared Function AjouterRepertoire(ByVal LeNod As TreeNode, ByVal Dossier As String, ByVal Nom As String, ByVal proj As VelerSoftware.SZVB.Projet.Projet, Optional ByVal Settings_And_Stats As Boolean = True)
        Dim ite As TreeNode = Nothing

        ' On ajout l'item PARAMETRE ici car c'est le premier item qui doit être affiché si l'on doit afficher les paramètres.
        If Settings_And_Stats AndAlso My.Computer.FileSystem.FileExists(Dossier & "\" & proj.Nom_Fichier_Projet) Then
            ite = New TreeNode
            With ite
                .Text = RM.GetString("Project_Settings")
                .ImageIndex = 15
                .SelectedImageIndex = 15
                .Tag = proj.Nom
            End With
            LeNod.Nodes.Add(ite)

            ite = New TreeNode
            With ite
                .Text = RM.GetString("Project_Statistics")
                .ImageIndex = 18
                .SelectedImageIndex = 18
                .Tag = proj.Nom
            End With
            LeNod.Nodes.Add(ite)

            If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                ite = New TreeNode
                With ite
                    .Text = RM.GetString("Application_Events")
                    .ImageIndex = 19
                    .SelectedImageIndex = 19
                    .Tag = proj.Nom
                End With
                LeNod.Nodes.Add(ite)
            End If
        End If

        ' On ajoute les dossier
        For Each chDir As String In IO.Directory.GetDirectories(Dossier)
            If My.Computer.FileSystem.DirectoryExists(chDir) AndAlso Not chDir = My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory) Then
                ite = New TreeNode
                With ite
                    .Text = IO.Path.GetFileName(chDir)
                    .ImageIndex = 3
                    .SelectedImageIndex = 4
                    .Tag = proj.Nom
                    .ToolTipText = chDir
                    ' S'il existe des dossiers ou fichier dans le répertoire, alors on ajoute une factice
                    If (IO.Directory.GetDirectories(chDir).Length > 0) OrElse (IO.Directory.GetFiles(chDir).Length > 0) Then .Nodes.Add("factice")
                End With

                LeNod.Nodes.Add(ite)
            End If
        Next
        Return Nothing
    End Function

    ' Permet de récupérer la liste des fichier et de les ajouter au treeview
    ' LeNod = TreeNode sélectionné
    ' Dossier = Dossier depuis lequel on doit récupérer la liste des fichiers
    Shared Function AjouterFichier(ByVal LeNod As TreeNode, ByVal Dossier As String, ByVal Nom As String, ByVal proj As VelerSoftware.SZVB.Projet.Projet)
        Dim ite As TreeNode = Nothing
        Dim fi As String

        ' Ajouts des fichiers
        For Each chfichier As String In IO.Directory.GetFiles(Dossier)
            If My.Computer.FileSystem.FileExists(chfichier) Then
                If My.Computer.FileSystem.FileExists(Dossier & "\" & proj.Nom_Fichier_Projet) AndAlso chfichier = Dossier & "\ApplicationEvents.szc" Then GoTo d

                ite = New TreeNode
                With ite
                    .Tag = proj.Nom
                    .ToolTipText = chfichier
                    fi = My.Computer.FileSystem.GetFileInfo(chfichier).Extension
                    Select Case fi
                        Case ".ico"
                            .ImageIndex = 16
                            .SelectedImageIndex = 16
                        Case ".bmp", ".jpg", ".jpeg"
                            .ImageIndex = 5
                            .SelectedImageIndex = 5
                        Case ".szw"
                            .ImageIndex = 7
                            .SelectedImageIndex = 7
                        Case ".szc"
                            .ImageIndex = 6
                            .SelectedImageIndex = 6
                        Case ".vb"
                            .ImageIndex = 14
                            .SelectedImageIndex = 14
                        Case ".szstat"
                            .ImageIndex = 20
                            .SelectedImageIndex = 20
                        Case ".resx"
                            GoTo d
                        Case ".ocx", ".dll", ".exe", ".lib"
                            .ImageIndex = 9
                            .SelectedImageIndex = 9
                        Case ".png", ".gif"
                            .ImageIndex = 10
                            .SelectedImageIndex = 10
                        Case ".txt", ".rtf"
                            .ImageIndex = 12
                            .SelectedImageIndex = 12
                        Case ".html", ".htm", ".php", ".css", ".asp", ".aspx", ".js", ".jsp"
                            .ImageIndex = 13
                            .SelectedImageIndex = 13
                        Case ".mdb"
                            .ImageIndex = 21
                            .SelectedImageIndex = 21
                        Case Else
                            .ImageIndex = 8
                            .SelectedImageIndex = 8
                    End Select
                    If Not IO.Path.GetFileName(chfichier) = proj.Nom_Fichier_Projet AndAlso (Not IO.Path.GetFileName(chfichier) = Nom & ".resx") AndAlso (Not IO.Path.GetFileName(chfichier) = Nom & ".resources") Then
                        .Text = IO.Path.GetFileName(chfichier)
                        LeNod.Nodes.Add(ite)
                    End If
                End With
            End If
d:
        Next
        Return Nothing
    End Function

#End Region

#Region "Document"

    ' Permet d'ouvrir un document dans l'espace de travail
    ' FileName() = Tableau dans lequel sont les fichiers à ouvrir
    ' SafeFileName() = Tableau dans lequel sont les noms (sans le chemin) des fichiers à ouvrir
    Shared Function Ouvrir_Document(ByVal FileName() As String, ByVal SafeFileName() As String, ByVal Projects() As VelerSoftware.SZVB.Projet.Projet, Optional ByVal Nom_A_Donner As String = Nothing) As String
        Dim tmp_NomFichier, tmp_NomCompletFichier As String
        Dim tmp_proj As VelerSoftware.SZVB.Projet.Projet
        Dim i_progress, i2_progress As Integer

        i_progress = FileName.Length
        i2_progress = 0
        For ite As Integer = 0 To FileName.Length - 1
            tmp_NomFichier = SafeFileName(ite)
            tmp_NomCompletFichier = FileName(ite)
            tmp_proj = Projects(ite)

            ClassApplication.Status_Application(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Status9"), tmp_NomCompletFichier))

            If tmp_NomCompletFichier = "PARAMETREDUPROJET" AndAlso tmp_NomFichier = "PARAMETREDUPROJET" Then
                If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert("Paramètres du projet " & tmp_proj.Nom) Then
                    Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Form1.Workspace_Nouveau_Paramètres_Du_Projet(tmp_proj)
                    If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                End If
                Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName("Paramètres du projet " & tmp_proj.Nom)
                If Not pag Is Nothing Then
                    Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                    Form1.KryptonDockableWorkspace1.ActiveCell = cell
                    cell.SelectedPage = pag
                End If
            ElseIf tmp_NomCompletFichier = "STATISTIQUESDUPROJET" AndAlso tmp_NomFichier = "STATISTIQUESDUPROJET" Then
                If My.Settings.Edition = ClassApplication.Edition.Free Then
                    ClassApplication.Should_Standard_Edition()
                Else
                    If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert("Statistiques du projet " & tmp_proj.Nom) Then
                        Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Form1.Workspace_Nouveau_Statistiques_Du_Projet(tmp_proj)
                        If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                    End If
                    Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName("Statistiques du projet " & tmp_proj.Nom)
                    If Not pag Is Nothing Then
                        Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                        Form1.KryptonDockableWorkspace1.ActiveCell = cell
                        cell.SelectedPage = pag
                    End If
                End If
            ElseIf tmp_NomCompletFichier = "APPLICATIONEVENTS" AndAlso tmp_NomFichier = "APPLICATIONEVENTS" Then
                If tmp_proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                    If Not My.Computer.FileSystem.FileExists(tmp_proj.Emplacement & "\ApplicationEvents.szc") AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Templates\Project\ApplicationEvents.szc") Then My.Computer.FileSystem.CopyFile(Application.StartupPath & "\Templates\Project\ApplicationEvents.szc", tmp_proj.Emplacement & "\ApplicationEvents.szc")

                    If My.Computer.FileSystem.FileExists(tmp_proj.Emplacement & "\ApplicationEvents.szc") Then
                        If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_proj.Emplacement & "\ApplicationEvents.szc") Then
                            Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                            doc = Form1.Workspace_Nouveau_Editeur_Fonctions(tmp_proj.Emplacement & "\ApplicationEvents.szc", tmp_proj, Nom_A_Donner)
                            If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                        End If
                        If ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_proj.Emplacement & "\ApplicationEvents.szc") Then
                            Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName(tmp_proj.Emplacement & "\ApplicationEvents.szc")
                            If Not pag Is Nothing Then
                                Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                                Form1.KryptonDockableWorkspace1.ActiveCell = cell
                                cell.SelectedPage = pag
                            End If
                        End If
                    End If
                End If
            Else
                If My.Computer.FileSystem.FileExists(tmp_NomCompletFichier) Then
                    ' FICHIER .SZW
                    If My.Computer.FileSystem.GetFileInfo(tmp_NomCompletFichier).Extension.ToLower = ".szw" AndAlso Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_NomCompletFichier) Then
                        Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                        doc = Form1.Workspace_Nouveau_Concepteur_Fenetre(tmp_NomCompletFichier, tmp_proj, Nom_A_Donner)
                        If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})

                        ' FICHIER .SZC
                    ElseIf My.Computer.FileSystem.GetFileInfo(tmp_NomCompletFichier).Extension.ToLower = ".szc" AndAlso Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_NomCompletFichier) Then
                        Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                        doc = Form1.Workspace_Nouveau_Editeur_Fonctions(tmp_NomCompletFichier, tmp_proj, Nom_A_Donner)
                        If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})

                        ' FICHIER .VB
                    ElseIf My.Computer.FileSystem.GetFileInfo(tmp_NomCompletFichier).Extension.ToLower = ".vb" AndAlso Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_NomCompletFichier) Then
                        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                            ClassApplication.Should_Professional_Edition()
                        Else
                            Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                            doc = Form1.Workspace_Nouveau_Editeur_Visual_Basic(tmp_NomCompletFichier, tmp_proj)
                            If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                        End If

                        ' FICHIER .SZSTAT
                    ElseIf My.Computer.FileSystem.GetFileInfo(tmp_NomCompletFichier).Extension.ToLower = ".szstat" AndAlso Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_NomCompletFichier) Then
                        If My.Settings.Edition = ClassApplication.Edition.Free Then
                            ClassApplication.Should_Standard_Edition()
                        Else
                            Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                            doc = Form1.Workspace_Nouveau_Statistiques_Fichier(tmp_NomCompletFichier)
                            If Not doc Is Nothing Then Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                        End If

                        ' FICHIER MDB (ACCESS)
                    ElseIf My.Computer.FileSystem.GetFileInfo(tmp_NomCompletFichier).Extension.ToLower = ".mdb" Then
                        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                            ClassApplication.Should_Education_Edition()
                        Else
                            Using frm As New AjouterBaseAccessExistante
                                frm.Nom_KryptonTextBox1.Text = tmp_NomCompletFichier
                                If frm.ShowDialog() = DialogResult.OK AndAlso My.Computer.FileSystem.FileExists(frm.Nom_KryptonTextBox1.Text) Then
                                    If Not DirectCast(Form1.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("Access").Nodes.ContainsKey("Access|" & frm.Nom_KryptonTextBox1.Text) Then
                                        Dim node As New System.Windows.Forms.TreeNode
                                        With node
                                            .Name = "Access|" & frm.Nom_KryptonTextBox1.Text
                                            .Text = My.Computer.FileSystem.GetName(frm.Nom_KryptonTextBox1.Text).Replace(My.Computer.FileSystem.GetFileInfo(frm.Nom_KryptonTextBox1.Text).Extension, Nothing)
                                            .ToolTipText = frm.Nom_KryptonTextBox1.Text
                                            .Tag = New VelerSoftware.SZVB.BasesDeDoonees.Access(frm.Nom_KryptonTextBox1.Text, frm.KryptonTextBox1.Text)
                                            .Nodes.Add("factise")
                                            .ImageIndex = 4
                                            .SelectedImageIndex = 4
                                        End With
                                        With DirectCast(Form1.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("Access")
                                            .Nodes.Add(node)
                                            .Expand()
                                        End With
                                    End If
                                End If
                            End Using
                        End If
                    End If

                    If ClassApplication.Determiner_Si_Document_Deja_Ouvert(tmp_NomCompletFichier) Then
                        Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName(tmp_NomCompletFichier)
                        If Not pag Is Nothing Then
                            Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                            Form1.KryptonDockableWorkspace1.ActiveCell = cell
                            cell.SelectedPage = pag
                        End If
                    End If
                End If
            End If

            ClassApplication.Status_Application(Nothing, True, (i2_progress / i_progress) * 100)
        Next

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return Nothing
    End Function


    Shared Function Creer_Nouveau_Document(ByVal SzTemplate As String, ByVal Emplacement_Destination As String, ByVal Nom_Projet As String, ByVal Tip As String, ByVal Nom_A_Donner As String) As Boolean
        Dim resultat, oki As Boolean
        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML   
        Dim files, inheritss, names As String
        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File
        Dim Tmp_SZC_File As VelerSoftware.SZVB.Projet.SZC_File

        files = Nothing
        inheritss = Nothing
        names = Nothing

        If My.Computer.FileSystem.FileExists(SzTemplate) AndAlso SOLUTION.GetProject(Nom_Projet) IsNot Nothing Then

            oki = False
            XmlRead = New Xml.XmlTextReader(SzTemplate)
            Do While XmlRead.Read()
                Select Case XmlRead.NodeType
                    Case Xml.XmlNodeType.Element
                        Select Case XmlRead.Name
                            Case "SZTemplate" ' Template
                                If XmlRead.GetAttribute("version") = "3.0" AndAlso XmlRead.GetAttribute("type") = Tip Then
                                    oki = True
                                    files = XmlRead.GetAttribute("file")
                                    inheritss = XmlRead.GetAttribute("inherits")
                                    names = XmlRead.GetAttribute("name_" & My.Settings.Langue)
                                End If
                            Case "Reference" ' Références
                                Dim ok As Boolean = False
                                For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(Nom_Projet).References
                                    If ref.FullName = XmlRead.GetAttribute("value") OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", XmlRead.GetAttribute("value")) OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", XmlRead.GetAttribute("value")) Then
                                        ok = True
                                        Exit For
                                    End If
                                Next
                                If Not ok Then ClassProjet.Ajouter_Reference_Projet(XmlRead.GetAttribute("value"), SOLUTION.GetProject(Nom_Projet), XmlRead.GetAttribute("copy"), XmlRead.GetAttribute("name"), XmlRead.GetAttribute("version"))
                        End Select
                End Select
            Loop
            XmlRead.Close()

            If oki AndAlso My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files)) Then
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Nouveau_Document"), Nom_A_Donner, Nom_Projet)))

                If Tip = "Window" Then
                    Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File(Nom_A_Donner)
                    Dim myFileStream As IO.Stream = IO.File.OpenRead(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files))

                    Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files))

                    Tmp_SZW_File.Nom = Nom_A_Donner
                    Tmp_SZW_File.WINDOWS.Namespaces(0).Name = Nom_Projet
                    If Not inheritss.Trim(" ") = Nothing Then
                        Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).BaseTypes.Clear()
                        Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).BaseTypes.Add(New CodeDom.CodeTypeReference(inheritss.Trim(" ")))
                    End If
                    Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).Name = Nom_A_Donner

                    myFileStream = IO.File.Create(Emplacement_Destination)
                    Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    serializer.Serialize(myFileStream, Tmp_SZW_File)
                    myFileStream.Close()
                    myFileStream.Dispose()

                    ' Ouverture du fichier
                    Dim filess() As String = New String(-1) {}
                    Dim Safefiles() As String = New String(-1) {}
                    Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
                    ReDim Preserve filess(filess.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    filess(filess.Length - 1) = Emplacement_Destination
                    Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(Emplacement_Destination)
                    projects(projects.Length - 1) = SOLUTION.GetProject(Nom_Projet)
                    ClassProjet.Ouvrir_Document(filess, Safefiles, projects, Nom_A_Donner)

                ElseIf Tip = "Class" Then
                    Tmp_SZC_File = New VelerSoftware.SZVB.Projet.SZC_File(Nom_A_Donner)
                    Dim myFileStream As IO.Stream = IO.File.OpenRead(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files))

                    Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files))

                    Tmp_SZC_File.Nom = Nom_A_Donner

                    myFileStream = IO.File.Create(Emplacement_Destination)
                    Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    serializer.Serialize(myFileStream, Tmp_SZC_File)
                    myFileStream.Close()
                    myFileStream.Dispose()

                    ' Ouverture du fichier
                    Dim filess() As String = New String(-1) {}
                    Dim Safefiles() As String = New String(-1) {}
                    Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
                    ReDim Preserve filess(filess.Length)
                    ReDim Preserve Safefiles(Safefiles.Length)
                    ReDim Preserve projects(projects.Length)
                    filess(filess.Length - 1) = Emplacement_Destination
                    Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(Emplacement_Destination)
                    projects(projects.Length - 1) = SOLUTION.GetProject(Nom_Projet)
                    ClassProjet.Ouvrir_Document(filess, Safefiles, projects, Nom_A_Donner)

                ElseIf Tip = "Code" Then
                    If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                        ClassApplication.Should_Professional_Edition()
                    Else
                        My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(SzTemplate) & "\", files), Emplacement_Destination, False)

                        ' Ouverture du fichier
                        Dim filess() As String = New String(-1) {}
                        Dim Safefiles() As String = New String(-1) {}
                        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
                        ReDim Preserve filess(filess.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        filess(filess.Length - 1) = Emplacement_Destination
                        Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(Emplacement_Destination)
                        projects(projects.Length - 1) = SOLUTION.GetProject(Nom_Projet)
                        ClassProjet.Ouvrir_Document(filess, Safefiles, projects, Nom_A_Donner)
                    End If


                End If

                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Nouveau_Document_Terminé"), Nom_A_Donner)))

                If Not SOLUTION.GetProject(Nom_Projet) Is Nothing Then SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
            End If

        End If


        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)

        Return resultat
    End Function

#End Region

End Class
