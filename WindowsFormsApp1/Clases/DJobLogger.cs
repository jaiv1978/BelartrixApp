using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Belatrix.Interfaces;

namespace Belatrix.Clases
{
    public class DJobLogger : Interfaces.IJobLogger
    {
        #region Properties

        public bool LogToFile { get; set; }
        public bool LogToDatabase { get; set; }
        public bool LogToConsole { get; set; }
        public bool LogTypeMessage { get; set; }
        public bool LogTypeWarning { get; set; }
        public bool LogTypeError { get; set; }
        public ILogToFile LogMsgToFile { get; set; }
        public ILogToDataBase LogMsgToDataBase { get; set; }
        public ILogToConsole LogMsgToConsole { get; set; }

        #endregion

        #region Constructors

        public DJobLogger()
        {
            LogToFile = true;
            LogToDatabase = true;
            LogToConsole = true;
            LogTypeMessage = true;
            LogTypeWarning = true;
            LogTypeError = true;
            LogMsgToFile = new DLogToFile();
            LogMsgToDataBase = new DLogToDataBase();
            LogMsgToConsole = new DLogToConsole();
        }

        public DJobLogger(bool pLogToFile, bool pLogToDatabase, bool pLogToConsole, bool pLogTypeMessage,
            bool pLogTypeWarning, bool pLogTypeError)
        {
            LogToFile = pLogToFile;
            LogToDatabase = pLogToDatabase;
            LogToConsole = pLogToConsole;
            LogTypeMessage = pLogTypeMessage;
            LogTypeWarning = pLogTypeWarning;
            LogTypeError = pLogTypeError;
            LogMsgToFile = new DLogToFile();
            LogMsgToDataBase = new DLogToDataBase();
            LogMsgToConsole = new DLogToConsole();
        }

        #endregion

        #region Functions

        public void LogMessage(string pMessage, Enumerations.LogType pLogType)
        {
            string validationResult = ValidateData(pMessage, pLogType);
            if (!string.IsNullOrEmpty(validationResult))
            {
                throw new Exception(validationResult);
            }

            try
            {
                if (LogToDatabase)
                {
                    LogMsgToDataBase.LogMessageToDataBase(pMessage, Convert.ToInt32(pLogType.GetHashCode().ToString()));
                }

                if (LogToFile)
                {
                    LogMsgToFile.LogMessageToFile(pMessage);
                }

                if (LogToConsole)
                {
                    LogMsgToConsole.LogMessageToConsole(pMessage, pLogType);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion al intentar registrar el mensaje", ex);
            }
        }

        public string ValidateData(string pMessage, Enumerations.LogType pLogType)
        {
            string messageResult = string.Empty;
            pMessage = pMessage == null ? "" : pMessage.Trim();

            if (string.IsNullOrEmpty(pMessage))
            {
                messageResult = "Message can't be null or empty";
            }

            if (!LogToConsole && !LogToFile && !LogToDatabase)
            {
                messageResult = "Error or Warning or Message must be specified";
            }

            if ((pLogType == Enumerations.LogType.message && !LogTypeMessage) ||
                (pLogType == Enumerations.LogType.error && !LogTypeError) ||
                (pLogType == Enumerations.LogType.warning && !LogTypeWarning))
            {
                messageResult = "JobLogger is not configured to save this type of log";
            }

            return messageResult;
        }

        #endregion

    }
}
