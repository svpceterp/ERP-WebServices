using System.Collections.Generic;
using System.Web.Services;
using nsManageInstitute;
using nsManageExamination;
/// <summary>
/// Summary description for WS_ExamMarks
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_ExamMarksEntry : System.Web.Services.WebService
{

 
    [WebMethod]
    public clsMessage UpdateExamQuestionSetup(clsExamQuestion eqs, string action = "insert")
    {
      return eqs.updateExamQuestionSetup(action);

    }

    [WebMethod]
    public clsMessage UpdateExamInternalMarks(int pIMID,List<clsExamInternalMarks> pIM,string action = "insert")
    {
        clsExamInternalMarks EIM = new clsExamInternalMarks();
        return EIM.UpdateExamInternalMarks(pIM,action);

    }



}
