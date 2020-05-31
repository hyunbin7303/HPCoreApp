using NLog;
using System;

namespace HP_Logging
{

    // Monitoring. automatic tool that reports information on your application.
    // Logging Target Types

    public static class HPLogger
    {
        private static void LogMessageBase<T>(string msgType, string msgIdentifier) where T : class
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Debug("This is a debug message");
            log.Error(new Exception(), "This is an error message");
            log.Fatal("This is a fatal message");
            var msg = new LogEventInfo(LogLevel.Info, "", "This is a message");
            msg.Properties.Add("User", "Ray Donovan");
            log.Info(msg);
            //log.Info("This is a message from {User}" "Mickey Donovan");
        }
    }
}
