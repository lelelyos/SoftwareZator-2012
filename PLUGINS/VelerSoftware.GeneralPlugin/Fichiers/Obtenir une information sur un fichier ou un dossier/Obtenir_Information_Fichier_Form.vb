Public Class Obtenir_Information_Fichier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Fichier.txt"

            .ComboBox2.SelectedIndex = 0

            .Variable_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                Select Case Param2
                    Case "GetCreationTime"
                        If .Param3 = "ToShortTimeString" Then
                            .ComboBox2.SelectedIndex = 0
                        Else
                            .ComboBox2.SelectedIndex = 3
                        End If
                    Case "GetLastAccessTime"
                        If .Param3 = "ToShortTimeString" Then
                            .ComboBox2.SelectedIndex = 1
                        Else
                            .ComboBox2.SelectedIndex = 4
                        End If
                    Case "GetLastWriteTime"
                        If .Param3 = "ToShortTimeString" Then
                            .ComboBox2.SelectedIndex = 2
                        Else
                            .ComboBox2.SelectedIndex = 5
                        End If
                    Case "GetAttributes"
                        .ComboBox2.SelectedIndex = 6
                End Select
            End If

            If Not .Param4 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param4) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param4))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .Variable_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param4 = .Variable_ComboBox.Text

            Select Case .ComboBox2.SelectedIndex
                Case 0
                    .Param2 = "GetCreationTime"
                    .Param3 = "ToShortTimeString"
                Case 1
                    .Param2 = "GetLastAccessTime"
                    .Param3 = "ToShortTimeString"
                Case 2
                    .Param2 = "GetLastWriteTime"
                    .Param3 = "ToShortTimeString"
                Case 3
                    .Param2 = "GetCreationTime"
                    .Param3 = "ToShortDateString"
                Case 4
                    .Param2 = "GetLastAccessTime"
                    .Param3 = "ToShortDateString"
                Case 5
                    .Param2 = "GetLastWriteTime"
                    .Param3 = "ToShortDateString"
                Case 6
                    .Param2 = "GetAttributes"
                    .Param3 = "ToString"
            End Select

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.Variable_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim nom_method, nom_propriété As String
        nom_method = Nothing
        nom_propriété = Nothing

        Select Case Me.ComboBox2.SelectedIndex
            Case 0
                nom_method = "GetCreationTime"
                nom_propriété = "ToShortTimeString"
            Case 1
                nom_method = "GetLastAccessTime"
                nom_propriété = "ToShortTimeString"
            Case 2
                nom_method = "GetLastWriteTime"
                nom_propriété = "ToShortTimeString"
            Case 3
                nom_method = "GetCreationTime"
                nom_propriété = "ToShortDateString"
            Case 4
                nom_method = "GetLastAccessTime"
                nom_propriété = "ToShortDateString"
            Case 5
                nom_method = "GetLastWriteTime"
                nom_propriété = "ToShortDateString"
            Case 6
                nom_method = "GetLastWriteTime"
                nom_propriété = "ToString"
        End Select

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("System.IO.File"), nom_method, New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True))), nom_propriété)
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim OperationStatement As CodeDom.CodePropertyReferenceExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePropertyReferenceExpression Then
                    Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    OperationStatement = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodePropertyReferenceExpression)
                    Select Case OperationStatement.PropertyName
                        Case "ToShortTimeString"
                            If TypeOf OperationStatement.TargetObject Is CodeDom.CodeMethodInvokeExpression Then
                                Select Case DirectCast(OperationStatement.TargetObject, CodeDom.CodeMethodInvokeExpression).Method.MethodName
                                    Case "GetCreationTime"
                                        Me.ComboBox2.SelectedIndex = 0
                                    Case "GetLastAccessTime"
                                        Me.ComboBox2.SelectedIndex = 1
                                    Case "GetLastWriteTime"
                                        Me.ComboBox2.SelectedIndex = 2
                                End Select
                            End If
                        Case "ToShortDateString"
                            If TypeOf OperationStatement.TargetObject Is CodeDom.CodeMethodInvokeExpression Then
                                Select Case DirectCast(OperationStatement.TargetObject, CodeDom.CodeMethodInvokeExpression).Method.MethodName
                                    Case "GetCreationTime"
                                        Me.ComboBox2.SelectedIndex = 3
                                    Case "GetLastAccessTime"
                                        Me.ComboBox2.SelectedIndex = 4
                                    Case "GetLastWriteTime"
                                        Me.ComboBox2.SelectedIndex = 5
                                End Select
                            End If
                        Case "ToString"
                            Me.ComboBox2.SelectedIndex = 6
                    End Select
                End If

            Next
        End If
    End Sub

End Class