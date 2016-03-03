Public Class Aller_Etiquette_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Texte_Message_ActionTextBox.Text = ""
            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If Me.Texte_Message_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim CommentStatement As New CodeDom.CodeGotoStatement(Me.Texte_Message_ActionTextBox.Text)
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(CommentStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private not_refresh As Boolean
    Private Sub Texte_Message_ActionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Texte_Message_ActionTextBox.TextChanged
        If Not not_refresh Then
            not_refresh = True
            With Me.Texte_Message_ActionTextBox
                If Not .Text = "" Then
                    .Text = .Text.Replace(" ", "_")
                    If .Text.Contains(".") _
                      OrElse .Text.Contains("?") _
                      OrElse .Text.Contains(",") _
                      OrElse .Text.Contains(";") _
                      OrElse .Text.Contains(":") _
                      OrElse .Text.Contains("/") _
                      OrElse .Text.Contains("!") _
                      OrElse .Text.Contains("§") _
                      OrElse .Text.Contains("-") _
                      OrElse .Text.Contains("&") _
                      OrElse .Text.Contains("²") _
                      OrElse .Text.Contains("^") _
                      OrElse .Text.Contains("*") _
                      OrElse .Text.Contains("%") _
                      Then
                        MsgBox(RM.GetString("Caractere_Non_valide"), MsgBoxStyle.Exclamation)
                    End If
                End If

            End With
        Else
            not_refresh = False
        End If
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements
                If TypeOf sta Is CodeDom.CodeGotoStatement Then
                    Me.Texte_Message_ActionTextBox.Text = DirectCast(sta, CodeDom.CodeGotoStatement).Label

                End If

            Next
        End If
    End Sub

End Class