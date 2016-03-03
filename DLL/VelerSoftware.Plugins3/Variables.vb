''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Friend Module Variables

    Friend RM As System.Resources.ResourceManager = Nothing

    Private _SZ_Edition As Integer = -1
    Public Property SZ_Edition As Integer
        Get
            Return _SZ_Edition
        End Get
        Set(value As Integer)
            If _SZ_Edition = -1 Then _SZ_Edition = value
        End Set
    End Property

End Module
