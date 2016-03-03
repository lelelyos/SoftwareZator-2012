Public Class Assistant_Changer_Statut_Suivant_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .RadioButton1.Checked = True

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindows(False)
                If aaa.ObjectType = GetType(System.CodeDom.CodeTypeDeclaration) AndAlso (DirectCast(aaa.Object, System.CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType = "VelerSoftware.WizardLib.AeroWizardForm" OrElse DirectCast(aaa.Object, System.CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType = "VelerSoftware.WizardLib.Wizard97Form") Then .Boutons_ComboBox.Items.Add(aaa.FullName)
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            Select Case .Param2
                Case "Show"
                    .RadioButton1.Checked = True
                Case "Hide"
                    .RadioButton2.Checked = True
                Case "Enable"
                    .RadioButton3.Checked = True
                Case "Disable"
                    .RadioButton4.Checked = True
            End Select

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            If .RadioButton1.Checked Then
                .Param2 = "Show"
            ElseIf .RadioButton2.Checked Then
                .Param2 = "Hide"
            ElseIf .RadioButton3.Checked Then
                .Param2 = "Enable"
            ElseIf .RadioButton4.Checked Then
                .Param2 = "Disable"
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

        Dim stat As String = Nothing

        If Me.RadioButton1.Checked Then
            stat = "Show"
        ElseIf Me.RadioButton2.Checked Then
            stat = "Hide"
        ElseIf Me.RadioButton3.Checked Then
            stat = "Enable"
        ElseIf Me.RadioButton4.Checked Then
            stat = "Disable"
        End If

        If Me.Boutons_ComboBox.Text = "Me" Then
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & "." & stat & "NextButton()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & "." & stat & "NextButton()"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

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
                    Select Case metho.Method.MethodName
                        Case "ShowNextButton"
                            Me.RadioButton1.Checked = True
                        Case "HideNextButton"
                            Me.RadioButton2.Checked = True
                        Case "EnableNextButton"
                            Me.RadioButton3.Checked = True
                        Case "DisableNextButton"
                            Me.RadioButton4.Checked = True
                    End Select
                    If TypeOf metho.Method.TargetObject Is CodeDom.CodeThisReferenceExpression Then
                        Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me"))
                    ElseIf TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression Then
                        If Not Me.Boutons_ComboBox.FindString(DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType.Replace("Variables.", Nothing)) = -1 Then
                            Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString(DirectCast(metho.Method.TargetObject, CodeDom.CodeTypeReferenceExpression).Type.BaseType.Replace("Variables.", Nothing)))
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class