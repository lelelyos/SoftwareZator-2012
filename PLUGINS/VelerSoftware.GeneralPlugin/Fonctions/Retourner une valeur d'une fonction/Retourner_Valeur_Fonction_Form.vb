Public Class Retourner_Valeur_Fonction_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .ValueEdit1.Tools = .Tools

            If Not .Param1 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param1)
            End If

            If Not .Param2 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param2, CInt(.Param3))
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            .Param2 = .ValueEdit1.GetStrictValue()
            .Param3 = CInt(.ValueEdit1.Editor)
            .Param1 = .ValueEdit1.GetGeneratedCode()

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

        Dim VariableStatement As New CodeDom.CodeMethodReturnStatement(New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode()))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(VariableStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class