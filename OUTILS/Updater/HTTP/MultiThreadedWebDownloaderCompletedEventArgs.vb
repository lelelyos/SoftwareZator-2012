''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class MultiThreadedWebDownloaderCompletedEventArgs
    Inherits EventArgs

    Private privateDownloadedSize As Long
    Public Property DownloadedSize() As Long
        Get
            Return privateDownloadedSize
        End Get
        Private Set(ByVal value As Long)
            privateDownloadedSize = value
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

    Private privateTotalTime As TimeSpan
    Public Property TotalTime() As TimeSpan
        Get
            Return privateTotalTime
        End Get
        Private Set(ByVal value As TimeSpan)
            privateTotalTime = value
        End Set
    End Property

    Public Sub New(ByVal downloadedSize As Long, ByVal totalSize As Long,
                   ByVal totalTime As TimeSpan)
        Me.DownloadedSize = downloadedSize
        Me.TotalSize = totalSize
        Me.TotalTime = totalTime
    End Sub
End Class

