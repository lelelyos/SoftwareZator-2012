''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Windows.Forms

Public Class Form_UIImageEditor

    Friend IMG As System.Drawing.Image

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Form_UIImageEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IMG Is Nothing Then
            Me.PictureBox1.Image = IMG
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.PictureBox1.Image = Nothing
        IMG = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(Me.OpenFileDialog1.FileName) Then
                IMG = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName, True)
                Me.PictureBox1.Image = IMG
            End If
        End If
    End Sub
End Class
