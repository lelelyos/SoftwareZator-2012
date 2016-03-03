Public Class Fonction_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Fonction", GetType(Fonction).Assembly)

        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Fonction).ActionChanged, AddressOf ActionChanged

    End Sub

End Class
