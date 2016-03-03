''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class CorrectionErreurs

    Friend ErrorToResolve As New Generic.List(Of VelerSoftware.SZVB.Projet.Erreur)

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i_progress, i2_progress As Integer

        With Me
            .Label2.Text = String.Format(Me.Label2.Text, My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition))

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView1.Handle, 4096 + 54, 65536, 65536)

            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

            Me.DisableOKButton()
            Me.Button1.Enabled = False


            Dim ite As ListViewItem
            For Each Err As VelerSoftware.SZVB.Projet.Erreur In ErrorToResolve
                ite = New ListViewItem
                With ite
                    .Name = Err.ActionId
                    .Text = RM.GetString("ErrorCorrector_Waiting")
                    .ImageIndex = 0
                    With .SubItems
                        .Add(Err.ProjectName)
                        .Add(My.Computer.FileSystem.GetName(Err.FileName))
                        .Add(Err.FunctionName)
                        .Add(Err.ActionName)
                        .Add(Err.ErrorText)
                    End With
                    .Tag = Err
                End With
                .ListView1.Items.Add(ite)
            Next


            i_progress = ErrorToResolve.Count
            i2_progress = 0
            For Each Err As VelerSoftware.SZVB.Projet.Erreur In ErrorToResolve
                If My.Computer.FileSystem.FileExists(Err.FileName) Then
                    ' Ouverture du fichier
                    Dim files() As String = New String(-1) {}
                    Dim Safefiles() As String = New String(-1) {}
                    Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

                    If SOLUTION.GetProject(Err.ProjectName) IsNot Nothing Then
                        If Err.FileName = SOLUTION.GetProject(Err.ProjectName).Emplacement & "\ApplicationEvents.szc" Then
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = "APPLICATIONEVENTS"
                            Safefiles(Safefiles.Length - 1) = "APPLICATIONEVENTS"
                            projects(projects.Length - 1) = SOLUTION.GetProject(Err.ProjectName)
                        Else
                            ReDim Preserve files(files.Length)
                            ReDim Preserve Safefiles(Safefiles.Length)
                            ReDim Preserve projects(projects.Length)
                            files(files.Length - 1) = Err.FileName
                            Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(Err.FileName)
                            projects(projects.Length - 1) = SOLUTION.GetProject(Err.ProjectName)
                        End If
                    End If

                    ClassProjet.Ouvrir_Document(files, Safefiles, projects)
                End If

                i2_progress += 1
                Me.ProgressBar1.Value = (i2_progress / i_progress) * 100
            Next

        End With
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        For Each ite As ListViewItem In Me.ListView1.Items
            If ite.ImageIndex = 2 Then DirectCast(Form1.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ListView1.Items.RemoveByKey(ite.Name)
        Next

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Ordre_Generation_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub





    Private Sub CorrectionErreurs_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Status_SZ = statu.Correction_Erreurs_En_Cours

        Try
            With Me
                .ProgressBar1.Value = 0

                Dim i_progress, i2_progress As Integer
                i_progress = ErrorToResolve.Count
                i2_progress = 0

                With Me.ListView1
                    For Each Err As VelerSoftware.SZVB.Projet.Erreur In ErrorToResolve

                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_InProgress")
                        .Items(i2_progress).ImageIndex = 1
                        .Refresh()
                        Application.DoEvents()

                        Generation_En_Cours_Projet = SOLUTION.GetProject(Err.ProjectName)

                        If (Not Generation_En_Cours_Projet Is Nothing) AndAlso ClassApplication.Determiner_Si_Document_Deja_Ouvert(Err.FileName) Then

                            If TypeOf Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0) Is DocConcepteurFenetre Then
                                For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                                    If Tabs.Text = Err.FunctionName Then
                                        If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl Then
                                            If DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                                Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), Err.ActionId, False, False)
                                                If Act IsNot Nothing Then
                                                    If Act.ResolveError(Err, New System.EventArgs) Then
                                                        If Err.ErrorNumber = "BC30260" Then Tabs.Text = Act.DisplayName
                                                        DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocConcepteurFenetre).DocumentModifier()
                                                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Corriged")
                                                        .Items(i2_progress).ImageIndex = 2
                                                    ElseIf Me.Correct_General_Error(Act, Err) Then
                                                        If Err.ErrorNumber = "BC30260" Then Tabs.Text = Act.DisplayName
                                                        DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocConcepteurFenetre).DocumentModifier()
                                                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Corriged")
                                                        .Items(i2_progress).ImageIndex = 2
                                                    Else
                                                        If Err.ErrorSolutionExplain = "" OrElse Err.ErrorSolutionExplain = Nothing Then
                                                            .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Failed")
                                                            .Items(i2_progress).ImageIndex = 3
                                                        Else
                                                            .Items(i2_progress).Text = RM.GetString("ErrorCorrector_SemiFailed")
                                                            .Items(i2_progress).ImageIndex = 4
                                                        End If
                                                    End If
                                                    SOLUTION.GetProject(Err.ProjectName).ShouldCompileRelease = True
                                                End If
                                            End If
                                        End If
                                        Exit For
                                    End If
                                Next

                            ElseIf TypeOf Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0) Is DocEditeurFonctions Then
                                For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                                    If Tabs.Text = Err.FunctionName Then
                                        If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl Then
                                            If DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                                Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), Err.ActionId, False, False)
                                                If Act IsNot Nothing Then
                                                    If Act.ResolveError(Err, New System.EventArgs) Then
                                                        If Err.ErrorNumber = "BC30260" Then Tabs.Text = Act.DisplayName
                                                        DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocEditeurFonctions).DocumentModifier()
                                                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Corriged")
                                                        .Items(i2_progress).ImageIndex = 2
                                                    ElseIf Me.Correct_General_Error(Act, Err) Then
                                                        If Err.ErrorNumber = "BC30260" Then Tabs.Text = Act.DisplayName
                                                        DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(Err.FileName).Controls(0), DocEditeurFonctions).DocumentModifier()
                                                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Corriged")
                                                        .Items(i2_progress).ImageIndex = 2
                                                    Else
                                                        .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Failed")
                                                        .Items(i2_progress).ImageIndex = 3
                                                    End If
                                                    SOLUTION.GetProject(Err.ProjectName).ShouldCompileRelease = True
                                                End If
                                            End If
                                        End If
                                        Exit For
                                    End If
                                Next
                            End If

                        End If

                        If .Items(i2_progress).ImageIndex = 1 Then
                            .Items(i2_progress).Text = RM.GetString("ErrorCorrector_Failed")
                            .Items(i2_progress).ImageIndex = 3
                        End If

                        i2_progress += 1
                        Me.ProgressBar1.Value = (i2_progress / i_progress) * 100

                        Me.ProgressBar1.Refresh()
                        .Refresh()
                        Application.DoEvents()
                    Next
                End With

                .ProgressBar1.Value = 100

                .DisableCancelButton()
                .EnableOKButton()
                .Button1.Enabled = True
            End With
        Finally
            Generation_En_Cours_Projet = Nothing
            Status_SZ = statu.Normal
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim txt As New System.Text.StringBuilder

        Dim i As Integer = 0
        With txt
            For Each Err As VelerSoftware.SZVB.Projet.Erreur In ErrorToResolve
                i += 1
                .Append("{\b " & i & "} - {\b " & RM.GetString("ErrorCorrector_Project") & "}" & Err.ProjectName & " - {\b " & RM.GetString("ErrorCorrector_File") & "}" & My.Computer.FileSystem.GetName(Err.FileName) & " - {\b " & RM.GetString("ErrorCorrector_Function") & "}" & Err.FunctionName & " - {\b " & RM.GetString("ErrorCorrector_Action") & "}" & Err.ActionName & " \par ")
                .Append("{\b \t " & RM.GetString("ErrorCorrector_Statut") & "}" & Me.ListView1.Items(i - 1).Text & "\par ")
                .Append("{\b \t " & RM.GetString("ErrorCorrector_Explain") & "}" & Err.ErrorExplain & "\par ")
                .Append("{\b \t " & RM.GetString("ErrorCorrector_SolutionExplain") & "}" & Err.ErrorSolutionExplain & "\par \par \par")
            Next

            Me.RichTextBox1.Rtf = "{\rtf1 " & .ToString & "}"
        End With

        Me.Height = 700
        Me.RichTextBox1.Visible = True
        Me.ProgressBar1.Visible = False

        Me.Button1.Enabled = False
    End Sub

    Private Sub RichTextBox1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripMenuItem.Click
        Me.RichTextBox1.Copy()
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








    Private Function Correct_General_Error(ByVal Act As VelerSoftware.Plugins3.Action, ByVal Err As VelerSoftware.SZVB.Projet.Erreur) As Boolean
        Dim RESULTAT As Boolean = False

        Dim Proj As VelerSoftware.SZVB.Projet.Projet = Nothing
        Dim tmp_str As String = ""

        If Err.Type = VelerSoftware.SZVB.Projet.Erreur.ErrorType.Building Then

            If Err.ErrorNumber = "BC30009" Then ' Assembly manquante   
                Dim isproject As Boolean
                Dim proj2 As VelerSoftware.SZVB.Projet.Projet = Nothing
                Dim assemb As Reflection.Assembly
                Err.ErrorExplain = Err.ErrorText
                Proj = SOLUTION.GetProject(Err.ProjectName)
                If Err.ErrorText.Split("'").Count = 7 Then ' à cause des apostrophe en Français
                    tmp_str = Err.ErrorText.Split("'")(2)
                Else
                    tmp_str = Err.ErrorText.Split("'")(1)
                End If
                If Proj IsNot Nothing AndAlso tmp_str.Contains(",") Then
                    For Each proj3 As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                        If proj3.Nom = tmp_str.Split(",")(0) Then
                            isproject = True
                            proj2 = proj3
                            Exit For
                        End If
                    Next
                    If isproject AndAlso proj2 IsNot Nothing Then
                        If proj2.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                            Proj.References.Add(New VelerSoftware.SZVB.Projet.Reference(isproject, Nothing, True, proj2.Nom, proj2.Assembly_AssemblyVersion, ClassFichier.Ouvrir_Fichier(proj2.Emplacement, My.Computer.FileSystem.CombinePath(Proj.Emplacement, proj2.GenerateDirectory & "\" & proj2.Nom & ".dll"))))
                        Else
                            Proj.References.Add(New VelerSoftware.SZVB.Projet.Reference(isproject, Nothing, True, proj2.Nom, proj2.Assembly_AssemblyVersion, ClassFichier.Ouvrir_Fichier(proj2.Emplacement, My.Computer.FileSystem.CombinePath(Proj.Emplacement, proj2.GenerateDirectory & "\" & proj2.Nom & ".exe"))))
                        End If
                        Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_1_Solution"), tmp_str)
                        RESULTAT = True
                    Else
                        Try
                            assemb = Reflection.Assembly.Load(tmp_str)
                            If assemb IsNot Nothing Then
                                Proj.References.Add(New VelerSoftware.SZVB.Projet.Reference(isproject, assemb, False, assemb.GetName.Name, assemb.GetName.Version.ToString.Trim(" "), tmp_str))
                                Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_1_Solution"), tmp_str)
                                RESULTAT = True
                            Else
                                Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_1_Solution_Bad"), tmp_str)
                                RESULTAT = False
                            End If
                        Catch
                            Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_1_Solution_Bad"), tmp_str)
                            RESULTAT = False
                        End Try
                    End If
                Else
                    Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_1_Solution_Bad"), tmp_str)
                    RESULTAT = False
                End If









            ElseIf Err.ErrorNumber = "BC30456" Then ' 'YYYY' n'est pas un membre de 'XXXX'.
                If Err.ErrorText.Contains("'Computer'") AndAlso Err.ErrorText.Contains("'My'") Then ' 'Computer' n'est pas un membre de 'My'.
                    Err.ErrorExplain = Err.ErrorText
                    Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_2_Solution_Bad"), Err.ActionName, Err.FunctionName, Err.FileName)
                    RESULTAT = False
                End If









            ElseIf Err.ErrorNumber = "BC30455" Then ' Argument non spécifié pour le paramètre 'YYYY' de 'Public Sub XXXX(YYYY As Object)'.
                If Err.ErrorText.Contains("'Public Sub Main(") Then
                    Err.ErrorExplain = Err.ErrorText
                    Err.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Correct_Error_3_Solution_Bad"))
                    RESULTAT = False
                End If


            End If


        End If

        Return RESULTAT
    End Function

End Class
