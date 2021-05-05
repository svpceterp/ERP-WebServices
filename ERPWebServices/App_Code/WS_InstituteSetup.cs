using System;
using System.Collections.Generic;
using System.Web.Services;
using nsManageInstitute;


/// <summary>
/// Summary description for WS_ERPMaster
/// </summary>
[WebService(Namespace = "http://erp.svpcet.int/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WS_InstituteSetup : System.Web.Services.WebService
{
    [WebMethod]
    public List<clsDepartment> GetDepartment(string departmentID)
    {
        clsMessage ec = new clsMessage();
        clsDepartment dClass = new clsDepartment();
        List<clsDepartment> deptList = new List<clsDepartment>();

        try
        {
            int id = 0;
            bool b = int.TryParse(departmentID, out id);


            dClass.DepartmentID = id;

            deptList = dClass.getDepartments();

        }
        catch (Exception er)
        {

            deptList.Add(new clsDepartment { ErrorMessage = er.Message.ToString() });

        }
        return deptList;

    }
    [WebMethod]
    public List<clsSemester> GetSemester(string semesterID)
    {
        clsSemester sClass = new clsSemester();
        List<clsSemester> semList = new List<clsSemester>();
        try
        {
            int id = 0;
            bool b = int.TryParse(semesterID, out id);

           sClass.SemesterID = id;

            semList = sClass.getSemesters();
        }
        catch (Exception er)
        {
            semList.Add(new clsSemester { ErrorMessage = er.Message.ToString() });
        }
        return semList;

    }
   

    [WebMethod]
    public List<clsProgram> GetProgram(string programID)
    {
        clsProgram pClass = new clsProgram();
        List<clsProgram> programList = new List<clsProgram>();
        try
        {
            int id = 0;
            bool b = int.TryParse(programID, out id);
            pClass.ProgramID = id;

            programList = pClass.getPrograms();
        }
        catch (Exception er)
        {
            programList.Add(new clsProgram { ErrorMessage = er.Message.ToString() });
        }
        return programList;

    }

  
    [WebMethod]
    public List<clsCountry> GetCountry()
    {
        clsCountry countryClass = new clsCountry();
        List<clsCountry> countryNameList = new List<clsCountry>();
        countryNameList = countryClass.getCountries();

        return countryNameList;

    }
    [WebMethod]
    public List<clsState> GetState(string countryCode)
    {
        clsState stateClass = new clsState();
        List<clsState> stateNameList = new List<clsState>();

        if (string.IsNullOrEmpty(countryCode))
            countryCode = "ALL";

        stateNameList = stateClass.getStates(countryCode);

        return stateNameList;

    }
    [WebMethod]
    public List<clsInstitute> GetInstitute(string instituteID)
    {
        clsInstitute Inst = new clsInstitute();
        List<clsInstitute> InstList = new List<clsInstitute>();

        int id = 0;
        bool b = int.TryParse(instituteID, out id);

        Inst.InstituteID = id;
        InstList = Inst.getInstitutes();

        return InstList;

    }
   
   

    [WebMethod]
    public clsMessage UpdateDepartment(clsDepartment dept, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
        rm = dept.updateDepartment(action);

        return rm;

    }
    [WebMethod]
    public clsMessage UpdateInstitute(clsInstitute Inst, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
        rm = Inst.updateInstitute(action);

        return rm;

    }

}
