Public Class Lire_Fichier_Texte_Ligne_Par_Ligne_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me

            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Fichier à lire.txt"

            .Variable_Depart_ComboBox.Items.Clear()
            .ComboBox1.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_Depart_ComboBox.Items.Add(a.Name)
                    .ComboBox1.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                If Not .Variable_Depart_ComboBox.FindString(.Param2) = -1 Then
                    .Variable_Depart_ComboBox.Text = .Variable_Depart_ComboBox.Items(.Variable_Depart_ComboBox.FindString(.Param2))
                End If
            End If

            If Not .Param3 = Nothing Then
                If Not .ComboBox1.FindString(.Param3) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param3))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Variable_Depart_ComboBox.Text = "" OrElse .Variable_Depart_ComboBox.Text = "" OrElse .ComboBox1.Text = Nothing OrElse (.Variable_Depart_ComboBox.Text = .ComboBox1.Text) Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .Variable_Depart_ComboBox.Text
            .Param3 = .ComboBox1.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Variable_Depart_ComboBox.Text = "" OrElse Me.Variable_Depart_ComboBox.Text = "" OrElse Me.ComboBox1.Text = Nothing OrElse (Me.Variable_Depart_ComboBox.Text = Me.ComboBox1.Text) Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim var_depart As New CodeDom.CodeVariableReferenceExpression(Me.Variable_Depart_ComboBox.Text)
        Dim var_arrivee As New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text)
        Dim codeloop As New CodeDom.CodeIterationStatement()

        codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeSnippetExpression("New System.IO.StreamReader(CStr(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & "), True)"))
        codeloop.TestExpression = New CodeDom.CodePrimitiveExpression(True)
        codeloop.IncrementStatement = New CodeDom.CodeSnippetStatement("If " & Me.Variable_Depart_ComboBox.Text & ".EndOfStream Then " & Me.Variable_Depart_ComboBox.Text & ".Close() : Exit Do")
        codeloop.Statements.Add(New CodeDom.CodeSnippetExpression(Me.ComboBox1.Text & " = " & Me.Variable_Depart_ComboBox.Text & ".ReadLine()"))

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(codeloop, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim codeloop As CodeDom.CodeIterationStatement
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                    Me.Variable_Depart_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                End If
                If TypeOf sta Is CodeDom.CodeIterationStatement Then
                    codeloop = DirectCast(sta, CodeDom.CodeIterationStatement)
                    If codeloop.Statements.Count >= 1 AndAlso TypeOf codeloop.Statements(0) Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(codeloop.Statements(0), CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.ComboBox1.Text = DirectCast(DirectCast(codeloop.Statements(0), CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If

                End If

            Next
        End If
    End Sub

End Class