Public Class Determiner_Dossier_Existe_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier"

            .ComboBox1.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox1.Items.Add(a.Name)
                End If
            Next

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .ComboBox1.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("_computer.FileSystem"), "DirectoryExists", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.FileSystem"), "DirectoryExists", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                    ' Dans le cas où se soit une simple méthode
                    Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                        ' Dans le cas où se soit une assignation de variable
                        metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                        If metho.Method.MethodName = "DirectoryExists" Then
                            If metho.Parameters.Count >= 0 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                                Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                            End If
                        End If

                    End If
                End If

            Next
        End If
    End Sub

End Class