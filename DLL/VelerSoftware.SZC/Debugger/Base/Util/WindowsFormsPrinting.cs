// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Drawing.Printing;
using System.Windows.Forms;
using VelerSoftware.SZC.Debugger.Base.Gui;
using VelerSoftware.SZC.Debugger.Core;

namespace VelerSoftware.SZC.Debugger.Base.Util
{
    /// <summary>
    /// Allows printing using the IPrintable interface.
    /// </summary>
    public class WindowsFormsPrinting
    {
        public static void Print(IPrintable printable)
        {
            using (PrintDocument pdoc = printable.PrintDocument)
            {
                if (pdoc != null)
                {
                    using (PrintDialog ppd = new PrintDialog())
                    {
                        ppd.Document = pdoc;
                        ppd.AllowSomePages = true;
                    }
                }
                else
                {
                    MessageService.ShowError("${res:VelerSoftware.SZC.Debugger.Base.Commands.Print.CreatePrintDocumentError}");
                }
            }
        }

        public static void PrintPreview(IPrintable printable)
        {
            using (PrintDocument pdoc = printable.PrintDocument)
            {
                if (pdoc != null)
                {
                    PrintPreviewDialog ppd = new PrintPreviewDialog();
                    ppd.TopMost = true;
                    ppd.Document = pdoc;
                }
                else
                {
                    MessageService.ShowError("${res:VelerSoftware.SZC.Debugger.Base.Commands.Print.CreatePrintDocumentError}");
                }
            }
        }
    }
}