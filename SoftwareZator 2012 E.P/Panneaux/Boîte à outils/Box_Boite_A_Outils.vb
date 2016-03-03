''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxBoiteAOutils

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Me.Vide_ToolBox.Dock = DockStyle.Fill
        Me.Concepteur_Fenetre_ToolBox.Dock = DockStyle.Fill
        Me.Fonctions_ToolBox.Dock = DockStyle.Fill
        Me.Classes_ToolBox.Dock = DockStyle.Fill
        Me.KryptonWrapLabel1.Dock = DockStyle.Fill

        Me.Vide_ToolBox.BorderStyle = Windows.Forms.BorderStyle.None
        Me.Concepteur_Fenetre_ToolBox.BorderStyle = Windows.Forms.BorderStyle.None
        Me.Fonctions_ToolBox.BorderStyle = Windows.Forms.BorderStyle.None
        Me.Classes_ToolBox.BorderStyle = Windows.Forms.BorderStyle.None

        Me.Vide_ToolBox.Visible = False
        Me.Concepteur_Fenetre_ToolBox.Visible = False
        Me.Fonctions_ToolBox.Visible = False
        Me.Classes_ToolBox.Visible = False
        Me.KryptonWrapLabel1.Visible = True

        Dim newGroup As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode()
        newGroup.Text = RM.GetString("Box_Boite_A_Outils_Aucun_Element")
        newGroup.Name = newGroup.Text
        Me.Vide_ToolBox.Nodes.Add(newGroup)
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.ToolStrip1.Font = font

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.Classes_ToolBox.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.Concepteur_Fenetre_ToolBox.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.Vide_ToolBox.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.Classes_ToolBox.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.Concepteur_Fenetre_ToolBox.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.Vide_ToolBox.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.Classes_ToolBox.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.Concepteur_Fenetre_ToolBox.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.Vide_ToolBox.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.Classes_ToolBox.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.Concepteur_Fenetre_ToolBox.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.Vide_ToolBox.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.Classes_ToolBox.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.Concepteur_Fenetre_ToolBox.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.Fonctions_ToolBox.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.Vide_ToolBox.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.Classes_ToolBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.Concepteur_Fenetre_ToolBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.Fonctions_ToolBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.Vide_ToolBox.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub




    Private Sub ToolBox1_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles Concepteur_Fenetre_ToolBox.ItemDrag, Fonctions_ToolBox.ItemDrag, Classes_ToolBox.ItemDrag, Vide_ToolBox.ItemDrag
        If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then

            If Me.Concepteur_Fenetre_ToolBox.Visible Then
                If Not Me.Concepteur_Fenetre_ToolBox.SelectedNode Is Nothing AndAlso _
                    (TryCast(e.Item, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso _
                    e.Button = Windows.Forms.MouseButtons.Left AndAlso _
                    TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 0 Then

                    Me.ListBox1.Items.Clear()
                    If Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Erreur_Chargement_Concepteur_Fenetre AndAlso _
                        Not Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name = Nothing Then

                        Dim ok As Boolean = False
                        If Not Me.Concepteur_Fenetre_ToolBox.SelectedNode.Tag = "" Then
                            For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                                For Each tags As String In CStr(Me.Concepteur_Fenetre_ToolBox.SelectedNode.Tag).Split(";")
                                    If ref.FullName = tags OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", tags) OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", tags) Then
                                        ok = True
                                        Exit For
                                    End If
                                Next
                            Next
                            If Not ok AndAlso _
                                VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content22"), Me.Concepteur_Fenetre_ToolBox.SelectedNode.Tag), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes AndAlso _
                                Not SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet) Is Nothing Then

                                For Each tags As String In CStr(Me.Concepteur_Fenetre_ToolBox.SelectedNode.Tag).Split(";")
                                    If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", tags)) Then
                                        ClassProjet.Ajouter_Reference_Projet(tags, SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet))
                                    ElseIf My.Computer.FileSystem.FileExists(tags) Then
                                        ClassProjet.Ajouter_Reference_Projet(tags, SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet))
                                    ElseIf My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Emplacement, tags)) Then
                                        ClassProjet.Ajouter_Reference_Projet(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Emplacement, tags), SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet))
                                    Else
                                        ClassProjet.Ajouter_Reference_Projet(tags, SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet))
                                    End If
                                Next
                            End If
                        Else
                            ok = True
                        End If

                        If ok Then
                            Dim types As Type = Nothing
                            Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl
                            For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                                If Not ref.Assembly Is Nothing Then
                                    Dim listTypes() As Type = New VelerSoftware.SZC.WindowsDesigner.AssemblyControl().LoadControlsFromAssembly(ref.Assembly)
                                    For i As Integer = 0 To listTypes.Length - 1
                                        If (listTypes(i).FullName & ", " & ref.Assembly.FullName) = Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name Then types = listTypes(i)
                                    Next
                                    For Each Type As Type In ref.Assembly.GetTypes()
                                        If Type.IsSubclassOf(GetType(AxHost)) AndAlso (Type.FullName & ", " & ref.Assembly.FullName) = Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name Then types = Type
                                    Next
                                End If
                            Next
                            If Not types = Nothing Then
                                DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ToolBoxs.AddToolboxItem(New System.Drawing.Design.ToolboxItem(types))
                                If Not Me.Concepteur_Fenetre_ToolBox.SelectedNode.Tag = "" Then DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Designer.View, Control).DoDragDrop(ListBox1.Items(ListBox1.Items.Count - 1), DragDropEffects.Copy Or DragDropEffects.Move)
                            End If
                        End If
                    End If
                End If

            ElseIf Me.Fonctions_ToolBox.Visible AndAlso Not Me.Fonctions_ToolBox.SelectedNode Is Nothing AndAlso (TryCast(e.Item, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then

                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 AndAlso _
                    Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage AndAlso _
                    Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then

                    Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                    If Not types = Nothing Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                    End If
                    Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                    Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                    System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)

                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions AndAlso _
                    Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage AndAlso _
                    Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then

                    Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                    If Not types = Nothing Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                    End If
                    Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                    Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                    System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)
                End If

            ElseIf Me.Classes_ToolBox.Visible AndAlso Not Me.Classes_ToolBox.SelectedNode Is Nothing AndAlso (TryCast(e.Item, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then

                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage AndAlso _
                    Not Me.Classes_ToolBox.SelectedNode.Name = Nothing Then

                    Dim types As Type = Me.Classes_ToolBox.SelectedNode.Tag
                    If Not types = Nothing Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                    End If
                    Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                    Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                    System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)

                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage AndAlso _
                    Not Me.Classes_ToolBox.SelectedNode.Name = Nothing Then

                    Dim types As Type = Me.Classes_ToolBox.SelectedNode.Tag
                    If Not types = Nothing Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                    End If
                    Dim type As Type = DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Item(0).Type
                    Dim data As New DataObject(System.Activities.Presentation.DragDropHelper.WorkflowItemTypeNameFormat, type.AssemblyQualifiedName)
                    System.Windows.DragDrop.DoDragDrop(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl, data, DragDropEffects.All)
                End If
            End If
        End If
    End Sub

    Private Sub ToolBox1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Concepteur_Fenetre_ToolBox.AfterSelect, Fonctions_ToolBox.AfterSelect, Classes_ToolBox.AfterSelect, Vide_ToolBox.AfterSelect
        If Me.Concepteur_Fenetre_ToolBox.Visible Then
            If Not Me.Concepteur_Fenetre_ToolBox.SelectedNode Is Nothing Then

                If (DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso _
                    Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 AndAlso _
                    TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 0 Then

                    Me.ListBox1.Items.Clear()
                    If Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Erreur_Chargement_Concepteur_Fenetre AndAlso _
                         Not Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name = Nothing Then

                        Dim types As Type = Nothing
                        Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl
                        For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                            If Not ref.Assembly Is Nothing Then
                                Dim listTypes() As Type = New VelerSoftware.SZC.WindowsDesigner.AssemblyControl().LoadControlsFromAssembly(ref.Assembly)
                                For i As Integer = 0 To listTypes.Length - 1
                                    If (listTypes(i).FullName & ", " & ref.Assembly.FullName) = Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name Then types = listTypes(i)
                                Next
                                For Each Type As Type In ref.Assembly.GetTypes()
                                    If Type.IsSubclassOf(GetType(AxHost)) AndAlso (Type.FullName & ", " & ref.Assembly.FullName) = Me.Concepteur_Fenetre_ToolBox.SelectedNode.Name Then types = Type
                                Next
                            End If
                        Next
                        If Not types = Nothing Then DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ToolBoxs.AddToolboxItem(New System.Drawing.Design.ToolboxItem(types))
                    End If
                End If

                If DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).Level <> 0 AndAlso Not DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp = Nothing Then
                    If Not DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp) Then
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                        Else
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                        End If
                    Else
                        DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate(DirectCast(Me.Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                    End If
                Else
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                End If

            Else
                DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
            End If

        ElseIf Me.Fonctions_ToolBox.Visible Then
            If Not Me.Fonctions_ToolBox.SelectedNode Is Nothing Then

                If (DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso _
                    Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                    If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                        DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 AndAlso _
                        Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage Then

                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                        If Not Me.Fonctions_ToolBox.SelectedNode.Name = Nothing Then
                            Dim types As Type = Me.Fonctions_ToolBox.SelectedNode.Tag
                            If Not types = Nothing Then
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                            End If
                        End If
                    ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions AndAlso Not DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage Then
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

                If DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).Level <> 0 AndAlso Not DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp = Nothing Then
                    If Not DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp) Then
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Fonctions_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
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

        ElseIf Me.Classes_ToolBox.Visible Then
            If Not Me.Classes_ToolBox.SelectedNode Is Nothing Then

                If (DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                    If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre AndAlso _
                        DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedIndex = 1 AndAlso _
                        DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                        If Not Me.Classes_ToolBox.SelectedNode.Name = Nothing Then
                            Dim types As Type = Me.Classes_ToolBox.SelectedNode.Tag
                            If Not types = Nothing Then
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                            End If
                        End If
                    ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions AndAlso DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage Is DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage Then
                        DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                        If Not Me.Classes_ToolBox.SelectedNode.Name = Nothing Then
                            Dim types As Type = Me.Classes_ToolBox.SelectedNode.Tag
                            If Not types = Nothing Then
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                            End If
                        End If
                    End If
                End If

                If DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).Level <> 0 AndAlso Not DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp = Nothing Then
                    If Not DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp) Then
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\" & DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                        Else
                            DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                        End If
                    Else
                        DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate(DirectCast(Me.Classes_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).FileHelp)
                    End If
                Else
                    DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
                End If

            Else
                DirectCast(Form1.Box_Aide_Rapide.Controls(0), BoxAideRapide).WebBrowser1.Navigate("about:blank")
            End If
        End If
    End Sub

    Private Sub ToolStripTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ToolStripButton1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.KryptonWrapLabel1.Visible = True
        Me.Refresh()
        If Not SOLUTION Is Nothing Then
            ClassApplication.Charger_ToolBox_Concepteur_Fenetre(Me.ToolStripTextBox1.Text)
            ClassApplication.Charger_ToolBox_Editeur_Fonctions(Me.ToolStripTextBox1.Text)
        End If
        Me.KryptonWrapLabel1.Visible = False
    End Sub



















    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim listTypes() As Type = Nothing
        Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl
        Dim i As Integer = 0
        Dim asm As System.Reflection.Assembly

        Dim XmlAttribut As System.Xml.XmlAttribute
        Dim elemUrl As System.Xml.XmlElement
        Dim XmlDoc As System.Xml.XmlDocument
        Dim elemSite As System.Xml.XmlElement
        Dim elemBox As System.Xml.XmlElement

        Form1.OpenFileDialog1.Title = RM.GetString("OpenFileDialog1_Ajouter_Composant")
        Form1.OpenFileDialog1.Multiselect = True
        Form1.OpenFileDialog1.Filter = RM.GetString("OpenFileDialog1_Ajouter_Composant_Filtre")
        Form1.OpenFileDialog1.FileName = Nothing
        If My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
            Form1.OpenFileDialog1.InitialDirectory = My.Settings.Emplacement_Project_Par_Defaut
        Else
            Form1.OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If

        If Form1.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each file As String In Form1.OpenFileDialog1.FileNames
                If My.Computer.FileSystem.FileExists(file) Then
                    'My.Computer.FileSystem.CopyFile(file, Application.StartupPath & "\" & My.Computer.FileSystem.GetName(file), True)
                    'If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & My.Computer.FileSystem.GetName(file)) Then
                    asm = Nothing
                    asm = System.Reflection.Assembly.LoadFile(file)
                    If Not asm Is Nothing Then

                        If Not asm.FullName.StartsWith("SoftwareZator 2012") AndAlso Not asm.FullName.StartsWith("VelerSoftware.SZVB") AndAlso Not asm.FullName.StartsWith("VelerSoftware.SZC") AndAlso Not asm.FullName.StartsWith("VelerSoftware.SZC35") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Plugins3") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Workspace") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Toolkit") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Ribbon") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Navigator") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Docking") AndAlso Not asm.FullName.StartsWith("VelerSoftware.Design.Design") AndAlso Not asm.FullName.StartsWith("Access32") AndAlso Not asm.FullName.StartsWith("Help") AndAlso Not asm.FullName.StartsWith("VelerSoftware.GeneralPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.AccessPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.MySQLPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.SQLServerPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.PrintPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.FTPPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.PrintLib") AndAlso Not asm.FullName.StartsWith("VelerSoftware.ExcelLib") AndAlso Not asm.FullName.StartsWith("VelerSoftware.ExcelPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.VoiceRecognitionPlugin") AndAlso Not asm.FullName.StartsWith("VelerSoftware.VoiceRecognitionLib") AndAlso Not asm.FullName.StartsWith("VelerSoftware.SerialPortPlugin") Then

                            XmlDoc = New System.Xml.XmlDocument()
                            XmlDoc.AppendChild(XmlDoc.CreateXmlDeclaration("1.0", "utf-8", Nothing))
                            elemBox = XmlDoc.CreateElement("Toolbox")

                            elemSite = XmlDoc.CreateElement("Category")
                            XmlAttribut = XmlDoc.CreateAttribute("name_fr")
                            XmlAttribut.Value = asm.GetName.Name
                            elemSite.Attributes.Append(XmlAttribut)
                            XmlAttribut = XmlDoc.CreateAttribute("name_en")
                            XmlAttribut.Value = asm.GetName.Name
                            elemSite.Attributes.Append(XmlAttribut)

                            listTypes = Nothing
                            listTypes = h.LoadControlsFromAssembly(asm)
                            If Not listTypes Is Nothing Then
                                For i = 0 To listTypes.Length - 1
                                    elemUrl = XmlDoc.CreateElement("Item")
                                    XmlAttribut = XmlDoc.CreateAttribute("name_fr")
                                    XmlAttribut.Value = listTypes(i).Name
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("name_en")
                                    XmlAttribut.Value = listTypes(i).Name
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("help")
                                    XmlAttribut.Value = listTypes(i).Name & ".html"
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("image")
                                    XmlAttribut.Value = listTypes(i).Name & ".bmp"
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("fullname")
                                    XmlAttribut.Value = listTypes(i).FullName & ", " & asm.FullName
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("assembly")
                                    XmlAttribut.Value = file
                                    elemUrl.Attributes.Append(XmlAttribut)

                                    elemSite.AppendChild(elemUrl)
                                Next
                            End If

                            For Each Type As Type In asm.GetTypes()
                                If Type.IsSubclassOf(GetType(AxHost)) Then
                                    elemUrl = XmlDoc.CreateElement("Item")
                                    XmlAttribut = XmlDoc.CreateAttribute("name_fr")
                                    XmlAttribut.Value = Type.Name
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("name_en")
                                    XmlAttribut.Value = Type.Name
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("help")
                                    XmlAttribut.Value = Type.Name & ".html"
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("image")
                                    XmlAttribut.Value = Type.Name & ".bmp"
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("fullname")
                                    XmlAttribut.Value = Type.FullName & ", " & asm.FullName
                                    elemUrl.Attributes.Append(XmlAttribut)
                                    XmlAttribut = XmlDoc.CreateAttribute("assembly")
                                    XmlAttribut.Value = file
                                    elemUrl.Attributes.Append(XmlAttribut)

                                    elemSite.AppendChild(elemUrl)
                                End If
                            Next

                            'on ajoute la balise parent au document
                            elemBox.AppendChild(elemSite)
                            XmlDoc.AppendChild(elemBox)

                            'Ecriture du Xml
                            XmlDoc.Save(Application.StartupPath & "\Toolbox\" & asm.GetName.Name & ".xml")

                        End If

                    End If
                    'End If
                End If
            Next

            Me.ToolStripTextBox1.Text = Nothing
            ClassApplication.Charger_ToolBox_Concepteur_Fenetre("")
        End If
    End Sub

End Class
