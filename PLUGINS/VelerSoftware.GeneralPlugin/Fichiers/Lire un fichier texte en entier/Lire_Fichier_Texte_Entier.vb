﻿<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Entier_Designer))> _
Public Class Lire_Fichier_Texte_Entier
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Entier", GetType(Lire_Fichier_Texte_Entier).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Lire_Fichier_Texte_Entier
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Entier", GetType(Lire_Fichier_Texte_Entier).Assembly)
        Using frm As New Lire_Fichier_Texte_Entier_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Entier", GetType(Lire_Fichier_Texte_Entier).Assembly)
        Using frm As New Lire_Fichier_Texte_Entier_Form
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.CodeEditor_Shown = Me.UseCustomVBCode
            frm.CodeEditor_Used = Me.UseCustomVBCode
            frm.Tools = Me.Tools

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
                If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param2), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("_computer.FileSystem"), "ReadAllText", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Text.Encoding"), Me.Param3)))
                Else
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param2), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("My.Computer.FileSystem"), "ReadAllText", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodePropertyReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Text.Encoding"), Me.Param3)))
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Entier", GetType(Lire_Fichier_Texte_Entier).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param1 = Nothing Then Me.Param1 = Me.Param1.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                        If Not Me.Param2 = Nothing Then Me.Param2 = Me.Param2.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param1 = Nothing Then Me.Param1 = " "
                If Me.Param2 = Nothing Then Me.Param2 = " "

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30452"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30452"))
                Return True

            ElseIf ErrorToResole.ErrorNumber = "BC32017" Then ' La variable recevant le résultat n'existe plus
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC32017"))
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC32017"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
