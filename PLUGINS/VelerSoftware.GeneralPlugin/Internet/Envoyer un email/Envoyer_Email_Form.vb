Public Class Envoyer_Email_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Expéditeur_ActionTextBox.Tools = .Tools
            .Destinataire_ActionTextBox1.Tools = .Tools
            .smtp_ActionTextBox2.Tools = .Tools
            .sujet_ActionTextBox3.Tools = .Tools
            .Texte_Message_ActionTextBox.Tools = .Tools
            .fichier_ActionTextBox4.Tools = .Tools
            .utilisateur_ActionTextBox5.Tools = .Tools
            .mdp_ActionTextBox6.Tools = .Tools

            .Expéditeur_ActionTextBox.Text = ""
            .Destinataire_ActionTextBox1.Text = ""
            .smtp_ActionTextBox2.Text = ""
            .sujet_ActionTextBox3.Text = ""
            .Texte_Message_ActionTextBox.Text = ""
            .fichier_ActionTextBox4.Text = ""
            .utilisateur_ActionTextBox5.Text = ""
            .mdp_ActionTextBox6.Text = ""

            .Variable_ComboBox.Items.Clear()
            .Variable_ComboBox.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Expéditeur_ActionTextBox.Text = .Param1
            If Not .Param2 = Nothing Then .Destinataire_ActionTextBox1.Text = .Param2
            If Not .Param3 = Nothing Then .smtp_ActionTextBox2.Text = .Param3
            If Not .Param4 = Nothing Then .sujet_ActionTextBox3.Text = .Param4
            If Not .Param5 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param5
            If Not .Param6 = Nothing Then .fichier_ActionTextBox4.Text = .Param6
            If Not .Param7 = Nothing Then .utilisateur_ActionTextBox5.Text = .Param7
            If Not .Param8 = Nothing Then .mdp_ActionTextBox6.Text = .Param8

            If Not .Param9 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param9) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param9))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .Expéditeur_ActionTextBox.Text = "" OrElse .Destinataire_ActionTextBox1.Text = "" OrElse .smtp_ActionTextBox2.Text = "" OrElse .sujet_ActionTextBox3.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Expéditeur_ActionTextBox.Text
            .Param2 = .Destinataire_ActionTextBox1.Text
            .Param3 = .smtp_ActionTextBox2.Text
            .Param4 = .sujet_ActionTextBox3.Text
            .Param5 = .Texte_Message_ActionTextBox.Text
            .Param6 = .fichier_ActionTextBox4.Text
            .Param7 = .utilisateur_ActionTextBox5.Text
            .Param8 = .mdp_ActionTextBox6.Text
            .Param9 = .Variable_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.Expéditeur_ActionTextBox.Text = "" OrElse Me.Destinataire_ActionTextBox1.Text = "" OrElse Me.smtp_ActionTextBox2.Text = "" OrElse Me.sujet_ActionTextBox3.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.Variable_ComboBox.Text = "" Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Envoyer_Email", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Expéditeur_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Destinataire_ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.smtp_ActionTextBox2.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.sujet_ActionTextBox3.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.fichier_ActionTextBox4.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.utilisateur_ActionTextBox5.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.mdp_ActionTextBox6.Text, True)))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text)
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Envoyer_Email", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Expéditeur_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Destinataire_ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.smtp_ActionTextBox2.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.sujet_ActionTextBox3.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.fichier_ActionTextBox4.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.utilisateur_ActionTextBox5.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.mdp_ActionTextBox6.Text, True)))
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
                    If metho.Method.MethodName = "Envoyer_Email" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType = "VelerSoftware_GeneralPlugin" Then
                        If metho.Parameters.Count > 0 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Expéditeur_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 1 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Destinataire_ActionTextBox1.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 2 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.smtp_ActionTextBox2.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 3 AndAlso TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.sujet_ActionTextBox3.Text = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 4 AndAlso TypeOf metho.Parameters(4) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(4), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 5 AndAlso TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            Me.fichier_ActionTextBox4.Text = DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 6 AndAlso TypeOf metho.Parameters(6) Is CodeDom.CodePrimitiveExpression Then
                            Me.utilisateur_ActionTextBox5.Text = DirectCast(metho.Parameters(6), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 7 AndAlso TypeOf metho.Parameters(7) Is CodeDom.CodePrimitiveExpression Then
                            Me.mdp_ActionTextBox6.Text = DirectCast(metho.Parameters(7), CodeDom.CodePrimitiveExpression).Value
                        End If
                        Me.Variable_ComboBox.Text = Nothing
                    End If



                ElseIf TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Envoyer_Email" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType = "VelerSoftware_GeneralPlugin" Then
                        If metho.Parameters.Count > 0 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Expéditeur_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 1 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Destinataire_ActionTextBox1.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 2 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.smtp_ActionTextBox2.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 3 AndAlso TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.sujet_ActionTextBox3.Text = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 4 AndAlso TypeOf metho.Parameters(4) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(4), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 5 AndAlso TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            Me.fichier_ActionTextBox4.Text = DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 6 AndAlso TypeOf metho.Parameters(6) Is CodeDom.CodePrimitiveExpression Then
                            Me.utilisateur_ActionTextBox5.Text = DirectCast(metho.Parameters(6), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count > 7 AndAlso TypeOf metho.Parameters(7) Is CodeDom.CodePrimitiveExpression Then
                            Me.mdp_ActionTextBox6.Text = DirectCast(metho.Parameters(7), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class