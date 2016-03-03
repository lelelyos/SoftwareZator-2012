<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Executer_Fonction_Projet_Designer))> _
Public Class Executer_Fonction_Projet
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Executer_Fonction_Projet", GetType(Executer_Fonction_Projet).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.execute_function
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Executer_Fonction_Projet", GetType(Executer_Fonction_Projet).Assembly)
        Using frm As New Executer_Fonction_Projet_Form
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
    End Function

    Public Overrides Function Modify() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Executer_Fonction_Projet", GetType(Executer_Fonction_Projet).Assembly)
        Using frm As New Executer_Fonction_Projet_Form
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
                If Not Me.Param3 = Nothing Then
                    If Me.Param1.StartsWith(Me.Tools.GetCurrentProjectName & ".Me") Then
                        Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2)))
                    ElseIf Me.Param1.StartsWith(Me.Tools.GetCurrentProjectName & ".") Then
                        Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Param1.Replace(Me.Tools.GetCurrentProjectName & ".", "Variables.").Replace("." & Me.Param1.Split(".")(2), Nothing)), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2)))
                    Else
                        Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Param1.Replace("." & Me.Param1.Split(".")(2), Nothing)), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2)))
                    End If
                Else
                    If Me.Param1.StartsWith(Me.Tools.GetCurrentProjectName & ".Me") Then
                        Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2))
                    ElseIf Me.Param1.StartsWith(Me.Tools.GetCurrentProjectName & ".") Then
                        Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Param1.Replace(Me.Tools.GetCurrentProjectName & ".", "Variables.").Replace("." & Me.Param1.Split(".")(2), Nothing)), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2))
                    Else
                        Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression(Me.Param1.Replace("." & Me.Param1.Split(".")(2), Nothing)), Me.Param1.Split(".")(2)), New CodeDom.CodeSnippetExpression(Me.Param2))
                    End If
                End If
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
