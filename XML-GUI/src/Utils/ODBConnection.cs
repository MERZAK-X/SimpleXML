﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
 using System.Linq;
 using System.Security;

 namespace XMLUtils
{
    public class ODBConnection
    {
        private static SqlConnection cn = null;
        private static string _host, _instance, _dbName, _user, _password;
        public static bool winAuth = true, remote = false;

        public static string connectionString
        {
            get => winAuth 
                ? $@"Data Source={((remote) ? "tcp:" : String.Empty)}{_host + _instance};Initial Catalog={_dbName};Integrated Security=true;Connection Timeout=10;" 
                : $@"Data Source={((remote) ? "tcp:" : String.Empty)}{_host + _instance};Initial Catalog={_dbName};User ID={_user};Password={_password};Connection Timeout=10;";
            set
            {
                _dbName = value.Split(':')[0];
                _user = winAuth ? String.Empty : value.Split(':')[1];
                _password = winAuth ? String.Empty : value.Split(':')[2];
                _host = remote ? value.Split(':')[3] : ".";
                _instance = remote ? value.Split(':')[4] : String.Empty;
                /*_connectionString = winAuth
                    ? $@"Data Source=.;Initial Catalog={_dbName};Integrated Security = true"
                    : $@"Data Source=.;Initial Catalog={_dbName};User ID=${_user};Password={_password}";*/
            }
        }

        public static SqlConnection getConnection()
        {
            // TODO : Implement connection
            if (cn == null || cn.State == ConnectionState.Closed || cn.State == ConnectionState.Broken)
            {
                cn = new SqlConnection(connectionString);
                cn.Open();
            }
            return cn;
        }
        
        public static string[] GetAllTables()
        {
            List<string> result = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT name FROM sys.Tables", ODBConnection.getConnection());
            SqlDataReader reader = cmd.ExecuteReader(); // Could've been returned directly tho ...
            while (reader.Read())
                result.Add(reader["name"].ToString());
            reader.Close();
            return result.ToArray();
        }

        public static string[] GetTableColumns(string tableName)
        {
            string[] restrictions = new string[4] { null, null, tableName, null };
            var columnList = (ODBConnection.getConnection()).GetSchema("Columns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToArray();
            return columnList;
        }
        
        public static DataTable GetTable(string tableName)
        {
            SqlCommand st = new SqlCommand($"SELECT * FROM {SecurityElement.Escape(tableName)}", ODBConnection.getConnection());
            DataTable dt = new DataTable(tableName);
            new SqlDataAdapter(st).Fill(dt);
            return dt;
        }
        
        public static void TableToXml(string tableName)
        {
            SqlCommand st = new SqlCommand($"SELECT * FROM {SecurityElement.Escape(tableName)}", ODBConnection.getConnection());
            //ps.Parameters.AddWithValue("@tableName", tableName); // Not working due to no DDL (only DML/DQL) support available for SqlCommand
            DataTable dt = new DataTable(tableName);
            new SqlDataAdapter(st).Fill(dt);
            dt.WriteXml($@"..\..\..\lib\examples\{tableName}_dbdump.xml");
        }
        
    }
}