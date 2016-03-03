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
            Process.GetCurrentProcess().PriorityBoostEnabled = True


            Windows.Forms.Application.EnableVisualStyles()
            MinimumSplashScreenDisplayTime = 0
            Status_SZ = statu.Normal


            ' Détermine le système d'exploitation
            ' If VelerSoftware.SZVB.Windows.Core.RunningOnXP Then
            '     Global.SoftwareZator.SplashScreen1.Close()
            '     Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
            '     With vd
            '         .Owner = Nothing
            '         .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            '         .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityError
            '         .Content = Application.Info.Title & " isn't compatible with " & Computer.Info.OSFullName & ". Please uninstall " & Application.Info.Title & " and try again on a computer with Microsoft Windows Vista or Microsoft Windows 7."
            '         .MainInstruction = "Compatibility error"
            '         .WindowTitle = Application.Info.Title
            '         .Show()
            '     End With
            '     End
            ' End If

            ' SoftwareZator 2012.exe
            If Not Computer.FileSystem.FileExists(Application.Info.DirectoryPath & "\SoftwareZator 2012.exe") Then
                SplashScreen1.Close()
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityError
                    .Content = "The principal file is not found. Please reinstall " & Application.Info.Title & " and retry."
                    .MainInstruction = "Security error"
                    .WindowTitle = Application.Info.Title
                    .Show()
                End With
                End
            End If

            ' Licence
            If Not Computer.FileSystem.FileExists(Application.Info.DirectoryPath & "\Help\fr\Licence.rtf") OrElse Not Computer.FileSystem.FileExists(Application.Info.DirectoryPath & "\Help\en\Licence.rtf") Then
                SplashScreen1.Close()
                Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
                With vd
                    .Owner = Nothing
                    .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
                    .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.SecurityError
                    .Content = "The license file is not found. Please reinstall " & Application.Info.Title & " and retry."
                    .MainInstruction = "Security error"
                    .WindowTitle = Application.Info.Title
                    .Show()
                End With
                End
            End If

            ' Si la langue est neutre, alors c'est un premier démarrage
            If Settings.Langue = Nothing Then

                'If Computer.FileSystem.FileExists(Application.Info.DirectoryPath & "\license.lic") Then Computer.FileSystem.DeleteFile(Application.Info.DirectoryPath & "\license.lic", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                Using firstStart As New PremierDemarrage
#If CONFIG = "Release" Then
                    Global.SoftwareZator.SplashScreen1.Close()
#End If
                    If firstStart.ShowDialog() = DialogResult.OK Then
#If CONFIG = "Release" Then
                        Global.SoftwareZator.SplashScreen1.Show()
                        Global.SoftwareZator.SplashScreen1.CreateControl()
                        Global.SoftwareZator.SplashScreen1.Refresh()
#End If
                    Else
                        End
                    End If
                    firstStart.Dispose()
                End Using
            Else
                ' Sinon, on définit la langue
                If Settings.Langue = "fr" Then
                    Threading.Thread.CurrentThread.CurrentUICulture = FrenchCulture
                Else
                    Threading.Thread.CurrentThread.CurrentUICulture = EnglishCulture
                End If
            End If

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If


            Dim registration As Integer = 0
_registration:
            Try
                If Not Settings.Edition = ClassApplication.Edition.Free Then
                    If Not Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man") Then
                        Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man", 121, False)
                    End If
                    If Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man") Then
                        Nombre_Utilisation_Restante = CInt(Computer.FileSystem.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man")) - 1
                        If Nombre_Utilisation_Restante = -1 Then Nombre_Utilisation_Restante = 0
                        Computer.FileSystem.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man", Nombre_Utilisation_Restante, False)
                        Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").CreationTime = New Date(2009, 7, 14, 3, 39, 0)
                        Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").LastAccessTime = New Date(2009, 7, 14, 3, 39, 0)
                        Computer.FileSystem.GetFileInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) & "\s_timeregistration.man").LastWriteTime = New Date(2009, 7, 14, 3, 39, 0)
                    End If
                End If
            Catch ex As Exception
                Threading.Thread.Sleep(CInt(Int((3000 - 1000 + 1) * Rnd() + 1000)))
                If registration = 2 Then Throw ex
                registration += 1
                GoTo _registration
            End Try




            ' Définit la langue du logiciel dans VelerSoftware.SZVB
            VelerSoftware.SZVB.Variables.Langue = Settings.Langue
            VelerSoftware.SZC.Variables.Langue = Settings.Langue
            VelerSoftware.Plugins3.CurrentCulture = Threading.Thread.CurrentThread.CurrentUICulture

            ' Définit le dossier du logiciel
            VelerSoftware.SZVB.Variables.AppPath = Application.Info.DirectoryPath & "\"
            VelerSoftware.Plugins3.Other.AppPath = Application.Info.DirectoryPath & "\"

            ' Définir les otpion de spell checking
            VelerSoftware.SZC35.Variables.SpellCheck = Settings.Correcteur_Orthographe

            ' Définir l'édition du logiciel
            For Each ass As Reflection.Assembly In AppDomain.CurrentDomain.GetAssemblies()
                If ass.FullName.StartsWith("VelerSoftware.Plugins3,") AndAlso ass.GetType("VelerSoftware.Plugins3.Variables") IsNot Nothing Then
                    ass.GetType("VelerSoftware.Plugins3.Variables").GetProperty("SZ_Edition").SetValue(Nothing, Settings.Edition, Nothing)
                    Exit For
                End If
            Next

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If


            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf ClassApplication.LoadFromSameFolderResolveEventHandler



#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If

            ' Initialisation du moteur de génération de nombre aléatoire
            Microsoft.VisualBasic.Randomize()

            ' On initialise les mots clés interdit
            Mot_Cles_Interdit.AddRange(New String() {"error", "_manager", "_computer", "alias", "addhandler", "ainsi", "as", "assembly", "auto", "binary", "boolean", "byref", "byval", "case", "catch", "class", "click", "custom", "control", "double", "default", "dim", "directcast", "each", "else", "elseif", "end", "error", "event", "false", "finally", "float", "for", "friend", "global", "handles", "implements", "in", "integer", "is", "lib", "loop", "me", "module", "mustinherit", "mustoverride", "mybase", "myclass", "norrowing", "new", "next", "nothing", "notinheritable", "notoverridable", "of", "off", "on", "option", "optional", "overrides", "overloads", "overridable", "paramarray", "partial", "preserve", "private", "public", "protected", "raiseevent", "readonly", "resume", "scroll", "shadows", "shared", "single", "static", "step", "structure", "string", "text", "then", "to", "true", "trycast", "unicode", "until", "when", "while", "widening", "withevents", "writeonly", "date", "datetime"})

            ' On initialise les caractères interdit
            Caractères_Interdit.AddRange(New String() {"²", "&", "1", "2", "3", ChrW(34), "#", "4", "'", "{", "5", "(", "[", "6", "-", "|", "7", "8", "9", "^", "0", "@", "°", ")", "]", "+", "=", "}", "<", ">", "¨", "$", "£", "¤", "%", "*", "µ", ",", "?", ".", ";", ":", "/", "!", "§", "-"})
            Caractères_Interdit_Non_Numerique.AddRange(New String() {"²", "&", ChrW(34), "#", "'", "{", "(", "[", "-", "|", "^", "@", "°", ")", "]", "+", "=", "}", "<", ">", "¨", "$", "£", "¤", "%", "*", "µ", ",", "?", ".", ";", ":", "/", "!", "§", "-"})


            ' On récupère les arguments de lancement
            For Each arg As String In From arg1 In e.CommandLine Where Computer.FileSystem.FileExists(arg1) AndAlso (Computer.FileSystem.GetFileInfo(arg1).Extension.ToLower = ".szproj" OrElse Computer.FileSystem.GetFileInfo(arg1).Extension.ToLower = ".szsl" OrElse Computer.FileSystem.GetFileInfo(arg1).Extension.ToLower = ".szstat")
                ArgumentOuverture = arg
                Exit For
            Next

#If CONFIG = "Release" Then
            If SplashScreen1.IsHandleCreated Then SplashScreen1.ProgressBar1.PerformStep()
#End If
        End Sub

#If CONFIG = "Release" Then
        Private Shadows Sub UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles MyBase.UnhandledException
            Using frm As New Erreur
                frm.TextBox1.Text = Application.Info.Title & " (" & Application.Info.Version.ToString() & ")" & Environment.NewLine
                Select Case Settings.Edition
                    Case ClassApplication.Edition.Free
                        frm.TextBox1.Text &= "Edition : Free" & Environment.NewLine & Environment.NewLine
                    Case ClassApplication.Edition.Standard
                        frm.TextBox1.Text &= "Edition : Standard" & Environment.NewLine & Environment.NewLine
                    Case ClassApplication.Edition.Education
                        frm.TextBox1.Text &= "Edition : Education" & Environment.NewLine & Environment.NewLine
                    Case ClassApplication.Edition.Professional
                        frm.TextBox1.Text &= "Edition : Professional" & Environment.NewLine & Environment.NewLine
                End Select

                frm.TextBox1.Text &= "Computer informations :" & Environment.NewLine
                frm.TextBox1.Text &= "Language : " & Computer.Info.InstalledUICulture.EnglishName & " (" & Computer.Info.InstalledUICulture.Name & ")" & Environment.NewLine
                frm.TextBox1.Text &= "Operating System Full Name : " & Computer.Info.OSFullName & Environment.NewLine
                frm.TextBox1.Text &= "Operating System Platform : " & Computer.Info.OSPlatform & Environment.NewLine
                frm.TextBox1.Text &= "Operating System Version : " & Computer.Info.OSVersion & Environment.NewLine
                frm.TextBox1.Text &= "Is 64 Bit Operating System : " & System.Environment.Is64BitOperatingSystem & Environment.NewLine
                frm.TextBox1.Text &= "Is 64 Bit Process : " & System.Environment.Is64BitProcess & Environment.NewLine
                frm.TextBox1.Text &= "Processor Count : " & System.Environment.ProcessorCount & Environment.NewLine
                frm.TextBox1.Text &= "User Interactive : " & System.Environment.UserInteractive & Environment.NewLine
                frm.TextBox1.Text &= ".Net Framework Version : " & VelerSoftware.SZVB.Windows.Core.GetFrameworkVersion() & Environment.NewLine & Environment.NewLine

                frm.TextBox1.Text &= "Exception Message : " & e.Exception.Message & Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Exception Help Link : " & e.Exception.HelpLink & Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Exception Source : " & Environment.NewLine & Environment.NewLine & e.Exception.Source & Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Exception Stack Trace : " & Environment.NewLine & Environment.NewLine & e.Exception.StackTrace & Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Exception Target Site : " & Environment.NewLine & Environment.NewLine & e.Exception.TargetSite.ReflectedType.FullName & "." & e.Exception.TargetSite.Name & Environment.NewLine & Environment.NewLine

                If e.Exception.Data.Count > 0 Then
                    frm.TextBox1.Text &= "Datas :" & Environment.NewLine & Environment.NewLine
                    For Each dat As DictionaryEntry In e.Exception.Data
                        frm.TextBox1.Text &= "Key : " & dat.Key.ToString() & " ----- Value : " & dat.Value.ToString() & Environment.NewLine
                    Next
                    frm.TextBox1.Text &= Environment.NewLine
                End If


                frm.TextBox1.Text &= Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Log SZ :" & Environment.NewLine
                For Each lo As ClassLog.LogType In Log_SZ.Log
                    frm.TextBox1.Text &= lo.InfoType.ToString & " : " & lo.Texte & Environment.NewLine
                Next

                frm.TextBox1.Text &= Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Log Project :" & Environment.NewLine
                For Each lo As ClassLog.LogType In Log_Projet.Log
                    frm.TextBox1.Text &= lo.InfoType.ToString & " : " & lo.Texte & Environment.NewLine
                Next

                frm.TextBox1.Text &= Environment.NewLine & Environment.NewLine
                frm.TextBox1.Text &= "Log Generation :" & Environment.NewLine
                For Each lo As ClassLog.LogType In Log_Generation.Log
                    frm.TextBox1.Text &= lo.InfoType.ToString & " : " & lo.Texte & Environment.NewLine
                Next

                If frm.ShowDialog = DialogResult.Cancel Then
                    e.ExitApplication = True
                Else
                    e.ExitApplication = False
                End If
            End Using

        End Sub
#End If

        Private Shadows Sub NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles MyBase.NetworkAvailabilityChanged
            If e.IsNetworkAvailable Then

                If Not Form1.SZ_Banned_User_BackgroundWorker.IsBusy Then Form1.SZ_Banned_User_BackgroundWorker.RunWorkerAsync()

                If Not Form1.SZ_Activation_BackgroundWorker.IsBusy Then Form1.SZ_Activation_BackgroundWorker.RunWorkerAsync()

                If Settings.Autoriser_Envoyer_Informations AndAlso Not Form1.SZ_Send_Informations_BackgroundWorker.IsBusy AndAlso CBool(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Certificated")) = False AndAlso (30 - DateDiff(DateInterval.Day, CDate(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("CertificateDate")), Now)) < 0 Then
                    Dim key As Microsoft.Win32.RegistryKey
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True)
                    key.SetValue("Certificated", True)
                    Form1.SZ_Send_Informations_BackgroundWorker.RunWorkerAsync(New DictionaryEntry("users", Computer.Info.OSFullName & Environment.NewLine & "Id : " & Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Veler Software\SoftwareZator", True).GetValue("Id")))
                End If

            End If
        End Sub

    End Class


End Namespace

