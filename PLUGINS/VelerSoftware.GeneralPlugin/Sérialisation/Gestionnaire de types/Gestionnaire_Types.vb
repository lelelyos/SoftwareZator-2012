Public Class Gestionnaire_Types

    Friend Nom_Projet As String
    Friend Tools As VelerSoftware.Plugins3.Tools
    Friend ProjPath As String

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Gestionnaire_Variables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProjPath = Tools.GetCurrentProjectPath
        Dim ite As Windows.Forms.ListViewItem
        Dim Visit As VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor

        If My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
            For Each fichier As String In Me.Tools.GetCurrentProjectVBNetFiles
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) AndAlso My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) = ProjPath & "\Datas Typed" Then
                    Using Parser As VelerSoftware.SZC.VBNetParser.IParser = VelerSoftware.SZC.VBNetParser.ParserFactory.CreateParser(My.Computer.FileSystem.CombinePath(ProjPath, fichier))
                        Parser.Parse()
                        If Parser.Errors.Count = 0 Then
                            Visit = New VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
                            Visit.VisitCompilationUnit(Parser.CompilationUnit, Nothing)
                            If Visit.codeCompileUnit.Namespaces(0).Name = "VelerSoftware_GeneralPlugin_Types" Then
                                ite = New Windows.Forms.ListViewItem
                                With ite
                                    .Name = Visit.codeCompileUnit.Namespaces(0).Types(0).Name
                                    .Text = Visit.codeCompileUnit.Namespaces(0).Types(0).Name
                                    .SubItems.Add(fichier)
                                    .Tag = ""
                                    For Each aaa As CodeDom.CodeTypeMember In Visit.codeCompileUnit.Namespaces(0).Types(0).Members
                                        If Not aaa.Name = ".ctor" Then .Tag &= aaa.Name & ";"
                                    Next
                                    .Tag = CStr(.Tag).TrimEnd(";")
                                End With
                                Me.ListView1.Items.Add(ite)
                            End If
                        End If
                        Parser.Dispose()
                    End Using
                End If
            Next

            ListView1_SelectedIndexChanged(Nothing, Nothing)
        End If


        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        'LV 1
        listviewsorter_lv1.ListView = Me.ListView1
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.Sort(0)

        Me.CancelButtonText = RM.GetString("CancelButtonText")
    End Sub


    Private Sub Ajouter_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ajouter_Button.Click
        Dim ite As New Windows.Forms.ListViewItem
        Dim CodeDom_CCu As New CodeDom.CodeCompileUnit
        Dim CodeDom_CLass As CodeDom.CodeTypeDeclaration
        Dim CodeDom_Sub_Main As New CodeDom.CodeConstructor
        Dim CodeDom_Field As CodeDom.CodeMemberField
        Dim sourceWriter As New IO.StringWriter()

        If Not My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
            My.Computer.FileSystem.CreateDirectory(ProjPath & "\Datas Typed")
        End If

        If My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
            Using frm As New Ajouter_Types
                If (frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK) AndAlso (Me.ListView1.Items.IndexOfKey(frm.Nom_KryptonTextBox1.Text) = -1) AndAlso (Not My.Computer.FileSystem.FileExists(ProjPath & "\Datas Typed\" & frm.Nom_KryptonTextBox1.Text & ".vb")) Then
                    CodeDom_CCu.Namespaces.Add(New CodeDom.CodeNamespace("VelerSoftware_GeneralPlugin_Types"))
                    CodeDom_CLass = New CodeDom.CodeTypeDeclaration(frm.Nom_KryptonTextBox1.Text)
                    CodeDom_CLass.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                    CodeDom_CLass.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                    CodeDom_CLass.CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Serializable"))
                    CodeDom_Sub_Main.Attributes = CodeDom.MemberAttributes.Public
                    CodeDom_CLass.Members.Add(CodeDom_Sub_Main)
                    With ite
                        .Name = frm.Nom_KryptonTextBox1.Text
                        .Text = frm.Nom_KryptonTextBox1.Text
                        .SubItems.Add(Variables.Ouvrir_Fichier(ProjPath, ProjPath & "\Datas Typed\" & frm.Nom_KryptonTextBox1.Text & ".vb"))
                        .Tag = ""
                        For Each ite2 As Windows.Forms.ListViewItem In frm.ListView1.Items
                            .Tag &= ite2.Text & ";"
                            CodeDom_Field = New CodeDom.CodeMemberField("System.Object", ite2.Text)
                            CodeDom_Field.Attributes = CodeDom.MemberAttributes.Public
                            CodeDom_CLass.Members.Add(CodeDom_Field)
                        Next
                        .Tag = CStr(.Tag).TrimEnd(";")
                    End With
                    Me.ListView1.Items.Add(ite)
                    CodeDom_CCu.Namespaces(0).Types.Add(CodeDom_CLass)
                    CodeDom_CCu.Namespaces(0).UserData.Clear()

                    If Me.Tools.GetCurrentProjectVBNetFiles.IndexOf("Datas Typed\" & frm.Nom_KryptonTextBox1.Text & ".vb") = -1 Then Me.Tools.GetCurrentProjectVBNetFiles.Add("Datas Typed\" & frm.Nom_KryptonTextBox1.Text & ".vb")

                    CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromNamespace(CodeDom_CCu.Namespaces(0), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
                    sourceWriter.Close()
                    My.Computer.FileSystem.WriteAllText(ProjPath & "\Datas Typed\" & frm.Nom_KryptonTextBox1.Text & ".vb", sourceWriter.ToString, False, System.Text.Encoding.UTF8)

                End If
                frm.Dispose()
            End Using
        End If
    End Sub

    Private Sub Modifier_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modifier_Button.Click
        Dim it As System.Windows.Forms.ListViewItem
        Dim CodeDom_CCu As New CodeDom.CodeCompileUnit
        Dim CodeDom_CLass As New CodeDom.CodeTypeDeclaration
        Dim CodeDom_Sub_Main As New CodeDom.CodeConstructor
        Dim CodeDom_Field As New CodeDom.CodeMemberField
        Dim sourceWriter As New IO.StringWriter()
        Dim OldPath As String

        If Not My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
            My.Computer.FileSystem.CreateDirectory(ProjPath & "\Datas Typed")
        End If

        Using frm As New Modifier_Types
            With frm
                .Nom_KryptonTextBox1.Text = Me.ListView1.SelectedItems(0).Text
                For Each aaa As String In CStr(Me.ListView1.SelectedItems(0).Tag).Split(";")
                    If Not aaa = Nothing Then
                        it = New System.Windows.Forms.ListViewItem
                        it.Name = aaa
                        it.Text = aaa
                        .ListView1.Items.Add(it)
                    End If
                Next

                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Me.ListView1.SelectedItems(0).Name = .Nom_KryptonTextBox1.Text
                    Me.ListView1.SelectedItems(0).Text = .Nom_KryptonTextBox1.Text
                    OldPath = Me.ListView1.SelectedItems(0).SubItems(1).Text
                    Me.ListView1.SelectedItems(0).SubItems(1).Text = Variables.Ouvrir_Fichier(ProjPath, ProjPath & "\Datas Typed\" & .Nom_KryptonTextBox1.Text & ".vb")

                    CodeDom_CCu.Namespaces.Add(New CodeDom.CodeNamespace("VelerSoftware_GeneralPlugin_Types"))
                    CodeDom_CLass = New CodeDom.CodeTypeDeclaration(frm.Nom_KryptonTextBox1.Text)
                    CodeDom_CLass.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                    CodeDom_CLass.TypeAttributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                    CodeDom_CLass.CustomAttributes.Add(New CodeDom.CodeAttributeDeclaration("System.Serializable"))
                    CodeDom_Sub_Main.Attributes = CodeDom.MemberAttributes.Public
                    CodeDom_CLass.Members.Add(CodeDom_Sub_Main)
                    Me.ListView1.SelectedItems(0).Tag = ""
                    For Each ite2 As Windows.Forms.ListViewItem In .ListView1.Items
                        Me.ListView1.SelectedItems(0).Tag &= ite2.Text & ";"
                        CodeDom_Field = New CodeDom.CodeMemberField("System.Object", ite2.Text)
                        CodeDom_Field.Attributes = CodeDom.MemberAttributes.Public
                        CodeDom_CLass.Members.Add(CodeDom_Field)
                    Next
                    Me.ListView1.SelectedItems(0).Tag = CStr(Me.ListView1.SelectedItems(0).Tag).TrimEnd(";")
                    CodeDom_CCu.Namespaces(0).Types.Add(CodeDom_CLass)
                    CodeDom_CCu.Namespaces(0).UserData.Clear()

                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(ProjPath, OldPath)) Then
                        My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CombinePath(ProjPath, OldPath), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
                    If Not Me.Tools.GetCurrentProjectVBNetFiles.IndexOf(OldPath) = -1 Then Me.Tools.GetCurrentProjectVBNetFiles.Remove(OldPath)
                    If Me.Tools.GetCurrentProjectVBNetFiles.IndexOf("Datas Typed\" & .Nom_KryptonTextBox1.Text & ".vb") = -1 Then Me.Tools.GetCurrentProjectVBNetFiles.Add("Datas Typed\" & .Nom_KryptonTextBox1.Text & ".vb")

                    CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromNamespace(CodeDom_CCu.Namespaces(0), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
                    sourceWriter.Close()
                    My.Computer.FileSystem.WriteAllText(ProjPath & "\Datas Typed\" & .Nom_KryptonTextBox1.Text & ".vb", sourceWriter.ToString, False, System.Text.Encoding.UTF8)

                End If
            End With
            frm.Dispose()
        End Using
    End Sub

    Private Sub Supprimer_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Supprimer_Button.Click
        For Each ite As Windows.Forms.ListViewItem In Me.ListView1.SelectedItems
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(ProjPath, ite.SubItems(1).Text)) Then
                My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.CombinePath(ProjPath, ite.SubItems(1).Text), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                If Not Me.Tools.GetCurrentProjectVBNetFiles.IndexOf(ite.SubItems(1).Text) = -1 Then Me.Tools.GetCurrentProjectVBNetFiles.Remove(ite.SubItems(1).Text)
            End If
            Me.ListView1.Items.RemoveByKey(ite.Name)
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedIndices.Count > 1 OrElse Me.ListView1.SelectedIndices.Count <= 0 Then
            Me.Modifier_Button.Enabled = False
        Else
            Me.Modifier_Button.Enabled = True
        End If
        If Me.ListView1.SelectedIndices.Count > 0 Then
            Me.Supprimer_Button.Enabled = True
        Else
            Me.Supprimer_Button.Enabled = False
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If Me.Modifier_Button.Enabled Then
            Modifier_Button_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Gestionnaire_Variables_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Gestionnaire_Variables_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class
