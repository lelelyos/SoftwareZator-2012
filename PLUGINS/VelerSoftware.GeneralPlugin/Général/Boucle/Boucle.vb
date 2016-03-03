<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Boucle_Designer))> _
Public Class Boucle
    Inherits VelerSoftware.Plugins3.ActionWithChildren

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle", GetType(Boucle).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.boucle
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
                Dim codeWhile As New CodeDom.CodeIterationStatement()
                codeWhile.TestExpression = New CodeDom.CodeSnippetExpression("True")
                codeWhile.IncrementStatement = New CodeDom.CodeSnippetStatement("")
                codeWhile.InitStatement = New CodeDom.CodeSnippetStatement("")
                Return codeWhile
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
