using Common.Enum;
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

namespace Common.Utils
{
    public static class LogHelper
    {
        private static readonly ILoggerRepository repository = LogManager.CreateRepository("ApiLogs");
        static LogHelper()
        {
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }
        private static readonly ILog log = LogManager.GetLogger(repository.Name, "LogHelper");
        private static readonly ILog log_Normal = LogManager.GetLogger(repository.Name, "LogHelperNormal");
        public static void Write(string msg, LogLev lev)
        {
            switch (lev)
            {
                case LogLev.Debug:
                    log_Normal.Debug(msg);
                    break;
                case LogLev.Error:
                    log.Error(msg);
                    break;
                case LogLev.Fatal:
                    log.Fatal(msg);
                    break;
                case LogLev.Info:
                    log_Normal.Info(msg);
                    break;
                case LogLev.Warn:
                    log_Normal.Warn(msg);
                    break;
                default:
                    break;
            }
        }
        public static void Write(string msg, LogLev lev, params object[] parm)
        {
            switch (lev)
            {
                case LogLev.Debug:
                    log_Normal.DebugFormat(msg, parm);
                    break;
                case LogLev.Error:
                    log.ErrorFormat(msg, parm);
                    break;
                case LogLev.Fatal:
                    log.FatalFormat(msg, parm);
                    break;
                case LogLev.Info:
                    log_Normal.InfoFormat(msg, parm);
                    break;
                case LogLev.Warn:
                    log_Normal.WarnFormat(msg, parm);
                    break;
                default:
                    break;
            }
        }
        public static void Write(Exception ex, LogLev lev)
        {
            switch (lev)
            {
                case LogLev.Debug:
                    log_Normal.Debug(ex);
                    break;
                case LogLev.Error:
                    log.Error(ex);
                    break;
                case LogLev.Fatal:
                    log.Fatal(ex);
                    break;
                case LogLev.Info:
                    log_Normal.Info(ex);
                    break;
                case LogLev.Warn:
                    log_Normal.Warn(ex);
                    break;
                default:
                    break;
            }
        }
        public static void Log(Exception ex)
        {
            Write($"等级：{LogLev.Fatal} 方法:{ex.TargetSite} 消息:{ex.Message} 类:{ex.Source} 堆:{ex.StackTrace} ",LogLev.Fatal);
        }
        public static void Log(Exception ex, int fmodelid)
        {
            Write("方法:{0} 消息:{1} 类:{2} 堆:{3} fmodelid:{4}", LogLev.Fatal, ex.TargetSite, ex.Message, ex.Source, ex.StackTrace, fmodelid);
        }
    }
}
