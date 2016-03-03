Public Class Envoyer_Fichier_FTP_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Hote_ActionTextBox1.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .Hote_ActionTextBox1.Text = "%(APPLICATION=APPLICATION_PATH)%\The file"
            .ActionTextBox1.Text = "/Path/The file"

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            .Boutons_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Boutons_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param3 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param3) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param3))
                End If
            End If

            If Not .Param1 = Nothing Then .Hote_ActionTextBox1.Text = .Param1
            If Not .Param2 = Nothing Then .ActionTextBox1.Text = .Param2

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Hote_ActionTextBox1.Text = "" OrElse .ActionTextBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Hote_ActionTextBox1.Text
            .Param2 = .ActionTextBox1.Text
            .Param3 = .Boutons_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Hote_ActionTextBox1.Text = "" OrElse Me.ActionTextBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_FTPPlugin"), "UploadFile", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Hote_ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)))
        If Me.Boutons_ComboBox.Text = Nothing Then
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
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
                    If metho.Method.MethodName = "UploadFile" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Hote_ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        Me.Boutons_ComboBox.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "UploadFile" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Hote_ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Boutons_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class