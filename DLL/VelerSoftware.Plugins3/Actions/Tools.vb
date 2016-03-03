''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Interface Tools

    Function GetProjectsName() As Generic.List(Of String)

    Function GetCurrentProjectVariableList() As Generic.List(Of VelerSoftware.SZVB.Projet.Variable)

    Function GetSolutionVariableList() As Generic.List(Of VelerSoftware.SZVB.Projet.Variable)

    Function GetCurrentProjectType() As VelerSoftware.SZVB.Projet.Projet.Types

    Function GetCurrentProjectName() As String

    Function GetCurrentProjectAssemblyVersion() As String

    Function GetCurrentProjectFileVersion() As String

    Function GetCurrentProjectTitle() As String

    Function GetCurrentProjectProduct() As String

    Function GetCurrentProjectSocity() As String

    Function GetCurrentProjectCopyright() As String

    Function GetCurrentProjectMark() As String

    Function GetCurrentProjectDescription() As String

    Function GetCurrentProjectGuid() As String

    Function GetCurrentProjectCPU() As VelerSoftware.SZVB.Projet.Projet.Cpus

    Function GetCurrentProjectObfuscationLevel() As VelerSoftware.SZVB.Projet.Projet.ObfuscationLevels

    Function GetCurrentProjectPath() As String

    Function GetCurrentProjectVBNetFiles() As Generic.List(Of String)

    Function GetCurrentProjectFormStart() As String

    Function GetCurrentProjectGenerateDirectory() As String

    Function GetCurrentProjectInstance() As Boolean

    Function GetCurrentProjectUseStyleXP() As Boolean

    Function GetCurrentProjectOptimize() As Boolean

    Function GetCurrentProjectSaveMySettings() As Boolean

    Function GetCurrentProjectSettings() As Generic.List(Of String)

    Function GetCurrentProjectSplashScreen() As String

    Function GetCurrentProjectShutMode() As VelerSoftware.SZVB.Projet.Projet.ShutModes

    Function GetCurrentProjectResoucres() As Generic.List(Of VelerSoftware.SZVB.Projet.Ressource)

    Function GetCurrentProjectReferences() As Generic.List(Of VelerSoftware.SZVB.Projet.Reference)

    Function GetCurrentProjectWindowsControls() As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)

    Function GetCurrentProjectWindows(ByVal Including_User_Control As Boolean) As Generic.List(Of VelerSoftware.Plugins3.Windows.Core.Object)

    Function GetCurrentFunctionSettings() As Generic.List(Of String)

    Function GetCurrentFunctionSettingType(ByVal Setting_Name As String) As String

    Function GetCurrentFunctionName() As String

    Function GetCurrentFunctionType() As Boolean

    Function GetCurrentFunctionIsClass() As Boolean

    Function GetCurrentFunctionActions() As Generic.List(Of VelerSoftware.Plugins3.Action)

    Function GetActionsOfFuntion(ByVal function_name As String) As Generic.List(Of VelerSoftware.Plugins3.Action)

    Function GetCurrentDocumentName() As String

    Function GetCurrentDocumentFileName() As String

    Function GetPropertyList(ByVal [Type] As String) As Generic.List(Of System.Reflection.PropertyInfo)

    Function GetMethodList(ByVal [Type] As String) As Generic.List(Of System.Reflection.MethodInfo)

    Function GetCurrentProjectFunctions() As Generic.List(Of String)

    Function GetSolutionFunctions() As Generic.List(Of String)

    Function AddVBNetFileToCurrentProject(ByVal File_Name As String) As Boolean

    Function SelectType() As Type

    Function SelectControl(Optional AllowSelectForm As Boolean = True, Optional OnlyFollowingControlsTypes As String() = Nothing, Optional OnlyFollowingPropertiesTypes As String() = Nothing) As String

    Function SelectControlProperty(Optional AllowSelectFormProperties As Boolean = True, Optional OnlyArrayProperty As Boolean = False, Optional OnlyFollowingControlsTypes As String() = Nothing, Optional OnlyFollowingPropertiesTypes As String() = Nothing) As String

    Function TransformKeyVariables(ByVal Param As String, ByVal IsText As Boolean, Optional WithOperator As Boolean = True) As String

    Function GetParentAction(ByVal Action As VelerSoftware.Plugins3.Action) As VelerSoftware.Plugins3.Action

    Function GetParentsAction(ByVal Action As VelerSoftware.Plugins3.Action) As Generic.List(Of VelerSoftware.Plugins3.Action)

    Function ShowVariableManager() As System.Windows.Forms.DialogResult

End Interface
