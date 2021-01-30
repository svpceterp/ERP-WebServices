﻿
using Examination;
using InstituteSetup;
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
    public List<ExamScheduleClass> GetExamSchedule(string ExamID)
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
    public MessageClass UpdateExamSchedule(ExamScheduleClass examSchedule, string action = "Insert")
    {
      
        MessageClass rm = new MessageClass();
        rm = examSchedule.UpdateExamSchedule(action);

        return rm;

    }
   
}
