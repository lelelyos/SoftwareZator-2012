Public Class Obtenir_Propriete_Tableau_Contrôle_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ComboBox1.Enabled = False

            .Var1_ComboBox.Items.Clear()
            .Var2_ComboBox.Items.Clear()
            For Each a As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If a.ObjectType = GetType(CodeDom.CodeMemberField) Then
                    .Var1_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
                ElseIf a.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                    .Var1_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
                End If
            Next

            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If a.Array Then
                    .Var2_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Var1_ComboBox.FindString(.Param1) = -1 Then
                    .Var1_ComboBox.Text = .Var1_ComboBox.Items(.Var1_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param3 = Nothing Then
                If Not .Var2_ComboBox.FindString(.Param3) = -1 Then
                    .Var2_ComboBox.Text = .Var2_ComboBox.Items(.Var2_ComboBox.FindString(.Param3))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Var1_ComboBox.Text = "" OrElse .Var2_ComboBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Var1_ComboBox.Text
            .Param2 = .ComboBox1.Text
            .Param3 = .Var2_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick

        If Me.Var1_ComboBox.Text = "" OrElse Me.Var2_ComboBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeAssignStatement
        If Me.Var1_ComboBox.Text.StartsWith("Me ") Then
            If Me.ComboBox1.Text.EndsWith("[])") Then
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Me." & Me.ComboBox1.Text.Split(" ")(0) & ")))"))
            Else
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Me." & Me.ComboBox1.Text.Split(" ")(0) & "))"))
            End If
        ElseIf Me.Var1_ComboBox.Text.StartsWith("Me.") Then
            If Me.ComboBox1.Text.EndsWith("[])") Then
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Me." & Me.Var1_ComboBox.Text.Substring(3).Split(" ")(0) & "." & Me.ComboBox1.Text.Split(" ")(0) & ")))"))
            Else
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Me." & Me.Var1_ComboBox.Text.Substring(3).Split(" ")(0) & "." & Me.ComboBox1.Text.Split(" ")(0) & "))"))
            End If
        Else
            If Me.ComboBox1.Text.EndsWith("[])") Then
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Variables." & Me.Var1_ComboBox.Text.Substring(3).Split(" ")(0) & "." & Me.ComboBox1.Text.Split(" ")(0) & ")))"))
            Else
                OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Variables." & Me.Var1_ComboBox.Text.Substring(3).Split(" ")(0) & "." & Me.ComboBox1.Text.Split(" ")(0) & "))"))
            End If
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePropertyReferenceExpression Then
                    Me.Var2_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                End If

            Next
        End If
    End Sub


    Private Sub Var1_ComboBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Var1_ComboBox.SelectedIndexChanged
        If Not Me.Var1_ComboBox.Text = "" Then Me.ComboBox1.Enabled = True

        Me.ComboBox1.Items.Clear()
        PropList = Tools.GetPropertyList(Me.Var1_ComboBox.Text.Split(" ")(3).TrimEnd(")"))
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanRead AndAlso (a.PropertyType.FullName.EndsWith("[]") OrElse a.PropertyType.FullName.Contains("+") OrElse a.PropertyType.FullName.Contains("Collection")) Then
                Me.ComboBox1.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next
    End Sub

End Class