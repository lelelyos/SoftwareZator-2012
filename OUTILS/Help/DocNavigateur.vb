''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocNavigateur

#Region "Propriétés"

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Navigateur_Internet

    Public ReadOnly Property TypeFichier() As VelerSoftware.SZVB.Projet.Document.Types
        Get
            Return _TypeFichier
        End Get
    End Property

#End Region ' Type du document

#End Region

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)
    End Sub

    Friend Function Page_Closing() As Boolean
        Return True
    End Function

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

    Friend Sub Activate_Page()
        With Form1
            .ImprimerToolStripButton.Enabled = True
            .AnnulerToolStripMenuItem.Enabled = True
            .RétablirToolStripMenuItem.Enabled = True
            .ActualiserToolStripMenuItem.Enabled = True
            .CopierToolStripButton.Enabled = True
            .CopierToolStripMenuItem.Enabled = True
            .SélectionnertoutToolStripMenuItem.Enabled = True
            .ToolStripButton1.Enabled = True
            .ToolStripButton2.Enabled = True
            .ToolStripButton3.Enabled = True
            .ImprimerToolStripMenuItem.Enabled = True
            .AperçuavantimpressionToolStripMenuItem.Enabled = True
            .PersonnaliserToolStripMenuItem.Enabled = True
        End With
    End Sub

    Private Sub WebBrowser1_NewWindow(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
        e.Cancel = True
        Try : Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Form1.Workspace_Nouveau_Page_De_Demarrage(Me.WebBrowser1.Document.ActiveElement.GetAttribute("href"))}) : Catch : End Try
        If ClassApplication.Determiner_Si_Document_Deja_Ouvert("Document " & DocNum) Then
            Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName("Document " & DocNum)
            If Not pag Is Nothing Then
                Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                Form1.KryptonDockableWorkspace1.ActiveCell = cell
                cell.SelectedPage = pag
            End If
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        CType(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Me.WebBrowser1.Document.Title
        Form1.ToolStripStatusLabel2.Text = RM.GetString("Ready")
    End Sub

    Private Sub WebBrowser1_Navigated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Form1.ToolStripStatusLabel2.Text = RM.GetString("Ready")
    End Sub

    Private Sub WebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Form1.ToolStripStatusLabel2.Text = e.Url.OriginalString
    End Sub
End Class
