Public Class Modifier_Point_Diagramme_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Texte_Message_ActionTextBox.Tools = .Tools
            .ActionTextBox1.Tools = .Tools
            .ActionTextBox2.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = ""
            .ActionTextBox1.Text = "0"
            .ActionTextBox2.Text = "0"

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.DataVisualization.Charting.Chart") Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                .Texte_Message_ActionTextBox.Text = .Param2
            End If

            If Not .Param3 = Nothing Then
                Me.ActionTextBox1.Text = .Param3
            End If

            If Not .Param4 = Nothing Then
                Me.ActionTextBox2.Text = .Param4
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .Texte_Message_ActionTextBox.Text = "" OrElse .ActionTextBox1.Text = "" OrElse .ActionTextBox2.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .Texte_Message_ActionTextBox.Text
            .Param3 = .ActionTextBox1.Text
            .Param4 = .ActionTextBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.Texte_Message_ActionTextBox.Text = "" OrElse Me.ActionTextBox1.Text = "" OrElse Me.ActionTextBox2.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
            OperationStatement = New CodeDom.CodeSnippetExpression("Me." & Me.Boutons_ComboBox.Text.Substring(3) & ".Series(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & ").Points(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False) & ").SetValueY(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False) & ")")
        Else
            OperationStatement = New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".Series(" & Me.Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True) & ").Points(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, False) & ").SetValueY(" & Me.Tools.TransformKeyVariables(Me.ActionTextBox2.Text, False) & ")")
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class