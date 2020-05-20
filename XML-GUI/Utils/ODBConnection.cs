﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace XML2DB
{
    public class ODBConnection
    {
        private static SqlConnection cn = null;
        private static string _host, _dbName, _user, _password;
        public static bool winAuth = true;

        public static string connectionString
        {
            get => winAuth ? $@"Data Source=.;Initial Catalog={_dbName};Integrated Security=true" : $@"Data Source=.;Initial Catalog={_dbName};User ID={_user};Password={_password}";
            set
            {
                _dbName = value.Split(':')[0];
                _user = winAuth ? String.Empty : value.Split(':')[1];
                _password = winAuth ? String.Empty : value.Split(':')[2];
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
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add(reader["name"].ToString());
            reader.Close();
            return result.ToArray();
        }
        
        public static void TableToXml(string tableName)
        {
            SqlCommand ps = new SqlCommand("SELECT * FROM QUOTENAME(@table_name)", ODBConnection.getConnection());
            ps.Parameters.AddWithValue("@table_name", tableName);
            //ps.Parameters.Add("@table_name", SqlDbType.VarChar, 50);
            //ps.Parameters["@table_name"].Value = tableName;
            ps.Prepare();
            //ps.ExecuteReader();
            DataTable dt = new DataTable();
            new SqlDataAdapter(ps).Fill(dt);
            dt.TableName = tableName;
            dt.WriteXml(tableName + ".xml");
        }
        
    }
}