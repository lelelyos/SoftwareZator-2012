Public Class Modifier_Propriete_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Param1
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete", GetType(Modifier_Propriete).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Param1

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each act As VelerSoftware.Plugins3.Action In DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Tools.GetActionsOfFuntion(DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete).Tools.GetCurrentDocumentName)
            If TypeOf act Is VelerSoftware.GeneralPlugin.Declarer_Propriete Then
                Me.ComboBox1.Items.Add(act.Param1)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub
End Class
