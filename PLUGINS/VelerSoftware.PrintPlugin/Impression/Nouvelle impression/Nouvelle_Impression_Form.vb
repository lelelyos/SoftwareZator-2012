Public Class Nouvelle_Impression_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ActionTextBox2.Tools = .Tools

            .ActionTextBox2.Text = ""
            .RadioButton1.Checked = True

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then .Boutons_ComboBox.Items.Add(aaa.Name)
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .ActionTextBox2.Text = .Param2
            End If

            Select Case .Param3
                Case "Automatic"
                    .RadioButton1.Checked = True
                Case "Portrait"
                    .RadioButton2.Checked = True
                Case "Lanscape"
                    .RadioButton3.Checked = True
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
            .Param2 = .ActionTextBox2.Text
            If .RadioButton1.Checked Then
                .Param3 = "Automatic"
            ElseIf .RadioButton2.Checked Then
                .Param3 = "Portrait"
            ElseIf .RadioButton3.Checked Then
                .Param3 = "Lanscape"
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
            stat = "Automatic"
        ElseIf Me.RadioButton2.Checked Then
            stat = "Portrait"
        ElseIf Me.RadioButton3.Checked Then
            stat = "Lanscape"
        End If

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & " = New VelerSoftware.PrintLib.PrintSystem.PrintClass(VelerSoftware.PrintLib.PrintSystem.Orientation." & stat & ", " & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, True) & ", False)"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeObjectCreateExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement Then
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Boutons_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeObjectCreateExpression Then
                        metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression)
                        If metho.Parameters.Count >= 1 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "Automatic"
                                    Me.RadioButton1.Checked = True
                                Case "Portrait"
                                    Me.RadioButton2.Checked = True
                                Case "Lanscape"
                                    Me.RadioButton3.Checked = True
                            End Select
                        End If
                        If metho.Parameters.Count >= 2 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If Me.RadioButton1.Checked Then
            Me.PictureBox1.Image = My.Resources.automatique
        ElseIf Me.RadioButton2.Checked Then
            Me.PictureBox1.Image = My.Resources.portrait
        ElseIf Me.RadioButton3.Checked Then
            Me.PictureBox1.Image = My.Resources.paysage
        End If
    End Sub

End Class