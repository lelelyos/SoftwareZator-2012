<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Calcul_Designer))> _
Public Class Calcul
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Calcul", GetType(Calcul).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Calcul
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary4"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary5"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary6"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Calcul", GetType(Calcul).Assembly)
        Using frm As New Calcul_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Calcul", GetType(Calcul).Assembly)
        Using frm As New Calcul_Form
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
                Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param2), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param1.Replace("√", "System.Math.Sqrt").Replace("π", "System.Math.PI").Replace("Trunc", "System.Math.Truncate").Replace(" Cosˉ¹(", " System.Math.ACos(").Replace(" Cos(", " System.Math.Cos(").Replace(" Sinˉ¹(", " System.Math.ASin(").Replace(" Sin(", " System.Math.Sin(").Replace(" Tanˉ¹(", " System.Math.ATan(").Replace(" Tan(", " System.Math.Tan(").Replace("Round", " System.Math.Round").Replace("Rest", "System.Math.IEEERemainder").Replace("Sign", "System.Math.Sign").Replace("AMax", "System.Math.Ceiling").Replace("AMin", "System.Math.Floor").Replace("Max", "System.Math.Max").Replace("Min", "System.Math.Min").Replace("%(", "CInt(%(").Replace(")%", ")%)"), False, False)))
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Calcul", GetType(Calcul).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param1 = Nothing Then Me.Param1 = Me.Param1.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param1 = Nothing Then Me.Param1 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC30311" Then ' La variable recevant le résultat est devenu une variable tableau 
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30311"), Me.Param5)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30311"))

                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' La variable recevant le résultat n'existe plus
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), Me.Param5)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
