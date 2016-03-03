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

namespace VelerSoftware.SZC.Debugger.Core.Services
{
    /// <summary>
    /// Interface for AnalyticsMonitorService.
    /// </summary>
    /// <remarks>Implementations of this interface must be thread-safe.</remarks>
    public interface IAnalyticsMonitor
    {
        void TrackException(Exception exception);

        IAnalyticsMonitorTrackedFeature TrackFeature(string featureName, string activationMethod);
    }
}