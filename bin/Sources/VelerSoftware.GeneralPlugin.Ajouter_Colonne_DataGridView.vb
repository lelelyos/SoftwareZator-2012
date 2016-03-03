Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function CreateNewDataGridViewColumn(ByVal Nom As String, ByVal Texte As String, ByVal Type As String, ByVal Visible As Boolean, ByVal LectureSeule As Boolean, ByVal Fige As Boolean) As Object
        Dim column As Object = Nothing
        Select Case Type
            Case "Button"
                column = New System.Windows.Forms.DataGridViewButtonColumn
            Case "Check Box"
                column = New System.Windows.Forms.DataGridViewCheckBoxColumn
            Case "Combo Box"
                column = New System.Windows.Forms.DataGridViewComboBoxColumn
            Case "Image"
                column = New System.Windows.Forms.DataGridViewImageColumn
            Case "Link"
                column = New System.Windows.Forms.DataGridViewLinkColumn
            Case "Text Box"
                column = New System.Windows.Forms.DataGridViewTextBoxColumn
        End Select
        With column
            .Name = Nom
            .HeaderText = Texte
            .Visible = Visible
            .ReadOnly = LectureSeule
            .Frozen = Fige
        End With
        Return column
    End Function

End Class
