
using Examination;
using InstituteSetup;
using Scheme;
using Student;
using System;
using System.Collections.Generic;
using System.Data;
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
    public List<ExamScheduleClass> GetExamScheduleList(string ExamID)
    {
        ExamScheduleClass examClass = new ExamScheduleClass();
        List<ExamScheduleClass> examList = new List<ExamScheduleClass>();

        try
        {
            examClass.ExamID = int.Parse((String.IsNullOrEmpty(ExamID) ? "0" : ExamID));

            examList = examClass.GetExamSchedule();
        }
        catch(Exception er) {
            examList.Add(new ExamScheduleClass { ErrorMessage = er.Message.ToString() });
        }
        return examList;

    }

    [WebMethod]
    public List<StudentClass> GetHallTicketStudentsByExamIDUID(string pExamID,string pUID)
    {
        ExamFormClass objExamForm = new ExamFormClass();
        List<StudentClass> objStudentsList = new List<StudentClass>();
        DataSet ds = new DataSet();
        try
        {
            
            ds = objExamForm.GetStudentHallTicketsByExamIDUID(pExamID,pUID);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objStudentsList.Add(new StudentClass
                {
                    UID = dr["uid"].ToString(),
                   StudentFullName = dr["Name"].ToString(),
                   MobileNo = dr["mobileno"].ToString(),
                   EmailID= dr["emailid"].ToString()
                });
            }

        }
        catch (Exception er)
        {
            objStudentsList.Add(new StudentClass { ErrorMessage = er.Message.ToString() });
        }
      return objStudentsList;

    }

    [WebMethod]
    public List<ExamCourseScheduleClass> GetHallTicketSelectedCoursesByExamIDUID(string pExamID, string pUID)
    {
        ExamFormClass objExamForm = new ExamFormClass();
        List<ExamCourseScheduleClass> objCourses = new List<ExamCourseScheduleClass>();
        DataSet ds = new DataSet();
        try
        {

            ds = objExamForm.GetStudentHallTicketsByExamIDUID(pExamID, pUID);

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                objCourses.Add(new ExamCourseScheduleClass
                {
                    CourseCode = dr["CourseCode"].ToString(),
                    CourseTitle = dr["CourseTitle"].ToString(),
                    ExamCourseScheduleID = int.Parse(dr["ExamCourseScheduleID"].ToString())
                   
                });
            }

        }
        catch (Exception er)
        {
            objCourses.Add(new ExamCourseScheduleClass { ErrorMessage = er.Message.ToString() });
        }
        return objCourses;

    }

    [WebMethod]
    public MessageClass UpdateExamSchedule(ExamScheduleClass examSchedule, string action = "Insert")
    {
      
        MessageClass rm = new MessageClass();
        rm = examSchedule.UpdateExamSchedule(action);

        return rm;

    }

    [WebMethod]
    public MessageClass UpdateExamScheduleBulk(ExamScheduleClass pExamSchedule,List<ExamCourseScheduleClass> pExamCourseScheduleList, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = pExamSchedule.UpdateExamScheduleBulk(pExamCourseScheduleList,action);

        return rm;

    }

    [WebMethod]
    public MessageClass UpdateExamFormBulk(ExamFormClass pExamForm, List<CourseSchemeClass> pCourseList, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = pExamForm.UpdateExamForm(pCourseList, action);

        return rm;

    }

}
