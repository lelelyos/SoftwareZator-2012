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
	''' Specifies constants defining which icon to display on what background.
	''' </summary>
	Public Enum VDialogIcon
		''' <summary>
		''' The VDialog contains no icon. The background is white.
		''' </summary>
		None
		''' <summary>
		''' The VDialog contains a symbol consisting of a lowercase letter i in a circle. The background is white.
		''' </summary>
		Information
		''' <summary>
		''' The VDialog contains a symbol consisting of a question mark in a circle. The background is white.
		''' </summary>
		Question
		''' <summary>
		''' The VDialog contains a symbol consisting of an exclamation point in a yellow triangle. The background is white.
		''' </summary>
		Warning
		''' <summary>
		''' The VDialog contains a symbol consisting of white X in a red circle. The background is white.
		''' </summary>
		[Error]
		''' <summary>
		''' The VDialog contains a symbol consisting of white check mark in a green shield. The background is green.
		''' </summary>
		SecuritySuccess
		''' <summary>
		''' The VDialog contains a symbol consisting of a question mark in a blue shield. The background is blue.
		''' </summary>
		SecurityQuestion
		''' <summary>
		''' The VDialog contains a symbol consisting of an exclamation point in a yellow shield. The background is yellow.
		''' </summary>
		SecurityWarning
		''' <summary>
		''' The VDialog contains a symbol consisting of white X in a red shield. The background is red.
		''' </summary>
		SecurityError
		''' <summary>
		''' The VDialog contains a symbol of a multicolored shield. The background is white.
		''' </summary>
		SecurityShield
		''' <summary>
		''' The VDialog contains a symbol of a multicolored shield. The background is blue-to-green gradient.
		''' </summary>
		SecurityShieldBlue
		''' <summary>
		''' The VDialog contains a symbol of a multicolored shield. The background is gray.
		''' </summary>
		SecurityShieldGray
	End Enum

	Public Module VDialogBigIcon
		Public ReadOnly Question As Image = My.Resources.Question
		Public ReadOnly Information As Image = My.Resources.Information
		Public ReadOnly Warning As Image = My.Resources.Warning_VistaDialog
		Public ReadOnly [Error] As Image = My.Resources.Error_VistaDialog
		Public ReadOnly Security As Image = My.Resources.Security
		Public ReadOnly SecuritySuccess As Image = My.Resources.SecuritySuccess
		Public ReadOnly SecurityQuestion As Image = My.Resources.SecurityQuestion
		Public ReadOnly SecurityWarning As Image = My.Resources.SecurityWarning
		Public ReadOnly SecurityError As Image = My.Resources.SecurityError
	End Module

	Public Module VDialogSmallIcon
		Public ReadOnly Question As Image = My.Resources.SmallQuestion
		Public ReadOnly Information As Image = My.Resources.SmallInformation
		Public ReadOnly Warning As Image = My.Resources.SmallWarning
		Public ReadOnly [Error] As Image = My.Resources.SmallError
		Public ReadOnly Security As Image = My.Resources.SmallSecurity
		Public ReadOnly SecuritySuccess As Image = My.Resources.SmallSecuritySucess
		Public ReadOnly SecurityQuestion As Image = My.Resources.SmallSecurityQuestion
		Public ReadOnly SecurityWarning As Image = My.Resources.SmallSecurityWarning
		Public ReadOnly SecurityError As Image = My.Resources.SmallSecurityError
	End Module

End Namespace