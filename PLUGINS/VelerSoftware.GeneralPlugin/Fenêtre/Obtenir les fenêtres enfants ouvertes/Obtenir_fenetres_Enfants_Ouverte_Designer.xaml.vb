Public Class Obtenir_fenetres_Enfants_Ouverte_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Param1
        If propertyName = "Param2" Then Me.ComboBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Param2
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_fenetres_Enfants_Ouverte", GetType(Obtenir_fenetres_Enfants_Ouverte).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.Label3.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Tools.GetCurrentProjectWindows(False)
            Me.ComboBox1.Items.Add(aaa.FullName)
        Next

        Me.ComboBox2.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Tools.GetCurrentProjectVariableList
            If aaa.Array Then Me.ComboBox2.Items.Add(aaa.Name)
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Param1

        Me.ComboBox2.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Tools.GetCurrentProjectWindows(False)
            Me.ComboBox1.Items.Add(aaa.FullName)
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox2_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDownOpened
        Dim txt As String = Me.ComboBox2.Text

        Me.ComboBox2.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_fenetres_Enfants_Ouverte).Tools.GetCurrentProjectVariableList
            If aaa.Array Then Me.ComboBox2.Items.Add(aaa.Name)
        Next

        Me.ComboBox2.SelectedItem = txt
    End Sub
End Class
