Public Class Encrypter_Fichier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools
            .ActionTextBox2.Tools = .Tools

            .ActionTextBox2.Text = ""
            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Fichier à encrypter"
            .ActionTextBox1.Text = "%(APPLICATION=APPLICATION_PATH)%\Fichier une fois encrypté"

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then .ActionTextBox1.Text = .Param2

            If Not .Param3 = Nothing Then .ActionTextBox2.Text = .Param3

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse .ActionTextBox1.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text

            .Param2 = .ActionTextBox1.Text

            .Param3 = .ActionTextBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.ActionTextBox1.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "EncryptOrDecryptFile", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression("DirectCast(VelerSoftware_GeneralPlugin.CreateKey(" & Tools.TransformKeyVariables(Me.ActionTextBox2.Text, True) & "), Byte())"), New CodeDom.CodeSnippetExpression("DirectCast(VelerSoftware_GeneralPlugin.CreateIV(" & Tools.TransformKeyVariables(Me.ActionTextBox2.Text, True) & "), Byte())"), New CodeDom.CodeSnippetExpression("VelerSoftware_GeneralPlugin.CryptoAction.ActionEncrypt"))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class