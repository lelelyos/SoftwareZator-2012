Public Class Boucle_Limitee_Designer

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle_Limitee", GetType(Boucle_Limitee).Assembly)

        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        If Not DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param1 = Nothing Then
            Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param1, DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param2, DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param3, "", DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param5)
        End If

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle_Limitee", GetType(Boucle_Limitee).Assembly)

        If propertyName = "Param5" Then
            If Not DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param5 = Nothing Then
                Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param1, DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param2, DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param3, "", DirectCast(Me.ModelItem.GetCurrentValue, Boucle_Limitee).Param5)
            End If
        End If
    End Sub

End Class
