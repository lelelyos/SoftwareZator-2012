Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function RunProcess(ByVal File As String, ByVal Mode As System.Diagnostics.ProcessWindowStyle, ByVal Arguments As String, ByVal WaitForExit As Boolean) As String
        Dim result As String = Nothing
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(File) Then
            Dim proc As New System.Diagnostics.Process
            With proc.StartInfo
                .FileName = File
                .ErrorDialog = True
                .RedirectStandardOutput = True
                .UseShellExecute = False
                If Mode = System.Diagnostics.ProcessWindowStyle.Hidden Then .CreateNoWindow = True
                .WindowStyle = Mode
                .Arguments = Arguments
            End With
            proc.Start()
            If WaitForExit Then
                result = proc.StandardOutput.ReadToEnd
                proc.WaitForExit()
            End If
        Else
            System.Diagnostics.Process.Start(File)
        End If
        Return result
    End Function

End Class
