''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ClassLog

    ' Log
    Private WithEvents _Log As New LogGenericList
    Public Property Log() As LogGenericList
        Get
            Return _Log
        End Get
        Set(ByVal value As LogGenericList)
            _Log = value
        End Set
    End Property

    Private Sub _Log_Added(sender As Object, e As System.EventArgs) Handles _Log.OnLogAdded
        RaiseEvent OnLogChanged(Me, New EventArgs)
    End Sub


    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnLogChangedEventHandler(ByVal sender As ClassLog, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Event OnLogChanged As OnLogChangedEventHandler

    Public Class LogType
        Enum Tip
            Info
            Warning
            [Error]
        End Enum

        Public Sub New(ByVal _type As Tip, ByVal _text As String)
            Texte = _text
            InfoType = _type
        End Sub

        Public Property Texte As String
        Public Property InfoType As Tip
    End Class

    Public Class LogGenericList
        Inherits Generic.List(Of LogType)

        Public Overloads Sub Add(item As LogType)
            MyBase.Add(item)
            RaiseEvent OnLogAdded(item, New EventArgs)
        End Sub


        ''' <summary>
        ''' Declare un delegate
        ''' </summary>
        Public Delegate Sub OnLogAddedEventHandler(ByVal sender As LogType, ByVal e As System.EventArgs)
        ''' <summary>
        ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
        ''' </summary>
        Public Event OnLogAdded As OnLogAddedEventHandler

    End Class

End Class
