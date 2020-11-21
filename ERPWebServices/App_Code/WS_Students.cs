using ERPNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WS_Students
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_Students : System.Web.Services.WebService
{

    

    [WebMethod]
    public MessageClass UpdateStudentDetails(PersonalClass pc, string action = "Insert")
    {
        MessageClass rm = new MessageClass();

        rm = pc.UpdatePersonalDetails(action);

        return rm;

    }

    [WebMethod]
    public List<PersonalClass> GetPersonalDetails(string UID="ALL",string EmailID="ALL",string Name="ALL")
    {
        PersonalClass pc = new PersonalClass();
        List<PersonalClass> personList = new List<PersonalClass>();
      personList=pc.GetPersonalDetails(UID,EmailID,Name);

        return personList;

    }
   

}
