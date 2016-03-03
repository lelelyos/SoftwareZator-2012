''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace Projet

    ' PROJET
    Public Class Projet

        ' INITIALISATION
        Public Sub New()
            Nom = "Untitled"

            Type = Types.ApplicationWindows
            ShutMode = ShutModes.AfterMainFormCloses
            ObfuscationLevel = ObfuscationLevels.Normal
            Cpu = Cpus.AnyCpu
        End Sub

        Public Sub New(ByVal Name As String)
            Nom = Name

            Type = Types.ApplicationWindows
            ShutMode = ShutModes.AfterMainFormCloses
            ObfuscationLevel = ObfuscationLevels.Normal
            Cpu = Cpus.AnyCpu
        End Sub

        Public Sub New(ByVal Name As String, ByVal Fichier As String)
            Nom = Name
            Emplacement = My.Computer.FileSystem.GetParentPath(Fichier)
            Nom_Fichier_Projet = My.Computer.FileSystem.GetName(Fichier)

            Type = Types.ApplicationWindows
            ShutMode = ShutModes.AfterMainFormCloses
            ObfuscationLevel = ObfuscationLevels.Normal
            Cpu = Cpus.AnyCpu
        End Sub


        ' TYPES
        Enum Types
            ApplicationWindows
            BibliothequeFonctions
            ApplicationConsole
        End Enum

        ' CPU
        Enum Cpus
            x86
            x64
            AnyCpu
        End Enum

        ' Niveau d'obfuscation
        Enum ObfuscationLevels
            Low
            Normal
            High
        End Enum

        ' Mode d'arrêt
        Enum ShutModes
            AfterMainFormCloses
            AfterAllFormsClose
        End Enum



        ' VARIABLES
        Public Property Variables As New Generic.List(Of Variable)

        ' REFERENCES
        Public Property References As New Generic.List(Of Reference)

        ' RESSOURCES
        Public Property Ressources As New Generic.List(Of Ressource)

        ' STATISTIQUES
        Public Property Statistiques As New Generic.List(Of Statistique)

        ' PARAMETRES
        Public Property Parametres As New Generic.List(Of String)

        ' FICHIERS VB.NET
        Public Property Fichiers_VBNet As New Generic.List(Of String)

        ' DOCUMENTS OUVERTS
        Public Property Doc_Ouverts As New Generic.List(Of String)

        ' NOM DU RPOJET
        Public Property Nom As String

        ' NOM DU FICHIER DE PROJET
        Public Property Nom_Fichier_Projet As String

        ' DETERMINE SI LE PROJET EST CORRECTEMENT CHARGER
        Public Property Loaded As Boolean

        ' TYPE DE PROJET
        Public Property Type As Types

        ' MODE D'ARRET
        Public Property ShutMode As ShutModes

        ' NIVEAU D'OBFUSCATION
        Public Property ObfuscationLevel As ObfuscationLevels

        ' FENETRE DE DEMARRAGE
        Public Property FormStart As String

        ' ECRAN DE DEMARRAGE
        Public Property SplashScreen As String

        ' STYLE XP
        Public Property StyleXP As Boolean

        ' INSTANCE UNIQUE
        Public Property Instance As Boolean

        ' ENREGISTRER PARAMETRES
        Public Property MySettings As Boolean

        Public Property Assembly_Title As String

        Public Property Assembly_Description As String

        Public Property Assembly_Socity As String

        Public Property Assembly_Product As String

        Public Property Assembly_Copyright As String

        Public Property Assembly_FileVersion As String

        Public Property Assembly_AssemblyVersion As String

        Public Property Assembly_Mark As String

        Public Property Assembly_Guid As String

        Public Property GenerateDirectory As String

        Public Property Optimize As Boolean

        Public Property Cpu As Cpus

        Public Property Emplacement As String

        Public Property ShouldCompileRelease As Boolean

        Public Property RapportGeneration As New Text.StringBuilder

        Public Property VBGénéréParGénération As String

    End Class

End Namespace