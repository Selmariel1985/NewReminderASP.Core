﻿using System;
using log4net;

namespace NewReminderASP.WebUI.Utilities
{
    public class Log
    {
        private static readonly Log _instance = new Log();
        protected static ILog debugLogger;
        protected ILog monitoringLogger;

        private Log()
        {
            monitoringLogger = LogManager.GetLogger("MonitoringLogger");
            debugLogger = LogManager.GetLogger("DebugLogger");
        }

        /// <summary>
        ///     Used to log Debug messages in an explicit Debug Logger
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Debug(string message)
        {
            debugLogger.Debug(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Debug(string message, Exception exception)
        {
            debugLogger.Debug(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Info(string message)
        {
            _instance.monitoringLogger.Info(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Info(string message, Exception exception)
        {
            _instance.monitoringLogger.Info(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Warn(string message)
        {
            _instance.monitoringLogger.Warn(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Warn(string message, Exception exception)
        {
            _instance.monitoringLogger.Warn(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Error(string message)
        {
            _instance.monitoringLogger.Error(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Error(string message, Exception exception)
        {
            _instance.monitoringLogger.Error(message, exception);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        public static void Fatal(string message)
        {
            _instance.monitoringLogger.Fatal(message);
        }

        /// <summary>
        /// </summary>
        /// <param name="message">The object message to log</param>
        /// <param name="exception">The exception to log, including its stack trace </param>
        public static void Fatal(string message, Exception exception)
        {
            _instance.monitoringLogger.Fatal(message, exception);
        }
    }
}