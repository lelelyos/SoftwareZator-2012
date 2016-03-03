Public Class Incrementer_Date_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param5" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Param5
        If propertyName = "Param6" Then Me.Combobox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Param6
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Incrementer_Date", GetType(Incrementer_Date).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.Label1.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.Combobox1.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then
                Me.Combobox1.Items.Add(aaa.Name)
            End If
        Next

        Me.Combobox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Param6

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Param5

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combobox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Incrementer_Date).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then
                Me.Combobox1.Items.Add(aaa.Name)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

End Class
