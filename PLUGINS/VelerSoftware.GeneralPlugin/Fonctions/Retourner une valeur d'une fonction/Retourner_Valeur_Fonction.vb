<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Retourner_Valeur_Fonction_Designer))> _
Public Class Retourner_Valeur_Fonction
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Retourner_Valeur_Fonction", GetType(Retourner_Valeur_Fonction).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.retourner_valeur_fonction
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Retourner_Valeur_Fonction", GetType(Retourner_Valeur_Fonction).Assembly)

        If Tools.GetCurrentFunctionType Then
            Using frm As New Retourner_Valeur_Fonction_Form
                frm.Tools = Me.Tools
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.UseCustomVBCode = frm.CodeEditor_Used
                    Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                    Me.Param1 = frm.Param1
                    Me.Param2 = frm.Param2
                    Me.Param3 = frm.Param3

                    Return True
                Else
                    Return False
                End If
                frm.Dispose()
            End Using
        Else
            MsgBox(RM.GetString("Pas_Compatible"), MsgBoxStyle.Exclamation)
            Return False
        End If

    End Function

    Public Overrides Function Modify() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Retourner_Valeur_Fonction", GetType(Retourner_Valeur_Fonction).Assembly)
        Using frm As New Retourner_Valeur_Fonction_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.CodeEditor_Shown = Me.UseCustomVBCode
            frm.CodeEditor_Used = Me.UseCustomVBCode

            Dim sourceWriter As New IO.StringWriter()
            If Not Me.CustomVBCode Is Nothing Then CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(Me.CustomVBCode, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()
            frm.CodeEditor_Text = sourceWriter.ToString

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Return True
            Else
                Return False
            End If
            frm.Dispose()
        End Using
    End Function

    Public Overrides Function GetVBCode(ByVal FromFunction As Boolean) As System.CodeDom.CodeObject
        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            If FromFunction Then
                Return New CodeDom.CodeMethodReturnStatement(New CodeDom.CodeSnippetExpression(Me.Param1))
            Else
                Return Nothing
            End If
        End If
    End Function


    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean
        Dim i_progress, i2_progress As Integer
        i_progress = 0
        i2_progress = 0

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Retourner_Valeur_Fonction", GetType(Retourner_Valeur_Fonction).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param2 = Nothing Then Me.Param2 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30647" Then ' Fonction pouvant être lié à un évènement

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30647"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30647"))
                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' Variable n'existe plus ou est renommé
                If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(VARIABLE=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(SETTING=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(RESOURCE=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(FUNCTION=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(ENVIRONMENT=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param34 = Nothing Then Me.Param2 = Me.Param2.Replace(ErrorToResole.ErrorText.Split("'")(1), Nothing)
                If Me.Param2 = Nothing Then Me.Param2 = "Nothing"
                If Me.Param2 = ErrorToResole.ErrorText.Split("'")(1) Then Me.Param2 = Nothing
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), ErrorToResole.ErrorText.Split("'")(1))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), ErrorToResole.ErrorText.Split("'")(1))

                Return True

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
