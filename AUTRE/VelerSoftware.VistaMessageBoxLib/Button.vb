

''' <summary>
''' Button which preferred width is always divisible by 25.
''' </summary>
Friend Class Button

	Public Overrides Function GetPreferredSize(ByVal proposedSize As System.Drawing.Size) As System.Drawing.Size

		proposedSize = MyBase.GetPreferredSize(proposedSize)
		proposedSize.Width += 24
		If Image IsNot Nothing Then proposedSize.Width += Image.Width
		proposedSize.Width -= proposedSize.Width Mod 25
		proposedSize.Width = [If](proposedSize.Width < 75, 75, proposedSize.Width)
		proposedSize.Height = [If](proposedSize.Height < 25, 25, proposedSize.Height)
		Return proposedSize

	End Function

End Class

