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
Partial Class DocPageDeDemarrage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocPageDeDemarrage))
        Me.kryptonPanel = New VelerSoftware.Design.Toolkit.KryptonPanel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonListBox2 = New VelerSoftware.Design.Toolkit.KryptonListBox()
        Me.KryptonLinkLabel1 = New VelerSoftware.Design.Toolkit.KryptonLinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonNavigator1 = New VelerSoftware.Design.Navigator.KryptonNavigator()
        Me.KryptonPage1 = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.KryptonPage2 = New VelerSoftware.Design.Navigator.KryptonPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.KryptonLabel1 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.KryptonBorderEdge2 = New VelerSoftware.Design.Toolkit.KryptonBorderEdge()
        Me.KryptonButton2 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.KryptonBorderEdge1 = New VelerSoftware.Design.Toolkit.KryptonBorderEdge()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kryptonPanel.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator1.SuspendLayout()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kryptonPanel
        '
        resources.ApplyResources(Me.kryptonPanel, "kryptonPanel")
        Me.kryptonPanel.Controls.Add(Me.PictureBox3)
        Me.kryptonPanel.Controls.Add(Me.PictureBox2)
        Me.kryptonPanel.Controls.Add(Me.TableLayoutPanel1)
        Me.kryptonPanel.Controls.Add(Me.Label1)
        Me.kryptonPanel.Controls.Add(Me.KryptonNavigator1)
        Me.kryptonPanel.Controls.Add(Me.KryptonLabel1)
        Me.kryptonPanel.Controls.Add(Me.KryptonBorderEdge2)
        Me.kryptonPanel.Controls.Add(Me.KryptonButton2)
        Me.kryptonPanel.Controls.Add(Me.KryptonButton1)
        Me.kryptonPanel.Controls.Add(Me.KryptonBorderEdge1)
        Me.kryptonPanel.Controls.Add(Me.PictureBox1)
        Me.kryptonPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.kryptonPanel.Name = "kryptonPanel"
        Me.kryptonPanel.PanelBackStyle = VelerSoftware.Design.Toolkit.PaletteBackStyle.ControlClient
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global.SoftwareZator.My.Resources.Resources.twitter
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, resources.GetString("PictureBox3.ToolTip"))
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.SoftwareZator.My.Resources.Resources.facebook
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, resources.GetString("PictureBox2.ToolTip"))
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonListBox2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.KryptonLinkLabel1, 0, 1)
        Me.TableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'KryptonListBox2
        '
        Me.KryptonListBox2.BorderStyle = VelerSoftware.Design.Toolkit.PaletteBorderStyle.TabLowProfile
        Me.KryptonListBox2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonListBox2, "KryptonListBox2")
        Me.KryptonListBox2.Name = "KryptonListBox2"
        '
        'KryptonLinkLabel1
        '
        resources.ApplyResources(Me.KryptonLinkLabel1, "KryptonLinkLabel1")
        Me.KryptonLinkLabel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonLinkLabel1.LinkBehavior = VelerSoftware.Design.Toolkit.KryptonLinkBehavior.HoverUnderline
        Me.KryptonLinkLabel1.Name = "KryptonLinkLabel1"
        Me.KryptonLinkLabel1.Values.Text = resources.GetString("KryptonLinkLabel1.Values.Text")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Name = "Label1"
        '
        'KryptonNavigator1
        '
        Me.KryptonNavigator1.AllowPageReorder = False
        resources.ApplyResources(Me.KryptonNavigator1, "KryptonNavigator1")
        Me.KryptonNavigator1.Button.CloseButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator1.Button.ContextButtonDisplay = VelerSoftware.Design.Navigator.ButtonDisplay.Hide
        Me.KryptonNavigator1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonNavigator1.MinimumSize = New System.Drawing.Size(250, 100)
        Me.KryptonNavigator1.Name = "KryptonNavigator1"
        Me.KryptonNavigator1.NavigatorMode = VelerSoftware.Design.Navigator.NavigatorMode.BarCheckButtonGroupInside
        Me.KryptonNavigator1.Pages.AddRange(New VelerSoftware.Design.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2})
        Me.KryptonNavigator1.SelectedIndex = 0
        Me.KryptonNavigator1.StateCommon.BorderEdge.Color1 = System.Drawing.Color.White
        Me.KryptonNavigator1.StateCommon.BorderEdge.Color2 = System.Drawing.Color.White
        Me.KryptonNavigator1.StateCommon.BorderEdge.ColorAngle = 0.0!
        Me.KryptonNavigator1.StateCommon.BorderEdge.Width = 0
        Me.KryptonNavigator1.StateCommon.HeaderGroup.Border.ColorAngle = 0.0!
        Me.KryptonNavigator1.StateCommon.HeaderGroup.Border.DrawBorders = VelerSoftware.Design.Toolkit.PaletteDrawBorders.None
        Me.KryptonNavigator1.StateCommon.HeaderGroup.Border.Rounding = 0
        Me.KryptonNavigator1.StateCommon.HeaderGroup.Border.Width = 0
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.KryptonPage1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonPage1.Flags = 65534
        resources.ApplyResources(Me.KryptonPage1, "KryptonPage1")
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.UniqueName = "EB78C7DCA1084D310D9A1DC8BC597EEB"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.WebBrowser1)
        Me.KryptonPage2.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonPage2.Flags = 65534
        resources.ApplyResources(Me.KryptonPage2, "KryptonPage2")
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.UniqueName = "F9DF5D5E632B4D4A488FF8227403D384"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.AllowNavigation = False
        Me.WebBrowser1.AllowWebBrowserDrop = False
        resources.ApplyResources(Me.WebBrowser1, "WebBrowser1")
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel1, "KryptonLabel1")
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Values.Text = resources.GetString("KryptonLabel1.Values.Text")
        '
        'KryptonBorderEdge2
        '
        resources.ApplyResources(Me.KryptonBorderEdge2, "KryptonBorderEdge2")
        Me.KryptonBorderEdge2.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonBorderEdge2.Name = "KryptonBorderEdge2"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonButton2, "KryptonButton2")
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.ToolTip1.SetToolTip(Me.KryptonButton2, resources.GetString("KryptonButton2.ToolTip"))
        Me.KryptonButton2.Values.Text = resources.GetString("KryptonButton2.Values.Text")
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.ToolTip1.SetToolTip(Me.KryptonButton1, resources.GetString("KryptonButton1.ToolTip"))
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'KryptonBorderEdge1
        '
        resources.ApplyResources(Me.KryptonBorderEdge1, "KryptonBorderEdge1")
        Me.KryptonBorderEdge1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonBorderEdge1.Name = "KryptonBorderEdge1"
        Me.KryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Vertical
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.SoftwareZator.My.Resources.Resources.Header
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Error_VistaDialog.png")
        Me.ImageList1.Images.SetKeyName(1, "Information.png")
        Me.ImageList1.Images.SetKeyName(2, "Nouveau Projet.png")
        Me.ImageList1.Images.SetKeyName(3, "Ouvrir Projet.png")
        Me.ImageList1.Images.SetKeyName(4, "Security.png")
        Me.ImageList1.Images.SetKeyName(5, "SecurityError.png")
        Me.ImageList1.Images.SetKeyName(6, "SecurityQuestion.png")
        Me.ImageList1.Images.SetKeyName(7, "SecuritySuccess.png")
        Me.ImageList1.Images.SetKeyName(8, "SecurityWarning.png")
        '
        'DocPageDeDemarrage
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kryptonPanel)
        Me.Name = "DocPageDeDemarrage"
        CType(Me.kryptonPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kryptonPanel.ResumeLayout(False)
        Me.kryptonPanel.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator1.ResumeLayout(False)
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage1.ResumeLayout(False)
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents kryptonPanel As VelerSoftware.Design.Toolkit.KryptonPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents KryptonBorderEdge1 As VelerSoftware.Design.Toolkit.KryptonBorderEdge
    Friend WithEvents KryptonNavigator1 As VelerSoftware.Design.Navigator.KryptonNavigator
    Friend WithEvents KryptonPage1 As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As VelerSoftware.Design.Navigator.KryptonPage
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents KryptonButton2 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents KryptonLabel1 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents KryptonBorderEdge2 As VelerSoftware.Design.Toolkit.KryptonBorderEdge
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents KryptonLinkLabel1 As VelerSoftware.Design.Toolkit.KryptonLinkLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonListBox2 As VelerSoftware.Design.Toolkit.KryptonListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox

End Class
