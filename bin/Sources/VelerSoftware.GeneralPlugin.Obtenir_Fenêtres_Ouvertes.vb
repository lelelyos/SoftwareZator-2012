Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function GetOpenForms() As System.Collections.Generic.List(Of System.Object)
        Dim Result As New System.Collections.Generic.List(Of System.Object)
        For Each Frmm As System.Windows.Forms.Form In System.Windows.Forms.Application.OpenForms
            Result.Add(Frmm)
        Next
        Return Result
    End Function

End Class
