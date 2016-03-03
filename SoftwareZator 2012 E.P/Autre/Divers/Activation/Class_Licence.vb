<System.Serializable()> _
Public Class Class_Licence

    Public Sub New()

    End Sub

    Public Sub New(ByVal Nom_ As String, ByVal Prénom_ As String, ByVal Pays_ As String, ByVal CodePostal_ As String, ByVal Email_ As String, ByVal Facture_ As Integer, ByVal Edition_ As Integer, ByVal CodeActivation_ As String)
        Nom = Nom_
        Prénom = Prénom_
        Pays = Pays_
        CodePostal = CodePostal_
        Email = Email_
        Facture = Facture_
        Edition = Edition_
        CodeActivation = CodeActivation_
    End Sub

    Public Property Nom As String

    Public Property Prénom As String

    Public Property Pays As String

    Public Property CodePostal As String

    Public Property Email As String

    Public Property Facture As Integer

    Public Property Edition As Integer

    Public Property CodeActivation As String

End Class
