<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Obtenir_Argument_Demarrage_Designer))> _
Public Class Obtenir_Argument_Demarrage
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Argument_Demarrage", GetType(Obtenir_Argument_Demarrage).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.obtenir_argument_demarrage
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary4"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary5"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression4"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Argument_Demarrage", GetType(Obtenir_Argument_Demarrage).Assembly)

        Dim tip As SZVB.Projet.Projet.Types = Tools.GetCurrentProjectType

        If tip = SZVB.Projet.Projet.Types.ApplicationWindows OrElse tip = SZVB.Projet.Projet.Types.ApplicationConsole Then
            Using frm As New Obtenir_Argument_Demarrage_Form
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
        Else
            MsgBox(RM.GetString("Pas_Compatible"), MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function

    Public Overrides Function Modify() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Argument_Demarrage", GetType(Obtenir_Argument_Demarrage).Assembly)
        Using frm As New Obtenir_Argument_Demarrage_Form
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
                If Me.Param2 = "Startup|ApplicationEvents.szc" OrElse Me.Param2 = "StartupNextInstance|ApplicationEvents.szc" Then
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param1), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of System.Object)(DirectCast(_e, Microsoft.VisualBasic.ApplicationServices." & Me.Param2.Split("|")(0) & "EventArgs).CommandLine)"))
                Else
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param1), New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of System.Object)(System.Environment.GetCommandLineArgs())"))
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Argument_Demarrage", GetType(Obtenir_Argument_Demarrage).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30451" Then ' La variable n'existe plus 
                Dim oki As Boolean
                For Each var As VelerSoftware.SZVB.Projet.Variable In Tools.GetCurrentProjectVariableList
                    If var.Name = Me.Param1 Then oki = True
                Next
                If Not oki Then Tools.GetCurrentProjectVariableList.Add(New VelerSoftware.SZVB.Projet.Variable(Me.Param1, True, Nothing, Nothing))
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), Me.Param1)

                Return True

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
