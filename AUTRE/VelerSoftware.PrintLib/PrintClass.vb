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
Imports System.Windows.Forms

Namespace PrintSystem

    Public Enum Alignement
        Left
        Center
        Right
    End Enum

    Public Enum HeaderType
        HeadStep
        FootStep
    End Enum

    Public Enum Orientation
        Automatic
        Portrait
        Lanscape
    End Enum

    Public Enum ObjectType
        Form = 0
        TabControl = 1
        TabPage = 2
        Panel = 3
        GroupBox = 4
        Control = 5
        Label = 6
        Button = 7
        Textbox = 8
        Radio = 9
        CheckBox = 10
        Picturebox = 11
        ListBox = 12
        Combobox = 13
        DateTime = 14
        Chart = 15
        DataGrid = 16
        Line = 17
        Ellipse = 18
        Rectangle = 19
        Polygon = 20
    End Enum

    Public Enum ShapeType
        Line = 17
        Ellipse = 18
        Rectangle = 19
        Polygon = 20
    End Enum

    Public Structure HeaderPage
        Public my_String As String
        Public my_Alignement As Alignement
        Public my_HeaderType As HeaderType
        Public my_Font As System.Drawing.Font
        Public my_isFirstPageUsed As Boolean
        Public my_Brush As System.Drawing.SolidBrush
        Public my_StringFormat As System.Drawing.StringFormat
        Public Sub New(ByVal theString As String, ByVal theAlign As Alignement, ByVal theType As HeaderType, ByVal theFont As System.Drawing.Font, ByVal isFirstPage As Boolean, ByVal theColor As System.Drawing.Color)
            my_String = theString
            my_Alignement = theAlign
            my_HeaderType = theType
            my_Font = theFont
            my_isFirstPageUsed = isFirstPage
            my_Brush = New System.Drawing.SolidBrush(theColor)
            my_StringFormat = New System.Drawing.StringFormat()
            my_StringFormat.FormatFlags = System.Drawing.StringFormatFlags.NoClip Or System.Drawing.StringFormatFlags.NoWrap
        End Sub
    End Structure

    Public Structure ObjectToPrint
        Public my_Type As ObjectType
        Public my_Name As String
        Public my_String As String
        Public my_StringFormat As System.Drawing.StringFormat
        Public my_RectBorder As System.Drawing.Rectangle
        Public my_Font As System.Drawing.Font
        Public my_Pen As System.Drawing.Pen
        Public my_Color As System.Drawing.Color
        Public my_TextBrush As System.Drawing.SolidBrush
        Public my_BackgroundColor As System.Drawing.Color()
        Public my_GradientAngle As Single
        Public my_LineBrush As System.Drawing.SolidBrush
        Public my_Control As System.Windows.Forms.Control
        Public my_ShapePointList As ArrayList
        Public my_PageNum As Int32
        Public my_isWinXPStyle As Int32
        Public my_isPrintTextBorder As Int32
        Public my_ZOrder As Int32
    End Structure

    Public Structure PageInfo
        Public my_LastLocY As Int32
        Public my_LastLocX As Int32
        Public my_PageNum As Int32
        Public Sub New(ByVal thePageNum As Int32)
            my_LastLocX = 1
            my_LastLocY = 1
            my_PageNum = thePageNum
        End Sub
    End Structure

    Public Class PrintClass
        Public my_isPrintButton As Boolean = False
        Public my_isPrintForm As Boolean = False
        Public my_isPrintPanel As Boolean = False
        Public my_isPrintTabPage As Boolean = False
        Public my_isPrintGroupBox As Boolean = False
        Public my_isPrintTextBorder As Boolean = False
        Public my_isWinXPStyle As Boolean = True
        Public my_isGradientShape As Boolean = False
        Public my_ZOrder As Int32 = 0
        Public my_PrintDocument As System.Drawing.Printing.PrintDocument
        Private my_Orientation As Orientation = Orientation.Portrait
        Private my_isAutoArranging As Boolean
        Private my_DocumentRect As System.Drawing.Rectangle
        Private my_HeaderDocumentRect As System.Drawing.Rectangle
        Private my_DpiX As Single
        Private my_PixelToCmRatioX As Single
        Private my_DpiY As Single
        Private my_PixelToCmRatioY As Single
        Private my_HeaderList As ArrayList
        Private my_PageCount As Int32
        Private my_CurrentPage As Int32
        Private my_CurrentCopie As Int32
        Private my_isFirstPage As Boolean
        Private my_isPreviewing As Boolean
        Private my_isUserMargin As Boolean
        Private my_UserMarginRect As System.Drawing.RectangleF
        Private my_ObjectList As ArrayList
        Private my_PageInfoList As ArrayList
        Private my_DefaultFont As System.Drawing.Font
        Private my_DefaultColor As System.Drawing.Color
        Public my_DefaultBackgroundColor As System.Drawing.Color()
        Private my_DefaultGradientAngle As Single
        Private my_DefaultTextBrush As System.Drawing.SolidBrush
        Private my_DefaultLineBrush As System.Drawing.SolidBrush
        Private my_DefaultPen As System.Drawing.Pen
        Private my_DefaultStringFormat As System.Drawing.StringFormat

        Private Sub InitDefaultValue()

            my_DefaultFont = New System.Drawing.Font("Arial", 12)
            my_DefaultColor = System.Drawing.Color.Black
            my_DefaultTextBrush = New System.Drawing.SolidBrush(System.Drawing.Color.Black)
            my_DefaultBackgroundColor = New System.Drawing.Color(1) {System.Drawing.Color.White, System.Drawing.Color.White}
            my_DefaultGradientAngle = 90.0F
            my_DefaultLineBrush = New System.Drawing.SolidBrush(System.Drawing.Color.Gainsboro)
            my_DefaultPen = New System.Drawing.Pen(System.Drawing.Color.Black, 1)
            my_DefaultStringFormat = New System.Drawing.StringFormat()
            my_DefaultStringFormat.Alignment = System.Drawing.StringAlignment.Near
            my_DefaultStringFormat.LineAlignment = System.Drawing.StringAlignment.Center
            my_DefaultStringFormat.Trimming = System.Drawing.StringTrimming.EllipsisCharacter
            my_DefaultStringFormat.FormatFlags = System.Drawing.StringFormatFlags.NoClip
            my_isFirstPage = True
            my_isPreviewing = False
            my_isUserMargin = False
            my_UserMarginRect = New System.Drawing.RectangleF(0.0F, 0.0F, 0.0F, 0.0F)
            my_HeaderList = New ArrayList()
            my_ObjectList = New ArrayList()
            my_PageInfoList = New ArrayList()
            Dim theFirstPage As New PageInfo()
            theFirstPage.my_PageNum = 1
            my_PageInfoList.Add(theFirstPage)
            my_PageCount = 1
            my_CurrentPage = 1
            my_CurrentCopie = 1
            my_ZOrder = 0
        End Sub

        Private Sub InitPrintObject(ByVal theOrientation As Orientation, ByVal theDocName As String, ByVal isAutoArrangingObject As Boolean)
            InitDefaultValue()
            my_Orientation = theOrientation
            my_isAutoArranging = isAutoArrangingObject
            Try
                my_PrintDocument = New System.Drawing.Printing.PrintDocument()
                my_PrintDocument.DocumentName = theDocName
                AddHandler my_PrintDocument.PrintPage, AddressOf PrintPage
                my_DocumentRect = New System.Drawing.Rectangle(0, 0, 0, 0)
                my_HeaderDocumentRect = New System.Drawing.Rectangle(0, 0, 0, 0)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("L'impression à rencontrée une erreure. Veuillez re-essayer ou contacter votre administrateur", "Erreur d'impression", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.[Error])
            End Try
            If my_Orientation = Orientation.Lanscape Then
                my_PrintDocument.DefaultPageSettings.Landscape = True
            End If
            my_PixelToCmRatioX = my_PrintDocument.DefaultPageSettings.Bounds.Width / 21.0F
            my_PixelToCmRatioY = my_PrintDocument.DefaultPageSettings.Bounds.Height / 29.7F
        End Sub

        Public Sub New(ByVal theOrientation As Orientation, ByVal theDocName As String, ByVal isAutoArrangingObject As Boolean)
            InitPrintObject(theOrientation, theDocName, isAutoArrangingObject)
        End Sub

        Public Sub New(ByVal theOrientation As Orientation, ByVal theDocName As String)
            InitPrintObject(theOrientation, theDocName, False)
        End Sub

        Public Sub New(ByVal theOrientation As Orientation)
            InitPrintObject(theOrientation, "Document", False)
        End Sub

        Public Sub New()
            InitPrintObject(Orientation.Portrait, "Document", False)
        End Sub

        Protected Overrides Sub Finalize()
            Try
                my_PrintDocument.Dispose()
                my_HeaderList.Clear()
                my_PageInfoList.Clear()
                my_DefaultFont.Dispose()
                my_DefaultTextBrush.Dispose()
                my_DefaultLineBrush.Dispose()
                my_DefaultPen.Dispose()
                my_DefaultStringFormat.Dispose()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Public Function Print(ByVal isShowPrinterOption As Boolean, ByVal isShowPrevisualisation As Boolean) As Boolean
            Dim isOkToContinue As Boolean = True
            If my_Orientation = Orientation.Automatic Then
                Dim isFormFound As Boolean = False
                Dim icpt As Int32 = 0
                While icpt < my_ObjectList.Count
                    Dim theCurrentObj As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                    If theCurrentObj.my_Type = ObjectType.Form Then
                        isFormFound = True
                        Exit While
                    End If
                    System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
                End While
                If isFormFound Then
                    Dim theCurrentObj As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                    If theCurrentObj.my_RectBorder.Width > theCurrentObj.my_RectBorder.Height Then
                        my_Orientation = Orientation.Lanscape
                    Else
                        my_Orientation = Orientation.Portrait
                    End If
                Else
                    Dim theLastLocX As Int32 = 0
                    Dim theLastLocY As Int32 = 0
                    icpt = 0
                    While icpt < my_ObjectList.Count
                        Dim theCurrentObj As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                        If theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height > theLastLocY Then
                            theLastLocY = theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height
                        End If
                        If theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width > theLastLocX Then
                            theLastLocX = theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width
                        End If
                        System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
                    End While
                    If theLastLocX > theLastLocY Then
                        my_Orientation = Orientation.Lanscape
                    Else
                        my_Orientation = Orientation.Portrait
                    End If
                End If
                If my_Orientation = Orientation.Lanscape Then
                    my_PrintDocument.DefaultPageSettings.Landscape = True
                Else
                    my_PrintDocument.DefaultPageSettings.Landscape = False
                End If
            End If
            If isShowPrinterOption Then
                Dim myPrintDialog As New System.Windows.Forms.PrintDialog()
                myPrintDialog.Document = my_PrintDocument
                myPrintDialog.PrinterSettings = my_PrintDocument.PrinterSettings
                myPrintDialog.AllowPrintToFile = True
                myPrintDialog.ShowNetwork = True
                myPrintDialog.UseEXDialog = True
                If myPrintDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    my_PrintDocument.PrinterSettings = myPrintDialog.PrinterSettings
                    If my_PrintDocument.DefaultPageSettings.Landscape Then
                        If my_Orientation <> Orientation.Lanscape Then
                            my_Orientation = Orientation.Lanscape
                        End If
                    Else
                        If my_Orientation <> Orientation.Portrait Then
                            my_Orientation = Orientation.Portrait
                        End If
                    End If
                    isOkToContinue = True
                Else
                    isOkToContinue = False
                End If
            End If
            If isOkToContinue Then
                If isShowPrevisualisation Then
                    my_isPreviewing = True
                    Dim myPreview As New System.Windows.Forms.PrintPreviewDialog()
                    myPreview.Document = my_PrintDocument
                    myPreview.WindowState = System.Windows.Forms.FormWindowState.Maximized
                    myPreview.UseAntiAlias = True
                    If Not myPreview.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        isOkToContinue = False
                    End If
                End If
            End If
            If isOkToContinue Then
                my_PrintDocument.Print()
            End If
            Return isOkToContinue
        End Function

        Private Sub PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
            If my_isFirstPage Then
                InitPageSetting(ev)
            End If
            DrawHeaders(ev)
            DrawAllObject(ev, my_CurrentPage)
            If my_CurrentPage < my_PageCount Then
                System.Math.Max(System.Threading.Interlocked.Increment(my_CurrentPage), my_CurrentPage - 1)
                my_isFirstPage = False
                ev.HasMorePages = True
            Else
                my_CurrentPage = 1
                my_isFirstPage = True
                If my_isPreviewing Then
                    my_isPreviewing = False
                    ev.HasMorePages = False
                Else
                    If my_CurrentCopie < ev.PageSettings.PrinterSettings.Copies Then
                        System.Math.Max(System.Threading.Interlocked.Increment(my_CurrentCopie), my_CurrentCopie - 1)
                        ev.HasMorePages = True
                    Else
                        ev.HasMorePages = False
                    End If
                End If
            End If
        End Sub

        Private Sub InitPageSetting(ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
            my_DpiX = ev.Graphics.DpiX
            my_DpiY = ev.Graphics.DpiY
            If Not my_isUserMargin Then
                my_PrintDocument.DefaultPageSettings.Margins.Top = ev.MarginBounds.Top
                my_PrintDocument.DefaultPageSettings.Margins.Bottom = ev.MarginBounds.Bottom
                my_PrintDocument.DefaultPageSettings.Margins.Left = ev.MarginBounds.Left
                my_PrintDocument.DefaultPageSettings.Margins.Right = ev.MarginBounds.Right
                my_DocumentRect = ev.MarginBounds
            Else
                setMargin(my_UserMarginRect.Y, my_UserMarginRect.X, my_UserMarginRect.Height, my_UserMarginRect.Width)
            End If
            If Not my_isPreviewing Then
                Dim DecalInCm As Single = 0.4F
                DecalInCm = DecalInCm * 100.0F / 2.54F
                my_PrintDocument.DefaultPageSettings.Margins.Top -= CType(DecalInCm, Int32)
                my_PrintDocument.DefaultPageSettings.Margins.Bottom -= CType(DecalInCm, Int32)
                my_PrintDocument.DefaultPageSettings.Margins.Left -= CType(DecalInCm, Int32)
                my_PrintDocument.DefaultPageSettings.Margins.Right -= CType(DecalInCm, Int32)
                my_DocumentRect.X -= CType(DecalInCm, Int32)
                my_DocumentRect.Y -= CType(DecalInCm, Int32)
            End If
            my_PixelToCmRatioX = my_PrintDocument.DefaultPageSettings.Bounds.Width / 21.0F
            my_PixelToCmRatioY = my_PrintDocument.DefaultPageSettings.Bounds.Height / 29.7F
            my_HeaderDocumentRect.X = my_DocumentRect.X
            my_HeaderDocumentRect.Y = my_DocumentRect.Y
            my_HeaderDocumentRect.Width = my_DocumentRect.Width
            my_HeaderDocumentRect.Height = my_DocumentRect.Height
            Dim theHeaderDecal As Int32 = 0
            Dim theFootDecal As Int32 = 0
            Dim icpt As Int32 = 0
            While icpt < my_HeaderList.Count
                Dim theHeader As HeaderPage = DirectCast((my_HeaderList(icpt)), HeaderPage)
                If theHeader.my_HeaderType = HeaderType.HeadStep Then
                    If theHeaderDecal < theHeader.my_Font.Height Then
                        theHeaderDecal = theHeader.my_Font.Height
                    End If
                Else
                    If theFootDecal < theHeader.my_Font.Height Then
                        theFootDecal = theHeader.my_Font.Height
                    End If
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
            my_DocumentRect.Y += theHeaderDecal
            my_DocumentRect.Height = my_DocumentRect.Height - (theHeaderDecal + theFootDecal)
            SortAllObject()
            SortObjectPerPage()
            If my_isAutoArranging Then
                AutoArrangeObjects()
            End If
        End Sub

        Private Sub DrawHeaders(ByVal ev As System.Drawing.Printing.PrintPageEventArgs)
            Dim theStartPoint As New System.Drawing.PointF(0.0F, 0.0F)
            Dim icpt As Int32 = 0
            While icpt < my_HeaderList.Count
                Dim theHeader As HeaderPage = DirectCast((my_HeaderList(icpt)), HeaderPage)
                If (my_isFirstPage AndAlso theHeader.my_isFirstPageUsed) OrElse (Not my_isFirstPage) Then
                    Select Case theHeader.my_Alignement
                        Case Alignement.Left
                            theStartPoint.X = my_HeaderDocumentRect.Left
                            theHeader.my_StringFormat.Alignment = System.Drawing.StringAlignment.Near
                        Case Alignement.Center
                            theStartPoint.X = my_HeaderDocumentRect.Left + my_HeaderDocumentRect.Width / 2
                            theHeader.my_StringFormat.Alignment = System.Drawing.StringAlignment.Center
                        Case Alignement.Right
                            theStartPoint.X = my_HeaderDocumentRect.Left + my_HeaderDocumentRect.Width
                            theHeader.my_StringFormat.Alignment = System.Drawing.StringAlignment.Far
                    End Select
                    Select Case theHeader.my_HeaderType
                        Case HeaderType.HeadStep
                            theStartPoint.Y = my_HeaderDocumentRect.Top
                        Case HeaderType.FootStep
                            theStartPoint.Y = my_HeaderDocumentRect.Top + my_HeaderDocumentRect.Height - theHeader.my_Font.Height
                    End Select
                    If Not theHeader.my_String = Nothing Then
                        theHeader.my_String = theHeader.my_String.Replace("&NumPage", CStr(my_CurrentPage))
                        theHeader.my_String = theHeader.my_String.Replace("&PageCount", CStr(my_PageCount))
                    End If
                    ev.Graphics.DrawString(theHeader.my_String, theHeader.my_Font, theHeader.my_Brush, theStartPoint, theHeader.my_StringFormat)
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
        End Sub

        Private Sub DrawAllObject(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, ByVal theCurrentPage As Int32)
            Dim icpt As Int32 = 0
            While icpt < my_ObjectList.Count
                Dim theCurrentObj As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                If theCurrentObj.my_PageNum = theCurrentPage Then
                    theCurrentObj.my_RectBorder.X += my_DocumentRect.X
                    theCurrentObj.my_RectBorder.Y += my_DocumentRect.Y
                    Select Case theCurrentObj.my_Type
                        Case ObjectType.Label, ObjectType.Combobox, ObjectType.DateTime, ObjectType.Textbox
                            If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                DrawBox(ev, theCurrentObj)
                            End If
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                        Case ObjectType.Radio
                            Dim theRadioButton As System.Windows.Forms.RadioButton = DirectCast(theCurrentObj.my_Control, System.Windows.Forms.RadioButton)
                            If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                DrawBox(ev, theCurrentObj)
                            End If
                            Dim theRadioRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 3, CType((theCurrentObj.my_RectBorder.Y + (theCurrentObj.my_RectBorder.Height - (theCurrentObj.my_Font.Height - 5)) / 2), Integer), theCurrentObj.my_Font.Height - 5, theCurrentObj.my_Font.Height - 5)
                            ev.Graphics.FillEllipse(System.Drawing.Brushes.White, theRadioRect)
                            If (theCurrentObj.my_isWinXPStyle = 1) OrElse ((theCurrentObj.my_isWinXPStyle = -1) AndAlso (my_isWinXPStyle)) Then
                                ev.Graphics.DrawEllipse(New System.Drawing.Pen(System.Drawing.Color.Navy, 1.2F), theRadioRect)
                            Else
                                ev.Graphics.DrawEllipse(theCurrentObj.my_Pen, theRadioRect)
                            End If
                            theRadioRect.X += 2
                            theRadioRect.Y += 2
                            theRadioRect.Width -= 4
                            theRadioRect.Height -= 4
                            If theRadioButton.Checked Then
                                ev.Graphics.FillEllipse(theCurrentObj.my_LineBrush, theRadioRect)
                            End If
                            theCurrentObj.my_RectBorder.X += (theRadioRect.Width + 7)
                            theCurrentObj.my_RectBorder.Width -= (theRadioRect.Width + 7)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                            theCurrentObj.my_RectBorder.X -= (theRadioRect.Width + 7)
                            theCurrentObj.my_RectBorder.Width += (theRadioRect.Width + 7)
                        Case ObjectType.CheckBox
                            Dim theCheckBox As System.Windows.Forms.CheckBox = DirectCast(theCurrentObj.my_Control, System.Windows.Forms.CheckBox)
                            If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                DrawBox(ev, theCurrentObj)
                            End If
                            Dim theCheckRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 5, CType((theCurrentObj.my_RectBorder.Y + (theCurrentObj.my_RectBorder.Height - (theCurrentObj.my_Font.Height - 5)) / 2), Integer), theCurrentObj.my_Font.Height - 5, theCurrentObj.my_Font.Height - 5)
                            ev.Graphics.FillRectangle(System.Drawing.Brushes.White, theCheckRect)
                            If (theCurrentObj.my_isWinXPStyle = 1) OrElse ((theCurrentObj.my_isWinXPStyle = -1) AndAlso (my_isWinXPStyle)) Then
                                ev.Graphics.DrawRectangle(New System.Drawing.Pen(System.Drawing.Color.Navy, 1.2F), theCheckRect)
                            Else
                                ev.Graphics.DrawRectangle(theCurrentObj.my_Pen, theCheckRect)
                            End If
                            Dim theCrossFont As New System.Drawing.Font("Comic sans MS", theCurrentObj.my_Font.Size - 3, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic)
                            If theCheckBox.Checked Then
                                theCheckRect.X -= 1
                                theCheckRect.Y += 1
                                ev.Graphics.DrawString("V", theCrossFont, theCurrentObj.my_LineBrush, theCheckRect, theCurrentObj.my_StringFormat)
                            End If
                            theCurrentObj.my_RectBorder.X += (theCheckRect.Width + 10)
                            theCurrentObj.my_RectBorder.Width -= (theCheckRect.Width + 10)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                            theCurrentObj.my_RectBorder.X -= (theCheckRect.Width + 10)
                            theCurrentObj.my_RectBorder.Width += (theCheckRect.Width + 10)
                        Case ObjectType.Picturebox
                            Dim thePicture As System.Windows.Forms.PictureBox = DirectCast(theCurrentObj.my_Control, System.Windows.Forms.PictureBox)
                            If thePicture.Image.Width > 800 Then
                                theCurrentObj.my_RectBorder.Width = 800
                                thePicture.Width = 800
                            End If
                            If thePicture.Image.Height > 600 Then
                                theCurrentObj.my_RectBorder.Height = 600
                                thePicture.Height = 600
                            End If
                            If thePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage Then
                                ev.Graphics.DrawImage(thePicture.Image, theCurrentObj.my_RectBorder)
                            Else
                                ev.Graphics.DrawImage(thePicture.Image, theCurrentObj.my_RectBorder.X, theCurrentObj.my_RectBorder.Y, theCurrentObj.my_RectBorder.Width, theCurrentObj.my_RectBorder.Height)
                            End If
                        Case ObjectType.ListBox
                            If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                DrawBox(ev, theCurrentObj)
                            End If
                            Dim theListBox As System.Windows.Forms.ListBox = DirectCast(theCurrentObj.my_Control, System.Windows.Forms.ListBox)
                            Dim theStringRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 10, theCurrentObj.my_RectBorder.Y + 2, theCurrentObj.my_RectBorder.Width - 11, theCurrentObj.my_Font.Height)
                            Dim theFont As New System.Drawing.Font(theCurrentObj.my_Font.FontFamily, theCurrentObj.my_Font.Size, System.Drawing.FontStyle.Bold)
                            Dim iRows As Int32 = 0
                            While iRows < theListBox.Items.Count
                                If theListBox.Items(iRows).ToString() = theCurrentObj.my_String Then
                                    theStringRect.X -= 9
                                    theStringRect.Width += 9
                                    ev.Graphics.FillRectangle(theCurrentObj.my_LineBrush, theStringRect)
                                    ev.Graphics.DrawString(theListBox.Items(iRows).ToString(), theFont, theCurrentObj.my_TextBrush, theStringRect, theCurrentObj.my_StringFormat)
                                    theStringRect.X += 9
                                    theStringRect.Width -= 9
                                Else
                                    ev.Graphics.DrawString(theListBox.Items(iRows).ToString(), theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theStringRect, theCurrentObj.my_StringFormat)
                                End If
                                theStringRect.Y += theCurrentObj.my_Font.Height
                                If theStringRect.Y + theCurrentObj.my_Font.Height > theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height Then
                                    Exit While
                                End If
                                System.Math.Max(System.Threading.Interlocked.Increment(iRows), iRows - 1)
                            End While
                        Case ObjectType.Button
                            If my_isPrintButton Then
                                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                    DrawBox(ev, theCurrentObj)
                                End If
                                ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                            End If
                        Case ObjectType.Form
                            If my_isPrintForm Then
                                theCurrentObj.my_RectBorder.Width = my_DocumentRect.Width
                                theCurrentObj.my_RectBorder.Height = my_DocumentRect.Height
                                Dim theTextRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 10, theCurrentObj.my_RectBorder.Y, theCurrentObj.my_RectBorder.Width - 20, theCurrentObj.my_Font.Height)
                                ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theTextRect)
                                theCurrentObj.my_RectBorder.Y += theTextRect.Height
                                theCurrentObj.my_RectBorder.Height -= theTextRect.Height
                                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                    DrawBox(ev, theCurrentObj)
                                End If
                                theCurrentObj.my_RectBorder.Y -= theTextRect.Height
                                theCurrentObj.my_RectBorder.Height += theTextRect.Height
                            End If
                        Case ObjectType.Panel
                            If my_isPrintPanel Then
                                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                    DrawBox(ev, theCurrentObj)
                                End If
                            End If
                        Case ObjectType.TabPage
                            If my_isPrintTabPage Then
                                Dim theTextRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 10, theCurrentObj.my_RectBorder.Y, CType((theCurrentObj.my_String.Length * theCurrentObj.my_Font.Size), Integer), theCurrentObj.my_Font.Height)
                                ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theTextRect)
                                ev.Graphics.DrawRectangle(theCurrentObj.my_Pen, theTextRect)
                                theCurrentObj.my_RectBorder.Y += theTextRect.Height
                                theCurrentObj.my_RectBorder.Height -= theTextRect.Height
                                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                    DrawBox(ev, theCurrentObj)
                                End If
                                theCurrentObj.my_RectBorder.Y -= theTextRect.Height
                                theCurrentObj.my_RectBorder.Height += theTextRect.Height
                            End If
                        Case ObjectType.GroupBox
                            If my_isPrintGroupBox Then
                                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                                    DrawBox(ev, theCurrentObj)
                                End If
                                Dim theTextRect As New System.Drawing.Rectangle(theCurrentObj.my_RectBorder.X + 10, theCurrentObj.my_RectBorder.Y - theCurrentObj.my_Font.Height / 2, CType((theCurrentObj.my_String.Length * theCurrentObj.my_Font.Size), Integer), theCurrentObj.my_Font.Height)
                                ev.Graphics.FillRectangle(System.Drawing.Brushes.White, theTextRect)
                                ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theTextRect, theCurrentObj.my_StringFormat)
                            End If
                        Case ObjectType.Chart
                            Dim theChart As System.Windows.Forms.DataVisualization.Charting.Chart = DirectCast(theCurrentObj.my_Control, System.Windows.Forms.DataVisualization.Charting.Chart)
                            theChart.Printing.PrintPaint(ev.Graphics, theCurrentObj.my_RectBorder)
                        Case ObjectType.DataGrid
                            System.Windows.Forms.MessageBox.Show(" - datagrid en cours d'integration - ")
                        Case ObjectType.Rectangle
                            DrawBox(ev, theCurrentObj)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                        Case ObjectType.Ellipse
                            If theCurrentObj.my_isPrintTextBorder = 1 Then
                                Dim theBGBrush As New System.Drawing.Drawing2D.LinearGradientBrush(theCurrentObj.my_RectBorder, theCurrentObj.my_BackgroundColor(0), theCurrentObj.my_BackgroundColor(1), theCurrentObj.my_GradientAngle)
                                ev.Graphics.FillEllipse(theBGBrush, theCurrentObj.my_RectBorder)
                            End If
                            ev.Graphics.DrawEllipse(theCurrentObj.my_Pen, theCurrentObj.my_RectBorder)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                        Case ObjectType.Line
                            ev.Graphics.DrawLine(theCurrentObj.my_Pen, theCurrentObj.my_RectBorder.X, theCurrentObj.my_RectBorder.Y, theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width, theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                        Case ObjectType.Polygon
                            Dim thePointList As System.Drawing.Point() = New System.Drawing.Point(theCurrentObj.my_ShapePointList.Count) {}
                            Dim iPointNum As Int32 = 0
                            While iPointNum < theCurrentObj.my_ShapePointList.Count
                                thePointList(iPointNum) = DirectCast((theCurrentObj.my_ShapePointList(iPointNum)), System.Drawing.Point)
                                thePointList(iPointNum).X += my_DocumentRect.X
                                thePointList(iPointNum).Y += my_DocumentRect.Y
                                System.Math.Max(System.Threading.Interlocked.Increment(iPointNum), iPointNum - 1)
                            End While
                            If theCurrentObj.my_isPrintTextBorder = 1 Then
                                Dim theBGBrush As New System.Drawing.Drawing2D.LinearGradientBrush(theCurrentObj.my_RectBorder, theCurrentObj.my_BackgroundColor(0), theCurrentObj.my_BackgroundColor(1), theCurrentObj.my_GradientAngle)
                                ev.Graphics.FillPolygon(theBGBrush, thePointList)
                            End If
                            ev.Graphics.DrawPolygon(theCurrentObj.my_Pen, thePointList)
                            ev.Graphics.DrawString(theCurrentObj.my_String, theCurrentObj.my_Font, theCurrentObj.my_TextBrush, theCurrentObj.my_RectBorder, theCurrentObj.my_StringFormat)
                        Case Else
                    End Select
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
        End Sub

        Private Sub DrawBox(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, ByVal theCurrentObj As ObjectToPrint)
            Dim theBGBrush As New System.Drawing.Drawing2D.LinearGradientBrush(theCurrentObj.my_RectBorder, theCurrentObj.my_BackgroundColor(0), theCurrentObj.my_BackgroundColor(1), theCurrentObj.my_GradientAngle)
            If (theCurrentObj.my_isWinXPStyle = 0) OrElse ((theCurrentObj.my_isWinXPStyle = -1) AndAlso (Not my_isWinXPStyle)) Then
                If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                    ev.Graphics.FillRectangle(theBGBrush, theCurrentObj.my_RectBorder)
                End If
                ev.Graphics.DrawRectangle(theCurrentObj.my_Pen, theCurrentObj.my_RectBorder)
            Else
                Dim theRoundSize As Int32 = 5
                Dim point1 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X, theCurrentObj.my_RectBorder.Y + theRoundSize)
                Dim point2 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theRoundSize, theCurrentObj.my_RectBorder.Y)
                Dim point3 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width - theRoundSize, theCurrentObj.my_RectBorder.Y)
                Dim point4 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width, theCurrentObj.my_RectBorder.Y + theRoundSize)
                Dim point5 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width, theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height - theRoundSize)
                Dim point6 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theCurrentObj.my_RectBorder.Width - theRoundSize, theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height)
                Dim point7 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X + theRoundSize, theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height)
                Dim point8 As New System.Drawing.PointF(theCurrentObj.my_RectBorder.X, theCurrentObj.my_RectBorder.Y + theCurrentObj.my_RectBorder.Height - theRoundSize)
                Dim curvePoints As System.Drawing.PointF() = {point2, point3, point4, point5, point6, point7, _
                  point8, point1}
                If theCurrentObj.my_Type = ObjectType.Button Then
                    Dim tension As Single = 0.05F
                    Dim aFillMode As System.Drawing.Drawing2D.FillMode = System.Drawing.Drawing2D.FillMode.Alternate
                    ev.Graphics.FillClosedCurve(theBGBrush, curvePoints, aFillMode, tension)
                    ev.Graphics.DrawClosedCurve(New System.Drawing.Pen(System.Drawing.Color.Navy, 1), curvePoints, tension, aFillMode)
                    point2.Y += 1
                    point3.Y += 1
                    point4.X -= 1
                    point5.X -= 1
                    point6.Y -= 1
                    point7.Y -= 1
                    point8.X += 1
                    point1.X += 1
                    Dim curvePoints2 As System.Drawing.PointF() = {point2, point3, point4, point5, point6, point7, _
                      point8, point1}
                    ev.Graphics.DrawClosedCurve(New System.Drawing.Pen(System.Drawing.Color.LightSkyBlue, 1), curvePoints2, tension, aFillMode)
                Else
                    Dim tension As Single = 2.0F / theCurrentObj.my_RectBorder.Height
                    Dim aFillMode As System.Drawing.Drawing2D.FillMode = System.Drawing.Drawing2D.FillMode.Alternate
                    If (theCurrentObj.my_isPrintTextBorder = 1) OrElse ((theCurrentObj.my_isPrintTextBorder = -1) AndAlso (my_isPrintTextBorder)) Then
                        ev.Graphics.FillClosedCurve(theBGBrush, curvePoints, aFillMode, tension)
                    End If
                    ev.Graphics.DrawClosedCurve(theCurrentObj.my_Pen, curvePoints, tension, aFillMode)
                End If
            End If
        End Sub

        Private Sub SortAllObject()
            Dim icpt As Int32 = 1
            While icpt < my_ObjectList.Count
                Dim theCurrentObj As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                Dim isFoundHigherPos As Boolean = False
                Dim theObjIndex As Int32 = 0
                theObjIndex = icpt - 1
                While theObjIndex >= 0
                    Dim theCompareObj As ObjectToPrint = DirectCast(my_ObjectList(theObjIndex), ObjectToPrint)
                    If theCurrentObj.my_ZOrder > theCompareObj.my_ZOrder Then
                        Exit While
                    ElseIf theCompareObj.my_RectBorder.Y < theCurrentObj.my_RectBorder.Y Then
                        isFoundHigherPos = True
                        Exit While
                    ElseIf theCompareObj.my_RectBorder.Y = theCurrentObj.my_RectBorder.Y Then
                        If theCompareObj.my_RectBorder.X < theCurrentObj.my_RectBorder.X Then
                            isFoundHigherPos = True
                            Exit While
                        ElseIf theObjIndex = 0 Then
                            isFoundHigherPos = True
                        End If
                    ElseIf theObjIndex = 0 Then
                        isFoundHigherPos = True
                    End If
                    System.Math.Max(System.Threading.Interlocked.Decrement(theObjIndex), theObjIndex + 1)
                End While
                If isFoundHigherPos Then
                    my_ObjectList.Insert(theObjIndex + 1, theCurrentObj)
                    my_ObjectList.RemoveAt(icpt + 1)
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
        End Sub

        Private Sub SortObjectPerPage()
            Dim theCurrentY As Int32 = 0
            Dim theCurrentIndex As Int32 = 0
            Dim theCurrentZOrder As Int32 = 0
            Dim icpt As Int32 = 0
            While icpt < my_ObjectList.Count
                Dim theCurrentObject As ObjectToPrint = DirectCast((my_ObjectList(icpt)), ObjectToPrint)
                If theCurrentObject.my_ZOrder > theCurrentZOrder Then
                    theCurrentY = 0
                    theCurrentIndex = 0
                    theCurrentZOrder = theCurrentObject.my_ZOrder
                End If
                If theCurrentY <> theCurrentObject.my_RectBorder.Y Then
                    theCurrentIndex = icpt
                    theCurrentY = theCurrentObject.my_RectBorder.Y
                End If
                If theCurrentObject.my_RectBorder.Y + theCurrentObject.my_RectBorder.Height >= my_DocumentRect.Height Then
                    DecalAllNextObject(-theCurrentObject.my_RectBorder.Y, theCurrentIndex, theCurrentObject.my_PageNum, theCurrentZOrder)
                End If
                If my_PageCount < theCurrentObject.my_PageNum Then
                    my_PageCount = theCurrentObject.my_PageNum
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
            icpt = 0
            While icpt < my_PageCount
                my_PageInfoList.Add(New PageInfo(icpt + 1))
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
            icpt = 0
            While icpt < my_ObjectList.Count
                Dim theCurrentObject As ObjectToPrint = DirectCast((my_ObjectList(icpt)), ObjectToPrint)
                If theCurrentObject.my_Type <> ObjectType.Form Then
                    Dim theCurrentPageInfo As PageInfo = DirectCast((my_PageInfoList(theCurrentObject.my_PageNum - 1)), PageInfo)
                    If theCurrentObject.my_RectBorder.Y + theCurrentObject.my_RectBorder.Height > theCurrentPageInfo.my_LastLocY Then
                        theCurrentPageInfo.my_LastLocY = theCurrentObject.my_RectBorder.Y + theCurrentObject.my_RectBorder.Height
                    End If
                    If theCurrentObject.my_RectBorder.X + theCurrentObject.my_RectBorder.Width > theCurrentPageInfo.my_LastLocX Then
                        theCurrentPageInfo.my_LastLocX = theCurrentObject.my_RectBorder.X + theCurrentObject.my_RectBorder.Width
                    End If
                    my_PageInfoList(theCurrentObject.my_PageNum - 1) = theCurrentPageInfo
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
        End Sub

        Private Sub DecalAllNextObject(ByVal theYDecal As Int32, ByVal theStartIndex As Int32, ByVal theCurrentPage As Int32, ByVal theZOrder As Int32)
            While theStartIndex < my_ObjectList.Count
                Dim theCurrentObject As ObjectToPrint = DirectCast((my_ObjectList(theStartIndex)), ObjectToPrint)
                If theZOrder <> theCurrentObject.my_ZOrder Then
                    If theCurrentObject.my_PageNum > theCurrentPage Then
                        System.Math.Max(System.Threading.Interlocked.Increment(theCurrentObject.my_PageNum), theCurrentObject.my_PageNum - 1)
                    End If
                Else
                    theCurrentObject.my_RectBorder.Y += theYDecal
                    System.Math.Max(System.Threading.Interlocked.Increment(theCurrentObject.my_PageNum), theCurrentObject.my_PageNum - 1)
                    If theCurrentObject.my_Type = ObjectType.Polygon Then
                        Dim icpt As Int32 = 0
                        While icpt < theCurrentObject.my_ShapePointList.Count
                            Dim thePoint As System.Drawing.Point = DirectCast((theCurrentObject.my_ShapePointList(icpt)), System.Drawing.Point)
                            thePoint.Y += theYDecal
                            theCurrentObject.my_ShapePointList(icpt) = thePoint
                            System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
                        End While
                    End If
                End If
                my_ObjectList(theStartIndex) = theCurrentObject
                System.Math.Max(System.Threading.Interlocked.Increment(theStartIndex), theStartIndex - 1)
            End While
        End Sub

        Private Sub AutoArrangeObjects()
            Dim icpt As Int32 = 0
            While icpt < my_ObjectList.Count
                Dim theObject As ObjectToPrint = DirectCast(my_ObjectList(icpt), ObjectToPrint)
                If (theObject.my_Type <> ObjectType.Polygon) AndAlso (theObject.my_Type <> ObjectType.Line) AndAlso (theObject.my_Type <> ObjectType.Ellipse) AndAlso (theObject.my_Type <> ObjectType.Rectangle) Then
                    Dim thePageInfo As PageInfo = DirectCast(my_PageInfoList(theObject.my_PageNum - 1), PageInfo)
                    Dim theXRatio As Double = my_DocumentRect.Width / (thePageInfo.my_LastLocX * 1)
                    Dim theYRatio As Double = my_DocumentRect.Height / (thePageInfo.my_LastLocY * 1)
                    theObject.my_RectBorder.X = CType((CType(theObject.my_RectBorder.X, Double) * theXRatio), Integer)
                    theObject.my_RectBorder.Y = CType((CType(theObject.my_RectBorder.Y, Double) * theYRatio), Integer)
                    theObject.my_RectBorder.Width = CType((theObject.my_RectBorder.Width * theXRatio), Integer)
                    If (theObject.my_Type = ObjectType.GroupBox) OrElse (theObject.my_Type = ObjectType.Panel) OrElse (theObject.my_Type = ObjectType.DataGrid) OrElse (theObject.my_Type = ObjectType.TabControl) Then
                        theObject.my_RectBorder.Height = CType((theObject.my_RectBorder.Height * theYRatio), Integer)
                    End If
                    my_ObjectList(icpt) = theObject
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
            End While
        End Sub

        Private Function AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal thePointList As System.Drawing.Point(), ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, _
          ByVal isFilled As Boolean, ByVal theFirstGradient As System.Drawing.Color, ByVal theSecondGradient As System.Drawing.Color, ByVal theGradientAngle As Single, ByVal theString As String, ByVal theStringAlign As System.Drawing.StringAlignment, _
          ByVal theTextColor As System.Drawing.Color, ByVal isWinXpStyle As Int32, ByVal theZOrder As Int32) As ObjectToPrint
            Dim theObjectToPrint As New ObjectToPrint()
            theObjectToPrint.my_Type = DirectCast((DirectCast(theShapeType, Integer)), ObjectType)
            theObjectToPrint.my_RectBorder = theRect
            theObjectToPrint.my_ZOrder = theZOrder
            Select Case theShapeType
                Case ShapeType.Ellipse
                    theObjectToPrint.my_Name = "Ellipse"
                Case ShapeType.Line
                    theObjectToPrint.my_Name = "Ligne"
                Case ShapeType.Polygon
                    theObjectToPrint.my_Name = "Polygone"
                    If Not thePointList Is Nothing Then
                        theObjectToPrint.my_ShapePointList = New ArrayList()
                        Dim icpt As Int32 = 0
                        While icpt < thePointList.Length
                            theObjectToPrint.my_ShapePointList.Add(thePointList(icpt))
                            If theObjectToPrint.my_RectBorder.X > thePointList(icpt).X Then
                                theObjectToPrint.my_RectBorder.X = thePointList(icpt).X
                            End If
                            If theObjectToPrint.my_RectBorder.Y > thePointList(icpt).Y Then
                                theObjectToPrint.my_RectBorder.Y = thePointList(icpt).Y
                            End If
                            If theObjectToPrint.my_RectBorder.Width < thePointList(icpt).X Then
                                theObjectToPrint.my_RectBorder.Width = thePointList(icpt).X
                            End If
                            If theObjectToPrint.my_RectBorder.Height < thePointList(icpt).Y Then
                                theObjectToPrint.my_RectBorder.Height = thePointList(icpt).Y
                            End If
                            System.Math.Max(System.Threading.Interlocked.Increment(icpt), icpt - 1)
                        End While
                        theObjectToPrint.my_RectBorder.Width -= theObjectToPrint.my_RectBorder.X
                        theObjectToPrint.my_RectBorder.Height -= theObjectToPrint.my_RectBorder.Y
                    End If
                Case ShapeType.Rectangle
                    theObjectToPrint.my_Name = "Rectangle"
                Case Else
                    theObjectToPrint.my_Name = "Forme inconnue"
            End Select
            theObjectToPrint.my_BackgroundColor = New System.Drawing.Color(2) {}
            theObjectToPrint.my_BackgroundColor(0) = theFirstGradient
            theObjectToPrint.my_BackgroundColor(1) = theSecondGradient
            theObjectToPrint.my_Color = theTextColor
            theObjectToPrint.my_Control = Nothing
            theObjectToPrint.my_Font = my_DefaultFont
            theObjectToPrint.my_GradientAngle = theGradientAngle
            If isFilled Then
                theObjectToPrint.my_isPrintTextBorder = 1
            Else
                theObjectToPrint.my_isPrintTextBorder = 0
            End If
            theObjectToPrint.my_isWinXPStyle = isWinXpStyle
            theObjectToPrint.my_LineBrush = New System.Drawing.SolidBrush(theBorderColor)
            theObjectToPrint.my_PageNum = thePageNum
            theObjectToPrint.my_Pen = New System.Drawing.Pen(theBorderColor, theBorderSize)
            theObjectToPrint.my_String = theString
            theObjectToPrint.my_StringFormat = New System.Drawing.StringFormat()
            theObjectToPrint.my_StringFormat.Alignment = theStringAlign
            theObjectToPrint.my_StringFormat.LineAlignment = System.Drawing.StringAlignment.Center
            theObjectToPrint.my_TextBrush = New System.Drawing.SolidBrush(theTextColor)
            my_ObjectList.Add(theObjectToPrint)
            Return theObjectToPrint
        End Function

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle)
            AddShape(theShapeType, theRect, Nothing, my_DefaultPen.Color, my_DefaultPen.Width, 1, _
              my_isGradientShape, my_DefaultBackgroundColor(0), my_DefaultBackgroundColor(1), my_DefaultGradientAngle, "", System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, 1, _
              my_isGradientShape, my_DefaultBackgroundColor(0), my_DefaultBackgroundColor(1), my_DefaultGradientAngle, "", System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
              my_isGradientShape, my_DefaultBackgroundColor(0), my_DefaultBackgroundColor(1), my_DefaultGradientAngle, "", System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFillColor As System.Drawing.Color)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
              True, theFillColor, theFillColor, my_DefaultGradientAngle, "", System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFillColor As System.Drawing.Color, _
          ByVal theString As String)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
              True, theFillColor, theFillColor, my_DefaultGradientAngle, theString, System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFillColor As System.Drawing.Color, _
          ByVal theString As String, ByVal theTextColor As System.Drawing.Color)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
              True, theFillColor, theFillColor, my_DefaultGradientAngle, theString, System.Drawing.StringAlignment.Center, _
              theTextColor, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFillColor As System.Drawing.Color, _
          ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal theStringAlignement As System.Drawing.StringAlignment, ByVal isRoundCorner As Boolean)
            If isRoundCorner Then
                AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
                  True, theFillColor, theFillColor, my_DefaultGradientAngle, theString, theStringAlignement, _
                  theTextColor, 1, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
            Else
                AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
                  True, theFillColor, theFillColor, my_DefaultGradientAngle, theString, theStringAlignement, _
                  theTextColor, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
            End If
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal thePointList As System.Drawing.Point(), ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32)
            AddShape(theShapeType, New System.Drawing.Rectangle(thePointList(0).X, thePointList(0).Y, 1, 1), thePointList, theBorderColor, theBorderSize, thePageNum, _
              my_isGradientShape, my_DefaultBackgroundColor(0), my_DefaultBackgroundColor(1), my_DefaultGradientAngle, "", System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal thePointList As System.Drawing.Point(), ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFillColor As System.Drawing.Color, _
          ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal theStringAlignement As System.Drawing.StringAlignment)
            AddShape(theShapeType, New System.Drawing.Rectangle(thePointList(0).X, thePointList(0).Y, 1, 1), thePointList, theBorderColor, theBorderSize, thePageNum, _
              True, theFillColor, theFillColor, my_DefaultGradientAngle, theString, theStringAlignement, _
              theTextColor, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal theString As String, ByVal thePageNum As Int32)
            AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
              my_isGradientShape, my_DefaultBackgroundColor(0), my_DefaultBackgroundColor(1), my_DefaultGradientAngle, theString, System.Drawing.StringAlignment.Center, _
              my_DefaultTextBrush.Color, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
        End Sub

        Public Sub AddShape(ByVal theShapeType As ShapeType, ByVal theRect As System.Drawing.Rectangle, ByVal theBorderColor As System.Drawing.Color, ByVal theBorderSize As Single, ByVal thePageNum As Int32, ByVal theFirstGradient As System.Drawing.Color, _
          ByVal theSecondGradient As System.Drawing.Color, ByVal theGradientAngle As Single, ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal theStringAlignement As System.Drawing.StringAlignment, ByVal isRoundCorner As Boolean)
            If isRoundCorner Then
                AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
                  True, theFirstGradient, theSecondGradient, theGradientAngle, theString, theStringAlignement, _
                  theTextColor, 1, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
            Else
                AddShape(theShapeType, theRect, Nothing, theBorderColor, theBorderSize, thePageNum, _
                  True, theFirstGradient, theSecondGradient, theGradientAngle, theString, theStringAlignement, _
                  theTextColor, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
            End If
        End Sub

        Public Sub AddText(ByVal theUpperCorner As System.Drawing.Point, ByVal theString As String)
            AddText(theUpperCorner, theString, my_DefaultTextBrush.Color, my_DefaultFont, 1)
        End Sub

        Public Sub AddText(ByVal theUpperCorner As System.Drawing.Point, ByVal theString As String, ByVal theTextColor As System.Drawing.Color)
            AddText(theUpperCorner, theString, theTextColor, my_DefaultFont, 1)
        End Sub

        Public Sub AddText(ByVal theUpperCorner As System.Drawing.Point, ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal theTextFont As System.Drawing.Font)
            AddText(theUpperCorner, theString, theTextColor, theTextFont, 1)
        End Sub

        Public Sub AddText(ByVal theUpperCorner As System.Drawing.Point, ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal thePageNum As Int32)
            AddText(theUpperCorner, theString, theTextColor, my_DefaultFont, thePageNum)
        End Sub

        Public Sub AddText(ByVal theUpperCorner As System.Drawing.Point, ByVal theString As String, ByVal theTextColor As System.Drawing.Color, ByVal theTextFont As System.Drawing.Font, ByVal thePageNum As Int32)
            Dim StringsCollect As New Generic.List(Of String)
            Dim insertIndex, iChar_less_insertIndex, lignelenght_less_iChar, page_larger As Integer
            Dim theRect As System.Drawing.Rectangle
            Dim tempfont As System.Drawing.Font = my_DefaultFont

            Dim oki As Boolean
            page_larger = my_PrintDocument.DefaultPageSettings.PaperSize.Width - (theUpperCorner.X * 15.3F)
            For Each ligne As String In theString.Split(Environment.NewLine)
                oki = False
                insertIndex = 0
                For iChar As Integer = insertIndex To ligne.Length - 1
                    iChar_less_insertIndex = iChar - insertIndex
                    If ((iChar_less_insertIndex) * my_DefaultFont.Size) > page_larger Then
                        StringsCollect.Add(ligne.Substring(insertIndex, iChar_less_insertIndex))
                        oki = True
                        lignelenght_less_iChar = ligne.Length - iChar
                        If (lignelenght_less_iChar * my_DefaultFont.Size) < page_larger Then
                            StringsCollect.Add(ligne.Substring(iChar, lignelenght_less_iChar))
                            Exit For
                        End If
                        insertIndex = iChar
                    End If
                Next
                If Not oki Then StringsCollect.Add(ligne)
            Next


            For i As Integer = 0 To StringsCollect.Count - 1
                If Char.IsWhiteSpace(StringsCollect(i)(0)) Then StringsCollect(i) = StringsCollect(i).Substring(1)

                theRect = New System.Drawing.Rectangle((theUpperCorner.X * 15.3F), ((theUpperCorner.Y * 3) + (i * my_DefaultFont.Height)), page_larger, my_DefaultFont.Height)
                my_DefaultFont = theTextFont
                AddShape(ShapeType.Rectangle, theRect, Nothing, System.Drawing.Color.White, 0, thePageNum, _
                  False, System.Drawing.Color.White, System.Drawing.Color.White, my_DefaultGradientAngle, StringsCollect(i), System.Drawing.StringAlignment.Near, _
                  theTextColor, 0, System.Math.Max(System.Threading.Interlocked.Increment(my_ZOrder), my_ZOrder - 1))
                my_DefaultFont = tempfont
            Next
        End Sub

        Public Sub AddImage(ByVal Img As System.Drawing.Bitmap, ByVal X As Integer, ByVal Y As Integer)
            AddImage(Img, X, Y, Img.Width, Img.Height)
        End Sub

        Public Sub AddImage(ByVal Img As System.Drawing.Bitmap, ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer)
            AddImage(Img, X, Y, Width, Height, 1)
        End Sub

        Public Sub AddImage(ByVal Img As System.Drawing.Bitmap, ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal thePageNum As Integer)
            Dim theObjectToPrint As New ObjectToPrint()
            theObjectToPrint.my_Type = ObjectType.Picturebox
            If Img.Width > 800 Then
                Width = 800
            End If
            If Img.Height > 600 Then
                Height = 600
            End If
            theObjectToPrint.my_RectBorder = New System.Drawing.Rectangle(X * 15.3F, Y * 3, Width, Height)
            Dim pic As New System.Windows.Forms.PictureBox
            Img.SetResolution(Width, Height)
            pic.SizeMode = Windows.Forms.PictureBoxSizeMode.AutoSize
            pic.Image = Img
            theObjectToPrint.my_Name = "Forme inconnue"
            theObjectToPrint.my_Control = pic
            theObjectToPrint.my_PageNum = thePageNum
            my_ObjectList.Add(theObjectToPrint)
        End Sub

        Public Sub setEntete(ByVal theEnteteString As String, ByVal theAlignement As Alignement, ByVal theType As HeaderType)
            Dim theNewHeader As New HeaderPage(theEnteteString, theAlignement, theType, my_DefaultFont, True, my_DefaultColor)
            my_HeaderList.Add(theNewHeader)
        End Sub

        Public Sub setEntete(ByVal theEnteteString As String, ByVal theAlignement As Alignement, ByVal theType As HeaderType, ByVal isFirstPageUsed As Boolean)
            Dim theNewHeader As New HeaderPage(theEnteteString, theAlignement, theType, my_DefaultFont, isFirstPageUsed, my_DefaultColor)
            my_HeaderList.Add(theNewHeader)
        End Sub

        Public Sub setEntete(ByVal theEnteteString As String, ByVal theAlignement As Alignement, ByVal theType As HeaderType, ByVal isFirstPageUsed As Boolean, ByVal theFont As System.Drawing.Font)
            Dim theNewHeader As New HeaderPage(theEnteteString, theAlignement, theType, theFont, isFirstPageUsed, my_DefaultColor)
            my_HeaderList.Add(theNewHeader)
        End Sub

        Public Sub setEntete(ByVal theEnteteString As String, ByVal theAlignement As Alignement, ByVal theType As HeaderType, ByVal isFirstPageUsed As Boolean, ByVal theFont As System.Drawing.Font, ByVal theColor As System.Drawing.Color)
            Dim theNewHeader As New HeaderPage(theEnteteString, theAlignement, theType, theFont, isFirstPageUsed, theColor)
            my_HeaderList.Add(theNewHeader)
        End Sub

        Public Sub setMargin(ByVal TopMarginWidth As Single, ByVal LeftMarginWidth As Single, ByVal BottomMarginWidth As Single, ByVal RightMarginWidth As Single)
            my_isUserMargin = True
            my_UserMarginRect.X = LeftMarginWidth
            my_UserMarginRect.Y = TopMarginWidth
            my_UserMarginRect.Width = RightMarginWidth
            my_UserMarginRect.Height = BottomMarginWidth
            my_PrintDocument.DefaultPageSettings.Margins.Top = CType((TopMarginWidth * my_PixelToCmRatioY), Int32)
            my_PrintDocument.DefaultPageSettings.Margins.Bottom = my_PrintDocument.DefaultPageSettings.Bounds.Height - CType((BottomMarginWidth * my_PixelToCmRatioY), Int32)
            my_PrintDocument.DefaultPageSettings.Margins.Left = CType((LeftMarginWidth * my_PixelToCmRatioX), Int32)
            my_PrintDocument.DefaultPageSettings.Margins.Right = my_PrintDocument.DefaultPageSettings.Bounds.Width - CType((RightMarginWidth * my_PixelToCmRatioX), Int32)
            my_DocumentRect.X = my_PrintDocument.DefaultPageSettings.Margins.Left
            my_DocumentRect.Y = my_PrintDocument.DefaultPageSettings.Margins.Top
            my_DocumentRect.Width = my_PrintDocument.DefaultPageSettings.Margins.Right - my_PrintDocument.DefaultPageSettings.Margins.Left
            my_DocumentRect.Height = my_PrintDocument.DefaultPageSettings.Margins.Bottom - my_PrintDocument.DefaultPageSettings.Margins.Top
        End Sub

        Public Sub setMargin(ByVal MarginWidth As Single)
            setMargin(MarginWidth, MarginWidth, MarginWidth, MarginWidth)
        End Sub

        Public Function getMarginBounds() As System.Drawing.Rectangle
            Return my_DocumentRect
        End Function

        Private Function getPageCount() As Int32
            Return my_PageCount
        End Function

        Private Function getTextWidthInInch(ByVal theText As String, ByVal theTextFont As System.Drawing.Font) As Single
            Return theText.Length * theTextFont.SizeInPoints * my_DpiX
        End Function

        Private Function getTextWidthInPixel(ByVal theText As String, ByVal theTextFont As System.Drawing.Font) As Single
            Return theText.Length * theTextFont.SizeInPoints
        End Function

        Private Function getTextHeightInInch(ByVal theTextfont As System.Drawing.Font) As Single
            Return theTextfont.Height / my_DpiY
        End Function

        Private Function getControlAlignement(ByVal theAlign As System.Drawing.ContentAlignment) As System.Drawing.StringAlignment
            Select Case theAlign
                Case System.Drawing.ContentAlignment.TopLeft, System.Drawing.ContentAlignment.MiddleLeft, System.Drawing.ContentAlignment.BottomLeft
                    Return System.Drawing.StringAlignment.Near
                Case System.Drawing.ContentAlignment.TopCenter, System.Drawing.ContentAlignment.MiddleCenter, System.Drawing.ContentAlignment.BottomCenter
                    Return System.Drawing.StringAlignment.Center
                Case System.Drawing.ContentAlignment.TopRight, System.Drawing.ContentAlignment.MiddleRight, System.Drawing.ContentAlignment.BottomRight
                    Return System.Drawing.StringAlignment.Far
                Case Else
                    Return System.Drawing.StringAlignment.Near
            End Select
        End Function

        Private Function getControlAlignement(ByVal theAlign As System.Windows.Forms.HorizontalAlignment) As System.Drawing.StringAlignment
            Select Case theAlign
                Case System.Windows.Forms.HorizontalAlignment.Left
                    Return System.Drawing.StringAlignment.Near
                Case System.Windows.Forms.HorizontalAlignment.Center
                    Return System.Drawing.StringAlignment.Center
                Case System.Windows.Forms.HorizontalAlignment.Right
                    Return System.Drawing.StringAlignment.Far
                Case Else
                    Return System.Drawing.StringAlignment.Near
            End Select
        End Function

        Private Declare Function StretchBlt Lib "gdi32" (ByVal hdc As IntPtr, ByVal X As Integer, _
          ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, _
          ByVal hSrcDC As IntPtr, ByVal xSrc As Integer, ByVal ySrc As Integer, _
          ByVal nSrcWidth As Integer, ByVal nSrcHeight As Integer, ByVal dwRop As Integer) As Integer

        Public Sub SetDocument(ByVal c As System.Windows.Forms.Control, ByVal X As Integer, ByVal Y As Integer, ByVal NumPage As Integer)
            If Not TypeOf c Is System.Windows.Forms.DataVisualization.Charting.Chart Then
                Dim buffer As System.Drawing.Bitmap
                Dim controlGraphics As System.Drawing.Graphics = c.CreateGraphics    ' graphique form
                Const SRCCOPY As Integer = &HCC0020

                '*** DEFINITION DE L'IMAGE

                Dim controlSize As System.Drawing.Size
                controlSize = c.ClientSize()
                buffer = New System.Drawing.Bitmap(controlSize.Width, controlSize.Height)
                Dim bufferGraphics As System.Drawing.Graphics = Drawing.Graphics.FromImage(buffer)

                Dim bufferHdc As IntPtr = bufferGraphics.GetHdc   'hdc de la form
                Dim controlHdc As IntPtr = controlGraphics.GetHdc

                '*** DESSINE LE FORMULAIRE DANS LA PICTURE
                StretchBlt(bufferHdc, 0, 0, controlSize.Width, controlSize.Height, _
                  controlHdc, 0, 0, controlSize.Width, controlSize.Height, SRCCOPY)

                bufferGraphics.ReleaseHdc(bufferHdc)
                controlGraphics.ReleaseHdc(controlHdc)

                AddImage(buffer, X * 15.3F, Y * 3, buffer.Width, buffer.Height, NumPage)
            Else
                Dim theObjectToPrint As New ObjectToPrint()
                Dim Width, Height As Integer
                Width = my_DocumentRect.Width - (X * 15.3F) - my_DocumentRect.Right
                Height = c.Height * (Width / c.Width)
                If c.Width > 800 Then Width = 800
                If c.Height > 600 Then Height = 600
                theObjectToPrint.my_Type = ObjectType.Chart
                theObjectToPrint.my_RectBorder = New System.Drawing.Rectangle(X * 15.3F, Y * 3, Width, Height)
                theObjectToPrint.my_Name = "Forme inconnue"
                theObjectToPrint.my_Control = c
                theObjectToPrint.my_PageNum = NumPage
                my_ObjectList.Add(theObjectToPrint)
            End If
        End Sub

    End Class

    Public Class PrintRichTextBox
        Implements IDisposable

        Private RichTextCtrl As System.Windows.Forms.Control
        Private WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
        Private m_nFirstCharOnPage As Integer
        Private ipage As Integer = 1

        Public Sub New(ByVal rich As System.Windows.Forms.Control)
            RichTextCtrl = rich
            PrintDocument1 = New System.Drawing.Printing.PrintDocument
            AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument1_PrintPage
        End Sub

        Public Sub PrintPreview()
            Dim pri As New PrintClass(Orientation.Automatic, "", True)
            pri.my_PrintDocument = PrintDocument1
            pri.Print(False, True)
        End Sub

        Public Sub Print()
            Dim pri As New PrintClass(Orientation.Automatic, "", True)
            pri.my_PrintDocument = PrintDocument1
            pri.Print(True, False)
        End Sub

        Private Structure STRUCT_RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure

        Private Structure STRUCT_CHAR_RANGE
            Public cpMin As Integer
            Public cpMax As Integer
        End Structure

        Private Structure STRUCT_FORMAT_RANGE
            Public hdc As IntPtr
            Public hdcTarget As IntPtr
            Public rc As STRUCT_RECT
            Public rcPage As STRUCT_RECT
            Public chrg As STRUCT_CHAR_RANGE
        End Structure

        Private Structure STRUCT_CHAR_FORMAT
            Public cbSize As Integer
            Public dwMask As UInt32
            Public dwEffects As UInt32
            Public yHeight As Integer
            Public yOffset As Integer
            Public crTextColor As Integer
            Public bCharSet As Byte
            Public bPitchAndFamily As Byte
            <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=32)> _
            Public szFaceName As Char()
        End Structure

        Private Const WM_USER As Integer = 1024
        Private Const EM_FORMATRANGE As Integer = 1081
        Private Const EM_GETCHARFORMAT As Integer = 1082
        Private Const EM_SETCHARFORMAT As Integer = 1092
        Private SCF_SELECTION As Integer
        Private SCF_WORD As Integer
        Private SCF_ALL As Integer
        Private Const CFM_BOLD As Long = 1
        Private Const CFM_ITALIC As Long = 2
        Private Const CFM_UNDERLINE As Long = 4
        Private Const CFM_STRIKEOUT As Long = 8
        Private Const CFM_PROTECTED As Long = 16
        Private Const CFM_LINK As Long = 32
        Private Const CFM_SIZE As Long = 2147483648
        Private Const CFM_COLOR As Long = 1073741824
        Private Const CFM_FACE As Long = 536870912
        Private Const CFM_OFFSET As Long = 268435456
        Private Const CFM_CHARSET As Long = 134217728
        Private Const CFE_BOLD As Long = 1
        Private Const CFE_ITALIC As Long = 2
        Private Const CFE_UNDERLINE As Long = 4
        Private Const CFE_STRIKEOUT As Long = 8
        Private Const CFE_PROTECTED As Long = 16
        Private Const CFE_LINK As Long = 32
        Private Const CFE_AUTOCOLOR As Long = 1073741824

        <System.Runtime.InteropServices.DllImport("user32.dll")> _
        Private Shared Shadows Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        End Function

        Public Function FormatRange(ByVal measureOnly As Boolean, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal charFrom As Integer, ByVal charTo As Integer) As Integer
            Dim sTRUCT_CHAR_RANGE As STRUCT_CHAR_RANGE
            Dim sTRUCT_FORMAT_RANGE As STRUCT_FORMAT_RANGE
            Dim sTRUCT_RECT1 As STRUCT_RECT
            Dim sTRUCT_RECT2 As STRUCT_RECT
            Dim j2 As Integer
            'Dim rectangle As Rectangle
            sTRUCT_CHAR_RANGE.cpMin = charFrom
            sTRUCT_CHAR_RANGE.cpMax = charTo
            sTRUCT_RECT1.top = HundredthInchToTwips(e.MarginBounds.Top)
            sTRUCT_RECT1.bottom = HundredthInchToTwips(e.MarginBounds.Bottom)
            sTRUCT_RECT1.left = HundredthInchToTwips(e.MarginBounds.Left)
            sTRUCT_RECT1.right = HundredthInchToTwips(e.MarginBounds.Right)
            sTRUCT_RECT2.top = HundredthInchToTwips(e.PageBounds.Top)
            sTRUCT_RECT2.bottom = HundredthInchToTwips(e.PageBounds.Bottom)
            sTRUCT_RECT2.left = HundredthInchToTwips(e.PageBounds.Left)
            sTRUCT_RECT2.right = HundredthInchToTwips(e.PageBounds.Right)
            Dim j1 As IntPtr = e.Graphics.GetHdc()
            sTRUCT_FORMAT_RANGE.chrg = sTRUCT_CHAR_RANGE
            sTRUCT_FORMAT_RANGE.hdc = j1
            sTRUCT_FORMAT_RANGE.hdcTarget = j1
            sTRUCT_FORMAT_RANGE.rc = sTRUCT_RECT1
            sTRUCT_FORMAT_RANGE.rcPage = sTRUCT_RECT2
            If measureOnly Then
                j2 = 0
            Else
                j2 = 1
            End If
            Dim k As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_FORMAT_RANGE))
            System.Runtime.InteropServices.Marshal.StructureToPtr(sTRUCT_FORMAT_RANGE, k, False)
            Dim i2 As Integer = SendMessage(RichTextCtrl.Handle, 1081, j2, k)
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(k)
            e.Graphics.ReleaseHdc(j1)
            Return i2
        End Function

        Private Function HundredthInchToTwips(ByVal n As Integer) As Integer
            Return Convert.ToInt32(n * 14.4)
        End Function

        Public Sub FormatRangeDone()
            Dim i As IntPtr = New IntPtr(0)
            SendMessage(RichTextCtrl.Handle, 1081, 0, i)
        End Sub

        Public Function SetSelectionFont(ByVal face As String) As Boolean
            Dim sTRUCT_CHAR_FORMAT As STRUCT_CHAR_FORMAT = New STRUCT_CHAR_FORMAT
            sTRUCT_CHAR_FORMAT.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT)
            sTRUCT_CHAR_FORMAT.dwMask = Convert.ToUInt32(536870912)
            sTRUCT_CHAR_FORMAT.szFaceName = New Char(32) {}
            face.CopyTo(0, sTRUCT_CHAR_FORMAT.szFaceName, 0, Math.Min(31, face.Length))
            Dim i As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT))
            System.Runtime.InteropServices.Marshal.StructureToPtr(sTRUCT_CHAR_FORMAT, i, False)
            If SendMessage(RichTextCtrl.Handle, 1092, SCF_SELECTION, i) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function SetSelectionSize(ByVal size As Integer) As Boolean
            Dim sTRUCT_CHAR_FORMAT As STRUCT_CHAR_FORMAT = New STRUCT_CHAR_FORMAT
            sTRUCT_CHAR_FORMAT.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT)
            sTRUCT_CHAR_FORMAT.dwMask = Convert.ToUInt32(2147483648)
            sTRUCT_CHAR_FORMAT.yHeight = size * 20
            Dim i As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT))
            System.Runtime.InteropServices.Marshal.StructureToPtr(sTRUCT_CHAR_FORMAT, i, False)
            If SendMessage(RichTextCtrl.Handle, 1092, SCF_SELECTION, i) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function SetSelectionBold(ByVal bold As Boolean) As Boolean
            If bold Then
                Return SetSelectionStyle(1, 1)
            Else
                Return SetSelectionStyle(1, 0)
            End If
        End Function

        Public Function SetSelectionItalic(ByVal italic As Boolean) As Boolean
            If italic Then
                Return SetSelectionStyle(2, 2)
            Else
                Return SetSelectionStyle(2, 0)
            End If
        End Function

        Public Function SetSelectionUnderlined(ByVal underlined As Boolean) As Boolean
            If underlined Then
                Return SetSelectionStyle(4, 4)
            Else
                Return SetSelectionStyle(4, 0)
            End If
        End Function

        Private Function SetSelectionStyle(ByVal mask As Integer, ByVal effect As Integer) As Boolean
            Dim sTRUCT_CHAR_FORMAT As New STRUCT_CHAR_FORMAT
            sTRUCT_CHAR_FORMAT.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT)
            sTRUCT_CHAR_FORMAT.dwMask = Convert.ToUInt32(mask)
            sTRUCT_CHAR_FORMAT.dwEffects = Convert.ToUInt32(effect)
            Dim i As IntPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(sTRUCT_CHAR_FORMAT))
            System.Runtime.InteropServices.Marshal.StructureToPtr(sTRUCT_CHAR_FORMAT, i, False)

            If SendMessage(RichTextCtrl.Handle, 1092, SCF_SELECTION, i) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
            Dim intPrintAreaWidth As Integer
            Dim intPrintAreaHeight As Integer
            Dim font As New System.Drawing.Font("Microsoft Sans Serif", 10)
            Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Blue, 2)
            Dim nWidth As Integer = PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Width
            Dim nHeight As Integer = PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height
            With PrintDocument1.DefaultPageSettings
                intPrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right
                intPrintAreaHeight = .PaperSize.Height - .Margins.Top
            End With
            m_nFirstCharOnPage = Me.FormatRange(False, e, m_nFirstCharOnPage, RichTextCtrl.Text.Length)


            '' e.Graphics.DrawLine(myPen, 0, intPrintAreaHeight + 30, PrintDocument1.DefaultPageSettings.PaperSize.Width, intPrintAreaHeight + 30)
            e.Graphics.DrawString("Page " & CStr(ipage), font, System.Drawing.Brushes.Black, intPrintAreaWidth + 90, intPrintAreaHeight + 50)
            If (m_nFirstCharOnPage < RichTextCtrl.Text.Length) Then
                ipage = ipage + 1
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Pour détecter les appels redondants

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: supprimez l'état managé (objets managés).
                End If

                ' TODO: libérez les ressources non managées (objets non managés) et substituez la méthode Finalize() ci-dessous.
                ' TODO: définissez les champs volumineux à null.

                PrintDocument1.Dispose()
                PrintDocument1 = Nothing
                RichTextCtrl = Nothing
                Me.Finalize()
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: substituez Finalize() uniquement si Dispose(ByVal disposing As Boolean) ci-dessus comporte du code permettant de libérer des ressources non managées.
        'Protected Overrides Sub Finalize()
        '    ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Ce code a été ajouté par Visual Basic pour permettre l'implémentation correcte du modèle pouvant être supprimé.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Ne modifiez pas ce code. Ajoutez du code de nettoyage dans Dispose(ByVal disposing As Boolean) ci-dessus.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class PrintDGV
        Private Shared StrFormat As StringFormat         ' Holds content of a TextBox Cell to write by DrawString
        Private Shared StrFormatComboBox As StringFormat ' Holds content of a Boolean Cell to write by DrawImage
        Private Shared CellButton As Button          ' Holds the Contents of Button Cell
        Private Shared CellCheckBox As CheckBox      ' Holds the Contents of CheckBox Cell
        Private Shared CellComboBox As ComboBox      ' Holds the Contents of ComboBox Cell

        Private Shared TotalWidth As Int16           ' Summation of Columns widths
        Private Shared RowPos As Int16               ' Position of currently printing row 
        Private Shared NewPage As Boolean            ' Indicates if a new page reached 
        Private Shared PageNo As Int16               ' Number of pages to print 
        Private Shared ColumnLefts As New ArrayList  ' Left Coordinate of Columns
        Private Shared ColumnWidths As New ArrayList ' Width of Columns
        Private Shared ColumnTypes As New ArrayList  ' DataType of Columns
        Private Shared CellHeight As Int16           ' Height of DataGrid Cell
        Private Shared RowsPerPage As Int16          ' Number of Rows per Page 
        Private Shared WithEvents PrintDoc As New System.Drawing.Printing.PrintDocument ' PrintDocumnet Object used for printing

        Private Shared PrintTitle As String = ""               ' Header of pages
        Private Shared dgv As DataGridView                     ' Holds DataGrid Object to print its contents
        Private Shared AvailableColumns As New List(Of String) ' All Columns avaiable in DataGrid   
        Private Shared PrintAllRows As Boolean = True          ' True = print all rows,  False = print selected rows    
        Private Shared FitToPageWidth As Boolean = True        ' True = Fits selected columns to page width ,  False = Print columns as showed    
        Private Shared HeaderHeight As Int16 = 0

        Public Shared Sub Print_DataGridView(ByVal dgv1 As DataGridView)
            Dim ppvw As PrintPreviewDialog
            Try
                ' Getting DataGridView object to print
                dgv = dgv1

                ' Getting all Coulmns Names in the DataGridView
                AvailableColumns.Clear()
                For Each c As DataGridViewColumn In dgv.Columns
                    If Not c.Visible Then Continue For
                    AvailableColumns.Add(c.HeaderText)
                Next

                ' Saving some printing attributes
                PrintTitle = ""
                PrintAllRows = True
                FitToPageWidth = True

                RowsPerPage = 0
                ppvw = New PrintPreviewDialog
                ppvw.Document = PrintDoc

                ' Showing the Print Preview Page
                If ppvw.ShowDialog() <> DialogResult.OK Then Exit Sub
                ' Printing the Documnet
                PrintDoc.Print()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub

        Private Shared Sub PrintDoc_BeginPrint(ByVal sender As Object, _
                    ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
            Try
                ' Formatting the Content of Text Cells to print
                StrFormat = New StringFormat
                StrFormat.Alignment = StringAlignment.Near
                StrFormat.LineAlignment = StringAlignment.Center
                StrFormat.Trimming = StringTrimming.EllipsisCharacter

                ' Formatting the Content of Combo Cells to print
                StrFormatComboBox = New StringFormat
                StrFormatComboBox.LineAlignment = StringAlignment.Center
                StrFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
                StrFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

                ColumnLefts.Clear()
                ColumnWidths.Clear()
                ColumnTypes.Clear()
                CellHeight = 0
                RowsPerPage = 0

                ' For various column types
                CellButton = New Button
                CellCheckBox = New CheckBox
                CellComboBox = New ComboBox

                TotalWidth = 0
                For Each GridCol As DataGridViewColumn In dgv.Columns
                    If Not GridCol.Visible Then Continue For
                    If Not AvailableColumns.Contains(GridCol.HeaderText) Then Continue For
                    TotalWidth += GridCol.Width
                Next
                PageNo = 1
                NewPage = True
                RowPos = 0
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub

        Private Shared Sub PrintDoc_PrintPage(ByVal sender As Object, _
                ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

            Dim tmpWidth As Int16, i As Int16
            Dim tmpTop As Int16 = e.MarginBounds.Top
            Dim tmpLeft As Int16 = e.MarginBounds.Left

            Try
                ' Before starting first page, it saves Width & Height of Headers and CoulmnType
                If PageNo = 1 Then
                    For Each GridCol As DataGridViewColumn In dgv.Columns
                        If Not GridCol.Visible Then Continue For
                        If Not AvailableColumns.Contains(GridCol.HeaderText) Then
                            Continue For
                        End If

                        ' Detemining whether the columns are fitted to page or not.
                        If FitToPageWidth Then
                            tmpWidth = CType(Math.Floor(GridCol.Width / TotalWidth * _
                                       TotalWidth * (e.MarginBounds.Width / TotalWidth)), Int16)
                        Else
                            tmpWidth = GridCol.Width
                        End If
                        HeaderHeight = e.Graphics.MeasureString(GridCol.HeaderText, _
                                       GridCol.InheritedStyle.Font, tmpWidth).Height + 11

                        ColumnLefts.Add(tmpLeft)
                        ColumnWidths.Add(tmpWidth)
                        ColumnTypes.Add(GridCol.GetType)
                        tmpLeft += tmpWidth
                    Next
                End If

                ' Printing Current Page, Row by Row
                Do While RowPos <= dgv.Rows.Count - 1
                    Dim GridRow As DataGridViewRow = dgv.Rows(RowPos)
                    If GridRow.IsNewRow OrElse (Not PrintAllRows AndAlso Not GridRow.Selected) Then
                        RowPos += 1 : Continue Do
                    End If

                    CellHeight = GridRow.Height

                    If tmpTop + CellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                        DrawFooter(e, RowsPerPage)
                        NewPage = True
                        PageNo += 1
                        e.HasMorePages = True
                        Exit Sub
                    Else
                        If NewPage Then
                            ' Draw Header
                            e.Graphics.DrawString(PrintTitle, New Font(dgv.Font, FontStyle.Bold), _
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - _
                            e.Graphics.MeasureString(PrintTitle, New Font(dgv.Font, _
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13)

                            Dim s As String = Now.ToLongDateString + " " + Now.ToShortTimeString

                            e.Graphics.DrawString(s, New Font(dgv.Font, FontStyle.Bold), _
                               Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - _
                               e.Graphics.MeasureString(s, New Font(dgv.Font, FontStyle.Bold), _
                               e.MarginBounds.Width).Width), e.MarginBounds.Top - _
                               e.Graphics.MeasureString(PrintTitle, _
                               New Font(New Font(dgv.Font, FontStyle.Bold), FontStyle.Bold), _
                               e.MarginBounds.Width).Height - 13)

                            ' Draw Columns
                            tmpTop = e.MarginBounds.Top
                            i = 0
                            For Each GridCol As DataGridViewColumn In dgv.Columns
                                If Not GridCol.Visible Then Continue For
                                If Not AvailableColumns.Contains(GridCol.HeaderText) Then
                                    Continue For
                                End If

                                e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), _
                                        New Rectangle(ColumnLefts(i), tmpTop, ColumnWidths(i), HeaderHeight))

                                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i), _
                                        tmpTop, ColumnWidths(i), HeaderHeight))

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, _
                                        New SolidBrush(GridCol.InheritedStyle.ForeColor), _
                                        New RectangleF(ColumnLefts(i), tmpTop, ColumnWidths(i), _
                                        HeaderHeight), StrFormat)
                                i += 1
                            Next
                            NewPage = False

                            tmpTop += HeaderHeight
                        End If

                        i = 0
                        For Each Cel As DataGridViewCell In GridRow.Cells
                            If Not Cel.OwningColumn.Visible Then Continue For
                            If Not AvailableColumns.Contains(Cel.OwningColumn.HeaderText) Then
                                Continue For
                            End If

                            ' For the TextBox Column
                            If ColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse _
                               ColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then

                                e.Graphics.DrawString(Cel.Value.ToString, Cel.InheritedStyle.Font, _
                                        New SolidBrush(Cel.InheritedStyle.ForeColor), _
                                        New RectangleF(ColumnLefts(i), tmpTop, ColumnWidths(i), _
                                        CellHeight), StrFormat)

                                ' For the Button Column
                            ElseIf ColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                                CellButton.Text = Cel.Value.ToString
                                CellButton.Size = New Size(ColumnWidths(i), CellHeight)
                                Dim bmp As New Bitmap(CellButton.Width, CellButton.Height)
                                CellButton.DrawToBitmap(bmp, New Rectangle(0, 0, _
                                        bmp.Width, bmp.Height))
                                e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))

                                ' For the CheckBox Column
                            ElseIf ColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then

                                CellCheckBox.Size = New Size(14, 14)
                                CellCheckBox.Checked = CType(Cel.Value, Boolean)
                                Dim bmp As New Bitmap(ColumnWidths(i), CellHeight)
                                Dim tmpGraphics As Graphics = Graphics.FromImage(bmp)
                                tmpGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, _
                                        bmp.Width, bmp.Height))
                                CellCheckBox.DrawToBitmap(bmp, New Rectangle(CType((bmp.Width - _
                                        CellCheckBox.Width) / 2, Int32), CType((bmp.Height - _
                                        CellCheckBox.Height) / 2, Int32), CellCheckBox.Width, _
                                        CellCheckBox.Height))
                                e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))

                                ' For the ComboBox Column
                            ElseIf ColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                                CellComboBox.Size = New Size(ColumnWidths(i), CellHeight)
                                Dim bmp As New Bitmap(CellComboBox.Width, CellComboBox.Height)
                                CellComboBox.DrawToBitmap(bmp, New Rectangle(0, 0, _
                                        bmp.Width, bmp.Height))
                                e.Graphics.DrawImage(bmp, New Point(ColumnLefts(i), tmpTop))
                                e.Graphics.DrawString(Cel.Value.ToString, Cel.InheritedStyle.Font, _
                                        New SolidBrush(Cel.InheritedStyle.ForeColor), _
                                        New RectangleF(ColumnLefts(i) + 1, tmpTop, ColumnWidths(i) _
                                        - 16, CellHeight), StrFormatComboBox)

                                ' For the Image Column
                            ElseIf ColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                                Dim CelSize As Rectangle = New Rectangle(ColumnLefts(i), _
                                        tmpTop, ColumnWidths(i), CellHeight)
                                Dim ImgSize As Size = CType(Cel.FormattedValue, Image).Size
                                e.Graphics.DrawImage(Cel.FormattedValue, New Rectangle(ColumnLefts(i) _
                                        + CType(((CelSize.Width - ImgSize.Width) / 2), Int32), _
                                        tmpTop + CType(((CelSize.Height - ImgSize.Height) / 2),  _
                                        Int32), CType(Cel.FormattedValue, Image).Width, CType(Cel.FormattedValue,  _
                                        Image).Height))

                            End If

                            ' Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(ColumnLefts(i), _
                                    tmpTop, ColumnWidths(i), CellHeight))

                            i += 1

                        Next
                        tmpTop += CellHeight

                    End If

                    RowPos += 1
                    ' For the first page it calculates Rows per Page
                    If PageNo = 1 Then
                        RowsPerPage += 1
                    End If
                Loop

                If RowsPerPage = 0 Then Exit Sub

                ' Write Footer (Page Number)
                DrawFooter(e, RowsPerPage)

                e.HasMorePages = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub

        Private Shared Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
            Dim cnt As Integer

            ' Detemining rows number to print
            If PrintAllRows Then
                If dgv.Rows(dgv.Rows.Count - 1).IsNewRow Then
                    ' When the DataGridView doesn't allow adding rows
                    cnt = dgv.Rows.Count - 2
                Else
                    ' When the DataGridView allows adding rows
                    cnt = dgv.Rows.Count - 1
                End If
            Else
                cnt = dgv.SelectedRows.Count
            End If

            ' Writing the Page Number on the Bottom of Page
            Dim PageNum As String = PageNo.ToString + " of " + _
                        Math.Ceiling(cnt / RowsPerPage).ToString
            e.Graphics.DrawString(PageNum, dgv.Font, Brushes.Black, _
                        e.MarginBounds.Left + (e.MarginBounds.Width - _
                        e.Graphics.MeasureString(PageNum, dgv.Font, _
                        e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + _
                        e.MarginBounds.Height + 31)

        End Sub

    End Class

End Namespace