using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Belatrix.Clases
{
    public class DLogToDataBase : Interfaces.ILogToDataBase
    {
        public int LogMessageToDataBase(string pMessage, int pType)
        {
            int record = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDB"].ToString());
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "SP_INSERT_LOG",
                CommandType = System.Data.CommandType.StoredProcedure                
            };
            command.Parameters.Add(new SqlParameter("@MESSAGE", pMessage));
            command.Parameters.Add(new SqlParameter("@TYPE", pType));

            try
            {
                connection.Open();
                record = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                command.Dispose();
            }

            return record;
        }
    }
}
