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

    ' PROJET
    Public Class Solution

        Enum LastBuildTypes
            None
            Normal
            Obfusced
            Debug
        End Enum

        Public Sub New()

        End Sub

        Public Sub New(ByVal Name As String)
            Nom = Name
        End Sub




        Public Property GenerationOrder As New Generic.List(Of String)

        Public Property Projets As New Generic.List(Of Projet)

        Public Function GetProject(ByVal Nom As String) As VelerSoftware.SZVB.Projet.Projet
            Dim proj As VelerSoftware.SZVB.Projet.Projet = Nothing
            For Each pr As VelerSoftware.SZVB.Projet.Projet In Projets ' On récupère le projet auquel appartient le dossier
                If pr.Nom = Nom Then
                    proj = pr
                    Exit For
                End If
            Next
            Return proj
        End Function




        Public Property Nom() As String

        Public Property Nom_Fichier_Projet() As String

        Public Property Emplacement() As String

        Public Property ProjetDemarrage() As String

        Public Property LastBuildType As LastBuildTypes = LastBuildTypes.None

    End Class

End Namespace