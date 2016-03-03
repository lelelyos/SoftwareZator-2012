<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Declarer_Propriete_Designer))> _
Public Class Declarer_Propriete
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Declarer_Propriete", GetType(Declarer_Propriete).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Declarer_Propriete
            .CompatibleClass = True
            .CompatibleFonctions = False
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Declarer_Propriete", GetType(Declarer_Propriete).Assembly)
        Using frm As New Declarer_Propriete_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Param1 = frm.Param1

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Declarer_Propriete", GetType(Declarer_Propriete).Assembly)
        Using frm As New Declarer_Propriete_Form
            frm.Param1 = Me.Param1
            frm.Tools = Me.Tools

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Param1 = frm.Param1
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
            If Not FromFunction Then
                Return New CodeDom.CodeSnippetTypeMember("Public Property " & Me.Param1 & " As Object")
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Declarer_Propriete", GetType(Declarer_Propriete).Assembly)

        If ErrorToResole.Type = SZVB.Projet.Erreur.ErrorType.Building Then

            If ErrorToResole.ErrorNumber = "BC30452" Then ' Une variable tableau a été utilisé dans le titre ou message
                i_progress = Me.Tools.GetCurrentProjectVariableList.Count
                i2_progress = 0
                For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                    If var.Array Then
                        If Not Me.Param1 = Nothing Then Me.Param1 = Me.Param1.Replace("%(VARIABLE=" & var.Name & ")%", Nothing)
                    End If
                Next
                If Me.Param1 = Nothing Then Me.Param1 = " "

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
