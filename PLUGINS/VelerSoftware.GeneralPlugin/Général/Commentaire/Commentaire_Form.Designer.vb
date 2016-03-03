<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Commentaire_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Commentaire_Form))
        Me.Texte_Message_ActionTextBox = New VelerSoftware.Plugins3.ActionTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.Controls_Panel.Controls.Add(Me.Label1)
        Me.Controls_Panel.Controls.Add(Me.Texte_Message_ActionTextBox)
        resources.ApplyResources(Me.Controls_Panel, "Controls_Panel")
        '
        'Texte_Message_ActionTextBox
        '
        Me.Texte_Message_ActionTextBox.IsReadOnly = False
        resources.ApplyResources(Me.Texte_Message_ActionTextBox, "Texte_Message_ActionTextBox")
        Me.Texte_Message_ActionTextBox.Multiline = True
        Me.Texte_Message_ActionTextBox.Name = "Texte_Message_ActionTextBox"
        Me.Texte_Message_ActionTextBox.Tools = Nothing
        Me.Texte_Message_ActionTextBox.WordWrap = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Commentaire_Form
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Icon_Windows = Global.VelerSoftware.GeneralPlugin.My.Resources.Resources.comment
        Me.Name = "Commentaire_Form"
        Me.Title = "Commentaire"
        Me.Center_Panel.ResumeLayout(False)
        Me.Center_Panel.PerformLayout()
        Me.Controls_Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Texte_Message_ActionTextBox As VelerSoftware.Plugins3.ActionTextBox
End Class
