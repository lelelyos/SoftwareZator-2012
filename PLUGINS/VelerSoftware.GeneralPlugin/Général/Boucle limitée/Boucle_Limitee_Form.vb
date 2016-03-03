Public Class Boucle_Limitee_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Variable_Depart_ComboBox.Items.Clear()
            .Variable_Valeur_Arrivee_ComboBox1.Items.Clear()
            .Variable_Valeur_Depart_ComboBox.Items.Clear()
            .Variable_Valeur_Pas_ComboBox2.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_Depart_ComboBox.Items.Add(a.Name)
                    .Variable_Valeur_Arrivee_ComboBox1.Items.Add(a.Name)
                    .Variable_Valeur_Depart_ComboBox.Items.Add(a.Name)
                    .Variable_Valeur_Pas_ComboBox2.Items.Add(a.Name)
                Else
                    .Variable_Valeur_Arrivee_ComboBox1.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Variable_Depart_ComboBox.FindString(.Param1) = -1 Then
                    .Variable_Depart_ComboBox.Text = .Variable_Depart_ComboBox.Items(.Variable_Depart_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .Variable_Valeur_Depart_ComboBox.FindString(.Param2) = -1 Then
                    .Variable_Valeur_Depart_ComboBox.Text = .Variable_Valeur_Depart_ComboBox.Items(.Variable_Valeur_Depart_ComboBox.FindString(.Param2))
                    .Variable_Valeur_Depart_RadioButton.Checked = True
                ElseIf IsNumeric(.Param2) Then
                    .Constante_Valeur_Depart_RadioButton.Checked = True
                    .Constante_Valeur_Depart_NumericUpDown.Value = CInt(.Param2)
                End If
            End If

            If Not .Param3 = Nothing Then
                If Not .Variable_Valeur_Arrivee_ComboBox1.FindString(.Param3) = -1 Then
                    .Variable_Valeur_Arrivee_ComboBox1.Text = .Variable_Valeur_Arrivee_ComboBox1.Items(.Variable_Valeur_Arrivee_ComboBox1.FindString(.Param3))
                    .Variable_Valeur_Arrivee_RadioButton.Checked = True
                ElseIf IsNumeric(.Param3) Then
                    .Constante_Valeur_Arrivee_RadioButton.Checked = True
                    .Constante_Valeur_Arrivee_NumericUpDown1.Value = CInt(.Param3)
                End If
            End If

            If Not .Param5 = Nothing Then
                If Not .Variable_Valeur_Pas_ComboBox2.FindString(.Param5) = -1 Then
                    .Variable_Valeur_Pas_ComboBox2.Text = .Variable_Valeur_Pas_ComboBox2.Items(.Variable_Valeur_Pas_ComboBox2.FindString(.Param5))
                    .Variable_Valeur_Pas_RadioButton.Checked = True
                ElseIf IsNumeric(.Param5) Then
                    .Constante_Valeur_Pas_RadioButton.Checked = True
                    .Constante_Valeur_Pas_NumericUpDown2.Value = CInt(.Param5)
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Variable_Depart_ComboBox.Text = Nothing OrElse (.Variable_Valeur_Depart_RadioButton.Checked AndAlso .Variable_Valeur_Depart_ComboBox.Text = Nothing) OrElse (.Variable_Valeur_Arrivee_RadioButton.Checked AndAlso .Variable_Valeur_Arrivee_ComboBox1.Text = Nothing) OrElse (.Variable_Valeur_Pas_RadioButton.Checked AndAlso .Variable_Valeur_Pas_ComboBox2.Text = Nothing) Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Variable_Depart_ComboBox.Text

            If .Constante_Valeur_Depart_RadioButton.Checked Then
                .Param2 = .Constante_Valeur_Depart_NumericUpDown.Value
            Else
                .Param2 = .Variable_Valeur_Depart_ComboBox.Text
            End If

            If .Constante_Valeur_Arrivee_RadioButton.Checked Then
                .Param3 = .Constante_Valeur_Arrivee_NumericUpDown1.Value
            Else
                .Param3 = .Variable_Valeur_Arrivee_ComboBox1.Text
                For Each a As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If a.Name = .Param3 Then
                        If a.Array Then
                            .Param6 = True
                            Exit For
                        Else
                            .Param6 = False
                            Exit For
                        End If
                    End If
                Next
            End If


            If .Constante_Valeur_Pas_RadioButton.Checked Then
                .Param5 = .Constante_Valeur_Pas_NumericUpDown2.Value
            Else
                .Param5 = .Variable_Valeur_Pas_ComboBox2.Text
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
        If Me.Variable_Depart_ComboBox.Text = Nothing OrElse (Me.Variable_Valeur_Depart_RadioButton.Checked AndAlso Me.Variable_Valeur_Depart_ComboBox.Text = Nothing) OrElse (Me.Variable_Valeur_Arrivee_RadioButton.Checked AndAlso Me.Variable_Valeur_Arrivee_ComboBox1.Text = Nothing) OrElse (Me.Variable_Valeur_Pas_RadioButton.Checked AndAlso Me.Variable_Valeur_Pas_ComboBox2.Text = Nothing) Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim var_depart As New CodeDom.CodeVariableReferenceExpression(Me.Variable_Depart_ComboBox.Text)
        Dim var_arrivee As New CodeDom.CodeVariableReferenceExpression(Me.Variable_Valeur_Arrivee_ComboBox1.Text)


        Dim codeloop As New CodeDom.CodeIterationStatement()

        If Me.Constante_Valeur_Depart_RadioButton.Checked Then
            codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodePrimitiveExpression(Me.Constante_Valeur_Depart_NumericUpDown.Value))
        Else
            codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeVariableReferenceExpression(Me.Variable_Valeur_Depart_ComboBox.Text))
        End If

        If Me.Constante_Valeur_Arrivee_RadioButton.Checked Then
            codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodePrimitiveExpression(Me.Constante_Valeur_Arrivee_NumericUpDown1.Value))
        Else
            For Each a As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                If a.Name = Me.Variable_Valeur_Arrivee_ComboBox1.Text Then
                    If a.Array Then
                        codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodePropertyReferenceExpression(var_arrivee, "Count"))
                        Exit For
                    Else
                        codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, var_arrivee)
                        Exit For
                    End If
                End If
            Next
        End If

        If Me.Constante_Valeur_Pas_RadioButton.Checked Then
            codeloop.IncrementStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.Add, New CodeDom.CodePrimitiveExpression(Me.Constante_Valeur_Pas_NumericUpDown2.Value)))
        Else
            codeloop.IncrementStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.Add, New CodeDom.CodeVariableReferenceExpression(Me.Variable_Valeur_Pas_ComboBox2.Text)))
        End If

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(codeloop, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub Constante_Valeur_Depart_RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constante_Valeur_Depart_RadioButton.CheckedChanged, Variable_Valeur_Depart_RadioButton.CheckedChanged
        If Constante_Valeur_Depart_RadioButton.Checked Then
            Me.Constante_Valeur_Depart_NumericUpDown.Enabled = True
            Me.Variable_Valeur_Depart_ComboBox.Enabled = False
        Else
            Me.Constante_Valeur_Depart_NumericUpDown.Enabled = False
            Me.Variable_Valeur_Depart_ComboBox.Enabled = True
        End If
    End Sub

    Private Sub Constante_Valeur_Arrivee_RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constante_Valeur_Arrivee_RadioButton.CheckedChanged, Variable_Valeur_Arrivee_RadioButton.CheckedChanged
        If Constante_Valeur_Arrivee_RadioButton.Checked Then
            Me.Constante_Valeur_Arrivee_NumericUpDown1.Enabled = True
            Me.Variable_Valeur_Arrivee_ComboBox1.Enabled = False
        Else
            Me.Constante_Valeur_Arrivee_NumericUpDown1.Enabled = False
            Me.Variable_Valeur_Arrivee_ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub Constante_Valeur_Pas_RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constante_Valeur_Pas_RadioButton.CheckedChanged, Variable_Valeur_Pas_RadioButton.CheckedChanged
        If Constante_Valeur_Pas_RadioButton.Checked Then
            Me.Constante_Valeur_Pas_NumericUpDown2.Enabled = True
            Me.Variable_Valeur_Pas_ComboBox2.Enabled = False
        Else
            Me.Constante_Valeur_Pas_NumericUpDown2.Enabled = False
            Me.Variable_Valeur_Pas_ComboBox2.Enabled = True
        End If
    End Sub

End Class