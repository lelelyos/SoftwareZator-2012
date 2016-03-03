Public Class Modifier_Propriete_Contrôle_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .ComboBox1.Enabled = False
            .ValueEdit1.Tools = .Tools

            .Parametre_ComboBox.Items.Clear()
                                               
            For Each a As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If a.ObjectType = GetType(CodeDom.CodeMemberField) Then
                    .Parametre_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
                ElseIf a.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                    .Parametre_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Parametre_ComboBox.FindString(.Param1) = -1 Then
                    .Parametre_ComboBox.Text = .Parametre_ComboBox.Items(.Parametre_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param4 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param4)
            End If

            If Not .Param3 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param3, CInt(.Param5))
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
            .Param2 = .ComboBox1.Text
            .Param3 = .ValueEdit1.GetStrictValue
            .Param5 = CInt(.ValueEdit1.Editor)
            .Param4 = .ValueEdit1.GetGeneratedCode

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

        Dim OperationStatement As CodeDom.CodeAssignStatement
        If Me.Parametre_ComboBox.Text.StartsWith("Me ") Then
            OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.ComboBox1.Text.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode()))
        ElseIf Me.Parametre_ComboBox.Text.StartsWith("Me.") Then
            OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Parametre_ComboBox.Text.Substring(3).Split(" ")(0) & "." & Me.ComboBox1.Text.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode()))
        Else
            OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeVariableReferenceExpression("Variables." & Me.Parametre_ComboBox.Text.Split("(")(0).Trim(" ")), Me.ComboBox1.Text.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode()))
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub


    Private Sub Var1_ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Parametre_ComboBox.SelectedIndexChanged
        If Not Me.Parametre_ComboBox.Text = "" Then Me.ComboBox1.Enabled = True

        Me.ComboBox1.Items.Clear()
        PropList = Tools.GetPropertyList(Me.Parametre_ComboBox.Text.Split(" ")(3).TrimEnd(")"))
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanWrite Then
                Me.ComboBox1.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next
    End Sub


End Class