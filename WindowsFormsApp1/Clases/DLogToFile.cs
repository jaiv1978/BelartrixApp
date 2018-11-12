using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Belatrix.Clases
{
    public class DLogToFile : Interfaces.ILogToFile
    {
        public string Path { get ; set; }

        public void LogMessageToFile(string pMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(Path))
                {
                    Path = string.Format(@"{0}\LogFile{1}.txt", ConfigurationManager.AppSettings["LogFileDirectory"], DateTime.Now.ToString("yyyy-MM-dd"));
                    if(Path == null)
                    {
                        throw new Exception("Path can't be null");
                    }
                }

                System.IO.File.AppendAllText(Path, string.Format("{0}{1} {2}", Environment.NewLine, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), pMessage));
            }
            catch (Exception ex)
            {
                throw new Exception("Exception when trying to write to log file", ex);
            }
        }
    }
}
