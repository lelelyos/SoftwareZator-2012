Public Class Couleur_Fond_Console_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            If Not .Param1 = Nothing AndAlso IsNumeric(.Param1) Then
                .ComboBox1.SelectedIndex = CInt(.Param1)
            Else
                .ComboBox1.SelectedIndex = 0
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me

            .Param1 = .ComboBox1.SelectedIndex

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

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Console"), "BackgroundColor"), New CodeDom.CodeSnippetExpression(Me.ComboBox1.SelectedIndex)), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        
        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodePropertyReferenceExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodePropertyReferenceExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodePropertyReferenceExpression)
                    If metho.PropertyName = "BackgroundColor" AndAlso TypeOf metho.TargetObject Is CodeDom.CodeTypeReferenceExpression AndAlso DirectCast(metho.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType = "System.Console" Then
                        If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePrimitiveExpression AndAlso Microsoft.VisualBasic.IsNumeric(DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodePrimitiveExpression).Value) Then
                            Me.ComboBox1.SelectedIndex = CInt(DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodePrimitiveExpression).Value)
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class