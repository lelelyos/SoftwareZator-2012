''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxSortie

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Me.ToolStripComboBox1.SelectedIndex = 1
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.ToolStrip1.Font = font

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.KryptonRichTextBox1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.KryptonRichTextBox1.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.KryptonRichTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.KryptonRichTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.KryptonRichTextBox1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.KryptonRichTextBox1.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.KryptonRichTextBox1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.KryptonRichTextBox1.StateNormal.Content.Color1 = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.KryptonRichTextBox1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.KryptonRichTextBox1.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.KryptonRichTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.KryptonRichTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.KryptonRichTextBox1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.KryptonRichTextBox1.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.KryptonRichTextBox1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.KryptonRichTextBox1.StateNormal.Content.Color1 = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.KryptonRichTextBox1.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.KryptonRichTextBox1.StateActive.Content.Color1 = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.KryptonRichTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.KryptonRichTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.KryptonRichTextBox1.StateDisabled.Back.Color1 = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.KryptonRichTextBox1.StateDisabled.Content.Color1 = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.KryptonRichTextBox1.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.KryptonRichTextBox1.StateNormal.Content.Color1 = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub

    Private Sub KryptonRichTextBox1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles KryptonRichTextBox1.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Public Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Dim strr As New System.Text.StringBuilder

        With Me.KryptonRichTextBox1
            .SuspendLayout()
            .Text = Nothing
            Select Case Me.ToolStripComboBox1.SelectedIndex
                Case 0
                    For Each lo As ClassLog.LogType In Log_Generation.Log
                        strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
                    Next
                Case 1
                    For Each lo As ClassLog.LogType In Log_Projet.Log
                        strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
                    Next
                Case 2
                    For Each lo As ClassLog.LogType In Log_SZ.Log
                        strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
                    Next
            End Select
            .Text = strr.ToString
            .ResumeLayout()
        End With
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim strr As New System.Text.StringBuilder
        Me.KryptonRichTextBox1.SuspendLayout()
        If Me.ToolStripComboBox1.SelectedIndex = 0 Then
            Log_Generation.Log = New ClassLog.LogGenericList
            Me.KryptonRichTextBox1.Text = Nothing
            For Each lo As ClassLog.LogType In Log_Generation.Log
                strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
            Next
            Me.KryptonRichTextBox1.Text = strr.ToString
        ElseIf Me.ToolStripComboBox1.SelectedIndex = 1 Then
            Log_Projet.Log = New ClassLog.LogGenericList
            Me.KryptonRichTextBox1.Text = Nothing
            For Each lo As ClassLog.LogType In Log_Projet.Log
                strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
            Next
            Me.KryptonRichTextBox1.Text = strr.ToString
        ElseIf Me.ToolStripComboBox1.SelectedIndex = 2 Then
            Log_SZ.Log = New ClassLog.LogGenericList
            Me.KryptonRichTextBox1.Text = Nothing
            For Each lo As ClassLog.LogType In Log_SZ.Log
                strr.AppendLine(lo.InfoType.ToString & " : " & lo.Texte)
            Next
            Me.KryptonRichTextBox1.Text = strr.ToString
        End If
        If Me.KryptonRichTextBox1.Text.Length > 0 Then Me.KryptonRichTextBox1.SelectionStart = Me.KryptonRichTextBox1.Text.Length - 1
        Me.KryptonRichTextBox1.ScrollToCaret()

        Me.KryptonRichTextBox1.ResumeLayout()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click, KryptonContextMenuItem1.Click
        Me.KryptonRichTextBox1.Copy()
    End Sub

End Class
