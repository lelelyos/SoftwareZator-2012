''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocConcepteurFenetre

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

#Region "Nom du document"

    Private _NomFichier As String = ""

    Public Property NomFichier() As String
        Get
            Return _NomFichier
        End Get
        Set(ByVal value As String)
            _NomFichier = value
        End Set
    End Property

#End Region ' Nom du fichier  

#Region "Nom Complet du document"

    Private _NomCompletFichier As String = ""

    Public Property NomCompletFichier() As String
        Get
            Return _NomCompletFichier
        End Get
        Set(ByVal value As String)
            _NomCompletFichier = value
        End Set
    End Property

#End Region ' Nom complet du fichier (chemin + fichier)

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Concepteur_Fenetre

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

#Region "Gestion"

    Public Sub DocumentModifier()
        If FinishLoad And Annuler And Retablir Then
            Modifier = True
            If (Not Me.Nom_Projet = "") AndAlso (Not SOLUTION.GetProject(Nom_Projet) Is Nothing) Then
                SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
            End If
        Else
        End If
        If Modifier AndAlso Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
            DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomFichier & "*"
        End If
    End Sub ' Document modifié








    Public Function Charger(ByVal Nom_A_Donner As String) As Boolean
        Dim RESULTAT As Boolean = True

        'Me.File = New VelerSoftware.SZVB.Projet.SZW_File("WindowsForm1")
        'Dim myFileStream2 As IO.Stream = IO.File.OpenRead("C:\Form1.szw")
        'Dim deserializer2 As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        'Me.File.WINDOWS = DirectCast(deserializer2.Deserialize(myFileStream2), System.CodeDom.CodeCompileUnit)
        'myFileStream2.Close()
        'Me.File.WINDOWS.Namespaces(0).Name = Nom_Projet
        'Me.File.Nom = "WindowsForm1"
        'Me.File.Functions.Clear()
        'Me.File.Functions = New Generic.List(Of String)
        'Dim myFileStream3 As IO.Stream = IO.File.Create(Me.NomCompletFichier)
        'Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        'serializer.Serialize(myFileStream3, Me.File)
        'myFileStream3.Close()

        'Info_Bar_Plugins_Actions_Introuvables = New Generic.List(Of String) 

        Dim myFileStream As IO.Stream = IO.File.OpenRead(Me.NomCompletFichier)
        Dim deserializer As Runtime.Serialization.Formatters.Binary.BinaryFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Try
            Me.File = DirectCast(deserializer.Deserialize(myFileStream), VelerSoftware.SZVB.Projet.SZW_File)
        Catch ex As Exception
            myFileStream.Close()
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, ex.Message))
            Erreur_Chargement_Concepteur_Fenetre = True
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content12"), My.Application.Info.Title)
                .MainInstruction = RM.GetString("MainInstruction10")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
            RESULTAT = False
        End Try
        myFileStream.Close()

        If RESULTAT Then

            Charger_Concepteur_Fenetre(Nom_A_Donner)

            If Not Erreur_Chargement_Concepteur_Fenetre Then
                Me.TabONE_KryptonPage.Text = Me.Designer.ComponentContainer.Components(0).Site.Name
            Else
                Me.TabONE_KryptonPage.Text = Me.NomFichier.Replace(" ", "_").ToLower.Replace(".szw", Nothing)
            End If

            Charger_Editeur_Code()

            If Not Erreur_Chargement_Concepteur_Fenetre AndAlso Not Nom_A_Donner = Nothing Then
                With Me
                    .Designer.ComponentContainer.Components(0).Site.Name = Nom_A_Donner
                    .Host.RootComponent.Site.Name = Nom_A_Donner
                    .Designer.Flush()
                    .TabONE_KryptonPage.Text = .Designer.ComponentContainer.Components(0).Site.Name
                    .File.Nom = Nom_A_Donner
                End With
            End If

            ' If Erreur_Plugins_Actions_Introuvables Then
            ' If Not Form1.Info_Bar1.Visible Then
            ' If OPTION_SZ.Plugins_Necessaires_Fonctionnement_De_X_Actions_Introuvables Then
            ' Form1.Info_Bar1.BarStyle = VelerSoftware.SZVB.Info_Bar.Style.Errors
            ' Form1.Info_Bar1.BarText = "Les plugins nécessaires au fonctionnement de " & Info_Bar_Plugins_Actions_Introuvables.Count & " action(s) sont introuvables."
            ' Form1.Info_Bar1.ButtonVisible = True
            ' Form1.Info_Bar1.ButtonText = "Télécharger les plugins"
            ' Form1.Info_Bar1.Tag = "Plugins_Necessaires_Fonctionnement_De_X_Actions_Introuvables"
            ' Form1.Info_Bar1.Visible = True
            ' End If
            ' End If
            ' End If

            If ClassFichier.IsReadOnly(Me.NomCompletFichier) AndAlso Not Form1.Info_Bar1.Visible Then
                Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_5_Description"), Me.NomFichier), Nothing, False, "Read_Only", Nothing)
            End If

        End If

        Return RESULTAT
    End Function

    Private Sub Charger_Concepteur_Fenetre(ByVal Nom_A_Donner As String)
        With Me

            Dim serviceContainer As System.ComponentModel.Design.IServiceContainer
            Dim proj As VelerSoftware.SZVB.Projet.Projet = SOLUTION.GetProject(.Nom_Projet)

            If .Panel1.Controls.Count > 0 Then .Panel1.Controls.RemoveAt(0)

            .Designer = New VelerSoftware.SZC.WindowsDesigner.Designer(My.Settings.Afficher_La_Griller, True, My.Settings.Aimentation_Intelligente, True, My.Settings.Smart_Tags, True, My.Settings.Afficher_La_Griller)
            .ToolBoxs = New VelerSoftware.SZC.WindowsDesigner.ToolBoxService
            .CodeDomHostLoader = New VelerSoftware.SZC.WindowsDesigner.CodeDomHostLoader

            AddHandler .Designer.Loaded, AddressOf Designer_OnEndLoaded

            .CodeDomHostLoader.Fichier = New VelerSoftware.SZVB.Projet.SZW_File

            .CodeDomHostLoader.Fichier = .File
            .CodeDomHostLoader.NomProjet = .Nom_Projet
            If Not proj Is Nothing Then .CodeDomHostLoader.Ass = proj.References

            .CodeDomHostLoader.LoadAssembly()

            .Host = TryCast(.Designer.GetService(GetType(System.ComponentModel.Design.IDesignerHost)), System.ComponentModel.Design.IDesignerHost)
            serviceContainer = DirectCast(.Host.GetService(GetType(System.ComponentModel.Design.ServiceContainer)), System.ComponentModel.Design.IServiceContainer)

            ' Ressources
            ' Génération du nom de fichier Temporaire
            Resx_File_Path = Application.StartupPath & "\Temp\Resources\"
            For i = 0 To 50 - 1
                Resx_File_Path &= Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
            Next
            Resx_File_Path &= ".resx"
            If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Temp\Resources") Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Temp\Resources")
            If My.Computer.FileSystem.FileExists(Resx_File_Path) Then My.Computer.FileSystem.DeleteFile(Resx_File_Path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            If Not .File.Resources = Nothing Then My.Computer.FileSystem.WriteAllText(Resx_File_Path, .File.Resources, False)
            If My.Computer.FileSystem.FileExists(Resx_File_Path) Then
                Me.Host.AddService(GetType(System.ComponentModel.Design.IResourceService), New VelerSoftware.SZC.WindowsDesigner.ResourceService(.Host, Resx_File_Path))
            End If

            .Designer.BeginLoad(CodeDomHostLoader)
            .MenuCommandService = New VelerSoftware.SZC.WindowsDesigner.MenuCommandServiceImpl(serviceContainer)
            .Host.AddService(GetType(System.ComponentModel.Design.MenuCommandService), .MenuCommandService)

            ' Ajout du service Annuler/Retablir
            .undoEngine = New VelerSoftware.SZC.WindowsDesigner.UndoEngineImpl(serviceContainer)
            .undoEngine.Enabled = False
            .Host.AddService(GetType(System.ComponentModel.Design.UndoEngine), .undoEngine)

            If Not Erreur_Chargement_Concepteur_Fenetre Then
                Try
                    If Not Nom_A_Donner = Nothing Then
                        .Designer.ComponentContainer.Components(0).Site.Name = Nom_A_Donner
                        .Host.RootComponent.Site.Name = Nom_A_Donner
                        .Designer.ComponentContainer.Components(0).GetType.GetProperty("Text").SetValue(.Designer.ComponentContainer.Components(0), Nom_A_Donner, Nothing)

                        Me.Modifier = True
                    End If

                Catch ex As Exception
                End Try
            End If

        End With
    End Sub

    Private Sub Charger_Editeur_Code()
        Dim i As Integer = 0
        For Each txt As String In Me.File.Functions
            i += 1
            If i = 1 Then
                Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
                editor.Dock = DockStyle.Fill
                editor.IsWindow = True
                editor.DebuggerService = editor.WorkflowDesigne.DebugManagerView

                ' Génération du nom de fichier Temporaire
                For i = 0 To 50 - 1
                    editor.TempXAMLFileName &= Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                Next
                editor.TempXAMLFileName &= ".xaml"

                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName, txt, False)
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
                    Exit Sub
                End If

                If Not Erreur_Chargement_Concepteur_Fenetre Then
                    Me.TabONE_KryptonPage.Text = Me.Designer.ComponentContainer.Components(0).Site.Name
                    Try
                        With editor.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root
                            If .ItemType.BaseType = GetType(VelerSoftware.Plugins3.ActionWithChildren) Then
                                DirectCast(.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName = Me.TabONE_KryptonPage.Text
                                DirectCast(.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Me.TabONE_KryptonPage.Text
                            End If
                        End With
                    Catch
                    End Try
                End If
                Me.TabONE_KryptonPage.Controls.Add(editor)

                AddHandler editor.SelectedActionChanger, AddressOf Me.SelectedActionChanged
            Else
                Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
                editor.Dock = DockStyle.Fill
                editor.IsWindow = True
                editor.DebuggerService = editor.WorkflowDesigne.DebugManagerView

                ' Génération du nom de fichier Temporaire
                For i = 0 To 50 - 1
                    editor.TempXAMLFileName &= Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                Next
                editor.TempXAMLFileName &= ".xaml"

                My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName, txt, False)
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
                    Exit Sub
                End If

                Dim CloseButton As New VelerSoftware.Design.Toolkit.ButtonSpecAny
                CloseButton.Type = VelerSoftware.Design.Toolkit.PaletteButtonSpecStyle.Close
                AddHandler CloseButton.Click, AddressOf Me.CloseButton_Click

                AddHandler editor.SelectedActionChanger, AddressOf Me.SelectedActionChanged

                Dim Tab2 As New VelerSoftware.Design.Navigator.KryptonPage
                DirectCast(Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
                Tab2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
                Tab2.ButtonSpecs.Add(CloseButton)
                Tab2.Cursor = System.Windows.Forms.Cursors.Default
                Tab2.Flags = 65534
                Tab2.LastVisibleSet = True
                Tab2.MinimumSize = New System.Drawing.Size(50, 50)
                Try
                    With editor.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root
                        If .ItemType.BaseType = GetType(VelerSoftware.Plugins3.ActionWithChildren) Then
                            With DirectCast(.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren)
                                Tab2.Name = .Param1
                                Tab2.Text = .Param1
                                Tab2.UniqueName = .Param1
                                .DisplayName = Tab2.Text
                            End With
                        End If
                    End With
                Catch
                End Try
                Tab2.Controls.Add(editor)
                DirectCast(Tab2, System.ComponentModel.ISupportInitialize).EndInit()
                Me.KryptonNavigator2.Pages.Add(Tab2)
            End If
        Next
    End Sub









    Public Sub Enregistrer(ByVal Enregistrer_SOUS As Boolean)

        ' Nom
        If Not Erreur_Chargement_Concepteur_Fenetre Then
            Me.File.Nom = Me.Designer.ComponentContainer.Components(0).Site.Name
        Else
            Me.File.Nom = Me.File.Nom
        End If

        ' Fenêtre
        'Me.Designer.Flush()
        Me.File.WINDOWS = CodeDomHostLoader.GetCodeCompileUnit
        Me.File.WINDOWS.Namespaces(0).Name = Me.Nom_Projet

        ' Ressources
        Me.File.Resources = Me.Enregistrer_Resx()

        ' Fonctions
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Temp\Functions") Then My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Temp")
        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
            If TAB.Controls.Count > 0 AndAlso DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content28"), Me.NomFichier)
                    .MainInstruction = RM.GetString("MainInstruction10")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                Exit Sub
            End If
        Next
        Me.File.Functions.Clear()
        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
            If TAB Is Me.TabONE_KryptonPage AndAlso TAB.Controls.Count > 0 Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
                DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\Function.xaml")
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                    Me.File.Functions.Insert(0, My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Temp\Functions\Function.xaml"))
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
            ElseIf TAB.Controls.Count > 0 Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
                DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\Function.xaml")
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                    Me.File.Functions.Add(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Temp\Functions\Function.xaml"))
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End If
            End If
        Next

        ' Enregistrement
        If Not Enregistrer_SOUS Then
            If My.Computer.FileSystem.FileExists(Me.NomCompletFichier) Then
                If Not ClassFichier.IsReadOnly(Me.NomCompletFichier) Then
                    Dim myFileStream As IO.Stream = IO.File.Create(Me.NomCompletFichier)
                    Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    serializer.Serialize(myFileStream, Me.File)
                    myFileStream.Close()

                    Modifier = False
                    DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Me.NomFichier
                Else
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content23"), Me.NomCompletFichier)
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Me.Enregistrer(True)
                End If
            Else
                Me.Enregistrer(True)
            End If
        Else
            Form1.SaveFileDialog1.Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Enregistrer_Document"), Me.NomFichier)
            Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Enregistrer_Document_Filtre")
            Form1.SaveFileDialog1.FilterIndex = 0
            Form1.SaveFileDialog1.FileName = Me.NomFichier
            If Form1.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.NomFichier = My.Computer.FileSystem.GetName(Form1.SaveFileDialog1.FileName)
                Me.NomCompletFichier = Form1.SaveFileDialog1.FileName
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).UniqueName = Me.NomCompletFichier

                Dim myFileStream As IO.Stream = IO.File.Create(Me.NomCompletFichier)
                Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                serializer.Serialize(myFileStream, Me.File)
                myFileStream.Close()

                Modifier = False

                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Me.NomFichier
                ' Mise à jour de l'explorateur de projet car, le fichier etant inexistant, il est possible qu'il ai été enregistré dans le dossier du projet
                DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ActualiserToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If

    End Sub

    Public Function Enregistrer_Resx() As String
        ' Générer un fichier .Designer.vb pour les fichiers ressources

        'Dim UnmatchedElements As String()
        'Dim CodeProvider As CodeDom.Compiler.CodeDomProvider = New Microsoft.CSharp.CSharpCodeProvider()
        'Dim Code As CodeDom.CodeCompileUnit = Resources.Tools.StronglyTypedResourceBuilder.Create("", "", "", CodeProvider, False, UnmatchedElements)
        'Dim writer As System.IO.StreamWriter = New IO.StreamWriter("")
        'CodeProvider.GenerateCodeFromCompileUnit(Code, writer, New CodeDom.Compiler.CodeGeneratorOptions())
        'writer.Close()

        Dim rs As VelerSoftware.SZC.WindowsDesigner.ResourceService = DirectCast(Me.Host.GetService(GetType(System.ComponentModel.Design.IResourceService)), VelerSoftware.SZC.WindowsDesigner.ResourceService)
        If rs Is Nothing Then
            Me.Host.AddService(GetType(System.ComponentModel.Design.IResourceService), New VelerSoftware.SZC.WindowsDesigner.ResourceService(Host, Resx_File_Path))
            rs = DirectCast(Me.Host.GetService(GetType(System.ComponentModel.Design.IResourceService)), VelerSoftware.SZC.WindowsDesigner.ResourceService)
        End If
        rs.Save()

        If My.Computer.FileSystem.FileExists(Resx_File_Path & "_2") Then
            Return My.Computer.FileSystem.ReadAllText(Resx_File_Path & "_2")
        Else
            Return Nothing
        End If

    End Function










    Public Sub Coller()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre AndAlso My.Computer.Clipboard.GetDataObject().GetDataPresent("CF_DESIGNERCOMPONENTS_V2", True) Then ' On vérifie que des contrôles soient dans le Presse-papiers
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Paste
                Me.MenuCommandService.GlobalInvoke(a)
                DocumentModifier()
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Coller()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Copier()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Copy
                Me.MenuCommandService.GlobalInvoke(a)

                'Clipboard.SetDataObject(Me.File, True)
                'If Clipboard.GetDataObject().GetDataPresent("VelerSoftware.SZVB.Projet.SZW_File", True) Then
                '    MsgBox(DirectCast(Clipboard.GetDataObject.GetData("VelerSoftware.SZVB.Projet.SZW_File", True), VelerSoftware.SZVB.Projet.SZW_File).Nom)
                'End If
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Copier()
            End If
        End If
    End Sub

    Public Sub Couper()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Cut
                Me.MenuCommandService.GlobalInvoke(a)
                DocumentModifier()
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Couper()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Undo()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Undo
                Me.MenuCommandService.GlobalInvoke(a)
                DocumentModifier()
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Annuler()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Redo()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Redo
                Me.MenuCommandService.GlobalInvoke(a)
                DocumentModifier()
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Rétablir()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub SelectionnerTout()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SelectAll
                Me.MenuCommandService.GlobalInvoke(a)
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).SelectionnerTout()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Supprimer()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
                Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.Delete
                Me.MenuCommandService.GlobalInvoke(a)
                DocumentModifier()
            ElseIf Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Couper()
                DocumentModifier()
            End If
        End If
    End Sub







    Public Sub Exporter_VB_Net()
        Form1.SaveFileDialog1.Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Exporter_Document_VBNet"), Me.NomFichier)
        Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Exporter_Document_VBNet_Filtre")
        Form1.SaveFileDialog1.FilterIndex = 0
        Form1.SaveFileDialog1.FileName = Me.NomFichier.Replace(".szw", ".vb")
        If Form1.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Designer.Flush()
            Dim cod As CodeDom.CodeCompileUnit = Me.CodeDomHostLoader.GetCodeCompileUnit
            cod.Namespaces(0).Name = Me.Nom_Projet
            cod.Namespaces(0).Comments.Add(New CodeDom.CodeCommentStatement("Ce Namespace a été généré avec " & My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition) & " " & My.Application.Info.Version.ToString))


            Dim o As New CodeDom.Compiler.CodeGeneratorOptions()
            Dim swVB As IO.StringWriter
            Dim vb As New VBCodeProvider()

            o.BlankLinesBetweenMembers = True
            o.BracingStyle = "VB"
            o.ElseOnClosing = True
            o.IndentString = "    "
            swVB = New IO.StringWriter()
            vb.GenerateCodeFromCompileUnit(cod, swVB, o)

            My.Computer.FileSystem.WriteAllText(Form1.SaveFileDialog1.FileName, swVB.ToString, False)
            My.Computer.FileSystem.WriteAllText(Form1.SaveFileDialog1.FileName.Replace(My.Computer.FileSystem.GetFileInfo(Form1.SaveFileDialog1.FileName).Extension, Nothing) & ".resx", Me.Enregistrer_Resx(), False)
        End If
    End Sub

    Public Sub Exporter_CSharp()
        Form1.SaveFileDialog1.Title = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("SaveFileDialog1_Exporter_Document_CSharp"), Me.NomFichier)
        Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Exporter_Document_CSharp_Filtre")
        Form1.SaveFileDialog1.FilterIndex = 0
        Form1.SaveFileDialog1.FileName = Me.NomFichier.Replace(".szw", ".cs")
        If Form1.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Designer.Flush()
            Dim cod As CodeDom.CodeCompileUnit = Me.CodeDomHostLoader.GetCodeCompileUnit
            cod.Namespaces(0).Name = Me.Nom_Projet
            cod.Namespaces(0).Comments.Add(New CodeDom.CodeCommentStatement("Ce Namespace a été généré avec " & My.Application.Info.Title & " " & RM.GetString("Edition_" & My.Settings.Edition) & " " & My.Application.Info.Version.ToString))


            Dim o As New CodeDom.Compiler.CodeGeneratorOptions()
            Dim swVB As IO.StringWriter
            Dim vb As New VBCodeProvider()

            o.BlankLinesBetweenMembers = True
            o.BracingStyle = "C"
            o.ElseOnClosing = True
            o.IndentString = "    "
            swVB = New IO.StringWriter()
            vb.GenerateCodeFromCompileUnit(cod, swVB, o)

            My.Computer.FileSystem.WriteAllText(Form1.SaveFileDialog1.FileName, swVB.ToString, False)
            My.Computer.FileSystem.WriteAllText(Form1.SaveFileDialog1.FileName.Replace(My.Computer.FileSystem.GetFileInfo(Form1.SaveFileDialog1.FileName).Extension, Nothing) & ".resx", Me.Enregistrer_Resx(), False)
        End If
    End Sub

    Public Sub Imprimer()
        If Me.KryptonNavigator1.SelectedIndex = 1 Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Imprimer()
        End If
    End Sub

    Public Sub Impression_Rapide()
        If Me.KryptonNavigator1.SelectedIndex = 1 Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Impression_Rapide()
        End If
    End Sub

    Public Sub Apercu_Avant_Impression()
        If Me.KryptonNavigator1.SelectedIndex = 1 Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Apercu_Avant_Impression()
        End If
    End Sub






    Public Sub NouvelleFonction()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 Then
            For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
                If TAB.Controls.Count > 0 AndAlso DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content52"))
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Exit Sub
                End If
            Next

            For Each plug As ClassPluginServices.Plugin In PLUGINS
                If plug.PluginName = "VelerSoftware.GeneralPlugin" Then
                    For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                        If act.GetType.FullName = "VelerSoftware.GeneralPlugin.Fonction" Then
                            Dim Fonction As New VelerSoftware.Plugins3.ActionWithChildren
                            Fonction = DirectCast(plug.Assembly.CreateInstance(act.GetType.FullName), VelerSoftware.Plugins3.ActionWithChildren)
                            Fonction.Tools = New ClassActionTools
                            If Fonction.Main() Then
                                Dim ok As Boolean = True

                                For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
                                    If Not DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Nothing AndAlso _
                                        DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1.ToLower = Fonction.Param1.ToLower Then

                                        ok = False
                                        Exit For
                                    End If
                                Next

                                If ok Then
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
                                            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content40"), Application.StartupPath & "\Temp\Functions\" & editor.TempXAMLFileName)
                                            .MainInstruction = RM.GetString("MainInstruction10")
                                            .WindowTitle = My.Application.Info.Title
                                            .Show()
                                        End With
                                        Exit Sub
                                    End If

                                    Dim CloseButton As New VelerSoftware.Design.Toolkit.ButtonSpecAny
                                    CloseButton.Type = VelerSoftware.Design.Toolkit.PaletteButtonSpecStyle.Close
                                    AddHandler CloseButton.Click, AddressOf Me.CloseButton_Click

                                    Dim Tab2 As New VelerSoftware.Design.Navigator.KryptonPage
                                    DirectCast(Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
                                    With Tab2
                                        .AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
                                        .ButtonSpecs.Add(CloseButton)
                                        .Cursor = System.Windows.Forms.Cursors.Default
                                        .Flags = 65534
                                        .LastVisibleSet = True
                                        .MinimumSize = New System.Drawing.Size(50, 50)
                                        .Name = Fonction.DisplayName
                                        .UniqueName = Fonction.DisplayName
                                        .Text = Fonction.DisplayName
                                        .Controls.Add(editor)
                                    End With
                                    DirectCast(Tab2, System.ComponentModel.ISupportInitialize).EndInit()
                                    Me.KryptonNavigator2.Pages.Add(Tab2)

                                    Me.KryptonNavigator1.SelectedIndex = 1
                                    Me.KryptonNavigator2.SelectedPage = Tab2

                                    AddHandler editor.SelectedActionChanger, AddressOf Me.SelectedActionChanged

                                    Me.DocumentModifier()
                                Else
                                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                                    With vd
                                        .Owner = Nothing
                                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content19"), Fonction.DisplayName)
                                        .MainInstruction = RM.GetString("MainInstruction11")
                                        .WindowTitle = My.Application.Info.Title
                                        .Show()
                                    End With
                                End If
                            End If
                            Exit For
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Public Sub ModifierAction()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Modifier_Action()
        End If
    End Sub

    Public Sub ZoomIn()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomIn()
        End If
    End Sub

    Public Sub ZoomOut()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomOut()
        End If
    End Sub

    Public Sub ZoomReset()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomReset()
        End If
    End Sub

    Public Sub EnregistrerImage()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).EnregistrerImage()
        End If
    End Sub

    Public Sub CopierImage()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).CopierImage()
        End If
    End Sub

    Public Sub Developper()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Developper()
        End If
    End Sub

    Public Sub Reduire()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 1 AndAlso TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
            DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Reduire()
        End If
    End Sub

    Public Sub Ajouter_Point_Arrêt()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Ajouter_Point_Arrêt()
            End If
        End If
    End Sub

    Public Sub Switch_Point_Arrêt()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Switch_Point_Arrêt()
            End If
        End If
    End Sub

    Public Sub Supprimer_Point_Arrêt()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Supprimer_Point_Arrêt()
            End If
        End If
    End Sub




    Public Sub PremierPlan()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.BringToFront
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub ArrierePlan()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SendToBack
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub VerouillerControles()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.LockControls
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub OrdreTabulation()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.TabOrder
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub CentrerVertical()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.CenterVertically
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub CentrerHorizontal()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.CenterHorizontally
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceVerticalSupprimer()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.VertSpaceConcatenate
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceVerticalDiminuer()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.VertSpaceDecrease
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceVerticalAugmenter()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.VertSpaceIncrease
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceVerticalEgaliser()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.VertSpaceMakeEqual
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceHorizontalSupprimer()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.HorizSpaceConcatenate
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceHorizontalDiminuer()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.HorizSpaceDecrease
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceHorizontalAugmenter()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.HorizSpaceIncrease
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub EspaceHorizontalEgaliser()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.HorizSpaceMakeEqual
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AjusterGrille()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SnapToGrid
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AjusterLargeur()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SizeToControlWidth
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AjusterHauteur()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SizeToControlHeight
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AjusterlargeurEtHauteur()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.SizeToControl
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerGauche()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignLeft
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerCentre()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignHorizontalCenters
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerDroite()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignRight
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerSommet()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignTop
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerMilieux()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignVerticalCenters
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerBase()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignBottom
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

    Public Sub AlignerGrille()
        If Me.FinishLoad AndAlso Me.KryptonNavigator1.SelectedIndex = 0 AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Dim a As System.ComponentModel.Design.CommandID = System.ComponentModel.Design.StandardCommands.AlignToGrid
            Me.MenuCommandService.GlobalInvoke(a)
            DocumentModifier()
        End If
    End Sub

#End Region

#Region "Concepteur de vue Déclaration"

    Public Activer_Renommer As Boolean = True
    Public Erreur_Chargement_Concepteur_Fenetre As Boolean = False
    <CLSCompliant(False)> Public CodeDomHostLoader As New VelerSoftware.SZC.WindowsDesigner.CodeDomHostLoader
    <CLSCompliant(False)> Public Designer As New VelerSoftware.SZC.WindowsDesigner.Designer
    Public Host As System.ComponentModel.Design.IDesignerHost
    <CLSCompliant(False)> Public ToolBoxs As New VelerSoftware.SZC.WindowsDesigner.ToolBoxService
    Public MenuCommandService As System.ComponentModel.Design.IMenuCommandService
    Public SelectionService As System.ComponentModel.Design.ISelectionService
    <CLSCompliant(False)> Public undoEngine As VelerSoftware.SZC.WindowsDesigner.UndoEngineImpl
    Public componentChangeService As System.ComponentModel.Design.IComponentChangeService

    Friend can_change As Boolean
    Friend OldName As String

    Private Resx_File_Path As String

#End Region

    Public File As VelerSoftware.SZVB.Projet.SZW_File



    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Annuler = False
            .Retablir = False


            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocConcepteurFenetre))
            .ToolTip1.SetToolTip(.KryptonTextBox1.TextBox, resources.GetString("KryptonTextBox1.ToolTip"))

            .KryptonTextBox1.Enabled = False
            .KryptonLabel1.Enabled = False
            .KryptonButton1.Enabled = False

            .RulerControl1.MouseTrackingOn = My.Settings.Suivre_Souris_Regle
            .RulerControl2.MouseTrackingOn = My.Settings.Suivre_Souris_Regle

            .KryptonNavigator1.SelectedIndex = 0
            .KryptonNavigator2.SelectedIndex = 0
            If .KryptonNavigator2.Pages.Count >= 2 Then
                .KryptonNavigator2.SelectedIndex = 1
            End If
        End With


        If Not Erreur_Chargement_Concepteur_Fenetre Then
            ' Récupération du service ISelectionService
            ToolBoxs = DirectCast(Designer.GetService(GetType(System.Drawing.Design.IToolboxService)), VelerSoftware.SZC.WindowsDesigner.ToolBoxService)

            ' On associe la toolbox au service
            ToolBoxs.ToolBox = DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ListBox1
            ToolBoxs.View = Me.Panel1


            ' Récupération du service ISelectionService
            SelectionService = DirectCast(Designer.GetService(GetType(System.ComponentModel.Design.ISelectionService)), System.ComponentModel.Design.ISelectionService)

            ' Ajout de l'évenement SelectionChanged
            AddHandler SelectionService.SelectionChanged, AddressOf selectionService_SelectionChanged

            ' Récupération du service ISelectionService (MENU CONTEXTUEL)
            MenuCommandService = DirectCast(Designer.GetService(GetType(System.ComponentModel.Design.IMenuCommandService)), System.ComponentModel.Design.IMenuCommandService)


            'Récupération du service IComponentChangeService et association des évènement ComponentAdded, ComponentRemoved, ComponentRename
            componentChangeService = DirectCast(Designer.GetService(GetType(System.ComponentModel.Design.IComponentChangeService)), System.ComponentModel.Design.IComponentChangeService)
            AddHandler componentChangeService.ComponentAdded, AddressOf componentChangeService_ComponentAdded
            AddHandler componentChangeService.ComponentRemoved, AddressOf componentChangeService_ComponentRemoved
            AddHandler componentChangeService.ComponentRename, AddressOf componentChangeService_ComponentRename
            AddHandler componentChangeService.ComponentChanged, AddressOf componentChangeService_ComponentChanged

            undoEngine.Enabled = True

            'Dim extender As New System.ComponentModel.Design.LocalizationExtenderProvider(Designer.ComponentContainer.Components(0).Site, Designer.ComponentContainer.Components(0))
            'extender.SetLocalizable(Designer.ComponentContainer.Components(0), True)

            Dim extender As New System.ComponentModel.Design.Serialization.CodeDomLocalizationProvider(Designer.ComponentContainer.Components(0).Site, System.ComponentModel.Design.Serialization.CodeDomLocalizationModel.PropertyAssignment)

        End If





        ' Initialisation de la première action (VelerSoftware.GeneralPlugin.Fonction)
        'Dim Fonction As New VelerSoftware.Plugins3.ActionWithChildren
        'For Each plug As ClassPluginServices.Plugin In PLUGINS
        '    For Each act As VelerSoftware.Plugins3.Action In plug.Actions
        '        If act.GetType.FullName = "VelerSoftware.GeneralPlugin.Fonction" Then
        '            Fonction = DirectCast(plug.Assembly.CreateInstance(act.GetType.FullName), VelerSoftware.Plugins3.ActionWithChildren)
        '            Fonction.Tools = New ClassActionTools
        '        End If
        '    Next
        'Next
        'Fonction.Param1 = Me.TabONE_KryptonPage.Text
        'Fonction.DisplayName = Me.TabONE_KryptonPage.Text
        'Fonction.Added = True
        '
        'Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
        'editor.Dock = DockStyle.Fill
        'editor.WorkflowDesigne.Load(Fonction)
        '
        'Me.TabONE_KryptonPage.Controls.Add(editor)


        If My.Settings.Réduire_Panneau_Lateral_WindowsDesigner Then Me.KryptonLinkLabel1_LinkClicked(Nothing, Nothing)



        Me.FinishLoad = True
        Me.Annuler = True
        Me.Retablir = True

        If Not Erreur_Chargement_Concepteur_Fenetre Then Me.SelectionService.SetSelectedComponents(New System.ComponentModel.Component() {Me.Host.RootComponent})

    End Sub

    Friend Function Page_Closing() As Boolean
        Dim resultat As Boolean
        If Me.Modifier Then
            Using frm As New Fermer_Document
                frm.Label2.Text = frm.Label2.Text.Replace("{0}", Me.NomFichier)
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.Yes Then
                    ' Enregistrer
                    Me.Enregistrer(False)
                    resultat = True
                ElseIf result = DialogResult.No Then
                    ' Ne pas enregistrer   
                    resultat = True
                ElseIf result = DialogResult.Cancel Then
                    ' Annuler     
                    resultat = False
                End If
                frm.Dispose()
            End Using
        Else
            resultat = True
        End If

        If resultat Then
            For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
                If TAB.Controls.Count > 0 AndAlso DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).breakpointList.Count > 0 Then
                    If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content36"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                        Exit For
                    Else
                        resultat = False
                        Exit For
                    End If
                End If
            Next
        End If

        If resultat Then
            For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
                If TAB.Controls.Count > 0 Then
                    With DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl)
                        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\" & .TempXAMLFileName) Then
                            My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\" & .TempXAMLFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End If
                        .WorkflowDesigne.Dispose()
                        .designerSourceLocationMapping.Clear()
                        .breakpointList.Clear()
                    End With
                End If
            Next
            If My.Computer.FileSystem.FileExists(Resx_File_Path) Then
                Dim rs As VelerSoftware.SZC.WindowsDesigner.ResourceService = DirectCast(Me.Host.GetService(GetType(System.ComponentModel.Design.IResourceService)), VelerSoftware.SZC.WindowsDesigner.ResourceService)
                If rs IsNot Nothing Then
                    rs.reader.Close()
                    rs.writer.Close()
                    rs.writer.Dispose()
                End If
                My.Computer.FileSystem.DeleteFile(Resx_File_Path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
            If My.Computer.FileSystem.FileExists(Resx_File_Path & "_2") Then
                My.Computer.FileSystem.DeleteFile(Resx_File_Path & "_2", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If

            Me.CodeDomHostLoader.Dispose()
            Me.componentChangeService = Nothing
            Me.Designer.Dispose()
            Me.Host = Nothing
            Me.MenuCommandService = Nothing
            Me.SelectionService = Nothing
            Me.ToolBoxs = Nothing
            Me.Designer = Nothing
            Me.undoEngine.Dispose()
        End If

        Return resultat
    End Function

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

    Private Sub KryptonNavigator1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonNavigator1.SelectedPageChanged, KryptonNavigator2.SelectedPageChanged
        Activate_Page()
    End Sub

    Friend Sub Activate_Page()
        If Me.FinishLoad Then
            If Me.KryptonNavigator1.SelectedIndex = 0 Then
                With Form1
                    With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)
                        .Vide_ToolBox.Visible = False
                        .Concepteur_Fenetre_ToolBox.Visible = True
                        .Fonctions_ToolBox.Visible = False
                        .Classes_ToolBox.Visible = False
                    End With

                    selectionService_SelectionChanged(Nothing, Nothing)

                    ' Configuration du ruban
                    .Enregistrer_KryptonRibbonGroupButton.Enabled = True
                    .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = True

                    .VbNet_KryptonRibbonGroupButton.Enabled = True
                    .CSharp_KryptonRibbonGroupButton.Enabled = True

                    .Imprimer_KryptonRibbonGroupButton.Enabled = False
                    .Impression_Rapide_KryptonRibbonGroupButton.Enabled = False
                    .Apercu_Impression_KryptonRibbonGroupButton.Enabled = False

                    .Coller_KryptonRibbonGroupButton.Enabled = True
                    .Copier_KryptonRibbonGroupButton.Enabled = True
                    .Couper_KryptonRibbonGroupButton.Enabled = True

                    .Annuler_KryptonRibbonGroupButton.Enabled = True
                    .Retablir_KryptonRibbonGroupButton.Enabled = True
                    .Supprimer_KryptonRibbonGroupButton.Enabled = True
                    .Selectionner_tout_KryptonRibbonGroupButton.Enabled = True

                    .QAT_Annuler.Enabled = True
                    .QAT_Coller.Enabled = True
                    .QAT_Copier.Enabled = True
                    .QAT_Couper.Enabled = True
                    .QAT_Enregistrer_Sous.Enabled = True
                    .QAT_Retablir.Enabled = True

                    .KryptonRibbon1.SelectedContext = "Concepteur_Fenetre"
                End With
            Else
                With Form1
                    With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)
                        .Vide_ToolBox.Visible = False
                        .Concepteur_Fenetre_ToolBox.Visible = False
                        If Me.KryptonNavigator2.SelectedPage Is Me.TabONE_KryptonPage Then
                            .Classes_ToolBox.Visible = True
                            .Fonctions_ToolBox.Visible = False
                        Else
                            .Classes_ToolBox.Visible = False
                            .Fonctions_ToolBox.Visible = True
                        End If
                    End With


                    SelectedActionChanged(DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).SelectedAction, New System.EventArgs)


                    ' Raffraichissement de la boîte à outils de l'éditeur
                    If DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Classes_ToolBox.Visible Then
                        With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Classes_ToolBox
                            If Not .SelectedNode Is Nothing AndAlso (DirectCast(.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 AndAlso Me.KryptonNavigator2.SelectedPage Is Me.TabONE_KryptonPage Then
                                DirectCast(Me.TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                                If Not .SelectedNode.Name = Nothing Then
                                    Dim types As Type = .SelectedNode.Tag
                                    If Not types = Nothing Then
                                        DirectCast(Me.TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                        DirectCast(Me.TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                                    End If
                                End If
                            End If
                        End With

                    ElseIf DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Fonctions_ToolBox.Visible Then
                        With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Fonctions_ToolBox
                            If Not .SelectedNode Is Nothing AndAlso (DirectCast(.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)).Level <> 0 AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 AndAlso Me.KryptonNavigator2.SelectedPage IsNot Me.TabONE_KryptonPage Then
                                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Clear()
                                If Not .SelectedNode.Name = Nothing Then
                                    Dim types As Type = .SelectedNode.Tag
                                    If Not types = Nothing Then
                                        DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories.Add(New System.Activities.Presentation.Toolbox.ToolboxCategory("Action"))
                                        DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ToolboxControl.Categories(0).Add(New System.Activities.Presentation.Toolbox.ToolboxItemWrapper(types))
                                    End If
                                End If
                            End If
                        End With
                    End If

                    ' Configuration du ruban
                    .Enregistrer_KryptonRibbonGroupButton.Enabled = True
                    .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = True

                    .VbNet_KryptonRibbonGroupButton.Enabled = False
                    .CSharp_KryptonRibbonGroupButton.Enabled = False

                    .Imprimer_KryptonRibbonGroupButton.Enabled = True
                    .Impression_Rapide_KryptonRibbonGroupButton.Enabled = True
                    .Apercu_Impression_KryptonRibbonGroupButton.Enabled = True

                    .Coller_KryptonRibbonGroupButton.Enabled = True
                    .Copier_KryptonRibbonGroupButton.Enabled = True
                    .Couper_KryptonRibbonGroupButton.Enabled = True

                    .Annuler_KryptonRibbonGroupButton.Enabled = True
                    .Retablir_KryptonRibbonGroupButton.Enabled = True
                    .Supprimer_KryptonRibbonGroupButton.Enabled = True
                    .Selectionner_tout_KryptonRibbonGroupButton.Enabled = True

                    .QAT_Annuler.Enabled = True
                    .QAT_Coller.Enabled = True
                    .QAT_Copier.Enabled = True
                    .QAT_Couper.Enabled = True
                    .QAT_Enregistrer_Sous.Enabled = True
                    .QAT_Retablir.Enabled = True

                    .KryptonRibbon1.SelectedContext = "Editeur_Fonctions"
                End With
            End If
        End If
    End Sub






    Private Sub KryptonLinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonLinkLabel1.LinkClicked
        If Me.Panel3.Height = 100 Then
            Me.Panel3.Height = 20
            Me.KryptonLinkLabel1.Text = RM.GetString("Maximize_Panel")
        Else
            Me.Panel3.Height = 100
            Me.KryptonLinkLabel1.Text = RM.GetString("Minimize_Panel")
        End If
    End Sub
















#Region "Concepteur de vue"

    Friend Sub Panel1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Panel1.DragDrop
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            If e.Data.GetDataPresent(GetType(System.Drawing.Design.ToolboxItem)) OrElse e.Data.GetDataPresent(GetType(Object)) Then
                Dim Nom_Ctrl_Actif As String
                If Not SelectionService.PrimarySelection.GetType.BaseType.FullName = "System.ComponentModel.Component" Then
                    If DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Contains("[") Then
                        Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
                    Else
                        Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.GetType.GetProperty("Name").GetValue(DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject, Nothing)
                    End If
                Else
                    Nom_Ctrl_Actif = SelectionService.PrimarySelection.ToString.Split("[")(0).TrimEnd(" ")
                End If

                Dim listTypes() As Type
                Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl
                For Each a As VelerSoftware.SZVB.Projet.Reference In Me.CodeDomHostLoader.Ass
                    If Not a Is Nothing AndAlso Not a.Assembly Is Nothing AndAlso a.Assembly.FullName = DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Concepteur_Fenetre_ToolBox.SelectedNode.Tag Then

                        listTypes = h.LoadControlsFromAssembly(a.Assembly)
                        If listTypes.Length > 0 Then
                            For i = 0 To listTypes.Length - 1
                                'If listTypes(i).FullName = DirectCast(DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Concepteur_Fenetre_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).Name Then
                                If TryCast(a.Assembly.CreateInstance(listTypes(i).FullName), Control) Is Nothing Then
                                    Dim objt As System.ComponentModel.Component = DirectCast(a.Assembly.CreateInstance(listTypes(i).FullName), System.ComponentModel.Component)
                                    Me.Designer.ComponentContainer.Add(objt)
                                    GoTo _gg
                                Else
                                    Dim objt As Control = DirectCast(a.Assembly.CreateInstance(listTypes(i).FullName), Control)
                                    objt.Visible = True
                                    If SelectionService.SelectionCount = 0 Then
                                        objt.Parent = Me.Designer.ComponentContainer.Components(0)
                                        If objt.Size.Height <= 1 Or objt.Size.Width <= 1 Then
                                            objt.Size = New System.Drawing.Point(50, 50)
                                        End If
                                        objt.Location = PointToClient(MousePosition) - New System.Drawing.Point(25, 50)
                                        Me.Designer.ComponentContainer.Add(objt)
                                        GoTo _gg
                                    Else
                                        objt.Parent = Me.Designer.ComponentContainer.Components(Nom_Ctrl_Actif)
                                        If objt.Size.Height <= 1 Or objt.Size.Width <= 1 Then
                                            objt.Size = New System.Drawing.Point(50, 50)
                                        End If
                                        objt.Location = PointToClient(MousePosition) - New System.Drawing.Point(25, 50)
                                        Me.Designer.ComponentContainer.Add(objt)
                                        GoTo _gg
                                    End If
                                End If
                                'End If
                            Next
                        End If

                        ' AX !
                        For Each Type As Type In a.Assembly.GetTypes()
                            If Type.IsSubclassOf(GetType(AxHost)) AndAlso Not Type.BaseType.FullName = "System.Windows.Forms.Form" Then
                                'If Type.FullName = DirectCast(Form1.Boite_A_Outils.Concepteur_ToolBox.SelectedNode, VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode).ToolTipCaption Then
                                If TryCast(a.Assembly.CreateInstance(Type.FullName), Control) Is Nothing Then
                                    Dim objt As System.ComponentModel.Component = DirectCast(a.Assembly.CreateInstance(Type.FullName), System.ComponentModel.Component)
                                    Me.Designer.ComponentContainer.Add(objt)
                                    GoTo _gg
                                Else
                                    Dim objt As AxHost = DirectCast(a.Assembly.CreateInstance(Type.FullName), AxHost)
                                    objt.Visible = True
                                    If SelectionService.SelectionCount = 0 Then
                                        objt.Parent = Me.Designer.ComponentContainer.Components(0)
                                        If objt.Size.Height <= 1 Or objt.Size.Width <= 1 Then
                                            objt.Size = New System.Drawing.Size(100, 50)
                                        End If
                                        objt.Location = PointToClient(MousePosition) - New System.Drawing.Point(25, 50)
                                        Me.Designer.ComponentContainer.Add(objt)
                                        GoTo _gg
                                    Else
                                        objt.Parent = Me.Designer.ComponentContainer.Components(Nom_Ctrl_Actif)
                                        If objt.Size.Height <= 1 Or objt.Size.Width <= 1 Then
                                            objt.Size = New System.Drawing.Size(100, 50)
                                        End If
                                        objt.Location = PointToClient(MousePosition) - New System.Drawing.Point(25, 50)
                                        Me.Designer.ComponentContainer.Add(objt)
                                        GoTo _gg
                                    End If
                                End If
                                'End If
                            End If
                        Next

                    End If
                Next
_gg:
                componentChangeService_ComponentChanged(Nothing, Nothing)
            End If

            DocumentModifier()
        End If
    End Sub

    Private Sub Designer_OnEndLoaded(ByVal sender As Object, ByVal e As System.ComponentModel.Design.LoadedEventArgs)
        If Not e.HasSucceeded Then
            Dim Er As New DocConcepteurFenetreErreurs

            Erreur_Chargement_Concepteur_Fenetre = True
            Me.Panel2.Visible = False
            Me.Panel3.Visible = False

            Dim ie As IEnumerator = e.Errors.GetEnumerator()
            While ie.MoveNext()
                If ie.Current.ToString.Contains("|") Then
                    Er.KryptonListBox1.Items.Add("Component type not found : " & ie.Current.ToString.Split("|")(1))
                    Log_Projet.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, "Component type not found : " & ie.Current.ToString.Split("|")(1)))
                Else
                    Er.KryptonListBox1.Items.Add("Other error : " & DirectCast(ie.Current, Exception).Message & " Stack trace : " & DirectCast(ie.Current, Exception).StackTrace)
                    Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, "Other error : " & DirectCast(ie.Current, Exception).Message & " Stack trace : " & DirectCast(ie.Current, Exception).StackTrace))
                End If
            End While

            Er.BackColor = Color.Transparent
            Er.BorderStyle = Windows.Forms.BorderStyle.None
            Er.Dock = DockStyle.Fill
            Me.Concepteur_Fenetre_KryptonPage.Controls.Add(Er)
        Else

            ' Pour la commande "ViewCode"
            AddHandler Me.Designer.OnExecuteViewCode, AddressOf Me.Designer_OnExecuteViewCode
            ' Pour la commande "Properties"
            AddHandler Me.Designer.OnExecuteViewProperty, AddressOf Me.Designer_OnExecuteViewProperty
            ' Pour la commande "Créer un évènement"
            AddHandler Me.Designer.OnExecuteCreateEvent, AddressOf Me.Designer_OnExecuteCreateEvent_KryptonButton1_Click
            ' Pour la commande "Sélectionner"
            AddHandler Me.Designer.OnSelectComponentEvent, AddressOf Me.Designer_OnSelectComponent
            ' Sérialisé
            AddHandler Me.Designer.Flushed, AddressOf Me.Designer_Flushed

            ' On spécifie que la vu du designer s’étends sur tout le control qui va l’acceuillir
            With DirectCast(Me.Designer.View, Control)
                .BackColor = System.Drawing.SystemColors.Window
                .Dock = DockStyle.Fill
                'Pour la gestion du drag and drop des toolboxItems
                .AllowDrop = True
                AddHandler .DragDrop, AddressOf Me.Panel1_DragDrop
                AddHandler .Paint, AddressOf View_Paint
                .Refresh()
            End With



            ' Ajout de la vu du designer dans le panel
            Me.Panel1.Controls.Add(DirectCast(Me.Designer.View, Control))
        End If
    End Sub

    Private Sub Designer_Flushed(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim rs As VelerSoftware.SZC.WindowsDesigner.ResourceService = DirectCast(Me.Host.GetService(GetType(System.ComponentModel.Design.IResourceService)), VelerSoftware.SZC.WindowsDesigner.ResourceService)
        If rs Is Nothing Then
            Me.Host.AddService(GetType(System.ComponentModel.Design.IResourceService), New VelerSoftware.SZC.WindowsDesigner.ResourceService(Host, Resx_File_Path))
            rs = DirectCast(Me.Host.GetService(GetType(System.ComponentModel.Design.IResourceService)), VelerSoftware.SZC.WindowsDesigner.ResourceService)
        End If
        rs.reader = New Resources.ResXResourceReader(Resx_File_Path)
        rs.writer = New Resources.ResXResourceWriter(Resx_File_Path)
    End Sub

    ' Composant sélectionné
    Sub selectionService_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        With Me
            If .FinishLoad Then
                If Not Erreur_Chargement_Concepteur_Fenetre Then
                    With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes)
                        .PropertyGrids1.SelectedObjects = Nothing
                        .PropertyGrids1.Item.Clear()
                        .PropertyGrids1.ItemSet.Clear()
                        .PropertyGrids1.ShowCustomProperties = True
                        .PropertyGrids1.SelectedObjects = SelectionService.GetSelectedComponents
                    End With

                    Try
                        If Not SelectionService.PrimarySelection Is Nothing Then
                            If Not DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject Is Nothing Then
                                Dim Nom_Ctrl_Actif As String
                                If Not SelectionService.PrimarySelection.GetType.BaseType.FullName = "System.ComponentModel.Component" Then
                                    If Not SelectionService.PrimarySelection Is Nothing Then
                                        If DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Contains("[") Then
                                            Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
                                        Else
                                            Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.GetType.GetProperty("Name").GetValue(DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject, Nothing)
                                        End If
                                    Else
                                        Nom_Ctrl_Actif = Nothing
                                    End If
                                Else
                                    Nom_Ctrl_Actif = SelectionService.PrimarySelection.ToString.Split("[")(0).TrimEnd(" ")
                                End If

                                .KryptonTextBox1.Enabled = True
                                .KryptonLabel1.Enabled = True
                                DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & Nom_Ctrl_Actif & " {\b(" & SelectionService.PrimarySelection.GetType.FullName & ")}}"
                                If SelectionService.SelectionCount = 1 Then
                                    .can_change = False
                                    .OldName = Nom_Ctrl_Actif
                                    .KryptonTextBox1.Text = Nom_Ctrl_Actif
                                    .KryptonButton1.Enabled = True
                                    .KryptonTextBox1.Enabled = True
                                    .KryptonLabel1.Enabled = True
                                    .can_change = True
                                Else
                                    .KryptonButton1.Enabled = False
                                    .KryptonTextBox1.Enabled = False
                                    .KryptonLabel1.Enabled = False
                                    .KryptonTextBox1.Text = Nothing
                                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = Nothing
                                End If
                            Else
                                .KryptonButton1.Enabled = False
                                .KryptonTextBox1.Enabled = False
                                .KryptonLabel1.Enabled = False
                                .KryptonTextBox1.Text = Nothing
                                DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = Nothing
                            End If
                        Else
                            .KryptonButton1.Enabled = False
                            .KryptonTextBox1.Enabled = False
                            .KryptonLabel1.Enabled = False
                            .KryptonTextBox1.Text = Nothing
                            DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = Nothing
                        End If
                    Catch err As Exception
                        .KryptonButton1.Enabled = False
                        .KryptonTextBox1.Enabled = False
                        .KryptonLabel1.Enabled = False
                        .KryptonTextBox1.Text = Nothing
                        DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = Nothing
                    End Try
                End If
            End If
        End With
    End Sub

    ' Composant ajouté
    Sub componentChangeService_ComponentAdded(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentEventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            DocumentModifier()
            DirectCast(Me.Designer.View, Control).Refresh()
            Me.ToolBoxs.SetCursorOff()
        End If
    End Sub

    ' Composant supprimé
    Sub componentChangeService_ComponentRemoved(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentEventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            DocumentModifier()
        End If
    End Sub

    ' Composant renommé
    Sub componentChangeService_ComponentRename(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentRenameEventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes)
                .PropertyGrids1.SelectedObjects = Nothing
                .PropertyGrids1.Item.Clear()
                .PropertyGrids1.ItemSet.Clear()
                .PropertyGrids1.ShowCustomProperties = True
                .PropertyGrids1.SelectedObjects = SelectionService.GetSelectedComponents
            End With



            If e.Component Is Me.Designer.ComponentContainer.Components(0) Then
                Me.TabONE_KryptonPage.Text = Me.Designer.ComponentContainer.Components(0).Site.Name
                With DirectCast(Me.TabONE_KryptonPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root
                    If .ItemType.BaseType = GetType(VelerSoftware.Plugins3.ActionWithChildren) Then
                        DirectCast(.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName = Me.TabONE_KryptonPage.Text
                        DirectCast(.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Me.TabONE_KryptonPage.Text
                    End If
                End With
            End If

            Dim Nom_Ctrl_Actif As String
            If Not SelectionService.PrimarySelection.GetType.BaseType.FullName = "System.ComponentModel.Component" Then
                If DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Contains("[") Then
                    Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
                Else
                    Nom_Ctrl_Actif = DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject.GetType.GetProperty("Name").GetValue(DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1.SelectedObject, Nothing)
                End If
            Else
                Nom_Ctrl_Actif = SelectionService.PrimarySelection.ToString.Split("[")(0).TrimEnd(" ")
            End If


            If SelectionService.SelectionCount = 1 Then
                Me.can_change = False
                Me.OldName = Nom_Ctrl_Actif
                Me.KryptonTextBox1.Text = Nom_Ctrl_Actif
                DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & Me.KryptonTextBox1.Text & " {\b(" & Me.SelectionService.PrimarySelection.GetType.FullName & ")}}"
                Me.KryptonButton1.Enabled = True
                Me.KryptonTextBox1.Enabled = True
                Me.KryptonLabel1.Enabled = True
                Me.can_change = True
            Else
                Me.KryptonButton1.Enabled = False
                Me.KryptonTextBox1.Enabled = False
                Me.KryptonLabel1.Enabled = False
            End If


            'For Each TAB As VelerSoftware.SZC.CustomTab.TabPageEx In Me.CustomTabControl2.Controls
            '    If DirectCast(TAB.Controls(0), doc_Editeur_Fonctions_Editeur).Param2.StartsWith("Handles", StringComparison.OrdinalIgnoreCase) Then
            '        tmp = Split(DirectCast(TAB.Controls(0), doc_Editeur_Fonctions_Editeur).Param2, ".")
            '        If tmp(0) = "Handles " & e.OldName Then
            '            For Each TAB2 As VelerSoftware.SZC.CustomTab.TabPageEx In Me.CustomTabControl2.Controls
            '                tmp = Split(DirectCast(TAB2.Controls(0), doc_Editeur_Fonctions_Editeur).Param2, ".")
            '                If tmp(0) = "Handles " & e.OldName Then
            '                    DirectCast(TAB2.Controls(0), doc_Editeur_Fonctions_Editeur).Param2 = "Handles " & e.NewName & "." & tmp(1)
            '                End If
            '            Next
            '        End If
            '    End If
            'Next

            DocumentModifier()
        End If
    End Sub

    ' Composant changé
    Sub componentChangeService_ComponentChanged(ByVal sender As Object, ByVal e As System.ComponentModel.Design.ComponentChangedEventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            DocumentModifier()
        End If
    End Sub

    ' Commande "ViewCode"
    Sub Designer_OnExecuteViewCode(ByVal sender As Object, ByVal e As EventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Me.KryptonNavigator1.SelectedPage = Me.Editeur_Fonction_KryptonPage
        End If
    End Sub

    ' Commande "Properties"
    Sub Designer_OnExecuteViewProperty(ByVal sender As Object, ByVal e As EventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            selectionService_SelectionChanged(sender, e)
            If Not Form1.Box_Proprietes Is Nothing Then
                If TypeOf Form1.Box_Proprietes.KryptonParentContainer Is VelerSoftware.Design.Workspace.KryptonWorkspaceCell Then
                    DirectCast(Form1.Box_Proprietes.KryptonParentContainer, VelerSoftware.Design.Workspace.KryptonWorkspaceCell).SelectedPage = Form1.Box_Proprietes
                ElseIf TypeOf Form1.Box_Proprietes.KryptonParentContainer Is VelerSoftware.Design.Navigator.KryptonPage Then
                    Form1.KryptonDockingManager1.SwitchAutoHiddenGroupToDockedCellRequest("Propriétés")
                End If
            End If
        End If
    End Sub

    ' Commande "Sélectionner"
    Sub Designer_OnSelectComponent(ByVal sender As Object, ByVal e As EventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre Then
            Me.SelectionService.SetSelectedComponents(New System.ComponentModel.Component() {sender.Tag})
        End If
    End Sub

    ' Créer un évènement
    Private Sub Designer_OnExecuteCreateEvent_KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre AndAlso Me.KryptonButton1.Enabled Then
            For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
                If TAB.Controls.Count > 0 AndAlso DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content52"))
                        .MainInstruction = RM.GetString("MainInstruction10")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    Exit Sub
                End If
            Next

            With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1
                .SelectedObjects = Nothing
                .Item.Clear()
                .ItemSet.Clear()
                .ShowCustomProperties = True
                .SelectedObjects = SelectionService.GetSelectedComponents

                If Not .SelectedObject Is Nothing Then
                    Dim Nom_Ctrl_Actif As String
                    If Not .SelectedObject.GetType.BaseType.FullName = "System.ComponentModel.Component" Then
                        If .SelectedObject.ToString.Contains("[") Then
                            Nom_Ctrl_Actif = .SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
                        Else
                            Nom_Ctrl_Actif = .SelectedObject.GetType.GetProperty("Name").GetValue(.SelectedObject, Nothing)
                        End If
                    Else
                        Nom_Ctrl_Actif = .SelectedObject.ToString.Split("[")(0).TrimEnd(" ")
                    End If


                    Using Creer As New CreerEvenement
                        Dim ite As ListViewItem = Nothing

                        Dim mi() As Reflection.EventInfo
                        Dim can_exit As Boolean = False
                        Dim Events As System.ComponentModel.EventDescriptorCollection
                        Dim h As New VelerSoftware.SZC.WindowsDesigner.AssemblyControl

                        If Not Me.SelectionService.SelectionCount = 0 Then
                            For Each a As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(Me.Nom_Projet).References
                                If Not a Is Nothing Then
                                    If Not a.Assembly Is Nothing Then
                                        For Each tip As Type In h.LoadTypesFromAssembly(a.Assembly)
                                            If tip = .SelectedObject.GetType Then
                                                Dim t As Type = .SelectedObject.GetType
                                                mi = t.GetEvents 'liste toutes les Method de ce type (sub ou function)
                                                For Each m As Reflection.EventInfo In mi
                                                    Events = System.ComponentModel.TypeDescriptor.GetEvents(t)

                                                    ite = New ListViewItem
                                                    ite.Text = m.Name
                                                    ite.SubItems.Add(Events.Find(m.Name, True).Description)

                                                    '*** Recupere tous les Paramettres ***
                                                    Dim Param As String = ""
                                                    Dim EventHandler As Type = m.EventHandlerType
                                                    For Each e2 As Reflection.ParameterInfo In EventHandler.GetMethod("Invoke").GetParameters
                                                        Param = Param & " " & IIf(e2.ParameterType.IsByRef = False, "ByVal", "ByRef") & " " & e2.Name & " As " & e2.ParameterType.ToString & ","
                                                    Next
                                                    If Param <> Nothing Then Param = Mid(Param, 2, Param.Length - 2)
                                                    '*** Complete la ligne ***
                                                    ite.Tag = Param

                                                    If Creer.ListView2.Groups(Events.Find(m.Name, True).Category) Is Nothing Then
                                                        Creer.ListView2.Groups.Add(Events.Find(m.Name, True).Category, Events.Find(m.Name, True).Category)
                                                    End If
                                                    ite.Group = Creer.ListView2.Groups(Events.Find(m.Name, True).Category)

                                                    Creer.ListView2.Items.Add(ite)
                                                Next
                                                can_exit = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    If can_exit Then Exit For
                                    a = Nothing
                                End If
                            Next
                        End If
                        If Not Me.SelectionService.SelectionCount = 0 AndAlso Not Nom_Ctrl_Actif Is Nothing Then
                            If Me.Host.RootComponent.Site.Name = Nom_Ctrl_Actif Then
                                Creer.Ctrl = "Me"
                                Creer.Ctrl2 = Nom_Ctrl_Actif
                                Creer.Tip = .SelectedObject.GetType.FullName
                            Else
                                Creer.Ctrl = Nom_Ctrl_Actif
                                Creer.Ctrl2 = Nom_Ctrl_Actif
                                Creer.Tip = .SelectedObject.GetType.FullName
                            End If
                        End If

                        Creer.ShowDialog()
                        Creer.Dispose()
                    End Using

                End If
            End With
        End If
    End Sub

    Private Sub KryptonTextBox1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonTextBox1.Validated
        If can_change Then
            Try
                If Not Me.Erreur_Chargement_Concepteur_Fenetre AndAlso Not Me.KryptonTextBox1.Text = OldName AndAlso Not Me.Designer Is Nothing Then
                    Me.Designer.ComponentContainer.Components(OldName).Site.Name = Me.KryptonTextBox1.Text
                    OldName = Me.KryptonTextBox1.Text
                    With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes)
                        .PropertyGrids1.SelectedObjects = Nothing
                        .PropertyGrids1.Item.Clear()
                        .PropertyGrids1.ItemSet.Clear()
                        .PropertyGrids1.ShowCustomProperties = True
                        .PropertyGrids1.SelectedObjects = Me.SelectionService.GetSelectedComponents
                        .KryptonRichTextBox1.Rtf = "{\rtf1" & Me.KryptonTextBox1.Text & " {\b(" & Me.SelectionService.PrimarySelection.GetType.FullName & ")}}"
                    End With
                End If
            Catch ex As Exception
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = RM.GetString("Content13")
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
                Me.KryptonTextBox1.Text = OldName
            End Try
        End If
    End Sub

    Private Sub KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KryptonTextBox1.KeyPress
        Dim oki As Boolean = True
        For Each strr As String In Caractères_Interdit_Non_Numerique
            If e.KeyChar.ToString.Contains(strr) Then oki = False : e.Handled = True : Exit For
        Next
        If oki Then
            Select Case e.KeyChar
                Case ChrW(Keys.Space)
                    e.Handled = True
                Case Else
                    e.Handled = False
            End Select
        End If
    End Sub



    Sub View_Paint(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.FinishLoad AndAlso Not Erreur_Chargement_Concepteur_Fenetre AndAlso DirectCast(Me.Designer.View, Control).Controls.Count = 3 AndAlso Not DirectCast(Me.Designer.View, Control).Controls(1).BackColor = System.Drawing.Color.FromArgb(187, 206, 230) Then
            DirectCast(Me.Designer.View, Control).Controls(1).BackColor = System.Drawing.Color.FromArgb(187, 206, 230)
        End If
    End Sub

#End Region

#Region "Editeur de fonctions"

    Public Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If VelerSoftware.SZVB.VistaDialog.VDialog.Show(Me, RM.GetString("Content21"), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If DirectCast(DirectCast(sender, VelerSoftware.Design.Toolkit.ButtonSpecAny).Owner, VelerSoftware.Design.Navigator.KryptonPage).Controls.Count > 0 AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\" & DirectCast(DirectCast(DirectCast(sender, VelerSoftware.Design.Toolkit.ButtonSpecAny).Owner, VelerSoftware.Design.Navigator.KryptonPage).Controls(0), DocEditeurFonctionsUserControl).TempXAMLFileName) Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\" & DirectCast(DirectCast(DirectCast(sender, VelerSoftware.Design.Toolkit.ButtonSpecAny).Owner, VelerSoftware.Design.Navigator.KryptonPage).Controls(0), DocEditeurFonctionsUserControl).TempXAMLFileName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
            Me.KryptonNavigator2.Pages.Remove(DirectCast(DirectCast(sender, VelerSoftware.Design.Toolkit.ButtonSpecAny).Owner, VelerSoftware.Design.Navigator.KryptonPage))
            Me.DocumentModifier()
        End If
    End Sub

    Private Sub ButtonSpecNavigator1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSpecNavigator1.Click
        Form1.Nouvelle_Fonction_KryptonRibbonGroupButton_Click(Nothing, Nothing)
    End Sub

    Public Sub SelectedActionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        With DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).PropertyGrids1
            If FinishLoad AndAlso KryptonNavigator1.SelectedPage Is Editeur_Fonction_KryptonPage Then
                If sender Is Nothing Then
                    .SelectedObjects = Nothing
                    .Item.Clear()
                    .ItemSet.Clear()
                    .ShowCustomProperties = True
                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = Nothing
                Else
                    Dim action As VelerSoftware.Plugins3.Action = sender

                    .SelectedObjects = Nothing
                    .Item.Clear()
                    .ItemSet.Clear()
                    .ShowCustomProperties = True
                    .Refresh()

                    Dim prop1 As String = RM.GetString("Editeur_Fonctions_Action_Proprietes1")
                    Dim prop2 As String = RM.GetString("Editeur_Fonctions_Action_Proprietes2")
                    Dim prop3 As String = RM.GetString("Editeur_Fonctions_Action_Proprietes3")

                    If Not action.Param1 = Nothing Then .Item.Add(prop1 & " 1", action.Param1, True, prop2, prop3 & " 1", True)
                    If Not action.Param2 = Nothing Then .Item.Add(prop1 & " 2", action.Param2, True, prop2, prop3 & " 2", True)
                    If Not action.Param3 = Nothing Then .Item.Add(prop1 & " 3", action.Param3, True, prop2, prop3 & " 3", True)
                    If Not action.Param4 = Nothing Then .Item.Add(prop1 & " 4", action.Param4, True, prop2, prop3 & " 4", True)
                    If Not action.Param5 = Nothing Then .Item.Add(prop1 & " 5", action.Param5, True, prop2, prop3 & " 5", True)
                    If Not action.Param6 = Nothing Then .Item.Add(prop1 & " 6", action.Param6, True, prop2, prop3 & " 6", True)
                    If Not action.Param7 = Nothing Then .Item.Add(prop1 & " 7", action.Param7, True, prop2, prop3 & " 7", True)
                    If Not action.Param8 = Nothing Then .Item.Add(prop1 & " 8", action.Param8, True, prop2, prop3 & " 8", True)
                    If Not action.Param9 = Nothing Then .Item.Add(prop1 & " 9", action.Param9, True, prop2, prop3 & " 9", True)
                    If Not action.Param10 = Nothing Then .Item.Add(prop1 & " 10", action.Param10, True, prop2, prop3 & " 10", True)
                    If Not action.Param11 = Nothing Then .Item.Add(prop1 & " 11", action.Param11, True, prop2, prop3 & " 11", True)
                    If Not action.Param12 = Nothing Then .Item.Add(prop1 & " 12", action.Param12, True, prop2, prop3 & " 12", True)
                    If Not action.Param13 = Nothing Then .Item.Add(prop1 & " 13", action.Param13, True, prop2, prop3 & " 13", True)
                    If Not action.Param14 = Nothing Then .Item.Add(prop1 & " 14", action.Param14, True, prop2, prop3 & " 14", True)
                    If Not action.Param15 = Nothing Then .Item.Add(prop1 & " 15", action.Param15, True, prop2, prop3 & " 15", True)
                    If Not action.Param16 = Nothing Then .Item.Add(prop1 & " 16", action.Param16, True, prop2, prop3 & " 16", True)
                    If Not action.Param17 = Nothing Then .Item.Add(prop1 & " 17", action.Param17, True, prop2, prop3 & " 17", True)
                    If Not action.Param18 = Nothing Then .Item.Add(prop1 & " 18", action.Param18, True, prop2, prop3 & " 18", True)
                    If Not action.Param19 = Nothing Then .Item.Add(prop1 & " 19", action.Param19, True, prop2, prop3 & " 19", True)
                    If Not action.Param20 = Nothing Then .Item.Add(prop1 & " 20", action.Param20, True, prop2, prop3 & " 20", True)
                    If Not action.Param21 = Nothing Then .Item.Add(prop1 & " 21", action.Param21, True, prop2, prop3 & " 21", True)
                    If Not action.Param22 = Nothing Then .Item.Add(prop1 & " 22", action.Param22, True, prop2, prop3 & " 22", True)
                    If Not action.Param23 = Nothing Then .Item.Add(prop1 & " 23", action.Param23, True, prop2, prop3 & " 23", True)
                    If Not action.Param24 = Nothing Then .Item.Add(prop1 & " 24", action.Param24, True, prop2, prop3 & " 24", True)
                    If Not action.Param25 = Nothing Then .Item.Add(prop1 & " 25", action.Param25, True, prop2, prop3 & " 25", True)
                    If Not action.Param26 = Nothing Then .Item.Add(prop1 & " 26", action.Param26, True, prop2, prop3 & " 26", True)
                    If Not action.Param27 = Nothing Then .Item.Add(prop1 & " 27", action.Param27, True, prop2, prop3 & " 27", True)
                    If Not action.Param28 = Nothing Then .Item.Add(prop1 & " 28", action.Param28, True, prop2, prop3 & " 28", True)
                    If Not action.Param29 = Nothing Then .Item.Add(prop1 & " 29", action.Param29, True, prop2, prop3 & " 29", True)
                    If Not action.Param30 = Nothing Then .Item.Add(prop1 & " 30", action.Param30, True, prop2, prop3 & " 30", True)
                    If Not action.Param31 = Nothing Then .Item.Add(prop1 & " 31", action.Param31, True, prop2, prop3 & " 31", True)
                    If Not action.Param32 = Nothing Then .Item.Add(prop1 & " 32", action.Param32, True, prop2, prop3 & " 32", True)
                    If Not action.Param33 = Nothing Then .Item.Add(prop1 & " 33", action.Param33, True, prop2, prop3 & " 33", True)
                    If Not action.Param34 = Nothing Then .Item.Add(prop1 & " 34", action.Param34, True, prop2, prop3 & " 34", True)
                    If Not action.Param35 = Nothing Then .Item.Add(prop1 & " 35", action.Param35, True, prop2, prop3 & " 35", True)
                    If Not action.Param36 = Nothing Then .Item.Add(prop1 & " 36", action.Param36, True, prop2, prop3 & " 36", True)
                    If Not action.Param37 = Nothing Then .Item.Add(prop1 & " 37", action.Param37, True, prop2, prop3 & " 37", True)
                    If Not action.Param38 = Nothing Then .Item.Add(prop1 & " 38", action.Param38, True, prop2, prop3 & " 38", True)
                    If Not action.Param39 = Nothing Then .Item.Add(prop1 & " 39", action.Param39, True, prop2, prop3 & " 39", True)
                    If Not action.Param40 = Nothing Then .Item.Add(prop1 & " 40", action.Param40, True, prop2, prop3 & " 40", True)

                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes5"), action.DisplayName, True, RM.GetString("Editeur_Fonctions_Action_Proprietes4"), RM.GetString("Editeur_Fonctions_Action_Proprietes6"), True)
                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes7"), action.Description, True, RM.GetString("Editeur_Fonctions_Action_Proprietes4"), RM.GetString("Editeur_Fonctions_Action_Proprietes8"), True)
                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes9"), action.Category, True, RM.GetString("Editeur_Fonctions_Action_Proprietes4"), RM.GetString("Editeur_Fonctions_Action_Proprietes10"), True)
                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes12"), action.References.AsReadOnly, True, RM.GetString("Editeur_Fonctions_Action_Proprietes11"), RM.GetString("Editeur_Fonctions_Action_Proprietes3"), True)
                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes14"), action.Voice_Recognition_Dictionary.AsReadOnly, True, RM.GetString("Editeur_Fonctions_Action_Proprietes11"), RM.GetString("Editeur_Fonctions_Action_Proprietes5"), True)
                    .Item.Add(RM.GetString("Editeur_Fonctions_Action_Proprietes16"), action.Voice_Recognition_Expressions_Dictionary.AsReadOnly, True, RM.GetString("Editeur_Fonctions_Action_Proprietes11"), RM.GetString("Editeur_Fonctions_Action_Proprietes7"), True)
                    .Refresh()

                    DirectCast(Form1.Box_Proprietes.Controls(0), BoxProprietes).KryptonRichTextBox1.Rtf = "{\rtf1" & action.DisplayName & " {\b(Action)}}"
                End If
            End If
        End With
    End Sub

#End Region

End Class
