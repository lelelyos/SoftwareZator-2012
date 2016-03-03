<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Afficher_Message_Avance_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Afficher_Message_Avance_Form))
        Me.Fenêtre_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Titre_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.EnTete_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Message_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IconePiedDePage_ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PiedDePage_ActionTextBox4 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PiedDePage_CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Info_ActionTextBox5 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.InfoCheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Bloquer_CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Icone_ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Variable_ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.Variable_ComboBox3)
        Me.Controls_Panel.Controls.Add(Me.Label10)
        Me.Controls_Panel.Controls.Add(Me.Bloquer_CheckBox3)
        Me.Controls_Panel.Controls.Add(Me.Icone_ComboBox2)
        Me.Controls_Panel.Controls.Add(Me.Label9)
        Me.Controls_Panel.Controls.Add(Me.Label8)
        Me.Controls_Panel.Controls.Add(Me.CheckedListBox1)
        Me.Controls_Panel.Controls.Add(Me.InfoCheckBox2)
        Me.Controls_Panel.Controls.Add(Me.Info_ActionTextBox5)
        Me.Controls_Panel.Controls.Add(Me.Label7)
        Me.Controls_Panel.Controls.Add(Me.PiedDePage_ActionTextBox4)
        Me.Controls_Panel.Controls.Add(Me.Label6)
        Me.Controls_Panel.Controls.Add(Me.PiedDePage_CheckBox1)
        Me.Controls_Panel.Controls.Add(Me.IconePiedDePage_ComboBox1)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Message_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.EnTete_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Titre_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Fenêtre_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Fenêtre_ComboBox
        '
        Me.Fenêtre_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fenêtre_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Fenêtre_ComboBox, "Fenêtre_ComboBox")
        Me.Fenêtre_ComboBox.FormattingEnabled = True
        Me.Fenêtre_ComboBox.Name = "Fenêtre_ComboBox"
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Titre_ActionTextBox1
        '
        Me.Titre_ActionTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Titre_ActionTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Titre_ActionTextBox1, "Titre_ActionTextBox1")
        Me.Titre_ActionTextBox1.IsReadOnly = False
        Me.Titre_ActionTextBox1.Multiline = False
        Me.Titre_ActionTextBox1.Name = "Titre_ActionTextBox1"
        Me.Titre_ActionTextBox1.SpellCheck = True
        Me.Titre_ActionTextBox1.Tools = Nothing
        Me.Titre_ActionTextBox1.WordWrap = True
        '
        'EnTete_ActionTextBox2
        '
        Me.EnTete_ActionTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.EnTete_ActionTextBox2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.EnTete_ActionTextBox2, "EnTete_ActionTextBox2")
        Me.EnTete_ActionTextBox2.IsReadOnly = False
        Me.EnTete_ActionTextBox2.Multiline = False
        Me.EnTete_ActionTextBox2.Name = "EnTete_ActionTextBox2"
        Me.EnTete_ActionTextBox2.SpellCheck = True
        Me.EnTete_ActionTextBox2.Tools = Nothing
        Me.EnTete_ActionTextBox2.WordWrap = True
        '
        'Label3
        '
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Message_ActionTextBox3
        '
        Me.Message_ActionTextBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Message_ActionTextBox3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Message_ActionTextBox3, "Message_ActionTextBox3")
        Me.Message_ActionTextBox3.IsReadOnly = False
        Me.Message_ActionTextBox3.Multiline = True
        Me.Message_ActionTextBox3.Name = "Message_ActionTextBox3"
        Me.Message_ActionTextBox3.SpellCheck = True
        Me.Message_ActionTextBox3.Tools = Nothing
        Me.Message_ActionTextBox3.WordWrap = False
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'IconePiedDePage_ComboBox1
        '
        Me.IconePiedDePage_ComboBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.IconePiedDePage_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.IconePiedDePage_ComboBox1, "IconePiedDePage_ComboBox1")
        Me.IconePiedDePage_ComboBox1.FormattingEnabled = True
        Me.IconePiedDePage_ComboBox1.Items.AddRange(New Object() {resources.GetString("IconePiedDePage_ComboBox1.Items"), resources.GetString("IconePiedDePage_ComboBox1.Items1"), resources.GetString("IconePiedDePage_ComboBox1.Items2"), resources.GetString("IconePiedDePage_ComboBox1.Items3"), resources.GetString("IconePiedDePage_ComboBox1.Items4"), resources.GetString("IconePiedDePage_ComboBox1.Items5"), resources.GetString("IconePiedDePage_ComboBox1.Items6"), resources.GetString("IconePiedDePage_ComboBox1.Items7"), resources.GetString("IconePiedDePage_ComboBox1.Items8"), resources.GetString("IconePiedDePage_ComboBox1.Items9"), resources.GetString("IconePiedDePage_ComboBox1.Items10"), resources.GetString("IconePiedDePage_ComboBox1.Items11")})
        Me.IconePiedDePage_ComboBox1.Name = "IconePiedDePage_ComboBox1"
        '
        'Label5
        '
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'PiedDePage_ActionTextBox4
        '
        Me.PiedDePage_ActionTextBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.PiedDePage_ActionTextBox4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.PiedDePage_ActionTextBox4, "PiedDePage_ActionTextBox4")
        Me.PiedDePage_ActionTextBox4.IsReadOnly = False
        Me.PiedDePage_ActionTextBox4.Multiline = False
        Me.PiedDePage_ActionTextBox4.Name = "PiedDePage_ActionTextBox4"
        Me.PiedDePage_ActionTextBox4.SpellCheck = True
        Me.PiedDePage_ActionTextBox4.Tools = Nothing
        Me.PiedDePage_ActionTextBox4.WordWrap = True
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'PiedDePage_CheckBox1
        '
        resources.ApplyResources(Me.PiedDePage_CheckBox1, "PiedDePage_CheckBox1")
        Me.PiedDePage_CheckBox1.Name = "PiedDePage_CheckBox1"
        Me.PiedDePage_CheckBox1.UseVisualStyleBackColor = True
        '
        'Info_ActionTextBox5
        '
        Me.Info_ActionTextBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.Info_ActionTextBox5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Info_ActionTextBox5, "Info_ActionTextBox5")
        Me.Info_ActionTextBox5.IsReadOnly = False
        Me.Info_ActionTextBox5.Multiline = False
        Me.Info_ActionTextBox5.Name = "Info_ActionTextBox5"
        Me.Info_ActionTextBox5.SpellCheck = True
        Me.Info_ActionTextBox5.Tools = Nothing
        Me.Info_ActionTextBox5.WordWrap = True
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'InfoCheckBox2
        '
        resources.ApplyResources(Me.InfoCheckBox2, "InfoCheckBox2")
        Me.InfoCheckBox2.Name = "InfoCheckBox2"
        Me.InfoCheckBox2.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {resources.GetString("CheckedListBox1.Items"), resources.GetString("CheckedListBox1.Items1"), resources.GetString("CheckedListBox1.Items2"), resources.GetString("CheckedListBox1.Items3"), resources.GetString("CheckedListBox1.Items4"), resources.GetString("CheckedListBox1.Items5"), resources.GetString("CheckedListBox1.Items6"), resources.GetString("CheckedListBox1.Items7"), resources.GetString("CheckedListBox1.Items8"), resources.GetString("CheckedListBox1.Items9"), resources.GetString("CheckedListBox1.Items10"), resources.GetString("CheckedListBox1.Items11")})
        resources.ApplyResources(Me.CheckedListBox1, "CheckedListBox1")
        Me.CheckedListBox1.Name = "CheckedListBox1"
        '
        'Label8
        '
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Bloquer_CheckBox3
        '
        resources.ApplyResources(Me.Bloquer_CheckBox3, "Bloquer_CheckBox3")
        Me.Bloquer_CheckBox3.Name = "Bloquer_CheckBox3"
        Me.Bloquer_CheckBox3.UseVisualStyleBackColor = True
        '
        'Icone_ComboBox2
        '
        Me.Icone_ComboBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icone_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Icone_ComboBox2, "Icone_ComboBox2")
        Me.Icone_ComboBox2.FormattingEnabled = True
        Me.Icone_ComboBox2.Items.AddRange(New Object() {resources.GetString("Icone_ComboBox2.Items"), resources.GetString("Icone_ComboBox2.Items1"), resources.GetString("Icone_ComboBox2.Items2"), resources.GetString("Icone_ComboBox2.Items3"), resources.GetString("Icone_ComboBox2.Items4"), resources.GetString("Icone_ComboBox2.Items5"), resources.GetString("Icone_ComboBox2.Items6"), resources.GetString("Icone_ComboBox2.Items7"), resources.GetString("Icone_ComboBox2.Items8"), resources.GetString("Icone_ComboBox2.Items9"), resources.GetString("Icone_ComboBox2.Items10"), resources.GetString("Icone_ComboBox2.Items11")})
        Me.Icone_ComboBox2.Name = "Icone_ComboBox2"
        '
        'Label9
        '
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Variable_ComboBox3
        '
        Me.Variable_ComboBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Variable_ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Variable_ComboBox3, "Variable_ComboBox3")
        Me.Variable_ComboBox3.FormattingEnabled = True
        Me.Variable_ComboBox3.Name = "Variable_ComboBox3"
        '
        'Label10
        '
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Afficher_Message_Avance_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.VistaMessageBox.My.Resources.Resources.application_error
        Me.Name = "Afficher_Message_Avance_Form"
        Me.Title = "Démarrer un Minuteur"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Fenêtre_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Titre_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Variable_ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Bloquer_CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Icone_ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents InfoCheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Info_ActionTextBox5 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PiedDePage_ActionTextBox4 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PiedDePage_CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents IconePiedDePage_ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Message_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EnTete_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
