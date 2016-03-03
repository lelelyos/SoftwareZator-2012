Public Class Declarer_Propriete_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .Texte_Message_ActionTextBox.Text = ""

            If Not .Param1 = Nothing Then .Texte_Message_ActionTextBox.Text = .Param1

            .ParseCode_Button_Visible = False
            .ShowHideCodeEditor_Button_Visible = False
        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            With Me.Texte_Message_ActionTextBox
                If .Text IsNot Nothing Then
                    If .Text.Contains(".") _
                      OrElse .Text.Contains("?") _
                      OrElse .Text.Contains(",") _
                      OrElse .Text.Contains(";") _
                      OrElse .Text.Contains(":") _
                      OrElse .Text.Contains("/") _
                      OrElse .Text.Contains("!") _
                      OrElse .Text.Contains("§") _
                      OrElse .Text.Contains("-") _
                      OrElse .Text.Contains("&") _
                      OrElse .Text.Contains("²") _
                      OrElse .Text.Contains("^") _
                      OrElse .Text.Contains("*") _
                      OrElse .Text.Contains("%") _
                      OrElse .Text.Contains(" ") _
                      Then
                        MsgBox(RM.GetString("Caractere_Non_valide"), MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
            End With

            .Param1 = .Texte_Message_ActionTextBox.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class