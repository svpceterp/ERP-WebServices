using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.SqlClient;
using System.Data;
using ERPNameSpace;

/// <summary>
/// Summary description for UserRoleClass
/// </summary>
public class UserModuleRoleClass:StudentPastClass
{
    public string ModuleRoleCode  { get; set; }
   
    public string ModuleRoleTitle { get; set; }
    public string ModuleCode { get; set; }
    public string ModuleName { get; set; }

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