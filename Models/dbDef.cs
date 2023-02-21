using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerPlatformDb.Models
{
    public class dbDef
    {
        public static string DbServerAddress = "server_name";
        public static string DbName = "mytestdb";
        public static string DbConnStr = "Server=" + dbDef.DbServerAddress + ";Database=" + dbDef.DbName + ";Trusted_Connection=True";
    }
}
