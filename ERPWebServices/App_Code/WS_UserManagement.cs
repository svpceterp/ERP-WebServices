using InstituteSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using UserManagement;

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
    public MessageClass CheckLogin(string UserName, string Password)
    {
        MessageClass status = new MessageClass();

        LoginClass Login = new LoginClass(UserName, Password);
        status = Login.CheckLogin();

            
        return status;
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

    [WebMethod]
    public MessageClass UpdatePersonalDetails(PersonalClass pc, string action = "Insert")
    {
        MessageClass rm = new MessageClass();

        rm = pc.UpdatePersonalDetails(action);

        return rm;

    }

    [WebMethod]
    public List<PersonalClass> GetPersonalDetails(string UID,string EmailID,string Name)
    {
        PersonalClass pc = new PersonalClass();
        List<PersonalClass> personList = new List<PersonalClass>();

        UID = (String.IsNullOrEmpty(UID)) ? "ALL" : UID;
        EmailID = (String.IsNullOrEmpty(EmailID)) ? "ALL" : EmailID;
        Name = (String.IsNullOrEmpty(Name)) ? "ALL" : Name;

        personList = pc.GetPersonalDetails(UID, EmailID, Name);

        return personList;

    }
}
