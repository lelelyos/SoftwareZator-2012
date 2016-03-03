''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<System.Windows.Forms.Docking(System.Windows.Forms.DockingBehavior.Ask), ComponentModel.DefaultProperty("MaPropriete"), ComponentModel.DefaultEvent("OnButtonClick"), ComponentModel.Designer(GetType(Info_Bar_SmartTag))> _
Public Class Info_Bar

    Public Overloads Sub Show(ByVal _style As Style, ByVal _text As String, ByVal _button_text As String, ByVal _button_visible As Boolean, ByVal _tag As String, ByVal _objet As Object, Optional ByVal _image As Drawing.Image = Nothing)
        With Me
            .BarStyle = _style
            .BarText = _text
            .ButtonText = _button_text
            .ButtonVisible = _button_visible
            .Tag = _tag
            .Objects = _objet
            If Not _image Is Nothing Then .Image = _image
        End With
        MyBase.Show()
    End Sub

    Enum Style
        Info
        Warning
        Errors
        Good
        Custom
    End Enum

    Private _BarStyle As Style = Style.Good
    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Définit le style de la barre."), ComponentModel.DefaultValue(Style.Good)> _
    Public Property BarStyle() As Style
        Get
            Return _BarStyle
        End Get
        Set(ByVal value As Style)
            _BarStyle = value
            Select Case _BarStyle
                Case Style.Errors
                    Me.PictureBox2.Image = My.Resources._Error
                Case Style.Good
                    Me.PictureBox2.Image = My.Resources.Good
                Case Style.Info
                    Me.PictureBox2.Image = My.Resources.Info
                Case Style.Warning
                    Me.PictureBox2.Image = My.Resources.Warning
            End Select
            Me.Refresh()
            RaiseEvent OnBarStyleChanged(Me, New System.EventArgs)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Définit le texte de la barre."), ComponentModel.DefaultValue("Information")> _
    Public Property BarText() As String
        Get
            Return Me.Label1.Text
        End Get
        Set(ByVal value As String)
            Me.Label1.Text = value
        End Set
    End Property

    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Définit le texte du bouton."), ComponentModel.DefaultValue("Cliquez ici !")> _
    Public Property ButtonText() As String
        Get
            Return Me.Button1.Text
        End Get
        Set(ByVal value As String)
            Me.Button1.Text = value
        End Set
    End Property

    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Définit l'image (à gauche) de la barre.")> _
    Public Property Image() As Drawing.Image
        Get
            Return Me.PictureBox2.Image
        End Get
        Set(ByVal value As Drawing.Image)
            Me.PictureBox2.Image = value
            RaiseEvent OnImageChanged(Me.PictureBox2, New System.EventArgs)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Détermine si le bouton doit être visible ou non."), ComponentModel.DefaultValue("True")> _
    Public Property ButtonVisible() As Boolean
        Get
            Return Me.Button1.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Button1.Visible = value
        End Set
    End Property

    Private _TopColor As Drawing.Color
    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Couleur Haut du dégradé pour le style Custom.")> _
    Public Property TopColor() As Drawing.Color
        Get
            Return _TopColor
        End Get
        Set(ByVal value As Drawing.Color)
            _TopColor = value
            Me.Refresh()
            RaiseEvent OnBarStyleChanged(Me, New System.EventArgs)
        End Set
    End Property

    Private _BottomColor As Drawing.Color
    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("Couleur Bas du dégradé pour le style Custom.")> _
    Public Property BottomColor() As Drawing.Color
        Get
            Return _BottomColor
        End Get
        Set(ByVal value As Drawing.Color)
            _BottomColor = value
            Me.Refresh()
            RaiseEvent OnBarStyleChanged(Me, New System.EventArgs)
        End Set
    End Property

    Private _Object As Object
    <ComponentModel.Category("Propriétés de l'Info_Bar"), ComponentModel.Description("")> _
    Public Property Objects() As Object
        Get
            Return _Object
        End Get
        Set(ByVal value As Object)
            _Object = value
        End Set
    End Property











    Private Sub Info_Bar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If BarStyle = Style.Errors Then
            Using b As Drawing.Brush = New Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, Drawing.Color.FromArgb(255, 189, 189), Drawing.Color.FromArgb(255, 130, 130), Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
            Using p As New Drawing.Pen(Drawing.Color.FromArgb(180, 85, 85))
                Dim rect As Drawing.Rectangle = ClientRectangle
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Width), rect.Width + 1)
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Height), rect.Height + 1)
                e.Graphics.DrawRectangle(p, rect)
            End Using

        ElseIf BarStyle = Style.Good Then
            Using b As Drawing.Brush = New Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, Drawing.Color.FromArgb(195, 255, 189), Drawing.Color.FromArgb(136, 255, 130), Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
            Using p As New Drawing.Pen(Drawing.Color.FromArgb(96, 180, 85))
                Dim rect As Drawing.Rectangle = ClientRectangle
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Width), rect.Width + 1)
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Height), rect.Height + 1)
                e.Graphics.DrawRectangle(p, rect)
            End Using

        ElseIf BarStyle = Style.Info Then
            Using b As Drawing.Brush = New Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, Drawing.Color.FromArgb(189, 192, 255), Drawing.Color.FromArgb(130, 133, 255), Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
            Using p As New Drawing.Pen(Drawing.Color.FromArgb(85, 89, 180))
                Dim rect As Drawing.Rectangle = ClientRectangle
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Width), rect.Width + 1)
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Height), rect.Height + 1)
                e.Graphics.DrawRectangle(p, rect)
            End Using

        ElseIf BarStyle = Style.Warning Then
            Using b As Drawing.Brush = New Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, Drawing.Color.FromArgb(255, 246, 189), Drawing.Color.FromArgb(255, 236, 130), Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
            Using p As New Drawing.Pen(Drawing.Color.FromArgb(180, 165, 85))
                Dim rect As Drawing.Rectangle = ClientRectangle
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Width), rect.Width + 1)
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Height), rect.Height + 1)
                e.Graphics.DrawRectangle(p, rect)
            End Using

        ElseIf BarStyle = Style.Custom Then
            Using b As Drawing.Brush = New Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, TopColor, BottomColor, Drawing.Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
            Using p As New Drawing.Pen(Drawing.Color.FromArgb(118, 118, 118))
                Dim rect As Drawing.Rectangle = ClientRectangle
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Width), rect.Width + 1)
                System.Math.Max(System.Threading.Interlocked.Decrement(rect.Height), rect.Height + 1)
                e.Graphics.DrawRectangle(p, rect)
            End Using
        End If
    End Sub

    Private Sub Info_Bar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = System.Windows.Forms.DockStyle.Top
    End Sub








    Private Sub Info_Bar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.Size.Height > 30 Then
            Me.Size = New Drawing.Size(Me.Size.Width, 30)
        End If
        Me.Refresh()
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        Me.PictureBox1.Image = My.Resources.info_bar_close_hover
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Me.PictureBox1.Image = My.Resources.info_bar_close_normal
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Me.PictureBox1.Image = My.Resources.info_bar_close_press
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Me.PictureBox1.Image = My.Resources.info_bar_close_hover
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
        RaiseEvent OnCloseButtonClick(Me.PictureBox1, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent OnButtonClick(Me.Button1, e)
    End Sub

    Private Sub Button1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.VisibleChanged
        RaiseEvent OnButtonVisibleChanged(Me.Button1, e)
    End Sub

    Private Sub Label1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        RaiseEvent OnTextChanged(Me.Label1, e)
    End Sub

    Private Sub Button1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.TextChanged
        RaiseEvent OnButtonTextChanged(Me.Label1, e)
    End Sub











#Region "Event"

#Region "OnButtonClick"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnButtonClickEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Event OnButtonClick As OnButtonClickEventHandler

#End Region

#Region "OnButtonVisibleChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnButtonVisibleChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Event OnButtonVisibleChanged As OnButtonVisibleChangedEventHandler

#End Region

#Region "OnCloseButtonClick"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnCloseButtonClickEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Event OnCloseButtonClick As OnCloseButtonClickEventHandler

#End Region

#Region "OnBarStyleChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnBarStyleChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Event OnBarStyleChanged As OnBarStyleChangedEventHandler

#End Region

#Region "OnTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Shadows Event OnTextChanged As OnTextChangedEventHandler

#End Region

#Region "OnButtonTextChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnButtonTextChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Shadows Event OnButtonTextChanged As OnButtonTextChangedEventHandler

#End Region

#Region "OnImageChanged"

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnImageChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    Public Shadows Event OnImageChanged As OnImageChangedEventHandler

#End Region

#End Region

End Class
