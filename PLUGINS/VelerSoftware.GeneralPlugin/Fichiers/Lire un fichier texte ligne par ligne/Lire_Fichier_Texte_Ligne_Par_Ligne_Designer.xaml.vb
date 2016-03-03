Public Class Lire_Fichier_Texte_Ligne_Par_Ligne_Designer

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne", GetType(Lire_Fichier_Texte_Ligne_Par_Ligne).Assembly)

        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        If Not DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param1 = Nothing Then
            Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param1, DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param2, DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param3)
        End If

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne", GetType(Lire_Fichier_Texte_Ligne_Par_Ligne).Assembly)

        If propertyName = "Param3" Then
            If Not DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param3 = Nothing Then
                Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param1, DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param2, DirectCast(Me.ModelItem.GetCurrentValue, Lire_Fichier_Texte_Ligne_Par_Ligne).Param3)
            End If
        End If
    End Sub

End Class
