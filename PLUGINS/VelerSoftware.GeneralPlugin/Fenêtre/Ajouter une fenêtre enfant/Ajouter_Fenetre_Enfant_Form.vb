Public Class Ajouter_Fenetre_Enfant_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ActionTextBox1.Tools = .Tools
            .ParseCode_Button_Visible = False
            .ActionTextBox1.Text = ""

            .Parent_ComboBox.Items.Clear()
            .Enfant_ComboBox1.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindows(False)
                .Parent_ComboBox.Items.Add(aaa.FullName)
                If Not aaa.FullName = "Me" Then .Enfant_ComboBox1.Items.Add(DirectCast(aaa.Object, System.CodeDom.CodeTypeDeclaration).Name)
            Next

            .ComboBox2.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then .ComboBox2.Items.Add(aaa.Name)
            Next

            If Not .Param1 = Nothing Then
                If Not .Parent_ComboBox.FindString(.Param1) = -1 Then
                    .Parent_ComboBox.Text = .Parent_ComboBox.Items(.Parent_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .Enfant_ComboBox1.FindString(.Param2) = -1 Then
                    .Enfant_ComboBox1.Text = .Enfant_ComboBox1.Items(.Enfant_ComboBox1.FindString(.Param2))
                End If
            End If

            If Not .Param3 = Nothing Then .ActionTextBox1.Text = .Param3

            If Not .Param4 = Nothing Then
                If Not .ComboBox2.FindString(.Param4) = -1 Then
                    .ComboBox2.Text = .ComboBox2.Items(.ComboBox2.FindString(.Param4))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Parent_ComboBox.Text = "" OrElse .Enfant_ComboBox1.Text = "" OrElse .ActionTextBox1.Text = "" OrElse .ComboBox2.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Parent_ComboBox.Text
            .Param2 = .Enfant_ComboBox1.Text
            .Param3 = .ActionTextBox1.Text
            .Param4 = .ComboBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Parent_ComboBox.Text = "" OrElse Me.Enfant_ComboBox1.Text = "" OrElse Me.ActionTextBox1.Text = "" OrElse Me.ComboBox2.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim parent As String = Me.Parent_ComboBox.Text
        If Not parent = "Me" Then parent = "Variables." & parent
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeSnippetStatement(Me.ComboBox2.Text & " = New " & Me.Enfant_ComboBox1.Text & " : " & Me.ComboBox2.Text & ".Name = " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True) & " : " & Me.ComboBox2.Text & ".MdiParent = " & parent & " : " & Me.ComboBox2.Text & ".Visible = True"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class