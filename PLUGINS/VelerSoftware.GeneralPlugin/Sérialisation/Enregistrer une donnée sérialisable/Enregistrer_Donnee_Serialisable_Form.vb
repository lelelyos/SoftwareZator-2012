Public Class Enregistrer_Donnee_Serialisable_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Friend ProjPath As String

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Nouveau fichier.bin"

            .ComboBox3.Items.Clear()

            .ComboBox2.Items.Clear()
            .ComboBox2.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox2.Items.Add(a.Name)
                    .ComboBox3.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
            If Not .Param2 = Nothing Then
                If CBool(.Param2) Then .CheckBox1.Checked = CBool(.Param2)
            End If
            If Not .Param3 = Nothing Then
                If Not .ComboBox3.FindString(.Param3) = -1 Then
                    .ComboBox3.Text = .ComboBox3.Items(.ComboBox3.FindString(.Param3))
                End If
            End If
            If Not .Param4 = Nothing Then
                If Not .ComboBox2.FindString(.Param4) = -1 Then
                    .ComboBox2.Text = .ComboBox2.Items(.ComboBox2.FindString(.Param4))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .ComboBox3.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .CheckBox1.Checked
            .Param3 = .ComboBox3.Text
            .Param40 = .ComboBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.ComboBox3.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.ComboBox2.Text = "" Then
            Dim Fonction As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Serialize", New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeVariableReferenceExpression(Me.ComboBox3.Text), New CodeDom.CodeSnippetExpression(Me.CheckBox1.Checked))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(Fonction, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim Fonction As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Serialize", New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeVariableReferenceExpression(Me.ComboBox3.Text), New CodeDom.CodeSnippetExpression(Me.CheckBox1.Checked))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox2.Text), Fonction), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
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
                    If metho.Method.MethodName = "Serialize" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeVariableReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName = "VelerSoftware_GeneralPlugin" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodeVariableReferenceExpression Then
                            Me.ComboBox3.Text = DirectCast(metho.Parameters(1), CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression AndAlso DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value.GetType.FullName = "System.Boolean" Then
                            Me.CheckBox1.Checked = CBool(DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value)
                        End If
                        Me.ComboBox2.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Serialize" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeVariableReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName = "VelerSoftware_GeneralPlugin" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodeVariableReferenceExpression Then
                            Me.ComboBox3.Text = DirectCast(metho.Parameters(1), CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression AndAlso DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value.GetType.FullName = "System.Boolean" Then
                            Me.CheckBox1.Checked = CBool(DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value)
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.ComboBox2.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class