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
Partial Class NouvelleTable
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NouvelleTable))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nom_KryptonTextBox1 = New VelerSoftware.Design.Toolkit.KryptonTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Noms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Types = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Foot_Panel.SuspendLayout()
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        DirectCast(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        Me.Center_Panel.Controls.Add(Me.Label2)
        Me.Center_Panel.Controls.Add(Me.DataGridView1)
        Me.Center_Panel.Controls.Add(Me.Nom_KryptonTextBox1)
        Me.Center_Panel.Controls.Add(Me.Label3)
        Me.Center_Panel.Controls.Add(Me.Label1)
        Me.Center_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Foot_Panel
        '
        Me.Foot_Panel.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Foot_Panel, "Foot_Panel")
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        '
        'OK_Button
        '
        Me.OK_Button.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Name = "Label1"
        '
        'Nom_KryptonTextBox1
        '
        resources.ApplyResources(Me.Nom_KryptonTextBox1, "Nom_KryptonTextBox1")
        Me.Nom_KryptonTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Nom_KryptonTextBox1.Name = "Nom_KryptonTextBox1"
        Me.ToolTip1.SetToolTip(Me.Nom_KryptonTextBox1, resources.GetString("Nom_KryptonTextBox1.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Name = "Label3"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'DataGridView1
        '
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Noms, Me.Types})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        '
        'Noms
        '
        Me.Noms.FillWeight = 170.0!
        resources.ApplyResources(Me.Noms, "Noms")
        Me.Noms.Name = "Noms"
        '
        'Types
        '
        Me.Types.FillWeight = 150.0!
        Me.Types.FlatStyle = System.Windows.Forms.FlatStyle.System
        resources.ApplyResources(Me.Types, "Types")
        Me.Types.Items.AddRange(New Object() {"BIGINT", "BINARY", "BIT", "CHAR", "DATE", "DATETIME", "DATETIME2", "DATETIMEOFFSET", "DECIMAL", "FLOAT", "GEOGRAPHY", "GEOMETRY", "HIERARCHYID", "IMAGE", "MONEY", "NCHAR", "NTEXT", "NUMERIC", "NVARCHAR", "REAL", "SMALLDATETIME", "SMALLINT", "SMALLMONEY", "SQL_VARIANT", "TEXT", "TIME", "TIMESTAMP", "TINYINT", "UDT", "UNIQUEIDENTIFER", "VARBINARY", "VARCHAR", "XML"})
        Me.Types.Name = "Types"
        Me.Types.Sorted = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Name = "Label2"
        '
        'NouvelleTable
        '
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.CancelButtonText = "Annuler"
        resources.ApplyResources(Me, "$this")
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.HelpButton = True
        Me.Name = "NouvelleTable"
        Me.OKButtonText = "OK"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Foot_Panel.ResumeLayout(False)
        DirectCast(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        DirectCast(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nom_KryptonTextBox1 As VelerSoftware.Design.Toolkit.KryptonTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Noms As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Types As System.Windows.Forms.DataGridViewComboBoxColumn

End Class
