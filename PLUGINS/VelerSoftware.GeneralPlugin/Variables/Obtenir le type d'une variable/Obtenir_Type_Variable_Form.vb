Public Class Obtenir_Type_Variable_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Var1_ComboBox.Items.Clear()
            .Var2_ComboBox.Items.Clear()
            For Each a As String In .Tools.GetCurrentFunctionSettings
                .Var1_ComboBox.Items.Add(a)
            Next
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Var1_ComboBox.Items.Add(a.Name)
                    .Var2_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Var1_ComboBox.FindString(.Param1) = -1 Then
                    .Var1_ComboBox.Text = .Var1_ComboBox.Items(.Var1_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .Var2_ComboBox.FindString(.Param2) = -1 Then
                    .Var2_ComboBox.Text = .Var2_ComboBox.Items(.Var2_ComboBox.FindString(.Param2))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Var1_ComboBox.Text = Nothing OrElse .Var2_ComboBox.Text = Nothing Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Var1_ComboBox.Text
            .Param2 = .Var2_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick

        Dim sourceWriter As New IO.StringWriter()

        Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Var1_ComboBox.Text)
        Dim VariableStatement2 As New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text)
        Dim OperationStatement As New CodeDom.CodeAssignStatement(VariableStatement2, New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeMethodInvokeExpression(VariableStatement, "GetType", New CodeDom.CodeExpression() {}), "FullName"))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeAssignStatement
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(sta, CodeDom.CodeAssignStatement)
                    If TypeOf metho.Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf metho.Right Is CodeDom.CodePropertyReferenceExpression AndAlso DirectCast(metho.Right, CodeDom.CodePropertyReferenceExpression).PropertyName = "FullName" Then
                        Me.Var2_ComboBox.Text = DirectCast(metho.Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        Me.Var1_ComboBox.Text = TryCast(DirectCast(DirectCast(metho.Right, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodeMethodInvokeExpression).Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                End If
            Next
        End If
    End Sub

End Class