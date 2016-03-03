''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxAideRapide

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

End Class
