Public Class Executer_Fonction_Projet_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private ListFonction As Generic.List(Of String)

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .ComboBox1.Enabled = False

            ListFonction = .Tools.GetSolutionFunctions

            .Boutons_ComboBox.SelectedIndex = 0
            .Boutons_ComboBox.Items.Clear()
            For Each a As String In ListFonction
                .Boutons_ComboBox.Items.Add(a.Split("(")(0))
            Next

            .ComboBox1.SelectedIndex = 0
            .ComboBox1.Items.Clear()
            .ComboBox1.Items.Add("")
            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                .ComboBox1.Items.Add(a.Name)
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                Dim ind As Integer = 0
                For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                    prop.Value = CStr(.Param2.Split(",")(ind).Trim(" "))
                    ind += 1
                Next
            End If

            If Not .Param3 = Nothing Then
                If Not .ComboBox1.FindString(.Param3) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param3))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If Not .Boutons_ComboBox.Text.Split(".")(0) = .Tools.GetCurrentProjectName Then
                Dim oki As Boolean = True
                For Each ref As VelerSoftware.SZVB.Projet.Reference In .Tools.GetCurrentProjectReferences
                    If ref.IsProject AndAlso ref.Name = .Boutons_ComboBox.Text.Split(".")(0) Then
                        oki = False
                    End If
                Next
                If oki Then
                    MsgBox(String.Format(RM.GetString("Ajouter_reference"), .Boutons_ComboBox.Text.Split(".")(0)), MsgBoxStyle.Information)
                End If
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = Nothing
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                .Param2 &= prop.Value & ","
            Next
            If Not .Param2 = Nothing Then .Param2 = .Param2.Trim(",")
            If .ComboBox1.Enabled Then
                .Param3 = .ComboBox1.Text
            Else
                .Param3 = Nothing
            End If


            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Boutons_ComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Boutons_ComboBox.SelectedIndexChanged
        Me.ComboBox1.Enabled = False
        For Each a As String In ListFonction
            If a.StartsWith(Me.Boutons_ComboBox.Text & "(") AndAlso a.EndsWith(" As System.Object") Then
                Me.ComboBox1.Enabled = True
                Exit For
            End If
        Next

        Me.PropertyGrids1.SelectedObjects = Nothing
        Me.PropertyGrids1.Item.Clear()
        Me.PropertyGrids1.ItemSet.Clear()
        Me.PropertyGrids1.ShowCustomProperties = True
        Me.PropertyGrids1.Refresh()
        Dim param As String = Nothing
        For Each a As String In ListFonction
            If a.StartsWith(Me.Boutons_ComboBox.Text & "(") Then
                param = a.Split("(")(1)
                param = param.Split(")")(0)
                If Not param = Nothing Then
                    For Each strrr As String In param.Split(",")
                        Me.PropertyGrids1.Item.Add(strrr.Trim(" ").Split(" ")(1), "Nothing", False, "", "", True)
                    Next
                End If
            End If
        Next
        Me.PropertyGrids1.Refresh()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        If Me.ComboBox1.Enabled AndAlso (Not Me.ComboBox1.Text = Nothing) Then
            Dim param As String = ""
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                param &= prop.Value & ","
            Next
            If Not param = Nothing Then param = param.Trim(",")
            If Me.Boutons_ComboBox.Text.StartsWith(Me.Tools.GetCurrentProjectName & ".Me") Then
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.Boutons_ComboBox.Text.StartsWith(Me.Tools.GetCurrentProjectName & ".") Then
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Boutons_ComboBox.Text.Replace(Me.Tools.GetCurrentProjectName & ".", "Variables.").Replace("." & Me.Boutons_ComboBox.Text.Split(".")(2), Nothing)), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            Else
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Boutons_ComboBox.Text.Replace("." & Me.Boutons_ComboBox.Text.Split(".")(2), Nothing)), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), MsgBoxStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            End If
        Else
            Dim param As String = ""
            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                param &= prop.Value & ","
            Next
            If Not param = Nothing Then param = param.Trim(",")
            If Me.Boutons_ComboBox.Text.StartsWith(Me.Tools.GetCurrentProjectName & ".Me") Then
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            ElseIf Me.Boutons_ComboBox.Text.StartsWith(Me.Tools.GetCurrentProjectName & ".") Then
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Boutons_ComboBox.Text.Replace(Me.Tools.GetCurrentProjectName & ".", "Variables.").Replace("." & Me.Boutons_ComboBox.Text.Split(".")(2), Nothing)), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            Else
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Boutons_ComboBox.Text.Replace("." & Me.Boutons_ComboBox.Text.Split(".")(2), Nothing)), Me.Boutons_ComboBox.Text.Split(".")(2)), New CodeDom.CodeSnippetExpression(param))
                CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            End If
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

End Class