Public Class Etiquette_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Etiquette).Param1
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Etiquette", GetType(Etiquette).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Etiquette).Param1

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Etiquette).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TextBox1.LostFocus
        If Me.TextBox1.Text = Nothing Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
            RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Etiquette", GetType(Etiquette).Assembly)

            MsgBox(RM.GetString("Aucun_Nom"), MsgBoxStyle.Exclamation)
            If Me.TextBox1.CanUndo Then Me.TextBox1.Undo()
        End If
    End Sub

End Class
