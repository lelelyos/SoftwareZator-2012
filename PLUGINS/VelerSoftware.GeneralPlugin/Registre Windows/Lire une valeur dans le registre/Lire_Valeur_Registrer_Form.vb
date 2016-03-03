Public Class Lire_Valeur_Registrer_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Argument_ActionTextBox1.Tools = .Tools
            .ActionTextBox1.Tools = .Tools
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox2.Items.Add(a.Name)
                End If
            Next

            .Argument_ActionTextBox1.Text = ""
            .ActionTextBox1.Text = ""
            .ComboBox1.SelectedIndex = 0

            If Not .Param1 = Nothing Then
                .Argument_ActionTextBox1.Text = .Param1
            End If

            If Not .Param2 = Nothing Then
                .ComboBox1.SelectedIndex = CInt(.Param2)
            End If

            If Not .Param3 = Nothing Then
                .ActionTextBox1.Text = .Param3
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
            If .Argument_ActionTextBox1.Text = "" OrElse .ComboBox2.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Argument_ActionTextBox1.Text
            .Param2 = .ComboBox1.SelectedIndex
            .Param3 = .ActionTextBox1.Text
            .Param4 = .ComboBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Argument_ActionTextBox1.Text = "" OrElse Me.ComboBox2.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim key As String = ""
        If Me.ComboBox1.SelectedIndex = 0 Then
            key = "HKEY_CLASSES_ROOT"
        ElseIf Me.ComboBox1.SelectedIndex = 1 Then
            key = "HKEY_CURRENT_CONFIG"
        ElseIf Me.ComboBox1.SelectedIndex = 2 Then
            key = "HKEY_CURRENT_USER"
        ElseIf Me.ComboBox1.SelectedIndex = 3 Then
            key = "HKEY_LOCAL_MACHINE"
        ElseIf Me.ComboBox1.SelectedIndex = 4 Then
            key = "HKEY_USERS"
        End If
        If Me.Argument_ActionTextBox1.Text.StartsWith("\") Then
            key &= Me.Argument_ActionTextBox1.Text
        Else
            key &= "\" & Me.Argument_ActionTextBox1.Text
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeAssignStatement
        If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
            OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox2.Text), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("_computer.Registry"), "GetValue"), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(key, True)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression("Nothing")))
        Else
            OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox2.Text), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.Registry"), "GetValue"), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(key, True)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression("Nothing")))
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class