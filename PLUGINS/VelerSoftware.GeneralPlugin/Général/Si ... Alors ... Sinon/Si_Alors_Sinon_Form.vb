Public Class Si_Alors_Sinon_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ValueEdit1.Tools = .Tools

            .ParseCode_Button_Visible = True

            .Condition_ComboBox.SelectedIndex = 0

            .Variable_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                .Variable_ComboBox.Items.Add(a.Name)
            Next

            If Not .Param1 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param1) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .Condition_ComboBox.SelectedIndex = CInt(.Param2)
            End If

            If Not .Param3 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param3)
            End If

            If Not .Param4 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param4, CInt(.Param5))
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Variable_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Variable_ComboBox.Text

            .Param2 = .Condition_ComboBox.SelectedIndex

            .Param3 = .ValueEdit1.GetGeneratedCode()
            .Param4 = .ValueEdit1.GetStrictValue()
            .Param5 = CInt(.ValueEdit1.Editor)

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

        Dim var_depart As New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text)

        Dim codecond As New CodeDom.CodeConditionStatement()
        Select Case Me.Condition_ComboBox.SelectedIndex
            Case 0
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.ValueEquality, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 1
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 2
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThanOrEqual, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 3
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.GreaterThan, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 4
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.GreaterThanOrEqual, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 5
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.IdentityInequality, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
            Case 6
                codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.IdentityEquality, New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode))
        End Select

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(codecond, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeBinaryOperatorExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeConditionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeConditionStatement).Condition Is CodeDom.CodeBinaryOperatorExpression Then
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeConditionStatement).Condition, CodeDom.CodeBinaryOperatorExpression)
                    If TypeOf metho.Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Variable_ComboBox.Text = DirectCast(metho.Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                    Select Case metho.Operator
                        Case CodeDom.CodeBinaryOperatorType.ValueEquality
                            Me.Condition_ComboBox.SelectedIndex = 0
                        Case CodeDom.CodeBinaryOperatorType.LessThan
                            Me.Condition_ComboBox.SelectedIndex = 1
                        Case CodeDom.CodeBinaryOperatorType.LessThanOrEqual
                            Me.Condition_ComboBox.SelectedIndex = 2
                        Case CodeDom.CodeBinaryOperatorType.GreaterThan
                            Me.Condition_ComboBox.SelectedIndex = 3
                        Case CodeDom.CodeBinaryOperatorType.GreaterThanOrEqual
                            Me.Condition_ComboBox.SelectedIndex = 4
                        Case CodeDom.CodeBinaryOperatorType.IdentityInequality
                            Me.Condition_ComboBox.SelectedIndex = 5
                        Case CodeDom.CodeBinaryOperatorType.IdentityEquality
                            Me.Condition_ComboBox.SelectedIndex = 6
                    End Select

                End If

            Next
        End If
    End Sub

    Private Sub Variable_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Variable_ComboBox.SelectedIndexChanged
        For Each a As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
            If Me.Variable_ComboBox.Text = a.Name AndAlso a.Array Then
                Me.Condition_ComboBox.SelectedIndex = 6
                Exit For
            End If
        Next
    End Sub
End Class