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
Partial Class Gestionnaire_Variables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gestionnaire_Variables))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Ajouter_Button = New System.Windows.Forms.Button()
        Me.Modifier_Button = New System.Windows.Forms.Button()
        Me.Supprimer_Button = New System.Windows.Forms.Button()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        Me.Center_Panel.Controls.Add(Me.Supprimer_Button)
        Me.Center_Panel.Controls.Add(Me.Modifier_Button)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.Ajouter_Button)
        Me.Center_Panel.Controls.Add(Me.ListView1)
        Me.ToolTip1.SetToolTip(Me.Center_Panel, resources.GetString("Center_Panel.ToolTip"))
        '
        'Foot_Panel
        '
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        Me.ToolTip1.SetToolTip(Me.Foot_Panel, resources.GetString("Foot_Panel.ToolTip"))
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.ToolTip1.SetToolTip(Me.Cancel_Button, resources.GetString("Cancel_Button.ToolTip"))
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.ToolTip1.SetToolTip(Me.OK_Button, resources.GetString("OK_Button.ToolTip"))
        '
        'ListView1
        '
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.AllowDrop = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("ListView1.Groups"), System.Windows.Forms.ListViewGroup)})
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ToolTip1.SetToolTip(Me.ListView1, resources.GetString("ListView1.ToolTip"))
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'ColumnHeader5
        '
        resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
        '
        'ColumnHeader6
        '
        resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
        '
        'ColumnHeader7
        '
        resources.ApplyResources(Me.ColumnHeader7, "ColumnHeader7")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Ajouter_Button
        '
        resources.ApplyResources(Me.Ajouter_Button, "Ajouter_Button")
        Me.Ajouter_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ajouter_Button.Image = Global.SoftwareZator.My.Resources.Resources.var_ajouter
        Me.Ajouter_Button.Name = "Ajouter_Button"
        Me.ToolTip1.SetToolTip(Me.Ajouter_Button, resources.GetString("Ajouter_Button.ToolTip"))
        Me.Ajouter_Button.UseVisualStyleBackColor = True
        '
        'Modifier_Button
        '
        resources.ApplyResources(Me.Modifier_Button, "Modifier_Button")
        Me.Modifier_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Modifier_Button.Image = Global.SoftwareZator.My.Resources.Resources.var_modifier
        Me.Modifier_Button.Name = "Modifier_Button"
        Me.ToolTip1.SetToolTip(Me.Modifier_Button, resources.GetString("Modifier_Button.ToolTip"))
        Me.Modifier_Button.UseVisualStyleBackColor = True
        '
        'Supprimer_Button
        '
        resources.ApplyResources(Me.Supprimer_Button, "Supprimer_Button")
        Me.Supprimer_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Supprimer_Button.Image = Global.SoftwareZator.My.Resources.Resources.var_supprimer
        Me.Supprimer_Button.Name = "Supprimer_Button"
        Me.ToolTip1.SetToolTip(Me.Supprimer_Button, resources.GetString("Supprimer_Button.ToolTip"))
        Me.Supprimer_Button.UseVisualStyleBackColor = True
        '
        'Gestionnaire_Variables
        '
        resources.ApplyResources(Me, "$this")
        Me.CancelButtonText = "Annuler"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.HelpButton = True
        Me.Name = "Gestionnaire_Variables"
        Me.OKButtonText = "OK"
        Me.ToolTip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Ajouter_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Supprimer_Button As System.Windows.Forms.Button
    Friend WithEvents Modifier_Button As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader

End Class
