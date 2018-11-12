using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix
{
    public class CJobLogger
    {
        #region properties

        public Interfaces.IJobLogger IfJobLogger { get; set; }

        #endregion

        #region Constructors

        public CJobLogger(Interfaces.IJobLogger pIJobLogger)
        {
            IfJobLogger = pIJobLogger;
        }

        #endregion

        #region Functions

        public void LogMessage(string pName, Enumerations.LogType pLogType)
        {
            IfJobLogger.LogMessage(pName, pLogType);
        }

        #endregion

    }
}
