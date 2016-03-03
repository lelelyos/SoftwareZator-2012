Public Class Modifier_Sous_Element_ListView_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox2.Tools = .Tools

            .ActionTextBox2.Text = "0"

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then
                    .Boutons_ComboBox.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .Texte_Message_ActionTextBox.Text = .Param2
            End If

            If Not .Param3 = Nothing Then
                .ActionTextBox2.Text = .Param3
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
            .Param2 = .Texte_Message_ActionTextBox.Text
            If Me.ActionTextBox2.Text = "" Then
                .Param3 = "0"
            Else
                .Param3 = Me.ActionTextBox2.Text
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

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        OperationStatement = New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".SubItems(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False, False) & ").Text = " & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodePropertyReferenceExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodePropertyReferenceExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodePropertyReferenceExpression)
                    If metho.PropertyName = "Text" AndAlso TypeOf metho.TargetObject Is CodeDom.CodeMethodInvokeExpression AndAlso DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Method.MethodName = "SubItems" Then
                        If TypeOf DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Method.TargetObject Is CodeDom.CodeVariableReferenceExpression Then
                            Me.Boutons_ComboBox.Text = DirectCast(DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName
                        End If
                        If DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Parameters.Count = 1 AndAlso TypeOf DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Parameters(0) Is CodeDom.CodePrimitiveExpression AndAlso Microsoft.VisualBasic.IsNumeric(DirectCast(DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Parameters(0), CodeDom.CodePrimitiveExpression).Value) Then
                            Me.ActionTextBox2.Text = DirectCast(DirectCast(metho.TargetObject, CodeDom.CodeMethodInvokeExpression).Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class