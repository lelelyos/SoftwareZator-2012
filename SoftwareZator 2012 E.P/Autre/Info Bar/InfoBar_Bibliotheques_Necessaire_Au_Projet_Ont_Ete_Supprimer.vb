''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class InfoBarBibliothequesNecessaireAuProjetOntEteSupprimer

    Friend listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pres_system, pres_system_core, pres_system_windows, pres_system_drawing, pres_system_xml As Boolean
        Dim ite As ListViewItem

        With Me
            .ListView1.Items.Clear()

            For Each a As VelerSoftware.SZVB.Projet.Reference In DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).References
                If Not a Is Nothing Then
                    If a.Name = "System" Then pres_system = True
                    If a.Name = "System.Core" Then pres_system_core = True
                    If a.Name = "System.Drawing" Then pres_system_drawing = True
                    If a.Name = "System.Windows.Forms" Then pres_system_windows = True
                    If a.Name = "System.Xml" Then pres_system_xml = True
                End If
            Next

            If Not pres_system Then
                ite = New ListViewItem
                ite.Text = "System"
                ite.SubItems.Add("4.0.0.0")
                ite.Tag = "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                .ListView1.Items.Add(ite)
            End If
            If Not pres_system_core Then
                ite = New ListViewItem
                ite.Text = "System.Core"
                ite.SubItems.Add("4.0.0.0")
                ite.Tag = "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                .ListView1.Items.Add(ite)
            End If
            If Not pres_system_drawing Then
                ite = New ListViewItem
                ite.Text = "System.Drawing"
                ite.SubItems.Add("4.0.0.0")
                ite.Tag = "System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
                .ListView1.Items.Add(ite)
            End If
            If Not pres_system_windows Then
                ite = New ListViewItem
                ite.Text = "System.Windows.Forms"
                ite.SubItems.Add("4.0.0.0")
                ite.Tag = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                .ListView1.Items.Add(ite)
            End If
            If Not pres_system_xml Then
                ite = New ListViewItem
                ite.Text = "System.XML"
                ite.SubItems.Add("4.0.0.0")
                ite.Tag = "System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
                .ListView1.Items.Add(ite)
            End If

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.ListView1.Handle, 4096 + 54, 65536, 65536)

            'LV 1
            .listviewsorter_lv1.ListView = .ListView1
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.ColumnComparerCollection(.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            .listviewsorter_lv1.Sort(0)

            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

        End With
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        For Each ite As ListViewItem In Me.ListView1.Items
            ClassProjet.Ajouter_Reference_Projet(ite.Tag, DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet))
            SOLUTION.GetProject(DirectCast(Form1.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet).Nom).ShouldCompileRelease = True
        Next

        Form1.Info_Bar1.Hide()

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
