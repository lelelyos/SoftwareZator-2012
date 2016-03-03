<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Fermer_Fenetre_Enfant_Designer))> _
Public Class Fermer_Fenetre_Enfant
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre_Enfant", GetType(Fermer_Fenetre_Enfant).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.fermer_fenetre_enfant
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre_Enfant", GetType(Fermer_Fenetre_Enfant).Assembly)
        Using frm As New Fermer_Fenetre_Enfant_Form
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre_Enfant", GetType(Fermer_Fenetre_Enfant).Assembly)
        Using frm As New Fermer_Fenetre_Enfant_Form
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
                Dim nom_var = Determine_Variable_Existe("frm")
                If Me.Param1 = "Me" Then
                    Return New CodeDom.CodeSnippetExpression("For Each " & nom_var & " As System.Windows.Forms.Form In Me.MdiChildren : If " & nom_var & ".Name = " & Me.Tools.TransformKeyVariables(Me.Param2, True) & " Then : " & nom_var & ".Close() : Exit For : End If : Next")
                Else
                    Return New CodeDom.CodeSnippetExpression("For Each " & nom_var & " As System.Windows.Forms.Form In Variables." & Me.Param1 & ".MdiChildren : If " & nom_var & ".Name = " & Me.Tools.TransformKeyVariables(Me.Param2, True) & " Then : " & nom_var & ".Close() : Exit For : End If : Next")
                End If
            Else
                Return Nothing
            End If
        End If
    End Function

    Public Overrides Function ResolveError(ByVal ErrorToResole As SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Dim result As Boolean

        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fermer_Fenetre_Enfant", GetType(Fermer_Fenetre_Enfant).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30456" Then ' Le Timer n'existe plus ou a été renommé
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30456"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30456"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

    Friend Function Determine_Variable_Existe(ByVal Nom As String) As String
        Dim varlist As Generic.IList(Of VelerSoftware.SZVB.Projet.Variable) = Me.Tools.GetCurrentProjectVariableList
        ' on cherche un nom de dossier pour le projet où l'on est sur qu'il n'existe pas, de façon à éviter les message d'erreur disant que le dossier existe déja.
        Dim RESULTAT As String = Nothing
        Dim i As Integer = 1
        Dim oki As Boolean
        Do
            For Each var As VelerSoftware.SZVB.Projet.Variable In varlist
                If var.Name = Nom & i Then oki = True : Exit For
            Next
            If Not oki Then
                RESULTAT = Nom & i
                Return RESULTAT
                Exit Function
            Else
                i = i + 1
            End If
        Loop
        Return RESULTAT
    End Function

End Class
