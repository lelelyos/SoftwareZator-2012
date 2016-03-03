<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ajouter_Element_ListView_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ajouter_Element_ListView_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Index_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Texte_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.InfoBulle_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Img_ActionTextBox4 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
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
        Me.Controls_Panel.Controls.Add(Me.CheckBox1)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Img_ActionTextBox4)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.InfoBulle_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Texte_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Index_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.RadioButton2)
        Me.Controls_Panel.Controls.Add(Me.RadioButton1)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Nom_ActionTextBox)
        Me.Controls_Panel.Controls.Add(Me.Boutons_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Boutons_ComboBox
        '
        Me.Boutons_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Boutons_ComboBox, "Boutons_ComboBox")
        Me.Boutons_ComboBox.FormattingEnabled = True
        Me.Boutons_ComboBox.Items.AddRange(New Object() {resources.GetString("Boutons_ComboBox.Items"), resources.GetString("Boutons_ComboBox.Items1"), resources.GetString("Boutons_ComboBox.Items2"), resources.GetString("Boutons_ComboBox.Items3"), resources.GetString("Boutons_ComboBox.Items4"), resources.GetString("Boutons_ComboBox.Items5")})
        Me.Boutons_ComboBox.Name = "Boutons_ComboBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Nom_ActionTextBox
        '
        Me.Nom_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Nom_ActionTextBox, "Nom_ActionTextBox")
        Me.Nom_ActionTextBox.Multiline = False
        Me.Nom_ActionTextBox.Name = "Nom_ActionTextBox"
        Me.Nom_ActionTextBox.SpellCheck = True
        Me.Nom_ActionTextBox.Tools = Nothing
        Me.Nom_ActionTextBox.WordWrap = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Index_ActionTextBox1
        '
        Me.Index_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Index_ActionTextBox1, "Index_ActionTextBox1")
        Me.Index_ActionTextBox1.Multiline = False
        Me.Index_ActionTextBox1.Name = "Index_ActionTextBox1"
        Me.Index_ActionTextBox1.SpellCheck = False
        Me.Index_ActionTextBox1.Tools = Nothing
        Me.Index_ActionTextBox1.WordWrap = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Texte_ActionTextBox2
        '
        Me.Texte_ActionTextBox2.IsReadOnly = False
        resources.ApplyResources(Me.Texte_ActionTextBox2, "Texte_ActionTextBox2")
        Me.Texte_ActionTextBox2.Multiline = False
        Me.Texte_ActionTextBox2.Name = "Texte_ActionTextBox2"
        Me.Texte_ActionTextBox2.SpellCheck = True
        Me.Texte_ActionTextBox2.Tools = Nothing
        Me.Texte_ActionTextBox2.WordWrap = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'InfoBulle_ActionTextBox3
        '
        Me.InfoBulle_ActionTextBox3.IsReadOnly = False
        resources.ApplyResources(Me.InfoBulle_ActionTextBox3, "InfoBulle_ActionTextBox3")
        Me.InfoBulle_ActionTextBox3.Multiline = False
        Me.InfoBulle_ActionTextBox3.Name = "InfoBulle_ActionTextBox3"
        Me.InfoBulle_ActionTextBox3.SpellCheck = True
        Me.InfoBulle_ActionTextBox3.Tools = Nothing
        Me.InfoBulle_ActionTextBox3.WordWrap = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Img_ActionTextBox4
        '
        Me.Img_ActionTextBox4.IsReadOnly = False
        resources.ApplyResources(Me.Img_ActionTextBox4, "Img_ActionTextBox4")
        Me.Img_ActionTextBox4.Multiline = False
        Me.Img_ActionTextBox4.Name = "Img_ActionTextBox4"
        Me.Img_ActionTextBox4.SpellCheck = False
        Me.Img_ActionTextBox4.Tools = Nothing
        Me.Img_ActionTextBox4.WordWrap = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Ajouter_Element_ListView_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.ajouter_item_listview
        Me.Name = "Ajouter_Element_ListView_Form"
        Me.Title = "Ajouter un élément à une Liste de cases à cocher"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Nom_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Index_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Img_ActionTextBox4 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents InfoBulle_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Texte_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
End Class
