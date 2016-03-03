Partial Public Class VelerSoftware_GeneralPlugin

    ' Créer une clé
    Shared Function CreateKey(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Microsoft.VisualBasic.Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytKey(31) As Byte
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next
        Return bytKey
    End Function

    ' Créer un IV
    Shared Function CreateIV(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Microsoft.VisualBasic.Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytIV(15) As Byte
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next
        Return bytIV
    End Function

    Public Enum CryptoAction
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    ' Encrypter/Décrypter un fichier
    Shared Sub EncryptOrDecryptFile(ByVal strInputFile As String, ByVal strOutputFile As String, ByVal bytKey() As Byte, ByVal bytIV() As Byte, ByVal Direction As CryptoAction)
        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream
        fsInput = New System.IO.FileStream(strInputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        fsOutput = New System.IO.FileStream(strOutputFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
        fsOutput.SetLength(0)
        Dim bytBuffer(4096) As Byte
        Dim lngBytesProcessed As Long = 0
        Dim lngFileLength As Long = fsInput.Length
        Dim intBytesInCurrentBlock As Integer
        Dim csCryptoStream As System.Security.Cryptography.CryptoStream
        Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged
        Select Case Direction
            Case CryptoAction.ActionEncrypt
                csCryptoStream = New System.Security.Cryptography.CryptoStream(fsOutput, _
                cspRijndael.CreateEncryptor(bytKey, bytIV), _
                System.Security.Cryptography.CryptoStreamMode.Write)
                While lngBytesProcessed < lngFileLength
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                End While
                csCryptoStream.Close()

            Case CryptoAction.ActionDecrypt
                csCryptoStream = New System.Security.Cryptography.CryptoStream(fsOutput, _
                cspRijndael.CreateDecryptor(bytKey, bytIV), _
                System.Security.Cryptography.CryptoStreamMode.Write)
                While lngBytesProcessed < lngFileLength
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                End While
                csCryptoStream.Close()
        End Select
        fsInput.Close()
        fsOutput.Close()
    End Sub

End Class
