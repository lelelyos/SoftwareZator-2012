// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Debugger.Interop.CorPublish
{
    public static partial class CorPublishExtensionMethods
    {
        private static void ProcessOutParameter(object parameter)
        {
            TrackedComObjects.ProcessOutParameter(parameter);
        }
    }
}