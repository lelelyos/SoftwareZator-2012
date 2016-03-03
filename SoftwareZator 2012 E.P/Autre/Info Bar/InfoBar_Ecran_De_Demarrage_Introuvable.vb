''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class InfoBarEcranDeDemarrageIntrouvable

    Friend listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ite As ListViewItem

        With Me
            .ListView1.Items.Clear()
            .ListView1.Items.Add("")

            For Each a As String In My.Computer.FileSystem.GetFiles(DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                    If Not ClassFichier.Ouvrir_Fichier(DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Emplacement, a) = DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).FormStart Then
                        ite = New ListViewItem
                        ite.Text = ClassFichier.Ouvrir_Fichier(DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Emplacement, a)
                        ite.Name = ite.Text
                        .ListView1.Items.Add(ite)
                    End If
                End If
            Next

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView1.Handle, 4096 + 54, 65536, 65536)

            'LV 1
            .listviewsorter_lv1.ListView = .ListView1
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.Sort(0)

            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

            .DisableOKButton()
        End With
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If Me.ListView1.SelectedItems.Count > 0 Then
            DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).SplashScreen = Me.ListView1.SelectedItems(0).Text
            SOLUTION.GetProject(DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Nom).ShouldCompileRelease = True

            For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                If page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Nom Then
                    DirectCast(page.Controls(0), DocParametresDuProjet).Ecran_Demarrage_KryptonComboBox.Text = Me.ListView1.SelectedItems(0).Text
                    DirectCast(page.Controls(0), DocParametresDuProjet).DocumentModifier()
                ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Nom Then
                    DirectCast(page.Controls(0), DocStatistiques).Ecran_Demarrage_KryptonLabel9.Text = Me.ListView1.SelectedItems(0).Text
                End If
            Next

            Form1.Info_Bar1.Hide()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Ordre_Generation_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.EnableOKButton()
        Else
            Me.DisableOKButton()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Me.OK_Button.Enabled Then
            Ordre_Generation_OnOKButtonClicked(Nothing, Nothing)
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
