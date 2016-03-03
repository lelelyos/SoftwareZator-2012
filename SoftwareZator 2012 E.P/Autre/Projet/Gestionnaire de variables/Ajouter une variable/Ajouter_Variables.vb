''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Ajouter_Variables

    Friend Nom_Projet As String

    Private Sub Gestionnaire_Variables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox1.TextBox, ToolTip1.GetToolTip(Me.Nom_KryptonTextBox1))
        Me.ToolTip1.SetToolTip(Me.Description_KryptonTextBox2.TextBox, ToolTip1.GetToolTip(Me.Description_KryptonTextBox2))

        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_KryptonTextBox1.TextChanged
        If Me.Nom_KryptonTextBox1.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.Nom_KryptonTextBox1, Me.ToolTip1.GetToolTip(Me.Nom_KryptonTextBox1))
        Else
            Me.ErrorProvider1.SetError(Me.Nom_KryptonTextBox1, "")
        End If
    End Sub

    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nom_KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Ajouter_Variables_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Ajouter_Variables_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        Dim oki As Boolean = True
        For Each strr As String In Caractères_Interdit
            If Me.Nom_KryptonTextBox1.Text.ToLower.Contains(strr) Then oki = False : Exit For
        Next
        If oki AndAlso (DirectCast(Me.Owner, Gestionnaire_Variables).ListView1.Items.IndexOfKey(Me.Nom_KryptonTextBox1.Text) = -1) AndAlso (Mot_Cles_Interdit.IndexOf(Me.Nom_KryptonTextBox1.Text.ToLower()) = -1) Then
            Me.Nom_KryptonTextBox1.Text = Me.Nom_KryptonTextBox1.Text.Replace(" ", Nothing)
            If Not Me.Nom_KryptonTextBox1.Text.Trim(" ") = Nothing Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.ErrorProvider1.SetError(Me.Nom_KryptonTextBox1, Me.ToolTip1.GetToolTip(Me.Nom_KryptonTextBox1))
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = RM.GetString("Content14")
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content15"), Me.Nom_KryptonTextBox1.Text)
                .MainInstruction = RM.GetString("MainInstruction11")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
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
