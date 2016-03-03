<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Obtenir_Liste_Fichier_Dossier_Designer))> _
Public Class Obtenir_Liste_Fichier_Dossier
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Liste_Fichier_Dossier", GetType(Obtenir_Liste_Fichier_Dossier).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.obtenir_liste_fichier_dossier
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression4"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression5"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression6"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Liste_Fichier_Dossier", GetType(Obtenir_Liste_Fichier_Dossier).Assembly)
        Using frm As New Obtenir_Liste_Fichier_Dossier_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4
                Me.Param5 = frm.Param5

                Return True
            Else
                Return False
            End If
            frm.Dispose()
        End Using
    End Function

    Public Overrides Function Modify() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Liste_Fichier_Dossier", GetType(Obtenir_Liste_Fichier_Dossier).Assembly)
        Using frm As New Obtenir_Liste_Fichier_Dossier_Form
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
            frm.Param5 = Me.Param5
            frm.CodeEditor_Shown = Me.UseCustomVBCode
            frm.CodeEditor_Used = Me.UseCustomVBCode
            frm.Tools = Me.Tools

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
                Me.Param4 = frm.Param4
                Me.Param5 = frm.Param5
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
                Dim searchOpt As String
                Dim searchTyp As String

                If CBool(Me.Param2) Then
                    searchOpt = "System.IO.SearchOption.AllDirectories"
                Else
                    searchOpt = "System.IO.SearchOption.TopDirectoryOnly"
                End If

                If CBool(Me.Param3) Then
                    searchTyp = "GetFiles"
                Else
                    searchTyp = "GetDirectories"
                End If

                Dim sourceWriter As New IO.StringWriter()

                Dim MsgBoxStatement As New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.IO.Directory." & searchTyp & "(" & Tools.TransformKeyVariables(Me.Param1, True) & ", " & Tools.TransformKeyVariables(Me.Param4, True) & ", " & searchOpt & "))")
                Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param5), MsgBoxStatement)

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Liste_Fichier_Dossier", GetType(Obtenir_Liste_Fichier_Dossier).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param1 = Nothing Then Me.Param1 = Me.Param1.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param1 = Nothing Then Me.Param1 = " "
                If Me.Param4 = Nothing Then Me.Param4 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC32017" Then ' La variable recevant le résultat n'existe plus
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC32017"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC32017"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
