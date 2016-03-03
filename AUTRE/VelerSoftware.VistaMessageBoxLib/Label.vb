Imports System.Drawing
Imports System.Windows.Forms



Friend Class Label

	Public Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		LinkColor = Color.FromArgb(0, 102, 204)
		ActiveLinkColor = LinkColor
		DisabledLinkColor = Color.FromArgb(126, 133, 156)

	End Sub

	Public Overrides Function GetPreferredSize(ByVal proposedSize As System.Drawing.Size) As System.Drawing.Size

		proposedSize = MyBase.GetPreferredSize(proposedSize)
		Dim w As Integer = Screen.FromControl(Me).WorkingArea.Width \ 2
		proposedSize.Width = [If](w < proposedSize.Width, w, proposedSize.Width)
		Return MyBase.GetPreferredSize(proposedSize)

	End Function
End Class

