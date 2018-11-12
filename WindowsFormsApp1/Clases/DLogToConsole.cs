using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Clases
{
    public class DLogToConsole : Interfaces.ILogToConsole
    {
        public void LogMessageToConsole(string pMessage, Enumerations.LogType pType)
        {
            switch (pType)
            {
                case Enumerations.LogType.message:
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                case Enumerations.LogType.error:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case Enumerations.LogType.warning:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
            }
            Console.WriteLine(string.Format("{0} {1}", DateTime.Now.ToShortDateString(), pMessage));
        }
    }
}
