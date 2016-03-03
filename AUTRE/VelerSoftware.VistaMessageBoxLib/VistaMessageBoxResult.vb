

''' <summary>
''' Specifies identifiers to indicate the return value of a VistaMessageBox.
''' </summary>
Public Enum VistaMessageBoxResult
	''' <summary>
	''' Nothing is returned from the VistaMessageBox. This means that the modal dialog continues running.
	''' </summary>
	None = 0
	''' <summary>
	''' The VistaMessageBox return value is OK (usually sent from a button labeled OK).
	''' </summary>
	OK = 1
	''' <summary>
	''' The VistaMessageBox return value is Cancel (usually sent from a button labeled Cancel).
	''' </summary>
	Cancel = 2
	''' <summary>
	''' The VistaMessageBox return value is Close (usually sent from a button labeled Close).
	''' </summary>
	Close = 3
	''' <summary>
	''' The VistaMessageBox return value is Yes (usually sent from a button labeled Yes).
	''' </summary>
	Yes = 4
	''' <summary>
	''' The VistaMessageBox return value is No (usually sent from a button labeled No).
	''' </summary>
	No = 5
	''' <summary>
	''' The VistaMessageBox return value is YesToAll (usually sent from a button labeled Yes to All).
	''' </summary>
	YesToAll = 6
	''' <summary>
	''' The VistaMessageBox return value is NoToAll (usually sent from a button labeled No to All).
	''' </summary>
	NoToAll = 7
	''' <summary>
	''' The VistaMessageBox return value is Abort (usually sent from a button labeled Abort).
	''' </summary>
	Abort = 8
	''' <summary>
	''' The VistaMessageBox return value is Retry (usually sent from a button labeled Retry).
	''' </summary>
	Retry = 9
	''' <summary>
	''' The VistaMessageBox return value is Ignore (usually sent from a button labeled Ignore).
	''' </summary>
	Ignore = 10
	''' <summary>
	''' The VistaMessageBox return value is Continue (usually sent from a button labeled Continue).
	''' </summary>
	[Continue] = 11
End Enum


