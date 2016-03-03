Public Class Ajouter_Image_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ValueEdit1.Tools = .Tools
            .ActionTextBox1.Tools = .Tools
            .ActionTextBox2.Tools = .Tools
            .ActionTextBox3.Tools = .Tools

            .ActionTextBox1.Text = "1"
            .ActionTextBox2.Text = "0"
            .ActionTextBox3.Text = "0"

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

            If Not .Param2 = Nothing Then .ActionTextBox1.Text = .Param2
            If Not .Param3 = Nothing Then .ActionTextBox2.Text = .Param3
            If Not .Param4 = Nothing Then .ActionTextBox3.Text = .Param4

            If Not .Param7 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param7)
            End If
            If Not .Param5 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param5, CInt(.Param6))
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
            If Me.ActionTextBox1.Text = "" Then
                .Param2 = "1"
            Else
                .Param2 = Me.ActionTextBox1.Text
            End If
            If Me.ActionTextBox2.Text = "" Then
                .Param3 = "0"
            Else
                .Param3 = Me.ActionTextBox2.Text
            End If
            If Me.ActionTextBox3.Text = "" Then
                .Param4 = "0"
            Else
                .Param4 = Me.ActionTextBox3.Text
            End If

            .Param5 = .ValueEdit1.GetStrictValue()
            .Param6 = CInt(.ValueEdit1.Editor)
            .Param7 = .ValueEdit1.GetGeneratedCode()

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

        If Me.ActionTextBox1.Text = "" Then Me.ActionTextBox1.Text = "0"
        If Me.ActionTextBox2.Text = "" Then Me.ActionTextBox2.Text = "0"
        If Me.ActionTextBox3.Text = "" Then Me.ActionTextBox3.Text = "0"

        Dim sourceWriter As New IO.StringWriter()

        Dim code As String = Me.ValueEdit1.GetGeneratedCode

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".AddImage(" & code & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox3.Text, False, False) & ", DirectCast(" & code & ", System.Drawing.Bitmap).Width,  DirectCast(" & code & ", System.Drawing.Bitmap).Height, " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

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
                    If metho.Method.MethodName = "AddImage" Then
                        If metho.Parameters.Count >= 1 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 2 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox3.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 3 AndAlso TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox1.Text = DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class