''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxReconnaissanceVocale

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Me.Fonctions_ToolBox.BorderStyle = Windows.Forms.BorderStyle.None

        Me.KryptonPanel1.Visible = False
        Me.KryptonSplitContainer1.Dock = DockStyle.Fill
        Me.KryptonPanel1.Dock = DockStyle.Fill

        Dim newGroup As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode()
        newGroup.Text = RM.GetString("Box_Boite_A_Outils_Aucun_Element")
        newGroup.Name = newGroup.Text
        Me.Fonctions_ToolBox.Nodes.Add(newGroup)
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub








    Private Sub ToolBox1_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles Fonctions_ToolBox.ItemDrag
        If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then

            If Not Me.Fonctions_ToolBox.SelectedNode Is Nothing Then
                If (TryCast(e.Item, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 Then
                    If e.Button = Windows.Forms.MouseButtons.Left Then

                        If My.Settings.Edition = ClassApplication.Edition.Free Then
                            ClassApplication.Should_Standard_Edition()
                            Exit Sub
                        End If

                        If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                            If DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 Then
                                If Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then
                                    Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                                    If Not types = Nothing Then
                                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                                    End If
                                    Dim action As VelerSoftware.Plugins3.Action = DirectCast(System.Reflection.Assembly.GetAssembly(types).CreateInstance(types.FullName), VelerSoftware.Plugins3.Action)
                                    If (DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage AndAlso action.CompatibleClass) OrElse (DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage IsNot DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage AndAlso action.CompatibleFonctions) Then
                                        Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                                        Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                                        System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)
                                    End If
                                End If
                            End If
                        ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                            If Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then
                                Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                                If Not types = Nothing Then
                                    DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                    DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                                End If
                                Dim action As VelerSoftware.Plugins3.Action = DirectCast(System.Reflection.Assembly.GetAssembly(types).CreateInstance(types.FullName), VelerSoftware.Plugins3.Action)
                                If (DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage AndAlso action.CompatibleClass) OrElse (DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage IsNot DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage AndAlso action.CompatibleFonctions) Then
                                    Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                                    Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                                    System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)
                                End If
                            End If
                        End If

                    End If
                End If
            End If

        End If
    End Sub

    Private Sub ToolBox1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Fonctions_ToolBox.AfterSelect
        If Not Me.Fonctions_ToolBox.SelectedNode Is Nothing Then

            If (DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 Then
                If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                    If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                        If DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 Then
                            DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                            If Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then
                                Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                                If Not types = Nothing Then
                                    DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                    DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                                End If
                            End If
                        End If
                    ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                        If Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then
                            Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                            If Not types = Nothing Then
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                            End If
                        End If
                    End If
                End If
            End If

            If DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).Level <> 0 Then
                If Not DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp = Nothing Then
                    If Not DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\Plugins\" & DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp) Then
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("file:///" & Application.StartupPath & "\Help\Plugins\" & DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                        Else
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                        End If
                    Else
                        DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate(DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                    End If
                Else
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                End If
            Else
                DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
            End If

        Else
            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
        End If
    End Sub


    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Me.KryptonPanel1.Visible = False
    End Sub
End Class
