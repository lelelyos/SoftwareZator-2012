<System.ComponentModel.Designer(GetType(VelerSoftware.SQLServerPlugin.Se_connecter_serveur_SQL_Server_Designer))> _
Public Class Se_connecter_serveur_SQL_Server
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.SQLServerPlugin.Se_connecter_serveur_SQL_Server", GetType(Se_connecter_serveur_SQL_Server).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.connect
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))

            .ClassCode = "VelerSoftware.SQLServerPlugin.vb"
            .References.Add("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.SQLServerPlugin.Se_connecter_serveur_SQL_Server", GetType(Se_connecter_serveur_SQL_Server).Assembly)
        Using frm As New Se_connecter_serveur_SQL_Server_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4
                Me.Param5 = frm.Param5
                Me.Param6 = frm.Param6
                Me.Param7 = frm.Param7
                Me.Param8 = frm.Param8

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
        RM = New System.Resources.ResourceManager("VelerSoftware.SQLServerPlugin.Se_connecter_serveur_SQL_Server", GetType(Se_connecter_serveur_SQL_Server).Assembly)
        Using frm As New Se_connecter_serveur_SQL_Server_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
            frm.Param5 = Me.Param5
            frm.Param6 = Me.Param6
            frm.Param7 = Me.Param7
            frm.Param8 = Me.Param8
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
                Me.Param6 = frm.Param6
                Me.Param7 = frm.Param7
                Me.Param8 = frm.Param8
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
                Dim MsgBoxStatement As New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeTypeReferenceExpression("VelerSoftware_SQLServerPlugin"), "Connect_SQLServer", New CodeDom.CodePrimitiveExpression(Param1), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Param2, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Param3, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Param4, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Param5, True)), New CodeDom.CodeSnippetExpression(Tools.TransformKeyVariables(Param8, True)), New CodeDom.CodePrimitiveExpression(CBool(Param6).ToString.Replace("True", "yes").Replace("False", "no")))
                If Me.Param7 = Nothing Then
                    Return MsgBoxStatement
                Else
                    Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Param7), MsgBoxStatement)
                End If
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.SQLServerPlugin.Se_connecter_serveur_SQL_Server", GetType(Se_connecter_serveur_SQL_Server).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30456" Then ' Le Timer n'existe plus ou a été renommé
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30456"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30456"))

                Return False

            ElseIf ErrorToResole.ErrorNumber = "BC30451" Then ' 'Nom_Variable' n'est pas déclaré. Il peut être inaccessible en raison de son niveau de protection.
                Dim nom_variable As String = ErrorToResole.ErrorText.Split("'")(1)
                Dim oki, problème_corrigé As Boolean
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30451"), nom_variable)
                For Each var As VelerSoftware.SZVB.Projet.Variable In Tools.GetCurrentProjectVariableList
                    If var.Name = nom_variable Then oki = True
                Next
                If Not oki Then Tools.GetCurrentProjectVariableList.Add(New VelerSoftware.SZVB.Projet.Variable(nom_variable, False, Nothing, Nothing)) : problème_corrigé = True
                If problème_corrigé Then
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451"), nom_variable)
                    Return True
                Else
                    ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30451_1"))
                    Return False
                End If


            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class
