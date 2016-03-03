<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Si_Alors_Sinon_Designer))> _
Public Class Si_Alors_Sinon
    Inherits VelerSoftware.Plugins3.ActionWithChildren

    Private _Children_Actions2 As System.Collections.Generic.List(Of VelerSoftware.Plugins3.Action)
    ''' <summary>
    ''' Obtient ou définit les actions enfants contenu dans le designer d'action (ActivityDesigner) si celui-ci donne la possibilité d'ajouter des actions enfants.
    ''' </summary>
    Public Overridable Overloads Property Children_Actions2 As System.Collections.Generic.List(Of VelerSoftware.Plugins3.Action)
        Get
            If Me._Children_Actions2 Is Nothing Then Me._Children_Actions2 = New System.Collections.Generic.List(Of VelerSoftware.Plugins3.Action)
            Return Me._Children_Actions2
        End Get
        Set(ByVal value As System.Collections.Generic.List(Of VelerSoftware.Plugins3.Action))
            Me._Children_Actions2 = value
        End Set
    End Property

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.si_alors_sinon
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary4"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)
        Using frm As New Si_Alors_Sinon_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)
        Using frm As New Si_Alors_Sinon_Form
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
                Dim codecond As New CodeDom.CodeConditionStatement()
                Select Case CInt(Me.Param2)
                    Case 0
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.ValueEquality, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 1
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 2
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.LessThanOrEqual, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 3
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.GreaterThan, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 4
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.GreaterThanOrEqual, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 5
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.IdentityInequality, New CodeDom.CodeSnippetExpression(Me.Param3))
                    Case 6
                        codecond.Condition = New CodeDom.CodeBinaryOperatorExpression(New CodeDom.CodeVariableReferenceExpression(Me.Param1), CodeDom.CodeBinaryOperatorType.IdentityEquality, New CodeDom.CodeSnippetExpression(Me.Param3))
                End Select

                Return codecond
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30020" Then ' Opérateur "Is" incorrecte
                Me.Param2 = 0
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30020"), Me.Param2.Replace("0", "=").Replace("1", "<").Replace("2", "<=").Replace("3", ">").Replace("4", "=>").Replace("5", "<>").Replace("6", "<=>"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30020"), Me.Param2.Replace("0", "=").Replace("1", "<").Replace("2", "<=").Replace("3", ">").Replace("4", "=>").Replace("5", "<>").Replace("6", "<=>"))

                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30452" Then ' Opérateur "=" incorrecte avec une variable tableau
                Me.Param2 = 6
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"), Me.Param2.Replace("0", "=").Replace("1", "<").Replace("2", "<=").Replace("3", ">").Replace("4", "=>").Replace("5", "<>").Replace("6", "<=>"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"), Me.Param2.Replace("0", "=").Replace("1", "<").Replace("2", "<=").Replace("3", ">").Replace("4", "=>").Replace("5", "<>").Replace("6", "<=>"))

                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30518" Then ' Valeur incompatible (ex : si variable tableau = "texte")
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30518"), Me.Param1, Me.Param3)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30518"), Me.Param1, Me.Param3)

                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' Variable n'existe plus ou est renommé
                If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(VARIABLE=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(SETTING=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(RESOURCE=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(FUNCTION=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param4 = Nothing Then Me.Param4 = Me.Param4.Replace("%(ENVIRONMENT=" & ErrorToResole.ErrorText.Split("'")(1) & ")%", Nothing)
                If Not Me.Param34 = Nothing Then Me.Param4 = Me.Param4.Replace(ErrorToResole.ErrorText.Split("'")(1), Nothing)
                If Me.Param4 = Nothing Then Me.Param4 = "Nothing"
                If Me.Param1 = ErrorToResole.ErrorText.Split("'")(1) Then Me.Param1 = Nothing
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
