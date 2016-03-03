Public Class Creer_Table_SQL_Server_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ActionTextBox1.Tools = .Tools
            .ActionTextBox1.Text = ""

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            .Boutons_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Boutons_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param2 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param2) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param2))
                End If
            End If

            If Not .Param1 = Nothing Then .ActionTextBox1.Text = .Param1

            If Not .Param3 = Nothing Then
                For Each strr As String In .Param3.Split(";")
                    If strr.Contains("|") Then
                        Me.DataGridView1.Rows.Add(strr.Split("|")(0), strr.Split("|")(1))
                    End If
                Next
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .ActionTextBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .ActionTextBox1.Text = .ActionTextBox1.Text.Replace(" ", "_")

            .Param2 = .Boutons_ComboBox.Text
            .Param1 = .ActionTextBox1.Text

            .Param3 = Nothing
            For Each cell As System.Windows.Forms.DataGridViewRow In DataGridView1.Rows
                If cell.Cells.Count > 0 AndAlso Not CStr(cell.Cells(0).Value) = Nothing AndAlso Not CStr(cell.Cells(1).Value) = Nothing Then
                    .Param3 &= CStr(cell.Cells(0).Value) & "|" & CStr(cell.Cells(1).Value) & ";"
                End If
            Next
            If Not .Param3 = Nothing Then .Param3 = .Param3.TrimEnd(";")

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.ActionTextBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()
        Dim columns As New Generic.List(Of String)
        Dim types As New Generic.List(Of String)
        Dim columns_param, types_param As String

        Me.ActionTextBox1.Text = Me.ActionTextBox1.Text.Replace(" ", "_")

        For Each cell As System.Windows.Forms.DataGridViewRow In DataGridView1.Rows
            If cell.Cells.Count > 0 AndAlso Not CStr(cell.Cells(0).Value) = Nothing AndAlso Not CStr(cell.Cells(1).Value) = Nothing Then
                columns.Add(CStr(cell.Cells(0).Value))
                types.Add(CStr(cell.Cells(1).Value))
            End If
        Next

        columns_param = Nothing
        types_param = Nothing
        For Each strr As String In columns
            columns_param += Tools.TransformKeyVariables(strr, True, True) & ", "
        Next
        If Not columns_param = Nothing Then columns_param = columns_param.TrimEnd(" ").TrimEnd(",")
        For Each strr As String In types
            types_param += ChrW(34) & strr & ChrW(34) & ", "
        Next
        If Not types_param = Nothing Then types_param = types_param.TrimEnd(" ").TrimEnd(",")

        If Not Me.Boutons_ComboBox.Text = "" Then
            Dim OperationStatement As New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), New CodeDom.CodeSnippetExpression("VelerSoftware_SQLServerPlugin.CreateNewTable_SQLServer(" & Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True, False) & ", New System.Collections.Generic.List(Of String)({" & columns_param & "}), New System.Collections.Generic.List(Of String)({" & types_param & "}))"))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeSnippetStatement("VelerSoftware_SQLServerPlugin.CreateNewTable_SQLServer(" & Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True, False) & ", New System.Collections.Generic.List(Of String)({" & columns_param & "}), New System.Collections.Generic.List(Of String)({" & types_param & "}))"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
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
                    If metho.Method.MethodName = "CreateNewTable_SQLServer" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Boutons_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                ElseIf TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho2 = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho2.Method.MethodName = "CreateNewTable_SQLServer" Then
                        If TypeOf metho2.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho2.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        Me.Boutons_ComboBox.Text = Nothing
                    End If

                End If

            Next
        End If
    End Sub

End Class