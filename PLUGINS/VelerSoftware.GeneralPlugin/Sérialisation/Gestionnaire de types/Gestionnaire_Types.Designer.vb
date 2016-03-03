<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gestionnaire_Types
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gestionnaire_Types))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = DirectCast(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = DirectCast(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Center_Panel.Controls.Add(Me.Supprimer_Button)
        Me.Center_Panel.Controls.Add(Me.Modifier_Button)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Controls.Add(Me.Ajouter_Button)
        Me.Center_Panel.Controls.Add(Me.ListView1)
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.AllowDrop = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1})
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
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
        'Ajouter_Button
        '
        resources.ApplyResources(Me.Ajouter_Button, "Ajouter_Button")
        Me.Ajouter_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Ajouter_Button.Name = "Ajouter_Button"
        Me.Ajouter_Button.UseVisualStyleBackColor = True
        '
        'Modifier_Button
        '
        resources.ApplyResources(Me.Modifier_Button, "Modifier_Button")
        Me.Modifier_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Modifier_Button.Name = "Modifier_Button"
        Me.Modifier_Button.UseVisualStyleBackColor = True
        '
        'Supprimer_Button
        '
        resources.ApplyResources(Me.Supprimer_Button, "Supprimer_Button")
        Me.Supprimer_Button.Cursor = System.Windows.Forms.Cursors.Default
        Me.Supprimer_Button.Name = "Supprimer_Button"
        Me.Supprimer_Button.UseVisualStyleBackColor = True
        '
        'Gestionnaire_Types
        '
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.HelpButton = True
        Me.Name = "Gestionnaire_Types"
        Me.OKButtonText = "OK"
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
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
