Public Class FonctionForm
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If Me.Nom_Fonction_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Me.Param1 = Me.Nom_Fonction_ActionTextBox.Text.Replace(" ", "_").Replace("-", "_").Replace("?", "_").Replace("/", "_").Replace(":", "_").Replace(";", "_").Replace(".", "_").Replace(",", "_")

        If CBool(Me.Tag) Then
            If Not Me.Tools.GetCurrentFunctionIsClass Then
                If Me.Param2 Is Nothing Then
                    Me.Param3 = Nothing
                    For Each ite As System.Windows.Forms.ListViewItem In Me.ListView1.Items
                        Me.Param3 &= ite.Text & ";"
                    Next
                    If Me.Param3 IsNot Nothing Then Me.Param3 = Me.Param3.TrimEnd(";")
                    Me.Param4 = Me.RadioButton1.Checked
                End If
            End If
        Else
            If Me.Param2 Is Nothing Then
                Me.Param3 = Nothing
                For Each ite As System.Windows.Forms.ListViewItem In Me.ListView1.Items
                    Me.Param3 &= ite.Text & ";"
                Next
                If Me.Param3 IsNot Nothing Then Me.Param3 = Me.Param3.TrimEnd(";")
                Me.Param4 = Me.RadioButton1.Checked
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")


            .Nom_Fonction_ActionTextBox.Text = ""
            If Not .Param1 = Nothing Then .Nom_Fonction_ActionTextBox.Text = .Param1

            .ParseCode_Button_Visible = False

            If Not .Param1 = Nothing Then
                If Not Me.Tools.GetCurrentFunctionIsClass Then
                    If .Param2 IsNot Nothing Then
                        .Sub_RadioButton.Checked = True
                        .ListView1.Enabled = False
                        .ajouter_Button.Enabled = False
                        .supprimer_Button2.Enabled = False
                        .monter_Button4.Enabled = False
                        .descendre_Button3.Enabled = False
                        .Sub_RadioButton.Enabled = False
                        .RadioButton1.Enabled = False
                        If .Param3 IsNot Nothing Then
                            For Each strr As String In .Param3.Split(",")
                                .ListView1.Items.Add(strr.Trim(" ").Split(" ")(1))
                            Next
                        End If
                        .ShowHideCodeEditor_Button_Visible = False
                        .CodeEditor_Shown = False
                        .HideCodeEditor()

                    Else
                        If .Param3 IsNot Nothing Then
                            Dim ite As System.Windows.Forms.ListViewItem
                            For Each strr As String In .Param3.Split(";")
                                ite = New System.Windows.Forms.ListViewItem
                                ite.Name = strr
                                ite.Text = strr
                                .ListView1.Items.Add(ite)
                            Next
                        End If
                        If .Param4 IsNot Nothing Then
                            If CBool(Me.Param4) Then
                                .RadioButton1.Checked = True
                            Else
                                .Sub_RadioButton.Checked = True
                            End If
                        End If
                    End If
                Else
                    .RadioButton1.Enabled = False
                    .Sub_RadioButton.Enabled = False
                    .ListView1.Enabled = False
                    .ajouter_Button.Enabled = False
                    .supprimer_Button2.Enabled = False
                    .monter_Button4.Enabled = False
                    .descendre_Button3.Enabled = False
                    .ShowHideCodeEditor_Button_Visible = False
                    .CodeEditor_Shown = False
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        Dim sourceWriter As New IO.StringWriter()

        Dim method As System.CodeDom.CodeMemberMethod = New System.CodeDom.CodeMemberMethod()
        method.Name = Me.Nom_Fonction_ActionTextBox.Text
        method.Comments.Add(New CodeDom.CodeCommentStatement(RM.GetString("DisplayName") & " " & Me.Nom_Fonction_ActionTextBox.Text))
        If Me.RadioButton1.Checked Then
            method.ReturnType = New System.CodeDom.CodeTypeReference("System.Object")
            method.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Static
        Else
            method.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
        End If
        For Each ite As System.Windows.Forms.ListViewItem In Me.ListView1.Items
            method.Parameters.Add(New System.CodeDom.CodeParameterDeclarationExpression("System.Object", ite.Text))
        Next
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromMember(method, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()
        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub




























    ''' <summary>
    ''' Move selected listview item up or down based on moveUp= True/false.
    ''' </summary>
    ''' <param name = "moveUp"></param>
    Private Sub MoveListViewItem(ByRef lv As Windows.Forms.ListView, ByVal moveUp As Boolean)
        Dim i As Integer
        Dim cache As String
        Dim selIdx As Integer

        With lv
            selIdx = .SelectedItems.Item(0).Index
            If moveUp Then
                ' ignore moveup of row(0)
                If selIdx = 0 Then
                    Exit Sub
                End If
                ' move the subitems for the previous row
                ' to cache so we can move the selected row up
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx - 1).SubItems(i).Text
                    .Items(selIdx - 1).SubItems(i).Text = _
                       .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx - 1).Selected = True
                .Refresh()
                .Focus()
            Else
                ' ignore move down of last row
                If selIdx = .Items.Count - 1 Then
                    Exit Sub
                End If
                ' move the subitems for the next row
                ' to cache so we can move the selected row down
                For i = 0 To .Items(selIdx).SubItems.Count - 1
                    cache = .Items(selIdx + 1).SubItems(i).Text
                    .Items(selIdx + 1).SubItems(i).Text = _
                       .Items(selIdx).SubItems(i).Text
                    .Items(selIdx).SubItems(i).Text = cache
                Next
                .Items(selIdx + 1).Selected = True
                .Refresh()
                .Focus()
            End If
        End With
    End Sub

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click, ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.monter_Button4.Enabled = True
            Me.descendre_Button3.Enabled = True
            Me.supprimer_Button2.Enabled = True
            If Me.ListView1.SelectedItems(0).Index = 0 Then
                Me.monter_Button4.Enabled = False
            End If
            If Me.ListView1.SelectedItems(0).Index = Me.ListView1.Items.Count - 1 Then
                Me.descendre_Button3.Enabled = False
            End If
        Else
            Me.monter_Button4.Enabled = False
            Me.descendre_Button3.Enabled = False
            Me.supprimer_Button2.Enabled = False
        End If
    End Sub

    Private Sub monter_Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles monter_Button4.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            MoveListViewItem(Me.ListView1, True)
        Else
            Me.monter_Button4.Enabled = False
            Me.descendre_Button3.Enabled = False
        End If
    End Sub

    Private Sub descendre_Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles descendre_Button3.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            MoveListViewItem(Me.ListView1, False)
        Else
            Me.monter_Button4.Enabled = False
            Me.descendre_Button3.Enabled = False
        End If
    End Sub

    Private Sub ajouter_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ajouter_Button.Click
        Me.ListView1.SelectedItems.Clear()
        Dim ite As New Windows.Forms.ListViewItem
        ite.Selected = True
        Dim i As Integer = 1
        ite.Text = "New_Parameter" & i
        ite.Name = ite.Text
        Do
            If Me.ListView1.Items.ContainsKey(ite.Text) Then
                i += 1
                ite.Text = "New_Parameter" & i
                ite.Name = ite.Text
            Else
                ite.Text = "New_Parameter" & i
                ite.Name = ite.Text
                Exit Do
            End If
        Loop
        Me.ListView1.Items.Add(ite)
    End Sub

    Private Sub RennomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RennomerToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.ListView1.SelectedItems(0).BeginEdit()
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.RennomerToolStripMenuItem.Enabled = True
        Else
            Me.RennomerToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub supprimer_Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles supprimer_Button2.Click
        If Me.ListView1.SelectedIndices.Count > 0 Then
            For Each a As Windows.Forms.ListViewItem In Me.ListView1.SelectedItems
                a.Remove()
            Next
        End If
    End Sub

    Private Sub ListView1_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        If e.Label IsNot Nothing Then
            If e.Label.Contains(".") _
              OrElse e.Label.Contains("?") _
              OrElse e.Label.Contains(",") _
              OrElse e.Label.Contains(";") _
              OrElse e.Label.Contains(":") _
              OrElse e.Label.Contains("/") _
              OrElse e.Label.Contains("!") _
              OrElse e.Label.Contains("§") _
              OrElse e.Label.Contains("-") _
              OrElse e.Label.Contains("&") _
              OrElse e.Label.Contains("²") _
              OrElse e.Label.Contains("^") _
              OrElse e.Label.Contains("*") _
              OrElse e.Label.Contains("%") _
              OrElse e.Label.Contains(" ") _
              OrElse e.Label = "0" _
              OrElse e.Label = "1" _
              OrElse e.Label = "2" _
              OrElse e.Label = "3" _
              OrElse e.Label = "4" _
              OrElse e.Label = "5" _
              OrElse e.Label = "6" _
              OrElse e.Label = "7" _
              OrElse e.Label = "8" _
              OrElse e.Label = "9" _
              Then
                e.CancelEdit = True
                MsgBox(RM.GetString("Caractere_Non_valide"), MsgBoxStyle.Exclamation)
            Else
                Me.ListView1.Items(e.Item).Name = e.Label
            End If
        Else
            e.CancelEdit = True
        End If
    End Sub

End Class