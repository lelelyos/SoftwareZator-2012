''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Activation_Evaluation

    Private Sub CommandLink3_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink3.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Activation_Evaluation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
        ProgressBar1.Value = 120 - Nombre_Utilisation_Restante
        Label3.Text = String.Format(Label3.Text, Nombre_Utilisation_Restante)
        Me.DialogResult = Windows.Forms.DialogResult.None
    End Sub

    Private Sub Activation_Evaluation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        '  Code to Override the Alt-F4 keys combination
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CommandLink1_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink1.Click
        System.Diagnostics.Process.Start("http://softwarezator.velersoftware.com/#editions")
    End Sub

    Private Sub CommandLink4_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink4.Click
        Using frm As New Changer_Edition
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
            frm.Dispose()
        End Using
    End Sub

    Private Sub CommandLink2_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink2.Click
        Using frm As New Activer
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
            frm.Dispose()
        End Using
    End Sub
End Class
