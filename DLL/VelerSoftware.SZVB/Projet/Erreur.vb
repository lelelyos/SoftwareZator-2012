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

    ' ERREUR
    Public Class Erreur

        Enum ErrorType
            Building
            RunTime
        End Enum

        Sub New()

        End Sub

        Public Property ErrorNumber As String

        Public Property ErrorText As String

        Public Property ErrorLine As Integer

        Public Property ErrorColumn As Integer

        Public Property ErrorExplain As String

        Public Property ErrorSolutionExplain As String

        Public Property ProjectName As String

        Public Property FunctionName As String

        Public Property FileName As String

        Public Property ActionId As String

        Public Property ActionName As String

        Public Property Type As ErrorType

    End Class

End Namespace