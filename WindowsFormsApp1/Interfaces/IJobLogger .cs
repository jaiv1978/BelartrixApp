using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Interfaces
{
    public interface IJobLogger
    {
        bool LogToFile { get; set; }
        bool LogToDatabase { get; set; }
        bool LogToConsole { get; set; }
        bool LogTypeMessage { get; set; }
        bool LogTypeWarning { get; set; }
        bool LogTypeError { get; set; }
        ILogToFile LogMsgToFile {  get; set; }
        ILogToDataBase LogMsgToDataBase { get; set; }
        ILogToConsole LogMsgToConsole { get; set; }

        void LogMessage(string pMessage, Enumerations.LogType pLogType);
        string ValidateData(string pMessage, Enumerations.LogType pLogType);
    }
}
