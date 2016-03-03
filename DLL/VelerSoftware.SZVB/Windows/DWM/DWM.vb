''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Forms.VisualStyles
Imports System.Runtime.CompilerServices

Namespace Windows

    Public Class DWM

        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
        Public Structure Margins
            Public Sub New(ByVal left As Integer, ByVal right As Integer, ByVal top As Integer, ByVal bottom As Integer)
                _left = left
                _right = right
                _top = top
                _bottom = bottom
            End Sub
            Public Sub New(ByVal allMargins As Integer)
                _left = allMargins
                _right = allMargins
                _top = allMargins
                _bottom = allMargins
            End Sub
            Private _left As Integer
            Private _right As Integer
            Private _top As Integer
            Private _bottom As Integer
            Public Property Left() As Integer
                Get
                    Return _left
                End Get
                Set(ByVal value As Integer)
                    _left = value
                End Set
            End Property
            Public Property Right() As Integer
                Get
                    Return _right
                End Get
                Set(ByVal value As Integer)
                    _right = value
                End Set
            End Property
            Public Property Top() As Integer
                Get
                    Return _top
                End Get
                Set(ByVal value As Integer)
                    _top = value
                End Set
            End Property
            Public Property Bottom() As Integer
                Get
                    Return _bottom
                End Get
                Set(ByVal value As Integer)
                    _bottom = value
                End Set
            End Property
            Public ReadOnly Property IsMarginless() As Boolean
                Get
                    Return (_left < 0 AndAlso _right < 0 AndAlso _top < 0 AndAlso _bottom < 0)
                End Get
            End Property
            Public ReadOnly Property IsNull() As Boolean
                Get
                    Return (_left = 0 AndAlso _right = 0 AndAlso _top = 0 AndAlso _bottom = 0)
                End Get
            End Property
        End Structure

        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
        Public Structure Rect
            Public stleft, sttop, stright, stbottom As Integer

            Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
                stleft = left
                sttop = top
                stright = right
                stbottom = bottom
            End Sub

            Public Sub Rect(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
                stleft = left
                sttop = top
                stright = right
                stbottom = bottom
            End Sub
        End Structure

        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
        Public Structure Dwm_ThumbnailProperties
            <CLSCompliant(False)> Public dwFlags As UInt64
            Public rcDestination As Rect
            Public rcSource As Rect
            Public opacity As Byte
            <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> _
            Public fVisible As Boolean
            <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> _
            Public fSourceClientAreaOnly As Boolean
            <CLSCompliant(False)> Public Const DWM_TNP_RECTDESTINATION As UInt32 = &H1
            <CLSCompliant(False)> Public Const DWM_TNP_RECTSOURCE As UInt32 = &H2
            <CLSCompliant(False)> Public Const DWM_TNP_OPACITY As UInt32 = &H4
            <CLSCompliant(False)> Public Const DWM_TNP_VISIBLE As UInt32 = &H8
            <CLSCompliant(False)> Public Const DWM_TNP_SOURCECLIENTAREAONLY As UInt32 = &H10
        End Structure

        <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
        Public Structure Dwm_BlurBehind
            <CLSCompliant(False)> Public dwFlags As UInt64
            <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> _
            Public fEnable As Boolean
            Public hRegionBlur As IntPtr
            <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> _
            Public fTransitionOnMaximized As Boolean
            <CLSCompliant(False)> Public Const DWM_BB_ENABLE As UInt32 = &H1
            <CLSCompliant(False)> Public Const DWM_BB_BLURREGION As UInt32 = &H2
            <CLSCompliant(False)> Public Const DWM_BB_TRANSITIONONMAXIMIZED As UInt32 = &H4
        End Structure

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarInset As Margins) As Integer
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmIsCompositionEnabled() As Boolean
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmEnableBlurBehindWindow(ByVal hWnd As IntPtr, ByVal pBlurBehind As Dwm_BlurBehind) As Integer
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmEnableComposition(ByVal bEnable As Boolean)
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmGetColorizationColor(ByVal pcrColorization As Integer, <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.Bool)> ByVal pfOpaqueBlend As Boolean)
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmRegisterThumbnail(ByVal dest As IntPtr, ByVal source As IntPtr) As IntPtr
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmUnregisterThumbnail(ByVal hThumbnail As IntPtr)
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmUpdateThumbnailProperties(ByVal hThumbnail As IntPtr, ByVal props As Dwm_ThumbnailProperties)
        End Function

        <Runtime.InteropServices.DllImport("dwmapi.dll", PreserveSig:=False)> _
        Shared Function DwmQueryThumbnailSourceSize(ByVal hThumbnail As IntPtr, ByVal size As Drawing.Size)
        End Function




        <DllImport("UxTheme.dll", ExactSpelling:=True, SetLastError:=True, CharSet:=CharSet.Unicode)> Shared Function DrawThemeTextEx(ByVal hTheme As IntPtr, ByVal hdc As IntPtr, ByVal iPartId As Integer, ByVal iStateId As Integer, ByVal text As String, ByVal iCharCount As Integer, ByVal dwFlags As Integer, ByRef pRect As Rect, ByRef pOptions As S_DTTOPTS) As Integer
        End Function

        Public Const DTT_COMPOSITED As Integer = 8192
        Public Const DTT_GLOWSIZE As Integer = 2048
        Public Const DTT_TEXTCOLOR As Integer = 1
        Public Const SRCCOPY As Integer = &HCC0020

        Public Structure S_DTTOPTS
            Dim dwSize As Integer
            Dim dwFlags As Integer
            Dim crText As Integer
            Dim crBorder As Integer
            Dim crShadow As Integer
            Dim iTextShadowType As Integer
            Dim ptShadowOffset As Point
            Dim iBorderSize As Integer
            Dim iFontPropId As Integer
            Dim iColorPropId As Integer
            Dim iStateId As Integer
            Dim fApplyOverlay As Boolean
            Dim iGlowSize As Integer
            Dim pfnDrawTextCallback As Integer
            Dim lParam As IntPtr
        End Structure

        Public Structure BITMAPINFOHEADER
            Dim biSize As Integer
            Dim biWidth As Integer
            Dim biHeight As Integer
            Dim biPlanes As Short
            Dim biBitCount As Short
            Dim biCompression As Integer
            Dim biSizeImage As Integer
            Dim biXPelsPerMeter As Integer
            Dim biYPelsPerMeter As Integer
            Dim biClrUsed As Integer
            Dim biClrImportant As Integer
        End Structure

        Public Structure RGBQUAD
            Dim rgbBlue As Byte
            Dim rgbGreen As Byte
            Dim rgbRed As Byte
            Dim rgbReserved As Byte
        End Structure

        Public Structure BITMAPINFO
            Dim bmiHeader As BITMAPINFOHEADER
            Dim bmiColors As RGBQUAD
        End Structure

        Shared Sub DrawTextGlow(ByVal Graphics As Graphics, ByVal text As String, ByVal fnt As Font, ByVal bounds As Rectangle, ByVal Clr As Color, ByVal flags As TextFormatFlags)

            ' Variables used later.
            Dim SavedBitmap As IntPtr = IntPtr.Zero
            Dim SavedFont As IntPtr = IntPtr.Zero
            Dim MainHDC As IntPtr = Graphics.GetHdc
            Dim MemHDC As IntPtr = NativeMethods.CreateCompatibleDC(MainHDC)
            Dim BtmInfo As New BITMAPINFO
            Dim TextRect As New Rect(0, 0, bounds.Right - bounds.Left + 2 * 15, bounds.Bottom - bounds.Top + 2 * 15)
            Dim ScreenRect As New Rect(bounds.Left - 15, bounds.Top - 15, bounds.Right + 15, bounds.Bottom + 15)
            Dim hFont As IntPtr = fnt.ToHfont

            Try
                Dim Renderer As VisualStyleRenderer = New VisualStyleRenderer(System.Windows.Forms.VisualStyles.VisualStyleElement.Window.Caption.Active)

                ' Memory bitmap to hold the drawn glowed text.
                BtmInfo.bmiHeader.biSize = Marshal.SizeOf(BtmInfo.bmiHeader)

                With BtmInfo
                    .bmiHeader.biWidth = bounds.Width + 30
                    .bmiHeader.biHeight = -bounds.Height - 30
                    .bmiHeader.biPlanes = 1
                    .bmiHeader.biBitCount = 32
                End With

                ' Create a DIB Section for this bitmap from the graphics object.
                Dim dibSection As IntPtr = NativeMethods.CreateDIBSection(MainHDC, BtmInfo, 0, 0, IntPtr.Zero, 0)

                ' Save the current handles temporarily.
                SavedBitmap = NativeMethods.SelectObject(MemHDC, dibSection)
                SavedFont = NativeMethods.SelectObject(MemHDC, hFont)

                ' Holds the properties of the text (size and color , ...etc).
                Dim TextOptions As S_DTTOPTS = New S_DTTOPTS

                With TextOptions
                    .dwSize = Marshal.SizeOf(TextOptions)
                    .dwFlags = DTT_COMPOSITED Or DTT_GLOWSIZE Or DTT_TEXTCOLOR
                    .crText = ColorTranslator.ToWin32(Clr)
                    .iGlowSize = 16
                End With

                ' Draw The text on the memory surface.
                DrawThemeTextEx(Renderer.Handle, MemHDC, 0, 0, text, -1, flags, TextRect, TextOptions)

                ' Reflecting the image on the primary surface of the graphics object.
                With ScreenRect
                    NativeMethods.BitBlt(MainHDC, .stleft, .sttop, .stright - .stleft, .stbottom - .sttop, MemHDC, 0, 0, SRCCOPY)
                End With

                ' Resources Cleaning.
                NativeMethods.SelectObject(MemHDC, SavedFont)
                NativeMethods.SelectObject(MemHDC, SavedBitmap)

                NativeMethods.DeleteDC(MemHDC)
                NativeMethods.DeleteObject(hFont)
                NativeMethods.DeleteObject(dibSection)

                Graphics.ReleaseHdc(MainHDC)
            Catch ex As Exception

            End Try
        End Sub

    End Class

End Namespace