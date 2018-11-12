using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Interfaces
{
    public interface ILogToDataBase
    {
        int LogMessageToDataBase(string pMessage, int pType);
    }
}
