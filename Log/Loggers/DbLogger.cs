using Log.Loggers;
using System.Data.SqlClient;

namespace Log
{
    public class DbLogger : ILogger
    {
        private readonly string sqlConnectionString;

        public DbLogger(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public void Log(string message, LogLevel logLevel) {

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    var command = new SqlCommand($"Insert into Log Values('{message}', {(int)logLevel})");
                    command.ExecuteNonQuery();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
