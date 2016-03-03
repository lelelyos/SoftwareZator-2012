Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function AddItemListView(ByVal Nom As String, ByVal Texte As String, ByVal InfoBulle As String, ByVal Img As Integer, ByVal Coche As Boolean) As System.Windows.Forms.ListViewItem
        Dim ite As New System.Windows.Forms.ListViewItem
        With ite
            .Name = Nom
            .Text = Texte
            .ToolTipText = InfoBulle
            .ImageKey = Img
            .StateImageIndex = Img
            .Checked = Coche
        End With
        Return ite
    End Function

End Class
