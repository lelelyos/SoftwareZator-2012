''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocEditeurFonctionsUserControl

#Region "IsWindow"

    Public Property IsWindow() As Boolean

#End Region

#Region "IsFinishLoad"

    Public Property IsFinishLoad() As Boolean

#End Region

#Region "TempXAMLFileName"

    Public Property TempXAMLFileName() As String

#End Region

#Region "Gestion"

    ' Document modifié
    Public Sub DocumentModifier()
        If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
            DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).DocumentModifier()
        ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
            DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).DocumentModifier()
        End If
    End Sub

    Public Sub Copier()
        If Not WorkflowDesigne Is Nothing AndAlso Not Erreur_Chargement AndAlso WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount >= 1 AndAlso WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue IsNot WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue Then
            DirectCast(System.Activities.Presentation.View.DesignerView.CopyCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub Couper()
        If Not WorkflowDesigne Is Nothing AndAlso Not Erreur_Chargement AndAlso WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount >= 1 AndAlso WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue IsNot WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue Then
            DirectCast(System.Activities.Presentation.View.DesignerView.CutCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub Coller()
        If Not Erreur_Chargement AndAlso Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.PasteCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())

    End Sub

    Public Sub Annuler()
        If Not Erreur_Chargement AndAlso Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.UndoCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())

    End Sub

    Public Sub Rétablir()
        If Not Erreur_Chargement AndAlso Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.RedoCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())

    End Sub

    Public Sub SelectionnerTout()
        If Not Erreur_Chargement AndAlso Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.SelectAllCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())

    End Sub

    Public Sub ZoomIn()
        If Not Erreur_Chargement AndAlso Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.ZoomInCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())

    End Sub

    Public Sub ZoomOut()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.ZoomOutCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub ZoomReset()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.ResetZoomCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub EnregistrerImage()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.SaveAsImageCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub CopierImage()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.CopyAsImageCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub Developper()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.ExpandCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub Reduire()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.CollapseCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
        End If
    End Sub

    Public Sub Imprimer()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.CopyAsImageCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
            If My.Computer.Clipboard.ContainsImage Then
                Dim _Print As New VelerSoftware.SZVB.Print.PrintClass(VelerSoftware.SZVB.Print.Orientation.Automatic, DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text, True)
                _Print.AddImage(My.Computer.Clipboard.GetImage(), 0, 0)
                _Print.Print(False, True)
            End If
        End If
    End Sub

    Public Sub Impression_Rapide()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.CopyAsImageCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
            If My.Computer.Clipboard.ContainsImage Then
                Dim _Print As New VelerSoftware.SZVB.Print.PrintClass(VelerSoftware.SZVB.Print.Orientation.Automatic, DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text, True)
                _Print.AddImage(My.Computer.Clipboard.GetImage(), 0, 0)
                _Print.Print(False, False)
            End If
        End If
    End Sub

    Public Sub Apercu_Avant_Impression()
        If Not Erreur_Chargement Then
            If Not WorkflowDesigne Is Nothing Then DirectCast(System.Activities.Presentation.View.DesignerView.CopyAsImageCommand, System.Windows.Input.RoutedCommand).Execute(Nothing, WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)())
            If My.Computer.Clipboard.ContainsImage Then
                Dim _Print As New VelerSoftware.SZVB.Print.PrintClass(VelerSoftware.SZVB.Print.Orientation.Automatic, DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text, True)
                _Print.AddImage(My.Computer.Clipboard.GetImage(), 0, 0)
                _Print.Print(True, False)
            End If
        End If
    End Sub




    Public Sub Ajouter_Point_Arrêt()
        If Not Erreur_Chargement Then
            Dim a As System.Activities.Activity = TryCast(WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue(), System.Activities.Activity)
            If a IsNot Nothing Then
                Supprimer_Point_Arrêt()
                Dim srcLoc As System.Activities.Debugger.SourceLocation = designerSourceLocationMapping(a)
                If Not breakpointList.Contains(srcLoc) Then
                    WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().UpdateBreakpoint(srcLoc, System.Activities.Presentation.Debug.BreakpointTypes.Bounded Or System.Activities.Presentation.Debug.BreakpointTypes.Enabled)
                    breakpointList.Add(srcLoc)
                End If
            End If
        End If
    End Sub

    Public Sub Switch_Point_Arrêt()
        If Not Erreur_Chargement Then
            Dim a As System.Activities.Activity = TryCast(WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue(), System.Activities.Activity)
            If a IsNot Nothing Then
                Ajouter_Point_Arrêt()
                Dim srcLoc As System.Activities.Debugger.SourceLocation = designerSourceLocationMapping(a)
                If breakpointList.Contains(srcLoc) Then
                    Select Case WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().GetBreakpointLocations(srcLoc)
                        Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded Or System.Activities.Presentation.Debug.BreakpointTypes.Enabled
                            WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().UpdateBreakpoint(srcLoc, System.Activities.Presentation.Debug.BreakpointTypes.Bounded)
                        Case System.Activities.Presentation.Debug.BreakpointTypes.Bounded
                            WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().UpdateBreakpoint(srcLoc, System.Activities.Presentation.Debug.BreakpointTypes.Bounded Or System.Activities.Presentation.Debug.BreakpointTypes.Enabled)
                    End Select
                End If
            End If
        End If
    End Sub

    Public Sub Supprimer_Point_Arrêt()
        If Not Erreur_Chargement Then
            Dim a As System.Activities.Activity = TryCast(WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue(), System.Activities.Activity)
            If a IsNot Nothing Then
                Dim srcLoc As System.Activities.Debugger.SourceLocation = designerSourceLocationMapping(a)
                If breakpointList.Contains(srcLoc) Then
                    WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Debug.IDesignerDebugView)().DeleteBreakpoint(srcLoc)
                    breakpointList.Remove(srcLoc)
                End If
            End If
        End If
    End Sub



    Public Sub Modifier_Action()
        If Not Erreur_Chargement AndAlso _
            Me.KryptonButton1.Enabled AndAlso _
            WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount = 1 AndAlso _
            WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.Modify() Then

            If WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue Is Me.WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.Param1
                If DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Name = "TabONE_KryptonPage" AndAlso TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).File.Nom = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.Param1
                Else
                    DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).UniqueName = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.Param1
                    DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Name = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.Param1
                End If
            End If
            Me.DocumentModifier()
        End If
    End Sub

#End Region

    Friend Event SelectedActionChanger As System.EventHandler

    Friend Property SelectedAction As VelerSoftware.Plugins3.Action

    Friend Property WorkflowDesigne As New Global.SoftwareZator.WorkflowDesigner

    Friend Property DebuggerService As System.Activities.Presentation.Debug.IDesignerDebugView

    Friend WithEvents ToolboxControl As New System.Activities.Presentation.Toolbox.ToolboxControl

    Friend WithEvents designerSourceLocationMapping As New Dictionary(Of Object, System.Activities.Debugger.SourceLocation)()

    Friend WithEvents breakpointList As New List(Of System.Activities.Debugger.SourceLocation)()

    Friend Erreur_Chargement As Boolean

    Private Considerate_As_Modify As Boolean



    Private Sub DocEditeurFonctionsUserControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Considerate_As_Modify = True

        ' Initialisation de la ToolBox
        ToolboxControl.Categories.Clear()


        If Not Me.DesignMode Then
            Me.ElementHost1.Child = WorkflowDesigne.View
#If Not Debug Then
            Try
#End If
                WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Validation.ValidationService)().ValidateWorkflow()
                If My.Settings.Afficher_Zoom_Bar Then
                    WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.Zoom + System.Activities.Presentation.View.ShellBarItemVisibility.MiniMap
                Else
                    WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().WorkflowShellBarItemVisibility = System.Activities.Presentation.View.ShellBarItemVisibility.None
                End If
                WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().ShouldCollapseAll = True
                WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().AllowDrop = True

                Dim menuitemms As New System.IO.MemoryStream()
                Dim menuitemimg As New System.Windows.Controls.Image()
                Dim menuitem As New System.Windows.Controls.MenuItem()

                My.Resources.gestionnaire_plugins_16.Save(menuitemms, System.Drawing.Imaging.ImageFormat.Png)
                menuitemimg.Source = DirectCast(System.Windows.Media.Imaging.BitmapDecoder.Create(menuitemms, System.Windows.Media.Imaging.BitmapCreateOptions.None, System.Windows.Media.Imaging.BitmapCacheOption.Default).Frames(0), System.Windows.Media.Imaging.BitmapSource)
                menuitemimg.Height = 16

                menuitem.Name = "Modifier_Action"
                menuitem.Header = Me.KryptonButton1.Text
                menuitem.Icon = menuitemimg
                menuitem.ItemContainerStyle = DirectCast(WorkflowDesigne.ContextMenu.Items(0), System.Windows.Controls.MenuItem).ItemContainerStyle
                AddHandler menuitem.Click, AddressOf KryptonButton1_Click
                WorkflowDesigne.ContextMenu.Items.Add(menuitem)

                Dim Resx As New System.Text.StringBuilder
                With Resx
                    .AppendLine("<ResourceDictionary x:Uid=" & ChrW(34) & "ResourceDictionary_1" & ChrW(34) & " xmlns=" & ChrW(34) & "http://schemas.microsoft.com/winfx/2006/xaml/presentation" & ChrW(34) & " xmlns:x=" & ChrW(34) & "http://schemas.microsoft.com/winfx/2006/xaml" & ChrW(34) & " xmlns:sap=" & ChrW(34) & "clr-namespace:System.Activities.Presentation;assembly=System.Activities.Presentation" & ChrW(34) & " xmlns:sapv=" & ChrW(34) & "clr-namespace:System.Activities.Presentation.View;assembly=System.Activities.Presentation" & ChrW(34) & ">")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarControlBackgroundColorKey}" & ChrW(34) & " Color=" & ChrW(34) & "#ffffff" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarColorGradientBeginKey}" & ChrW(34) & " Color=" & ChrW(34) & "#ffffff" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarColorGradientEndKey}" & ChrW(34) & " Color=" & ChrW(34) & "#ffffff" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarHoverColorGradientBeginKey}" & ChrW(34) & " Color=" & ChrW(34) & "#f8e187" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarHoverColorGradientEndKey}" & ChrW(34) & " Color=" & ChrW(34) & "#f8e187" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarSelectedColorGradientBeginKey}" & ChrW(34) & " Color=" & ChrW(34) & "#f8e187" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarSelectedColorGradientEndKey}" & ChrW(34) & " Color=" & ChrW(34) & "#f8e187" & ChrW(34) & "/>")
                    .AppendLine("<SolidColorBrush x:Key=" & ChrW(34) & "{x:Static sap:WorkflowDesignerColors.DesignerViewShellBarCaptionColorKey}" & ChrW(34) & " Color=" & ChrW(34) & "#1e395b" & ChrW(34) & "/>")
                    .AppendLine("</ResourceDictionary>")
                End With
                Dim reader As New IO.StringReader(Resx.ToString)
                Dim xmlReader__1 As Xml.XmlReader = Xml.XmlReader.Create(reader)
                Dim fontAndColorDictionary As Windows.ResourceDictionary = DirectCast(System.Windows.Markup.XamlReader.Load(xmlReader__1), Windows.ResourceDictionary)
                Dim hashTable As New Hashtable()
                For Each key As Object In fontAndColorDictionary.Keys
                    hashTable.Add(key, fontAndColorDictionary(key))
                Next
                WorkflowDesigne.PropertyInspectorFontAndColorData = Xaml.XamlServices.Save(hashTable)

                'Dim expandButtonField As Reflection.FieldInfo = WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)().GetType().GetField("expandAllButton", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                'Dim toggleButton As Windows.Controls.Primitives.ToggleButton = DirectCast(expandButtonField.GetValue(WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.View.DesignerView)()), Windows.Controls.Primitives.ToggleButton)
                'toggleButton.Visibility = Windows.Visibility.Hidden

                AddHandler WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().ModelChanged, AddressOf WorkflowDesigne_ModelChanged


                ' Updating the mapping between Model item and Source Location as soon as you load the designer so that BP setting can re-use that information from the DesignerSourceLocationMapping.
                UpdateSourceLocationMappingInDebuggerService()

                Me.Timer1.Start()
#If Not Debug Then
            Catch ex As Exception
                Erreur_Chargement = True
                If Not Form1.Info_Bar1.Visible Then
                    Form1.Info_Bar1.Show(VelerSoftware.SZVB.Info_Bar.Style.Errors, RM.GetString("InfoBar_7_Description"), Nothing, False, "Erreur_Chargement_Editeur_Fonctions", Nothing)
                End If
            End Try
#End If
        End If

        Me.IsFinishLoad = True

        If My.Settings.Réduire_Panneau_Lateral_FunctionEditor Then Me.KryptonLinkLabel1_LinkClicked(Nothing, Nothing)

    End Sub

    Private Sub KryptonLinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonLinkLabel1.LinkClicked
        If Me.Panel3.Height = 67 Then
            Me.Panel3.Height = 20
            Me.KryptonLinkLabel1.Text = RM.GetString("Maximize_Panel")
        Else
            Me.Panel3.Height = 67
            Me.KryptonLinkLabel1.Text = RM.GetString("Minimize_Panel")
        End If
    End Sub






    Private Sub WorkflowDesigne_ModelChanged(ByVal sender As Object, ByVal e As System.Activities.Presentation.Services.ModelChangedEventArgs) ' Handles WorkflowDesigne.ModelChanged
        If Not Erreur_Chargement Then
            ' Ajout d'une action
            If e IsNot Nothing Then
                Dim itemsAdded As IEnumerable(Of System.Activities.Presentation.Model.ModelItem) = e.ItemsAdded
                If Not itemsAdded Is Nothing Then
                    For Each modelItem As System.Activities.Presentation.Model.ModelItem In itemsAdded
                        If Not CBool(modelItem.GetCurrentValue.Added) Then
                            modelItem.GetCurrentValue.Tools = New ClassActionTools
                            ' Génération de l'ID
                            For i = 0 To 50 - 1
                                modelItem.GetCurrentValue.Id = modelItem.GetCurrentValue.Id & Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                            Next
                            If modelItem.GetCurrentValue.Main() Then
                                modelItem.GetCurrentValue.Added = True
                                For Each value As String In DirectCast(modelItem.GetCurrentValue(), VelerSoftware.Plugins3.Action).References
                                    Dim ok As Boolean = False
                                    If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                                        For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                                            If ref.FullName = value OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value) OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value) Then
                                                ok = True
                                                Exit For
                                            End If
                                        Next
                                    ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                                        For Each ref As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).References
                                            If ref.FullName = value OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\", value) OrElse ref.FullName = My.Computer.FileSystem.CombinePath(Application.StartupPath & "\Sources\", value) Then
                                                ok = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                    If Not ok Then
                                        If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                                            ClassProjet.Ajouter_Reference_Projet(value, SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet))
                                        ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                                            ClassProjet.Ajouter_Reference_Projet(value, SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet))
                                        End If
                                    End If
                                Next
                                Me.DocumentModifier()
                            Else
                                modelItem.GetCurrentValue.Added = False
                                System.Activities.Presentation.View.Selection.Select(WorkflowDesigne.Context, modelItem)
                                If WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount = 1 Then
                                    Considerate_As_Modify = False
                                    Me.Couper()
                                End If
                            End If
                        Else
                            ' Génération de l'ID
                            For i = 0 To 50 - 1
                                modelItem.GetCurrentValue.Id = modelItem.GetCurrentValue.Id & Mid("abcdefghijklmnopqrstuvwxyz1234567890", Int(Rnd() * Len("abcdefghijklmnopqrstuvwxyz1234567890")) + 1, 1)
                            Next
                        End If
                    Next
                Else
                    If Considerate_As_Modify Then Me.DocumentModifier()
                    Considerate_As_Modify = True
                End If
                If e.ItemsAdded IsNot Nothing OrElse e.ItemsRemoved IsNot Nothing Then
                    ' Updating the mapping between Model item and Source Location as soon as you load the designer so that BP setting can re-use that information from the DesignerSourceLocationMapping.
                    UpdateSourceLocationMappingInDebuggerService()
                End If
            End If
        End If

    End Sub


    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Modifier_Action()

        'If WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.ItemType.BaseType = GetType(VelerSoftware.Plugins3.Action) Then
        '    MsgBox(DirectCast(WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).DisplayName)
        '    For Each aaa As VelerSoftware.Plugins3.Action In DirectCast(WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue, VelerSoftware.Plugins3.ActionWithChildren).Children_Actions
        '        MsgBox(aaa.DisplayName)
        '    Next
        'End If
        '
        '
        'For Each ite As System.Activities.Presentation.Model.ModelItem In WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectedObjects
        '    'MsgBox(ite.ItemType.FullName)
        '    For Each aa As System.Activities.Presentation.Model.ModelProperty In ite.Properties
        '        'MsgBox(aa.Name)
        '    Next
        'Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not Me.DesignMode AndAlso Me.IsFinishLoad AndAlso Not Erreur_Chargement Then

            If WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount = 1 Then
                If (SelectedAction Is Nothing) OrElse (Not SelectedAction.id = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue.id) Then
                    SelectedAction = WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().PrimarySelection.GetCurrentValue
                    If DirectCast(DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).KryptonParentContainer, VelerSoftware.Design.Navigator.KryptonNavigator).SelectedPage Is DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage) Then
                        RaiseEvent SelectedActionChanger(SelectedAction, New System.EventArgs)
                    End If
                    If DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Name = "TabONE_KryptonPage" AndAlso WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue Is SelectedAction Then
                        If IsWindow Then
                            Me.KryptonButton1.Enabled = False
                        Else
                            Me.KryptonButton1.Enabled = True
                        End If
                    Else
                        Me.KryptonButton1.Enabled = True
                    End If
                End If
            Else
                If Not SelectedAction Is Nothing Then
                    SelectedAction = Nothing
                    If DirectCast(DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).KryptonParentContainer, VelerSoftware.Design.Navigator.KryptonNavigator).SelectedPage Is DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage) Then
                        RaiseEvent SelectedActionChanger(SelectedAction, New System.EventArgs)
                    End If
                    Me.KryptonButton1.Enabled = False
                End If
            End If

            For Each ite As Object In WorkflowDesigne.ContextMenu.Items
                If TypeOf ite Is System.Windows.Controls.MenuItem AndAlso DirectCast(ite, System.Windows.Controls.MenuItem).Name = "Modifier_Action" Then
                    DirectCast(ite, System.Windows.Controls.MenuItem).IsEnabled = Me.KryptonButton1.Enabled
                    Exit For
                End If
            Next

            If WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.View.Selection)().SelectionCount >= 1 Then
                If WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue Is SelectedAction Then
                    For Each ite As Object In WorkflowDesigne.ContextMenu.Items
                        If TypeOf ite Is System.Windows.Controls.MenuItem AndAlso DirectCast(ite, System.Windows.Controls.MenuItem).Name = "copyMenuItem" Then
                            DirectCast(ite, System.Windows.Controls.MenuItem).IsEnabled = False
                            Exit For
                        End If
                    Next
                    If DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Name = "TabONE_KryptonPage" Then
                        If IsWindow Then
                            Me.KryptonButton1.Enabled = False
                        Else
                            Me.KryptonButton1.Enabled = True
                        End If
                        For Each ite As Object In WorkflowDesigne.ContextMenu.Items
                            If TypeOf ite Is System.Windows.Controls.MenuItem AndAlso DirectCast(ite, System.Windows.Controls.MenuItem).Name = "Modifier_Action" Then
                                DirectCast(ite, System.Windows.Controls.MenuItem).IsEnabled = Me.KryptonButton1.Enabled
                                Exit For
                            End If
                        Next
                    End If
                Else
                    For Each ite As Object In WorkflowDesigne.ContextMenu.Items
                        If TypeOf ite Is System.Windows.Controls.MenuItem AndAlso DirectCast(ite, System.Windows.Controls.MenuItem).Name = "copyMenuItem" Then
                            DirectCast(ite, System.Windows.Controls.MenuItem).IsEnabled = True
                            Exit For
                        End If
                    Next
                End If
            End If

        End If
    End Sub










    Friend Function UpdateSourceLocationMappingInDebuggerService() As Dictionary(Of Object, System.Activities.Debugger.SourceLocation)
        Dim rootInstance As Object = WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue
        'Me.designerSourceLocationMapping.Clear()
        'Me.designerSourceLocationMapping = New Dictionary(Of Object, System.Activities.Debugger.SourceLocation)()

        If rootInstance IsNot Nothing Then
            Dim documentRootElement As VelerSoftware.Plugins3.Action = GetRootWorkflowElement(rootInstance)
            'If documentRootElement.Children_Actions.Count > 0 Then
            '    System.Activities.Debugger.SourceLocationProvider.CollectMapping(GetRootRuntimeWorkflowElement(), documentRootElement, sourceLocationMapping, WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.WorkflowFileItem)().LoadedFile)
            '    System.Activities.Debugger.SourceLocationProvider.CollectMapping(documentRootElement, rootInstance, sourceLocationMapping, WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.WorkflowFileItem)().LoadedFile)
            'Else
            '    System.Activities.Debugger.SourceLocationProvider.CollectMapping(documentRootElement, rootInstance, sourceLocationMapping, WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.WorkflowFileItem)().LoadedFile)
            'End If

            'Collect the mapping between the Model Item tree and its underlying source location
            Try
                System.Activities.Debugger.SourceLocationProvider.CollectMapping(documentRootElement, rootInstance, designerSourceLocationMapping, WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.WorkflowFileItem)().LoadedFile)
            Catch
            End Try

            ' System.Activities.Debugger.SourceLocationProvider.CollectMapping(GetRootRuntimeWorkflowElement(), documentRootElement, sourceLocationMapping, WorkflowDesigne.Context.Items.GetValue(Of System.Activities.Presentation.WorkflowFileItem)().LoadedFile)
        End If

        ' Notify the DebuggerService of the new sourceLocationMapping.
        ' When rootInstance == null, it'll just reset the mapping.
        'DebuggerService debuggerService = debuggerService as DebuggerService;
        If DebuggerService IsNot Nothing Then
            Try
                DirectCast(DebuggerService, System.Activities.Presentation.Debug.DebuggerService).UpdateSourceLocations(designerSourceLocationMapping)
            Catch
            End Try
        End If

        Return Nothing
    End Function

    ' Get root WorkflowElement.  Currently only handle when the object is ActivitySchemaType or WorkflowElement.
    ' May return null if it does not know how to get the root activity.
    Private Function GetRootWorkflowElement(rootModelObject As Object) As VelerSoftware.Plugins3.Action
        System.Diagnostics.Debug.Assert(rootModelObject IsNot Nothing, "Impossible de passer avec rootModelObject = null")

        Dim rootWorkflowElement As System.Activities.Activity
        Dim debuggableWorkflowTree As System.Activities.Debugger.IDebuggableWorkflowTree = TryCast(rootModelObject, System.Activities.Debugger.IDebuggableWorkflowTree)
        If debuggableWorkflowTree IsNot Nothing Then
            rootWorkflowElement = debuggableWorkflowTree.GetWorkflowRoot
        Else
            ' Loose xaml case.
            rootWorkflowElement = TryCast(rootModelObject, VelerSoftware.Plugins3.Action)
        End If

        Return rootWorkflowElement
    End Function

    Private tmp_save_oki As Boolean

    Private Function GetRootRuntimeWorkflowElement() As VelerSoftware.Plugins3.Action
        'If Not tmp_save_oki Then WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\" & TempXAMLFileName) : tmp_save_oki = True
        WorkflowDesigne.Save(Application.StartupPath & "\Temp\Functions\" & TempXAMLFileName)
        Dim root As System.Activities.Activity = System.Activities.XamlIntegration.ActivityXamlServices.Load(Application.StartupPath & "\Temp\Functions\" & TempXAMLFileName)
        System.Activities.WorkflowInspectionServices.CacheMetadata(root)


        Dim enumerator1 As IEnumerator(Of System.Activities.Activity) = System.Activities.WorkflowInspectionServices.GetActivities(root).GetEnumerator()
        'Get the first child of the x:class
        enumerator1.MoveNext()
        root = enumerator1.Current
        Return root
    End Function

End Class





Friend Class WorkflowDesigner
    Inherits System.Activities.Presentation.WorkflowDesigner
    Implements IDisposable



#Region "IDisposable Support"
    Private disposedValue As Boolean ' Pour détecter les appels redondants

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: supprimez l'état managé (objets managés).
            End If
            'MyBase.Context.Dispose()
            MyBase.Finalize()

            ' TODO: libérez les ressources non managées (objets non managés) et substituez la méthode Finalize() ci-dessous.
            ' TODO: définissez les champs volumineux à null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: substituez Finalize() uniquement si Dispose(ByVal disposing As Boolean) ci-dessus comporte du code permettant de libérer des ressources non managées.
    'Protected Overrides Sub Finalize()
    '    ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
