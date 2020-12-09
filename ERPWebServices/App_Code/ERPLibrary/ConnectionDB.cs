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
       
        ERPConnectionClass erpconnection = new ERPConnectionClass();
        erpconnection.OpenConnection("MSA\\DEV_MSA","TestERPDB_V2","DEV_sohail","tpdc123#");
        
        return erpconnection.conn;
    }
    public static string RunSQL(string sql)
    {
        try
        {
            ERPConnectionClass erpclass = new ERPConnectionClass();
            return erpclass.RunFindSQL(sql, OpenConnection());
        }
        catch { return "0"; }
    }
   
}