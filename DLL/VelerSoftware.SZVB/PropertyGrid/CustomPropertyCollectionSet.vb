''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace PropertyGrids
    Public Class CustomPropertyCollectionSet
        Inherits System.Collections.CollectionBase

        Public Overridable Function Add(ByVal value As CustomPropertyCollection) As Integer
            Return MyBase.List.Add(value)
        End Function

        Public Overridable Function Add() As Integer
            Return MyBase.List.Add(New CustomPropertyCollection)
        End Function

        Default Public Overridable Property Item(ByVal index As Integer) As CustomPropertyCollection
            Get
                Return DirectCast(MyBase.List.Item(index), CustomPropertyCollection)
            End Get
            Set(ByVal value As CustomPropertyCollection)
                MyBase.List.Item(index) = value
            End Set
        End Property

        Public Overridable Function ToArray()
            Dim list As New ArrayList
            list.AddRange(MyBase.List)
            Return list.ToArray(GetType(CustomPropertyCollection))
        End Function

    End Class
End Namespace
