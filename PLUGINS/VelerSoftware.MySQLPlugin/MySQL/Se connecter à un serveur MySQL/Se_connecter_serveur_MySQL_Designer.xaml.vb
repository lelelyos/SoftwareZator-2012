Public Class Se_connecter_serveur_MySQL_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param2" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param2
        If propertyName = "Param3" Then Me.TextBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param3
        If propertyName = "Param4" Then Me.TextBox3.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param4
        If propertyName = "Param5" Then Me.TextBox4.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param5
        If propertyName = "Param8" Then Me.TextBox5.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param8
        If propertyName = "Param7" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param7
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.MySQLPlugin.Se_connecter_serveur_MySQL", GetType(Se_connecter_serveur_MySQL).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.Label3.Content = RM.GetString("Designer_Text3")
        Me.Label4.Content = RM.GetString("Designer_Text4")
        Me.Label5.Content = RM.GetString("Designer_Text5")
        Me.Label6.Content = RM.GetString("Designer_Text6")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("")
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param2
        Me.TextBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param3
        Me.TextBox3.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param4
        Me.TextBox4.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param5
        Me.TextBox5.Text = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param8
        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Param7

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("")
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Se_connecter_serveur_MySQL).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub
End Class
