using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP;
using ERPConnection;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserRoleClass
/// </summary>
public class UserModuleRoleClass:RoleClass
{
       public static string GetUserModuleRole(string uid, string ModuleCode = "ERP")
    {
       
        string MRole = "Guest";
        try
        {
           
            string sql = "select dbo.funGetUserModuleRole('" + uid + "','" + ModuleCode + "') as ModuleRole";
            MRole = ConnectionDB.RunSQL(sql);
                       
        }
        catch(Exception er) {

            MRole = "Error : " + er.Message.ToString();
        }
        return MRole;
    }


}