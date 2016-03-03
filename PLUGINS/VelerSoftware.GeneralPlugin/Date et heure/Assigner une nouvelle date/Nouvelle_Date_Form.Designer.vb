<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nouvelle_Date_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nouvelle_Date_Form))
        Me.Boutons_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Annee_ActionTextBox1 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Mois_ActionTextBox2 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Jour_ActionTextBox3 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Heure_ActionTextBox4 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Minute_ActionTextBox5 = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Second_ActionTextBox6 = New VelerSoftware.Plugins3.ActionTextBox()
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
        Me.Controls_Panel.Controls.Add(Me.Second_ActionTextBox6)
        Me.Controls_Panel.Controls.Add(Me.Minute_ActionTextBox5)
        Me.Controls_Panel.Controls.Add(Me.Heure_ActionTextBox4)
        Me.Controls_Panel.Controls.Add(Me.Jour_ActionTextBox3)
        Me.Controls_Panel.Controls.Add(Me.Mois_ActionTextBox2)
        Me.Controls_Panel.Controls.Add(Me.Annee_ActionTextBox1)
        Me.Controls_Panel.Controls.Add(Me.Label7)
        Me.Controls_Panel.Controls.Add(Me.Label6)
        Me.Controls_Panel.Controls.Add(Me.Label5)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.Label2)
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
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Annee_ActionTextBox1
        '
        Me.Annee_ActionTextBox1.IsReadOnly = False
        resources.ApplyResources(Me.Annee_ActionTextBox1, "Annee_ActionTextBox1")
        Me.Annee_ActionTextBox1.Multiline = False
        Me.Annee_ActionTextBox1.Name = "Annee_ActionTextBox1"
        Me.Annee_ActionTextBox1.SpellCheck = False
        Me.Annee_ActionTextBox1.Tools = Nothing
        Me.Annee_ActionTextBox1.WordWrap = True
        '
        'Mois_ActionTextBox2
        '
        Me.Mois_ActionTextBox2.IsReadOnly = False
        resources.ApplyResources(Me.Mois_ActionTextBox2, "Mois_ActionTextBox2")
        Me.Mois_ActionTextBox2.Multiline = False
        Me.Mois_ActionTextBox2.Name = "Mois_ActionTextBox2"
        Me.Mois_ActionTextBox2.SpellCheck = False
        Me.Mois_ActionTextBox2.Tools = Nothing
        Me.Mois_ActionTextBox2.WordWrap = True
        '
        'Jour_ActionTextBox3
        '
        Me.Jour_ActionTextBox3.IsReadOnly = False
        resources.ApplyResources(Me.Jour_ActionTextBox3, "Jour_ActionTextBox3")
        Me.Jour_ActionTextBox3.Multiline = False
        Me.Jour_ActionTextBox3.Name = "Jour_ActionTextBox3"
        Me.Jour_ActionTextBox3.SpellCheck = False
        Me.Jour_ActionTextBox3.Tools = Nothing
        Me.Jour_ActionTextBox3.WordWrap = True
        '
        'Heure_ActionTextBox4
        '
        Me.Heure_ActionTextBox4.IsReadOnly = False
        resources.ApplyResources(Me.Heure_ActionTextBox4, "Heure_ActionTextBox4")
        Me.Heure_ActionTextBox4.Multiline = False
        Me.Heure_ActionTextBox4.Name = "Heure_ActionTextBox4"
        Me.Heure_ActionTextBox4.SpellCheck = False
        Me.Heure_ActionTextBox4.Tools = Nothing
        Me.Heure_ActionTextBox4.WordWrap = True
        '
        'Minute_ActionTextBox5
        '
        Me.Minute_ActionTextBox5.IsReadOnly = False
        resources.ApplyResources(Me.Minute_ActionTextBox5, "Minute_ActionTextBox5")
        Me.Minute_ActionTextBox5.Multiline = False
        Me.Minute_ActionTextBox5.Name = "Minute_ActionTextBox5"
        Me.Minute_ActionTextBox5.SpellCheck = False
        Me.Minute_ActionTextBox5.Tools = Nothing
        Me.Minute_ActionTextBox5.WordWrap = True
        '
        'Second_ActionTextBox6
        '
        Me.Second_ActionTextBox6.IsReadOnly = False
        resources.ApplyResources(Me.Second_ActionTextBox6, "Second_ActionTextBox6")
        Me.Second_ActionTextBox6.Multiline = False
        Me.Second_ActionTextBox6.Name = "Second_ActionTextBox6"
        Me.Second_ActionTextBox6.SpellCheck = False
        Me.Second_ActionTextBox6.Tools = Nothing
        Me.Second_ActionTextBox6.WordWrap = True
        '
        'Nouvelle_Date_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.nouvelle_date
        Me.Name = "Nouvelle_Date_Form"
        Me.Title = "Assigner une nouvelle date"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Boutons_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Second_ActionTextBox6 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Minute_ActionTextBox5 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Heure_ActionTextBox4 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Jour_ActionTextBox3 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Mois_ActionTextBox2 As VelerSoftware.Plugins3.ActionTextBox
    Friend WithEvents Annee_ActionTextBox1 As VelerSoftware.Plugins3.ActionTextBox
End Class
