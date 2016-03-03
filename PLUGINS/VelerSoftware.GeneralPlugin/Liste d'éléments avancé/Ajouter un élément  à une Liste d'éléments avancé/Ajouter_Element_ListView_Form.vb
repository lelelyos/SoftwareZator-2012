Public Class Ajouter_Element_ListView_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Index_ActionTextBox1.Tools = .Tools
            .Nom_ActionTextBox.Tools = .Tools
            .Texte_ActionTextBox2.Tools = .Tools
            .InfoBulle_ActionTextBox3.Tools = .Tools
            .Img_ActionTextBox4.Tools = .Tools

            .Index_ActionTextBox1.Text = "0"
            .Img_ActionTextBox4.Text = "0"

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.ListView" Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If CBool(.Param2) Then
                    .RadioButton1.Checked = True
                Else
                    .RadioButton2.Checked = True
                End If
                .Index_ActionTextBox1.Text = .Param3
            End If

            If Not .Param4 = Nothing Then
                .Nom_ActionTextBox.Text = .Param4
            End If

            If Not .Param5 = Nothing Then
                .Texte_ActionTextBox2.Text = .Param5
            End If

            If Not .Param6 = Nothing Then
                .InfoBulle_ActionTextBox3.Text = .Param6
            End If

            If Not .Param7 = Nothing Then
                .Img_ActionTextBox4.Text = .Param7
            End If

            If Not .Param8 = Nothing Then
                .CheckBox1.Checked = CBool(.Param8)
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .RadioButton1.Checked
            If Me.Index_ActionTextBox1.Text = "" Then
                .Param3 = "0"
            Else
                .Param3 = Me.Index_ActionTextBox1.Text
            End If
            .Param4 = .Nom_ActionTextBox.Text
            .Param5 = .Texte_ActionTextBox2.Text
            .Param6 = .InfoBulle_ActionTextBox3.Text
            If Me.Img_ActionTextBox4.Text = "" Then
                .Param7 = "0"
            Else
                .Param7 = Me.Img_ActionTextBox4.Text
            End If
            .Param8 = .CheckBox1.Checked

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

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        If Me.RadioButton1.Checked Then
            If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
                OperationStatement = New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".Items.Add(VelerSoftware_GeneralPlugin.AddItemListView(" & Me.Tools.TransformKeyVariables(Me.Nom_ActionTextBox.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Texte_ActionTextBox2.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.InfoBulle_ActionTextBox3.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Img_ActionTextBox4.Text, False, False) & ", " & Me.CheckBox1.Checked & "))")
            Else
                OperationStatement = New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".Items.Add(VelerSoftware_GeneralPlugin.AddItemListView(" & Me.Tools.TransformKeyVariables(Me.Nom_ActionTextBox.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Texte_ActionTextBox2.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.InfoBulle_ActionTextBox3.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Img_ActionTextBox4.Text, False, False) & ", " & Me.CheckBox1.Checked & "))")
            End If
        Else
            If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
                OperationStatement = New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".Items.Insert(" & Me.Tools.TransformKeyVariables(Me.Index_ActionTextBox1.Text, False, False) & ", VelerSoftware_GeneralPlugin.AddItemListView(" & Me.Tools.TransformKeyVariables(Me.Nom_ActionTextBox.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Texte_ActionTextBox2.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.InfoBulle_ActionTextBox3.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Img_ActionTextBox4.Text, False, False) & ", " & Me.CheckBox1.Checked & "))")
            Else
                OperationStatement = New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".Items.Insert(" & Me.Tools.TransformKeyVariables(Me.Index_ActionTextBox1.Text, False, False) & ", VelerSoftware_GeneralPlugin.AddItemListView(" & Me.Tools.TransformKeyVariables(Me.Nom_ActionTextBox.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Texte_ActionTextBox2.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.InfoBulle_ActionTextBox3.Text, True) & ", " & Me.Tools.TransformKeyVariables(Me.Img_ActionTextBox4.Text, False, False) & ", " & Me.CheckBox1.Checked & "))")
            End If
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        Me.Index_ActionTextBox1.Enabled = Me.RadioButton2.Checked
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "Add" Then
                        Me.RadioButton1.Checked = True
                    ElseIf metho.Method.MethodName = "Insert" Then
                        Me.RadioButton2.Checked = True
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression AndAlso Microsoft.VisualBasic.IsNumeric(DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value) Then
                            Me.Index_ActionTextBox1.Text = CInt(DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value)
                        End If
                    End If
                    If TypeOf metho.Method.TargetObject Is CodeDom.CodePropertyReferenceExpression AndAlso TypeOf DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression) Is CodeDom.CodePropertyReferenceExpression Then
                        If Not Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                            Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                        End If
                        If Not Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                            Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class