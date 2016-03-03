''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace VistaDialog

    ''' <summary>
    ''' Specifies identifiers to indicate the return value of a VDialog.
    ''' </summary>
    Public Enum VDialogResult
        ''' <summary>
        ''' Nothing is returned from the VDialog. This means that the modal dialog continues running.
        ''' </summary>
        None = 0
        ''' <summary>
        ''' The VDialog return value is OK (usually sent from a button labeled OK).
        ''' </summary>
        OK = 1
        ''' <summary>
        ''' The VDialog return value is Cancel (usually sent from a button labeled Cancel).
        ''' </summary>
        Cancel = 2
        ''' <summary>
        ''' The VDialog return value is Close (usually sent from a button labeled Close).
        ''' </summary>
        Close = 3
        ''' <summary>
        ''' The VDialog return value is Yes (usually sent from a button labeled Yes).
        ''' </summary>
        Yes = 4
        ''' <summary>
        ''' The VDialog return value is No (usually sent from a button labeled No).
        ''' </summary>
        No = 5
        ''' <summary>
        ''' The VDialog return value is YesToAll (usually sent from a button labeled Yes to All).
        ''' </summary>
        YesToAll = 6
        ''' <summary>
        ''' The VDialog return value is NoToAll (usually sent from a button labeled No to All).
        ''' </summary>
        NoToAll = 7
        ''' <summary>
        ''' The VDialog return value is Abort (usually sent from a button labeled Abort).
        ''' </summary>
        Abort = 8
        ''' <summary>
        ''' The VDialog return value is Retry (usually sent from a button labeled Retry).
        ''' </summary>
        Retry = 9
        ''' <summary>
        ''' The VDialog return value is Ignore (usually sent from a button labeled Ignore).
        ''' </summary>
        Ignore = 10
        ''' <summary>
        ''' The VDialog return value is Continue (usually sent from a button labeled Continue).
        ''' </summary>
        [Continue] = 11
    End Enum

End Namespace
