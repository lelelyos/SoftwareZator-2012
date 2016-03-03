Public Class Obtenir_Propriete_Variable_Designer

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param1
        If propertyName = "Param2" Then
            Me.Label2.Content = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param2

            Dim txt As String = Me.ComboBox4.Text
            Me.ComboBox3.Items.Clear()
            PropList = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetPropertyList(Me.Label2.Content)
            For Each a As System.Reflection.PropertyInfo In PropList
                If a.CanRead AndAlso (Not a.PropertyType.FullName.EndsWith("[]") OrElse Not a.PropertyType.FullName.Contains("+") OrElse Not a.PropertyType.FullName.Contains("Collection")) Then
                    Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
                End If
            Next
            Me.ComboBox3.SelectedItem = txt
        End If
        If propertyName = "Param3" Then Me.ComboBox3.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param3
        If propertyName = "Param4" Then Me.ComboBox4.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param4
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Propriete_Variable", GetType(Obtenir_Propriete_Variable).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label22.Content = RM.GetString("Designer_Text2")
        Me.Label3.Content = RM.GetString("Designer_Text3")
        Me.Label4.Content = RM.GetString("Designer_Text4")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox3.Items.Clear()
        Me.ComboBox4.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox4.Items.Add(a.Name)
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param1
        Me.ComboBox4.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param4

        Me.Label2.Content = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param2

        If Not Me.Label2.Content = Nothing Then
            PropList = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetPropertyList(Me.Label2.Content)
            For Each a As System.Reflection.PropertyInfo In PropList
                If a.CanRead AndAlso (Not a.PropertyType.FullName.EndsWith("[]") OrElse Not a.PropertyType.FullName.Contains("+") OrElse Not a.PropertyType.FullName.Contains("Collection")) Then
                    Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
                End If
            Next
        End If

        Me.ComboBox3.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Param3

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetCurrentProjectVariableList
            If Not a.Array Then Me.ComboBox1.Items.Add(a.Name)
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox3_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDownOpened
        Dim txt As String = Me.ComboBox3.Text

        Me.ComboBox3.Items.Clear()
        PropList = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetPropertyList(Me.Label2.Content)
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanRead AndAlso (Not a.PropertyType.FullName.EndsWith("[]") OrElse Not a.PropertyType.FullName.Contains("+") OrElse Not a.PropertyType.FullName.Contains("Collection")) Then
                Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next

        Me.ComboBox3.SelectedItem = txt
    End Sub

    Private Sub ComboBox4_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.DropDownOpened
        Dim txt As String = Me.ComboBox4.Text

        Me.ComboBox4.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Propriete_Variable).Tools.GetCurrentProjectVariableList
            If Not a.Array Then Me.ComboBox4.Items.Add(a.Name)
        Next

        Me.ComboBox4.SelectedItem = txt
    End Sub

End Class
