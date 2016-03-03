''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Friend Class ToolStripNumericUpDown
    Inherits System.Windows.Forms.ToolStripControlHost
    ' Call the base constructor passing in a MonthCalendar instance.
    Public Sub New()
        MyBase.New(New System.Windows.Forms.NumericUpDown())
        With NumericUpDown
            .Dock = System.Windows.Forms.DockStyle.Fill
            .Minimum = 0
            .Maximum = 999999999999
            .Size = Me.NumericUpDown.PreferredSize
        End With
        AddHandler Me.NumericUpDown.KeyPress, AddressOf On_Key_Press
    End Sub

    Public ReadOnly Property NumericUpDown() As System.Windows.Forms.NumericUpDown
        Get
            Return TryCast(Control, System.Windows.Forms.NumericUpDown)
        End Get
    End Property

    Protected Overrides Sub OnBoundsChanged()
        MyBase.OnBoundsChanged()
        Me.NumericUpDown.Size = Me.NumericUpDown.PreferredSize
    End Sub

    Private Sub On_Key_Press(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If CType(e, System.Windows.Forms.KeyPressEventArgs).KeyChar = ChrW(System.Windows.Forms.Keys.Enter) Then
            Me.OnValidated(New System.EventArgs)
        End If
    End Sub

    Public Property value() As Decimal
        Get
            Return NumericUpDown.Value
        End Get
        Set(ByVal value As Decimal)
            NumericUpDown.Value = value
        End Set
    End Property
End Class