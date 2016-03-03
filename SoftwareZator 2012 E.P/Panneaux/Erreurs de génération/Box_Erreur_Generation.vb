''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxErreurGeneration

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        'VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        'VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        'LV 1
        listviewsorter_lv1.ListView = Me.ListView1
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(3).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(4).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.Sort(0)

        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.ToolStripButton2.Enabled = True
        Else
            Me.ToolStripButton2.Enabled = False
        End If

        Me.ToolStripButton1.Enabled = True = False
        If Me.ListView1.Items.Count > 0 Then Me.ToolStripButton1.Enabled = True
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.ToolStrip1.Font = font

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.ListView1.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.ListView1.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.ListView1.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.Items.Count > 0 Then Me.ToolStripButton1.Enabled = True
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.ToolStripButton2.Enabled = True
        Else
            Me.ToolStripButton2.Enabled = False
        End If
    End Sub


    Private Sub ToolStripButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.ButtonClick
        If Me.ListView1.SelectedItems.Count > 0 Then

            If My.Settings.Edition = ClassApplication.Edition.Free Then
                ClassApplication.Should_Standard_Edition()
                Exit Sub
            End If

            Dim ErrorToResolve As New Generic.List(Of VelerSoftware.SZVB.Projet.Erreur)
            For Each ite As ListViewItem In Me.ListView1.SelectedItems
                ErrorToResolve.Add(DirectCast(ite.Tag, VelerSoftware.SZVB.Projet.Erreur))
            Next
            Using frm As New CorrectionErreurs
                frm.ErrorToResolve = ErrorToResolve
                frm.ShowDialog()
                frm.Dispose()
            End Using
        End If
    End Sub

    Friend Sub CorrigerTouteLesErreursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CorrigerTouteLesErreursToolStripMenuItem.Click
        If Me.ListView1.Items.Count > 0 Then

            If My.Settings.Edition = ClassApplication.Edition.Free Then
                ClassApplication.Should_Standard_Edition()
                Exit Sub
            End If

            Dim ErrorToResolve As New Generic.List(Of VelerSoftware.SZVB.Projet.Erreur)
            For Each ite As ListViewItem In Me.ListView1.Items
                ErrorToResolve.Add(DirectCast(ite.Tag, VelerSoftware.SZVB.Projet.Erreur))
            Next
            Using frm As New CorrectionErreurs
                frm.ErrorToResolve = ErrorToResolve
                frm.ShowDialog()
                frm.Dispose()
            End Using
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click, AtteindreLerreurToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 1 Then
            Dim erro As VelerSoftware.SZVB.Projet.Erreur = DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur)

            If My.Computer.FileSystem.FileExists(erro.FileName) Then
                ' Ouverture du fichier
                Dim files() As String = New String(-1) {}
                Dim Safefiles() As String = New String(-1) {}
                Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

                If SOLUTION.GetProject(erro.ProjectName) IsNot Nothing Then
                    If erro.FileName = SOLUTION.GetProject(erro.ProjectName).Emplacement & "\ApplicationEvents.szc" Then
                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = "APPLICATIONEVENTS"
                        Safefiles(Safefiles.Length - 1) = "APPLICATIONEVENTS"
                        projects(projects.Length - 1) = SOLUTION.GetProject(erro.ProjectName)
                    Else
                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = erro.FileName
                        Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(erro.FileName)
                        projects(projects.Length - 1) = SOLUTION.GetProject(erro.ProjectName)
                    End If
                End If

                ClassProjet.Ouvrir_Document(files, Safefiles, projects)

            ElseIf erro.ActionId = "{Unknow}" Then
                Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(erro.ProjectName)
                If proj IsNot Nothing Then
                    erro.FileName = Application.StartupPath & "\Temp\Building\" & proj.Nom & ".vb"
                    My.Computer.FileSystem.WriteAllText(erro.FileName, proj.VBGénéréParGénération, False)
                    If My.Computer.FileSystem.FileExists(erro.FileName) Then
                        ' Ouverture du fichier
                        Dim files() As String = New String(-1) {}
                        Dim Safefiles() As String = New String(-1) {}
                        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

                        ReDim Preserve files(files.Length)
                        ReDim Preserve Safefiles(Safefiles.Length)
                        ReDim Preserve projects(projects.Length)
                        files(files.Length - 1) = erro.FileName
                        Safefiles(Safefiles.Length - 1) = proj.Nom & ".vb"
                        projects(projects.Length - 1) = proj

                        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
                    End If
                End If

            End If

            If ClassApplication.Determiner_Si_Document_Deja_Ouvert(erro.FileName) Then

                If TypeOf Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0) Is DocConcepteurFenetre Then
                    DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedPage = DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocConcepteurFenetre).Editeur_Fonction_KryptonPage
                    For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                        If Tabs.Text = erro.FunctionName Then
                            DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage = Tabs
                            Application.DoEvents()  ' on laisse se charger le Workflow
                            If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl AndAlso DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), erro.ActionId, False, False)
                                If Act IsNot Nothing Then
                                    For Each mode As System.Activities.Presentation.Model.ModelItem In DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Find(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root, Act.GetType)
                                        If DirectCast(mode.GetCurrentValue, VelerSoftware.Plugins3.Action).id = Act.id Then
                                            System.Activities.Presentation.View.Selection.Select(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context, mode)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                            Exit For
                        End If
                    Next

                ElseIf TypeOf Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0) Is DocEditeurFonctions Then
                    For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                        If Tabs.Text = erro.FunctionName Then
                            DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage = Tabs
                            Application.DoEvents()  ' on laisse se charger le Workflow
                            If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl AndAlso DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), erro.ActionId, False, False)
                                If Act IsNot Nothing Then
                                    For Each mode As System.Activities.Presentation.Model.ModelItem In DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Find(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root, Act.GetType)
                                        If DirectCast(mode.GetCurrentValue, VelerSoftware.Plugins3.Action).id = Act.id Then
                                            System.Activities.Presentation.View.Selection.Select(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context, mode)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                            Exit For
                        End If
                    Next

                ElseIf TypeOf Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0) Is DocEditeurVisualBasic Then
                    DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocEditeurVisualBasic).CodeEditor.ScrollTo(erro.ErrorLine, erro.ErrorColumn)
                    DirectCast(Form1.KryptonDockableWorkspace1.PageForUniqueName(erro.FileName).Controls(0), DocEditeurVisualBasic).CodeEditor.Focus()

                End If

            End If

        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Me.ListView1.SelectedItems.Count = 1 Then
            ToolStripButton2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub IgnorerLerreurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IgnorerLerreurToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            For Each ite As ListViewItem In Me.ListView1.SelectedItems
                Me.ListView1.Items.Remove(ite)
            Next
        End If
    End Sub

    Private Sub CopierLerreurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierLerreurToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 1 Then
            Clipboard.SetText("Project : " & Me.ListView1.SelectedItems(0).Text & Environment.NewLine & "File : " & Me.ListView1.SelectedItems(0).SubItems(1).Text & Environment.NewLine & "Function : " & Me.ListView1.SelectedItems(0).SubItems(2).Text & Environment.NewLine & "Action : " & Me.ListView1.SelectedItems(0).SubItems(3).Text & Environment.NewLine & "Error number : " & DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ErrorNumber & Environment.NewLine & "Description : " & Me.ListView1.SelectedItems(0).SubItems(4).Text)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Me.ListView1.SelectedItems.Count = 1 Then
            Me.CopierLerreurToolStripMenuItem.Enabled = True
            Me.AtteindreLerreurToolStripMenuItem.Enabled = True
            Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = True
        Else
            Me.CopierLerreurToolStripMenuItem.Enabled = False
            Me.AtteindreLerreurToolStripMenuItem.Enabled = False
            Me.OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Enabled = False
        End If
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.IgnorerLerreurToolStripMenuItem.Enabled = True
        Else
            Me.IgnorerLerreurToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeDernierRapportDeGénérationDuProjetToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 1 AndAlso SOLUTION.GetProject(DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ProjectName) IsNot Nothing Then
            My.Computer.FileSystem.WriteAllText(SOLUTION.GetProject(DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ProjectName).Emplacement & "\Report.txt", SOLUTION.GetProject(DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ProjectName).RapportGeneration.ToString, False)
            If My.Computer.FileSystem.FileExists(SOLUTION.GetProject(DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ProjectName).Emplacement & "\Report.txt") Then
                System.Diagnostics.Process.Start(SOLUTION.GetProject(DirectCast(Me.ListView1.SelectedItems(0).Tag, VelerSoftware.SZVB.Projet.Erreur).ProjectName).Emplacement & "\Report.txt")
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If My.Settings.Langue = "fr" Then
            System.Diagnostics.Process.Start("http://forumvelersoftware.bbactif.com/")
        Else
            System.Diagnostics.Process.Start("http://velersoftware.forum-phpbb.ca/")
        End If
    End Sub
End Class
