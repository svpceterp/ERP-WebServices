using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPLocalConnection;

/// <summary>
/// Summary description for ConnectionDB
/// </summary>
public class ConnectionDB
{
    public static SqlConnection OpenConnection()
    {
        SqlConnection conn = new SqlConnection();
        ERPConnectionClass erpconnection = new ERPConnectionClass();
        conn = erpconnection.OpenConnection();
        return conn;
    }
    public static string RunSQL(string sql)
    {
        SqlConnection conn = new SqlConnection();
        ERPConnectionClass erpconnection = new ERPConnectionClass();
        string str= erpconnection.RunFindSQL(sql);
        return str;
    }
   
}