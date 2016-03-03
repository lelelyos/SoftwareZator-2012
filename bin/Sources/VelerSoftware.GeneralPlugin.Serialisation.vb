Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function Serialize(ByVal FileName As String, ByVal ObjectToSerialize As System.Object, ByVal DoNotSaveIfExist As Boolean) As Boolean
        Dim Oki As Boolean = True
        If DoNotSaveIfExist AndAlso Microsoft.VisualBasic.FileIO.FileSystem.FileExists(FileName) Then Oki = False
        If Oki Then
            Dim myFileStream As IO.Stream = IO.File.Create(FileName)
            Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            serializer.Serialize(myFileStream, ObjectToSerialize)
            myFileStream.Close()
        End If
        Return Oki
    End Function

    Shared Function Deserialize(ByVal FileName As String) As System.Object
        Dim Resultat As System.Object = Nothing
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(FileName) Then
            Dim myFileStream As IO.Stream = IO.File.OpenRead(FileName)
            Dim deserializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Try
                Resultat = deserializer.Deserialize(myFileStream)
            Catch
            Finally
                myFileStream.Close()
            End Try
        End If
        Return Resultat
    End Function

End Class
