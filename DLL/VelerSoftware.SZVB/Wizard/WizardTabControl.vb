''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

' <ComponentModel.Designer(GetType(AeroWizardTabControlDesigner))> _
Public Class WizardTabControl
    Inherits System.Windows.Forms.TabControl

    Public Overrides ReadOnly Property DisplayRectangle() As System.Drawing.Rectangle
        Get
            If (Not Me.DesignMode) Then
                Return New Drawing.Rectangle(0, 0, Width, Height)
            Else
                Return MyBase.DisplayRectangle
            End If
        End Get
    End Property

End Class