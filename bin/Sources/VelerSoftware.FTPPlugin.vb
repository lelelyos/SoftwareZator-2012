Module VelerSoftware_FTPPlugin

    Private HostFtp As VelerSoftware.FTPLib.FtpConnection

    Public Function Connect(ByVal Host As String, ByVal Port As Integer, ByVal Login As String, ByVal Password As String) As Integer
        Try
            Disconnect()
            HostFtp = New VelerSoftware.FTPLib.FtpConnection(Host, Port, Login, Password)
            HostFtp.Open()
            HostFtp.Login()
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to connect to the server : host, port, username and or password are not good.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Sub Disconnect()
        If HostFtp IsNot Nothing Then
            HostFtp.Close()
            HostFtp.Dispose()
        End If
    End Sub

    Public Function CreateDirectory(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.CreateDirectory(Path)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to create the directory '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function DirectoryExists(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            If HostFtp.DirectoryExists(Path) Then
                Return 1
            Else
                Return 0
            End If
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to test if the directory '" & Path & "' exists on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function FileExists(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            If HostFtp.FileExists(Path) Then
                Return 1
            Else
                Return 0
            End If
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to test if the file '" & Path & "' exists on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetCurrentDirectory() As String
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return HostFtp.GetCurrentDirectory()
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the current directory on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

    Public Function SetCurrentDirectory(ByVal path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.SetCurrentDirectory(path)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to set the current directory '" & path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function GetCurrentDirectoryInfo() As VelerSoftware.FTPLib.FtpDirectoryInfo
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return HostFtp.GetCurrentDirectoryInfo()
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the current directory infos on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function GetDirectories() As System.Collections.Generic.List(Of Object)
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(HostFtp.GetDirectories()))
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the list of directories from the current directory on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New System.Collections.Generic.List(Of Object)
        End Try
    End Function

    Public Function GetDirectories(ByVal Path As String) As System.Collections.Generic.List(Of Object)
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(HostFtp.GetDirectories(Path)))
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the list of directories from path '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New System.Collections.Generic.List(Of Object)
        End Try
    End Function

    Public Function GetFiles() As System.Collections.Generic.List(Of Object)
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(HostFtp.GetFiles()))
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the list of files from the current directory on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New System.Collections.Generic.List(Of Object)
        End Try
    End Function

    Public Function GetFiles(ByVal Path As String) As System.Collections.Generic.List(Of Object)
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(HostFtp.GetFiles(Path)))
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the list of files from path '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New System.Collections.Generic.List(Of Object)
        End Try
    End Function

    Public Function GetFileSize(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return HostFtp.GetFileSize(Path)
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to get the size of the file from path '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function DownloadFile(ByVal RemoteFile As String, ByVal LocalFile As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.GetFile(RemoteFile, LocalFile, False)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to download '" & RemoteFile & "' from the server to '" & LocalFile & "' on the hard disk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function UploadFile(ByVal LocalFile As String, ByVal RemoteFile As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.PutFile(LocalFile, RemoteFile)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to upload '" & LocalFile & "' from the hard disk to '" & RemoteFile & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function RemoveDirectory(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.RemoveDirectory(Path)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to remove the directory '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function RemoveFile(ByVal Path As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.RemoveFile(Path)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to remove the file '" & Path & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function RenameFile(ByVal Path As String, ByVal NewName As String) As Integer
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            HostFtp.RenameFile(Path, NewName)
            Return 1
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to rename the file '" & Path & "' to '" & NewName & "' on the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Public Function SendCommand(ByVal Request As String) As String
        Try
            If HostFtp Is Nothing Then Throw New Exception()
            Return HostFtp.SendCommand(Request)
        Catch
            System.Windows.Forms.MessageBox.Show("Unable to send the request '" & Request & "' to the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "-1"
        End Try
    End Function

End Module