<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Run_PowerShell_Command_Designer))> _
Public Class Run_PowerShell_Command
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Run_PowerShell_Command", GetType(Run_PowerShell_Command).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Run_PowerShell_Command
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))

            .ClassCode = "VelerSoftware.GeneralPlugin.Run_PowerShell_Command.vb"

            For Each ref As VelerSoftware.SZVB.Projet.Reference In .GetGACAssemblyList()
                If ref.Name = "System.Management.Automation" Then
                    .References.Add(ref.FullName)
                    Exit For
                End If
            Next
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Run_PowerShell_Command", GetType(Run_PowerShell_Command).Assembly)
        Using frm As New Run_PowerShell_Command_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Run_PowerShell_Command", GetType(Run_PowerShell_Command).Assembly)
        Using frm As New Run_PowerShell_Command_Form
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
                If Me.Param3 = Nothing Then
                    Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "RunPowerShellCommand", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodePrimitiveExpression(Me.Param2))
                    Return MsgBoxStatement
                Else
                    Dim VariableStatement As New CodeDom.CodeVariableReferenceExpression(Me.Param3)
                    Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_GeneralPlugin"), "RunPowerShellCommand", New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Me.Param1, True)), New CodeDom.CodePrimitiveExpression(Me.Param2))
                    Dim OperationStatement As New CodeDom.CodeAssignStatement(VariableStatement, MsgBoxStatement)
                    Return OperationStatement
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Run_PowerShell_Command", GetType(Run_PowerShell_Command).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30311" Then ' La variable recevant le résultat est devenu une variable tableau 
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30311"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30311"))

                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' La variable n'existe plus 
                Dim nom_variable As String = ErrorToResole.ErrorText.Split("'")(1)
                Dim oki, problème_corrigé As Boolean

                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), nom_variable)

                If Me.Param1.Contains("%(VARIABLE=" & nom_variable & ")%") OrElse Me.Param3.Contains("%(VARIABLE=" & nom_variable & ")%") Then
                    For Each var As VelerSoftware.SZVB.Projet.Variable In Tools.GetCurrentProjectVariableList
                        If var.Name = nom_variable Then oki = True
                    Next
                    If Not oki Then Tools.GetCurrentProjectVariableList.Add(New VelerSoftware.SZVB.Projet.Variable(nom_variable, False, Nothing, Nothing)) : problème_corrigé = True
                End If
                oki = False
                For Each var As VelerSoftware.SZVB.Projet.Variable In Tools.GetCurrentProjectVariableList
                    If var.Name = Me.Param3 Then oki = True
                Next
                If Not oki Then Tools.GetCurrentProjectVariableList.Add(New VelerSoftware.SZVB.Projet.Variable(nom_variable, False, Nothing, Nothing)) : problème_corrigé = True

                If problème_corrigé Then
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), nom_variable)
                    Return True
                Else
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30311"))
                    Return False
                End If


            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
