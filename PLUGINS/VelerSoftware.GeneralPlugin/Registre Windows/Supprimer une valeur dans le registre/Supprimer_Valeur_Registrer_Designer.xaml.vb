Public Class Supprimer_Valeur_Registrer_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param3" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Supprimer_Valeur_Registrer).Param3
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Supprimer_Valeur_Registrer", GetType(Supprimer_Valeur_Registrer).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Supprimer_Valeur_Registrer).Param3

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Supprimer_Valeur_Registrer).ActionChanged, AddressOf ActionChanged
    End Sub

End Class
