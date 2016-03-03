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

    ' RESSOURCE
    Public Class Ressource

        Enum Types
            Texte
            Image
            Fichier
        End Enum

        Sub New()

        End Sub

        Sub New(ByVal Tip As Types, ByVal Nam As String, ByVal Val As String)
            _Type = Tip
            _Name = Nam
            _Value = Val
        End Sub

        Public Property Type() As Types

        Public Property Value() As String

        Public Property Name() As String

    End Class

End Namespace