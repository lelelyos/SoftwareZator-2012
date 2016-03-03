Public Class Obtenir_Tous_Element_Groupe_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Param1
        If propertyName = "Param2" Then Me.ComboBox2.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Param2
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Obtenir_Tous_Element_Groupe", GetType(Obtenir_Tous_Element_Groupe).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text")
        Me.Label3.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Tools.GetCurrentProjectWindowsControls
            If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.GroupBox" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonGroup" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonGroupBox") Then
                Me.ComboBox1.Items.Add(aaa.FullName)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Param1

        Me.ComboBox2.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Tools.GetCurrentProjectVariableList
            If aaa.Array Then
                Me.ComboBox2.Items.Add(aaa.Name)
            End If
        Next

        Me.ComboBox2.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Tools.GetCurrentProjectWindowsControls
            If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.GroupBox" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonGroup") Then
                Me.ComboBox1.Items.Add(aaa.FullName)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox2_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDownOpened
        Dim txt As String = Me.ComboBox2.Text

        Me.ComboBox2.Items.Clear()
        For Each aaa As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Tous_Element_Groupe).Tools.GetCurrentProjectVariableList
            If aaa.Array Then
                Me.ComboBox2.Items.Add(aaa.Name)
            End If
        Next

        Me.ComboBox2.SelectedItem = txt
    End Sub
End Class
