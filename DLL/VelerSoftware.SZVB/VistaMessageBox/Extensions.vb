''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Windows.Forms

Namespace VistaDialog

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

		Public Function GetButtonName(ByVal button As VDialogResult) As String

			Select Case button

                Case VDialogResult.Abort
                    If Langue = "fr" Then Return My.Resources.AbortText Else Return My.Resources.AbortText_EN

                Case VDialogResult.Cancel
                    If Langue = "fr" Then Return My.Resources.CancelText Else Return My.Resources.CancelText_EN

                Case VDialogResult.Close
                    If Langue = "fr" Then Return My.Resources.CloseText Else Return My.Resources.CloseText_EN

                Case VDialogResult.Continue
                    If Langue = "fr" Then Return My.Resources.ContinueText Else Return My.Resources.ContinueText_EN

                Case VDialogResult.Ignore
                    If Langue = "fr" Then Return My.Resources.IgnoreText Else Return My.Resources.IgnoreText_EN

                Case VDialogResult.No
                    If Langue = "fr" Then Return My.Resources.NoText Else Return My.Resources.NoText_EN

                Case VDialogResult.NoToAll
                    If Langue = "fr" Then Return My.Resources.NoToAllText Else Return My.Resources.NoToAllText_EN

                Case VDialogResult.OK
                    If Langue = "fr" Then Return My.Resources.OKText Else Return My.Resources.OKText_EN

                Case VDialogResult.Retry
                    If Langue = "fr" Then Return My.Resources.RetryText Else Return My.Resources.RetryText_EN

                Case VDialogResult.Yes
                    If Langue = "fr" Then Return My.Resources.YesText Else Return My.Resources.YesText_EN

                Case VDialogResult.YesToAll
                    If Langue = "fr" Then Return My.Resources.YesToAllText Else Return My.Resources.YesToAllText_EN

                Case Else
                    If Langue = "fr" Then Return My.Resources.NoneText Else Return My.Resources.NoneText_EN
            End Select

		End Function

		Public Function MakeDialogResult(ByVal Result As VDialogResult) As DialogResult
			Select Case Result
				Case VDialogResult.Abort
					Return DialogResult.Abort
				Case VDialogResult.Cancel, VDialogResult.Close
					Return DialogResult.Cancel
				Case VDialogResult.Ignore
					Return DialogResult.Ignore
				Case VDialogResult.No, VDialogResult.NoToAll
					Return DialogResult.No
				Case VDialogResult.OK, VDialogResult.Continue
					Return DialogResult.OK
				Case VDialogResult.Retry
					Return DialogResult.Retry
				Case VDialogResult.Yes, VDialogResult.YesToAll
					Return DialogResult.Yes
				Case Else
					Return DialogResult.None
			End Select
		End Function

		Public Function MakeVDialogDefaultButton(ByVal DefaultButton As MessageBoxDefaultButton) As VDialogDefaultButton
			Select Case DefaultButton
				Case MessageBoxDefaultButton.Button1
					Return VDialogDefaultButton.Button1
				Case MessageBoxDefaultButton.Button2
					Return VDialogDefaultButton.Button2
				Case MessageBoxDefaultButton.Button3
					Return VDialogDefaultButton.Button3
				Case Else
					Return VDialogDefaultButton.None
			End Select
		End Function
	End Module

End Namespace