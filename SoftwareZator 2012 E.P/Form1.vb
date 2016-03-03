Imports VelerSoftware.Design.Navigator

''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Form1

#Region "Variables"

    ' Panneaux
    Friend Box_Explorateur_Solutions As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Proprietes As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Boite_A_Outils As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Bases_Donnees As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Sortie As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Aide_Rapide As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Erreur_Generation As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Debogage As New VelerSoftware.Design.Navigator.KryptonPage
    Friend Box_Reconnaissance_Vocale As New VelerSoftware.Design.Navigator.KryptonPage

    ' Débogueur
    Friend WithEvents Débogueur As VelerSoftware.SZC.Debugger.WindowsDebugger

    ' Reconnaissance Vocale
    Friend WithEvents SRE As Speech.Recognition.SpeechRecognitionEngine

    ' Composant de génération
    Friend GenerationComponent1 As New GenerationComponent

#End Region

#Region "Log"

    Friend Sub Log_Generation_OnLogChanged(ByVal sender As ClassLog, ByVal e As System.EventArgs)
        If Not Me.GenerationComponent1.BackgroundWorker_Building.IsBusy AndAlso Status_SZ = statu.Normal AndAlso Box_Sortie.Controls.Count > 0 AndAlso DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1.SelectedIndex = 0 Then DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub Log_Projet_OnLogChanged(ByVal sender As ClassLog, ByVal e As System.EventArgs)
        If Not Me.GenerationComponent1.BackgroundWorker_Building.IsBusy AndAlso Box_Sortie.Controls.Count > 0 AndAlso DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1.SelectedIndex = 1 Then DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub Log_SZ_OnLogChanged(ByVal sender As ClassLog, ByVal e As System.EventArgs)
        If Not Me.GenerationComponent1.BackgroundWorker_Building.IsBusy AndAlso Box_Sortie.Controls.Count > 0 AndAlso DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1.SelectedIndex = 2 Then DirectCast(Box_Sortie.Controls(0), BoxSortie).ToolStripComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

#End Region

#Region "QAT"

    Friend WithEvents QAT_Ouvrir As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Enregistrer_Tout As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Fermer As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Enregistrer_Sous As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Copier As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Coller As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Couper As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Annuler As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Retablir As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton
    Friend WithEvents QAT_Generer As New VelerSoftware.Design.Ribbon.KryptonRibbonQATButton

    Private Sub AddQATS()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))

        With QAT_Ouvrir
            .Image = My.Resources.Ouvrir_Projet_16x16
            .ToolTipImage = My.Resources.Ouvrir_Projet_16x16
            .Text = resources.GetString("Ouvrir_Projet_KryptonRibbonGroupButton.TextLine1") & " " & resources.GetString("Ouvrir_Projet_KryptonRibbonGroupButton.TextLine2")
            .ToolTipTitle = resources.GetString("Ouvrir_Projet_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Ouvrir_Projet_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Ouvrir
        End With

        With QAT_Enregistrer_Sous
            .Image = My.Resources.save_as_Small
            .ToolTipImage = My.Resources.save_as_Small
            .Text = resources.GetString("Enregistrer_Sous_KryptonRibbonGroupButton.TextLine1") & " " & resources.GetString("Enregistrer_Sous_KryptonRibbonGroupButton.TextLine2")
            .ToolTipTitle = resources.GetString("Enregistrer_Sous_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Enregistrer_Sous_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Enregistrer_Sous
        End With

        With QAT_Enregistrer_Tout
            .Image = My.Resources.save_all_Small
            .ToolTipImage = My.Resources.save_all_Small
            .Text = resources.GetString("Enregistrer_Tout_KryptonRibbonGroupButton.TextLine1") & " " & resources.GetString("Enregistrer_Tout_KryptonRibbonGroupButton.TextLine2")
            .ToolTipTitle = resources.GetString("Enregistrer_Tout_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Enregistrer_Tout_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Enregistrer_Tout
        End With

        With QAT_Fermer
            .Image = My.Resources._305_Close_16x16_72
            .ToolTipImage = My.Resources._305_Close_16x16_72
            .Text = resources.GetString("Fermer_Projet_KryptonRibbonGroupButton.TextLine1") & " " & resources.GetString("Fermer_Projet_KryptonRibbonGroupButton.TextLine2")
            .ToolTipTitle = resources.GetString("Fermer_Projet_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Fermer_Projet_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Fermer
        End With

        With QAT_Copier
            .Image = My.Resources.copy_small
            .ToolTipImage = My.Resources.copy_small
            .Text = resources.GetString("Copier_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Copier_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Copier_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Copier
        End With

        With QAT_Coller
            .Image = My.Resources.paste_sma
            .ToolTipImage = My.Resources.paste_sma
            .Text = resources.GetString("Coller_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Coller_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Coller_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Coller
        End With

        With QAT_Couper
            .Image = My.Resources.cut
            .ToolTipImage = My.Resources.cut
            .Text = resources.GetString("Couper_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Couper_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Couper_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Couper
        End With

        With QAT_Annuler
            .Image = My.Resources.undo
            .ToolTipImage = My.Resources.undo
            .Text = resources.GetString("Annuler_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Annuler_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Annuler_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Annuler
        End With

        With QAT_Retablir
            .Image = My.Resources.redo
            .ToolTipImage = My.Resources.redo
            .Text = resources.GetString("Retablir_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Retablir_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Retablir_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Retablir
        End With

        With QAT_Generer
            .Image = My.Resources.Generer_Small
            .ToolTipImage = My.Resources.Generer_Small
            .Text = resources.GetString("Generer_KryptonRibbonGroupButton.TextLine1")
            .ToolTipTitle = resources.GetString("Generer_KryptonRibbonGroupButton.ToolTipTitle")
            .ToolTipBody = resources.GetString("Generer_KryptonRibbonGroupButton.ToolTipBody")
            .Visible = My.Settings.QAT_Generer
        End With

        With KryptonRibbon1.QATButtons
            .Add(QAT_Ouvrir)
            .Add(QAT_Enregistrer_Sous)
            .Add(QAT_Enregistrer_Tout)
            .Add(QAT_Fermer)
            .Add(QAT_Copier)
            .Add(QAT_Coller)
            .Add(QAT_Couper)
            .Add(QAT_Annuler)
            .Add(QAT_Retablir)
            .Add(QAT_Generer)
        End With

    End Sub

#End Region

#Region "Form"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        AddHandler Log_Generation.OnLogChanged, AddressOf Log_Generation_OnLogChanged
        AddHandler Log_SZ.OnLogChanged, AddressOf Log_SZ_OnLogChanged
        AddHandler Log_Projet.OnLogChanged, AddressOf Log_Projet_OnLogChanged

#If CONFIG = "Release" Then
        If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Loading languages...")))

        ' Initialisation des ressources
        RM = New Resources.ResourceManager("SoftwareZator.Custom", Reflection.Assembly.GetExecutingAssembly())
        RM_Log = New Resources.ResourceManager("SoftwareZator.Custom_Log", Reflection.Assembly.GetExecutingAssembly())

#If CONFIG = "Release" Then
        If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

        With Me
            .SuspendLayout()

            .GenerationComponent1.Timer1.Stop()

            ' Chargement des plugins et autre
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Plugins"))))
            .SZ_Initialisation_BackgroundWorker.RunWorkerAsync()

            ' Initialisation de la fenêtre
            .Text = My.Application.Info.CompanyName & " - " & My.Application.Info.ProductName

            .Size = New Size(My.Computer.Screen.WorkingArea.Width - 100, My.Computer.Screen.WorkingArea.Height - 100)
            .Location = New Point((My.Computer.Screen.WorkingArea.Width - Width) / 2, (My.Computer.Screen.WorkingArea.Height - Height) / 2)
            .StartPosition = Windows.Forms.FormStartPosition.CenterScreen

            .ToolStripStatusLabel3.Alignment = LeftRightAlignment.Right

            .Info_Bar1.Hide()

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

            ' Initialisation du dock
            .KryptonDockingManager1.ManageControl(KryptonPanel1, KryptonDockingManager1.ManageWorkspace(KryptonDockableWorkspace1))
            .KryptonDockingManager1.ManageFloating(Me)

            ' Initialisation du GenerationComponent1   
            With .GenerationComponent1
                .Name = "GenerationComponent1"
                .Dock = DockStyle.Fill
                .Visible = False
                Controls.Add(GenerationComponent1)
                .Solution_Windows7ProgressBar.ContainerControl = Me
                If My.Settings.Temps_Pause Then
                    .Timer1.Interval = 3000
                Else
                    .Timer1.Interval = 1000
                End If
            End With

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

            ' Ajout des panneaux
            With .KryptonDockingManager1
                .AddAutoHiddenGroup("Control", VelerSoftware.Design.Docking.DockingEdge.Bottom, New VelerSoftware.Design.Navigator.KryptonPage() {Dock_Nouveau_Sortie(), Dock_Nouveau_Aide_Rapide(), Dock_Nouveau_Erreur_Generation(), Dock_Nouveau_Debogage()})
                .AddDockspace("Control", VelerSoftware.Design.Docking.DockingEdge.Right, New VelerSoftware.Design.Navigator.KryptonPage() {Dock_Nouveau_Explorateur_Solution(), Dock_Nouveau_Propriete()})
                .AddDockspace("Control", VelerSoftware.Design.Docking.DockingEdge.Left, New VelerSoftware.Design.Navigator.KryptonPage() {Dock_Nouveau_Boite_A_Outils(), Dock_Nouveau_Reconnaissance_Vocale()})
                .AddAutoHiddenGroup("Control", VelerSoftware.Design.Docking.DockingEdge.Left, New VelerSoftware.Design.Navigator.KryptonPage() {Dock_Nouveau_Bases_Donnees()})
            End With

            Select Case My.Settings.WindowTheme
                Case 0
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Blue
                    .StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                    DirectCast(.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Blue())
                Case 1
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Silver
                    .StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                    DirectCast(.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Silver())
                Case 2
                    .KryptonManager1.GlobalPaletteMode = VelerSoftware.Design.Toolkit.PaletteModeManager.Office2010Black
                    .StatusStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Aide_Rapide.Controls(0), BoxAideRapide).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.ToolStrip.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
                    DirectCast(.Box_Sortie.Controls(0), BoxSortie).ToolStrip1.Renderer = New VelerSoftware.Design.Toolkit.RenderOffice2010().RenderToolStrip(New VelerSoftware.Design.Toolkit.PaletteOffice2010Black())
            End Select

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

            ' Chargement de l'interface
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Dock.xml") Then
                Try
                    .KryptonDockingManager1.LoadConfigFromFile(Application.StartupPath & "\Dock.xml")
                Catch
                    .KryptonDockingManager1.Clear()
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Dock.xml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End Try
            End If

            Try
                If Box_Bases_Donnees.Controls.Count > 0 AndAlso TypeOf Box_Bases_Donnees.Controls(0) Is BoxBasesDonnees AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\logins") Then
                    Dim databases As New VelerSoftware.SZVB.BasesDeDoonees.DataBases
                    Dim node As Windows.Forms.TreeNode
                    Dim myFileStream As IO.Stream = IO.File.OpenRead(Application.StartupPath & "\logins")
                    Dim deserializer As Runtime.Serialization.Formatters.Binary.BinaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    Try
                        databases = DirectCast(deserializer.Deserialize(myFileStream), VelerSoftware.SZVB.BasesDeDoonees.DataBases)
                    Catch
                        myFileStream.Close()
                    End Try
                    myFileStream.Close()

                    With DirectCast(Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1
                        For Each dat As VelerSoftware.SZVB.BasesDeDoonees.Access In databases.Access
                            node = New Windows.Forms.TreeNode
                            With node
                                .Name = "Access|" & dat.Fichier
                                .Text = My.Computer.FileSystem.GetName(dat.Fichier).Replace(My.Computer.FileSystem.GetFileInfo(dat.Fichier).Extension, Nothing)
                                .ToolTipText = dat.Fichier
                                .Tag = dat
                                .Nodes.Add("factise")
                                .ImageIndex = 4
                                .SelectedImageIndex = 4
                            End With
                            .Nodes("Access").Nodes.Add(node)
                        Next

                        For Each dat As VelerSoftware.SZVB.BasesDeDoonees.SQLServer In databases.SQLServer
                            node = New Windows.Forms.TreeNode
                            With node
                                .Name = "SQLServer|" & dat.Base_de_données_initial
                                .Text = dat.Base_de_données_initial
                                .ToolTipText = dat.Base_de_données_initial
                                .Tag = dat
                                .Nodes.Add("factise")
                                .ImageIndex = 4
                                .SelectedImageIndex = 4
                            End With
                            .Nodes("SQL Server").Nodes.Add(node)
                        Next

                        For Each dat As VelerSoftware.SZVB.BasesDeDoonees.MySQL In databases.MySQL
                            node = New Windows.Forms.TreeNode
                            With node
                                .Name = "MySQL|" & dat.Base_de_données_initial
                                .Text = dat.Base_de_données_initial
                                .ToolTipText = dat.Base_de_données_initial
                                .Tag = dat
                                .Nodes.Add("factise")
                                .ImageIndex = 4
                                .SelectedImageIndex = 4
                            End With
                            .Nodes("MySQL").Nodes.Add(node)
                        Next

                        .Nodes("Access").Expand()
                        .Nodes("SQL Server").Expand()
                        .Nodes("MySQL").Expand()
                    End With
                End If
            Catch
            End Try


            ' Configuration du ruban
            .AddQATS()

            .Exporter_Projet_KryptonRibbonGroupButton.Visible = True

            .Enregistrer_Projet_KryptonRibbonGroupButton.Enabled = False
            .Exporter_Projet_KryptonRibbonGroupButton.Enabled = False
            .Fermer_Projet_KryptonRibbonGroupButton.Enabled = False

            .Enregistrer_KryptonRibbonGroupButton.Enabled = False
            .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = False
            .Enregistrer_Tout_KryptonRibbonGroupButton.Enabled = False

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


#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If


            .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = False
            .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = False
            .Statistiques_KryptonRibbonGroupButton.Enabled = False
            .Ordre_Generation_KryptonRibbonGroupButton.Enabled = False
            .Ajouter_Projet_KryptonRibbonGroupButton.Enabled = False
            .Nouveau_Document_KryptonRibbonGroupButton.Enabled = False
            .Generer_KryptonRibbonGroupButton.Enabled = False
            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
            .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = False
            .Demarrer_Le_Debogage_KryptonRibbonGroupButton1.Enabled = False
            .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = False
            .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
            .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = False
            .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

            .KryptonRibbon1.SelectedContext = Nothing
            .KryptonRibbon1.SelectedTab = Accueil_KryptonRibbonTab
            .QAT_Annuler.Enabled = False
            .QAT_Coller.Enabled = False
            .QAT_Copier.Enabled = False
            .QAT_Couper.Enabled = False
            .QAT_Enregistrer_Sous.Enabled = False
            .QAT_Enregistrer_Tout.Enabled = False
            .QAT_Fermer.Enabled = False
            .QAT_Retablir.Enabled = False
            .QAT_Generer.Enabled = False

            If VelerSoftware.SZVB.Windows.Core.RunningOnXP Then
                .Reconnaissance_Vocal_KryptonRibbonGroupButton.Enabled = False
                .Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Enabled = False
            End If

            .Activer_Licence_SZ_KryptonRibbonGroupButton.Enabled = True
            If My.Settings.Edition = ClassApplication.Edition.Free Then .Activer_Licence_SZ_KryptonRibbonGroupButton.Enabled = False

            If .Box_Explorateur_Solutions.Controls.Count > 0 Then
                With DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions)
                    .Actualiser_ToolStripButton.Enabled = False
                    .Nouveau_Dossier_ToolStripButton.Enabled = False
                    .Nouveau_Fichier_ToolStripButton.Enabled = False
                    .Proprietes_ToolStripButton.Enabled = False
                    .Reduire_Projet_ToolStripButton.Enabled = False
                    .TreeViewMultiSelect1.Enabled = False
                End With
            End If

            With DirectCast(.Generer_KryptonContextMenu.Items(0), VelerSoftware.Design.Toolkit.KryptonContextMenuItems)
                AddHandler DirectCast(.Items(0), VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Click, AddressOf Generer_Solution_KryptonContextMenu_Menu_Click
                AddHandler DirectCast(.Items(1), VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Click, AddressOf Generer_Solution_Obfuscation_KryptonContextMenu_Menu_Click
            End With

            ' Ajout de la page de démarrage
            If My.Settings.Ouvrir_Page_De_Démarrage Then
                Try : .KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Workspace_Nouveau_Page_De_Demarrage()}) : Catch : End Try
            End If

            .StatusStrip1.Visible = My.Settings.Barre_Etat
            .KryptonRibbon1.MinimizedMode = My.Settings.Minimiser_Ruban
            .KryptonRibbon1.AllowFormIntegrate = My.Settings.Activer_Aero
            If My.Settings.Barre_Acces_Rapide_Dessous Then
                .KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Below
            Else
                .KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Above
            End If
            If Not My.Settings.FormSize.Height = 0 Then
                .Size = My.Settings.FormSize
                .Location = My.Settings.FormLocation
            End If
            .WindowState = My.Settings.FormState


            .ResumeLayout(False)

            With DirectCast(Ajouter_Projet_KryptonContextMenu.Items(0), VelerSoftware.Design.Toolkit.KryptonContextMenuItems)
                AddHandler DirectCast(.Items(0), VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Click, AddressOf Ajouter_Nouveau_Projet_KryptonRibbonGroupButton_Click
                AddHandler DirectCast(.Items(1), VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Click, AddressOf Ajouter_Projet_Existant_KryptonRibbonGroupButton_Click
            End With

#If CONFIG = "Release" Then
            Global.SoftwareZator.SplashScreen1.Close()
#End If

            If DateTime.Today.DayOfYear = 1 Then .Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Good, String.Format(Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_6_Description"), My.Application.Info.Title, DateTime.Today.Year), Nothing, False, "Happy_New_Year", Nothing)

            ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

            ' Ouvrir le projet donnée
            If My.Computer.FileSystem.FileExists(ArgumentOuverture) Then
                If My.Computer.FileSystem.GetFileInfo(ArgumentOuverture).Extension.ToLower = ".szstat" Then
                    If My.Settings.Edition = ClassApplication.Edition.Free Then
                        ClassApplication.Should_Standard_Edition()
                        Exit Sub
                    End If

                    If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(.OpenFileDialog1.FileName) Then
                        Dim doc As VelerSoftware.Design.Navigator.KryptonPage = .Workspace_Nouveau_Statistiques_Fichier(.OpenFileDialog1.FileName)
                        If Not doc Is Nothing Then .KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                    End If
                    If ClassApplication.Determiner_Si_Document_Deja_Ouvert(.OpenFileDialog1.FileName) Then
                        Dim pag As VelerSoftware.Design.Navigator.KryptonPage = .KryptonDockableWorkspace1.PageForUniqueName(.OpenFileDialog1.FileName)
                        If Not pag Is Nothing Then
                            Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = .KryptonDockableWorkspace1.CellForPage(pag)
                            .KryptonDockableWorkspace1.ActiveCell = cell
                            cell.SelectedPage = pag
                        End If
                    End If
                Else
                    ClassProjet.Ouvrir_Solution(ArgumentOuverture)
                End If
            End If

        End With

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)

    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Me.SZ_Activation_BackgroundWorker.RunWorkerAsync()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If GenerationComponent1.Visible Then e.Cancel = True

        If Status_SZ = statu.Debuggage_En_Cours Then
            If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content39"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                Débogueur.Stop()
            End If
        End If

        If SZ_Initialisation_BackgroundWorker.IsBusy Then SZ_Initialisation_BackgroundWorker.CancelAsync()

        If Not e.Cancel Then
            ' Enregistrer la solution
            If Not SOLUTION Is Nothing Then ClassProjet.Enregistrer_Solution(True)

            For Each pag As KryptonPage In From pag1 In KryptonDockingManager1.Pages Where pag1.Controls.Count > 0
                If TypeOf pag.Controls(0) Is DocPageDeDemarrage Then
                    If DirectCast(pag.Controls(0), DocPageDeDemarrage).Page_Closing() Then
                        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Page_Demarrage"))))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocConcepteurFenetre Then
                    If DirectCast(pag.Controls(0), DocConcepteurFenetre).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocConcepteurFenetre).NomFichier)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions Then
                    If DirectCast(pag.Controls(0), DocEditeurFonctions).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocEditeurFonctions).NomFichier)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocParametresDuProjet Then
                    If DirectCast(pag.Controls(0), DocParametresDuProjet).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocParametresDuProjet).Nom_Projet)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocStatistiques Then
                    If DirectCast(pag.Controls(0), DocStatistiques).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocStatistiques).Nom_Projet)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocEditeurVisualBasic Then
                    If DirectCast(pag.Controls(0), DocEditeurVisualBasic).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocEditeurVisualBasic).Nom_Projet)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                ElseIf TypeOf pag.Controls(0) Is DocEditeurTable Then
                    If DirectCast(pag.Controls(0), DocEditeurTable).Page_Closing() Then
                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(pag.Controls(0), DocEditeurTable).NomTable)))
                        KryptonDockingManager1.RemovePage(pag, True)
                    Else
                        e.Cancel = True
                        Exit For
                    End If
                End If
            Next

            ' Enregistrement de l'interface
            KryptonDockingManager1.SaveConfigToFile(Application.StartupPath & "\Dock.xml", System.Text.Encoding.UTF8)

            If Box_Bases_Donnees.Controls.Count > 0 AndAlso TypeOf Box_Bases_Donnees.Controls(0) Is BoxBasesDonnees Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\logins") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\logins", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                If Not (DirectCast(Me.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("Access").Nodes.Count = 0 AndAlso DirectCast(Me.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("SQL Server").Nodes.Count = 0 AndAlso DirectCast(Me.Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("MySQL").Nodes.Count = 0) Then
                    Dim databases As New VelerSoftware.SZVB.BasesDeDoonees.DataBases()
                    For Each node As TreeNode In From node1 As TreeNode In DirectCast(Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("Access").Nodes Where TypeOf node1.Tag Is VelerSoftware.SZVB.BasesDeDoonees.Access
                        databases.Access.Add(node.Tag)
                    Next
                    For Each node As TreeNode In From node1 As TreeNode In DirectCast(Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("SQL Server").Nodes Where TypeOf node1.Tag Is VelerSoftware.SZVB.BasesDeDoonees.SQLServer
                        databases.SQLServer.Add(node.Tag)
                    Next
                    For Each node As TreeNode In From node1 As TreeNode In DirectCast(Box_Bases_Donnees.Controls(0), BoxBasesDonnees).TreeViewMultiSelect1.Nodes("MySQL").Nodes Where TypeOf node1.Tag Is VelerSoftware.SZVB.BasesDeDoonees.MySQL
                        databases.MySQL.Add(node.Tag)
                    Next
                    Dim myFileStream As IO.Stream = IO.File.Create(Application.StartupPath & "\logins")
                    Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    serializer.Serialize(myFileStream, databases)
                    myFileStream.Close()
                End If
            End If

            With My.Settings
                If WindowState = FormWindowState.Normal Then
                    .FormSize = Me.Size
                    .FormLocation = Me.Location
                    .FormState = Me.WindowState
                Else
                    .FormState = Me.WindowState
                End If

                .QAT_Annuler = Me.QAT_Annuler.Visible
                .QAT_Retablir = Me.QAT_Retablir.Visible
                .QAT_Ouvrir = Me.QAT_Ouvrir.Visible
                .QAT_Fermer = Me.QAT_Fermer.Visible
                .QAT_Enregistrer_Sous = Me.QAT_Enregistrer_Sous.Visible
                .QAT_Enregistrer_Tout = Me.QAT_Enregistrer_Tout.Visible
                .QAT_Copier = Me.QAT_Copier.Visible
                .QAT_Coller = Me.QAT_Coller.Visible
                .QAT_Couper = Me.QAT_Couper.Visible
                .QAT_Generer = Me.QAT_Generer.Visible
                If Me.KryptonRibbon1.QATLocation = VelerSoftware.Design.Ribbon.QATLocation.Below Then
                    .Barre_Acces_Rapide_Dessous = True
                Else
                    .Barre_Acces_Rapide_Dessous = False
                End If
                .Minimiser_Ruban = Me.KryptonRibbon1.MinimizedMode
            End With


        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If Not Me.Compiler_UserControl1.Visible Then
        If e.Control And e.KeyCode.ToString = "O" Then
            ' Ouvrir projet
            If Ouvrir_Projet_KryptonRibbonGroupButton.Enabled Then Ouvrir_Projet_KryptonRibbonGroupButton_Click(Nothing, Nothing)
            Exit Sub
        ElseIf e.Control And e.KeyCode.ToString = "V" Then
            ' Coller
            'If Me.Coller_KryptonRibbonGroupButton.Enabled Then
            ' Coller_KryptonRibbonGroupButton_Click(Nothing, Nothing)
            'End If
            'Exit Sub
        ElseIf e.KeyCode = Keys.F1 Then
            ' Aide
            If ButtonSpecAny1.Enabled Then Aide_KryptonRibbonGroupButton2_Click(Nothing, Nothing)
            Exit Sub
        End If
        'End If
    End Sub

    Private Sub Info_Bar1_OnButtonClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Info_Bar1.OnButtonClick
        If Info_Bar1.Tag = "Bibliotheques_Necessaire_Au_Projet_Ont_Ete_Supprimer" Then
            Using frm As New InfoBarBibliothequesNecessaireAuProjetOntEteSupprimer
                frm.ShowDialog()
                frm.Dispose()
            End Using
        ElseIf Info_Bar1.Tag = "Formulaire_De_Demarrage_Introuvable" Then
            Using frm As New InfoBarFormulaireDeDemarrageIntrouvable
                frm.ShowDialog()
                frm.Dispose()
            End Using
        ElseIf Info_Bar1.Tag = "Ecran_De_Demarrage_Introuvable" Then
            Using frm As New InfoBarEcranDeDemarrageIntrouvable
                frm.ShowDialog()
                frm.Dispose()
            End Using
        ElseIf Info_Bar1.Tag = "Bibliothèque_Fonctions_Réutilisables_Dans_Projet_Pas_Pu_Etre_Chargées" Then
            Using frm As New InfoBarBibliothèqueFonctionsRéutilisablesDansProjetPasPuEtreChargées
                frm.ShowDialog()
                frm.Dispose()
            End Using
            Info_Bar1.Hide()
        ElseIf Info_Bar1.Tag = "Erreur_Chargement_Editeur_Fonctions" Then
            Dim files() As String = New String(-1) {}
            Dim Safefiles() As String = New String(-1) {}
            Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
            ReDim Preserve files(files.Length)
            ReDim Preserve Safefiles(Safefiles.Length)
            ReDim Preserve projects(projects.Length)
            files(files.Length - 1) = "PARAMETREDUPROJET"
            Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
            projects(projects.Length - 1) = DirectCast(Me.Info_Bar1.Objects, VelerSoftware.SZVB.Projet.Projet)
            ClassProjet.Ouvrir_Document(files, Safefiles, projects)
            Info_Bar1.Hide()
        ElseIf Info_Bar1.Tag = "Erreur_Generation_Projet" Then
            DirectCast(Box_Erreur_Generation.Controls(0), BoxErreurGeneration).CorrigerTouteLesErreursToolStripMenuItem_Click(Nothing, Nothing)
            Info_Bar1.Hide()
        ElseIf Info_Bar1.Tag = "Read_Only" Then
        ElseIf Info_Bar1.Tag = "Happy_New_Year" Then
        End If
    End Sub

#End Region

#Region "Dock"

    Private Sub KryptonDockingManager1_DockspaceAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockspaceEventArgs) Handles KryptonDockingManager1.DockspaceAdding
        e.DockspaceControl.Size = New Size(250, 250)
    End Sub

    Private Sub KryptonDockingManager1_FloatingWindowAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.FloatingWindowEventArgs) Handles KryptonDockingManager1.FloatingWindowAdding
        e.FloatingWindow.ClientSize = New Size(400, 400)
    End Sub

    Private Sub KryptonDockingManager1_DockspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockspaceCellEventArgs) Handles KryptonDockingManager1.DockspaceCellAdding
        e.CellControl.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.HeaderBarCheckButtonGroup
    End Sub

    Private Sub KryptonDockingManager1_FloatspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.FloatspaceCellEventArgs) Handles KryptonDockingManager1.FloatspaceCellAdding
        e.CellControl.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.HeaderBarCheckButtonGroup
    End Sub

    Private Sub KryptonDockableWorkspace1_WorkspaceCellAdding(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Workspace.WorkspaceCellEventArgs) Handles KryptonDockableWorkspace1.WorkspaceCellAdding
        e.Cell.Button.CloseButtonAction = VelerSoftware.Design.Navigator.CloseButtonAction.None
    End Sub





    Private Sub KryptonDockingManager1_GlobalSaving(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockGlobalSavingEventArgs) Handles KryptonDockingManager1.GlobalSaving
        ' Example code showing how to save extra data into the global config
        'e.XmlWriter.WriteStartElement("CustomGlobalData")
        'e.XmlWriter.WriteAttributeString("SavedTime", DateTime.Now.ToString())
        'e.XmlWriter.WriteEndElement()
    End Sub

    Private Sub KryptonDockingManager1_GlobalLoading(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.DockGlobalLoadingEventArgs) Handles KryptonDockingManager1.GlobalLoading
        ' Example code showing how to reload the extra data that was saved into the global config
        'e.XmlReader.Read()
        'MsgBox("GlobalConfig was saved at {0}", e.XmlReader.GetAttribute("SavedTime"))
        'e.XmlReader.Read()
    End Sub





    Private Sub KryptonDockableWorkspace1_ActivePageChanged(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Workspace.ActivePageChangedEventArgs) Handles KryptonDockableWorkspace1.ActivePageChanged
        If Not e.NewPage Is Nothing Then
            If TypeOf e.NewPage.Controls(0) Is DocPageDeDemarrage Then
                DirectCast(e.NewPage.Controls(0), DocPageDeDemarrage).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(e.NewPage.Controls(0), DocConcepteurFenetre).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(e.NewPage.Controls(0), DocEditeurFonctions).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocParametresDuProjet Then
                DirectCast(e.NewPage.Controls(0), DocParametresDuProjet).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocStatistiques Then
                DirectCast(e.NewPage.Controls(0), DocStatistiques).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(e.NewPage.Controls(0), DocEditeurVisualBasic).Activate_Page()
            ElseIf TypeOf e.NewPage.Controls(0) Is DocEditeurTable Then
                DirectCast(e.NewPage.Controls(0), DocEditeurTable).Activate_Page()
            End If
        End If
    End Sub

    Private Sub KryptonDockableWorkspace1_PageCloseClicked(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Docking.UniqueNameEventArgs) Handles KryptonDockableWorkspace1.PageCloseClicked
        With Me.KryptonDockableWorkspace1

            If Not e.UniqueName = Nothing Then
                If ClassApplication.Determiner_Si_Document_Deja_Ouvert(e.UniqueName) Then
                    If .PageForUniqueName(e.UniqueName).Controls.Count > 0 Then
                        If TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocPageDeDemarrage Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocPageDeDemarrage).Page_Closing() Then
                                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Page_Demarrage"))))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocConcepteurFenetre Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocConcepteurFenetre).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocConcepteurFenetre).NomFichier)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocEditeurFonctions Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurFonctions).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurFonctions).NomFichier)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocParametresDuProjet Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocParametresDuProjet).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocParametresDuProjet).Nom_Projet)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocStatistiques Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocStatistiques).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocStatistiques).Nom_Projet)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocEditeurVisualBasic Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurVisualBasic).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurVisualBasic).Nom_Projet)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        ElseIf TypeOf .PageForUniqueName(e.UniqueName).Controls(0) Is DocEditeurTable Then
                            If DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurTable).Page_Closing() Then
                                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Fermeture_Document"), DirectCast(.PageForUniqueName(e.UniqueName).Controls(0), DocEditeurTable).NomBaseDeDonnees)))
                                Me.KryptonDockingManager1.RemovePage(.PageForUniqueName(e.UniqueName), True)
                            End If
                        End If
                    End If
                End If
            End If

        End With

        If Me.KryptonDockableWorkspace1.AllPages.Length = 0 Then
            With Me
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
                    .KryptonRichTextBox1.Rtf = "{\rtf1}}"
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
        End If

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub



#Region "Nouveau Panneau Propriétés"

    Private Function Dock_Nouveau_Propriete() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Propriété"))))

        Box_Proprietes = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Proprietes
            .Text = RM.GetString("Dock_Proprietes")
            .TextTitle = RM.GetString("Dock_Proprietes")
            .TextDescription = RM.GetString("Dock_Proprietes_Description")
            .UniqueName = "Propriétés"
            .ImageSmall = My.Resources.Propriété

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxProprietes
        content.Dock = DockStyle.Fill
        Box_Proprietes.Controls.Add(content)

        DirectCast(Box_Proprietes.Controls(0), BoxProprietes).CreateControl()

        Return Box_Proprietes
    End Function

#End Region

#Region "Nouveau Panneau Explorateur de Solutions"

    Private Function Dock_Nouveau_Explorateur_Solution() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Explorateur"))))

        Box_Explorateur_Solutions = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Explorateur_Solutions
            .Text = RM.GetString("Dock_Explorateur_Solution")
            .TextTitle = RM.GetString("Dock_Explorateur_Solution")
            .TextDescription = RM.GetString("Dock_Explorateur_Solution_Description")
            .UniqueName = "Explorateur de solution"
            .ImageSmall = My.Resources.Explorateur_de_solutions

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxExplorateurSolutions
        content.Dock = DockStyle.Fill
        Box_Explorateur_Solutions.Controls.Add(content)

        DirectCast(Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).CreateControl()

        Return Box_Explorateur_Solutions
    End Function

#End Region

#Region "Nouveau Panneau Boîte à outils"

    Private Function Dock_Nouveau_Boite_A_Outils() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Toolbox"))))

        Box_Boite_A_Outils = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Boite_A_Outils
            .Text = RM.GetString("Dock_Boite_A_Outils")
            .TextTitle = RM.GetString("Dock_Boite_A_Outils")
            .TextDescription = RM.GetString("Dock_Boite_A_Outils_Description")
            .UniqueName = "Boîte à outils"
            .ImageSmall = My.Resources.Boite_a_outils

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxBoiteAOutils
        content.Dock = DockStyle.Fill
        Box_Boite_A_Outils.Controls.Add(content)

        DirectCast(Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).CreateControl()

        Return Box_Boite_A_Outils
    End Function

#End Region

#Region "Nouveau Panneau Bases de données"

    Private Function Dock_Nouveau_Bases_Donnees() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_DataBase"))))

        Box_Bases_Donnees = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Bases_Donnees
            .Text = RM.GetString("Dock_Bases_Donnees")
            .TextTitle = RM.GetString("Dock_Bases_Donnees")
            .TextDescription = RM.GetString("Dock_Bases_Donnees_Description")
            .UniqueName = "Bases de données"
            .ImageSmall = My.Resources.bases_de_donnees

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxBasesDonnees
        content.Dock = DockStyle.Fill
        Box_Bases_Donnees.Controls.Add(content)

        If Box_Bases_Donnees.Controls.Count > 0 Then DirectCast(Box_Bases_Donnees.Controls(0), BoxBasesDonnees).CreateControl()

        Return Box_Bases_Donnees
    End Function

#End Region

#Region "Nouveau Panneau Sortie"

    Private Function Dock_Nouveau_Sortie() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Sortie"))))

        Box_Sortie = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Sortie
            .Text = RM.GetString("Dock_Sortie")
            .TextTitle = RM.GetString("Dock_Sortie")
            .TextDescription = RM.GetString("Dock_Sortie_Description")
            .UniqueName = "Sortie"
            .ImageSmall = My.Resources.sortie

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxSortie
        content.Dock = DockStyle.Fill
        Box_Sortie.Controls.Add(content)

        DirectCast(Box_Sortie.Controls(0), BoxSortie).CreateControl()

        Return Box_Sortie
    End Function

#End Region

#Region "Nouveau Panneau Aide Rapide"

    Private Function Dock_Nouveau_Aide_Rapide() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Help"))))

        Box_Aide_Rapide = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Aide_Rapide
            .Text = RM.GetString("Dock_Aide_Rapide")
            .TextTitle = RM.GetString("Dock_Aide_Rapide")
            .TextDescription = RM.GetString("Dock_Aide_Rapide_Description")
            .UniqueName = "Aide rapide"
            .ImageSmall = My.Resources.help

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxAideRapide
        content.Dock = DockStyle.Fill
        Box_Aide_Rapide.Controls.Add(content)

        DirectCast(Box_Aide_Rapide.Controls(0), BoxAideRapide).CreateControl()

        Return Box_Aide_Rapide
    End Function

#End Region

#Region "Nouveau Panneau Erreurs de génération"

    Private Function Dock_Nouveau_Erreur_Generation() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Erreurs"))))

        Box_Erreur_Generation = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Erreur_Generation
            .Text = RM.GetString("Dock_Erreur_Generation")
            .TextTitle = RM.GetString("Dock_Erreur_Generation")
            .TextDescription = RM.GetString("Dock_Erreur_Generation_Description")
            .UniqueName = "Erreurs de génération"
            .ImageSmall = My.Resources._Error

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxErreurGeneration
        content.Dock = DockStyle.Fill
        Box_Erreur_Generation.Controls.Add(content)

        DirectCast(Box_Erreur_Generation.Controls(0), BoxErreurGeneration).CreateControl()

        Return Box_Erreur_Generation
    End Function

#End Region

#Region "Nouveau Panneau Débogage"

    Private Function Dock_Nouveau_Debogage() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Debogage"))))

        Box_Debogage = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Debogage
            .Text = RM.GetString("Dock_Debogage")
            .TextTitle = RM.GetString("Dock_Debogage")
            .TextDescription = RM.GetString("Dock_Debogage_Description")
            .UniqueName = "Débogage"
            .ImageSmall = My.Resources.breakpoint_16

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxDebogage
        content.Dock = DockStyle.Fill
        Box_Debogage.Controls.Add(content)

        DirectCast(Box_Debogage.Controls(0), BoxDebogage).CreateControl()

        Return Box_Debogage
    End Function

#End Region

#Region "Nouveau Panneau Reconnaissance Vocale"

    Private Function Dock_Nouveau_Reconnaissance_Vocale() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Panneau_Vocal"))))

        Box_Reconnaissance_Vocale = New VelerSoftware.Design.Navigator.KryptonPage()
        With Box_Reconnaissance_Vocale
            .Text = RM.GetString("Dock_Reconnaissance_Vocale")
            .TextTitle = RM.GetString("Dock_Reconnaissance_Vocale")
            .TextDescription = RM.GetString("Dock_Reconnaissance_Vocale_Description")
            .UniqueName = "Reconnaissance vocale"
            .ImageSmall = My.Resources.Vocale

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowConfigSave)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowAutoHidden)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDocked)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowDropDown)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowFloating)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowNavigator)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.PageInOverflowBarForOutlookMode)
        End With

        Dim content As New BoxReconnaissanceVocale
        content.Dock = DockStyle.Fill
        Box_Reconnaissance_Vocale.Controls.Add(content)

        DirectCast(Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale).CreateControl()

        Return Box_Reconnaissance_Vocale
    End Function

#End Region




#Region "Nouveau Document Page De Démarrage"

    Private Function Workspace_Nouveau_Page_De_Demarrage() As VelerSoftware.Design.Navigator.KryptonPage
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Page_Demarrage"))))

        Dim Document_Page_De_Demarrage = New VelerSoftware.Design.Navigator.KryptonPage()
        With Document_Page_De_Demarrage
            .Text = RM.GetString("Document_Page_De_Demarrage")
            .TextTitle = RM.GetString("Document_Page_De_Demarrage")
            .TextDescription = RM.GetString("Document_Page_De_Demarrage")
            .UniqueName = "Page de démarrage"
            .ImageSmall = My.Resources.page_de_demarrage
            .ToolTipBody = RM.GetString("Document_Page_De_Demarrage")
            .ToolTipTitle = RM.GetString("Document_Page_De_Demarrage")
            .ToolTipImage = My.Resources.page_de_demarrage

            .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
            .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)
        End With

        Dim content As New DocPageDeDemarrage
        content.Dock = DockStyle.Fill
        Document_Page_De_Demarrage.Controls.Add(content)

        Return Document_Page_De_Demarrage
    End Function

#End Region

#Region "Nouveau Document Paramètres Du Projet"

    Friend Function Workspace_Nouveau_Paramètres_Du_Projet(ByVal proj As VelerSoftware.SZVB.Projet.Projet) As VelerSoftware.Design.Navigator.KryptonPage
        If Not proj Is Nothing Then
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Parametre"), proj.Nom)))
            Dim Document_Paramètres_Du_Projet = New VelerSoftware.Design.Navigator.KryptonPage()
            With Document_Paramètres_Du_Projet
                .Text = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextTitle = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextDescription = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .UniqueName = "Paramètres du projet " & proj.Nom
                .ImageSmall = My.Resources.parametre
                .ToolTipBody = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipTitle = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipImage = My.Resources.parametre

                .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)
            End With

            Dim resultat As Boolean

            Dim content As New DocParametresDuProjet
            content.Dock = DockStyle.Fill

            content.Nom_Projet = proj.Nom
            resultat = content.Charger()

            If resultat Then
                Document_Paramètres_Du_Projet.Controls.Add(content)
                Return Document_Paramètres_Du_Projet
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Concepteur De Fenêtre"

    Friend Function Workspace_Nouveau_Concepteur_Fenetre(ByVal file_name As String, ByVal proj As VelerSoftware.SZVB.Projet.Projet, Optional ByVal Nom_A_Donner As String = Nothing) As VelerSoftware.Design.Navigator.KryptonPage
        If Not proj Is Nothing Then
            If My.Computer.FileSystem.FileExists(file_name) Then
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Document"), file_name)))

                Dim resultat As Boolean

                Dim content As New DocConcepteurFenetre
                content.Dock = DockStyle.Fill
                content.Nom_Projet = proj.Nom
                content.NomFichier = My.Computer.FileSystem.GetName(file_name)
                content.NomCompletFichier = file_name
                resultat = content.Charger(Nom_A_Donner)

                If resultat Then
                    Dim Document_Concepteur_Fenetre = New VelerSoftware.Design.Navigator.KryptonPage()
                    With Document_Concepteur_Fenetre
                        .Text = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextDescription = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .UniqueName = file_name
                        .ImageSmall = My.Resources.Fichier_Fenetre
                        .ToolTipBody = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipImage = My.Resources.Fichier_Fenetre

                        .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

                        .Controls.Add(content)
                    End With
                    Return Document_Concepteur_Fenetre
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Editeur De Fonctions"

    Friend Function Workspace_Nouveau_Editeur_Fonctions(ByVal file_name As String, ByVal proj As VelerSoftware.SZVB.Projet.Projet, Optional ByVal Nom_A_Donner As String = Nothing) As VelerSoftware.Design.Navigator.KryptonPage
        If Not proj Is Nothing Then
            If My.Computer.FileSystem.FileExists(file_name) Then
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Document"), file_name)))

                Dim resultat As Boolean

                Dim content As New DocEditeurFonctions
                content.Dock = DockStyle.Fill
                content.Nom_Projet = proj.Nom
                content.NomFichier = My.Computer.FileSystem.GetName(file_name)
                content.NomCompletFichier = file_name
                resultat = content.Charger(Nom_A_Donner)

                If resultat Then
                    Dim Document_Editeur_Fonction = New VelerSoftware.Design.Navigator.KryptonPage()
                    With Document_Editeur_Fonction
                        .Text = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextDescription = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .UniqueName = file_name
                        .ImageSmall = My.Resources.Fichier_Code
                        .ToolTipBody = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipImage = My.Resources.Fichier_Code

                        .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

                        Document_Editeur_Fonction.Controls.Add(content)
                    End With
                    Return Document_Editeur_Fonction
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Editeur de code VB.Net"

    Friend Function Workspace_Nouveau_Editeur_Visual_Basic(ByVal file_name As String, ByVal proj As VelerSoftware.SZVB.Projet.Projet) As VelerSoftware.Design.Navigator.KryptonPage
        If Not proj Is Nothing Then
            If My.Computer.FileSystem.FileExists(file_name) Then
                Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Document"), file_name)))

                Dim resultat As Boolean

                Dim content As New DocEditeurVisualBasic
                content.Dock = DockStyle.Fill
                content.Nom_Projet = proj.Nom
                content.NomFichier = My.Computer.FileSystem.GetName(file_name)
                content.NomCompletFichier = file_name
                resultat = content.Charger(My.Computer.FileSystem.ReadAllText(file_name, System.Text.Encoding.Default))

                If resultat Then
                    Dim Document_Editeur_VB = New VelerSoftware.Design.Navigator.KryptonPage()
                    With Document_Editeur_VB
                        .Text = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .TextDescription = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .UniqueName = file_name
                        .ImageSmall = My.Resources.VB_File
                        .ToolTipBody = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                        .ToolTipImage = My.Resources.VB_File

                        .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                        .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

                        .Controls.Add(content)
                    End With
                    Return Document_Editeur_VB
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Statistiques Du Projet"

    Friend Function Workspace_Nouveau_Statistiques_Du_Projet(ByVal proj As VelerSoftware.SZVB.Projet.Projet) As VelerSoftware.Design.Navigator.KryptonPage
        If Not proj Is Nothing Then
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Stat"), proj.Nom)))
            Dim Document_Statistiques_Du_Projet = New VelerSoftware.Design.Navigator.KryptonPage()
            With Document_Statistiques_Du_Projet
                .Text = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextTitle = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextDescription = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .UniqueName = "Statistiques du projet " & proj.Nom
                .ImageSmall = My.Resources.Chart_Small
                .ToolTipBody = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipTitle = proj.Nom ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipImage = My.Resources.Chart_Small

                .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)
            End With

            Dim resultat As Boolean

            Dim content As New DocStatistiques
            content.Dock = DockStyle.Fill

            content.Nom_Projet = proj.Nom
            resultat = content.Charger(False)

            If resultat Then
                Document_Statistiques_Du_Projet.Controls.Add(content)
                Return Document_Statistiques_Du_Projet
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Statistiques Fichier"

    Friend Function Workspace_Nouveau_Statistiques_Fichier(ByVal file_name As String) As VelerSoftware.Design.Navigator.KryptonPage
        If My.Computer.FileSystem.FileExists(file_name) Then
            Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Document"), file_name)))

            Dim resultat As Boolean

            Dim content As New DocStatistiques
            content.Dock = DockStyle.Fill
            content.Nom_Projet = file_name
            resultat = content.Charger(file_name)

            If resultat Then
                Dim Document_Statistiques_Fichier = New VelerSoftware.Design.Navigator.KryptonPage()
                With Document_Statistiques_Fichier
                    .Text = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                    .TextTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                    .TextDescription = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                    .UniqueName = file_name
                    .ImageSmall = My.Resources.Fichier_Statistiques
                    .ToolTipBody = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                    .ToolTipTitle = My.Computer.FileSystem.GetName(file_name) ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                    .ToolTipImage = My.Resources.Fichier_Statistiques

                    .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                    .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                    .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                    .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

                    .Controls.Add(content)
                End With
                Return Document_Statistiques_Fichier
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Nouveau Document Editeur De Table"

    Friend Function Workspace_Nouveau_Editeur_De_Table(ByVal Dat As DataTable, ByVal DataBaseFileOrHost As String, ByVal Password As String, ByVal DataBaseName As String, ByVal Table_Name As String, ByVal DataBaseType As String, ByVal locale As Boolean, ByVal user As String, ByVal port As String) As VelerSoftware.Design.Navigator.KryptonPage
        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Ouverture_Document"), DataBaseName & "." & Table_Name)))

        Dim resultat As Boolean

        Dim content As New DocEditeurTable
        content.Dock = DockStyle.Fill
        content.HostOuFichierDeBaseDeDonnees = DataBaseFileOrHost
        content.NomBaseDeDonnees = DataBaseName
        content.NomTable = Table_Name
        content.MotDePasse = Password
        content.Utilisateur = user
        content.Port = port
        content.Locale = locale
        Select Case DataBaseType
            Case "Access"
                content.TypeBaseDeDonnees = DocEditeurTable.DataBaseType.Access
            Case "MySQL"
                content.TypeBaseDeDonnees = DocEditeurTable.DataBaseType.MySql
            Case "SQLServer"
                content.TypeBaseDeDonnees = DocEditeurTable.DataBaseType.SQLServer
            Case "Oracle"
                content.TypeBaseDeDonnees = DocEditeurTable.DataBaseType.Oracle
        End Select
        resultat = content.Charger(Dat)

        If resultat Then
            Dim Document_Concepteur_Fenetre = New VelerSoftware.Design.Navigator.KryptonPage()
            With Document_Concepteur_Fenetre
                .Text = DataBaseName & "." & Table_Name ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextTitle = DataBaseName & "." & Table_Name ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .TextDescription = DataBaseName & "." & Table_Name ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .UniqueName = "Table " & DataBaseName & "." & Table_Name
                .ImageSmall = My.Resources.table
                .ToolTipBody = DataBaseName & "." & Table_Name ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipTitle = DataBaseName & "." & Table_Name ' RM.GetString("Document_Paramètres_Du_Projet") & " '" & proj.Nom & "'"
                .ToolTipImage = My.Resources.table

                .ClearFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.All)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageDrag)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.AllowPageReorder)
                .SetFlags(VelerSoftware.Design.Navigator.KryptonPageFlags.DockingAllowWorkspace)

                .Controls.Add(content)
            End With
            Return Document_Concepteur_Fenetre
        Else
            Return Nothing
        End If
    End Function

#End Region

#End Region

#Region "Ruban"

#Region "Accueil"

#Region "Nouveau Projet"

    Friend Sub Nouveau_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nouveau_Projet_KryptonRibbonGroupButton.Click, QAT_Ouvrir.Click
        Using frm As New NouveauProjet
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Ouvrir Un Projet"

    Friend Sub Ouvrir_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ouvrir_Projet_KryptonRibbonGroupButton.Click, QAT_Ouvrir.Click
        With Me.OpenFileDialog1
            .Title = RM.GetString("OpenFileDialog1_Ouvrir_Un_Projet")
            .Multiselect = False
            .Filter = RM.GetString("OpenFileDialog1_Ouvrir_Un_Projet_Filtre")
            .FileName = Nothing
            If My.Computer.FileSystem.DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then
                .InitialDirectory = My.Settings.Emplacement_Project_Par_Defaut
            Else
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
        End With

        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(Me.OpenFileDialog1.FileName) Then
                ' FICHIER SZSL
                If My.Computer.FileSystem.GetFileInfo(Me.OpenFileDialog1.FileName).Extension.ToUpper.EndsWith(".SZSL") Then 'Si c'est un fichier SZSL (solution)
                    If Not SOLUTION Is Nothing Then ' Si une solution est déja ouverte
                        If Me.OpenFileDialog1.FileName <> SOLUTION.Emplacement & "\" & SOLUTION.Nom_Fichier_Projet Then ' si la solution est différente de celle ouverte
                            ' Fermer la solution
                            ClassProjet.Ouvrir_Solution(Me.OpenFileDialog1.FileName)
                        End If
                    Else
                        ClassProjet.Ouvrir_Solution(Me.OpenFileDialog1.FileName)
                    End If

                    'FICHIER SZPROJ
                ElseIf My.Computer.FileSystem.GetFileInfo(Me.OpenFileDialog1.FileName).Extension.ToUpper.EndsWith(".SZPROJ") Then 'Si c'est un fichier SZPROJ (projet)
                    If Not SOLUTION Is Nothing Then ' Si une solution est déja ouverte
                        Dim ok As Boolean = True
                        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                            If proj IsNot Nothing AndAlso proj.Loaded Then
                                If Me.OpenFileDialog1.FileName = proj.Emplacement & "\" & proj.Nom_Fichier_Projet Then
                                    ok = False
                                    Exit For
                                End If
                            End If
                        Next
                        If ok Then ' Si le projet n'est pas déjà présent dans la solution
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Me
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Question
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content2"), Me.OpenFileDialog1.SafeFileName.Split(".")(0))
                                .MainInstruction = RM.GetString("MainInstruction2")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then ' Si l'utilisateur veux ajouter le projet à la solution
                                Dim proj As VelerSoftware.SZVB.Projet.Projet = ClassProjet.Ouvrir_Projet(Me.OpenFileDialog1.FileName)
                                If Not proj Is Nothing Then
                                    SOLUTION.Projets.Add(proj)
                                    SOLUTION.GenerationOrder.Add(proj.Nom)
                                    ClassProjet.Charger_Projet_Explorateur_Solutions(DirectCast(Me.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).TreeViewMultiSelect1.Nodes(0), proj)
                                End If
                            Else ' Sinon, on ferme la solution et en ouvre une nouvelle
                                ClassProjet.Ouvrir_Solution(Me.OpenFileDialog1.FileName)
                            End If
                        Else
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Me
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content1"), Me.OpenFileDialog1.SafeFileName.Split(".")(0))
                                .MainInstruction = RM.GetString("MainInstruction1")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                        End If
                    Else ' Si une solution n'est pas ouverte
                        ' On ouvre le projet dans une nouvelle solution
                        ClassProjet.Ouvrir_Solution(Me.OpenFileDialog1.FileName)
                    End If

                    ' FICHIER SZSTAT
                ElseIf My.Computer.FileSystem.GetFileInfo(Me.OpenFileDialog1.FileName).Extension.ToUpper.EndsWith(".SZSTAT") Then
                    If My.Settings.Edition = ClassApplication.Edition.Free Then
                        ClassApplication.Should_Standard_Edition()
                        Exit Sub
                    End If

                    If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert(Me.OpenFileDialog1.FileName) Then
                        Dim doc As VelerSoftware.Design.Navigator.KryptonPage = Nothing
                        doc = Me.Workspace_Nouveau_Statistiques_Fichier(Me.OpenFileDialog1.FileName)
                        If Not doc Is Nothing Then
                            Me.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {doc})
                        End If
                    End If
                    If ClassApplication.Determiner_Si_Document_Deja_Ouvert(Me.OpenFileDialog1.FileName) Then
                        Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Me.KryptonDockableWorkspace1.PageForUniqueName(Me.OpenFileDialog1.FileName)
                        If Not pag Is Nothing Then
                            Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Me.KryptonDockableWorkspace1.CellForPage(pag)
                            Me.KryptonDockableWorkspace1.ActiveCell = cell
                            cell.SelectedPage = pag
                        End If
                    End If

                End If
            End If
        End If
    End Sub

#End Region

#Region "Enregistrer le projet"

    Friend Sub Enregistrer_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enregistrer_Projet_KryptonRibbonGroupButton.Click
        Me.Enregistrer_Tout_KryptonRibbonGroupButton_Click(Nothing, Nothing)
        ClassProjet.Enregistrer_Solution(True)
    End Sub

#End Region

#Region "Exporter le projet vers Visual Studio"

    Friend Sub Exporter_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exporter_Projet_KryptonRibbonGroupButton.Click
        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        Using frm As New ExporterVisualStudio
            frm.ShowDialog()
        End Using
    End Sub

#End Region

#Region "Fermer le projet"

    Friend Sub Fermer_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fermer_Projet_KryptonRibbonGroupButton.Click, QAT_Fermer.Click
        ClassProjet.Fermer_Solution(True)
    End Sub

#End Region

#Region "Enregistrer"

    Friend Sub Enregistrer_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enregistrer_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Enregistrer(False)
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Enregistrer(False)
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocParametresDuProjet Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocParametresDuProjet).Enregistrer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Enregistrer(False)
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocStatistiques Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocStatistiques).Enregistrer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Enregistrer()
            End If
        End If
    End Sub

#End Region

#Region "Enregistrer Sous"

    Friend Sub Enregistrer_Sous_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enregistrer_Sous_KryptonRibbonGroupButton.Click, QAT_Enregistrer_Sous.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Enregistrer(True)
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Enregistrer(True)
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Enregistrer(True)
            End If
        End If
    End Sub

#End Region

#Region "Enregistrer Tout"

    Friend Sub Enregistrer_Tout_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enregistrer_Tout_KryptonRibbonGroupButton.Click, QAT_Enregistrer_Tout.Click
        For Each page As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonDockableWorkspace1.AllPages
            If page.Controls.Count > 0 Then
                If TypeOf page.Controls(0) Is DocConcepteurFenetre Then
                    DirectCast(page.Controls(0), DocConcepteurFenetre).Enregistrer(False)
                ElseIf TypeOf page.Controls(0) Is DocEditeurFonctions Then
                    DirectCast(page.Controls(0), DocEditeurFonctions).Enregistrer(False)
                ElseIf TypeOf page.Controls(0) Is DocParametresDuProjet Then
                    DirectCast(page.Controls(0), DocParametresDuProjet).Enregistrer()
                ElseIf TypeOf page.Controls(0) Is DocEditeurVisualBasic Then
                    DirectCast(page.Controls(0), DocEditeurVisualBasic).Enregistrer(False)
                End If
            End If
        Next
    End Sub

#End Region

#Region "Exporter en Visual Basic.Net"

    Friend Sub VbNet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VbNet_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then

                If My.Settings.Edition = ClassApplication.Edition.Free Then
                    ClassApplication.Should_Standard_Edition()
                    Exit Sub
                End If

                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Exporter_VB_Net()
            End If
        End If
    End Sub

#End Region

#Region "Exporter en C#"

    Friend Sub CSharp_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSharp_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then

                If My.Settings.Edition = ClassApplication.Edition.Free Then
                    ClassApplication.Should_Standard_Edition()
                    Exit Sub
                End If

                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Exporter_CSharp()
            End If
        End If
    End Sub

#End Region

#Region "Imprimer"

    Friend Sub Imprimer_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Imprimer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Imprimer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Imprimer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Imprimer()
            End If
        End If
    End Sub

#End Region

#Region "Impression rapide"

    Friend Sub Impression_Rapide_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Impression_Rapide_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Impression_Rapide()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Impression_Rapide()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Impression_Rapide()
            End If
        End If
    End Sub

#End Region

#Region "Aperçu avant impression"

    Friend Sub Apercu_Impression_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apercu_Impression_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Apercu_Avant_Impression()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Apercu_Avant_Impression()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Apercu_Avant_Impression()
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Edition"

#Region "Coller"

    Private Sub Coller_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coller_KryptonRibbonGroupButton.Click, QAT_Coller.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Coller()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Coller()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Coller()
            End If
        End If
    End Sub

#End Region

#Region "Copier"

    Private Sub Copier_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copier_KryptonRibbonGroupButton.Click, QAT_Copier.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Copier()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Copier()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Copier()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Copier()
            End If
        End If
    End Sub

#End Region

#Region "Couper"

    Private Sub Couper_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Couper_KryptonRibbonGroupButton.Click, QAT_Couper.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Couper()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Couper()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Couper()
            End If
        End If
    End Sub

#End Region

#Region "Annuler"

    Private Sub Annuler_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_KryptonRibbonGroupButton.Click, QAT_Annuler.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Undo()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Undo()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Undo()
            End If
        End If
    End Sub

#End Region

#Region "Rétablir"

    Private Sub Retablir_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Retablir_KryptonRibbonGroupButton.Click, QAT_Retablir.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Redo()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Redo()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).Redo()
            End If
        End If
    End Sub

#End Region

#Region "Sélectionner tout"

    Private Sub Selectionner_tout_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selectionner_tout_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).SelectionnerTout()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).SelectionnerTout()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurVisualBasic Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurVisualBasic).SelectionnerTout()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).SelectionnerTout()
            End If
        End If
    End Sub

#End Region

#Region "Supprimer"

    Private Sub Supprimer_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Supprimer_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Supprimer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Supprimer()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurTable Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurTable).Supprimer()
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Projet"

    Private Sub KryptonRibbonGroup16_DialogBoxLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroup16.DialogBoxLauncherClick
        If Not Me.Box_Explorateur_Solutions Is Nothing Then
            If TypeOf Me.Box_Explorateur_Solutions.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                DirectCast(Me.Box_Explorateur_Solutions.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Explorateur_Solutions
            ElseIf TypeOf Me.Box_Explorateur_Solutions.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Explorateur de solution")
            End If
        End If
    End Sub

    Private Sub KryptonRibbonGroup25_DialogBoxLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroup25.DialogBoxLauncherClick
        If Not Me.Box_Debogage Is Nothing Then
            If TypeOf Me.Box_Debogage.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                DirectCast(Me.Box_Debogage.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Debogage
            ElseIf TypeOf Me.Box_Debogage.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Débogage")
            End If
        End If
    End Sub

#Region "Paramètres"

    Private Sub Parametre_Projet_KryptonRibbonGroupButton3_DropDown(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Toolkit.ContextMenuArgs) Handles Parametre_Projet_KryptonRibbonGroupButton3.DropDown
        Me.Parametre_Projet_KryptonRibbonGroupButton3.KryptonContextMenu.Items.Clear()
        Dim menu_items As New VelerSoftware.Design.Toolkit.KryptonContextMenuItems
        Dim ite As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj IsNot Nothing AndAlso proj.Loaded Then
                    ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
                    ite.AutoClose = True
                    ite.Text = proj.Nom
                    If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        ite.Image = My.Resources.Project_DLL_16x16
                    Else
                        ite.Image = My.Resources.Project_Application_16x16
                    End If
                    AddHandler ite.Click, AddressOf Parametres_Projet_KryptonContextMenu_Menu_Click
                    menu_items.Items.Add(ite)
                End If
            Next
        End If
        If Not menu_items.Items.Count > 0 Then
            ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
            ite.AutoClose = True
            ite.Text = RM.GetString("ContextMenu_Projet")
            menu_items.Items.Add(ite)
        End If
        Me.Parametre_Projet_KryptonRibbonGroupButton3.KryptonContextMenu.Items.Add(menu_items)
    End Sub

    Private Sub Parametres_Projet_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim files() As String = New String(-1) {}
        Dim Safefiles() As String = New String(-1) {}
        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
        ReDim Preserve files(files.Length)
        ReDim Preserve Safefiles(Safefiles.Length)
        ReDim Preserve projects(projects.Length)
        files(files.Length - 1) = "PARAMETREDUPROJET"
        Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
        projects(projects.Length - 1) = SOLUTION.GetProject(DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Text)
        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
    End Sub

#End Region

#Region "Gestionnaire de variables"

    Private Sub Gestionnaire_Variables_KryptonRibbonGroupButton5_DropDown(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Toolkit.ContextMenuArgs) Handles Gestionnaire_Variables_KryptonRibbonGroupButton5.DropDown
        Me.Gestionnaire_Variables_KryptonRibbonGroupButton5.KryptonContextMenu.Items.Clear()
        Dim menu_items As New VelerSoftware.Design.Toolkit.KryptonContextMenuItems
        Dim ite As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj IsNot Nothing AndAlso proj.Loaded Then
                    ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
                    ite.AutoClose = True
                    ite.Text = proj.Nom
                    If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        ite.Image = My.Resources.Project_DLL_16x16
                    Else
                        ite.Image = My.Resources.Project_Application_16x16
                    End If
                    AddHandler ite.Click, AddressOf Gestionnaire_Variables_KryptonContextMenu_Menu_Click
                    menu_items.Items.Add(ite)
                End If
            Next
        End If
        If Not menu_items.Items.Count > 0 Then
            ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
            ite.AutoClose = True
            ite.Text = RM.GetString("ContextMenu_Projet")
            menu_items.Items.Add(ite)
        End If
        Me.Gestionnaire_Variables_KryptonRibbonGroupButton5.KryptonContextMenu.Items.Add(menu_items)
    End Sub

    Private Sub Gestionnaire_Variables_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Using frm As New Gestionnaire_Variables
            frm.Nom_Projet = DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Text
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Statistiques"

    Private Sub Statistiques_KryptonRibbonGroupButton5_DropDown(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Toolkit.ContextMenuArgs) Handles Statistiques_KryptonRibbonGroupButton.DropDown
        Me.Statistiques_KryptonRibbonGroupButton.KryptonContextMenu.Items.Clear()
        Dim menu_items As New VelerSoftware.Design.Toolkit.KryptonContextMenuItems
        Dim ite As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj IsNot Nothing AndAlso proj.Loaded Then
                    ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
                    ite.AutoClose = True
                    ite.Text = proj.Nom
                    If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        ite.Image = My.Resources.Project_DLL_16x16
                    Else
                        ite.Image = My.Resources.Project_Application_16x16
                    End If
                    AddHandler ite.Click, AddressOf Statistiques_KryptonContextMenu_Menu_Click
                    menu_items.Items.Add(ite)
                End If
            Next
        End If
        If Not menu_items.Items.Count > 0 Then
            ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
            ite.AutoClose = True
            ite.Text = RM.GetString("ContextMenu_Projet")
            menu_items.Items.Add(ite)
        End If
        Me.Statistiques_KryptonRibbonGroupButton.KryptonContextMenu.Items.Add(menu_items)
    End Sub

    Private Sub Statistiques_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If My.Settings.Edition = ClassApplication.Edition.Free Then
            ClassApplication.Should_Standard_Edition()
            Exit Sub
        End If

        Dim files() As String = New String(-1) {}
        Dim Safefiles() As String = New String(-1) {}
        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}
        ReDim Preserve files(files.Length)
        ReDim Preserve Safefiles(Safefiles.Length)
        ReDim Preserve projects(projects.Length)
        files(files.Length - 1) = "STATISTIQUESDUPROJET"
        Safefiles(Safefiles.Length - 1) = "STATISTIQUESDUPROJET"
        projects(projects.Length - 1) = SOLUTION.GetProject(DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonContextMenuItem).Text)
        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
    End Sub

#End Region

#Region "Ordre de la génération"

    Private Sub Ordre_Generation_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordre_Generation_KryptonRibbonGroupButton.Click
        Using frm As New OrdreGeneration
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Nouveau document"

    Private Sub Nouveau_Document_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nouveau_Document_KryptonRibbonGroupButton.Click
        Using frm As New NouveauDocument
            frm.ShowDialog()
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Ajouter un nouveau projet"

    Private Sub Ajouter_Nouveau_Projet_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Nouveau_Projet_KryptonRibbonGroupButton_Click(sender, e)
    End Sub

#End Region

#Region "Ajouter un projet existant"

    Private Sub Ajouter_Projet_Existant_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SOLUTION Is Nothing Then
            DirectCast(Me.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).AjouterUnProjetExistantToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

#End Region

#Region "Générer le projet"

    Private Sub Geneger_KryptonRibbonGroupButton_DropDown(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Toolkit.ContextMenuArgs) Handles Generer_KryptonRibbonGroupButton.DropDown
        If Me.Generer_KryptonRibbonGroupButton.KryptonContextMenu.Items.Count = 2 Then
            Me.Generer_KryptonRibbonGroupButton.KryptonContextMenu.Items.RemoveAt(1)
        End If

        Dim menu_items As New VelerSoftware.Design.Toolkit.KryptonContextMenuItems
        Dim ite As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj IsNot Nothing AndAlso proj.Loaded Then
                    ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
                    ite.AutoClose = True
                    ite.Text = proj.Nom
                    If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        ite.Image = My.Resources.Project_DLL_16x16
                    Else
                        ite.Image = My.Resources.Project_Application_16x16
                    End If
                    AddHandler ite.Click, AddressOf Generer_KryptonContextMenu_Menu_Click
                    menu_items.Items.Add(ite)
                End If
            Next
        End If
        If Not menu_items.Items.Count > 0 Then
            ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
            ite.AutoClose = True
            ite.Text = RM.GetString("ContextMenu_Projet")
            menu_items.Items.Add(ite)
        End If
        Me.Generer_KryptonRibbonGroupButton.KryptonContextMenu.Items.Add(menu_items)
    End Sub

    Private Sub Generer_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SOLUTION Is Nothing AndAlso Not Status_SZ = statu.Debuggage_En_Cours Then
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(sender.Text)

            Dim ok2 As Boolean = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
                Try
                    If proc.MainModule.FileName = My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory & "\" & proj.Nom & ".exe") Then
                        ok2 = False
                        Exit For
                    End If
                Catch
                End Try
            Next
            If Not ok2 Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content34"), My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory & "\" & proj.Nom & ".exe"))
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then
                    For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                        Try
                            If DirectCast(proc.MainModule, System.Diagnostics.ProcessModule).FileName = My.Computer.FileSystem.CombinePath(proj.Emplacement, proj.GenerateDirectory & "\" & proj.Nom & ".exe") Then
                                proc.Kill()
                                Exit For
                            End If
                        Catch
                        End Try
                    Next
                Else
                    Exit Sub
                End If
            End If

            If proj IsNot Nothing AndAlso ClassProjet.Valider_Projet(proj, True) Then
                Generation_En_Cours_Type = generation_type.Release
                Me.GenerationComponent1.Generation_Code = False
                Me.GenerationComponent1.Obfuscation = False
                Me.GenerationComponent1.Generer_Projet_Base(sender.Text, True)
            End If
        End If
    End Sub

    Private Sub Generer_Solution_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QAT_Generer.Click
        If Not SOLUTION Is Nothing AndAlso Not Status_SZ = statu.Debuggage_En_Cours Then
            Dim ok2 As Boolean = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
                Try
                    If proc.MainModule.FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                        ok2 = False
                        Exit For
                    End If
                Catch
                End Try
            Next
            If Not ok2 Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content34"), My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then
                    For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                        Try
                            If DirectCast(proc.MainModule, System.Diagnostics.ProcessModule).FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                proc.Kill()
                                Exit For
                            End If
                        Catch
                        End Try
                    Next
                Else
                    Exit Sub
                End If
            End If

            Dim ok As Boolean = True
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If Not ClassProjet.Valider_Projet(proj, True) Then ok = False : Exit For
            Next

            If ok Then
                SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Normal
                Generation_En_Cours_Type = generation_type.Release
                Me.GenerationComponent1.Generation_Code = False
                Me.GenerationComponent1.Obfuscation = False
                Me.GenerationComponent1.Generer_Solution(False)
            End If
        End If
    End Sub

    Private Sub Generer_Solution_Obfuscation_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Settings.Edition = ClassApplication.Edition.Free Then
            ClassApplication.Should_Standard_Edition()
            Exit Sub
        End If

        If Not SOLUTION Is Nothing AndAlso Not Status_SZ = statu.Debuggage_En_Cours Then
            Dim ok2 As Boolean = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
                Try
                    If proc.MainModule.FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                        ok2 = False
                        Exit For
                    End If
                Catch
                End Try
            Next
            If Not ok2 Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content34"), My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then
                    For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                        Try
                            If DirectCast(proc.MainModule, System.Diagnostics.ProcessModule).FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                proc.Kill()
                                Exit For
                            End If
                        Catch
                        End Try
                    Next
                Else
                    Exit Sub
                End If
            End If

            Dim ok As Boolean = True
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If Not ClassProjet.Valider_Projet(proj, True) Then ok = False : Exit For
            Next
            If ok Then
                SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Obfusced
                Generation_En_Cours_Type = generation_type.Release
                Me.GenerationComponent1.Generation_Code = False
                Me.GenerationComponent1.Obfuscation = True
                Me.GenerationComponent1.Generer_Solution(False)
            End If
        End If
    End Sub

#End Region

#Region "Exécuter le projet"

    Private Sub KryptonRibbonGroupButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Executer_Le_Projet_KryptonRibbonGroupButton.Click
        If Not Status_SZ = statu.Debuggage_En_Cours Then

            Dim Generer_Solution As Boolean
            Dim ok As Boolean

            If SOLUTION IsNot Nothing AndAlso SOLUTION.GetProject(SOLUTION.ProjetDemarrage) IsNot Nothing AndAlso SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Loaded AndAlso (SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) Then
                ' Si le projet est chargé et est de type Application Windows/Console

                ' On détermine si un projet a besoin d'être généré.
                Generer_Solution = False
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    If proj.Loaded AndAlso proj.ShouldCompileRelease Then Generer_Solution = True : Exit For
                Next

                If Generer_Solution Then
                    Dim ok2 As Boolean = True
                    For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
                        Try
                            If proc.MainModule.FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                ok2 = False
                                Exit For
                            End If
                        Catch
                        End Try
                    Next
                    If Not ok2 Then
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content34"), My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
                            .MainInstruction = RM.GetString("MainInstruction11")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                        If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then
                            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                                Try
                                    If DirectCast(proc.MainModule, System.Diagnostics.ProcessModule).FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                        proc.Kill()
                                        Exit For
                                    End If
                                Catch
                                End Try
                            Next
                        Else
                            Exit Sub
                        End If
                    End If

                    ok = True
                    For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                        If Not ClassProjet.Valider_Projet(proj, True) Then ok = False : Exit For
                    Next
                    If ok Then
                        SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Normal
                        Generation_En_Cours_Type = generation_type.Release
                        Me.GenerationComponent1.Generation_Code = False
                        Me.GenerationComponent1.Obfuscation = False
                        Me.GenerationComponent1.Generer_Solution(True)
                    End If

                Else
                    Dim can_launch As Boolean = True
                    For Each a As System.Diagnostics.Process In Process.GetProcesses
                        If a.ProcessName = SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom Then
                            can_launch = False
                            Exit For
                        End If
                    Next
                    If can_launch Then
                        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")) Then
                            Process.Start(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
                        Else
                            SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Normal
                            Generation_En_Cours_Type = generation_type.Release
                            Me.GenerationComponent1.Generation_Code = False
                            Me.GenerationComponent1.Obfuscation = False
                            Me.GenerationComponent1.Generer_Solution(True)
                        End If
                    End If
                End If

            Else
                ' Si le projet n'est pas chargé ou n'est pas de type Application Windows/Console
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Me
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content33"), SOLUTION.ProjetDemarrage)
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If

        End If
    End Sub

#End Region

#Region "Voir les codes"

    Private Sub Voir_Les_Codes_KryptonRibbonGroupButton_DropDown(ByVal sender As System.Object, ByVal e As VelerSoftware.Design.Toolkit.ContextMenuArgs) Handles Voir_Les_Codes_KryptonRibbonGroupButton.DropDown
        Me.Voir_Les_Codes_KryptonRibbonGroupButton.KryptonContextMenu.Items.Clear()

        Dim menu_items As New VelerSoftware.Design.Toolkit.KryptonContextMenuItems
        Dim ite As VelerSoftware.Design.Toolkit.KryptonContextMenuItem
        If Not SOLUTION Is Nothing Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If proj IsNot Nothing AndAlso proj.Loaded Then
                    ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
                    ite.AutoClose = True
                    ite.Text = proj.Nom
                    If proj.Type = VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions Then
                        ite.Image = My.Resources.Project_DLL_16x16
                    Else
                        ite.Image = My.Resources.Project_Application_16x16
                    End If
                    AddHandler ite.Click, AddressOf Voir_Les_Codes_KryptonContextMenu_Menu_Click
                    menu_items.Items.Add(ite)
                End If
            Next
        End If
        If Not menu_items.Items.Count > 0 Then
            ite = New VelerSoftware.Design.Toolkit.KryptonContextMenuItem
            ite.AutoClose = True
            ite.Text = RM.GetString("ContextMenu_Projet")
            menu_items.Items.Add(ite)
        End If
        Me.Voir_Les_Codes_KryptonRibbonGroupButton.KryptonContextMenu.Items.Add(menu_items)
    End Sub

    Private Sub Voir_Les_Codes_KryptonContextMenu_Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SOLUTION Is Nothing AndAlso Not Status_SZ = statu.Debuggage_En_Cours Then

            If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                ClassApplication.Should_Professional_Edition()
                Exit Sub
            End If

            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(sender.Text)
            If proj IsNot Nothing AndAlso ClassProjet.Valider_Projet(proj, True) Then
                Status_SZ = statu.Normal
                SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Normal
                Generation_En_Cours_Type = generation_type.Release
                Me.GenerationComponent1.Generation_Code = True
                Me.GenerationComponent1.Obfuscation = False
                Me.GenerationComponent1.Generer_Projet_Base(sender.Text, True)
            End If
        End If
    End Sub

#End Region

#Region "Démarrer le débogage"

    Private Sub Demarrer_Le_Debogage_KryptonRibbonGroupButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Demarrer_Le_Debogage_KryptonRibbonGroupButton1.Click
        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        Dim Generer_Solution, AnyCPU As Boolean
        Dim ok As Boolean

        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
            If proj.Loaded AndAlso Not proj.Cpu = VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu Then AnyCPU = True : Exit For
        Next

        If AnyCPU Then
            ' Si un projet n'est pas AnyCPU, alors on annule le débogage
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Me
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content38"))
                .MainInstruction = RM.GetString("MainInstruction11")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            Exit Sub

        Else

            If SOLUTION IsNot Nothing AndAlso SOLUTION.GetProject(SOLUTION.ProjetDemarrage) IsNot Nothing AndAlso SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Loaded AndAlso (SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Type = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole) Then
                ' Si le projet est chargé et est de type Application Windows/Console


                Generer_Solution = False
                For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                    If proj.Loaded AndAlso proj.ShouldCompileRelease Then Generer_Solution = True : Exit For
                Next

                If Not SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Debug OrElse Generer_Solution OrElse SOLUTION.GetProject(SOLUTION.ProjetDemarrage).VBGénéréParGénération = Nothing Then
                    Dim ok2 As Boolean = True
                    For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses
                        Try
                            If proc.MainModule.FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                ok2 = False
                                Exit For
                            End If
                        Catch
                        End Try
                    Next
                    If Not ok2 Then
                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                        With vd
                            .Owner = Nothing
                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content34"), My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe"))
                            .MainInstruction = RM.GetString("MainInstruction11")
                            .WindowTitle = My.Application.Info.Title
                            .Show()
                        End With
                        If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then
                            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcesses()
                                Try
                                    If DirectCast(proc.MainModule, System.Diagnostics.ProcessModule).FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe") Then
                                        proc.Kill()
                                        Exit For
                                    End If
                                Catch
                                End Try
                            Next
                        Else
                            Exit Sub
                        End If
                    End If

                    ok = True
                    For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                        If Not ClassProjet.Valider_Projet(proj, True) Then ok = False : Exit For
                    Next
                    If ok Then
                        SOLUTION.LastBuildType = VelerSoftware.SZVB.Projet.Solution.LastBuildTypes.Debug
                        Generation_En_Cours_Type = generation_type.Debug
                        Me.GenerationComponent1.Generation_Code = False
                        Me.GenerationComponent1.Obfuscation = False
                        Me.GenerationComponent1.Generer_Solution(False)
                    End If

                Else
                    Me.Lancer_Debugger()
                End If

            Else
                ' Si le projet n'est pas chargé ou n'est pas de type Application Windows/Console
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Me
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content37"), SOLUTION.ProjetDemarrage)
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If

        End If
    End Sub

#End Region

#Region "Débogage en Pause"

    Private Sub Debogage_Pause_KryptonRibbonGroupButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Debogage_Pause_KryptonRibbonGroupButton6.Click
        If Status_SZ = statu.Debuggage_En_Cours AndAlso Débogueur IsNot Nothing Then

            If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                ClassApplication.Should_Professional_Edition()
                Exit Sub
            End If

            Débogueur.Break()
        End If
    End Sub

#End Region

#Region "Arrêter le débogage"

    Private Sub Debogage_Arreter_KryptonRibbonGroupButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Debogage_Arreter_KryptonRibbonGroupButton7.Click
        If Status_SZ = statu.Debuggage_En_Cours AndAlso Débogueur IsNot Nothing Then

            If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                ClassApplication.Should_Professional_Edition()
                Exit Sub
            End If

            Débogueur.Stop()
        End If
    End Sub

#End Region

#Region "Reprendre le débogage"

    Private Sub Debogage_Reprendre_KryptonRibbonGroupButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Debogage_Reprendre_KryptonRibbonGroupButton9.Click
        If Status_SZ = statu.Debuggage_En_Cours AndAlso Débogueur IsNot Nothing Then

            If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                ClassApplication.Should_Professional_Edition()
                Exit Sub
            End If

            Débogueur.Continue()
        End If
    End Sub

#End Region

#Region "Redémarrer le débogage"

    Private Sub Debogage_Redemarrer_KryptonRibbonGroupButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Debogage_Redemarrer_KryptonRibbonGroupButton1.Click
        If Status_SZ = statu.Debuggage_En_Cours AndAlso Débogueur IsNot Nothing Then

            If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
                ClassApplication.Should_Professional_Edition()
                Exit Sub
            End If

            Débogueur.Stop()
            Demarrer_Le_Debogage_KryptonRibbonGroupButton1_Click(Nothing, Nothing)
        End If
    End Sub

#End Region

#End Region

#Region "Outils"

    Private Sub KryptonRibbonGroup22_DialogBoxLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroup22.DialogBoxLauncherClick
        If Not Me.Box_Reconnaissance_Vocale Is Nothing Then
            If TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                DirectCast(Me.Box_Reconnaissance_Vocale.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Reconnaissance_Vocale
            ElseIf TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Reconnaissance vocale")
            End If
        End If
    End Sub

#Region "Options"

    Private Sub Options_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Options_KryptonRibbonGroupButton.Click
        Using frm As New Options
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Page de démarrage"

    Private Sub Page_De_Demarrage_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Page_De_Demarrage_KryptonRibbonGroupButton.Click
        If Not ClassApplication.Determiner_Si_Document_Deja_Ouvert("Page de démarrage") Then
            Try : Me.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Workspace_Nouveau_Page_De_Demarrage()}) : Catch : End Try
        End If
        Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Me.KryptonDockableWorkspace1.PageForUniqueName("Page de démarrage")
        If Not pag Is Nothing Then
            Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Me.KryptonDockableWorkspace1.CellForPage(pag)
            Me.KryptonDockableWorkspace1.ActiveCell = cell
            cell.SelectedPage = pag
        End If
    End Sub

#End Region

#Region "Gestionnaire de plugins"

    Private Sub Gestionnaire_Plugins_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gestionnaire_Plugins_KryptonRibbonGroupButton.Click
        If Plugins_Has_Been_Loaded Then
            Using frm As New Gestionnaire_Plugins
                frm.ShowDialog()
            End Using
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content53"))
                .MainInstruction = RM.GetString("MainInstruction15")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
        End If
    End Sub

#End Region

#Region "SZStore"

    Private Sub SZStore_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZStore_KryptonRibbonGroupButton.Click
        System.Diagnostics.Process.Start("http://szstore.velersoftware.com/")
    End Sub

#End Region

#Region "Configurer la reconnaissance vocale"

    Private Sub Reconnaissance_Vocal_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reconnaissance_Vocal_KryptonRibbonGroupButton.Click
        Using frm As New ReconnaissanceVocale
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Activer la reconnaissance vocale"

    Private Sub Reconnaissance_Vocal_KryptonRibbonGroupCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.CheckedChanged
        If My.Settings.Edition = ClassApplication.Edition.Free Then
            If Me.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked = False Then Exit Sub
            ClassApplication.Should_Standard_Edition()
            Me.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked = False
        End If

        My.Settings.Activer_Reconnaissance_Vocale = Me.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked

        If Not SRE Is Nothing Then
            SRE.RecognizeAsyncCancel()
            SRE.RecognizeAsyncStop()
            SRE.UnloadAllGrammars()
            SRE.Dispose()
            SRE = Nothing
        End If

        ' Initialisation de la reconnaissance vocale
        If Not VelerSoftware.SZVB.Windows.Core.RunningOnXP AndAlso My.Settings.Activer_Reconnaissance_Vocale Then
            SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
            SRE.SetInputToDefaultAudioDevice()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)
        End If
    End Sub

#End Region

#End Region

#Region "Concepteur de fenêtre"

#Region "Aligner coté gauche"

    Private Sub Cote_Gauche_KryptonRibbonGroupClusterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cote_Gauche_KryptonRibbonGroupClusterButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerGauche()
            End If
        End If
    End Sub

#End Region

#Region "Aligner centre"

    Private Sub Centre_KryptonRibbonGroupClusterButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Centre_KryptonRibbonGroupClusterButton2.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerCentre()
            End If
        End If
    End Sub

#End Region

#Region "Aligner coté droit"

    Private Sub Cote_Droit_KryptonRibbonGroupClusterButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cote_Droit_KryptonRibbonGroupClusterButton3.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerDroite()
            End If
        End If
    End Sub

#End Region

#Region "Aligner sommet"

    Private Sub Sommet_KryptonRibbonGroupClusterButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sommet_KryptonRibbonGroupClusterButton4.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerSommet()
            End If
        End If
    End Sub

#End Region

#Region "Aligner millieu"

    Private Sub Milieux_KryptonRibbonGroupClusterButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Milieux_KryptonRibbonGroupClusterButton5.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerMilieux()
            End If
        End If
    End Sub

#End Region

#Region "Aligner base"

    Private Sub Bas_KryptonRibbonGroupClusterButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bas_KryptonRibbonGroupClusterButton6.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerBase()
            End If
        End If
    End Sub

#End Region

#Region "Aligner sur la grille"

    Private Sub Sur_Grille_KryptonRibbonGroupButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sur_Grille_KryptonRibbonGroupButton1.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AlignerGrille()
            End If
        End If
    End Sub

#End Region

#Region "Ajuster largeur"

    Private Sub Largeur_KryptonRibbonGroupButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Largeur_KryptonRibbonGroupButton2.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AjusterLargeur()
            End If
        End If
    End Sub

#End Region

#Region "Ajuster hauteur"

    Private Sub Hauteur_KryptonRibbonGroupButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hauteur_KryptonRibbonGroupButton4.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AjusterHauteur()
            End If
        End If
    End Sub

#End Region

#Region "Ajuster largeur et hauteur"

    Private Sub Largeur_Et_Hauteur_KryptonRibbonGroupButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Largeur_Et_Hauteur_KryptonRibbonGroupButton3.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AjusterlargeurEtHauteur()
            End If
        End If
    End Sub

#End Region

#Region "Ajuster sur la grille"

    Private Sub Ajuster_Grille_KryptonRibbonGroupButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ajuster_Grille_KryptonRibbonGroupButton5.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).AjusterGrille()
            End If
        End If
    End Sub

#End Region

#Region "Espacement horizontal égalisé"

    Private Sub H_Egaliser_KryptonRibbonGroupButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H_Egaliser_KryptonRibbonGroupButton6.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceHorizontalEgaliser()
            End If
        End If
    End Sub

#End Region

#Region "Espacement horizontal augmenté"

    Private Sub H_Augmenter_KryptonRibbonGroupButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H_Augmenter_KryptonRibbonGroupButton8.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceHorizontalAugmenter()
            End If
        End If
    End Sub

#End Region

#Region "Espacement horizontal diminué"

    Private Sub H_Diminuer_KryptonRibbonGroupButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H_Diminuer_KryptonRibbonGroupButton7.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceHorizontalDiminuer()
            End If
        End If
    End Sub

#End Region

#Region "Espacement horizontal supprimé"

    Private Sub H_Supprimer_KryptonRibbonGroupButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H_Supprimer_KryptonRibbonGroupButton9.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceHorizontalSupprimer()
            End If
        End If
    End Sub

#End Region

#Region "Espacement vertical égalisé"

    Private Sub V_Egaliser_KryptonRibbonGroupButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles V_Egaliser_KryptonRibbonGroupButton10.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceVerticalEgaliser()
            End If
        End If
    End Sub

#End Region

#Region "Espacement vertical augmenté"

    Private Sub V_Augmenter_KryptonRibbonGroupButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles V_Augmenter_KryptonRibbonGroupButton12.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceVerticalAugmenter()
            End If
        End If
    End Sub

#End Region

#Region "Espacement vertical diminué"

    Private Sub V_Diminuer_KryptonRibbonGroupButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles V_Diminuer_KryptonRibbonGroupButton11.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceVerticalDiminuer()
            End If
        End If
    End Sub

#End Region

#Region "Espacement vertical supprimé"

    Private Sub V_Supprimer_KryptonRibbonGroupButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles V_Supprimer_KryptonRibbonGroupButton13.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EspaceVerticalSupprimer()
            End If
        End If
    End Sub

#End Region

#Region "Centrer horizontal"

    Private Sub Centrer_H_KryptonRibbonGroupButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Centrer_H_KryptonRibbonGroupButton14.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).CentrerHorizontal()
            End If
        End If
    End Sub

#End Region

#Region "Centrer vertical"

    Private Sub Centrer_V_KryptonRibbonGroupButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Centrer_V_KryptonRibbonGroupButton15.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).CentrerVertical()
            End If
        End If
    End Sub

#End Region

#Region "Mettre au premier plan"

    Private Sub Premier_Plan_KryptonRibbonGroupButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Premier_Plan_KryptonRibbonGroupButton16.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).PremierPlan()
            End If
        End If
    End Sub

#End Region

#Region "Mettre en arrière plan"

    Private Sub Arriere_Plan_KryptonRibbonGroupButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Arriere_Plan_KryptonRibbonGroupButton17.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ArrierePlan()
            End If
        End If
    End Sub

#End Region

#Region "Vérouiller les contrôles"

    Private Sub Verouiller_KryptonRibbonGroupButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Verouiller_KryptonRibbonGroupButton18.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).VerouillerControles()
            End If
        End If
    End Sub

#End Region

#Region "Ordre de tabulation"

    Private Sub Ordre_Tabulation_KryptonRibbonGroupButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordre_Tabulation_KryptonRibbonGroupButton19.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).OrdreTabulation()
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Editeur de fonctions"

    Private Sub KryptonRibbonGroup15_DialogBoxLauncherClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonRibbonGroup15.DialogBoxLauncherClick
        If Not Me.Box_Boite_A_Outils Is Nothing Then
            If TypeOf Me.Box_Boite_A_Outils.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                DirectCast(Me.Box_Boite_A_Outils.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Boite_A_Outils
            ElseIf TypeOf Me.Box_Boite_A_Outils.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Boîte à outils")
            End If
        End If
    End Sub

#Region "Nouvelle Fonction"

    Friend Sub Nouvelle_Fonction_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nouvelle_Fonction_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).NouvelleFonction()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).NouvelleFonction()
            End If
        End If
    End Sub

#End Region

#Region "Modifier une action"

    Private Sub Modifier_Action_KryptonRibbonGroupButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modifier_Action_KryptonRibbonGroupButton2.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ModifierAction()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).ModifierAction()
            End If
        End If
    End Sub

#End Region

#Region "Avancer"

    Private Sub Avancer_Zoom_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Avancer_Zoom_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ZoomIn()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).ZoomIn()
            End If
        End If
    End Sub

#End Region

#Region "Reculer"

    Private Sub Reculer_Zoom_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reculer_Zoom_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ZoomOut()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).ZoomOut()
            End If
        End If
    End Sub

#End Region

#Region "Réinitialiser"

    Private Sub Reinitialiser_Zoom_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reinitialiser_Zoom_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).ZoomReset()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).ZoomReset()
            End If
        End If
    End Sub

#End Region

#Region "Enregistrer en tant qu'image"

    Private Sub Enregistrer_Image_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enregistrer_Image_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).EnregistrerImage()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).EnregistrerImage()
            End If
        End If
    End Sub

#End Region

#Region "Copier en tant qu'image"

    Private Sub Copier_Image_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copier_Image_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).CopierImage()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).CopierImage()
            End If
        End If
    End Sub

#End Region

#Region "Réduire"

    Private Sub Reduire_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reduire_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Reduire()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Reduire()
            End If
        End If
    End Sub

#End Region

#Region "Développer"

    Private Sub Developper_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Developper_KryptonRibbonGroupButton.Click
        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Developper()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Developper()
            End If
        End If
    End Sub

#End Region

#Region "Insérer un point d'arrêt"

    Private Sub Inserer_Breakpoint_KryptonRibbonGroupButton1_Click(sender As System.Object, e As System.EventArgs) Handles Inserer_Breakpoint_KryptonRibbonGroupButton1.Click
        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Ajouter_Point_Arrêt()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Ajouter_Point_Arrêt()
            End If
        End If
    End Sub

#End Region

#Region "Activer/Desactiver un point d'arrêt"

    Private Sub KryptonRibbonGroupButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton4.Click
        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Switch_Point_Arrêt()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Switch_Point_Arrêt()
            End If
        End If
    End Sub

#End Region

#Region "Supprimer un point d'arrêt"

    Private Sub KryptonRibbonGroupButton5_Click(sender As System.Object, e As System.EventArgs) Handles KryptonRibbonGroupButton5.Click
        If Not My.Settings.Edition = ClassApplication.Edition.Professional Then
            ClassApplication.Should_Professional_Edition()
            Exit Sub
        End If

        If Me.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Supprimer_Point_Arrêt()
            ElseIf TypeOf Me.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                DirectCast(Me.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Supprimer_Point_Arrêt()
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Aide"

#Region "A propos de SZ"

    Private Sub A_Propos_De_KryptonRibbonGroupButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A_Propos_De_KryptonRibbonGroupButton1.Click
        Using frm As New A_Propos_De
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Aide"

    Private Sub Aide_KryptonRibbonGroupButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Aide_KryptonRibbonGroupButton2.Click, ButtonSpecAny1.Click
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Help.exe") Then
            System.Diagnostics.Process.Start(Application.StartupPath & "\Help.exe")
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
    End Sub

#End Region

#Region "Envoyez vos commentaires"

    Private Sub FeedBack_KryptonRibbonGroupButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeedBack_KryptonRibbonGroupButton3.Click, ButtonSpecAny2.Click
        Using frm As New Feedback
            frm.ShowDialog(Me)
            frm.Dispose()
        End Using
    End Sub

#End Region

#Region "Activer SoftwareZator"

    Private Sub Activer_Licence_SZ_KryptonRibbonGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Activer_Licence_SZ_KryptonRibbonGroupButton.Click
        If Not Me.SZ_Activation_BackgroundWorker.IsBusy Then Me.SZ_Activation_BackgroundWorker.RunWorkerAsync()
    End Sub

#End Region

#End Region

#End Region

#Region "SZ Initialisation"

    Private Sub SZ_Initialisation_BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SZ_Initialisation_BackgroundWorker.DoWork
        Dim Resultat As New Generic.List(Of Generic.List(Of ListViewItem))
        Dim GacList As New Generic.List(Of ListViewItem)
        Dim ComList As New Generic.List(Of ListViewItem)
        Dim ImgList As New System.Windows.Forms.ImageList()
        Dim ite As ListViewItem

        With My.Computer.FileSystem

            ' Chargement des plugins
            If .DirectoryExists(Application.StartupPath & "\Plugins") Then PLUGINS = ClassPluginServices.LoadPlugins()

            If System.Diagnostics.Process.GetProcessesByName("SoftwareZator 2012").Length = 1 AndAlso .DirectoryExists(Application.StartupPath & "\Temp") Then .DeleteDirectory(Application.StartupPath & "\Temp", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)

            ' Initialisation des dossiers 
            If Not .DirectoryExists(My.Settings.Emplacement_Project_Par_Defaut) Then .CreateDirectory(My.Settings.Emplacement_Project_Par_Defaut)
            If Not .DirectoryExists(Application.StartupPath & "\Toolbox") Then .CreateDirectory(Application.StartupPath & "\Toolbox")
            If Not .DirectoryExists(Application.StartupPath & "\Images") Then .CreateDirectory(Application.StartupPath & "\Images")
            If Not .DirectoryExists(Application.StartupPath & "\Plugins") Then .CreateDirectory(Application.StartupPath & "\Plugins")
            If Not .DirectoryExists(Application.StartupPath & "\Temp") Then .CreateDirectory(Application.StartupPath & "\Temp")
            If Not .DirectoryExists(Application.StartupPath & "\Temp\Functions") Then .CreateDirectory(Application.StartupPath & "\Temp\Functions")
            If Not .DirectoryExists(Application.StartupPath & "\Temp\Resources") Then .CreateDirectory(Application.StartupPath & "\Temp\Resources")
            If Not .DirectoryExists(Application.StartupPath & "\Temp\Building") Then .CreateDirectory(Application.StartupPath & "\Temp\Building")
            If Not .DirectoryExists(Application.StartupPath & "\Temp\Debugger") Then .CreateDirectory(Application.StartupPath & "\Temp\Debugger")
            If Not .DirectoryExists(Application.StartupPath & "\Temp\Obfuscator") Then .CreateDirectory(Application.StartupPath & "\Temp\Obfuscator")
            If Not .DirectoryExists(Application.StartupPath & "\Sources") Then .CreateDirectory(Application.StartupPath & "\Sources")

            ' Initialisation du registre
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True) Is Nothing Then
                Dim key As Microsoft.Win32.RegistryKey
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Veler Software\SoftwareZator")
            End If
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("InstallDate") Is Nothing Then
                Dim key As Microsoft.Win32.RegistryKey
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
                key.SetValue("InstallDate", New Date(Now.Ticks))
            End If
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("CertificateDate") Is Nothing Then
                Dim key As Microsoft.Win32.RegistryKey
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
                key.SetValue("CertificateDate", New Date(Now.Ticks))
            End If
            If Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Certificated") Is Nothing Then
                Dim key As Microsoft.Win32.RegistryKey
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
                key.SetValue("Certificated", False)
            End If

            ' Initialisation de la reconnaissance vocale
            If Not VelerSoftware.SZVB.Windows.Core.RunningOnXP AndAlso My.Settings.Activer_Reconnaissance_Vocale Then
                SRE = New Speech.Recognition.SpeechRecognitionEngine
                SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
                SRE.SetInputToDefaultAudioDevice()
                SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)
            End If

            ' Initialisation du Parser
            Using Parser As VelerSoftware.SZC.VBNetParser.IParser = VelerSoftware.SZC.VBNetParser.ParserFactory.CreateParser(New IO.StringReader("NameSpace Test" & Environment.NewLine & "End NameSpace"))
                Parser.Parse()
                Parser.Dispose()
            End Using

            ' Initialisation de l'Obfuscation 
            For Each Types As Type In GetType(VelerSoftware.SZC.Obfuscator.Confuser.Core.IConfusion).Assembly.GetTypes()
                If GetType(VelerSoftware.SZC.Obfuscator.Confuser.Core.IConfusion).IsAssignableFrom(Types) AndAlso Types IsNot GetType(VelerSoftware.SZC.Obfuscator.Confuser.Core.IConfusion) Then ldConfusions.Add(Types.FullName, DirectCast(Activator.CreateInstance(Types), VelerSoftware.SZC.Obfuscator.Confuser.Core.IConfusion))
                If GetType(VelerSoftware.SZC.Obfuscator.Confuser.Core.Packer).IsAssignableFrom(Types) AndAlso Types IsNot GetType(VelerSoftware.SZC.Obfuscator.Confuser.Core.Packer) Then ldPackers.Add(Types.FullName, DirectCast(Activator.CreateInstance(Types), VelerSoftware.SZC.Obfuscator.Confuser.Core.Packer))
            Next

            ''' GAC '''
            For Each b As VelerSoftware.SZC.Reference.GacInterop.AssemblyListEntry In (New VelerSoftware.SZC.Reference.GacInterop).GetAssemblyList
                ite = New ListViewItem(New String() {b.Name, b.Version, b.FullName, ""})
                ite.Tag = False
                GacList.Add(ite)
            Next

            ''' COM '''
            For Each b As VelerSoftware.SZC.Reference.TypeLibrary In VelerSoftware.SZC.Reference.TypeLibrary.Libraries
                ite = New ListViewItem(New String() {b.Name, b.Version, b.Path, "COM"})
                ite.Tag = False
                ComList.Add(ite)
            Next

            Resultat.Add(GacList)
            Resultat.Add(ComList)

            If .DirectoryExists(Application.StartupPath & "\Images") Then
                For Each Fichier As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Images", FileIO.SearchOption.SearchAllSubDirectories)
                    If My.Computer.FileSystem.GetFileInfo(Fichier).Extension.ToUpper = ".BMP" Then
                        Me.SZ_Initialisation_BackgroundWorker.ReportProgress(1, New Object() {Fichier, System.Drawing.Image.FromFile(Fichier, True)})
                    End If
                Next
            End If

            For Each plug As ClassPluginServices.Plugin In PLUGINS
                For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                    If act._ToolBoxImage IsNot Nothing Then Me.SZ_Initialisation_BackgroundWorker.ReportProgress(1, New Object() {act.GetType.FullName, act._ToolBoxImage})
                Next
            Next


            If My.Settings.Verifier_Mise_A_Jours AndAlso .FileExists(Application.StartupPath & "\Updater.exe") Then System.Diagnostics.Process.Start(Application.StartupPath & "\Updater.exe", "-silent")


        End With


        e.Result = Resultat
    End Sub

    Private Sub SZ_Initialisation_BackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SZ_Initialisation_BackgroundWorker.RunWorkerCompleted
        If PLUGINS.Count > 0 Then
            For Each Plug As ClassPluginServices.Plugin In PLUGINS
                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Plugin_Chargé"), Plug.PluginName, Plug.PluginVersion)))
            Next
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Plugins_Terminé"))))
        Else
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Aucun_Plugin_Chargé"))))
        End If


        ' Chargement de la boîte à outils
        ClassApplication.Charger_ToolBox_Concepteur_Fenetre(Nothing)
        ' Charger ToolBox Actions
        ClassApplication.Charger_ToolBox_Editeur_Fonctions(Nothing)
        DirectCast(Me.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).KryptonWrapLabel1.Visible = False


        'Dim builder As New System.Activities.Presentation.Metadata.AttributeTableBuilder()
        'For Each plug As ClassPluginServices.Plugin In PLUGINS
        '    If Not plug.Assembly Is Nothing Then
        '        For Each objType In plug.Assembly.GetTypes
        '            If objType.IsPublic Then
        '                If Not ((objType.Attributes And System.Reflection.TypeAttributes.Abstract) = System.Reflection.TypeAttributes.Abstract) Then
        '                    If objType.IsSubclassOf(GetType(VelerSoftware.Plugins3.Action)) Then
        '                        Dim attributes As System.ComponentModel.AttributeCollection = System.ComponentModel.TypeDescriptor.GetAttributes(objType)
        '                        builder.AddCustomAttributes(objType, DirectCast(attributes(GetType(System.ComponentModel.DesignerAttribute)), System.ComponentModel.DesignerAttribute))
        '                    End If
        '                End If
        '            End If
        '        Next
        '    End If
        'Next
        'System.Activities.Presentation.Metadata.MetadataStore.AddAttributeTable(builder.CreateTable())


        Dim dm As System.Activities.Core.Presentation.DesignerMetadata = New System.Activities.Core.Presentation.DesignerMetadata()
        dm.Register()



        Me.Reconnaissance_Vocal_KryptonRibbonGroupCheckBox.Checked = My.Settings.Activer_Reconnaissance_Vocale


        ' Références
        Add_Reference = New Ajouter_Reference
        If (Not e.Result Is Nothing) AndAlso (Not Add_Reference Is Nothing) Then
            With Add_Reference
                ' Gac
                For Each ite As ListViewItem In DirectCast(e.Result, Generic.List(Of Generic.List(Of ListViewItem)))(0)
                    .Net_ListView.Items.Add(ite)
                Next
                ' Com
                For Each ite As ListViewItem In DirectCast(e.Result, Generic.List(Of Generic.List(Of ListViewItem)))(1)
                    .Com_ListView.Items.Add(ite)
                Next

                DirectCast(e.Result, Generic.List(Of Generic.List(Of ListViewItem)))(0).Clear()
                DirectCast(e.Result, Generic.List(Of Generic.List(Of ListViewItem)))(1).Clear()

                'LV 1
                .listviewsorter_lv1.ListView = .Net_ListView
                .listviewsorter_lv1.ColumnComparerCollection(.Net_ListView.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv1.ColumnComparerCollection(.Net_ListView.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv1.ColumnComparerCollection(.Net_ListView.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv1.Sort(0)

                'LV 2
                .listviewsorter_lv2.ListView = .Com_ListView
                .listviewsorter_lv2.ColumnComparerCollection(.Com_ListView.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv2.ColumnComparerCollection(.Com_ListView.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv2.ColumnComparerCollection(.Com_ListView.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv2.Sort(0)

                'LV 3
                .listviewsorter_lv3.ListView = .Total_ListView
                .listviewsorter_lv3.ColumnComparerCollection(.Total_ListView.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv3.ColumnComparerCollection(.Total_ListView.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv3.ColumnComparerCollection(.Total_ListView.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv3.Sort(0)

                'LV 4
                .listviewsorter_lv4.ListView = .Projets_ListView
                .listviewsorter_lv4.ColumnComparerCollection(.Projets_ListView.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv4.ColumnComparerCollection(.Projets_ListView.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv4.ColumnComparerCollection(.Projets_ListView.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                .listviewsorter_lv4.Sort(0)

                .Ok = True
            End With
        End If

        If My.Settings.Autoriser_Envoyer_Informations AndAlso Not Me.SZ_Send_Informations_BackgroundWorker.IsBusy AndAlso CBool(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Certificated")) = False AndAlso (30 - DateDiff(DateInterval.Day, CDate(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("CertificateDate")), Now)) < 0 Then
            Dim key As Microsoft.Win32.RegistryKey
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
            key.SetValue("Certificated", True)
            Me.SZ_Send_Informations_BackgroundWorker.RunWorkerAsync(New DictionaryEntry("users", My.Computer.Info.OSFullName & Environment.NewLine & "Id : " & Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Id")))
        End If

        Me.SZ_Activation_BackgroundWorker.RunWorkerAsync()

        Me.SZ_Banned_User_BackgroundWorker.RunWorkerAsync()

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

    Private Sub SZ_Initialisation_BackgroundWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles SZ_Initialisation_BackgroundWorker.ProgressChanged
        With DirectCast(e.UserState, Object())
            DirectCast(Me.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ImageList1.Images.Add(.GetValue(0), .GetValue(1))
        End With
    End Sub

#End Region

#Region "SZ Send Informations"

    Private Sub SZ_Send_Informations_BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SZ_Send_Informations_BackgroundWorker.DoWork
        If VelerSoftware.SZVB.Windows.Core.IsConnected Then
            Dim data As String = Environment.MachineName & " - " & Microsoft.VisualBasic.Replace(Date.Today, "/", "-") & " - " & Microsoft.VisualBasic.Replace(TimeOfDay, ":", "-")
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\" & data & ".txt", DirectCast(e.Argument, DictionaryEntry).Value, False)

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\" & data & ".txt") Then
                Try
                    My.Computer.Network.UploadFile(Application.StartupPath & "\Temp\" & data & ".txt", "ftp://ftp.velersoftware.com/files/softwarezator/feedbacks/" & DirectCast(e.Argument, DictionaryEntry).Key & "/" & data & ".txt", "velersof", "DwxxeqXc")
                Catch
                End Try
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\" & data & ".txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        Else
            ' Throw New Exception("Computer is not connected to internet.")
        End If
    End Sub

    Private Sub SZ_Send_Informations_BackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SZ_Send_Informations_BackgroundWorker.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, e.Error.Message & Environment.NewLine & e.Error.StackTrace))
        Else
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, "Informations have been sent to Veler Software."))
        End If

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

#End Region

#Region "SZ Activation"

    Private Sub SZ_Activation_BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SZ_Activation_BackgroundWorker.DoWork
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\license.lic") AndAlso Not My.Settings.Edition = ClassApplication.Edition.Free Then
            ClassFichier.EncryptOrDecryptFile(Application.StartupPath & "\license.lic", Application.StartupPath & "\Temp\license.lic", ClassFichier.CreateKey("RU45O8GYFZ4R9OC8YO54OA89TC9O1YC2NO4YC42NO572OI3YTOC4N5425OY8U5Y29C045NY2O4IYCIOUCYESINGUCN3ITUYCIO43ZI"), ClassFichier.CreateIV("RU45O8GYFZ4R9OC8YO54OA89TC9O1YC2NO4YC42NO572OI3YTOC4N5425OY8U5Y29C045NY2O4IYCIOUCYESINGUCN3ITUYCIO43ZI"), ClassFichier.CryptoAction.ActionDecrypt)
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\license.lic") Then
                Dim lic As Class_Licence = Nothing
                Dim myFileStream As IO.Stream = IO.File.OpenRead(Application.StartupPath & "\Temp\license.lic")
                Dim deserializer As Runtime.Serialization.Formatters.Binary.BinaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                Try
                    lic = DirectCast(deserializer.Deserialize(myFileStream), Class_Licence)
                Catch ex As Exception
                    myFileStream.Close()
                End Try
                myFileStream.Close()
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\license.lic", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                If lic IsNot Nothing Then
                    Try
                        Dim key As Microsoft.Win32.RegistryKey
                        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
                        key.SetValue("Id", lic.CodeActivation)
                    Catch
                    End Try
                    If ClassApplication.Verify_License(lic.Nom, lic.Prénom, lic.Pays, lic.CodePostal, lic.Email, lic.Facture, lic.Edition, lic.CodeActivation) Then
                        If Not My.Settings.Edition = lic.Edition + 1 Then
                            My.Settings.Edition = lic.Edition + 1
                            e.Result = 3
                        End If
                        SZ_Est_Activé = True
                        Dim data As String = lic.Nom & " " & lic.Prénom & " - " & Environment.MachineName & " - " & Microsoft.VisualBasic.Replace(Date.Today, "/", "-") & " - " & Microsoft.VisualBasic.Replace(TimeOfDay, ":", "-")
                        Try
                            If Not My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man") AndAlso VelerSoftware.SZVB.Windows.Core.IsConnected Then
                                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\" & data & ".txt", "Nom : " & lic.Nom & Environment.NewLine & "Prénom : " & lic.Prénom & Environment.NewLine & "Pays : " & lic.Pays & Environment.NewLine & "Zip : " & lic.CodePostal & Environment.NewLine & "Email : " & lic.Email & Environment.NewLine & "Facture : " & lic.Facture & Environment.NewLine & "Edition : " & CInt(lic.Edition + 1) & Environment.NewLine & "Code : " & lic.CodeActivation & Environment.NewLine & "Version : " & My.Application.Info.Version.ToString() & Environment.NewLine & "Id : " & Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Id"), False)

                                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\" & data & ".txt") Then
                                    My.Computer.Network.UploadFile(Application.StartupPath & "\Temp\" & data & ".txt", "ftp://ftp.velersoftware.com/files/softwarezator/feedbacks/license/" & data & ".txt", "velersof", "DwxxeqXc")
                                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\" & data & ".txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                                    My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man", "True", False)
                                End If
                            End If
                        Catch ex As Exception
                            If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man") Then My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_send.man", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\" & data & ".txt") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\" & data & ".txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End Try
                        e.Result = 4
                    Else
                        e.Result = 2
                    End If
                End If
            End If

        Else
            If My.Settings.Edition = ClassApplication.Edition.Free Then
                e.Result = 4
            ElseIf Not My.Settings.Edition = ClassApplication.Edition.Free AndAlso Nombre_Utilisation_Restante <= 0 Then
                Dim __registration As Integer = 0
_registration:
                Try
                    My.Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man", 0, False)
                    My.Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").CreationTime = New Date(2009, 7, 14, 3, 39, 0)
                    My.Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").LastAccessTime = New Date(2009, 7, 14, 3, 39, 0)
                    My.Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").LastWriteTime = New Date(2009, 7, 14, 3, 39, 0)
                Catch ex As Exception
                    Threading.Thread.Sleep(CInt(Int((3000 - 1000 + 1) * Rnd() + 1000)))
                    If __registration = 2 Then Throw ex
                    GoTo _registration
                End Try
                e.Result = 0
            ElseIf Not My.Settings.Edition = ClassApplication.Edition.Free AndAlso Nombre_Utilisation_Restante > 0 Then
                e.Result = 1
            End If
        End If
    End Sub

    Private Sub SZ_Activation_BackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SZ_Activation_BackgroundWorker.RunWorkerCompleted
        Select Case CInt(e.Result)
            Case 0 ' fin de la démo
                Using frm As New Activation_Evaluation
                    frm.CommandLink3.Enabled = False
                    frm.Cancel_Button.Visible = True
                    If frm.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        Application.Exit()
                    End If
                End Using
            Case 1 ' démo
                SZ_Est_En_Version_Demo = True
                Using frm As New Activation_Evaluation
                    frm.ShowDialog()
                End Using
            Case 2 ' licence non valide
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = RM.GetString("Content56")
                    .MainInstruction = RM.GetString("MainInstruction16")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                ClassProjet.Fermer_Solution(True)
                Application.Exit()
            Case 3 ' mauvaise édition
                ClassProjet.Fermer_Solution(True)
                Application.Restart()
            Case 4 ' tout est bon
                Me.Activer_Licence_SZ_KryptonRibbonGroupButton.Enabled = False
        End Select

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

#End Region

#Region "SZ Banned User"

    Private Sub SZ_Banned_User_BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SZ_Banned_User_BackgroundWorker.DoWork
        If VelerSoftware.SZVB.Windows.Core.IsConnected Then
            Try
                My.Computer.Network.DownloadFile("http://files.velersoftware.com/softwarezator/updates/sz2012_banned.txt", Application.StartupPath & "\Temp\banned.txt")
            Catch
            End Try
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\banned.txt") Then
                Dim monStreamReader As New IO.StreamReader(Application.StartupPath & "\Temp\banned.txt")
                Dim ligne, app_id As String
                app_id = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Id")
                If Not app_id = "" AndAlso app_id IsNot Nothing Then
                    Do
                        ligne = monStreamReader.ReadLine()
                        If ligne = app_id Then
                            e.Result = True
                            Exit Do
                        End If
                    Loop Until ligne Is Nothing
                End If
                monStreamReader.Close()
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\banned.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        Else
            ' Throw New Exception("Computer is not connected to internet.")
        End If
    End Sub

    Private Sub SZ_Banned_User_BackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SZ_Banned_User_BackgroundWorker.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, e.Error.Message & Environment.NewLine & e.Error.StackTrace))
        Else
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, RM_Log.GetString("Utilisateur_Banni")))
        End If

        If e.Result = True Then
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Me
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityError
                .Content = RM.GetString("Utilisateur_Banni")
                .MainInstruction = RM.GetString("MainInstruction16")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            Application.Exit()
        End If

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

#End Region

#Region "Reconnaissance Vocale"

    Private SRE_ToolBoxItems As Generic.List(Of VelerSoftware.Plugins3.Action)

    Private Sub SRE_SpeechRecognized(ByVal sender As Object, ByVal e As Speech.Recognition.SpeechRecognizedEventArgs) Handles SRE.SpeechRecognized
        If Not My.Settings.Edition = ClassApplication.Edition.Free Then
            Dim oki, okiloop As Boolean
            Dim txt As String = e.Result.Text
            Dim txt2 As String
            Dim words As System.Collections.ObjectModel.ReadOnlyCollection(Of System.Speech.Recognition.RecognizedWordUnit) = e.Result.Words

            If Not txt = Nothing AndAlso My.Settings.Activer_Reconnaissance_Vocale AndAlso VelerSoftware.SZVB.NativeMethods.GetForegroundWindow() = Me.Handle.ToInt32 AndAlso words.Count > 2 Then

                If txt.ToLower.Contains("norris") OrElse txt.ToLower.Contains("boris") OrElse txt.ToLower.Contains("nourrissent") OrElse txt.ToLower.Contains("russe") OrElse txt.ToLower.Contains("maurice") Then
                    ' CHUK NORRIS    
                    DirectCast(Me.Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale).KryptonPanel1.Visible = True
                    If Not Me.Box_Reconnaissance_Vocale Is Nothing Then
                        If TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                            DirectCast(Me.Box_Reconnaissance_Vocale.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Reconnaissance_Vocale
                        ElseIf TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                            Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Reconnaissance vocale")
                        End If
                    End If
                Else
                    Me.ToolStripStatusLabel3.Text = ChrW(34) & txt & ChrW(34)

                    For i As Integer = 0 To words.Count - 1
                        If words(i).Text = RM.GetString("Voice_Recognisation_Word1") AndAlso words.Count - 1 > i AndAlso (words(i + 1).Text = RM.GetString("Voice_Recognisation_Word2") OrElse words(i + 1).Text = RM.GetString("Voice_Recognisation_Word3") OrElse words(i + 1).Text = RM.GetString("Voice_Recognisation_Word4") OrElse words(i + 1).Text = RM.GetString("Voice_Recognisation_Word5")) Then okiloop = True
                    Next

                    If okiloop Then
                        If My.Settings.Activer_Significations_Sonores Then
                            If My.Computer.FileSystem.FileExists(Environment.ExpandEnvironmentVariables("%SystemRoot%\Media\") & "Synthèse vocale désactivée.wav") Then
                                My.Computer.Audio.Play(Environment.ExpandEnvironmentVariables("%SystemRoot%\Media\") & "Synthèse vocale désactivée.wav", AudioPlayMode.Background)
                            ElseIf My.Computer.FileSystem.FileExists(Environment.ExpandEnvironmentVariables("%SystemRoot%\Media\") & "Speech Off.wav") Then
                                My.Computer.Audio.Play(Environment.ExpandEnvironmentVariables("%SystemRoot%\Media\") & "Speech Off.wav", AudioPlayMode.Background)
                            End If
                        End If

                        DirectCast(Me.Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale).Label1.Visible = False
                        DirectCast(Me.Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale).TextBox1.Text = Microsoft.VisualBasic.UCase(Microsoft.VisualBasic.Left(txt, 1)) & Microsoft.VisualBasic.Mid(Microsoft.VisualBasic.LCase(txt), 2, Microsoft.VisualBasic.Len(txt) - 1) & "."
                        Dim i As Integer = 0

                        SRE_ToolBoxItems = New Generic.List(Of VelerSoftware.Plugins3.Action)

                        txt2 = txt.ToLower.Replace(RM.GetString("Voice_Recognisation_Word1") & " " & RM.GetString("Voice_Recognisation_Word2"), Nothing).Replace(RM.GetString("Voice_Recognisation_Word1") & " " & RM.GetString("Voice_Recognisation_Word3"), Nothing).Replace(RM.GetString("Voice_Recognisation_Word1") & " " & RM.GetString("Voice_Recognisation_Word4"), Nothing).Replace(RM.GetString("Voice_Recognisation_Word1") & " " & RM.GetString("Voice_Recognisation_Word5"), Nothing)
                        txt2 = txt2.Trim(" ")
                        For Each plug As ClassPluginServices.Plugin In PLUGINS
                            For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                                If My.Settings.Langue = "en" Then
                                    If txt2.ToLower = "to " & act.DisplayName.ToLower AndAlso Not SRE_ToolBoxItems.Contains(act) Then oki = True : SRE_ToolBoxItems.Add(act) : Exit For
                                Else
                                    If txt2.ToLower = act.DisplayName.ToLower AndAlso Not SRE_ToolBoxItems.Contains(act) Then oki = True : SRE_ToolBoxItems.Add(act) : Exit For
                                End If
                            Next
                        Next

                        If Not oki Then
                            For Each plug As ClassPluginServices.Plugin In PLUGINS
                                For Each act As VelerSoftware.Plugins3.Action In plug.Actions

                                    For Each wrd As String In act.Voice_Recognition_Expressions_Dictionary
                                        If txt.ToLower.Contains(wrd.ToLower) AndAlso Not SRE_ToolBoxItems.Contains(act) Then oki = True : SRE_ToolBoxItems.Add(act)
                                    Next

                                Next
                            Next
                        End If


                        If Not oki Then
                            For Each plug As ClassPluginServices.Plugin In PLUGINS
                                For Each act As VelerSoftware.Plugins3.Action In plug.Actions

                                    For Each word As System.Speech.Recognition.RecognizedWordUnit In words
                                        i += 1
                                        If i > 2 Then
                                            For Each wrd As String In act.Voice_Recognition_Dictionary
                                                If wrd.ToLower = word.Text.ToLower AndAlso Not SRE_ToolBoxItems.Contains(act) Then SRE_ToolBoxItems.Add(act)
                                            Next
                                        End If
                                    Next

                                Next
                            Next
                        End If

                        If My.Settings.Autoriser_Envoyer_Informations AndAlso My.Settings.Autoriser_Donnees_Reconnaissances_Vocale AndAlso Not Me.SZ_Send_Informations_BackgroundWorker.IsBusy Then
                            Dim actions_list_string As String = ""
                            For i2 As Integer = 0 To SRE_ToolBoxItems.Count - 1
                                actions_list_string &= "- " & SRE_ToolBoxItems(i2).DisplayName & Environment.NewLine
                            Next
                            Me.SZ_Send_Informations_BackgroundWorker.RunWorkerAsync(New DictionaryEntry("voice_recognition", "Phrase : " & txt & Environment.NewLine & Environment.NewLine & "Resultat :" & Environment.NewLine & actions_list_string))
                        End If

                        Dim d As New delLoadToolBox(AddressOf SRE_SpeechRecognized_Load_ToolBox)
                        Me.Invoke(d)


                    End If
                End If
            End If
        End If
    End Sub

    Private Delegate Sub delLoadToolBox()

    Private Sub SRE_SpeechRecognized_Load_ToolBox()
        Dim newGroup As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode
        Dim newSubItem As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode
        Dim Nom_Group_Fonction As New Generic.List(Of String)
        Dim Uncategorised As String = RM.GetString("Uncategorised")

        With DirectCast(Me.Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale)

            .Fonctions_ToolBox.BeginUpdate()
            .Fonctions_ToolBox.Nodes.Clear()

            For Each act As VelerSoftware.Plugins3.Action In SRE_ToolBoxItems
                If act.Category = Nothing Then
                    If Not Nom_Group_Fonction.Contains(Uncategorised) Then
                        newGroup = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(Uncategorised)
                        Nom_Group_Fonction.Add(newGroup.Text)
                        .Fonctions_ToolBox.Nodes.Add(newGroup)
                    End If
                Else
                    If Not Nom_Group_Fonction.Contains(act.Category) Then
                        newGroup = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.Category)
                        Nom_Group_Fonction.Add(act.Category)
                        .Fonctions_ToolBox.Nodes.Add(newGroup)
                    End If
                End If
                newSubItem = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.DisplayName, act.GetType.FullName, act.GetType, act.FileHelp, act.DisplayName, act.Description)
                If act._ToolBoxImage Is Nothing Then
                    newSubItem.ImageIndex = 0
                    newSubItem.SelectedImageIndex = 0
                Else
                    .ImageList1.Images.Add(act._ToolBoxImage)
                    newSubItem.ImageIndex = .ImageList1.Images.Count - 1
                    newSubItem.SelectedImageIndex = .ImageList1.Images.Count - 1
                End If
                If act.Category = Nothing Then
                    .Fonctions_ToolBox.Nodes(Uncategorised).Nodes.Add(newSubItem)
                Else
                    .Fonctions_ToolBox.Nodes(act.Category).Nodes.Add(newSubItem)
                End If
            Next

            If .Fonctions_ToolBox.Nodes.Count = 0 Then
                newGroup = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(RM.GetString("Box_Boite_A_Outils_Aucun_Element"))
                .Fonctions_ToolBox.Nodes.Add(newGroup)
            End If

            .Fonctions_ToolBox.ExpandAll()
            .Fonctions_ToolBox.TreeViewNodeSorter = New VelerSoftware.SZC.TreeViewComparer.TreeViewComparer()
            .Fonctions_ToolBox.EndUpdate()

            If Not Me.Box_Reconnaissance_Vocale Is Nothing Then
                If TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                    DirectCast(Me.Box_Reconnaissance_Vocale.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Me.Box_Reconnaissance_Vocale
                ElseIf TypeOf Me.Box_Reconnaissance_Vocale.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                    Me.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Reconnaissance vocale")
                End If
            End If

        End With
    End Sub

#End Region

#Region "Débogueur"

    Friend Sub Lancer_Debugger()
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Temp\Building") Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Temp\Building")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Temp\Debugger") Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Temp\Debugger")
        End If

        Dim can_launch As Boolean = True
        For Each a As System.Diagnostics.Process In Process.GetProcesses
            If a.ProcessName = SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom Then
                can_launch = False
                Exit For
            End If
        Next
        If can_launch AndAlso My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")) Then
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Debugger\" & proj.Nom & ".vb", proj.VBGénéréParGénération, False, System.Text.Encoding.UTF8)
                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Building\" & proj.Nom & ".vb", proj.VBGénéréParGénération, False, System.Text.Encoding.UTF8)
            Next

            ' Initialisation du débogueur
            Dim procstartinfo As New ProcessStartInfo
            procstartinfo.FileName = My.Computer.FileSystem.CombinePath(SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Emplacement, SOLUTION.GetProject(SOLUTION.ProjetDemarrage).GenerateDirectory & "\" & SOLUTION.GetProject(SOLUTION.ProjetDemarrage).Nom & ".exe")

            Me.Débogueur = New VelerSoftware.SZC.Debugger.WindowsDebugger()

            Me.Débogueur.Start(procstartinfo)

            ' On récupère tous les points d'arrêts.
            Dim PointArrets As New Generic.List(Of VelerSoftware.SZC.Debugger.Debugger.Breakpoint)
            For Each pag As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonDockingManager1.Pages
                If pag.Controls.Count > 0 Then
                    If TypeOf pag.Controls(0) Is DocConcepteurFenetre Then
                        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                            ' Ajout des breakpoints
                            For Each key As KeyValuePair(Of Object, System.Activities.Debugger.SourceLocation) In DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).designerSourceLocationMapping
                                If DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).breakpointList.Contains(key.Value) Then
                                    With DirectCast(key.Key, VelerSoftware.Plugins3.Action)
                                        Try
                                            Select Case DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().GetBreakpointLocations(key.Value)
                                                Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded Or System.Activities.Presentation.Debug.BreakpointTypes.Enabled
                                                    PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocConcepteurFenetre).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, True, DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                                Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded
                                                    PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocConcepteurFenetre).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, False, DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                            End Select
                                        Catch
                                            PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocConcepteurFenetre).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, True, DirectCast(pag.Controls(0), DocConcepteurFenetre).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                        End Try
                                    End With
                                End If
                            Next
                        Next

                    ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions Then
                        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                            ' Ajout des breakpoints
                            For Each key As KeyValuePair(Of Object, System.Activities.Debugger.SourceLocation) In DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).designerSourceLocationMapping
                                If DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).breakpointList.Contains(key.Value) Then
                                    With DirectCast(key.Key, VelerSoftware.Plugins3.Action)
                                        Try
                                            Select Case DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().GetBreakpointLocations(key.Value)
                                                Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded Or System.Activities.Presentation.Debug.BreakpointTypes.Enabled
                                                    PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocEditeurFonctions).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, True, DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                                Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded
                                                    PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocEditeurFonctions).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, False, DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                            End Select
                                        Catch
                                            PointArrets.Add(New VelerSoftware.SZC.Debugger.Debugger.Breakpoint(DirectCast(pag.Controls(0), DocEditeurFonctions).NomCompletFichier, Application.StartupPath & "\Temp\Debugger\" & DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet & ".vb", DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1, .DisplayName, .id, 0, True, DirectCast(pag.Controls(0), DocEditeurFonctions).Nom_Projet, key.Value, Me.Débogueur.DebuggerCore))
                                        End Try
                                    End With
                                End If
                            Next
                        Next
                    End If
                End If
            Next

            ' On récupère la ligne de chaque actions pour les points d'arrêts
            Dim Monflux As IO.Stream
            Dim Maligne As IO.StreamReader
            Dim line As String
            Dim numero_line As Integer
            For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Debugger\" & proj.Nom & ".vb") Then
                    Monflux = IO.File.OpenRead(Application.StartupPath & "\Temp\Debugger\" & proj.Nom & ".vb")
                    Maligne = New IO.StreamReader(Monflux, System.Text.Encoding.UTF8)
                    Maligne.BaseStream.Seek(0, IO.SeekOrigin.Begin)
                    line = Nothing
                    numero_line = 0
                    While Maligne.Peek() > -1
                        numero_line += 1
                        Maligne.Peek()
                        line = Maligne.ReadLine()
                        If line.TrimStart(" ").StartsWith("'project:" & proj.Nom, StringComparison.OrdinalIgnoreCase) Then
                            For Each bre As VelerSoftware.SZC.Debugger.Debugger.Breakpoint In PointArrets
                                If bre.ActionID = line.Split("|")(3).Replace("actionid:", Nothing) Then
                                    bre.Line = numero_line + 1
                                    Exit For
                                End If
                            Next
                        End If
                    End While
                    Maligne.Close()
                End If
            Next

            ' Ajout des breakpoint au débogueur
            For Each bre As VelerSoftware.SZC.Debugger.Debugger.Breakpoint In PointArrets
                Me.Débogueur.DebuggerCore.Breakpoints.Add(bre)
            Next
            For Each bre As VelerSoftware.SZC.Debugger.Debugger.Breakpoint In Me.Débogueur.DebuggerCore.Breakpoints
                AddHandler bre.Hit, AddressOf Débogueur_BreakpointHit
            Next

            ' Configuration du débogueur
            Me.Débogueur.SelectProcess(Me.Débogueur.DebuggedProcess)

            AddHandler Me.Débogueur.DebuggedProcess.Paused, AddressOf Débogueur_Paused
            AddHandler Me.Débogueur.DebuggedProcess.Resumed, AddressOf Débogueur_Resumed
            AddHandler Me.Débogueur.DebuggedProcess.ExceptionThrown, AddressOf Débogueur_ExceptionThrown

            VelerSoftware.SZC.Debugger.Base.Debugging.DebuggerService.CurrentDebugger = Me.Débogueur
        End If
    End Sub

#Region "DebugStarted"

    Private Sub Débogueur_DebugStarted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Débogueur.DebugStarted
        With DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage)
            .TreeViewAdv1.Root.Children.Clear()
            .KryptonButton1.Enabled = False
            .KryptonButton1.Tag = Nothing
            .KryptonRichTextBox1.Text = ""
        End With

        With Me
            .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = True
            .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = True
            .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = True
            .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

            ClassApplication.Activer_Desactiver_Interface(False)
        End With
        Status_SZ = statu.Debuggage_En_Cours
    End Sub

#End Region

#Region "DebugStopped"

    Private Sub Débogueur_DebugStopped(ByVal sender As Object, e As System.EventArgs) Handles Débogueur.DebugStopped
        For Each pag As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonDockingManager1.Pages
            If pag.Controls.Count > 0 Then
                If TypeOf pag.Controls(0) Is DocConcepteurFenetre Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                        DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = Nothing
                    Next

                ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                        DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = Nothing
                    Next
                End If
            End If
        Next

        With DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage)
            .TreeViewAdv1.Root.Children.Clear()
            .KryptonButton1.Enabled = False
            .KryptonButton1.Tag = Nothing
            .KryptonRichTextBox1.Text = ""
        End With

        RemoveHandler Me.Débogueur.DebuggedProcess.Paused, AddressOf Débogueur_Paused
        RemoveHandler Me.Débogueur.DebuggedProcess.Resumed, AddressOf Débogueur_Resumed
        RemoveHandler Me.Débogueur.DebuggedProcess.ExceptionThrown, AddressOf Débogueur_ExceptionThrown
        For Each bre As VelerSoftware.SZC.Debugger.Debugger.Breakpoint In Me.Débogueur.DebuggerCore.Breakpoints
            RemoveHandler bre.Hit, AddressOf Débogueur_BreakpointHit
        Next

        With Me
            .Débogueur.DebuggerCore.Breakpoints.Clear()

            .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = False
            .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
            .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = False
            .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

            ClassApplication.Activer_Desactiver_Interface(True)

            VelerSoftware.SZC.Debugger.Base.Debugging.DebuggerService.CurrentDebugger = Nothing
            .Débogueur = Nothing
        End With

        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Debugger\" & proj.Nom & ".vb") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Debugger\" & proj.Nom & ".vb", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Building\" & proj.Nom & ".vb") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Building\" & proj.Nom & ".vb", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Next

        Status_SZ = statu.Normal

        GC.WaitForPendingFinalizers()
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
    End Sub

#End Region

#Region "Paused"

    Private Sub Débogueur_Paused(ByVal sender As Object, e As System.EventArgs)
        With Me
            .BringToFront()
            .Focus()
            .Activate()

            .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = True
            .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = False
            .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = True
            .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = True

            .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = False
            .Generer_KryptonRibbonGroupButton.Enabled = False
            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False

            If .Débogueur.DebuggedProcess Is Nothing OrElse .Débogueur.DebuggedProcess.IsRunning OrElse .Débogueur.DebuggedProcess.SelectedStackFrame Is Nothing Then
                DirectCast(.Box_Debogage.Controls(0), BoxDebogage).TreeViewAdv1.Root.Children.Clear()
                Exit Sub
            End If

            If Not .Box_Debogage Is Nothing Then
                If TypeOf .Box_Debogage.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                    DirectCast(.Box_Debogage.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = .Box_Debogage
                ElseIf TypeOf .Box_Debogage.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                    .KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Débogage")
                End If
            End If

            Try
                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).TreeViewAdv1.BeginUpdate()
                VelerSoftware.SZC.Debugger.TreeModel.Utils.DoEvents(.Débogueur.DebuggedProcess)
                VelerSoftware.SZC.Debugger.TreeModel.TreeViewVarNode.SetContentRecursive(.Débogueur.DebuggedProcess, DirectCast(.Box_Debogage.Controls(0), BoxDebogage).TreeViewAdv1, New VelerSoftware.SZC.Debugger.TreeModel.StackFrameNode(.Débogueur.DebuggedProcess.SelectedStackFrame, SOLUTION.GetProject(SOLUTION.ProjetDemarrage), .Débogueur).ChildNodes)
            Catch generatedExceptionName As VelerSoftware.SZC.Debugger.TreeModel.AbortedBecauseDebuggeeResumedException
            Catch generatedExceptionName As Exception
                If .Débogueur.DebuggedProcess Is Nothing OrElse .Débogueur.DebuggedProcess.HasExited Then
                    ' Process unexpectedly exited
                Else
                    ' DEBOG MODEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
                    MsgBox(generatedExceptionName.Message & Environment.NewLine & generatedExceptionName.StackTrace)
                End If
            Finally
                DirectCast(.Box_Debogage.Controls(0), BoxDebogage).TreeViewAdv1.EndUpdate()
            End Try


            'If Me.Débogueur.DebuggedProcess.SelectedStackFrame.Thread.CurrentException IsNot Nothing Then
            'yield Return New ExpressionNode(Nothing, "__exception", New IdentifierExpression("__exception"))
            'End If
        End With
    End Sub

#End Region

#Region "Resumed"

    Private Sub Débogueur_Resumed(ByVal sender As Object, e As System.EventArgs)
        For Each pag As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonDockingManager1.Pages
            If pag.Controls.Count > 0 Then
                If TypeOf pag.Controls(0) Is DocConcepteurFenetre Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                        DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = Nothing
                    Next

                ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                        DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = Nothing
                    Next
                End If
            End If
        Next

        With DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage)
            .TreeViewAdv1.Root.Children.Clear()
            .KryptonButton1.Enabled = False
            .KryptonButton1.Tag = Nothing
            .KryptonRichTextBox1.Text = ""
        End With

        With Me
            .Debogage_Arreter_KryptonRibbonGroupButton7.Enabled = True
            .Debogage_Pause_KryptonRibbonGroupButton6.Enabled = True
            .Debogage_Redemarrer_KryptonRibbonGroupButton1.Enabled = True
            .Debogage_Reprendre_KryptonRibbonGroupButton9.Enabled = False

            .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = False
            .Generer_KryptonRibbonGroupButton.Enabled = False
            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = False
        End With
    End Sub

#End Region

#Region "ExceptionThrown"

    Private Sub Débogueur_ExceptionThrown(ByVal sender As Object, e As VelerSoftware.SZC.Debugger.Debugger.ExceptionEventArgs)
        Dim stacktraceBuilder As New System.Text.StringBuilder()
        Dim Monflux As IO.Stream
        Dim Maligne As IO.StreamReader
        Dim line As String
        Dim numero_line As Integer
        Dim proj As VelerSoftware.SZVB.Projet.Projet
        Dim NomCompletFichier As String
        Dim StackTrace As String = ""
        Dim NomProj As String = ""
        Dim NuméroLineErreur As Integer

        ' Need to intercept now so that we can evaluate properties
        If e.Process.SelectedThread.InterceptCurrentException() Then
            With stacktraceBuilder
                .AppendLine("Type : " & e.Exception.Type)
                .AppendLine("")
                .AppendLine("Message : " & e.Exception.Message)
                .AppendLine("")
                .AppendLine("Trace : " & e.Process.SelectedThread.GetStackTrace())
            End With


            Try


                For Each stackFrame As VelerSoftware.SZC.Debugger.Debugger.StackFrame In e.Process.SelectedThread.GetCallstack(100)
                    Dim loc As VelerSoftware.SZC.Debugger.Debugger.SourcecodeSegment = stackFrame.NextStatement
                    If loc IsNot Nothing Then
                        NomProj = loc.Filename.Split("\")(loc.Filename.Split("\").Length - 1).Replace(".vb", Nothing)
                        NuméroLineErreur = loc.StartLine
                        Exit For
                    End If
                Next

                If Not NomProj = Nothing Then
                    ' On récupère la ligne de chaque actions pour les points d'arrêts
                    proj = SOLUTION.GetProject(NomProj)

                    If proj IsNot Nothing Then

                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Debugger\" & NomProj & ".vb") Then
                            Monflux = IO.File.OpenRead(Application.StartupPath & "\Temp\Debugger\" & NomProj & ".vb")
                            Maligne = New IO.StreamReader(Monflux, System.Text.Encoding.UTF8)
                            Maligne.BaseStream.Seek(0, IO.SeekOrigin.Begin)
                            line = Nothing
                            numero_line = 0
                            While Maligne.Peek() > -1
                                numero_line += 1
                                Maligne.Peek()

                                If numero_line = NuméroLineErreur AndAlso Not line = Nothing AndAlso line.TrimStart(" ").StartsWith("'project:" & NomProj, StringComparison.OrdinalIgnoreCase) Then
                                    NomCompletFichier = line.Split("|")(2).Replace("file:", Nothing)
                                    If My.Computer.FileSystem.FileExists(NomCompletFichier) Then
                                        ' Ouverture du fichier
                                        Dim files() As String = New String(-1) {}
                                        Dim Safefiles() As String = New String(-1) {}
                                        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

                                        If NomCompletFichier = proj.Emplacement & "\ApplicationEvents.szc" Then
                                            ReDim Preserve files(files.Length)
                                            ReDim Preserve Safefiles(Safefiles.Length)
                                            ReDim Preserve projects(projects.Length)
                                            files(files.Length - 1) = "APPLICATIONEVENTS"
                                            Safefiles(Safefiles.Length - 1) = "APPLICATIONEVENTS"
                                            projects(projects.Length - 1) = SOLUTION.GetProject(NomProj)
                                        Else
                                            ReDim Preserve files(files.Length)
                                            ReDim Preserve Safefiles(Safefiles.Length)
                                            ReDim Preserve projects(projects.Length)
                                            files(files.Length - 1) = NomCompletFichier
                                            Safefiles(Safefiles.Length - 1) = My.Computer.FileSystem.GetName(NomCompletFichier)
                                            projects(projects.Length - 1) = SOLUTION.GetProject(NomProj)
                                        End If

                                        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
                                    End If

                                    If ClassApplication.Determiner_Si_Document_Deja_Ouvert(NomCompletFichier) Then

                                        If TypeOf Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0) Is DocConcepteurFenetre Then
                                            DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedPage = DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocConcepteurFenetre).Editeur_Fonction_KryptonPage
                                            For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                                                If Tabs.Text = line.Split("|")(1).Replace("function:", Nothing) Then
                                                    DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage = Tabs
                                                    Application.DoEvents()  ' on laisse se charger le Workflow
                                                    If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl AndAlso DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                                        Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), line.Split("|")(3).Replace("actionid:", Nothing), False, False)
                                                        If Act IsNot Nothing Then
                                                            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\", Act.FileHelp)) Then
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Tag = Act.FileHelp
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Enabled = True
                                                            Else
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Enabled = False
                                                            End If
                                                            DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).designerSourceLocationMapping(Act)
                                                            Exit For
                                                        End If
                                                    End If
                                                    Exit For
                                                End If
                                            Next

                                        ElseIf TypeOf Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0) Is DocEditeurFonctions Then
                                            For Each Tabs As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                                                If Tabs.Text = line.Split("|")(2).Replace("file:", Nothing) Then
                                                    DirectCast(Me.KryptonDockableWorkspace1.PageForUniqueName(NomCompletFichier).Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage = Tabs
                                                    Application.DoEvents()  ' on laisse se charger le Workflow
                                                    If TypeOf Tabs.Controls(0) Is DocEditeurFonctionsUserControl AndAlso DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
                                                        Dim Act As VelerSoftware.Plugins3.Action = ClassApplication.SearchAction(DirectCast(DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren), line.Split("|")(3).Replace("actionid:", Nothing), False, False)
                                                        If Act IsNot Nothing Then
                                                            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Help\" & My.Settings.Langue & "\Plugins\", Act.FileHelp)) Then
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Tag = Act.FileHelp
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Enabled = True
                                                            Else
                                                                DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Enabled = False
                                                            End If
                                                            DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = DirectCast(Tabs.Controls(0), DocEditeurFonctionsUserControl).designerSourceLocationMapping(Act)
                                                            Exit For
                                                        End If
                                                    End If
                                                    Exit For
                                                End If
                                            Next
                                        End If

                                    End If

                                End If

                                line = Maligne.ReadLine()
                            End While
                            Maligne.Close()
                        End If

                    End If

                End If





            Catch generatedExceptionName As VelerSoftware.SZC.Debugger.Debugger.GetValueException
                StackTrace = e.Process.SelectedThread.GetStackTrace()
            End Try
            stacktraceBuilder.Append(StackTrace)
        Else
            ' For example, happens on stack overflow
            stacktraceBuilder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content51")))
            Try
                stacktraceBuilder.AppendLine(e.Exception.ToString())
                stacktraceBuilder.Append(e.Process.SelectedThread.GetStackTrace())
            Catch ex As Exception
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content51"))
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End Try
        End If


        DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonRichTextBox1.Text = stacktraceBuilder.ToString()


    End Sub

#End Region

#Region "Breakpoint Hit"

    Private Sub Débogueur_BreakpointHit(ByVal sender As Object, ByVal e As VelerSoftware.SZC.Debugger.Debugger.BreakpointEventArgs)
        If ClassApplication.Determiner_Si_Document_Deja_Ouvert(e.Breakpoint.SZW_SZC_FileName) Then

            Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Me.KryptonDockableWorkspace1.PageForUniqueName(e.Breakpoint.SZW_SZC_FileName)
            If pag IsNot Nothing Then

                If TypeOf pag.Controls(0) Is DocConcepteurFenetre Then
                    DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator1.SelectedPage = DirectCast(pag.Controls(0), DocConcepteurFenetre).Editeur_Fonction_KryptonPage
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                        If DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1 = e.Breakpoint.FunctionName Then
                            DirectCast(pag.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage = TAB
                            DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = e.Breakpoint.SourceLocation
                            Exit For
                        End If
                    Next

                ElseIf TypeOf pag.Controls(0) Is DocEditeurFonctions Then
                    For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(pag.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                        If DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.Action).Param1 = e.Breakpoint.FunctionName Then
                            DirectCast(pag.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage = TAB
                            DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).DebuggerService.CurrentLocation = e.Breakpoint.SourceLocation
                            Exit For
                        End If
                    Next

                End If

                Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Me.KryptonDockableWorkspace1.CellForPage(pag)
                Me.KryptonDockableWorkspace1.ActiveCell = cell
                cell.SelectedPage = pag

            End If

        End If

        DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Enabled = False
        DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonButton1.Tag = Nothing
        DirectCast(Me.Box_Debogage.Controls(0), BoxDebogage).KryptonRichTextBox1.Text = ""
    End Sub

#End Region

#End Region

#Region "Autre"

    Friend Sub FinGeneration()
        With Me
            .Controls.RemoveByKey("GenerationComponent1")
            .GenerationComponent1.Dispose()
            .GenerationComponent1 = Nothing

            .GenerationComponent1 = New GenerationComponent
            .GenerationComponent1.Timer1.Stop()
            .GenerationComponent1.Name = "GenerationComponent1"
            .GenerationComponent1.Dock = DockStyle.Fill
            .GenerationComponent1.Visible = False
            .Controls.Add(.GenerationComponent1)
            .GenerationComponent1.Solution_Windows7ProgressBar.ContainerControl = Me

            GC.WaitForPendingFinalizers()
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
        End With
    End Sub

#End Region

End Class
