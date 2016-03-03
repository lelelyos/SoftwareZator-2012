''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace Windows

    Public Class Core

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows XP
        ''' </summary>
        Shared ReadOnly Property RunningOnXP() As Boolean
            Get
                Return Environment.OSVersion.Version.Major = 5
            End Get
        End Property

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows Vista
        ''' </summary>
        Shared ReadOnly Property RunningOnVista() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor < 1)
            End Get
        End Property

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows 7
        ''' </summary>
        Shared ReadOnly Property RunningOnWin7() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor = 1)
            End Get
        End Property

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows 8
        ''' </summary>
        Shared ReadOnly Property RunningOnWin8() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 2)
            End Get
        End Property

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows 7 or 8
        ''' </summary>
        Shared ReadOnly Property RunningOnWinVistaOr7Or8() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6)
            End Get
        End Property

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows 7 or 8
        ''' </summary>
        Shared ReadOnly Property RunningOnWin7Or8() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6 AndAlso (Environment.OSVersion.Version.Minor = 1 OrElse Environment.OSVersion.Version.Minor >= 2))
            End Get
        End Property

        ''' <summary>
        ''' Récupère l'image au format Bitmap d'un Icon
        ''' </summary>
        Shared Function GetBitmapFromIcon(ByVal Icon As Drawing.Icon) As Drawing.Bitmap
            Dim bmp As Drawing.Bitmap = Icon.ToBitmap
            Dim gxMem As Drawing.Graphics = Drawing.Graphics.FromImage(bmp)
            gxMem.DrawIcon(Icon, 0, 0)
            gxMem.Dispose()
            Return bmp
        End Function

        Shared Function BitmapToBase64(ByVal image As System.Drawing.Image) As String
            Dim base64 As String
            Dim memory As New System.IO.MemoryStream()
            image.Save(memory, image.RawFormat)
            base64 = System.Convert.ToBase64String(memory.ToArray)
            memory.Close()
            memory = Nothing
            Return base64
        End Function

        Shared Function BitmapFromBase64(ByVal base64 As String) As System.Drawing.Image
            Dim oBitmap As System.Drawing.Image
            Dim memory As New System.IO.MemoryStream(Convert.FromBase64String(base64))
            oBitmap = System.Drawing.Image.FromStream(memory, True, True)
            memory.Close()
            memory = Nothing
            Return oBitmap
        End Function




        Private Declare Function InternetGetConnectedState Lib "wininet.dll" Alias "InternetGetConnectedState" (ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Boolean

        Shared Function IsConnected() As Boolean
            Dim Desc As Integer
            Return InternetGetConnectedState(Desc, 0)
        End Function



        Shared Function GetFrameworkVersion() As String
            With Microsoft.Win32.Registry.LocalMachine
                Dim test As Microsoft.Win32.RegistryKey
                test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", False)
                If Not test Is Nothing Then
                    Return test.GetValue("Version")
                    Exit Function
                End If
                test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client", False)
                If Not test Is Nothing Then
                    Return test.GetValue("Version")
                    Exit Function
                End If
                test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5", False)
                If Not test Is Nothing Then
                    Return test.GetValue("Version")
                    Exit Function
                End If
                test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.0\Setup", False)
                If Not test Is Nothing Then
                    Return test.GetValue("Version")
                    Exit Function
                End If
                test = .OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727", False)
                If Not test Is Nothing Then
                    Return test.GetValue("Version")
                    Exit Function
                End If
            End With
            Return Nothing
        End Function

    End Class

End Namespace