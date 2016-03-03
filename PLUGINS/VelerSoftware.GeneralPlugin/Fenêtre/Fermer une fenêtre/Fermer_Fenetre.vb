<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Fermer_Fenetre_Designer))> _
Public Class Fermer_Fenetre
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre", GetType(Fermer_Fenetre).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.fermer_fenetre
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre", GetType(Fermer_Fenetre).Assembly)
        Using frm As New Fermer_Fenetre_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre", GetType(Fermer_Fenetre).Assembly)
        Using frm As New Fermer_Fenetre_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
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
                If Me.Param1 = "Me" Then
                    If CInt(Me.Param2) = 0 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.None : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 1 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.OK : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 2 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Cancel : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 3 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Yes : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 4 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.No : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 5 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Abort : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 6 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Retry : " & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 7 Then
                        Return New CodeDom.CodeSnippetExpression(Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Ignore : " & Me.Param1 & ".Close()")
                    End If
                Else
                    If CInt(Me.Param2) = 0 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.None : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 1 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.OK : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 2 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Cancel : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 3 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Yes : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 4 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.No : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 5 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Abort : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 6 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Retry : Variables." & Me.Param1 & ".Close()")
                    ElseIf CInt(Me.Param2) = 7 Then
                        Return New CodeDom.CodeSnippetExpression("Variables." & Me.Param1 & ".DialogResult = System.Windows.Forms.DialogResult.Ignore : Variables." & Me.Param1 & ".Close()")
                    End If
                End If

                Return Nothing
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre", GetType(Fermer_Fenetre).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30456" Then ' Le Timer n'existe plus ou a été renommé
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30456"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30456"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
