Public Class Calcul_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Variable_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Variable_ComboBox.Items.Add(a.Name)
                End If
            Next

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                If Not .Variable_ComboBox.FindString(.Param2) = -1 Then
                    .Variable_ComboBox.Text = .Variable_ComboBox.Items(.Variable_ComboBox.FindString(.Param2))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" OrElse Me.Variable_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text

            .Param2 = .Variable_ComboBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.Variable_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox.Text), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text.Replace("√", "System.Math.Sqrt").Replace("π", "System.Math.PI").Replace("Trunc", "System.Math.Truncate").Replace(" Cosˉ¹(", " System.Math.ACos(").Replace(" Cos(", " System.Math.Cos(").Replace(" Sinˉ¹(", " System.Math.ASin(").Replace(" Sin(", " System.Math.Sin(").Replace(" Tanˉ¹(", " System.Math.ATan(").Replace(" Tan(", " System.Math.Tan(").Replace("Round", " System.Math.Round").Replace("Rest", "System.Math.IEEERemainder").Replace("Sign", "System.Math.Sign").Replace("AMax", "System.Math.Ceiling").Replace("AMin", "System.Math.Floor").Replace("Max", "System.Math.Max").Replace("Min", "System.Math.Min").Replace("%(", "CDec(%(").Replace(")%", ")%)"), False, False))), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub














    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Me.Texte_Message_ActionTextBox.Text &= "7"
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Me.Texte_Message_ActionTextBox.Text &= "8"
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Texte_Message_ActionTextBox.Text &= "9"
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Texte_Message_ActionTextBox.Text &= "4"
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Me.Texte_Message_ActionTextBox.Text &= "5"
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Me.Texte_Message_ActionTextBox.Text &= "6"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Texte_Message_ActionTextBox.Text &= "1"
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        Me.Texte_Message_ActionTextBox.Text &= "2"
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Me.Texte_Message_ActionTextBox.Text &= "3"
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Texte_Message_ActionTextBox.Text &= "0"
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        Me.Texte_Message_ActionTextBox.Text &= "."
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Me.Texte_Message_ActionTextBox.Text &= " * "
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Me.Texte_Message_ActionTextBox.Text &= " / "
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Me.Texte_Message_ActionTextBox.Text &= " - "
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Texte_Message_ActionTextBox.Text &= " + "
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        Me.Texte_Message_ActionTextBox.Text &= "("
    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Me.Texte_Message_ActionTextBox.Text &= ")"
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Me.Texte_Message_ActionTextBox.Text &= "√(0)"
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Me.Texte_Message_ActionTextBox.Text &= "^(2)"
    End Sub

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        Me.Texte_Message_ActionTextBox.Text &= "π"
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        Me.Texte_Message_ActionTextBox.Text &= "Trunc(0)"
    End Sub

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        Me.Texte_Message_ActionTextBox.Text &= "Round(0)"
    End Sub

    Private Sub Button35_Click(sender As System.Object, e As System.EventArgs) Handles Button35.Click
        If Not Me.Texte_Message_ActionTextBox.Text.Length < 0 Then Me.Texte_Message_ActionTextBox.Text = Me.Texte_Message_ActionTextBox.Text.Substring(0, Me.Texte_Message_ActionTextBox.Text.Length - 1)
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        Me.Texte_Message_ActionTextBox.Text &= "Cos(0)"
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Me.Texte_Message_ActionTextBox.Text &= "Sin(0)"
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Me.Texte_Message_ActionTextBox.Text &= "Tan(0)"
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Me.Texte_Message_ActionTextBox.Text &= "Cosˉ¹(0)"
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        Me.Texte_Message_ActionTextBox.Text &= "Sinˉ¹(0)"
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        Me.Texte_Message_ActionTextBox.Text &= "Tanˉ¹(0)"
    End Sub

    Private Sub Button33_Click(sender As System.Object, e As System.EventArgs) Handles Button33.Click
        Me.Texte_Message_ActionTextBox.Text &= "Sign(0)"
    End Sub

    Private Sub Button29_Click(sender As System.Object, e As System.EventArgs) Handles Button29.Click
        Me.Texte_Message_ActionTextBox.Text &= "Max(4, 2)"
    End Sub

    Private Sub Button34_Click(sender As System.Object, e As System.EventArgs) Handles Button34.Click
        Me.Texte_Message_ActionTextBox.Text &= "Rest(4, 2)"
    End Sub

    Private Sub Button30_Click(sender As System.Object, e As System.EventArgs) Handles Button30.Click
        Me.Texte_Message_ActionTextBox.Text &= "Min(4, 2)"
    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        Me.Texte_Message_ActionTextBox.Text &= "AMax(0)"
    End Sub

    Private Sub Button32_Click(sender As System.Object, e As System.EventArgs) Handles Button32.Click
        Me.Texte_Message_ActionTextBox.Text &= "AMin(0)"
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePropertyReferenceExpression Then
                    ' Dans le cas  où se soit une assignation de variable
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Variable_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If

                End If

            Next
        End If
    End Sub

End Class