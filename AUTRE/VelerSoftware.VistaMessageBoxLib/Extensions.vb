Imports System.Windows.Forms



''' <summary>
''' Helper methods…
''' </summary>
<HideModuleName()> _
Friend Module Extensions

	Public Function [If](Of T)(ByVal Expression As Boolean, ByVal TruePart As T, ByVal FalsePart As T) As T
		If Expression Then
			Return TruePart
		End If
		Return FalsePart
	End Function

	Public Function GetButtonName(ByVal button As VistaMessageBoxResult) As String

		Select Case button

			Case VistaMessageBoxResult.Abort
				Return My.Resources.AbortText

			Case VistaMessageBoxResult.Cancel
				Return My.Resources.CancelText

			Case VistaMessageBoxResult.Close
				Return My.Resources.CloseText

			Case VistaMessageBoxResult.Continue
				Return My.Resources.ContinueText

			Case VistaMessageBoxResult.Ignore
				Return My.Resources.IgnoreText

			Case VistaMessageBoxResult.No
				Return My.Resources.NoText

			Case VistaMessageBoxResult.NoToAll
				Return My.Resources.NoToAllText

			Case VistaMessageBoxResult.OK
				Return My.Resources.OKText

			Case VistaMessageBoxResult.Retry
				Return My.Resources.RetryText

			Case VistaMessageBoxResult.Yes
				Return My.Resources.YesText

			Case VistaMessageBoxResult.YesToAll
				Return My.Resources.YesToAllText

			Case Else
				Return My.Resources.NoneText
		End Select

	End Function

	Public Function MakeDialogResult(ByVal Result As VistaMessageBoxResult) As DialogResult
		Select Case Result
			Case VistaMessageBoxResult.Abort
				Return DialogResult.Abort
			Case VistaMessageBoxResult.Cancel, VistaMessageBoxResult.Close
				Return DialogResult.Cancel
			Case VistaMessageBoxResult.Ignore
				Return DialogResult.Ignore
			Case VistaMessageBoxResult.No, VistaMessageBoxResult.NoToAll
				Return DialogResult.No
			Case VistaMessageBoxResult.OK, VistaMessageBoxResult.Continue
				Return DialogResult.OK
			Case VistaMessageBoxResult.Retry
				Return DialogResult.Retry
			Case VistaMessageBoxResult.Yes, VistaMessageBoxResult.YesToAll
				Return DialogResult.Yes
			Case Else
				Return DialogResult.None
		End Select
	End Function

	Public Function MakeVistaMessageBoxDefaultButton(ByVal DefaultButton As MessageBoxDefaultButton) As VistaMessageBoxDefaultButton
		Select Case DefaultButton
			Case MessageBoxDefaultButton.Button1
				Return VistaMessageBoxDefaultButton.Button1
			Case MessageBoxDefaultButton.Button2
				Return VistaMessageBoxDefaultButton.Button2
			Case MessageBoxDefaultButton.Button3
				Return VistaMessageBoxDefaultButton.Button3
			Case Else
				Return VistaMessageBoxDefaultButton.None
		End Select
	End Function
End Module

