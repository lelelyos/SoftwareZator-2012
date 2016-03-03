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
Partial Class DocConcepteurFenetreErreurs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocConcepteurFenetreErreurs))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.KryptonLabel1 = New VelerSoftware.Design.Toolkit.KryptonLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KryptonListBox1 = New VelerSoftware.Design.Toolkit.KryptonListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Image = Global.SoftwareZator.My.Resources.Resources.error_Big
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.KryptonLabel1, "KryptonLabel1")
        Me.KryptonLabel1.LabelStyle = VelerSoftware.Design.Toolkit.LabelStyle.TitleControl
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Values.Text = resources.GetString("KryptonLabel1.Values.Text")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.AutoEllipsis = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label1.Name = "Label1"
        '
        'KryptonButton1
        '
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.ToolTip1.SetToolTip(Me.KryptonButton1, resources.GetString("KryptonButton1.ToolTip"))
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label2.Name = "Label2"
        '
        'KryptonListBox1
        '
        resources.ApplyResources(Me.KryptonListBox1, "KryptonListBox1")
        Me.KryptonListBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonListBox1.Name = "KryptonListBox1"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'DocConcepteurFenetreErreurs
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.KryptonListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.KryptonButton1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.KryptonLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "DocConcepteurFenetreErreurs"
        DirectCast(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents KryptonLabel1 As VelerSoftware.Design.Toolkit.KryptonLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents KryptonListBox1 As VelerSoftware.Design.Toolkit.KryptonListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
