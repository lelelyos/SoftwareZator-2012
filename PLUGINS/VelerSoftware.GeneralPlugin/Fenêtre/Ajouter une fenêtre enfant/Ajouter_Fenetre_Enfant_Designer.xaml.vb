Public Class Ajouter_Fenetre_Enfant_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param1
        If propertyName = "Param2" Then Me.ComboBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param2
        If propertyName = "Param3" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param3
        If propertyName = "Param4" Then Me.ComboBox3.Text = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param4
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Ajouter_Fenetre_Enfant", GetType(Ajouter_Fenetre_Enfant).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text1")
        Me.Label3.Content = RM.GetString("Designer_Text2")
        Me.Label4.Content = RM.GetString("Designer_Text3")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox2.Items.Clear()
        Me.ComboBox3.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Tools.GetCurrentProjectWindows(False)
            Me.ComboBox1.Items.Add(aaa.FullName)
            If Not aaa.FullName = "Me" Then Me.ComboBox2.Items.Add(aaa.FullName)
        Next
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then Me.ComboBox3.Items.Add(aaa.Name)
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param1
        Me.ComboBox2.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param2
        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param3
        Me.ComboBox3.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Param4

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Tools.GetCurrentProjectWindows(False)
            Me.ComboBox1.Items.Add(aaa.FullName)
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox2_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDownOpened
        Dim txt As String = Me.ComboBox2.Text

        Me.ComboBox2.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Tools.GetCurrentProjectWindows(False)
            If Not aaa.FullName = "Me" Then Me.ComboBox2.Items.Add(aaa.FullName)
        Next

        Me.ComboBox2.SelectedItem = txt
    End Sub

    Private Sub ComboBox3_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDownOpened
        Dim txt As String = Me.ComboBox3.Text

        Me.ComboBox3.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Ajouter_Fenetre_Enfant).Tools.GetCurrentProjectVariableList
            If Not aaa.Array Then Me.ComboBox3.Items.Add(aaa.Name)
        Next

        Me.ComboBox3.SelectedItem = txt
    End Sub
End Class
