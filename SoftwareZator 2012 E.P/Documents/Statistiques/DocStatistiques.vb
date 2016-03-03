''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocStatistiques

#Region "Propriétés"

#Region "Nom du projet"

    Private _Nom_Projet As String = Nothing

    Public Property Nom_Projet() As String
        Get
            Return _Nom_Projet
        End Get
        Set(ByVal value As String)
            _Nom_Projet = value
        End Set
    End Property

#End Region ' Nom du projet

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Statistiques

    Public ReadOnly Property TypeFichier() As VelerSoftware.SZVB.Projet.Document.Types
        Get
            Return _TypeFichier
        End Get
    End Property

#End Region ' Type du document

#Region "Annuler"

    Private _Annuler As Boolean = False

    Public Property Annuler() As Boolean
        Get
            Return _Annuler
        End Get
        Set(ByVal value As Boolean)
            _Annuler = value
        End Set
    End Property

#End Region ' Détermine si l'on peu annuler ou pas

#Region "Rétablir"

    Private _Retablir As Boolean = False

    Public Property Retablir() As Boolean
        Get
            Return _Retablir
        End Get
        Set(ByVal value As Boolean)
            _Retablir = value
        End Set
    End Property

#End Region ' Détermine si l'on peu rétablir ou pas

#Region "Finit de se chargé"

    Private _FinishLoad As Boolean = False

    Public Property FinishLoad() As Boolean
        Get
            Return _FinishLoad
        End Get
        Set(ByVal value As Boolean)
            _FinishLoad = value
        End Set
    End Property

#End Region ' Détermine si l'éditeur a finit d'être chargé ou modifié

#Region "Modifié"

    Private _Modifier As Boolean = False

    Public Property Modifier() As Boolean
        Get
            Return _Modifier
        End Get
        Set(ByVal value As Boolean)
            _Modifier = value
        End Set
    End Property

#End Region ' Détermine si l'éditeur a été modifié ou pas

#End Region

    Public Sub DocumentModifier()
        If FinishLoad And Annuler And Retablir Then
            Modifier = True
            If Not Me.Nom_Projet = "" Then
                SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
            End If
        Else
        End If
        If Modifier Then
            If Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Nom_Projet & "*"
            End If
        End If
    End Sub

    Public Function Charger(ByVal Generation As Boolean) As Boolean
        Dim RESULTAT As Boolean = True
        Dim ite As ListViewItem

        With Me
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
            If Not proj Is Nothing Then

                Me.SuspendLayout()

                If Generation Then
                    .Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Clear()
                    .Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Clear()

                    If proj.Statistiques.Count > 0 Then
                        For Each stat As VelerSoftware.SZVB.Projet.Statistique In proj.Statistiques
                            Select Case stat.TypeValue
                                Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess
                                    .Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(stat.XValue, stat.YValue))
                                Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail
                                    .Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(stat.XValue, stat.YValue))
                            End Select
                        Next
                    Else
                        .Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(Date.Today.ToOADate, 0))
                    End If

                Else
                    .TableLayoutPanel1.Visible = False
                    .TableLayoutPanel1.Dock = DockStyle.Fill

                    Nbr_Fonctions = 0
                    Nbr_Controls = 0

                    If Not .BackgroundWorker1.IsBusy Then
                        .BackgroundWorker1.RunWorkerAsync(proj)
                    End If
                End If

                .Nom_KryptonLabel.Text = proj.Nom : If .Nom_KryptonLabel.Text = Nothing Then .Nom_KryptonLabel.Text = "{" & RM.GetString("Nothing_Text") & "}"
                Select Case proj.Type
                    Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                        .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_17")
                    Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                        .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_18")
                    Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                        .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_19")
                End Select
                .Fenêtre_Demarrage_KryptonLabel6.Text = proj.FormStart : If .Fenêtre_Demarrage_KryptonLabel6.Text = Nothing Then .Fenêtre_Demarrage_KryptonLabel6.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Ecran_Demarrage_KryptonLabel9.Text = proj.SplashScreen : If .Ecran_Demarrage_KryptonLabel9.Text = Nothing Then .Ecran_Demarrage_KryptonLabel9.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Style_Visual_KryptonLabel11.Text = proj.StyleXP.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                .Instance_KryptonLabel13.Text = proj.Instance.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                .Enregistrer_Settings_KryptonLabel15.Text = proj.MySettings.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                Select Case proj.ShutMode
                    Case VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose
                        .Mode_Arrête_KryptonLabel17.Text = RM.GetString("Statistics_Mode_Arret").Split(Environment.NewLine)(1).Substring(1)
                    Case VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses
                        .Mode_Arrête_KryptonLabel17.Text = RM.GetString("Statistics_Mode_Arret").Split(Environment.NewLine)(0)
                End Select
                If My.Computer.FileSystem.FileExists(proj.Emplacement & "\icon.ico") Then
                    Dim fs As IO.FileStream = New IO.FileStream(proj.Emplacement & "\icon.ico", IO.FileMode.Open)
                    .PictureBox1.Image = VelerSoftware.SZVB.Windows.Core.GetBitmapFromIcon(New Icon(fs))
                    fs.Close()
                    fs.Dispose()
                End If
                .Titre_KryptonLabel22.Text = proj.Assembly_Title : If .Titre_KryptonLabel22.Text = Nothing Then .Titre_KryptonLabel22.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Description_KryptonLabel24.Text = proj.Assembly_Description : If .Description_KryptonLabel24.Text = Nothing Then .Description_KryptonLabel24.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Produit_KryptonLabel28.Text = proj.Assembly_Product : If .Produit_KryptonLabel28.Text = Nothing Then .Produit_KryptonLabel28.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Societe_KryptonLabel26.Text = proj.Assembly_Socity : If .Societe_KryptonLabel26.Text = Nothing Then .Societe_KryptonLabel26.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Copyright_KryptonLabel30.Text = proj.Assembly_Copyright : If .Copyright_KryptonLabel30.Text = Nothing Then .Copyright_KryptonLabel30.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Marque_KryptonLabel36.Text = proj.Assembly_Mark : If .Marque_KryptonLabel36.Text = Nothing Then .Marque_KryptonLabel36.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Version_Fichier_KryptonLabel32.Text = proj.Assembly_FileVersion : If .Version_Fichier_KryptonLabel32.Text = Nothing Then .Version_Fichier_KryptonLabel32.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Version_Assembly_KryptonLabel34.Text = proj.Assembly_AssemblyVersion : If .Version_Assembly_KryptonLabel34.Text = Nothing Then .Version_Assembly_KryptonLabel34.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Dossier_Generation_KryptonLabel39.Text = proj.GenerateDirectory : If .Dossier_Generation_KryptonLabel39.Text = Nothing Then .Dossier_Generation_KryptonLabel39.Text = "{" & RM.GetString("Nothing_Text") & "}"
                .Optimiser_KryptonLabel41.Text = proj.Optimize.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                Select Case proj.Cpu
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.x86
                        .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(0)
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.x64
                        .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(1).Substring(1)
                    Case VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu
                        .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(2).Substring(1)
                End Select
                Select Case proj.ObfuscationLevel
                    Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Low
                        .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(0)
                    Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal
                        .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(1).Substring(1)
                    Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.High
                        .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(2).Substring(1)
                End Select
                ' Références
                .References_ListView1.Items.Clear()
                For Each a As VelerSoftware.SZVB.Projet.Reference In proj.References
                    If Not a Is Nothing Then
                        ite = New ListViewItem
                        ite.Text = a.Name
                        ite.SubItems.Add(a.Version)
                        ite.SubItems.Add(a.Copy.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                        ite.SubItems.Add(a.FullName)
                        ite.ToolTipText = a.Location
                        ite.Tag = a.IsProject
                        If (Not a.IsProject) AndAlso (a.Assembly Is Nothing) Then
                            ite.ImageKey = "Warning"
                        End If
                        .References_ListView1.Items.Add(ite)
                    End If
                Next
                ' Paramètres
                .Settings_ListView2.Items.Clear()
                For Each a As String In proj.Parametres
                    If Not a = Nothing Then
                        ite = New ListViewItem
                        ite.Text = a
                        ite.Name = a
                        .Settings_ListView2.Items.Add(ite)
                    End If
                Next
                ' Fichiers VB.Net
                .VB_ListView4.Items.Clear()
                For Each a As String In proj.Fichiers_VBNet
                    If Not a = Nothing Then
                        ite = New ListViewItem
                        ite.Text = a
                        ite.Name = a
                        .VB_ListView4.Items.Add(ite)
                    End If
                Next
                ' Ressources
                .Resx_ListView3.Items.Clear()
                For Each a As VelerSoftware.SZVB.Projet.Ressource In proj.Ressources
                    If Not a Is Nothing Then
                        ite = New ListViewItem
                        ite.Text = a.Name
                        ite.Name = a.Name
                        ite.Tag = a.Value
                        If a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Texte Then
                            ite.ImageKey = "TXT"
                        ElseIf a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Image Then
                            ite.ImageKey = "IMG"
                        ElseIf a.Type = VelerSoftware.SZVB.Projet.Ressource.Types.Fichier Then
                            ite.ImageKey = "FILE"
                        End If
                        .Resx_ListView3.Items.Add(ite)
                    End If
                Next
                ' variables
                .Variables_ListView.Items.Clear()
                For Each var As VelerSoftware.SZVB.Projet.Variable In proj.Variables
                    ite = New ListViewItem
                    With ite
                        .Name = var.Name
                        .Text = var.Name
                        .SubItems.Add(var.Array.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                        .SubItems.Add(var.Description)
                        .SubItems.Add(var.NullAtStart.ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                        If var.Group = Nothing Then
                            .Group = Me.Variables_ListView.Groups(0)
                        Else
                            If Me.Variables_ListView.Groups(var.Group) Is Nothing Then
                                Me.Variables_ListView.Groups.Add(var.Group, var.Group)
                            End If
                            .Group = Me.Variables_ListView.Groups(var.Group)
                        End If
                        Me.Variables_ListView.Items.Add(ite)
                    End With
                Next
                VelerSoftware.SZC.Windows.User32.SetWindowTheme(.Variables_ListView.Handle, "explorer", Nothing)
                VelerSoftware.SZC.Windows.User32.SendMessage(.Variables_ListView.Handle, 4096 + 54, 65536, 65536)
                'LV 1
                listviewsorter_lv5.ListView = .Variables_ListView
                listviewsorter_lv5.ColumnComparerCollection(.Variables_ListView.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                listviewsorter_lv5.ColumnComparerCollection(.Variables_ListView.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                listviewsorter_lv5.ColumnComparerCollection(.Variables_ListView.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
                listviewsorter_lv5.Sort(0)



                Me.ResumeLayout()

            Else
                RESULTAT = False
            End If

        End With

        Return RESULTAT
    End Function

    Public Function Charger(ByVal file_name As String) As Boolean
        Dim RESULTAT As Boolean = True
        Dim XmlRead As Xml.XmlTextReader ' Lecture de XML 
        Dim ite As ListViewItem

        If My.Computer.FileSystem.FileExists(file_name) Then

            With Me

                .SuspendLayout()

                ' Teste de la version de la solution
                XmlRead = New Xml.XmlTextReader(file_name)
                Do While XmlRead.Read()
                    Select Case XmlRead.NodeType
                        Case Xml.XmlNodeType.Element
                            Select Case XmlRead.Name
                                Case "SZStatistic" ' Solution
                                    If XmlRead.GetAttribute("ToolsVersion") >= "3.1" Then ' Projet plus récent que SZ 2012
                                        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                        With vd
                                            .Owner = Nothing
                                            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityWarning
                                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content5"), XmlRead.GetAttribute("ToolsVersion"), Application.ProductVersion, My.Application.Info.Title, XmlRead.GetAttribute("Name"))
                                            .MainInstruction = RM.GetString("MainInstruction5")
                                            .WindowTitle = My.Application.Info.Title
                                            .Show()
                                        End With
                                        RESULTAT = False
                                        Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Le projet n'a pas été chargé car il est incompatible avec ce logiciel.")))
                                        Return RESULTAT
                                        Exit Function
                                    Else ' Projet SZ 2012
                                        Exit Do
                                    End If
                            End Select
                    End Select
                Loop
                XmlRead.Close()

                ' Ouverture de la solution
                XmlRead = New Xml.XmlTextReader(file_name)
                Do While XmlRead.Read()
                    Select Case XmlRead.NodeType
                        Case Xml.XmlNodeType.Element
                            Select Case XmlRead.Name
                                Case "SZStatistic" ' Solution
                                    .Nom_KryptonLabel.Text = XmlRead.GetAttribute("Name") : If .Nom_KryptonLabel.Text = Nothing Then .Nom_KryptonLabel.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Type" ' Type de projet
                                    Select Case DirectCast(CInt(XmlRead.GetAttribute("value")), VelerSoftware.SZVB.Projet.Projet.Types)
                                        Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows
                                            .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_17")
                                        Case VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole
                                            .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_18")
                                        Case VelerSoftware.SZVB.Projet.Projet.Types.BibliothequeFonctions
                                            .Type_KryptonLabel3.Text = RM.GetString("Dock_Explorateur_Solution_Proprietes_19")
                                    End Select
                                Case "ShutMode" ' Mode d'arrêt
                                    Select Case DirectCast(CInt(XmlRead.GetAttribute("value")), VelerSoftware.SZVB.Projet.Projet.ShutModes)
                                        Case VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterAllFormsClose
                                            .Mode_Arrête_KryptonLabel17.Text = RM.GetString("Statistics_Mode_Arret").Split(Environment.NewLine)(1).Substring(1)
                                        Case VelerSoftware.SZVB.Projet.Projet.ShutModes.AfterMainFormCloses
                                            .Mode_Arrête_KryptonLabel17.Text = RM.GetString("Statistics_Mode_Arret").Split(Environment.NewLine)(0)
                                    End Select
                                Case "FormStart" ' fenêtre de démarrage du projet
                                    .Fenêtre_Demarrage_KryptonLabel6.Text = XmlRead.GetAttribute("value") : If .Fenêtre_Demarrage_KryptonLabel6.Text = Nothing Then .Fenêtre_Demarrage_KryptonLabel6.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "SplashScreen" ' écran de démarrage du projet
                                    .Ecran_Demarrage_KryptonLabel9.Text = XmlRead.GetAttribute("value") : If .Ecran_Demarrage_KryptonLabel9.Text = Nothing Then .Ecran_Demarrage_KryptonLabel9.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "StyleXP" ' StyleXP
                                    .Style_Visual_KryptonLabel11.Text = CBool(XmlRead.GetAttribute("value")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                                Case "Instance" ' Instance
                                    .Instance_KryptonLabel13.Text = CBool(XmlRead.GetAttribute("value")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                                Case "MySettings" ' Enregistrer les paramètres
                                    .Enregistrer_Settings_KryptonLabel15.Text = CBool(XmlRead.GetAttribute("value")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                                Case "Assembly.Title" ' Assembly.Title
                                    .Titre_KryptonLabel22.Text = XmlRead.GetAttribute("value") : If .Titre_KryptonLabel22.Text = Nothing Then .Titre_KryptonLabel22.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.Description" ' Assembly.Description
                                    .Description_KryptonLabel24.Text = XmlRead.GetAttribute("value") : If .Description_KryptonLabel24.Text = Nothing Then .Description_KryptonLabel24.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.Socity" ' Assembly.Socity
                                    .Societe_KryptonLabel26.Text = XmlRead.GetAttribute("value") : If .Societe_KryptonLabel26.Text = Nothing Then .Societe_KryptonLabel26.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.Product" ' Assembly.Product
                                    .Produit_KryptonLabel28.Text = XmlRead.GetAttribute("value") : If .Produit_KryptonLabel28.Text = Nothing Then .Produit_KryptonLabel28.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.Copyright" ' Assembly.Copyright
                                    .Copyright_KryptonLabel30.Text = XmlRead.GetAttribute("value") : If .Copyright_KryptonLabel30.Text = Nothing Then .Copyright_KryptonLabel30.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.FileVersion" ' Assembly.FileVersion
                                    .Version_Fichier_KryptonLabel32.Text = XmlRead.GetAttribute("value") : If .Version_Fichier_KryptonLabel32.Text = Nothing Then .Version_Fichier_KryptonLabel32.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.AssemblyVersion" ' Assembly.AssemblyVersion
                                    .Version_Assembly_KryptonLabel34.Text = XmlRead.GetAttribute("value") : If .Version_Assembly_KryptonLabel34.Text = Nothing Then .Version_Assembly_KryptonLabel34.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Assembly.Mark" ' Assembly.Mark
                                    .Marque_KryptonLabel36.Text = XmlRead.GetAttribute("value") : If .Marque_KryptonLabel36.Text = Nothing Then .Marque_KryptonLabel36.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "GenerateDirectory" ' GenerateDirectory
                                    .Dossier_Generation_KryptonLabel39.Text = XmlRead.GetAttribute("value") : If .Dossier_Generation_KryptonLabel39.Text = Nothing Then .Dossier_Generation_KryptonLabel39.Text = "{" & RM.GetString("Nothing_Text") & "}"
                                Case "Optimize" ' Optimize
                                    .Optimiser_KryptonLabel41.Text = CBool(XmlRead.GetAttribute("value")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text"))
                                Case "Cpu" ' Cpu
                                    Select Case DirectCast(CInt(XmlRead.GetAttribute("value")), VelerSoftware.SZVB.Projet.Projet.Cpus)
                                        Case VelerSoftware.SZVB.Projet.Projet.Cpus.x86
                                            .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(0)
                                        Case VelerSoftware.SZVB.Projet.Projet.Cpus.x64
                                            .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(1).Substring(1)
                                        Case VelerSoftware.SZVB.Projet.Projet.Cpus.AnyCpu
                                            .CPU_KryptonLabel43.Text = RM.GetString("Statistics_CPU").Split(Environment.NewLine)(2).Substring(1)
                                    End Select
                                Case "ObfuscationLevel" ' ObfuscationLevel
                                    Select Case DirectCast(CInt(XmlRead.GetAttribute("value")), VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels)
                                        Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Low
                                            .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(0)
                                        Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.Normal
                                            .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(1).Substring(1)
                                        Case VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels.High
                                            .ObfuscationLevel_KryptonLabel.Text = RM.GetString("Statistics_Obfuscation").Split(Environment.NewLine)(2).Substring(1)
                                    End Select
                                Case "Setting" ' Paramètres
                                    If Not XmlRead.GetAttribute("name") = Nothing Then
                                        ite = New ListViewItem
                                        ite.Text = XmlRead.GetAttribute("name")
                                        ite.Name = ite.Name
                                        .Settings_ListView2.Items.Add(ite)
                                    End If
                                Case "VBNet_File" ' Fichier VB.Net                    
                                    If Not XmlRead.GetAttribute("name") = Nothing Then
                                        ite = New ListViewItem
                                        ite.Text = XmlRead.GetAttribute("name")
                                        ite.Name = ite.Name
                                        .VB_ListView4.Items.Add(ite)
                                    End If
                                Case "Variable" ' Variable
                                    ite = New ListViewItem
                                    With ite
                                        .Name = XmlRead.GetAttribute("name")
                                        .Text = .Name
                                        .SubItems.Add(CBool(XmlRead.GetAttribute("array")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                        .SubItems.Add(XmlRead.GetAttribute("description"))
                                        .SubItems.Add(CBool(IIf(XmlRead.GetAttribute("null") = "", "False", XmlRead.GetAttribute("null"))).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                        If XmlRead.GetAttribute("group") = Nothing Then
                                            .Group = Me.Variables_ListView.Groups(0)
                                        Else
                                            If Me.Variables_ListView.Groups(XmlRead.GetAttribute("group")) Is Nothing Then
                                                Me.Variables_ListView.Groups.Add(XmlRead.GetAttribute("group"), XmlRead.GetAttribute("group"))
                                            End If
                                            .Group = Me.Variables_ListView.Groups(XmlRead.GetAttribute("group"))
                                        End If
                                        Me.Variables_ListView.Items.Add(ite)
                                    End With
                                Case "Resource" ' Ressource
                                    ite = New ListViewItem
                                    ite.Text = XmlRead.GetAttribute("name")
                                    ite.Name = ite.Text
                                    ite.Tag = XmlRead.GetAttribute("value")
                                    If CType(XmlRead.GetAttribute("type"), VelerSoftware.SZVB.Projet.Ressource.Types) = VelerSoftware.SZVB.Projet.Ressource.Types.Texte Then
                                        ite.ImageKey = "TXT"
                                    ElseIf CType(XmlRead.GetAttribute("type"), VelerSoftware.SZVB.Projet.Ressource.Types) = VelerSoftware.SZVB.Projet.Ressource.Types.Image Then
                                        ite.ImageKey = "IMG"
                                    ElseIf CType(XmlRead.GetAttribute("type"), VelerSoftware.SZVB.Projet.Ressource.Types) = VelerSoftware.SZVB.Projet.Ressource.Types.Fichier Then
                                        ite.ImageKey = "FILE"
                                    End If
                                    .Resx_ListView3.Items.Add(ite)
                                Case "Composition_Controls" ' Composition_Controls
                                    Me.Composition_Chart.Series("Serie").Points(0).YValues.SetValue(CInt(XmlRead.GetAttribute("value")), 0)
                                Case "Composition_Functions" ' Composition_Functions
                                    Me.Composition_Chart.Series("Serie").Points(1).YValues.SetValue(CInt(XmlRead.GetAttribute("value")), 0)
                                Case "Statistic" ' Statistique
                                    Select Case CType(XmlRead.GetAttribute("type"), VelerSoftware.SZVB.Projet.Statistique.Type)
                                        Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess
                                            Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(CInt(XmlRead.GetAttribute("xvalue")), CInt(XmlRead.GetAttribute("yvalue"))))
                                        Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail
                                            Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(CInt(XmlRead.GetAttribute("xvalue")), CInt(XmlRead.GetAttribute("yvalue"))))
                                    End Select
                                Case "Reference" ' Référence
                                    If Not XmlRead.GetAttribute("value") = Nothing Then
                                        ite = New ListViewItem
                                        ite.Text = XmlRead.GetAttribute("name")
                                        ite.SubItems.Add(XmlRead.GetAttribute("version"))
                                        ite.SubItems.Add(CBool(XmlRead.GetAttribute("copy")).ToString.Replace("True", RM.GetString("Yes_Text")).Replace("False", RM.GetString("No_Text")))
                                        ite.SubItems.Add(XmlRead.GetAttribute("value"))
                                        ite.ToolTipText = XmlRead.GetAttribute("value")
                                        ite.Tag = XmlRead.GetAttribute("isproject")
                                        .References_ListView1.Items.Add(ite)
                                    End If
                            End Select
                    End Select
                Loop
                XmlRead.Close()

                .TableLayoutPanel1.Dock = DockStyle.Fill
                .TableLayoutPanel1.Visible = True
                .TableLayoutPanel1.BringToFront()

                .Reinitialiser_KryptonButton1.Enabled = False

                .ResumeLayout()

            End With

        Else
            RESULTAT = False
        End If

        Return RESULTAT
    End Function

    Public Sub Enregistrer()
        With Me

            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)
            If Not proj Is Nothing Then

                Form1.SaveFileDialog1.Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Enregistrer_Document"), .Nom_Projet & " - " & Date.Today.ToLongDateString & ".szstat")
                Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Enregistrer_Document_Filtre_4")
                Form1.SaveFileDialog1.FilterIndex = 0
                Form1.SaveFileDialog1.FileName = .Nom_Projet & " - " & Date.Today.ToLongDateString & ".szstat"
                If Form1.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    ClassProjet.Enregistrer_Statistiques_Projet(._Nom_Projet, Form1.SaveFileDialog1.FileName, .Composition_Chart.Series(0).Points(0).YValues(0), .Composition_Chart.Series(0).Points(1).YValues(0))

                    ' Mise à jour de l'explorateur de projet car, le fichier etant inexistant, il est possible qu'il ai été enregistré dans le dossier du projet
                    DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ActualiserToolStripMenuItem_Click(Nothing, Nothing)
                End If

            End If

        End With
    End Sub

    Private listviewsorter_lv1, listviewsorter_lv2, listviewsorter_lv3, listviewsorter_lv4, listviewsorter_lv5 As New VelerSoftware.SZC.ListViewStored.ListViewSorter

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Modifier = False
            .Annuler = False
            .Retablir = False

            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            .TableLayoutPanel1.ScrollControlIntoView(.KryptonLabel21)

            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.References_ListView1.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.References_ListView1.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.Resx_ListView3.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.Resx_ListView3.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.VB_ListView4.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.VB_ListView4.Handle, 4096 + 54, 65536, 65536)
            VelerSoftware.SZC.Windows.User32.SetWindowTheme(.Settings_ListView2.Handle, "explorer", Nothing)
            VelerSoftware.SZC.Windows.User32.SendMessage(.Settings_ListView2.Handle, 4096 + 54, 65536, 65536)

            'LV 1
            listviewsorter_lv1.ListView = .References_ListView1
            listviewsorter_lv1.ColumnComparerCollection(.References_ListView1.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.References_ListView1.Columns(1).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.References_ListView1.Columns(2).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.ColumnComparerCollection(.References_ListView1.Columns(3).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv1.Sort(0)

            'LV 2
            listviewsorter_lv2.ListView = .Resx_ListView3
            listviewsorter_lv2.ColumnComparerCollection(.Resx_ListView3.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv2.Sort(0)

            'LV 2
            listviewsorter_lv3.ListView = .VB_ListView4
            listviewsorter_lv3.ColumnComparerCollection(.VB_ListView4.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv3.Sort(0)

            'LV 2
            listviewsorter_lv4.ListView = .Settings_ListView2
            listviewsorter_lv4.ColumnComparerCollection(.Settings_ListView2.Columns(0).Text) = New VelerSoftware.SZC.ListViewStored.Collections.NameComparer
            listviewsorter_lv4.Sort(0)

            If My.Settings.Langue = "fr" Then
                .Composition_Chart.Titles(0).Text = "Composition du projet"
                .Composition_Chart.Series(0).Points(0).LegendText = "Contrôles"
                .Composition_Chart.Series(0).Points(1).LegendText = "Fonctions"
                .Generation_Succes_Echecs_Chart.Titles(0).Text = "Succès et échecs de génération"
                .Generation_Succes_Echecs_Chart.Series(0).LegendText = "Succès"
                .Generation_Succes_Echecs_Chart.Series(1).LegendText = "Echecs"
            Else
                .Composition_Chart.Titles(0).Text = "Project composition"
                .Composition_Chart.Series(0).Points(0).LegendText = "Control"
                .Composition_Chart.Series(0).Points(1).LegendText = "Functions"
                .Generation_Succes_Echecs_Chart.Titles(0).Text = "Build successes and failures"
                .Generation_Succes_Echecs_Chart.Series(0).LegendText = "Successes"
                .Generation_Succes_Echecs_Chart.Series(1).LegendText = "Failures"
            End If

            .FinishLoad = True
            .Modifier = False
            .Annuler = True
            .Retablir = True
        End With
    End Sub

    Friend Function Page_Closing() As Boolean
        If Me.Modifier Then
            Using frm As New Fermer_Document
                frm.Label2.Text = frm.Label2.Text.Replace("{0}", Me.Nom_Projet)
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.Yes Then
                    ' Enregistrer
                    ' Me.Enregistrer()
                    Return True
                ElseIf result = DialogResult.No Then
                    ' Ne pas enregistrer
                    Return True
                ElseIf result = DialogResult.Cancel Then
                    ' Annuler
                    Return False
                End If
                frm.Dispose()
            End Using
        Else
            Return True
        End If
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
            End With

            ' Configuration du ruban
            If SOLUTION IsNot Nothing Then
                If SOLUTION.GetProject(Me.Nom_Projet) IsNot Nothing Then
                    DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & Me.Nom_Projet & " {\b(" & RM.GetString("Document_Statistiques_Du_Projet") & ")}}"
                    .Enregistrer_KryptonRibbonGroupButton.Enabled = True
                Else
                    DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text & " {\b(" & RM.GetString("Document_Statistiques_Fichier") & ")}}"
                    .Enregistrer_KryptonRibbonGroupButton.Enabled = False
                End If
            Else
                DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text & " {\b(" & RM.GetString("Document_Statistiques_Fichier") & ")}}"
                .Enregistrer_KryptonRibbonGroupButton.Enabled = False
            End If
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






    Private Nbr_Fonctions, Nbr_Controls As Double

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim PROJET As VelerSoftware.SZVB.Projet.Projet = DirectCast(e.Argument, VelerSoftware.SZVB.Projet.Projet)

        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File
        Dim Tmp_SZC_File As VelerSoftware.SZVB.Projet.SZC_File
        Dim i_progress, i2_progress As Integer

        Nbr_Fonctions = 0
        Nbr_Controls = 0

        i_progress = System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories).Length + System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories).Length
        i2_progress = 0

        ' CHARGEMENT FICHIERS SZW
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZW", System.IO.SearchOption.AllDirectories)
            Tmp_SZW_File = Nothing
            Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(NomCompletFichier)
            If Not Tmp_SZW_File Is Nothing Then
                Nbr_Controls += Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).Members.Count - 2   ' -3 fonctions + 1 déclaration (fenêtre)
                Nbr_Fonctions += Tmp_SZW_File.Functions.Count - 1   ' -1 pour la racine de la Class
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress((i2_progress / i_progress) * 100)
        Next



        ' CHARGEMENT FICHIERS SZC
        For Each NomCompletFichier As String In System.IO.Directory.GetFiles(PROJET.Emplacement, "*.SZC", System.IO.SearchOption.AllDirectories)
            Tmp_SZC_File = Nothing
            Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(NomCompletFichier)
            If Not Tmp_SZC_File Is Nothing Then
                Nbr_Fonctions += Tmp_SZC_File.Functions.Count - 1   ' -1 pour la racine de la Class
            End If

            i2_progress += 1
            Me.BackgroundWorker1.ReportProgress((i2_progress / i_progress) * 100)
        Next

        e.Result = PROJET
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Clear()
        Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Clear()

        If DirectCast(e.Result, VelerSoftware.SZVB.Projet.Projet).Statistiques.Count > 0 Then
            For Each stat As VelerSoftware.SZVB.Projet.Statistique In DirectCast(e.Result, VelerSoftware.SZVB.Projet.Projet).Statistiques
                Select Case stat.TypeValue
                    Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildSuccess
                        Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(stat.XValue, stat.YValue))
                    Case VelerSoftware.SZVB.Projet.Statistique.Type.BuildFail
                        Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(stat.XValue, stat.YValue))
                End Select
            Next
        Else
            Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(Date.Today.ToOADate, 0))
        End If

        If (Nbr_Controls + Nbr_Fonctions) > 0 Then
            Me.Composition_Chart.Series("Serie").Points(0).YValues.SetValue(System.Math.Round((Nbr_Controls / (Nbr_Controls + Nbr_Fonctions)) * 100), 0)
            Me.Composition_Chart.Series("Serie").Points(1).YValues.SetValue(System.Math.Round((Nbr_Fonctions / (Nbr_Controls + Nbr_Fonctions)) * 100), 0)
        Else
            Me.Composition_Chart.Series("Serie").Points(0).YValues.SetValue(50, 0)
            Me.Composition_Chart.Series("Serie").Points(1).YValues.SetValue(50, 0)
        End If

        Me.TableLayoutPanel1.Visible = True
        Me.TableLayoutPanel1.BringToFront()

        Me.Reinitialiser_KryptonButton1.Focus()
    End Sub


    Private Sub Reinitialiser_KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reinitialiser_KryptonButton1.Click
        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Form1
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes), New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.No)}
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Question
            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content32"), Me.Nom_Projet)
            .MainInstruction = RM.GetString("MainInstruction13")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With
        If vd.Result = VelerSoftware.SZVB.VistaDialog.VDialogResult.Yes Then ' Si l'utilisateur veux ajouter le projet à la solution
            If SOLUTION.GetProject(Me.Nom_Projet) IsNot Nothing Then
                SOLUTION.GetProject(Me.Nom_Projet).Statistiques.Clear()

                Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Clear()
                Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Echecs").Points.Clear()
                Me.Generation_Succes_Echecs_Chart.Series("Serie_Generation_Succes").Points.Add(New System.Windows.Forms.DataVisualization.Charting.DataPoint(Date.Today.ToOADate, 0))
            End If
        End If
    End Sub

End Class
