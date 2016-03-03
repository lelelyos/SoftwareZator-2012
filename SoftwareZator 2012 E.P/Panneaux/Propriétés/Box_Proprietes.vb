''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxProprietes

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.PropertyGrids1.Font = font
        Me.PropertyGrids1.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.PropertyGrids1.ViewBackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.PropertyGrids1.BackColor = System.Drawing.Color.FromArgb(187, 206, 230)
                Me.PropertyGrids1.CommandsBackColor = System.Drawing.Color.FromArgb(187, 206, 230)
                Me.PropertyGrids1.HelpBackColor = System.Drawing.Color.FromArgb(187, 206, 230)
                Me.PropertyGrids1.LineColor = System.Drawing.Color.FromArgb(187, 206, 230)
                Me.PropertyGrids1.CategoryForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.PropertyGrids1.HelpForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.PropertyGrids1.CommandsForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.PropertyGrids1.ViewForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.PropertyGrids1.ViewBackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.PropertyGrids1.BackColor = System.Drawing.Color.FromArgb(227, 230, 232)
                Me.PropertyGrids1.CommandsBackColor = System.Drawing.Color.FromArgb(227, 230, 232)
                Me.PropertyGrids1.HelpBackColor = System.Drawing.Color.FromArgb(227, 230, 232)
                Me.PropertyGrids1.LineColor = System.Drawing.Color.FromArgb(227, 230, 232)
                Me.PropertyGrids1.CategoryForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.PropertyGrids1.HelpForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.PropertyGrids1.CommandsForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.PropertyGrids1.ViewForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.PropertyGrids1.ViewBackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.PropertyGrids1.BackColor = System.Drawing.Color.FromArgb(113, 113, 113)
                Me.PropertyGrids1.CommandsBackColor = System.Drawing.Color.FromArgb(113, 113, 113)
                Me.PropertyGrids1.HelpBackColor = System.Drawing.Color.FromArgb(113, 113, 113)
                Me.PropertyGrids1.LineColor = System.Drawing.Color.FromArgb(113, 113, 113)
                Me.PropertyGrids1.CategoryForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.PropertyGrids1.HelpForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.PropertyGrids1.CommandsForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.PropertyGrids1.ViewForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub

    Private Sub PropertyGrids1_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrids1.PropertyValueChanged
        If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 AndAlso _
            TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocParametresDuProjet AndAlso _
            TypeOf e.ChangedItem.Value Is String AndAlso _
            Not CStr(e.ChangedItem.Value) = Nothing AndAlso _
            CStr(e.ChangedItem.Label) = RM.GetString("Doc_Parametres_Du_Projet_7") Then

            DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocParametresDuProjet).ListView1.SelectedItems(0).SubItems(2).Text = e.ChangedItem.Value
            DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocParametresDuProjet).DocumentModifier()
        End If
    End Sub

    Private Sub PropertyGrids1_SelectedObjectsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyGrids1.SelectedObjectsChanged
        If Me.PropertyGrids1.SelectedObject Is Nothing Then
            Me.KryptonRichTextBox1.Rtf = "{\rtf1" & Nothing & "}"
        End If
    End Sub

End Class
