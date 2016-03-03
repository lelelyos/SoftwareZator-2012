Public Class Obtenir_Liste_Fichier_Dossier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\"
            .ActionTextBox1.Text = "*.*"

            .ComboBox1.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If a.Array Then
                    .ComboBox1.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
            If Not .Param2 = Nothing Then
                If CBool(.Param2) Then
                    .RadioButton2.Checked = True
                Else
                    .RadioButton1.Checked = True
                End If
            End If
            If Not .Param3 = Nothing Then
                If CBool(.Param3) Then
                    .RadioButton3.Checked = True
                Else
                    .RadioButton4.Checked = True
                End If
            End If
            If Not .Param4 = Nothing Then .ActionTextBox1.Text = .Param4
            If Not .Param5 = Nothing Then
                If Not .ComboBox1.FindString(.Param5) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param5))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .RadioButton2.Checked
            .Param3 = .RadioButton3.Checked
            If .ActionTextBox1.Text = "" Then
                .Param4 = "*.*"
            Else
                .Param4 = .ActionTextBox1.Text
            End If
            .Param5 = .ComboBox1.Text

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

        Dim searchOpt As String
        Dim searchTyp As String

        If Me.RadioButton2.Checked Then
            searchOpt = "System.IO.SearchOption.AllDirectories"
        Else
            searchOpt = "System.IO.SearchOption.TopDirectoryOnly"
        End If

        If Me.RadioButton3.Checked Then
            searchTyp = "GetFiles"
        Else
            searchTyp = "GetDirectories"
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.IO.Directory." & searchTyp & "(" & Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & ", " & Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True) & ", " & searchOpt & "))")
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim OperationStatement As CodeDom.CodeObjectCreateExpression
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeObjectCreateExpression Then
                    Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    OperationStatement = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression)
                    If OperationStatement.Parameters.Count = 1 AndAlso TypeOf OperationStatement.Parameters(0) Is CodeDom.CodeMethodInvokeExpression Then
                        metho = DirectCast(OperationStatement.Parameters(0), CodeDom.CodeMethodInvokeExpression)
                        If metho.Method.MethodName = "GetFiles" Then
                            Me.RadioButton3.Checked = True
                        Else
                            Me.RadioButton4.Checked = True
                        End If
                        If metho.Parameters.Count = 3 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePropertyReferenceExpression Then
                            If DirectCast(metho.Parameters(2), CodeDom.CodePropertyReferenceExpression).PropertyName = "AllDirectories" Then
                                Me.RadioButton2.Checked = True
                            Else
                                Me.RadioButton1.Checked = True
                            End If
                        End If
                    End If
                End If

            Next
        End If
    End Sub

End Class