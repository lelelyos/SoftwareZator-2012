<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle_Designer))> _
Public Class Modifier_Propriete_Contrôle
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle", GetType(Modifier_Propriete_Contrôle).Assembly)

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle", GetType(Modifier_Propriete_Contrôle).Assembly)
        Using frm As New Modifier_Propriete_Contrôle_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle", GetType(Modifier_Propriete_Contrôle).Assembly)
        Using frm As New Modifier_Propriete_Contrôle_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
            frm.Param5 = Me.Param5
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
                    OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param2.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.Param4))
                ElseIf Me.Param1.StartsWith("Me.") Then
                    OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodeFieldReferenceExpression(New CodeDom.CodeThisReferenceExpression(), Me.Param1.Substring(3).Split(" ")(0) & "." & Me.Param2.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.Param4))
                Else
                    OperationStatement = New CodeDom.CodeAssignStatement(New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeVariableReferenceExpression("Variables." & Me.Param1.Split("(")(0).Trim(" ")), Me.Param2.Split(" ")(0)), New CodeDom.CodeSnippetExpression(Me.Param4))
                End If
                Return OperationStatement
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle", GetType(Modifier_Propriete_Contrôle).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30311" Then ' La variable de retour est une variable tableau
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30456"), Me.Param2)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30456"))
                
                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30456" Then ' Le Timer n'existe plus ou a été renommé
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
