''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class GenerationComponent

    ' S'exécute lors de la génération de toute la solution
    Public Function Generer_Solution(ByVal executer As Boolean) As Boolean
        With Me
            Generation_Global_OK = True

            ' Initialisation de l'interface de génération
            .Initialisation_Generation()

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Solution_Debut"), SOLUTION.Nom)))

            If Not SOLUTION Is Nothing Then
                .Projet_KryptonWrapLabel.Text = SOLUTION.Nom
                .Progression_KryptonWrapLabel.Text = RM.GetString("Generation_Save_Solution")
                .Solution_Windows7ProgressBar.Maximum = SOLUTION.Projets.Count * 100
                .Projet_Windows7ProgressBar.Maximum = 100

                Application.DoEvents()

                ' Enregistrement de tout les documents
                Dim i As Integer = Form1.KryptonDockableWorkspace1.AllPages.Length
                Dim i2 As Integer = 0
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                    i2 += 1
                    If page.Controls.Count > 0 Then
                        If TypeOf page.Controls(0) Is DocConcepteurFenetre Then
                            DirectCast(page.Controls(0), DocConcepteurFenetre).Enregistrer(False)
                        ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions Then
                            DirectCast(page.Controls(0), DocEditeurFonctions).Enregistrer(False)
                        ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet Then
                            DirectCast(page.Controls(0), DocParametresDuProjet).Enregistrer()
                        ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic Then
                            DirectCast(page.Controls(0), DocEditeurVisualBasic).Enregistrer(False)
                        End If
                    End If
                    .Projet_Windows7ProgressBar.Value = (i2 / i) * 100
                    Application.DoEvents()
                Next

                .Projet_Windows7ProgressBar.Value = 100
                Application.DoEvents()

                ' Enregistrement de la solution
                ClassProjet.Enregistrer_Solution(True)

                .Projet_Windows7ProgressBar.Value = 0
                Application.DoEvents()

                If (Generation_Global_OK) AndAlso (Not .BackgroundWorker_Building.IsBusy) Then
                    ' Démarrage de la génération de la solution
                    .BackgroundWorker_Building.RunWorkerAsync("COMPILE_ALL_SOLUTION|" & executer.ToString)
                End If
            End If

            Return True
        End With
    End Function

    ' S'exécute lors de la génération d'un projet
    Public Function Generer_Projet_Base(ByVal Nom_Projet As String, ByVal Should_Save_Project As Boolean) As Boolean
        With Me
            Generation_Global_OK = True

            ' Initialisation de l'interface de génération
            .Initialisation_Generation()

            If Not SOLUTION Is Nothing Then
                .Projet_KryptonWrapLabel.Text = Nom_Projet
                .Progression_KryptonWrapLabel.Text = RM.GetString("Generation_Save_Project")

                .Solution_Windows7ProgressBar.Maximum = 100
                .Projet_Windows7ProgressBar.Maximum = 100

                Application.DoEvents()

                ' Enregistrement de tout les documents
                Dim i As Integer = Form1.KryptonDockableWorkspace1.AllPages.Length
                Dim i2 As Integer = 0
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                    i2 += 1
                    If page.Controls.Count > 0 Then
                        If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso DirectCast(page.Controls(0), DocConcepteurFenetre).Nom_Projet = Nom_Projet Then
                            DirectCast(page.Controls(0), DocConcepteurFenetre).Enregistrer(False)
                        ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(page.Controls(0), DocEditeurFonctions).Nom_Projet = Nom_Projet Then
                            DirectCast(page.Controls(0), DocEditeurFonctions).Enregistrer(False)
                        ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = Nom_Projet Then
                            DirectCast(page.Controls(0), DocParametresDuProjet).Enregistrer()
                        ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic AndAlso DirectCast(page.Controls(0), DocEditeurVisualBasic).Nom_Projet = Nom_Projet Then
                            DirectCast(page.Controls(0), DocEditeurVisualBasic).Enregistrer(False)
                        End If
                    End If
                    .Projet_Windows7ProgressBar.Value = (i2 / i) * 100
                    Application.DoEvents()
                Next

                .Projet_Windows7ProgressBar.Value = 100
                Application.DoEvents()

                ' Enregistrement du projet
                ClassProjet.Enregistrer_Projet(Nom_Projet)

                .Projet_Windows7ProgressBar.Value = 0
                Application.DoEvents()

                If Not .BackgroundWorker_Building.IsBusy Then
                    ' Démarrage de la génération du projet
                    .BackgroundWorker_Building.RunWorkerAsync(Nom_Projet)
                End If
            End If

            Return True
        End With
    End Function

    ' Annulation de la génération
    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        With Me.BackgroundWorker_Building
            If .IsBusy Then .CancelAsync()
        End With
        With Me.BackgroundWorker_Obfuscation
            If .IsBusy Then .CancelAsync()
        End With

        With My.Computer.FileSystem
            If .DirectoryExists(Application.StartupPath & "\Temp\Building") Then
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.*", System.IO.SearchOption.AllDirectories)
                    .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Next
            Else
                .CreateDirectory(Application.StartupPath & "\Temp\Building")
            End If
        End With

        With My.Computer.FileSystem
            If .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom) Then
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, "*.*", System.IO.SearchOption.AllDirectories)
                    .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Next
                .DeleteDirectory(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            ElseIf .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator") Then
                .CreateDirectory(Application.StartupPath & "\Temp\Obfuscator")
            End If
        End With

        ' Mise à jour de l'interface de génération
        Me.Finalisation_Generation()
    End Sub

    ' Initialisation de l'interface
    Private Sub Initialisation_Generation()
        If Generation_En_Cours_Type = generation_type.Release Then
            Status_SZ = statu.Generation_En_Cours_Release
        Else
            Status_SZ = statu.Generation_En_Cours_Debug
        End If

        Log_Generation.Log.Clear()

        Select Case Generation_En_Cours_Type
            Case generation_type.Release
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Mode_Normal"))))
            Case generation_type.Debug
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Mode_Debug"))))
        End Select
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Obfuscation"), Obfuscation)))


        With Form1
            ' Mise à jour de la fenêtre principale
            .SuspendLayout()
            .Info_Bar1.Hide()
            .KryptonRibbon1.Visible = False
            .KryptonRibbon1.AllowFormIntegrate = False
            .KryptonPanel1.Visible = False
            .StatusStrip1.Visible = False
            DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ListView1.Items.Clear()
            ResError_ListViewItem = New Generic.List(Of ListViewItem)
        End With

        With Me
            ' Initialisation des barres de progression

            With .Solution_Windows7ProgressBar
                .ShowInTaskbar = True
                .State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
                .Value = 0
            End With
            'Me.Windows7ProgressBar1.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error

            With .Projet_Windows7ProgressBar
                .State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
                .Value = 0
            End With

            .Progression_KryptonWrapLabel.Text = Nothing


            ' Donne le focus
            .Visible = True
            .KryptonButton1.Enabled = True
            .KryptonButton1.Focus()

        End With

        Form1.ResumeLayout()
        Application.DoEvents()
    End Sub

    ' Effacement de l'interface de génération
    Private Sub Finalisation_Generation()
        With Me
            If .BackgroundWorker_Building.IsBusy Then .BackgroundWorker_Building.CancelAsync()


            'If Not WorkflowDesigne_ElementHost Is Nothing Then WorkflowDesigne_ElementHost.Dispose()
            If Not ReWriter Is Nothing Then ReWriter.Dispose()
            If Not Tmp_SZW_File_Tmp Is Nothing Then Tmp_SZW_File_Tmp.Dispose()
            If Not Tmp_SZC_File_Tmp Is Nothing Then Tmp_SZC_File_Tmp.Dispose()

            If Not List_SZC_File Is Nothing Then
                For Each ite As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
                    ite.Dispose()
                Next
                List_SZC_File.Clear()
            End If
            If Not List_SZW_File Is Nothing Then
                For Each ite As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
                    ite.Dispose()
                Next
                List_SZW_File.Clear()
            End If
            If Not List_File_Name Is Nothing Then List_File_Name.Clear()
            If Not List_VBFile Is Nothing Then List_VBFile.Clear()

            FunctionWorkflow = Nothing
            'WorkflowDesigne = Nothing
            'WorkflowDesigne_Txt = Nothing
            'WorkflowDesigne_ElementHost = Nothing
            PROJET = Nothing
            CodeDom_CCu = Nothing
            Code_Module_Variables = Nothing
            Code_MySettings = Nothing
            Code_VB_Files = Nothing
            CodeDom_CodeObject = Nothing
            CodeDom_MY_NameSpace = Nothing
            CodeDom_MyApplication_Class = Nothing
            CodeDom_MyApplication_Constructor = Nothing
            CodeDom_MyApplication_OnCreateMainForm_Method = Nothing
            CodeDom_MyApplication_OnCreateSplashScreen_Method = Nothing
            CodeDom_NameSpace = Nothing
            CodeDom_Resources_CCu = Nothing
            CodeDom_Sub_Main = Nothing
            CodeDom_SZW_SZC_Class = Nothing
            List_SZW_File = Nothing
            List_SZC_File = Nothing
            List_File_Name = Nothing
            List_VBFile = Nothing
            Tmp_SZW_File = Nothing
            Tmp_SZC_File = Nothing
            Tmp_SZW_File_Tmp = Nothing
            Tmp_SZC_File_Tmp = Nothing
            i_progress = 0
            i2_progress = 0
            i_function = 0
            i_remove = 0
            RrX = Nothing
            RrEn = Nothing
            ReWriter = Nothing
            para = Nothing
            ResError = Nothing
            Nom_Form_Demarrage = Nothing

            Generation_Code = False


            Form1.SuspendLayout()
            With .Solution_Windows7ProgressBar
                .ShowInTaskbar = False
                .State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
                .Value = 0
            End With

            With .Projet_Windows7ProgressBar
                .State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
                .Value = 0
            End With

            .Projet_KryptonWrapLabel.Text = Nothing
            .Progression_KryptonWrapLabel.Text = Nothing

            With Form1
                .KryptonPanel1.Visible = True
                .StatusStrip1.Visible = My.Settings.Barre_Etat
                .KryptonRibbon1.Visible = True
                Me.Visible = False
                .KryptonRibbon1.AllowFormIntegrate = My.Settings.Activer_Aero
                .ResumeLayout()


                Status_SZ = statu.Normal

                .Log_Generation_OnLogChanged(Nothing, Nothing)
            End With

        End With
    End Sub

    ' Timer pour la fin de la génération
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Timer1.Stop()

        If Generation_Code AndAlso (Not PROJET Is Nothing) AndAlso PROJET.Loaded AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb") Then
            ' Ouverture du fichier
            Dim files() As String = New String(-1) {}
            Dim Safefiles() As String = New String(-1) {}
            Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

            ReDim Preserve files(files.Length)
            ReDim Preserve Safefiles(Safefiles.Length)
            ReDim Preserve projects(projects.Length)
            files(files.Length - 1) = Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb"
            Safefiles(Safefiles.Length - 1) = PROJET.Nom & ".vb"
            projects(projects.Length - 1) = PROJET

            ClassProjet.Ouvrir_Document(files, Safefiles, projects)
            files = New String(-1) {}
            Safefiles = New String(-1) {}
            projects = New VelerSoftware.SZVB.Projet.Projet(-1) {}
        End If

        With My.Computer.FileSystem
            If .DirectoryExists(Application.StartupPath & "\Temp\Building") Then
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.*", System.IO.SearchOption.AllDirectories)
                    .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Next
            Else
                .CreateDirectory(Application.StartupPath & "\Temp\Building")
            End If

            If .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom) Then
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, "*.*", System.IO.SearchOption.AllDirectories)
                    .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Next
                .DeleteDirectory(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            ElseIf .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator") Then
                .CreateDirectory(Application.StartupPath & "\Temp\Obfuscator")
            End If
        End With

        If Not Generation_Code Then
            ' Recharger les statistiques
            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = PROJET.Nom Then DirectCast(page.Controls(0), DocStatistiques).Charger(True)
            Next

            With DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ListView1.Items
                .Clear()
                For Each ite As ListViewItem In ResError_ListViewItem
                    .Add(ite)
                Next
            End With
        End If

        Me.Finalisation_Generation()

        If Not Generation_Code Then
            If ResError_ListViewItem.Count > 0 Then
                If My.Settings.Autoriser_Envoyer_Informations AndAlso My.Settings.Autoriser_Erreur_Generation AndAlso Not Form1.SZ_Send_Informations_BackgroundWorker.IsBusy Then Form1.SZ_Send_Informations_BackgroundWorker.RunWorkerAsync(New DictionaryEntry("bluid_errors", SOLUTION.GetProject(ResError_ListViewItem(0).Text).RapportGeneration.ToString))

                If Not Form1.Box_Erreur_Generation Is Nothing Then
                    If TypeOf Form1.Box_Erreur_Generation.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                        DirectCast(Form1.Box_Erreur_Generation.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Form1.Box_Erreur_Generation
                    ElseIf TypeOf Form1.Box_Erreur_Generation.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                        Form1.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Erreurs de génération")
                    End If
                End If
                If Not Form1.Info_Bar1.Visible Then Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Errors, String.Format(RM.GetString("InfoBar_9_Description"), ResError_ListViewItem(0).Text), RM.GetString("InfoBar_9_Button"), True, "Erreur_Generation_Projet", Nothing)
            End If
            With DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration)
                If .ListView1.Items.Count > 0 Then
                    .ToolStripButton1.Enabled = True
                End If
            End With
        End If

        If Generation_Global_OK AndAlso Generation_En_Cours_Type = generation_type.Debug Then Form1.Lancer_Debugger()

        Form1.FinGeneration()
    End Sub










#Region "GENERER"

    ' Lors de la génération d'un projet
    Private Sub BackgroundWorker_Building_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Building.DoWork
        Dim Worker As System.ComponentModel.BackgroundWorker = sender

        ' Instanciation d'un objet StopWatch 
        Dim monStopWatch As New Stopwatch
        ' Déclenchement du "chronomètre"
        monStopWatch.Start()

        ' GENERER SOLUTION
        If TypeOf e.Argument Is String AndAlso ((CStr(e.Argument) = "COMPILE_ALL_SOLUTION|True") OrElse (CStr(e.Argument) = "COMPILE_ALL_SOLUTION|False")) Then
            ' Génération de tout les projets selon l'ordre de génération
            Dim i As Integer = SOLUTION.GenerationOrder.Count
            Dim i2 As Integer = 0
            For Each projet_name As String In SOLUTION.GenerationOrder
                i2 += 1
                If (Not e.Cancel) AndAlso (Generation_Global_OK) Then
                    If Not Me.Generer_Projet(projet_name, i2, Worker) Then
                        Generation_Global_OK = False
                        e.Cancel = True
                    Else
                        Worker.ReportProgress(100, New GenerationProgress(projet_name, RM.GetString("Generation_Project_Finish"), i2 * 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
                    End If
                End If
            Next

            If Generation_Global_OK AndAlso (Not e.Cancel) AndAlso CStr(e.Argument) = "COMPILE_ALL_SOLUTION|True" Then
                Dim can_launch As Boolean = True
                For Each a As System.Diagnostics.Process In Process.GetProcesses
                    If a.ProcessName = SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom Then can_launch = False : Exit For
                Next
                If can_launch AndAlso Not Generation_Code AndAlso My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")) Then Process.Start(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
            End If

            ' GENERER PROJET SPECIFIER
        ElseIf TypeOf e.Argument Is String Then
            ' Génération du projet
            If Not Me.Generer_Projet(CStr(e.Argument), 1, Worker) Then
                Generation_Global_OK = False
                e.Cancel = True
            End If
            Worker.ReportProgress(100, New GenerationProgress(CStr(e.Argument).Split("|")(0), RM.GetString("Generation_Project_Finish"), 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        End If

        ' Arrêt du "chronomètre" 
        monStopWatch.Stop()
        ' Le temps écoulé peut être récupéré très facilement avec un membre de StopWatch, 
        ' de la façon suivante. Le résultat est exprimé en millisecondes 
        e.Result = monStopWatch.Elapsed.Minutes & "min " & monStopWatch.Elapsed.Seconds & "sec " & monStopWatch.Elapsed.Milliseconds & "milli sec "
    End Sub

    ' Lors du changement de la progression
    Private Sub BackgroundWorker_Building_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Building.ProgressChanged
        With Me
            ' Mise à jour des barres de progressions
            If DirectCast(e.UserState, GenerationProgress).Status_Barre_Progression = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error Then
                .Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error
                .Projet_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error
            ElseIf DirectCast(e.UserState, GenerationProgress).Status_Barre_Progression = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause Then
                .Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause
                .Projet_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause
            End If
            .Solution_Windows7ProgressBar.Value = DirectCast(e.UserState, GenerationProgress).Solution_Percent

            .Projet_Windows7ProgressBar.Value = e.ProgressPercentage

            If Not .Projet_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet Then .Projet_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet
            If Not .Progression_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Texte Then .Progression_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Texte

            .KryptonButton1.Enabled = DirectCast(e.UserState, GenerationProgress).BoutonAnnuler

        End With
    End Sub

    ' Lors de la fin de la génération
    Private Sub BackgroundWorker_Building_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Building.RunWorkerCompleted
        With Me
            .KryptonButton1.Enabled = True

            If Not e.Cancelled Then Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Temp"), e.Result)))

            If Obfuscation AndAlso Not e.Cancelled AndAlso Not .BackgroundWorker_Obfuscation.IsBusy Then  ' Si on doit obfusquer et que la génération c'est bien passé
                .Solution_Windows7ProgressBar.Maximum = 100
                .BackgroundWorker_Obfuscation.RunWorkerAsync()

            Else ' Sinon, on termine la génération   
                .KryptonButton1.Enabled = False
                .Timer1.Enabled = True
                .Timer1.Start()
            End If

        End With
    End Sub


    Friend Generation_Global_OK, Generation_Code, Obfuscation, Verification_reference_ok, ok_for_add_event As Boolean

    Private FunctionWorkflow As Object

    Private PROJET As VelerSoftware.SZVB.Projet.Projet

    Private CodeDom_CCu, CodeDom_Resources_CCu, CodeDom_CCu_Exporation As CodeDom.CodeCompileUnit
    Private CodeDom_NameSpace, CodeDom_MY_NameSpace As CodeDom.CodeNamespace
    Private CodeDom_MyApplication_Class, CodeDom_SZW_SZC_Class As CodeDom.CodeTypeDeclaration
    Private CodeDom_MyApplication_Constructor As CodeDom.CodeConstructor
    Private CodeDom_MyApplication_OnCreateMainForm_Method, CodeDom_MyApplication_OnCreateSplashScreen_Method As CodeDom.CodeMemberMethod
    Private CodeDom_Sub_Main As CodeDom.CodeEntryPointMethod
    Private CodeDom_CodeObject As CodeDom.CodeObject

    Private Code_Module_Variables, Code_MySettings, Code_VB_Files As New System.Text.StringBuilder
    Private sourceWriter As New IO.StringWriter

    Private List_SZW_File As New Generic.List(Of VelerSoftware.SZVB.Projet.SZW_File_Tmp)
    Private List_SZC_File As New Generic.List(Of VelerSoftware.SZVB.Projet.SZC_File_Tmp)
    Private List_File_Name As New Generic.List(Of String)
    Private List_VBFile As New Generic.List(Of String)
    Private Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File
    Private Tmp_SZC_File As VelerSoftware.SZVB.Projet.SZC_File
    Private Tmp_SZW_File_Tmp As VelerSoftware.SZVB.Projet.SZW_File_Tmp
    Private Tmp_SZC_File_Tmp As VelerSoftware.SZVB.Projet.SZC_File_Tmp

    Private i_progress, i2_progress, i_function, i_remove As Integer

    Private RrX As System.Resources.ResXResourceReader
    Private RrEn As IDictionaryEnumerator
    Private ReWriter As Resources.IResourceWriter


    Private para As CodeDom.Compiler.CompilerParameters
    Private ResError As CodeDom.Compiler.CompilerResults
    Private ResError_ListViewItem As New Generic.List(Of ListViewItem)

    Private Nom_Form_Demarrage As String


    Private Function Generer_Projet(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker) As Boolean
        Worker.ReportProgress(0, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Initialize"), ((NumeroProjet - 1) * 100) + 0, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))

        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Debut"), Nom_Projet)))


        ' Déclarations 
        Dim err As VelerSoftware.SZVB.Projet.Erreur
        Dim itelistview As ListViewItem

        If ReWriter IsNot Nothing Then ReWriter.Dispose()
        If Tmp_SZW_File_Tmp IsNot Nothing Then Tmp_SZW_File_Tmp.Dispose()
        If Tmp_SZC_File_Tmp IsNot Nothing Then Tmp_SZC_File_Tmp.Dispose()

        If List_SZC_File IsNot Nothing Then
            For Each ite As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
                ite.Dispose()
            Next
            List_SZC_File.Clear()
        End If
        If List_SZW_File IsNot Nothing Then
            For Each ite As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
                ite.Dispose()
            Next
            List_SZW_File.Clear()
        End If
        If List_File_Name IsNot Nothing Then List_File_Name.Clear()
        If List_VBFile IsNot Nothing Then List_VBFile.Clear()

        PROJET = Nothing
        CodeDom_CCu = Nothing
        Code_Module_Variables = New System.Text.StringBuilder
        Code_MySettings = New System.Text.StringBuilder
        Code_VB_Files = New System.Text.StringBuilder
        CodeDom_CodeObject = Nothing
        CodeDom_MY_NameSpace = Nothing
        CodeDom_MyApplication_Class = Nothing
        CodeDom_MyApplication_Constructor = Nothing
        CodeDom_MyApplication_OnCreateMainForm_Method = Nothing
        CodeDom_MyApplication_OnCreateSplashScreen_Method = Nothing
        CodeDom_NameSpace = Nothing
        CodeDom_Resources_CCu = Nothing
        CodeDom_Sub_Main = Nothing
        CodeDom_SZW_SZC_Class = Nothing
        List_SZW_File = New Generic.List(Of VelerSoftware.SZVB.Projet.SZW_File_Tmp)
        List_SZC_File = New Generic.List(Of VelerSoftware.SZVB.Projet.SZC_File_Tmp)
        List_File_Name = New Generic.List(Of String)
        List_VBFile = New Generic.List(Of String)
        Tmp_SZW_File = Nothing
        Tmp_SZC_File = Nothing
        Tmp_SZW_File_Tmp = Nothing
        Tmp_SZC_File_Tmp = Nothing
        i_progress = 0
        i2_progress = 0
        i_function = 0
        i_remove = 0
        RrX = Nothing
        RrEn = Nothing
        ReWriter = Nothing
        para = Nothing
        ResError = Nothing
        Nom_Form_Demarrage = Nothing


        PROJET = SOLUTION.GetProject(Nom_Projet)
        Generation_En_Cours_Projet = PROJET
        If PROJET IsNot Nothing AndAlso PROJET.Loaded Then

            With My.Computer.FileSystem
                ' Création du dossier de génération
                If Not Generation_Code AndAlso Not .DirectoryExists(.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory)) Then
                    Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Creation_Dossier"), (.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory)))))
                    .CreateDirectory(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory))
                End If


                If .DirectoryExists(Application.StartupPath & "\Temp\Building") Then
                    Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Suppression_Temp"))))
                    For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.*", System.IO.SearchOption.AllDirectories)
                        .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    Next
                Else
                    .CreateDirectory(Application.StartupPath & "\Temp\Building")
                End If
            End With

            ' Initialisation de CodeDom
            Initialisation_CodeDom()


            Worker.ReportProgress(5, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Load"), ((NumeroProjet - 1) * 100) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


            i_progress = System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories).Length + System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories).Length
            i2_progress = 0


            ' Chargement des Fichiers SZW
            Chargement_Fichiers_SZW(Nom_Projet, NumeroProjet, Worker)



            If Not Worker.CancellationPending Then



                ' Chargement des Fichiers SZC  
                Chargement_Fichiers_SZC(Nom_Projet, NumeroProjet, Worker)


                If Not Worker.CancellationPending Then


                    Worker.ReportProgress(25, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Code"), ((NumeroProjet - 1) * 100) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    i_progress = List_SZW_File.Count + List_SZC_File.Count
                    For Each ite As VelerSoftware.SZVB.Projet.SZW_File In List_SZW_File
                        i_progress += ite.Functions.Count
                    Next
                    For Each ite As VelerSoftware.SZVB.Projet.SZC_File In List_SZC_File
                        i_progress += ite.Functions.Count
                    Next
                    i2_progress = 0

                    ' Fichier SZW
                    Generer_Code_SZW(Nom_Projet, NumeroProjet, Worker)

                    ' Fichier SZC
                    Generer_Code_SZC(Nom_Projet, NumeroProjet, Worker)


                    If Not Worker.CancellationPending Then




                        i_progress = PROJET.Fichiers_VBNet.Count + List_VBFile.Count
                        i2_progress = 0
                        Worker.ReportProgress(75, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_VBFile"), ((NumeroProjet - 1) * 100) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))




                        ' Fichier .VB incluent 
                        Chargement_Fichiers_VB(Nom_Projet, NumeroProjet, Worker)



                        i_progress = System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.resx", System.IO.SearchOption.AllDirectories).Length
                        i2_progress = 0
                        Worker.ReportProgress(80, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Resx"), ((NumeroProjet - 1) * 100) + 80, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))





                        ' Génération des fichiers ressources
                        Generer_Ressources_Et_Code(Nom_Projet, NumeroProjet, Worker)



                        i_progress = PROJET.Variables.Count + List_SZW_File.Count + List_SZC_File.Count
                        i2_progress = 0
                        Worker.ReportProgress(85, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Variable"), ((NumeroProjet - 1) * 100) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))





                        ' MODULE VARIABLES
                        Generer_Module_Variables(Nom_Projet, NumeroProjet, Worker)




                        Worker.ReportProgress(90, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Compiler"), ((NumeroProjet - 1) * 100) + 90, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))




                        If Not Generation_Code Then
                            ' COMPILATION
                            Configuration_Compilateur()
                        End If


                        Worker.ReportProgress(95, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Generating"), ((NumeroProjet - 1) * 100) + 95, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, False))


                        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_VB"))))

                        sourceWriter = New IO.StringWriter()
                        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromCompileUnit(CodeDom_CCu, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
                        sourceWriter.Close()
                        PROJET.VBGénéréParGénération = sourceWriter.ToString.Replace(ChrW(34) & "My.Resources" & ChrW(34), ChrW(34) & PROJET.Nom & ".Resources" & ChrW(34)) & Environment.NewLine & Code_MySettings.ToString & Environment.NewLine & Code_VB_Files.ToString & Environment.NewLine & Code_Module_Variables.ToString
                        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb", PROJET.VBGénéréParGénération, False, System.Text.Encoding.UTF8)


                        If Not Generation_Code Then
                            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Compile"))))

                            ' COMPILATION DU FICHIER DE SORTIE
                            ResError = CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").CompileAssemblyFromFile(para, Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb")


                            If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\" & PROJET.Nom & ".resx") Then My.Computer.FileSystem.DeleteFile(PROJET.Emplacement & "\" & PROJET.Nom & ".resx", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                            If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\" & PROJET.Nom & ".My.Resources.resources") Then My.Computer.FileSystem.DeleteFile(PROJET.Emplacement & "\" & PROJET.Nom & ".My.Resources.resources", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                            If ResError.Errors.Count > 0 Then
                                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Compile_Echec"))))

                                Generation_Global_OK = False

                                Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Error"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Error, True))
                                If Not Obfuscation Then
                                    ' Statistiques
                                    Dim stat_ok As Boolean
                                    For Each stat As VelerSoftware.SZVB.Projet.Statistique In PROJET.Statistiques
                                        If stat.TypeValue = VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail AndAlso stat.XValue = Date.Today.ToOADate Then
                                            stat.YValue += 1
                                            stat_ok = True
                                            Exit For
                                        End If
                                    Next
                                    If Not stat_ok Then PROJET.Statistiques.Add(New VelerSoftware.SZVB.Projet.Statistique(Date.Today.ToOADate, 1, VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail))
                                End If
                            Else
                                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Compile_Succès"))))

                                PROJET.ShouldCompileRelease = False

                                Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Finish"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
                                If Not Obfuscation Then
                                    ' Statistiques
                                    Dim stat_ok As Boolean
                                    For Each stat As VelerSoftware.SZVB.Projet.Statistique In PROJET.Statistiques
                                        If stat.TypeValue = VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess AndAlso stat.XValue = Date.Today.ToOADate Then
                                            stat.YValue += 1
                                            stat_ok = True
                                            Exit For
                                        End If
                                    Next
                                    If Not stat_ok Then PROJET.Statistiques.Add(New VelerSoftware.SZVB.Projet.Statistique(Date.Today.ToOADate, 1, VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess))
                                End If
                            End If

                            'For Each strrr As String In ResError.Output
                            'MsgBox(strrr)                
                            'Next


                            PROJET.RapportGeneration = New System.Text.StringBuilder()
                            With PROJET.RapportGeneration
                                For Each strrr As System.CodeDom.Compiler.CompilerError In ResError.Errors
                                    With Log_Generation.Log
                                        .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, ""))
                                        .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, "Line : " & strrr.Line & ", Column : " & strrr.Column & ", Error : " & strrr.ErrorNumber & ", File name : " & strrr.FileName & Environment.NewLine & "Description : " & strrr.ErrorText))
                                    End With
                                    .AppendLine("Error === Line " & strrr.Line & ", Column " & strrr.Column & ", Error " & strrr.ErrorNumber)
                                    .AppendLine("Description : " & strrr.ErrorText)
                                    .AppendLine()
                                    .AppendLine()
                                Next
                                If ResError.Errors.Count > 0 AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb") Then
                                    .AppendLine()
                                    .AppendLine()
                                    .AppendLine()
                                    .AppendLine()
                                    .Append(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb", System.Text.Encoding.UTF8))
                                End If
                            End With


                            For Each strrr As System.CodeDom.Compiler.CompilerError In ResError.Errors
                                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb") Then
                                    Dim lin As String = Nothing
                                    Using l_textFile As New IO.StreamReader(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & ".vb")
                                        Dim i As Integer = 0
                                        While Not l_textFile.EndOfStream
                                            i = i + 1
                                            If i = strrr.Line - 1 Then lin = l_textFile.ReadLine
                                            l_textFile.ReadLine()
                                        End While
                                        l_textFile.Close()
                                    End Using

                                    If Not lin = Nothing Then
                                        lin = lin.TrimStart(" ")

                                        err = New VelerSoftware.SZVB.Projet.Erreur
                                        itelistview = New System.Windows.Forms.ListViewItem

                                        If lin.StartsWith("'project:", StringComparison.OrdinalIgnoreCase) Then
                                            With err
                                                .ActionId = lin.Split("|")(3).Replace("actionid:", Nothing)
                                                .ActionName = lin.Split("|")(4).Replace("actionname:", Nothing)
                                                .ErrorNumber = strrr.ErrorNumber
                                                .ErrorText = strrr.ErrorText
                                                .ErrorLine = strrr.Line
                                                .ErrorColumn = strrr.Column
                                                .FileName = lin.Split("|")(2).Replace("file:", Nothing)
                                                .FunctionName = lin.Split("|")(1).Replace("function:", Nothing)
                                                .ProjectName = lin.Split("|")(0).Replace("'project:", Nothing)
                                                .Type = VelerSoftware.SZVB.Projet.Erreur.ErrorType.Building
                                            End With
                                        Else
                                            With err
                                                .ActionId = "{Unknow}"
                                                .ActionName = "Line " & strrr.Line
                                                .ErrorNumber = strrr.ErrorNumber
                                                .ErrorText = strrr.ErrorText
                                                .ErrorLine = strrr.Line
                                                .ErrorColumn = strrr.Column
                                                .FileName = RM.GetString("Unknow")
                                                .FunctionName = RM.GetString("Unknow")
                                                .ProjectName = My.Computer.FileSystem.GetFileInfo(strrr.FileName).Name.Replace(".vb", Nothing)
                                                .Type = VelerSoftware.SZVB.Projet.Erreur.ErrorType.Building
                                            End With
                                        End If

                                        With itelistview
                                            .Name = err.ActionId
                                            .Text = err.ProjectName
                                            .SubItems.Add(My.Computer.FileSystem.GetName(err.FileName))
                                            .SubItems.Add(err.FunctionName)
                                            .SubItems.Add(err.ActionName)
                                            .SubItems.Add(strrr.ErrorText)
                                            .Tag = err
                                        End With

                                        ResError_ListViewItem.Add(itelistview)
                                    End If
                                End If
                            Next

                            If ResError.Errors.Count > 0 Then Return False

                        Else
                            Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Finish"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
                            Return True
                        End If

                    Else
                        Return False ' génération annulé
                    End If

                Else
                    Return False ' génération annulé
                End If
            Else
                Return False  ' génération annulé
            End If

        Else
            Return True
            Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Ignore"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        End If

        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, Environment.NewLine & Environment.NewLine))

        Generation_En_Cours_Projet = Nothing

        Return True
    End Function

    Private Sub Initialisation_CodeDom()
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Initialisation_CodeDom"))))

        CodeDom_CCu = New CodeDom.CodeCompileUnit
        CodeDom_Resources_CCu = New CodeDom.CodeCompileUnit


        CodeDom_MyApplication_OnCreateMainForm_Method = New CodeDom.CodeMemberMethod()
        CodeDom_MyApplication_OnCreateSplashScreen_Method = New CodeDom.CodeMemberMethod()

        ' Ajout des Attributs de l'Assembly
        With CodeDom_CCu.AssemblyCustomAttributes
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyTitleAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Title))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyVersionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_AssemblyVersion))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyCopyrightAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Copyright))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyDescriptionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Description))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyFileVersionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_FileVersion))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Runtime.InteropServices.GuidAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Guid))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyTrademarkAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Mark))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyProductAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Product))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyCompanyAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Socity))}))
            .Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Runtime.InteropServices.ComVisibleAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(False))}))
        End With

        ' Création du NameSpace
        CodeDom_NameSpace = New CodeDom.CodeNamespace(PROJET.Nom.Replace(" ", "_").Replace("-", "_").Replace(":", "_").Replace("/", "_").Replace(".", "_").Replace(",", "_").Replace("&", "_"))
        With CodeDom_NameSpace.Comments
            .Add(New CodeDom.CodeCommentStatement("----------------------------------------------------------------------", False))
            .Add(New CodeDom.CodeCommentStatement("This code was generated by " & My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition) & " (" & My.Application.Info.Version.ToString & ")", False))
            .Add(New CodeDom.CodeCommentStatement("The " & DateTime.Now.ToLongDateString & " at " & DateTime.Now.ToLongTimeString & "", False))
            .Add(New CodeDom.CodeCommentStatement("----------------------------------------------------------------------", False))
        End With
        With CodeDom_NameSpace.Imports
            .Add(New CodeDom.CodeNamespaceImport("System"))
            .Add(New CodeDom.CodeNamespaceImport("System.Drawing"))
            .Add(New CodeDom.CodeNamespaceImport("System.Windows.Forms"))
            .Add(New CodeDom.CodeNamespaceImport("Microsoft.VisualBasic"))
        End With
        CodeDom_CCu.Namespaces.Add(CodeDom_NameSpace)

        ' Création du NameSpace "My"
        If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
            CodeDom_MY_NameSpace = New CodeDom.CodeNamespace(PROJET.Nom & ".My")
            CodeDom_CCu.Namespaces.Add(CodeDom_MY_NameSpace)
            CodeDom_MyApplication_Constructor = New CodeDom.CodeConstructor()


            ' Création de la Class "MyApplication"
            CodeDom_MyApplication_Class = New CodeDom.CodeTypeDeclaration("MyApplication")
            With CodeDom_MyApplication_Class
                .IsPartial = True
                .TypeAttributes = CodeDom.MemberAttributes.Family
                .BaseTypes.Clear()
                .BaseTypes.Add(GetType(Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase))
            End With
            CodeDom_MY_NameSpace.Types.Add(CodeDom_MyApplication_Class)

            ' Sub New
            With CodeDom_MyApplication_Constructor
                .Attributes = CodeDom.MemberAttributes.Public
                .CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
                .BaseConstructorArgs.Add(New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows"))
                With .Statements
                    .Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "IsSingleInstance"), New CodeDom.CodePrimitiveExpression(PROJET.Instance)))
                    .Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "EnableVisualStyles"), New CodeDom.CodePrimitiveExpression(PROJET.StyleXP)))
                    .Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "SaveMySettingsOnExit"), New CodeDom.CodePrimitiveExpression(PROJET.MySettings)))
                End With
                If PROJET.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose Then
                    .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "ShutdownStyle"), New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterAllFormsClose")))
                ElseIf PROJET.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses Then
                    .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "ShutdownStyle"), New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses")))
                End If
                If SZ_Est_En_Version_Demo Then .Statements.Add(New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.MsgBox(" & ChrW(34) & "This software has been created with a demo version of SoftwareZator 2012 (http://softwarezator.velersoftware.com). To remove this message, please purchase SoftwareZator 2012 or use SoftwareZator 2012 Free Edition." & ChrW(34) & ", Microsoft.VisualBasic.MsgBoxStyle.Information, " & Chr(34) & PROJET.Nom & ChrW(34) & ")"))
                CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_Constructor)
            End With

            ' Sub OnCreateMainForm
            With CodeDom_MyApplication_OnCreateMainForm_Method
                .Name = "OnCreateMainForm"
                .CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
                .Attributes = CodeDom.MemberAttributes.Family Or CodeDom.MemberAttributes.Override
            End With
            CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_OnCreateMainForm_Method)

            ' Sub OnCreateSplashScreen
            If Not PROJET.SplashScreen = Nothing Then
                With CodeDom_MyApplication_OnCreateSplashScreen_Method
                    .Name = "OnCreateSplashScreen"
                    .CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
                    .Attributes = CodeDom.MemberAttributes.Family Or CodeDom.MemberAttributes.Override
                End With
                CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_OnCreateSplashScreen_Method)
            End If

            ' Evènements d'application
            Evenements_Application()

            ' Class MySettings
            Code_MySettings = New System.Text.StringBuilder
            If PROJET.Parametres.Count > 0 Then
                With Code_MySettings
                    .AppendLine("NameSpace " & PROJET.Nom & ".My")
                    .AppendLine("    Partial Public Class MySettings")
                    .AppendLine("        Inherits Global.System.Configuration.ApplicationSettingsBase")
                    .AppendLine("        Private Shared defaultInstance As MySettings = DirectCast(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)")
                    .AppendLine("        Private Shared addedHandler As Boolean")
                    .AppendLine("        Private Shared addedHandlerLockObject As New Object")
                    .AppendLine("        Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)")
                    .AppendLine("            If " & PROJET.Nom & ".Variables._manager.SaveMySettingsOnExit Then")
                    .AppendLine("                My.Settings.Save()")
                    .AppendLine("            End If")
                    .AppendLine("        End Sub")
                    .AppendLine("        Public Shared ReadOnly Property [Default]() As MySettings")
                    .AppendLine("            Get")
                    .AppendLine("                If Not addedHandler Then")
                    .AppendLine("                    SyncLock addedHandlerLockObject")
                    .AppendLine("                        If Not addedHandler Then")
                    .AppendLine("                            AddHandler " & PROJET.Nom & ".Variables._manager.Shutdown, AddressOf AutoSaveSettings")
                    .AppendLine("                            addedHandler = True")
                    .AppendLine("                        End If")
                    .AppendLine("                    End SyncLock")
                    .AppendLine("                End If")
                    .AppendLine("                Return defaultInstance")
                    .AppendLine("            End Get")
                    .AppendLine("        End Property")
                    .AppendLine()
                    For Each sett As String In PROJET.Parametres
                        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Ajout_Paramètre"), sett)))
                        .AppendLine("        <Global.System.Configuration.UserScopedSettingAttribute()> _")
                        .AppendLine("        Public Property " & sett & "() As Object")
                        .AppendLine("            Get")
                        .AppendLine("                Return DirectCast(Me(" & ChrW(34) & sett & ChrW(34) & "), Object)")
                        .AppendLine("            End Get")
                        .AppendLine("            Set")
                        .AppendLine("                Me(" & ChrW(34) & sett & ChrW(34) & ") = value")
                        .AppendLine("            End Set")
                        .AppendLine("        End Property")
                        .AppendLine()
                    Next
                    .AppendLine()
                    .AppendLine("    End Class")
                    .AppendLine("    Module MySettingsProperty")
                    .AppendLine("        <Global.System.ComponentModel.Design.HelpKeywordAttribute(" & ChrW(34) & "My.Settings" & ChrW(34) & ")>  _")
                    .AppendLine("        Friend ReadOnly Property Settings() As My.MySettings")
                    .AppendLine("            Get")
                    .AppendLine("                Return My.MySettings.Default")
                    .AppendLine("            End Get")
                    .AppendLine("        End Property")
                    .AppendLine("    End Module")
                    .AppendLine("End NameSpace")
                End With
            End If

        End If

        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Initialisation_CodeDom_Terminé"))))
    End Sub

    Private Sub Evenements_Application()
        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\ApplicationEvents.szc") Then
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Evenement_Application"))))

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier"), PROJET.Emplacement & "\ApplicationEvents.szc")))

            Tmp_SZC_File = Nothing
            Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(PROJET.Emplacement & "\ApplicationEvents.szc")

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier_Terminé"), PROJET.Emplacement & "\ApplicationEvents.szc")))

            i_function = 0
            For Each txt As String In Tmp_SZC_File.Functions
                i_function += 1

                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fonction"), i_function)))
                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Generation_Chargement_Fonction_Terminer")))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_MyApplication_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), PROJET.Emplacement & "\ApplicationEvents.szc", "ApplicationEvents"))
                    Else
                        Select Case DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1
                            Case "Startup"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "Startup", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "Startup")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                With DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod)
                                    .Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                    .Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "Startup"))
                                End With
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "Shutdown"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "Shutdown", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "_Shutdown")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                With DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod)
                                    .Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                    .Name = "_Shutdown"
                                    .Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "Shutdown"))
                                End With
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "NetworkAvailabilityChanged"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "NetworkAvailabilityChanged", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "NetworkAvailabilityChanged")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                With DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod)
                                    .Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                    .Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "NetworkAvailabilityChanged"))
                                End With
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "StartupNextInstance"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "StartupNextInstance", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "StartupNextInstance")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                With DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod)
                                    .Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                    .Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "StartupNextInstance"))
                                End With
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                        End Select
                    End If
                End If
            Next

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Evenement_Application_Terminé"))))
        End If
    End Sub

    Private Sub Chargement_Fichiers_SZW(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories)
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier"), NomCompletFichier)))

            Tmp_SZW_File = Nothing
            Tmp_SZW_File_Tmp = Nothing
            Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(NomCompletFichier)
            If Tmp_SZW_File IsNot Nothing Then
                Tmp_SZW_File_Tmp = New VelerSoftware.SZVB.Projet.SZW_File_Tmp
                With Tmp_SZW_File_Tmp
                    .Fichier = NomCompletFichier
                    .Functions = Tmp_SZW_File.Functions
                    .Nom = Tmp_SZW_File.Nom
                    .Resources = Tmp_SZW_File.Resources
                    .WINDOWS = Tmp_SZW_File.WINDOWS
                    If List_File_Name.Contains(Tmp_SZW_File.Nom) Then
                        BackgroundWorker_Building.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Doublon"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                        BackgroundWorker_Building.CancelAsync()
                        Exit For
                    Else
                        List_File_Name.Add(Tmp_SZW_File.Nom)
                    End If

                    .WINDOWS.Namespaces(0).Types(0).IsPartial = True
                    List_SZW_File.Add(Tmp_SZW_File_Tmp)
                    ' Fenêtre de démarrage
                    If (PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) AndAlso ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.FormStart Then
                        If .WINDOWS.Namespaces(0).Types(0).BaseTypes(0).BaseType = "System.Windows.Forms.UserControl" Then
                            Worker.ReportProgress(((i2_progress / i_progress) * 20) + 5, New GenerationProgress(Nom_Projet, RM.GetString("Generation_UserControl"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                            Worker.CancelAsync()
                        End If
                        If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then CodeDom_MyApplication_OnCreateMainForm_Method.Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "MainForm"), New CodeDom.CodeSnippetExpression("Variables." & .WINDOWS.Namespaces(0).Types(0).Name)))
                        Nom_Form_Demarrage = Tmp_SZW_File_Tmp.WINDOWS.Namespaces(0).Types(0).Name
                    End If
                    ' SplashScreen
                    If Not PROJET.SplashScreen = Nothing AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows AndAlso ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.SplashScreen Then CodeDom_MyApplication_OnCreateSplashScreen_Method.Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "SplashScreen"), New CodeDom.CodeSnippetExpression("New Global." & CodeDom_NameSpace.Name & "." & .WINDOWS.Namespaces(0).Types(0).Name)))
                End With
            End If

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier_Terminé"), NomCompletFichier)))

            i2_progress += 1
            Worker.ReportProgress(((i2_progress / i_progress) * 20) + 5, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Load"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Chargement_Fichiers_SZC(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories)
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier"), NomCompletFichier)))

            Tmp_SZC_File = Nothing
            Tmp_SZC_File_Tmp = Nothing
            Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(NomCompletFichier)
            If Not Tmp_SZC_File Is Nothing Then
                Tmp_SZC_File_Tmp = New VelerSoftware.SZVB.Projet.SZC_File_Tmp
                With Tmp_SZC_File_Tmp
                    .Fichier = NomCompletFichier
                    .Functions = Tmp_SZC_File.Functions
                    .Nom = Tmp_SZC_File.Nom
                    If List_File_Name.Contains(Tmp_SZC_File.Nom) Then
                        Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Doublon"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                        Worker.CancelAsync()
                        Exit For
                    Else
                        List_File_Name.Add(Tmp_SZC_File.Nom)
                    End If

                    If Not NomCompletFichier = PROJET.Emplacement & "\ApplicationEvents.szc" Then
                        List_SZC_File.Add(Tmp_SZC_File_Tmp)
                        ' Fenêtre de démarrage
                        If (PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) AndAlso ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.FormStart Then Nom_Form_Demarrage = .Nom
                    End If
                End With
            End If

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier_Terminé"), NomCompletFichier)))

            i2_progress += 1
            Worker.ReportProgress(((i2_progress / i_progress) * 20) + 5, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Load"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Chargement_Fichiers_VB(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        With Log_Generation.Log
            Code_VB_Files = New System.Text.StringBuilder
            For Each fi As String In List_VBFile
                .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier"), fi)))
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", fi)) Then
                    Code_VB_Files.Append(My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", fi), System.Text.Encoding.UTF8) & Environment.NewLine & Environment.NewLine & Environment.NewLine)
                ElseIf My.Computer.FileSystem.FileExists(fi) Then
                    Code_VB_Files.Append(My.Computer.FileSystem.ReadAllText(fi, System.Text.Encoding.UTF8) & Environment.NewLine & Environment.NewLine & Environment.NewLine)
                End If

                .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier_Terminé"), fi)))

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 75, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_VBFile"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
            For Each fi As String In PROJET.Fichiers_VBNet
                .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier"), fi)))
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi)) Then Code_VB_Files.Append(My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi), System.Text.Encoding.UTF8) & Environment.NewLine & Environment.NewLine & Environment.NewLine)

                .Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fichier_Terminé"), fi)))

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 75, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_VBFile"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
        End With
    End Sub

    Private Sub Generer_Code_SZW(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        For Each Tmp_SZW_File2 As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Code"), Tmp_SZW_File2.Nom)))

            ' Création de la class de la fenêtre
            i_remove = -1
            For i As Integer = 0 To Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members.Count - 1
                Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i).Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                If Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i).Name = "Main" Then i_remove = i
            Next
            If i_remove > -1 Then Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members.RemoveAt(i_remove)

            If Nom_Form_Demarrage = Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Name AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                CodeDom_Sub_Main = New CodeDom.CodeEntryPointMethod
                With CodeDom_Sub_Main
                    .Name = "Main"
                    .Attributes = CodeDom.MemberAttributes.Public
                    .CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.STAThreadAttribute"))
                    .Statements.Add(New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeVariableReferenceExpression("_manager"), "Run", New CodeDom.CodeSnippetExpression("System.Environment.GetCommandLineArgs()")))
                End With
                Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members.Add(CodeDom_Sub_Main)
            End If

            Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("Microsoft.VisualBasic.CompilerServices.DesignerGenerated"))

            ' Enregistrement du fichier ressource temporaire
            If Not Generation_Code Then My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Building\" & PROJET.Nom & "." & Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Name & ".resx", Tmp_SZW_File2.Resources, True)

            ' Création de la class des fonctions 
            CodeDom_SZW_SZC_Class = New CodeDom.CodeTypeDeclaration(Tmp_SZW_File2.Nom)
            CodeDom_SZW_SZC_Class.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
            CodeDom_SZW_SZC_Class.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final

            i_function = 0
            For Each txt As String In Tmp_SZW_File2.Functions
                i_function += 1

                ok_for_add_event = False


                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fonction"), i_function)))
                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Generation_Chargement_Fonction_Terminer")))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_SZW_SZC_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), Tmp_SZW_File2.Fichier, Tmp_SZW_File2.Nom))
                    Else
                        CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                        If Not Generation_Code Then DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Comments.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1 & "|file:" & Tmp_SZW_File2.Fichier & "|actionid:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).id & "|actionname:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).DisplayName))
                        Dim handl As String = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param2
                        If handl IsNot Nothing Then

                            For i As Integer = 0 To Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members.Count - 1
                                If Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i).Name = "InitializeComponent" Then
                                    If Not handl.Split(".")(0) = "Me" Then
                                        For Each codeeee As Object In DirectCast(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0), CodeDom.CodeTypeDeclaration).Members
                                            If TypeOf codeeee Is CodeDom.CodeMemberField AndAlso codeeee.Name = handl.Split(".")(0) Then ok_for_add_event = True : Exit For
                                        Next
                                    Else
                                        ok_for_add_event = True
                                    End If
                                    If ok_for_add_event Then
                                        If Not Generation_Code Then DirectCast(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i), CodeDom.CodeMemberMethod).Statements.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1 & "|file:" & Tmp_SZW_File2.Fichier & "|actionid:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).id & "|actionname:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).DisplayName))
                                        DirectCast(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i), CodeDom.CodeMemberMethod).Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression(handl.Split(".")(0)), handl.Split(".")(1), New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1)))
                                    End If
                                    Exit For
                                End If
                            Next

                        End If

                        DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, Tmp_SZW_File2.Fichier, DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1))

                        CodeDom_SZW_SZC_Class.Members.Add(CodeDom_CodeObject)
                    End If
                End If

                FunctionWorkflow = Nothing

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next

            CodeDom_NameSpace.Types.Add(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0))
            CodeDom_NameSpace.Types.Add(CodeDom_SZW_SZC_Class)

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Code_Terminé"), Tmp_SZW_File2.Nom)))

            i2_progress += 1
            Worker.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_Code_SZC(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        For Each Tmp_SZC_File2 As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Code"), Tmp_SZC_File2.Nom)))

            ' Création de la class des fonctions 
            CodeDom_SZW_SZC_Class = New CodeDom.CodeTypeDeclaration(Tmp_SZC_File2.Nom)
            CodeDom_SZW_SZC_Class.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
            CodeDom_SZW_SZC_Class.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final

            Dim ok_console_main As Boolean

            i_function = 0
            For Each txt As String In Tmp_SZC_File2.Functions
                i_function += 1

                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Chargement_Fonction"), i_function)))
                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Generation_Chargement_Fonction_Terminer")))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_SZW_SZC_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), Tmp_SZC_File2.Fichier, Tmp_SZC_File2.Nom))
                    Else
                        If Nom_Form_Demarrage = Tmp_SZC_File2.Nom AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole AndAlso DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1 = "Main" Then ok_console_main = True

                        CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                        If Not Generation_Code Then DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Comments.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1 & "|file:" & Tmp_SZC_File2.Fichier & "|actionid:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).id & "|actionname:" & DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).DisplayName))
                        DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, Tmp_SZC_File2.Fichier, DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1))

                        CodeDom_SZW_SZC_Class.Members.Add(CodeDom_CodeObject)
                    End If
                End If

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next

            CodeDom_NameSpace.Types.Add(CodeDom_SZW_SZC_Class)

            FunctionWorkflow = Nothing

            If Not Generation_Code AndAlso Nom_Form_Demarrage = Tmp_SZC_File2.Nom AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole AndAlso ok_console_main = False Then
                ' Car il n'y a pas de fonction "Main"
                Worker.ReportProgress(100, New GenerationProgress(Nom_Projet, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Generation_Project_Main_Introuvable"), Nom_Form_Demarrage), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                Worker.CancelAsync()
                Exit For
            End If

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Code_Terminé"), Tmp_SZC_File2.Nom)))

            i2_progress += 1
            Worker.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_Ressources_Et_Code(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx"))))

        If Not Generation_Code Then
            For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.resx", System.IO.SearchOption.AllDirectories)
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx_Fichier"), NomCompletFichier)))

                RrX = New System.Resources.ResXResourceReader(NomCompletFichier)
                RrEn = RrX.GetEnumerator()
                ReWriter = New Resources.ResourceWriter(NomCompletFichier.Replace(".resx", ".resources"))
                While (RrEn.MoveNext())
                    ReWriter.AddResource(RrEn.Key.ToString(), RrEn.Value)
                End While
                RrX.Close()
                ReWriter.Close()
                ReWriter.Dispose()

                i2_progress += 1

                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx_Fichier_Terminer"), NomCompletFichier)))
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 80, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Resx"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 80, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
        End If


        ' Génération de la Class des ressources du projet
        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\" & PROJET.Nom & ".resx") Then My.Computer.FileSystem.DeleteFile(PROJET.Emplacement & "\" & PROJET.Nom & ".resx", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        If PROJET.Ressources.Count > 0 Then
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx_Fichier"), PROJET.Emplacement & "\" & PROJET.Nom & ".resx")))

            Using resxwr As New Resources.ResXResourceWriter(PROJET.Emplacement & "\" & PROJET.Nom & ".resx")
                With resxwr
                    For Each res As VelerSoftware.SZVB.Projet.Ressource In PROJET.Ressources
                        Select Case res.Type
                            Case VelerSoftware.SZVB.Projet.Ressource.Types.Image
                                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) Then .AddResource(res.Name, Drawing.Image.FromFile(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)))
                            Case VelerSoftware.SZVB.Projet.Ressource.Types.Texte
                                .AddResource(res.Name, res.Value)
                            Case VelerSoftware.SZVB.Projet.Ressource.Types.Fichier
                                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) Then .AddResource(res.Name, My.Computer.FileSystem.ReadAllBytes(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)))
                        End Select
                    Next
                    .Close()
                End With
            End Using
            If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\" & PROJET.Nom & ".resx") Then
                If Not Generation_Code Then
                    RrX = New System.Resources.ResXResourceReader(PROJET.Emplacement & "\" & PROJET.Nom & ".resx")
                    RrEn = RrX.GetEnumerator()
                    ReWriter = New Resources.ResourceWriter(PROJET.Emplacement & "\" & PROJET.Nom & ".My.Resources.resources")
                    While (RrEn.MoveNext())
                        ReWriter.AddResource(RrEn.Key.ToString(), RrEn.Value)
                    End While
                    RrX.Close()
                    ReWriter.Close()
                    ReWriter.Dispose()
                End If

                CodeDom_Resources_CCu = Resources.Tools.StronglyTypedResourceBuilder.Create(PROJET.Emplacement & "\" & PROJET.Nom & ".resx", "Resources", PROJET.Nom & ".My", CodeDom.Compiler.CodeDomProvider.CreateProvider("VB"), True, New String() {"Error"})
                CodeDom_CCu.Namespaces.Add(CodeDom_Resources_CCu.Namespaces(0))

                My.Computer.FileSystem.DeleteFile(PROJET.Emplacement & "\" & PROJET.Nom & ".resx", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx_Fichier_Terminer"), PROJET.Emplacement & "\" & PROJET.Nom & ".resx")))
        End If

        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Resx_Terminé"))))

    End Sub

    Private Sub Generer_Module_Variables(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer, ByVal Worker As System.ComponentModel.BackgroundWorker)
        Code_Module_Variables = New System.Text.StringBuilder
        With Code_Module_Variables
            .AppendLine("NameSpace " & PROJET.Nom)
            .AppendLine("  Module Variables")
            If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                .AppendLine("      Sub Main()")
                If SZ_Est_En_Version_Demo Then .AppendLine("          Microsoft.VisualBasic.MsgBox(" & ChrW(34) & "This software has been created with a demo version of SoftwareZator 2012 (http://softwarezator.velersoftware.com). To remove this message, please purchase SoftwareZator 2012 or use SoftwareZator 2012 Free Edition." & ChrW(34) & ", Microsoft.VisualBasic.MsgBoxStyle.Information, " & Chr(34) & PROJET.Nom & ChrW(34) & ")")
                .AppendLine("          " & Nom_Form_Demarrage & ".Main")
                .AppendLine("      End Sub")
            ElseIf PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                .AppendLine("      Public _manager As My.MyApplication = New My.MyApplication")
                .AppendLine("      Public _computer As Microsoft.VisualBasic.Devices.Computer = New Microsoft.VisualBasic.Devices.Computer")
            End If
            For Each var As VelerSoftware.SZVB.Projet.Variable In PROJET.Variables
                If var.Array Then
                    If var.NullAtStart Then
                        .AppendLine("      Public " & var.Name & " As System.Collections.Generic.List(Of System.Object) ' " & var.Description.Replace(Environment.NewLine, " "))
                    Else
                        .AppendLine("      Public " & var.Name & " As New System.Collections.Generic.List(Of System.Object) ' " & var.Description.Replace(Environment.NewLine, " "))
                    End If
                Else
                    If var.NullAtStart Then
                        .AppendLine("      Public " & var.Name & " As System.Object = Nothing ' " & var.Description.Replace(Environment.NewLine, " "))
                    Else
                        .AppendLine("      Public " & var.Name & " As New System.Object ' " & var.Description.Replace(Environment.NewLine, " "))
                    End If
                End If

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 85, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Variable"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
            For Each szwfi As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
                .AppendLine("      Private _" & szwfi.Nom & " As New Global." & PROJET.Nom & "." & szwfi.Nom & "()")
                .AppendLine("      Public Property " & szwfi.Nom & " As Global." & PROJET.Nom & "." & szwfi.Nom & " ' Window " & szwfi.Nom)
                .AppendLine("           Get")
                .AppendLine("               If _" & szwfi.Nom & ".IsDisposed Then _" & szwfi.Nom & " = New Global." & PROJET.Nom & "." & szwfi.Nom & "()")
                .AppendLine("               Return _" & szwfi.Nom)
                .AppendLine("           End Get")
                .AppendLine("           Set(ByVal value As Global." & PROJET.Nom & "." & szwfi.Nom & ")")
                .AppendLine("               _" & szwfi.Nom & " = value")
                .AppendLine("           End Set")
                .AppendLine("      End Property")

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 85, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Variable"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
            For Each szwfi As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
                .AppendLine("      Public Property " & szwfi.Nom & " As New Global." & PROJET.Nom & "." & szwfi.Nom & "() ' Class " & szwfi.Nom)

                i2_progress += 1
                Worker.ReportProgress(((i2_progress / i_progress) * 5) + 85, New GenerationProgress(Nom_Projet, RM.GetString("Generation_Project_Variable"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
            .AppendLine("  End Module")
            .AppendLine("End NameSpace")
        End With
    End Sub

    Private Sub Configuration_Compilateur()
        If PROJET IsNot Nothing Then

            para = New CodeDom.Compiler.CompilerParameters
            With para
                If PROJET.GenerateDirectory = Nothing Then PROJET.GenerateDirectory = "Bin"
                If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                    .GenerateExecutable = False
                    .OutputAssembly = My.Computer.FileSystem.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & PROJET.Nom & ".dll")
                Else
                    .GenerateExecutable = True
                    .OutputAssembly = My.Computer.FileSystem.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & PROJET.Nom & ".exe")
                End If
                .IncludeDebugInformation = True
                .GenerateInMemory = False
                .TreatWarningsAsErrors = False

                .CompilerOptions &= " /langversion:10.0 /debug:full "

                Select Case PROJET.Type
                    Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\icon.ico") Then .CompilerOptions &= " /win32icon:" & ChrW(34) & PROJET.Emplacement & "\icon.ico" & ChrW(34)
                        .CompilerOptions &= " /win32manifest:" & ChrW(34) & Application.StartupPath & "\Tools\app.manifest" & ChrW(34)
                        .CompilerOptions &= " /target:winexe"
                    Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\icon.ico") Then .CompilerOptions &= " /win32icon:" & ChrW(34) & PROJET.Emplacement & "\icon.ico" & ChrW(34)
                        .CompilerOptions &= " /win32manifest:" & ChrW(34) & Application.StartupPath & "\Tools\app.manifest" & ChrW(34)
                        .CompilerOptions &= " /target:exe"
                    Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                        .CompilerOptions &= " /target:library"
                End Select

                If PROJET.Optimize AndAlso Generation_En_Cours_Type = generation_type.Release Then .CompilerOptions &= " /optimize"

                Select Case PROJET.Cpu
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.x86
                        .CompilerOptions &= " /platform:x86"
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.x64
                        .CompilerOptions &= " /platform:x64"
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu
                        .CompilerOptions &= " /platform:anycpu"
                End Select

                For Each a As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Building", "*.resources", System.IO.SearchOption.AllDirectories)
                    .EmbeddedResources.Add(a)
                Next
                If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\" & PROJET.Nom & ".My.Resources.resources") Then .EmbeddedResources.Add(PROJET.Emplacement & "\" & PROJET.Nom & ".My.Resources.resources")


                ' REFERENCES
                For Each a As VelerSoftware.SZVB.Projet.Reference In PROJET.References
                    If a.IsProject Then
                        With My.Computer.FileSystem
                            If a.Copy Then
                                If .FileExists(.CombinePath(PROJET.Emplacement, a.FullName)) Then
                                    .CopyFile(.CombinePath(PROJET.Emplacement, a.FullName), .CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & .GetName(a.FullName)), True)
                                    para.ReferencedAssemblies.Add(.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & .GetName(a.FullName)))
                                End If
                                If .FileExists(.CombinePath(PROJET.Emplacement, a.FullName.Replace(".dll", ".pdb"))) Then .CopyFile(.CombinePath(PROJET.Emplacement, a.FullName.Replace(".dll", ".pdb")), .CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & .GetName(a.FullName.Replace(".dll", ".pdb"))), True)
                                If .FileExists(.CombinePath(PROJET.Emplacement, a.FullName.Replace(".dll", ".xml"))) Then .CopyFile(.CombinePath(PROJET.Emplacement, a.FullName.Replace(".dll", ".xml")), .CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & .GetName(a.FullName.Replace(".dll", ".xml"))), True)
                            Else
                                If .FileExists(.CombinePath(PROJET.Emplacement, a.FullName)) Then para.ReferencedAssemblies.Add(.CombinePath(PROJET.Emplacement, a.FullName))
                            End If
                        End With
                    ElseIf Not a.Assembly Is Nothing Then
                        If a.Copy Then
                            If My.Computer.FileSystem.FileExists(a.Assembly.Location) Then
                                My.Computer.FileSystem.CopyFile(a.Assembly.Location, My.Computer.FileSystem.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & My.Computer.FileSystem.GetName(a.Assembly.Location)), True)
                                .ReferencedAssemblies.Add(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, PROJET.GenerateDirectory & "\" & My.Computer.FileSystem.GetName(a.Assembly.Location)))
                            End If
                        Else
                            .ReferencedAssemblies.Add(a.Assembly.Location)
                        End If
                    End If
                Next
            End With

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Config"))))
        End If
    End Sub

    Private Sub Verification_References(ByVal Refer As Generic.List(Of String))
        For Each value As String In Refer
            Verification_reference_ok = False
            For Each ref As VelerSoftware.SZVB.Projet.Reference In PROJET.References
                With ref
                    If .FullName = value OrElse .FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value) OrElse .FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value) Then Verification_reference_ok = True
                End With
            Next
            If Not Verification_reference_ok Then ClassProjet.Ajouter_Reference_Projet(value, PROJET)
        Next
    End Sub

    Private Function Add_CodeDom_Recursivity(ByVal Root As VelerSoftware.Plugins3.ActionWithChildren, ByVal condition As Boolean, ByVal alors As Boolean, ByVal nom_fichier As String, ByVal nom_fonction As String) As CodeDom.CodeStatementCollection
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), Root.DisplayName, nom_fonction, nom_fichier)))

        Dim result As New CodeDom.CodeStatementCollection

        If Not Generation_Code Then Me.Verification_References(Root.References)
        If (Not Root.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(Root.ClassCode)) Then List_VBFile.Add(Root.ClassCode)

        Dim cod As CodeDom.CodeObject
        If Not condition Then
            For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), aaa.DisplayName, nom_fonction, nom_fichier)))

                cod = aaa.GetVBCode(True)
                If Not Generation_Code Then Me.Verification_References(aaa.References)
                If (Not aaa.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(aaa.ClassCode)) Then List_VBFile.Add(aaa.ClassCode)
                If Not cod Is Nothing Then
                    ' Pour le débuggueur
                    If Not Generation_Code Then result.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & aaa.id & "|actionname:" & aaa.DisplayName))
                    '''
                    If TypeOf cod Is CodeDom.CodeConditionStatement Then
                        With DirectCast(cod, CodeDom.CodeConditionStatement)
                            .TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                            .FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
                        End With
                        result.Add(DirectCast(cod, CodeDom.CodeConditionStatement))
                    ElseIf TypeOf cod Is CodeDom.CodeStatement Then
                        result.Add(DirectCast(cod, CodeDom.CodeStatement))
                    ElseIf TypeOf cod Is CodeDom.CodeExpression Then
                        result.Add(DirectCast(cod, CodeDom.CodeExpression))
                    End If
                    If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso aaa.Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
                End If
            Next
        Else
            If alors Then
                For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
                    With aaa
                        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), .DisplayName, nom_fonction, nom_fichier)))

                        cod = .GetVBCode(True)
                        If Not Generation_Code Then Me.Verification_References(.References)
                        If (Not .ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(.ClassCode)) Then List_VBFile.Add(.ClassCode)
                        If Not cod Is Nothing Then
                            ' Pour le débuggueur
                            If Not Generation_Code Then result.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & .id & "|actionname:" & .DisplayName))
                            '''
                            If TypeOf cod Is CodeDom.CodeConditionStatement Then
                                With DirectCast(cod, CodeDom.CodeConditionStatement)
                                    .TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                                    .FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
                                End With
                                result.Add(DirectCast(cod, CodeDom.CodeConditionStatement))
                            ElseIf TypeOf cod Is CodeDom.CodeStatement Then
                                result.Add(DirectCast(cod, CodeDom.CodeStatement))
                            ElseIf TypeOf cod Is CodeDom.CodeExpression Then
                                result.Add(DirectCast(cod, CodeDom.CodeExpression))
                            End If
                            If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso .Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
                        End If
                    End With
                Next
            Else
                For Each aaa As VelerSoftware.Plugins3.Action In DirectCast(DirectCast(Root, Object).Children_Actions2, Generic.List(Of VelerSoftware.Plugins3.Action))
                    With aaa
                        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), .DisplayName, nom_fonction, nom_fichier)))

                        cod = .GetVBCode(True)
                        If Not Generation_Code Then Me.Verification_References(.References)
                        If (Not .ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(.ClassCode)) Then List_VBFile.Add(.ClassCode)
                        If Not cod Is Nothing Then
                            ' Pour le débuggueur
                            If Not Generation_Code Then result.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & .id & "|actionname:" & .DisplayName))
                            '''
                            If TypeOf cod Is CodeDom.CodeConditionStatement Then
                                With DirectCast(cod, CodeDom.CodeConditionStatement)
                                    .TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                                    .FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
                                End With
                                result.Add(DirectCast(cod, CodeDom.CodeConditionStatement))
                            ElseIf TypeOf cod Is CodeDom.CodeStatement Then
                                result.Add(DirectCast(cod, CodeDom.CodeStatement))
                            ElseIf TypeOf cod Is CodeDom.CodeExpression Then
                                result.Add(DirectCast(cod, CodeDom.CodeExpression))
                            End If
                            If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso .Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
                        End If
                    End With
                Next
            End If
        End If

        Return result
    End Function

    Private Function Add_CodeDom_TypeMember_Recursivity(ByVal Root As VelerSoftware.Plugins3.ActionWithChildren, ByVal nom_fichier As String, ByVal nom_fonction As String) As CodeDom.CodeTypeMemberCollection
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), Root.DisplayName, nom_fonction, nom_fichier)))

        Dim result As New CodeDom.CodeTypeMemberCollection

        If Not Generation_Code Then Me.Verification_References(Root.References)
        If (Not Root.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(Root.ClassCode)) Then List_VBFile.Add(Root.ClassCode)

        Dim cod As CodeDom.CodeObject
        For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
            With aaa
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), .DisplayName, nom_fonction, nom_fichier)))

                cod = .GetVBCode(False)
                If Not Generation_Code Then Me.Verification_References(.References)
                If (Not .ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(.ClassCode)) Then List_VBFile.Add(.ClassCode)
                If Not cod Is Nothing Then
                    If TypeOf cod Is CodeDom.CodeTypeMember Then
                        If Not Generation_Code Then DirectCast(cod, CodeDom.CodeTypeMember).Comments.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & .id & "|actionname:" & .DisplayName))
                        result.Add(DirectCast(cod, CodeDom.CodeTypeMember))
                    ElseIf TypeOf cod Is CodeDom.CodeMemberProperty Then
                        If Not Generation_Code Then DirectCast(cod, CodeDom.CodeMemberProperty).Comments.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & .id & "|actionname:" & .DisplayName))
                        result.Add(DirectCast(cod, CodeDom.CodeMemberProperty))
                    ElseIf TypeOf cod Is CodeDom.CodeSnippetTypeMember Then
                        If Not Generation_Code Then DirectCast(cod, CodeDom.CodeSnippetTypeMember).Comments.Add(New CodeDom.CodeCommentStatement("project:" & PROJET.Nom & "|function:" & nom_fonction & "|file:" & nom_fichier & "|actionid:" & .id & "|actionname:" & .DisplayName))
                        result.Add(DirectCast(cod, CodeDom.CodeSnippetTypeMember))
                    ElseIf TypeOf cod Is CodeDom.CodeObject Then
                        result.Add(DirectCast(cod, CodeDom.CodeObject))
                    End If
                    If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso .Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
                End If
            End With
        Next

        Return result
    End Function

#End Region

#Region "OBFUSCATION"

    ' Lors de l'obfuscation d'une solution
    Private Sub BackgroundWorker_Obfuscation_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Obfuscation.DoWork
        ObfuscationWorker = sender

        ' Instanciation d'un objet StopWatch 
        Dim monStopWatch As New Stopwatch
        ' Déclenchement du "chronomètre"
        monStopWatch.Start()



        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, Environment.NewLine & Environment.NewLine))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Obfuscation_Starting")))




        Dim NomCompletFichierDeBaseAProteger As String = Nothing
        Dim cr As New VelerSoftware.SZC.Obfuscator.Confuser.Core.Confuser()
        Dim ObfuscatorParam As New VelerSoftware.SZC.Obfuscator.Confuser.Core.ConfuserParameter()

        With My.Computer.FileSystem
            ' Création du dossier d'obfuscation
            If .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom) Then
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Suppression_Temp"))))
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, "*.*", System.IO.SearchOption.AllDirectories)
                    .DeleteFile(NomCompletFichier, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Next
            Else
                .CreateDirectory(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom)
            End If

            ' Récupération du fichier principal à obfusquer
            If .FileExists(.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")) Then
                NomCompletFichierDeBaseAProteger = .CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")
            ElseIf .FileExists(.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".dll")) Then
                NomCompletFichierDeBaseAProteger = .CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".dll")
            Else
                ObfuscationWorker.ReportProgress(100, New GenerationProgress(SOLUTION.Nom, String.Format(RM.GetString("Obfuscation_Fichier_Introuvable"), .CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom)), 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Error, False))
                e.Cancel = True
            End If

        End With

        ' Paramétrage de l'obfuscation
        With ObfuscatorParam
            .SourceAssembly = NomCompletFichierDeBaseAProteger
            .DestinationPath = Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom
            .ReferencesPath = My.Computer.FileSystem.GetParentPath(NomCompletFichierDeBaseAProteger)
            .Confusions = ldConfusions.Values.ToArray()
            .Packers = ldPackers.Values.ToArray()
            Select Case SOLUTION.GetProject(SOLUTION.ProjetDemarrage).ObfuscationLevel
                Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Low
                    .DefaultPreset = VelerSoftware.SZC.Obfuscator.Confuser.Core.Preset.Minimum
                Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal
                    .DefaultPreset = VelerSoftware.SZC.Obfuscator.Confuser.Core.Preset.Normal
                Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.High
                    .DefaultPreset = VelerSoftware.SZC.Obfuscator.Confuser.Core.Preset.Aggressive
            End Select

            AddHandler .Logger.BeginPhase, AddressOf ObfuscatorParam_Logger_BeginPhase
            AddHandler .Logger.End, AddressOf ObfuscatorParam_Logger_End
            AddHandler .Logger.Fault, AddressOf ObfuscatorParam_Logger_Fault
            AddHandler .Logger.Logging, AddressOf ObfuscatorParam_Logger_Logging
            AddHandler .Logger.Progressing, AddressOf ObfuscatorParam_Logger_Progressing

            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Obfuscation_Started")))

            cr.Confuse(ObfuscatorParam)

            RemoveHandler .Logger.BeginPhase, AddressOf ObfuscatorParam_Logger_BeginPhase
            RemoveHandler .Logger.End, AddressOf ObfuscatorParam_Logger_End
            RemoveHandler .Logger.Fault, AddressOf ObfuscatorParam_Logger_Fault
            RemoveHandler .Logger.Logging, AddressOf ObfuscatorParam_Logger_Logging
            RemoveHandler .Logger.Progressing, AddressOf ObfuscatorParam_Logger_Progressing
        End With

        ' Arrêt du "chronomètre" 
        monStopWatch.Stop()
        ' Le temps écoulé peut être récupéré très facilement avec un membre de StopWatch, 
        ' de la façon suivante. Le résultat est exprimé en millisecondes 
        e.Result = monStopWatch.Elapsed.Minutes & "min " & monStopWatch.Elapsed.Seconds & "sec " & monStopWatch.Elapsed.Milliseconds & "milli sec "
    End Sub

    ' Lors du changement de la progression
    Private Sub BackgroundWorker_Obfuscation_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Obfuscation.ProgressChanged
        With Me
            ' Mise à jour des barres de progressions
            If DirectCast(e.UserState, GenerationProgress).Status_Barre_Progression = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error Then
                .Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error
                .Projet_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error
            ElseIf DirectCast(e.UserState, GenerationProgress).Status_Barre_Progression = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause Then
                .Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause
                .Projet_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause
            End If
            .Solution_Windows7ProgressBar.Value = DirectCast(e.UserState, GenerationProgress).Solution_Percent

            .Projet_Windows7ProgressBar.Value = e.ProgressPercentage

            If Not .Projet_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet Then .Projet_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet
            If Not .Progression_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Texte Then .Progression_KryptonWrapLabel.Text = DirectCast(e.UserState, GenerationProgress).Texte

            .KryptonButton1.Enabled = DirectCast(e.UserState, GenerationProgress).BoutonAnnuler

        End With
    End Sub

    ' Lors de la fin de l'obfuscation
    Private Sub BackgroundWorker_Obfuscation_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Obfuscation.RunWorkerCompleted
        With Me
            .KryptonButton1.Enabled = False

            If Not e.Cancelled Then Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Obfuscation_Temp"), e.Result)))

            .Timer1.Enabled = True
            .Timer1.Start()

        End With
    End Sub




    Private ObfuscationWorker As System.ComponentModel.BackgroundWorker
    Private ObfuscationProgressValue As Double
    Private ObfuscationProgressMessage As String




    Private Sub ObfuscatorParam_Logger_BeginPhase(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Obfuscator.Confuser.Core.PhaseEventArgs)
    End Sub

    Private Sub ObfuscatorParam_Logger_End(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Obfuscator.Confuser.Core.LogEventArgs)
        With My.Computer.FileSystem
            If .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom) Then
                For Each NomCompletFichier As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, "*.*", System.IO.SearchOption.AllDirectories)
                    Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(RM_Log.GetString("Obfuscation_Move"), NomCompletFichier)))
                    .MoveFile(NomCompletFichier, .CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & .GetName(NomCompletFichier)), True)
                Next
                .DeleteDirectory(Application.StartupPath & "\Temp\Obfuscator\" & SOLUTION.Nom, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
        End With

        ObfuscationProgressMessage = RM.GetString("Obfuscator_Finish")
        ObfuscationWorker.ReportProgress(100, New GenerationProgress(SOLUTION.Nom, ObfuscationProgressMessage, 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Obfuscation_Succès")))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, Environment.NewLine & Environment.NewLine))

        ' Statistiques
        Dim stat_ok As Boolean
        For Each stat As VelerSoftware.SZVB.Projet.Statistique In PROJET.Statistiques
            If stat.TypeValue = VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess AndAlso stat.XValue = Date.Today.ToOADate Then
                stat.YValue += 1
                stat_ok = True
                Exit For
            End If
        Next
        If Not stat_ok Then PROJET.Statistiques.Add(New VelerSoftware.SZVB.Projet.Statistique(Date.Today.ToOADate, 1, VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess))

    End Sub

    Private Sub ObfuscatorParam_Logger_Fault(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Obfuscator.Confuser.Core.ExceptionEventArgs)
        If e IsNot Nothing AndAlso e.Exception IsNot Nothing Then ObfuscationProgressMessage = e.Exception.Message & Environment.NewLine & e.Exception.Source & Environment.NewLine & e.Exception.StackTrace
        ObfuscationWorker.ReportProgress(100, New GenerationProgress(SOLUTION.Nom, RM.GetString("Obfuscator_Err"), 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Error, False))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Obfuscation_Err"), ObfuscationProgressMessage)))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Obfuscation_Echec")))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, Environment.NewLine & Environment.NewLine))

        ' Statistiques
        Dim stat_ok As Boolean
        For Each stat As VelerSoftware.SZVB.Projet.Statistique In PROJET.Statistiques
            If stat.TypeValue = VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail AndAlso stat.XValue = Date.Today.ToOADate Then
                stat.YValue += 1
                stat_ok = True
                Exit For
            End If
        Next
        If Not stat_ok Then PROJET.Statistiques.Add(New VelerSoftware.SZVB.Projet.Statistique(Date.Today.ToOADate, 1, VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail))

        BackgroundWorker_Building.CancelAsync()
    End Sub

    Private Sub ObfuscatorParam_Logger_Logging(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Obfuscator.Confuser.Core.LogEventArgs)
        ObfuscationProgressMessage = e.Message
        ObfuscationWorker.ReportProgress(ObfuscationProgressValue, New GenerationProgress(SOLUTION.Nom, ObfuscationProgressMessage, ObfuscationProgressValue, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Obfuscation_Message"), ObfuscationProgressMessage)))
    End Sub

    Private Sub ObfuscatorParam_Logger_Progressing(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Obfuscator.Confuser.Core.ProgressEventArgs)
        ObfuscationProgressValue = CInt(e.Progress * 100)
        ObfuscationWorker.ReportProgress(ObfuscationProgressValue, New GenerationProgress(SOLUTION.Nom, ObfuscationProgressMessage, ObfuscationProgressValue, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
    End Sub

#End Region

End Class

Public Class GenerationProgress

    <CLSCompliant(False)>
    Public Sub New(ByVal _proj As String, ByVal _txt As String, ByVal _sol_percent As Integer, ByVal _prog_state As VelerSoftware.SZC.ProgressBar.ProgressBarState, ByVal EnabledcancelButton As Boolean)
        Nom_projet = _proj
        Texte = _txt
        Solution_Percent = _sol_percent
        BoutonAnnuler = EnabledcancelButton
        Status_Barre_Progression = _prog_state
    End Sub

    Public Property Nom_projet As String
    Public Property Texte As String
    Public Property BoutonAnnuler As Boolean
    Public Property Solution_Percent As Integer
    <CLSCompliant(False)> Public Property Status_Barre_Progression As VelerSoftware.SZC.ProgressBar.ProgressBarState

End Class
