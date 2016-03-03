Public Class Comparer_Deux_Dates_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ValueEdit1.Tools = .Tools
            .ValueEdit2.Tools = .Tools

            .Boutons_ComboBox.SelectedIndex = 0

            .ComboBox1.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then
                    ComboBox1.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param1)
            End If
            If Not .Param2 = Nothing Then
                .ValueEdit1.SetStrictValue(.Param2, CInt(.Param3))
            End If

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

            .Param1 = .ValueEdit1.GetGeneratedCode()
            .Param2 = .ValueEdit1.GetStrictValue()
            .Param3 = CInt(.ValueEdit1.Editor)

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
                comparer = "Microsoft.VisualBasic.DateInterval.Year"
            Case 1
                comparer = "Microsoft.VisualBasic.DateInterval.DayOfYear"
            Case 2
                comparer = "Microsoft.VisualBasic.DateInterval.Day"
            Case 3
                comparer = "Microsoft.VisualBasic.DateInterval.Hour"
            Case 4
                comparer = "Microsoft.VisualBasic.DateInterval.Minute"
            Case 5
                comparer = "Microsoft.VisualBasic.DateInterval.Month"
            Case 6
                comparer = "Microsoft.VisualBasic.DateInterval.Quarter"
            Case 7
                comparer = "Microsoft.VisualBasic.DateInterval.Second"
            Case 8
                comparer = "Microsoft.VisualBasic.DateInterval.Weekday"
            Case 9
                comparer = "Microsoft.VisualBasic.DateInterval.WeekOfYear"
        End Select

        Dim OperationStatement As CodeDom.CodeMethodInvokeExpression
        OperationStatement = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Microsoft.VisualBasic"), "DateDiff"), New CodeDom.CodeSnippetExpression(comparer), New CodeDom.CodeSnippetExpression(Me.ValueEdit1.GetGeneratedCode), New CodeDom.CodeSnippetExpression(Me.ValueEdit2.GetGeneratedCode))
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), OperationStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())


        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim OperationStatement As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeMethodInvokeExpression Then
                    Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    OperationStatement = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeMethodInvokeExpression)
                    If OperationStatement.Method.MethodName = "DateDiff" AndAlso OperationStatement.Parameters.Count > 0 AndAlso TypeOf OperationStatement.Parameters(0) Is CodeDom.CodePropertyReferenceExpression Then
                        Select Case DirectCast(OperationStatement.Parameters(0), CodeDom.CodePropertyReferenceExpression).PropertyName
                            Case "Year"
                                Me.Boutons_ComboBox.SelectedIndex = 0
                            Case "DayOfYear"
                                Me.Boutons_ComboBox.SelectedIndex = 1
                            Case "Day"
                                Me.Boutons_ComboBox.SelectedIndex = 2
                            Case "Hour"
                                Me.Boutons_ComboBox.SelectedIndex = 3
                            Case "Minute"
                                Me.Boutons_ComboBox.SelectedIndex = 4
                            Case "Month"
                                Me.Boutons_ComboBox.SelectedIndex = 5
                            Case "Quarter"
                                Me.Boutons_ComboBox.SelectedIndex = 6
                            Case "Second"
                                Me.Boutons_ComboBox.SelectedIndex = 7
                            Case "Weekday"
                                Me.Boutons_ComboBox.SelectedIndex = 8
                            Case "WeekOfYear"
                                Me.Boutons_ComboBox.SelectedIndex = 9
                        End Select
                    End If
                End If

            Next
        End If
    End Sub

End Class