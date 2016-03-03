''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ActionToolsSelectionnerTypeForm

#Region "RESULTAT"

    Private _RESULTAT As Type

    <System.ComponentModel.Category("General"), System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Description("Est égale au type sélectionné dans la fenêtre.")> _
    Public Property RESULTAT() As Type
        Get
            Return _RESULTAT
        End Get
        Set(ByVal value As Type)
            _RESULTAT = value
        End Set
    End Property

#End Region

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent(). 
        'Me.BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Sub ActionToolsSelectionnerTypeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")

        Me.TreeView1.BeginUpdate()



        Dim List_type As New Generic.List(Of Type)
        Dim List_item As New Generic.List(Of TreeNode)
        Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl
        Dim ite_assembly, ite As TreeNode
        If Not Me.Tag Is Nothing Then
            For Each ref As VelerSoftware.SZVB.Projet.Reference In DirectCast(Me.Tag, Generic.List(Of VelerSoftware.SZVB.Projet.Reference))
                If (Not ref Is Nothing) AndAlso (Not ref.Assembly Is Nothing) Then
                    List_type = New Generic.List(Of Type)
                    List_type.AddRange(h.LoadTypesFromAssembly(ref.Assembly))
                    ite_assembly = New TreeNode(ref.Name, 2, 2)
                    For Each tip As Type In List_type
                        If (tip.IsPublic AndAlso tip.IsVisible) AndAlso (tip.IsClass OrElse tip.IsValueType) Then
                            If Not ite_assembly.Nodes.ContainsKey(tip.Namespace) Then ite_assembly.Nodes.Add(New TreeNode(tip.Namespace, 3, 3)) : ite_assembly.Nodes(ite_assembly.Nodes.Count - 1).Name = tip.Namespace
                            ite = New TreeNode(tip.Name, 4, 4)
                            ite.Tag = tip
                            Try
                                If Not ite_assembly.Nodes(tip.Namespace).Nodes.ContainsKey(tip.Name) Then ite_assembly.Nodes(tip.Namespace).Nodes.Add(ite)
                            Catch : End Try
                        End If
                    Next
                    List_item.Add(ite_assembly)
                End If
            Next
        End If


        Me.TreeView1.Nodes.AddRange(List_item.ToArray)

        Me.TreeView1.TreeViewNodeSorter = New VelerSoftware.SZC.TreeViewComparer.TreeViewComparer()
        Me.TreeView1.EndUpdate()

        Me.EnableCancelButton()
        Me.DisableOKButton()


        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.TreeView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 64, 64)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.TreeView1.Handle, 4352 + 44, 32, 32)


    End Sub

    Private Sub ActionToolsSelectionnerTypeForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If Me.OK_Button.Enabled Then
            Me.RESULTAT = Me.TreeView1.SelectedNode.Tag

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ActionToolsSelectionnerTypeForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.RESULTAT = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TreeView1_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Me.TreeView1.SelectedNode.ImageIndex = 4 Then
            Me.EnableOKButton()
        Else
            Me.DisableOKButton()
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TreeView1.DoubleClick
        Me.TreeView1_AfterSelect(Nothing, Nothing)
        Me.ActionToolsSelectionnerTypeForm_OnOKButtonClicked(Nothing, Nothing)
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
