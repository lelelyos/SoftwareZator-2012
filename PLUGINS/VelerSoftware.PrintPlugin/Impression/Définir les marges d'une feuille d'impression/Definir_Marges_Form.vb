Public Class Definir_Marges_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Designed As Designer = Nothing
    Private host As System.ComponentModel.Design.IDesignerHost = Nothing

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = False

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If Not aaa.Array Then
                    .Boutons_ComboBox.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If





            Dim my_PixelToCmRatioX As Single
            Dim my_PixelToCmRatioY As Single
            my_PixelToCmRatioX = 210 / 21.0F
            my_PixelToCmRatioY = 297 / 29.7F

            Designed = New Designer()
            Designed.BeginLoad(GetType(System.Windows.Forms.UserControl))
            If Not Designed.IsLoaded Then Throw New Exception("Le concepteur n'a pu être chargé") : Me.DialogResult = System.Windows.Forms.DialogResult.Cancel : Me.Close()

            DirectCast(Designed.View, System.Windows.Forms.Control).Dock = System.Windows.Forms.DockStyle.Fill
            DirectCast(Designed.View, System.Windows.Forms.Control).AllowDrop = True

            Me.Designer_Panel.Controls.Add(DirectCast(Designed.View, System.Windows.Forms.Control))

            host = DirectCast(Designed.GetService(GetType(System.ComponentModel.Design.IDesignerHost)), System.ComponentModel.Design.IDesignerHost)

            Dim Pane As ComponentModel.IComponent = host.CreateComponent(GetType(Windows.Forms.Panel))
            With DirectCast(Pane, System.Windows.Forms.Panel)
                .Location = New Drawing.Point(1 * my_PixelToCmRatioY, 1 * my_PixelToCmRatioX)
                .BorderStyle = Windows.Forms.BorderStyle.None
                .Size = New Drawing.Size(190, 277)
                .MaximumSize = New Drawing.Size(210, 297)
                .MinimumSize = New Drawing.Size(100, 100)
                .Name = "Marge_Panel"
                If Not Me.Param2 = Nothing Then
                    .Location = New Drawing.Point(CType(CInt(Me.Param2.Split(",")(1)) * my_PixelToCmRatioX, Int32), CType(CInt(Me.Param2.Split(",")(0)) * my_PixelToCmRatioY, Int32))
                    .Size = New Drawing.Size(210 - .Location.X - CType(CInt(Me.Param2.Split(",")(3)) * my_PixelToCmRatioX, Int32), 297 - .Location.Y - CType(CInt(Me.Param2.Split(",")(2)) * my_PixelToCmRatioY, Int32))
                End If
            End With

            With DirectCast(host.RootComponent, System.Windows.Forms.UserControl)
                .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                .BackColor = Drawing.SystemColors.Window
                .Location = New Drawing.Point((Me.Designer_Panel.Width / 2) - 105, (Me.Designer_Panel.Height / 2) - (297 / 2))
                .Size = New Drawing.Size(210, 297)
                .MaximumSize = New Drawing.Size(210, 297)
                .MinimumSize = New Drawing.Size(210, 297)
                .Controls.Add(DirectCast(Pane, System.Windows.Forms.Panel))
            End With

            Dim selectionService As System.ComponentModel.Design.ISelectionService = DirectCast(Designed.GetService(GetType(System.ComponentModel.Design.ISelectionService)), System.ComponentModel.Design.ISelectionService)
            AddHandler selectionService.SelectionChanged, AddressOf selectionService_SelectionChanged
            Dim i As New Generic.List(Of Windows.Forms.Panel)
            i.Add(host.Container.Components(1))
            selectionService.SetSelectedComponents(i)

            Dim viewService As ViewService = DirectCast(Designed.GetService(GetType(ViewService)), ViewService)
            viewService.View = DirectCast(Designed.View, Windows.Forms.Control)

            .Timer1.Start()

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text

            Dim my_PixelToCmRatioX As Single
            Dim my_PixelToCmRatioY As Single
            my_PixelToCmRatioX = 210 / 21.0F
            my_PixelToCmRatioY = 297 / 29.7F

            .Param2 = _
            CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Top / my_PixelToCmRatioY, Int32) & _
            "," & CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Left / my_PixelToCmRatioX, Int32) & _
            "," & CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Height - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Top + DirectCast(host.Container.Components(1), Windows.Forms.Control).Height)) / my_PixelToCmRatioY, Int32) & _
            "," & CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Width - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Left + DirectCast(host.Container.Components(1), Windows.Forms.Control).Width)) / my_PixelToCmRatioX, Int32)


            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim stat As String = Nothing

        Dim my_PixelToCmRatioX As Single
        Dim my_PixelToCmRatioY As Single
        my_PixelToCmRatioX = 210 / 21.0F
        my_PixelToCmRatioY = 297 / 29.7F

        stat = _
        CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Top / my_PixelToCmRatioY, Int32) & _
        "," & CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Left / my_PixelToCmRatioX, Int32) & _
        "," & CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Height - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Top + DirectCast(host.Container.Components(1), Windows.Forms.Control).Height)) / my_PixelToCmRatioY, Int32) & _
        "," & CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Width - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Left + DirectCast(host.Container.Components(1), Windows.Forms.Control).Width)) / my_PixelToCmRatioX, Int32)


        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromExpression(New CodeDom.CodeSnippetExpression(Me.Boutons_ComboBox.Text & ".setMargin(" & stat & ")"), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub selectionService_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim selectionService As System.ComponentModel.Design.ISelectionService = DirectCast(sender, System.ComponentModel.Design.ISelectionService)
        Dim i As New Generic.List(Of Windows.Forms.Panel)
        i.Add(host.Container.Components(1))

        selectionService.SetSelectedComponents(host.Container.Components(1))
        DirectCast(Designed.GetService(GetType(System.ComponentModel.Design.ISelectionService)), System.ComponentModel.Design.ISelectionService).SetSelectedComponents(i)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim my_PixelToCmRatioX As Single
        Dim my_PixelToCmRatioY As Single
        my_PixelToCmRatioX = 210 / 21.0F
        my_PixelToCmRatioY = 297 / 29.7000008F

        Dim t, b, l, r As Int32

        t = CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Top / my_PixelToCmRatioY, Int32)
        l = CType(DirectCast(host.Container.Components(1), Windows.Forms.Control).Left / my_PixelToCmRatioX, Int32)
        b = CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Height - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Top + DirectCast(host.Container.Components(1), Windows.Forms.Control).Height)) / my_PixelToCmRatioY, Int32)
        r = CType((DirectCast(host.Container.Components(0), Windows.Forms.Control).Width - (DirectCast(host.Container.Components(1), Windows.Forms.Control).Left + DirectCast(host.Container.Components(1), Windows.Forms.Control).Width)) / my_PixelToCmRatioX, Int32)


        Me.Label2.Text = "Top : " & t & "cm    Bottom : " & b & "cm    Left : " & l & "cm    Right : " & r & "cm"
    End Sub

End Class