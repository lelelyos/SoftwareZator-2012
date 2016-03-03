Public Class Obtenir_Taille_Fichier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = True

            .CheckBox1_CheckedChanged(Nothing, Nothing)

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Fichier.txt"

            .ComboBox1.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox1.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param3 = Nothing Then .Ajouter_Unité_CheckBox.Checked = CBool(.Param3)

            If Not .Param5 = Nothing Then
                Select Case .Param5
                    Case "Auto"
                        .Automatique_RadioButton.Checked = True
                    Case "Octet"
                        .Octect_RadioButton.Checked = True
                    Case "Ko"
                        .Ko_RadioButton.Checked = True
                    Case "Mo"
                        .Mo_RadioButton.Checked = True
                    Case "Go"
                        .Go_RadioButton.Checked = True
                End Select
            End If

            If Not .Param4 = Nothing Then .Format_Specifié_CheckBox.Checked = CBool(.Param4)

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .ComboBox1.Text
            .Param3 = .Ajouter_Unité_CheckBox.Checked
            .Param4 = .Format_Specifié_CheckBox.Checked
            If .Automatique_RadioButton.Checked Then
                .Param5 = "Auto"
            ElseIf .Octect_RadioButton.Checked Then
                .Param5 = "Octet"
            ElseIf .Ko_RadioButton.Checked Then
                .Param5 = "Ko"
            ElseIf .Mo_RadioButton.Checked Then
                .Param5 = "Mo"
            ElseIf .Go_RadioButton.Checked Then
                .Param5 = "Go"
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
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim forma As String = Nothing
        If Automatique_RadioButton.Checked Then
            forma = "Auto"
        ElseIf Octect_RadioButton.Checked Then
            forma = "Octet"
        ElseIf Ko_RadioButton.Checked Then
            forma = "Ko"
        ElseIf Mo_RadioButton.Checked Then
            forma = "Mo"
        ElseIf Go_RadioButton.Checked Then
            forma = "Go"
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "GetFileLen", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodePrimitiveExpression(Me.Ajouter_Unité_CheckBox.Checked), New CodeDom.CodePrimitiveExpression(Me.Format_Specifié_CheckBox.Checked), New CodeDom.CodePrimitiveExpression(forma))), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "GetFileLen" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeVariableReferenceExpression AndAlso DirectCast(metho.Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName = "VelerSoftware_GeneralPlugin" Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Ajouter_Unité_CheckBox.Checked = CBool(DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value)
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Format_Specifié_CheckBox.Checked = CBool(DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value)
                        End If
                        If TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Select Case CStr(DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value)
                                Case "Auto"
                                    Me.Automatique_RadioButton.Checked = True
                                Case "Octet"
                                    Me.Octect_RadioButton.Checked = True
                                Case "Ko"
                                    Me.Ko_RadioButton.Checked = True
                                Case "Mo"
                                    Me.Mo_RadioButton.Checked = True
                                Case "Go"
                                    Me.Go_RadioButton.Checked = True
                            End Select
                        End If
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                            Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Format_Specifié_CheckBox.CheckedChanged
        If Me.Format_Specifié_CheckBox.Checked Then
            Me.Automatique_RadioButton.Enabled = True
            Me.Ko_RadioButton.Enabled = True
            Me.Mo_RadioButton.Enabled = True
            Me.Go_RadioButton.Enabled = True
        Else
            Me.Automatique_RadioButton.Enabled = False
            Me.Ko_RadioButton.Enabled = False
            Me.Mo_RadioButton.Enabled = False
            Me.Go_RadioButton.Enabled = False
            Me.Octect_RadioButton.Checked = True
        End If
    End Sub

End Class