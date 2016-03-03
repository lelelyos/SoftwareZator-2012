''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxDebogage

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Me.KryptonButton1.Enabled = False

        Dim iconControl As VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls.NodeIcon = New VelerSoftware.SZC.Debugger.TreeModel.ItemIcon()
        iconControl.ParentColumn = Me.TreeColumn1
        Me.TreeViewAdv1.NodeControls.Add(iconControl)

        Dim nameControl As VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls.NodeControl = New VelerSoftware.SZC.Debugger.TreeModel.ItemName()
        nameControl.ParentColumn = Me.TreeColumn1
        Me.TreeViewAdv1.NodeControls.Add(nameControl)

        Dim textControl As VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls.NodeControl = New VelerSoftware.SZC.Debugger.TreeModel.ItemText()
        textControl.ParentColumn = Me.TreeColumn2
        Me.TreeViewAdv1.NodeControls.Add(textControl)

        Dim typeControl As VelerSoftware.SZC.TreeViewAdv.Tree.NodeControls.NodeControl = New VelerSoftware.SZC.Debugger.TreeModel.ItemType()
        typeControl.ParentColumn = Me.TreeColumn3
        Me.TreeViewAdv1.NodeControls.Add(typeControl)

        Me.TreeViewAdv1.AutoRowHeight = True
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.TreeViewAdv1.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.TreeViewAdv1.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.TreeViewAdv1.LineColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.TreeViewAdv1.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.TreeViewAdv1.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.TreeViewAdv1.LineColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.TreeViewAdv1.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.TreeViewAdv1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.TreeViewAdv1.LineColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub

    Private Sub TreeViewAdv1_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles TreeViewAdv1.VisibleChanged
        Me.TreeViewAdv1.Focus()
        Me.TreeViewAdv1.OnGotFocus(e)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Me.TreeViewAdv1.SelectedNode IsNot Nothing Then
            Me.CopierToolStripMenuItem.Enabled = True
        Else
            Me.CopierToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub CopierToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopierToolStripMenuItem.Click
        If Me.TreeViewAdv1.SelectedNode IsNot Nothing Then
            Clipboard.SetText("Variable : " & DirectCast(Me.TreeViewAdv1.SelectedNode, VelerSoftware.SZC.Debugger.TreeModel.TreeViewVarNode).Content.Name & Environment.NewLine & "Value : " & DirectCast(Me.TreeViewAdv1.SelectedNode, VelerSoftware.SZC.Debugger.TreeModel.TreeViewVarNode).Content.Text & Environment.NewLine & "Value type : " & DirectCast(Me.TreeViewAdv1.SelectedNode, VelerSoftware.SZC.Debugger.TreeModel.TreeViewVarNode).Content.Type)
        End If
    End Sub

    Private Sub CopierToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonContextMenuItem1.Click
        If Not Me.KryptonRichTextBox1.SelectedText = Nothing Then
            Clipboard.SetText(Me.KryptonRichTextBox1.SelectedText)
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        If Not Me.KryptonButton1.Tag = Nothing Then
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\", Me.KryptonButton1.Tag)) Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help.exe") Then
                    System.Diagnostics.Process.Start(Application.StartupPath & "\Help.exe", ChrW(34) & My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\", Me.KryptonButton1.Tag) & "#debug" & ChrW(34))
                End If
            End If
        End If
    End Sub
End Class
