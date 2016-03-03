<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Quitter_Application_Designer))> _
Public Class Quitter_Application
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Quitter_Application", GetType(Quitter_Application).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.arreterapplicationSmall
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Quitter_Application", GetType(Quitter_Application).Assembly)

        Dim tip As SZVB.Projet.Projet.Types = Tools.GetCurrentProjectType

        If tip = SZVB.Projet.Projet.Types.ApplicationWindows OrElse tip = SZVB.Projet.Projet.Types.ApplicationConsole Then
            Return True
        Else
            MsgBox(RM.GetString("Pas_Compatible"), MsgBoxStyle.Exclamation)
            Return False
        End If
    End Function

    Public Overrides Function Modify() As Boolean
        Return False
    End Function

    Public Overrides Function GetVBCode(ByVal FromFunction As Boolean) As System.CodeDom.CodeObject
        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            If FromFunction Then
                Return New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("System.Windows.Forms.Application"), "Exit"))
            Else
                Return Nothing
            End If
        End If
    End Function

End Class