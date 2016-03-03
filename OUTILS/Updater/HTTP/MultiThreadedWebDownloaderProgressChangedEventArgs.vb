''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class MultiThreadedWebDownloaderProgressChangedEventArgs
    Inherits EventArgs

    Private privateReceivedSize As Long
    Public Property ReceivedSize() As Long
        Get
            Return privateReceivedSize
        End Get
        Private Set(ByVal value As Long)
            privateReceivedSize = value
        End Set
    End Property

    Private privateTotalSize As Long
    Public Property TotalSize() As Long
        Get
            Return privateTotalSize
        End Get
        Private Set(ByVal value As Long)
            privateTotalSize = value
        End Set
    End Property

    Private privateDownloadSpeed As Integer
    Public Property DownloadSpeed() As Integer
        Get
            Return privateDownloadSpeed
        End Get
        Private Set(ByVal value As Integer)
            privateDownloadSpeed = value
        End Set
    End Property

    Public Sub New(ByVal receivedSize As Long, ByVal totalSize As Long,
                   ByVal downloadSpeed As Integer)
        Me.ReceivedSize = receivedSize
        Me.TotalSize = totalSize
        Me.DownloadSpeed = downloadSpeed
    End Sub
End Class

