Public Class Ajouter_Enete_Impression_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ActionTextBox2.Tools = .Tools
            .ActionTextBox2.Text = ""

            .RadioButton2.Checked = True
            .RadioButton4.Checked = True

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then
                    .Boutons_ComboBox.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .ActionTextBox2.Text = .Param2
            End If

            If Not .Param3 = Nothing Then
                Select Case .Param3
                    Case "Left"
                        .RadioButton1.Checked = True
                    Case "Center"
                        .RadioButton2.Checked = True
                    Case "Right"
                        .RadioButton3.Checked = True
                End Select
            End If

            If Not .Param4 = Nothing Then
                Select Case .Param4
                    Case "FootStep"
                        .RadioButton4.Checked = True
                    Case "HeadStep"
                        .RadioButton6.Checked = True
                End Select
            End If

            If Not .Param5 = Nothing Then
                Me.CheckBox1.Checked = CBool(.Param5)
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .ActionTextBox2.Text
            If .RadioButton1.Checked Then
                .Param3 = "Left"
            ElseIf .RadioButton2.Checked Then
                .Param3 = "Center"
            ElseIf .RadioButton3.Checked Then
                .Param3 = "Right"
            End If
            If .RadioButton4.Checked Then
                .Param4 = "FootStep"
            ElseIf .RadioButton6.Checked Then
                .Param4 = "HeadStep"
            End If
            .Param5 = .CheckBox1.Checked

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim pam3 As String = Nothing
        Dim pam4 As String = Nothing
        If Me.RadioButton1.Checked Then
            pam3 = "Left"
        ElseIf Me.RadioButton2.Checked Then
            pam3 = "Center"
        ElseIf Me.RadioButton3.Checked Then
            pam3 = "Right"
        End If
        If Me.RadioButton4.Checked Then
            pam4 = "FootStep"
        ElseIf Me.RadioButton6.Checked Then
            pam4 = "HeadStep"
        End If

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".setEntete(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, True) & ", VelerSoftware.PrintLib.PrintSystem.Alignement." & pam3 & ", VelerSoftware.PrintLib.PrintSystem.HeaderType." & pam4 & ", " & Me.CheckBox1.Checked & ")"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())


        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "setEntete" Then
                        If metho.Parameters.Count >= 1 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox2.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 2 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(1), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Left"
                                    Me.RadioButton1.Checked = True
                                Case "Center"
                                    Me.RadioButton2.Checked = True
                                Case "Right"
                                    Me.RadioButton3.Checked = True
                            End Select
                        End If
                        If metho.Parameters.Count >= 3 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(2), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "FootStep"
                                    Me.RadioButton4.Checked = True
                                Case "HeadStep"
                                    Me.RadioButton6.Checked = True
                            End Select
                        End If
                        If metho.Parameters.Count >= 4 AndAlso TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.CheckBox1.Checked = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class