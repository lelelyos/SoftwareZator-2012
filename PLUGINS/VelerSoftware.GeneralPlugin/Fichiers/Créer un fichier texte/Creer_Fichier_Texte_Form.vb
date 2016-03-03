Public Class Creer_Fichier_Texte_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")
            .ParseCode_Button_Visible = False

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .ActionTextBox1.Text = ""
            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Nouveau fichier.txt"
            .ComboBox1.SelectedIndex = 5

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1
            If Not .Param2 = Nothing Then .ActionTextBox1.Text = .Param2
            If Not .Param3 = Nothing Then
                If CBool(.Param3) Then
                    .RadioButton2.Checked = True
                Else
                    .RadioButton1.Checked = True
                End If
            End If
            If Not .Param4 = Nothing Then .ComboBox1.Text = .Param4
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text
            .Param2 = .ActionTextBox1.Text
            .Param3 = .RadioButton2.Checked
            .Param4 = .ComboBox1.Text

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

        If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("_computer.FileSystem"), "WriteAllText", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Me.RadioButton2.Checked), New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Text.Encoding"), Me.ComboBox1.Text))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.FileSystem"), "WriteAllText", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True)), New CodeDom.CodeSnippetExpression(Me.RadioButton2.Checked), New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Text.Encoding"), Me.ComboBox1.Text))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class