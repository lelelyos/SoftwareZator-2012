Public Class Attendre_Appui_Touche_Continuer_Console_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Attendre_Appui_Touche_Continuer_Console).Param1
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Attendre_Appui_Touche_Continuer_Console", GetType(Attendre_Appui_Touche_Continuer_Console).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Attendre_Appui_Touche_Continuer_Console).Param1

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Attendre_Appui_Touche_Continuer_Console).ActionChanged, AddressOf ActionChanged
    End Sub

End Class
