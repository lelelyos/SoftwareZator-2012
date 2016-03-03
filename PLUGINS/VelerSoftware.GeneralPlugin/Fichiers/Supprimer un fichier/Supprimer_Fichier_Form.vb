Public Class Supprimer_Fichier_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Texte_Message_ActionTextBox.Tools = .Tools

            .Texte_Message_ActionTextBox.Text = "%(APPLICATION=APPLICATION_PATH)%\Un dossier\Fichier à supprimer"

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            If Not .Param2 = Nothing Then
                If CBool(.Param2) Then
                    .Afficher_Boite_Dialogue_RadioButton.Checked = True
                Else
                    .Afficher_Erreur_RadioButton.Checked = True
                End If
            End If

            If Not .Param3 = Nothing Then
                If CBool(.Param3) Then
                    .Corbeille_RadioButton.Checked = True
                Else
                    .Supprimer_RadioButton.Checked = True
                End If
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Texte_Message_ActionTextBox.Text = "" Then
                MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Texte_Message_ActionTextBox.Text

            .Param2 = .Afficher_Boite_Dialogue_RadioButton.Checked

            .Param3 = .Corbeille_RadioButton.Checked

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Texte_Message_ActionTextBox.Text = "" Then
            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim dialog As String
        If Me.Afficher_Boite_Dialogue_RadioButton.Checked Then
            dialog = "Microsoft.VisualBasic.FileIO.UIOption.AllDialogs"
        Else
            dialog = "Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs"
        End If

        Dim remove As String
        If Me.Corbeille_RadioButton.Checked Then
            remove = "Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin"
        Else
            remove = "Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently"
        End If

        If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("_computer.FileSystem"), "DeleteFile", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(dialog), New CodeDom.CodeSnippetExpression(remove))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.FileSystem"), "DeleteFile", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Texte_Message_ActionTextBox.Text, True)), New CodeDom.CodeSnippetExpression(dialog), New CodeDom.CodeSnippetExpression(remove))
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(MsgBoxStatement, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeExpressionStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeExpressionStatement).Expression Is CodeDom.CodeMethodInvokeExpression Then
                    ' Dans le cas où se soit une simple méthode
                    metho = DirectCast(DirectCast(sta, CodeDom.CodeExpressionStatement).Expression, CodeDom.CodeMethodInvokeExpression)
                    If metho.Method.MethodName = "DeleteFile" AndAlso TypeOf metho.Method.TargetObject Is CodeDom.CodeTypeReferenceExpression Then
                        If TypeOf metho.Parameters(0) Is CodeDom.CodePrimitiveExpression Then
                            Me.Texte_Message_ActionTextBox.Text = DirectCast(metho.Parameters(0), CodeDom.CodePrimitiveExpression).Value
                        End If
                        If TypeOf metho.Parameters(1) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(1), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "AllDialogs"
                                    Me.Afficher_Boite_Dialogue_RadioButton.Checked = True
                                Case "OnlyErrorDialogs"
                                    Me.Afficher_Erreur_RadioButton.Checked = True
                            End Select
                        End If
                        If TypeOf metho.Parameters(2) Is CodeDom.CodePropertyReferenceExpression Then
                            Select Case DirectCast(metho.Parameters(2), CodeDom.CodePropertyReferenceExpression).PropertyName
                                Case "SendToRecycleBin"
                                    Me.Corbeille_RadioButton.Checked = True
                                Case "DeletePermanently"
                                    Me.Supprimer_RadioButton.Checked = True
                            End Select
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class