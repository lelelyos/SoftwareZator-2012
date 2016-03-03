Public Class Ajouter_Types

    Private Sub Gestionnaire_Variables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VelerSoftware.SZC.Windows.User32.SetWindowTheme(Me.ListView1.Handle, "explorer", Nothing)
        VelerSoftware.SZC.Windows.User32.SendMessage(Me.ListView1.Handle, 4096 + 54, 65536, 65536)

        Me.CancelButtonText = RM.GetString("CancelButtonText")
    End Sub


    Private Sub Nom_KryptonTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nom_KryptonTextBox1.KeyPress
        Select Case e.KeyChar
            Case ChrW(Windows.Forms.Keys.Space)
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Private Sub Ajouter_Variables_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Ajouter_Variables_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        If (DirectCast(Me.Owner, Gestionnaire_Types).ListView1.Items.IndexOfKey(Me.Nom_KryptonTextBox1.Text) = -1) Then
            Me.Nom_KryptonTextBox1.Text = Me.Nom_KryptonTextBox1.Text.Replace(" ", Nothing)
            If Not Me.Nom_KryptonTextBox1.Text.Trim(" ") = Nothing Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                    .Content = RM.GetString("Content14")
                    .MainInstruction = RM.GetString("MainInstruction11")
                    .WindowTitle = My.Application.Info.Title
                    .Show()
                End With
            End If
        Else
            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            With vd
                .Owner = Nothing
                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Warning
                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content15"), Me.Nom_KryptonTextBox1.Text)
                .MainInstruction = RM.GetString("MainInstruction11")
                .WindowTitle = My.Application.Info.Title
                .Show()
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.ListView1.SelectedItems.Clear()
        Dim ite As New System.Windows.Forms.ListViewItem
        ite.Selected = True
        Dim i As Integer = 1
        ite.Text = "New_Property" & i
        ite.Name = ite.Text
        Do
            If Me.ListView1.Items.ContainsKey(ite.Text) Then
                i += 1
                ite.Text = "New_Property" & i
                ite.Name = ite.Text
            Else
                ite.Text = "New_Property" & i
                ite.Name = ite.Text
                Exit Do
            End If
        Loop
        Me.ListView1.Items.Add(ite)
        ite.BeginEdit()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Me.ListView1.SelectedIndices.Count > 0 Then
            For Each a As System.Windows.Forms.ListViewItem In Me.ListView1.SelectedItems
                a.Remove()
            Next
        End If
    End Sub


    Private Sub ListView3_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        With e
            If Not .Label = Nothing Then
                If .Label.Contains("?") OrElse _
                .Label.Contains(",") OrElse _
                .Label.Contains(":") OrElse _
                .Label.Contains("/") OrElse _
                .Label.Contains("!") OrElse _
                .Label.Contains("§") OrElse _
                .Label.Contains("|") OrElse _
                .Label.Contains("-") OrElse _
                .Label.Contains("&") OrElse _
                .Label.Contains("#") OrElse _
                .Label.Contains("'") OrElse _
                .Label.Contains("{") OrElse _
                .Label.Contains("(") OrElse _
                .Label.Contains("[") OrElse _
                .Label.Contains("\") OrElse _
                .Label.Contains("ç") OrElse _
                .Label.Contains("^") OrElse _
                .Label.Contains(")") OrElse _
                .Label.Contains("@") OrElse _
                .Label.Contains("]") OrElse _
                .Label.Contains("=") OrElse _
                .Label.Contains("+") OrElse _
                .Label.Contains("}") OrElse _
                .Label.Contains("$") OrElse _
                .Label.Contains("£") OrElse _
                .Label.Contains("¤") OrElse _
                .Label.Contains("ù") OrElse _
                .Label.Contains("%") OrElse _
                .Label.Contains("*") OrElse _
                .Label.Contains("µ") OrElse _
                .Label.Contains("<") OrElse _
                .Label.Contains(">") OrElse _
                .Label.Contains(".") OrElse _
                .Label.Contains(";") OrElse _
                .Label.Contains(" ") Then
                    Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                    With vd
                        .Owner = Nothing
                        .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                        .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                        .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content8"))
                        .MainInstruction = RM.GetString("MainInstruction11")
                        .WindowTitle = My.Application.Info.Title
                        .Show()
                    End With
                    .CancelEdit = True
                Else
                    For Each ite As Windows.Forms.ListViewItem In Me.ListView1.Items
                        If ite.Text = .Label AndAlso Not ite.Index = .Item Then
                            Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                            With vd
                                .Owner = Nothing
                                .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                                .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Error
                                .Content = String.Format(System.Globalization.CultureInfo.InvariantCulture, RM.GetString("Content9"), e.Label)
                                .MainInstruction = RM.GetString("MainInstruction11")
                                .WindowTitle = My.Application.Info.Title
                                .Show()
                            End With
                            .CancelEdit = True
                            Exit For
                        End If
                    Next
                End If

                If Not .CancelEdit Then
                    If .Label.StartsWith("0") OrElse .Label.StartsWith("1") OrElse .Label.StartsWith("2") OrElse .Label.StartsWith("3") OrElse .Label.StartsWith("4") OrElse .Label.StartsWith("5") OrElse .Label.StartsWith("6") OrElse .Label.StartsWith("7") OrElse .Label.StartsWith("8") OrElse .Label.StartsWith("9") Then
                        Me.ListView1.Items(.Item).Name = "_" & .Label
                    Else
                        Me.ListView1.Items(.Item).Name = .Label
                    End If
                End If
            Else
                .CancelEdit = True
            End If
        End With
    End Sub

End Class
