''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Net
Imports System.Configuration
Imports System.IO

Public Class Form1

    Private _downloader As MultiThreadedWebDownloader = Nothing

    Private _lastNotificationTime As Date

    ' Specify whether the download is paused.
    Private _isPaused As Boolean = False

    Private version_read As Integer = 0
    Private version_actual As Integer = 0
    Private betaversion As Integer = 0
    Private betaversion_actual As Integer = 0
    Private update_url As String = ""
    Private isbeta As Boolean
    Private isbeta_actual As Boolean

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With Me
            ' Initialisation des ressources
            RM = New System.Resources.ResourceManager("Updater.Custom", System.Reflection.Assembly.GetExecutingAssembly())

            If Mode_Silence Then .Visible = False

            ' Initialisation de la fenêtre                                                     
            .Text = My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName

            .CheckBox1.Checked = My.Settings.CheckBeta

            .Panel1.Visible = False
            .Panel2.Visible = False
            .Panel3.Visible = False
            .Panel4.Visible = False
            .Panel5.Visible = False
            .Panel1.Size = New System.Drawing.Size(376, 195)
            .Panel2.Size = New System.Drawing.Size(376, 195)
            .Panel3.Size = New System.Drawing.Size(376, 195)
            .Panel4.Size = New System.Drawing.Size(376, 195)
            .Panel5.Size = New System.Drawing.Size(376, 195)
            .Panel1.Location = New System.Drawing.Size(45, 60)
            .Panel2.Location = New System.Drawing.Size(45, 60)
            .Panel3.Location = New System.Drawing.Size(45, 60)
            .Panel4.Location = New System.Drawing.Size(45, 60)
            .Panel5.Location = New System.Drawing.Size(45, 60)

            .Panel1.Visible = True

            .lbSummary.Text = ""
            .lbStatus.Text = ""
        End With

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\version") Then
            version_actual = CInt(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\version"))
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\isbeta") Then
            isbeta_actual = CBool(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\isbeta"))
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\betaversion") Then
            betaversion_actual = CInt(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\betaversion"))
        End If
        If Mode_Silence Then Me.Opacity = 0
    End Sub

    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        If Mode_Silence Then
            Me.Visible = False
            Me.Opacity = 0
        Else
            Me.Visible = True
            Me.Opacity = 1
            Application.DoEvents()
        End If

        With My.Computer.FileSystem
            If Not .DirectoryExists(Application.StartupPath & "\Temp") Then
                .CreateDirectory(Application.StartupPath & "\Temp")
            End If
        End With

        ' Initialize an instance of MultiThreadedWebDownloader.
        _downloader = New MultiThreadedWebDownloader("http://files.velersoftware.com/softwarezator/updates/sz2012.xml")
        _downloader.Proxy = New WebProxy()

        Try
            If VelerSoftware.SZVB.Windows.Core.IsConnected() Then
                _downloader.CheckFile()
                _downloader.DownloadPath = Application.StartupPath & "\Temp\update.xml"

                ' Register the events of HttpDownloadClient.
                AddHandler _downloader.DownloadCompleted, AddressOf DownloadCompleted
                AddHandler _downloader.DownloadProgressChanged, AddressOf DownloadProgressChanged
                AddHandler _downloader.StatusChanged, AddressOf StatusChanged
                AddHandler _downloader.ErrorOccurred, AddressOf ErrorOccurred
                ' Start to download file.
                _downloader.Start()
            Else
                Throw New Exception()
            End If
        Catch ex As Exception
            Me.Label3.Text = RM.GetString("Content1")
            _downloader = Nothing
            Me.Panel1.Visible = False
            Me.Panel2.Visible = True
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.CheckBeta = Me.CheckBox1.Checked
    End Sub



    ''' <summary>
    ''' Handle DownloadCompleted event.
    ''' </summary>
    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As MultiThreadedWebDownloaderCompletedEventArgs)
        With My.Computer.FileSystem
            If .DirectoryExists(Application.StartupPath & "\Temp") Then

                If .FileExists(Application.StartupPath & "\Temp\update.xml") Then
                    Dim XmlRead As Xml.XmlTextReader ' Lecture de XML
                    ' Teste de la version de la solution
                    XmlRead = New Xml.XmlTextReader(Application.StartupPath & "\Temp\update.xml")
                    If XmlRead IsNot Nothing Then
                        Do While XmlRead.Read()
                            Select Case XmlRead.NodeType
                                Case Xml.XmlNodeType.Element
                                    Select Case XmlRead.Name
                                        Case "updater" ' Solution
                                            version_read = CInt(XmlRead.GetAttribute("version"))
                                            update_url = XmlRead.GetAttribute("url")
                                            isbeta = CBool(XmlRead.GetAttribute("isbeta"))
                                            betaversion = CInt(XmlRead.GetAttribute("betaversion"))
                                            Exit Do
                                    End Select
                            End Select
                        Loop
                        XmlRead.Close()
                    End If

                    .DeleteFile(Application.StartupPath & "\Temp\update.xml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                    Windows7ProgressBar1.Value = 0

                    Dim need_update As Boolean
                    If version_read > version_actual Then
                        need_update = True
                    ElseIf CheckBox1.Checked AndAlso version_read = version_actual Then
                        If isbeta_actual AndAlso Not isbeta Then
                            need_update = True
                        ElseIf isbeta_actual AndAlso isbeta AndAlso betaversion > betaversion_actual Then
                            need_update = True
                        End If
                    End If
                    If need_update Then
                        ' Initialize an instance of MultiThreadedWebDownloader.
                        _downloader = Nothing
                        _downloader = New MultiThreadedWebDownloader("http://files.velersoftware.com/softwarezator/updates/sz2012.rtf")
                        _downloader.Proxy = New WebProxy()

                        Try
                            _downloader.CheckFile()
                            _downloader.DownloadPath = Application.StartupPath & "\Temp\update.rtf"

                            ' Register the events of HttpDownloadClient.
                            AddHandler _downloader.DownloadCompleted, AddressOf DownloadCompleted
                            AddHandler _downloader.DownloadProgressChanged, AddressOf DownloadProgressChanged
                            AddHandler _downloader.StatusChanged, AddressOf StatusChanged
                            AddHandler _downloader.ErrorOccurred, AddressOf ErrorOccurred
                            ' Start to download file.
                            _downloader.Start()
                        Catch
                            Me.Label3.Text = RM.GetString("Content2")
                            _downloader = Nothing
                            Me.Panel1.Visible = False
                            Me.Panel2.Visible = True
                            If Mode_Silence Then
                                Application.Exit()
                            End If
                        End Try

                    Else
                        Me.Panel1.Visible = False
                        Me.Panel2.Visible = True
                        If Mode_Silence Then
                            Application.Exit()
                        End If
                    End If





                ElseIf .FileExists(Application.StartupPath & "\Temp\update.rtf") Then
                    Me.TextBox1.Rtf = .ReadAllText(Application.StartupPath & "\Temp\update.rtf")
                    .DeleteFile(Application.StartupPath & "\Temp\update.rtf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    Me.Label4.Text = String.Format(Me.Label4.Text, CStr(version_read).Insert(1, ".").Insert(3, ".").Insert(5, "."))
                    Me.Panel1.Visible = False
                    Me.Panel3.Visible = True
                    Windows7ProgressBar1.Value = 0
                    _downloader = Nothing
                    Me.Opacity = 1
                    Me.Visible = True
                    Me.Focus()





                ElseIf .FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Update_SoftwareZator_2012.tmp") Then
                    .RenameFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Update_SoftwareZator_2012.tmp", "Update_SoftwareZator_2012.exe")
                    Me.Panel4.Visible = False
                    Me.Panel5.Visible = True

                End If
            End If
        End With
    End Sub

    Private Sub ErrorOccurred(ByVal sender As Object, ByVal e As ErrorEventArgs)
        Me.Label3.Text = RM.GetString("Content3") & " :" & Environment.NewLine & e.Exception.Message
        Me.Panel1.Visible = False
        Me.Panel2.Visible = True
        ' Refresh the status.
        lbStatus.Text = _downloader.Status.ToString()
    End Sub


    ''' <summary>
    ''' Handle DownloadProgressChanged event.
    ''' </summary>
    Private Sub DownloadProgressChanged(ByVal sender As Object,
                                        ByVal e As MultiThreadedWebDownloaderProgressChangedEventArgs)
        ' Refresh the summary every second.
        If Date.Now > _lastNotificationTime.AddSeconds(1) Then
            If e.DownloadSpeed > 0 Then
                lbSummary.Text = String.Format(
                  RM.GetString("Content4"),
                  e.ReceivedSize \ 1024,
                  e.TotalSize \ 1024,
                  e.DownloadSpeed \ 1024,
                  _downloader.DownloadThreadsCount,
                  ((e.TotalSize) - (e.ReceivedSize)) \ (e.DownloadSpeed))
            Else
                lbSummary.Text = String.Format(
                   RM.GetString("Content5"),
                   e.ReceivedSize \ 1024,
                   e.TotalSize \ 1024,
                   e.DownloadSpeed \ 1024,
                   _downloader.DownloadThreadsCount)
            End If


            If CInt(Fix(e.ReceivedSize * 100 \ e.TotalSize)) <= 100 Then Windows7ProgressBar1.Value = CInt(Fix(e.ReceivedSize * 100 \ e.TotalSize))
            _lastNotificationTime = Date.Now
            ' Refresh the status.
            lbStatus.Text = _downloader.Status.ToString()
        End If
    End Sub

    ''' <summary>
    ''' Handle StatusChanged event.
    ''' </summary>
    Private Sub StatusChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Refresh the status.
        lbStatus.Text = _downloader.Status.ToString()

        If _downloader.Status = MultiThreadedWebDownloaderStatus.Paused Then
            lbSummary.Text = String.Format(
                RM.GetString("Content6"),
                _downloader.DownloadedSize / 1024,
                _downloader.TotalSize / 1024,
                _downloader.TotalUsedTime.Hours,
                _downloader.TotalUsedTime.Minutes,
                _downloader.TotalUsedTime.Seconds)
        End If
    End Sub

    Private Sub Form1_OnCancelButtonClicked(sender As System.Object, e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        My.Settings.CheckBeta = Me.CheckBox1.Checked
        Application.Exit()
    End Sub

    Private Sub CommandLink1_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink1.Click
        Windows7ProgressBar1.Value = 0

        ' Initialize an instance of MultiThreadedWebDownloader.
        _downloader = Nothing
        _downloader = New MultiThreadedWebDownloader(update_url)
        _downloader.Proxy = New WebProxy()

        Try
            _downloader.CheckFile()
            _downloader.DownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Update_SoftwareZator_2012.tmp"

            Me.Panel3.Visible = False
            Me.Panel4.Visible = True

            ' Register the events of HttpDownloadClient.
            AddHandler _downloader.DownloadCompleted, AddressOf DownloadCompleted
            AddHandler _downloader.DownloadProgressChanged, AddressOf DownloadProgressChanged
            AddHandler _downloader.StatusChanged, AddressOf StatusChanged
            AddHandler _downloader.ErrorOccurred, AddressOf ErrorOccurred
            ' Start to download file.
            _downloader.Start()
        Catch
            Me.Label3.Text = RM.GetString("Content7")
            _downloader = Nothing
            Me.Panel1.Visible = False
            Me.Panel2.Visible = True
        End Try
    End Sub

    Private Sub CommandLink2_Click(sender As System.Object, e As System.EventArgs) Handles CommandLink2.Click
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Update_SoftwareZator_2012.exe") Then
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Update_SoftwareZator_2012.exe")
            Application.Exit()
        End If
    End Sub

End Class
