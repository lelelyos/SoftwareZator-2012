Public Class Modifier_Ligne_Table_Access_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            If Not .Tools.GetCurrentProjectCPU = SZVB.Projet.Projet.Cpus.x86 Then
                System.Windows.Forms.MessageBox.Show(RM.GetString("Message_CPU"), RM.GetString("MainInstruction1"), Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")


            .ValueEdit1.Tools = .Tools

            .ActionTextBox1.Tools = .Tools
            .ActionTextBox1.Text = ""
            .ActionTextBox2.Tools = .Tools
            .ActionTextBox2.Text = "0"
            .ActionTextBox3.Tools = .Tools
            .ActionTextBox3.Text = ""

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            .Boutons_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Boutons_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then .ActionTextBox1.Text = .Param2

            If Not .Param3 = Nothing Then .ActionTextBox2.Text = .Param3

            If Not .Param4 = Nothing Then .ActionTextBox3.Text = .Param4

            If Not .Param5 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param5)
            End If

            If Not .Param6 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param6, CInt(.Param7))
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .ActionTextBox1.Text = "" OrElse .ActionTextBox2.Text = "" OrElse .ActionTextBox3.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .ActionTextBox1.Text = .ActionTextBox1.Text.Replace(" ", "_")

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .ActionTextBox1.Text
            .Param3 = .ActionTextBox2.Text
            .Param4 = .ActionTextBox3.Text

            .Param6 = .ValueEdit1.GetStrictValue()
            .Param7 = CInt(.ValueEdit1.Editor)
            .Param5 = .ValueEdit1.GetGeneratedCode()

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.ActionTextBox1.Text = "" OrElse Me.ActionTextBox2.Text = "" OrElse Me.ActionTextBox3.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Me.ActionTextBox1.Text = Me.ActionTextBox1.Text.Replace(" ", "_")

        Dim sourceWriter As New IO.StringWriter()

        If Not Me.Boutons_ComboBox.Text = "" Then
            Dim OperationStatement As New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), New CodeDom.CodeSnippetExpression("VelerSoftware_AccessPlugin.ChangeRowTable_Access(" & Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True, False) & ", " & Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False, False) & ", " & Tools.TransformKeyVariables(Me.ActionTextBox3.Text, True, False) & ", " & Me.ValueEdit1.GetGeneratedCode() & ")"))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeSnippetStatement("VelerSoftware_AccessPlugin.ChangeRowTable_Access(" & Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True, False) & ", " & Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False, False) & ", " & Tools.TransformKeyVariables(Me.ActionTextBox3.Text, True, False) & ", " & Me.ValueEdit1.GetGeneratedCode() & ")"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            Dim metho2 As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "ChangeRowTable_Access" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox3.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Boutons_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                ElseIf TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho2 = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho2.Method.MethodName = "ChangeRowTable_Access" Then
                        If TypeOf metho2.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho2.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho2.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox2.Text = DirectCast(metho2.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho2.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox3.Text = DirectCast(metho2.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        Me.Boutons_ComboBox.Text = Nothing
                    End If

                End If

            Next
        End If
    End Sub

End Class