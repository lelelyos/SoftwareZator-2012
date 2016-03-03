Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function Envoyer_Email(ByVal De As String, ByVal A As String, ByVal server As String, ByVal Sujet As String, ByVal Corps As String, ByVal Fichier As String, ByVal Utilisateur As String, ByVal MotDePasse As String) As String
        Try
            Dim message As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(New System.Net.Mail.MailAddress(De), New System.Net.Mail.MailAddress(A))

            message.Subject = Sujet
            message.Body = Corps

            If My.Computer.FileSystem.FileExists(Fichier) Then
                Dim data As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(Fichier)
                data.ContentDisposition.CreationDate = System.IO.File.GetCreationTime(Fichier)
                data.ContentDisposition.ModificationDate = System.IO.File.GetLastWriteTime(Fichier)
                data.ContentDisposition.ReadDate = System.IO.File.GetLastAccessTime(Fichier)
                message.Attachments.Add(data)
            End If

            Dim client As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(server)

            If Not Utilisateur = "" Then client.Credentials = New System.Net.NetworkCredential(Utilisateur, MotDePasse)

            client.Port = 25
            client.Send(message)

            Return "1"
        Catch ex As Exception
            Return "Sending email failed : " & ex.Message
        End Try
    End Function

End Class