﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPNameSpace;
using ERPConnection;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserRoleClass
/// </summary>
public class UserModuleRoleClass:PersonalClass
{
    public string RoleCode  { get; set; }
   
    public string RoleTitle { get; set; }
    public string ModuleCode { get; set; }
    public string ModuleName { get; set; }

    public static string GetUserModuleRole(string uid, string ModuleCode = "ERP")
    {
       
        string MRole = "Guest";
        try
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();
            string sql = "select dbo.funGetUserModuleRole('" + uid + "','" + ModuleCode + "') as ModuleRole";
            MRole = erpconn.RunFindSQL(sql);
                       
        }
        catch(Exception er) {

            MRole = "Error : " + er.Message.ToString();
        }
        return MRole;
    }


}