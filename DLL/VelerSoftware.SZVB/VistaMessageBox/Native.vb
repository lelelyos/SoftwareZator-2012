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

Namespace VistaDialog

	''' <summary>
	''' Win32 API needed for LockSystem mode.
	''' </summary>
	''' <remarks></remarks>
	<HideModuleName()> _
	Friend Module Native

		Public Const GENERIC_ALL As Integer = &H10000000
		Public Const DESKTOP_SWITCHDESKTOP As Integer = &H100L

		Public Declare Auto Function GetThreadDesktop Lib "user32.dll" (ByVal threadId As Integer) As IntPtr
		Public Declare Auto Function OpenInputDesktop Lib "user32.dll" (ByVal flags As Integer, <MarshalAs(UnmanagedType.Bool)> ByVal inherit As Boolean, ByVal desiredAccess As Integer) As IntPtr
		Public Declare Auto Function CreateDesktop Lib "user32.dll" (ByVal desktop As String, ByVal device As String, ByVal devmode As IntPtr, ByVal flags As Integer, ByVal desiredAccess As Integer, ByVal lpsa As IntPtr) As IntPtr
		Public Declare Auto Function SetThreadDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
		Public Declare Auto Function SwitchDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
		Public Declare Auto Function CloseDesktop Lib "user32.dll" (ByVal desktop As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

	End Module

End Namespace