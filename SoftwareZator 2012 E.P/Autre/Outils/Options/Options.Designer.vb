''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits VelerSoftware.SZVB.AeroWindowsForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.WizardTabControl1 = New VelerSoftware.SZVB.WizardTabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Fichiers_Extension_Button = New System.Windows.Forms.Button()
        Me.Emplacement_Projet_TextBox = New System.Windows.Forms.TextBox()
        Me.Emplacement_Projet_Button = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Nom_Societe_TextBox = New System.Windows.Forms.TextBox()
        Me.Nom_Utilisateur_TextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Interfaces = New System.Windows.Forms.TabPage()
        Me.Pause_CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Activer_Aero_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Barre_Acces_Rapide_En_Dessous_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Minimiser_Ruban_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Barre_Etat_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Language = New System.Windows.Forms.TabPage()
        Me.Langue_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Starter = New System.Windows.Forms.TabPage()
        Me.Splash_Screen_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Updates_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Start_Page_CheckBox = New System.Windows.Forms.CheckBox()
        Me.WindowsDesigner = New System.Windows.Forms.TabPage()
        Me.Suivre_Souris_Regle_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Panneaux_Lateral_WindowsDesigner_CheckBox = New System.Windows.Forms.CheckBox()
        Me.SmartTags_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Aimentation_Intelligente_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Afficher_Grille_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Functions_Editor = New System.Windows.Forms.TabPage()
        Me.Correcteur_Orthographique_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Zoom_Bar_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Panneau_Lateral_FunctionEditor_CheckBox = New System.Windows.Forms.CheckBox()
        Me.VBEditor = New System.Windows.Forms.TabPage()
        Me.Colorisation_Syntaxe_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Numerotation_Lignes_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Voice_Recognition = New System.Windows.Forms.TabPage()
        Me.Configure_Voice_Recognition_Button = New System.Windows.Forms.Button()
        Me.Sounds_Voice_Recognition_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Activate_Voice_Recognition_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Confidentiality = New System.Windows.Forms.TabPage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Erreurs_Generations_Confidentiality_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Vocale_Confidentiality_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Envoyer_Confidentiality_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.WizardTabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        Me.Interfaces.SuspendLayout()
        Me.Language.SuspendLayout()
        Me.Starter.SuspendLayout()
        Me.WindowsDesigner.SuspendLayout()
        Me.Functions_Editor.SuspendLayout()
        Me.VBEditor.SuspendLayout()
        Me.Voice_Recognition.SuspendLayout()
        Me.Confidentiality.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.TreeView1)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.WizardTabControl1)
        Me.Center_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        Me.Foot_Panel.Controls.Add(Me.Button1)
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        Me.Foot_Panel.Controls.SetChildIndex(Me.Button1, 0)
        Me.Foot_Panel.Controls.SetChildIndex(Me.Cancel_Button, 0)
        Me.Foot_Panel.Controls.SetChildIndex(Me.OK_Button, 0)
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'TreeView1
        '
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {CType(resources.GetObject("TreeView1.Nodes"), System.Windows.Forms.TreeNode), CType(resources.GetObject("TreeView1.Nodes1"), System.Windows.Forms.TreeNode), CType(resources.GetObject("TreeView1.Nodes2"), System.Windows.Forms.TreeNode)})
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowNodeToolTips = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'WizardTabControl1
        '
        resources.ApplyResources(Me.WizardTabControl1, "WizardTabControl1")
        Me.WizardTabControl1.Controls.Add(Me.General)
        Me.WizardTabControl1.Controls.Add(Me.Interfaces)
        Me.WizardTabControl1.Controls.Add(Me.Language)
        Me.WizardTabControl1.Controls.Add(Me.Starter)
        Me.WizardTabControl1.Controls.Add(Me.WindowsDesigner)
        Me.WizardTabControl1.Controls.Add(Me.Functions_Editor)
        Me.WizardTabControl1.Controls.Add(Me.VBEditor)
        Me.WizardTabControl1.Controls.Add(Me.Voice_Recognition)
        Me.WizardTabControl1.Controls.Add(Me.Confidentiality)
        Me.WizardTabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.WizardTabControl1.Multiline = True
        Me.WizardTabControl1.Name = "WizardTabControl1"
        Me.WizardTabControl1.SelectedIndex = 0
        '
        'General
        '
        Me.General.Controls.Add(Me.Button2)
        Me.General.Controls.Add(Me.RadioButton4)
        Me.General.Controls.Add(Me.RadioButton3)
        Me.General.Controls.Add(Me.RadioButton2)
        Me.General.Controls.Add(Me.RadioButton1)
        Me.General.Controls.Add(Me.Label8)
        Me.General.Controls.Add(Me.Fichiers_Extension_Button)
        Me.General.Controls.Add(Me.Emplacement_Projet_TextBox)
        Me.General.Controls.Add(Me.Emplacement_Projet_Button)
        Me.General.Controls.Add(Me.Label5)
        Me.General.Controls.Add(Me.Nom_Societe_TextBox)
        Me.General.Controls.Add(Me.Nom_Utilisateur_TextBox)
        Me.General.Controls.Add(Me.Label4)
        Me.General.Controls.Add(Me.Label3)
        Me.General.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.General, "General")
        Me.General.Name = "General"
        Me.General.UseVisualStyleBackColor = True
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        resources.ApplyResources(Me.RadioButton4, "RadioButton4")
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.TabStop = True
        Me.ToolTip1.SetToolTip(Me.RadioButton4, resources.GetString("RadioButton4.ToolTip"))
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.TabStop = True
        Me.ToolTip1.SetToolTip(Me.RadioButton3, resources.GetString("RadioButton3.ToolTip"))
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.TabStop = True
        Me.ToolTip1.SetToolTip(Me.RadioButton2, resources.GetString("RadioButton2.ToolTip"))
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.ToolTip1.SetToolTip(Me.RadioButton1, resources.GetString("RadioButton1.ToolTip"))
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Name = "Label8"
        '
        'Fichiers_Extension_Button
        '
        resources.ApplyResources(Me.Fichiers_Extension_Button, "Fichiers_Extension_Button")
        Me.Fichiers_Extension_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Fichiers_Extension_Button.Name = "Fichiers_Extension_Button"
        Me.Fichiers_Extension_Button.UseVisualStyleBackColor = True
        '
        'Emplacement_Projet_TextBox
        '
        resources.ApplyResources(Me.Emplacement_Projet_TextBox, "Emplacement_Projet_TextBox")
        Me.Emplacement_Projet_TextBox.BackColor = System.Drawing.SystemColors.Window
        Me.Emplacement_Projet_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Emplacement_Projet_TextBox.Name = "Emplacement_Projet_TextBox"
        Me.Emplacement_Projet_TextBox.ReadOnly = True
        Me.ToolTip1.SetToolTip(Me.Emplacement_Projet_TextBox, resources.GetString("Emplacement_Projet_TextBox.ToolTip"))
        '
        'Emplacement_Projet_Button
        '
        resources.ApplyResources(Me.Emplacement_Projet_Button, "Emplacement_Projet_Button")
        Me.Emplacement_Projet_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Emplacement_Projet_Button.Name = "Emplacement_Projet_Button"
        Me.ToolTip1.SetToolTip(Me.Emplacement_Projet_Button, resources.GetString("Emplacement_Projet_Button.ToolTip"))
        Me.Emplacement_Projet_Button.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Name = "Label5"
        '
        'Nom_Societe_TextBox
        '
        resources.ApplyResources(Me.Nom_Societe_TextBox, "Nom_Societe_TextBox")
        Me.Nom_Societe_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Nom_Societe_TextBox.Name = "Nom_Societe_TextBox"
        Me.ToolTip1.SetToolTip(Me.Nom_Societe_TextBox, resources.GetString("Nom_Societe_TextBox.ToolTip"))
        '
        'Nom_Utilisateur_TextBox
        '
        resources.ApplyResources(Me.Nom_Utilisateur_TextBox, "Nom_Utilisateur_TextBox")
        Me.Nom_Utilisateur_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Nom_Utilisateur_TextBox.Name = "Nom_Utilisateur_TextBox"
        Me.ToolTip1.SetToolTip(Me.Nom_Utilisateur_TextBox, resources.GetString("Nom_Utilisateur_TextBox.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'Interfaces
        '
        Me.Interfaces.Controls.Add(Me.Pause_CheckBox1)
        Me.Interfaces.Controls.Add(Me.ComboBox1)
        Me.Interfaces.Controls.Add(Me.Label7)
        Me.Interfaces.Controls.Add(Me.Activer_Aero_CheckBox)
        Me.Interfaces.Controls.Add(Me.Barre_Acces_Rapide_En_Dessous_CheckBox)
        Me.Interfaces.Controls.Add(Me.Minimiser_Ruban_CheckBox)
        Me.Interfaces.Controls.Add(Me.Barre_Etat_CheckBox)
        Me.Interfaces.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Interfaces, "Interfaces")
        Me.Interfaces.Name = "Interfaces"
        Me.Interfaces.UseVisualStyleBackColor = True
        '
        'Pause_CheckBox1
        '
        resources.ApplyResources(Me.Pause_CheckBox1, "Pause_CheckBox1")
        Me.Pause_CheckBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Pause_CheckBox1.Name = "Pause_CheckBox1"
        Me.ToolTip1.SetToolTip(Me.Pause_CheckBox1, resources.GetString("Pause_CheckBox1.ToolTip"))
        Me.Pause_CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {resources.GetString("ComboBox1.Items"), resources.GetString("ComboBox1.Items1"), resources.GetString("ComboBox1.Items2")})
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Name = "Label7"
        '
        'Activer_Aero_CheckBox
        '
        resources.ApplyResources(Me.Activer_Aero_CheckBox, "Activer_Aero_CheckBox")
        Me.Activer_Aero_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Activer_Aero_CheckBox.Name = "Activer_Aero_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Activer_Aero_CheckBox, resources.GetString("Activer_Aero_CheckBox.ToolTip"))
        Me.Activer_Aero_CheckBox.UseVisualStyleBackColor = True
        '
        'Barre_Acces_Rapide_En_Dessous_CheckBox
        '
        resources.ApplyResources(Me.Barre_Acces_Rapide_En_Dessous_CheckBox, "Barre_Acces_Rapide_En_Dessous_CheckBox")
        Me.Barre_Acces_Rapide_En_Dessous_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Barre_Acces_Rapide_En_Dessous_CheckBox.Name = "Barre_Acces_Rapide_En_Dessous_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Barre_Acces_Rapide_En_Dessous_CheckBox, resources.GetString("Barre_Acces_Rapide_En_Dessous_CheckBox.ToolTip"))
        Me.Barre_Acces_Rapide_En_Dessous_CheckBox.UseVisualStyleBackColor = True
        '
        'Minimiser_Ruban_CheckBox
        '
        resources.ApplyResources(Me.Minimiser_Ruban_CheckBox, "Minimiser_Ruban_CheckBox")
        Me.Minimiser_Ruban_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Minimiser_Ruban_CheckBox.Name = "Minimiser_Ruban_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Minimiser_Ruban_CheckBox, resources.GetString("Minimiser_Ruban_CheckBox.ToolTip"))
        Me.Minimiser_Ruban_CheckBox.UseVisualStyleBackColor = True
        '
        'Barre_Etat_CheckBox
        '
        resources.ApplyResources(Me.Barre_Etat_CheckBox, "Barre_Etat_CheckBox")
        Me.Barre_Etat_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Barre_Etat_CheckBox.Name = "Barre_Etat_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Barre_Etat_CheckBox, resources.GetString("Barre_Etat_CheckBox.ToolTip"))
        Me.Barre_Etat_CheckBox.UseVisualStyleBackColor = True
        '
        'Language
        '
        Me.Language.Controls.Add(Me.Langue_ComboBox)
        Me.Language.Controls.Add(Me.Label2)
        Me.Language.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Language, "Language")
        Me.Language.Name = "Language"
        Me.Language.UseVisualStyleBackColor = True
        '
        'Langue_ComboBox
        '
        Me.Langue_ComboBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Langue_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Langue_ComboBox, "Langue_ComboBox")
        Me.Langue_ComboBox.FormattingEnabled = True
        Me.Langue_ComboBox.Items.AddRange(New Object() {resources.GetString("Langue_ComboBox.Items"), resources.GetString("Langue_ComboBox.Items1")})
        Me.Langue_ComboBox.Name = "Langue_ComboBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Starter
        '
        Me.Starter.Controls.Add(Me.Splash_Screen_CheckBox)
        Me.Starter.Controls.Add(Me.Updates_CheckBox)
        Me.Starter.Controls.Add(Me.Start_Page_CheckBox)
        Me.Starter.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Starter, "Starter")
        Me.Starter.Name = "Starter"
        Me.Starter.UseVisualStyleBackColor = True
        '
        'Splash_Screen_CheckBox
        '
        resources.ApplyResources(Me.Splash_Screen_CheckBox, "Splash_Screen_CheckBox")
        Me.Splash_Screen_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Splash_Screen_CheckBox.Name = "Splash_Screen_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Splash_Screen_CheckBox, resources.GetString("Splash_Screen_CheckBox.ToolTip"))
        Me.Splash_Screen_CheckBox.UseVisualStyleBackColor = True
        '
        'Updates_CheckBox
        '
        resources.ApplyResources(Me.Updates_CheckBox, "Updates_CheckBox")
        Me.Updates_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Updates_CheckBox.Name = "Updates_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Updates_CheckBox, resources.GetString("Updates_CheckBox.ToolTip"))
        Me.Updates_CheckBox.UseVisualStyleBackColor = True
        '
        'Start_Page_CheckBox
        '
        resources.ApplyResources(Me.Start_Page_CheckBox, "Start_Page_CheckBox")
        Me.Start_Page_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Start_Page_CheckBox.Name = "Start_Page_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Start_Page_CheckBox, resources.GetString("Start_Page_CheckBox.ToolTip"))
        Me.Start_Page_CheckBox.UseVisualStyleBackColor = True
        '
        'WindowsDesigner
        '
        Me.WindowsDesigner.Controls.Add(Me.Suivre_Souris_Regle_CheckBox)
        Me.WindowsDesigner.Controls.Add(Me.Panneaux_Lateral_WindowsDesigner_CheckBox)
        Me.WindowsDesigner.Controls.Add(Me.SmartTags_CheckBox)
        Me.WindowsDesigner.Controls.Add(Me.Aimentation_Intelligente_RadioButton)
        Me.WindowsDesigner.Controls.Add(Me.Afficher_Grille_RadioButton)
        Me.WindowsDesigner.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.WindowsDesigner, "WindowsDesigner")
        Me.WindowsDesigner.Name = "WindowsDesigner"
        Me.WindowsDesigner.UseVisualStyleBackColor = True
        '
        'Suivre_Souris_Regle_CheckBox
        '
        resources.ApplyResources(Me.Suivre_Souris_Regle_CheckBox, "Suivre_Souris_Regle_CheckBox")
        Me.Suivre_Souris_Regle_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Suivre_Souris_Regle_CheckBox.Name = "Suivre_Souris_Regle_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Suivre_Souris_Regle_CheckBox, resources.GetString("Suivre_Souris_Regle_CheckBox.ToolTip"))
        Me.Suivre_Souris_Regle_CheckBox.UseVisualStyleBackColor = True
        '
        'Panneaux_Lateral_WindowsDesigner_CheckBox
        '
        resources.ApplyResources(Me.Panneaux_Lateral_WindowsDesigner_CheckBox, "Panneaux_Lateral_WindowsDesigner_CheckBox")
        Me.Panneaux_Lateral_WindowsDesigner_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panneaux_Lateral_WindowsDesigner_CheckBox.Name = "Panneaux_Lateral_WindowsDesigner_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Panneaux_Lateral_WindowsDesigner_CheckBox, resources.GetString("Panneaux_Lateral_WindowsDesigner_CheckBox.ToolTip"))
        Me.Panneaux_Lateral_WindowsDesigner_CheckBox.UseVisualStyleBackColor = True
        '
        'SmartTags_CheckBox
        '
        resources.ApplyResources(Me.SmartTags_CheckBox, "SmartTags_CheckBox")
        Me.SmartTags_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.SmartTags_CheckBox.Name = "SmartTags_CheckBox"
        Me.ToolTip1.SetToolTip(Me.SmartTags_CheckBox, resources.GetString("SmartTags_CheckBox.ToolTip"))
        Me.SmartTags_CheckBox.UseVisualStyleBackColor = True
        '
        'Aimentation_Intelligente_RadioButton
        '
        resources.ApplyResources(Me.Aimentation_Intelligente_RadioButton, "Aimentation_Intelligente_RadioButton")
        Me.Aimentation_Intelligente_RadioButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.Aimentation_Intelligente_RadioButton.Name = "Aimentation_Intelligente_RadioButton"
        Me.Aimentation_Intelligente_RadioButton.TabStop = True
        Me.ToolTip1.SetToolTip(Me.Aimentation_Intelligente_RadioButton, resources.GetString("Aimentation_Intelligente_RadioButton.ToolTip"))
        Me.Aimentation_Intelligente_RadioButton.UseVisualStyleBackColor = True
        '
        'Afficher_Grille_RadioButton
        '
        resources.ApplyResources(Me.Afficher_Grille_RadioButton, "Afficher_Grille_RadioButton")
        Me.Afficher_Grille_RadioButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.Afficher_Grille_RadioButton.Name = "Afficher_Grille_RadioButton"
        Me.Afficher_Grille_RadioButton.TabStop = True
        Me.ToolTip1.SetToolTip(Me.Afficher_Grille_RadioButton, resources.GetString("Afficher_Grille_RadioButton.ToolTip"))
        Me.Afficher_Grille_RadioButton.UseVisualStyleBackColor = True
        '
        'Functions_Editor
        '
        Me.Functions_Editor.Controls.Add(Me.Correcteur_Orthographique_CheckBox)
        Me.Functions_Editor.Controls.Add(Me.Zoom_Bar_CheckBox)
        Me.Functions_Editor.Controls.Add(Me.Panneau_Lateral_FunctionEditor_CheckBox)
        Me.Functions_Editor.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Functions_Editor, "Functions_Editor")
        Me.Functions_Editor.Name = "Functions_Editor"
        Me.Functions_Editor.UseVisualStyleBackColor = True
        '
        'Correcteur_Orthographique_CheckBox
        '
        resources.ApplyResources(Me.Correcteur_Orthographique_CheckBox, "Correcteur_Orthographique_CheckBox")
        Me.Correcteur_Orthographique_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Correcteur_Orthographique_CheckBox.Name = "Correcteur_Orthographique_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Correcteur_Orthographique_CheckBox, resources.GetString("Correcteur_Orthographique_CheckBox.ToolTip"))
        Me.Correcteur_Orthographique_CheckBox.UseVisualStyleBackColor = True
        '
        'Zoom_Bar_CheckBox
        '
        resources.ApplyResources(Me.Zoom_Bar_CheckBox, "Zoom_Bar_CheckBox")
        Me.Zoom_Bar_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Zoom_Bar_CheckBox.Name = "Zoom_Bar_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Zoom_Bar_CheckBox, resources.GetString("Zoom_Bar_CheckBox.ToolTip"))
        Me.Zoom_Bar_CheckBox.UseVisualStyleBackColor = True
        '
        'Panneau_Lateral_FunctionEditor_CheckBox
        '
        resources.ApplyResources(Me.Panneau_Lateral_FunctionEditor_CheckBox, "Panneau_Lateral_FunctionEditor_CheckBox")
        Me.Panneau_Lateral_FunctionEditor_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panneau_Lateral_FunctionEditor_CheckBox.Name = "Panneau_Lateral_FunctionEditor_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Panneau_Lateral_FunctionEditor_CheckBox, resources.GetString("Panneau_Lateral_FunctionEditor_CheckBox.ToolTip"))
        Me.Panneau_Lateral_FunctionEditor_CheckBox.UseVisualStyleBackColor = True
        '
        'VBEditor
        '
        Me.VBEditor.Controls.Add(Me.Colorisation_Syntaxe_CheckBox)
        Me.VBEditor.Controls.Add(Me.Numerotation_Lignes_CheckBox)
        Me.VBEditor.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.VBEditor, "VBEditor")
        Me.VBEditor.Name = "VBEditor"
        Me.VBEditor.UseVisualStyleBackColor = True
        '
        'Colorisation_Syntaxe_CheckBox
        '
        resources.ApplyResources(Me.Colorisation_Syntaxe_CheckBox, "Colorisation_Syntaxe_CheckBox")
        Me.Colorisation_Syntaxe_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Colorisation_Syntaxe_CheckBox.Name = "Colorisation_Syntaxe_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Colorisation_Syntaxe_CheckBox, resources.GetString("Colorisation_Syntaxe_CheckBox.ToolTip"))
        Me.Colorisation_Syntaxe_CheckBox.UseVisualStyleBackColor = True
        '
        'Numerotation_Lignes_CheckBox
        '
        resources.ApplyResources(Me.Numerotation_Lignes_CheckBox, "Numerotation_Lignes_CheckBox")
        Me.Numerotation_Lignes_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Numerotation_Lignes_CheckBox.Name = "Numerotation_Lignes_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Numerotation_Lignes_CheckBox, resources.GetString("Numerotation_Lignes_CheckBox.ToolTip"))
        Me.Numerotation_Lignes_CheckBox.UseVisualStyleBackColor = True
        '
        'Voice_Recognition
        '
        Me.Voice_Recognition.Controls.Add(Me.Configure_Voice_Recognition_Button)
        Me.Voice_Recognition.Controls.Add(Me.Sounds_Voice_Recognition_CheckBox)
        Me.Voice_Recognition.Controls.Add(Me.Label6)
        Me.Voice_Recognition.Controls.Add(Me.Activate_Voice_Recognition_CheckBox)
        Me.Voice_Recognition.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Voice_Recognition, "Voice_Recognition")
        Me.Voice_Recognition.Name = "Voice_Recognition"
        Me.Voice_Recognition.UseVisualStyleBackColor = True
        '
        'Configure_Voice_Recognition_Button
        '
        resources.ApplyResources(Me.Configure_Voice_Recognition_Button, "Configure_Voice_Recognition_Button")
        Me.Configure_Voice_Recognition_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Configure_Voice_Recognition_Button.Name = "Configure_Voice_Recognition_Button"
        Me.Configure_Voice_Recognition_Button.UseVisualStyleBackColor = True
        '
        'Sounds_Voice_Recognition_CheckBox
        '
        resources.ApplyResources(Me.Sounds_Voice_Recognition_CheckBox, "Sounds_Voice_Recognition_CheckBox")
        Me.Sounds_Voice_Recognition_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Sounds_Voice_Recognition_CheckBox.Name = "Sounds_Voice_Recognition_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Sounds_Voice_Recognition_CheckBox, resources.GetString("Sounds_Voice_Recognition_CheckBox.ToolTip"))
        Me.Sounds_Voice_Recognition_CheckBox.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Activate_Voice_Recognition_CheckBox
        '
        resources.ApplyResources(Me.Activate_Voice_Recognition_CheckBox, "Activate_Voice_Recognition_CheckBox")
        Me.Activate_Voice_Recognition_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Activate_Voice_Recognition_CheckBox.Name = "Activate_Voice_Recognition_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Activate_Voice_Recognition_CheckBox, resources.GetString("Activate_Voice_Recognition_CheckBox.ToolTip"))
        Me.Activate_Voice_Recognition_CheckBox.UseVisualStyleBackColor = True
        '
        'Confidentiality
        '
        Me.Confidentiality.Controls.Add(Me.LinkLabel1)
        Me.Confidentiality.Controls.Add(Me.GroupBox1)
        Me.Confidentiality.Controls.Add(Me.Envoyer_Confidentiality_CheckBox)
        resources.ApplyResources(Me.Confidentiality, "Confidentiality")
        Me.Confidentiality.Name = "Confidentiality"
        Me.Confidentiality.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Erreurs_Generations_Confidentiality_CheckBox)
        Me.GroupBox1.Controls.Add(Me.Vocale_Confidentiality_CheckBox)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Erreurs_Generations_Confidentiality_CheckBox
        '
        resources.ApplyResources(Me.Erreurs_Generations_Confidentiality_CheckBox, "Erreurs_Generations_Confidentiality_CheckBox")
        Me.Erreurs_Generations_Confidentiality_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Erreurs_Generations_Confidentiality_CheckBox.Name = "Erreurs_Generations_Confidentiality_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Erreurs_Generations_Confidentiality_CheckBox, resources.GetString("Erreurs_Generations_Confidentiality_CheckBox.ToolTip"))
        Me.Erreurs_Generations_Confidentiality_CheckBox.UseVisualStyleBackColor = True
        '
        'Vocale_Confidentiality_CheckBox
        '
        resources.ApplyResources(Me.Vocale_Confidentiality_CheckBox, "Vocale_Confidentiality_CheckBox")
        Me.Vocale_Confidentiality_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Vocale_Confidentiality_CheckBox.Name = "Vocale_Confidentiality_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Vocale_Confidentiality_CheckBox, resources.GetString("Vocale_Confidentiality_CheckBox.ToolTip"))
        Me.Vocale_Confidentiality_CheckBox.UseVisualStyleBackColor = True
        '
        'Envoyer_Confidentiality_CheckBox
        '
        resources.ApplyResources(Me.Envoyer_Confidentiality_CheckBox, "Envoyer_Confidentiality_CheckBox")
        Me.Envoyer_Confidentiality_CheckBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.Envoyer_Confidentiality_CheckBox.Name = "Envoyer_Confidentiality_CheckBox"
        Me.ToolTip1.SetToolTip(Me.Envoyer_Confidentiality_CheckBox, resources.GetString("Envoyer_Confidentiality_CheckBox.ToolTip"))
        Me.Envoyer_Confidentiality_CheckBox.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Options
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.HelpButton = True
        Me.Name = "Options"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.WizardTabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        Me.Interfaces.ResumeLayout(False)
        Me.Language.ResumeLayout(False)
        Me.Starter.ResumeLayout(False)
        Me.WindowsDesigner.ResumeLayout(False)
        Me.Functions_Editor.ResumeLayout(False)
        Me.VBEditor.ResumeLayout(False)
        Me.Voice_Recognition.ResumeLayout(False)
        Me.Confidentiality.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents WizardTabControl1 As VelerSoftware.SZVB.WizardTabControl
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents Interfaces As System.Windows.Forms.TabPage
    Friend WithEvents Language As System.Windows.Forms.TabPage
    Friend WithEvents Starter As System.Windows.Forms.TabPage
    Friend WithEvents WindowsDesigner As System.Windows.Forms.TabPage
    Friend WithEvents Functions_Editor As System.Windows.Forms.TabPage
    Friend WithEvents VBEditor As System.Windows.Forms.TabPage
    Friend WithEvents Panneaux_Lateral_WindowsDesigner_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SmartTags_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Aimentation_Intelligente_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Afficher_Grille_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Panneau_Lateral_FunctionEditor_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Langue_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Start_Page_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Updates_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Nom_Societe_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Nom_Utilisateur_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Emplacement_Projet_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents Emplacement_Projet_Button As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Barre_Acces_Rapide_En_Dessous_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Minimiser_Ruban_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Barre_Etat_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Voice_Recognition As System.Windows.Forms.TabPage
    Friend WithEvents Activate_Voice_Recognition_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Numerotation_Lignes_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Colorisation_Syntaxe_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Activer_Aero_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Fichiers_Extension_Button As System.Windows.Forms.Button
    Friend WithEvents Suivre_Souris_Regle_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Sounds_Voice_Recognition_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Configure_Voice_Recognition_Button As System.Windows.Forms.Button
    Friend WithEvents Confidentiality As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Erreurs_Generations_Confidentiality_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Vocale_Confidentiality_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Envoyer_Confidentiality_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Zoom_Bar_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Correcteur_Orthographique_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Splash_Screen_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Pause_CheckBox1 As System.Windows.Forms.CheckBox

End Class
