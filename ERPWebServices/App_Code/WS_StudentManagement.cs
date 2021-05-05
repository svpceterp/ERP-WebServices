using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using nsManageInstitute;
using nsManageStudent;
using nsManageCourseScheme;
/// <summary>
/// Summary description for WS_StudentManagement
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_StudentManagement : System.Web.Services.WebService
{


   

    [WebMethod]
    public List<clsCourseScheme> GetStudentResgisteredCourses(string StudRegID,string uid,string programID,string semesterID)
     {
        clsStudentCourseRegistration stregcourse = new clsStudentCourseRegistration();
        int pID = 0;
        bool b = false;
        int sID = 0;
        int studID = 0;
        b = int.TryParse(StudRegID, out studID);

        b = int.TryParse(programID, out pID);

        b = int.TryParse(semesterID, out sID);

        if (uid.Length == 0)
            uid = "ALL";

        stregcourse.UID = uid;
      


        List<clsCourseScheme> studentCoursesList = new List<clsCourseScheme>();
        studentCoursesList=stregcourse.getStudentCourseRegistration();
        return studentCoursesList;
    }
    [WebMethod]
    public clsMessage UpdateStudentCourseRegistration(string pUID,string pCourseID,string action = "Insert")
    {
        clsStudentCourseRegistration stregcourse = new clsStudentCourseRegistration();
        clsMessage rm = new clsMessage();
        stregcourse.UID = pUID;
        stregcourse.CourseID = int.Parse(pCourseID);
        rm =stregcourse.updateStudentCourseRegistration(action);

        return rm;

    }
    [WebMethod]
    public clsMessage UpdateStudentCourseRegistrationBulk(clsStudentCourseRegistration studCourseReg ,clsManageInstitute Inst,List<string> pCourseList, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
       
        rm = studCourseReg.updateStudentCourseRegistrationBulk(Inst,pCourseList,action);

        return rm;

    }

}
