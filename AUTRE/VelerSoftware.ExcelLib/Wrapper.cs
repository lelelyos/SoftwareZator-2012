// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing;

namespace VelerSoftware.ExcelLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Wrapper
    {
        #region Variables
        private Excel.Application excel;
        private Excel.Workbook workbook;
        private Excel.Sheets sheets;
        private Excel.Worksheet worksheet;
        private object missing = System.Reflection.Missing.Value;
        private Excel.Range range;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Wrapper() { this.Create(false); }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Wrapper(bool visible) { this.Create(visible); }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Wrapper(String path, bool visible) { this.Open(path, visible); }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new excel document
        /// </summary>
        public bool Create(bool visible)
        {
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                worksheet = new Microsoft.Office.Interop.Excel.Worksheet();
                workbook = (Excel.Workbook)(excel.Workbooks.Add(missing));
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                sheets = workbook.Worksheets;
                excel.Visible = visible;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                System.Windows.Forms.MessageBox.Show(E.Message);
                CleanUp();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Open an exisiting excel Document
        /// </summary>
        public bool Open(string path, bool visible)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
                System.Windows.Forms.MessageBox.Show("File does not exist");
                return false;
            } 
            if (!path.EndsWith("xls") && !path.EndsWith("xlsx"))
            {
                Console.WriteLine("Invalid file format");
                System.Windows.Forms.MessageBox.Show("Invalid file format");
                return false;
            }

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                worksheet = new Microsoft.Office.Interop.Excel.Worksheet();
                workbook = excel.Workbooks.Open(path, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                sheets = workbook.Worksheets;
                excel.Visible = visible;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                System.Windows.Forms.MessageBox.Show(E.Message);
                CleanUp();
                return false;
            }

            return true;
        }


        /// <summary>
        /// Close Excel without saving changes
        /// </summary>
        public void Close()
        {
            CleanUp();
        }


        /// <summary>
        /// Saves the current excel document
        /// </summary>
        public void Save()
        {
            workbook.Save();
        }
        /// <summary>
        /// Add a new worksheet
        /// </summary>
        /// <param name="name"></param>
        public void AddWorksheet(string name)
        {
            workbook.Worksheets.Add(missing, missing, missing, missing);
            Excel.Worksheet worksheetName = (Excel.Worksheet)sheets.get_Item(1);
            worksheetName.Name = name;
        }

        /// <summary>
        /// Delete a worksheet by index. index start from 1 not 0
        /// </summary>
        /// <param name="index"></param>
        public void DeleteWorksheet(int index)
        {
            bool deleteCurrentSheet = false;

            if (index < 1)
                throw new Exception("Index out of bounds");
            if (index > workbook.Sheets.Count)
                throw new Exception("Index out of bounds");

            //Check if we are deleting the worksheet that is being used. If so point it to another worksheet after deletion
            if (worksheet.Name.Equals(((Excel.Worksheet)excel.Application.ActiveWorkbook.Sheets[index]).Name))
                deleteCurrentSheet = true;

            ((Excel.Worksheet)excel.Application.ActiveWorkbook.Sheets[index]).Delete();

            if (deleteCurrentSheet)
                worksheet = (Excel.Worksheet)sheets.get_Item(1);

        }

        /// <summary>
        /// Delete a worksheet by name
        /// </summary>
        /// <param name="name"></param>
        public void DeleteWorksheet(string name)
        {
            for (int i = 0; i < workbook.Sheets.Count; i++)
            {
                Excel.Worksheet worksheetDelete = (Excel.Worksheet)sheets.get_Item(i + 1);
                if (name.Equals(worksheetDelete.Name))
                {
                    DeleteWorksheet(i + 1);
                }
            }
        }


        /// <summary>
        /// Set the current worksheet by name
        /// </summary>
        /// <param name="name"></param>
        public void SetCurrentWorksheet(string name)
        {
            for (int i = 0; i < workbook.Sheets.Count; i++)
            {
                Excel.Worksheet worksheetCurrent = (Excel.Worksheet)sheets.get_Item(i + 1);
                if (name.Equals(worksheetCurrent.Name))
                {
                    worksheet = (Excel.Worksheet)sheets.get_Item(i + 1);
                }
            }
        }


        /// <summary>
        /// Set the current worksheet by index
        /// </summary>
        /// <param name="index"></param>
        public void SetCurrentWorksheet(int index)
        {
            if (index < 1)
                throw new Exception("Index out of bounds");
            if (index > workbook.Sheets.Count)
                throw new Exception("Index out of bounds");

            worksheet = (Excel.Worksheet)sheets.get_Item(index);
        }


        /// <summary>
        /// Saves as excel 2007 format
        /// </summary>
        /// <param name="fullPath">Full path with .xlsx extension</param>
        public void SaveAs2007(string fullPath)
        {
            workbook.SaveAs(fullPath, 52,
                    missing, missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    missing, missing, missing, missing, missing);
        }

        /// <summary>
        /// Saves as excel 2003 format
        /// </summary>
        /// <param name="fullPath">Full path with .xls extension</param>
        public void SaveAs2003(string fullPath)
        {
            workbook.SaveAs(fullPath, Excel.XlFileFormat.xlWorkbookNormal,
                missing, missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
        }

        /// <summary>
        /// Release system resources
        /// </summary>        
        private void CleanUp()
        {
            try
            {
                if (workbook != null)
                {
                    workbook.Close(false, null, null);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    excel.Workbooks.Close();
                }
                if (excel != null)
                {
                    excel.Quit();
                    excel.Workbooks.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                }

                excel = null;
                sheets = null;
                worksheet = null;
                workbook = null;

            }
            catch (Exception) { }

            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Set the column ranges e.g A1 B30 or A1 A1 if you want.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void SetRange(string from, string to)
        {
            range = worksheet.get_Range(from, to);
        }

        /// <summary>
        /// Set the value of the range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void SetRangeValue(string value)
        {
            range.Value2 = value;
        }

        /// <summary>
        /// Set the value of the range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void SetRangeValue(string[,] value)
        {
            range.Value2 = value;
        }


        /// <summary>
        /// Returns a multidimensional array of the range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string[,] GetRangeValue(string value)
        {
            return (string[,])range.Value2;
        }

        /// <summary>
        /// Formats the font in a cell, bold italic and underline take a bool as a value.
        /// Fontsize font color and font type are all nullable so you can write null if you dont want to specify
        /// </summary>
        public void FormatRangeFont(string from, string to, bool bold, bool italic, bool underline, double? fontSize, Color? fontColor, string fontName)
        {
            range = worksheet.get_Range(from, to);

            range.Font.Bold = bold;
            range.Font.Italic = italic;
            range.Font.Underline = underline;

            if (fontSize != null)
                range.Font.Size = fontSize;
            if (fontColor != null)
                range.Font.Color = ColorTranslator.ToOle(fontColor.Value);
            if (!string.IsNullOrEmpty(fontName))
                range.Font.Name = fontName;
        }


        public void FormatRange(string from, string to, Color? background, Align vertical, Align horizontal, BorderType borderType, BorderLineStyle borderStyle)
        {
            range = worksheet.get_Range(from, to);

            if (background != null)
                range.Interior.Color = ColorTranslator.ToOle(background.Value);
            if (!vertical.Equals(Align.None))
                range.VerticalAlignment = vertical;
            if (!horizontal.Equals(Align.None))
                range.HorizontalAlignment = horizontal;

            if (borderType == BorderType.None)
                return;
            if (borderType == BorderType.BorderOutside)
                range.BorderAround(borderStyle, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexNone, missing);
            else
            {
                range.Borders.LineStyle = borderStyle;
            }
        }

        /// <summary>
        /// Get the value of a cell e.g  A1
        /// </summary>
        public string GetCellValue(string location)
        {
            return worksheet.get_Range(location, missing).Value2.ToString();
        }

        /// <summary>
        /// Set the value of a cell e.g  A1
        /// </summary>
        public void SetCellValue(string location, string value)
        {
            worksheet.get_Range(location, missing).Value2 = value;
        }


        /// <summary>
        /// Formats the font in a cell, bold italic and underline take a bool as a value.
        /// Fontsize font color and font type are all nullable so you can write null if you dont want to specify
        /// </summary>
        public void FormatCellFont(string location, bool bold, bool italic, bool underline, double? fontsize, Color? fontcolor, string fontname)
        {
            range = worksheet.get_Range(location, missing);

            range.Font.Bold = bold;
            range.Font.Italic = italic;
            range.Font.Underline = underline;

            if (fontsize != null)
                range.Font.Size = fontsize;
            if (fontcolor != null)
                range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontcolor.Value);
            if (!string.IsNullOrEmpty(fontname))
                range.Font.Name = fontname;
        }

        /// <summary>
        /// Set whether Excel should display alerts such as "Do you want to save this file?"
        /// </summary>
        /// <param name="alerts"></param>
        private void DisplayAlerts(bool alerts)
        {
            excel.DisplayAlerts = alerts;
        }

        /// <summary>
        /// Make the excel document visible or invisible
        /// </summary>
        private void SetVisibility(bool visibility)
        {
            excel.Visible = visibility;
        }

        /// <summary>
        /// Prints the current worksheet
        /// </summary>
        public void PrintWorksheet(int copies)
        {
            worksheet.PrintOut(missing, missing, copies, missing, true, missing, missing, missing);
        }


        /// <summary>
        /// Prints all the worksheets 
        /// </summary>
        public void PrintAllWorksheets(int copies)
        {
            int count = WorksheetCount;

            for (int i = 1; i < count + 1; i++)
            {
                Excel.Worksheet worksheetPrint = (Excel.Worksheet)sheets.get_Item(i);
                worksheetPrint.PrintOut(missing, missing, copies, missing, true, missing, missing, missing);
            }
        }


        #endregion

        #region properties

        /// <summary>
        /// Get the current worksheet you are working with
        /// </summary>
        public string CurrentWorksheet
        {
            get { return worksheet.Name; }
        }


        /// <summary>
        /// Get the address of current range you are working with
        /// </summary>
        public string GetRangeAddress
        {
            get
            {
                if (range == null)
                    return "null";
                else
                    return range.get_AddressLocal(range.Rows.Count, range.Columns.Count, Excel.XlReferenceStyle.xlA1, null, worksheet.UsedRange).Replace("$", "");
            }
        }


        /// <summary>
        /// Get the current number of worksheets
        /// </summary>
        public int WorksheetCount
        {
            get { return workbook.Worksheets.Count; }
        }

        /// <summary>
        /// Return a list of worksheet names
        /// </summary>
        public List<object> WorksheetNames
        {
            get
            {
                Excel.Worksheet worksheetName;

                List<object> names = new List<object>();

                for (int i = 0; i < workbook.Sheets.Count; i++)
                {
                    worksheetName = (Excel.Worksheet)sheets.get_Item(i + 1);
                    names.Add(worksheetName.Name);
                }

                return names;
            }
        }


        /// <summary>
        /// Returns whether a worksheet has any values or not. Cells with white space are considered to be empty
        /// </summary>
        public bool WorksheetBlank
        {
            get
            {
                Excel.Range rangeBlank = worksheet.UsedRange;

                if (rangeBlank.Count == 1 && rangeBlank.Value2 == null)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        #region Enums
        enum BorderOptions
        {
            Diagonal = Excel.XlBordersIndex.xlDiagonalDown,
            DiagonalUp = Excel.XlBordersIndex.xlDiagonalUp,
            EdgeBottom = Excel.XlBordersIndex.xlEdgeBottom,
            EdgeLeft = Excel.XlBordersIndex.xlEdgeLeft,
            EdgeRight = Excel.XlBordersIndex.xlEdgeRight,
            EdgeTop = Excel.XlBordersIndex.xlEdgeTop,
            InsideHorizontal = Excel.XlBordersIndex.xlInsideHorizontal,
            InsideVerticale = Excel.XlBordersIndex.xlInsideVertical

        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum BorderType
    {
        BorderOutside = 2,
        AllBorder = 1,
        None = 0
    }


    /// <summary>
    /// Line style options
    /// </summary>
    public enum BorderLineStyle
    {
        Continuous = Excel.XlLineStyle.xlContinuous,
        Dash = Excel.XlLineStyle.xlDash,
        DashDot = Excel.XlLineStyle.xlDashDot,
        DashDotDot = Excel.XlLineStyle.xlDashDotDot,
        Dot = Excel.XlLineStyle.xlDot,
        Double = Excel.XlLineStyle.xlDouble,
        SlantDashDot = Excel.XlLineStyle.xlSlantDashDot,
        None = Excel.XlLineStyle.xlLineStyleNone
    }
    /// <summary>
    /// 
    /// </summary>
    public enum Align
    {
        AlignBottom = Excel.XlVAlign.xlVAlignBottom,
        AlignCenter = Excel.XlVAlign.xlVAlignCenter,
        AlignDistributed = Excel.XlVAlign.xlVAlignDistributed,
        AlginJustify = Excel.XlVAlign.xlVAlignJustify,
        AlignTop = Excel.XlVAlign.xlVAlignTop,
        None = 0

    }
}
