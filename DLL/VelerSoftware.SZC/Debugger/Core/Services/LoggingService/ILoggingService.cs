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
    public interface ILoggingService
    {
        void Debug(object message);

        void DebugFormatted(string format, params object[] args);

        void Info(object message);

        void InfoFormatted(string format, params object[] args);

        void Warn(object message);

        void Warn(object message, Exception exception);

        void WarnFormatted(string format, params object[] args);

        void Error(object message);

        void Error(object message, Exception exception);

        void ErrorFormatted(string format, params object[] args);

        void Fatal(object message);

        void Fatal(object message, Exception exception);

        void FatalFormatted(string format, params object[] args);

        bool IsDebugEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }
    }
}