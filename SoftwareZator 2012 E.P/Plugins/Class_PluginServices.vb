''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Reflection

Public Class ClassPluginServices

    Public Structure Plugin
        Public PluginName As String
        Public PluginVersion As String
        <CLSCompliant(False)> Public Actions As Generic.List(Of VelerSoftware.Plugins3.Action)
        Public [Assembly] As System.Reflection.Assembly
    End Structure

    Public Shared Function LoadPlugins() As Generic.List(Of Plugin)
        Dim Resultat As New Generic.List(Of Plugin)
        Dim Plug As Plugin
        Dim objDLL As [Assembly]
        Dim objType As Type
        Dim objInterface As Type
        Dim objAction As VelerSoftware.Plugins3.Action
        Dim Nom As String

        For Each Fichier As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Plugins\", FileIO.SearchOption.SearchAllSubDirectories, "*.dll")
            Nom = My.Computer.FileSystem.GetName(Fichier)
            If (My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard) AndAlso (Nom = "VelerSoftware.AccessPlugin.dll" OrElse Nom = "VelerSoftware.MySQLPlugin.dll" OrElse Nom = "VelerSoftware.PrintPlugin.dll" OrElse Nom = "VelerSoftware.SQLServerPlugin.dll" OrElse Nom = "VelerSoftware.FTPPlugin.dll" OrElse Nom = "VelerSoftware.ExcelPlugin.dll" OrElse Nom = "VelerSoftware.SerialPortPlugin.dll") Then GoTo _ignore
            If (My.Settings.Edition = ClassApplication.Edition.Free) AndAlso (Nom = "VelerSoftware.VoiceRecognitionPlugin.dll") Then GoTo _ignore
            If (My.Settings.Edition = ClassApplication.Edition.Education) AndAlso (Nom = "VelerSoftware.FTPPlugin.dll" OrElse Nom = "VelerSoftware.ExcelPlugin.dll") Then GoTo _ignore
            Try
                objDLL = [Assembly].LoadFrom(Fichier)
                If Not objDLL Is Nothing Then
                    Nom = objDLL.GetName.Name
                    If (My.Settings.Edition = ClassApplication.Edition.Free OrElse My.Settings.Edition = ClassApplication.Edition.Standard) AndAlso (Nom = "VelerSoftware.MySQLPlugin" OrElse Nom = "VelerSoftware.SQLServerPlugin" OrElse Nom = "VelerSoftware.PrintPlugin" OrElse Nom = "VelerSoftware.AccessPlugin" OrElse Nom = "VelerSoftware.FTPPlugin" OrElse Nom = "VelerSoftware.ExcelPlugin" OrElse Nom = "VelerSoftware.SerialPortPlugin.dll") Then GoTo _ignore
                    If (My.Settings.Edition = ClassApplication.Edition.Free) AndAlso (Nom = "VelerSoftware.VoiceRecognitionPlugin") Then GoTo _ignore
                    If (My.Settings.Edition = ClassApplication.Edition.Education) AndAlso (Nom = "VelerSoftware.FTPPlugin" OrElse Nom = "VelerSoftware.ExcelPlugin") Then GoTo _ignore
                    Plug = New Plugin
                    With Plug
                        .Actions = New Generic.List(Of VelerSoftware.Plugins3.Action)
                        .PluginName = Nom
                        .PluginVersion = objDLL.GetName.Version.ToString
                        .Assembly = objDLL
                        For Each objType In objDLL.GetTypes
                            If objType.IsSubclassOf(GetType(VelerSoftware.Plugins3.Action)) AndAlso objType.IsPublic AndAlso Not ((objType.Attributes And System.Reflection.TypeAttributes.Abstract) = System.Reflection.TypeAttributes.Abstract) Then
                                objAction = DirectCast(.Assembly.CreateInstance(objType.FullName), VelerSoftware.Plugins3.Action)
                                If Not .Actions.Contains(objAction) Then .Actions.Add(objAction)
                            End If
                        Next
                    End With
                    If Plug.Actions.Count > 0 Then
                        Resultat.Add(Plug)
                    Else
                        Plug.Assembly = Nothing
                        Plug.Actions = Nothing
                        Plug = Nothing
                    End If
                End If
            Catch e As Exception
                MsgBox("Assembly (may be a plugin) '" & My.Computer.FileSystem.GetName(Fichier) & "' has met an error. This plugin has not be load. Please report the next error : " & Environment.NewLine & e.Message & Environment.NewLine & e.Source & Environment.NewLine & e.StackTrace)
                'Error loading DLL, we don't need to do anything special
            End Try
_ignore:
        Next

        Plug = Nothing
        objDLL = Nothing
        objType = Nothing
        objInterface = Nothing
        objAction = Nothing

        Plugins_Has_Been_Loaded = True

        Return Resultat
    End Function

End Class
