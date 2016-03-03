Public Class Afficher_Message_Avance_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Titre_ActionTextBox1.Tools = .Tools
            .EnTete_ActionTextBox2.Tools = .Tools
            .Message_ActionTextBox3.Tools = .Tools
            .PiedDePage_ActionTextBox4.Tools = .Tools
            .Info_ActionTextBox5.Tools = .Tools

            .IconePiedDePage_ComboBox1.SelectedIndex = 4
            .Icone_ComboBox2.SelectedIndex = 4

            .Fenêtre_ComboBox.Items.Clear()
            .Fenêtre_ComboBox.Items.Add("")
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindows(False)
                If aaa.ObjectType = GetType(System.CodeDom.CodeTypeDeclaration) Then .Fenêtre_ComboBox.Items.Add(aaa.FullName)
            Next

            .Variable_ComboBox3.Items.Clear()
            .Variable_ComboBox3.Items.Add("")
            For Each var As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList()
                If Not var.Array Then .Variable_ComboBox3.Items.Add(var.Name)
            Next





            If Not .Param1 = Nothing Then
                If Not .Fenêtre_ComboBox.FindString(.Param1) = -1 Then
                    .Fenêtre_ComboBox.Text = .Fenêtre_ComboBox.Items(.Fenêtre_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then .Titre_ActionTextBox1.Text = .Param2

            If Not .Param3 = Nothing Then .EnTete_ActionTextBox2.Text = .Param3

            If Not .Param4 = Nothing Then .Message_ActionTextBox3.Text = .Param4

            If Not .Param5 = Nothing Then
                If .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 0
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 1
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 2
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 3
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 4
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 5
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 6
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 7
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 8
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 9
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 10
                ElseIf .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray" Then
                    .IconePiedDePage_ComboBox1.SelectedIndex = 11
                End If
            End If

            If Not .Param6 = Nothing Then .PiedDePage_ActionTextBox4.Text = .Param6

            If Not .Param7 = Nothing Then .PiedDePage_CheckBox1.Checked = CBool(.Param7)

            If Not .Param8 = Nothing Then .Info_ActionTextBox5.Text = .Param8

            If Not .Param9 = Nothing Then .InfoCheckBox2.Checked = CBool(.Param9)

            .CheckedListBox1.SetItemChecked(0, False)
            .CheckedListBox1.SetItemChecked(1, False)
            .CheckedListBox1.SetItemChecked(2, False)
            .CheckedListBox1.SetItemChecked(3, False)
            .CheckedListBox1.SetItemChecked(4, False)
            .CheckedListBox1.SetItemChecked(5, False)
            .CheckedListBox1.SetItemChecked(6, False)
            .CheckedListBox1.SetItemChecked(7, False)
            .CheckedListBox1.SetItemChecked(8, False)
            .CheckedListBox1.SetItemChecked(9, False)
            .CheckedListBox1.SetItemChecked(10, False)
            .CheckedListBox1.SetItemChecked(11, False)
            If Not .Param10 = Nothing Then
                Dim tmp As String = .Param10
                tmp = tmp.Replace("New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton() {New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.", Nothing)
                tmp = tmp.Replace(", New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.", Nothing)
                tmp = tmp.Replace(")}", Nothing)
                Dim but() As String = tmp.Split(")")
                For Each a As String In but
                    Select Case a
                        Case "Continue"
                            .CheckedListBox1.SetItemChecked(0, True)
                        Case "Ignore"
                            .CheckedListBox1.SetItemChecked(1, True)
                        Case "Retry"
                            .CheckedListBox1.SetItemChecked(2, True)
                        Case "Abort"
                            .CheckedListBox1.SetItemChecked(3, True)
                        Case "Close"
                            .CheckedListBox1.SetItemChecked(4, True)
                        Case "None"
                            .CheckedListBox1.SetItemChecked(5, True)
                        Case "No"
                            .CheckedListBox1.SetItemChecked(8, True)
                        Case "NoToAll"
                            .CheckedListBox1.SetItemChecked(9, True)
                        Case "Yes"
                            .CheckedListBox1.SetItemChecked(6, True)
                        Case "YesToAll"
                            .CheckedListBox1.SetItemChecked(7, True)
                        Case "OK"
                            .CheckedListBox1.SetItemChecked(10, True)
                        Case "Cancel"
                            .CheckedListBox1.SetItemChecked(11, True)
                    End Select
                Next
            End If

            If Not .Param11 = Nothing Then
                If .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning" Then
                    .Icone_ComboBox2.SelectedIndex = 0
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error" Then
                    .Icone_ComboBox2.SelectedIndex = 1
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information" Then
                    .Icone_ComboBox2.SelectedIndex = 2
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question" Then
                    .Icone_ComboBox2.SelectedIndex = 3
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None" Then
                    .Icone_ComboBox2.SelectedIndex = 4
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError" Then
                    .Icone_ComboBox2.SelectedIndex = 5
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning" Then
                    .Icone_ComboBox2.SelectedIndex = 6
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion" Then
                    .Icone_ComboBox2.SelectedIndex = 7
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess" Then
                    .Icone_ComboBox2.SelectedIndex = 8
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield" Then
                    .Icone_ComboBox2.SelectedIndex = 9
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue" Then
                    .Icone_ComboBox2.SelectedIndex = 10
                ElseIf .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray" Then
                    .Icone_ComboBox2.SelectedIndex = 11
                End If
            End If

            If Not .Param12 = Nothing Then .Bloquer_CheckBox3.Checked = CBool(.Param12)

            If Not .Param13 = Nothing Then
                If Not .Variable_ComboBox3.FindString(.Param13) = -1 Then
                    .Variable_ComboBox3.Text = .Variable_ComboBox3.Items(.Variable_ComboBox3.FindString(.Param13))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Titre_ActionTextBox1.Text = "" OrElse .Message_ActionTextBox3.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Fenêtre_ComboBox.Text
            .Param2 = .Titre_ActionTextBox1.Text
            .Param3 = .EnTete_ActionTextBox2.Text
            .Param4 = .Message_ActionTextBox3.Text

            Select Case .IconePiedDePage_ComboBox1.SelectedIndex
                Case 0
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning"
                Case 1
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error"
                Case 2
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information"
                Case 3
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question"
                Case 4
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None"
                Case 5
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError"
                Case 6
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning"
                Case 7
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion"
                Case 8
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess"
                Case 9
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield"
                Case 10
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue"
                Case 11
                    .Param5 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray"
            End Select

            .Param6 = .PiedDePage_ActionTextBox4.Text
            .Param7 = .PiedDePage_CheckBox1.Checked
            .Param8 = .Info_ActionTextBox5.Text
            .Param9 = .InfoCheckBox2.Checked

            If .CheckedListBox1.CheckedItems.Count > 0 Then
                .Param10 = "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton() {"
                For Each a As Integer In .CheckedListBox1.CheckedIndices
                    Select Case a
                        Case 0
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Continue), "
                        Case 1
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Ignore), "
                        Case 2
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Retry), "
                        Case 3
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Abort), "
                        Case 4
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Close), "
                        Case 5
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.None), "
                        Case 6
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Yes), "
                        Case 7
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.YesToAll), "
                        Case 8
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.No), "
                        Case 9
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.NoToAll), "
                        Case 10
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.OK), "
                        Case 11
                            .Param10 = .Param10 & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Cancel), "
                    End Select
                Next
                .Param10 = .Param10 & "}"
                .Param10 = .Param10.Replace(", }", "}")
            Else
                .Param10 = "Nothing"
            End If

            Select Case .Icone_ComboBox2.SelectedIndex
                Case 0
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning"
                Case 1
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error"
                Case 2
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information"
                Case 3
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question"
                Case 4
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None"
                Case 5
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError"
                Case 6
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning"
                Case 7
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion"
                Case 8
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess"
                Case 9
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield"
                Case 10
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue"
                Case 11
                    .Param11 = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray"
            End Select

            .Param12 = .Bloquer_CheckBox3.Checked
            .Param13 = .Variable_ComboBox3.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Titre_ActionTextBox1.Text = "" OrElse Me.Message_ActionTextBox3.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim footericon As String = ""
        Select Case Me.IconePiedDePage_ComboBox1.SelectedIndex
            Case 0
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning"
            Case 1
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error"
            Case 2
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information"
            Case 3
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question"
            Case 4
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None"
            Case 5
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError"
            Case 6
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning"
            Case 7
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion"
            Case 8
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess"
            Case 9
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield"
            Case 10
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue"
            Case 11
                footericon = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray"
        End Select

        Dim boutons As String = ""
        If Me.CheckedListBox1.CheckedItems.Count > 0 Then
            boutons = "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton() {"
            For Each a As Integer In Me.CheckedListBox1.CheckedIndices
                Select Case a
                    Case 0
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Continue), "
                    Case 1
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Ignore), "
                    Case 2
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Retry), "
                    Case 3
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Abort), "
                    Case 4
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Close), "
                    Case 5
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.None), "
                    Case 6
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Yes), "
                    Case 7
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.YesToAll), "
                    Case 8
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.No), "
                    Case 9
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.NoToAll), "
                    Case 10
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.OK), "
                    Case 11
                        boutons = boutons & "New VelerSoftware.VistaMessageBoxLib.VistaMessageBoxButton(VelerSoftware.VistaMessageBoxLib.VistaMessageBoxResult.Cancel), "
                End Select
            Next
            boutons = boutons & "}"
            boutons = boutons.Replace(", }", "}")
        Else
            boutons = "Nothing"
        End If

        Dim icone As String = ""
        Select Case Me.Icone_ComboBox2.SelectedIndex
            Case 0
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Warning"
            Case 1
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Error"
            Case 2
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Information"
            Case 3
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.Question"
            Case 4
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.None"
            Case 5
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityError"
            Case 6
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityWarning"
            Case 7
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityQuestion"
            Case 8
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecuritySuccess"
            Case 9
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShield"
            Case 10
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldBlue"
            Case 11
                icone = "VelerSoftware.VistaMessageBoxLib.VistaMessageBoxIcon.SecurityShieldGray"
        End Select


        Dim sourceWriter As New IO.StringWriter()

        Dim method As CodeDom.CodeMethodInvokeExpression

        If Me.Fenêtre_ComboBox.Text = "Me" Then
            method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeThisReferenceExpression, New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Titre_ActionTextBox1.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.EnTete_ActionTextBox2.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Message_ActionTextBox3.Text, True, False)), New CodeDom.CodeSnippetExpression(footericon), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.PiedDePage_ActionTextBox4.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.PiedDePage_CheckBox1.Checked), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Info_ActionTextBox5.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.InfoCheckBox2.Checked), New CodeDom.CodeSnippetExpression(boutons), New CodeDom.CodeSnippetExpression(icone), New CodeDom.CodePrimitiveExpression(Me.Bloquer_CheckBox3.Checked))
        ElseIf Not Me.Fenêtre_ComboBox.Text = "" Then
            method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.Fenêtre_ComboBox.Text), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Titre_ActionTextBox1.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.EnTete_ActionTextBox2.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Message_ActionTextBox3.Text, True, False)), New CodeDom.CodeSnippetExpression(footericon), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.PiedDePage_ActionTextBox4.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.PiedDePage_CheckBox1.Checked), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Info_ActionTextBox5.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.InfoCheckBox2.Checked), New CodeDom.CodeSnippetExpression(boutons), New CodeDom.CodeSnippetExpression(icone), New CodeDom.CodePrimitiveExpression(Me.Bloquer_CheckBox3.Checked))
        Else
            method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Titre_ActionTextBox1.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.EnTete_ActionTextBox2.Text, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Message_ActionTextBox3.Text, True, False)), New CodeDom.CodeSnippetExpression(footericon), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.PiedDePage_ActionTextBox4.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.PiedDePage_CheckBox1.Checked), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Info_ActionTextBox5.Text, True, False)), New CodeDom.CodePrimitiveExpression(Me.InfoCheckBox2.Checked), New CodeDom.CodeSnippetExpression(boutons), New CodeDom.CodeSnippetExpression(icone), New CodeDom.CodePrimitiveExpression(Me.Bloquer_CheckBox3.Checked))
        End If

        If Me.Variable_ComboBox3.Text = Nothing Then
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(method, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Variable_ComboBox3.Text), method), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class