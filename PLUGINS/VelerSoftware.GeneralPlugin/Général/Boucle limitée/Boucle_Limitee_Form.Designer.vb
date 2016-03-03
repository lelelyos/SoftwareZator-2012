<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Boucle_Limitee_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Boucle_Limitee_Form))
        Me.Variable_Depart_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Constante_Valeur_Depart_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Variable_Valeur_Depart_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Constante_Valeur_Depart_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Variable_Valeur_Depart_RadioButton = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Variable_Valeur_Arrivee_ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Constante_Valeur_Arrivee_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Constante_Valeur_Arrivee_NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Variable_Valeur_Arrivee_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Variable_Valeur_Pas_ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Constante_Valeur_Pas_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Constante_Valeur_Pas_NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Variable_Valeur_Pas_RadioButton = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        CType(Me.Constante_Valeur_Depart_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.Constante_Valeur_Arrivee_NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.Constante_Valeur_Pas_NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls_Panel.Controls.Add(Me.Label4)
        Me.Controls_Panel.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls_Panel.Controls.Add(Me.Label3)
        Me.Controls_Panel.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls_Panel.Controls.Add(Me.Variable_Depart_ComboBox)
        Me.Controls_Panel.Controls.Add(Me.Label2)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Variable_Depart_ComboBox
        '
        Me.Variable_Depart_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.Variable_Depart_ComboBox, "Variable_Depart_ComboBox")
        Me.Variable_Depart_ComboBox.FormattingEnabled = True
        Me.Variable_Depart_ComboBox.Name = "Variable_Depart_ComboBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Constante_Valeur_Depart_NumericUpDown
        '
        resources.ApplyResources(Me.Constante_Valeur_Depart_NumericUpDown, "Constante_Valeur_Depart_NumericUpDown")
        Me.Constante_Valeur_Depart_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Constante_Valeur_Depart_NumericUpDown.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.Constante_Valeur_Depart_NumericUpDown.Name = "Constante_Valeur_Depart_NumericUpDown"
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.Variable_Valeur_Depart_ComboBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Constante_Valeur_Depart_RadioButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Constante_Valeur_Depart_NumericUpDown, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Variable_Valeur_Depart_RadioButton, 0, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'Variable_Valeur_Depart_ComboBox
        '
        resources.ApplyResources(Me.Variable_Valeur_Depart_ComboBox, "Variable_Valeur_Depart_ComboBox")
        Me.Variable_Valeur_Depart_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Variable_Valeur_Depart_ComboBox.FormattingEnabled = True
        Me.Variable_Valeur_Depart_ComboBox.Name = "Variable_Valeur_Depart_ComboBox"
        '
        'Constante_Valeur_Depart_RadioButton
        '
        resources.ApplyResources(Me.Constante_Valeur_Depart_RadioButton, "Constante_Valeur_Depart_RadioButton")
        Me.Constante_Valeur_Depart_RadioButton.Checked = True
        Me.Constante_Valeur_Depart_RadioButton.Name = "Constante_Valeur_Depart_RadioButton"
        Me.Constante_Valeur_Depart_RadioButton.TabStop = True
        Me.Constante_Valeur_Depart_RadioButton.UseVisualStyleBackColor = True
        '
        'Variable_Valeur_Depart_RadioButton
        '
        resources.ApplyResources(Me.Variable_Valeur_Depart_RadioButton, "Variable_Valeur_Depart_RadioButton")
        Me.Variable_Valeur_Depart_RadioButton.Name = "Variable_Valeur_Depart_RadioButton"
        Me.Variable_Valeur_Depart_RadioButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.Variable_Valeur_Arrivee_ComboBox1, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Constante_Valeur_Arrivee_RadioButton, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Constante_Valeur_Arrivee_NumericUpDown1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Variable_Valeur_Arrivee_RadioButton, 0, 1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'Variable_Valeur_Arrivee_ComboBox1
        '
        resources.ApplyResources(Me.Variable_Valeur_Arrivee_ComboBox1, "Variable_Valeur_Arrivee_ComboBox1")
        Me.Variable_Valeur_Arrivee_ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Variable_Valeur_Arrivee_ComboBox1.FormattingEnabled = True
        Me.Variable_Valeur_Arrivee_ComboBox1.Name = "Variable_Valeur_Arrivee_ComboBox1"
        '
        'Constante_Valeur_Arrivee_RadioButton
        '
        resources.ApplyResources(Me.Constante_Valeur_Arrivee_RadioButton, "Constante_Valeur_Arrivee_RadioButton")
        Me.Constante_Valeur_Arrivee_RadioButton.Name = "Constante_Valeur_Arrivee_RadioButton"
        Me.Constante_Valeur_Arrivee_RadioButton.UseVisualStyleBackColor = True
        '
        'Constante_Valeur_Arrivee_NumericUpDown1
        '
        resources.ApplyResources(Me.Constante_Valeur_Arrivee_NumericUpDown1, "Constante_Valeur_Arrivee_NumericUpDown1")
        Me.Constante_Valeur_Arrivee_NumericUpDown1.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Constante_Valeur_Arrivee_NumericUpDown1.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.Constante_Valeur_Arrivee_NumericUpDown1.Name = "Constante_Valeur_Arrivee_NumericUpDown1"
        '
        'Variable_Valeur_Arrivee_RadioButton
        '
        resources.ApplyResources(Me.Variable_Valeur_Arrivee_RadioButton, "Variable_Valeur_Arrivee_RadioButton")
        Me.Variable_Valeur_Arrivee_RadioButton.Checked = True
        Me.Variable_Valeur_Arrivee_RadioButton.Name = "Variable_Valeur_Arrivee_RadioButton"
        Me.Variable_Valeur_Arrivee_RadioButton.TabStop = True
        Me.Variable_Valeur_Arrivee_RadioButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.Variable_Valeur_Pas_ComboBox2, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Constante_Valeur_Pas_RadioButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Constante_Valeur_Pas_NumericUpDown2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Variable_Valeur_Pas_RadioButton, 0, 1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'Variable_Valeur_Pas_ComboBox2
        '
        resources.ApplyResources(Me.Variable_Valeur_Pas_ComboBox2, "Variable_Valeur_Pas_ComboBox2")
        Me.Variable_Valeur_Pas_ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Variable_Valeur_Pas_ComboBox2.FormattingEnabled = True
        Me.Variable_Valeur_Pas_ComboBox2.Name = "Variable_Valeur_Pas_ComboBox2"
        '
        'Constante_Valeur_Pas_RadioButton
        '
        resources.ApplyResources(Me.Constante_Valeur_Pas_RadioButton, "Constante_Valeur_Pas_RadioButton")
        Me.Constante_Valeur_Pas_RadioButton.Checked = True
        Me.Constante_Valeur_Pas_RadioButton.Name = "Constante_Valeur_Pas_RadioButton"
        Me.Constante_Valeur_Pas_RadioButton.TabStop = True
        Me.Constante_Valeur_Pas_RadioButton.UseVisualStyleBackColor = True
        '
        'Constante_Valeur_Pas_NumericUpDown2
        '
        resources.ApplyResources(Me.Constante_Valeur_Pas_NumericUpDown2, "Constante_Valeur_Pas_NumericUpDown2")
        Me.Constante_Valeur_Pas_NumericUpDown2.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Constante_Valeur_Pas_NumericUpDown2.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
        Me.Constante_Valeur_Pas_NumericUpDown2.Name = "Constante_Valeur_Pas_NumericUpDown2"
        Me.Constante_Valeur_Pas_NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Variable_Valeur_Pas_RadioButton
        '
        resources.ApplyResources(Me.Variable_Valeur_Pas_RadioButton, "Variable_Valeur_Pas_RadioButton")
        Me.Variable_Valeur_Pas_RadioButton.Name = "Variable_Valeur_Pas_RadioButton"
        Me.Variable_Valeur_Pas_RadioButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Boucle_Limitee_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.boucle
        Me.Name = "Boucle_Limitee_Form"
        Me.Title = "Boucle limitée"
        Me.Center_Panel.ResumeLayout(False)
        Me.Controls_Panel.ResumeLayout(False)
        CType(Me.Constante_Valeur_Depart_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.Constante_Valeur_Arrivee_NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.Constante_Valeur_Pas_NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Variable_Depart_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Variable_Valeur_Depart_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Constante_Valeur_Depart_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Constante_Valeur_Depart_NumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Variable_Valeur_Depart_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Variable_Valeur_Arrivee_ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Constante_Valeur_Arrivee_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Constante_Valeur_Arrivee_NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Variable_Valeur_Arrivee_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Variable_Valeur_Pas_ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Constante_Valeur_Pas_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Constante_Valeur_Pas_NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Variable_Valeur_Pas_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
