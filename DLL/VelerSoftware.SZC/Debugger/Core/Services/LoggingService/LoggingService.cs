﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System;
using VelerSoftware.SZC.Debugger.Core.Services;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Class for easy logging.
    /// </summary>
    public static class LoggingService
    {
        public static void Debug(object message)
        {
            ServiceManager.Instance.LoggingService.Debug(message);
        }

        public static void DebugFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.DebugFormatted(format, args);
        }

        public static void Info(object message)
        {
            ServiceManager.Instance.LoggingService.Info(message);
        }

        public static void InfoFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.InfoFormatted(format, args);
        }

        public static void Warn(object message)
        {
            ServiceManager.Instance.LoggingService.Warn(message);
        }

        public static void Warn(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Warn(message, exception);
        }

        public static void WarnFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.WarnFormatted(format, args);
        }

        public static void Error(object message)
        {
            ServiceManager.Instance.LoggingService.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Error(message, exception);
        }

        public static void ErrorFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.ErrorFormatted(format, args);
        }

        public static void Fatal(object message)
        {
            ServiceManager.Instance.LoggingService.Fatal(message);
        }

        public static void Fatal(object message, Exception exception)
        {
            ServiceManager.Instance.LoggingService.Fatal(message, exception);
        }

        public static void FatalFormatted(string format, params object[] args)
        {
            ServiceManager.Instance.LoggingService.FatalFormatted(format, args);
        }

        public static bool IsDebugEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsDebugEnabled;
            }
        }

        public static bool IsInfoEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsInfoEnabled;
            }
        }

        public static bool IsWarnEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsWarnEnabled;
            }
        }

        public static bool IsErrorEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsErrorEnabled;
            }
        }

        public static bool IsFatalEnabled
        {
            get
            {
                return ServiceManager.Instance.LoggingService.IsFatalEnabled;
            }
        }
    }
}