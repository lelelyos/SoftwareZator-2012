''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class OrdreGeneration

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not SOLUTION Is Nothing Then
            Dim ite As ListViewItem
            For Each proj As String In SOLUTION.GenerationOrder
                If Not SOLUTION.GetProject(proj) Is Nothing Then
                    ite = New ListViewItem
                    ite.Text = proj
                    Me.ListView1.Items.Add(ite)
                End If
            Next
        End If

        ListView1_Click(Nothing, Nothing)

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If Not SOLUTION Is Nothing Then
            SOLUTION.GenerationOrder.Clear()
            For Each ite As ListViewItem In Me.ListView1.Items
                SOLUTION.GenerationOrder.Add(ite.Text)
            Next
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Ordre_Generation_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            MoveListViewItem(Me.ListView1, True)
        Else
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            MoveListViewItem(Me.ListView1, False)
        Else
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Move selected listview item up or down based on moveUp= True/false.
    ''' </summary>
    ''' <param name = "moveUp"></param>
    Private Sub MoveListViewItem(ByRef lv As ListView, ByVal moveUp As Boolean)
        Dim i As Integer
        Dim cache As String
        Dim selIdx As Integer

        With lv
            selIdx = .SelectedItems.Item(0).Index
            If moveUp Then
                ' ignore moveup of row(0)
                If selIdx = 0 Then
                    Exit Sub
                End If
                ' move the subitems for the previous row
                ' to cache so we can move the selected row up
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx - 1).SubItems(i).Text
                    .Items(selIdx - 1).SubItems(i).Text = _
                       .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx - 1).Selected = True
                .Refresh()
                .Focus()
            Else
                ' ignore move down of last row
                If selIdx = .Items.Count - 1 Then
                    Exit Sub
                End If
                ' move the subitems for the next row
                ' to cache so we can move the selected row down
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx + 1).SubItems(i).Text
                    .Items(selIdx + 1).SubItems(i).Text = _
                       .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx + 1).Selected = True
                .Refresh()
                .Focus()
            End If
        End With
    End Sub

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click, ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
            If Me.ListView1.SelectedItems(0).Index = 0 Then
                Me.Button1.Enabled = False
            End If
            If Me.ListView1.SelectedItems(0).Index = Me.ListView1.Items.Count - 1 Then
                Me.Button2.Enabled = False
            End If
        Else
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
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
End Class
