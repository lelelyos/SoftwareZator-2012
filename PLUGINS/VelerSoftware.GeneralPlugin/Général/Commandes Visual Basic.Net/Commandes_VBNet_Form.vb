Public Class Commandes_VBNet_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False
            .RefreshCode_Button_Visible = False
            .ShowHideCodeEditor_Button_Visible = False

            .ValueEdit1.VariablesButtonVisible = False

            .ValueEdit1.Tools = .Tools

            .ValueEdit1.SetGeneratedCode(" ")

            If Not .Param1 = Nothing Then
                .ValueEdit1.SetGeneratedCode(.Param1)
            End If
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            .Param1 = .ValueEdit1.GetGeneratedCode()

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class