Imports System.Drawing



''' <summary>
''' Helper class required by LockSystem feature.
''' </summary>
Friend Class VistaMessageBoxLockSystemParameters
	Public NewDesktop As IntPtr
	Public Background As Bitmap
	Public Sub New(ByVal newDesktop As IntPtr, ByVal background As Bitmap)
		Me.NewDesktop = newDesktop
		Me.Background = background
	End Sub
End Class

