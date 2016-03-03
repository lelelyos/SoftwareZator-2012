<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Envoyer_Email_Designer))> _
Public Class Envoyer_Email
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Envoyer_Email", GetType(Envoyer_Email).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Envoyer_Email
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))

            .ClassCode = "VelerSoftware.GeneralPlugin.Envoyer_Email.vb"
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Envoyer_Email", GetType(Envoyer_Email).Assembly)
        Using frm As New Envoyer_Email_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4
                Me.Param5 = frm.Param5
                Me.Param6 = frm.Param6
                Me.Param7 = frm.Param7
                Me.Param8 = frm.Param8
                Me.Param9 = frm.Param9

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Envoyer_Email", GetType(Envoyer_Email).Assembly)
        Using frm As New Envoyer_Email_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
            frm.Param5 = Me.Param5
            frm.Param6 = Me.Param6
            frm.Param7 = Me.Param7
            frm.Param8 = Me.Param8
            frm.Param9 = Me.Param9
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
                Me.Param4 = frm.Param4
                Me.Param5 = frm.Param5
                Me.Param6 = frm.Param6
                Me.Param7 = frm.Param7
                Me.Param8 = frm.Param8
                Me.Param9 = frm.Param9
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
                If Me.Param5 = "" OrElse Me.Param5 = Nothing Then
                    Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Envoyer_Email", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param2, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param3, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param4, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param5, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param6, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param7, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param8, True)))
                Else
                    Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Param9)
                    Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "Envoyer_Email", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param2, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param3, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param4, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param5, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param6, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param7, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param8, True)))
                    Return New CodeDom.CodeAssignStatement(VariableStatement, MsgBoxStatement)
                End If
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Envoyer_Email", GetType(Envoyer_Email).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30518" Then ' L'un des paramètres est nul
                If Me.Param1 = Nothing Then Me.Param1 = " "
                If Me.Param2 = Nothing Then Me.Param2 = " "
                If Me.Param3 = Nothing Then Me.Param3 = " "
                If Me.Param4 = Nothing Then Me.Param4 = " "
                If Me.Param5 = Nothing Then Me.Param5 = " "
                If Me.Param6 = Nothing Then Me.Param6 = " "
                If Me.Param7 = Nothing Then Me.Param7 = " "
                If Me.Param8 = Nothing Then Me.Param8 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30518"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30518"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param1 = Nothing Then Me.Param1 = Me.Param1.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param3 = Nothing Then Me.Param3 = Me.Param3.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param5 = Nothing Then Me.Param5 = Me.Param5.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param6 = Nothing Then Me.Param6 = Me.Param6.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param7 = Nothing Then Me.Param7 = Me.Param7.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param8 = Nothing Then Me.Param8 = Me.Param8.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param1 = Nothing Then Me.Param1 = " "
                If Me.Param2 = Nothing Then Me.Param2 = " "
                If Me.Param3 = Nothing Then Me.Param3 = " "
                If Me.Param4 = Nothing Then Me.Param4 = " "
                If Me.Param5 = Nothing Then Me.Param5 = " "
                If Me.Param6 = Nothing Then Me.Param6 = " "
                If Me.Param7 = Nothing Then Me.Param7 = " "
                If Me.Param8 = Nothing Then Me.Param8 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30311" Then ' La variable recevant le résultat est devenu une variable tableau 
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30311"), Me.Param5)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30311"))
                Me.Param5 = Nothing

                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' La variable recevant le résultat n'existe plus
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), Me.Param5)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"))
                Me.Param5 = Nothing

                Return True

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
