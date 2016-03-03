''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Changer_Edition

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CommandLink12_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink12.Click
        System.Diagnostics.Process.Start("http://softwarezator.velersoftware.com/#editions")
    End Sub

    Private Sub CommandLink8_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink8.Click
        Change(0)
    End Sub

    Private Sub CommandLink9_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink9.Click
        Change(1)
    End Sub

    Private Sub CommandLink10_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink10.Click
        Change(2)
    End Sub

    Private Sub CommandLink11_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink11.Click
        Change(3)
    End Sub

    Private Sub Change(ByVal edition As Integer)
        Dim resultat As VelerSoftware.SZVB.VistaDialog.VDialogResult = VelerSoftware.SZVB.VistaDialog.VDialogResult.Continue

        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Nothing
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Cancel)}
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
            .Content = RM.GetString("Content50")
            .MainInstruction = RM.GetString("MainInstruction14")
            .WindowTitle = My.Application.Info.Title
            resultat = .Show()
        End With

        If resultat = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK Then
            My.Settings.Edition = edition
            ClassProjet.Fermer_Solution(True)
            Application.Restart()
        End If
    End Sub
End Class
