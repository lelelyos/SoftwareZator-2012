''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class NouvelleBaseAccess

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Nom_KryptonTextBox1))
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(KryptonTextBox1))

        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
        Me.DisableOKButton()
    End Sub

    Private Sub Ordre_Generation_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
            If My.Computer.FileSystem.FileExists(Me.Nom_KryptonTextBox1.Text) Then
                My.Computer.FileSystem.DeleteFile(Me.Nom_KryptonTextBox1.Text, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
            Dim proc As New Process
            With proc.StartInfo
                .FileName = Application.StartupPath & "\Access32.exe"
                .CreateNoWindow = True
                .ErrorDialog = True
                .ErrorDialogParentHandle = Me.Handle
                .RedirectStandardOutput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                If Not Me.KryptonTextBox1.Text = Nothing Then
                    .Arguments = "createdb=" & ChrW(34) & Me.Nom_KryptonTextBox1.Text & ChrW(34) & " pswd=" & ChrW(34) & Me.KryptonTextBox1.Text & ChrW(34)
                Else
                    .Arguments = "createdb=" & ChrW(34) & Me.Nom_KryptonTextBox1.Text & ChrW(34)
                End If
            End With
            proc.Start()
            Dim result As String = proc.StandardOutput.ReadLine
            proc.WaitForExit()

            If result = "1" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                .MainInstruction = RM.GetString("MainInstruction10")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
        End If

    End Sub

    Private Sub Ordre_Generation_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.SaveFileDialog1.Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Nouvelle_Base_Access"))
        Me.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Nouvelle_Base_Access_Filtre")
        Me.SaveFileDialog1.FilterIndex = 0
        Me.SaveFileDialog1.OverwritePrompt = True
        Me.SaveFileDialog1.FileName = Nothing
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Nom_KryptonTextBox1.Text = Me.SaveFileDialog1.FileName
            Me.EnableOKButton()
            Me.Nom_KryptonTextBox1_TextChanged(Nothing, Nothing)
        End If
    End Sub


    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonTextBox1.TextChanged
        Dim oki As Boolean = True
        For Each strr As String In Caractères_Interdit_Non_Numerique
            If Me.KryptonTextBox1.Text.Contains(strr) Then oki = False : Exit For
        Next

        If Not oki OrElse Me.KryptonTextBox1.Text.Contains(" ") Then
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, Me.ToolTip1.GetToolTip(Me.KryptonTextBox1))
            Me.DisableOKButton()
        Else
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, "")
            Me.EnableOKButton()
        End If

        If Me.Nom_KryptonTextBox1.Text = Nothing Then
            Me.DisableOKButton()
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
