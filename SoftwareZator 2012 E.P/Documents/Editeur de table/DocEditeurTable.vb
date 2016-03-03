''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocEditeurTable

    Enum DataBaseType
        Access
        MySql
        SQLServer
        Oracle
    End Enum

#Region "Propriétés"

    Public Property HostOuFichierDeBaseDeDonnees As String

    Public Property MotDePasse As String

    Public Property NomBaseDeDonnees As String

    Public Property NomTable As String

    Public Property TypeBaseDeDonnees As DataBaseType

    Public Property Locale As Boolean

    Public Property Utilisateur As String

    Public Property Port As String

#Region "Type du document"

    Private _TypeFichier As VelerSoftware.SZVB.Projet.Document.Types = VelerSoftware.SZVB.Projet.Document.Types.Editeur_Table

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
        Else
        End If
        If Modifier AndAlso Not DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text.EndsWith("*") Then
            DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomBaseDeDonnees & "." & NomTable & "*"
        End If
    End Sub ' Document modifié








    Public Function Charger(ByVal Dat As DataTable) As Boolean
        Dim RESULTAT As Boolean = True

        Me.KryptonDataGridView1.DataSource = Dat

        Return RESULTAT
    End Function









    Public Sub Enregistrer()
        ' Enregistrement   

        If TypeBaseDeDonnees = DataBaseType.Access Then
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Temp\") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Temp")
            End If
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Temp\datatable") Then
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Temp\datatable", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If

            Dim dat As System.Data.DataTable = Me.KryptonDataGridView1.DataSource
            Dim myFileStream As IO.Stream = IO.File.Create(My.Application.Info.DirectoryPath & "\Temp\datatable")
            Dim serializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            serializer.Serialize(myFileStream, dat)
            myFileStream.Close()

            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Access32.exe") Then
                Dim proc As New Process
                With proc.StartInfo
                    .FileName = Application.StartupPath & "\Access32.exe"
                    .CreateNoWindow = True
                    .ErrorDialog = True
                    .ErrorDialogParentHandle = Me.Handle
                    .RedirectStandardOutput = True
                    .UseShellExecute = False
                    .WindowStyle = ProcessWindowStyle.Hidden
                    If Not MotDePasse = Nothing Then
                        .Arguments = "file=" & ChrW(34) & Application.StartupPath & "\Temp\datatable" & ChrW(34) & " db=" & ChrW(34) & Me.HostOuFichierDeBaseDeDonnees & ChrW(34) & " pswd=" & ChrW(34) & Me.MotDePasse & ChrW(34) & " updatedatatable=" & Me.NomTable
                    Else
                        .Arguments = "file=" & ChrW(34) & Application.StartupPath & "\Temp\datatable" & ChrW(34) & " db=" & ChrW(34) & Me.HostOuFichierDeBaseDeDonnees & ChrW(34) & " updatedatatable=" & Me.NomTable
                    End If
                End With
                proc.Start()
                Dim result As String = proc.StandardOutput.ReadLine
                proc.WaitForExit()

                If result = "0" Then
                    MsgBox("Table not found.", MsgBoxStyle.Exclamation)
                ElseIf result = "1" Then
                    DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomBaseDeDonnees & "." & NomTable
                    Me.Modifier = False
                End If

            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                    .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content17"), Application.StartupPath & "\Access32.exe", My.Application.Info.Title)
                    .MainInstruction = RM.GetString("MainInstruction10")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If





        ElseIf TypeBaseDeDonnees = DataBaseType.SQLServer Then
            Dim cnx As New ClassBasesDeDonneesSQLServer
            cnx.Connect(Me.Locale, Me.HostOuFichierDeBaseDeDonnees, Me.Port, Me.Utilisateur, Me.MotDePasse, Nothing, "yes")
            cnx.ChangeDataBase(Me.NomBaseDeDonnees)
            Dim result As Integer = cnx.UpdateDataTable(Me.KryptonDataGridView1.DataSource, Me.NomTable)
            cnx.Disconnect()

            If result = 0 Then
                MsgBox("Table not found.", MsgBoxStyle.Exclamation)
            ElseIf result = 1 Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomBaseDeDonnees & "." & NomTable
                Me.Modifier = False
            End If





        ElseIf TypeBaseDeDonnees = DataBaseType.MySql Then
            Dim cnx As New ClassBasesDeDonneesMySQL
            cnx.Connect(Me.HostOuFichierDeBaseDeDonnees, Me.Port, Me.Utilisateur, Me.MotDePasse, Nothing, True)
            cnx.ChangeDataBase(Me.NomBaseDeDonnees)
            Dim result As Integer = cnx.UpdateDataTable(Me.KryptonDataGridView1.DataSource, Me.NomTable)
            cnx.Disconnect()

            If result = 0 Then
                MsgBox("Table not found.", MsgBoxStyle.Exclamation)
            ElseIf result = 1 Then
                DirectCast(Me.Parent, VelerSoftware.Design.Navigator.KryptonPage).Text = NomBaseDeDonnees & "." & NomTable
                Me.Modifier = False
            End If

        End If

    End Sub










    Public Sub Copier()
        If Me.FinishLoad Then
            If Me.KryptonDataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
                Clipboard.SetDataObject(Me.KryptonDataGridView1.GetClipboardContent())
            End If
        End If
    End Sub

    Public Sub SelectionnerTout()
        If Me.FinishLoad Then
            Me.KryptonDataGridView1.SelectAll()
        End If
    End Sub

    Public Sub Supprimer()
        If Me.FinishLoad Then
            For Each row As DataGridViewRow In Me.KryptonDataGridView1.SelectedRows
                If Not row.IsNewRow Then Me.KryptonDataGridView1.Rows.Remove(row)
            Next
            DocumentModifier()
        End If
    End Sub








    Public Sub Imprimer()
        If FinishLoad Then
            ClassBasesDeDonneesImprimer.Print_DataGridView(Me.KryptonDataGridView1, False, False, NomBaseDeDonnees, NomTable)
        End If
    End Sub

    Public Sub Impression_Rapide()
        If FinishLoad Then
            ClassBasesDeDonneesImprimer.Print_DataGridView(Me.KryptonDataGridView1, False, True, NomBaseDeDonnees, NomTable)
        End If
    End Sub

    Public Sub Apercu_Avant_Impression()
        If FinishLoad Then
            ClassBasesDeDonneesImprimer.Print_DataGridView(Me.KryptonDataGridView1, True, False, NomBaseDeDonnees, NomTable)
        End If
    End Sub

#End Region

    Private Sub Box_Proprietes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .FinishLoad = False
            .Annuler = False
            .Retablir = False

            AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
            OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocConcepteurFenetre))
            '.ToolTip1.SetToolTip(.KryptonTextBox1.TextBox, resources.GetString("KryptonTextBox1.ToolTip"))

        End With





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



        Me.FinishLoad = True
        Me.Annuler = True
        Me.Retablir = True

    End Sub

    Friend Function Page_Closing() As Boolean
        Dim resultat As Boolean
        If Me.Modifier Then
            Using frm As New Fermer_Document
                frm.Label2.Text = frm.Label2.Text.Replace("{0}", NomBaseDeDonnees & "." & NomTable)
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.Yes Then
                    ' Enregistrer
                    Me.Enregistrer()
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

            ' dispose
        End If

        Return resultat
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
                .Enregistrer_Sous_KryptonRibbonGroupButton.Enabled = False

                .VbNet_KryptonRibbonGroupButton.Enabled = False
                .CSharp_KryptonRibbonGroupButton.Enabled = False

                .Imprimer_KryptonRibbonGroupButton.Enabled = True
                .Impression_Rapide_KryptonRibbonGroupButton.Enabled = True
                .Apercu_Impression_KryptonRibbonGroupButton.Enabled = True

                .Coller_KryptonRibbonGroupButton.Enabled = False
                .Copier_KryptonRibbonGroupButton.Enabled = True
                .Couper_KryptonRibbonGroupButton.Enabled = False

                .Annuler_KryptonRibbonGroupButton.Enabled = False
                .Retablir_KryptonRibbonGroupButton.Enabled = False
                .Supprimer_KryptonRibbonGroupButton.Enabled = True
                .Selectionner_tout_KryptonRibbonGroupButton.Enabled = True

                .QAT_Annuler.Enabled = False
                .QAT_Coller.Enabled = False
                .QAT_Copier.Enabled = True
                .QAT_Couper.Enabled = False
                .QAT_Enregistrer_Sous.Enabled = False
                .QAT_Retablir.Enabled = False

                .KryptonRibbon1.SelectedContext = ""
            End With
        End If
    End Sub


    Private Sub KryptonDataGridView1_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles KryptonDataGridView1.DataError
        Dim type As String = DirectCast(sender, VelerSoftware.Design.Toolkit.KryptonDataGridView).Columns(e.ColumnIndex).ValueType.FullName
        If System.Threading.Thread.CurrentThread.CurrentUICulture Is FrenchCulture Then
            type = type.Replace("System.Int32", "Numérique")
            type = type.Replace("System.String", "Texte")
            type = type.Replace("System.Boolean", "Vrai/Faux (True / False)")
            type = type.Replace("System.Decimal", "Decimale")
        Else
            type = type.Replace("System.Int32", "Numeric")
            type = type.Replace("System.String", "Text")
            type = type.Replace("System.Boolean", "Boolean (True / False)")
            type = type.Replace("System.Decimal", "Decimal")
        End If
        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Nothing
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
            .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content44"), e.RowIndex, e.ColumnIndex, e.Exception.Message, type)
            .MainInstruction = RM.GetString("MainInstruction11")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With

        e.ThrowException = False
    End Sub

    Private Sub KryptonDataGridView1_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles KryptonDataGridView1.CellValueChanged
        'KryptonDataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = Nothing   

        DocumentModifier()
    End Sub

    Private Sub KryptonDataGridView1_UserAddedRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles KryptonDataGridView1.UserAddedRow
        DocumentModifier()
    End Sub

    Private Sub KryptonDataGridView1_UserDeletedRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles KryptonDataGridView1.UserDeletedRow
        DocumentModifier()
    End Sub
End Class
