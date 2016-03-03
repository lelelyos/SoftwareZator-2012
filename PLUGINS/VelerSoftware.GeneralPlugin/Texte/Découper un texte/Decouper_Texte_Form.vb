Public Class Decouper_Texte_Form
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

            .Variable_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param3 = Nothing Then
                .Titre_ActionTextBox.Text = .Param3
            End If

            If Not .Param2 = Nothing Then
                .Texte_Message_ActionTextBox.Text = .Param2
            End If

            If Not .Param1 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param1) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param1))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .Titre_ActionTextBox.Text = "" OrElse .Variable_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param3 = .Titre_ActionTextBox.Text
            .Param2 = .Texte_Message_ActionTextBox.Text
            .Param1 = .Variable_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.Titre_ActionTextBox.Text = "" OrElse Me.Variable_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text)
        Dim MsgBoxStatement As New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(CStr(" & Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & ").Split(" & Tools.TransformKeyVariables(Me.Titre_ActionTextBox.Text, True) & ")))")
        Dim OperationStatement As New CodeDom.CodeAssignStatement(VariableStatement, MsgBoxStatement)
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeObjectCreateExpression Then
                    Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    ' Dans le cas où se soit une simple méthode
                    If DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters.Count = 1 AndAlso TypeOf DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters(0) Is CodeDom.CodeMethodInvokeExpression Then
                        metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters(0)
                        If metho.Method.MethodName = "Cast" AndAlso metho.Parameters.Count = 1 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodeMethodInvokeExpression AndAlso DirectCast(metho.Parameters(0), CodeDom.CodeMethodInvokeExpression).Method.MethodName = "Split" Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodeMethodInvokeExpression).Method.TargetObject, CodeDom.CodePrimitiveExpression).Value
                            Me.Titre_ActionTextBox.Text = DirectCast(DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodeMethodInvokeExpression).Method.TargetObject, CodeDom.CodeMethodInvokeExpression).Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class