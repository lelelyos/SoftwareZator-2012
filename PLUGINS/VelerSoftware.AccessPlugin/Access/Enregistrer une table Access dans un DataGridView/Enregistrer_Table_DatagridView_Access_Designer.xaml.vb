Public Class Enregistrer_Table_DatagridView_Access_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Param1
        If propertyName = "Param2" Then Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Param2
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.AccessPlugin.Enregistrer_Table_DatagridView_Access", GetType(Enregistrer_Table_DatagridView_Access).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Tools.GetCurrentProjectWindowsControls
            If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.DataGridView" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonDataGridView") Then
                Me.ComboBox1.Items.Add(aaa.FullName)
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Param1
        Me.TextBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Enregistrer_Table_DatagridView_Access).Tools.GetCurrentProjectWindowsControls
            If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.DataGridView" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonDataGridView") Then
                Me.ComboBox1.Items.Add(aaa.FullName)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub
End Class
