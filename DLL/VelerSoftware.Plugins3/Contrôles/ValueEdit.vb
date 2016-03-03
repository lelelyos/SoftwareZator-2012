''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ValueEdit

    Public Enum ValueType
        VBNet
        Text
        Number
        TrueFalse
        Color
        Other
        Variables
        Resources
    End Enum

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        With Me
            .CodeEditor.Document.Text = " "
            .Variables_ActionTextBox.Text = 0
            .Text_ActionTextBox.Text = ""
            .Number_ActionTextBox.Text = ""
            .Variables_ActionTextBox.Text = ""
        End With
    End Sub


    Private Ex_Editor As ValueType = ValueType.Text

    Private _Editor As ValueType = ValueType.Text
    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Type de l'éditeur de valeur affiché")> _
    Public Property Editor() As ValueType
        Get
            Return _Editor
        End Get
        Set(ByVal value As ValueType)
            With Me
                _Editor = value
                UpdateGeneratedCode()
                RaiseEvent OnEditorChanged(New Object, New EventArgs)
                If value = ValueType.VBNet Then
                    .VB_Panel.Visible = True
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = True
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Text Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = True
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = True
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Number Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = True
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = True
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.TrueFalse Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = True
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = True
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Color Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = True
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = True
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Other Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = True
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = True
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Variables Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = True
                    .Resources_Panel.Visible = False
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = True
                    .Ressource_CheckBox.Checked = False
                ElseIf value = ValueType.Resources Then
                    .VB_Panel.Visible = False
                    .Text_Panel.Visible = False
                    .Num_Panel.Visible = False
                    .TrueFalse_Panel.Visible = False
                    .Color_Panel.Visible = False
                    .Other_Panel.Visible = False
                    .Variables_Panel.Visible = False
                    .Resources_Panel.Visible = True
                    .VB_CheckBox.Checked = False
                    .Text_CheckBox.Checked = False
                    .Number_CheckBox.Checked = False
                    .TrueFalse_CheckBox.Checked = False
                    .Color_CheckBox.Checked = False
                    .Other_CheckBox.Checked = False
                    .Variable_CheckBox.Checked = False
                    .Ressource_CheckBox.Checked = True
                End If
            End With
        End Set
    End Property

    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnEditorChangedEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Category("Evènement de ValueEdit"), ComponentModel.Description("Se déclenche lorsque la propriété 'Editor' change.")> _
    Public Event OnEditorChanged As OnEditorChangedEventHandler



    Private vHost As VelerSoftware.Plugins3.Tools
    Property Tools() As VelerSoftware.Plugins3.Tools
        Get
            Return vHost
        End Get
        Set(ByVal value As VelerSoftware.Plugins3.Tools)
            With Me
                vHost = value
                .Text_ActionTextBox.Tools = vHost
                .Number_ActionTextBox.Tools = vHost
                .Variables_ActionTextBox.Tools = vHost

                .Variables_ComboBox.Items.Clear()
                If vHost IsNot Nothing Then
                    For Each var As VelerSoftware.SZVB.Projet.Variable In vHost.GetCurrentProjectVariableList
                        .Variables_ComboBox.Items.Add(var.Name)
                    Next
                End If

                .Resources_ComboBox.Items.Clear()
                If vHost IsNot Nothing Then
                    For Each var As VelerSoftware.SZVB.Projet.Ressource In vHost.GetCurrentProjectResoucres
                        .Resources_ComboBox.Items.Add(var.Name)
                    Next
                End If
            End With
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir du code VB.Net' est visible ou pas.")> _
    Public Property VBNetButtonVisible() As Boolean
        Get
            Return Me.VB_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.VB_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir du texte' est visible ou pas.")> _
    Public Property TextButtonVisible() As Boolean
        Get
            Return Me.Text_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Text_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir une valeur numérique' est visible ou pas.")> _
    Public Property NumberButtonVisible() As Boolean
        Get
            Return Me.Number_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Number_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir une valeur vrai/faux (true/false)' est visible ou pas.")> _
    Public Property TrueFalseButtonVisible() As Boolean
        Get
            Return Me.TrueFalse_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.TrueFalse_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir une couleur' est visible ou pas.")> _
    Public Property ColorButtonVisible() As Boolean
        Get
            Return Me.Color_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Color_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Saisir une valeur d'un autre type' est visible ou pas.")> _
    Public Property OtherButtonVisible() As Boolean
        Get
            Return Me.Other_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Other_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Utiliser une valeur d'une variable' est visible ou pas.")> _
    Public Property VariablesButtonVisible() As Boolean
        Get
            Return Me.Variable_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Variable_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property

    <ComponentModel.Category("Propriétés de ValueEdit"), ComponentModel.Description("Détermine si le bouton 'Utiliser une ressource' est visible ou pas.")> _
    Public Property ResourcesButtonVisible() As Boolean
        Get
            Return Me.Ressource_CheckBox.Visible
        End Get
        Set(ByVal value As Boolean)
            Me.Ressource_CheckBox.Visible = value
            ParameterComponent_SizeChanged(Nothing, Nothing)
        End Set
    End Property


    Friend WithEvents CodeEditor As New VelerSoftware.SZC35.TextEditor
    Friend WithEvents ColorPicker As New VelerSoftware.SZC.ColorPicker.frmColorPicker(Drawing.Color.Black)

    Private Sub ParameterComponent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            With .CodeEditor
                .ShowLineNumbers = True
                .FontFamily = New System.Windows.Media.FontFamily("Consolas")
                .FontSize = 12
                .IsReadOnly = False
                .SyntaxHighlighting = VelerSoftware.SZC35.Highlighting.HighlightingManager.Instance.GetDefinition("VBNET")
                .SpellCheck = False
            End With
            .ElementHost1.Child = Me.CodeEditor

            .ColorPicker.Dock = System.Windows.Forms.DockStyle.Fill
            .ColorPicker.BackColor = Drawing.Color.Transparent
            .Color_Panel.Controls.Add(Me.ColorPicker)

            .VB_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Text_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Num_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .TrueFalse_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Color_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Other_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Variables_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            .Resources_Panel.Dock = System.Windows.Forms.DockStyle.Fill

            .Text_ActionTextBox.Multiline = True
            .Number_ActionTextBox.Multiline = True
            .Variables_ActionTextBox.Multiline = False
            .Text_ActionTextBox.WordWrap = False
            .Number_ActionTextBox.WordWrap = False
            .Variables_ActionTextBox.WordWrap = False
            .Text_ActionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
            .Number_ActionTextBox.Dock = System.Windows.Forms.DockStyle.Fill

            .Number_ActionTextBox.SpellCheck = False
            .Variables_ActionTextBox.SpellCheck = False

            .ParameterComponent_SizeChanged(Nothing, Nothing)
        End With
    End Sub

    Private Sub ParameterComponent_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        With Me
            Dim Hei As Integer = 2
            If .VB_CheckBox.Visible Then Hei += 24
            If .Text_CheckBox.Visible Then Hei += 24
            If .Number_CheckBox.Visible Then Hei += 24
            If .TrueFalse_CheckBox.Visible Then Hei += 24
            If .Color_CheckBox.Visible Then Hei += 24
            If .Other_CheckBox.Visible Then Hei += 24
            If .Variable_CheckBox.Visible Then Hei += 24
            If .Ressource_CheckBox.Visible Then Hei += 24
            If .Height < Hei Then
                If .SplitContainer1.Panel2.Width = 25 Then
                    .SplitContainer1.SplitterDistance = Me.SplitContainer1.SplitterDistance - 24
                End If
            Else
                If .SplitContainer1.Panel2.Width = 49 Then
                    .SplitContainer1.SplitterDistance = Me.SplitContainer1.SplitterDistance + 24
                End If
            End If
        End With
    End Sub











    Private Sub CopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopierToolStripMenuItem.Click
        Me.CodeEditor.Copy()
    End Sub

    Private Sub CouperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouperToolStripMenuItem.Click
        Me.CodeEditor.Cut()
    End Sub

    Private Sub CollerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollerToolStripMenuItem.Click
        Me.CodeEditor.Paste()
    End Sub

    Private Sub SélectionnerToutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SélectionnerToutToolStripMenuItem.Click
        Me.CodeEditor.SelectAll()
    End Sub

    Private Sub AnnulerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerToolStripMenuItem.Click
        Me.CodeEditor.Undo()
    End Sub

    Private Sub RétablirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RétablirToolStripMenuItem.Click
        Me.CodeEditor.Redo()
    End Sub




    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VB_CheckBox.CheckedChanged
        If Me.VB_CheckBox.Checked Then
            Me.Editor = ValueType.VBNet
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_CheckBox.CheckedChanged
        If Me.Text_CheckBox.Checked Then
            Me.Editor = ValueType.Text
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Number_CheckBox.CheckedChanged
        If Me.Number_CheckBox.Checked Then
            Me.Editor = ValueType.Number
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueFalse_CheckBox.CheckedChanged
        If Me.TrueFalse_CheckBox.Checked Then
            Me.Editor = ValueType.TrueFalse
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Color_CheckBox.CheckedChanged
        If Me.Color_CheckBox.Checked Then
            Me.Editor = ValueType.Color
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Other_CheckBox.CheckedChanged
        If Me.Other_CheckBox.Checked Then
            Me.Editor = ValueType.Other
        End If
    End Sub

    Private Sub Variable_CheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Variable_CheckBox.CheckedChanged
        If Me.Variable_CheckBox.Checked Then
            Me.Editor = ValueType.Variables
        End If
    End Sub

    Private Sub Ressource_CheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Ressource_CheckBox.CheckedChanged
        If Me.Ressource_CheckBox.Checked Then
            Me.Editor = ValueType.Resources
        End If
    End Sub





    Public Function GetGeneratedCode() As String
        Dim resultat As String = ""
        UpdateGeneratedCode()
        resultat = Me.CodeEditor.Document.Text
        Return resultat
    End Function

    Public Function GetStrictValue() As String
        Dim resultat As String = ""
        Select Case Me.Editor
            Case ValueType.Color
                UpdateGeneratedCode()
                resultat = Me.CodeEditor.Document.Text
            Case ValueType.Number
                resultat = Me.Number_ActionTextBox.Text
            Case ValueType.Other
                UpdateGeneratedCode()
                resultat = (Me.Constructor_ComboBox.SelectedIndex + 1) & "-" & Me.CodeEditor.Document.Text
            Case ValueType.Text
                resultat = Me.Text_ActionTextBox.Text
            Case ValueType.TrueFalse
                UpdateGeneratedCode()
                resultat = Me.CodeEditor.Document.Text
            Case ValueType.VBNet
                resultat = Me.CodeEditor.Document.Text
            Case ValueType.Variables
                If Me.Tools IsNot Nothing Then
                    For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                        If var.Name = Me.Variables_ComboBox.Text Then
                            If var.Array Then
                                resultat = Me.Variables_ComboBox.Text & "|" & Me.Variables_ActionTextBox.Text
                            Else
                                resultat = Me.Variables_ComboBox.Text
                            End If
                            Exit For
                        End If
                    Next
                End If
            Case ValueType.Resources
                resultat = Me.Resources_ComboBox.Text
        End Select
        Return resultat
    End Function

    Public Sub SetGeneratedCode(ByVal code As String)
        Me.Editor = ValueType.VBNet
        With Me.CodeEditor.Document
            If code = Nothing Then
                .Text = " "
            Else
                .Text = code
            End If
        End With

    End Sub

    Public Sub SetStrictValue(ByVal strictvalue As String, ByVal _type As ValueType)
        With Me
            Select Case _type
                Case ValueType.Text
                    .Editor = ValueType.Text
                    .Text_ActionTextBox.Text = strictvalue
                Case ValueType.Number
                    .Editor = ValueType.Number
                    .Number_ActionTextBox.Text = strictvalue
                Case ValueType.TrueFalse
                    .Editor = ValueType.TrueFalse
                    If Not strictvalue = Nothing Then
                        If CBool(strictvalue) Then
                            .Vrai_RadioButton.Checked = True
                        Else
                            .Faux_RadioButton.Checked = True
                        End If
                    End If
                Case ValueType.VBNet
                    .Editor = ValueType.VBNet
                    If strictvalue = Nothing Then
                        .CodeEditor.Document.Text = " "
                    Else
                        .CodeEditor.Document.Text = strictvalue
                    End If
                Case ValueType.Color
                    .Editor = ValueType.Color
                    If strictvalue.StartsWith("System.Drawing.Color.FromArgb(") Then
                        strictvalue = strictvalue.Replace("System.Drawing.Color.FromArgb(", Nothing)
                        .ColorPicker.PrimaryColor = Drawing.Color.FromArgb(CInt(strictvalue.Split(",")(0)), CInt(strictvalue.Split(",")(1)), CInt(strictvalue.Split(",")(2)), CInt(strictvalue.Split(",")(3).TrimEnd(")")))
                    End If
                Case ValueType.Other
                    .Editor = ValueType.Other
                    If Not strictvalue = Nothing Then
                        Dim resolver As New VelerSoftware.SZC.WindowsDesigner.TypeResolutionService
                        Dim t As Type = resolver.GetType(strictvalue.Split("-")(1).Split("(")(0).Replace("New ", Nothing).Trim(" "))
                        If Not t Is Nothing Then
                            Tips = t
                            .Type_TextBox.Text = Tips.FullName
                            .Constructor_ComboBox.Items.Clear()
                            With .PropertyGrids1
                                .SelectedObjects = Nothing
                                .Item.Clear()
                                .ItemSet.Clear()
                                .ShowCustomProperties = True
                                .Refresh()
                            End With
                            Dim i As Integer = 0
                            For Each ifo As Reflection.ConstructorInfo In Tips.GetConstructors()
                                If ifo.IsPublic Then
                                    i += 1
                                    .Constructor_ComboBox.Items.Add(String.Format("{0} - Constructor with {1} parameter(s)", i, CType(ifo, Reflection.ConstructorInfo).GetParameters.Length))
                                End If
                            Next
                            If .Constructor_ComboBox.Items.Count > 0 Then .Constructor_ComboBox.SelectedIndex = 0
                            .Constructor_ComboBox.SelectedIndex = CInt(strictvalue.Split("-")(0)) - 1
                            Dim ind As Integer = 0
                            Dim strictvaluesplit As String = strictvalue.Split("(")(1).Split(",")(ind).TrimEnd(")").Trim(" ").Trim(ChrW(34))
                            For Each prop As VelerSoftware.SZVB.PropertyGrids.CustomProperty In Me.PropertyGrids1.Item
                                If prop.Type.FullName = "System.String" Then
                                    prop.Value = CStr(strictvaluesplit)
                                ElseIf prop.Type.FullName = "System.Int32" Then
                                    prop.Value = CInt(strictvaluesplit)
                                Else
                                    prop.Value = TryCast(strictvaluesplit, Object)
                                End If
                                ind += 1
                            Next
                        End If
                    End If
                Case ValueType.Variables
                    .Editor = ValueType.Variables
                    If Not strictvalue = Nothing Then
                        If strictvalue.Contains("|") Then
                            .Variables_ComboBox.Text = strictvalue.Split("|")(0)
                            .Variables_ActionTextBox.Text = strictvalue.Split("|")(1)
                        Else
                            .Variables_ComboBox.Text = strictvalue
                        End If
                    End If
                Case ValueType.Resources
                    .Editor = ValueType.Resources
                    .Resources_ComboBox.Text = strictvalue
            End Select
        End With
    End Sub

    Private Sub UpdateGeneratedCode()
        With Me
            If Ex_Editor = ValueType.Color Then
                .CodeEditor.Document.Text = "System.Drawing.Color.FromArgb(" & .ColorPicker.PrimaryColor.A & ", " & .ColorPicker.PrimaryColor.R & ", " & .ColorPicker.PrimaryColor.G & ", " & .ColorPicker.PrimaryColor.B & ")"
                If Ex_Editor = ValueType.Color AndAlso _Editor = ValueType.Number Then
                    .Number_ActionTextBox.Text = Me.ColorPicker.PrimaryColor.ToArgb
                ElseIf Ex_Editor = ValueType.Color AndAlso _Editor = ValueType.Other Then
                    With .PropertyGrids1
                        .SelectedObjects = Nothing
                        .Item.Clear()
                        .ItemSet.Clear()
                        .ShowCustomProperties = True
                        .Refresh()
                    End With
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.Color AndAlso _Editor = ValueType.Text Then
                    .Text_ActionTextBox.Text = Nothing
                ElseIf Ex_Editor = ValueType.Color AndAlso _Editor = ValueType.TrueFalse Then
                    .Vrai_RadioButton.Checked = True
                ElseIf Ex_Editor = ValueType.Color AndAlso _Editor = ValueType.Variables Then
                    .Variables_ComboBox.Text = Nothing
                    .Variables_ActionTextBox.Text = "0"
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Resources Then
                    .Resources_ComboBox.Text = Nothing
                End If
            End If

            If Ex_Editor = ValueType.Number Then
                If Not .Number_ActionTextBox.Text = Nothing Then
                    If Tools IsNot Nothing Then
                        .CodeEditor.Document.Text = "CInt(" & Tools.TransformKeyVariables(.Number_ActionTextBox.Text, False, False) & ")"
                    Else
                        .CodeEditor.Document.Text = "CInt(" & .Number_ActionTextBox.Text & ")"
                    End If
                Else
                    .CodeEditor.Document.Text = "CInt(O)"
                End If

                If Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Color Then
                    .ColorPicker.PrimaryColor = Drawing.Color.Black
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Other Then
                    With .PropertyGrids1
                        .SelectedObjects = Nothing
                        .Item.Clear()
                        .ItemSet.Clear()
                        .ShowCustomProperties = True
                        .Refresh()
                    End With
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Text Then
                    .Text_ActionTextBox.Text = .Number_ActionTextBox.Text
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.TrueFalse Then
                    If .Number_ActionTextBox.Text = "0" Then
                        .Faux_RadioButton.Checked = True
                    Else
                        .Vrai_RadioButton.Checked = True
                    End If
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Variables Then
                    .Variables_ComboBox.Text = Nothing
                    .Variables_ActionTextBox.Text = "0"
                    If .Number_ActionTextBox.Text.StartsWith("%(VARIABLE=") Then
                        Dim txt As String = .Number_ActionTextBox.Text.Split("=")(1).Split(")")(0)
                        If txt.Contains("[") AndAlso txt.Contains("]") Then
                            .Variables_ComboBox.Text = txt.Split("[")(0)
                            .Variables_ActionTextBox.Text = txt.Split("[")(1).TrimEnd("]")
                        Else
                            .Variables_ComboBox.Text = txt
                            .Variables_ActionTextBox.Text = "0"
                        End If
                        .Variables_ComboBox_SelectedIndexChanged(Nothing, Nothing)
                    End If
                ElseIf Ex_Editor = ValueType.Number AndAlso _Editor = ValueType.Resources Then
                    .Resources_ComboBox.Text = Nothing
                    If .Number_ActionTextBox.Text.StartsWith("%(RESOURCE=") Then
                        Dim txt As String = .Number_ActionTextBox.Text.Split("=")(1).Split(")")(0)
                        .Resources_ComboBox.Text = txt
                    End If
                End If
            End If

            If Ex_Editor = ValueType.Text Then
                'If Not Me.Text_ActionTextBox.Text = Nothing Then
                '    Me.CodeEditor.Document.Text = Me.Text_ActionTextBox.Text.Replace(ChrW(34), ChrW(34) & " & ChrW(34) & " & ChrW(34)).Replace(System.Environment.NewLine, ChrW(34) & " & System.Environment.NewLine & " & ChrW(34))
                'End If
                If (Not Tools Is Nothing) Then
                    .CodeEditor.Document.Text = Tools.TransformKeyVariables(Me.Text_ActionTextBox.Text, True)
                Else
                    .CodeEditor.Document.Text = ChrW(34) & Me.CodeEditor.Document.Text & ChrW(34)
                End If

                If Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.Color Then
                    If Not .Text_ActionTextBox.Text = Nothing Then
                        If .Text_ActionTextBox.Text.StartsWith("System.Drawing.Color.FromArgb(") AndAlso .Text_ActionTextBox.Text.EndsWith(")") Then
                            Dim col As String = .Text_ActionTextBox.Text.Substring(30, .Text_ActionTextBox.Text.Length - 31)
                            .ColorPicker.PrimaryColor = Drawing.Color.FromArgb(col.Split(",")(0).Trim(" "), col.Split(",")(1).Trim(" "), col.Split(",")(2).Trim(" "), col.Split(",")(3).Trim(" "))
                        Else
                            .ColorPicker.PrimaryColor = Drawing.Color.Black
                        End If
                    Else
                        .ColorPicker.PrimaryColor = Drawing.Color.Black
                    End If
                ElseIf Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.Other Then
                    With .PropertyGrids1
                        .SelectedObjects = Nothing
                        .Item.Clear()
                        .ItemSet.Clear()
                        .ShowCustomProperties = True
                        .Refresh()
                    End With
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.Number Then
                    If Not .Text_ActionTextBox.Text = Nothing Then
                        If .Text_ActionTextBox.Text.StartsWith("CInt(") AndAlso .Text_ActionTextBox.Text.EndsWith(")") Then
                            .Number_ActionTextBox.Text = .Text_ActionTextBox.Text.Substring(5, .Text_ActionTextBox.Text.Length - 6)
                        Else
                            .Number_ActionTextBox.Text = 0
                        End If
                    Else
                        .Number_ActionTextBox.Text = 0
                    End If
                ElseIf Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.TrueFalse Then
                    If .Text_ActionTextBox.Text.ToUpper = "FALSE" Then
                        .Faux_RadioButton.Checked = True
                    Else
                        .Vrai_RadioButton.Checked = True
                    End If
                ElseIf Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.Variables Then
                    .Variables_ComboBox.Text = Nothing
                    .Variables_ActionTextBox.Text = "0"
                    If .Text_ActionTextBox.Text.StartsWith("%(VARIABLE=") Then
                        Dim txt As String = .Text_ActionTextBox.Text.Split("=")(1).Split(")")(0)
                        If txt.Contains("[") AndAlso txt.Contains("]") Then
                            .Variables_ComboBox.Text = txt.Split("[")(0)
                            .Variables_ActionTextBox.Text = txt.Split("[")(1).TrimEnd("]")
                        Else
                            .Variables_ComboBox.Text = txt
                            .Variables_ActionTextBox.Text = "0"
                        End If
                        .Variables_ComboBox_SelectedIndexChanged(Nothing, Nothing)
                    End If
                ElseIf Ex_Editor = ValueType.Text AndAlso _Editor = ValueType.Resources Then
                    .Resources_ComboBox.Text = Nothing
                    If .Text_ActionTextBox.Text.StartsWith("%(RESOURCE=") Then
                        Dim txt As String = .Text_ActionTextBox.Text.Split("=")(1).Split(")")(0)
                        .Resources_ComboBox.Text = txt
                    End If
                End If
            End If

            If Ex_Editor = ValueType.TrueFalse Then
                .CodeEditor.Document.Text = .Vrai_RadioButton.Checked
                If Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Color Then
                    .ColorPicker.PrimaryColor = Drawing.Color.Black
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Other Then
                    With .PropertyGrids1
                        .SelectedObjects = Nothing
                        .Item.Clear()
                        .ItemSet.Clear()
                        .ShowCustomProperties = True
                        .Refresh()
                    End With
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Number Then
                    If .Vrai_RadioButton.Checked Then
                        .Number_ActionTextBox.Text = 1
                    Else
                        .Number_ActionTextBox.Text = 0
                    End If
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Text Then
                    .Text_ActionTextBox.Text = .Vrai_RadioButton.Checked.ToString
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Variables Then
                    .Variables_ComboBox.Text = Nothing
                    .Variables_ActionTextBox.Text = "0"
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Resources Then
                    .Resources_ComboBox.Text = Nothing
                End If
            End If

            If Ex_Editor = ValueType.VBNet Then
                If Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.TrueFalse Then
                    If .CodeEditor.Document.Text.ToUpper = "FALSE" Then
                        .Faux_RadioButton.Checked = True
                    ElseIf .CodeEditor.Document.Text.ToUpper = "TRUE" Then
                        .Vrai_RadioButton.Checked = True
                    Else
                        If Not .CodeEditor.Document.Text = Nothing Then
                            If .CodeEditor.Document.Text.StartsWith("CInt(") AndAlso .CodeEditor.Document.Text.EndsWith(")") Then
                                If .CodeEditor.Document.Text.Substring(5, .CodeEditor.Document.Text.Length - 6) = "0" Then
                                    .Faux_RadioButton.Checked = True
                                Else
                                    .Vrai_RadioButton.Checked = True
                                End If
                            Else
                                .Vrai_RadioButton.Checked = True
                            End If
                        Else
                            .Vrai_RadioButton.Checked = True
                        End If
                    End If
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Color Then
                    If Not .CodeEditor.Document.Text = Nothing Then
                        If .CodeEditor.Document.Text.StartsWith("System.Drawing.Color.FromArgb(") AndAlso .CodeEditor.Document.Text.EndsWith(")") Then
                            Dim col As String = .CodeEditor.Document.Text.Substring(30, .CodeEditor.Document.Text.Length - 31)
                            .ColorPicker.PrimaryColor = Drawing.Color.FromArgb(col.Split(",")(0).Trim(" "), col.Split(",")(1).Trim(" "), col.Split(",")(2).Trim(" "), col.Split(",")(3).Trim(" "))
                        Else
                            .ColorPicker.PrimaryColor = Drawing.Color.Black
                        End If
                    Else
                        .ColorPicker.PrimaryColor = Drawing.Color.Black
                    End If
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Other Then
                    With .PropertyGrids1
                        .SelectedObjects = Nothing
                        .Item.Clear()
                        .ItemSet.Clear()
                        .ShowCustomProperties = True
                        .Refresh()
                    End With
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Number Then
                    If Not .CodeEditor.Document.Text = Nothing Then
                        If .CodeEditor.Document.Text.StartsWith("CInt(") AndAlso .CodeEditor.Document.Text.EndsWith(")") Then
                            .Number_ActionTextBox.Text = .CodeEditor.Document.Text.Substring(5, .CodeEditor.Document.Text.Length - 6)
                        Else
                            .Number_ActionTextBox.Text = 0
                        End If
                    Else
                        .Number_ActionTextBox.Text = 0
                    End If
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Text Then
                    If Not .CodeEditor.Document.Text = Nothing Then
                        .Text_ActionTextBox.Text = .CodeEditor.Document.Text.Trim(ChrW(34))
                    End If
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Variables Then
                    If Not .CodeEditor.Document.Text = Nothing AndAlso (Not Tools Is Nothing) Then
                        For Each var As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                            If var.Array AndAlso .CodeEditor.Document.Text.StartsWith(var.Name & "(") Then
                                .Variables_ComboBox.Text = .CodeEditor.Document.Text.Split("(")(0)
                                .Variables_ActionTextBox.Text = .CodeEditor.Document.Text.Split("(")(1).TrimEnd(")")
                            ElseIf .CodeEditor.Document.Text = var.Name Then
                                .CodeEditor.Document.Text = .Variables_ComboBox.Text
                                .Variables_ActionTextBox.Text = "0"
                            End If
                        Next
                    End If
                ElseIf Ex_Editor = ValueType.VBNet AndAlso _Editor = ValueType.Resources Then
                    If Not .CodeEditor.Document.Text = Nothing Then
                        If .CodeEditor.Document.Text.StartsWith("My.Resources.") Then
                            Dim col As String = .CodeEditor.Document.Text.Substring(13, .CodeEditor.Document.Text.Length - 13)
                            .Resources_ComboBox.Text = col
                        Else
                            .Resources_ComboBox.Text = Nothing
                        End If
                    Else
                        .Resources_ComboBox.Text = Nothing
                    End If
                End If
            End If


            If Ex_Editor = ValueType.Other Then
                If Not .Type_TextBox.Text = Nothing Then
                    Dim param As String = ""
                    For Each a As VelerSoftware.SZVB.PropertyGrids.CustomProperty In .PropertyGrids1.Item
                        If a.Type.FullName = "System.String" Then
                            param = param & ChrW(34) & a.Value.ToString & ChrW(34) & ", "
                        Else
                            If a.Value Is Nothing Then
                                param = param & "Nothing, "
                            Else
                                param = param & a.Value.ToString & ", "
                            End If
                        End If
                    Next
                    If param <> Nothing Then param = Mid(param, 1, param.Length - 2)
                    .CodeEditor.Document.Text = "New " & .Type_TextBox.Text & "(" & param & ")"
                    If Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.TrueFalse Then
                        .Vrai_RadioButton.Checked = True
                    ElseIf Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.Color Then
                        .ColorPicker.PrimaryColor = Drawing.Color.Black
                    ElseIf Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.Number Then
                        .Number_ActionTextBox.Text = Nothing
                    ElseIf Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.Text Then
                        .Text_ActionTextBox.Text = Nothing
                    ElseIf Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.Variables Then
                        .Variables_ComboBox.Text = Nothing
                        .Variables_ActionTextBox.Text = "0"
                    ElseIf Ex_Editor = ValueType.Other AndAlso _Editor = ValueType.Resources Then
                        .Resources_ComboBox.Text = Nothing
                    End If
                Else
                    .CodeEditor.Document.Text = ""
                End If
            End If



            If Ex_Editor = ValueType.Variables Then
                If (Not Tools Is Nothing) Then
                    For Each var As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                        If var.Name = .Variables_ComboBox.Text Then
                            If var.Array Then
                                .CodeEditor.Document.Text = .Variables_ComboBox.Text & "(" & .Tools.TransformKeyVariables(.Variables_ActionTextBox.Text, False, False) & ")"
                            Else
                                .CodeEditor.Document.Text = .Variables_ComboBox.Text
                            End If
                        End If
                    Next
                End If

                If Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.Color Then
                    .ColorPicker.PrimaryColor = Drawing.Color.Black
                ElseIf Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.Other Then
                    .PropertyGrids1.SelectedObjects = Nothing
                    .PropertyGrids1.Item.Clear()
                    .PropertyGrids1.ItemSet.Clear()
                    .PropertyGrids1.ShowCustomProperties = True
                    .PropertyGrids1.Refresh()
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.Number Then
                    If Not .Variables_ComboBox.Text = Nothing Then
                        If (Not Tools Is Nothing) Then
                            For Each var As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                                If var.Name = .Variables_ComboBox.Text Then
                                    If var.Array Then
                                        .Number_ActionTextBox.Text = "%(VARIABLE=" & .Variables_ComboBox.Text & "[" & .Variables_ActionTextBox.Text & "])%"
                                    Else
                                        .Number_ActionTextBox.Text = "%(VARIABLE=" & .Variables_ComboBox.Text & ")%"
                                    End If
                                End If
                            Next
                        End If
                    Else
                        .Number_ActionTextBox.Text = 0
                    End If
                ElseIf Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.Text Then
                    If Not .Variables_ComboBox.Text = Nothing Then
                        If (Not Tools Is Nothing) Then
                            For Each var As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                                If var.Name = Me.Variables_ComboBox.Text Then
                                    If var.Array Then
                                        .Text_ActionTextBox.Text = "%(VARIABLE=" & .Variables_ComboBox.Text & "[" & .Variables_ActionTextBox.Text & "])%"
                                    Else
                                        .Text_ActionTextBox.Text = "%(VARIABLE=" & .Variables_ComboBox.Text & ")%"
                                    End If
                                End If
                            Next
                        End If
                    Else
                        .Text_ActionTextBox.Text = Nothing
                    End If
                ElseIf Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.TrueFalse Then
                    .Vrai_RadioButton.Checked = True
                ElseIf Ex_Editor = ValueType.Variables AndAlso _Editor = ValueType.Resources Then
                    .Resources_ComboBox.Text = Nothing
                End If
            End If



            If Ex_Editor = ValueType.Resources Then
                .CodeEditor.Document.Text = "My.Resources." & .Resources_ComboBox.Text

                If Ex_Editor = ValueType.Resources AndAlso _Editor = ValueType.Color Then
                    .ColorPicker.PrimaryColor = Drawing.Color.Black
                ElseIf Ex_Editor = ValueType.Resources AndAlso _Editor = ValueType.Other Then
                    .PropertyGrids1.SelectedObjects = Nothing
                    .PropertyGrids1.Item.Clear()
                    .PropertyGrids1.ItemSet.Clear()
                    .PropertyGrids1.ShowCustomProperties = True
                    .PropertyGrids1.Refresh()
                    .Constructor_ComboBox.Items.Clear()
                    .Type_TextBox.Text = Nothing
                    .Tips = Nothing
                ElseIf Ex_Editor = ValueType.Resources AndAlso _Editor = ValueType.Number Then
                    If Not .Resources_ComboBox.Text = Nothing Then
                        .Number_ActionTextBox.Text = "%(RESOURCE=" & .Resources_ComboBox.Text & ")%"
                    Else
                        .Number_ActionTextBox.Text = 0
                    End If
                ElseIf Ex_Editor = ValueType.Resources AndAlso _Editor = ValueType.Text Then
                    If Not .Resources_ComboBox.Text = Nothing Then
                        .Text_ActionTextBox.Text = "%(RESOURCE=" & .Resources_ComboBox.Text & ")%"
                    Else
                        .Text_ActionTextBox.Text = Nothing
                    End If
                ElseIf Ex_Editor = ValueType.Resources AndAlso _Editor = ValueType.TrueFalse Then
                    .Vrai_RadioButton.Checked = True
                ElseIf Ex_Editor = ValueType.TrueFalse AndAlso _Editor = ValueType.Variables Then
                    .Variables_ComboBox.Text = Nothing
                    .Variables_ActionTextBox.Text = "0"
                End If
            End If



            If .CodeEditor.Document.Text = "" Then      .CodeEditor.Document.Text = "Nothing"
          
            Ex_Editor = _Editor
        End With
    End Sub










    Private Tips As Type

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type_Button.Click
        With Me
            Dim t As Type = Me.Tools.SelectType()
            If Not t Is Nothing Then
                Tips = t
                .Type_TextBox.Text = Tips.FullName
                .Constructor_ComboBox.Items.Clear()
                .PropertyGrids1.SelectedObjects = Nothing
                .PropertyGrids1.Item.Clear()
                .PropertyGrids1.ItemSet.Clear()
                .PropertyGrids1.ShowCustomProperties = True
                .PropertyGrids1.Refresh()
                Dim i As Integer = 0
                For Each ifo As Reflection.ConstructorInfo In Tips.GetConstructors()
                    If ifo.IsPublic Then
                        i += 1
                        .Constructor_ComboBox.Items.Add(String.Format("{0} - Constructor with {1} parameter(s)", i, CType(ifo, Reflection.ConstructorInfo).GetParameters.Length))
                    End If
                Next
                If .Constructor_ComboBox.Items.Count > 0 Then Me.Constructor_ComboBox.SelectedIndex = 0
            End If
        End With
    End Sub

    Private Sub Constructor_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constructor_ComboBox.SelectedIndexChanged
        With Me
            If Not .Constructor_ComboBox.Text = Nothing Then
                If Not Tips Is Nothing Then
                    .PropertyGrids1.SelectedObjects = Nothing
                    .PropertyGrids1.Item.Clear()
                    .PropertyGrids1.ItemSet.Clear()
                    .PropertyGrids1.ShowCustomProperties = True
                    .PropertyGrids1.Refresh()
                    Dim i As Integer = 0
                    For Each ifo As Reflection.ConstructorInfo In Tips.GetConstructors()
                        i += 1
                        If i = CInt(Me.Constructor_ComboBox.Text.Split(" ")(0)) Then
                            For Each pi As Reflection.ParameterInfo In CType(ifo, Reflection.ConstructorInfo).GetParameters
                                ' MsgBox("nom : " & pi.Name & Environment.NewLine & "is value type : " & pi.ParameterType.IsValueType & Environment.NewLine & pi.ParameterType.GetConstructors().Count & Environment.NewLine & "is generic type : " & pi.ParameterType.IsGenericType & Environment.NewLine & "is class : " & pi.ParameterType.IsClass & Environment.NewLine & "is by ref : " & pi.ParameterType.IsByRef & Environment.NewLine & "is interface : " & pi.ParameterType.IsInterface & Environment.NewLine & "full name : " & pi.ParameterType.FullName)
                                Try
                                    If pi.ParameterType.FullName = "System.String" Then
                                        .PropertyGrids1.Item.Add(pi.Name, "", False, "", "", True)
                                    Else
                                        .PropertyGrids1.Item.Add(pi.Name, pi.ParameterType.Assembly.CreateInstance(pi.ParameterType.FullName, True), False, "", "", True)
                                    End If
                                    If .PropertyGrids1.Item(.PropertyGrids1.Item.Count - 1).IsReadOnly Then .PropertyGrids1.Item(.PropertyGrids1.Item.Count - 1).Value = Nothing
                                Catch
                                    .PropertyGrids1.Item.Add(pi.Name, pi.ParameterType, False, "", "", True)
                                    If .PropertyGrids1.Item(.PropertyGrids1.Item.Count - 1).IsReadOnly Then .PropertyGrids1.Item(.PropertyGrids1.Item.Count - 1).Value = Nothing
                                End Try
                            Next
                        End If
                    Next
                    Me.PropertyGrids1.Refresh()
                End If
            End If
        End With
    End Sub

    Private Sub Variables_ComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Variables_ComboBox.SelectedIndexChanged
        Me.Variables_ComboBox.Refresh()
        If (Not Tools Is Nothing) Then
            For Each var As VelerSoftware.SZVB.Projet.Variable In Me.Tools.GetCurrentProjectVariableList
                If var.Name = Me.Variables_ComboBox.Text Then
                    If var.Array Then
                        Me.Variables_ActionTextBox.Enabled = True
                    Else
                        Me.Variables_ActionTextBox.Enabled = False
                    End If
                End If
            Next
        End If
    End Sub
End Class
