Public Class Arreter_Processus_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).Param1
        If propertyName = "Param2" Then Me.CheckBox1.IsChecked = CBool(DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).Param2)
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Arreter_Processus", GetType(Arreter_Processus).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.CheckBox1.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).Param1
        If Not DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).Param2 = Nothing Then
            Me.CheckBox1.IsChecked = CBool(DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).Param2)
        End If

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Arreter_Processus).ActionChanged, AddressOf ActionChanged
    End Sub

End Class
