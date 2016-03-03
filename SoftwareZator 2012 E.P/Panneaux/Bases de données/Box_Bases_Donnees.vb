''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class BoxBasesDonnees

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.TreeViewMultiSelect1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeViewMultiSelect1.Handle, 4352 + 44, 64, 64)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeViewMultiSelect1.Handle, 4352 + 44, 32, 32)

        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

#If DEBUG Then
        Me.TreeViewMultiSelect1.LabelEdit = False
#End If

        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton3.Enabled = False


        Dim node As System.Windows.Forms.TreeNode

        node = New System.Windows.Forms.TreeNode
        With node
            .Name = "MySQL"
            .Text = "MySQL"
            .ToolTipText = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("DataBases"), .Text)
            .ImageIndex = 1
            .SelectedImageIndex = 1
        End With
        Me.TreeViewMultiSelect1.Nodes.Add(node)

        node = New System.Windows.Forms.TreeNode
        With node
            .Name = "SQL Server"
            .Text = "SQL Server"
            .ToolTipText = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("DataBases"), .Text)
            .ImageIndex = 3
            .SelectedImageIndex = 3
        End With
        Me.TreeViewMultiSelect1.Nodes.Add(node)

        node = New System.Windows.Forms.TreeNode
        With node
            .Name = "Access"
            .Text = "Access"
            .ToolTipText = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("DataBases"), .Text)
            .ImageIndex = 0
            .SelectedImageIndex = 0
        End With
        Me.TreeViewMultiSelect1.Nodes.Add(node)
    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
        Me.ToolStrip1.Font = font

        Select Case Form1.KryptonManager1.GlobalPaletteMode
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(217, 229, 242)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(30, 57, 91)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(30, 57, 91)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(235, 238, 241)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(59, 59, 59)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(59, 59, 59)
            Case VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                Me.TreeViewMultiSelect1.BackColor = System.Drawing.Color.FromArgb(146, 146, 146)
                Me.TreeViewMultiSelect1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0)
                Me.TreeViewMultiSelect1.LineColor = System.Drawing.Color.FromArgb(0, 0, 0)
        End Select
    End Sub





    Private Sub TreeViewMultiSelect1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewMultiSelect1.AfterSelect
        If e.Node.ImageIndex = 0 OrElse e.Node.ImageIndex = 1 OrElse e.Node.ImageIndex = 2 OrElse e.Node.ImageIndex = 3 Then ' on interdit l'édition du label
            Me.TreeViewMultiSelect1.LabelEdit = False
            Me.ToolStripButton2.Enabled = False
            Me.ToolStripButton3.Enabled = False
        ElseIf e.Node.ImageIndex = 4 Then ' Base de donnée 
            Me.TreeViewMultiSelect1.LabelEdit = False
            Me.ToolStripButton2.Enabled = True
            Me.ToolStripButton3.Enabled = True
        ElseIf e.Node.ImageIndex = 5 Then ' Table
            Me.TreeViewMultiSelect1.LabelEdit = True
            Me.ToolStripButton2.Enabled = False
            Me.ToolStripButton3.Enabled = False
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_BeforeExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeViewMultiSelect1.BeforeExpand
        If e IsNot Nothing Then

            If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                ClassApplication.Should_Education_Edition()
                Exit Sub
            End If

            If TypeOf e.Node.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access AndAlso e.Node.Nodes.Count > 0 AndAlso e.Node.Nodes(0).Text = "factise" Then
                'on efface les noeuds enfants pour le noeud selectionné
                e.Node.Nodes.Clear()
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                    Dim proc As New Process
                    With proc.StartInfo
                        .FileName = Application.StartupPath & "\Access32.exe"
                        .CreateNoWindow = True
                        .ErrorDialog = True
                        .ErrorDialogParentHandle = Me.Handle
                        .RedirectStandardOutput = True
                        .UseShellExecute = False
                        .WindowStyle = ProcessWindowStyle.Hidden
                        If Not DirectCast(e.Node.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                            .Arguments = "db=" & ChrW(34) & e.Node.ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(e.Node.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " gettablelist"
                        Else
                            .Arguments = "db=" & ChrW(34) & e.Node.ToolTipText & ChrW(34) & " gettablelist"
                        End If
                    End With
                    proc.Start()
                    Dim result As String = proc.StandardOutput.ReadLine
                    proc.WaitForExit()

                    If Not result = "" Then
                        For Each strr As String In result.Split("|")
                            Dim node As New System.Windows.Forms.TreeNode
                            With node
                                .Name = strr
                                .Text = strr
                                .ToolTipText = strr
                                .ImageIndex = 5
                                .SelectedImageIndex = 5
                            End With
                            e.Node.Nodes.Add(node)
                        Next
                    End If
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                End If





            ElseIf TypeOf e.Node.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer AndAlso e.Node.Nodes.Count > 0 AndAlso e.Node.Nodes(0).Text = "factise" Then
                'on efface les noeuds enfants pour le noeud selectionné
                e.Node.Nodes.Clear()

                Dim cnx As New ClassBasesDeDonneesSQLServer
                With DirectCast(e.Node.Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                    cnx.Connect(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Nothing, "yes")
                    If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(e.Node.Text) = 1 Then
                        For Each strr As String In cnx.GetTables(e.Node.Text)
                            Dim node As New System.Windows.Forms.TreeNode
                            With node
                                .Name = strr
                                .Text = strr
                                .ToolTipText = strr
                                .ImageIndex = 5
                                .SelectedImageIndex = 5
                            End With
                            e.Node.Nodes.Add(node)
                        Next
                    Else
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                            .MainInstruction = RM.GetString("MainInstruction10")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                    End If
                    cnx.Disconnect()
                End With





            ElseIf TypeOf e.Node.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL AndAlso e.Node.Nodes.Count > 0 AndAlso e.Node.Nodes(0).Text = "factise" Then
                'on efface les noeuds enfants pour le noeud selectionné
                e.Node.Nodes.Clear()

                Dim cnx As New ClassBasesDeDonneesMySQL
                With DirectCast(e.Node.Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                    cnx.Connect(.Host, .Port, .Utilisateur, .MotDePasse, e.Node.Text, True)
                    If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(e.Node.Text) = 1 Then
                        For Each strr As String In cnx.GetTables(e.Node.Text)
                            Dim node As New System.Windows.Forms.TreeNode
                            With node
                                .Name = strr
                                .Text = strr
                                .ToolTipText = strr
                                .ImageIndex = 5
                                .SelectedImageIndex = 5
                            End With
                            e.Node.Nodes.Add(node)
                        Next
                    Else
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                            .MainInstruction = RM.GetString("MainInstruction10")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                    End If
                    cnx.Disconnect()
                End With

            End If

        End If
    End Sub

    Private Sub TreeViewMultiSelect1_NodeMouseDoubleClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewMultiSelect1.NodeMouseDoubleClick
        If Me.TreeViewMultiSelect1.SelectedNodes(0) IsNot Nothing Then
            If (Me.TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 5 AndAlso (TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access OrElse TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer OrElse TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL)) Then

                If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                    ClassApplication.Should_Education_Edition()
                    Exit Sub
                End If

                OuvrirToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub TreeViewMultiSelect1_BeforeLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeViewMultiSelect1.BeforeLabelEdit

    End Sub

    Private Sub TreeViewMultiSelect1_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.NodeLabelEditEventArgs) Handles TreeViewMultiSelect1.AfterLabelEdit
        If Me.TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
            If Not e.Label = Nothing Then

                If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                    ClassApplication.Should_Education_Edition()
                    e.CancelEdit = True
                    Exit Sub
                End If

                Dim nouvo_chemin As String = Nothing
                Dim ancien_chemin As String = Nothing
                Dim oki As Boolean = True
                For Each strr As String In Caractères_Interdit_Non_Numerique
                    If e.Label.Contains(strr) Then oki = False : Exit For
                Next
                If oki Then

                    ancien_chemin = e.Node.Text
                    nouvo_chemin = e.Label

                    If (e.Node.ImageIndex = 5 AndAlso TypeOf e.Node.Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access) Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                            Dim proc As New Process
                            With proc.StartInfo
                                .FileName = Application.StartupPath & "\Access32.exe"
                                .CreateNoWindow = True
                                .ErrorDialog = True
                                .ErrorDialogParentHandle = Me.Handle
                                .RedirectStandardOutput = True
                                .UseShellExecute = False
                                .WindowStyle = ProcessWindowStyle.Hidden
                                If Not DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                                    .Arguments = "db=" & ChrW(34) & e.Node.Parent.ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(e.Node.Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " renametable=" & e.Node.Text & "|" & e.Label
                                Else
                                    .Arguments = "db=" & ChrW(34) & e.Node.Parent.ToolTipText & ChrW(34) & " renametable=" & e.Node.Text & "|" & e.Label
                                End If
                            End With
                            proc.Start()
                            Dim result As String = proc.StandardOutput.ReadLine
                            proc.WaitForExit()

                            If Not result = "1" Then
                                e.CancelEdit = True
                            Else
                                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                    If page.Controls.Count > 0 Then
                                        If TypeOf page.Controls(0) Is DocEditeurTable AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomTable = ancien_chemin AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees = e.Node.Parent.Text Then
                                            DirectCast(page.Controls(0), DocEditeurTable).NomTable = nouvo_chemin
                                            If Not page.Text.EndsWith("*") Then
                                                page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label
                                            Else
                                                page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label & "*"
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                                .MainInstruction = RM.GetString("MainInstruction10")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If




                    ElseIf (e.Node.ImageIndex = 5 AndAlso TypeOf e.Node.Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer) Then
                        Dim cnx As New ClassBasesDeDonneesSQLServer
                        With DirectCast(e.Node.Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                            cnx.Connect(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Nothing, "yes")
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                If Not cnx.RenameTable(e.Node.Text, e.Label) = 1 Then
                                    e.CancelEdit = True
                                Else
                                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                        If page.Controls.Count > 0 Then
                                            If TypeOf page.Controls(0) Is DocEditeurTable AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomTable = ancien_chemin AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees = e.Node.Parent.Text Then
                                                DirectCast(page.Controls(0), DocEditeurTable).NomTable = nouvo_chemin
                                                If Not page.Text.EndsWith("*") Then
                                                    page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label
                                                Else
                                                    page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label & "*"
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                        End With




                    ElseIf (e.Node.ImageIndex = 5 AndAlso TypeOf e.Node.Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL) Then
                        Dim cnx As New ClassBasesDeDonneesMySQL
                        With DirectCast(e.Node.Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                            cnx.Connect(.Host, .Port, .Utilisateur, .MotDePasse, Nothing, True)
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                If Not cnx.RenameTable(e.Node.Text, e.Label) = 1 Then
                                    e.CancelEdit = True
                                Else
                                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                        If page.Controls.Count > 0 Then
                                            If TypeOf page.Controls(0) Is DocEditeurTable AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomTable = ancien_chemin AndAlso DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees = e.Node.Parent.Text Then
                                                DirectCast(page.Controls(0), DocEditeurTable).NomTable = nouvo_chemin
                                                If Not page.Text.EndsWith("*") Then
                                                    page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label
                                                Else
                                                    page.Text = DirectCast(page.Controls(0), DocEditeurTable).NomBaseDeDonnees & "." & e.Label & "*"
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                        End With



                    End If


                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                        .Content = RM.GetString("Content26") & Environment.NewLine & "\ / : * ? " & ChrW(34) & " < > |"
                        .MainInstruction = RM.GetString("MainInstruction11")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    e.CancelEdit = True
                End If
            Else
                e.CancelEdit = True
            End If
        End If
    End Sub














    Private Sub ContextMenuStrip1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        With Me

            .OuvrirToolStripMenuItem.Enabled = False

            .ActualiserToolStripMenuItem.Enabled = True
            .SupprimerToolStripMenuItem.Enabled = True

            If .TreeViewMultiSelect1.SelectedNodes.Count = 1 Then
                If .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 0 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 1 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 2 OrElse .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 3 Then
                    .ActualiserToolStripMenuItem.Enabled = False
                    .SupprimerToolStripMenuItem.Enabled = False
                End If
                If .TreeViewMultiSelect1.SelectedNodes(0).ImageIndex = 5 Then
                    .OuvrirToolStripMenuItem.Enabled = True
                    .ActualiserToolStripMenuItem.Enabled = False
                End If
            End If

        End With
    End Sub

    ' Créer une base Access
    Private Sub AccessToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AccessToolStripMenuItem.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New NouvelleBaseAccess
            If frm.ShowDialog() = DialogResult.OK AndAlso My.Computer.FileSystem.FileExists(frm.Nom_KryptonTextBox1.Text) Then
                If Me.TreeViewMultiSelect1.Nodes("Access").Nodes.ContainsKey("Access|" & frm.Nom_KryptonTextBox1.Text) Then
                    Me.TreeViewMultiSelect1.Nodes("Access").Nodes.RemoveByKey("Access|" & frm.Nom_KryptonTextBox1.Text)
                End If
                Dim node As New System.Windows.Forms.TreeNode
                With node
                    .Name = "Access|" & frm.Nom_KryptonTextBox1.Text
                    .Text = My.Computer.FileSystem.GetName(frm.Nom_KryptonTextBox1.Text).Replace(My.Computer.FileSystem.GetFileInfo(frm.Nom_KryptonTextBox1.Text).Extension, Nothing)
                    .ToolTipText = frm.Nom_KryptonTextBox1.Text
                    .Tag = New VelerSoftware.SZVB.BasesDeDoonees.Access(frm.Nom_KryptonTextBox1.Text, frm.KryptonTextBox1.Text)
                    .Nodes.Add("factise")
                    .ImageIndex = 4
                    .SelectedImageIndex = 4
                End With
                Me.TreeViewMultiSelect1.Nodes("Access").Nodes.Add(node)
                Me.TreeViewMultiSelect1.Nodes("Access").Expand()
            End If
        End Using
    End Sub

    ' Créer une base SQL Server
    Private Sub SQLServerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SQLServerToolStripMenuItem.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New NouvelleBaseSQLServer
            If frm.ShowDialog() = DialogResult.OK Then
                If Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.ContainsKey("SQLServer|" & frm.Nom_KryptonTextBox4.Text) Then
                    Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.RemoveByKey("SQLServer|" & frm.Nom_KryptonTextBox4.Text)
                End If
                Dim node As New System.Windows.Forms.TreeNode
                With node
                    .Name = "SQLServer|" & frm.Nom_KryptonTextBox4.Text
                    .Text = frm.Nom_KryptonTextBox4.Text
                    .ToolTipText = frm.Nom_KryptonTextBox4.Text
                    .Tag = New VelerSoftware.SZVB.BasesDeDoonees.SQLServer(frm.Adresse_KryptonTextBox1.Text, frm.Utilisateur_KryptonTextBox2.Text, frm.Mot_De_Passe_KryptonTextBox3.Text, frm.Port_KryptonTextBox1.Text, frm.LOCALE, frm.Nom_KryptonTextBox4.Text)
                    .Nodes.Add("factise")
                    .ImageIndex = 4
                    .SelectedImageIndex = 4
                End With
                Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.Add(node)
                Me.TreeViewMultiSelect1.Nodes("SQL Server").Expand()
            End If
        End Using
    End Sub

    ' Créer une base MySQL
    Private Sub MySQLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MySQLToolStripMenuItem.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New NouvelleBaseMySQL
            If frm.ShowDialog() = DialogResult.OK Then
                If Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.ContainsKey("MySQL|" & frm.Nom_KryptonTextBox4.Text) Then
                    Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.RemoveByKey("MySQL|" & frm.Nom_KryptonTextBox4.Text)
                End If
                Dim node As New System.Windows.Forms.TreeNode
                With node
                    .Name = "MySQL|" & frm.Nom_KryptonTextBox4.Text
                    .Text = frm.Nom_KryptonTextBox4.Text
                    .ToolTipText = frm.Nom_KryptonTextBox4.Text
                    .Tag = New VelerSoftware.SZVB.BasesDeDoonees.SQLServer(frm.Adresse_KryptonTextBox1.Text, frm.Utilisateur_KryptonTextBox2.Text, frm.Mot_De_Passe_KryptonTextBox3.Text, frm.Port_KryptonTextBox1.Text, frm.LOCALE, frm.Nom_KryptonTextBox4.Text)
                    .Nodes.Add("factise")
                    .ImageIndex = 4
                    .SelectedImageIndex = 4
                End With
                Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.Add(node)
                Me.TreeViewMultiSelect1.Nodes("MySQL").Expand()
            End If
        End Using
    End Sub





    ' Ajouter une base Access existante
    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New AjouterBaseAccessExistante
            If frm.ShowDialog() = DialogResult.OK AndAlso My.Computer.FileSystem.FileExists(frm.Nom_KryptonTextBox1.Text) Then
                If Not Me.TreeViewMultiSelect1.Nodes("Access").Nodes.ContainsKey("Access|" & frm.Nom_KryptonTextBox1.Text) Then
                    Dim node As New System.Windows.Forms.TreeNode
                    With node
                        .Name = "Access|" & frm.Nom_KryptonTextBox1.Text
                        .Text = My.Computer.FileSystem.GetName(frm.Nom_KryptonTextBox1.Text).Replace(My.Computer.FileSystem.GetFileInfo(frm.Nom_KryptonTextBox1.Text).Extension, Nothing)
                        .ToolTipText = frm.Nom_KryptonTextBox1.Text
                        .Tag = New VelerSoftware.SZVB.BasesDeDoonees.Access(frm.Nom_KryptonTextBox1.Text, frm.KryptonTextBox1.Text)
                        .Nodes.Add("factise")
                        .ImageIndex = 4
                        .SelectedImageIndex = 4
                    End With
                    Me.TreeViewMultiSelect1.Nodes("Access").Nodes.Add(node)
                    Me.TreeViewMultiSelect1.Nodes("Access").Expand()
                End If
            End If
        End Using
    End Sub

    ' Ajouter une base SQL Server existante
    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New AjouterBaseSQLServerExistante
            If frm.ShowDialog() = DialogResult.OK Then
                If Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.ContainsKey("SQLServer|" & frm.Nom_KryptonTextBox4.Text) Then
                    Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.RemoveByKey("SQLServer|" & frm.Nom_KryptonTextBox4.Text)
                End If
                Dim node As New System.Windows.Forms.TreeNode
                With node
                    .Name = "SQLServer|" & frm.Nom_KryptonTextBox4.Text
                    .Text = frm.Nom_KryptonTextBox4.Text
                    .ToolTipText = frm.Nom_KryptonTextBox4.Text
                    .Tag = New VelerSoftware.SZVB.BasesDeDoonees.SQLServer(frm.Adresse_KryptonTextBox1.Text, frm.Utilisateur_KryptonTextBox2.Text, frm.Mot_De_Passe_KryptonTextBox3.Text, frm.Port_KryptonTextBox1.Text, frm.LOCALE, frm.Nom_KryptonTextBox4.Text)
                    .Nodes.Add("factise")
                    .ImageIndex = 4
                    .SelectedImageIndex = 4
                End With
                Me.TreeViewMultiSelect1.Nodes("SQL Server").Nodes.Add(node)
                Me.TreeViewMultiSelect1.Nodes("SQL Server").Expand()
            End If
        End Using
    End Sub

    ' Ajouter une base MySQL existante
    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
            ClassApplication.Should_Education_Edition()
            Exit Sub
        End If

        Using frm As New AjouterBaseMySQLExistante
            If frm.ShowDialog() = DialogResult.OK Then
                If Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.ContainsKey("MySQL|" & frm.Nom_KryptonTextBox4.Text) Then
                    Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.RemoveByKey("MySQL|" & frm.Nom_KryptonTextBox4.Text)
                End If
                Dim node As New System.Windows.Forms.TreeNode
                With node
                    .Name = "MySQL|" & frm.Nom_KryptonTextBox4.Text
                    .Text = frm.Nom_KryptonTextBox4.Text
                    .ToolTipText = frm.Nom_KryptonTextBox4.Text
                    .Tag = New VelerSoftware.SZVB.BasesDeDoonees.MySQL(frm.Adresse_KryptonTextBox1.Text, frm.Utilisateur_KryptonTextBox2.Text, frm.Mot_De_Passe_KryptonTextBox3.Text, frm.Port_KryptonTextBox1.Text, frm.Nom_KryptonTextBox4.Text)
                    .Nodes.Add("factise")
                    .ImageIndex = 4
                    .SelectedImageIndex = 4
                End With
                Me.TreeViewMultiSelect1.Nodes("MySQL").Nodes.Add(node)
                Me.TreeViewMultiSelect1.Nodes("MySQL").Expand()
            End If
        End Using
    End Sub







    ' Créer une table
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.TreeViewMultiSelect1.SelectedNodes(0) IsNot Nothing Then

            If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                ClassApplication.Should_Education_Edition()
                Exit Sub
            End If

            Using frm As New NouvelleTable
                If frm.ShowDialog() = DialogResult.OK Then
                    Dim table_name As String = frm.Nom_KryptonTextBox1.Text
                    Dim param As New System.Text.StringBuilder
                    For Each cell As DataGridViewRow In frm.DataGridView1.Rows
                        If cell.Cells.Count > 0 AndAlso Not CStr(cell.Cells(0).Value) = Nothing AndAlso Not CStr(cell.Cells(0).Value) = Nothing Then
                            param.Append(CStr(cell.Cells(0).Value) & "|" & CStr(cell.Cells(1).Value) & ",")
                        End If
                    Next

                    If TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                            Dim proc As New Process
                            With proc.StartInfo
                                .FileName = Application.StartupPath & "\Access32.exe"
                                .CreateNoWindow = True
                                .ErrorDialog = True
                                .ErrorDialogParentHandle = Me.Handle
                                .RedirectStandardOutput = True
                                .UseShellExecute = False
                                .WindowStyle = ProcessWindowStyle.Hidden
                                If Not DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                                    .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " createtable=" & table_name & ";" & param.ToString.TrimEnd(",")
                                Else
                                    .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & ChrW(34) & " createtable=" & table_name & ";" & param.ToString.TrimEnd(",")
                                End If
                            End With
                            proc.Start()
                            Dim result As String = proc.StandardOutput.ReadLine
                            proc.WaitForExit()

                            If result = "1" Then
                                If Me.TreeViewMultiSelect1.SelectedNodes(0).IsExpanded Then
                                    Dim node As New System.Windows.Forms.TreeNode
                                    With node
                                        .Name = table_name
                                        .Text = table_name
                                        .ToolTipText = table_name
                                        .ImageIndex = 5
                                        .SelectedImageIndex = 5
                                    End With
                                    Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add(node)
                                Else
                                    Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add("factise")
                                    Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
                                End If
                            End If
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                                .MainInstruction = RM.GetString("MainInstruction10")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If



                    ElseIf TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer Then
                        Dim columns As New Generic.List(Of String)
                        Dim types As New Generic.List(Of String)
                        If Not param.ToString = Nothing Then
                            For Each strr As String In param.ToString.TrimEnd(",").Split(",")
                                columns.Add(strr.Split("|")(0))
                                types.Add(strr.Split("|")(1))
                            Next
                        End If
                        Dim result As Integer
                        Dim cnx As New ClassBasesDeDonneesSQLServer
                        With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                            cnx.Connect(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Nothing, "yes")
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                result = cnx.CreateNewTable(table_name, columns, types)
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                        End With
                        If result = 1 Then
                            If Me.TreeViewMultiSelect1.SelectedNodes(0).IsExpanded Then
                                Dim node As New System.Windows.Forms.TreeNode
                                With node
                                    .Name = table_name
                                    .Text = table_name
                                    .ToolTipText = table_name
                                    .ImageIndex = 5
                                    .SelectedImageIndex = 5
                                End With
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add(node)
                            Else
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add("factise")
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
                            End If
                        End If



                    ElseIf TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL Then
                        Dim columns As New Generic.List(Of String)
                        Dim types As New Generic.List(Of String)
                        If Not param.ToString = Nothing Then
                            For Each strr As String In param.ToString.TrimEnd(",").Split(",")
                                columns.Add(strr.Split("|")(0))
                                types.Add(strr.Split("|")(1))
                            Next
                        End If
                        Dim result As Integer
                        Dim cnx As New ClassBasesDeDonneesMySQL
                        With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                            cnx.Connect(.Host, .Port, .Utilisateur, .MotDePasse, Nothing, True)
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                result = cnx.CreateNewTable(table_name, columns, types)
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                        End With
                        If result = 1 Then
                            If Me.TreeViewMultiSelect1.SelectedNodes(0).IsExpanded Then
                                Dim node As New System.Windows.Forms.TreeNode
                                With node
                                    .Name = table_name
                                    .Text = table_name
                                    .ToolTipText = table_name
                                    .ImageIndex = 5
                                    .SelectedImageIndex = 5
                                End With
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add(node)
                            Else
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add("factise")
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Expand()
                            End If
                        End If


                    End If
                End If
            End Using
        End If
    End Sub

    ' Actualiser
    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click, ActualiserToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes(0) IsNot Nothing Then

            If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                ClassApplication.Should_Education_Edition()
                Exit Sub
            End If

            With Me.TreeViewMultiSelect1.SelectedNodes(0)
                If TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access Then
                    'on efface les noeuds enfants pour le noeud selectionné
                    .Nodes.Clear()
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                        Dim proc As New Process
                        With proc.StartInfo
                            .FileName = Application.StartupPath & "\Access32.exe"
                            .CreateNoWindow = True
                            .ErrorDialog = True
                            .ErrorDialogParentHandle = Me.Handle
                            .RedirectStandardOutput = True
                            .UseShellExecute = False
                            .WindowStyle = ProcessWindowStyle.Hidden
                            If Not DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                                .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " gettablelist"
                            Else
                                .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).ToolTipText & ChrW(34) & " gettablelist"
                            End If
                        End With
                        proc.Start()
                        Dim result As String = proc.StandardOutput.ReadLine
                        proc.WaitForExit()

                        If Not result = "" Then
                            For Each strr As String In result.Split("|")
                                Dim node As New System.Windows.Forms.TreeNode
                                With node
                                    .Name = strr
                                    .Text = strr
                                    .ToolTipText = strr
                                    .ImageIndex = 5
                                    .SelectedImageIndex = 5
                                End With
                                .Nodes.Add(node)
                            Next
                        End If
                    Else
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                            .MainInstruction = RM.GetString("MainInstruction10")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                    End If





                ElseIf TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer Then
                    'on efface les noeuds enfants pour le noeud selectionné
                    .Nodes.Clear()
                    Dim cnx As New ClassBasesDeDonneesSQLServer
                    With DirectCast(.Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                        cnx.Connect(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Nothing, "yes")
                        If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                            For Each strr As String In cnx.GetTables(Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                                Dim node As New System.Windows.Forms.TreeNode
                                With node
                                    .Name = strr
                                    .Text = strr
                                    .ToolTipText = strr
                                    .ImageIndex = 5
                                    .SelectedImageIndex = 5
                                End With
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add(node)
                            Next
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                .MainInstruction = RM.GetString("MainInstruction10")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If
                        cnx.Disconnect()
                    End With





                ElseIf TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL Then
                    'on efface les noeuds enfants pour le noeud selectionné
                    .Nodes.Clear()
                    Dim cnx As New ClassBasesDeDonneesMySQL
                    With DirectCast(.Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                        cnx.Connect(.Host, .Port, .Utilisateur, .MotDePasse, Nothing, True)
                        If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                            For Each strr As String In cnx.GetTables(Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                                Dim node As New System.Windows.Forms.TreeNode
                                With node
                                    .Name = strr
                                    .Text = strr
                                    .ToolTipText = strr
                                    .ImageIndex = 5
                                    .SelectedImageIndex = 5
                                End With
                                Me.TreeViewMultiSelect1.SelectedNodes(0).Nodes.Add(node)
                            Next
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                .MainInstruction = RM.GetString("MainInstruction10")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If
                        cnx.Disconnect()
                    End With

                End If

            End With
        End If
    End Sub

    ' Supprimer une table/base
    Private Sub SupprimerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes(0) IsNot Nothing Then

            If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                ClassApplication.Should_Education_Edition()
                Exit Sub
            End If

            With Me.TreeViewMultiSelect1.SelectedNodes(0)
                If TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access OrElse TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer OrElse TypeOf .Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL Then
                    If Not My.Computer.FileSystem.FileExists(.ToolTipText) Then
                        Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Nodes.RemoveByKey(.Name)
                    Else
                        If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content43"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Nodes.RemoveByKey(.Name)
                        End If
                    End If

                ElseIf (.ImageIndex = 5 AndAlso TypeOf .Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer) Then
                    If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content41"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim cnx As New ClassBasesDeDonneesSQLServer
                        With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                            Dim result As Integer = -1
                            cnx.Connect(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Nothing, "yes")
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                result = cnx.DeleteTable(Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                            If result = 1 OrElse result = 0 Then
                                Me.TreeViewMultiSelect1.Nodes.Remove(Me.TreeViewMultiSelect1.SelectedNodes(0))
                            End If
                        End With
                    End If

                ElseIf (.ImageIndex = 5 AndAlso TypeOf .Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL) Then
                    If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content41"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Dim cnx As New ClassBasesDeDonneesMySQL
                        With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                            Dim result As Integer = -1
                            cnx.Connect(.Host, .Port, .Utilisateur, .MotDePasse, Nothing, True)
                            If cnx.GetConnectStatus = 1 AndAlso cnx.ChangeDataBase(.Base_de_données_initial) = 1 Then
                                result = cnx.DeleteTable(Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                            Else
                                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                With vd
                                    .Owner = Nothing
                                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content49"))
                                    .MainInstruction = RM.GetString("MainInstruction10")
                                    .WindowTitle = My.Application.Info.Title
                                    .Show()
                                End With
                            End If
                            cnx.Disconnect()
                            If result = 1 OrElse result = 0 Then
                                Me.TreeViewMultiSelect1.Nodes.Remove(Me.TreeViewMultiSelect1.SelectedNodes(0))
                            End If
                        End With
                    End If

                ElseIf (.ImageIndex = 5 AndAlso TypeOf .Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access) Then
                    If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content41"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                            Dim proc As New Process
                            With proc.StartInfo
                                .FileName = Application.StartupPath & "\Access32.exe"
                                .CreateNoWindow = True
                                .ErrorDialog = True
                                .ErrorDialogParentHandle = Me.Handle
                                .RedirectStandardOutput = True
                                .UseShellExecute = False
                                .WindowStyle = ProcessWindowStyle.Hidden
                                If Not DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                                    .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " deletetable=" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text
                                Else
                                    .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.ToolTipText & ChrW(34) & " deletetable=" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text
                                End If
                            End With
                            proc.Start()
                            Dim result As String = proc.StandardOutput.ReadLine
                            proc.WaitForExit()
                            If result = "1" OrElse result = "0" Then
                                Me.TreeViewMultiSelect1.Nodes.Remove(Me.TreeViewMultiSelect1.SelectedNodes(0))
                            End If
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                                .MainInstruction = RM.GetString("MainInstruction10")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If
                    End If

                End If
            End With
        End If
    End Sub

    ' Ouvrir une table
    Private Sub OuvrirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OuvrirToolStripMenuItem.Click
        If Me.TreeViewMultiSelect1.SelectedNodes(0) IsNot Nothing Then

            If My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard Then
                ClassApplication.Should_Education_Edition()
                Exit Sub
            End If

            If TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                    Dim proc As New Process
                    With proc.StartInfo
                        .FileName = Application.StartupPath & "\Access32.exe"
                        .CreateNoWindow = True
                        .ErrorDialog = True
                        .ErrorDialogParentHandle = Me.Handle
                        .RedirectStandardOutput = True
                        .UseShellExecute = False
                        .WindowStyle = ProcessWindowStyle.Hidden
                        If Not DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse = Nothing Then
                            .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.ToolTipText & ChrW(34) & " pswd=" & ChrW(34) & DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse & ChrW(34) & " getdatatable=" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text
                        Else
                            .Arguments = "db=" & ChrW(34) & Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.ToolTipText & ChrW(34) & " getdatatable=" & Me.TreeViewMultiSelect1.SelectedNodes(0).Text
                        End If
                    End With
                    proc.Start()
                    Dim result As String = proc.StandardOutput.ReadLine
                    proc.WaitForExit()

                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\datatable") Then
                        ClassBasesDeDonnees.Ouvrir_Table_Access(Application.StartupPath & "\Temp\datatable", Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.ToolTipText, DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.Access).MotDePasse, Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Text, Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                    End If
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                End If




            ElseIf TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer Then
                With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.SQLServer)
                    ClassBasesDeDonnees.Ouvrir_Table_SQLServer(.Locale, .Host, .Port, .Utilisateur, .MotDePasse, Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Text, Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                End With




            ElseIf TypeOf Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL Then
                With DirectCast(Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Tag, VelerSoftware.SZVB.BasesDeDoonees.MySQL)
                    ClassBasesDeDonnees.Ouvrir_Table_MySQL(.Host, .Port, .Utilisateur, .MotDePasse, Me.TreeViewMultiSelect1.SelectedNodes(0).Parent.Text, Me.TreeViewMultiSelect1.SelectedNodes(0).Text)
                End With

            End If
        End If
    End Sub

End Class
