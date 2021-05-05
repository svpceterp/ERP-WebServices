
using nsManageCourseScheme;
using nsManageExamination;
using nsManageInstitute;
using nsManageStudent;

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
    public List<clsExamSchedule> GetExamScheduleList(string ExamID)
    {
        clsExamSchedule examClass = new clsExamSchedule();
        List<clsExamSchedule> examList = new List<clsExamSchedule>();

        try
        {
            examClass.ExamID = int.Parse((String.IsNullOrEmpty(ExamID) ? "0" : ExamID));

            examList = examClass.getExamSchedule();
        }
        catch(Exception er) {
            examList.Add(new clsExamSchedule { ErrorMessage = er.Message.ToString() });
        }
        return examList;

    }

    [WebMethod]
    public List<clsStudent> GetHallTicketStudentsByExamIDUID(string pExamID,string pUID)
    {
        clsExamForm objExamForm = new clsExamForm();
        List<clsStudent> objStudentsList = new List<clsStudent>();
        DataTable dt = new DataTable();
        try
        {
            
            dt = objExamForm.getStudentHallTicketsByExamIDUID(pExamID,pUID);

            foreach (DataRow dr in dt.Rows)
            {
                objStudentsList.Add(new clsStudent
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
            objStudentsList.Add(new clsStudent { ErrorMessage = er.Message.ToString() });
        }
      return objStudentsList;

    }

    [WebMethod]
    public List<clsExamCourseSchedule> GetHallTicketSelectedCoursesByExamIDUID(string pExamID, string pUID)
    {
        clsExamForm objExamForm = new clsExamForm();
        List<clsExamCourseSchedule> objCourses = new List<clsExamCourseSchedule>();
        DataTable dt = new DataTable();
        try
        {

            dt = objExamForm.getStudentHallTicketsByExamIDUID(pExamID, pUID);

            foreach (DataRow dr in dt.Rows)
            {
                objCourses.Add(new clsExamCourseSchedule
                {
                    CourseCode = dr["CourseCode"].ToString(),
                    CourseTitle = dr["CourseTitle"].ToString(),
                    ExamCourseScheduleID = int.Parse(dr["ExamCourseScheduleID"].ToString())
                   
                });
            }

        }
        catch (Exception er)
        {
            objCourses.Add(new clsExamCourseSchedule { ErrorMessage = er.Message.ToString() });
        }
        return objCourses;

    }

    [WebMethod]
    public clsMessage UpdateExamSchedule(clsExamSchedule examSchedule, string action = "Insert")
    {
      
        clsMessage rm = new clsMessage();
        rm = examSchedule.updateExamSchedule(action);

        return rm;

    }

    [WebMethod]
    public clsMessage UpdateExamScheduleBulk(clsExamSchedule pExamSchedule,List<clsExamCourseSchedule> pExamCourseScheduleList, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
        rm = pExamSchedule.updateExamScheduleBulk(pExamCourseScheduleList,action);

        return rm;

    }

    [WebMethod]
    public clsMessage UpdateExamFormBulk(clsExamForm pExamForm, List<clsCourseScheme> pCourseList, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
        rm = pExamForm.updateExamForm(pCourseList, action);

        return rm;

    }

}
