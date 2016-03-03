Public Class Ajouter_Element_DataGridView_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.DataGridView" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonDataGridView") Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If .Param2 IsNot Nothing Then
                Dim ite As System.Windows.Forms.ListViewItem
                For Each strr As String In .Param2.Split("█")
                    ite = New System.Windows.Forms.ListViewItem
                    ite.Name = strr
                    ite.Text = strr
                    .ListView1.Items.Add(ite)
                Next
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = Nothing
            For Each ite As System.Windows.Forms.ListViewItem In .ListView1.Items
                .Param2 &= ite.Text & "█"
            Next
            If .Param2 IsNot Nothing Then .Param2 = .Param2.TrimEnd("█")

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

        Dim param As String = Nothing
        For Each ite As System.Windows.Forms.ListViewItem In Me.ListView1.Items
            param &= Me.Tools.TransformKeyVariables(ite.Text, True) & ","
        Next
        If param IsNot Nothing Then param = param.TrimEnd(",")

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
            OperationStatement = New CodeDom.CodeSnippetExpression("Me." & Me.Boutons_ComboBox.Text.Substring(3) & ".Rows.Add(New String() {" & param & "})")
        Else
            OperationStatement = New CodeDom.CodeSnippetExpression("Variables." & Me.Boutons_ComboBox.Text & ".Rows.Add(New String() {" & param & "})")
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(OperationStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements
                ' Dans le cas où se soit une simple méthode
                metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                If metho.Method.MethodName = "Add" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodePropertyReferenceExpression Then
                    If Not Me.Boutons_ComboBox.FindString("Me." & DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                        Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me." & DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                    End If
                    If Not Me.Boutons_ComboBox.FindString(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                        Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString(DirectCast(metho.Method.TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                    End If
                End If

            Next
        End If
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
        ite.Text = "New data " & i & " - %(VARIABLE=MyVar)%"
        ite.Name = ite.Text
        Do
            If Me.ListView1.Items.ContainsKey(ite.Text) Then
                i += 1
                ite.Text = "New data " & i & " - %(VARIABLE=MyVar)%"
                ite.Name = ite.Text
            Else
                ite.Text = "New data " & i & " - %(VARIABLE=MyVar)%"
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
            Me.ListView1.Items(e.Item).Name = e.Label
        Else
            e.CancelEdit = True
        End If
    End Sub


End Class