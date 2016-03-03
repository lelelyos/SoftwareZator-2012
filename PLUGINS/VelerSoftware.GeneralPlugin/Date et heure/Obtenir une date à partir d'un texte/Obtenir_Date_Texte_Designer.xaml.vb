Public Class Obtenir_Date_Texte_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param2" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Param2
        If propertyName = "Param1" Then Me.Combobox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Param1
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Date_Texte", GetType(Obtenir_Date_Texte).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.Label1.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.Combobox1.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then
                Me.Combobox1.Items.Add(aaa.Name)
            End If
        Next

        Me.Combobox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Param1

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combobox1.DropDownOpened
        Dim txt As String = Me.Combobox1.Text

        Me.Combobox1.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Date_Texte).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then
                Me.Combobox1.Items.Add(aaa.Name)
            End If
        Next

        Me.Combobox1.SelectedItem = txt
    End Sub

End Class
