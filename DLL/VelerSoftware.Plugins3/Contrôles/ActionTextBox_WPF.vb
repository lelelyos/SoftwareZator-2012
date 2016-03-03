''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

<System.ComponentModel.Designer(GetType(System.Windows.Forms.Design.ControlDesigner)), Drawing.ToolboxBitmap(GetType(System.Windows.Forms.TextBox))> _
Public Class ActionTextBox
    Inherits UserControl

    Private WithEvents CodeEditor As New VelerSoftware.SZC35.TextEditor

    Public Property SpellCheck As Boolean
        Get
            Return Me.CodeEditor.SpellCheck
        End Get
        Set(value As Boolean)
            Me.CodeEditor.SpellCheck = value
        End Set
    End Property

    Public Property IsReadOnly As Boolean
        Get
            Return Me.CodeEditor.IsReadOnly
        End Get
        Set(value As Boolean)
            Me.CodeEditor.IsReadOnly = value
        End Set
    End Property

    Public Property Multiline As Boolean
        Get
            Return Me.CodeEditor.isLineSingle
        End Get
        Set(value As Boolean)
            Me.CodeEditor.isLineSingle = value
            If Not value Then
                Me.Height = 22
            End If
        End Set
    End Property

    Public Property WordWrap As Boolean
        Get
            Return Me.CodeEditor.WordWrap
        End Get
        Set(value As Boolean)
            Me.CodeEditor.WordWrap = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return Me.CodeEditor.Document.Text
        End Get
        Set(value As String)
            Me.CodeEditor.Document.Text = value
        End Set
    End Property

    Private marketService As VelerSoftware.SZC35.Services.ITextMarkerService
    Private market As VelerSoftware.SZC35.Services.ITextMarker

    Public Sub New()
        InitializeComponent()

        With Me

            .Text = ""

            With CodeEditor
                .ShowLineNumbers = False
                .FontFamily = New System.Windows.Media.FontFamily("Consolas")
                .FontSize = 12
                .IsReadOnly = Me.IsReadOnly
                .SpellCheck = Me.SpellCheck
            End With
            .CodeEditorHost.Child = Me.CodeEditor

            If Not RM Is Nothing Then
                .Copier_ToolStripMenuItem.Text = RM.GetString("Copy")
                .Couper_ToolStripMenuItem.Text = RM.GetString("Cut")
                .Coller_ToolStripMenuItem.Text = RM.GetString("Paste")
                .Selectionner_Tout_ToolStripMenuItem.Text = RM.GetString("SelectAll")
                .Annuler_ToolStripMenuItem.Text = RM.GetString("Annuler")
                .Retablir_ToolStripMenuItem.Text = RM.GetString("Rétablir")
                .Projet_ToolStripMenuItem.Text = RM.GetString("Projet")
                .Parametres_Fonction_ToolStripMenuItem.Text = RM.GetString("Parametres_Fonction")
                .Parametres_Projet_ToolStripMenuItem.Text = RM.GetString("Parametres_Projet")
                .Resources_ToolStripMenuItem.Text = RM.GetString("Resources")
                .Application_ToolStripMenuItem.Text = RM.GetString("Application")
                .Environement_ToolStripMenuItem.Text = RM.GetString("Environement")
                .Code_ToolStripMenuItem.Text = RM.GetString("Code")
                .PropriétésDuDocumentToolStripMenuItem.Text = RM.GetString("Properties")
                .PropriétésDunContrôleToolStripMenuItem.Text = RM.GetString("Contols")

                .Application_Path_ToolStripMenuItem.ToolTipText = RM.GetString("Application_Path")
                .MY_DOCUMENTS_ToolStripMenuItem.ToolTipText = RM.GetString("My_Documents")
                .MY_MUSICS_ToolStripMenuItem.ToolTipText = RM.GetString("My_Musics")
                .MY_PICTURES_ToolStripMenuItem.ToolTipText = RM.GetString("My_Pictures")
                .MY_VIDEOS_ToolStripMenuItem.ToolTipText = RM.GetString("My_Movies")

                .ToolTip1.SetToolTip(Me.ParseCodeButton, RM.GetString("Button1"))
            End If

        End With
    End Sub

    Private vHost As VelerSoftware.Plugins3.Tools
    Property Tools() As VelerSoftware.Plugins3.Tools
        Get
            Return vHost
        End Get
        Set(ByVal value As VelerSoftware.Plugins3.Tools)
            With Me
                If Not Me.DesignMode Then
                    vHost = value
                    Try
                        If Not vHost Is Nothing Then
                            .ToolTip1.SetToolTip(Me, RM.GetString("ToolTip1"))
                            .ParseCodeButton.Visible = True
                            .SplitContainer1.Panel2Collapsed = False
                            .CodeEditor.SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("Action")

                        Else
                            .ParseCodeButton.Visible = False
                            .SplitContainer1.Panel2Collapsed = True
                            .CodeEditor.SyntaxHighlighting = Nothing
                        End If
                    Catch
                        .ToolTip1.RemoveAll()
                        .ParseCodeButton.Visible = False
                        .SplitContainer1.Panel2Collapsed = True
                        .CodeEditor.SyntaxHighlighting = Nothing
                    End Try
                End If
            End With
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Shared Function Determiner_Si_On_Est_Dans_Une_Variable(ByVal Texte As String, ByVal Position As Integer) As Boolean
        Dim RESULTAT As Boolean
        Dim ouvert As Boolean = False
        Dim fermer As Boolean = True

        If Position >= 1 Then
            For i As Integer = 1 To Position - 1
                If Texte.Chars(i) = "(" AndAlso Texte.Chars(i - 1) = "%" Then
                    ouvert = True
                    RESULTAT = True
                    If Not fermer Then
                        'il y a un problème, alors on retourne "false"
                        RESULTAT = False
                        Exit For
                    End If
                Else
                    If Texte.Chars(i) = "%" AndAlso Texte.Chars(i - 1) = ")" Then
                        If ouvert Then
                            fermer = True
                            ouvert = False
                            RESULTAT = False
                        Else
                            'il y a un problème, alors on retourne "false"
                            RESULTAT = False
                            Exit For
                        End If
                    End If
                End If
            Next
        End If

        Return RESULTAT
    End Function

    Private AlreadyMenuOpened As Boolean = False

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        With Me
            If .CodeEditor.IsReadOnly Then
                .Couper_ToolStripMenuItem.Enabled = False
                .Coller_ToolStripMenuItem.Enabled = False
                .Annuler_ToolStripMenuItem.Enabled = False
                .Retablir_ToolStripMenuItem.Enabled = False
            Else
                .Couper_ToolStripMenuItem.Enabled = True
                .Coller_ToolStripMenuItem.Enabled = True
                .Annuler_ToolStripMenuItem.Enabled = True
                .Retablir_ToolStripMenuItem.Enabled = True

                If .ContextMenuStrip1.Items(0) IsNot Copier_ToolStripMenuItem Then
                    Dim li As New List(Of ToolStripItem)
                    For Each item As ToolStripItem In .ContextMenuStrip1.Items
                        If TypeOf item Is ToolStripSeparator Then
                            li.Add(item)
                            Exit For
                        Else
                            li.Add(item)
                        End If
                    Next
                    For Each item As ToolStripItem In li
                        .ContextMenuStrip1.Items.Remove(item)
                    Next
                End If
                If Me.SpellCheck AndAlso VelerSoftware.SZC35.Variables.SpellCheck Then
                    Dim err As System.Windows.Controls.SpellingError = .CodeEditor.GetSpellingError(.CodeEditor.TextArea.Caret.Offset - 1)
                    If err IsNot Nothing Then
                        Dim item As ToolStripMenuItem = Nothing
                        If err.Suggestions.Count > 0 Then
                            For Each strr As String In err.Suggestions
                                item = New ToolStripMenuItem(strr)
                                item.Font = New Font(item.Font, FontStyle.Bold)
                                AddHandler item.Click, AddressOf Correct_Spell
                                .ContextMenuStrip1.Items.Insert(0, item)
                            Next
                            .ContextMenuStrip1.Items.Insert(err.Suggestions.Count, New ToolStripSeparator())
                        Else
                            item = New ToolStripMenuItem(RM.GetString("No_Correction"))
                            item.Enabled = False
                            .ContextMenuStrip1.Items.Insert(0, item)
                            .ContextMenuStrip1.Items.Insert(1, New ToolStripSeparator())
                        End If
                    End If
                End If

            End If

            If vHost Is Nothing Then
                .Projet_ToolStripMenuItem.Visible = False
                .Parametres_Fonction_ToolStripMenuItem.Visible = False
                .Parametres_Projet_ToolStripMenuItem.Visible = False
                .Resources_ToolStripMenuItem.Visible = False
                .Application_ToolStripMenuItem.Visible = False
                .Environement_ToolStripMenuItem.Visible = False
                .PropriétésDuDocumentToolStripMenuItem.Visible = False
                .PropriétésDunContrôleToolStripMenuItem.Visible = False
                .Code_ToolStripMenuItem.Visible = False

                .Projet_ToolStripMenuItem.DropDownItems.Clear()
                .Parametres_Fonction_ToolStripMenuItem.DropDownItems.Clear()
                .Parametres_Projet_ToolStripMenuItem.DropDownItems.Clear()
                .Resources_ToolStripMenuItem.DropDownItems.Clear()
                .Environement_ToolStripMenuItem.DropDownItems.Clear()
                .PropriétésDuDocumentToolStripMenuItem.DropDownItems.Clear()

                AlreadyMenuOpened = False
            Else
                .Projet_ToolStripMenuItem.Visible = True
                .Parametres_Fonction_ToolStripMenuItem.Visible = True
                .Parametres_Projet_ToolStripMenuItem.Visible = True
                .Resources_ToolStripMenuItem.Visible = True
                .Application_ToolStripMenuItem.Visible = True
                .Environement_ToolStripMenuItem.Visible = True
                .PropriétésDuDocumentToolStripMenuItem.Visible = True
                .PropriétésDunContrôleToolStripMenuItem.Visible = True
                .Code_ToolStripMenuItem.Visible = True

                .Projet_ToolStripMenuItem.Enabled = True
                .Parametres_Fonction_ToolStripMenuItem.Enabled = True
                .Parametres_Projet_ToolStripMenuItem.Enabled = True
                .Resources_ToolStripMenuItem.Enabled = True
                .Application_ToolStripMenuItem.Enabled = True
                .Environement_ToolStripMenuItem.Enabled = True
                .PropriétésDuDocumentToolStripMenuItem.Enabled = True
                .PropriétésDunContrôleToolStripMenuItem.Enabled = True
                .Code_ToolStripMenuItem.Enabled = True

                If Not Determiner_Si_On_Est_Dans_Une_Variable(.CodeEditor.Text, .CodeEditor.SelectionStart) Then
                    If Not AlreadyMenuOpened Then
                        .Projet_ToolStripMenuItem.DropDownItems.Clear()
                        .Parametres_Fonction_ToolStripMenuItem.DropDownItems.Clear()
                        .Parametres_Projet_ToolStripMenuItem.DropDownItems.Clear()
                        .Resources_ToolStripMenuItem.DropDownItems.Clear()
                        .Environement_ToolStripMenuItem.DropDownItems.Clear()
                        .PropriétésDuDocumentToolStripMenuItem.DropDownItems.Clear()

                        If vHost.GetCurrentProjectType = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationWindows OrElse vHost.GetCurrentProjectType = VelerSoftware.SZVB.Projet.Projet.Types.ApplicationConsole Then
                            .Application_Path_ToolStripMenuItem.Enabled = True
                        Else
                            .Application_Path_ToolStripMenuItem.Enabled = False
                        End If

                        Dim item, item2 As System.Windows.Forms.ToolStripMenuItem
                        Dim vars As Generic.List(Of VelerSoftware.SZVB.Projet.Variable) = vHost.GetCurrentProjectVariableList
                        Dim param_fonction As Generic.List(Of String) = vHost.GetCurrentFunctionSettings
                        Dim param_projet As Generic.List(Of String) = vHost.GetCurrentProjectSettings
                        Dim resx_projet As Generic.List(Of VelerSoftware.SZVB.Projet.Ressource) = vHost.GetCurrentProjectResoucres
                        Dim ClassActions As Generic.List(Of VelerSoftware.Plugins3.Action) = vHost.GetActionsOfFuntion(vHost.GetCurrentDocumentName)

                        For Each variable As DictionaryEntry In Environment.GetEnvironmentVariables()
                            item = New System.Windows.Forms.ToolStripMenuItem(CStr(variable.Key))
                            item.ToolTipText = CStr(variable.Value)
                            AddHandler item.Click, AddressOf ENVIRONMENT_Click
                            .Environement_ToolStripMenuItem.DropDownItems.Add(item)
                        Next

                        item = New System.Windows.Forms.ToolStripMenuItem(RM.GetString("VariableManager"))
                        item.Name = "VariableManagerToolStripMenuItem"
                        item.Image = My.Resources.gest_var
                        AddHandler item.Click, AddressOf VariableManagerToolStripMenuItem_Click
                        .Projet_ToolStripMenuItem.DropDownItems.Add(item)

                        .Projet_ToolStripMenuItem.DropDownItems.Add(New System.Windows.Forms.ToolStripSeparator())

                        For Each variable As VelerSoftware.SZVB.Projet.Variable In vars
                            item = New System.Windows.Forms.ToolStripMenuItem(variable.Name)
                            item.ToolTipText = variable.Description
                            item.Tag = variable.Name
                            If variable.Array Then
                                item2 = New System.Windows.Forms.ToolStripMenuItem(RM.GetString("AucunIndex"))
                                item2.Name = "None"
                                item2.Tag = item.Tag
                                AddHandler item2.Click, AddressOf Variable_Tableau_Click
                                item.DropDownItems.Add(item2)
                                item.DropDownItems.Add(New ToolStripSeparator)
                                Dim numericitem As New ToolStripNumericUpDown
                                numericitem.value = 0
                                numericitem.Tag = item.Tag
                                AddHandler numericitem.Validated, AddressOf Variable_Tableau_Click
                                item.DropDownItems.Add(numericitem)
                                item.DropDownItems.Add(New ToolStripSeparator)
                                For Each variable2 As VelerSoftware.SZVB.Projet.Variable In vars
                                    If Not variable2.Array Then
                                        item2 = New System.Windows.Forms.ToolStripMenuItem(variable2.Name)
                                        item2.ToolTipText = variable.Description
                                        item2.Tag = item.Tag
                                        AddHandler item2.Click, AddressOf Variable_Tableau_Click
                                        item.DropDownItems.Add(item2)
                                    End If
                                Next
                            Else
                                AddHandler item.Click, AddressOf Variable_Click
                            End If
                            .Projet_ToolStripMenuItem.DropDownItems.Add(item)
                        Next

                        For Each variable As String In param_fonction
                            item = New System.Windows.Forms.ToolStripMenuItem(variable)
                            item.ToolTipText = variable
                            item.Tag = variable
                            AddHandler item.Click, AddressOf Parametre_Fonction_Click
                            .Parametres_Fonction_ToolStripMenuItem.DropDownItems.Add(item)
                        Next

                        For Each variable As String In param_projet
                            item = New System.Windows.Forms.ToolStripMenuItem(variable)
                            item.ToolTipText = variable
                            item.Tag = variable
                            AddHandler item.Click, AddressOf Parametre_Projet_Click
                            .Parametres_Projet_ToolStripMenuItem.DropDownItems.Add(item)
                        Next

                        For Each variable As VelerSoftware.SZVB.Projet.Ressource In resx_projet
                            item = New System.Windows.Forms.ToolStripMenuItem(variable.Name)
                            item.ToolTipText = variable.Name
                            item.Tag = variable
                            AddHandler item.Click, AddressOf Resources_Click
                            .Resources_ToolStripMenuItem.DropDownItems.Add(item)
                        Next

                        For Each Action As VelerSoftware.Plugins3.Action In ClassActions
                            If Action.GetType.FullName = "VelerSoftware.GeneralPlugin.Declarer_Propriete" Then
                                item = New System.Windows.Forms.ToolStripMenuItem(Action.Param1)
                                item.ToolTipText = Action.Param1
                                item.Tag = Action
                                AddHandler item.Click, AddressOf Propriété_Click
                                .PropriétésDuDocumentToolStripMenuItem.DropDownItems.Add(item)
                            End If
                        Next

                    End If

                    AlreadyMenuOpened = True

                Else
                    .Projet_ToolStripMenuItem.Enabled = False
                    .Parametres_Fonction_ToolStripMenuItem.Enabled = False
                    .Parametres_Projet_ToolStripMenuItem.Enabled = False
                    .Resources_ToolStripMenuItem.Enabled = False
                    .Application_ToolStripMenuItem.Enabled = False
                    .Environement_ToolStripMenuItem.Enabled = False
                    .PropriétésDuDocumentToolStripMenuItem.Enabled = False
                    .PropriétésDunContrôleToolStripMenuItem.Enabled = False
                    .Code_ToolStripMenuItem.Enabled = False
                End If
            End If
        End With
    End Sub

    Private Sub Correct_Spell(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim err As System.Windows.Controls.SpellingError = Me.CodeEditor.GetSpellingError(Me.CodeEditor.TextArea.Caret.Offset - 1)
        If err IsNot Nothing Then
            Dim start As Integer = Me.CodeEditor.GetSpellingErrorStart(Me.CodeEditor.TextArea.Caret.Offset - 1)
            Dim length As Integer = Me.CodeEditor.GetSpellingErrorLength(Me.CodeEditor.TextArea.Caret.Offset - 1)
            Me.CodeEditor.Text = Me.CodeEditor.Text.Remove(start, length)
            Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(start, DirectCast(sender, ToolStripMenuItem).Text)
        End If
    End Sub

    Private Sub APPLICATION_PATH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Application_Path_ToolStripMenuItem.Click, MY_DOCUMENTS_ToolStripMenuItem.Click, MY_MUSICS_ToolStripMenuItem.Click, MY_PICTURES_ToolStripMenuItem.Click, MY_VIDEOS_ToolStripMenuItem.Click
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(APPLICATION=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Code_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Code_ToolStripMenuItem.Click
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "[CODE][/CODE]")
    End Sub

    Private Sub ENVIRONMENT_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(ENVIRONMENT=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Variable_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(VARIABLE=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Variable_Tableau_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf sender Is ToolStripNumericUpDown Then
            Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(VARIABLE=" & CType(sender, ToolStripNumericUpDown).Tag & "[" & CType(sender, ToolStripNumericUpDown).value & "]" & ")%")
            Me.ContextMenuStrip1.Close()
        Else
            If CType(sender, ToolStripMenuItem).Name = "None" Then
                Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(VARIABLE=" & CType(sender, ToolStripMenuItem).Tag & ")%")
            Else
                Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(VARIABLE=" & CType(sender, ToolStripMenuItem).Tag & "[" & CType(sender, ToolStripMenuItem).Text & "]" & ")%")
            End If
        End If
    End Sub

    Private Sub Parametre_Fonction_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(FUNCTION=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Resources_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(RESOURCE=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Propriété_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(PROPERTY=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub Parametre_Projet_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(SETTING=" & CType(sender, ToolStripMenuItem).Text & ")%")
    End Sub

    Private Sub CodeEditor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodeEditor.TextChanged
        Me.OnTextChanged(e)
    End Sub

    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copier_ToolStripMenuItem.Click
        Me.CodeEditor.Copy()
    End Sub

    Private Sub CouperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Couper_ToolStripMenuItem.Click
        Me.CodeEditor.Cut()
    End Sub

    Private Sub CollerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coller_ToolStripMenuItem.Click
        Me.CodeEditor.Paste()
    End Sub

    Private Sub SélectionnerToutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selectionner_Tout_ToolStripMenuItem.Click
        Me.CodeEditor.SelectAll()
    End Sub

    Private Sub AnnulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annuler_ToolStripMenuItem.Click
        Me.CodeEditor.Undo()
    End Sub

    Private Sub RétablirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Retablir_ToolStripMenuItem.Click
        Me.CodeEditor.Redo()
    End Sub

    Private Sub VariableManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If vHost.ShowVariableManager() = DialogResult.OK Then
            AlreadyMenuOpened = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParseCodeButton.Click
        Me.ContextMenuStrip1.Show(Me.ParseCodeButton.PointToScreen(New Point(Me.ParseCodeButton.Width / 2, Me.ParseCodeButton.Height / 2)))
    End Sub

    Private Sub ActionTextBox_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.EnabledChanged
        Me.CodeEditor.IsEnabled = Me.Enabled
        Me.ParseCodeButton.Enabled = Me.Enabled
        Me.ContextMenuStrip1.Enabled = Me.Enabled
    End Sub

    Private Sub PropriétésDunContrôleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PropriétésDunContrôleToolStripMenuItem.Click
        Me.ContextMenuStrip1.Close()
        Dim result As String = Me.Tools.SelectControlProperty()
        If Not result = Nothing Then
            Me.CodeEditor.Text = Me.CodeEditor.Text.Insert(Me.CodeEditor.SelectionStart, "%(CONTROL=" & result & ")%")
        End If
    End Sub
End Class
