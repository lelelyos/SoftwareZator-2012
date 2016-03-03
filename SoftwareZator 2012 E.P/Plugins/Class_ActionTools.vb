''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ClassActionTools
    Implements VelerSoftware.Plugins3.Tools

#Region "Current Project Properties"

    Public Function GetCurrentProjectVariableList() As System.Collections.Generic.List(Of VelerSoftware.SZVB.Projet.Variable) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectVariableList
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Variables
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Variables
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Variables
            Else
                Return New Generic.List(Of VelerSoftware.SZVB.Projet.Variable)
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectType() As VelerSoftware.SZVB.Projet.Projet.Types Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectType
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Type
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Type
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Type
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectName() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectName
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Nom
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Nom
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Nom
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectAssemblyVersion() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectAssemblyVersion
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_AssemblyVersion
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_AssemblyVersion
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_AssemblyVersion
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectCopyright() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectCopyright
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Copyright
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Copyright
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Copyright
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectDescription() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectDescription
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Description
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Description
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Description
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectFileVersion() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectFileVersion
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_FileVersion
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_FileVersion
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_FileVersion
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectGuid() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectGuid
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Guid
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Guid
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Guid
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectMark() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectMark
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Mark
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Mark
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Mark
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectProduct() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectProduct
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Product
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Product
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Product
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectSocity() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectSocity
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Socity
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Socity
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Socity
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectTitle() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectTitle
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Assembly_Title
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Assembly_Title
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Assembly_Title
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectCPU() As VelerSoftware.SZVB.Projet.Projet.Cpus Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectCPU
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Cpu
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Cpu
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Cpu
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectObfuscationLevel() As VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectObfuscationLevel
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).ObfuscationLevel
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).ObfuscationLevel
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.ObfuscationLevel
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectPath() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectPath
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Emplacement
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Emplacement
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.Emplacement
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectVBNetFiles() As Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectVBNetFiles
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Fichiers_VBNet
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Fichiers_VBNet
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Fichiers_VBNet
            Else
                Return New Generic.List(Of String)
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectFormStart() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectFormStart
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).FormStart
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).FormStart
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.FormStart
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectGenerateDirectory() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectGenerateDirectory
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).GenerateDirectory
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).GenerateDirectory
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.GenerateDirectory
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectInstance() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectInstance
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Instance
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Instance
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Instance
            Else
                Return False
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectSaveMySettings() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectSaveMySettings
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).MySettings
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).MySettings
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.MySettings
            Else
                Return False
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectOptimize() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectOptimize
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Optimize
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Optimize
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Optimize
            Else
                Return False
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectUseStyleXP() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectUseStyleXP
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).StyleXP
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).StyleXP
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.StyleXP
            Else
                Return False
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectSettings() As Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectSettings
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Parametres
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Parametres
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Parametres
            Else
                Return New Generic.List(Of String)
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectSplashScreen() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectSplashScreen
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).SplashScreen
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).SplashScreen
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.SplashScreen
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectShutMode() As VelerSoftware.SZVB.Projet.Projet.ShutModes Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectShutMode
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).ShutMode
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).ShutMode
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then Return Generation_En_Cours_Projet.ShutMode
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectResoucres() As Generic.List(Of VelerSoftware.SZVB.Projet.Ressource) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectResoucres
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).Ressources
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).Ressources
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.Ressources
            Else
                Return New Generic.List(Of VelerSoftware.SZVB.Projet.Ressource)
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentProjectReferences() As Generic.List(Of VelerSoftware.SZVB.Projet.Reference) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectReferences
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).References
                End If
            End If
        Else
            If Generation_En_Cours_Projet IsNot Nothing Then
                Return Generation_En_Cours_Projet.References
            Else
                Return New Generic.List(Of VelerSoftware.SZVB.Projet.Reference)
            End If
        End If
        Return Nothing
    End Function

    Public Function AddVBNetFileToCurrentProject(ByVal File_Name As String) As Boolean Implements VelerSoftware.Plugins3.Tools.AddVBNetFileToCurrentProject
        Dim Resultat As Boolean

        If My.Computer.FileSystem.FileExists(File_Name) Then
            Resultat = True
            Dim path As String = ClassFichier.Ouvrir_Fichier(Me.GetCurrentProjectPath, File_Name)
            Dim nom_proj As String = Me.GetCurrentProjectName
            Dim ite As New ListViewItem

            If Me.GetCurrentProjectVBNetFiles().Contains(path) Then Resultat = False
            If Resultat Then
                SOLUTION.GetProject(nom_proj).Fichiers_VBNet.Add(path)
                If Status_SZ = statu.Normal Then
                    For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                        If page.Controls.Count > 0 Then
                            If TypeOf page.Controls(0) Is DocParametresDuProjet AndAlso DirectCast(page.Controls(0), DocParametresDuProjet).Nom_Projet = nom_proj Then
                                ite = New ListViewItem
                                ite.Text = path
                                ite.Name = path
                                With DirectCast(page.Controls(0), DocParametresDuProjet)
                                    .ListView4.Items.Add(ite)
                                    .DocumentModifier()
                                End With
                            ElseIf page.Controls.Count > 0 AndAlso TypeOf page.Controls(0) Is DocStatistiques AndAlso DirectCast(page.Controls(0), DocStatistiques).Nom_Projet = nom_proj Then
                                ite = New ListViewItem
                                ite.Text = path
                                ite.Name = path
                                DirectCast(page.Controls(0), DocStatistiques).VB_ListView4.Items.Add(ite)
                            End If
                        End If
                    Next
                End If
            End If
        End If

        Return Resultat
    End Function

#End Region

#Region "Solution"

    Public Function GetProjectsName() As System.Collections.Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetProjectsName
        Dim resultat As New Generic.List(Of String)
        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
            If proj IsNot Nothing AndAlso proj.Loaded Then resultat.Add(proj.Nom)
        Next
        Return resultat
    End Function

    Public Function GetSolutionVariableList() As System.Collections.Generic.List(Of VelerSoftware.SZVB.Projet.Variable) Implements VelerSoftware.Plugins3.Tools.GetSolutionVariableList
        Dim resultat As New Generic.List(Of VelerSoftware.SZVB.Projet.Variable)
        For Each proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets
            If proj IsNot Nothing AndAlso proj.Loaded Then resultat.AddRange(proj.Variables)
        Next
        Return resultat
    End Function

#End Region

#Region "Current Project Windows Controls"

    Private GetCurrentProjectWindowsControls_List As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)
    Private GetCurrentProjectWindowsControls_StopWatch As New Stopwatch

    <CLSCompliant(False)>
    Public Function GetCurrentProjectWindowsControls() As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectWindowsControls
        With GetCurrentProjectWindowsControls_StopWatch
            If .IsRunning Then
                .Stop()
                If .ElapsedMilliseconds < 15000 Then
                    .Start()
                    Return GetCurrentProjectWindowsControls_List
                    Exit Function
                End If
            ElseIf GetCurrentProjectWindowsControls_List IsNot Nothing Then
                .Reset()
                .Start()
                Return GetCurrentProjectWindowsControls_List
                Exit Function
            End If
            ' Déclenchement du "chronomètre"
            .Reset()
            .Start()
        End With

        Dim Resultat As New Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)
        Dim Proj As VelerSoftware.SZVB.Projet.Projet = Nothing
        Dim NomDocActuel, codedomtypemember_Name As String
        NomDocActuel = Nothing
        codedomtypemember_Name = Nothing
        Dim oki As Boolean
        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File

        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                End If
            End If
        Else
            Proj = Generation_En_Cours_Projet
        End If

        If Proj IsNot Nothing AndAlso Proj.Loaded Then
            For Each a As String In My.Computer.FileSystem.GetFiles(Proj.Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                    Tmp_SZW_File = Nothing
                    oki = True
                    If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso (NomDocActuel = a) Then
                        oki = False
                        With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre)
                            If Not .Erreur_Chargement_Concepteur_Fenetre Then
                                Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File(.Designer.ComponentContainer.Components(0).Site.Name)
                                Tmp_SZW_File.WINDOWS = .CodeDomHostLoader.GetCodeCompileUnit
                            Else
                                Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File()
                            End If
                        End With
                    End If
                    If oki Then Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(a)
                    If Tmp_SZW_File IsNot Nothing Then
                        If a = NomDocActuel Then
                            Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object("Me", Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0), GetType(System.CodeDom.CodeTypeDeclaration)))
                            For Each codedomtypemember As CodeDom.CodeTypeMember In Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).Members
                                codedomtypemember_Name = codedomtypemember.Name
                                Select Case codedomtypemember_Name
                                    Case ".ctor", "Dispose", "components", "Main", "InitializeComponent"
                                    Case Else
                                        Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object("Me." & codedomtypemember_Name, codedomtypemember, codedomtypemember.GetType))
                                End Select
                            Next
                        Else
                            Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object(Tmp_SZW_File.Nom, Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0), GetType(System.CodeDom.CodeTypeDeclaration)))
                            For Each codedomtypemember As CodeDom.CodeTypeMember In Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).Members
                                codedomtypemember_Name = codedomtypemember.Name
                                Select Case codedomtypemember_Name
                                    Case ".ctor", "Dispose", "components", "Main", "InitializeComponent"
                                    Case Else
                                        Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object(Tmp_SZW_File.Nom & "." & codedomtypemember_Name, codedomtypemember, codedomtypemember.GetType))
                                End Select
                            Next
                        End If
                    End If
                End If
            Next
        End If

        GetCurrentProjectWindowsControls_List = Resultat
        Return Resultat
    End Function

#End Region

#Region "Current Project Windows"

    Private GetCurrentProjectWindows_List As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)
    Private GetCurrentProjectWindows_StopWatch As New Stopwatch

    <CLSCompliant(False)>
    Public Function GetCurrentProjectWindows(ByVal Including_User_Control As Boolean) As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectWindows
        With GetCurrentProjectWindows_StopWatch
            If .IsRunning Then
                .Stop()
                If .ElapsedMilliseconds < 15000 Then
                    .Start()
                    Return GetCurrentProjectWindows_List
                    Exit Function
                End If
            ElseIf GetCurrentProjectWindows_List IsNot Nothing Then
                .Reset()
                .Start()
                Return GetCurrentProjectWindows_List
                Exit Function
            End If
            ' Déclenchement du "chronomètre"
            .Reset()
            .Start()
        End With

        Dim Resultat As New Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)
        Dim Proj As VelerSoftware.SZVB.Projet.Projet = Nothing
        Dim NomDocActuel As String = Nothing
        Dim oki As Boolean
        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File

        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                End If
            End If
        Else
            Proj = Generation_En_Cours_Projet
        End If

        If Proj IsNot Nothing AndAlso Proj.Loaded Then
            For Each a As String In My.Computer.FileSystem.GetFiles(Proj.Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                    Tmp_SZW_File = Nothing
                    oki = True
                    If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso (NomDocActuel = a) Then
                        oki = False
                        With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre)
                            Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File(.Designer.ComponentContainer.Components(0).Site.Name)
                            Tmp_SZW_File.WINDOWS = .CodeDomHostLoader.GetCodeCompileUnit
                        End With
                    End If
                    If oki Then Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(a)
                    If Tmp_SZW_File IsNot Nothing Then
                        If Not Including_User_Control AndAlso Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0).BaseTypes(0).BaseType = "System.Windows.Forms.UserControl" Then GoTo _next

                        If a = NomDocActuel Then
                            Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object("Me", Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0), GetType(System.CodeDom.CodeTypeDeclaration)))
                        Else
                            Resultat.Add(New VelerSoftware.Plugins3.Windows.Core.Object(Tmp_SZW_File.Nom, Tmp_SZW_File.WINDOWS.Namespaces(0).Types(0), GetType(System.CodeDom.CodeTypeDeclaration)))
                        End If
                    End If
                End If
_next:
            Next
        End If

        GetCurrentProjectWindows_List = Resultat
        Return Resultat
    End Function


#End Region

#Region "Current Function"

    Public Function GetCurrentFunctionSettings() As Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionSettings
        Dim result As New Generic.List(Of String)
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                    If Not .Param2 = Nothing Then
                        If Not .Param3 = Nothing Then
                            For Each strr As String In .Param3.Split(",")
                                result.Add(strr.Trim(" ").Split(" ")(1))
                            Next
                        End If
                    Else
                        If Not .Param3 = Nothing Then result.AddRange(.Param3.Split(";"))
                    End If
                    Return result
                End With
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                    If Not .Param2 = Nothing Then
                        If Not .Param3 = Nothing Then
                            For Each strr As String In .Param3.Split(",")
                                result.Add(strr.Trim(" ").Split(" ")(1))
                            Next
                        End If
                    Else
                        If Not .Param3 = Nothing Then result.AddRange(.Param3.Split(";"))
                    End If
                    Return result
                End With
            End If
        End If
        Return result
    End Function

    Public Function GetCurrentFunctionSettingType(ByVal Setting_Name As String) As String Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionSettingType
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                        If Not .Param2 = Nothing Then
                            If Not .Param3 = Nothing Then
                                For Each strr As String In .Param3.Split(",")
                                    If strr.Trim(" ").Split(" ")(1) = Setting_Name Then Return strr.Trim(" ").Split(" ")(3) : Exit For
                                Next
                            End If
                        Else
                            Return "System.Object"
                        End If
                        Return ""
                    End With
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                        If Not .Param2 = Nothing Then
                            If Not .Param3 = Nothing AndAlso _
                            Not .Param3 = Nothing Then
                                For Each strr As String In .Param3.Split(",")
                                    If strr.Trim(" ").Split(" ")(1) = Setting_Name Then Return strr.Trim(" ").Split(" ")(3) : Exit For
                                Next
                            End If
                        Else
                            Return "System.Object"
                        End If
                        Return ""
                    End With
                End If
            End If
        End If
        Return ""
    End Function

    Public Function GetCurrentFunctionType() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionType
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    Return CBool(DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren).Param4)
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    Return CBool(DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren).Param4)
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentFunctionIsClass() As Boolean Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionIsClass
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    If DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Name = "TabONE_KryptonPage" Then
                        Return True
                    Else
                        Return False
                    End If
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    If DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Name = "TabONE_KryptonPage" Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentFunctionName() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionName
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                Return CStr(DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren).Param1)
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                Return CStr(DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren).Param1)
            End If
        End If
        Return Nothing
    End Function

    <CLSCompliant(False)> _
    Public Function GetCurrentFunctionAction() As Generic.List(Of VelerSoftware.Plugins3.Action) Implements VelerSoftware.Plugins3.Tools.GetCurrentFunctionActions
        Dim result As New Generic.List(Of VelerSoftware.Plugins3.Action)
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                    result.AddRange(.Children_Actions)
                    Return result
                End With
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                With DirectCast(DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                    result.AddRange(.Children_Actions)
                    Return result
                End With
            End If
        End If
        Return result
    End Function

#End Region

#Region "Current Project Functions"

    Private GetCurrentProjectFunctions_List As Generic.List(Of String)
    Private GetCurrentProjectFunctions_StopWatch As New Stopwatch

    Public Function GetCurrentProjectFunctions() As Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetCurrentProjectFunctions
        With GetCurrentProjectFunctions_StopWatch
            If .IsRunning Then
                .Stop()
                If .ElapsedMilliseconds < 15000 Then
                    .Start()
                    Return GetCurrentProjectFunctions_List
                    Exit Function
                End If
            ElseIf GetCurrentProjectFunctions_List IsNot Nothing Then
                .Reset()
                .Start()
                Return GetCurrentProjectFunctions_List
                Exit Function
            End If
            ' Déclenchement du "chronomètre"
            .Reset()
            .Start()
        End With

        Dim Resultat As New Generic.List(Of String)
        Dim Proj As VelerSoftware.SZVB.Projet.Projet = Nothing
        Dim NomDocActuel As String = Nothing
        Dim oki As Boolean
        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File
        Dim Tmp_SZC_File As VelerSoftware.SZVB.Projet.SZC_File

        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    With DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions)
                        Proj = SOLUTION.GetProject(.Nom_Projet)
                        NomDocActuel = .NomCompletFichier
                    End With
                End If
            End If
        Else
            Proj = Generation_En_Cours_Projet
        End If

        If Proj IsNot Nothing AndAlso Proj.Loaded Then
            For Each a As String In My.Computer.FileSystem.GetFiles(Proj.Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                    Tmp_SZW_File = Nothing
                    oki = True
                    If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
                        For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                            If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso a = DirectCast(page.Controls(0), DocConcepteurFenetre).NomCompletFichier Then
                                oki = False
                                Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File(DirectCast(page.Controls(0), DocConcepteurFenetre).Designer.ComponentContainer.Components(0).Site.Name)
                                For Each page2 As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(page.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                                    If TypeOf page2.Controls(0) Is DocEditeurFonctionsUserControl Then Tmp_SZW_File.Functions.Add(DirectCast(page2.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Text)
                                Next
                                Exit For
                            End If
                        Next
                    End If
                    If oki Then Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(a)
                    If Tmp_SZW_File IsNot Nothing Then
                        ' i=1 afin de ne pas analyser la première fonction (racine de la class)
                        For i As Integer = 1 To Tmp_SZW_File.Functions.Count - 1
                            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\Function.xaml", Tmp_SZW_File.Functions(i), False)
                            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                                Dim XmlRead As New Xml.XmlTextReader(Application.StartupPath & "\Temp\Functions\Function.xaml")
                                If XmlRead IsNot Nothing Then
                                    Do While XmlRead.Read()
                                        Select Case XmlRead.NodeType
                                            Case Xml.XmlNodeType.Element
                                                Select Case XmlRead.Name
                                                    Case "Fonction" ' Solution
                                                        If CBool(XmlRead.GetAttribute("Param4")) Then
                                                            Dim param As String = " "
                                                            If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                param = Nothing
                                                                For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                    param &= "ByVal " & Strrr & " As Object, "
                                                                Next
                                                            End If
                                                            If a = NomDocActuel Then
                                                                Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                            Else
                                                                Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                            End If
                                                        Else
                                                            Dim param As String = " "
                                                            If Not XmlRead.GetAttribute("Param2") = "{x:Null}" Then
                                                                If a = NomDocActuel Then
                                                                    Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                Else
                                                                    Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                End If
                                                            Else
                                                                If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                    param = Nothing
                                                                    For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                        param &= "ByVal " & Strrr & " As Object, "
                                                                    Next
                                                                End If
                                                                If a = NomDocActuel Then
                                                                    Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                Else
                                                                    Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                End If
                                                            End If
                                                        End If
                                                        Exit Do
                                                End Select
                                        End Select
                                    Loop
                                    XmlRead.Close()
                                End If
                            End If
                        Next
                    End If

                ElseIf My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szc" Then
                    Tmp_SZC_File = Nothing
                    oki = True
                    If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
                        For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                            If TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso a = DirectCast(page.Controls(0), DocEditeurFonctions).NomCompletFichier Then
                                oki = False
                                Tmp_SZC_File = New VelerSoftware.SZVB.Projet.SZC_File(DirectCast(page.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages(0).Text)
                                For Each page2 As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(page.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                                    If TypeOf page2.Controls(0) Is DocEditeurFonctionsUserControl Then
                                        Tmp_SZC_File.Functions.Add(DirectCast(page2.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Text)
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    End If
                    If oki Then Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(a)
                    If Tmp_SZC_File IsNot Nothing Then
                        ' i=1 afin de ne pas analyser la première fonction (racine de la class)
                        For i As Integer = 1 To Tmp_SZC_File.Functions.Count - 1
                            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\Function.xaml", Tmp_SZC_File.Functions(i), False)
                            If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                                Dim XmlRead As New Xml.XmlTextReader(Application.StartupPath & "\Temp\Functions\Function.xaml")
                                If XmlRead IsNot Nothing Then
                                    Do While XmlRead.Read()
                                        Select Case XmlRead.NodeType
                                            Case Xml.XmlNodeType.Element
                                                Select Case XmlRead.Name
                                                    Case "Fonction" ' Solution
                                                        If CBool(XmlRead.GetAttribute("Param4")) Then
                                                            Dim param As String = " "
                                                            If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                param = Nothing
                                                                For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                    param &= "ByVal " & Strrr & " As Object, "
                                                                Next
                                                            End If
                                                            If a = NomDocActuel Then
                                                                Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                            Else
                                                                Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                            End If
                                                        Else
                                                            Dim param As String = " "
                                                            If Not XmlRead.GetAttribute("Param2") = "{x:Null}" Then
                                                                If a = NomDocActuel Then
                                                                    Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                Else
                                                                    Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                End If
                                                            Else
                                                                If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                    param = Nothing
                                                                    For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                        param &= "ByVal " & Strrr & " As Object, "
                                                                    Next
                                                                End If
                                                                If a = NomDocActuel Then
                                                                    Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                Else
                                                                    Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                End If
                                                            End If
                                                        End If
                                                        Exit Do
                                                End Select
                                        End Select
                                    Loop
                                    XmlRead.Close()
                                End If
                            End If
                        Next
                    End If

                End If
            Next
        End If

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        Tmp_SZW_File = Nothing
        Tmp_SZC_File = Nothing

        GetCurrentProjectFunctions_List = Resultat
        Return Resultat
    End Function

    <CLSCompliant(False)> _
    Public Function GetActionsOfFunction(ByVal function_name As String) As Generic.List(Of VelerSoftware.Plugins3.Action) Implements VelerSoftware.Plugins3.Tools.GetActionsOfFuntion
        Dim result As New Generic.List(Of VelerSoftware.Plugins3.Action)
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                    With DirectCast(DirectCast(page.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                        If CStr(.Param1) = function_name Then
                            result.AddRange(.Children_Actions)
                            Return result
                            Exit Function
                        End If
                    End With
                Next
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                For Each page As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                    With DirectCast(DirectCast(page.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.GetCurrentValue(), VelerSoftware.Plugins3.ActionWithChildren)
                        If CStr(.Param1) = function_name Then
                            result.AddRange(.Children_Actions)
                            Return result
                            Exit Function
                        End If
                    End With
                Next
            End If
        End If
        Return result
    End Function

#End Region

#Region "Solution Functions"

    Private GetSolutionFunctions_List As Generic.List(Of String)
    Private GetSolutionFunctions_StopWatch As New Stopwatch

    Public Function GetSolutionFunctions() As Generic.List(Of String) Implements VelerSoftware.Plugins3.Tools.GetSolutionFunctions
        With GetSolutionFunctions_StopWatch
            If .IsRunning Then
                .Stop()
                If .ElapsedMilliseconds < 15000 Then
                    .Start()
                    Return GetSolutionFunctions_List
                    Exit Function
                End If
            ElseIf GetSolutionFunctions_List IsNot Nothing Then
                .Reset()
                .Start()
                Return GetSolutionFunctions_List
                Exit Function
            End If
            ' Déclenchement du "chronomètre"
            .Reset()
            .Start()
        End With

        Dim Resultat As New Generic.List(Of String)
        Dim NomDocActuel As String = Nothing
        Dim oki As Boolean
        Dim Tmp_SZW_File As VelerSoftware.SZVB.Projet.SZW_File
        Dim Tmp_SZC_File As VelerSoftware.SZVB.Projet.SZC_File

        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                NomDocActuel = DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).NomCompletFichier
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                NomDocActuel = DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).NomCompletFichier
            End If
        End If

        If SOLUTION IsNot Nothing Then

            For Each Proj As VelerSoftware.SZVB.Projet.Projet In SOLUTION.Projets

                If Proj IsNot Nothing AndAlso Proj.Loaded Then
                    For Each a As String In My.Computer.FileSystem.GetFiles(Proj.Emplacement, FileIO.SearchOption.SearchAllSubDirectories)
                        If My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szw" Then
                            Tmp_SZW_File = Nothing
                            oki = True
                            If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
                                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                    If TypeOf page.Controls(0) Is DocConcepteurFenetre AndAlso a = DirectCast(page.Controls(0), DocConcepteurFenetre).NomCompletFichier Then
                                        oki = False
                                        Tmp_SZW_File = New VelerSoftware.SZVB.Projet.SZW_File(DirectCast(page.Controls(0), DocConcepteurFenetre).Designer.ComponentContainer.Components(0).Site.Name)
                                        For Each page2 As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(page.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages
                                            If TypeOf page2.Controls(0) Is DocEditeurFonctionsUserControl Then Tmp_SZW_File.Functions.Add(DirectCast(page2.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Text)
                                        Next
                                        Exit For
                                    End If
                                Next
                            End If
                            If oki Then Tmp_SZW_File = ClassFichier.Charger_Fichier_SZW(a)
                            If Tmp_SZW_File IsNot Nothing Then
                                ' i=1 afin de ne pas analyser la première fonction (racine de la class)
                                For i As Integer = 1 To Tmp_SZW_File.Functions.Count - 1
                                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\Function.xaml", Tmp_SZW_File.Functions(i), False)
                                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                                        Dim XmlRead As New Xml.XmlTextReader(Application.StartupPath & "\Temp\Functions\Function.xaml")
                                        If XmlRead IsNot Nothing Then
                                            Do While XmlRead.Read()
                                                Select Case XmlRead.NodeType
                                                    Case Xml.XmlNodeType.Element
                                                        Select Case XmlRead.Name
                                                            Case "Fonction" ' Solution
                                                                If CBool(XmlRead.GetAttribute("Param4")) Then
                                                                    Dim param As String = " "
                                                                    If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                        param = Nothing
                                                                        For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                            param &= "ByVal " & Strrr & " As Object, "
                                                                        Next
                                                                    End If
                                                                    If a = NomDocActuel Then
                                                                        Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                                    Else
                                                                        Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                                    End If
                                                                Else
                                                                    Dim param As String = " "
                                                                    If Not XmlRead.GetAttribute("Param2") = "{x:Null}" Then
                                                                        If a = NomDocActuel Then
                                                                            Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                        Else
                                                                            Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                        End If
                                                                    Else
                                                                        If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                            param = Nothing
                                                                            For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                                param &= "ByVal " & Strrr & " As Object, "
                                                                            Next
                                                                        End If
                                                                        If a = NomDocActuel Then
                                                                            Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                        Else
                                                                            Resultat.Add(Proj.Nom & "." & Tmp_SZW_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                        End If
                                                                    End If
                                                                End If
                                                                Exit Do
                                                        End Select
                                                End Select
                                            Loop
                                            XmlRead.Close()
                                        End If
                                    End If
                                Next
                            End If

                        ElseIf My.Computer.FileSystem.GetFileInfo(a).Extension.ToLower = ".szc" Then
                            Tmp_SZC_File = Nothing
                            oki = True
                            If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
                                For Each page As VelerSoftware.Design.Navigator.KryptonPage In Form1.KryptonDockableWorkspace1.AllPages
                                    If TypeOf page.Controls(0) Is DocEditeurFonctions AndAlso a = DirectCast(page.Controls(0), DocEditeurFonctions).NomCompletFichier Then
                                        oki = False
                                        Tmp_SZC_File = New VelerSoftware.SZVB.Projet.SZC_File(DirectCast(page.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages(0).Text)
                                        For Each page2 As VelerSoftware.Design.Navigator.KryptonPage In DirectCast(page.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages
                                            If TypeOf page2.Controls(0) Is DocEditeurFonctionsUserControl Then Tmp_SZC_File.Functions.Add(DirectCast(page2.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Text)
                                        Next
                                        Exit For
                                    End If
                                Next
                            End If
                            If oki Then
                                Tmp_SZC_File = ClassFichier.Charger_Fichier_SZC(a)
                            End If
                            If Tmp_SZC_File IsNot Nothing Then
                                ' i=1 afin de ne pas analyser la première fonction (racine de la class)
                                For i As Integer = 1 To Tmp_SZC_File.Functions.Count - 1
                                    My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\Temp\Functions\Function.xaml", Tmp_SZC_File.Functions(i), False)
                                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then
                                        Dim XmlRead As New Xml.XmlTextReader(Application.StartupPath & "\Temp\Functions\Function.xaml")
                                        If XmlRead IsNot Nothing Then
                                            Do While XmlRead.Read()
                                                Select Case XmlRead.NodeType
                                                    Case Xml.XmlNodeType.Element
                                                        Select Case XmlRead.Name
                                                            Case "Fonction" ' Solution
                                                                If CBool(XmlRead.GetAttribute("Param4")) Then
                                                                    Dim param As String = " "
                                                                    If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                        param = Nothing
                                                                        For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                            param &= "ByVal " & Strrr & " As Object, "
                                                                        Next
                                                                    End If
                                                                    If a = NomDocActuel Then
                                                                        Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                                    Else
                                                                        Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ") As System.Object")
                                                                    End If
                                                                Else
                                                                    Dim param As String = " "
                                                                    If Not XmlRead.GetAttribute("Param2") = "{x:Null}" Then
                                                                        If a = NomDocActuel Then
                                                                            Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                        Else
                                                                            Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & XmlRead.GetAttribute("Param3") & ")")
                                                                        End If
                                                                    Else
                                                                        If Not XmlRead.GetAttribute("Param3") = "{x:Null}" Then
                                                                            param = Nothing
                                                                            For Each Strrr As String In XmlRead.GetAttribute("Param3").Split(";")
                                                                                param &= "ByVal " & Strrr & " As Object, "
                                                                            Next
                                                                        End If
                                                                        If a = NomDocActuel Then
                                                                            Resultat.Add(Proj.Nom & ".Me." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                        Else
                                                                            Resultat.Add(Proj.Nom & "." & Tmp_SZC_File.Nom & "." & XmlRead.GetAttribute("Param1") & "(" & param.TrimEnd(" ").TrimEnd(",") & ")")
                                                                        End If
                                                                    End If
                                                                End If
                                                                Exit Do
                                                        End Select
                                                End Select
                                            Loop
                                            XmlRead.Close()
                                        End If
                                    End If
                                Next
                            End If

                        End If
                    Next
                End If

            Next

        End If

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Temp\Functions\Function.xaml") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\Functions\Function.xaml", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        Tmp_SZW_File = Nothing
        Tmp_SZC_File = Nothing

        GetSolutionFunctions_List = Resultat
        Return Resultat
    End Function

#End Region

#Region "Current Document"

    Public Function GetCurrentDocumentFileName() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentDocumentFileName
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                Return DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).NomCompletFichier
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                Return DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).NomCompletFichier
            End If
        End If
        Return Nothing
    End Function

    Public Function GetCurrentDocumentName() As String Implements VelerSoftware.Plugins3.Tools.GetCurrentDocumentName
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                Return DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.Pages(0).Text
            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                Return DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.Pages(0).Text
            End If
        End If
        Return Nothing
    End Function

#End Region

#Region "Other"

    Public Function SelectType() As Type Implements VelerSoftware.Plugins3.Tools.SelectType
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            Using frm As New ActionToolsSelectionnerTypeForm
                frm.Tag = Me.GetCurrentProjectReferences
                If frm.ShowDialog Then Return frm.RESULTAT
                frm.Dispose()
            End Using
        End If
        Return Nothing
    End Function

    Public Function SelectControlProperty(Optional AllowSelectForm As Boolean = True, Optional OnlyArrayProperty As Boolean = False, Optional OnlyFollowingControlsTypes As String() = Nothing, Optional OnlyFollowingPropertiesTypes As String() = Nothing) As String Implements VelerSoftware.Plugins3.Tools.SelectControlProperty
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            Using frm As New ActionToolsSelectionnerCOntrolePropriétéForm
                With frm
                    .Tag = Me
                    .AllowSelectForms = AllowSelectForm
                    .OnlyArrayProperty = OnlyArrayProperty
                    .OnlyFollowingControlsTypes = OnlyFollowingControlsTypes
                    .OnlyFollowingPropertiesTypes = OnlyFollowingPropertiesTypes
                    .SelectProperty = True
                    If .ShowDialog Then Return .RESULTAT
                    .Dispose()
                End With
            End Using
        End If
        Return Nothing
    End Function

    Public Function SelectControl(Optional AllowSelectFormProperties As Boolean = True, Optional OnlyFollowingControlsTypes As String() = Nothing, Optional OnlyFollowingPropertiesTypes As String() = Nothing) As String Implements VelerSoftware.Plugins3.Tools.SelectControl
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            Using frm As New ActionToolsSelectionnerCOntrolePropriétéForm
                With frm
                    .Tag = Me
                    .AllowSelectForms = AllowSelectFormProperties
                    .OnlyArrayProperty = False
                    .OnlyFollowingControlsTypes = OnlyFollowingControlsTypes
                    .OnlyFollowingPropertiesTypes = OnlyFollowingPropertiesTypes
                    .SelectProperty = False
                    If .ShowDialog Then Return .RESULTAT
                    .Dispose()
                End With
            End Using
        End If
        Return Nothing
    End Function

    Public Function ShowVariableManager() As DialogResult Implements VelerSoftware.Plugins3.Tools.ShowVariableManager
        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            Using frm As New Gestionnaire_Variables
                frm.Nom_Projet = Me.GetCurrentProjectName()
                Return frm.ShowDialog()
                frm.Dispose()
            End Using
        End If
        Return DialogResult.Cancel
    End Function

    Public Function TransformKeyVariables(ByVal Param As String, ByVal IsText As Boolean, Optional ByVal WithOperator As Boolean = True) As String Implements VelerSoftware.Plugins3.Tools.TransformKeyVariables
        Dim resultat As String = Param

        If Not resultat = Nothing Then

            If IsText Then
                resultat = resultat.Replace(ChrW(34), ChrW(34) & " & Microsoft.VisualBasic.ChrW(34) & " & ChrW(34))
                resultat = resultat.Replace(ChrW(13), "")
                resultat = resultat.Replace(ChrW(10), ChrW(34) & " & System.Environment.NewLine & " & ChrW(34))

                resultat = resultat.Replace("[CODE]", ChrW(34) & " & ").Replace("[/CODE]", " & " & ChrW(34))
                If resultat.Contains("%(APPLICATION=") Then
                    resultat = resultat.Replace("%(APPLICATION=APPLICATION_PATH)%", ChrW(34) & " & System.Windows.Forms.Application.StartupPath & " & ChrW(34))
                    resultat = resultat.Replace("%(APPLICATION=MY_DOCUMENTS)%", ChrW(34) & " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) & " & ChrW(34))
                    resultat = resultat.Replace("%(APPLICATION=MY_MUSICS)%", ChrW(34) & " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic) & " & ChrW(34))
                    resultat = resultat.Replace("%(APPLICATION=MY_PICTURES)%", ChrW(34) & " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) & " & ChrW(34))
                    resultat = resultat.Replace("%(APPLICATION=MY_VIDEOS)%", ChrW(34) & " & System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) & " & ChrW(34))
                End If
                If resultat.Contains("%(SETTING=") Then resultat = resultat.Replace("%(SETTING=", ChrW(34) & " & My.Settings.")
                If resultat.Contains("%(FUNCTION=") Then resultat = resultat.Replace("%(FUNCTION=", ChrW(34) & " & ")
                If resultat.Contains("%(PROPERTY=") Then resultat = resultat.Replace("%(PROPERTY=", ChrW(34) & " & Me.")
                If resultat.Contains("%(CONTROL=Me.") Then resultat = resultat.Replace("%(CONTROL=", ChrW(34) & " & ")
                If resultat.Contains("%(CONTROL=Me)%") Then resultat = resultat.Replace("%(CONTROL=Me)%", ChrW(34) & " & Me & " & ChrW(34))
                If resultat.Contains("%(CONTROL=") Then resultat = resultat.Replace("%(CONTROL=", ChrW(34) & " & Variables.")

                If resultat.Contains("%(ENVIRONMENT=") Then
                    For Each b As DictionaryEntry In Environment.GetEnvironmentVariables()
                        resultat = resultat.Replace("%(ENVIRONMENT=" & CStr(b.Key) & ")%", ChrW(34) & " & CStr(System.Environment.GetEnvironmentVariable(" & ChrW(34) & CStr(b.Key) & ChrW(34) & ")) & " & ChrW(34))
                        If Not resultat.Contains("%(ENVIRONMENT=") Then Exit For
                    Next
                End If

                If resultat.Contains("%(RESOURCE=") Then
                    For Each b As VelerSoftware.SZVB.Projet.Ressource In Me.GetCurrentProjectResoucres
                        resultat = resultat.Replace("%(RESOURCE=" & b.Name & ")%", ChrW(34) & " & CStr(My.Resources." & b.Name & ") & " & ChrW(34))
                        If Not resultat.Contains("%(RESOURCE=") Then Exit For
                    Next

                    If resultat.Contains("%(RESOURCE=") Then resultat = resultat.Replace("%(RESOURCE=", " & CStr(My.Resources.")
                End If

                If resultat.Contains("%(VARIABLE=") Then
                    Dim varlist As Generic.List(Of VelerSoftware.SZVB.Projet.Variable) = Me.GetCurrentProjectVariableList
                    For Each b As VelerSoftware.SZVB.Projet.Variable In varlist
                        resultat = resultat.Replace("%(VARIABLE=" & b.Name & ")%", ChrW(34) & " & " & b.Name & " & " & ChrW(34))
                        For Each c As VelerSoftware.SZVB.Projet.Variable In varlist
                            resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & c.Name & "])%", ChrW(34) & " & " & b.Name & "(" & c.Name & ")" & " & " & ChrW(34))
                        Next
                        If resultat.Contains("%(VARIABLE=" & b.Name & "[") Then
                            For x As Integer = 0 To 20
                                resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & x & "])%", ChrW(34) & " & " & b.Name & "(" & x & ")" & " & " & ChrW(34))
                            Next
                        End If
                        If Not resultat.Contains("%(VARIABLE=") Then Exit For
                    Next

                    If resultat.Contains("%(VARIABLE=") Then resultat = resultat.Replace("%(VARIABLE=", ChrW(34) & " & ")
                End If

                If resultat.Contains("%(") Then
                    Dim varlist As Generic.List(Of VelerSoftware.SZVB.Projet.Variable) = Me.GetCurrentProjectVariableList
                    For Each b As VelerSoftware.SZVB.Projet.Variable In varlist
                        resultat = resultat.Replace("%(" & b.Name & ")%", ChrW(34) & " & " & b.Name & " & " & ChrW(34))
                        For Each c As VelerSoftware.SZVB.Projet.Variable In varlist
                            resultat = resultat.Replace("%(" & b.Name & "[" & c.Name & "])%", ChrW(34) & " & " & b.Name & "(" & c.Name & ")" & " & " & ChrW(34))
                        Next
                        If resultat.Contains("%(" & b.Name & "[") Then
                            For x As Integer = 0 To 20
                                resultat = resultat.Replace("%(" & b.Name & "[" & x & "])%", ChrW(34) & " & " & b.Name & "(" & x & ")" & " & " & ChrW(34))
                            Next
                        End If
                        If Not resultat.Contains("%(") Then Exit For
                    Next

                    If resultat.Contains("%(") Then resultat = resultat.Replace("%(", ChrW(34) & " & ")
                End If

                resultat = resultat.Replace("&NumPage", "_&NumPage").Replace("&PageCount", "_&PageCount")
                resultat = ChrW(34) & resultat.Replace(")%", " & " & ChrW(34)).TrimStart(" & ", Nothing).TrimEnd(" & ", Nothing).TrimStart("& ", Nothing).TrimEnd(" &", Nothing) & ChrW(34)
                resultat = resultat.Replace("_&NumPage", "&NumPage").Replace("_&PageCount", "&PageCount")
            Else

                If WithOperator Then
                    resultat = resultat.Replace("[CODE]", " + ").Replace("[/CODE]", " + ")
                    If resultat.Contains("%(APPLICATION=") Then
                        resultat = resultat.Replace("%(APPLICATION=APPLICATION_PATH)%", " + System.Windows.Forms.Application.StartupPath + ")
                        resultat = resultat.Replace("%(APPLICATION=MY_DOCUMENTS)%", " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + ")
                        resultat = resultat.Replace("%(APPLICATION=MY_MUSICS)%", " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic) + ")
                        resultat = resultat.Replace("%(APPLICATION=MY_PICTURES)%", " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + ")
                        resultat = resultat.Replace("%(APPLICATION=MY_VIDEOS)%", " + System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + ")
                    End If
                    If resultat.Contains("%(SETTING=") Then resultat = resultat.Replace("%(SETTING=", " + My.Settings.")
                    If resultat.Contains("%(FUNCTION=") Then resultat = resultat.Replace("%(FUNCTION=", " + ")
                    If resultat.Contains("%(PROPERTY=") Then resultat = resultat.Replace("%(PROPERTY=", " + Me.")
                    If resultat.Contains("%(CONTROL=Me.") Then resultat = resultat.Replace("%(CONTROL=", " + ")
                    If resultat.Contains("%(CONTROL=Me)%") Then resultat = resultat.Replace("%(CONTROL=Me)%", " + Me + ")
                    If resultat.Contains("%(CONTROL=") Then resultat = resultat.Replace("%(CONTROL=", " + Variables.")

                    If resultat.Contains("%(ENVIRONMENT=") Then
                        For Each b As DictionaryEntry In Environment.GetEnvironmentVariables()
                            resultat = resultat.Replace("%(ENVIRONMENT=" & CStr(b.Key) & ")%", " + CStr(System.Environment.GetEnvironmentVariable(" & ChrW(34) & CStr(b.Key) & ChrW(34) & ")) + ")
                            If Not resultat.Contains("%(ENVIRONMENT=") Then Exit For
                        Next
                    End If

                    If resultat.Contains("%(RESOURCE=") Then
                        For Each b As VelerSoftware.SZVB.Projet.Ressource In Me.GetCurrentProjectResoucres
                            resultat = resultat.Replace("%(RESOURCE=" & b.Name & ")%", " + My.Resources." & b.Name & " + ")
                            If Not resultat.Contains("%(RESOURCE=") Then Exit For
                        Next

                        If resultat.Contains("%(RESOURCE=") Then resultat = resultat.Replace("%(RESOURCE=", " +  My.Resources.")
                    End If

                    If resultat.Contains("%(VARIABLE=") Then
                        Dim varlist As Generic.List(Of VelerSoftware.SZVB.Projet.Variable) = Me.GetCurrentProjectVariableList
                        For Each b As VelerSoftware.SZVB.Projet.Variable In varlist
                            resultat = resultat.Replace("%(VARIABLE=" & b.Name & ")%", " + " & b.Name & " + ")
                            For Each c As VelerSoftware.SZVB.Projet.Variable In varlist
                                resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & c.Name & "])%", " + " & b.Name & "(" & c.Name & ")" & " + ")
                            Next
                            If resultat.Contains("%(VARIABLE=" & b.Name & "[") Then
                                For x As Integer = 0 To 20
                                    resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & x & "])%", " + " & b.Name & "(" & x & ")" & " + ")
                                Next
                            End If
                            If Not resultat.Contains("%(VARIABLE=") Then Exit For
                        Next

                        If resultat.Contains("%(VARIABLE=") Then resultat = resultat.Replace("%(VARIABLE=", " + ")
                    End If

                    resultat = resultat.Replace(")%", " + ")
                    resultat = resultat.Trim(" ", Nothing)
                    resultat = resultat.Trim("+", Nothing)
                    resultat = resultat.Trim(" ", Nothing)

                Else

                    resultat = resultat.Replace("[CODE]", " ").Replace("[/CODE]", " ")
                    If resultat.Contains("%(APPLICATION=") Then
                        resultat = resultat.Replace("%(APPLICATION=APPLICATION_PATH)%", " System.Windows.Forms.Application.StartupPath ")
                        resultat = resultat.Replace("%(APPLICATION=MY_DOCUMENTS)%", " System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) ")
                        resultat = resultat.Replace("%(APPLICATION=MY_MUSICS)%", " System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic) ")
                        resultat = resultat.Replace("%(APPLICATION=MY_PICTURES)%", " System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) ")
                        resultat = resultat.Replace("%(APPLICATION=MY_VIDEOS)%", " System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) ")
                    End If
                    If resultat.Contains("%(SETTING=") Then resultat = resultat.Replace("%(SETTING=", " My.Settings.")
                    If resultat.Contains("%(FUNCTION=") Then resultat = resultat.Replace("%(FUNCTION=", " ")
                    If resultat.Contains("%(CONTROL=Me.") Then resultat = resultat.Replace("%(CONTROL=", " ")
                    If resultat.Contains("%(CONTROL=Me)%") Then resultat = resultat.Replace("%(CONTROL=Me)%", " Me ")
                    If resultat.Contains("%(CONTROL=") Then resultat = resultat.Replace("%(CONTROL=", " Variables.")

                    If resultat.Contains("%(ENVIRONMENT=") Then
                        For Each b As DictionaryEntry In Environment.GetEnvironmentVariables()
                            resultat = resultat.Replace("%(ENVIRONMENT=" & CStr(b.Key) & ")%", " CStr(System.Environment.GetEnvironmentVariable(" & ChrW(34) & CStr(b.Key) & ChrW(34) & ")) ")
                            If Not resultat.Contains("%(ENVIRONMENT=") Then Exit For
                        Next
                    End If

                    If resultat.Contains("%(RESOURCE=") Then
                        For Each b As VelerSoftware.SZVB.Projet.Ressource In Me.GetCurrentProjectResoucres
                            resultat = resultat.Replace("%(RESOURCE=" & b.Name & ")%", " My.Resources." & b.Name & " ")
                            If Not resultat.Contains("%(RESOURCE=") Then Exit For
                        Next

                        If resultat.Contains("%(RESOURCE=") Then resultat = resultat.Replace("%(RESOURCE=", "  My.Resources.")
                    End If

                    If resultat.Contains("%(VARIABLE=") Then
                        Dim varlist As Generic.List(Of VelerSoftware.SZVB.Projet.Variable) = Me.GetCurrentProjectVariableList
                        For Each b As VelerSoftware.SZVB.Projet.Variable In varlist
                            resultat = resultat.Replace("%(VARIABLE=" & b.Name & ")%", " " & b.Name & " ")
                            For Each c As VelerSoftware.SZVB.Projet.Variable In varlist
                                resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & c.Name & "])%", " " & b.Name & "(" & c.Name & ")" & " ")
                            Next
                            If resultat.Contains("%(VARIABLE=" & b.Name & "[") Then
                                For x As Integer = 0 To 20
                                    resultat = resultat.Replace("%(VARIABLE=" & b.Name & "[" & x & "])%", " " & b.Name & "(" & x & ")" & " ")
                                Next
                            End If
                            If Not resultat.Contains("%(VARIABLE=") Then Exit For
                        Next

                        If resultat.Contains("%(VARIABLE=") Then resultat = resultat.Replace("%(VARIABLE=", "  ")
                    End If

                    resultat = resultat.Replace(")%", " ")
                    resultat = resultat.Trim(" ", Nothing)
                    resultat = resultat.Trim("+", Nothing)
                    resultat = resultat.Trim(" ", Nothing)

                End If
            End If

        Else
            If IsText Then
                resultat = ChrW(34) & ChrW(34)
            Else
                resultat = "Nothing"
            End If
        End If

        Return resultat
    End Function

    Public Function GetPropertyList(ByVal Tip As String) As Generic.List(Of System.Reflection.PropertyInfo) Implements VelerSoftware.Plugins3.Tools.GetPropertyList
        Dim RESULTAT As New Generic.List(Of System.Reflection.PropertyInfo)

        ' Référence
        Dim mi() As System.Reflection.PropertyInfo
        Dim can_exit As Boolean = False
        Dim t As Type = Nothing

        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    For Each a As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                        If a.Assembly IsNot Nothing Then
                            t = a.Assembly.GetType(Tip)
                            If t IsNot Nothing Then
                                mi = t.GetProperties 'liste toutes les Method de ce type (sub ou function)
                                For Each m As System.Reflection.PropertyInfo In mi
                                    If Not m.IsSpecialName Then RESULTAT.Add(m)
                                Next
                                can_exit = True
                                Exit For
                            End If
                        End If
                        If can_exit Then Exit For
                        a = Nothing
                    Next
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    For Each a As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).References
                        If a.Assembly IsNot Nothing Then
                            t = a.Assembly.GetType(Tip)
                            If t IsNot Nothing Then
                                mi = t.GetProperties 'liste toutes les Method de ce type (sub ou function)
                                For Each m As System.Reflection.PropertyInfo In mi
                                    If Not m.IsSpecialName Then RESULTAT.Add(m)
                                Next
                                can_exit = True
                                Exit For
                            End If
                        End If
                        If can_exit Then Exit For
                        a = Nothing
                    Next
                End If
            End If
        Else
            For Each a As VelerSoftware.SZVB.Projet.Reference In Generation_En_Cours_Projet.References
                If a.Assembly IsNot Nothing Then
                    t = a.Assembly.GetType(Tip)
                    If t IsNot Nothing Then
                        mi = t.GetProperties 'liste toutes les Method de ce type (sub ou function)
                        For Each m As System.Reflection.PropertyInfo In mi
                            If Not m.IsSpecialName Then RESULTAT.Add(m)
                        Next
                        can_exit = True
                        Exit For
                    End If
                End If
                If can_exit Then Exit For
                a = Nothing
            Next
        End If

        Return RESULTAT
    End Function

    Public Function GetMethodList(ByVal Tip As String) As Generic.List(Of System.Reflection.MethodInfo) Implements VelerSoftware.Plugins3.Tools.GetMethodList
        Dim RESULTAT As New Generic.List(Of System.Reflection.MethodInfo)

        ' Référence
        Dim mi() As System.Reflection.MethodInfo
        Dim can_exit As Boolean = False
        Dim t As Type = Nothing

        If Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours Then
            If Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
                If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                    For Each a As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet).References
                        If a.Assembly IsNot Nothing Then
                            t = a.Assembly.GetType(Tip)
                            If t IsNot Nothing Then
                                mi = t.GetMethods 'liste toutes les Method de ce type (sub ou function)
                                For Each m As System.Reflection.MethodInfo In mi
                                    If Not m.IsSpecialName Then RESULTAT.Add(m)
                                Next
                                can_exit = True
                                Exit For
                            End If
                        End If
                        If can_exit Then Exit For
                        a = Nothing
                    Next
                ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                    For Each a As VelerSoftware.SZVB.Projet.Reference In SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).Nom_Projet).References
                        If a.Assembly IsNot Nothing Then
                            t = a.Assembly.GetType(Tip)
                            If t IsNot Nothing Then
                                mi = t.GetMethods 'liste toutes les Method de ce type (sub ou function)
                                For Each m As System.Reflection.MethodInfo In mi
                                    If Not m.IsSpecialName Then RESULTAT.Add(m)
                                Next
                                can_exit = True
                                Exit For
                            End If
                        End If
                        If can_exit Then Exit For
                        a = Nothing
                    Next
                End If
            End If
        Else
            For Each a As VelerSoftware.SZVB.Projet.Reference In Generation_En_Cours_Projet.References
                If a.Assembly IsNot Nothing Then
                    t = a.Assembly.GetType(Tip)
                    If t IsNot Nothing Then
                        mi = t.GetMethods 'liste toutes les Method de ce type (sub ou function)
                        For Each m As System.Reflection.MethodInfo In mi
                            If Not m.IsSpecialName Then RESULTAT.Add(m)
                        Next
                        can_exit = True
                        Exit For
                    End If
                End If
                If can_exit Then Exit For
                a = Nothing
            Next
        End If

        Return RESULTAT
    End Function

    <CLSCompliant(False)> _
    Public Function GetParentAction(ByVal Action As VelerSoftware.Plugins3.Action) As VelerSoftware.Plugins3.Action Implements VelerSoftware.Plugins3.Tools.GetParentAction
        Dim result As System.Activities.Presentation.Model.ModelItem = Nothing
        If (Status_SZ = statu.Normal OrElse Status_SZ = statu.Debuggage_En_Cours) AndAlso Form1.KryptonDockableWorkspace1.ActivePage.Controls.Count > 0 Then
            If TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocConcepteurFenetre Then
                For Each model As System.Activities.Presentation.Model.ModelItem In DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.Properties("Children_Actions").Collection
                    If model IsNot Nothing AndAlso model.GetCurrentValue IsNot Nothing Then
                        If model.GetCurrentValue.id = Action.id Then
                            result = model.Parent
                            Exit For
                        End If
                        result = ExploreModeItem(model, Action)
                        If Not result Is Nothing Then Exit For
                    End If
                Next

            ElseIf TypeOf Form1.KryptonDockableWorkspace1.ActivePage.Controls(0) Is DocEditeurFonctions Then
                For Each model As System.Activities.Presentation.Model.ModelItem In DirectCast(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocEditeurFonctions).KryptonNavigator2.SelectedPage.Controls(0), DocEditeurFonctionsUserControl).WorkflowDesigne.Context.Services.GetService(Of System.Activities.Presentation.Services.ModelService)().Root.Properties("Children_Actions").Collection
                    If model.GetCurrentValue.id = Action.id Then
                        result = model.Parent
                        Exit For
                    End If
                    result = ExploreModeItem(model, Action)
                    If Not result Is Nothing Then Exit For
                Next

            End If
        End If
        If result IsNot Nothing Then
            Return result.Parent.GetCurrentValue
        Else
            Return Nothing
        End If
    End Function

    <CLSCompliant(False)> _
    Public Function GetParentsAction(ByVal Action As VelerSoftware.Plugins3.Action) As Generic.List(Of VelerSoftware.Plugins3.Action) Implements VelerSoftware.Plugins3.Tools.GetParentsAction
        Dim result As New Generic.List(Of VelerSoftware.Plugins3.Action)

        Dim oki As Boolean
        Dim parent As VelerSoftware.Plugins3.Action = Nothing
        Dim id_old As String

        parent = Me.GetParentAction(Action)
        id_old = parent.id
        While oki = False
            If parent Is Nothing Then
                oki = True
            Else
                result.Add(parent)
                parent = Me.GetParentAction(parent)
                If parent IsNot Nothing Then
                    If parent.id = id_old Then
                        oki = True
                    Else
                        id_old = parent.id
                    End If
                End If
            End If
        End While

        Return result
    End Function

    <CLSCompliant(False)> _
    Public Function ExploreModeItem(ByVal Model As System.Activities.Presentation.Model.ModelItem, ByVal Action As VelerSoftware.Plugins3.Action) As System.Activities.Presentation.Model.ModelItem
        Dim result As System.Activities.Presentation.Model.ModelItem = Nothing
        For Each aaa As System.Activities.Presentation.Model.ModelItem In Model.Properties("Children_Actions").Collection()
            If aaa IsNot Nothing AndAlso aaa.GetCurrentValue IsNot Nothing Then
                If aaa.GetCurrentValue.id = Action.id Then
                    result = aaa.Parent
                    Exit For
                End If
                result = ExploreModeItem(aaa, Action)
                If Not result Is Nothing Then Exit For
            End If
        Next
        Return result
    End Function

#End Region

End Class
