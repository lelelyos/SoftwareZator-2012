''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Gestionnaire_Plugins

    Private Sub Fermer_Document_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

            .TreeView1.BeginUpdate()

            Dim List_item As New Generic.List(Of TreeNode)
            Dim ite_plugin, ite As TreeNode
            Dim nbr_actions As Integer = 0

            For Each plug As ClassPluginServices.Plugin In PLUGINS
                ite_plugin = New TreeNode(plug.PluginName, 0, 0)
                ite_plugin.Tag = plug
                nbr_actions += plug.Actions.Count
                For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                    If act._ToolBoxImage Is Nothing Then
                        ite = New TreeNode(act.GetType.FullName, 1, 1)
                    Else
                        .ImageList1.Images.Add(act._ToolBoxImage)
                        ite = New TreeNode(act.GetType.FullName, .ImageList1.Images.Count - 1, .ImageList1.Images.Count - 1)
                    End If
                    ite.Text = act.DisplayName
                    ite.Tag = act
                    ite_plugin.Nodes.Add(ite)
                Next
                List_item.Add(ite_plugin)
            Next

            .Label2.Text = String.Format(RM.GetString("Gestionnaire_Plugins_Texte_Nbr"), My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition), PLUGINS.Count, nbr_actions)

            .TreeView1.Nodes.AddRange(List_item.ToArray)

            .TreeView1.TreeViewNodeSorter = New VelerSoftware.SZC.TreeViewComparer.TreeViewComparer()
            .TreeView1.EndUpdate()

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.TreeView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.TreeView1.Handle, 4352 + 44, 64, 64)
            VelerSoftware.SZC.Windows.User32.SendMessage(.TreeView1.Handle, 4352 + 44, 32, 32)

        End With
    End Sub

    Private Sub Options_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub Options_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        With Me.PropertyGrids1
            If Not Me.TreeView1.SelectedNode Is Nothing Then
                .SelectedObjects = Nothing
                .Item.Clear()
                .ItemSet.Clear()
                .ShowCustomProperties = True
                .Refresh()
                If TypeOf Me.TreeView1.SelectedNode.Tag Is ClassPluginServices.Plugin Then
                    Dim OBJ As ClassPluginServices.Plugin = Me.TreeView1.SelectedNode.Tag
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_2"), OBJ.PluginName, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_3"), OBJ.PluginVersion, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_2"), OBJ.Assembly.FullName, True, RM.GetString("Gestionnaire_Plugins_Proprietes_6"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_8"), OBJ.Assembly.Location, True, RM.GetString("Gestionnaire_Plugins_Proprietes_6"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_5"), OBJ.Actions.Count, True, RM.GetString("Gestionnaire_Plugins_Proprietes_4"), "", True)
                    .Refresh()
                ElseIf TypeOf Me.TreeView1.SelectedNode.Tag Is VelerSoftware.Plugins3.Action Then
                    Dim OBJ As VelerSoftware.Plugins3.Action = Me.TreeView1.SelectedNode.Tag
                    If Not OBJ.Category = Nothing Then .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_9"), OBJ.Category, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)
                    If Not OBJ.Description = Nothing Then .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_10"), OBJ.Description, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)
                    If Not OBJ.DisplayName = Nothing Then .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_2"), OBJ.DisplayName, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)
                    If Not OBJ.FileHelp = Nothing Then .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_17"), OBJ.FileHelp, True, RM.GetString("Gestionnaire_Plugins_Proprietes_1"), "", True)

                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_12"), OBJ.CompatibleClass.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")), True, RM.GetString("Gestionnaire_Plugins_Proprietes_11"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_13"), OBJ.CompatibleFonctions.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")), True, RM.GetString("Gestionnaire_Plugins_Proprietes_11"), "", True)

                    If Not OBJ.ClassCode = Nothing Then .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_14"), OBJ.ClassCode, True, RM.GetString("Gestionnaire_Plugins_Proprietes_15"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_16"), OBJ.References.AsReadOnly, True, RM.GetString("Gestionnaire_Plugins_Proprietes_15"), "", True)

                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_19"), OBJ.Voice_Recognition_Dictionary.AsReadOnly, True, RM.GetString("Gestionnaire_Plugins_Proprietes_18"), "", True)
                    .Item.Add(RM.GetString("Gestionnaire_Plugins_Proprietes_20"), OBJ.Voice_Recognition_Expressions_Dictionary.AsReadOnly, True, RM.GetString("Gestionnaire_Plugins_Proprietes_18"), "", True)
                    .Refresh()
                End If
            End If
        End With
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

End Class
