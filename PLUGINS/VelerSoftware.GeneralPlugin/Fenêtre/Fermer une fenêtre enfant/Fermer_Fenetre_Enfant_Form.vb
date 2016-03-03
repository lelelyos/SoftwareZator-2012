Public Class Fermer_Fenetre_Enfant_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")


            .ActionTextBox1.WordWrap = False
            .ActionTextBox1.Multiline = False
            .ActionTextBox1.Tools = .Tools
            .ActionTextBox1.Text = ""

            .Height += 5

            .ParseCode_Button_Visible = False

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindows(False)
                .Boutons_ComboBox.Items.Add(aaa.FullName)
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then Me.ActionTextBox1.Text = .Param2

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .ActionTextBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .ActionTextBox1.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.ActionTextBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()
        Dim nom_var = Determine_Variable_Existe("frm")

        If Me.Boutons_ComboBox.Text = "Me" Then
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("For Each " & nom_var & " As System.Windows.Forms.Form In Me.MdiChildren : If " & nom_var & ".Name = " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True) & " Then : " & nom_var & ".Close() : Exit For : End If : Next"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        Else
            CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression("For Each " & nom_var & " As System.Windows.Forms.Form In Variables." & Me.Boutons_ComboBox.Text & ".MdiChildren : If " & nom_var & ".Name = " & Me.Tools.TransformKeyVariables(Me.ActionTextBox1.Text, True) & " Then : " & nom_var & ".Close() : Exit For : End If : Next"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
        End If


        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Friend Function Determine_Variable_Existe(ByVal Nom As String) As String
        Dim varlist As Generic.IList(Of VelerSoftware.SZVB.Projet.Variable) = Me.Tools.GetCurrentProjectVariableList
        ' on cherche un nom de dossier pour le projet où l'on est sur qu'il n'existe pas, de façon à éviter les message d'erreur disant que le dossier existe déja.
        Dim RESULTAT As String = Nothing
        Dim i As Integer = 1
        Dim oki As Boolean
        Do
            For Each var As VelerSoftware.SZVB.Projet.Variable In varlist
                If var.Name = Nom & i Then oki = True : Exit For
            Next
            If Not oki Then
                RESULTAT = Nom & i
                Return RESULTAT
                Exit Function
            Else
                i = i + 1
            End If
        Loop
        Return RESULTAT
    End Function

End Class