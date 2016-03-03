''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Ajouter_Reference

    Friend Ok As Boolean
    Friend Nom_Projet As String

    Friend listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter
    Friend listviewsorter_lv2 As New VelerSoftware.SZC.ListViewStored.ListViewSorter
    Friend listviewsorter_lv3 As New VelerSoftware.SZC.ListViewStored.ListViewSorter
    Friend listviewsorter_lv4 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Ajouter_Reference_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ite As ListViewItem

        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

        Me.Total_ListView.Items.Clear()
        Me.Projets_ListView.Items.Clear()

        If Not SOLUTION.GetProject(Nom_Projet) Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If (Not proj Is Nothing) AndAlso (proj.Loaded) Then
                    If Not proj.Nom = Nom_Projet Then
                        ite = New ListViewItem
                        ite.Text = proj.Nom
                        ite.SubItems.Add(proj.Assembly_AssemblyVersion)
                        If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                            ite.SubItems.Add(ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Nom_Projet).Emplacement, My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory & "\" & proj.Nom & ".dll")))
                        Else
                            ite.SubItems.Add(ClassFichier.Ouvrir_Fichier(SOLUTION.GetProject(Nom_Projet).Emplacement, My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory & "\" & proj.Nom & ".exe")))
                        End If
                        ite.SubItems.Add("PROJECT")
                        ite.Tag = True
                        Me.Projets_ListView.Items.Add(ite)
                    End If
                End If
            Next
        End If

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.Projets_ListView.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.Projets_ListView.Handle, 4096 + 54, 65536, 65536)

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.Net_ListView.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.Net_ListView.Handle, 4096 + 54, 65536, 65536)

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.Com_ListView.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.Com_ListView.Handle, 4096 + 54, 65536, 65536)

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.Total_ListView.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.Total_ListView.Handle, 4096 + 54, 65536, 65536)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedTab Is Me.TabPage3 Then
            Me.Button1.Enabled = False
        Else
            Me.Button1.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.Total_ListView.SelectedIndices.Count > 0 Then
            For Each a As ListViewItem In Me.Total_ListView.SelectedItems
                a.Remove()
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Net_ListView.BeginUpdate()
        Me.Com_ListView.BeginUpdate()
        Me.Projets_ListView.BeginUpdate()
        Me.Total_ListView.BeginUpdate()

        If Me.TabControl1.SelectedTab Is Me.TabPage1 Then
            If Me.Net_ListView.SelectedIndices.Count > 0 Then
                For i As Integer = 0 To Me.Net_ListView.SelectedItems.Count - 1
                    Dim add As Boolean = True
                    For Each ite As ListViewItem In Me.Total_ListView.Items
                        If ite.Text = Me.Net_ListView.SelectedItems(i).Text Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        Me.Total_ListView.Items.Add(Me.Net_ListView.SelectedItems(i).Clone)
                    End If
                Next
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage2 Then
            If Me.Com_ListView.SelectedIndices.Count > 0 Then
                For i As Integer = 0 To Me.Com_ListView.SelectedItems.Count - 1
                    Dim add As Boolean = True
                    For Each ite As ListViewItem In Me.Total_ListView.Items
                        If ite.Text = Me.Com_ListView.SelectedItems(i).Text Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        Me.Total_ListView.Items.Add(Me.Com_ListView.SelectedItems(i).Clone)
                    End If
                Next
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage4 Then
            If Me.Projets_ListView.SelectedIndices.Count > 0 Then
                For i As Integer = 0 To Me.Projets_ListView.SelectedItems.Count - 1
                    Dim add As Boolean = True
                    For Each ite As ListViewItem In Me.Total_ListView.Items
                        If ite.Text = Me.Projets_ListView.SelectedItems(i).Text Then
                            add = False
                            Exit For
                        End If
                    Next
                    If add Then
                        Me.Total_ListView.Items.Add(Me.Projets_ListView.SelectedItems(i).Clone)
                    End If
                Next
            End If
        End If

        Me.Net_ListView.EndUpdate()
        Me.Com_ListView.EndUpdate()
        Me.Projets_ListView.EndUpdate()
        Me.Total_ListView.EndUpdate()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim asms() As Reflection.Assembly = Nothing
        If Not SOLUTION.GetProject(Nom_Projet) Is Nothing Then
            Me.OpenFileDialog1.InitialDirectory = SOLUTION.GetProject(Nom_Projet).Emplacement
        End If
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim ite As ListViewItem
            Dim ass As Reflection.Assembly
            For Each a As String In Me.OpenFileDialog1.FileNames
                If My.Computer.FileSystem.FileExists(a) Then
                    Try
                        ass = Reflection.Assembly.LoadFile(a)
                        Dim add As Boolean = True
                        For Each ite2 As ListViewItem In Me.Total_ListView.Items
                            If ite2.Text = ass.GetName.Name Then
                                add = False
                                Exit For
                            End If
                        Next
                        If add Then
                            ite = New ListViewItem
                            ite.Text = ass.GetName.Name
                            ite.SubItems.Add(ass.GetName.Version.ToString.Trim(" "))
                            ite.SubItems.Add(ass.Location.Trim(" "))
                            ite.SubItems.Add("")
                            ite.Tag = True
                            Me.Total_ListView.Items.Add(ite)
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
            Next
        End If
    End Sub

    Private Sub Total_ListView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Total_ListView.DragEnter
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

    Private Sub Total_ListView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Total_ListView.DragDrop
        Dim ite As ListViewItem
        Dim ass As Reflection.Assembly
        Dim asms() As Reflection.Assembly = Nothing
        For Each a As String In e.Data.GetData(DataFormats.FileDrop)
            If My.Computer.FileSystem.FileExists(a) Then
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".ocx" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".exe" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".dll" OrElse My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".tlb" Then
                    Try
                        asms = AppDomain.CurrentDomain.GetAssemblies
                        ass = Reflection.Assembly.LoadFile(a)
                        Dim add As Boolean = True
                        For Each ite2 As ListViewItem In Me.Total_ListView.Items
                            If ite2.Text = ass.GetName.Name Then
                                add = False
                                Exit For
                            End If
                        Next
                        If add Then
                            ite = New ListViewItem
                            ite.Text = ass.GetName.Name
                            ite.SubItems.Add(ass.GetName.Version.ToString.Trim(" "))
                            ite.SubItems.Add(ass.Location.Trim(" "))
                            ite.SubItems.Add("")
                            ite.Tag = True
                            Me.Total_ListView.Items.Add(ite)
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
            End If
        Next
    End Sub

    Private Sub Net_ListView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Net_ListView.MouseDoubleClick, Com_ListView.MouseDoubleClick, Projets_ListView.MouseDoubleClick
        Button1_Click(Nothing, Nothing)
    End Sub




    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Me.TabControl1.SelectedTab Is Me.TabPage1 Then
            If Me.Net_ListView.SelectedIndices.Count > 0 Then
                Me.CopierLerreurToolStripMenuItem.Enabled = True
            Else
                Me.CopierLerreurToolStripMenuItem.Enabled = False
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage2 Then
            If Me.Com_ListView.SelectedIndices.Count > 0 Then
                Me.CopierLerreurToolStripMenuItem.Enabled = True
            Else
                Me.CopierLerreurToolStripMenuItem.Enabled = False
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage4 Then
            If Me.Projets_ListView.SelectedIndices.Count > 0 Then
                Me.CopierLerreurToolStripMenuItem.Enabled = True
            Else
                Me.CopierLerreurToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub

    Private Sub CopierLerreurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierLerreurToolStripMenuItem.Click
        If Me.TabControl1.SelectedTab Is Me.TabPage1 Then
            If Me.Net_ListView.SelectedIndices.Count > 0 Then
                Clipboard.SetText(Me.Net_ListView.SelectedItems(0).SubItems(2).Text, TextDataFormat.Text)
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage2 Then
            If Me.Com_ListView.SelectedIndices.Count > 0 Then
                Clipboard.SetText(Me.Com_ListView.SelectedItems(0).SubItems(2).Text, TextDataFormat.Text)
            End If
        ElseIf Me.TabControl1.SelectedTab Is Me.TabPage4 Then
            If Me.Projets_ListView.SelectedIndices.Count > 0 Then
                Clipboard.SetText(Me.Projets_ListView.SelectedItems(0).SubItems(2).Text, TextDataFormat.Text)
            End If
        End If
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

    Private Sub Ajouter_Reference_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Ajouter_Reference_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
