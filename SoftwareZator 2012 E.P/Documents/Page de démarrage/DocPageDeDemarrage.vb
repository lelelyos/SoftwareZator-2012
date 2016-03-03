''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocPageDeDemarrage

#Region "Propriétés"

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Page_Demarrage

    Public ReadOnly Property TypeFichier() As VelerSoftware.SZVB.Projet.Document.Types
        Get
            Return _TypeFichier
        End Get
    End Property

#End Region ' Type du document

#End Region

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

        Dim beta_txt As String = ""
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\isbeta") AndAlso CBool(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\isbeta")) AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\betaversion") Then
            beta_txt = " Beta " & CInt(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\betaversion"))
        End If
        Me.Label1.Text = My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition.ToString()) & ", Version " & My.Application.Info.Version.ToString & beta_txt & ", " & My.Application.Info.Copyright

        Me.KryptonListBox2.Items.Clear()
        For Each recent As String In My.Settings.Projets_Recents
            If Not recent = Nothing AndAlso recent.Contains("|") Then
                Me.KryptonListBox2.Items.Add(recent.Split("|")(0))
            End If
        Next



        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML
        Dim CommandCtrl As VelerSoftware.Design.Toolkit.KryptonButton
        Dim i2 As Integer = 0
        Dim Nom As String

        If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Samples") Then
            For Each a As String In System.IO.Directory.GetFiles(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Samples\", "*.szsl", System.IO.SearchOption.AllDirectories)
                If My.Computer.FileSystem.FileExists(a) Then
                    Nom = Nothing
                    i2 += 1

                    Try
                        XmlRead = New Xml.XmlTextReader(a)
                        If XmlRead IsNot Nothing Then
                            Do While XmlRead.Read()
                                Select Case XmlRead.NodeType
                                    Case Xml.XmlNodeType.Element
                                        Select Case XmlRead.Name
                                            Case "SZSolution" ' Solution
                                                Nom = XmlRead.GetAttribute("Name")
                                        End Select
                                End Select
                            Loop
                            XmlRead.Close()
                        End If
                    Catch
                        Nom = a
                    End Try

                    CommandCtrl = New VelerSoftware.Design.Toolkit.KryptonButton
                    With CommandCtrl
                        .Name = "CommandLink2" & i2
                        .Tag = a
                        .Text = Nom
                        .Size = New Size(Me.TableLayoutPanel2.Width, 25)
                        .Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                        .Location = New Point(0, 0)
                        AddHandler .Click, AddressOf Sample_Click
                    End With
                    Me.TableLayoutPanel2.Controls.Add(CommandCtrl)
                End If
            Next
        End If

    End Sub

    Friend Function Page_Closing() As Boolean
        Return True
    End Function

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

    Friend Sub Activate_Page()
        With Form1
            With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)
                .Vide_ToolBox.Visible = True
                .Concepteur_Fenetre_ToolBox.Visible = False
                .Fonctions_ToolBox.Visible = False
                .Classes_ToolBox.Visible = False
            End With
            With DirectCast(.Box_Proprietes.Controls(0), BoxProprietes)
                .PropertyGrids1.SelectedObjects = Nothing
                .PropertyGrids1.Item.Clear()
                .PropertyGrids1.ItemSet.Clear()
                .PropertyGrids1.ShowCustomProperties = True
                .KryptonRichTextBox1.Rtf = "{\rtf1" & RM.GetString("Document_Page_De_Demarrage") & " {\b(" & RM.GetString("Document_Page_De_Demarrage") & ")}}"
            End With
            ' Configuration du ruban
            .Enregistrer_KryptonRibbonGroupButton.Enabled = False
            .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = False

            .VbNet_KryptonRibbonGroupButton.Enabled = False
            .CSharp_KryptonRibbonGroupButton.Enabled = False

            .Imprimer_KryptonRibbonGroupButton.Enabled = False
            .Impression_Rapide_KryptonRibbonGroupButton.Enabled = False
            .Apercu_Impression_KryptonRibbonGroupButton.Enabled = False

            .Coller_KryptonRibbonGroupButton.Enabled = False
            .Copier_KryptonRibbonGroupButton.Enabled = False
            .Couper_KryptonRibbonGroupButton.Enabled = False

            .Annuler_KryptonRibbonGroupButton.Enabled = False
            .Retablir_KryptonRibbonGroupButton.Enabled = False
            .Supprimer_KryptonRibbonGroupButton.Enabled = False
            .Selectionner_tout_KryptonRibbonGroupButton.Enabled = False

            .QAT_Annuler.Enabled = False
            .QAT_Coller.Enabled = False
            .QAT_Copier.Enabled = False
            .QAT_Couper.Enabled = False
            .QAT_Enregistrer_Sous.Enabled = False
            .QAT_Retablir.Enabled = False

            .KryptonRibbon1.SelectedContext = Nothing
        End With
    End Sub





    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Form1.Nouveau_Projet_KryptonRibbonGroupButton_Click(sender, e)
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton2.Click
        Form1.Ouvrir_Projet_KryptonRibbonGroupButton_Click(sender, e)
    End Sub

    Private Sub KryptonNavigator1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonNavigator1.SelectedPageChanged
        If Me.KryptonNavigator1.SelectedPage Is Me.KryptonPage2 Then
            If Me.WebBrowser1.Url = Nothing AndAlso VelerSoftware.SZVB.Windows.Core.IsConnected() Then
                Me.WebBrowser1.Navigate("http://softwarezator.velersoftware.com/feed.php?lang=" & My.Settings.Langue)
            Else
                Me.WebBrowser1.Navigate("file:///" & Application.StartupPath & "\Help\" & My.Settings.Langue & "\NoConnect.html")
            End If
        End If
    End Sub

    Private Sub KryptonLinkLabel1_LinkClicked(sender As System.Object, e As System.EventArgs) Handles KryptonLinkLabel1.LinkClicked
        My.Settings.Projets_Recents.Clear()

        Me.KryptonListBox2.Items.Clear()
        For Each recent As String In My.Settings.Projets_Recents
            If Not recent = Nothing AndAlso recent.Contains("|") Then
                Me.KryptonListBox2.Items.Add(recent.Split("|")(0))
            End If
        Next
    End Sub

    Private Sub KryptonListBox2_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles KryptonListBox2.SelectedValueChanged
        For Each recent As String In My.Settings.Projets_Recents
            Dim fileName As String
            If Not recent = Nothing AndAlso recent.Contains("|") AndAlso recent.Split("|")(0) = Me.KryptonListBox2.SelectedItem Then
                fileName = recent.Split("|")(1)
                If My.Computer.FileSystem.FileExists(fileName) Then

                    ' FICHIER SZSL
                    If My.Computer.FileSystem.GetFileInfo(fileName).Extension.ToUpper.EndsWith(".SZSL") Then 'Si c'est un fichier SZSL (solution)
                        If Not SOLUTION Is Nothing Then ' Si une solution est déja ouverte
                            If fileName <> SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet Then ' si la solution est différente de celle ouverte
                                ' Fermer la solution
                                ClassProjet.Ouvrir_Solution(fileName)
                            End If
                        Else
                            ClassProjet.Ouvrir_Solution(fileName)
                        End If

                    End If

                Else
                    Me.KryptonListBox2.Items.Remove(Me.KryptonListBox2.SelectedItem)
                    My.Settings.Projets_Recents.Remove(recent)
                End If
                Exit For
            End If
        Next
    End Sub


    Private Sub Sample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Computer.FileSystem.FileExists(sender.Tag) AndAlso My.Computer.FileSystem.GetFileInfo(sender.Tag).Extension.ToUpper.EndsWith(".SZSL") Then 'Si c'est un fichier SZSL (solution)
            If Not SOLUTION Is Nothing Then ' Si une solution est déja ouverte
                If sender.Tag <> SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet Then ' si la solution est différente de celle ouverte
                    ' Fermer la solution
                    ClassProjet.Ouvrir_Solution(sender.Tag)
                End If
            Else
                ClassProjet.Ouvrir_Solution(sender.Tag)
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("https://www.facebook.com/pages/Veler-Software/237323213000380")
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        System.Diagnostics.Process.Start("http://twitter.com/VelerSoftware")
    End Sub
End Class
