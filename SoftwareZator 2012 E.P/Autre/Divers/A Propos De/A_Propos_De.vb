''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class A_Propos_De

    Private Sub WizardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim beta_txt As String = ""
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\isbeta") AndAlso CBool(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\isbeta")) AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\betaversion") Then
            beta_txt = " Beta " & CInt(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\betaversion"))
        End If
        Me.Label2.Text = RM.GetString("Edition_" & My.Settings.Edition)
        Me.Label4.Text = String.Format("2012 ({0})", My.Application.Info.Version.ToString & beta_txt)
        Me.Label5.Text = My.Application.Info.Copyright
        Me.Label7.Text = My.Application.Info.CompanyName
        If My.Settings.Société = Nothing Then
            Me.Label12.Text = My.Settings.Nom_Utilisateur
        Else
            Me.Label12.Text = My.Settings.Nom_Utilisateur & " (" & My.Settings.Société & ")"
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:support@velersoftware.com")
    End Sub

    Private Sub A_Propos_De_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, Cancel_Button.KeyPress, Button1.KeyPress
        If e.KeyChar.ToString.ToUpper = "H" Then
            Using frm As New Historique_SZ
                frm.ShowDialog()
                frm.Dispose()
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Using frm As New Licence
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub
End Class