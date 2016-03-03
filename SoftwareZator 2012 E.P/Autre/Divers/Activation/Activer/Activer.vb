''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Activer

    Private Sub Activer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
        Me.DisableOKButton()
        Me.HideOKButton()
        Me.ComboBox1.SelectedIndex = My.Settings.Edition - 1
    End Sub

    Private Sub CommandLink1_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink1.Click

        With Me
            If ClassApplication.Verify_License(.TextBox_Nom.Text, .TextBox_Prenom.Text, .TextBox_Pays.Text, .TextBox_Postal.Text, .TextBox_Email.Text, .NumericUpDown_No_Facture.Value, .ComboBox1.SelectedIndex, .TextBox_Code.Text) Then
                Dim lic As New Class_Licence(.TextBox_Nom.Text, .TextBox_Prenom.Text, .TextBox_Pays.Text, .TextBox_Postal.Text, .TextBox_Email.Text, .NumericUpDown_No_Facture.Value, .ComboBox1.SelectedIndex, .TextBox_Code.Text)

                Dim myFileStream As IO.Stream = IO.File.Create(Application.StartupPath & "\license.lic")
                Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                serializer.Serialize(myFileStream, lic)
                myFileStream.Close()

                ClassFichier.EncryptOrDecryptFile(Application.StartupPath & "\license.lic", Application.StartupPath & "\Temp\license.lic", ClassFichier.CreateKey("RU45O8GYFZ4R9OC8YO54OA89TC9O1YC2NO4YC42NO572OI3YTOC4N5425OY8U5Y29C045NY2O4IYCIOUCYESINGUCN3ITUYCIO43ZI"), ClassFichier.CreateIV("RU45O8GYFZ4R9OC8YO54OA89TC9O1YC2NO4YC42NO572OI3YTOC4N5425OY8U5Y29C045NY2O4IYCIOUCYESINGUCN3ITUYCIO43ZI"), ClassFichier.CryptoAction.ActionEncrypt)

                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\license.lic") Then My.Computer.FileSystem.MoveFile(Application.StartupPath & "\Temp\license.lic", Application.StartupPath & "\license.lic", True)
                If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man") Then My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                    .Content = RM.GetString("Content54")
                    .MainInstruction = RM.GetString("MainInstruction15")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With

                My.Settings.Edition = .ComboBox1.SelectedIndex + 1
                ClassProjet.Fermer_Solution(True)
                My.Settings.Save()
                Application.Restart()
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = RM.GetString("Content55")
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If
        End With
    End Sub
End Class
