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

    Friend Class Cores

        ''' <summary>
        ''' Déterminer si l'application fonctionne sur Windows 7 or 8
        ''' </summary>
        Shared ReadOnly Property RunningOnWinVistaOr7Or8() As Boolean
            Get
                Return (Environment.OSVersion.Version.Major = 6)
            End Get
        End Property

    End Class

End Namespace

Namespace Windows.Core

    Public Class [Object]

        Public Sub New(ByVal _FullName As String, ByVal _Object As Object, ByVal _ObjectType As Type)
            FullName = _FullName
            Me.Object = _Object
            ObjectType = _ObjectType
        End Sub

        Public Property FullName As String

        Public Property [Object] As Object

        Public Property ObjectType As Type

    End Class

End Namespace