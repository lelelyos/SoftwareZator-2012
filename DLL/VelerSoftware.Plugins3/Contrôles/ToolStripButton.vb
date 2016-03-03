''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Friend Class ToolStripButton
    Inherits System.Windows.Forms.ToolStripControlHost
    ' Call the base constructor passing in a MonthCalendar instance.
    Public Sub New()
        MyBase.New(New System.Windows.Forms.Button())
        With Button
            .Dock = System.Windows.Forms.DockStyle.Fill
            .FlatStyle = System.Windows.Forms.FlatStyle.System
        End With
        Me.Height = 22
    End Sub

    Public ReadOnly Property Button() As System.Windows.Forms.Button
        Get
            Return TryCast(Control, System.Windows.Forms.Button)
        End Get
    End Property

    Protected Overrides Sub OnBoundsChanged()
        MyBase.OnBoundsChanged()
        With Button
            .Dock = System.Windows.Forms.DockStyle.Fill
        End With
        Me.Height = 22
    End Sub

End Class