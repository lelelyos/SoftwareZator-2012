''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

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

End Class