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
Partial Class GenerationComponent
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerationComponent))
        Me.KryptonGroupBox1 = New VelerSoftware.Design.Toolkit.KryptonGroupBox()
        Me.Projet_KryptonWrapLabel = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.Progression_KryptonWrapLabel = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.Projet_Windows7ProgressBar = New VelerSoftware.SZC.ProgressBar.Windows7ProgressBar()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.KryptonWrapLabel2 = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.KryptonWrapLabel1 = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.Solution_Windows7ProgressBar = New VelerSoftware.SZC.ProgressBar.Windows7ProgressBar()
        Me.BackgroundWorker_Building = New System.ComponentModel.BackgroundWorker()
        Me.KryptonPanel1 = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker_Obfuscation = New System.ComponentModel.BackgroundWorker()
        DirectCast(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonGroupBox1.Panel.SuspendLayout()
        Me.KryptonGroupBox1.SuspendLayout()
        DirectCast(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonGroupBox1
        '
        resources.ApplyResources(Me.KryptonGroupBox1, "KryptonGroupBox1")
        Me.KryptonGroupBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonGroupBox1.GroupBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlToolTip
        Me.KryptonGroupBox1.Name = "KryptonGroupBox1"
        '
        'KryptonGroupBox1.Panel
        '
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Projet_KryptonWrapLabel)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Progression_KryptonWrapLabel)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Projet_Windows7ProgressBar)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonButton1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonWrapLabel2)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonGroupBox1.Panel.Controls.Add(Me.Solution_Windows7ProgressBar)
        Me.KryptonGroupBox1.Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonGroupBox1.Panel, "KryptonGroupBox1.Panel")
        Me.KryptonGroupBox1.Values.Heading = resources.GetString("KryptonGroupBox1.Values.Heading")
        '
        'Projet_KryptonWrapLabel
        '
        resources.ApplyResources(Me.Projet_KryptonWrapLabel, "Projet_KryptonWrapLabel")
        Me.Projet_KryptonWrapLabel.AutoEllipsis = True
        Me.Projet_KryptonWrapLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Projet_KryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Projet_KryptonWrapLabel.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.Projet_KryptonWrapLabel.Name = "Projet_KryptonWrapLabel"
        Me.Projet_KryptonWrapLabel.UseCompatibleTextRendering = True
        '
        'Progression_KryptonWrapLabel
        '
        resources.ApplyResources(Me.Progression_KryptonWrapLabel, "Progression_KryptonWrapLabel")
        Me.Progression_KryptonWrapLabel.AutoEllipsis = True
        Me.Progression_KryptonWrapLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Progression_KryptonWrapLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Progression_KryptonWrapLabel.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.Progression_KryptonWrapLabel.Name = "Progression_KryptonWrapLabel"
        Me.Progression_KryptonWrapLabel.UseCompatibleTextRendering = True
        '
        'Projet_Windows7ProgressBar
        '
        resources.ApplyResources(Me.Projet_Windows7ProgressBar, "Projet_Windows7ProgressBar")
        Me.Projet_Windows7ProgressBar.ContainerControl = Me
        Me.Projet_Windows7ProgressBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Projet_Windows7ProgressBar.Name = "Projet_Windows7ProgressBar"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'KryptonWrapLabel2
        '
        resources.ApplyResources(Me.KryptonWrapLabel2, "KryptonWrapLabel2")
        Me.KryptonWrapLabel2.AutoEllipsis = True
        Me.KryptonWrapLabel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonWrapLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonWrapLabel2.Name = "KryptonWrapLabel2"
        Me.KryptonWrapLabel2.UseCompatibleTextRendering = True
        '
        'KryptonWrapLabel1
        '
        resources.ApplyResources(Me.KryptonWrapLabel1, "KryptonWrapLabel1")
        Me.KryptonWrapLabel1.AutoEllipsis = True
        Me.KryptonWrapLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.KryptonWrapLabel1.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        Me.KryptonWrapLabel1.UseCompatibleTextRendering = True
        '
        'Solution_Windows7ProgressBar
        '
        resources.ApplyResources(Me.Solution_Windows7ProgressBar, "Solution_Windows7ProgressBar")
        Me.Solution_Windows7ProgressBar.ContainerControl = Me
        Me.Solution_Windows7ProgressBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Solution_Windows7ProgressBar.Name = "Solution_Windows7ProgressBar"
        Me.Solution_Windows7ProgressBar.ShowInTaskbar = True
        Me.Solution_Windows7ProgressBar.State = VelerSoftware.SZC.ProgressBar.ProgressBarState.[Error]
        Me.Solution_Windows7ProgressBar.Value = 75
        '
        'BackgroundWorker_Building
        '
        Me.BackgroundWorker_Building.WorkerReportsProgress = True
        Me.BackgroundWorker_Building.WorkerSupportsCancellation = True
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonGroupBox1)
        Me.KryptonPanel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonPanel1, "KryptonPanel1")
        Me.KryptonPanel1.Name = "KryptonPanel1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'BackgroundWorker_Obfuscation
        '
        Me.BackgroundWorker_Obfuscation.WorkerReportsProgress = True
        Me.BackgroundWorker_Obfuscation.WorkerSupportsCancellation = True
        '
        'GenerationComponent
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Name = "GenerationComponent"
        Me.KryptonGroupBox1.Panel.ResumeLayout(False)
        DirectCast(Me.KryptonGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonGroupBox1.ResumeLayout(False)
        DirectCast(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker_Building As System.ComponentModel.BackgroundWorker
    Friend WithEvents Solution_Windows7ProgressBar As VelerSoftware.SZC.ProgressBar.Windows7ProgressBar
    Friend WithEvents KryptonPanel1 As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents KryptonGroupBox1 As VelerSoftware.Design.Toolkit.KryptonGroupBox
    Friend WithEvents KryptonWrapLabel1 As VelerSoftware.Design.Toolkit.KryptonWrapLabel
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents KryptonWrapLabel2 As VelerSoftware.Design.Toolkit.KryptonWrapLabel
    Friend WithEvents Projet_KryptonWrapLabel As VelerSoftware.Design.Toolkit.KryptonWrapLabel
    Friend WithEvents Progression_KryptonWrapLabel As VelerSoftware.Design.Toolkit.KryptonWrapLabel
    Friend WithEvents Projet_Windows7ProgressBar As VelerSoftware.SZC.ProgressBar.Windows7ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker_Obfuscation As System.ComponentModel.BackgroundWorker

End Class
