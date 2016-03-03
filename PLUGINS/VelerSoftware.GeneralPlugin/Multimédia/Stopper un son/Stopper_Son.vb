<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Stopper_Son_Designer))> _
Public Class Stopper_Son
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Stopper_Son", GetType(Stopper_Son).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Stopper_Son
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
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
                If Tools.GetCurrentProjectType = SZVB.Projet.Projet.Types.ApplicationWindows Then
                    Return New CodeDom.CodeSnippetExpression("_computer.Audio.Stop()")
                Else
                    Return New CodeDom.CodeSnippetExpression("My.Computer.Audio.Stop()")
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Stopper_Son", GetType(Stopper_Son).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            Return False

        End If

        Return result
    End Function

End Class
