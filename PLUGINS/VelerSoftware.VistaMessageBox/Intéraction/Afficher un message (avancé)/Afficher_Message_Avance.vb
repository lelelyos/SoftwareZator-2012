<System.ComponentModel.Designer(GetType(VelerSoftware.VistaMessageBox.Afficher_Message_Avance_Designer))> _
Public Class Afficher_Message_Avance
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.VistaMessageBox.Afficher_Message_Avance", GetType(Afficher_Message_Avance).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.application_error
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))

            .References.Add("VelerSoftware.VistaMessageBoxLib.dll")
            .ClassCode = "VelerSoftware.VistaMessageBoxLib.vb"
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.VistaMessageBox.Afficher_Message_Avance", GetType(Afficher_Message_Avance).Assembly)
        Using frm As New Afficher_Message_Avance_Form
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
                Me.Param10 = frm.Param10
                Me.Param11 = frm.Param11
                Me.Param12 = frm.Param12
                Me.Param13 = frm.Param13

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
        RM = New System.Resources.ResourceManager("VelerSoftware.VistaMessageBox.Afficher_Message_Avance", GetType(Afficher_Message_Avance).Assembly)
        Using frm As New Afficher_Message_Avance_Form
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
            frm.Param10 = Me.Param10
            frm.Param11 = Me.Param11
            frm.Param12 = Me.Param12
            frm.Param13 = Me.Param13
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
                Me.Param10 = frm.Param10
                Me.Param11 = frm.Param11
                Me.Param12 = frm.Param12
                Me.Param13 = frm.Param13
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
                Dim method As CodeDom.CodeMethodInvokeExpression

                If Me.Param1 = "Me" Then
                    method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeThisReferenceExpression, New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param2, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param3, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param4, True, False)), New CodeDom.CodeSnippetExpression(Param5), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param6, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Me.Param7)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param8, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Param9)), New CodeDom.CodeSnippetExpression(Param10), New CodeDom.CodeSnippetExpression(Param11), New CodeDom.CodePrimitiveExpression(CBool(Param12)))
                ElseIf Not Me.Param1 = "" Then
                    method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.Param1), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param2, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param3, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param4, True, False)), New CodeDom.CodeSnippetExpression(Param5), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param6, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Me.Param7)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param8, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Param9)), New CodeDom.CodeSnippetExpression(Param10), New CodeDom.CodeSnippetExpression(Param11), New CodeDom.CodePrimitiveExpression(CBool(Param12)))
                Else
                    method = New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_VistaMessageBox"), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param2, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param3, True, False)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param4, True, False)), New CodeDom.CodeSnippetExpression(Param5), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param6, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Me.Param7)), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param8, True, False)), New CodeDom.CodePrimitiveExpression(CBool(Param9)), New CodeDom.CodeSnippetExpression(Param10), New CodeDom.CodeSnippetExpression(Param11), New CodeDom.CodePrimitiveExpression(CBool(Param12)))
                End If

                If Me.Param13 = Nothing Then
                    Return method
                Else
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param13), method)
                End If
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.VistaMessageBox.Afficher_Message_Avance", GetType(Afficher_Message_Avance).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30451" Then ' 'Nom_Variable' n'est pas déclaré. Il peut être inaccessible en raison de son niveau de protection.
                Dim nom_variable As String = ErrorToResole.ErrorText.Split("'")(1)
                Dim oki, problème_corrigé As Boolean
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), nom_variable)
                If Me.Param2.Contains("%(VARIABLE=" & nom_variable & ")%") Then
                    For Each var As VelerSoftware.SZVB.Projet.Variable In Tools.GetCurrentProjectVariableList
                        If var.Name = nom_variable Then oki = True
                    Next
                    If Not oki Then Tools.GetCurrentProjectVariableList.Add(New VelerSoftware.SZVB.Projet.Variable(nom_variable, False, Nothing, Nothing)) : problème_corrigé = True
                End If
                If problème_corrigé Then
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), nom_variable)
                    Return True
                Else
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451_1"))
                    Return False
                End If


            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
