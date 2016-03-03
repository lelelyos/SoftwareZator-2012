Public Class Assigner_Donnee_Serialisable_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Friend ProjPath As String

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .ComboBox1.Items.Clear()
            .ComboBox2.Items.Clear()

            For Each a As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not a.Array Then
                    .ComboBox2.Items.Add(a.Name)
                End If
            Next

            ProjPath = Tools.GetCurrentProjectPath

            If My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
                Dim Visit As VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
                For Each fichier As String In Me.Tools.GetCurrentProjectVBNetFiles
                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) AndAlso My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) = ProjPath & "\Datas Typed" Then
                        Using Parser As VelerSoftware.SZC.VBNetParser.IParser = VelerSoftware.SZC.VBNetParser.ParserFactory.CreateParser(My.Computer.FileSystem.CombinePath(ProjPath, fichier))
                            Parser.Parse()
                            If Parser.Errors.Count = 0 Then
                                Visit = New VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
                                Visit.VisitCompilationUnit(Parser.CompilationUnit, Nothing)
                                If Visit.codeCompileUnit.Namespaces(0).Name = "VelerSoftware_GeneralPlugin_Types" Then
                                    .ComboBox1.Items.Add(Visit.codeCompileUnit.Namespaces(0).Types(0).Name & " (" & fichier & ")")
                                End If
                            End If
                            Parser.Dispose()
                        End Using
                    End If
                Next
            End If

            If Not .Param1 = Nothing Then
                If Not .ComboBox1.FindString(.Param1) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .ComboBox2.FindString(.Param2) = -1 Then
                    .ComboBox2.Text = .ComboBox2.Items(.ComboBox2.FindString(.Param2))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .ComboBox2.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .ComboBox1.Text
            .Param2 = .ComboBox2.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Using frm As New Gestionnaire_Types
            frm.Tools = Me.Tools
            frm.ShowDialog()
        End Using

        Dim txt As String = Me.ComboBox1.Text
        Me.ComboBox1.Items.Clear()
        If My.Computer.FileSystem.DirectoryExists(ProjPath & "\Datas Typed\") Then
            Dim Visit As VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
            For Each fichier As String In Me.Tools.GetCurrentProjectVBNetFiles
                If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) AndAlso My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.CombinePath(ProjPath, fichier)) = ProjPath & "\Datas Typed" Then
                    Using Parser As VelerSoftware.SZC.VBNetParser.IParser = VelerSoftware.SZC.VBNetParser.ParserFactory.CreateParser(My.Computer.FileSystem.CombinePath(ProjPath, fichier))
                        Parser.Parse()
                        If Parser.Errors.Count = 0 Then
                            Visit = New VelerSoftware.SZC.VBNetParser.Visitors.CodeDomVisitor
                            Visit.VisitCompilationUnit(Parser.CompilationUnit, Nothing)
                            If Visit.codeCompileUnit.Namespaces(0).Name = "VelerSoftware_GeneralPlugin_Types" Then
                                Me.ComboBox1.Items.Add(Visit.codeCompileUnit.Namespaces(0).Types(0).Name & " (" & fichier & ")")
                            End If
                        End If
                        Parser.Dispose()
                    End Using
                End If
            Next
        End If
        Me.ComboBox1.Text = txt
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.combobox2.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox2.Text), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("New VelerSoftware_GeneralPlugin_Types"), Me.ComboBox1.Text.Split("(")(0).Trim(" "))), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeObjectCreateExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement Then
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression Then
                        Me.ComboBox2.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName
                    End If
                    If TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeObjectCreateExpression Then
                        metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression)
                        For Each strr As String In Me.ComboBox1.Items
                            If strr.StartsWith(metho.CreateType.BaseType.Replace("VelerSoftware_GeneralPlugin_Types.", "") & " (", StringComparison.InvariantCulture) Then
                                Me.ComboBox1.Text = strr
                                Exit For
                            End If
                        Next
                    End If

                End If

            Next
        End If
    End Sub

End Class