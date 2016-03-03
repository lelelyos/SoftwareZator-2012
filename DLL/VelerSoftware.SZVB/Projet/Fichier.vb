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

    ' FICHIER SZC
    <System.Serializable()> _
    Public Class SZC_File

        Public Sub New()

        End Sub

        Public Sub New(ByVal Name As String)
            Nom = Name
        End Sub

        Public Property Functions As New Generic.List(Of String) ' Est égale aux fonctions

        Public Property Nom As String

    End Class

    ' FICHIER SZC
    Public Class SZC_File_Tmp
        Inherits SZC_File
        Implements IDisposable


        Public Property Fichier As String

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Pour détecter les appels redondants

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                End If

                Me.Fichier = Nothing
                Me.Functions.Clear()
                Me.Functions = Nothing
                Me.Nom = Nothing
                ' TODO: libérez les ressources non managées (objets non managés) et substituez la méthode Finalize() ci-dessous.
                ' TODO: définissez les champs volumineux à null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: substituez Finalize() uniquement si Dispose(ByVal disposing As Boolean) ci-dessus comporte du code permettant de libérer des ressources non managées.
        'Protected Overrides Sub Finalize()
        '    ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region

    End Class









    ' FICHIER SZW
    <Serializable()> _
    Public Class SZW_File

        Public Sub New()

        End Sub

        Public Sub New(ByVal Name As String)
            Nom = Name
        End Sub

        Public Property Functions As New Generic.List(Of String) ' Est égale aux fonctions

        Public Property Resources As String ' Est égale aux ressources

        Public Property WINDOWS As CodeDom.CodeCompileUnit

        Public Property Nom As String

    End Class

    ' FICHIER SZW
    Public Class SZW_File_Tmp
        Inherits SZW_File
        Implements IDisposable


        Public Property Fichier As String

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Pour détecter les appels redondants

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                End If

                Me.Fichier = Nothing
                Me.Functions.Clear()
                Me.Functions = Nothing
                Me.Nom = Nothing
                Me.Resources = Nothing
                Me.WINDOWS = Nothing
                ' TODO: libérez les ressources non managées (objets non managés) et substituez la méthode Finalize() ci-dessous.
                ' TODO: définissez les champs volumineux à null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: substituez Finalize() uniquement si Dispose(ByVal disposing As Boolean) ci-dessus comporte du code permettant de libérer des ressources non managées.
        'Protected Overrides Sub Finalize()
        '    ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region

    End Class

End Namespace