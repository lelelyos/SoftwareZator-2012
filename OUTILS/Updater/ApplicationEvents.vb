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

            If System.Globalization.CultureInfo.InstalledUICulture.Name.StartsWith("fr") Then
                System.Threading.Thread.CurrentThread.CurrentUICulture = FrenchCulture
            Else
                System.Threading.Thread.CurrentThread.CurrentUICulture = EnglishCulture
            End If

            For Each arg As String In e.CommandLine
                If arg = "-silent" Then Mode_Silence = True
            Next
        End Sub

    End Class


End Namespace

