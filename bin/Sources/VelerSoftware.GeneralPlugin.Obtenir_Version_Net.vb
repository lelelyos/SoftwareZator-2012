Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function GetFrameworkVersion() As String
        With Microsoft.Win32.Registry.LocalMachine
            Dim test As Microsoft.Win32.RegistryKey
            test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", False)
            If Not test Is Nothing Then
                Return test.GetValue("Version")
                Exit Function
            End If
            test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client", False)
            If Not test Is Nothing Then
                Return test.GetValue("Version")
                Exit Function
            End If
            test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5", False)
            If Not test Is Nothing Then
                Return test.GetValue("Version")
                Exit Function
            End If
            test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0\Setup", False)
            If Not test Is Nothing Then
                Return test.GetValue("Version")
                Exit Function
            End If
            test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727", False)
            If Not test Is Nothing Then
                Return test.GetValue("Version")
                Exit Function
            End If
        End With
        Return Nothing
    End Function

End Class
