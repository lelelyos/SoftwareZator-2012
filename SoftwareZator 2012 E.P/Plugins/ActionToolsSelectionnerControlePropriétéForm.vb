''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ActionToolsSelectionnerCOntrolePropriétéForm

#Region "RESULTAT"

    Private _RESULTAT As String

    <System.ComponentModel.Category("General"), System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content), System.ComponentModel.Description("Est égale au type sélectionné dans la fenêtre.")> _
    Public Property RESULTAT() As String
        Get
            Return _RESULTAT
        End Get
        Set(ByVal value As String)
            _RESULTAT = value
        End Set
    End Property

#End Region

    Friend Property SelectProperty As Boolean
    Friend Property OnlyArrayProperty As Boolean
    Friend Property OnlyFollowingControlsTypes As String()
    Friend Property OnlyFollowingPropertiesTypes As String()
    Friend Property AllowSelectForms As Boolean

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent(). 
        'Me.BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Sub ActionToolsSelectionnerTypeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CancelButtonText = RM.GetString("AeroWindowsForm_CancelButtontext")
        If SelectProperty Then
            Me.Label1.Text = RM.GetString("ActionSelectionnerControlePropriété")
        Else
            Me.Label1.Text = RM.GetString("ActionSelectionnerControle")
        End If

        Me.TreeView1.BeginUpdate()


        Dim List_item As New Generic.List(Of TreeNode)
        Dim ite_assembly, ite As TreeNode
        Dim oki As Boolean
        ite_assembly = Nothing
        If TypeOf Me.Tag Is ClassActionTools Then
            For Each ctrl As VelerSoftware.Plugins3.Windows.Core.Object In DirectCast(Me.Tag, ClassActionTools).GetCurrentProjectWindowsControls
                If ctrl.ObjectType = GetType(CodeDom.CodeTypeDeclaration) Then
                    ite_assembly = New TreeNode(ctrl.FullName, 2, 2)
                    ite_assembly.ToolTipText = DirectCast(ctrl.Object, CodeDom.CodeTypeDeclaration).BaseTypes(0).BaseType
                    ite_assembly.Tag = ctrl.FullName
                    If SelectProperty AndAlso AllowSelectForms Then ite_assembly.Nodes.Add("factise", "factise")
                    List_item.Add(ite_assembly)
                ElseIf ctrl.ObjectType = GetType(CodeDom.CodeMemberField) Then
                    oki = False
                    If OnlyFollowingControlsTypes IsNot Nothing Then
                        If OnlyFollowingControlsTypes.Contains(DirectCast(ctrl.Object, CodeDom.CodeMemberField).Type.BaseType) Then
                            oki = True
                        End If
                    Else
                        oki = True
                    End If
                    If oki Then
                        ite = New TreeNode(ctrl.FullName.Split(".")(1), 3, 3)
                        ite.ToolTipText = DirectCast(ctrl.Object, CodeDom.CodeMemberField).Type.BaseType
                        ite.Tag = ctrl.FullName
                        If SelectProperty Then ite.Nodes.Add("factise", "factise")
                        ite_assembly.Nodes.Add(ite)
                    End If
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
        If Me.TreeView1.SelectedNode IsNot Nothing Then
            If SelectProperty Then
                If Me.TreeView1.SelectedNode.ImageIndex = 4 Then
                    Me.EnableOKButton()
                Else
                    Me.DisableOKButton()
                End If
            Else
                If AllowSelectForms Then
                    If Me.TreeView1.SelectedNode.ImageIndex = 2 OrElse Me.TreeView1.SelectedNode.ImageIndex = 3 Then
                        Me.EnableOKButton()
                    Else
                        Me.DisableOKButton()
                    End If
                Else
                    If Me.TreeView1.SelectedNode.ImageIndex = 3 Then
                        Me.EnableOKButton()
                    Else
                        Me.DisableOKButton()
                    End If
                End If
            End If
        Else
            Me.DisableOKButton()
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles TreeView1.DoubleClick
        Me.TreeView1_AfterSelect(Nothing, Nothing)
        Me.ActionToolsSelectionnerTypeForm_OnOKButtonClicked(Nothing, Nothing)
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As System.Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        If e.Node.Nodes.Count > 0 AndAlso e.Node.Nodes.ContainsKey("factise") Then
            e.Node.Nodes.RemoveByKey("factise")
            Dim oki As Boolean
            Dim ite_property As TreeNode

            For Each a As System.Reflection.PropertyInfo In DirectCast(Me.Tag, ClassActionTools).GetPropertyList(e.Node.ToolTipText)
                If a.CanRead Then
                    oki = False
                    If OnlyArrayProperty Then
                        If a.PropertyType.FullName.EndsWith("[]") OrElse a.PropertyType.FullName.Contains("+") OrElse a.PropertyType.FullName.Contains("Collection") Then
                            oki = True
                        End If
                    Else
                        oki = True
                    End If
                    If oki Then
                        oki = False
                        If OnlyFollowingPropertiesTypes IsNot Nothing Then
                            If OnlyFollowingPropertiesTypes.Contains(a.PropertyType.FullName) Then
                                oki = True
                            End If
                        Else
                            oki = True
                        End If
                        If oki Then
                            ite_property = New TreeNode(a.Name, 4, 4)
                            ite_property.ToolTipText = a.PropertyType.FullName
                            ite_property.Tag = e.Node.Tag & "." & a.Name
                            e.Node.Nodes.Add(ite_property)
                        End If
                    End If
                End If
            Next
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
End Class
