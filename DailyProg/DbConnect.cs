using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DailyProg
{
    public class DbConnect
    {
        public IDbConnection Connect { get; private set; }
        public DbConnect(IConfiguration configuration) 
        {
            Connect = new SqlConnection(configuration.GetConnectionString("DailyConnect"));
        }
        public DbConnect(string configuration)
        {
            Connect = new SqlConnection(configuration);
        }
    }
}
