''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Form1


    Friend Box_Explorateur As New VelerSoftware.Design.Navigator.KryptonPage

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            ' Initialisation des ressources
            RM = New System.Resources.ResourceManager("Help.Custom", System.Reflection.Assembly.GetExecutingAssembly())


            ' Initialisation de la fenêtre
            .Text = My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName

            .Size = New System.Drawing.Size(My.Computer.Screen.WorkingArea.Width - 100, My.Computer.Screen.WorkingArea.Height - 100)
            .Location = New System.Drawing.Point((My.Computer.Screen.WorkingArea.Width - Me.Width) / 2, (My.Computer.Screen.WorkingArea.Height - Me.Height) / 2)
            .StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen

            Select Case My.Settings.WindowTheme
                Case 0
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Case 1
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Case 2
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
            End Select

            ' Initialisation du dock
            .KryptonDockingManager1.ManageControl(Me.KryptonPanel1, Me.KryptonDockingManager1.ManageWorkspace(Me.KryptonDockableWorkspace1))
            .KryptonDockingManager1.ManageFloating(Me)

            ' Ajout des panneaux
            .KryptonDockingManager1.AddDockspace("Control", VelerSoftware.Design.Docking.DockingEdge.Left, New VelerSoftware.Design.Navigator.KryptonPage() {Dock_Nouveau_Explorateur()})

            ' Chargement de l'interface
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help.Dock.xml") Then
                .KryptonDockingManager1.LoadConfigFromFile(Application.StartupPath & "\Help.Dock.xml")
            End If


            If ArgumentOuverture = Nothing Then
                Try : .KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Workspace_Nouveau_Page_De_Demarrage("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\Introduction.html")}) : Catch : End Try
            Else
                Try : Me.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Me.Workspace_Nouveau_Page_De_Demarrage("file:///" & ArgumentOuverture)}) : Catch : End Try
                If ClassApplication.Determiner_Si_Document_Deja_Ouvert("Document " & DocNum) Then
                    Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Me.KryptonDockableWorkspace1.PageForUniqueName("Document " & DocNum)
                    If Not pag Is Nothing Then
                        Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Me.KryptonDockableWorkspace1.CellForPage(pag)
                        Me.KryptonDockableWorkspace1.ActiveCell = cell
                        cell.SelectedPage = pag
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Application.Exit()
    End Sub

#Region "Dock"

    Private Sub KryptonDockingManager1_DockspaceAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockspaceEventArgs) Handles KryptonDockingManager1.DockspaceAdding
        e.DockspaceControl.Size = New Size(250, 250)
    End Sub

    Private Sub KryptonDockingManager1_FloatingWindowAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.FloatingWindowEventArgs) Handles KryptonDockingManager1.FloatingWindowAdding
        e.FloatingWindow.ClientSize = New Size(400, 400)
    End Sub

    Private Sub KryptonDockingManager1_DockspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockspaceCellEventArgs) Handles KryptonDockingManager1.DockspaceCellAdding
        e.CellControl.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.HeaderBarCheckButtonGroup
    End Sub

    Private Sub KryptonDockingManager1_FloatspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.FloatspaceCellEventArgs) Handles KryptonDockingManager1.FloatspaceCellAdding
        e.CellControl.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.HeaderBarCheckButtonGroup
    End Sub

    Private Sub KryptonDockableWorkspace1_WorkspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Workspace.WorkspaceCellEventArgs) Handles KryptonDockableWorkspace1.WorkspaceCellAdding
        e.Cell.Button.CloseButtonAction = VelerSoftware.Design.Navigator.CloseButtonAction.None
    End Sub





    Private Sub KryptonDockingManager1_GlobalSaving(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockGlobalSavingEventArgs) Handles KryptonDockingManager1.GlobalSaving
        ' Example code showing how to save extra data into the global config
        'e.XmlWriter.WriteStartElement("CustomGlobalData")
        'e.XmlWriter.WriteAttributeString("SavedTime", DateTime.Now.ToString())
        'e.XmlWriter.WriteEndElement()
    End Sub

    Private Sub KryptonDockingManager1_GlobalLoading(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockGlobalLoadingEventArgs) Handles KryptonDockingManager1.GlobalLoading
        ' Example code showing how to reload the extra data that was saved into the global config
        'e.XmlReader.Read()
        'MsgBox("GlobalConfig was saved at {0}", e.XmlReader.GetAttribute("SavedTime"))
        'e.XmlReader.Read()
    End Sub





    Private Sub KryptonDockableWorkspace1_ActivePageChanged(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Workspace.ActivePageChangedEventArgs) Handles KryptonDockableWorkspace1.ActivePageChanged
        If Not e.NewPage Is Nothing Then
            If TypeOf e.NewPage.Controls(0) Is DocNavigateur Then
                CType(e.NewPage.Controls(0), DocNavigateur).Activate_Page()
            End If
        End If
    End Sub

    Private Sub KryptonDockableWorkspace1_PageCloseClicked(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.UniqueNameEventArgs) Handles KryptonDockableWorkspace1.PageCloseClicked
        If Not e.UniqueName = Nothing Then
            If Me.KryptonDockableWorkspace1.PageForUniqueName(e.UniqueName).Controls.Count > 0 Then
                If TypeOf Me.KryptonDockableWorkspace1.PageForUniqueName(e.UniqueName).Controls(0) Is DocNavigateur Then
                    If CType(Me.KryptonDockableWorkspace1.PageForUniqueName(e.UniqueName).Controls(0), DocNavigateur).Page_Closing() Then
                        Me.KryptonDockingManager1.RemovePage(Me.KryptonDockableWorkspace1.PageForUniqueName(e.UniqueName), True)
                    End If
                End If
            End If
        End If

        If Me.KryptonDockableWorkspace1.AllPages.Length = 0 Then
            With Me
                ' Configuration du ruban
                .ImprimerToolStripButton.Enabled = False
                .AnnulerToolStripMenuItem.Enabled = False
                .RétablirToolStripMenuItem.Enabled = False
                .ActualiserToolStripMenuItem.Enabled = False
                .CopierToolStripButton.Enabled = False
                .CopierToolStripMenuItem.Enabled = False
                .SélectionnertoutToolStripMenuItem.Enabled = False
                .ToolStripButton1.Enabled = False
                .ToolStripButton2.Enabled = False
                .ToolStripButton3.Enabled = False
                .ImprimerToolStripMenuItem.Enabled = False
                .AperçuavantimpressionToolStripMenuItem.Enabled = False
                .PersonnaliserToolStripMenuItem.Enabled = False
            End With
        End If
    End Sub
















    Friend Function Workspace_Nouveau_Page_De_Demarrage(ByVal url As String) As VelerSoftware.Design.Navigator.KryptonPage
        DocNum += 1

        Dim Document_Page_De_Demarrage = New VelerSoftware.Design.Navigator.KryptonPage()
        Document_Page_De_Demarrage.UniqueName = "Document " & DocNum
        Document_Page_De_Demarrage.ImageSmall = My.Resources.internet
        Document_Page_De_Demarrage.ToolTipImage = My.Resources.internet
        Document_Page_De_Demarrage.Text = "Document"

        Document_Page_De_Demarrage.ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
        Document_Page_De_Demarrage.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
        Document_Page_De_Demarrage.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
        Document_Page_De_Demarrage.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

        Dim content As New DocNavigateur
        content.Dock = DockStyle.Fill
        Document_Page_De_Demarrage.Controls.Add(content)
        content.WebBrowser1.Navigate(url)

        Return Document_Page_De_Demarrage
    End Function

#End Region

    Private Sub NouveauToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripMenuItem.Click, NouveauToolStripButton.Click
        Try : Me.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Workspace_Nouveau_Page_De_Demarrage("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\Introduction.html")}) : Catch : End Try
        If ClassApplication.Determiner_Si_Document_Deja_Ouvert("Document " & DocNum) Then
            Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Me.KryptonDockableWorkspace1.PageForUniqueName("Document " & DocNum)
            If Not pag Is Nothing Then
                Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Me.KryptonDockableWorkspace1.CellForPage(pag)
                Me.KryptonDockableWorkspace1.ActiveCell = cell
                cell.SelectedPage = pag
            End If
        End If
    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripMenuItem.Click, ImprimerToolStripButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.ShowPrintDialog()
            End If
        End If
    End Sub

    Private Sub AperçuavantimpressionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperçuavantimpressionToolStripMenuItem.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.ShowPrintPreviewDialog()
            End If
        End If
    End Sub

    Private Sub AnnulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerToolStripMenuItem.Click, ToolStripButton1.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.GoBack()
            End If
        End If
    End Sub

    Private Sub RétablirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RétablirToolStripMenuItem.Click, ToolStripButton2.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.GoForward()
            End If
        End If
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripMenuItem.Click, CopierToolStripButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.Focus()
                My.Computer.Keyboard.SendKeys("^c")
            End If
        End If
    End Sub

    Private Sub SélectionnertoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SélectionnertoutToolStripMenuItem.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.Focus()
                My.Computer.Keyboard.SendKeys("^a")
            End If
        End If
    End Sub

    Private Sub ActualiserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualiserToolStripMenuItem.Click, ToolStripButton3.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocNavigateur Then
                CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.Navigate(CType(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocNavigateur).WebBrowser1.Url.OriginalString)
            End If
        End If
    End Sub

    Private Sub PersonnaliserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonnaliserToolStripMenuItem.Click
        If Not Me.KryptonDockableWorkspace1.ActivePage Is Nothing Then
            Me.KryptonDockingManager1.RemovePage(Me.KryptonDockableWorkspace1.ActivePage, True)
        End If
        If Me.KryptonDockableWorkspace1.AllPages.Length = 0 Then
            With Me
                ' Configuration du ruban
                .ImprimerToolStripButton.Enabled = False
                .AnnulerToolStripMenuItem.Enabled = False
                .RétablirToolStripMenuItem.Enabled = False
                .ActualiserToolStripMenuItem.Enabled = False
                .CopierToolStripButton.Enabled = False
                .CopierToolStripMenuItem.Enabled = False
                .SélectionnertoutToolStripMenuItem.Enabled = False
                .ToolStripButton1.Enabled = False
                .ToolStripButton2.Enabled = False
                .ToolStripButton3.Enabled = False
                .ImprimerToolStripMenuItem.Enabled = False
                .AperçuavantimpressionToolStripMenuItem.Enabled = False
                .PersonnaliserToolStripMenuItem.Enabled = False
            End With
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Enregistrement de l'interface
        Me.KryptonDockingManager1.SaveConfigToFile(Application.StartupPath & "\Help.Dock.xml", System.Text.Encoding.UTF8)
    End Sub

    Private Function Dock_Nouveau_Explorateur() As VelerSoftware.Design.Navigator.KryptonPage
        Box_Explorateur = New VelerSoftware.Design.Navigator.KryptonPage()
        Box_Explorateur.Text = RM.GetString("Dock_Explorateur")
        Box_Explorateur.TextTitle = RM.GetString("Dock_Explorateur")
        Box_Explorateur.TextDescription = RM.GetString("Dock_Explorateur_Description")
        Box_Explorateur.UniqueName = "Explorateur"
        Box_Explorateur.ImageSmall = My.Resources.Explorateur_de_solutions

        Box_Explorateur.ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
        Box_Explorateur.SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)

        Dim content As New BoxExplorateur
        content.Dock = DockStyle.Fill
        Box_Explorateur.Controls.Add(content)

        Return Box_Explorateur
    End Function

    Private Sub ÀproposdeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ÀproposdeToolStripMenuItem.Click
        Using frm As New A_Propos_De
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles OptionsToolStripMenuItem1.Click
        Using frm As New Options
            frm.ShowDialog()
        End Using
    End Sub
End Class
