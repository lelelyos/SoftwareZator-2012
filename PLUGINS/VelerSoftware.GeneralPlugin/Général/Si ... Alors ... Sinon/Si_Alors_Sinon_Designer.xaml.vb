Public Class Si_Alors_Sinon_Designer

    Private Sub ActivityDesigner_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)

        Me.TextBlock1.Text = RM.GetString("Designer_Collaspe")
        Me.Label2.Content = RM.GetString("Designer_Text1")
        Me.Label3.Content = RM.GetString("Designer_Text2")
        Me.CheckBox1.Content = Me.Label3.Content

        If DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param6 = "" Then
            Me.CheckBox1.IsChecked = True
            DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param6 = "True"
        Else
            Me.CheckBox1.IsChecked = CBool(DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param6)
            If Me.CheckBox1.IsChecked Then
                Grid1.ColumnDefinitions(0).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
                Grid1.ColumnDefinitions(1).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
            Else
                Grid1.ColumnDefinitions(0).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
                Grid1.ColumnDefinitions(1).Width = New Windows.GridLength(0, Windows.GridUnitType.Pixel)
            End If
        End If

        If Not DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param2 = Nothing Then
            Select Case CInt(DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param2)
                Case 0
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "=", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 1
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 2
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<=", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 3
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, ">", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 4
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "=>", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 5
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<>", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 6
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, RM.GetString("Designer_Text3"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
            End Select
        End If

        AddHandler DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).ActionChanged, AddressOf ActionChanged
    End Sub

    Private Sub ActionChanged(ByVal sender As System.Object, ByVal propertyName As String, ByVal e As System.EventArgs)
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Si_Alors_Sinon", GetType(Si_Alors_Sinon).Assembly)

        If Not DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param2 = Nothing Then
            Select Case CInt(DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param2)
                Case 0
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "=", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 1
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 2
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<=", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 3
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, ">", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 4
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "=>", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 5
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, "<>", DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
                Case 6
                    Me.Label1.Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Designer_Text"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param1, RM.GetString("Designer_Text3"), DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param4)
            End Select
        End If

    End Sub

    Private Sub CheckBox1_Checked(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles CheckBox1.Checked
        Grid1.ColumnDefinitions(0).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
        Grid1.ColumnDefinitions(1).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
        DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param6 = "True"
    End Sub

    Private Sub CheckBox1_Unchecked(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles CheckBox1.Unchecked
        Grid1.ColumnDefinitions(0).Width = New Windows.GridLength(1, Windows.GridUnitType.Star)
        Grid1.ColumnDefinitions(1).Width = New Windows.GridLength(0, Windows.GridUnitType.Pixel)
        DirectCast(Me.ModelItem.GetCurrentValue, Si_Alors_Sinon).Param6 = "False"
    End Sub

End Class
