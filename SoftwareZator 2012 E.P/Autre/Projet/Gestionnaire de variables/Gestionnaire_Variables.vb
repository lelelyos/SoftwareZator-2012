''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Gestionnaire_Variables

    Friend Nom_Projet As String

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Gestionnaire_Variables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not SOLUTION Is Nothing Then
            Dim ite As ListViewItem
            For Each var As VelerSoftware.SZVB.Projet.Variable In SOLUTION.GetProject(Nom_Projet).Variables
                ite = New ListViewItem
                With ite
                    .Name = var.Name
                    .Text = var.Name
                    .SubItems.Add(var.Array.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                    .SubItems.Add(var.Description)
                    .SubItems.Add(var.NullAtStart.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                    If var.Group = Nothing Then
                        .Group = Me.ListView1.Groups(0)
                    Else
                        If Me.ListView1.Groups(var.Group) Is Nothing Then
                            Me.ListView1.Groups.Add(var.Group, var.Group)
                        End If
                        .Group = Me.ListView1.Groups(var.Group)
                    End If
                    Me.ListView1.Items.Add(ite)
                End With
            Next
        End If

        ListView1_SelectedIndexChanged(Nothing, Nothing)


        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        'LV 1
        listviewsorter_lv1.ListView = Me.ListView1
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.Sort(0)

        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
    End Sub


    Private Sub Ajouter_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ajouter_Button.Click
        Using frm As New Ajouter_Variables
            frm.Nom_Projet = Me.Nom_Projet
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If Me.ListView1.Items.IndexOfKey(frm.Nom_KryptonTextBox1.Text) = -1 Then
                    Dim ite As New ListViewItem
                    With ite
                        .Name = frm.Nom_KryptonTextBox1.Text
                        .Text = frm.Nom_KryptonTextBox1.Text
                        .SubItems.Add(frm.CheckBox1.Checked.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                        .SubItems.Add(frm.Description_KryptonTextBox2.Text)
                        .SubItems.Add(frm.CheckBox2.Checked.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                        If frm.ComboBox1.Text = Nothing Then
                            .Group = Me.ListView1.Groups(0)
                        Else
                            If Me.ListView1.Groups(frm.ComboBox1.Text) Is Nothing Then
                                Me.ListView1.Groups.Add(frm.ComboBox1.Text, frm.ComboBox1.Text)
                            End If
                            .Group = Me.ListView1.Groups(frm.ComboBox1.Text)
                        End If
                        Me.ListView1.Items.Add(ite)
                    End With
                End If
            End If
            frm.Dispose()
        End Using
    End Sub

    Private Sub Modifier_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modifier_Button.Click
        Using frm As New Modifier_Variables
            With frm
                .Nom_Projet = Me.Nom_Projet
                .Nom_KryptonTextBox1.Text = Me.ListView1.SelectedItems(0).Text
                .CheckBox1.Checked = CBool(Me.ListView1.SelectedItems(0).SubItems(1).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False"))
                .Description_KryptonTextBox2.Text = Me.ListView1.SelectedItems(0).SubItems(2).Text
                .CheckBox2.Checked = CBool(Me.ListView1.SelectedItems(0).SubItems(3).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False"))
                If Me.ListView1.SelectedItems(0).Group.Name = "Default" Then
                    .ComboBox1.Text = Nothing
                Else
                    .ComboBox1.Text = Me.ListView1.SelectedItems(0).Group.Header
                End If

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.ListView1.SelectedItems(0).Text = .Nom_KryptonTextBox1.Text
                    Me.ListView1.SelectedItems(0).SubItems(1).Text = .CheckBox1.Checked.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                    Me.ListView1.SelectedItems(0).SubItems(2).Text = .Description_KryptonTextBox2.Text
                    Me.ListView1.SelectedItems(0).SubItems(3).Text = .CheckBox2.Checked.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                    If .ComboBox1.Text = Nothing Then
                        Me.ListView1.SelectedItems(0).Group = Me.ListView1.Groups(0)
                    Else
                        If Me.ListView1.Groups(.ComboBox1.Text) Is Nothing Then
                            Me.ListView1.Groups.Add(.ComboBox1.Text, .ComboBox1.Text)
                        End If
                        Me.ListView1.SelectedItems(0).Group = Me.ListView1.Groups(.ComboBox1.Text)
                    End If
                End If
            End With
            frm.Dispose()
        End Using
    End Sub

    Private Sub Supprimer_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Supprimer_Button.Click
        For Each ite As ListViewItem In Me.ListView1.SelectedItems
            Me.ListView1.Items.RemoveByKey(ite.Name)
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedIndices.Count > 1 OrElse Me.ListView1.SelectedIndices.Count <= 0 Then
            Me.Modifier_Button.Enabled = False
        Else
            Me.Modifier_Button.Enabled = True
        End If
        If Me.ListView1.SelectedIndices.Count > 0 Then
            Me.Supprimer_Button.Enabled = True
        Else
            Me.Supprimer_Button.Enabled = False
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.Modifier_Button.Enabled Then
            Modifier_Button_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Gestionnaire_Variables_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If Not SOLUTION Is Nothing Then
            Dim var As VelerSoftware.SZVB.Projet.Variable
            SOLUTION.GetProject(Nom_Projet).Variables.Clear()
            For Each ite As ListViewItem In Me.ListView1.Items
                var = New VelerSoftware.SZVB.Projet.Variable
                var.Name = ite.Text
                var.Description = ite.SubItems(2).Text
                If var.Group = "Default" Then
                    var.Group = Nothing
                Else
                    var.Group = ite.Group.Header
                End If
                var.Array = ite.SubItems(1).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False")
                var.NullAtStart = ite.SubItems(3).Text.Replace(RM.GetString("Yes_Text"), "True").Replace(RM.GetString("No_Text"), "False")
                SOLUTION.GetProject(Nom_Projet).Variables.Add(var)
            Next

            ' Recharger les statistiques
            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = Nom_Projet Then
                    DirectCast(page.Controls(0), DocStatistiques).Charger(False)
                End If
            Next

            If Not SOLUTION.GetProject(Nom_Projet) Is Nothing Then
                SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
            End If
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Gestionnaire_Variables_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
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
