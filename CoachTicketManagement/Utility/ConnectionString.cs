using System;
using System.Collections.Generic;
using System.Text;

namespace CoachTicketManagement.Utility
{
    public class ConnectionString
    {
        #region Design Singleton Pattern
        private static ConnectionString instance;
        public static ConnectionString Instance
        {
            get { if (instance == null) instance = new ConnectionString(); return instance; }
            private set { instance = value; }
        }
        private ConnectionString() { }
        #endregion

        #region Connection String
        public string getConnectionString() => @"Data Source=.; Initial Catalog=CoachTicketManagementCNPM; Integrated Security=True";
        public string getConnectionString(string databaseName) => @"Data Source=.; Initial Catalog=" + databaseName + "; Integrated Security=True";
        public string getConnectionString(string serverName, string databaseName) => @"Data Source=" + serverName + "; Initial Catalog=" + databaseName + "; Integrated Security=True";
        public string getConnectionString(string serverName, string databaseName, string id, string pass) => @"Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User ID=" + id + ";Password=" + pass;
        #endregion
    }
}

