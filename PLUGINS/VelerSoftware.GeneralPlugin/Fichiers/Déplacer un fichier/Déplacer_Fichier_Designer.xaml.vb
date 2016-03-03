Public Class Déplacer_Fichier_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param1
        If propertyName = "Param2" Then Me.TextBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param2
        If propertyName = "Param3" Then
            If CBool(DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param3) Then
                Me.RadioButton1.IsChecked = True
            Else
                Me.RadioButton2.IsChecked = True
            End If
        End If
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Déplacer_Fichier", GetType(Déplacer_Fichier).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.RadioButton1.Content = RM.GetString("Designer_Text3")
        Me.RadioButton2.Content = RM.GetString("Designer_Text4")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param1

        Me.TextBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param2

        If Not DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param3 = Nothing Then
            If CBool(DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).Param3) Then
                Me.RadioButton1.IsChecked = True
            Else
                Me.RadioButton2.IsChecked = True
            End If
        End If

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Déplacer_Fichier).ActionChanged, AddressOf ActionChanged
    End Sub

End Class
