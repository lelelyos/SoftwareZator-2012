''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocEditeurFonctions

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

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Editeur_Fonctions

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
        End If
        If Modifier Then
            If Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomFichier & "*"
            End If
        End If
    End Sub ' Document modifié








    Public Function Charger(ByVal Nom_A_Donner As String) As Boolean
        Dim RESULTAT As Boolean = True

        'Me.File = New VelerSoftware.SZVB.Projet.SZC_File("Class1")
        'Me.File.Nom = "Class1"
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
            Me.File = DirectCast(deserializer.Deserialize(myFileStream), VelerSoftware.SZVB.Projet.SZC_File)
        Catch ex As Exception
            myFileStream.Close()
            Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Error, ex.Message))
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


            Me.TabONE_KryptonPage.Text = Me.File.Nom

            Charger_Editeur_Code(Nom_A_Donner)

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

            If ClassFichier.IsReadOnly(Me.NomCompletFichier) Then
                If Not Form1.Info_Bar1.Visible Then
                    Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("InfoBar_5_Description"), Me.NomFichier), Nothing, False, "Read_Only", Nothing)
                End If
            End If

        End If

        Return RESULTAT
    End Function

    Private Sub Charger_Editeur_Code(ByVal Nom_A_Donner As String)
        Dim i As Integer = 0
        For Each txt As String In Me.File.Functions
            i += 1
            If i = 1 Then
                Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
                editor.Dock = DockStyle.Fill
                editor.IsWindow = False
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

                Me.TabONE_KryptonPage.Controls.Add(editor)
                Me.TabONE_KryptonPage.Text = Me.File.Nom
                If Not Nom_A_Donner = Nothing Then
                    Try
                        If editor.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType = GetType(VelerSoftware.Plugins3.ActionWithChildren) Then
                            DirectCast(editor.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName = Me.TabONE_KryptonPage.Text
                            DirectCast(editor.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Me.TabONE_KryptonPage.Text
                        End If
                    Catch
                    End Try
                    Modifier = True
                End If

                AddHandler editor.SelectedActionChanger, AddressOf Me.SelectedActionChanged

            Else
                Dim editor As DocEditeurFonctionsUserControl = New DocEditeurFonctionsUserControl
                editor.Dock = DockStyle.Fill
                editor.IsWindow = False
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

                AddHandler editor.SelectedActionChanger, AddressOf Me.SelectedActionChanged
            End If
        Next
    End Sub









    Public Sub Enregistrer(ByVal Enregistrer_SOUS As Boolean)

        ' Fonctions
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\Temp\Functions\") Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\Temp\Functions")
        End If
        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
            If TAB.Controls.Count > 0 Then
                If DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).Erreur_Chargement Then
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
            End If
        Next
        Me.File.Functions.Clear()
        For Each TAB As VelerSoftware.Design.Navigator.KryptonPage In Me.KryptonNavigator2.Pages
            If TAB Is Me.TabONE_KryptonPage Then
                If TAB.Controls.Count > 0 Then
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
                    Me.File.Nom = DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue.Param1
                    DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\Function.xaml")
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                        Me.File.Functions.Insert(0, My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Temp\Functions\Function.xaml"))
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
                End If
            Else
                If TAB.Controls.Count > 0 Then
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
                    DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\Function.xaml")
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                        Me.File.Functions.Add(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Temp\Functions\Function.xaml"))
                        My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
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
            Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Enregistrer_Document_Filtre_3")
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










    Public Sub Coller()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Coller()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Copier()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Copier()
            End If
        End If
    End Sub

    Public Sub Couper()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Couper()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Undo()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Annuler()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Redo()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Rétablir()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub SelectionnerTout()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).SelectionnerTout()
                DocumentModifier()
            End If
        End If
    End Sub

    Public Sub Supprimer()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Couper()
                DocumentModifier()
            End If
        End If
    End Sub








    Public Sub Imprimer()
        DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Imprimer()
    End Sub

    Public Sub Impression_Rapide()
        DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Impression_Rapide()
    End Sub

    Public Sub Apercu_Avant_Impression()
        DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Apercu_Avant_Impression()
    End Sub






    Public Sub NouvelleFonction()
        If Me.FinishLoad Then
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
                                    If Not DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1 = Nothing Then
                                        If DirectCast(DirectCast(TAB.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Param1.ToLower = Fonction.Param1.ToLower Then
                                            ok = False
                                            Exit For
                                        End If
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
                                    editor.IsWindow = False
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
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Modifier_Action()
            End If
        End If
    End Sub

    Public Sub ZoomIn()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomIn()
            End If
        End If
    End Sub

    Public Sub ZoomOut()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomOut()
            End If
        End If
    End Sub

    Public Sub ZoomReset()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).ZoomReset()
            End If
        End If
    End Sub

    Public Sub EnregistrerImage()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).EnregistrerImage()
            End If
        End If
    End Sub

    Public Sub CopierImage()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).CopierImage()
            End If
        End If
    End Sub

    Public Sub Developper()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Developper()
            End If
        End If
    End Sub

    Public Sub Reduire()
        If Me.FinishLoad Then
            If TypeOf Me.KryptonNavigator2.SelectedPage.Controls(0) Is DocEditeurFonctionsUserControl Then
                DirectCast(Me.KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).Reduire()
            End If
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

#End Region

    Public File As VelerSoftware.SZVB.Projet.SZC_File



    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Annuler = False
            .Retablir = False

            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocEditeurFonctions))

            .KryptonNavigator2.SelectedIndex = 0
            'If .KryptonNavigator2.Pages.Count >= 1 Then
            '.KryptonNavigator2.SelectedIndex = 1
            'End If
        End With

        Me.FinishLoad = True
        Me.Annuler = True
        Me.Retablir = True

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
        End If

        Return resultat
    End Function

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

    Private Sub KryptonNavigator2_SelectedPageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonNavigator2.SelectedPageChanged
        Activate_Page()
    End Sub

    Friend Sub Activate_Page()
        If Me.FinishLoad Then
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
    End Sub


















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
        End With
    End Sub

#End Region

End Class
