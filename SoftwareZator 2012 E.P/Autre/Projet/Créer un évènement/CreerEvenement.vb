''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class CreerEvenement

    Friend Ctrl, Ctrl2, Tip As String


    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter


    Private Sub CreerEvenement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView2.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView2.Handle, 4096 + 54, 65536, 65536)

        'LV 1
        listviewsorter_lv1.ListView = Me.ListView2
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView2.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.ColumnComparerCollection(Me.ListView2.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
        listviewsorter_lv1.Sort(0)

        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Nom_KryptonTextBox1))


        DisableNextButton()
        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("CreerEvenemt_Caption")
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_KryptonTextBox1.TextChanged
        If Me.Nom_KryptonTextBox1.Text = Nothing OrElse Me.Nom_KryptonTextBox1.Text.Contains(" ") Then
            Me.ErrorProvider1.SetError(Me.Nom_KryptonTextBox1, Me.ToolTip1.GetToolTip(Me.Nom_KryptonTextBox1))
            DisableNextButton()
        Else
            Me.ErrorProvider1.SetError(Me.Nom_KryptonTextBox1, "")
            EnableNextButton()
        End If
    End Sub

    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nom_KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub ListView2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
        GoToTab(Me.WizardTabControl1.TabPages(1))
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        If Me.ListView2.SelectedIndices.Count > 0 Then
            EnableNextButton()
        Else
            DisableNextButton()
        End If
    End Sub

    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        If Me.WizardTabControl1.SelectedIndex = 0 Then
            ListView2_SelectedIndexChanged(Nothing, Nothing)
        ElseIf Me.WizardTabControl1.SelectedIndex = 1 Then
            If Me.Nom_KryptonTextBox1.Text = Nothing Then
                Me.Nom_KryptonTextBox1.Text = Ctrl2 & "_" & Me.ListView2.SelectedItems(0).Text
            End If
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

    Private Sub OnFinishButton_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    If Not Ajouter_Evenement(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre), Me.ListView2.SelectedItems(0).Text, Me.Nom_KryptonTextBox1.Text, CStr(Me.ListView2.SelectedItems(0).Tag)) Then
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub


    Private Function Ajouter_Evenement(ByVal ChildForm As DocConcepteurFenetre, ByVal Nom_Evenement As String, ByVal Valeur_Propriete As String, ByVal Parameter As String) As Boolean
        Dim ok As Boolean = True

        Dim tmp() As String

        Dim Nom_Ctrl_Actif As String
        If Not DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.GetType.BaseType.FullName = "System.ComponentModel.Component" Then
            If DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Contains("[") Then
                Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
            Else
                Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.GetType.GetProperty("Name").GetValue(DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject, Nothing)
            End If
        Else
            Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
        End If

        If Not ChildForm.SelectionService.SelectionCount = 0 Then

            For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In ChildForm.KryptonNavigator2.Pages
                If Not DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Nothing Then
                    If DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1.ToLower = Valeur_Propriete.ToLower Then
                        ok = False
                        Exit For
                    End If
                End If
            Next

            If ok Then
                For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In ChildForm.KryptonNavigator2.Pages
                    If Not DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param2 = Nothing Then
                        tmp = Split(DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param2, ".")
                        If tmp(0) = Nom_Ctrl_Actif Then
                            If Me.ListView2.SelectedItems(0).Text = tmp(tmp.Length - 1) Then
                                If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content20"), Ctrl2, Me.ListView2.SelectedItems(0).Text, Valeur_Propriete), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                    DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Valeur_Propriete
                                    DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName = Valeur_Propriete
                                    TAB.Text = Valeur_Propriete
                                    ChildForm.KryptonNavigator1.SelectedIndex = 1
                                    ChildForm.KryptonNavigator2.SelectedPage = TAB
                                    ChildForm.DocumentModifier()
                                    Return True
                                    Exit Function
                                Else
                                    Return False
                                    Exit Function
                                End If
                            End If
                        ElseIf tmp(0) = "Me" AndAlso Ctrl2 = ChildForm.Host.RootComponent.Site.Name Then
                            If Me.ListView2.SelectedItems(0).Text = tmp(tmp.Length - 1) Then
                                If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content20"), Ctrl2, Me.ListView2.SelectedItems(0).Text, Valeur_Propriete), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                    DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Valeur_Propriete
                                    DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName = Valeur_Propriete
                                    TAB.Text = Valeur_Propriete
                                    ChildForm.KryptonNavigator1.SelectedIndex = 1
                                    ChildForm.KryptonNavigator2.SelectedPage = TAB
                                    ChildForm.DocumentModifier()
                                    Return True
                                    Exit Function
                                Else
                                    Return False
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            Dim oki As Boolean = True
            For Each strr As String In Caractères_Interdit_Non_Numerique
                If Me.Nom_KryptonTextBox1.Text.Contains(strr) Then oki = False : Exit For
            Next
            If ok AndAlso oki AndAlso (Not Mot_Cles_Interdit.Contains(Me.Nom_KryptonTextBox1.Text)) Then
                ' Initialisation de la première action (VelerSoftware.GeneralPlugin.Fonction)
                Dim Fonction As New VelerSoftware.Plugins3.ActionWithChildren
                For Each plug As ClassPluginServices.Plugin In PLUGINS
                    For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                        If act.GetType.FullName = "VelerSoftware.GeneralPlugin.Fonction" Then
                            Fonction = DirectCast(plug.Assembly.CreateInstance(act.GetType.FullName), VelerSoftware.Plugins3.ActionWithChildren)
                            Fonction.Tools = New ClassActionTools
                        End If
                    Next
                Next
                Fonction.Param1 = Valeur_Propriete
                Fonction.Param2 = Ctrl & "." & Nom_Evenement
                Fonction.Param3 = Parameter
                Fonction.Param4 = False
                Fonction.DisplayName = Valeur_Propriete
                ' Génération de l'ID
                For i = 0 To 50 - 1
                    Fonction.id = Fonction.id & Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                Next
                Fonction.Added = True

                Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
                editor.Dock = DockStyle.Fill
                editor.IsWindow = True
                editor.DebuggerService = editor.WorkflowDesigne.DebugManagerView

                ' Génération du nom de fichier Temporaire
                For i = 0 To 50 - 1
                    editor.TempXAMLFileName &= Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                Next
                editor.TempXAMLFileName &= ".xaml"

                Xaml.XamlServices.Save(Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName, Fonction)
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName) Then
                    editor.WorkflowDesigne.Load(Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName)
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Return False
                    Exit Function
                End If

                Dim CloseButton As New VelerSoftware.Design.Toolkit.ButtonSpecAny
                CloseButton.Type = VelerSoftware.Design.Toolkit.PaletteButtonSpecStyle.Close
                AddHandler CloseButton.Click, AddressOf ChildForm.CloseButton_Click

                Dim Tab2 As New VelerSoftware.Design.Navigator.KryptonPage
                DirectCast(Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
                Tab2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
                Tab2.ButtonSpecs.Add(CloseButton)
                Tab2.Cursor = System.Windows.Forms.Cursors.Default
                Tab2.Flags = 65534
                Tab2.LastVisibleSet = True
                Tab2.MinimumSize = New System.Drawing.Size(50, 50)
                Tab2.Name = Valeur_Propriete
                Tab2.UniqueName = Valeur_Propriete
                Tab2.Text = Valeur_Propriete
                Tab2.Controls.Add(editor)
                DirectCast(Tab2, System.ComponentModel.ISupportInitialize).EndInit()
                ChildForm.KryptonNavigator2.Pages.Add(Tab2)

                ChildForm.KryptonNavigator1.SelectedIndex = 1
                ChildForm.KryptonNavigator2.SelectedPage = Tab2

                AddHandler editor.SelectedActionChanger, AddressOf ChildForm.SelectedActionChanged

                ChildForm.DocumentModifier()

                Return True
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content19"), Valeur_Propriete)
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                Return False
            End If

        Else
            Return False
        End If

    End Function

End Class
