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
Partial Class DocConcepteurFenetre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocConcepteurFenetre))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.KryptonNavigator1 = New VelerSoftware.Design.Navigator.KryptonNavigator()
        Me.Concepteur_Fenetre_KryptonPage = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RulerControl2 = New VelerSoftware.SZC.RulerControl.RulerControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RulerControl1 = New VelerSoftware.SZC.RulerControl.RulerControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonLinkLabel1 = New VelerSoftware.Design.Toolkit.KryptonLinkLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.Editeur_Fonction_KryptonPage = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.KryptonNavigator2 = New VelerSoftware.Design.Navigator.KryptonNavigator()
        Me.ButtonSpecNavigator1 = New VelerSoftware.Design.Navigator.ButtonSpecNavigator()
        Me.TabONE_KryptonPage = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        DirectCast(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator1.SuspendLayout()
        DirectCast(Me.Concepteur_Fenetre_KryptonPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Concepteur_Fenetre_KryptonPage.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        DirectCast(Me.Editeur_Fonction_KryptonPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Editeur_Fonction_KryptonPage.SuspendLayout()
        DirectCast(Me.KryptonNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator2.SuspendLayout()
        DirectCast(Me.TabONE_KryptonPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.KryptonNavigator1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonPanel.Name = "kryptonPanel"
        Me.kryptonPanel.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'KryptonNavigator1
        '
        Me.KryptonNavigator1.AllowPageReorder = False
        Me.KryptonNavigator1.Bar.BarMinimumHeight = 30
        Me.KryptonNavigator1.Bar.BarOrientation = VelerSoftware.Design.Toolkit.VisualOrientation.Bottom
        Me.KryptonNavigator1.Bar.ItemAlignment = VelerSoftware.Design.Toolkit.RelativePositionAlign.Center
        Me.KryptonNavigator1.Bar.ItemSizing = VelerSoftware.Design.Navigator.BarItemSizing.SameWidthAndHeight
        Me.KryptonNavigator1.Button.CloseButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator1.Button.ContextButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonNavigator1, "KryptonNavigator1")
        Me.KryptonNavigator1.Name = "KryptonNavigator1"
        Me.KryptonNavigator1.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.BarCheckButtonGroupInside
        Me.KryptonNavigator1.Pages.AddRange(New VelerSoftware.Design.Navigator.KryptonPage() {Me.Concepteur_Fenetre_KryptonPage, Me.Editeur_Fonction_KryptonPage})
        Me.KryptonNavigator1.SelectedIndex = 1
        Me.KryptonNavigator1.StateCommon.HeaderGroup.Border.DrawBorders = VelerSoftware.Design.Toolkit.PaletteDrawBorders.None
        '
        'Concepteur_Fenetre_KryptonPage
        '
        Me.Concepteur_Fenetre_KryptonPage.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.Concepteur_Fenetre_KryptonPage.Controls.Add(Me.Panel2)
        Me.Concepteur_Fenetre_KryptonPage.Controls.Add(Me.Panel3)
        Me.Concepteur_Fenetre_KryptonPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.Concepteur_Fenetre_KryptonPage.Flags = 65534
        resources.ApplyResources(Me.Concepteur_Fenetre_KryptonPage, "Concepteur_Fenetre_KryptonPage")
        Me.Concepteur_Fenetre_KryptonPage.LastVisibleSet = True
        Me.Concepteur_Fenetre_KryptonPage.MinimumSize = New System.Drawing.Size(50, 50)
        Me.Concepteur_Fenetre_KryptonPage.Name = "Concepteur_Fenetre_KryptonPage"
        Me.Concepteur_Fenetre_KryptonPage.UniqueName = "3E04CCBE75E54D9299A6850757A8E0CC"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.RulerControl2)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.RulerControl1)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'RulerControl2
        '
        Me.RulerControl2.ActualSize = True
        resources.ApplyResources(Me.RulerControl2, "RulerControl2")
        Me.RulerControl2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.RulerControl2.Cursor = System.Windows.Forms.Cursors.Default
        Me.RulerControl2.DivisionMarkFactor = 4
        Me.RulerControl2.Divisions = 6
        Me.RulerControl2.ForeColor = System.Drawing.Color.Black
        Me.RulerControl2.MajorInterval = 100
        Me.RulerControl2.MiddleMarkFactor = 2
        Me.RulerControl2.MouseTrackingOn = False
        Me.RulerControl2.Name = "RulerControl2"
        Me.RulerControl2.Orientation = VelerSoftware.SZC.RulerControl.enumOrientation.orVertical
        Me.RulerControl2.RulerAlignment = VelerSoftware.SZC.RulerControl.enumRulerAlignment.raMiddle
        Me.RulerControl2.ScaleMode = VelerSoftware.SZC.RulerControl.enumScaleMode.smPixels
        Me.RulerControl2.StartValue = 0.0R
        Me.RulerControl2.VerticalNumbers = False
        Me.RulerControl2.ZoomFactor = 1.0R
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel1.Name = "Panel1"
        '
        'RulerControl1
        '
        Me.RulerControl1.ActualSize = True
        resources.ApplyResources(Me.RulerControl1, "RulerControl1")
        Me.RulerControl1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.RulerControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RulerControl1.DivisionMarkFactor = 4
        Me.RulerControl1.Divisions = 6
        Me.RulerControl1.ForeColor = System.Drawing.Color.Black
        Me.RulerControl1.MajorInterval = 100
        Me.RulerControl1.MiddleMarkFactor = 2
        Me.RulerControl1.MouseTrackingOn = False
        Me.RulerControl1.Name = "RulerControl1"
        Me.RulerControl1.Orientation = VelerSoftware.SZC.RulerControl.enumOrientation.orHorizontal
        Me.RulerControl1.RulerAlignment = VelerSoftware.SZC.RulerControl.enumRulerAlignment.raMiddle
        Me.RulerControl1.ScaleMode = VelerSoftware.SZC.RulerControl.enumScaleMode.smPixels
        Me.RulerControl1.StartValue = 0.0R
        Me.RulerControl1.VerticalNumbers = False
        Me.RulerControl1.ZoomFactor = 1.0R
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.KryptonLinkLabel1)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Controls.Add(Me.KryptonButton1)
        Me.Panel3.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'KryptonLinkLabel1
        '
        Me.KryptonLinkLabel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLinkLabel1, "KryptonLinkLabel1")
        Me.KryptonLinkLabel1.Name = "KryptonLinkLabel1"
        Me.KryptonLinkLabel1.Values.Text = resources.GetString("KryptonLinkLabel1.Values.Text")
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonTextBox1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLabel1, 0, 0)
        Me.TableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonTextBox1, "KryptonTextBox1")
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.KryptonTextBox1, resources.GetString("KryptonTextBox1.ToolTip"))
        '
        'KryptonLabel1
        '
        resources.ApplyResources(Me.KryptonLabel1, "KryptonLabel1")
        Me.KryptonLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Values.Text = resources.GetString("KryptonLabel1.Values.Text")
        '
        'KryptonButton1
        '
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.ToolTip1.SetToolTip(Me.KryptonButton1, resources.GetString("KryptonButton1.ToolTip"))
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'Editeur_Fonction_KryptonPage
        '
        Me.Editeur_Fonction_KryptonPage.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.Editeur_Fonction_KryptonPage.Controls.Add(Me.KryptonNavigator2)
        Me.Editeur_Fonction_KryptonPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.Editeur_Fonction_KryptonPage.Flags = 65534
        resources.ApplyResources(Me.Editeur_Fonction_KryptonPage, "Editeur_Fonction_KryptonPage")
        Me.Editeur_Fonction_KryptonPage.LastVisibleSet = True
        Me.Editeur_Fonction_KryptonPage.MinimumSize = New System.Drawing.Size(50, 50)
        Me.Editeur_Fonction_KryptonPage.Name = "Editeur_Fonction_KryptonPage"
        Me.Editeur_Fonction_KryptonPage.UniqueName = "CDBD1DA7D5BB40D3EF9CBCAFCB22C5BF"
        '
        'KryptonNavigator2
        '
        Me.KryptonNavigator2.Bar.BarMinimumHeight = 30
        Me.KryptonNavigator2.Button.ButtonDisplayLogic = VelerSoftware.Design.Navigator.ButtonDisplayLogic.ContextNextPrevious
        Me.KryptonNavigator2.Button.ButtonSpecs.AddRange(New VelerSoftware.Design.Navigator.ButtonSpecNavigator() {Me.ButtonSpecNavigator1})
        Me.KryptonNavigator2.Button.CloseButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonNavigator2, "KryptonNavigator2")
        Me.KryptonNavigator2.Name = "KryptonNavigator2"
        Me.KryptonNavigator2.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.BarCheckButtonGroupInside
        Me.KryptonNavigator2.Pages.AddRange(New VelerSoftware.Design.Navigator.KryptonPage() {Me.TabONE_KryptonPage})
        Me.KryptonNavigator2.SelectedIndex = 0
        Me.KryptonNavigator2.StateCommon.HeaderGroup.Border.DrawBorders = VelerSoftware.Design.Toolkit.PaletteDrawBorders.None
        '
        'ButtonSpecNavigator1
        '
        resources.ApplyResources(Me.ButtonSpecNavigator1, "ButtonSpecNavigator1")
        Me.ButtonSpecNavigator1.Image = Global.SoftwareZator.My.Resources.Resources.Fonction
        Me.ButtonSpecNavigator1.ToolTipImage = Global.SoftwareZator.My.Resources.Resources.Fonction
        Me.ButtonSpecNavigator1.UniqueName = "EC62C1B2C0D34D0DA191834E74BDF028"
        '
        'TabONE_KryptonPage
        '
        Me.TabONE_KryptonPage.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.TabONE_KryptonPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.TabONE_KryptonPage.Flags = 65534
        resources.ApplyResources(Me.TabONE_KryptonPage, "TabONE_KryptonPage")
        Me.TabONE_KryptonPage.LastVisibleSet = True
        Me.TabONE_KryptonPage.MinimumSize = New System.Drawing.Size(50, 50)
        Me.TabONE_KryptonPage.Name = "TabONE_KryptonPage"
        Me.TabONE_KryptonPage.UniqueName = "TabONE"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'DocConcepteurFenetre
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "DocConcepteurFenetre"
        DirectCast(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        DirectCast(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator1.ResumeLayout(False)
        DirectCast(Me.Concepteur_Fenetre_KryptonPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Concepteur_Fenetre_KryptonPage.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        DirectCast(Me.Editeur_Fonction_KryptonPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Editeur_Fonction_KryptonPage.ResumeLayout(False)
        DirectCast(Me.KryptonNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator2.ResumeLayout(False)
        DirectCast(Me.TabONE_KryptonPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonNavigator1 As VelerSoftware.Design.Navigator.KryptonNavigator
    Friend WithEvents Concepteur_Fenetre_KryptonPage As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents Editeur_Fonction_KryptonPage As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents KryptonNavigator2 As VelerSoftware.Design.Navigator.KryptonNavigator
    Friend WithEvents TabONE_KryptonPage As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents RulerControl2 As VelerSoftware.SZC.RulerControl.RulerControl
    Friend WithEvents RulerControl1 As VelerSoftware.SZC.RulerControl.RulerControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents KryptonLinkLabel1 As VelerSoftware.Design.Toolkit.KryptonLinkLabel
    Friend WithEvents ButtonSpecNavigator1 As VelerSoftware.Design.Navigator.ButtonSpecNavigator

End Class
