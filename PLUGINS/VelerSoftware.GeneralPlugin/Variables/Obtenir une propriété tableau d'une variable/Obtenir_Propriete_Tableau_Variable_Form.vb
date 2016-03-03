Public Class Obtenir_Propriete_Tableau_Variable_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ComboBox1.Enabled = False
            .ActionTextBox1.IsReadOnly = False

            .Var1_ComboBox.Items.Clear()
            .Var2_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Var1_ComboBox.Items.Add(a.Name)
                Else
                    .Var2_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Var1_ComboBox.FindString(.Param1) = -1 Then
                    .Var1_ComboBox.Text = .Var1_ComboBox.Items(.Var1_ComboBox.FindString(.Param1))
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

            If Not .Param4 = Nothing Then
                If Not .Var2_ComboBox.FindString(.Param4) = -1 Then
                    .Var2_ComboBox.Text = .Var2_ComboBox.Items(.Var2_ComboBox.FindString(.Param4))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Var1_ComboBox.Text = Nothing OrElse .Var2_ComboBox.Text = Nothing OrElse .ComboBox1.Text = Nothing Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Var1_ComboBox.Text
            .Param2 = .ActionTextBox1.Text
            .Param3 = .ComboBox1.Text
            .Param4 = .Var2_ComboBox.Text

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

        Dim VariableStatement2 As New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text)
        Dim OperationStatement As CodeDom.CodeAssignStatement

        If Me.ComboBox1.Text.EndsWith("[])") Then
            OperationStatement = New CodeDom.CodeAssignStatement(VariableStatement2, New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(DirectCast(" & Me.Var1_ComboBox.Text & ", " & Me.ActionTextBox1.Text & ")" & "." & Me.ComboBox1.Text.Split("(")(0).Trim(" ") & ")))"))
        Else
            OperationStatement = New CodeDom.CodeAssignStatement(VariableStatement2, New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(DirectCast(" & Me.Var1_ComboBox.Text & ", " & Me.ActionTextBox1.Text & ")" & "." & Me.ComboBox1.Text.Split("(")(0).Trim(" ") & "))"))
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
       If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                    Me.Var2_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                End If

            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tip As Type = Me.Tools.SelectType
        If Not tip Is Nothing Then
            Me.ActionTextBox1.Text = tip.FullName
        End If
    End Sub

    Private Sub ActionTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionTextBox1.TextChanged
        If Not Me.ActionTextBox1.Text = Nothing Then Me.ComboBox1.Enabled = True

        Me.ComboBox1.Items.Clear()
        PropList = Tools.GetPropertyList(Me.ActionTextBox1.Text)
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanRead AndAlso (a.PropertyType.FullName.EndsWith("[]") OrElse a.PropertyType.FullName.Contains("+") OrElse a.PropertyType.FullName.Contains("Collection")) Then
                Me.ComboBox1.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next
    End Sub

End Class