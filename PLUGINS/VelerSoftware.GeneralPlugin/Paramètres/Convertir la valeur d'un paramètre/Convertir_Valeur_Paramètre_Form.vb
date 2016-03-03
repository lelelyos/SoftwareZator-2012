Public Class Convertir_Valeur_Paramètre_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Var1_ComboBox.Items.Clear()
            .Var2_ComboBox.Items.Clear()
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .Var2_ComboBox.Items.Add(a.Name)
                End If
            Next
            For Each a As String In .Tools.GetCurrentProjectSettings
                .Var1_ComboBox.Items.Add(a)
            Next

            If Not .Param1 = Nothing Then
                If Not .Var1_ComboBox.FindString(.Param1) = -1 Then
                    .Var1_ComboBox.Text = .Var1_ComboBox.Items(.Var1_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If .Param2 = "String" Then
                    .RadioButton1.Checked = True
                ElseIf .Param2 = "Integer" Then
                    .RadioButton2.Checked = True
                ElseIf .Param2 = "Decimal" Then
                    .RadioButton3.Checked = True
                ElseIf .Param2 = "Boolean" Then
                    .RadioButton4.Checked = True
                Else
                    .RadioButton5.Checked = True
                    .ActionTextBox1.Text = .Param2
                End If
            End If

            If Not .Param3 = Nothing Then
                If Not .Var2_ComboBox.FindString(.Param3) = -1 Then
                    .Var2_ComboBox.Text = .Var2_ComboBox.Items(.Var2_ComboBox.FindString(.Param3))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Var1_ComboBox.Text = "" OrElse .Var2_ComboBox.Text = Nothing OrElse (Me.RadioButton5.Checked AndAlso Me.ActionTextBox1.Text = Nothing) Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Var1_ComboBox.Text
            If Me.RadioButton1.Checked Then
                .Param2 = "String"
            ElseIf Me.RadioButton2.Checked Then
                .Param2 = "Integer"
            ElseIf Me.RadioButton3.Checked Then
                .Param2 = "Decimal"
            ElseIf Me.RadioButton4.Checked Then
                .Param2 = "Boolean"
            Else
                .Param2 = .ActionTextBox1.Text
            End If
            .Param3 = .Var2_ComboBox.Text

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

        Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression("My.Settings." & Me.Var1_ComboBox.Text)
        Dim VariableStatement2 As New CodeDom.CodeVariableReferenceExpression(Me.Var2_ComboBox.Text)
        Dim Tip As New CodeDom.CodeTypeReference()
        If Me.RadioButton1.Checked Then
            Tip = New CodeDom.CodeTypeReference("String")
        ElseIf Me.RadioButton2.Checked Then
            Tip = New CodeDom.CodeTypeReference("Integer")
        ElseIf Me.RadioButton3.Checked Then
            Tip = New CodeDom.CodeTypeReference("Decimal")
        ElseIf Me.RadioButton4.Checked Then
            Tip = New CodeDom.CodeTypeReference("Boolean")
        Else
            Tip = New CodeDom.CodeTypeReference(Me.ActionTextBox1.Text)
        End If
        Dim OperationStatement As New CodeDom.CodeAssignStatement(VariableStatement2, New CodeDom.CodeCastExpression(Tip, VariableStatement))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tip As Type = Me.Tools.SelectType
        If Not tip Is Nothing Then
            Me.ActionTextBox1.Text = tip.FullName
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton5.CheckedChanged, RadioButton4.CheckedChanged, RadioButton3.CheckedChanged, RadioButton2.CheckedChanged
        Me.ActionTextBox1.Enabled = Me.RadioButton5.Checked
        Me.Button1.Enabled = Me.RadioButton5.Checked
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeCastExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeCastExpression Then
                    ' Dans le cas où se soit une assignation de variable
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeCastExpression)
                    Select Case metho.TargetType.BaseType
                        Case "String" Or "System.String"
                            Me.RadioButton1.Checked = True
                        Case "Integer" Or "System.Integer"
                            Me.RadioButton2.Checked = True
                        Case "Decimal" Or "System.Decimal"
                            Me.RadioButton3.Checked = True
                        Case "Boolean" Or "System.Boolean"
                            Me.RadioButton4.Checked = True
                        Case Else
                            Me.RadioButton5.Checked = True
                            Me.ActionTextBox1.Text = metho.TargetType.BaseType
                    End Select
                    If TypeOf metho.Expression Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Var1_ComboBox.Text = DirectCast(metho.Expression, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.Var2_ComboBox.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If

                End If

            Next
        End If
    End Sub

End Class