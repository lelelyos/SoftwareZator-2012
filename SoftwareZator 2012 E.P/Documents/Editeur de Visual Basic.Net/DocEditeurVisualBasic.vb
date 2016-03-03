''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocEditeurVisualBasic

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

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Editeur_VBCode

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
        If Modifier Then
            If Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomFichier & "*"
            End If
        End If
    End Sub ' Document modifié








    Public Function Charger(ByVal _Text As String) As Boolean
        Dim RESULTAT As Boolean = True

        Me.CodeEditor.ShowLineNumbers = My.Settings.Numerotation_Lignes
        Me.CodeEditor.FontFamily = New System.Windows.Media.FontFamily("Consolas")
        Me.CodeEditor.FontSize = 12
        Me.CodeEditor.IsReadOnly = False
        Me.CodeEditor.isLineSingle = True

        Me.CodeEditor.Encoding = System.Text.Encoding.Default
        Me.CodeEditor.Document.Text = _Text


        Return RESULTAT
    End Function









    Public Sub Enregistrer(ByVal Enregistrer_SOUS As Boolean)
        ' Enregistrement
        If Not Enregistrer_SOUS Then
            If My.Computer.FileSystem.FileExists(Me.NomCompletFichier) Then
                If Not ClassFichier.IsReadOnly(Me.NomCompletFichier) Then
                    My.Computer.FileSystem.WriteAllText(Me.NomCompletFichier, Me.CodeEditor.Text, False)

                    Modifier = False
                    If Not SOLUTION.GetProject(Me.Nom_Projet) Is Nothing Then
                        SOLUTION.GetProject(Nom_Projet).ShouldCompileRelease = True
                    End If
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
            Form1.SaveFileDialog1.Filter = RM.GetString("SaveFileDialog1_Enregistrer_Document_Filtre_2")
            Form1.SaveFileDialog1.FilterIndex = 0
            Form1.SaveFileDialog1.FileName = Me.NomFichier
            If Form1.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.NomFichier = My.Computer.FileSystem.GetName(Form1.SaveFileDialog1.FileName)
                Me.NomCompletFichier = Form1.SaveFileDialog1.FileName
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).UniqueName = Me.NomCompletFichier

                My.Computer.FileSystem.WriteAllText(Me.NomCompletFichier, Me.CodeEditor.Text, False)

                Modifier = False
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = Me.NomFichier
                ' Mise à jour de l'explorateur de projet car, le fichier etant inexistant, il est possible qu'il ai été enregistré dans le dossier du projet
                DirectCast(Form1.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).ActualiserToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If

    End Sub











    Public Sub Coller()
        If Me.FinishLoad Then
            Me.CodeEditor.Paste()
            DocumentModifier()
        End If
    End Sub

    Public Sub Copier()
        If Me.FinishLoad Then
            Me.CodeEditor.Copy()
            DocumentModifier()
        End If
    End Sub

    Public Sub Couper()
        If Me.FinishLoad Then
            Me.CodeEditor.Cut()
            DocumentModifier()
        End If
    End Sub

    Public Sub Undo()
        If Me.FinishLoad Then
            Me.CodeEditor.Undo()
            DocumentModifier()
        End If
    End Sub

    Public Sub Redo()
        If Me.FinishLoad Then
            Me.CodeEditor.Redo()
            DocumentModifier()
        End If
    End Sub

    Public Sub SelectionnerTout()
        If Me.FinishLoad Then
            Me.CodeEditor.SelectAll()
            DocumentModifier()
        End If
    End Sub










    Public Sub Imprimer()
        Me.DoThePrint(Me.CreateFlowDocumentForEditor(Me.CodeEditor))
    End Sub

    Public Function CreateFlowDocumentForEditor(ByVal editor As VelerSoftware.SZC35.TextEditor) As Windows.Documents.FlowDocument
        Dim highlighter As VelerSoftware.SZC35.Highlighting.IHighlighter = TryCast(editor.TextArea.GetService(GetType(VelerSoftware.SZC35.Highlighting.IHighlighter)), VelerSoftware.SZC35.Highlighting.IHighlighter)
        Dim doc As New Windows.Documents.FlowDocument(ConvertTextDocumentToBlock(editor.Document, highlighter))
        doc.FontFamily = editor.FontFamily
        doc.FontSize = editor.FontSize
        Return doc
    End Function

    Public Function ConvertTextDocumentToBlock(ByVal document As VelerSoftware.SZC35.Document.TextDocument, ByVal highlighter As VelerSoftware.SZC35.Highlighting.IHighlighter) As Windows.Documents.Block
        If document Is Nothing Then
            Throw New ArgumentNullException("document")
        End If
        Dim p As New Windows.Documents.Paragraph()
        For Each line As VelerSoftware.SZC35.Document.DocumentLine In document.Lines
            Dim lineNumber As Integer = line.LineNumber
            Dim inlineBuilder As New VelerSoftware.SZC35.Highlighting.HighlightedInlineBuilder(document.GetText(line))
            If highlighter IsNot Nothing Then
                Dim highlightedLine As VelerSoftware.SZC35.Highlighting.HighlightedLine = highlighter.HighlightLine(lineNumber)
                Dim lineStartOffset As Integer = line.Offset
                For Each section As VelerSoftware.SZC35.Highlighting.HighlightedSection In highlightedLine.Sections
                    inlineBuilder.SetHighlighting(section.Offset - lineStartOffset, section.Length, section.Color)
                Next
            End If
            p.Inlines.AddRange(inlineBuilder.CreateRuns())
            p.Inlines.Add(New Windows.Documents.LineBreak())
        Next
        Return p
    End Function

    Public Sub DoThePrint(ByVal document As System.Windows.Documents.FlowDocument)
        ' Clone the source document's content into a new FlowDocument. 
        ' This is because the pagination for the printer needs to be 
        ' done differently than the pagination for the displayed page. 
        ' We print the copy, rather that the original FlowDocument. 
        Dim s As New System.IO.MemoryStream()
        Dim source As New Windows.Documents.TextRange(document.ContentStart, document.ContentEnd)
        source.Save(s, System.Windows.DataFormats.Xaml)
        Dim copy As New Windows.Documents.FlowDocument()
        Dim dest As New Windows.Documents.TextRange(copy.ContentStart, copy.ContentEnd)
        dest.Load(s, System.Windows.DataFormats.Xaml)
        ' Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog, 
        ' and allowing the user to select a printer. 
        ' get information about the dimensions of the seleted printer+media. 
        Dim ia As System.Printing.PrintDocumentImageableArea = Nothing
        Dim docWriter As System.Windows.Xps.XpsDocumentWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(ia)
        If docWriter IsNot Nothing AndAlso ia IsNot Nothing Then
            Dim paginator As Windows.Documents.DocumentPaginator = DirectCast(copy, Windows.Documents.IDocumentPaginatorSource).DocumentPaginator
            ' Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device. 
            paginator.PageSize = New System.Windows.Size(ia.MediaSizeWidth, ia.MediaSizeHeight)
            Dim t As New Windows.Thickness(72)
            ' copy.PagePadding; 
            copy.PagePadding = New Windows.Thickness(Math.Max(ia.OriginWidth, t.Left), Math.Max(ia.OriginHeight, t.Top), Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), t.Right), Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), t.Bottom))
            copy.ColumnWidth = Double.PositiveInfinity
            'copy.PageWidth = 528; // allow the page to be the natural with of the output device 
            ' Send content to the printer. 
            docWriter.Write(paginator)
        End If
    End Sub




#End Region

    Public WithEvents CodeEditor As New VelerSoftware.SZC35.TextEditor
    Private foldingManager As VelerSoftware.SZC35.Folding.FoldingManager
    Private foldingStrategy As VelerSoftware.SZC35.Folding.AbstractFoldingStrategy



    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Modifier = False
            .Annuler = False
            .Retablir = False

            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            With .CodeEditor
                .ShowLineNumbers = My.Settings.Numerotation_Lignes
                .FontFamily = New System.Windows.Media.FontFamily("Consolas")
                .FontSize = 12
                .IsReadOnly = False
                .isLineSingle = True
                .SpellCheck = False
            End With
            If My.Settings.Colorisation_Syntaxe Then .CodeEditor.SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("VBNET")

            .ElementHost1.Child = Me.CodeEditor

            .FinishLoad = True
            .Modifier = False
            .Annuler = True
            .Retablir = True

        End With
    End Sub

    Friend Function Page_Closing() As Boolean
        If Me.Modifier Then
            Using frm As New Fermer_Document
                frm.Label2.Text = frm.Label2.Text.Replace("{0}", Me.NomFichier)
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.Yes Then
                    ' Enregistrer
                    Me.Enregistrer(False)
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
        If Me.FinishLoad Then
            With Form1
                With DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)
                    .Vide_ToolBox.Visible = True
                    .Concepteur_Fenetre_ToolBox.Visible = False
                    .Fonctions_ToolBox.Visible = False
                    .Classes_ToolBox.Visible = False
                End With


                ' Configuration du ruban
                .Enregistrer_KryptonRibbonGroupButton.Enabled = True
                .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = True

                .VbNet_KryptonRibbonGroupButton.Enabled = False
                .CSharp_KryptonRibbonGroupButton.Enabled = False

                .Imprimer_KryptonRibbonGroupButton.Enabled = True
                .Impression_Rapide_KryptonRibbonGroupButton.Enabled = False
                .Apercu_Impression_KryptonRibbonGroupButton.Enabled = False

                .Coller_KryptonRibbonGroupButton.Enabled = True
                .Copier_KryptonRibbonGroupButton.Enabled = True
                .Couper_KryptonRibbonGroupButton.Enabled = True

                .Annuler_KryptonRibbonGroupButton.Enabled = True
                .Retablir_KryptonRibbonGroupButton.Enabled = True
                .Supprimer_KryptonRibbonGroupButton.Enabled = False
                .Selectionner_tout_KryptonRibbonGroupButton.Enabled = True

                .QAT_Annuler.Enabled = True
                .QAT_Coller.Enabled = True
                .QAT_Copier.Enabled = True
                .QAT_Couper.Enabled = True
                .QAT_Enregistrer_Sous.Enabled = True
                .QAT_Retablir.Enabled = True

                .KryptonRibbon1.SelectedContext = Nothing
            End With
        End If
    End Sub

    Private Sub CodeEditor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeEditor.TextChanged
        Me.DocumentModifier()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Me.CodeEditor.Cut()
        Me.DocumentModifier()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Me.CodeEditor.Copy()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Me.CodeEditor.Paste()
        Me.DocumentModifier()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        Me.CodeEditor.SelectAll()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        Me.CodeEditor.Undo()
        Me.DocumentModifier()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Me.CodeEditor.Redo()
        Me.DocumentModifier()
    End Sub
End Class
