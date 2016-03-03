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
Partial Class ExporterVisualStudio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExporterVisualStudio))
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.ExporterVisualStudioComposant1 = New Global.SoftwareZator.ExporterVisualStudioComposant(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = DirectCast(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Projet_Windows7ProgressBar = New VelerSoftware.SZC.ProgressBar.Windows7ProgressBar()
        Me.Solution_Windows7ProgressBar = New VelerSoftware.SZC.ProgressBar.Windows7ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.WizardTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.LabelTitle)
        Me.TabPage1.Controls.Add(Me.ExporterVisualStudioComposant1)
        Me.TabPage1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.SoftwareZator.My.Resources.Resources.Visual_Studio_2010_Logo
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, resources.GetString("PictureBox1.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'LabelTitle
        '
        resources.ApplyResources(Me.LabelTitle, "LabelTitle")
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelTitle.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelTitle.Name = "LabelTitle"
        '
        'ExporterVisualStudioComposant1
        '
        Me.ExporterVisualStudioComposant1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExporterVisualStudioComposant1.Emplacement_Choisit = Nothing
        resources.ApplyResources(Me.ExporterVisualStudioComposant1, "ExporterVisualStudioComposant1")
        Me.ExporterVisualStudioComposant1.Name = "ExporterVisualStudioComposant1"
        Me.ExporterVisualStudioComposant1.Projet_A_Exporter = Nothing
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ListView2
        '
        Me.ListView2.CheckBoxes = True
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ListView2, "ListView2")
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.MinimumSize = New System.Drawing.Size(4, 50)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
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
        Me.TabPage3.Controls.Add(Me.Projet_Windows7ProgressBar)
        Me.TabPage3.Controls.Add(Me.Solution_Windows7ProgressBar)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Projet_Windows7ProgressBar
        '
        Me.Projet_Windows7ProgressBar.ContainerControl = Me
        Me.Projet_Windows7ProgressBar.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Projet_Windows7ProgressBar, "Projet_Windows7ProgressBar")
        Me.Projet_Windows7ProgressBar.Name = "Projet_Windows7ProgressBar"
        '
        'Solution_Windows7ProgressBar
        '
        Me.Solution_Windows7ProgressBar.ContainerControl = Me
        Me.Solution_Windows7ProgressBar.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Solution_Windows7ProgressBar, "Solution_Windows7ProgressBar")
        Me.Solution_Windows7ProgressBar.Name = "Solution_Windows7ProgressBar"
        Me.Solution_Windows7ProgressBar.ShowInTaskbar = True
        Me.Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.[Error]
        Me.Solution_Windows7ProgressBar.Value = 75
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.CheckBox1)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage4, "TabPage4")
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Name = "Label8"
        '
        'ExporterVisualStudio
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackCaption = "Précédent"
        Me.CancelButtonText = "Annuler"
        Me.Caption = "Exporter vers Microsoft® Visual Studio"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FinishButtonText = "Terminer"
        Me.HelpButton = True
        Me.Name = "ExporterVisualStudio"
        Me.NextButtonText = "Suivant"
        Me.WizardIcon = Global.SoftwareZator.My.Resources.Resources.Exporter_VS_Small
        Me.WizardTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Projet_Windows7ProgressBar As VelerSoftware.SZC.ProgressBar.Windows7ProgressBar
    Friend WithEvents Solution_Windows7ProgressBar As VelerSoftware.SZC.ProgressBar.Windows7ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ExporterVisualStudioComposant1 As Global.SoftwareZator.ExporterVisualStudioComposant
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
