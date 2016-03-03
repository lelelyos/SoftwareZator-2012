''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Module Variables

    Enum statu
        Normal
        Generation_En_Cours_Release
        Generation_En_Cours_Debug
        Debuggage_En_Cours
        Correction_Erreurs_En_Cours
    End Enum

    Enum generation_type
        Release
        Debug
    End Enum

    Public Status_SZ As statu

    Public Nombre_Utilisation_Restante As Integer = 0
    Public SZ_Est_Activé As Boolean = False
    Public SZ_Est_En_Version_Demo As Boolean = False

    ' En cours de génération
    Public Generation_En_Cours_Projet As VelerSoftware.SZVB.Projet.Projet
    Public Generation_En_Cours_Type As generation_type

    ' Obfuscation
    <CLSCompliant(False)> Public ldConfusions As New Dictionary(Of String, VelerSoftware.SZC.Obfuscator.Confuser.Core.IConfusion)()
    <CLSCompliant(False)> Public ldPackers As New Dictionary(Of String, VelerSoftware.SZC.Obfuscator.Confuser.Core.Packer)()

    ' Mots clés interdit
    Public Mot_Cles_Interdit As New Generic.List(Of String)

    ' Caractères interdit
    Public Caractères_Interdit As New Generic.List(Of String)
    Public Caractères_Interdit_Non_Numerique As New Generic.List(Of String)

    ' SOLTUION
    Public SOLUTION As VelerSoftware.SZVB.Projet.Solution

    ' PLUGINS
    Public PLUGINS As New Generic.List(Of ClassPluginServices.Plugin)
    Public Plugins_Has_Been_Loaded As Boolean

    ' Argument d'ouverture de SoftwareZator
    Public ArgumentOuverture As String

    ' Langues
    Public EnglishCulture As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en")
    Public FrenchCulture As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("fr")
    Public RM As System.Resources.ResourceManager = Nothing
    Public RM_Log As System.Resources.ResourceManager = Nothing

    ' Fenêtre Ajouter_Reference
    Public Add_Reference As Ajouter_Reference


    ' Log
    Public WithEvents Log_Generation As New ClassLog
    Public WithEvents Log_Projet As New ClassLog
    Public WithEvents Log_SZ As New ClassLog

End Module
