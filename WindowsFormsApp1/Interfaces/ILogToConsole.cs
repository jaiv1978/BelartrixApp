using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Interfaces
{
    public interface ILogToConsole
    {
        void LogMessageToConsole(string pMessage, Enumerations.LogType pType);
    }
}
