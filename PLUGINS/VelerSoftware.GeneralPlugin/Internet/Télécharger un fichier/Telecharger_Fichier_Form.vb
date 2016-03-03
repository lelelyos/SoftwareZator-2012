Public Class Telecharger_Fichier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Titre_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .Titre_ActionTextBox.Text = "http://"
            .ActionTextBox1.Text = "%(APPLICATION=APPLICATION_PATH)%\Votre fichier.txt"

            If Not .Param1 = Nothing Then
                .Titre_ActionTextBox.Text = .Param1
            End If

            If Not .Param2 = Nothing Then
                .ActionTextBox1.Text = .Param2
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .ActionTextBox1.Text = "" OrElse .Titre_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Titre_ActionTextBox.Text

            .Param2 = .ActionTextBox1.Text


            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.ActionTextBox1.Text = "" OrElse Me.Titre_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.Network"), "DownloadFile", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Titre_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

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
                    If metho.Method.MethodName = "DownloadFile" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeVariableReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName = "My.Computer.Network" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Titre_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class