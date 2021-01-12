using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using ERPConnection;
using ERP;
/// <summary>
/// Summary description for WS_UserLogin
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_UserLogin : System.Web.Services.WebService
{

    [WebMethod]
    public UserClass CheckLogin(string UserName, string Password)
    {

        UserClass user = new UserClass();

        LoginClass Login = new LoginClass(UserName, Password);
        user = Login.CheckLogin();

            
        return user;
    }

    [WebMethod]
    public  MessageClass ChangePassword(string Uname,string OldPassword,string NewPassword)
    {
        MessageClass rm = new MessageClass();
        LoginClass Login = new LoginClass(Uname,OldPassword,NewPassword);
        rm = Login.ChangePassword();

        return rm;
    }

    [WebMethod]
    public string GetModuleRole(string UserName, string ModuleCode="ERP")
    {

        LoginClass Login = new LoginClass(UserName, ModuleCode);
        string MRole= UserModuleRoleClass.GetUserModuleRole(UserName,ModuleCode);

        return MRole;
    }
}
