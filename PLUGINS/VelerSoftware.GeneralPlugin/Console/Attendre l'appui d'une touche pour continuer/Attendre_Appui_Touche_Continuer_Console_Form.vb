Public Class Attendre_Appui_Touche_Continuer_Console_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            Me.Texte_Message_ActionTextBox.Tools = Me.Tools

            .Texte_Message_ActionTextBox.Text = ""
            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me

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
        Dim sourceWriter As New IO.StringWriter()

        If Me.Texte_Message_ActionTextBox.Text = "" Then
            Dim WaitKey As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("System.Console"), "ReadKey", New CodeDom.CodeSnippetExpression("False"))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(WaitKey, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("System.Console.WriteLine(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & ") : System.Console.ReadKey(False)"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class