Imports System.Windows.Forms
Imports System.Drawing



''' <summary>
''' Form used in LockSystem mode. Contains an image of grayed desktop.
''' </summary>
Friend Class BackgroundForm
	Inherits Form

	Private background As Bitmap

	Public Sub New(ByVal background As Bitmap)
		Me.BackColor = Color.Black
		Me.FormBorderStyle = FormBorderStyle.None
		Me.Location = Point.Empty
		Me.Size = Screen.PrimaryScreen.Bounds.Size
		Me.StartPosition = FormStartPosition.Manual
		Me.Visible = True
		Me.background = background
	End Sub

	Protected Overrides Sub OnShown(ByVal e As System.EventArgs)
		Me.BackgroundImage = background
		Me.DoubleBuffered = True
		MyBase.OnShown(e)
	End Sub

End Class

