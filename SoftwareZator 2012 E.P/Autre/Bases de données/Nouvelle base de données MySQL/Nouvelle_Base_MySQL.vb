''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class NouvelleBaseMySQL

    Friend LOCALE As Boolean

    Private Sub CreerEvenement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ToolTip1.SetToolTip(Me.Adresse_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Adresse_KryptonTextBox1))
        Me.ToolTip1.SetToolTip(Me.Port_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Port_KryptonTextBox1))
        Me.ToolTip1.SetToolTip(Me.Utilisateur_KryptonTextBox2.TextBox, Me.ToolTip1.GetToolTip(Utilisateur_KryptonTextBox2))
        Me.ToolTip1.SetToolTip(Me.Mot_De_Passe_KryptonTextBox3.MaskedTextBox, Me.ToolTip1.GetToolTip(Mot_De_Passe_KryptonTextBox3))
        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox4.TextBox, Me.ToolTip1.GetToolTip(Nom_KryptonTextBox4))


        DisableNextButton()
        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("NouvelleBaseMySQL_Caption")
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Adresse_KryptonTextBox1.TextChanged, Nom_KryptonTextBox4.TextChanged
        If sender.Text = Nothing OrElse sender.Text.Contains(" ") Then
            Me.ErrorProvider1.SetError(sender, Me.ToolTip1.GetToolTip(sender))
            DisableNextButton()
        Else
            Me.ErrorProvider1.SetError(sender, "")
            EnableNextButton()
        End If
    End Sub

    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Adresse_KryptonTextBox1.KeyPress, Nom_KryptonTextBox4.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        If Me.WizardTabControl1.SelectedIndex = 0 Then
            DisableNextButton()
        ElseIf Me.WizardTabControl1.SelectedIndex = 1 Then
            If Me.Adresse_KryptonTextBox1.Text = Nothing Then
                DisableNextButton()
            Else
                EnableNextButton()
            End If
        ElseIf Me.WizardTabControl1.SelectedIndex = 2 Then
            EnableNextButton()
        ElseIf Me.WizardTabControl1.SelectedIndex = 3 Then
            Nom_KryptonTextBox1_TextChanged(Me.Nom_KryptonTextBox4, Nothing)
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

    Private Sub OnFinishButton_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim cnx As New ClassBasesDeDonneesMySQL
            cnx.Connect(Adresse_KryptonTextBox1.Text, Port_KryptonTextBox1.Text, Utilisateur_KryptonTextBox2.Text, Mot_De_Passe_KryptonTextBox3.Text, Nothing, True)
            If cnx.GetConnectStatus = 1 Then
                If Not cnx.CreateNewDataBase(Me.Nom_KryptonTextBox4.Text) = 1 Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content47"))
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    e.Cancel = True
                End If
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content46"))
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                e.Cancel = True
            End If
            cnx.Disconnect()
        End If
    End Sub

    Private Sub Windows_CommandLink_Click(sender As System.Object, e As System.EventArgs) Handles Windows_CommandLink.Click
        Me.Adresse_KryptonTextBox1.Text = "localhost"
        Me.Port_KryptonTextBox1.Text = "21"
        Me.GoToNextStep()
    End Sub

    Private Sub Console_CommandLink1_Click(sender As System.Object, e As System.EventArgs) Handles Console_CommandLink1.Click
        Me.Adresse_KryptonTextBox1.Text = "xxx.xxx.xxx.xxx"
        Me.Port_KryptonTextBox1.Text = "21"
        Me.GoToNextStep()
    End Sub
End Class
