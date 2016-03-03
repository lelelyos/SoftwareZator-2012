''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class AdvancedInstaller

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("https://secure.avangate.com/affiliate.php?ACCOUNT=CAPHYO1&AFFILIATE=32358&PATH=http%3A%2F%2Fwww.advancedinstaller.com")
        Me.Close()
    End Sub

    Private Sub AdvancedInstaller_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
        If System.Threading.Thread.CurrentThread.CurrentUICulture Is FrenchCulture Then
            Me.PictureBox1.Image = My.Resources.AdvancedInstaller_fr
        Else
            Me.PictureBox1.Image = My.Resources.AdvancedInstaller_en
        End If
    End Sub
End Class
