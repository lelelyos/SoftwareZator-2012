Partial Public Class VelerSoftware_GeneralPlugin

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" Alias "InternetGetConnectedState" (ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Boolean

    Shared Function IsConnected() As Boolean
        Dim Desc As Integer
        Return InternetGetConnectedState(Desc, 0)
    End Function

End Class
