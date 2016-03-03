Public Class Executer_Fonction_Controle_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.MethodInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .ComboBox1.Enabled = False
            .Boutons_ComboBox.Enabled = False

            .Var1_ComboBox.Items.Clear()
            .ComboBox1.Items.Clear()
            .ComboBox1.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox1.Items.Add(a.Name)
                End If
            Next
            For Each a As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If a.ObjectType = GetType(CodeDom.CodeMemberField) Then
                    .Var1_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
                ElseIf a.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                    .Var1_ComboBox.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Var1_ComboBox.FindString(.Param1) = -1 Then
                    .Var1_ComboBox.Text = .Var1_ComboBox.Items(.Var1_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param3 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param3) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param3))
                End If
            End If

            If Not .Param4 = Nothing Then
                Dim ind As Integer = 0
                For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                    prop.Value = CStr(.Param4.Split(",")(ind).Trim(" "))
                    ind += 1
                Next
            End If

            If Not .Param5 = Nothing Then
                If Not .ComboBox1.FindString(.Param5) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param5))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .Var1_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Var1_ComboBox.Text
            .Param3 = .Boutons_ComboBox.Text
            .Param4 = Nothing
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                .Param4 &= prop.Value & ","
            Next
            If Not .Param4 = Nothing Then .Param4 = .Param4.Trim(",")
            If .ComboBox1.Enabled Then
                .Param5 = .ComboBox1.Text
            Else
                .Param5 = Nothing
            End If

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Boutons_ComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Boutons_ComboBox.SelectedIndexChanged
        Me.ComboBox1.Enabled = False
        If Me.Boutons_ComboBox.Text.Contains("(type :") Then
            Me.ComboBox1.Enabled = True
        End If

        Me.PropertyGrids1.SelectedObjects = Nothing
        Me.PropertyGrids1.Item.Clear()
        Me.PropertyGrids1.ItemSet.Clear()
        Me.PropertyGrids1.ShowCustomProperties = True
        Me.PropertyGrids1.Refresh()

        Dim metho As System.Reflection.MethodInfo = Nothing
        For Each a As System.Reflection.MethodInfo In PropList
            If Me.Boutons_ComboBox.Text.StartsWith(a.Name & " ") AndAlso Me.Boutons_ComboBox.Text.Split(")")(0).Split(" ")(Me.Boutons_ComboBox.Text.Split(")")(0).Split(" ").Count - 1) = a.GetParameters.Count Then
                metho = a
                Exit For
            End If
        Next
        If Not metho = Nothing Then
            For Each a As System.Reflection.ParameterInfo In metho.GetParameters()
                Me.PropertyGrids1.Item.Add(a.Name, "Nothing", False, "", "", True)
            Next
        End If
        Me.PropertyGrids1.Refresh()
    End Sub

    Private Sub Var1_Combobox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Var1_ComboBox.SelectedIndexChanged
        Me.Boutons_ComboBox.Enabled = True

        Me.Boutons_ComboBox.Items.Clear()
        PropList = Tools.GetMethodList(Me.Var1_ComboBox.Text.Split(" ")(3).TrimEnd(")"))
        For Each a As System.Reflection.MethodInfo In PropList
            If a.ReturnType.FullName = "System.Void" Then
                Me.Boutons_ComboBox.Items.Add(a.Name & " (parameters count : " & a.GetParameters.Length & ")")
            Else
                Me.Boutons_ComboBox.Items.Add(a.Name & " (type : " & a.ReturnType.FullName & "; parameters count : " & a.GetParameters.Length & ")")
            End If
        Next
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.Var1_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.ComboBox1.Enabled AndAlso (Not Me.ComboBox1.Text = Nothing) Then
            Dim param As String = ""
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                param &= prop.Value & ","
            Next
            If Not param = Nothing Then param = param.Trim(",")

            Dim MsgBoxStatement As CodeDom.CodeMethodInvokeExpression
            If Me.Var1_ComboBox.Text.StartsWith("Me ") Then
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            ElseIf Me.Var1_ComboBox.Text.StartsWith("Me.") Then
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Var1_ComboBox.Text.Split(" ")(0).Split(".")(1)), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            Else
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeVariableReferenceExpression("Variables." & Me.Var1_ComboBox.Text.Split(" ")(0)), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            End If
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim param As String = ""
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                param &= prop.Value & ","
            Next
            If Not param = Nothing Then param = param.Trim(",")

            Dim MsgBoxStatement As CodeDom.CodeMethodInvokeExpression
            If Me.Var1_ComboBox.Text.StartsWith("Me ") Then
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            ElseIf Me.Var1_ComboBox.Text.StartsWith("Me.") Then
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Var1_ComboBox.Text.Split(" ")(0).Split(".")(1)), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            Else
                MsgBoxStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeVariableReferenceExpression("Variables." & Me.Var1_ComboBox.Text.Split(" ")(0)), Me.Boutons_ComboBox.Text.Split(" ")(0), New CodeDom.CodeSnippetExpression(param))
            End If
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class