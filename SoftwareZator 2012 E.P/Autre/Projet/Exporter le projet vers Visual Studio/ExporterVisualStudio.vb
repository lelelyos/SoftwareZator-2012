''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ExporterVisualStudio

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter


    Private Sub CreerEvenement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj.Loaded Then Me.ListView2.Items.Add(proj.Nom)
            Next

            If My.Computer.FileSystem.DirectoryExists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Visual Studio 2010\Projects") Then
                Me.TextBox1.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Visual Studio 2010\Projects"
            ElseIf My.Computer.FileSystem.DirectoryExists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Visual Studio 2012\Projects") Then
                Me.TextBox1.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Visual Studio 2012\Projects"
            ElseIf My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
                Me.TextBox1.Text = My.Settings.Emplacement_Project_Par_Defaut
            Else
                Me.TextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            Me.TextBox1.Text = Me.TextBox1.Text & "\" & ClassFichier.Determine_Dossier_Existe(Me.TextBox1.Text, SOLUTION.Nom & "_Exported")
        End If

        For i As Integer = 0 To Me.ListView2.Items.Count - 1
            Me.ListView2.Items(i).Checked = True
        Next








        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView2.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView2.Handle, 4096 + 54, 65536, 65536)

        'LV 1
        listviewsorter_lv1.ListView = Me.ListView2
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView2.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.Sort(0)

        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("ExporterVisualStudio_Caption")
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

    Private Sub OnFinishButton_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If Me.CheckBox1.Checked AndAlso My.Computer.FileSystem.FileExists(Me.TextBox1.Text & "\" & SOLUTION.Nom & ".sln") Then
                System.Diagnostics.Process.Start(Me.TextBox1.Text & "\" & SOLUTION.Nom & ".sln")
            End If
        Else
            If Me.ExporterVisualStudioComposant1.BackgroundWorker1.IsBusy Then
                Me.EnableBackButton()
                Me.ExporterVisualStudioComposant1.Stops()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Process.Start("http://www.microsoft.com/visualstudio/en-us")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ExporterVisualStudio_OnNextButtonClicked(sender As System.Object, e As System.EventArgs) Handles MyBase.OnNextButtonClicked
        If Me.WizardTabControl1.SelectedTab Is Me.TabPage3 Then
            Me.DisableBackButton()
            Me.DisableNextButton()

            Dim li As New Generic.List(Of ListViewItem)
            For Each it As ListViewItem In Me.ListView2.Items
                If it.Checked Then
                    If SOLUTION.ProjetDemarrage = it.Text Then
                        li.Insert(0, it)
                    Else
                        li.Add(it)
                    End If
                End If
            Next
            Me.ExporterVisualStudioComposant1.Start(Me, Me.TextBox1.Text, li)
        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage4 Then
            Me.DisableBackButton()
            Me.DisableCancelButton()
        End If
    End Sub

    Private Sub ExporterVisualStudio_OnBackButtonClicked(sender As System.Object, e As System.EventArgs) Handles MyBase.OnBackButtonClicked
        If Me.WizardTabControl1.SelectedTab Is Me.TabPage2 Then
            Me.EnableCancelButton()
        End If
    End Sub













    Private Sub ExporterVisualStudioComposant1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExporterVisualStudioComposant1.DoWork

    End Sub

    Private Sub ExporterVisualStudioComposant1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles ExporterVisualStudioComposant1.ProgressChanged
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

            If Not .Label6.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet Then .Label6.Text = DirectCast(e.UserState, GenerationProgress).Nom_projet
            If Not .Label7.Text = DirectCast(e.UserState, GenerationProgress).Texte Then .Label7.Text = DirectCast(e.UserState, GenerationProgress).Texte

            If DirectCast(e.UserState, GenerationProgress).BoutonAnnuler Then
                .EnableCancelButton()
            Else
                .DisableCancelButton()
            End If
        End With
    End Sub

    Private Sub ExporterVisualStudioComposant1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExporterVisualStudioComposant1.RunWorkerCompleted
        Me.EnableBackButton()
        Me.EnableNextButton()
        Me.DisableCancelButton()
    End Sub

End Class
