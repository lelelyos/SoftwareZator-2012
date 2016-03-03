Public Class Obtenir_Type_Propriete_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Param1
        If propertyName = "Param2" Then Me.ComboBox2.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Param2
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Type_Propriete", GetType(Obtenir_Type_Propriete).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox2.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox2.Items.Add(a.Name)
            End If
        Next
        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Param1
        Me.ComboBox2.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox2_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDownOpened
        Dim txt As String = Me.ComboBox2.Text

        Me.ComboBox2.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Type_Propriete).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox2.Items.Add(a.Name)
            End If
        Next

        Me.ComboBox2.SelectedItem = txt
    End Sub
End Class
