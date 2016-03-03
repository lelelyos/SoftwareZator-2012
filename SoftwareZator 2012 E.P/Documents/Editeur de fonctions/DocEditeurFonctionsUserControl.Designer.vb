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
Partial Class DocEditeurFonctionsUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocEditeurFonctionsUserControl))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.KryptonLinkLabel1 = New VelerSoftware.Design.Toolkit.KryptonLinkLabel()
        Me.KryptonButton1 = New VelerSoftware.Design.Toolkit.KryptonButton()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.KryptonLinkLabel1)
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
        'KryptonButton1
        '
        resources.ApplyResources(Me.KryptonButton1, "KryptonButton1")
        Me.KryptonButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.ToolTip1.SetToolTip(Me.KryptonButton1, resources.GetString("KryptonButton1.ToolTip"))
        Me.KryptonButton1.Values.Text = resources.GetString("KryptonButton1.Values.Text")
        '
        'ElementHost1
        '
        Me.ElementHost1.BackColorTransparent = True
        Me.ElementHost1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.ElementHost1, "ElementHost1")
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'DocEditeurFonctionsUserControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.ElementHost1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "DocEditeurFonctionsUserControl"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents KryptonLinkLabel1 As VelerSoftware.Design.Toolkit.KryptonLinkLabel
    Friend WithEvents KryptonButton1 As VelerSoftware.Design.Toolkit.KryptonButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
