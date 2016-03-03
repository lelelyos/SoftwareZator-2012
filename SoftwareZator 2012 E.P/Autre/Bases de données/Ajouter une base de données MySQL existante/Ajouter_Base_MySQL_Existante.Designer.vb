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
Partial Class AjouterBaseMySQLExistante
    Inherits VelerSoftware.SZVB.AeroWizardForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjouterBaseMySQLExistante))
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Console_CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.Windows_CommandLink = New VelerSoftware.SZVB.CommandLink()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Port_KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Adresse_KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Mot_De_Passe_KryptonTextBox3 = New VelerSoftware.Design.Toolkit.KryptonMaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Utilisateur_KryptonTextBox2 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Nom_KryptonTextBox4 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WizardTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'WizardTabControl1
        '
        Me.WizardTabControl1.Controls.Add(Me.TabPage1)
        Me.WizardTabControl1.Controls.Add(Me.TabPage2)
        Me.WizardTabControl1.Controls.Add(Me.TabPage3)
        Me.WizardTabControl1.Controls.Add(Me.TabPage4)
        resources.ApplyResources(Me.WizardTabControl1, "WizardTabControl1")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Console_CommandLink1)
        Me.TabPage1.Controls.Add(Me.Windows_CommandLink)
        Me.TabPage1.Controls.Add(Me.LabelTitle)
        Me.TabPage1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Console_CommandLink1
        '
        Me.Console_CommandLink1.AutoEllipsis = True
        Me.Console_CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        resources.ApplyResources(Me.Console_CommandLink1, "Console_CommandLink1")
        Me.Console_CommandLink1.Name = "Console_CommandLink1"
        Me.Console_CommandLink1.Tag = "Console"
        Me.ToolTip1.SetToolTip(Me.Console_CommandLink1, resources.GetString("Console_CommandLink1.ToolTip"))
        '
        'Windows_CommandLink
        '
        Me.Windows_CommandLink.AutoEllipsis = True
        Me.Windows_CommandLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        resources.ApplyResources(Me.Windows_CommandLink, "Windows_CommandLink")
        Me.Windows_CommandLink.Name = "Windows_CommandLink"
        Me.Windows_CommandLink.Tag = "Window"
        Me.ToolTip1.SetToolTip(Me.Windows_CommandLink, resources.GetString("Windows_CommandLink.ToolTip"))
        '
        'LabelTitle
        '
        resources.ApplyResources(Me.LabelTitle, "LabelTitle")
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelTitle.Name = "LabelTitle"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = DirectCast(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "down")
        Me.ImageList2.Images.SetKeyName(1, "up")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Port_KryptonTextBox1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Adresse_KryptonTextBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'Port_KryptonTextBox1
        '
        resources.ApplyResources(Me.Port_KryptonTextBox1, "Port_KryptonTextBox1")
        Me.Port_KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Port_KryptonTextBox1.Name = "Port_KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.Port_KryptonTextBox1, resources.GetString("Port_KryptonTextBox1.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'Adresse_KryptonTextBox1
        '
        resources.ApplyResources(Me.Adresse_KryptonTextBox1, "Adresse_KryptonTextBox1")
        Me.Adresse_KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Adresse_KryptonTextBox1.Name = "Adresse_KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.Adresse_KryptonTextBox1, resources.GetString("Adresse_KryptonTextBox1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Mot_De_Passe_KryptonTextBox3)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Utilisateur_KryptonTextBox2)
        Me.TabPage3.Controls.Add(Me.Label6)
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Name = "Label5"
        '
        'Mot_De_Passe_KryptonTextBox3
        '
        resources.ApplyResources(Me.Mot_De_Passe_KryptonTextBox3, "Mot_De_Passe_KryptonTextBox3")
        Me.Mot_De_Passe_KryptonTextBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Mot_De_Passe_KryptonTextBox3.Name = "Mot_De_Passe_KryptonTextBox3"
        Me.ToolTip1.SetToolTip(Me.Mot_De_Passe_KryptonTextBox3, resources.GetString("Mot_De_Passe_KryptonTextBox3.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Name = "Label4"
        '
        'Utilisateur_KryptonTextBox2
        '
        resources.ApplyResources(Me.Utilisateur_KryptonTextBox2, "Utilisateur_KryptonTextBox2")
        Me.Utilisateur_KryptonTextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Utilisateur_KryptonTextBox2.Name = "Utilisateur_KryptonTextBox2"
        Me.ToolTip1.SetToolTip(Me.Utilisateur_KryptonTextBox2, resources.GetString("Utilisateur_KryptonTextBox2.ToolTip"))
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Name = "Label6"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.Nom_KryptonTextBox4)
        Me.TabPage4.Controls.Add(Me.Label7)
        resources.ApplyResources(Me.TabPage4, "TabPage4")
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Name = "Label8"
        '
        'Nom_KryptonTextBox4
        '
        resources.ApplyResources(Me.Nom_KryptonTextBox4, "Nom_KryptonTextBox4")
        Me.Nom_KryptonTextBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Nom_KryptonTextBox4.Name = "Nom_KryptonTextBox4"
        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox4, resources.GetString("Nom_KryptonTextBox4.ToolTip"))
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Name = "Label7"
        '
        'AjouterBaseMySQLExistante
        '
        resources.ApplyResources(Me, "$this")
        Me.BackCaption = "Précédent"
        Me.CancelButtonText = "Annuler"
        Me.Caption = "Créer une nouvelle base de données Oracle MySQL"
        Me.FinishButtonText = "Terminer"
        Me.HelpButton = True
        Me.Name = "AjouterBaseMySQLExistante"
        Me.NextButtonText = "Suivant"
        Me.WizardIcon = Global.SoftwareZator.My.Resources.Resources.database_mysql
        Me.WizardTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Windows_CommandLink As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Console_CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Adresse_KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Port_KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Mot_De_Passe_KryptonTextBox3 As VelerSoftware.Design.Toolkit.KryptonMaskedTextBox
    Friend WithEvents Utilisateur_KryptonTextBox2 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Nom_KryptonTextBox4 As VelerSoftware.Design.Toolkit.KryptonTextBox

End Class
