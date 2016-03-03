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
Partial Class NouveauProjet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NouveauProjet))
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Installateur_CommandLink3 = New VelerSoftware.SZVB.CommandLink()
        Me.DLL_CommandLink2 = New VelerSoftware.SZVB.CommandLink()
        Me.Console_CommandLink1 = New VelerSoftware.SZVB.CommandLink()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Windows_CommandLink = New VelerSoftware.SZVB.CommandLink()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Nom_Solution_KryptonTextBox3 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Emplacement_KryptonTextBox2 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Nom_Projet_KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.WizardTabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'WizardTabControl1
        '
        Me.WizardTabControl1.Controls.Add(Me.TabPage2)
        Me.WizardTabControl1.Controls.Add(Me.TabPage3)
        Me.WizardTabControl1.Controls.Add(Me.TabPage5)
        resources.ApplyResources(Me.WizardTabControl1, "WizardTabControl1")
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Installateur_CommandLink3)
        Me.TabPage2.Controls.Add(Me.DLL_CommandLink2)
        Me.TabPage2.Controls.Add(Me.Console_CommandLink1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Windows_CommandLink)
        Me.TabPage2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Installateur_CommandLink3
        '
        Me.Installateur_CommandLink3.AutoEllipsis = True
        Me.Installateur_CommandLink3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Installateur_CommandLink3, "Installateur_CommandLink3")
        Me.Installateur_CommandLink3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Installateur_CommandLink3.Name = "Installateur_CommandLink3"
        Me.Installateur_CommandLink3.ShowElevationIcon = True
        Me.Installateur_CommandLink3.Tag = "Install"
        Me.ToolTip1.SetToolTip(Me.Installateur_CommandLink3, resources.GetString("Installateur_CommandLink3.ToolTip"))
        '
        'DLL_CommandLink2
        '
        Me.DLL_CommandLink2.AutoEllipsis = True
        Me.DLL_CommandLink2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.DLL_CommandLink2, "DLL_CommandLink2")
        Me.DLL_CommandLink2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.DLL_CommandLink2.Name = "DLL_CommandLink2"
        Me.DLL_CommandLink2.Tag = "DLL"
        Me.ToolTip1.SetToolTip(Me.DLL_CommandLink2, resources.GetString("DLL_CommandLink2.ToolTip"))
        '
        'Console_CommandLink1
        '
        Me.Console_CommandLink1.AutoEllipsis = True
        Me.Console_CommandLink1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Console_CommandLink1, "Console_CommandLink1")
        Me.Console_CommandLink1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Console_CommandLink1.Name = "Console_CommandLink1"
        Me.Console_CommandLink1.Tag = "Console"
        Me.ToolTip1.SetToolTip(Me.Console_CommandLink1, resources.GetString("Console_CommandLink1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'Windows_CommandLink
        '
        Me.Windows_CommandLink.AutoEllipsis = True
        Me.Windows_CommandLink.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Windows_CommandLink, "Windows_CommandLink")
        Me.Windows_CommandLink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Windows_CommandLink.Name = "Windows_CommandLink"
        Me.Windows_CommandLink.Tag = "Window"
        Me.ToolTip1.SetToolTip(Me.Windows_CommandLink, resources.GetString("Windows_CommandLink.ToolTip"))
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TextBox1)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label2)
        Me.TabPage3.Controls.Add(Me.ListView1)
        Me.TabPage3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Name = "Label2"
        '
        'ListView1
        '
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.LargeImageList = Me.ImageList2
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImageList2, "ImageList2")
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.RadioButton2)
        Me.TabPage5.Controls.Add(Me.RadioButton1)
        Me.TabPage5.Controls.Add(Me.Nom_Solution_KryptonTextBox3)
        Me.TabPage5.Controls.Add(Me.Label5)
        Me.TabPage5.Controls.Add(Me.Button1)
        Me.TabPage5.Controls.Add(Me.Emplacement_KryptonTextBox2)
        Me.TabPage5.Controls.Add(Me.Label4)
        Me.TabPage5.Controls.Add(Me.Nom_Projet_KryptonTextBox1)
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.Label14)
        Me.TabPage5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage5, "TabPage5")
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Nom_Solution_KryptonTextBox3
        '
        Me.Nom_Solution_KryptonTextBox3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Nom_Solution_KryptonTextBox3, "Nom_Solution_KryptonTextBox3")
        Me.Nom_Solution_KryptonTextBox3.Name = "Nom_Solution_KryptonTextBox3"
        Me.ToolTip1.SetToolTip(Me.Nom_Solution_KryptonTextBox3, resources.GetString("Nom_Solution_KryptonTextBox3.ToolTip"))
        '
        'Label5
        '
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Emplacement_KryptonTextBox2
        '
        Me.Emplacement_KryptonTextBox2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Emplacement_KryptonTextBox2, "Emplacement_KryptonTextBox2")
        Me.Emplacement_KryptonTextBox2.Name = "Emplacement_KryptonTextBox2"
        Me.Emplacement_KryptonTextBox2.ReadOnly = True
        Me.ToolTip1.SetToolTip(Me.Emplacement_KryptonTextBox2, resources.GetString("Emplacement_KryptonTextBox2.ToolTip"))
        '
        'Label4
        '
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Nom_Projet_KryptonTextBox1
        '
        Me.Nom_Projet_KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Nom_Projet_KryptonTextBox1, "Nom_Projet_KryptonTextBox1")
        Me.Nom_Projet_KryptonTextBox1.Name = "Nom_Projet_KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.Nom_Projet_KryptonTextBox1, resources.GetString("Nom_Projet_KryptonTextBox1.ToolTip"))
        '
        'Label15
        '
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.Name = "Label14"
        '
        'NouveauProjet
        '
        Me.BackCaption = "Précédent"
        Me.CancelButtonText = "Annuler"
        Me.Caption = "New document"
        resources.ApplyResources(Me, "$this")
        Me.FinishButtonText = "Terminer"
        Me.HelpButton = True
        Me.Name = "NouveauProjet"
        Me.NextButtonText = "Suivant"
        Me.WizardIcon = Global.SoftwareZator.My.Resources.Resources.Nouveau_Projet_16x16
        Me.WizardTabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Windows_CommandLink As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Console_CommandLink1 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents DLL_CommandLink2 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Nom_Projet_KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Installateur_CommandLink3 As VelerSoftware.SZVB.CommandLink
    Friend WithEvents Emplacement_KryptonTextBox2 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Nom_Solution_KryptonTextBox3 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog

End Class
