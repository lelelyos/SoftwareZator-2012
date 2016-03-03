''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class InfoBarBibliothèqueFonctionsRéutilisablesDansProjetPasPuEtreChargées

    Friend listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ite As ListViewItem

        With Me
            .ListView1.Items.Clear()

            For Each a As VelerSoftware.SZVB.Projet.Reference In DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).References
                If Not a Is Nothing Then
                    If a.Assembly Is Nothing Then
                        If Not a.IsProject Then
                            ite = New ListViewItem
                            ite.Text = a.Name
                            ite.Name = ite.Text
                            ite.SubItems.Add(a.Version)
                            ite.SubItems.Add(a.FullName)
                            Me.ListView1.Items.Add(ite)
                        End If
                    End If
                End If
            Next

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView1.Handle, 4096 + 54, 65536, 65536)

            'LV 1
            .listviewsorter_lv1.ListView = .ListView1
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.Sort(0)

            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

        End With
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Ordre_Generation_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
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
