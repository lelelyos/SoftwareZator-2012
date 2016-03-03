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
Partial Class DocStatistiques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocStatistiques))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 12.0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.0R, 15.0R)
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.KryptonSplitContainer1 = New VelerSoftware.Design.Toolkit.KryptonSplitContainer()
        Me.Ressource_KryptonTextBox = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.KryptonWrapLabel1 = New VelerSoftware.Design.Toolkit.KryptonWrapLabel()
        Me.ButtonSpecAny1 = New VelerSoftware.Design.Toolkit.ButtonSpecAny()
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel23 = New System.Windows.Forms.TableLayoutPanel()
        Me.ObfuscationLevel_KryptonLabel = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.Variables_ListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KryptonLabel2 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.Resx_ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonLabel48 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.Settings_ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KryptonLabel47 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.References_ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KryptonLabel45 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel22 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonLabel46 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel21 = New System.Windows.Forms.TableLayoutPanel()
        Me.CPU_KryptonLabel43 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel44 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel20 = New System.Windows.Forms.TableLayoutPanel()
        Me.Optimiser_KryptonLabel41 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel42 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel19 = New System.Windows.Forms.TableLayoutPanel()
        Me.Dossier_Generation_KryptonLabel39 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel40 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel38 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel18 = New System.Windows.Forms.TableLayoutPanel()
        Me.Marque_KryptonLabel36 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel37 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.Version_Assembly_KryptonLabel34 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel35 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.Version_Fichier_KryptonLabel32 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel33 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.Copyright_KryptonLabel30 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel31 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.Produit_KryptonLabel28 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel29 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Societe_KryptonLabel26 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel27 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.Description_KryptonLabel24 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel25 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.Titre_KryptonLabel22 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel23 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel19 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel21 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonLabel20 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.Mode_Arrête_KryptonLabel17 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel18 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Enregistrer_Settings_KryptonLabel15 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel16 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Instance_KryptonLabel13 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel14 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Style_Visual_KryptonLabel11 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Ecran_Demarrage_KryptonLabel9 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Fenêtre_Demarrage_KryptonLabel6 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Type_KryptonLabel3 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.Composition_Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Generation_Succes_Echecs_Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Reinitialiser_KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Nom_KryptonLabel = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonLabel7 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.VB_ListView4 = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.KryptonButton5 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.KryptonLabel4 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel23.SuspendLayout()
        Me.TableLayoutPanel22.SuspendLayout()
        Me.TableLayoutPanel21.SuspendLayout()
        Me.TableLayoutPanel20.SuspendLayout()
        Me.TableLayoutPanel19.SuspendLayout()
        Me.TableLayoutPanel18.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        Me.TableLayoutPanel16.SuspendLayout()
        Me.TableLayoutPanel15.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Composition_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Generation_Succes_Echecs_Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonSplitContainer1
        '
        resources.ApplyResources(Me.KryptonSplitContainer1, "KryptonSplitContainer1")
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1.Panel1, "KryptonSplitContainer1.Panel1")
        Me.KryptonSplitContainer1.Panel1.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.Ressource_KryptonTextBox)
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonWrapLabel1)
        Me.KryptonSplitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonSplitContainer1.Panel2, "KryptonSplitContainer1.Panel2")
        Me.KryptonSplitContainer1.Panel2.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'Ressource_KryptonTextBox
        '
        Me.Ressource_KryptonTextBox.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Ressource_KryptonTextBox, "Ressource_KryptonTextBox")
        Me.Ressource_KryptonTextBox.Name = "Ressource_KryptonTextBox"
        '
        'KryptonWrapLabel1
        '
        Me.KryptonWrapLabel1.AutoEllipsis = True
        resources.ApplyResources(Me.KryptonWrapLabel1, "KryptonWrapLabel1")
        Me.KryptonWrapLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.KryptonWrapLabel1.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.KryptonWrapLabel1.Name = "KryptonWrapLabel1"
        '
        'ButtonSpecAny1
        '
        Me.ButtonSpecAny1.Image = Global.SoftwareZator.My.Resources.Resources.save_Small
        Me.ButtonSpecAny1.ToolTipImage = Global.SoftwareZator.My.Resources.Resources.save_Small
        Me.ButtonSpecAny1.UniqueName = "8BA4A6ED5DCD4AAD34B779C2FA72F7AA"
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonPanel.Name = "kryptonPanel"
        Me.kryptonPanel.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel23, 0, 23)
        Me.TableLayoutPanel1.Controls.Add(Me.Variables_ListView, 0, 33)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel2, 0, 32)
        Me.TableLayoutPanel1.Controls.Add(Me.Resx_ListView3, 0, 31)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel48, 0, 30)
        Me.TableLayoutPanel1.Controls.Add(Me.Settings_ListView2, 0, 29)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel47, 0, 28)
        Me.TableLayoutPanel1.Controls.Add(Me.References_ListView1, 0, 27)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel45, 0, 26)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel22, 0, 24)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel21, 0, 22)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel20, 0, 21)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel19, 0, 20)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel38, 0, 19)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel18, 0, 18)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel17, 0, 17)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel16, 0, 16)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel15, 0, 15)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel14, 0, 14)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel13, 0, 13)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel12, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel11, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel19, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel21, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Composition_Chart, 0, 34)
        Me.TableLayoutPanel1.Controls.Add(Me.Generation_Succes_Echecs_Chart, 0, 35)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 36)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.VB_ListView4, 0, 25)
        Me.TableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'TableLayoutPanel23
        '
        resources.ApplyResources(Me.TableLayoutPanel23, "TableLayoutPanel23")
        Me.TableLayoutPanel23.Controls.Add(Me.ObfuscationLevel_KryptonLabel, 0, 0)
        Me.TableLayoutPanel23.Controls.Add(Me.KryptonLabel6, 0, 0)
        Me.TableLayoutPanel23.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel23.Name = "TableLayoutPanel23"
        '
        'ObfuscationLevel_KryptonLabel
        '
        Me.ObfuscationLevel_KryptonLabel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ObfuscationLevel_KryptonLabel, "ObfuscationLevel_KryptonLabel")
        Me.ObfuscationLevel_KryptonLabel.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.ObfuscationLevel_KryptonLabel.Name = "ObfuscationLevel_KryptonLabel"
        Me.ObfuscationLevel_KryptonLabel.Values.Text = resources.GetString("ObfuscationLevel_KryptonLabel.Values.Text")
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel6, "KryptonLabel6")
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Values.Text = resources.GetString("KryptonLabel6.Values.Text")
        '
        'Variables_ListView
        '
        Me.Variables_ListView.AllowColumnReorder = True
        Me.Variables_ListView.AllowDrop = True
        Me.Variables_ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.Variables_ListView.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Variables_ListView, "Variables_ListView")
        Me.Variables_ListView.FullRowSelect = True
        Me.Variables_ListView.GridLines = True
        Me.Variables_ListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("Variables_ListView.Groups"), System.Windows.Forms.ListViewGroup)})
        Me.Variables_ListView.Name = "Variables_ListView"
        Me.Variables_ListView.ShowItemToolTips = True
        Me.Variables_ListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Variables_ListView.UseCompatibleStateImageBehavior = False
        Me.Variables_ListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        resources.ApplyResources(Me.ColumnHeader8, "ColumnHeader8")
        '
        'ColumnHeader9
        '
        resources.ApplyResources(Me.ColumnHeader9, "ColumnHeader9")
        '
        'ColumnHeader10
        '
        resources.ApplyResources(Me.ColumnHeader10, "ColumnHeader10")
        '
        'ColumnHeader11
        '
        resources.ApplyResources(Me.ColumnHeader11, "ColumnHeader11")
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel2, "KryptonLabel2")
        Me.KryptonLabel2.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Values.Text = resources.GetString("KryptonLabel2.Values.Text")
        '
        'Resx_ListView3
        '
        Me.Resx_ListView3.AllowColumnReorder = True
        Me.Resx_ListView3.AllowDrop = True
        Me.Resx_ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6})
        Me.Resx_ListView3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Resx_ListView3, "Resx_ListView3")
        Me.Resx_ListView3.FullRowSelect = True
        Me.Resx_ListView3.GridLines = True
        Me.Resx_ListView3.Name = "Resx_ListView3"
        Me.Resx_ListView3.ShowItemToolTips = True
        Me.Resx_ListView3.SmallImageList = Me.ImageList2
        Me.Resx_ListView3.UseCompatibleStateImageBehavior = False
        Me.Resx_ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "down")
        Me.ImageList2.Images.SetKeyName(1, "up")
        Me.ImageList2.Images.SetKeyName(2, "Warning")
        Me.ImageList2.Images.SetKeyName(3, "IMG")
        Me.ImageList2.Images.SetKeyName(4, "FILE")
        Me.ImageList2.Images.SetKeyName(5, "TXT")
        '
        'KryptonLabel48
        '
        Me.KryptonLabel48.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel48, "KryptonLabel48")
        Me.KryptonLabel48.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel48.Name = "KryptonLabel48"
        Me.KryptonLabel48.Values.Text = resources.GetString("KryptonLabel48.Values.Text")
        '
        'Settings_ListView2
        '
        Me.Settings_ListView2.AllowColumnReorder = True
        Me.Settings_ListView2.AllowDrop = True
        Me.Settings_ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5})
        Me.Settings_ListView2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Settings_ListView2, "Settings_ListView2")
        Me.Settings_ListView2.FullRowSelect = True
        Me.Settings_ListView2.GridLines = True
        Me.Settings_ListView2.Name = "Settings_ListView2"
        Me.Settings_ListView2.ShowItemToolTips = True
        Me.Settings_ListView2.SmallImageList = Me.ImageList2
        Me.Settings_ListView2.UseCompatibleStateImageBehavior = False
        Me.Settings_ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
        '
        'KryptonLabel47
        '
        Me.KryptonLabel47.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel47, "KryptonLabel47")
        Me.KryptonLabel47.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel47.Name = "KryptonLabel47"
        Me.KryptonLabel47.Values.Text = resources.GetString("KryptonLabel47.Values.Text")
        '
        'References_ListView1
        '
        Me.References_ListView1.AllowColumnReorder = True
        Me.References_ListView1.AllowDrop = True
        Me.References_ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.References_ListView1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.References_ListView1, "References_ListView1")
        Me.References_ListView1.FullRowSelect = True
        Me.References_ListView1.GridLines = True
        Me.References_ListView1.Name = "References_ListView1"
        Me.References_ListView1.ShowItemToolTips = True
        Me.References_ListView1.SmallImageList = Me.ImageList2
        Me.References_ListView1.UseCompatibleStateImageBehavior = False
        Me.References_ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'KryptonLabel45
        '
        Me.KryptonLabel45.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel45, "KryptonLabel45")
        Me.KryptonLabel45.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel45.Name = "KryptonLabel45"
        Me.KryptonLabel45.Values.Text = resources.GetString("KryptonLabel45.Values.Text")
        '
        'TableLayoutPanel22
        '
        resources.ApplyResources(Me.TableLayoutPanel22, "TableLayoutPanel22")
        Me.TableLayoutPanel22.Controls.Add(Me.KryptonLabel46, 0, 0)
        Me.TableLayoutPanel22.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel22.Name = "TableLayoutPanel22"
        '
        'KryptonLabel46
        '
        Me.KryptonLabel46.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel46, "KryptonLabel46")
        Me.KryptonLabel46.Name = "KryptonLabel46"
        Me.KryptonLabel46.Values.Text = resources.GetString("KryptonLabel46.Values.Text")
        '
        'TableLayoutPanel21
        '
        resources.ApplyResources(Me.TableLayoutPanel21, "TableLayoutPanel21")
        Me.TableLayoutPanel21.Controls.Add(Me.CPU_KryptonLabel43, 0, 0)
        Me.TableLayoutPanel21.Controls.Add(Me.KryptonLabel44, 0, 0)
        Me.TableLayoutPanel21.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel21.Name = "TableLayoutPanel21"
        '
        'CPU_KryptonLabel43
        '
        Me.CPU_KryptonLabel43.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.CPU_KryptonLabel43, "CPU_KryptonLabel43")
        Me.CPU_KryptonLabel43.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.CPU_KryptonLabel43.Name = "CPU_KryptonLabel43"
        Me.CPU_KryptonLabel43.Values.Text = resources.GetString("CPU_KryptonLabel43.Values.Text")
        '
        'KryptonLabel44
        '
        Me.KryptonLabel44.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel44, "KryptonLabel44")
        Me.KryptonLabel44.Name = "KryptonLabel44"
        Me.KryptonLabel44.Values.Text = resources.GetString("KryptonLabel44.Values.Text")
        '
        'TableLayoutPanel20
        '
        resources.ApplyResources(Me.TableLayoutPanel20, "TableLayoutPanel20")
        Me.TableLayoutPanel20.Controls.Add(Me.Optimiser_KryptonLabel41, 0, 0)
        Me.TableLayoutPanel20.Controls.Add(Me.KryptonLabel42, 0, 0)
        Me.TableLayoutPanel20.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel20.Name = "TableLayoutPanel20"
        '
        'Optimiser_KryptonLabel41
        '
        Me.Optimiser_KryptonLabel41.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Optimiser_KryptonLabel41, "Optimiser_KryptonLabel41")
        Me.Optimiser_KryptonLabel41.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Optimiser_KryptonLabel41.Name = "Optimiser_KryptonLabel41"
        Me.Optimiser_KryptonLabel41.Values.Text = resources.GetString("Optimiser_KryptonLabel41.Values.Text")
        '
        'KryptonLabel42
        '
        Me.KryptonLabel42.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel42, "KryptonLabel42")
        Me.KryptonLabel42.Name = "KryptonLabel42"
        Me.KryptonLabel42.Values.Text = resources.GetString("KryptonLabel42.Values.Text")
        '
        'TableLayoutPanel19
        '
        resources.ApplyResources(Me.TableLayoutPanel19, "TableLayoutPanel19")
        Me.TableLayoutPanel19.Controls.Add(Me.Dossier_Generation_KryptonLabel39, 0, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.KryptonLabel40, 0, 0)
        Me.TableLayoutPanel19.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel19.Name = "TableLayoutPanel19"
        '
        'Dossier_Generation_KryptonLabel39
        '
        Me.Dossier_Generation_KryptonLabel39.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Dossier_Generation_KryptonLabel39, "Dossier_Generation_KryptonLabel39")
        Me.Dossier_Generation_KryptonLabel39.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Dossier_Generation_KryptonLabel39.Name = "Dossier_Generation_KryptonLabel39"
        Me.Dossier_Generation_KryptonLabel39.Values.Text = resources.GetString("Dossier_Generation_KryptonLabel39.Values.Text")
        '
        'KryptonLabel40
        '
        Me.KryptonLabel40.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel40, "KryptonLabel40")
        Me.KryptonLabel40.Name = "KryptonLabel40"
        Me.KryptonLabel40.Values.Text = resources.GetString("KryptonLabel40.Values.Text")
        '
        'KryptonLabel38
        '
        Me.KryptonLabel38.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel38, "KryptonLabel38")
        Me.KryptonLabel38.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel38.Name = "KryptonLabel38"
        Me.KryptonLabel38.Values.Text = resources.GetString("KryptonLabel38.Values.Text")
        '
        'TableLayoutPanel18
        '
        resources.ApplyResources(Me.TableLayoutPanel18, "TableLayoutPanel18")
        Me.TableLayoutPanel18.Controls.Add(Me.Marque_KryptonLabel36, 0, 0)
        Me.TableLayoutPanel18.Controls.Add(Me.KryptonLabel37, 0, 0)
        Me.TableLayoutPanel18.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel18.Name = "TableLayoutPanel18"
        '
        'Marque_KryptonLabel36
        '
        Me.Marque_KryptonLabel36.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Marque_KryptonLabel36, "Marque_KryptonLabel36")
        Me.Marque_KryptonLabel36.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Marque_KryptonLabel36.Name = "Marque_KryptonLabel36"
        Me.Marque_KryptonLabel36.Values.Text = resources.GetString("Marque_KryptonLabel36.Values.Text")
        '
        'KryptonLabel37
        '
        Me.KryptonLabel37.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel37, "KryptonLabel37")
        Me.KryptonLabel37.Name = "KryptonLabel37"
        Me.KryptonLabel37.Values.Text = resources.GetString("KryptonLabel37.Values.Text")
        '
        'TableLayoutPanel17
        '
        resources.ApplyResources(Me.TableLayoutPanel17, "TableLayoutPanel17")
        Me.TableLayoutPanel17.Controls.Add(Me.Version_Assembly_KryptonLabel34, 0, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.KryptonLabel35, 0, 0)
        Me.TableLayoutPanel17.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        '
        'Version_Assembly_KryptonLabel34
        '
        Me.Version_Assembly_KryptonLabel34.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Version_Assembly_KryptonLabel34, "Version_Assembly_KryptonLabel34")
        Me.Version_Assembly_KryptonLabel34.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Version_Assembly_KryptonLabel34.Name = "Version_Assembly_KryptonLabel34"
        Me.Version_Assembly_KryptonLabel34.Values.Text = resources.GetString("Version_Assembly_KryptonLabel34.Values.Text")
        '
        'KryptonLabel35
        '
        Me.KryptonLabel35.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel35, "KryptonLabel35")
        Me.KryptonLabel35.Name = "KryptonLabel35"
        Me.KryptonLabel35.Values.Text = resources.GetString("KryptonLabel35.Values.Text")
        '
        'TableLayoutPanel16
        '
        resources.ApplyResources(Me.TableLayoutPanel16, "TableLayoutPanel16")
        Me.TableLayoutPanel16.Controls.Add(Me.Version_Fichier_KryptonLabel32, 0, 0)
        Me.TableLayoutPanel16.Controls.Add(Me.KryptonLabel33, 0, 0)
        Me.TableLayoutPanel16.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        '
        'Version_Fichier_KryptonLabel32
        '
        Me.Version_Fichier_KryptonLabel32.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Version_Fichier_KryptonLabel32, "Version_Fichier_KryptonLabel32")
        Me.Version_Fichier_KryptonLabel32.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Version_Fichier_KryptonLabel32.Name = "Version_Fichier_KryptonLabel32"
        Me.Version_Fichier_KryptonLabel32.Values.Text = resources.GetString("Version_Fichier_KryptonLabel32.Values.Text")
        '
        'KryptonLabel33
        '
        Me.KryptonLabel33.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel33, "KryptonLabel33")
        Me.KryptonLabel33.Name = "KryptonLabel33"
        Me.KryptonLabel33.Values.Text = resources.GetString("KryptonLabel33.Values.Text")
        '
        'TableLayoutPanel15
        '
        resources.ApplyResources(Me.TableLayoutPanel15, "TableLayoutPanel15")
        Me.TableLayoutPanel15.Controls.Add(Me.Copyright_KryptonLabel30, 0, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.KryptonLabel31, 0, 0)
        Me.TableLayoutPanel15.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        '
        'Copyright_KryptonLabel30
        '
        Me.Copyright_KryptonLabel30.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Copyright_KryptonLabel30, "Copyright_KryptonLabel30")
        Me.Copyright_KryptonLabel30.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Copyright_KryptonLabel30.Name = "Copyright_KryptonLabel30"
        Me.Copyright_KryptonLabel30.Values.Text = resources.GetString("Copyright_KryptonLabel30.Values.Text")
        '
        'KryptonLabel31
        '
        Me.KryptonLabel31.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel31, "KryptonLabel31")
        Me.KryptonLabel31.Name = "KryptonLabel31"
        Me.KryptonLabel31.Values.Text = resources.GetString("KryptonLabel31.Values.Text")
        '
        'TableLayoutPanel14
        '
        resources.ApplyResources(Me.TableLayoutPanel14, "TableLayoutPanel14")
        Me.TableLayoutPanel14.Controls.Add(Me.Produit_KryptonLabel28, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.KryptonLabel29, 0, 0)
        Me.TableLayoutPanel14.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        '
        'Produit_KryptonLabel28
        '
        Me.Produit_KryptonLabel28.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Produit_KryptonLabel28, "Produit_KryptonLabel28")
        Me.Produit_KryptonLabel28.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Produit_KryptonLabel28.Name = "Produit_KryptonLabel28"
        Me.Produit_KryptonLabel28.Values.Text = resources.GetString("Produit_KryptonLabel28.Values.Text")
        '
        'KryptonLabel29
        '
        Me.KryptonLabel29.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel29, "KryptonLabel29")
        Me.KryptonLabel29.Name = "KryptonLabel29"
        Me.KryptonLabel29.Values.Text = resources.GetString("KryptonLabel29.Values.Text")
        '
        'TableLayoutPanel13
        '
        resources.ApplyResources(Me.TableLayoutPanel13, "TableLayoutPanel13")
        Me.TableLayoutPanel13.Controls.Add(Me.Societe_KryptonLabel26, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.KryptonLabel27, 0, 0)
        Me.TableLayoutPanel13.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        '
        'Societe_KryptonLabel26
        '
        Me.Societe_KryptonLabel26.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Societe_KryptonLabel26, "Societe_KryptonLabel26")
        Me.Societe_KryptonLabel26.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Societe_KryptonLabel26.Name = "Societe_KryptonLabel26"
        Me.Societe_KryptonLabel26.Values.Text = resources.GetString("Societe_KryptonLabel26.Values.Text")
        '
        'KryptonLabel27
        '
        Me.KryptonLabel27.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel27, "KryptonLabel27")
        Me.KryptonLabel27.Name = "KryptonLabel27"
        Me.KryptonLabel27.Values.Text = resources.GetString("KryptonLabel27.Values.Text")
        '
        'TableLayoutPanel12
        '
        resources.ApplyResources(Me.TableLayoutPanel12, "TableLayoutPanel12")
        Me.TableLayoutPanel12.Controls.Add(Me.Description_KryptonLabel24, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.KryptonLabel25, 0, 0)
        Me.TableLayoutPanel12.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        '
        'Description_KryptonLabel24
        '
        Me.Description_KryptonLabel24.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Description_KryptonLabel24, "Description_KryptonLabel24")
        Me.Description_KryptonLabel24.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Description_KryptonLabel24.Name = "Description_KryptonLabel24"
        Me.Description_KryptonLabel24.Values.Text = resources.GetString("Description_KryptonLabel24.Values.Text")
        '
        'KryptonLabel25
        '
        Me.KryptonLabel25.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel25, "KryptonLabel25")
        Me.KryptonLabel25.Name = "KryptonLabel25"
        Me.KryptonLabel25.Values.Text = resources.GetString("KryptonLabel25.Values.Text")
        '
        'TableLayoutPanel11
        '
        resources.ApplyResources(Me.TableLayoutPanel11, "TableLayoutPanel11")
        Me.TableLayoutPanel11.Controls.Add(Me.Titre_KryptonLabel22, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.KryptonLabel23, 0, 0)
        Me.TableLayoutPanel11.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        '
        'Titre_KryptonLabel22
        '
        Me.Titre_KryptonLabel22.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Titre_KryptonLabel22, "Titre_KryptonLabel22")
        Me.Titre_KryptonLabel22.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Titre_KryptonLabel22.Name = "Titre_KryptonLabel22"
        Me.Titre_KryptonLabel22.Values.Text = resources.GetString("Titre_KryptonLabel22.Values.Text")
        '
        'KryptonLabel23
        '
        Me.KryptonLabel23.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel23, "KryptonLabel23")
        Me.KryptonLabel23.Name = "KryptonLabel23"
        Me.KryptonLabel23.Values.Text = resources.GetString("KryptonLabel23.Values.Text")
        '
        'KryptonLabel19
        '
        Me.KryptonLabel19.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel19, "KryptonLabel19")
        Me.KryptonLabel19.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel19.Name = "KryptonLabel19"
        Me.KryptonLabel19.Values.Text = resources.GetString("KryptonLabel19.Values.Text")
        '
        'KryptonLabel21
        '
        Me.KryptonLabel21.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel21, "KryptonLabel21")
        Me.KryptonLabel21.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel21.Name = "KryptonLabel21"
        Me.KryptonLabel21.Values.Text = resources.GetString("KryptonLabel21.Values.Text")
        '
        'TableLayoutPanel10
        '
        resources.ApplyResources(Me.TableLayoutPanel10, "TableLayoutPanel10")
        Me.TableLayoutPanel10.Controls.Add(Me.KryptonLabel20, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.PictureBox1, 1, 0)
        Me.TableLayoutPanel10.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        '
        'KryptonLabel20
        '
        Me.KryptonLabel20.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel20, "KryptonLabel20")
        Me.KryptonLabel20.Name = "KryptonLabel20"
        Me.KryptonLabel20.Values.Text = resources.GetString("KryptonLabel20.Values.Text")
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'TableLayoutPanel9
        '
        resources.ApplyResources(Me.TableLayoutPanel9, "TableLayoutPanel9")
        Me.TableLayoutPanel9.Controls.Add(Me.Mode_Arrête_KryptonLabel17, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.KryptonLabel18, 0, 0)
        Me.TableLayoutPanel9.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        '
        'Mode_Arrête_KryptonLabel17
        '
        Me.Mode_Arrête_KryptonLabel17.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Mode_Arrête_KryptonLabel17, "Mode_Arrête_KryptonLabel17")
        Me.Mode_Arrête_KryptonLabel17.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Mode_Arrête_KryptonLabel17.Name = "Mode_Arrête_KryptonLabel17"
        Me.Mode_Arrête_KryptonLabel17.Values.Text = resources.GetString("Mode_Arrête_KryptonLabel17.Values.Text")
        '
        'KryptonLabel18
        '
        Me.KryptonLabel18.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel18, "KryptonLabel18")
        Me.KryptonLabel18.Name = "KryptonLabel18"
        Me.KryptonLabel18.Values.Text = resources.GetString("KryptonLabel18.Values.Text")
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel8.Controls.Add(Me.Enregistrer_Settings_KryptonLabel15, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.KryptonLabel16, 0, 0)
        Me.TableLayoutPanel8.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'Enregistrer_Settings_KryptonLabel15
        '
        Me.Enregistrer_Settings_KryptonLabel15.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Enregistrer_Settings_KryptonLabel15, "Enregistrer_Settings_KryptonLabel15")
        Me.Enregistrer_Settings_KryptonLabel15.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Enregistrer_Settings_KryptonLabel15.Name = "Enregistrer_Settings_KryptonLabel15"
        Me.Enregistrer_Settings_KryptonLabel15.Values.Text = resources.GetString("Enregistrer_Settings_KryptonLabel15.Values.Text")
        '
        'KryptonLabel16
        '
        Me.KryptonLabel16.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel16, "KryptonLabel16")
        Me.KryptonLabel16.Name = "KryptonLabel16"
        Me.KryptonLabel16.Values.Text = resources.GetString("KryptonLabel16.Values.Text")
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.Instance_KryptonLabel13, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.KryptonLabel14, 0, 0)
        Me.TableLayoutPanel7.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'Instance_KryptonLabel13
        '
        Me.Instance_KryptonLabel13.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Instance_KryptonLabel13, "Instance_KryptonLabel13")
        Me.Instance_KryptonLabel13.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Instance_KryptonLabel13.Name = "Instance_KryptonLabel13"
        Me.Instance_KryptonLabel13.Values.Text = resources.GetString("Instance_KryptonLabel13.Values.Text")
        '
        'KryptonLabel14
        '
        Me.KryptonLabel14.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel14, "KryptonLabel14")
        Me.KryptonLabel14.Name = "KryptonLabel14"
        Me.KryptonLabel14.Values.Text = resources.GetString("KryptonLabel14.Values.Text")
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.Style_Visual_KryptonLabel11, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.KryptonLabel12, 0, 0)
        Me.TableLayoutPanel6.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'Style_Visual_KryptonLabel11
        '
        Me.Style_Visual_KryptonLabel11.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Style_Visual_KryptonLabel11, "Style_Visual_KryptonLabel11")
        Me.Style_Visual_KryptonLabel11.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Style_Visual_KryptonLabel11.Name = "Style_Visual_KryptonLabel11"
        Me.Style_Visual_KryptonLabel11.Values.Text = resources.GetString("Style_Visual_KryptonLabel11.Values.Text")
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel12, "KryptonLabel12")
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Values.Text = resources.GetString("KryptonLabel12.Values.Text")
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.Ecran_Demarrage_KryptonLabel9, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.KryptonLabel10, 0, 0)
        Me.TableLayoutPanel5.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'Ecran_Demarrage_KryptonLabel9
        '
        Me.Ecran_Demarrage_KryptonLabel9.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Ecran_Demarrage_KryptonLabel9, "Ecran_Demarrage_KryptonLabel9")
        Me.Ecran_Demarrage_KryptonLabel9.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Ecran_Demarrage_KryptonLabel9.Name = "Ecran_Demarrage_KryptonLabel9"
        Me.Ecran_Demarrage_KryptonLabel9.Values.Text = resources.GetString("Ecran_Demarrage_KryptonLabel9.Values.Text")
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel10, "KryptonLabel10")
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Values.Text = resources.GetString("KryptonLabel10.Values.Text")
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.Fenêtre_Demarrage_KryptonLabel6, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.KryptonLabel8, 0, 0)
        Me.TableLayoutPanel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'Fenêtre_Demarrage_KryptonLabel6
        '
        Me.Fenêtre_Demarrage_KryptonLabel6.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Fenêtre_Demarrage_KryptonLabel6, "Fenêtre_Demarrage_KryptonLabel6")
        Me.Fenêtre_Demarrage_KryptonLabel6.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Fenêtre_Demarrage_KryptonLabel6.Name = "Fenêtre_Demarrage_KryptonLabel6"
        Me.Fenêtre_Demarrage_KryptonLabel6.Values.Text = resources.GetString("Fenêtre_Demarrage_KryptonLabel6.Values.Text")
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel8, "KryptonLabel8")
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Values.Text = resources.GetString("KryptonLabel8.Values.Text")
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.Type_KryptonLabel3, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.KryptonLabel5, 0, 0)
        Me.TableLayoutPanel3.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'Type_KryptonLabel3
        '
        Me.Type_KryptonLabel3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Type_KryptonLabel3, "Type_KryptonLabel3")
        Me.Type_KryptonLabel3.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Type_KryptonLabel3.Name = "Type_KryptonLabel3"
        Me.Type_KryptonLabel3.Values.Text = resources.GetString("Type_KryptonLabel3.Values.Text")
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel5, "KryptonLabel5")
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Values.Text = resources.GetString("KryptonLabel5.Values.Text")
        '
        'Composition_Chart
        '
        Me.Composition_Chart.BackColor = System.Drawing.Color.Empty
        Me.Composition_Chart.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.Inclination = 45
        ChartArea1.Area3DStyle.PointDepth = 125
        ChartArea1.AxisX.ScaleBreakStyle.Spacing = 1.0R
        ChartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisY.ScaleBreakStyle.Spacing = 1.0R
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.CursorX.IsUserEnabled = True
        ChartArea1.CursorX.IsUserSelectionEnabled = True
        ChartArea1.CursorX.SelectionColor = System.Drawing.Color.LightBlue
        ChartArea1.Name = "Composition_ChartArea"
        Me.Composition_Chart.ChartAreas.Add(ChartArea1)
        Me.Composition_Chart.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Composition_Chart, "Composition_Chart")
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.DockedToChartArea = "Composition_ChartArea"
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Composition_Legend"
        Me.Composition_Chart.Legends.Add(Legend1)
        Me.Composition_Chart.Name = "Composition_Chart"
        Me.Composition_Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.ChartArea = "Composition_ChartArea"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Color = System.Drawing.Color.Green
        Series1.IsXValueIndexed = True
        Series1.Legend = "Composition_Legend"
        Series1.LegendText = "Success"
        Series1.Name = "Serie"
        DataPoint1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        DataPoint1.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataPoint1.IsValueShownAsLabel = True
        DataPoint1.Label = "#VAL%"
        DataPoint1.LabelFormat = ""
        DataPoint1.LegendText = "Controls"
        DataPoint2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        DataPoint2.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataPoint2.IsValueShownAsLabel = True
        DataPoint2.Label = "#VAL%"
        DataPoint2.LegendText = "Functions"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Composition_Chart.Series.Add(Series1)
        Me.Composition_Chart.SuppressExceptions = True
        Title1.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Title1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Title1.Name = "Titre_Composition"
        Title1.Text = "Project composition"
        Me.Composition_Chart.Titles.Add(Title1)
        '
        'Generation_Succes_Echecs_Chart
        '
        Me.Generation_Succes_Echecs_Chart.BackColor = System.Drawing.Color.Empty
        Me.Generation_Succes_Echecs_Chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Generation_Succes_Echecs_Chart.BackSecondaryColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        ChartArea2.AxisX.ScaleBreakStyle.Spacing = 1.0R
        ChartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea2.AxisY.ScaleBreakStyle.Spacing = 1.0R
        ChartArea2.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.CursorX.IsUserEnabled = True
        ChartArea2.CursorX.IsUserSelectionEnabled = True
        ChartArea2.CursorX.SelectionColor = System.Drawing.Color.LightBlue
        ChartArea2.Name = "Generation_Succes_Echecs_ChartArea"
        Me.Generation_Succes_Echecs_Chart.ChartAreas.Add(ChartArea2)
        Me.Generation_Succes_Echecs_Chart.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Generation_Succes_Echecs_Chart, "Generation_Succes_Echecs_Chart")
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.DockedToChartArea = "Generation_Succes_Echecs_ChartArea"
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Generation_Succes_Echecs_Legend"
        Me.Generation_Succes_Echecs_Chart.Legends.Add(Legend2)
        Me.Generation_Succes_Echecs_Chart.Name = "Generation_Succes_Echecs_Chart"
        Me.Generation_Succes_Echecs_Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Series2.ChartArea = "Generation_Succes_Echecs_ChartArea"
        Series2.Color = System.Drawing.Color.Green
        Series2.Legend = "Generation_Succes_Echecs_Legend"
        Series2.LegendText = "Successes"
        Series2.Name = "Serie_Generation_Succes"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Series3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series3.ChartArea = "Generation_Succes_Echecs_ChartArea"
        Series3.Color = System.Drawing.Color.Red
        Series3.Legend = "Generation_Succes_Echecs_Legend"
        Series3.LegendText = "Failures"
        Series3.Name = "Serie_Generation_Echecs"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.Generation_Succes_Echecs_Chart.Series.Add(Series2)
        Me.Generation_Succes_Echecs_Chart.Series.Add(Series3)
        Me.Generation_Succes_Echecs_Chart.SuppressExceptions = True
        Title2.Alignment = System.Drawing.ContentAlignment.MiddleLeft
        Title2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Title2.Name = "Titre_Generation_Succes_Echecs"
        Title2.Text = "Build successes and failures"
        Me.Generation_Succes_Echecs_Chart.Titles.Add(Title2)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Reinitialiser_KryptonButton1)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'Reinitialiser_KryptonButton1
        '
        Me.Reinitialiser_KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Reinitialiser_KryptonButton1, "Reinitialiser_KryptonButton1")
        Me.Reinitialiser_KryptonButton1.Name = "Reinitialiser_KryptonButton1"
        Me.Reinitialiser_KryptonButton1.Values.Text = resources.GetString("Reinitialiser_KryptonButton1.Values.Text")
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.Nom_KryptonLabel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.KryptonLabel7, 0, 0)
        Me.TableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'Nom_KryptonLabel
        '
        Me.Nom_KryptonLabel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Nom_KryptonLabel, "Nom_KryptonLabel")
        Me.Nom_KryptonLabel.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.SuperTip
        Me.Nom_KryptonLabel.Name = "Nom_KryptonLabel"
        Me.Nom_KryptonLabel.Values.Text = resources.GetString("Nom_KryptonLabel.Values.Text")
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel7, "KryptonLabel7")
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Values.Text = resources.GetString("KryptonLabel7.Values.Text")
        '
        'VB_ListView4
        '
        Me.VB_ListView4.AllowColumnReorder = True
        Me.VB_ListView4.AllowDrop = True
        Me.VB_ListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7})
        Me.VB_ListView4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.VB_ListView4, "VB_ListView4")
        Me.VB_ListView4.FullRowSelect = True
        Me.VB_ListView4.GridLines = True
        Me.VB_ListView4.Name = "VB_ListView4"
        Me.VB_ListView4.ShowItemToolTips = True
        Me.VB_ListView4.SmallImageList = Me.ImageList2
        Me.VB_ListView4.UseCompatibleStateImageBehavior = False
        Me.VB_ListView4.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        resources.ApplyResources(Me.ColumnHeader7, "ColumnHeader7")
        '
        'KryptonButton5
        '
        Me.KryptonButton5.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonButton5, "KryptonButton5")
        Me.KryptonButton5.Name = "KryptonButton5"
        Me.KryptonButton5.Values.Text = resources.GetString("KryptonButton5.Values.Text")
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel4, "KryptonLabel4")
        Me.KryptonLabel4.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Values.Text = resources.GetString("KryptonLabel4.Values.Text")
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'DocStatistiques
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "DocStatistiques"
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        Me.KryptonSplitContainer1.Panel2.PerformLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel23.ResumeLayout(False)
        Me.TableLayoutPanel23.PerformLayout()
        Me.TableLayoutPanel22.ResumeLayout(False)
        Me.TableLayoutPanel22.PerformLayout()
        Me.TableLayoutPanel21.ResumeLayout(False)
        Me.TableLayoutPanel21.PerformLayout()
        Me.TableLayoutPanel20.ResumeLayout(False)
        Me.TableLayoutPanel20.PerformLayout()
        Me.TableLayoutPanel19.ResumeLayout(False)
        Me.TableLayoutPanel19.PerformLayout()
        Me.TableLayoutPanel18.ResumeLayout(False)
        Me.TableLayoutPanel18.PerformLayout()
        Me.TableLayoutPanel17.ResumeLayout(False)
        Me.TableLayoutPanel17.PerformLayout()
        Me.TableLayoutPanel16.ResumeLayout(False)
        Me.TableLayoutPanel16.PerformLayout()
        Me.TableLayoutPanel15.ResumeLayout(False)
        Me.TableLayoutPanel15.PerformLayout()
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.TableLayoutPanel14.PerformLayout()
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel13.PerformLayout()
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.Composition_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Generation_Succes_Echecs_Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonLabel4 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton5 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents KryptonSplitContainer1 As VelerSoftware.Design.Toolkit.KryptonSplitContainer
    Friend WithEvents Ressource_KryptonTextBox As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents KryptonWrapLabel1 As VelerSoftware.Design.Toolkit.KryptonWrapLabel
    Friend WithEvents ButtonSpecAny1 As VelerSoftware.Design.Toolkit.ButtonSpecAny
    Friend WithEvents Generation_Succes_Echecs_Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Composition_Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Reinitialiser_KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Type_KryptonLabel3 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents Nom_KryptonLabel As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents KryptonLabel20 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Mode_Arrête_KryptonLabel17 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel18 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Enregistrer_Settings_KryptonLabel15 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel16 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Instance_KryptonLabel13 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel14 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Style_Visual_KryptonLabel11 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel12 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Ecran_Demarrage_KryptonLabel9 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Fenêtre_Demarrage_KryptonLabel6 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel8 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel21 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents KryptonLabel19 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Titre_KryptonLabel22 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel23 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel18 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Marque_KryptonLabel36 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel37 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel17 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Version_Assembly_KryptonLabel34 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel35 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel16 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Version_Fichier_KryptonLabel32 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel33 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel15 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Copyright_KryptonLabel30 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel31 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel14 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Produit_KryptonLabel28 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel29 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Societe_KryptonLabel26 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel27 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Description_KryptonLabel24 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel25 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel38 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel19 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Dossier_Generation_KryptonLabel39 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel40 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel20 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Optimiser_KryptonLabel41 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel42 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel21 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CPU_KryptonLabel43 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel44 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents VB_ListView4 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TableLayoutPanel22 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents KryptonLabel46 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel45 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents References_ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Settings_ListView2 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents KryptonLabel47 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents Resx_ListView3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents KryptonLabel48 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents KryptonLabel2 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents Variables_ListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TableLayoutPanel23 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ObfuscationLevel_KryptonLabel As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader

End Class
