''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Drawing

Namespace VistaDialog

	''' <summary>
	''' Helper class required by LockSystem feature.
	''' </summary>
	Friend Class VDialogLockSystemParameters
		Public NewDesktop As IntPtr
		Public Background As Bitmap
		Public Sub New(ByVal newDesktop As IntPtr, ByVal background As Bitmap)
			Me.NewDesktop = newDesktop
			Me.Background = background
		End Sub
	End Class

End Namespace