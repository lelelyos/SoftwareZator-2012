''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class NouveauProjet

    Friend Tip As String

    Private listviewsorter_lv1 As New VelerSoftware.SZC.ListViewStored.ListViewSorter


    Private Sub NouveauDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        Me.ToolTip1.SetToolTip(Me.Nom_Projet_KryptonTextBox1.TextBox, Me.ToolTip1.GetToolTip(Nom_Projet_KryptonTextBox1))
        Me.ToolTip1.SetToolTip(Me.Emplacement_KryptonTextBox2.TextBox, Me.ToolTip1.GetToolTip(Emplacement_KryptonTextBox2))
        Me.ToolTip1.SetToolTip(Me.Nom_Solution_KryptonTextBox3.TextBox, Me.ToolTip1.GetToolTip(Nom_Solution_KryptonTextBox3))

        DisableNextButton()
        GoToTab(Me.WizardTabControl1.TabPages(0))

        Me.CancelButtonText = RM.GetString("Wizard_CancelButtonText")
        Me.NextButtonText = RM.GetString("Wizard_NextButtonText")
        Me.FinishButtonText = RM.GetString("Wizard_FinishButtonText")
        Me.BackCaption = RM.GetString("Wizard_BackCaption")
        Me.Caption = RM.GetString("NouveauProjet_Caption")
    End Sub


    Private Sub WizardTabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles WizardTabControl1.Selected
        If Me.WizardTabControl1.SelectedIndex = 0 Then
            Me.HideNextButton()
            Me.EnableNextButton()
        ElseIf Me.WizardTabControl1.SelectedIndex = 1 Then
            Me.ShowNextButton()
            Me.DisableNextButton()
            ListView1_SelectedIndexChanged(Nothing, Nothing)
        ElseIf Me.WizardTabControl1.SelectedIndex = 2 Then
            If SOLUTION IsNot Nothing Then
                Me.Emplacement_KryptonTextBox2.Text = SOLUTION.Emplacement
                Me.RadioButton2.Checked = True
                Me.RadioButton2.Enabled = True
                Me.Nom_Solution_KryptonTextBox3.Enabled = False
                Me.Nom_Projet_KryptonTextBox1.Text = ClassFichier.Determine_Dossier_Existe(Me.Emplacement_KryptonTextBox2.Text, Me.ListView1.SelectedItems(0).Text.Replace(" ", "_"))
                Me.Nom_Solution_KryptonTextBox3.Text = ClassFichier.Determine_Dossier_Existe(Me.Emplacement_KryptonTextBox2.Text, "Solution")
            Else
                Me.RadioButton2.Enabled = False
                Me.RadioButton1.Checked = True
                Me.Nom_Solution_KryptonTextBox3.Enabled = True
                If My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
                    Me.Emplacement_KryptonTextBox2.Text = My.Settings.Emplacement_Project_Par_Defaut
                Else
                    Me.Emplacement_KryptonTextBox2.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                End If
                Me.Nom_Projet_KryptonTextBox1.Text = ClassFichier.Determine_Dossier_Existe(Me.Emplacement_KryptonTextBox2.Text & "\Solution", Me.ListView1.SelectedItems(0).Text.Replace(" ", "_"))
                Me.Nom_Solution_KryptonTextBox3.Text = ClassFichier.Determine_Dossier_Existe(Me.Emplacement_KryptonTextBox2.Text, "Solution")
            End If

            Nom_KryptonTextBox1_TextChanged(Nothing, Nothing)

            Me.ShowNextButton()
            Me.EnableNextButton()
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









    Private Sub Fenetre_CommandLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Windows_CommandLink.Click, DLL_CommandLink2.Click, Console_CommandLink1.Click
        Tip = CStr(sender.Tag)

        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML
        Dim ok As Boolean
        Dim names, images, descriptions As String
        Dim ite As ListViewItem

        Me.ListView1.BeginUpdate()

        Me.ListView1.Items.Clear()
        Me.ImageList2.Images.Clear()
        Me.ImageList2.ImageSize = New Size(32, 32)

        If Not My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates")) Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates"))
        End If
        If Not My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Project")) Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Project"))
        End If


        ' templates
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Project")) Then
            For Each Fichier As String In My.Computer.FileSystem.GetFiles(IO.Path.GetDirectoryName(Application.StartupPath & "\Templates\Project\"), FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.FileExists(Fichier) AndAlso My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToLower = ".sztemplate" Then
                    ok = False
                    names = Nothing
                    images = Nothing
                    descriptions = Nothing

                    XmlRead = New Xml.XmlTextReader(Fichier)
                    Do While XmlRead.Read()
                        Select Case XmlRead.NodeType
                            Case Xml.XmlNodeType.Element
                                Select Case XmlRead.Name
                                    Case "SZTemplate" ' Template
                                        If XmlRead.GetAttribute("version") = "3.0" AndAlso XmlRead.GetAttribute("type") = Tip Then
                                            names = XmlRead.GetAttribute("name_" & My.Settings.Langue)
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
                        Me.ListView1.Items.Add(ite)
                    End If

                End If
            Next
        End If

        Me.ListView1.EndUpdate()

        Me.TextBox1.Text = Nothing

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

    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nom_Projet_KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Nom_KryptonTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nom_Projet_KryptonTextBox1.TextChanged
        With Me
            If .Nom_Projet_KryptonTextBox1.Text = Nothing Then
                .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox1, ToolTip1.GetToolTip(Nom_Projet_KryptonTextBox1))
                .DisableNextButton()
            Else
                Dim oki As Boolean = True
                For Each strr As String In Caractères_Interdit_Non_Numerique
                    If Me.Nom_Projet_KryptonTextBox1.Text.Contains(strr) Then oki = False : Exit For
                Next
                If oki AndAlso (Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("0") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("1") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("2") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("3") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("4") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("5") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("6") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("7") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("8") OrElse Me.Nom_Projet_KryptonTextBox1.Text.StartsWith("9")) Then
                    oki = False
                End If
                If Not oki OrElse .Nom_Projet_KryptonTextBox1.Text.Contains(".") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("-") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains(":") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("/") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("\") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains(";") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("|") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("&") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("<") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains(">") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains("*") OrElse _
                    .Nom_Projet_KryptonTextBox1.Text.Contains(" ") OrElse _
                    Mot_Cles_Interdit.Contains(.Nom_Projet_KryptonTextBox1.Text) Then
                    .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox1, ToolTip1.GetToolTip(.Nom_Projet_KryptonTextBox1))
                    .DisableNextButton()
                Else
                    .ErrorProvider1.SetError(.Nom_Projet_KryptonTextBox1, "")
                    .EnableNextButton()
                End If
            End If
        End With
    End Sub






















    Private Sub OnFinishButton_Clicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim oki As Boolean = True
            For Each strr As String In Caractères_Interdit_Non_Numerique
                If Me.Nom_Projet_KryptonTextBox1.Text.Contains(strr) Then oki = False : Exit For
            Next
            If Not oki OrElse My.Computer.FileSystem.FileExists(Me.Nom_Projet_KryptonTextBox1.Text & ".szproj") OrElse My.Computer.FileSystem.DirectoryExists(Me.Nom_Projet_KryptonTextBox1.Text & ".szproj") Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content31"), "", Me.Nom_Projet_KryptonTextBox1.Text & ".szproj")
                    .MainInstruction = RM.GetString("MainInstruction12")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                e.Cancel = True
            Else
                ClassProjet.Creer_Nouveau_Projet(Me.Emplacement_KryptonTextBox2.Text, Me.Nom_Projet_KryptonTextBox1.Text, Me.Nom_Solution_KryptonTextBox3.Text, Me.RadioButton2.Checked, Me.ListView1.SelectedItems(0).ToolTipText, Me.Tip)
            End If
        End If
    End Sub

    Private Sub Installateur_CommandLink3_Click(sender As System.Object, e As System.EventArgs) Handles Installateur_CommandLink3.Click
        Using frm As New AdvancedInstaller
            frm.ShowDialog()
        End Using
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Me.Nom_Solution_KryptonTextBox3.Enabled = Me.RadioButton1.Checked
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
            Me.FolderBrowserDialog1.SelectedPath = My.Settings.Emplacement_Project_Par_Defaut
        Else
            Me.FolderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Emplacement_KryptonTextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class
