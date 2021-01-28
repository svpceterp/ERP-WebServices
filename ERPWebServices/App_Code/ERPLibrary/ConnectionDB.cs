using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using  ERPLocalConnection;

/// <summary>
/// Summary description for ConnectionDB
/// </summary>
public class ConnectionDB
{
    // Connection Code for Live 

    //public static SqlConnection OpenConnection()
    //{

    //    ERPConnectionClass erpconnection = new ERPConnectionClass();

    //    return erpconnection.OpenConnection();
    //}

    public static SqlConnection OpenConnection()
    {

        ERPConnectionClass erpconnection = new ERPConnectionClass();
        erpconnection.OpenConnection("MSA\\DEV_MSA", "Test_ERPDB", "DEV_ERPUser", "tpdc123#");

        return erpconnection.conn;
    }
    public static string RunSQL(string sql)
    {
        try
        {
            ERPConnectionClass erpclass = new ERPConnectionClass();
            string x= erpclass.RunFindSQL(sql, OpenConnection());

            

            return x;
        }
        catch { return "0"; }
    }

   
   
}