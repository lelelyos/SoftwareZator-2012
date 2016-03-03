''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace BasesDeDoonees

    <System.Serializable()> _
    Public Class DataBases

        Public Sub New()

        End Sub

        Public Property Access As New Generic.List(Of Access)

        Public Property MySQL As New Generic.List(Of MySQL)

        Public Property SQLServer As New Generic.List(Of SQLServer)

    End Class

    <System.Serializable()> _
    Public Class Access

        Public Sub New()

        End Sub

        Public Sub New(ByVal fichier As String, ByVal mdp As String)
            Me.Fichier = fichier
            Me.MotDePasse = mdp
        End Sub

        Public Property Fichier As String

        Public Property MotDePasse As String

    End Class

    <System.Serializable()> _
    Public Class MySQL

        Public Sub New()

        End Sub

        Public Sub New(ByVal host As String, ByVal user As String, ByVal mdp As String, ByVal por As String, ByVal Initial_DataBase As String)
            With Me
                .Host = host
                .MotDePasse = mdp
                .Utilisateur = user
                .Port = por
                .Base_de_données_initial = Initial_DataBase
            End With
        End Sub

        Public Property Host As String

        Public Property Utilisateur As String

        Public Property MotDePasse As String

        Public Property Port As String

        Public Property Base_de_données_initial As String

    End Class

    <System.Serializable()> _
    Public Class SQLServer

        Public Sub New()

        End Sub

        Public Sub New(ByVal host As String, ByVal user As String, ByVal mdp As String, ByVal por As String, ByVal locale As Boolean, ByVal Initial_DataBase As String)
            With Me
                .Host = host
                .MotDePasse = mdp
                .Utilisateur = user
                .Port = por
                .Locale = locale
                .Base_de_données_initial = Initial_DataBase
            End With
        End Sub

        Public Property Host As String

        Public Property Utilisateur As String

        Public Property MotDePasse As String

        Public Property Port As String

        Public Property Locale As Boolean

        Public Property Base_de_données_initial As String

    End Class

End Namespace
