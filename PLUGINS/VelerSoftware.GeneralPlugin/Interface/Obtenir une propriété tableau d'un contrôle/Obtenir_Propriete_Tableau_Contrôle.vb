<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Obtenir_Propriete_Tableau_Contrôle_Designer))> _
Public Class Obtenir_Propriete_Tableau_Contrôle
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Propriete_Tableau_Contrôle", GetType(Obtenir_Propriete_Tableau_Contrôle).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.obtenir_propriété_controle
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Propriete_Tableau_Contrôle", GetType(Obtenir_Propriete_Tableau_Contrôle).Assembly)
        Using frm As New Obtenir_Propriete_Tableau_Contrôle_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Propriete_Tableau_Contrôle", GetType(Obtenir_Propriete_Tableau_Contrôle).Assembly)
        Using frm As New Obtenir_Propriete_Tableau_Contrôle_Form
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
                Dim OperationStatement As CodeDom.CodeAssignStatement
                If Me.Param1.StartsWith("Me ") Then
                    If Me.Param2.EndsWith("[])") Then
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Me." & Me.Param2.Split(" ")(0) & ")))"))
                    Else
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Me." & Me.Param2.Split(" ")(0) & "))"))
                    End If
                ElseIf Me.Param1.StartsWith("Me.") Then
                    If Me.Param2.EndsWith("[])") Then
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Me." & Me.Param1.Substring(3).Split(" ")(0) & "." & Me.Param2.Split(" ")(0) & ")))"))
                    Else
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Me." & Me.Param1.Substring(3).Split(" ")(0) & "." & Me.Param2.Split(" ")(0) & "))"))
                    End If
                Else
                    If Me.Param2.EndsWith("[])") Then
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(System.Linq.Enumerable.AsEnumerable(Variables." & Me.Param1.Substring(3).Split(" ")(0) & "." & Me.Param2.Split(" ")(0) & ")))"))
                    Else
                        OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param3), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Variables." & Me.Param1.Substring(3).Split(" ")(0) & "." & Me.Param2.Split(" ")(0) & "))"))
                    End If
                End If
                Return OperationStatement
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
