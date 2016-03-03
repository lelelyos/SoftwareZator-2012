Public Class Modifier_Propriete_Contrôle_Designer

    Private PropList As New Generic.List(Of System.Reflection.PropertyInfo)

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then
            Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Param1

            Dim txt As String = Me.ComboBox3.Text
            Me.ComboBox3.Items.Clear()
            PropList = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Tools.GetPropertyList(Me.ComboBox1.Text.Split(" ")(3).TrimEnd(")"))
            For Each a As System.Reflection.PropertyInfo In PropList
                If a.CanWrite Then
                    Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
                End If
            Next
            Me.ComboBox3.SelectedItem = txt
        End If
        If propertyName = "Param2" Then Me.ComboBox3.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Param2
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Modifier_Propriete_Contrôle", GetType(Modifier_Propriete_Contrôle).Assembly)

        Me.Label1.Content = RM.GetString("Designer_Text")
        Me.Label3.Content = RM.GetString("Designer_Text3")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        Me.ComboBox3.Items.Clear()
        For Each a As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Tools.GetCurrentProjectWindowsControls
            If a.ObjectType = GetType(CodeDom.CodeMemberField) Then
                Me.ComboBox1.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
            ElseIf a.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                Me.ComboBox1.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
            End If
        Next

        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Param1

        If Not Me.ComboBox1.Text = Nothing Then
            PropList = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Tools.GetPropertyList(Me.ComboBox1.Text.Split(" ")(3).TrimEnd(")"))
            For Each a As System.Reflection.PropertyInfo In PropList
                If a.CanWrite Then
                    Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
                End If
            Next
        End If

        Me.ComboBox3.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Param2

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each a As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Tools.GetCurrentProjectWindowsControls
            If a.ObjectType = GetType(CodeDom.CodeMemberField) Then
                Me.ComboBox1.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeMemberField).Type.BaseType & ")")
            ElseIf a.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                Me.ComboBox1.Items.Add(a.FullName & " (type : " & DirectCast(a.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType & ")")
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub

    Private Sub ComboBox3_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDownOpened
        Dim txt As String = Me.ComboBox3.Text

        Me.ComboBox3.Items.Clear()
        PropList = DirectCast(Me.ModelItem.GetCurrentValue, Modifier_Propriete_Contrôle).Tools.GetPropertyList(Me.ComboBox1.Text.Split(" ")(3).TrimEnd(")"))
        For Each a As System.Reflection.PropertyInfo In PropList
            If a.CanWrite Then
                Me.ComboBox3.Items.Add(a.Name & " (type : " & a.PropertyType.FullName & ")")
            End If
        Next

        Me.ComboBox3.SelectedItem = txt
    End Sub

End Class
