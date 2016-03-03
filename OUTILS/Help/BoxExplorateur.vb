''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxExplorateur

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.TreeView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 64, 64)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 32, 32)

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Dim tree As New TreeNode
        tree.Text = My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName
        tree.ToolTipText = Application.StartupPath & "\Help\" & My.Settings.Langue & "\"
        tree.ImageIndex = 0
        tree.SelectedImageIndex = 1
        tree.Nodes.Add("factice")

        ClassApplication.AjouterRepertoire(tree, tree.ToolTipText)
        ClassApplication.AjouterFichier(tree, tree.ToolTipText)

        tree.Expand()

        Me.TreeView1.Nodes.Clear()

        Me.TreeView1.Nodes.Add(tree)

    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.TreeView1.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.TreeView1.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.TreeView1.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.TreeView1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.TreeView1.LineColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub









    Private Sub TreeViewMultiSelect1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        e.Node.Nodes.Clear()
        If My.Computer.FileSystem.DirectoryExists(e.Node.ToolTipText) Then ' Si le dossier existe
            ClassApplication.AjouterRepertoire(e.Node, e.Node.ToolTipText)
            ClassApplication.AjouterFichier(e.Node, e.Node.ToolTipText)
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand
        If e.Node.ImageIndex = 0 Then
            e.Node.ImageIndex = 1
            If e.Node.IsSelected Then
                e.Node.SelectedImageIndex = 1
            Else
                e.Node.SelectedImageIndex = 1
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 0
            If e.Node.IsSelected Then
                e.Node.SelectedImageIndex = 0
            Else
                e.Node.SelectedImageIndex = 0
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        If Me.TreeView1.SelectedNode IsNot Nothing Then
            If (Not e.Node.ImageIndex = 0) AndAlso (Not e.Node.ImageIndex = 1) Then ' Si l'élément sélectionné n'est pas le noeud de la solution, donc un dossier ou fichier ou projet
                Try : Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Form1.Workspace_Nouveau_Page_De_Demarrage("file:///" & e.Node.ToolTipText)}) : Catch : End Try
                If ClassApplication.Determiner_Si_Document_Deja_Ouvert("Document " & DocNum) Then
                    Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName("Document " & DocNum)
                    If Not pag Is Nothing Then
                        Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                        Form1.KryptonDockableWorkspace1.ActiveCell = cell
                        cell.SelectedPage = pag
                    End If
                End If
            End If
        End If
    End Sub

End Class
