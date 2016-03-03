''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ReconnaissanceVocale

    Friend WithEvents SRE As New Speech.Recognition.SpeechRecognitionEngine

    Private StepIndex As Integer

    Private Sub CreerEvenement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Nom_KryptonTextBox1))


        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("ReconnaissanceVocale_Caption")

        Me.CheckBox1.Checked = True
    End Sub

    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        SRE.RecognizeAsyncCancel()
        SRE.RecognizeAsyncStop()
        SRE.UnloadAllGrammars()
        If Me.WizardTabControl1.SelectedTab Is Me.TabPage2 Then
            StepIndex = 1
            ' RECONNAISSANCE VOCALE
            ' Rajout des choix à la grammaire du prog
            Dim grammar As System.Speech.Recognition.GrammarBuilder = New System.Speech.Recognition.GrammarBuilder()
            grammar.Culture = System.Threading.Thread.CurrentThread.CurrentCulture
            grammar.Append(New System.Speech.Recognition.Choices(RM.GetString("ReconnaissanceVocale_Sentence")))

            ' Initialisation de la reconnaissance vocale
            SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.Grammar(grammar))
            SRE.SetInputToDefaultAudioDevice()
            SRE.RequestRecognizerUpdate()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)

            Me.Label7.Visible = False
            DisableNextButton()

        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage4 Then
            StepIndex = 2
            Me.TextBox1.Text = Nothing
            Me.PictureBox2.Image = My.Resources.ok_no
            Me.PictureBox3.Image = My.Resources.ok_no
            Me.PictureBox2.Tag = ""
            Me.PictureBox3.Tag = ""
            ' RECONNAISSANCE VOCALE                                
            ' Initialisation de la reconnaissance vocale
            SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
            SRE.SetInputToDefaultAudioDevice()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)

            DisableNextButton()

        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage5 Then
            StepIndex = 3
            Me.TextBox2.Text = Nothing
            If My.Settings.Langue = "en" Then
                Me.PictureBox4.Image = My.Resources.Vocale_Didac_en_1
            Else
                Me.PictureBox4.Image = My.Resources.Vocale_Didac_fr_1
            End If
            Me.PictureBox5.Image = My.Resources.ok_no
            Me.PictureBox5.Tag = ""
            ' RECONNAISSANCE VOCALE                                
            ' Initialisation de la reconnaissance vocale
            SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
            SRE.SetInputToDefaultAudioDevice()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)

            DisableNextButton()

        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage6 Then
            StepIndex = 4
            Me.TextBox3.Text = Nothing
            If My.Settings.Langue = "en" Then
                Me.PictureBox6.Image = My.Resources.Vocale_Didac_en_1
            Else
                Me.PictureBox6.Image = My.Resources.Vocale_Didac_fr_1
            End If
            Me.PictureBox7.Image = My.Resources.ok_no
            Me.PictureBox7.Tag = ""
            ' RECONNAISSANCE VOCALE                                
            ' Initialisation de la reconnaissance vocale
            SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
            SRE.SetInputToDefaultAudioDevice()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)

            DisableNextButton()

        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage1 Then
            EnableNextButton()

        ElseIf Me.WizardTabControl1.SelectedTab Is Me.TabPage3 Then
            EnableNextButton()
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
            If Form1.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox IsNot Nothing Then
                Form1.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked = Me.CheckBox1.Checked
            ElseIf Me.ParentForm Is Options Then
                Options.Activate_Voice_Recognition_CheckBox.Checked = Me.CheckBox1.Checked
            Else
                My.Settings.Activer_Reconnaissance_Vocale = Me.CheckBox1.Checked
            End If
        End If
    End Sub




    Private Sub SRE_AudioLevelUpdated(ByVal sender As Object, ByVal e As Speech.Recognition.AudioLevelUpdatedEventArgs) Handles SRE.AudioLevelUpdated
        Select Case StepIndex
            Case 1
                If e.AudioLevel <= 100 Then
                    Me.ProgressBar1.Value = e.AudioLevel
                End If
        End Select
    End Sub

    Private Sub SRE_SpeechRecognized(ByVal sender As Object, ByVal e As Speech.Recognition.SpeechRecognizedEventArgs) Handles SRE.SpeechRecognized
        Select Case StepIndex
            Case 1
                If e.Result.Text.ToLower = RM.GetString("ReconnaissanceVocale_Sentence") Then
                    Me.Label7.Visible = True
                    EnableNextButton()
                    SRE.RecognizeAsyncCancel()
                    SRE.RecognizeAsyncStop()
                    SRE.UnloadAllGrammars()
                    Me.ProgressBar1.Value = 0
                End If

            Case 2
                Dim txt As String = e.Result.Text
                Dim words As System.Collections.ObjectModel.ReadOnlyCollection(Of System.Speech.Recognition.RecognizedWordUnit) = e.Result.Words

                Me.TextBox1.Text = txt

                If words.Count = 2 Then
                    If words(0).Text = RM.GetString("Voice_Recognisation_Word1") AndAlso words(1).Text = RM.GetString("Voice_Recognisation_Word2") Then
                        Me.PictureBox2.Image = My.Resources.ok
                        Me.PictureBox2.Tag = "ok"
                    ElseIf words(0).Text = RM.GetString("Voice_Recognisation_Word1") AndAlso words(1).Text = RM.GetString("Voice_Recognisation_Word3") Then
                        Me.PictureBox3.Image = My.Resources.ok
                        Me.PictureBox3.Tag = "ok"
                    End If
                End If

                If Me.PictureBox2.Tag = "ok" AndAlso Me.PictureBox3.Tag = "ok" Then
                    SRE.RecognizeAsyncCancel()
                    SRE.RecognizeAsyncStop()
                    SRE.UnloadAllGrammars()
                    EnableNextButton()
                End If

            Case 3
                Dim txt As String = e.Result.Text
                Me.TextBox2.Text = txt

                If txt.ToLower = RM.GetString("ReconnaissanceVocale_Sentence2") Then
                    Me.PictureBox5.Image = My.Resources.ok
                    Me.PictureBox5.Tag = "ok"
                    If My.Settings.Langue = "en" Then
                        Me.PictureBox4.Image = My.Resources.Vocale_Didac_en_2
                    Else
                        Me.PictureBox4.Image = My.Resources.Vocale_Didac_fr_2
                    End If
                End If

                If Me.PictureBox5.Tag = "ok" Then
                    SRE.RecognizeAsyncCancel()
                    SRE.RecognizeAsyncStop()
                    SRE.UnloadAllGrammars()
                    EnableNextButton()
                End If

            Case 4
                Dim txt As String = e.Result.Text
                Me.TextBox3.Text = txt

                If txt.ToLower.Contains(RM.GetString("ReconnaissanceVocale_Sentence3")) AndAlso txt.ToLower.Contains(RM.GetString("ReconnaissanceVocale_Sentence4")) Then
                    Me.PictureBox7.Image = My.Resources.ok
                    Me.PictureBox7.Tag = "ok"
                    If My.Settings.Langue = "en" Then
                        Me.PictureBox6.Image = My.Resources.Vocale_Didac_en_3
                    Else
                        Me.PictureBox6.Image = My.Resources.Vocale_Didac_fr_3
                    End If
                End If

                If Me.PictureBox7.Tag = "ok" Then
                    SRE.RecognizeAsyncCancel()
                    SRE.RecognizeAsyncStop()
                    SRE.UnloadAllGrammars()
                    EnableNextButton()
                End If

        End Select
    End Sub

End Class
