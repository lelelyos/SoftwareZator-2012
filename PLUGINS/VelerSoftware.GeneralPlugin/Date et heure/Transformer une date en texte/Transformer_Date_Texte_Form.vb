Public Class Transformer_Date_Texte_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ValueEdit2.Tools = .Tools

            .Boutons_ComboBox.Items.Clear()
            .Boutons_ComboBox.Items.Add(Date.Now.ToShortDateString)
            .Boutons_ComboBox.Items.Add(Date.Now.ToLongDateString)
            .Boutons_ComboBox.SelectedIndex = 0

            .ComboBox1.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then
                    ComboBox1.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param4 = Nothing Then
                .ValueEdit2.SetGeneratedCode(.Param4)
            End If
            If Not .Param5 = Nothing Then
                .ValueEdit2.SetStrictValue(.Param5, CInt(.Param6))
            End If

            If Not .Param7 = Nothing Then
                .Boutons_ComboBox.SelectedIndex = CInt(.Param7)
            End If

            If Not .Param8 = Nothing Then
                If Not .ComboBox1.FindString(.Param8) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param8))
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param4 = .ValueEdit2.GetGeneratedCode()
            .Param5 = .ValueEdit2.GetStrictValue()
            .Param6 = CInt(.ValueEdit2.Editor)

            .Param7 = .Boutons_ComboBox.SelectedIndex
            .Param8 = .ComboBox1.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()
        Dim comparer As String = Nothing
        Select Case Me.Boutons_ComboBox.SelectedIndex
            Case 0
                comparer = "ToShortDateString"
            Case 1
                comparer = "ToLongDateString"
        End Select

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        OperationStatement = New CodeDom.CodeSnippetExpression(Me.ValueEdit2.GetGeneratedCode & "." & comparer)
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), OperationStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())


        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim OperationStatement As CodeDom.CodePropertyReferenceExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodePropertyReferenceExpression Then
                    Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    OperationStatement = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodePropertyReferenceExpression)
                    If OperationStatement.PropertyName = "ToShortDateString" Then
                        Me.Boutons_ComboBox.SelectedIndex = 0
                    ElseIf OperationStatement.PropertyName = "ToLongDateString" Then
                        Me.Boutons_ComboBox.SelectedIndex = 1S
                    End If
                End If

            Next
        End If
    End Sub


End Class