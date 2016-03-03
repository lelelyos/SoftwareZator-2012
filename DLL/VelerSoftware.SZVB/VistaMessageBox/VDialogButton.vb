''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace VistaDialog

    ''' <summary>
    ''' Represents a button on VDialog form.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class VDialogButton

#Region " Fields and Properties "

        Private _useCustomText As Boolean
        ''' <summary>
        ''' Determines whether the button should contain a custom text.
        ''' </summary>
        Public Property UseCustomText() As Boolean
            Get
                Return _useCustomText
            End Get
            Set(ByVal value As Boolean)
                _useCustomText = value
            End Set
        End Property

        Private _text As String
        ''' <summary>
        ''' The custom text shown on the button.
        ''' </summary>
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property

        Private _vDialogResult As VDialogResult
        ''' <summary>
        ''' Determines the value returned to the parent form when the button is clicked.
        ''' </summary>
        Public Property VDialogResult() As VDialogResult
            Get
                Return _vDialogResult
            End Get
            Set(ByVal value As VDialogResult)
                _vDialogResult = value
            End Set
        End Property

        Private _showElevationIcon As Boolean
        ''' <summary>
        ''' Determines whether to show the elevation icon (shield).
        ''' </summary>
        Public Property ShowElevationIcon() As Boolean
            Get
                Return _showElevationIcon
            End Get
            Set(ByVal value As Boolean)
                _showElevationIcon = value
            End Set
        End Property

#End Region

#Region " Events "

        ''' <summary>
        ''' Occurs when the button is clicked, but before the VDialog form is closed.
        ''' </summary>
        Public Event Click As EventHandler
        Friend Sub RaiseClickEvent(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent Click(sender, e)
        End Sub

#End Region

#Region " Constructors "

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="vDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        Public Sub New(ByVal vDialogResult As VDialogResult)
            _vDialogResult = vDialogResult
        End Sub

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="vDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        ''' <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        Public Sub New(ByVal vDialogResult As VDialogResult, ByVal showElevationIcon As Boolean)
            _vDialogResult = vDialogResult
            _showElevationIcon = showElevationIcon
        End Sub

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="text">The custom text shown on the button.</param>
        ''' <param name="click">Occurs when the button is clicked, but before the VDialog form is closed.</param>
        Public Sub New(ByVal text As String, ByVal click As EventHandler)
            _useCustomText = True
            _text = text
            _vDialogResult = VDialogResult.None
            AddHandler Me.Click, click
        End Sub

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="text">The custom text shown on the button.</param>
        ''' <param name="click">Occurs when the button is clicked, but before the VDialog form is closed.</param>
        ''' <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        Public Sub New(ByVal text As String, ByVal click As EventHandler, ByVal showElevationIcon As Boolean)
            _useCustomText = True
            _text = text
            _vDialogResult = VDialogResult.None
            AddHandler Me.Click, click
            _showElevationIcon = showElevationIcon
        End Sub

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="vDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        ''' <param name="text">The custom text shown on the button.</param>
        Public Sub New(ByVal vDialogResult As VDialogResult, ByVal text As String)
            _useCustomText = True
            _text = text
            _vDialogResult = vDialogResult
        End Sub

        ''' <summary>
        ''' Initializes the new instance of the VDialogButton.
        ''' </summary>
        ''' <param name="vDialogResult">Determines the value returned to the parent form when the button is clicked.</param>
        ''' <param name="text">The custom text shown on the button.</param>
        ''' <param name="showElevationIcon">Determines whether to show the elevation icon (shield).</param>
        Public Sub New(ByVal vDialogResult As VDialogResult, ByVal text As String, ByVal showElevationIcon As Boolean)
            _useCustomText = True
            _text = text
            _vDialogResult = vDialogResult
            _showElevationIcon = showElevationIcon
        End Sub

#End Region

    End Class

End Namespace