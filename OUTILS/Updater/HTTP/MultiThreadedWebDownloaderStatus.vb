''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Enum MultiThreadedWebDownloaderStatus
    Idle = 0
    Checked = 1
    Downloading = 2
    Pausing = 3
    Paused = 4
    Canceling = 5
    Canceled = 6
    Completed = 7
End Enum

