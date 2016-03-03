<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Sortie_Boucle_Designer))> _
Public Class Sortie_Boucle
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Sortie_Boucle", GetType(Sortie_Boucle).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.sortir_boucle
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean

        Dim oki As Boolean
        For Each act As VelerSoftware.Plugins3.Action In Me.Tools.GetParentsAction(Me)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Boucle_Limitee OrElse TypeOf act Is VelerSoftware.GeneralPlugin.Boucle OrElse TypeOf act Is VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne Then
                oki = True
                Exit For
            End If
        Next

        If Not oki Then
            ' Initialisation de la langue et des ressources
            System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
            RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Sortie_Boucle", GetType(Sortie_Boucle).Assembly)
            MsgBox(RM.GetString("Error_Explain_BC30089"), MsgBoxStyle.Information)
            Return False
        End If

        Return True
    End Function

    Public Overrides Function Modify() As Boolean
        Return False
    End Function

    Public Overrides Function GetVBCode(ByVal FromFunction As Boolean) As System.CodeDom.CodeObject
        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            If FromFunction Then
                Return New CodeDom.CodeSnippetStatement("Exit Do")
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Sortie_Boucle", GetType(Sortie_Boucle).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30089" Then
                ErrorToResole.ErrorExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Explain_BC30089"), Me.Param1)
                ErrorToResole.ErrorSolutionExplain = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Error_Solution_Explain_BC30089"))

                Return False

            Else
                Return False

            End If

        End If

        Return result
    End Function

End Class