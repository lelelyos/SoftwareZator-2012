Public Class Afficher_Menu_Contextuel_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "0"
            .ActionTextBox1.Text = "0"

            .Boutons_ComboBox.Items.Clear()
            .ComboBox1.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.ContextMenuStrip" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonContextMenu") Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) Then
                    .ComboBox1.Items.Add(aaa.FullName & " (type : " & DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
                ElseIf aaa.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                    .ComboBox1.Items.Add(aaa.FullName & " (type : " & DirectCast(aaa.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param3 = Nothing Then
                .Texte_Message_ActionTextBox.Text = .Param3
            End If

            If Not .Param4 = Nothing Then
                .ActionTextBox1.Text = .Param4
            End If


        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .ComboBox1.Text
            If Me.Texte_Message_ActionTextBox.Text = "" Then
                .Param3 = "0"
            Else
                .Param3 = Me.Texte_Message_ActionTextBox.Text
            End If
            If Me.ActionTextBox1.Text = "" Then
                .Param4 = "0"
            Else
                .Param4 = Me.ActionTextBox1.Text
            End If

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeMethodInvokeExpression
        If Not Me.ComboBox1.Text = "" Then
            If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
                If Me.ComboBox1.Text.StartsWith("Me.") Then
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Substring(3)), "Show"), New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.ComboBox1.Text.Substring(3).Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                ElseIf Me.ComboBox1.Text.StartsWith("Me ") Then
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Me"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                Else
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.ComboBox1.Text.Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                End If
            Else
                If Me.ComboBox1.Text.StartsWith("Me.") Then
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Boutons_ComboBox.Text), "Show"), New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.ComboBox1.Text.Substring(3).Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                ElseIf Me.ComboBox1.Text.StartsWith("Me ") Then
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Boutons_ComboBox.Text), "Show"), New CodeDom.CodeSnippetExpression("Me"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                Else
                    OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Boutons_ComboBox.Text), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.ComboBox1.Text.Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
                End If
            End If
        Else
            If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
                OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
            Else
                OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Boutons_ComboBox.Text), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")"))
            End If
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class