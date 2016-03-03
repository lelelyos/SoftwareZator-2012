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
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Partial Friend NotInheritable Class NativeMethods

    Friend Declare Function CreateDIBSection Lib "gdi32.dll" (ByVal hdc As IntPtr, ByRef pbmi As Windows.DWM.BITMAPINFO, ByVal iUsage As UInt32, ByVal ppvBits As Integer, ByVal hSection As IntPtr, ByVal dwOffset As UInt32) As IntPtr
    Friend Declare Function BitBlt Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As Int32) As Boolean


#Region "Method Imports"

#Region "dwmapi"

    ''' <summary>
    ''' Extends the window frame behind the client area.
    ''' </summary>
    ''' <param name="hWnd">The handle to the window for which the frame is extended into the client area</param>
    ''' <param name="pMarInset">[in] A pointer to a MARGINS structure that describes the margins to use when extending the frame into the client area</param>
    ''' <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    ''' <remarks>This function must be called whenever Desktop Window Manager (DWM) composition is toggled. 
    ''' Handle the WM_DWMCOMPOSITIONCHANGED message for composition change notification. 
    ''' Negative margins are used to create the "sheet of glass" effect where the client area is rendered as a solid surface with no window border.
    ''' </remarks>
    <DllImport("dwmapi.dll", SetLastError:=True)> _
    Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As MARGINS) As IntPtr
    End Function

    ''' <summary>
    ''' Obtains a value that indicates whether Desktop Window Manager (DWM) composition is enabled. 
    ''' Applications can listen for composition state changes by handling the WM_DWMCOMPOSITIONCHANGED notification.
    ''' </summary>
    ''' <param name="pfEnabled">[out] A pointer to a Boolean value that receives TRUE if DWM composition is enabled; otherwise, FALSE.</param>
    ''' <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    <DllImport("dwmapi.dll", SetLastError:=True)> _
    Public Shared Function DwmIsCompositionEnabled(<MarshalAs(UnmanagedType.Bool)> ByVal pfEnabled As Boolean) As IntPtr
    End Function

    ''' <summary>
    ''' Enables the blur effect on a specified window.
    ''' </summary>
    ''' <param name="hwnd">The handle to the window on which the blur behind data is applied.</param>
    ''' <param name="blurBehind">[in] A pointer to a DWM_BLURBEHIND structure that provides blur behind data.</param>
    ''' <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    ''' <remarks>
    ''' Enabling blur by setting pBlurBehind's fEnable to TRUE results in subsequent compositions of the window having the content underneath it blurred. This function should be called immediately before a BeginPaint call to ensure prompt application of the effect.
    ''' 
    ''' The alpha values in the window are honored and the rendering atop the blur will use these alpha values. It is the application's responsibility for ensuring that the alpha values of all pixels in the window are correct. Some Windows Graphics Device Interface (GDI) operations do not preserve alpha values, so care must be taken when presenting child windows because the alpha values they contribute are unpredictable.
    ''' 
    ''' The region specified within the DWM_BLURBEHIND is owned by the caller. It is the caller's responsibility to free the region, and they can do so as soon as the function call is completed.
    ''' 
    ''' This function can only be called on top-level windows. An error will result when called on other window types.
    ''' 
    ''' This function must be called whenver Desktop Window Manager (DWM) composition is toggled. Handle the WM_DWMCOMPOSITIONCHANGED message for composition change notification.
    ''' </remarks>
    <DllImport("dwmapi.dll", SetLastError:=True)> _
    Public Shared Function DwmEnableBlurBehindWindow(ByVal hwnd As IntPtr, ByRef blurBehind As DWM_BLURBEHIND) As IntPtr
    End Function

    '''// <summary>
    '''// Retrieves the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color scheme and is modifiable by the user. Applications can listen for color changes by handling the WM_DWMCOLORIZATIONCOLORCHANGED notification.
    '''// </summary>
    '''// <param name="pcrColorization">[out] A pointer to a value that, when this function returns successfully, receives the current color used for glass composition. The color format of the value is 0xAARRGGBB.</param>
    '''// <param name="pfOpaqueBlend">[out] A pointer to a value that, when this function returns successfully, indicates whether the color is an opaque blend. TRUE if the color is an opaque blend; otherwise, FALSE.</param>
    '''// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    '''// <remarks>
    '''// The value pointed to by pcrColorization is in an 0xAARRGGBB format. Many Microsoft Win32 APIs, such as COLORREF, use a 0x00BBGGRR format. Care must be taken to assure the intended colors are used.
    '''// </remarks>
    '[DllImport("dwmapi.dll", SetLastError = true)]
    'public static extern IntPtr DwmGetColorizationColor(out int pcrColorization, [MarshalAs(UnmanagedType.Bool)]out bool pfOpaqueBlend);

#End Region

#Region "uxtheme"

    ''' <summary>
    ''' Draws text using the color and font defined by the visual style. Extends DrawThemeText by allowing additional text format options.
    ''' </summary>
    ''' <param name="hTheme">[in] Handle to a window's specified theme data. Use OpenThemeData to create an HTHEME.</param>
    ''' <param name="hdc">[in] Handle to a device context (HDC) to use for drawing.</param>
    ''' <param name="iPartId">[in] The control part that has the desired text appearance. See Parts and States. If this value is 0, the text is drawn in the default font, or a font selected into the device context.</param>
    ''' <param name="iStateId">[in] The control state that has the desired text appearance. See Parts and States.</param>
    ''' <param name="pszText">[in] Pointer to a string that contains the text to draw.</param>
    ''' <param name="iCharCount">[in] Value of type int that contains the number of characters to draw. If the parameter is set to -1, all the characters in the string are drawn.</param>
    ''' <param name="dwFlags">[in] DWORD that contains one or more values that specify the string's formatting. See Format Values for possible parameter values.</param>
    ''' <param name="pRect">[in, out] Pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be drawn.</param>
    ''' <param name="pOptions">[in] A DTTOPTS structure that defines additional formatting options that will be applied to the text being drawn.</param>
    ''' <returns>Returns S_OK if successful, or an error value otherwise.</returns>
    ''' <remarks>
    ''' The function always uses the themed font for the specified part and state if one is defined. Otherwise it uses the font currently selected into the device context. To find out if a themed font is defined, you can call GetThemeFont or GetThemePropertyOrigin with TMT_FONT as the property identifier.
    ''' </remarks>
    <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Public Shared Function DrawThemeTextEx(ByVal hTheme As IntPtr, ByVal hdc As IntPtr, ByVal iPartId As Integer, ByVal iStateId As Integer, ByVal pszText As String, ByVal iCharCount As Integer, _
   ByVal dwFlags As TextFormatFlags, ByRef pRect As RECT, ByRef pOptions As DTTOPTS) As IntPtr
    End Function

#End Region

#Region "user32"

    ''' <summary>
    ''' Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message. 
    '''
    ''' To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
    ''' </summary>
    ''' <param name="hWnd">[in] Handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
    ''' Microsoft Windows Vista and later. Message sending is subject to User Interface Privilege Isolation (UIPI). The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
    ''' </param>
    ''' <param name="Msg">[in] Specifies the message to be sent.</param>
    ''' <param name="wParam">[in] Specifies additional message-specific information.</param>
    ''' <param name="lParam">[in] Specifies additional message-specific information.</param>
    ''' <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    ''' <remarks>Microsoft Windows Vista and later. When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).
    '''
    ''' Applications that need to communicate using HWND_BROADCAST should use the RegisterWindowMessage function to obtain a unique message for inter-application communication.
    '''
    ''' The system only does marshalling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those >= WM_USER) to another process, you must do custom marshalling.
    '''
    ''' If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine. If the specified window was created by a different thread, the system switches to that thread and calls the appropriate window procedure. Messages sent between threads are processed only when the receiving thread executes message retrieval code. The sending thread is blocked until the receiving thread processes the message. However, the sending thread will process incoming nonqueued messages while waiting for its message to be processed. To prevent this, use SendMessageTimeout with SMTO_BLOCK set. For more information on nonqueued messages, see Nonqueued Messages.
    '''
    ''' Windows 95/98/Me: SendMessageW is supported by the Microsoft Layer for Unicode (MSLU). To use this, you must add certain files to your application, as outlined in Microsoft Layer for Unicode on Windows 95/98/Me Systems.
    ''' </remarks>
    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByRef lParam As TCHITTESTINFO) As IntPtr
    End Function

#End Region

#Region "gdi32"

    ''' <summary>
    ''' The BitBlt function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the specified source device context into a destination device context.
    ''' </summary>
    ''' <param name="hdcDest">[in] A handle to the destination device context.</param>
    ''' <param name="nXDest">[in] The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
    ''' <param name="nYDest">[in] The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
    ''' <param name="nWidth">[in] The width, in logical units, of the source and destination rectangles.</param>
    ''' <param name="nHeight">[in] The height, in logical units, of the source and the destination rectangles.</param>
    ''' <param name="hdcSrc">[in] The height, in logical units, of the source and the destination rectangles.</param>
    ''' <param name="nXSrc">[in] The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
    ''' <param name="nYSrc">[in] The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
    ''' <param name="dwRop">[in] A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.</param>
    ''' <returns>If the function succeeds, the return value is nonzero.
    ''' If the function fails, the return value is zero.
    ''' </returns>
    ''' <remarks>
    ''' BitBlt only does clipping on the destination DC.
    ''' 
    ''' If a rotation or shear transformation is in effect in the source device context, BitBlt returns an error. If other transformations exist in the source device context (and a matching transformation is not in effect in the destination device context), the rectangle in the destination device context is stretched, compressed, or rotated, as necessary.
    '''
    ''' If the color formats of the source and destination device contexts do not match, the BitBlt function converts the source color format to match the destination format.
    '''
    ''' When an enhanced metafile is being recorded, an error occurs if the source device context identifies an enhanced-metafile device context.
    '''
    ''' Not all devices support the BitBlt function. For more information, see the RC_BITBLT raster capability entry in the GetDeviceCaps function as well as the following functions: MaskBlt, PlgBlt, and StretchBlt.
    '''
    ''' BitBlt returns an error if the source and destination device contexts represent different devices. To transfer data between DCs for different devices, convert the memory bitmap to a DIB by calling GetDIBits. To display the DIB to the second device, call SetDIBits or StretchDIBits.
    '''
    ''' ICM: No color management is performed when blits occur.
    ''' </remarks>
    <DllImport("gdi32.dll")> _
    Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
   ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ''' <summary>
    ''' The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.
    ''' </summary>
    ''' <param name="hdc">[in] A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
    ''' </param>
    ''' <returns>If the function succeeds, the return value is the handle to a memory DC.
    ''' If the function fails, the return value is NULL.
    ''' </returns>
    ''' <remarks>
    ''' A memory DC exists only in memory. When the memory DC is created, its display surface is exactly one monochrome pixel wide and one monochrome pixel high. Before an application can use a memory DC for drawing operations, it must select a bitmap of the correct width and height into the DC. To select a bitmap into a DC, use the CreateCompatibleBitmap function, specifying the height, width, and color organization required.
    '''
    ''' When a memory DC is created, all attributes are set to normal default values. The memory DC can be used as a normal DC. You can set the attributes; obtain the current settings of its attributes; and select pens, brushes, and regions.
    '''
    ''' The CreateCompatibleDC function can only be used with devices that support raster operations. An application can determine whether a device supports these operations by calling the GetDeviceCaps function.
    '''
    ''' When you no longer need the memory DC, call the DeleteDC function.
    '''
    ''' If hdc is NULL, the thread that calls CreateCompatibleDC owns the HDC that is created. When this thread is destroyed, the HDC is no longer valid. Thus, if you create the HDC andpass it to another thread, then exit the first thread, the second thread will not be able to use the HDC.
    '''
    ''' ICM: If the DC that is passed to this function is enabled for Image Color Management (ICM), the DC created by the function is ICM-enabled. The source and destination color spaces are specified in the DC.
    ''' </remarks>
    <DllImport("gdi32.dll")> _
    Public Shared Function CreateCompatibleDC(ByVal hdc As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' CreateDIBSection Function
    '''
    ''' The CreateDIBSection function creates a DIB that applications can write to directly. The function gives you a pointer to the location of the bitmap bit values. You can supply a handle to a file-mapping object that the function will use to create the bitmap, or you can let the system allocate the memory for the bitmap.
    ''' </summary>
    ''' <param name="hdc">[in] A handle to a device context. If the value of iUsage is DIB_PAL_COLORS, the function uses this device context's logical palette to initialize the DIB colors.</param>
    ''' <param name="pbmi">[in] A pointer to a BITMAPINFO structure that specifies various attributes of the DIB, including the bitmap dimensions and colors.</param>
    ''' <param name="iUsage">[in] The type of data contained in the bmiColors array member of the BITMAPINFO structure pointed to by pbmi (either logical palette indexes or literal RGB values).</param>
    ''' <param name="ppvBits">[out] A pointer to a variable that receives a pointer to the location of the DIB bit values.</param>
    ''' <param name="hSection">[in] A handle to a file-mapping object that the function will use to create the DIB. This parameter can be NULL.
    '''
    ''' If hSection is not NULL, it must be a handle to a file-mapping object created by calling the CreateFileMapping function with the PAGE_READWRITE or PAGE_WRITECOPY flag. Read-only DIB sections are not supported. Handles created by other means will cause CreateDIBSection to fail.
    '''
    ''' If hSection is not NULL, the CreateDIBSection function locates the bitmap bit values at offset dwOffset in the file-mapping object referred to by hSection. An application can later retrieve the hSection handle by calling the GetObject function with the HBITMAP returned by CreateDIBSection.
    '''
    ''' If hSection is NULL, the system allocates memory for the DIB. In this case, the CreateDIBSection function ignores the dwOffset parameter. An application cannot later obtain a handle to this memory. The dshSection member of the DIBSECTION structure filled in by calling the GetObject function will be NULL.
    ''' </param>
    ''' <param name="dwOffset">[in] The offset from the beginning of the file-mapping object referenced by hSection where storage for the bitmap bit values is to begin. This value is ignored if hSection is NULL. The bitmap bit values are aligned on doubleword boundaries, so dwOffset must be a multiple of the size of a DWORD.</param>
    ''' <returns>If the function succeeds, the return value is a handle to the newly created DIB, and *ppvBits points to the bitmap bit values.
    '''
    ''' If the function fails, the return value is NULL, and *ppvBits is NULL.
    ''' </returns>
    <DllImport("gdi32.dll")> _
    Public Shared Function CreateDIBSection(ByVal hdc As IntPtr, ByVal pbmi As BITMAPINFO, ByVal iUsage As UInteger, ByVal ppvBits As IntPtr, ByVal hSection As IntPtr, ByVal dwOffset As UInteger) As IntPtr
    End Function

    ''' <summary>
    ''' The DeleteDC function deletes the specified device context (DC).
    ''' </summary>
    ''' <param name="hdc">[in] A handle to the device context.</param>
    ''' <returns>If the function succeeds, the return value is nonzero.
    '''
    ''' If the function fails, the return value is zero.
    ''' </returns>
    <DllImport("gdi32.dll", SetLastError:=True)> _
    Public Shared Function DeleteDC(ByVal hdc As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ''' <summary>
    ''' The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
    ''' </summary>
    ''' <param name="hObject">[in] A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
    ''' <returns>If the function succeeds, the return value is nonzero.
    '''
    ''' If the specified handle is not valid or is currently selected into a DC, the return value is zero.
    ''' </returns>
    ''' <remarks>
    ''' Do not delete a drawing object (pen or brush) while it is still selected into a DC.
    '''
    ''' When a pattern brush is deleted, the bitmap associated with the brush is not deleted. The bitmap must be deleted independently
    ''' </remarks>
    <DllImport("gdi32.dll", SetLastError:=True)> _
    Public Shared Function DeleteObject(ByVal hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    ''' <summary>
    ''' The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
    ''' </summary>
    ''' <param name="hdc">[in] A handle to the DC.</param>
    ''' <param name="hObject">[in] A handle to the object to be selected.</param>
    ''' <returns>If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced.
    ''' If the selected object is a region and the function succeeds, the return value is one of the following values.
    ''' SIMPLEREGION    Region consists of a single rectangle.
    ''' COMPLEXREGION   Region consists of more than one rectangle.
    ''' NULLREGION      Region is empty.
    ''' 
    ''' If an error occurs and the selected object is not a region, the return value is NULL. Otherwise, it is HGDI_ERROR.
    ''' </returns>
    ''' <remarks>
    ''' This function returns the previously selected object of the specified type. An application should always replace a new object with the original, default object after it has finished drawing with the new object.
    '''
    ''' An application cannot select a single bitmap into more than one DC at a time.
    '''
    ''' ICM: If the object being selected is a brush or a pen, color management is performed.
    ''' </remarks>
    <DllImport("gdi32.dll")> _
    Public Shared Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
    End Function

#End Region

#End Region

#Region "Structures"

    ''' <summary>
    ''' The BITMAPINFO structure defines the dimensions and color information for a DIB.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Class BITMAPINFO
        ''' <summary>
        ''' A BITMAPINFOHEADER structure that contains information about the dimensions of color format.
        ''' </summary>
        Public biHdr As BITMAPINFOHEADER
        ''' <summary>
        ''' The bmiColors member contains one of the following:
        '''
        ''' An array of RGBQUAD. The elements of the array that make up the color table.
        ''' 
        ''' An array of 16-bit unsigned integers that specifies indexes into the currently realized logical palette. This use of bmiColors is allowed for functions that use DIBs. When bmiColors elements contain indexes to a realized logical palette, they must also call the following bitmap functions:
        ''' \tCreateDIBitmap
        ''' 
        ''' \tCreateDIBPatternBrush
        ''' 
        ''' \tCreateDIBSection
        ''' 
        ''' The iUsage parameter of CreateDIBSection must be set to DIB_PAL_COLORS.
        ''' 
        ''' The number of entries in the array depends on the values of the biBitCount and biClrUsed members of the BITMAPINFOHEADER structure.
        ''' 
        ''' The colors in the bmiColors table appear in order of importance. For more information, see the Remarks section.
        ''' </summary>
        <MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=256)> _
        Public bmiColors As RGBQUAD()
    End Class

    ''' <summary>
    ''' The BITMAPINFOHEADER structure contains information about the dimensions and color format of a DIB.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure BITMAPINFOHEADER
        ''' <summary>
        ''' The number of bytes required by the structure.
        ''' </summary>
        Public biSize As Integer
        ''' <summary>
        ''' The width of the bitmap, in pixels.
        ''' 
        ''' If biCompression is BI_JPEG or BI_PNG, the biWidth member specifies the width of the decompressed JPEG or PNG image file, respectively.
        ''' </summary>
        Public biWidth As Integer
        ''' <summary>
        ''' The height of the bitmap, in pixels. If biHeight is positive, the bitmap is a bottom-up DIB and its origin is the lower-left corner. If biHeight is negative, the bitmap is a top-down DIB and its origin is the upper-left corner.
        ''' 
        ''' If biHeight is negative, indicating a top-down DIB, biCompression must be either BI_RGB or BI_BITFIELDS. Top-down DIBs cannot be compressed.
        ''' 
        ''' If biCompression is BI_JPEG or BI_PNG, the biHeight member specifies the height of the decompressed JPEG or PNG image file, respectively.
        ''' </summary>
        Public biHeight As Integer
        ''' <summary>
        ''' The number of planes for the target device. This value must be set to 1.
        ''' </summary>
        Public biPlanes As Short
        ''' <summary>
        ''' The number of bits-per-pixel. The biBitCount member of the BITMAPINFOHEADER structure determines the number of bits that define each pixel and the maximum number of colors in the bitmap.
        ''' </summary>
        Public biBitCount As Short
        ''' <summary>
        ''' The type of compression for a compressed bottom-up bitmap (top-down DIBs cannot be compressed).
        ''' </summary>
        Public biCompression As BITMAPCOMPRESSION
        ''' <summary>
        ''' The size, in bytes, of the image. This may be set to zero for RGB bitmaps.
        '''
        ''' If biCompression is JPEG or PNG, biSizeImage indicates the size of the JPEG or PNG image buffer, respectively.
        ''' </summary>
        Public biSizeImage As Integer
        ''' <summary>
        ''' The horizontal resolution, in pixels-per-meter, of the target device for the bitmap. An application can use this value to select a bitmap from a resource group that best matches the characteristics of the current device.
        ''' </summary>
        Public biXPelsPerMeter As Integer
        ''' <summary>
        ''' The vertical resolution, in pixels-per-meter, of the target device for the bitmap.
        ''' </summary>
        Public biYPelsPerMeter As Integer
        ''' <summary>
        ''' 
        ''' The number of color indexes in the color table that are actually used by the bitmap. If this value is zero, the bitmap uses the maximum number of colors corresponding to the value of the biBitCount member for the compression mode specified by biCompression.
        '''
        ''' If biClrUsed is nonzero and the biBitCount member is less than 16, the biClrUsed member specifies the actual number of colors the graphics engine or device driver accesses. If biBitCount is 16 or greater, the biClrUsed member specifies the size of the color table used to optimize performance of the system color palettes. If biBitCount equals 16 or 32, the optimal color palette starts immediately following the three DWORD masks.
        '''
        ''' When the bitmap array immediately follows the BITMAPINFO structure, it is a packed bitmap. Packed bitmaps are referenced by a single pointer. Packed bitmaps require that the biClrUsed member must be either zero or the actual size of the color table.
        ''' </summary>
        Public biClrUsed As Integer
        ''' <summary>
        ''' The number of color indexes that are required for displaying the bitmap. If this value is zero, all colors are required.
        ''' </summary>
        Public biClrImportant As Integer
    End Structure

    ''' <summary>
    ''' Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MARGINS
        ''' <summary>
        ''' Width of the left border that retains its size.
        ''' </summary>
        Public cxLeftWidth As Integer
        ''' <summary>
        ''' Width of the right border that retains its size.
        ''' </summary>
        Public cxRightWidth As Integer
        ''' <summary>
        ''' Height of the top border that retains its size
        ''' </summary>
        Public cyTopHeight As Integer
        ''' <summary>
        ''' Height of the bottom border that retains its size.
        ''' </summary>
        Public cyBottomHeight As Integer
        ''' <summary>
        ''' Creates a MARGINS structure with specified values.
        ''' </summary>
        ''' <param name="leftWidth">Width of the left border that retains its size.</param>
        ''' <param name="rightWidth">Width of the right border that retains its size.</param>
        ''' <param name="topHeight">Height of the top border that retains its size.</param>
        ''' <param name="bottomHeight">Height of the bottom border that retains its size.</param>
        Public Sub New(ByVal leftWidth As Integer, ByVal rightWidth As Integer, ByVal topHeight As Integer, ByVal bottomHeight As Integer)
            cxLeftWidth = leftWidth
            cxRightWidth = rightWidth
            cyTopHeight = topHeight
            cyBottomHeight = bottomHeight
        End Sub
    End Structure

    ''' <summary>
    ''' Specifies Desktop Window Manager (DWM) blur behind properties.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DWM_BLURBEHIND
        ''' <summary>
        ''' A bitwise combination of DWM Blur Behind Constants values indicating which members are set.
        ''' </summary>
        Public dwFlags As DwmBlurBehindFlags
        ''' <summary>
        ''' TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.
        ''' </summary>
        Public fEnable As Boolean
        ''' <summary>
        ''' The region within the client area to apply the blur behind. A NULL value will apply the blur behind the entire client area.
        ''' </summary>
        Public hRgnBlur As IntPtr
        ''' <summary>
        ''' TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.
        ''' </summary>
        Public fTransitionOnMaximized As Boolean
    End Structure

    ''' <summary>
    ''' Contains information about a hit test. This structure supersedes the TC_HITTESTINFO structure. 
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure TCHITTESTINFO
        ''' <summary>
        ''' Position to hit test, in client coordinates.
        ''' </summary>
        Public pt As Point
        ''' <summary>
        ''' Variable that receives the results of a hit test.
        ''' </summary>
        Public flags As TCHITTESTFLAGS
        ''' <summary>
        ''' Creates a TCHITESTINFO structure with the designated coordinates.
        ''' </summary>
        ''' <param name="x">The x position to test.</param>
        ''' <param name="y">The y position to test.</param>
        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            pt = New Point(x, y)
            flags = TCHITTESTFLAGS.ONITEM
        End Sub
    End Structure

    ''' <summary>
    ''' The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        ''' <summary>
        ''' The x-coordinate of the upper-left corner of the rectangle.
        ''' </summary>
        Public left As Integer
        ''' <summary>
        ''' The y-coordinate of the upper-left corner of the rectangle.
        ''' </summary>
        Public top As Integer
        ''' <summary>
        ''' The x-coordinate of the lower-right corner of the rectangle.
        ''' </summary>
        Public right As Integer
        ''' <summary>
        ''' The y-coordinate of the lower-right corner of the rectangle
        ''' </summary>
        Public bottom As Integer
        ''' <summary>
        ''' Creates a RECT structure which conforms the bounds of the Rectangle passed in.
        ''' </summary>
        ''' <param name="rc"></param>
        Public Sub New(ByVal rc As Rectangle)
            left = rc.Left
            top = rc.Top
            right = rc.Right
            bottom = rc.Bottom
        End Sub
    End Structure

    ''' <summary>
    ''' Defines the options for the DrawThemeTextEx function.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure DTTOPTS
        ''' <summary>
        ''' Size of the structure.
        ''' </summary>
        Public dwSize As Integer
        ''' <summary>
        ''' A combination of flags that specify whether certain values of the DTTOPTS structure have been specified, and how to interpret these values.
        ''' </summary>
        Public dwFlags As DrawThemeTextFlags
        ''' <summary>
        ''' Specifies the color of the text that will be drawn.
        ''' </summary>
        Public crText As Integer
        ''' <summary>
        ''' Specifies the color of the outline that will be drawn around the text.
        ''' </summary>
        Public crBorder As Integer
        ''' <summary>
        ''' Specifies the color of the shadow that will be drawn behind the text.
        ''' </summary>
        Public crShadow As Integer
        ''' <summary>
        ''' Specifies the type of the shadow that will be drawn behind the text.
        ''' </summary>
        Public iTextShadowType As TextShadowType
        ''' <summary>
        ''' Specifies the amount of offset, in logical coordinates, between the shadow and the text.
        ''' </summary>
        Public ptShadowOffset As Point
        ''' <summary>
        ''' Specifies the radius of the outline that will be drawn around the text.
        ''' </summary>
        Public iBorderSize As Integer
        ''' <summary>
        ''' Specifies an alternate font property to use when drawing text. For a list of possible values, see GetThemeSysFont.
        ''' </summary>
        Public iFontPropId As Integer
        ''' <summary>
        ''' Specifies an alternate color property to use when drawing text. If this value is valid and the corresponding flag is set in dwFlags, this value will override the value of crText. See the values listed in GetSysColor for the nIndex parameter.
        ''' </summary>
        Public iColorPropId As Integer
        ''' <summary>
        ''' Specifies an alternate state to use. This member is not used by DrawThemeTextEx.
        ''' </summary>
        Public iStateId As Integer
        ''' <summary>
        ''' If TRUE, text will be drawn on top of the shadow and outline effects. If FALSE, just the shadow and outline effects will be drawn.
        ''' </summary>
        Public fApplyOverlay As Boolean
        ''' <summary>
        ''' Specifies the size of a glow that will be drawn on the background prior to any text being drawn.
        ''' </summary>
        Public iGlowSize As Integer
        ''' <summary>
        ''' Pointer to callback function for DrawThemeTextEx.
        ''' </summary>
        Public pfnDrawTextCallback As IntPtr
        ''' <summary>
        ''' Parameter for callback back function specified by pfnDrawTextCallback.
        ''' </summary>
        Public lParam As IntPtr
    End Structure

    ''' <summary>
    ''' The RGBQUAD structure describes a color consisting of relative intensities of red, green, and blue.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RGBQUAD
        ''' <summary>
        ''' The intensity of blue in the color.
        ''' </summary>
        Public rgbBlue As Byte
        ''' <summary>
        ''' The intensity of green in the color.
        ''' </summary>
        Public rgbGreen As Byte
        ''' <summary>
        ''' The intensity of red in the color.
        ''' </summary>
        Public rgbRed As Byte
        ''' <summary>
        ''' The intensity of Alpha in the color.
        ''' </summary>
        Public rgbAlpha As Byte
    End Structure

#End Region

#Region "Enumerations"

    ''' <summary>
    ''' 
    ''' </summary>
    Public Enum BITMAPCOMPRESSION
        ''' <summary>
        ''' An uncompressed format.
        ''' </summary>
        RGB
        ''' <summary>
        ''' A run-length encoded (RLE) format for bitmaps with 8 bpp. The compression format is a 2-byte format consisting of a count byte followed by a byte containing a color index.
        ''' </summary>
        RLE8
        ''' <summary>
        ''' An RLE format for bitmaps with 4 bpp. The compression format is a 2-byte format consisting of a count byte followed by two word-length color indexes.
        ''' </summary>
        RLE4
        ''' <summary>
        ''' Specifies that the bitmap is not compressed and that the color table consists of three DWORD color masks that specify the red, green, and blue components, respectively, of each pixel. This is valid when used with 16- and 32-bpp bitmaps.
        ''' </summary>
        BITFIELDS
        ''' <summary>
        ''' Indicates that the image is a JPEG image.
        ''' </summary>
        JPEG
        ''' <summary>
        ''' Indicates that the image is a PNG image.
        ''' </summary>
        PNG
    End Enum

    ''' <summary>
    ''' Flags used by DWM_BLURBEHIND to indicate which members have been set
    ''' </summary>
    <Flags()> _
    Public Enum DwmBlurBehindFlags As UInteger
        ''' <summary>
        ''' Indicates a value for fEnable has been specified.
        ''' </summary>
        DWM_BB_ENABLE = &H1
        ''' <summary>
        ''' Indicates a value for hRgnBlur has been specified.
        ''' </summary>
        DWM_BB_BLURREGION = &H2
        ''' <summary>
        ''' Indicates a value for fTransitionOnMaximized has been specified.
        ''' </summary>
        DWM_BB_TRANSITIONONMAXIMIZED = &H4
    End Enum

    ''' <summary>
    ''' The Return values of a TabControls HitTest.
    ''' </summary>
    <Flags()> _
    Public Enum TCHITTESTFLAGS
        ''' <summary>
        ''' The position is not over a tab.
        ''' </summary>
        NOWHERE = 1
        ''' <summary>
        ''' The position is over a tab's icon.
        ''' </summary>
        ONITEMICON = 2
        ''' <summary>
        ''' The position is over a tab's text.
        ''' </summary>
        ONITEMLABEL = 4
        ''' <summary>
        ''' The position is over a tab but not over its icon or its text. For owner-drawn tab controls, this value is specified if the position is anywhere over a tab.
        ''' </summary>
        ONITEM = ONITEMICON Or ONITEMLABEL
    End Enum

    ''' <summary>
    ''' The flags used by DrawThemeText & DrawThemeTextEx
    ''' </summary>
    <Flags()> _
    Public Enum DrawThemeTextFlags
        ''' <summary>
        ''' crText has been specified
        ''' </summary>
        DTT_TEXTCOLOR = &H1
        ''' <summary>
        ''' crBorder has been specified
        ''' </summary>
        DTT_BORDERCOLOR = &H2
        ''' <summary>
        ''' crShadow has been specified
        ''' </summary>
        DTT_SHADOWCOLOR = &H4
        ''' <summary>
        ''' iTextShadowType has been specified
        ''' </summary>
        DTT_SHADOWTYPE = &H8
        ''' <summary>
        ''' ptShadowOffset has been specified
        ''' </summary>
        DTT_SHADOWOFFSET = &H10
        ''' <summary>
        ''' iBorderSize has been specified
        ''' </summary>
        DTT_BORDERSIZE = &H20
        ''' <summary>
        ''' iFontPropId has been specified
        ''' </summary>
        DTT_FONTPROP = &H40
        ''' <summary>
        ''' iColorPropId has been specified
        ''' </summary>
        DTT_COLORPROP = &H80
        ''' <summary>
        ''' IStateId has been specified
        ''' </summary>
        DTT_STATEID = &H100
        ''' <summary>
        ''' Use pRect as and in/out parameter
        ''' </summary>
        DTT_CALCRECT = &H200
        ''' <summary>
        ''' fApplyOverlay has been specified
        ''' </summary>
        DTT_APPLYOVERLAY = &H400
        ''' <summary>
        ''' iGlowSize has been specified
        ''' </summary>
        DTT_GLOWSIZE = &H800
        ''' <summary>
        ''' pfnDrawTextCallback has been specified
        ''' </summary>
        DTT_CALLBACK = &H1000
        ''' <summary>
        ''' Draws text with antialiased alpha (needs a DIB section)
        ''' </summary>
        DTT_COMPOSITED = &H2000
        DTT_VALIDBITS = DTT_TEXTCOLOR Or DTT_BORDERCOLOR Or DTT_SHADOWCOLOR Or DTT_SHADOWTYPE Or DTT_SHADOWOFFSET Or DTT_BORDERSIZE Or DTT_FONTPROP Or DTT_COLORPROP Or DTT_STATEID Or DTT_CALCRECT Or DTT_APPLYOVERLAY Or DTT_GLOWSIZE Or DTT_COMPOSITED
    End Enum

    ''' <summary>
    ''' Messages sent by TabControl
    ''' </summary>
    Public Enum TCMessage
        GETIMAGELIST = (TCM_FIRST + 2)
        SETIMAGELIST = (TCM_FIRST + 3)
        GETITEMCOUNT = (TCM_FIRST + 4)
        GETITEMA = (TCM_FIRST + 5)
        SETITEMA = (TCM_FIRST + 6)
        INSERTITEMA = (TCM_FIRST + 7)
        DELETEITEM = (TCM_FIRST + 8)
        DELETEALLITEMS = (TCM_FIRST + 9)
        GETITEMRECT = (TCM_FIRST + 10)
        GETCURSEL = (TCM_FIRST + 11)
        SETCURSEL = (TCM_FIRST + 12)
        HITTEST = (TCM_FIRST + 13)
        SETITEMEXTRA = (TCM_FIRST + 14)
        ADJUSTRECT = (TCM_FIRST + 40)
        SETITEMSIZE = (TCM_FIRST + 41)
        REMOVEIMAGE = (TCM_FIRST + 42)
        SETPADDING = (TCM_FIRST + 43)
        GETROWCOUNT = (TCM_FIRST + 44)
        GETTOOLTIPS = (TCM_FIRST + 45)
        SETTOOLTIPS = (TCM_FIRST + 46)
        GETCURFOCUS = (TCM_FIRST + 47)
        SETCURFOCUS = (TCM_FIRST + 48)
        SETMINTABWIDTH = (TCM_FIRST + 49)
        DESELECTALL = (TCM_FIRST + 50)
        HIGHLIGHTITEM = (TCM_FIRST + 51)
        SETEXTENDEDSTYLE = (TCM_FIRST + 52)
        GETEXTENDEDSTYLE = (TCM_FIRST + 53)
        GETITEMW = (TCM_FIRST + 60)
        SETITEMW = (TCM_FIRST + 61)
        INSERTITEMW = (TCM_FIRST + 62)
    End Enum

    ''' <summary>
    ''' Constants used by DTTOPTS.iShadowType.
    ''' </summary>
    Public Enum TextShadowType
        ''' <summary>
        ''' No shadow will be drawn.
        ''' </summary>
        None
        ''' <summary>
        ''' The shadow will be drawn to appear detailed underneath text.
        ''' </summary>
        [Single]
        ''' <summary>
        ''' The shadow will be drawn to appear blurred underneath text.
        ''' </summary>
        Continuos
    End Enum

#End Region

#Region "Constants"

    Public Const TCM_FIRST As Integer = &H1300
    Public Const S_OK As Integer = 0
    Public Const WM_DWMCOMPOSITIONCHANGED As Integer = &H31E

    Public Const SRCCOPY As Integer = &HCC0020
    Public Const SRCPAINT As Integer = &HEE0086

#End Region

#Region "Helper Methods"

    Public Shared Function HiWord(ByVal number As Integer) As Integer
        Return (number >> 16)
    End Function

    Public Shared Function HiWord(ByVal number As IntPtr) As Integer
        Return HiWord(number.ToInt32())
    End Function

    Public Shared Function LoWord(ByVal number As Integer) As Integer
        Return number And &HFFFF
    End Function

    Public Shared Function LoWord(ByVal number As IntPtr) As Integer
        Return LoWord(number.ToInt32())
    End Function

    Public Shared Function MakeLong(ByVal LoWord As Integer, ByVal HiWord As Integer) As Integer
        Return (HiWord << 16) Or (LoWord And &HFFFF)
    End Function

    Public Shared Function MakeLParam(ByVal LoWord As Integer, ByVal HiWord As Integer) As IntPtr
        Return CType((HiWord << 16) Or (LoWord And &HFFFF), IntPtr)
    End Function

#End Region

End Class