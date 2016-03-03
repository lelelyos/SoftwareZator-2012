''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace My

    ' Les événements suivants sont disponibles pour MyApplication :
    ' 
    ' Startup : déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : déclenché après la fermeture de tous les formulaires de l'application. Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : déclenché lorsque la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication

        Private Shadows Sub StartUp(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles MyBase.Startup
            Me.MinimumSplashScreenDisplayTime = 0

            ' .NET
            If CInt(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Install", Nothing)) = 0 Then
                System.Windows.Forms.MessageBox.Show("The Microsoft .Net Framework v4.0 isn't installed on your computer. SoftwareZator can't run properly without. Please download and install the Microsoft .Net Framework v4.0 and try again.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                System.Diagnostics.Process.Start("http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=9cfb2d51-5ff4-4491-b0e5-b386f32c0992")
                End
            End If

            ' Détermine le système d'exploitation
            '  If (Not VelerSoftware.SZVB.Windows.Core.RunningOnVista) AndAlso (Not VelerSoftware.SZVB.Windows.Core.RunningOnWin7) Then
            '      Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            '      With vd
            '          .Owner = Nothing
            '          .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            '          .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityError
            '          .Content = My.Application.Info.Title & " isn't compatible with " & My.Computer.Info.OSFullName & ". Please uninstall " & My.Application.Info.Title & " and try again on a computer with Microsoft Windows Vista or Microsoft Windows 7."
            '          .MainInstruction = "Compatibility error"
            '          .WindowTitle = My.Application.Info.Title
            '          .Show()
            '      End With
            '      End
            '  End If

            ' Si la langue est neutre, alors c'est un premier démarrage
            If My.Settings.Langue = Nothing Then
                Using First_Start As New PremierDemarrage
                    First_Start.ShowDialog()
                    First_Start.Dispose()
                End Using
            Else
                ' Sinon, on définit la langue
                If My.Settings.Langue = "fr" Then
                    System.Threading.Thread.CurrentThread.CurrentUICulture = FrenchCulture
                Else
                    System.Threading.Thread.CurrentThread.CurrentUICulture = EnglishCulture
                End If
            End If


            ' Définit la langue du logiciel dans VelerSoftware.SZVB
            VelerSoftware.SZVB.Variables.Langue = My.Settings.Langue

            ' Définit le dossier du logiciel
            VelerSoftware.SZVB.Variables.AppPath = My.Application.Info.DirectoryPath & "\"

            ' On récupère les arguments de lancement
            Dim debug As Boolean
            For Each arg As String In e.CommandLine
                debug = arg.Contains("#debug")
                arg = arg.Replace("#debug", Nothing)
                If arg.ToLower.EndsWith(".html") OrElse arg.ToLower.EndsWith(".php") OrElse arg.ToLower.EndsWith(".asp") OrElse arg.ToLower.EndsWith(".aspx") Then
                    If debug Then
                        ArgumentOuverture = arg & "#debug"
                    Else
                        ArgumentOuverture = arg
                    End If
                    Exit For
                End If
            Next
        End Sub

        Private Shadows Sub StartUpInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles MyBase.StartupNextInstance
            Dim debug As Boolean
            For Each arg As String In e.CommandLine
                debug = arg.Contains("#debug")
                arg = arg.Replace("#debug", Nothing)
                If arg.ToLower.EndsWith(".html") OrElse arg.ToLower.EndsWith(".php") OrElse arg.ToLower.EndsWith(".asp") OrElse arg.ToLower.EndsWith(".aspx") Then
                    If debug Then
                        ArgumentOuverture = arg & "#debug"
                    Else
                        ArgumentOuverture = arg
                    End If
                    Try : Form1.KryptonDockingManager1.AddToWorkspace("Workspace", New VelerSoftware.Design.Navigator.KryptonPage() {Form1.Workspace_Nouveau_Page_De_Demarrage(ArgumentOuverture)}) : Catch : End Try
                    If ClassApplication.Determiner_Si_Document_Deja_Ouvert("Document " & DocNum) Then
                        Dim pag As VelerSoftware.Design.Navigator.KryptonPage = Form1.KryptonDockableWorkspace1.PageForUniqueName("Document " & DocNum)
                        If Not pag Is Nothing Then
                            Dim cell As VelerSoftware.Design.Workspace.KryptonWorkspaceCell = Form1.KryptonDockableWorkspace1.CellForPage(pag)
                            Form1.KryptonDockableWorkspace1.ActiveCell = cell
                            cell.SelectedPage = pag
                        End If
                    End If
                    Exit For
                End If
            Next

            Form1.BringToFront()
            Form1.Activate()
            Form1.Focus()
            e.BringToForeground = True
        End Sub

        'Private Shadows Sub UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles MyBase.UnhandledException
        '
        '    e.ExitApplication = False
        'Dim txt As String = "Rapport d'erreur de " & Application.Info.Title & " (" & Application.Info.Version.ToString & ")" & Environment.NewLine & _
        ' "" & My.Computer.Info.OSFullName & " " & My.Computer.Info.OSVersion & Environment.NewLine & _
        ' "" & Environment.NewLine & _
        ' "" & e.Exception.Message & Environment.NewLine & _
        ' "" & Environment.NewLine & _
        ' "" & e.Exception.Source & Environment.NewLine & _
        ' "" & Environment.NewLine & _
        ' "" & e.Exception.StackTrace & Environment.NewLine & _
        ' "" & Environment.NewLine & _
        ' "" & e.Exception.TargetSite.Name
        '
        '   Dim frm As New BUG
        '    frm.TextBox1.Text = txt
        '    frm.ShowDialog()
        '    frm.Dispose()
        '
        'End Sub


    End Class


End Namespace

