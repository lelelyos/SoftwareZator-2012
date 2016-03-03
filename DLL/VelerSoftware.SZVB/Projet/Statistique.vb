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

    ' STATISTIQUES
    Public Class Statistique

        ' Type de statistique
        Enum Type
            BuildSuccess
            BuildFail
        End Enum

        Sub New()

        End Sub

        Sub New(ByVal X_Value As Double, ByVal Y_Value As Double, ByVal Type_Value As VelerSoftware.SZVB.Projet.Statistique.Type)
            XValue = X_Value
            YValue = Y_Value
            TypeValue = Type_Value
        End Sub

        Public Property XValue As Double

        Public Property YValue As Double

        Public Property TypeValue As VelerSoftware.SZVB.Projet.Statistique.Type

    End Class

End Namespace