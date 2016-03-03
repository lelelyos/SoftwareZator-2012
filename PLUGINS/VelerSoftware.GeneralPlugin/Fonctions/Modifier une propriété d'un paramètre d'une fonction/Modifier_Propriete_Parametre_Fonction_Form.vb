Public Class Modifier_Propriete_Parametre_Fonction_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .ComboBox1.Enabled = False
            .ActionTextBox1.IsReadOnly = False
            .ActionTextBox1.Text = ""
            .ValueEdit1.Tools = .Tools

            .Parametre_ComboBox.Items.Clear()

            For Each a As String In .Tools.GetCurrentFunctionSettings
                .Parametre_ComboBox.Items.Add(a)
            Next

            If Not .Param1 = Nothing Then
                If Not .Parametre_ComboBox.FindString(.Param1) = -1 Then
                    .Parametre_ComboBox.Text = .Parametre_ComboBox.Items(.Parametre_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .ActionTextBox1.Text = .Param2
            End If

            If Not .Param3 = Nothing Then
                If Not .ComboBox1.FindString(.Param3) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param3))
                End If
            End If

            If Not .Param5 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param5)
            End If

            If Not .Param4 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param4, CInt(.Param6))
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Parametre_ComboBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Parametre_ComboBox.Text
            .Param2 = .ActionTextBox1.Text
            .Param3 = .ComboBox1.Text
            .Param4 = .ValueEdit1.GetStrictValue
            .Param6 = CInt(.ValueEdit1.Editor)
            .Param5 = .ValueEdit1.GetGeneratedCode

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick

        If Me.Parametre_ComboBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As New CodeDom.CodeAssignStatement(New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeCastExpression(New CodeDom.CodeTypeReference(Me.ActionTextBox1.Text), New CodeDom.CodeVariableReferenceExpression(Me.Parametre_ComboBox.Text)), Me.ComboBox1.Text.Split("(")(0).Trim(" ")), New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode()))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tip As Type = Me.Tools.SelectType
        If Not tip Is Nothing Then
            Me.ActionTextBox1.Text = tip.FullName
        End If
    End Sub

    Private Sub ActionTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionTextBox1.TextChanged
        If Not Me.ActionTextBox1.Text = "" Then Me.ComboBox1.Enabled = True

        Me.ComboBox1.Items.Clear()
        PropList = Tools.GetPropertyList(Me.ActionTextBox1.Text)
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanWrite Then
                Me.ComboBox1.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next
    End Sub

    Private Sub Parametre_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Parametre_ComboBox.SelectedIndexChanged, LinkLabel1.Click
        For Each a As String In Tools.GetCurrentFunctionSettings
            If a = Me.Parametre_ComboBox.Text Then
                Me.ActionTextBox1.Text = Tools.GetCurrentFunctionSettingType(a)
            End If
        Next
    End Sub

End Class