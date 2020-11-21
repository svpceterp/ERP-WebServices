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

    StudentClass s = new StudentClass();

    [WebMethod]
    public MessageClass UpdateStudentDetails(StudentClass sclr, string action = "Insert")
    {
        MessageClass rm = new MessageClass();

       // rm = s.UpdateStudentDetails(sclr, action);

        return rm;

    }

    [WebMethod(MessageName = "WithOutParametter")]
    public List<StudentClass> GetStudentDetails(string UID="ALL")
    {
        List<StudentClass> studentList = new List<StudentClass>();
      //studentList=s.GetStudentDetails("ALL", 0);

        return studentList;

    }
   

}
