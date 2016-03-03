''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.ComponentModel

<System.ComponentModel.Designer(GetType(ActionDesigner))>
Public Class ActionWithChildren
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        Children_Actions = New System.Collections.Generic.List(Of Action)()
    End Sub

End Class


