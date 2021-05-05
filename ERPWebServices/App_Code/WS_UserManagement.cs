
using nsManageInstitute;
using nsManageUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for WS_UserLogin
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_UserManagement : System.Web.Services.WebService
{

    [WebMethod]
    public clsMessage CheckLogin(string UserName, string Password)
    {
        clsMessage status = new clsMessage();

        clsLogin Login = new clsLogin();
        status = Login.checkLogin(UserName,Password);
                   
        return status;
    }

    [WebMethod]
    public  clsMessage ChangePassword(string Uname,string OldPassword,string NewPassword)
    {
        clsMessage rm = new clsMessage();
        clsLogin Login = new clsLogin();
       
        rm = Login.changePassword(Uname,OldPassword,NewPassword);

        return rm;
    }

    [WebMethod]
    public string GetModuleRole(string UserName, string ModuleCode="ERP")
    {
           
        string MRole= clsUserModuleRole.GetUserModuleRole(UserName,ModuleCode);

        return MRole;
    }

   

  
    [WebMethod]
    public clsManageUser GetUserInfo(string UID)
    {
        clsManageUser u = new clsManageUser();
        u.getPersonalDetails(UID);

        return u;

    }


}
