Public Class Afficher_Un_Message_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param4" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Param4
        If propertyName = "Param5" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Param5
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Afficher_Un_Message", GetType(Afficher_Un_Message).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("")
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Param4
        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Param5

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        Me.ComboBox1.Items.Add("")
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Afficher_Un_Message).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub
End Class
