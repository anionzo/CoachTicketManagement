using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace CoachTicketManagement.Utility
{
    public class ADOHelper
    {
        #region Design Singleton Pattern
        private static ADOHelper instance;
        public static ADOHelper Instance
        {
            get { if (instance == null) instance = new ADOHelper(); return instance; }
            private set { instance = value; }
        }
        private ADOHelper() { }
        #endregion

        #region Make Query
        public void AddParameters(ref SqlCommand cmd, object[] obj)
        {
            int lenPara = obj.Length;
            for (int i = 0; i < lenPara; i++)
                cmd.Parameters.AddWithValue(@"@para_" + i.ToString(), obj[i]);
        }
        public List<T> ExecuteReader<T>(string serverName, string databaseName, string query, params object[] obj) where T : class, new()
        {
            List<T> list = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString(serverName, databaseName)))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                SqlDataReader reader = cmd.ExecuteReader();
                int lenField = reader.FieldCount;
                while (reader.Read())
                {
                    T item = new T();
                    for (int i = 0; i < lenField; i++)
                    {
                        PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                        if (propertyInfo != null)
                            propertyInfo.SetValue(item, reader.GetValue(i));
                    }
                    list.Add(item);
                }
            }
            return list;
        }
        public int ExecuteNonQuery(string serverName, string databaseName, string query, params object[] obj)
        {
            int rowEffect = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString(serverName, databaseName)))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                rowEffect = cmd.ExecuteNonQuery();
            }
            return rowEffect;
        }
        public int ExecuteScalar(string serverName, string databaseName, string query, params object[] obj)
        {
            int rowEffect = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString(serverName, databaseName)))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                rowEffect = (int)cmd.ExecuteScalar();
            }
            return rowEffect;
        }


        public List<T> ExecuteReader<T>(string query, params object[] obj) where T : class, new()
        {
            List<T> list = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                SqlDataReader reader = cmd.ExecuteReader();
                int lenField = reader.FieldCount;
                while (reader.Read())
                {
                    T item = new T();
                    for (int i = 0; i < lenField; i++)
                    {
                        PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                        if (propertyInfo != null)
                            propertyInfo.SetValue(item, reader.GetValue(i));
                    }
                    list.Add(item);
                }
            }
            return list;
        }
        public int ExecuteNonQuery(string query, params object[] obj)
        {
            int rowEffect = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                rowEffect = cmd.ExecuteNonQuery();
            }
            return rowEffect;
        }
        public int ExecuteScalar(string query, params object[] obj)
        {
            int rowEffect = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj != null)
                    AddParameters(ref cmd, obj);
                rowEffect = (int)cmd.ExecuteScalar();
            }
            return rowEffect;
        }

        public DataTable ExecuteReader(string query, params object[] obj)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString.Instance.getConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                if (obj.Length > 0)
                    AddParameters(ref cmd, obj);
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                return dataTable;
            }    
        }

        #endregion
    }
}
