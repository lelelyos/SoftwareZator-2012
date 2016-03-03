Public Class Obtenir_Dossier_Courant_FTP_Designer

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        If propertyName = "Param1" Then Me.ComboBox1.Text = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Dossier_Courant_FTP).Param1
    End Sub

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.FTPPlugin.Obtenir_Dossier_Courant_FTP", GetType(Obtenir_Dossier_Courant_FTP).Assembly)

        Me.Label2.Content = RM.GetString("Designer_Text2")
        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")

        Me.ComboBox1.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Dossier_Courant_FTP).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next


        Me.ComboBox1.SelectedItem = DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Dossier_Courant_FTP).Param1

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Dossier_Courant_FTP).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ComboBox1_DropDownOpened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Dim txt As String = Me.ComboBox1.Text

        Me.ComboBox1.Items.Clear()
        For Each a As VelerSoftware.SZVB.Projet.Variable In DirectCast(Me.ModelItem.GetCurrentValue, Obtenir_Dossier_Courant_FTP).Tools.GetCurrentProjectVariableList
            If Not a.Array Then
                Me.ComboBox1.Items.Add(a.Name)
            End If
        Next

        Me.ComboBox1.SelectedItem = txt
    End Sub
End Class
