using DramaReview.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DramaReview
{
    public enum DatabaseType
    {
        SQL
    }
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; } = new SQLConnector();

        public static void InitializeConnections(DatabaseType db)
        {
            if(db == DatabaseType.SQL)
            {
                SQLConnector sql = new SQLConnector();
                Connection = sql;
            }
        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
