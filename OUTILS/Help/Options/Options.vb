''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Options

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

            .ComboBox1.SelectedIndex = My.Settings.WindowTheme
            If My.Settings.Langue = "fr" Then
                .Langue_ComboBox.SelectedIndex = 1
            Else
                .Langue_ComboBox.SelectedIndex = 0
            End If

        End With
    End Sub

    Private Sub Options_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            My.Settings.WindowTheme = .ComboBox1.SelectedIndex

            If .Langue_ComboBox.SelectedIndex = 1 Then
                My.Settings.Langue = "fr"
            Else
                My.Settings.Langue = "en"
            End If

            My.Settings.Save()

            Select Case My.Settings.WindowTheme
                Case 0
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Case 1
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Case 2
                    Form1.KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
            End Select

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub Options_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
