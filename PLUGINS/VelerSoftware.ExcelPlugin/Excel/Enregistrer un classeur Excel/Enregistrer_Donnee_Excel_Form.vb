Public Class Enregistrer_Donnee_Excel_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Hote_ActionTextBox1.Tools = .Tools

            .Hote_ActionTextBox1.Text = "%(APPLICATION=APPLICATION_PATH)%\File.xlsx"
            .Actif_RadioButton.Checked = True
            .RadioButton1.Checked = True

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Boutons_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If CBool(.Param2) Then
                    Me.Sous_RadioButton1.Checked = True
                    Me.Actif_RadioButton.Checked = False
                Else
                    Me.Sous_RadioButton1.Checked = False
                    Me.Actif_RadioButton.Checked = True
                End If
            End If

            If Not .Param3 = Nothing Then
                .Hote_ActionTextBox1.Text = .Param3
            End If

            If Not .Param4 = Nothing Then
                If CBool(.Param4) Then
                    Me.RadioButton1.Checked = True
                    Me.RadioButton2.Checked = False
                Else
                    Me.RadioButton1.Checked = False
                    Me.RadioButton2.Checked = True
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .Hote_ActionTextBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .Sous_RadioButton1.Checked
            .Param3 = .Hote_ActionTextBox1.Text
            .Param4 = .RadioButton1.Checked

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.Hote_ActionTextBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim saveas As String
        If Me.Sous_RadioButton1.Checked Then
            If Me.RadioButton1.Checked Then
                saveas = "As2007"
            Else
                saveas = "As2003"
            End If
        Else
            saveas = ""
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeMethodInvokeExpression
        If Me.Actif_RadioButton.Checked Then
            OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), "Save")
        Else
            OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), "Save" & saveas, New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Hote_ActionTextBox1.Text, True)))
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
                    If TypeOf metho.Method.TargetObject Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Boutons_ComboBox.Text = DirectCast(metho.Method.TargetObject, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                    If metho.Method.MethodName = "Save" Then
                        Me.Actif_RadioButton.Checked = True
                    Else
                        Me.Sous_RadioButton1.Checked = True
                        Select Case metho.Method.MethodName
                            Case "SaveAs2003"
                                Me.RadioButton2.Checked = True
                            Case "SaveAs2007"
                                Me.RadioButton1.Checked = True
                        End Select
                        If metho.Parameters.Count > 0 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Hote_ActionTextBox1.Text = CStr(DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value)
                        End If
                    End If

                End If

            Next
        End If
    End Sub

    Private Sub Actif_RadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Actif_RadioButton.CheckedChanged, Sous_RadioButton1.CheckedChanged
        With Me
            If Me.Actif_RadioButton.Checked Then
                .Hote_ActionTextBox1.Enabled = False
                .RadioButton1.Enabled = False
                .RadioButton2.Enabled = False
            Else
                .Hote_ActionTextBox1.Enabled = True
                .RadioButton1.Enabled = True
                .RadioButton2.Enabled = True
            End If
        End With
    End Sub
End Class