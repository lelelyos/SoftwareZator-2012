﻿<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Afficher_Menu_Contextuel_Designer))> _
Public Class Afficher_Menu_Contextuel
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Afficher_Menu_Contextuel", GetType(Afficher_Menu_Contextuel).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.afficher_contextmenustrip
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Afficher_Menu_Contextuel", GetType(Afficher_Menu_Contextuel).Assembly)
        Using frm As New Afficher_Menu_Contextuel_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Afficher_Menu_Contextuel", GetType(Afficher_Menu_Contextuel).Assembly)
        Using frm As New Afficher_Menu_Contextuel_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
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
                If Not Me.Param2 = Nothing Then
                    If Me.Param1.StartsWith("Me.") Then
                        If Me.Param2.StartsWith("Me.") Then
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Substring(3)), "Show"), New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param2.Substring(3).Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        ElseIf Me.Param2.StartsWith("Me ") Then
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Me"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        Else
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.Param2.Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        End If
                    Else
                        If Me.Param2.StartsWith("Me.") OrElse Me.Param2.StartsWith("Me ") Then
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Param1), "Show"), New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param2.Substring(3).Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        ElseIf Me.Param2.StartsWith("Me ") Then
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Param1), "Show"), New CodeDom.CodeSnippetExpression("Me"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        Else
                            Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Param1), "Show"), New CodeDom.CodeSnippetExpression("Variables." & Me.Param2.Split(" ")(0)), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                        End If
                    End If
                Else
                    If Me.Param1.StartsWith("Me.") Then
                        Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Substring(3)), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                    Else
                        Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Variables." & Me.Param1), "Show"), New CodeDom.CodeSnippetExpression("Nothing"), New CodeDom.CodeSnippetExpression("New System.Drawing.Point(" & Me.Tools.TransformKeyVariables(Me.Param3, False, False) & ", " & Me.Tools.TransformKeyVariables(Me.Param4, False, False) & ")"))
                    End If
                End If
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Afficher_Menu_Contextuel", GetType(Afficher_Menu_Contextuel).Assembly)

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
