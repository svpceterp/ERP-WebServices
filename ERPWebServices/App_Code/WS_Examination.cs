using ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WS_Examination
/// </summary>
[WebService(Namespace = "http://erp.svpcet.int/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_Examination : System.Web.Services.WebService
{

   

   
   
    [WebMethod]
    public List<ExamScheduleClass> GetExamSchedule(string ExamID,string DeptID,string SemID,string CourseID)
    {
        ExamScheduleClass examClass = new ExamScheduleClass();
        List<ExamScheduleClass> examList = new List<ExamScheduleClass>();

        try
        {
            examClass.ExamCourseID = (String.IsNullOrEmpty(CourseID) ? "0" : CourseID);
            examClass.ExamDeptID = (String.IsNullOrEmpty(DeptID) ? "0" : DeptID);
            examClass.ExamSemID = (String.IsNullOrEmpty(SemID) ? "0" : SemID);
            examClass.ExamID = (String.IsNullOrEmpty(ExamID) ? "0" : ExamID);

            examList = examClass.GetExamSchedule();
        }
        catch(Exception er) {
            examList.Add(new ExamScheduleClass { ErrorMessage = er.Message.ToString() });
        }
        return examList;

    }
    [WebMethod]
    public List<ExamSubjectsClass> GetExamCourse(string ExamID, string uid)
    {
        ExamSubjectsClass exSub = new ExamSubjectsClass();
        List<ExamSubjectsClass> exsubjectList = new List<ExamSubjectsClass>();

        try
        {
            exSub.ExamID = (String.IsNullOrEmpty(ExamID) ? "0" : ExamID);
           
            exsubjectList = exSub.GetExamSubject(uid);
        }
        catch (Exception er)
        {
            exsubjectList.Add(new ExamSubjectsClass { ErrorMessage = er.Message.ToString() });
        }
        return exsubjectList;

    }

  



    [WebMethod]
    public MessageClass UpdateExamSchedule(ExamScheduleClass examSchedule, string action = "Insert")
    {
      
        MessageClass rm = new MessageClass();
        rm = examSchedule.UpdateExamSchedule(action);

        return rm;

    }
    [WebMethod]
    public MessageClass UpdateExamCourse(ExamSubjectsClass exSub, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = exSub.UpdateExamSubject(action);

        return rm;

    }
   
}
