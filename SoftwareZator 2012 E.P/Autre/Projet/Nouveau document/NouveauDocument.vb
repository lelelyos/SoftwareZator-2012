''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class NouveauDocument

    Friend Tip, Extension As String

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter
    Private Nom_Group As New Generic.List(Of String)


    Private Sub NouveauDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.TreeView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 64, 64)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 32, 32)

        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        ' On ajoute les projets à la solution
        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
            If proj.Loaded Then
                Me.TreeView1.Nodes.Add(ClassProjet.Charger_Projet_Explorateur_Solutions(Nothing, proj, False))
            End If
        Next

        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(KryptonTextBox1))

        DisableNextButton()
        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("NouveauDocument_Caption")
    End Sub


    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        If Me.WizardTabControl1.SelectedIndex = 0 Then
            Me.ShowNextButton()
        ElseIf Me.WizardTabControl1.SelectedIndex = 1 Then
            Me.HideNextButton()
            Me.EnableNextButton()
        ElseIf Me.WizardTabControl1.SelectedIndex = 2 Then
            Me.ShowNextButton()
            Me.DisableNextButton()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        ElseIf Me.WizardTabControl1.SelectedIndex = 3 Then
            Dim ext As String = Nothing
            Select Case Tip
                Case "Window"
                    ext = "szw"
                Case "Class"
                    ext = "szc"
                Case "Code"
                    ext = "vb"
            End Select

            If Me.ListView1.SelectedIndices.Count > 0 Then
                If My.Computer.FileSystem.DirectoryExists(Me.TreeView1.SelectedNode.ToolTipText) Then
                    Me.KryptonTextBox1.Text = ClassFichier.Determine_Fichier_Existe(Me.ListView1.SelectedItems(0).Text.Replace(" ", "_"), Me.TreeView1.SelectedNode.ToolTipText, ext)
                Else
                    Me.KryptonTextBox1.Text = ClassFichier.Determine_Fichier_Existe(Me.ListView1.SelectedItems(0).Text.Replace(" ", "_"), My.Computer.FileSystem.GetParentPath(Me.TreeView1.SelectedNode.ToolTipText), ext)
                End If
            End If

            Nom_KryptonTextBox1_TextChanged(Nothing, Nothing)

        End If
    End Sub

    Private Sub Form_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        e.Cancel = True
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\introduction.html") Then
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help.exe") Then
                System.Diagnostics.Process.Start(Application.StartupPath & "\Help.exe", ChrW(34) & Application.StartupPath & "\Help\" & My.Settings.Langue & "\introduction.html" & ChrW(34))
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Help.exe", My.Application.Info.Title)
                    .MainInstruction = RM.GetString("MainInstruction10")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content18"), My.Application.Info.Title)
                .MainInstruction = RM.GetString("MainInstruction10")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
        End If
    End Sub










    Private Sub TreeViewMultiSelect1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        If Not SOLUTION Is Nothing Then ' Si une solution est ouverte
            If (Not e.Node.Tag = "ROOT") Then ' Si l'élément sélectionné n'est pas le noeud de la solution, donc un dossier ou fichier ou projet
                'on efface les noeuds enfants pour le noeud selectionné
                e.Node.Nodes.Clear()

                If My.Computer.FileSystem.DirectoryExists(e.Node.ToolTipText) Then ' Si le dossier existe
                    Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(e.Node.Tag)
                    If proj.Loaded Then ' Et on ouvre le dossier
                        ClassProjet.AjouterRepertoire(e.Node, e.Node.ToolTipText, e.Node.Tag, proj, False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterExpand
        If Not SOLUTION Is Nothing Then
            If e.Node.ImageIndex = 3 Then
                e.Node.ImageIndex = 4
                If e.Node.IsSelected Then
                    e.Node.SelectedImageIndex = 4
                Else
                    e.Node.SelectedImageIndex = 4
                End If
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse
        If Not SOLUTION Is Nothing Then
            If e.Node.ImageIndex = 4 Then
                e.Node.ImageIndex = 3
                If e.Node.IsSelected Then
                    e.Node.SelectedImageIndex = 3
                Else
                    e.Node.SelectedImageIndex = 3
                End If
            End If
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        Me.EnableNextButton()
    End Sub

    Private Sub TreeView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        TreeView1_AfterSelect(Nothing, Nothing)
    End Sub

    Private Sub Fenetre_CommandLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fenetre_CommandLink.Click, CommandLink2.Click, CommandLink1.Click
        If CStr(sender.Tag) = "Code" AndAlso Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        Tip = CStr(sender.Tag)

        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML
        Dim ok As Boolean
        Dim names, images, descriptions, group As String
        Dim ite As ListViewItem

        Me.ListView1.BeginUpdate()

        Me.ListView1.Items.Clear()
        Me.ImageList2.Images.Clear()
        Me.ImageList2.ImageSize = New Size(32, 32)

        If Not My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates")) Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates"))
        End If
        If Not My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Documents")) Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Documents"))
        End If


        ' templates
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Documents")) Then
            For Each Fichier As String In My.Computer.FileSystem.GetFiles(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Documents\"), FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.FileExists(Fichier) AndAlso My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToLower = ".sztemplate" Then
                    ok = False
                    names = Nothing
                    images = Nothing
                    descriptions = Nothing
                    group = Nothing

                    XmlRead = New Xml.XmlTextReader(Fichier)
                    Do While XmlRead.Read()
                        Select Case XmlRead.NodeType
                            Case Xml.XmlNodeType.Element
                                Select Case XmlRead.Name
                                    Case "SZTemplate" ' Template
                                        If XmlRead.GetAttribute("version") = "3.0" AndAlso XmlRead.GetAttribute("type") = Tip Then
                                            names = XmlRead.GetAttribute("name_" & My.Settings.Langue)
                                            group = XmlRead.GetAttribute("group_" & My.Settings.Langue)
                                            ok = True
                                        End If
                                    Case "Info" ' Informations
                                        If ok Then
                                            images = XmlRead.GetAttribute("image")
                                            descriptions = XmlRead.GetAttribute("description_" & My.Settings.Langue)
                                        End If
                                End Select
                        End Select
                    Loop
                    XmlRead.Close()

                    If ok Then
                        ite = New ListViewItem
                        ite.Text = names
                        ite.Tag = descriptions
                        ite.Name = names
                        ite.ToolTipText = Fichier
                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(Fichier), images)) Then
                            Using fs As IO.Stream = New IO.FileStream(My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.GetParentPath(Fichier), images), IO.FileMode.Open)
                                Me.ImageList2.Images.Add(ite.Text, Drawing.Image.FromStream(fs))
                                fs.Close()
                            End Using
                        End If
                        ite.ImageKey = ite.Text
                        If Not group = Nothing Then
                            If Not Nom_Group.Contains(group) Then
                                Me.ListView1.Groups.Add(group, group)
                            End If
                            ite.Group = Me.ListView1.Groups(group)
                        Else
                            ite.Group = Me.ListView1.Groups(0)
                        End If
                        Me.ListView1.Items.Add(ite)
                    End If

                End If
            Next
        End If

        Me.ListView1.EndUpdate()

        Me.TextBox1.Text = Nothing

        If Tip = "Window" Then Extension = ".szw"
        If Tip = "Class" Then Extension = ".szc"
        If Tip = "Code" Then Extension = ".vb"

        Me.GoToNextStep()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.TextBox1.Text = Me.ListView1.SelectedItems(0).Tag
            Me.EnableNextButton()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Me.ListView1.SelectedItems.Count > 0 Then
            Me.GoToNextStep()
        End If
    End Sub

    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonTextBox1.TextChanged
        If Me.KryptonTextBox1.Text = Nothing Then
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, Me.ToolTip1.GetToolTip(Me.KryptonTextBox1))
            Me.DisableNextButton()
        Else
            Me.ErrorProvider1.SetError(Me.KryptonTextBox1, "")
            Me.EnableNextButton()
        End If
    End Sub






















    Private Sub OnFinishButton_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim oki As Boolean = True
            For Each strr As String In Caractères_Interdit_Non_Numerique
                If Me.KryptonTextBox1.Text.Contains(strr) Then oki = False : Exit For
            Next
            If Not oki OrElse My.Computer.FileSystem.FileExists(Me.TreeView1.SelectedNode.ToolTipText & "\" & Me.KryptonTextBox1.Text & Extension) OrElse My.Computer.FileSystem.DirectoryExists(Me.TreeView1.SelectedNode.ToolTipText & "\" & Me.KryptonTextBox1.Text & Extension) OrElse (Mot_Cles_Interdit.Contains(Me.KryptonTextBox1.Text)) Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content31"), Me.TreeView1.SelectedNode.ToolTipText, Me.KryptonTextBox1.Text & Extension)
                    .MainInstruction = RM.GetString("MainInstruction12")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                e.Cancel = True
            Else
                ClassProjet.Creer_Nouveau_Document(Me.ListView1.SelectedItems(0).ToolTipText, Me.TreeView1.SelectedNode.ToolTipText & "\" & Me.KryptonTextBox1.Text & Extension, Me.TreeView1.SelectedNode.Tag, Tip, Me.KryptonTextBox1.Text)
                DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ActualiserToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

End Class
