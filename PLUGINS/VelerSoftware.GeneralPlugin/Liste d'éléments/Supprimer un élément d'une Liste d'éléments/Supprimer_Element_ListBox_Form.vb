Public Class Supprimer_Element_ListBox_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ActionTextBox1.Tools = .Tools

            Me.ActionTextBox1.Text = "0"

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.ListBox" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonListBox") Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            If Me.ActionTextBox1.Text = "" Then
                .Param2 = "0"
            Else
                .Param2 = Me.ActionTextBox1.Text
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
        If Me.Boutons_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
            OperationStatement = New CodeDom.CodeSnippetExpression("Me." & Me.Boutons_ComboBox.Text.Substring(3) & ".Items.RemoveAt(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")")
        Else
            OperationStatement = New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".Items.RemoveAt(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False, False) & ")")
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "RemoveAt" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodePropertyReferenceExpression Then
                        If TypeOf DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject Is CodeDom.CodePropertyReferenceExpression Then
                            If Not Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                            If Not Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                        End If
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression AndAlso Microsoft.VisualBasic.IsNumeric(DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value) Then
                            Me.ActionTextBox1.Text = CInt(DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value)
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class