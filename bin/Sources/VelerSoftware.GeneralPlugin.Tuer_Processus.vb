Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function KillProc(ByVal Nom As String, ByVal Force As Boolean)
        Dim prc As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(Nom)
        For Each a As System.Diagnostics.Process In prc
            If Force Then
                a.Kill()
                a.Close()
            Else
                a.CloseMainWindow()
                a.Close()
            End If
        Next
    End Function

End Class
