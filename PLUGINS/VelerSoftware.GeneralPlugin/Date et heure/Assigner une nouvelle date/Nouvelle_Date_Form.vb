Public Class Nouvelle_Date_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Annee_ActionTextBox1.Tools = .Tools
            .Mois_ActionTextBox2.Tools = .Tools
            .Jour_ActionTextBox3.Tools = .Tools
            .Heure_ActionTextBox4.Tools = .Tools
            .Minute_ActionTextBox5.Tools = .Tools
            .Second_ActionTextBox6.Tools = .Tools

            Dim tod As DateTime = Date.Now
            .Annee_ActionTextBox1.Text = tod.Year
            .Mois_ActionTextBox2.Text  = tod.Month
            .Jour_ActionTextBox3.Text = tod.Day
            .Heure_ActionTextBox4.Text = "0"
            .Minute_ActionTextBox5.Text = "0"
            .Second_ActionTextBox6.Text = "0"

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

            If Not .Param2 = Nothing Then .Annee_ActionTextBox1.Text = .Param2
            If Not .Param3 = Nothing Then .Mois_ActionTextBox2.Text = .Param3
            If Not .Param4 = Nothing Then .Jour_ActionTextBox3.Text = .Param4
            If Not .Param5 = Nothing Then .Heure_ActionTextBox4.Text = .Param5
            If Not .Param6 = Nothing Then .Minute_ActionTextBox5.Text = .Param6
            If Not .Param7 = Nothing Then .Second_ActionTextBox6.Text = .Param7

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            If .Annee_ActionTextBox1.Text = "" Then
                .Param2 = "0"
            Else
                .Param2 = .Annee_ActionTextBox1.Text
            End If
            If .Mois_ActionTextBox2.Text = "" Then
                .Param3 = "0"
            Else
                .Param3 = .Mois_ActionTextBox2.Text
            End If
            If .Jour_ActionTextBox3.Text = "" Then
                .Param4 = "0"
            Else
                .Param4 = .Jour_ActionTextBox3.Text
            End If
            If .Heure_ActionTextBox4.Text = "" Then
                .Param5 = "0"
            Else
                .Param5 = .Heure_ActionTextBox4.Text
            End If
            If .Minute_ActionTextBox5.Text = "" Then
                .Param6 = "0"
            Else
                .Param6 = .Minute_ActionTextBox5.Text
            End If
            If .Second_ActionTextBox6.Text = "" Then
                .Param7 = "0"
            Else
                .Param7 = .Second_ActionTextBox6.Text
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

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Boutons_ComboBox.Text), New CodeDom.CodeSnippetExpression("New System.DateTime(" & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Annee_ActionTextBox1.Text, False, False) & ", " & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Mois_ActionTextBox2.Text, False, False) & ", " & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Jour_ActionTextBox3.Text, False, False) & ", " & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Heure_ActionTextBox4.Text, False, False) & ", " & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Minute_ActionTextBox5.Text, False, False) & ", " & _
                                                                                                                                                                           Me.Tools.TransformKeyVariables(Me.Second_ActionTextBox6.Text, False, False) & ")"))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

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
                        If metho.Parameters.Count >= 1 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Annee_ActionTextBox1.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 2 AndAlso TypeOf metho.Parameters(1) Is CodeDom.CodePrimitiveExpression Then
                            Me.Mois_ActionTextBox2.Text = DirectCast(metho.Parameters(1), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 3 AndAlso TypeOf metho.Parameters(2) Is CodeDom.CodePrimitiveExpression Then
                            Me.Jour_ActionTextBox3.Text = DirectCast(metho.Parameters(2), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 4 AndAlso TypeOf metho.Parameters(3) Is CodeDom.CodePrimitiveExpression Then
                            Me.Heure_ActionTextBox4.Text = DirectCast(metho.Parameters(3), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 5 AndAlso TypeOf metho.Parameters(4) Is CodeDom.CodePrimitiveExpression Then
                            Me.Minute_ActionTextBox5.Text = DirectCast(metho.Parameters(4), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If metho.Parameters.Count >= 6 AndAlso TypeOf metho.Parameters(5) Is CodeDom.CodePrimitiveExpression Then
                            Me.Second_ActionTextBox6.Text = DirectCast(metho.Parameters(5), CodeDom.CodePrimitiveExpression).Value
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class