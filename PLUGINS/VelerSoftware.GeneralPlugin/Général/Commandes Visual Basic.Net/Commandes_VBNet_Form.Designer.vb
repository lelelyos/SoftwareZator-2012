<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Commandes_VBNet_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Commandes_VBNet_Form))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ValueEdit1 = New VelerSoftware.Plugins3.ValueEdit()
        Me.Center_Panel.SuspendLayout()
        Me.Controls_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Center_Panel
        '
        resources.ApplyResources(Me.Center_Panel, "Center_Panel")
        '
        'Controls_Panel
        '
        Me.Controls_Panel.Controls.Add(Me.ValueEdit1)
        Me.Controls_Panel.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ValueEdit1
        '
        Me.ValueEdit1.BackColor = System.Drawing.Color.Transparent
        Me.ValueEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ValueEdit1.ColorButtonVisible = False
        Me.ValueEdit1.Editor = VelerSoftware.Plugins3.ValueEdit.ValueType.VBNet
        resources.ApplyResources(Me.ValueEdit1, "ValueEdit1")
        Me.ValueEdit1.Name = "ValueEdit1"
        Me.ValueEdit1.NumberButtonVisible = False
        Me.ValueEdit1.OtherButtonVisible = False
        Me.ValueEdit1.ResourcesButtonVisible = False
        Me.ValueEdit1.TextButtonVisible = False
        Me.ValueEdit1.Tools = Nothing
        Me.ValueEdit1.TrueFalseButtonVisible = False
        Me.ValueEdit1.VariablesButtonVisible = False
        Me.ValueEdit1.VBNetButtonVisible = True
        '
        'Commandes_VBNet_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.commandes_vb
        Me.Name = "Commandes_VBNet_Form"
        Me.ShowHideCodeEditor_Button_Visible = False
        Me.Title = "Commandes Visual Basic.Net"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ValueEdit1 As VelerSoftware.Plugins3.ValueEdit
End Class
