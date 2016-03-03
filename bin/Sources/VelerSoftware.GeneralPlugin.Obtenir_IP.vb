Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function GetIp() As String
        Dim ContenuPage As String = ""
        Dim ConnexionWeb As New System.Net.WebClient
        Dim SR As New System.IO.StreamReader(ConnexionWeb.OpenRead("http://automation.whatismyip.com/n09230945.asp"))

        While SR.Peek > 0
            ContenuPage = SR.ReadLine()
        End While

        Return ContenuPage
        SR.Close()
    End Function

End Class
