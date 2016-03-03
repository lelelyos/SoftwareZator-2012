Public Class Afficher_Un_Message_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Titre_ActionTextBox.Tools = .Tools
            .Texte_Message_ActionTextBox.Tools = .Tools

            .Titre_ActionTextBox.Text = ""
            .Texte_Message_ActionTextBox.Text = ""

            .Boutons_ComboBox.SelectedIndex = 0
            .Icone_ComboBox.SelectedIndex = 4

            .Variable_ComboBox.Items.Clear()
            .Variable_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            .Titre_ActionTextBox.Text = .Tools.GetCurrentProjectTitle

            If Not .Param1 = Nothing Then
                .Titre_ActionTextBox.Text = .Param1
            End If

            If Not .Param2 = Nothing Then
                If .Param2 = "System.Windows.Forms.MessageBoxButtons.OK" Then
                    .Boutons_ComboBox.SelectedIndex = 0
                ElseIf .Param2 = "System.Windows.Forms.MessageBoxButtons.OKCancel" Then
                    .Boutons_ComboBox.SelectedIndex = 1
                ElseIf .Param2 = "System.Windows.Forms.MessageBoxButtons.YesNo" Then
                    .Boutons_ComboBox.SelectedIndex = 2
                ElseIf .Param2 = "System.Windows.Forms.MessageBoxButtons.YesNoCancel" Then
                    .Boutons_ComboBox.SelectedIndex = 3
                ElseIf .Param2 = "System.Windows.Forms.MessageBoxButtons.RetryCancel" Then
                    .Boutons_ComboBox.SelectedIndex = 4
                ElseIf .Param2 = "System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore" Then
                    .Boutons_ComboBox.SelectedIndex = 5
                End If
            End If

            If Not .Param3 = Nothing Then
                If .Param3 = "System.Windows.Forms.MessageBoxIcon.Error" Then
                    .Icone_ComboBox.SelectedIndex = 0
                ElseIf .Param3 = "System.Windows.Forms.MessageBoxIcon.Warning" Then
                    .Icone_ComboBox.SelectedIndex = 1
                ElseIf .Param3 = "System.Windows.Forms.MessageBoxIcon.Question" Then
                    .Icone_ComboBox.SelectedIndex = 2
                ElseIf .Param3 = "System.Windows.Forms.MessageBoxIcon.Information" Then
                    .Icone_ComboBox.SelectedIndex = 3
                ElseIf .Param3 = "System.Windows.Forms.MessageBoxIcon.None" Then
                    .Icone_ComboBox.SelectedIndex = 4
                End If
            End If

            If Not .Param4 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param4

            If Not .Param5 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param5) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param5))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .Titre_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Titre_ActionTextBox.Text

            If .Boutons_ComboBox.SelectedIndex = 0 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.OK"
            ElseIf .Boutons_ComboBox.SelectedIndex = 1 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.OKCancel"
            ElseIf .Boutons_ComboBox.SelectedIndex = 2 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.YesNo"
            ElseIf .Boutons_ComboBox.SelectedIndex = 3 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.YesNoCancel"
            ElseIf .Boutons_ComboBox.SelectedIndex = 4 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.RetryCancel"
            ElseIf .Boutons_ComboBox.SelectedIndex = 5 Then
                .Param2 = "System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore"
            End If

            If .Icone_ComboBox.SelectedIndex = 0 Then
                .Param3 = "System.Windows.Forms.MessageBoxIcon.Error"
            ElseIf .Icone_ComboBox.SelectedIndex = 1 Then
                .Param3 = "System.Windows.Forms.MessageBoxIcon.Warning"
            ElseIf .Icone_ComboBox.SelectedIndex = 2 Then
                .Param3 = "System.Windows.Forms.MessageBoxIcon.Question"
            ElseIf .Icone_ComboBox.SelectedIndex = 3 Then
                .Param3 = "System.Windows.Forms.MessageBoxIcon.Information"
            ElseIf .Icone_ComboBox.SelectedIndex = 4 Then
                .Param3 = "System.Windows.Forms.MessageBoxIcon.None"
            End If

            .Param4 = .Texte_Message_ActionTextBox.Text

            .Param5 = .Variable_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.Titre_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim txt1 As String = Nothing
        Dim txt2 As String = Nothing

        If Me.Boutons_ComboBox.SelectedIndex = 0 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.OK"
        ElseIf Me.Boutons_ComboBox.SelectedIndex = 1 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.OKCancel"
        ElseIf Me.Boutons_ComboBox.SelectedIndex = 2 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.YesNo"
        ElseIf Me.Boutons_ComboBox.SelectedIndex = 3 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.YesNoCancel"
        ElseIf Me.Boutons_ComboBox.SelectedIndex = 4 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.RetryCancel"
        ElseIf Me.Boutons_ComboBox.SelectedIndex = 5 Then
            txt1 = "System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore"
        End If

        If Me.Icone_ComboBox.SelectedIndex = 0 Then
            txt2 = "System.Windows.Forms.MessageBoxIcon.Error"
        ElseIf Me.Icone_ComboBox.SelectedIndex = 1 Then
            txt2 = "System.Windows.Forms.MessageBoxIcon.Warning"
        ElseIf Me.Icone_ComboBox.SelectedIndex = 2 Then
            txt2 = "System.Windows.Forms.MessageBoxIcon.Question"
        ElseIf Me.Icone_ComboBox.SelectedIndex = 3 Then
            txt2 = "System.Windows.Forms.MessageBoxIcon.Information"
        ElseIf Me.Icone_ComboBox.SelectedIndex = 4 Then
            txt2 = "System.Windows.Forms.MessageBoxIcon.None"
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.Variable_ComboBox.Text = "" Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("System.Windows.Forms.MessageBox"), "Show", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Titre_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(txt1), New CodeDom.CodeSnippetExpression(txt2))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text)
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("System.Windows.Forms.MessageBox"), "Show", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Titre_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(txt1), New CodeDom.CodeSnippetExpression(txt2)), "ToString", New CodeDom.CodeExpression() {})
            Dim OperationStatement As New CodeDom.CodeAssignStatement(VariableStatement, MsgBoxStatement)
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

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
                    If metho.Method.MethodName = "Show" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType = "System.Windows.Forms.MessageBox" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Titre_ActionTextBox.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(2), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "OK"
                                    Me.Boutons_ComboBox.SelectedIndex = 0
                                Case "OKCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 1
                                Case "YesNo"
                                    Me.Boutons_ComboBox.SelectedIndex = 2
                                Case "YesNoCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 3
                                Case "RetryCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 4
                                Case "AbortRetryIgnore"
                                    Me.Boutons_ComboBox.SelectedIndex = 5
                            End Select
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(3), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Error"
                                    Me.Icone_ComboBox.SelectedIndex = 0
                                Case "Warning"
                                    Me.Icone_ComboBox.SelectedIndex = 1
                                Case "Question"
                                    Me.Icone_ComboBox.SelectedIndex = 2
                                Case "Information"
                                    Me.Icone_ComboBox.SelectedIndex = 3
                                Case "None"
                                    Me.Icone_ComboBox.SelectedIndex = 4
                            End Select
                        End If
                        Me.Variable_ComboBox.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Show" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType = "System.Windows.Forms.MessageBox" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Titre_ActionTextBox.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(2), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "OK"
                                    Me.Boutons_ComboBox.SelectedIndex = 0
                                Case "OKCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 1
                                Case "YesNo"
                                    Me.Boutons_ComboBox.SelectedIndex = 2
                                Case "YesNoCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 3
                                Case "RetryCancel"
                                    Me.Boutons_ComboBox.SelectedIndex = 4
                                Case "AbortRetryIgnore"
                                    Me.Boutons_ComboBox.SelectedIndex = 5
                            End Select
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(3), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Error"
                                    Me.Icone_ComboBox.SelectedIndex = 0
                                Case "Warning"
                                    Me.Icone_ComboBox.SelectedIndex = 1
                                Case "Question"
                                    Me.Icone_ComboBox.SelectedIndex = 2
                                Case "Information"
                                    Me.Icone_ComboBox.SelectedIndex = 3
                                Case "None"
                                    Me.Icone_ComboBox.SelectedIndex = 4
                            End Select
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class