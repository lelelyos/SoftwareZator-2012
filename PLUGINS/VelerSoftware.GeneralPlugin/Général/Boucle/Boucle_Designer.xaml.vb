Public Class Boucle_Designer

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle", GetType(Boucle).Assembly)

        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

    End Sub

End Class
