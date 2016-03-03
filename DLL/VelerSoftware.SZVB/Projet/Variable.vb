''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace Projet

    ' VARIABLES
    Public Class Variable

        Public Sub New()

        End Sub

        Public Sub New(ByVal N As String, ByVal A As Boolean, ByVal D As String, ByVal G As String, Optional ByVal Nu As Boolean = False)
            Name = N
            Array = A
            Description = D
            Group = G
            NullAtStart = Nu
        End Sub

        Public Property Name() As String

        Public Property Description() As String

        Public Property Group() As String

        Public Property Array() As Boolean

        Public Property NullAtStart() As Boolean

        Public Overrides Function ToString() As String
            Return Name
        End Function

    End Class

End Namespace