
Public Class Se_connecter_serveur_MySQL_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Hote_ActionTextBox1.Tools = .Tools
            .Port_ActionTextBox2.Tools = .Tools
            .Utilisateur_ActionTextBox3.Tools = .Tools
            .Mot_de_passe_ActionTextBox4.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .Distance_RadioButton2.Checked = True

            .Port_ActionTextBox2.Text = "21"
            .Hote_ActionTextBox1.Text = ""
            .Utilisateur_ActionTextBox3.Text = ""
            .Mot_de_passe_ActionTextBox4.Text = ""
            .ActionTextBox1.Text = ""

            .variable_ComboBox.Items.Clear()
            .variable_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If CBool(.Param1) Then
                    .Locale_RadioButton1.Checked = True
                    .Hote_ActionTextBox1.Text = "localhost"
                    .CheckBox1.Enabled = False
                Else
                    .Distance_RadioButton2.Checked = True
                    .Hote_ActionTextBox1.Text = "xxx.xxx.xxx.xxx"
                    .CheckBox1.Enabled = True
                End If
            Else
                .Distance_RadioButton2.Checked = True
                .Hote_ActionTextBox1.Text = "xxx.xxx.xxx.xxx"
                .CheckBox1.Enabled = True
            End If

            If Not .Param2 = Nothing Then
                .Hote_ActionTextBox1.Text = .Param2
            End If

            If Not .Param3 = Nothing Then
                .Port_ActionTextBox2.Text = .Param3
            End If

            If Not .Param4 = Nothing Then
                .Utilisateur_ActionTextBox3.Text = .Param4
            End If

            If Not .Param5 = Nothing Then
                .Mot_de_passe_ActionTextBox4.Text = .Param5
            End If

            If Not .Param8 = Nothing Then
                .ActionTextBox1.Text = .Param8
            End If

            If Not .Param6 = Nothing Then
                .CheckBox1.Checked = CBool(.Param6)
            End If

            If Not .Param7 = Nothing Then
                If Not .variable_ComboBox.FindString(.Param7) = -1 Then
                    .variable_ComboBox.Text = .variable_ComboBox.Items(.variable_ComboBox.FindString(.Param7))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Hote_ActionTextBox1.Text = "" OrElse .Port_ActionTextBox2.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Locale_RadioButton1.Checked
            .Param2 = .Hote_ActionTextBox1.Text
            .Param3 = .Port_ActionTextBox2.Text
            .Param4 = .Utilisateur_ActionTextBox3.Text
            .Param5 = .Mot_de_passe_ActionTextBox4.Text
            .Param8 = .ActionTextBox1.Text
            .Param6 = .CheckBox1.Checked
            .Param7 = .variable_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Locale_RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Locale_RadioButton1.Click
        If Me.Locale_RadioButton1.Checked Then
            Me.Hote_ActionTextBox1.Text = "localhost"
            Me.CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub Distance_RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Distance_RadioButton2.Click
        If Me.Distance_RadioButton2.Checked Then
            Me.CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Hote_ActionTextBox1.Text = "" OrElse Port_ActionTextBox2.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_MySQLPlugin"), "Connect_MySQL", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Hote_ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Port_ActionTextBox2.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Utilisateur_ActionTextBox3.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Mot_de_passe_ActionTextBox4.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodePrimitiveExpression(Me.CheckBox1.Checked))
        If Me.variable_ComboBox.Text = "" Then
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim OperationStatement As New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.variable_ComboBox.Text), MsgBoxStatement)
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
                    If metho.Method.MethodName = "Connect_MySQL" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Hote_ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Port_ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Utilisateur_ActionTextBox3.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.Mot_de_passe_ActionTextBox4.Text = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(4) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(4), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            If DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value.ToString = "True" Then
                                CheckBox1.Checked = True
                            Else
                                CheckBox1.Checked = False
                            End If
                        End If
                        Me.variable_ComboBox.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Connect_MySQL" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Hote_ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Port_ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Utilisateur_ActionTextBox3.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.Mot_de_passe_ActionTextBox4.Text = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(4) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(4), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            If DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value.ToString = "True" Then
                                CheckBox1.Checked = True
                            Else
                                CheckBox1.Checked = False
                            End If
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class