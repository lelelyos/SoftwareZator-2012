// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class Options
    {
        public bool EnableJustMyCode = true;
        public bool StepOverNoSymbols = true;
        public bool StepOverDebuggerAttributes = true;
        public bool StepOverAllProperties = true;
        public bool StepOverSingleLineProperties = true;
        public bool StepOverFieldAccessProperties = true;
        public bool Verbose = true;
        public string[] SymbolsSearchPaths = new string[0];
        public bool SuspendOtherThreads = true;
    }
}