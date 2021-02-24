using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Student;
using Scheme;
using InstituteSetup;
/// <summary>
/// Summary description for WS_StudentManagement
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_StudentManagement : System.Web.Services.WebService
{


    StudentCourseRegistrationClass stregcourse = new StudentCourseRegistrationClass();

    [WebMethod]
    public List<CourseSchemeClass> GetStudentResgisteredCourses(string StudRegID,string uid,string programID,string semesterID)
     {
        int pID = 0;
        bool b = false;
        int sID = 0;
        int studID = 0;
        b = int.TryParse(StudRegID, out studID);

        b = int.TryParse(programID, out pID);

        b = int.TryParse(semesterID, out sID);

        if (uid.Length == 0)
            uid = "ALL";

       
        stregcourse.StudentCourseRegID = studID;
        stregcourse.UID = uid;
        stregcourse.ProgramID = pID;
        stregcourse.SemesterID = sID;


        List<CourseSchemeClass> studentCoursesList = new List<CourseSchemeClass>();
        studentCoursesList=stregcourse.GetStudentCourseRegistration();
        return studentCoursesList;
    }
    [WebMethod]
    public MessageClass UpdateStudentCourseRegistration(string pUID,string pCourseID,string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        stregcourse.UID = pUID;
        stregcourse.CourseID = int.Parse(pCourseID);
        rm =stregcourse.UpdateStudentCourseRegistration(action);

        return rm;

    }
    public MessageClass UpdateStudentCourseRegistrationBulk(StudentCourseRegistrationClass pstudentRegCourse,List<CourseSchemeClass> pCourseList, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = pstudentRegCourse.UpdateStudentCourseRegistrationBulk(pCourseList,action);

        return rm;

    }

}
