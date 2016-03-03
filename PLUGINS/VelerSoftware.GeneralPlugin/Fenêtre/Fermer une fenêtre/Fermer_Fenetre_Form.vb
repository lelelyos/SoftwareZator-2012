Public Class Fermer_Fenetre_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ComboBox1.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindows(False)
                .Boutons_ComboBox.Items.Add(aaa.FullName)
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then   
                .ComboBox1.SelectedIndex = CInt(.Param2)
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
            .Param2 = .ComboBox1.SelectedIndex

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

        If Me.Boutons_ComboBox.Text = "Me" Then
            If Me.ComboBox1.SelectedIndex = 0 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.None : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 1 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.OK : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 2 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Cancel : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 3 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Yes : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 4 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.No : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 5 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Abort : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 6 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Retry : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 7 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Ignore : " & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            End If
        Else
            If Me.ComboBox1.SelectedIndex = 0 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.None : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 1 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.OK : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 2 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Cancel : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 3 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Yes : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 4 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.No : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 5 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Abort : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 6 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Retry : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.ComboBox1.SelectedIndex = 7 Then
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".DialogResult = System.Windows.Forms.DialogResult.Ignore : Variables." & Me.Boutons_ComboBox.Text & ".Close()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            End If
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodePropertyReferenceExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePropertyReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodePropertyReferenceExpression AndAlso DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodePropertyReferenceExpression).PropertyName = "DialogResult" Then
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodePropertyReferenceExpression)
                    If TypeOf metho.TargetObject Is CodeDom.CodePropertyReferenceExpression Then
                        If TypeOf DirectCast(metho.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject Is CodeDom.CodeThisReferenceExpression Then
                            If Not Me.Boutons_ComboBox.FindString("Me." & DirectCast(metho.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me." & DirectCast(metho.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                        Else
                            If Not Me.Boutons_ComboBox.FindString("Variables." & DirectCast(metho.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Variables." & DirectCast(metho.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                        End If
                    ElseIf TypeOf metho.TargetObject Is CodeDom.CodeThisReferenceExpression Then
                        If Not Me.Boutons_ComboBox.FindString("Me") = -1 Then
                            Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me"))
                        End If
                    End If
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodePropertyReferenceExpression)
                    Select Case metho.PropertyName
                        Case "None"
                            Me.ComboBox1.SelectedIndex = 0
                        Case "OK"
                            Me.ComboBox1.SelectedIndex = 1
                        Case "Cancel"
                            Me.ComboBox1.SelectedIndex = 2
                        Case "Yes"
                            Me.ComboBox1.SelectedIndex = 3
                        Case "No"
                            Me.ComboBox1.SelectedIndex = 4
                        Case "Abort"
                            Me.ComboBox1.SelectedIndex = 5
                        Case "Retry"
                            Me.ComboBox1.SelectedIndex = 6
                        Case "Ignore"
                            Me.ComboBox1.SelectedIndex = 7
                    End Select

                End If

            Next
        End If
    End Sub

End Class