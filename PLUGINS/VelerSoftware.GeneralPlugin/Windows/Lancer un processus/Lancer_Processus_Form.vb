Public Class Lancer_Processus_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Fichier_ActionTextBox.Tools = .Tools
            .Argument_ActionTextBox1.Tools = .Tools

            .ComboBox1.SelectedIndex = 0

            .Fichier_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Fichier à exécuter"
            
            .Variable_ComboBox.Items.Clear()
            .Variable_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                .Fichier_ActionTextBox.Text = .Param1
            End If

            If Not .Param2 = Nothing Then
                .ComboBox1.SelectedIndex = CInt(.Param2)
            End If

            .Argument_ActionTextBox1.Text = .Param3

            If Not .Param4 = Nothing Then
                .CheckBox1.Checked = CBool(.Param4)
            End If

            .Variable_ComboBox.Enabled = .CheckBox1.Checked

            If Not .Param5 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param5) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param5))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Fichier_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Fichier_ActionTextBox.Text
            .Param2 = .ComboBox1.SelectedIndex
            .Param3 = .Argument_ActionTextBox1.Text
            .Param4 = .CheckBox1.Checked
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
        If Me.Fichier_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim txt1 As String = Nothing

        If Me.ComboBox1.SelectedIndex = 0 Then
            txt1 = "System.Diagnostics.ProcessWindowStyle.Normal"
        ElseIf Me.ComboBox1.SelectedIndex = 1 Then
            txt1 = "System.Diagnostics.ProcessWindowStyle.Maximized"
        ElseIf Me.ComboBox1.SelectedIndex = 2 Then
            txt1 = "System.Diagnostics.ProcessWindowStyle.Minimized"
        ElseIf Me.ComboBox1.SelectedIndex = 3 Then
            txt1 = "System.Diagnostics.ProcessWindowStyle.Hidden"
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.Variable_ComboBox.Text = "" Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "RunProcess", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Fichier_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(txt1), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Argument_ActionTextBox1.Text, True)), New CodeDom.CodePrimitiveExpression(Me.CheckBox1.Checked))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text)
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "RunProcess", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Fichier_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(txt1), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Argument_ActionTextBox1.Text, True)), New CodeDom.CodePrimitiveExpression(Me.CheckBox1.Checked))
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
                    If metho.Method.MethodName = "RunProcess" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Fichier_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(1), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Normal"
                                    Me.ComboBox1.SelectedIndex = 0
                                Case "Maximized"
                                    Me.ComboBox1.SelectedIndex = 1
                                Case "Minimized"
                                    Me.ComboBox1.SelectedIndex = 2
                                Case "Hidden"
                                    Me.ComboBox1.SelectedIndex = 3
                            End Select
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Argument_ActionTextBox1.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            If CStr(DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value).ToLower = "true" Then
                                Me.CheckBox1.Checked = True
                            Else
                                Me.CheckBox1.Checked = False
                            End If
                        End If
                        Me.Variable_ComboBox.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "RunProcess" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Fichier_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(1), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Normal"
                                    Me.ComboBox1.SelectedIndex = 0
                                Case "Maximized"
                                    Me.ComboBox1.SelectedIndex = 1
                                Case "Minimized"
                                    Me.ComboBox1.SelectedIndex = 2
                                Case "Hidden"
                                    Me.ComboBox1.SelectedIndex = 3
                            End Select
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Argument_ActionTextBox1.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            If CStr(DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value).ToLower = "true" Then
                                Me.CheckBox1.Checked = True
                            Else
                                Me.CheckBox1.Checked = False
                            End If
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Me.Variable_ComboBox.Enabled = Me.CheckBox1.Checked
    End Sub

End Class