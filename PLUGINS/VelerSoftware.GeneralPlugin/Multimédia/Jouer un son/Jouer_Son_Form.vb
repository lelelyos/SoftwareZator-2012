Public Class Jouer_Son_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Musique.wav"
            .RadioButton1.Checked = True

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                Select Case .Param2
                    Case "Background"
                        .RadioButton1.Checked = True
                    Case "BackgroundLoop"
                        .RadioButton2.Checked = True
                    Case "WaitToComplete"
                        .RadioButton3.Checked = True
                End Select
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            If .RadioButton1.Checked Then
                .Param2 = "Background"
            ElseIf .RadioButton2.Checked Then
                .Param2 = "BackgroundLoop"
            ElseIf .RadioButton3.Checked Then
                .Param2 = "WaitToComplete"
            End If

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim strr As String = ""
        If Me.RadioButton1.Checked Then
            strr = "Microsoft.VisualBasic.AudioPlayMode.Background"
        ElseIf Me.RadioButton2.Checked Then
            strr = "Microsoft.VisualBasic.AudioPlayMode.BackgroundLoop"
        ElseIf Me.RadioButton3.Checked Then
            strr = "Microsoft.VisualBasic.AudioPlayMode.WaitToComplete"
        End If

        If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("_computer.Audio"), "Play", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(strr))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.Audio"), "Play", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(strr))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Play" Then
                        If metho.Parameters.Count >= 0 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 1 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(1), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Background"
                                    Me.RadioButton1.Checked = True
                                Case "BackgroundLoop"
                                    Me.RadioButton2.Checked = True
                                Case "WaitToComplete"
                                    Me.RadioButton3.Checked = True
                            End Select
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class