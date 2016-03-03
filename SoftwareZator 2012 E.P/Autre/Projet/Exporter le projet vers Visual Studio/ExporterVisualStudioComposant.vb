''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ExporterVisualStudioComposant

    Public Delegate Sub OnDoWorkEventHandler(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs)
    Public Event DoWork As OnDoWorkEventHandler

    Public Delegate Sub OnProgressChangedEventHandler(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs)
    Public Event ProgressChanged As OnProgressChangedEventHandler

    Public Delegate Sub OnRunWorkerCompletedEventHandler(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
    Public Event RunWorkerCompleted As OnRunWorkerCompletedEventHandler

    Public Property Emplacement_Choisit As String

    Public Property Projet_A_Exporter As New Generic.List(Of ListViewItem)

    Friend Sub Start(ByVal ParentControl As ExporterVisualStudio, ByVal path As String, ByVal ite As Generic.List(Of ListViewItem))
        If Not Me.BackgroundWorker1.IsBusy Then
            Me.Emplacement_Choisit = path

            Me.Projet_A_Exporter = ite

            Generation_Global_OK = True

            Me.Initialisation_Generation(ParentControl)

            If Not SOLUTION Is Nothing Then
                ParentControl.Label6.Text = SOLUTION.Nom
                ParentControl.Label7.Text = RM.GetString("Generation_Save_Solution")
                ParentControl.Solution_Windows7ProgressBar.Maximum = Me.Projet_A_Exporter.Count * 100
                ParentControl.Projet_Windows7ProgressBar.Maximum = 100

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
                    ParentControl.Projet_Windows7ProgressBar.Value = (i2 / i) * 100
                    Application.DoEvents()
                Next

                ParentControl.Projet_Windows7ProgressBar.Value = 100
                Application.DoEvents()

                ' Enregistrement de la solution
                ClassProjet.Enregistrer_Solution(True)

                ParentControl.Projet_Windows7ProgressBar.Value = 0
                Application.DoEvents()

                If Generation_Global_OK Then Me.BackgroundWorker1.RunWorkerAsync(ParentControl)
            End If

        End If
    End Sub

    Friend Sub Stops()
        If Me.BackgroundWorker1.IsBusy Then
            Me.BackgroundWorker1.CancelAsync()
        End If
    End Sub


    Private Sub Initialisation_Generation(ByVal ParentControl As ExporterVisualStudio)
        Status_SZ = statu.Generation_En_Cours_Release

        ' Initialisation des barres de progression

        ParentControl.Solution_Windows7ProgressBar.ShowInTaskbar = True
        ParentControl.Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
        ParentControl.Solution_Windows7ProgressBar.Value = 0
        'Me.Windows7ProgressBar1.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Error

        ParentControl.Projet_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal
        ParentControl.Projet_Windows7ProgressBar.Value = 0

        ParentControl.Label7.Text = Nothing


        ' Donne le focus
        ParentControl.Visible = True
        ParentControl.DisableCancelButton()
    End Sub









    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        RaiseEvent DoWork(sender, e)


        ' Création du dossier de génération
        If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit) Then
            My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit)
        End If

        Dim Sol_File As New System.Text.StringBuilder()
        Sol_File.AppendLine("")
        Sol_File.AppendLine("Microsoft Visual Studio Solution File, Format Version 11.00")
        Sol_File.AppendLine("# Visual Studio 2010")

        Dim Sol_File2 As New System.Text.StringBuilder()
        Sol_File2.AppendLine("Global")
        Sol_File2.AppendLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution")
        Sol_File2.AppendLine("		Debug|x86 = Debug|x86")
        Sol_File2.AppendLine("		Release|x86 = Release|x86")
        Sol_File2.AppendLine("	EndGlobalSection")
        Sol_File2.AppendLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution")

        ' Génération de tout les projets selon l'ordre de génération
        Dim i As Integer = Me.Projet_A_Exporter.Count
        Dim i2 As Integer = 0
        Dim guid As String = Nothing
        For Each ite As ListViewItem In Me.Projet_A_Exporter
            i2 += 1

            guid = SOLUTION.GetProject(ite.Text).Assembly_Guid

            Sol_File.AppendLine("Project(" & ChrW(34) & "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}" & ChrW(34) & ") = " & ChrW(34) & ite.Text & ChrW(34) & ", " & ChrW(34) & ite.Text & "\" & ite.Text & ".vbproj" & ChrW(34) & ", " & ChrW(34) & "{" & guid & "}" & ChrW(34) & "")
            Sol_File.AppendLine("EndProject")

            Sol_File2.AppendLine("		{" & guid & "}" & ".Debug|x86.ActiveCfg = Debug|x86")
            Sol_File2.AppendLine("		{" & guid & "}" & ".Debug|x86.Build.0 = Debug|x86")
            Sol_File2.AppendLine("		{" & guid & "}" & ".Release|x86.ActiveCfg = Release|x86")
            Sol_File2.AppendLine("		{" & guid & "}" & ".Release|x86.Build.0 = Release|x86")

            If (Not e.Cancel) AndAlso (Generation_Global_OK) Then
                If Not Me.Generer_Projet(DirectCast(e.Argument, ExporterVisualStudio), ite.Text, i2) Then
                    e.Cancel = True
                Else
                    Me.BackgroundWorker1.ReportProgress(100, New GenerationProgress(ite.Text, RM.GetString("Exportation_Project_Finish"), i2 * 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
                End If
            End If
        Next

        Sol_File2.AppendLine("	EndGlobalSection")
        Sol_File2.AppendLine("	GlobalSection(SolutionProperties) = preSolution")
        Sol_File2.AppendLine("		HideSolutionNode = FALSE")
        Sol_File2.AppendLine("	EndGlobalSection")
        Sol_File2.AppendLine("EndGlobal")

        My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & SOLUTION.Nom & ".sln", Sol_File.ToString & Sol_File2.ToString, False)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        RaiseEvent ProgressChanged(sender, e)

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        RaiseEvent RunWorkerCompleted(sender, e)

        If Me.BackgroundWorker1.IsBusy Then
            Me.BackgroundWorker1.CancelAsync()
        End If


        If Not ReWriter Is Nothing Then ReWriter.Dispose()
        If Not Tmp_SZW_File_Tmp Is Nothing Then Tmp_SZW_File_Tmp.Dispose()
        If Not Tmp_SZC_File_Tmp Is Nothing Then Tmp_SZC_File_Tmp.Dispose()

        For Each ite As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
            ite.Dispose()
        Next
        For Each ite As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
            ite.Dispose()
        Next
        List_SZC_File.Clear()
        List_SZW_File.Clear()
        List_File_Name.Clear()
        List_VBFile.Clear()

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
        Nom_Form_Demarrage = Nothing

        Status_SZ = statu.Normal
    End Sub










    Friend Generation_Global_OK As Boolean

    Private FunctionWorkflow As Object
    'Friend WorkflowDesigne As New Global.SoftwareZator.WorkflowDesigner
    'Friend WorkflowDesigne_Txt As String
    'Friend WorkflowDesigne_ElementHost As New Integration.ElementHost

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

    Private Nom_Form_Demarrage, Nom_SplashScreen, Complete_path As String
    Private List_Form_File_VB As New Generic.List(Of String)

    Private Function Generer_Projet(ByVal ParentControl As ExporterVisualStudio, ByVal Nom_Projet As String, ByVal NumeroProjet As Integer) As Boolean
        Me.BackgroundWorker1.ReportProgress(0, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Initialize"), ((NumeroProjet - 1) * 100) + 0, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


        ' Déclarations
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
        Nom_Form_Demarrage = Nothing
        List_Form_File_VB = New Generic.List(Of String)

        PROJET = SOLUTION.GetProject(Nom_Projet)
        Generation_En_Cours_Projet = PROJET
        If PROJET IsNot Nothing AndAlso PROJET.Loaded Then

            ' Création du dossier de génération
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet) Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet)
            End If
            ' Création du dossier My Project
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\My Project") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\My Project")
            End If
            ' Création du dossier Resources
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\Resources") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\Resources")
            End If
            ' Création du dossier Include
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\Include") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\Include")
            End If
            ' Création du dossier bin
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin")
            End If
            ' Création du dossier bin\Debug
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin\Debug") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin\Debug")
            End If
            ' Création du dossier bin\Release
            If Not My.Computer.FileSystem.DirectoryExists(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin\Release") Then
                My.Computer.FileSystem.CreateDirectory(Me.Emplacement_Choisit & "\" & Nom_Projet & "\bin\Release")
            End If

            Me.Initialisation_CodeDom()

            Me.BackgroundWorker1.ReportProgress(5, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Load"), ((NumeroProjet - 1) * 100) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


            i_progress = System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories).Length + System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories).Length
            i2_progress = 0

            ' Chargement des Fichiers SZW
            Me.Chargement_Fichiers_SZW(Nom_Projet, NumeroProjet)

            If Not Me.BackgroundWorker1.CancellationPending Then

                ' Chargement des Fichiers SZC  
                Me.Chargement_Fichiers_SZC(Nom_Projet, NumeroProjet)

                If Not Me.BackgroundWorker1.CancellationPending Then

                    ' Application.Designer.vb
                    If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                        Me.Generer_My_Namespace()
                    Else
                        CodeDom_CCu = New CodeDom.CodeCompileUnit

                        sourceWriter = New IO.StringWriter()
                        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromCompileUnit(CodeDom_CCu, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
                        sourceWriter.Close()

                        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.Designer.vb") Then
                            My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.Designer.vb", sourceWriter.ToString, False)
                        End If
                        sourceWriter.ToString()
                    End If


                    Me.BackgroundWorker1.ReportProgress(25, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Code"), ((NumeroProjet - 1) * 100) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    i_progress = List_SZW_File.Count + List_SZC_File.Count
                    For Each ite As VelerSoftware.SZVB.Projet.SZW_File In List_SZW_File
                        i_progress += ite.Functions.Count
                    Next
                    For Each ite As VelerSoftware.SZVB.Projet.SZC_File In List_SZC_File
                        i_progress += ite.Functions.Count
                    Next
                    i2_progress = 0

                    ' Fichier SZW
                    Me.Generer_Code_SZW(Nom_Projet, NumeroProjet)




                    ' Fichier SZC
                    Me.Generer_Code_SZC(Nom_Projet, NumeroProjet)




                    i_progress = PROJET.Fichiers_VBNet.Count + List_VBFile.Count
                    i2_progress = 0
                    Me.BackgroundWorker1.ReportProgress(75, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_VBFile"), ((NumeroProjet - 1) * 100) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    ' Fichier .VB incluent 
                    Me.Copier_Fichiers_VB(Nom_Projet, NumeroProjet)


                    i_progress = PROJET.Variables.Count
                    i2_progress = 0
                    Me.BackgroundWorker1.ReportProgress(85, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Variable"), ((NumeroProjet - 1) * 100) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    ' MODULE VARIABLES
                    Me.Generer_Module_Variables(Nom_Projet, NumeroProjet)



                    Me.BackgroundWorker1.ReportProgress(90, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Resx"), ((NumeroProjet - 1) * 100) + 90, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    ' Settings.Designer.vb & Settings.settings
                    Me.Generer_Settings()

                    ' Resources.Designer.vb & Resources.resx
                    Me.Generer_Ressources_Projet()

                    ' AssemblyInfo.vb
                    Me.Generer_AssemblyInfo()


                    Me.BackgroundWorker1.ReportProgress(95, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Resx"), ((NumeroProjet - 1) * 100) + 95, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))


                    ' Application.myapp
                    Me.Generer_Application_MyApp()

                    ' Projet.vbproj
                    Me.Generer_Fichier_Projet()

                    Me.BackgroundWorker1.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Resx"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))

                Else
                    Return False
                End If
            Else
                Return False
            End If

        Else
            Return True
            Me.BackgroundWorker1.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Ignore"), ((NumeroProjet - 1) * 100) + 100, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        End If

        Generation_En_Cours_Projet = Nothing

        Return True
    End Function

    Private Sub Initialisation_CodeDom()
        CodeDom_CCu = New CodeDom.CodeCompileUnit
        CodeDom_Resources_CCu = New CodeDom.CodeCompileUnit

        CodeDom_MyApplication_OnCreateMainForm_Method = New CodeDom.CodeMemberMethod()
        CodeDom_MyApplication_OnCreateSplashScreen_Method = New CodeDom.CodeMemberMethod()

        If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
            CodeDom_MY_NameSpace = New CodeDom.CodeNamespace("My")
            CodeDom_MyApplication_Constructor = New CodeDom.CodeConstructor()
        End If
    End Sub

    Private Sub Generer_My_Namespace()
        ' ApplicationEvents.vb
        Me.Evenements_Application()

        CodeDom_MY_NameSpace.Types.Clear()

        ' Création de la Class "MyApplication"
        CodeDom_MyApplication_Class = New CodeDom.CodeTypeDeclaration("MyApplication")
        With CodeDom_MyApplication_Class
            .IsPartial = True
            .TypeAttributes = CodeDom.MemberAttributes.Family
            .BaseTypes.Clear()
            .BaseTypes.Add(GetType(Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase))
        End With

        ' Sub New
        With CodeDom_MyApplication_Constructor
            .Attributes = CodeDom.MemberAttributes.Public
            .CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
            .BaseConstructorArgs.Add(New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows"))
            .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "IsSingleInstance"), New CodeDom.CodePrimitiveExpression(PROJET.Instance)))
            .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "EnableVisualStyles"), New CodeDom.CodePrimitiveExpression(PROJET.StyleXP)))
            .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "SaveMySettingsOnExit"), New CodeDom.CodePrimitiveExpression(PROJET.MySettings)))
            If PROJET.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose Then
                .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "ShutdownStyle"), New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterAllFormsClose")))
            ElseIf PROJET.ShutMode = VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses Then
                .Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "ShutdownStyle"), New CodeDom.CodeSnippetExpression("Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses")))
            End If
            CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_Constructor)
        End With
        CodeDom_MY_NameSpace.Types.Add(CodeDom_MyApplication_Class)

        ' Sub OnCreateMainForm
        CodeDom_MyApplication_OnCreateMainForm_Method.Name = "OnCreateMainForm"
        CodeDom_MyApplication_OnCreateMainForm_Method.CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
        CodeDom_MyApplication_OnCreateMainForm_Method.Attributes = CodeDom.MemberAttributes.Family Or CodeDom.MemberAttributes.Override
        CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_OnCreateMainForm_Method)

        ' Sub OnCreateSplashScreen
        If Not PROJET.SplashScreen = Nothing Then
            CodeDom_MyApplication_OnCreateSplashScreen_Method.Name = "OnCreateSplashScreen"
            CodeDom_MyApplication_OnCreateSplashScreen_Method.CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Diagnostics.DebuggerStepThroughAttribute"))
            CodeDom_MyApplication_OnCreateSplashScreen_Method.Attributes = CodeDom.MemberAttributes.Family Or CodeDom.MemberAttributes.Override
            CodeDom_MyApplication_Class.Members.Add(CodeDom_MyApplication_OnCreateSplashScreen_Method)
        End If

        CodeDom_CCu = New CodeDom.CodeCompileUnit
        CodeDom_CCu.Namespaces.Add(CodeDom_MY_NameSpace)

        sourceWriter = New IO.StringWriter()
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromCompileUnit(CodeDom_CCu, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        sourceWriter.Close()

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.Designer.vb") Then
            My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.Designer.vb", sourceWriter.ToString, False)
        End If
    End Sub

    Private Sub Evenements_Application()
        ' ApplicationEvents.vb

        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\ApplicationEvents.szc") Then

            ' Création de la Class "MyApplication"
            CodeDom_MyApplication_Class = New CodeDom.CodeTypeDeclaration("MyApplication")
            With CodeDom_MyApplication_Class
                .IsPartial = True
                .TypeAttributes = CodeDom.MemberAttributes.Family
                .BaseTypes.Clear()
                .BaseTypes.Add(GetType(Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase))
            End With

            Tmp_SZC_File = Nothing
            Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(PROJET.Emplacement & "\ApplicationEvents.szc")
            i_function = 0
            For Each txt As String In Tmp_SZC_File.Functions
                i_function += 1

                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_MyApplication_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), PROJET.Emplacement & "\ApplicationEvents.szc", "ApplicationEvents"))
                    Else
                        Select Case DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1
                            Case "Startup"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "Startup", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "Startup")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "Startup"))
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "Shutdown"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "Shutdown", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "_Shutdown")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Name = "_Shutdown"
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "Shutdown"))
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "NetworkAvailabilityChanged"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "NetworkAvailabilityChanged", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "NetworkAvailabilityChanged")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "NetworkAvailabilityChanged"))
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                            Case "StartupNextInstance"
                                CodeDom_MyApplication_Constructor.Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression("MyBase"), "StartupNextInstance", New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), "StartupNextInstance")))
                                CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final Or CodeDom.MemberAttributes.New
                                DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, PROJET.Emplacement & "\ApplicationEvents.szc", "StartupNextInstance"))
                                CodeDom_MyApplication_Class.Members.Add(CodeDom_CodeObject)
                        End Select
                    End If
                End If
            Next

            CodeDom_MY_NameSpace = New CodeDom.CodeNamespace("My")
            CodeDom_MY_NameSpace.Types.Add(CodeDom_MyApplication_Class)

            sourceWriter = New IO.StringWriter()
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromNamespace(CodeDom_MY_NameSpace, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()

            If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\ApplicationEvents.vb") Then
                My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\ApplicationEvents.vb", sourceWriter.ToString, False)
            End If

        End If
    End Sub

    Private Sub Chargement_Fichiers_SZW(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories)
            Tmp_SZW_File = Nothing
            Tmp_SZW_File_Tmp = Nothing
            Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(NomCompletFichier)
            If Not Tmp_SZW_File Is Nothing Then
                Tmp_SZW_File_Tmp = New VelerSoftware.SZVB.Projet.SZW_File_Tmp
                With Tmp_SZW_File_Tmp
                    .Fichier = NomCompletFichier
                    .Functions = Tmp_SZW_File.Functions
                    .Nom = Tmp_SZW_File.Nom
                    .Resources = Tmp_SZW_File.Resources
                    .WINDOWS = Tmp_SZW_File.WINDOWS
                    If List_File_Name.Contains(Tmp_SZW_File.Nom) Then
                        Me.BackgroundWorker1.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Doublon"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                        Me.BackgroundWorker1.CancelAsync()
                        Exit For
                    Else
                        List_File_Name.Add(Tmp_SZW_File.Nom)
                    End If

                    .WINDOWS.Namespaces(0).Types(0).IsPartial = True
                    List_SZW_File.Add(Tmp_SZW_File_Tmp)
                    ' Fenêtre de démarrage
                    If ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.FormStart AndAlso (PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) Then
                        If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then CodeDom_MyApplication_OnCreateMainForm_Method.Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "MainForm"), New CodeDom.CodeSnippetExpression(.WINDOWS.Namespaces(0).Types(0).Name)))
                        Nom_Form_Demarrage = Tmp_SZW_File_Tmp.WINDOWS.Namespaces(0).Types(0).Name
                    End If
                    ' SplashScreen
                    If ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.SplashScreen AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                        Nom_SplashScreen = .WINDOWS.Namespaces(0).Types(0).Name
                        CodeDom_MyApplication_OnCreateSplashScreen_Method.Statements.Add(New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), "SplashScreen"), New CodeDom.CodeSnippetExpression(Nom_SplashScreen)))
                    End If
                End With
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 20) + 5, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Load"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Chargement_Fichiers_SZC(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories)
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
                        Me.BackgroundWorker1.ReportProgress(100, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Doublon"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Pause, False))
                        Me.BackgroundWorker1.CancelAsync()
                        Exit For
                    Else
                        List_File_Name.Add(Tmp_SZC_File.Nom)
                    End If

                    If Not NomCompletFichier = PROJET.Emplacement & "\ApplicationEvents.szc" Then
                        List_SZC_File.Add(Tmp_SZC_File_Tmp)
                        ' Fenêtre de démarrage
                        If ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, NomCompletFichier) = PROJET.FormStart AndAlso (PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) Then Nom_Form_Demarrage = .Nom
                    End If
                End With
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 20) + 5, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Load"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 20) + 5, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_Code_SZW(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        For Each Tmp_SZW_File2 As VelerSoftware.SZVB.Projet.SZW_File_Tmp In List_SZW_File
            Complete_path = Me.Emplacement_Choisit & "\" & PROJET.Nom
            For Each folder As String In ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, Tmp_SZW_File2.Fichier).Split("\")
                If Not folder.ToLower.EndsWith(".szw") AndAlso Not My.Computer.FileSystem.DirectoryExists(Complete_path & "\" & folder) Then
                    My.Computer.FileSystem.CreateDirectory(Complete_path & "\" & folder)
                    Complete_path &= "\" & folder
                End If
            Next

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

            ' Création de la class des fonctions 
            CodeDom_SZW_SZC_Class = New CodeDom.CodeTypeDeclaration(Tmp_SZW_File2.Nom)
            CodeDom_SZW_SZC_Class.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
            CodeDom_SZW_SZC_Class.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final

            i_function = 0
            For Each txt As String In Tmp_SZW_File2.Functions
                i_function += 1

                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_SZW_SZC_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), Tmp_SZW_File2.Fichier, Tmp_SZW_File2.Nom))
                    Else
                        CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                        Dim handl As String = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param2
                        If handl IsNot Nothing Then
                            For i As Integer = 0 To Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members.Count - 1
                                If Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i).Name = "InitializeComponent" Then
                                    DirectCast(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0).Members(i), CodeDom.CodeMemberMethod).Statements.Add(New CodeDom.CodeAttachEventStatement(New CodeDom.CodeSnippetExpression(handl.Split(".")(0)), handl.Split(".")(1), New CodeDom.CodeDelegateCreateExpression(New CodeDom.CodeTypeReference("System.EventHandler"), New CodeDom.CodeThisReferenceExpression(), DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1)))
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
                Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next

            ' Enregistrement du fichier ressource temporaire
            My.Computer.FileSystem.WriteAllText(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".resx"), Tmp_SZW_File2.Resources, True)

            sourceWriter = New IO.StringWriter()
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromType(Tmp_SZW_File2.WINDOWS.Namespaces(0).Types(0), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()

            If Not ClassFichier.IsReadOnly(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".Designer.vb")) Then
                My.Computer.FileSystem.WriteAllText(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".Designer.vb"), sourceWriter.ToString, False)
            End If

            sourceWriter = New IO.StringWriter()
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromType(CodeDom_SZW_SZC_Class, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()

            If Not ClassFichier.IsReadOnly(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".vb")) Then
                My.Computer.FileSystem.WriteAllText(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".vb"), sourceWriter.ToString, False)
                List_Form_File_VB.Add(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZW_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZW_File2.Fichier).Extension, ".vb"))
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_Code_SZC(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        For Each Tmp_SZC_File2 As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
            Complete_path = Me.Emplacement_Choisit & "\" & PROJET.Nom
            For Each folder As String In ClassFichier.Ouvrir_Fichier(PROJET.Emplacement, Tmp_SZC_File2.Fichier).Split("\")
                If Not folder.ToLower.EndsWith(".szc") AndAlso Not My.Computer.FileSystem.DirectoryExists(Complete_path & "\" & folder) Then
                    My.Computer.FileSystem.CreateDirectory(Complete_path & "\" & folder)
                    Complete_path &= "\" & folder
                End If
            Next

            ' Création de la class des fonctions  
            CodeDom_NameSpace = New CodeDom.CodeNamespace(PROJET.Nom)
            CodeDom_SZW_SZC_Class = New CodeDom.CodeTypeDeclaration(Tmp_SZC_File2.Nom)
            CodeDom_SZW_SZC_Class.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
            CodeDom_SZW_SZC_Class.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final

            Dim ok_console_main As Boolean

            i_function = 0
            For Each txt As String In Tmp_SZC_File2.Functions
                i_function += 1

                FunctionWorkflow = Xaml.XamlServices.Load(DirectCast(New System.IO.StringReader(txt), System.IO.TextReader))

                If FunctionWorkflow.GetType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                    If i_function = 1 Then
                        CodeDom_SZW_SZC_Class.Members.AddRange(Add_CodeDom_TypeMember_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), Tmp_SZC_File2.Fichier, Tmp_SZC_File2.Nom))
                    Else
                        If Nom_Form_Demarrage = Tmp_SZC_File2.Nom AndAlso PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole AndAlso DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1 = "Main" Then ok_console_main = True

                        CodeDom_CodeObject = DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).GetVBCode(True)
                        DirectCast(CodeDom_CodeObject, CodeDom.CodeMemberMethod).Statements.AddRange(Add_CodeDom_Recursivity(DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren), False, False, Tmp_SZC_File2.Fichier, DirectCast(FunctionWorkflow, VelerSoftware.Plugins3.ActionWithChildren).Param1))

                        CodeDom_SZW_SZC_Class.Members.Add(CodeDom_CodeObject)
                    End If
                End If

                FunctionWorkflow = Nothing

                i2_progress += 1
                Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next

            sourceWriter = New IO.StringWriter()
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromType(CodeDom_SZW_SZC_Class, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()

            If Not ClassFichier.IsReadOnly(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZC_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZC_File2.Fichier).Extension, ".vb")) Then
                My.Computer.FileSystem.WriteAllText(Complete_path & "\" & My.Computer.FileSystem.GetName(Tmp_SZC_File2.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(Tmp_SZC_File2.Fichier).Extension, ".vb"), sourceWriter.ToString, False)
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 50) + 25, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Code"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 50) + 25, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_Module_Variables(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        Code_Module_Variables = New System.Text.StringBuilder
        With Code_Module_Variables
            .AppendLine("  Module Variables")
            If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                .AppendLine("      Sub Main()")
                .AppendLine("          " & Nom_Form_Demarrage & ".Main")
                .AppendLine("      End Sub")
            ElseIf PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
                .AppendLine("      Public _manager As My.MyApplication = New My.MyApplication")
                .AppendLine("      Public _computer As Microsoft.VisualBasic.Devices.Computer = New Microsoft.VisualBasic.Devices.Computer")
            End If
            For Each var As VelerSoftware.SZVB.Projet.Variable In PROJET.Variables
                If var.Array Then
                    .AppendLine("      Public " & var.Name & " As New System.Collections.Generic.List(Of System.Object) ' " & var.Description)
                Else
                    .AppendLine("      Public " & var.Name & " As New System.Object ' " & var.Description)
                End If

                i2_progress += 1
                Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 5) + 85, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_Variable"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 85, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
            Next
            For Each szwfi As VelerSoftware.SZVB.Projet.SZC_File_Tmp In List_SZC_File
                .AppendLine("      Public Property " & szwfi.Nom & " As New Global." & PROJET.Nom & "." & szwfi.Nom & "() ' Class " & szwfi.Nom)
            Next
            .AppendLine("  End Module")
        End With

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Variables_Module.vb") Then
            My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Variables_Module.vb", Code_Module_Variables.ToString, False)
        End If
    End Sub

    Private Sub Copier_Fichiers_VB(ByVal Nom_Projet As String, ByVal NumeroProjet As Integer)
        Code_VB_Files = New System.Text.StringBuilder
        For Each fi As String In List_VBFile
            Complete_path = Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Include"
            For Each folder As String In fi.Split("\")
                If My.Computer.FileSystem.DirectoryExists(Complete_path & "\" & folder) Then
                    My.Computer.FileSystem.CreateDirectory(Complete_path & "\" & folder)
                End If
                Complete_path &= "\" & folder
            Next
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", fi)) Then
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", fi), Complete_path, True)
            ElseIf My.Computer.FileSystem.FileExists(fi) Then
                My.Computer.FileSystem.CopyFile(fi, Complete_path, True)
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 5) + 75, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_VBFile"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
        For Each fi As String In PROJET.Fichiers_VBNet
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi)) Then
                Complete_path = Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Include"
                For Each folder As String In fi.Split("\")
                    If My.Computer.FileSystem.DirectoryExists(Complete_path & "\" & folder) Then
                        My.Computer.FileSystem.CreateDirectory(Complete_path & "\" & folder)
                    End If
                    Complete_path &= "\" & folder
                Next
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, fi), Complete_path, True)
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress(((i2_progress / i_progress) * 5) + 75, New GenerationProgress(Nom_Projet, RM.GetString("Exportation_Project_VBFile"), ((NumeroProjet - 1) * 100) + ((i2_progress / i_progress) * 5) + 75, VelerSoftware.SZC.ProgressBar.ProgressBarState.Normal, True))
        Next
    End Sub

    Private Sub Generer_AssemblyInfo()
        CodeDom_CCu = New CodeDom.CodeCompileUnit

        ' Ajout des Attributs de l'Assembly
        With CodeDom_CCu
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyTitleAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Title))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyVersionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_AssemblyVersion))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyCopyrightAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Copyright))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyDescriptionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Description))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyFileVersionAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_FileVersion))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Runtime.InteropServices.GuidAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Guid))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyTrademarkAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Mark))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyProductAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Product))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Reflection.AssemblyCompanyAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(PROJET.Assembly_Socity))}))
            .AssemblyCustomAttributes.Add(New CodeDom.CodeAttributeDeclaration(New CodeDom.CodeTypeReference(GetType(System.Runtime.InteropServices.ComVisibleAttribute), New CodeDom.CodeTypeReferenceOptions()), New CodeDom.CodeAttributeArgument() {New CodeDom.CodeAttributeArgument("", New CodeDom.CodePrimitiveExpression(True))}))
        End With

        sourceWriter = New IO.StringWriter()
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromCompileUnit(CodeDom_CCu, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        sourceWriter.Close()

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\AssemblyInfo.vb") Then
            My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\AssemblyInfo.vb", sourceWriter.ToString, False)
        End If
    End Sub

    Private Sub Generer_Settings()
        Code_MySettings = New System.Text.StringBuilder
        If PROJET.Parametres.Count > 0 Then
            With Code_MySettings
                .AppendLine("NameSpace My")
                .AppendLine("    Partial Friend NotInheritable Class MySettings")
                .AppendLine("        Inherits Global.System.Configuration.ApplicationSettingsBase")
                .AppendLine("        Private Shared defaultInstance As MySettings = DirectCast(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)")
                .AppendLine("#If _MyType = " & ChrW(34) & "WindowsForms" & ChrW(34) & " Then")
                .AppendLine("        Private Shared addedHandler As Boolean")
                .AppendLine("        Private Shared addedHandlerLockObject As New Object")
                .AppendLine("        Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)")
                .AppendLine("            If _manager.SaveMySettingsOnExit Then")
                .AppendLine("                My.Settings.Save()")
                .AppendLine("            End If")
                .AppendLine("        End Sub")
                .AppendLine("#End If")
                .AppendLine("        Public Shared ReadOnly Property [Default]() As MySettings")
                .AppendLine("            Get")
                .AppendLine("#If _MyType = " & ChrW(34) & "WindowsForms" & ChrW(34) & " Then")
                .AppendLine("                If Not addedHandler Then")
                .AppendLine("                    SyncLock addedHandlerLockObject")
                .AppendLine("                        If Not addedHandler Then")
                .AppendLine("                            AddHandler _manager.Shutdown, AddressOf AutoSaveSettings")
                .AppendLine("                            addedHandler = True")
                .AppendLine("                        End If")
                .AppendLine("                    End SyncLock")
                .AppendLine("                End If")
                .AppendLine("#End If")
                .AppendLine("                Return defaultInstance")
                .AppendLine("            End Get")
                .AppendLine("        End Property")
                .AppendLine()
                For Each sett As String In PROJET.Parametres
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
                .AppendLine("    Friend Module MySettingsProperty")
                .AppendLine("        <Global.System.ComponentModel.Design.HelpKeywordAttribute(" & ChrW(34) & "My.Settings" & ChrW(34) & ")>  _")
                .AppendLine("        Friend ReadOnly Property Settings() As My.MySettings")
                .AppendLine("            Get")
                .AppendLine("                Return My.MySettings.Default")
                .AppendLine("            End Get")
                .AppendLine("        End Property")
                .AppendLine("    End Module")
                .AppendLine("End NameSpace")
            End With

            If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.Designer.vb") Then
                My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.Designer.vb", Code_MySettings.ToString, False)
            End If
        End If




        Dim XmlDoc As System.Xml.XmlDocument
        Dim elemBox_Project As System.Xml.XmlElement
        Dim elemSub_PropertyGroup, elemSub_Other As System.Xml.XmlElement
        Dim XmlAttribut As System.Xml.XmlAttribute

        XmlDoc = New System.Xml.XmlDocument()
        XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

        ' SettingsFile
        elemBox_Project = XmlDoc.CreateElement("SettingsFile")
        XmlAttribut = XmlDoc.CreateAttribute("xmlns")
        XmlAttribut.Value = "http://schemas.microsoft.com/VisualStudio/2004/01/settings"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("CurrentProfile")
        XmlAttribut.Value = "(Default)"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("GeneratedClassNamespace")
        XmlAttribut.Value = "My"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("GeneratedClassName")
        XmlAttribut.Value = "MySettings"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("UseMySettingsClassName")
        XmlAttribut.Value = "true"
        elemBox_Project.Attributes.Append(XmlAttribut)

        ' Profile
        elemSub_PropertyGroup = XmlDoc.CreateElement("Profile")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' Settings
        elemSub_PropertyGroup = XmlDoc.CreateElement("Settings")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        For Each sett As String In PROJET.Parametres
            ' Setting
            elemSub_Other = XmlDoc.CreateElement("Setting")
            XmlAttribut = XmlDoc.CreateAttribute("Name")
            XmlAttribut.Value = sett
            elemSub_Other.Attributes.Append(XmlAttribut)
            XmlAttribut = XmlDoc.CreateAttribute("Description")
            XmlAttribut.Value = ""
            elemSub_Other.Attributes.Append(XmlAttribut)
            XmlAttribut = XmlDoc.CreateAttribute("Type")
            XmlAttribut.Value = "System.Object"
            elemSub_Other.Attributes.Append(XmlAttribut)
            XmlAttribut = XmlDoc.CreateAttribute("Scope")
            XmlAttribut.Value = "User"
            elemSub_Other.Attributes.Append(XmlAttribut)

            elemSub_PropertyGroup.AppendChild(elemSub_Other)
        Next

        XmlDoc.AppendChild(elemBox_Project)

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.settings") Then
            'Ecriture du Xml
            XmlDoc.Save(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.settings")
        End If
    End Sub

    Private Sub Generer_Ressources_Projet()
        If PROJET.Ressources.Count > 0 AndAlso Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Resources.resx") Then
            Dim resxwr As New Resources.ResXResourceWriter(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Resources.resx")
            With resxwr
                For Each res As VelerSoftware.SZVB.Projet.Ressource In PROJET.Ressources
                    Select Case res.Type
                        Case VelerSoftware.SZVB.Projet.Ressource.Types.Image
                            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) Then
                                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value), Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)), True)
                                .AddResource(New System.Resources.ResXDataNode(res.Name, New System.Resources.ResXFileRef("..\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)), "System.Drawing.Bitmap, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), AddressOf convert_TypeString))
                                '.AddResource(res.Name, "..\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) & ";System.Drawing.Bitmap, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")
                            End If
                        Case VelerSoftware.SZVB.Projet.Ressource.Types.Texte
                            .AddResource(res.Name, res.Value)
                        Case VelerSoftware.SZVB.Projet.Ressource.Types.Fichier
                            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) Then
                                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value), Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)), True)
                                .AddResource(New System.Resources.ResXDataNode(res.Name, New System.Resources.ResXFileRef("..\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)), "System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"), AddressOf convert_TypeString))
                                '.AddResource(res.Name, "..\Resources\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, res.Value)) & ";System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                            End If
                    End Select
                Next
                .Close()
            End With

            CodeDom_CCu = New CodeDom.CodeCompileUnit
            CodeDom_Resources_CCu = Resources.Tools.StronglyTypedResourceBuilder.Create(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Resources.resx", "Resources", "My", CodeDom.Compiler.CodeDomProvider.CreateProvider("VB"), True, New String() {"Error"})
            CodeDom_CCu.Namespaces.Add(CodeDom_Resources_CCu.Namespaces(0))

            sourceWriter = New IO.StringWriter()
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromCompileUnit(CodeDom_CCu, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()

            If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Resources.Designer.vb") Then
                My.Computer.FileSystem.WriteAllText(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Resources.Designer.vb", sourceWriter.ToString, False)
            End If
        End If

    End Sub

    Private Function convert_TypeString(name As Type) As String
        Return "System.Resources.ResXFileRef, System.Windows.Forms"
    End Function

    Private Function Generer_Application_MyApp() As Boolean
        Dim resultat As Boolean

        Dim XmlDoc As System.Xml.XmlDocument
        Dim elemBox_Project As System.Xml.XmlElement
        Dim elemSub_Other As System.Xml.XmlElement
        Dim XmlAttribut As System.Xml.XmlAttribute

        XmlDoc = New System.Xml.XmlDocument()
        XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

        ' Project
        elemBox_Project = XmlDoc.CreateElement("MyApplicationData")
        XmlAttribut = XmlDoc.CreateAttribute("xmlns:xsi")
        XmlAttribut.Value = "http://www.w3.org/2001/XMLSchema-instance"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("xmlns:xsd")
        XmlAttribut.Value = "http://www.w3.org/2001/XMLSchema"
        elemBox_Project.Attributes.Append(XmlAttribut)

        ' MySubMain
        elemSub_Other = XmlDoc.CreateElement("MySubMain")
        If PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows Then
            elemSub_Other.InnerText = "true"
        Else
            elemSub_Other.InnerText = "false"
        End If
        elemBox_Project.AppendChild(elemSub_Other)

        If Not PROJET.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
            ' MainForm
            elemSub_Other = XmlDoc.CreateElement("MainForm")
            elemSub_Other.InnerText = Nom_Form_Demarrage
            elemBox_Project.AppendChild(elemSub_Other)

            ' SingleInstance
            elemSub_Other = XmlDoc.CreateElement("SingleInstance")
            elemSub_Other.InnerText = PROJET.Instance
            elemBox_Project.AppendChild(elemSub_Other)

            ' ShutdownMode
            elemSub_Other = XmlDoc.CreateElement("ShutdownMode")
            elemSub_Other.InnerText = CInt(PROJET.ShutMode)
            elemBox_Project.AppendChild(elemSub_Other)

            ' EnableVisualStyles
            elemSub_Other = XmlDoc.CreateElement("EnableVisualStyles")
            elemSub_Other.InnerText = PROJET.StyleXP
            elemBox_Project.AppendChild(elemSub_Other)

            ' AuthenticationMode
            elemSub_Other = XmlDoc.CreateElement("AuthenticationMode")
            elemSub_Other.InnerText = "0"
            elemBox_Project.AppendChild(elemSub_Other)

            If Not PROJET.SplashScreen = Nothing Then
                ' SplashScreen
                elemSub_Other = XmlDoc.CreateElement("SplashScreen")
                elemSub_Other.InnerText = Nom_SplashScreen
                elemBox_Project.AppendChild(elemSub_Other)
            End If

            ' SaveMySettingsOnExit
            elemSub_Other = XmlDoc.CreateElement("SaveMySettingsOnExit")
            elemSub_Other.InnerText = PROJET.MySettings
            elemBox_Project.AppendChild(elemSub_Other)
        End If

        ' EnableVisualStyles
        elemSub_Other = XmlDoc.CreateElement("ApplicationType")
        Select Case PROJET.Type
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                elemSub_Other.InnerText = "2"
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                elemSub_Other.InnerText = "0"
            Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                elemSub_Other.InnerText = "1"
        End Select
        elemBox_Project.AppendChild(elemSub_Other)

        XmlDoc.AppendChild(elemBox_Project)

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.myapp") Then
            'Ecriture du Xml
            XmlDoc.Save(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.myapp")
            resultat = True
        End If

        Return resultat
    End Function

    Private Function Generer_Fichier_Projet() As Boolean
        Dim resultat As Boolean

        Dim XmlDoc As System.Xml.XmlDocument
        Dim elemBox_Project As System.Xml.XmlElement
        Dim elemSub_PropertyGroup, elemSub_Other, elemSub_Other2 As System.Xml.XmlElement
        Dim XmlAttribut As System.Xml.XmlAttribute

        XmlDoc = New System.Xml.XmlDocument()
        XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))

        ' Project
        elemBox_Project = XmlDoc.CreateElement("Project")
        XmlAttribut = XmlDoc.CreateAttribute("ToolsVersion")
        XmlAttribut.Value = "4.0"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("DefaultTargets")
        XmlAttribut.Value = "Build"
        elemBox_Project.Attributes.Append(XmlAttribut)
        XmlAttribut = XmlDoc.CreateAttribute("xmlns")
        XmlAttribut.Value = "http://schemas.microsoft.com/developer/msbuild/2003"
        elemBox_Project.Attributes.Append(XmlAttribut)




        ' PropertyGroup (1 er)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' Configuration
        elemSub_Other = XmlDoc.CreateElement("Configuration")
        XmlAttribut = XmlDoc.CreateAttribute("Condition")
        XmlAttribut.Value = " '$(Configuration)' == '' "
        elemSub_Other.Attributes.Append(XmlAttribut)
        elemSub_Other.InnerText = "Debug"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' Platform
        elemSub_Other = XmlDoc.CreateElement("Platform")
        XmlAttribut = XmlDoc.CreateAttribute("Condition")
        XmlAttribut.Value = " '$(Platform)' == '' "
        elemSub_Other.Attributes.Append(XmlAttribut)
        elemSub_Other.InnerText = "x86"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' ProductVersion
        elemSub_Other = XmlDoc.CreateElement("ProductVersion")
        elemSub_Other.InnerText = ""
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' SchemaVersion
        elemSub_Other = XmlDoc.CreateElement("SchemaVersion")
        elemSub_Other.InnerText = "2.0"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' AppDesignerFolder
        elemSub_Other = XmlDoc.CreateElement("AppDesignerFolder")
        elemSub_Other.InnerText = "My Project"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' ProjectGuid
        elemSub_Other = XmlDoc.CreateElement("ProjectGuid")
        elemSub_Other.InnerText = "{" & PROJET.Assembly_Guid & "}"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' OutputType
        elemSub_Other = XmlDoc.CreateElement("OutputType")
        Select Case PROJET.Type
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                elemSub_Other.InnerText = "Exe"
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                elemSub_Other.InnerText = "WinExe"
            Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                elemSub_Other.InnerText = "Library"
        End Select
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' OutputType
        elemSub_Other = XmlDoc.CreateElement("StartupObject")
        Select Case PROJET.Type
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                elemSub_Other.InnerText = "Sub Main"
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                elemSub_Other.InnerText = PROJET.Nom & "." & Nom_Form_Demarrage
            Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                elemSub_Other.InnerText = "(Aucune)"
        End Select
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' SchemaVersion
        elemSub_Other = XmlDoc.CreateElement("StartupObject")
        Select Case PROJET.Type
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                elemSub_Other.InnerText = "Sub Main"
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                elemSub_Other.InnerText = PROJET.Nom & ".My.MyApplication"
            Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                elemSub_Other.InnerText = ""
        End Select
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' RootNamespace
        elemSub_Other = XmlDoc.CreateElement("RootNamespace")
        elemSub_Other.InnerText = PROJET.Nom
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' AssemblyName
        elemSub_Other = XmlDoc.CreateElement("AssemblyName")
        elemSub_Other.InnerText = PROJET.Nom
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' FileAlignment
        elemSub_Other = XmlDoc.CreateElement("FileAlignment")
        elemSub_Other.InnerText = "512"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' MyType
        elemSub_Other = XmlDoc.CreateElement("MyType")
        Select Case PROJET.Type
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                elemSub_Other.InnerText = "Console"
            Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                elemSub_Other.InnerText = "WindowsForms"
            Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                elemSub_Other.InnerText = "Windows"
        End Select
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' TargetFrameworkVersion
        elemSub_Other = XmlDoc.CreateElement("TargetFrameworkVersion")
        elemSub_Other.InnerText = "4.0"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' TargetFrameworkProfile
        elemSub_Other = XmlDoc.CreateElement("TargetFrameworkProfile")
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (2 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        XmlAttribut = XmlDoc.CreateAttribute("Condition")
        XmlAttribut.Value = " '$(Configuration)|$(Platform)' == 'Debug|x86' "
        elemSub_PropertyGroup.Attributes.Append(XmlAttribut)
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("PlatformTarget")
        elemSub_Other.InnerText = "x86"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DebugSymbols
        elemSub_Other = XmlDoc.CreateElement("DebugSymbols")
        elemSub_Other.InnerText = "true"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DebugType
        elemSub_Other = XmlDoc.CreateElement("DebugType")
        elemSub_Other.InnerText = "full"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DefineDebug
        elemSub_Other = XmlDoc.CreateElement("DefineDebug")
        elemSub_Other.InnerText = "true"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DefineTrace
        elemSub_Other = XmlDoc.CreateElement("DefineTrace")
        elemSub_Other.InnerText = "true"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' OutputPath
        elemSub_Other = XmlDoc.CreateElement("OutputPath")
        elemSub_Other.InnerText = "bin\Debug\"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DocumentationFile
        elemSub_Other = XmlDoc.CreateElement("DocumentationFile")
        elemSub_Other.InnerText = PROJET.Nom & ".xml"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' NoWarn
        elemSub_Other = XmlDoc.CreateElement("NoWarn")
        elemSub_Other.InnerText = "42016,41999,42017,42018,42019,42032,42036,42020,42021,42022"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (3 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        XmlAttribut = XmlDoc.CreateAttribute("Condition")
        XmlAttribut.Value = " '$(Configuration)|$(Platform)' == 'Release|x86' "
        elemSub_PropertyGroup.Attributes.Append(XmlAttribut)
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("PlatformTarget")
        elemSub_Other.InnerText = "x86"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DebugType
        elemSub_Other = XmlDoc.CreateElement("DebugType")
        elemSub_Other.InnerText = "pdbonly"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DefineDebug
        elemSub_Other = XmlDoc.CreateElement("DefineDebug")
        elemSub_Other.InnerText = "false"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DefineTrace
        elemSub_Other = XmlDoc.CreateElement("DefineTrace")
        elemSub_Other.InnerText = "true"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' Optimize
        elemSub_Other = XmlDoc.CreateElement("Optimize")
        elemSub_Other.InnerText = "true"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' OutputPath
        elemSub_Other = XmlDoc.CreateElement("OutputPath")
        elemSub_Other.InnerText = "bin\Release\"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' DocumentationFile
        elemSub_Other = XmlDoc.CreateElement("DocumentationFile")
        elemSub_Other.InnerText = PROJET.Nom & ".xml"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        ' NoWarn
        elemSub_Other = XmlDoc.CreateElement("NoWarn")
        elemSub_Other.InnerText = "42016,41999,42017,42018,42019,42032,42036,42020,42021,42022"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (4 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("OptionExplicit")
        elemSub_Other.InnerText = "On"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (5 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("OptionCompare")
        elemSub_Other.InnerText = "Binary"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (6 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("OptionStrict")
        elemSub_Other.InnerText = "Off"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (7 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        ' PlatformTarget
        elemSub_Other = XmlDoc.CreateElement("OptionInfer")
        elemSub_Other.InnerText = "On"
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        If My.Computer.FileSystem.FileExists(PROJET.Emplacement & "\icon.ico") Then
            My.Computer.FileSystem.CopyFile(PROJET.Emplacement & "\icon.ico", Me.Emplacement_Choisit & "\" & PROJET.Nom & "\icon.ico", True)
            ' PropertyGroup (7 ème)
            elemSub_PropertyGroup = XmlDoc.CreateElement("PropertyGroup")
            elemBox_Project.AppendChild(elemSub_PropertyGroup)

            ' PlatformTarget
            elemSub_Other = XmlDoc.CreateElement("ApplicationIcon")
            elemSub_Other.InnerText = "icon.ico"
            elemSub_PropertyGroup.AppendChild(elemSub_Other)
        End If




        ' PropertyGroup (8 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        For Each ref As VelerSoftware.SZVB.Projet.Reference In PROJET.References
            If Not ref.Name = "mscorlib" AndAlso Not ref.IsProject Then
                ' Reference
                elemSub_Other = XmlDoc.CreateElement("Reference")
                XmlAttribut = XmlDoc.CreateAttribute("Include")
                XmlAttribut.Value = ref.Name
                elemSub_Other.Attributes.Append(XmlAttribut)
                If ref.Copy Then
                    elemSub_Other2 = XmlDoc.CreateElement("HintPath")
                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", ref.FullName)) Then
                        My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", ref.FullName), Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Include\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", ref.FullName)), True)
                        elemSub_Other2.InnerText = "Include\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", ref.FullName))
                    ElseIf My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, ref.FullName)) Then
                        My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, ref.FullName), Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Include\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, ref.FullName)), True)
                        elemSub_Other2.InnerText = "Include\" & My.Computer.FileSystem.GetName(My.Computer.FileSystem.CombinePath(PROJET.Emplacement, ref.FullName))
                    ElseIf My.Computer.FileSystem.FileExists(ref.FullName) Then
                        My.Computer.FileSystem.CopyFile(ref.FullName, Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Include\" & My.Computer.FileSystem.GetName(ref.FullName), True)
                        elemSub_Other2.InnerText = "Include\" & My.Computer.FileSystem.GetName(ref.FullName)
                    End If
                    elemSub_Other.AppendChild(elemSub_Other2)
                End If
                elemSub_PropertyGroup.AppendChild(elemSub_Other)
            End If
        Next




        ' PropertyGroup (8 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        elemSub_Other = XmlDoc.CreateElement("Import")
        XmlAttribut = XmlDoc.CreateAttribute("Include")
        XmlAttribut.Value = "Microsoft.VisualBasic"
        elemSub_Other.Attributes.Append(XmlAttribut)
        elemSub_PropertyGroup.AppendChild(elemSub_Other)

        elemSub_Other = XmlDoc.CreateElement("Import")
        XmlAttribut = XmlDoc.CreateAttribute("Include")
        XmlAttribut.Value = "System"
        elemSub_Other.Attributes.Append(XmlAttribut)
        elemSub_PropertyGroup.AppendChild(elemSub_Other)




        ' PropertyGroup (9 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)

        For Each ref As VelerSoftware.SZVB.Projet.Reference In PROJET.References
            If ref.IsProject Then
                ' Reference
                elemSub_Other = XmlDoc.CreateElement("ProjectReference")
                XmlAttribut = XmlDoc.CreateAttribute("Include")
                XmlAttribut.Value = "..\" & ref.Name & "\" & ref.Name & ".vbproj"
                elemSub_Other.Attributes.Append(XmlAttribut)

                elemSub_Other2 = XmlDoc.CreateElement("Project")
                elemSub_Other2.InnerText = "{" & SOLUTION.GetProject(ref.Name).Assembly_Guid & "}"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_Other2 = XmlDoc.CreateElement("Name")
                elemSub_Other2.InnerText = ref.Name
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_PropertyGroup.AppendChild(elemSub_Other)
            End If
        Next





        elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)
        For Each fi As String In System.IO.Directory.GetFiles(Me.Emplacement_Choisit & "\" & PROJET.Nom, "*.vb", System.IO.SearchOption.AllDirectories)
            elemSub_Other = XmlDoc.CreateElement("Compile")
            XmlAttribut = XmlDoc.CreateAttribute("Include")
            XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(Me.Emplacement_Choisit & "\" & PROJET.Nom, fi)
            elemSub_Other.Attributes.Append(XmlAttribut)

            If List_Form_File_VB.Contains(fi) Then
                elemSub_Other2 = XmlDoc.CreateElement("SubType")
                elemSub_Other2.InnerText = "Form"
                elemSub_Other.AppendChild(elemSub_Other2)
            End If

            If XmlAttribut.Value = "My Project\Application.Designer.vb" Then
                elemSub_Other2 = XmlDoc.CreateElement("AutoGen")
                elemSub_Other2.InnerText = "True"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("DependentUpon")
                elemSub_Other2.InnerText = "Application.myapp"
                elemSub_Other.AppendChild(elemSub_Other2)
            ElseIf XmlAttribut.Value = "My Project\Resources.Designer.vb" Then
                elemSub_Other2 = XmlDoc.CreateElement("AutoGen")
                elemSub_Other2.InnerText = "True"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("DesignTime")
                elemSub_Other2.InnerText = "True"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("DependentUpon")
                elemSub_Other2.InnerText = "Resources.resx"
                elemSub_Other.AppendChild(elemSub_Other2)
            ElseIf XmlAttribut.Value = "My Project\Settings.Designer.vb" Then
                elemSub_Other2 = XmlDoc.CreateElement("AutoGen")
                elemSub_Other2.InnerText = "True"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("DesignTimeSharedInput")
                elemSub_Other2.InnerText = "True"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("DependentUpon")
                elemSub_Other2.InnerText = "Settings.settings"
                elemSub_Other.AppendChild(elemSub_Other2)
            ElseIf XmlAttribut.Value.EndsWith(".Designer.vb") Then
                elemSub_Other2 = XmlDoc.CreateElement("DependentUpon")
                elemSub_Other2.InnerText = My.Computer.FileSystem.GetName(fi).Replace(".Designer.vb", ".vb")
                elemSub_Other.AppendChild(elemSub_Other2)
            End If

            elemSub_PropertyGroup.AppendChild(elemSub_Other)
        Next




        elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
        elemBox_Project.AppendChild(elemSub_PropertyGroup)
        For Each fi As String In System.IO.Directory.GetFiles(Me.Emplacement_Choisit & "\" & PROJET.Nom, "*.resx", System.IO.SearchOption.AllDirectories)
            elemSub_Other = XmlDoc.CreateElement("EmbeddedResource")
            XmlAttribut = XmlDoc.CreateAttribute("Include")
            XmlAttribut.Value = ClassFichier.Ouvrir_Fichier(Me.Emplacement_Choisit & "\" & PROJET.Nom, fi)
            elemSub_Other.Attributes.Append(XmlAttribut)
            If XmlAttribut.Value = "My Project\Resources.resx" Then
                elemSub_Other2 = XmlDoc.CreateElement("Generator")
                elemSub_Other2.InnerText = "VbMyResourcesResXFileCodeGenerator"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("LastGenOutput")
                elemSub_Other2.InnerText = "Resources.Designer.vb"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("CustomToolNamespace")
                elemSub_Other2.InnerText = "My"
                elemSub_Other.AppendChild(elemSub_Other2)
                elemSub_Other2 = XmlDoc.CreateElement("SubType")
                elemSub_Other2.InnerText = "Designers"
                elemSub_Other.AppendChild(elemSub_Other2)
            Else
                elemSub_Other2 = XmlDoc.CreateElement("DependentUpon")
                elemSub_Other2.InnerText = My.Computer.FileSystem.GetName(fi).Replace(My.Computer.FileSystem.GetFileInfo(fi).Extension, ".vb")
                elemSub_Other.AppendChild(elemSub_Other2)
            End If

            elemSub_PropertyGroup.AppendChild(elemSub_Other)
        Next



        If My.Computer.FileSystem.FileExists(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.myapp") OrElse My.Computer.FileSystem.FileExists(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.settings") Then
            elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
            elemBox_Project.AppendChild(elemSub_PropertyGroup)

            If My.Computer.FileSystem.FileExists(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Application.myapp") Then
                elemSub_Other = XmlDoc.CreateElement("None")
                XmlAttribut = XmlDoc.CreateAttribute("Include")
                XmlAttribut.Value = "My Project\Application.myapp"
                elemSub_Other.Attributes.Append(XmlAttribut)

                elemSub_Other2 = XmlDoc.CreateElement("Generator")
                elemSub_Other2.InnerText = "MyApplicationCodeGenerator"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_Other2 = XmlDoc.CreateElement("LastGenOutput")
                elemSub_Other2.InnerText = "Application.Designer.vb"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_PropertyGroup.AppendChild(elemSub_Other)
            End If

            If My.Computer.FileSystem.FileExists(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\My Project\Settings.settings") Then
                elemSub_Other = XmlDoc.CreateElement("None")
                XmlAttribut = XmlDoc.CreateAttribute("Include")
                XmlAttribut.Value = "My Project\Settings.settings"
                elemSub_Other.Attributes.Append(XmlAttribut)

                elemSub_Other2 = XmlDoc.CreateElement("Generator")
                elemSub_Other2.InnerText = "SettingsSingleFileGenerator"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_Other2 = XmlDoc.CreateElement("LastGenOutput")
                elemSub_Other2.InnerText = "Settings.Designer.vb"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_Other2 = XmlDoc.CreateElement("CustomToolNamespace")
                elemSub_Other2.InnerText = "My"
                elemSub_Other.AppendChild(elemSub_Other2)

                elemSub_PropertyGroup.AppendChild(elemSub_Other)
            End If
        End If




        For Each fi As String In System.IO.Directory.GetFiles(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\Resources", "*.*", System.IO.SearchOption.AllDirectories)
            elemSub_PropertyGroup = XmlDoc.CreateElement("ItemGroup")
            elemBox_Project.AppendChild(elemSub_PropertyGroup)

            elemSub_Other = XmlDoc.CreateElement("None")
            XmlAttribut = XmlDoc.CreateAttribute("Include")
            XmlAttribut.Value = "Resources\" & My.Computer.FileSystem.GetName(fi)
            elemSub_Other.Attributes.Append(XmlAttribut)

            elemSub_PropertyGroup.AppendChild(elemSub_Other)
        Next





        ' PropertyGroup (3 ème)
        elemSub_PropertyGroup = XmlDoc.CreateElement("Import")
        XmlAttribut = XmlDoc.CreateAttribute("Project")
        XmlAttribut.Value = "$(MSBuildToolsPath)\Microsoft.VisualBasic.targets"
        elemSub_PropertyGroup.Attributes.Append(XmlAttribut)
        elemBox_Project.AppendChild(elemSub_PropertyGroup)






        XmlDoc.AppendChild(elemBox_Project)

        If Not ClassFichier.IsReadOnly(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\" & PROJET.Nom & ".vbproj") Then
            'Ecriture du Xml
            XmlDoc.Save(Me.Emplacement_Choisit & "\" & PROJET.Nom & "\" & PROJET.Nom & ".vbproj")
            resultat = True
        End If

        Return resultat
    End Function

    Private Function Add_CodeDom_Recursivity(ByVal Root As VelerSoftware.Plugins3.ActionWithChildren, ByVal condition As Boolean, ByVal alors As Boolean, ByVal nom_fichier As String, ByVal nom_fonction As String) As CodeDom.CodeStatementCollection
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), Root.DisplayName, nom_fonction, nom_fichier)))

        Dim result As New CodeDom.CodeStatementCollection

        If (Not Root.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(Root.ClassCode)) Then List_VBFile.Add(Root.ClassCode)

        Dim cod As CodeDom.CodeObject
        If Not condition Then
            For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
                Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), aaa.DisplayName, nom_fonction, nom_fichier)))

                If (Not aaa.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(aaa.ClassCode)) Then List_VBFile.Add(aaa.ClassCode)
                cod = aaa.GetVBCode(True)
                If Not cod Is Nothing Then
                    '''
                    If TypeOf cod Is CodeDom.CodeConditionStatement Then
                        DirectCast(cod, CodeDom.CodeConditionStatement).TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                        DirectCast(cod, CodeDom.CodeConditionStatement).FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
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
                    Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), aaa.DisplayName, nom_fonction, nom_fichier)))

                    If (Not aaa.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(aaa.ClassCode)) Then List_VBFile.Add(aaa.ClassCode)
                    cod = aaa.GetVBCode(True)
                    If Not cod Is Nothing Then
                        '''
                        If TypeOf cod Is CodeDom.CodeConditionStatement Then
                            DirectCast(cod, CodeDom.CodeConditionStatement).TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                            DirectCast(cod, CodeDom.CodeConditionStatement).FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
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
                For Each aaa As VelerSoftware.Plugins3.Action In DirectCast(DirectCast(Root, Object).Children_Actions2, Generic.List(Of VelerSoftware.Plugins3.Action))
                    Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), aaa.DisplayName, nom_fonction, nom_fichier)))

                    If (Not aaa.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(aaa.ClassCode)) Then List_VBFile.Add(aaa.ClassCode)
                    cod = aaa.GetVBCode(True)
                    If Not cod Is Nothing Then
                        '''
                        If TypeOf cod Is CodeDom.CodeConditionStatement Then
                            DirectCast(cod, CodeDom.CodeConditionStatement).TrueStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, True, nom_fichier, nom_fonction))
                            DirectCast(cod, CodeDom.CodeConditionStatement).FalseStatements.AddRange(Add_CodeDom_Recursivity(aaa, True, False, nom_fichier, nom_fonction))
                            result.Add(DirectCast(cod, CodeDom.CodeConditionStatement))
                        ElseIf TypeOf cod Is CodeDom.CodeStatement Then
                            result.Add(DirectCast(cod, CodeDom.CodeStatement))
                        ElseIf TypeOf cod Is CodeDom.CodeExpression Then
                            result.Add(DirectCast(cod, CodeDom.CodeExpression))
                        End If
                        If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso aaa.Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
                    End If
                Next
            End If
        End If

        Return result
    End Function

    Private Function Add_CodeDom_TypeMember_Recursivity(ByVal Root As VelerSoftware.Plugins3.ActionWithChildren, ByVal nom_fichier As String, ByVal nom_fonction As String) As CodeDom.CodeTypeMemberCollection
        Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), Root.DisplayName, nom_fonction, nom_fichier)))

        Dim result As New CodeDom.CodeTypeMemberCollection

        If (Not Root.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(Root.ClassCode)) Then List_VBFile.Add(Root.ClassCode)

        Dim cod As CodeDom.CodeObject
        For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
            Log_Generation.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Generation_Action"), aaa.DisplayName, nom_fonction, nom_fichier)))

            If (Not aaa.ClassCode = Nothing) AndAlso (Not List_VBFile.Contains(aaa.ClassCode)) Then List_VBFile.Add(aaa.ClassCode)
            cod = aaa.GetVBCode(False)
            If Not cod Is Nothing Then
                If TypeOf cod Is CodeDom.CodeTypeMember Then
                    result.Add(DirectCast(cod, CodeDom.CodeTypeMember))
                ElseIf TypeOf cod Is CodeDom.CodeObject Then
                    result.Add(DirectCast(cod, CodeDom.CodeObject))
                End If
                If cod.GetType.GetProperty("Statements") IsNot Nothing AndAlso aaa.Children_Actions.Count > 0 Then DirectCast(DirectCast(cod, Object).Statements, CodeDom.CodeStatementCollection).AddRange(Add_CodeDom_Recursivity(aaa, False, False, nom_fichier, nom_fonction))
            End If
        Next

        Return result
    End Function

End Class
