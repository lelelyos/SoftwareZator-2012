<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Fonction_Designer))> _
Public Class Fonction
    Inherits VelerSoftware.Plugins3.ActionWithChildren

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Fonction
            .CompatibleClass = False
            .CompatibleFonctions = False
            .FileHelp = RM.GetString("Help_File")
        End With

    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)
        Using frm As New FonctionForm
            frm.Tools = Me.Tools
            frm.Tag = Me.Added
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4
                Me.DisplayName = Me.Param1

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)
        Using frm As New FonctionForm
            frm.Tools = Me.Tools
            frm.Tag = Me.Added
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
                Me.DisplayName = Me.Param1
                Return True
            Else
                Return False
            End If
            frm.Dispose()
        End Using
    End Function

    Public Overrides Function GetVBCode(ByVal FromFunction As Boolean) As System.CodeDom.CodeObject
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)

        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            If FromFunction Then
                Dim method As System.CodeDom.CodeMemberMethod = New System.CodeDom.CodeMemberMethod()
                method.Name = Me.Param1
                method.Comments.Add(New CodeDom.CodeCommentStatement(RM.GetString("DisplayName") & " " & Me.Param1))
                If Me.Param4 IsNot Nothing Then
                    If CBool(Me.Param4) Then
                        method.ReturnType = New System.CodeDom.CodeTypeReference("System.Object")
                        method.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Static
                    Else
                        method.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                    End If
                Else
                    method.Attributes = CodeDom.MemberAttributes.Public Or CodeDom.MemberAttributes.Final
                End If
                If Me.Param2 IsNot Nothing Then
                    If Me.Param3 IsNot Nothing Then
                        For Each strr As String In Me.Param3.Split(",")
                            strr = strr.Trim(" ")
                            method.Parameters.Add(New System.CodeDom.CodeParameterDeclarationExpression(strr.Split(" ")(3), strr.Split(" ")(1)))
                        Next
                    End If
                Else
                    If Me.Param3 IsNot Nothing Then
                        For Each strr As String In Me.Param3.Split(";")
                            method.Parameters.Add(New System.CodeDom.CodeParameterDeclarationExpression("System.Object", strr))
                        Next
                    End If
                End If

                Return method
            Else
                Return Nothing
            End If
        End If
    End Function






    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30451" Then ' Fonction lié à un contrôle qui n'existe plus
                If Me.Param2 IsNot Nothing Then
                    Me.Param2 = Nothing
                    If Me.Param3 IsNot Nothing Then
                        Dim para As String = Nothing
                        For Each strr As String In Me.Param3.Split(",")
                            para &= strr.TrimStart(" ").Replace("ByVal ", Nothing).Replace("ByRef ", Nothing).Split(" ")(0) & ";"
                        Next
                        Me.Param3 = para.TrimEnd(";")
                    End If

                    ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), Me.Param1, ErrorToResole.ErrorText.Split("'")(1))
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), Me.Param1)
                    Return True
                End If

            ElseIf ErrorToResole.ErrorNumber = "BC30260" Then ' Le nom de la fonction est en conflit avec un contrôle, variable, ressource, paramètre ou aurte fonction   
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30260"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30260"), Me.Param1)
                Me.Param1 &= "_Function_"
                ' Génération de l'ID
                For i = 0 To 5 - 1
                    Randomize()
                    Me.Param1 = Me.Param1 & Mid("abcdefghijklmnopqrstuvwxyz", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz")) + 1, 1)
                Next
                Me.DisplayName = Me.Param1

                Return True

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
