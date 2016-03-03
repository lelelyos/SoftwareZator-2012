''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Public NotInheritable Class SplashScreen1

    'TODO: ce formulaire peut facilement être configuré comme écran de démarrage de l'application en accédant à l'onglet "Application"
    '  du Concepteur de projets ("Propriétés" sous le menu "Projet").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configurez le texte de la boîte de dialogue au moment de l'exécution en fonction des informations d'assembly de l'application.  

        'TODO: personnalisez les informations d'assembly de l'application dans le volet "Application" de la 
        '  boîte de dialogue Propriétés du projet (sous le menu "Projet").

        Me.ShowInTaskbar = VelerSoftware.SZVB.Windows.Core.RunningOnWin7Or8

        'Titre de l'application
        If My.Application.Info.Title <> "" Then
            'ApplicationTitle.Text = My.Application.Info.Title
        Else
            'Si le titre de l'application est absent, utilisez le nom de l'application, sans l'extension
            'ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Mettez en forme les informations de version à l'aide du texte défini dans le contrôle de version au moment du design en tant que
        '  chaîne de mise en forme. Ceci permet une localisation efficace si besoin est.
        '  Les informations de génération et de révision peuvent être incluses en utilisant le code suivant et en remplaçant le 
        '  texte du contrôle de version par "Version {0}.{1:00}.{2}.{3}" ou un équivalent. Voir
        '  String.Format() dans l'aide pour plus d'informations.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Dim beta_txt As String = ""
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\isbeta") AndAlso CBool(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\isbeta")) AndAlso My.Computer.FileSystem.FileExists(Application.StartupPath & "\Tools\betaversion") Then
            beta_txt = " Beta " & CInt(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Tools\betaversion"))
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.ToString & beta_txt)

        'Informations de copyright
        Copyright.Text = My.Application.Info.Copyright

        Me.Size = New System.Drawing.Size(700, 450)

    End Sub

End Class