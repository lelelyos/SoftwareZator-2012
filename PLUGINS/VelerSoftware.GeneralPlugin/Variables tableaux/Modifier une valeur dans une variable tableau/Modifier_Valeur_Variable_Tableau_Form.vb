Public Class Modifier_Valeur_Variable_Tableau_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ValueEdit1.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            Me.ActionTextBox1.Text =" 0"

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If a.Array Then
                    .Boutons_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param3 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param3)
            End If

            If Not .Param2 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param2, CInt(.Param4))
            End If

            If Not .Param5 = Nothing Then
                Me.ActionTextBox1.Text = .Param5
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
            .Param2 = .ValueEdit1.GetStrictValue()
            .Param4 = CInt(.ValueEdit1.Editor)
            .Param3 = .ValueEdit1.GetGeneratedCode()
            If Me.ActionTextBox1.Text = "" Then
                .Param5 = "0"
            Else
                .Param5 = Me.ActionTextBox1.Text
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
        If Me.Boutons_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Me.ActionTextBox1.Text = "" Then Me.ActionTextBox1.Text = "0"

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & "(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ") = " & Me.ValueEdit1.GetGeneratedCode())
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements
                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeMethodInvokeExpression Then
                    Me.Boutons_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeMethodInvokeExpression).Method.MethodName
                    If TypeOf DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeMethodInvokeExpression).Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                        Me.ActionTextBox1.Text = DirectCast(DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeMethodInvokeExpression).Parameters(0), CodeDom.CodePrimitiveExpression).Value
                    End If
                End If

            Next
        End If
    End Sub


End Class