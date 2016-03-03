Public Class Convertir_Valeur_Propriete_Designer

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Param1
        If propertyName = "Param3" Then Me.ComboBox4.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Param3
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Propriete_Propriete", GetType(Convertir_Valeur_Propriete).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label4.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox4.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox4.Items.Add(a.Name)
            End If
        Next

        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Param1
        Me.ComboBox4.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Param3

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox4_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.DropDownOpened
        Dim txt As String = Me.ComboBox4.Text

        Me.ComboBox4.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Convertir_Valeur_Propriete).Tools.GetCurrentProjectVariableList
            If Not a.Array Then Me.ComboBox4.Items.Add(a.Name)
        Next

        Me.ComboBox4.SelectedItem = txt
    End Sub

End Class
