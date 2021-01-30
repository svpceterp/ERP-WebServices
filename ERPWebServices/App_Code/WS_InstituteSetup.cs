
using InstituteSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
    public List<DepartmentClass> GetDepartment(string departmentID)
    {
        MessageClass ec = new MessageClass();
        DepartmentClass dClass = new DepartmentClass();
        List<DepartmentClass> deptList = new List<DepartmentClass>();

        try
        {
            int id = 0;
            bool b = int.TryParse(departmentID, out id);


            dClass.DepartmentID = id;
            
            deptList = dClass.GetDepartment();

        }
        catch (Exception er)
        {

            deptList.Add(new DepartmentClass { ErrorMessage = er.Message.ToString() });

        }
        return deptList;

    }
    [WebMethod]
    public List<SemesterClass> GetSemester(string semesterID)
    {
        SemesterClass sClass = new SemesterClass();
        List<SemesterClass> semList = new List<SemesterClass>();
        try
        {
            int id = 0;
            bool b = int.TryParse(semesterID, out id);

           sClass.SemesterID = id;

            semList = sClass.GetSemester();
        }
        catch (Exception er)
        {
            semList.Add(new SemesterClass { ErrorMessage = er.Message.ToString() });
        }
        return semList;

    }
   

    [WebMethod]
    public List<ProgramClass> GetProgram(string programID)
    {
        ProgramClass pClass = new ProgramClass();
        List<ProgramClass> programList = new List<ProgramClass>();
        try
        {
            int id = 0;
            bool b = int.TryParse(programID, out id);
            pClass.ProgramID = id;

            programList = pClass.GetProgram();
        }
        catch (Exception er)
        {
            programList.Add(new ProgramClass { ErrorMessage = er.Message.ToString() });
        }
        return programList;

    }

  
    [WebMethod]
    public List<CountryClass> GetCountry()
    {
        CountryClass countryClass = new CountryClass();
        List<CountryClass> countryNameList = new List<CountryClass>();
        countryNameList = countryClass.GetCountry();

        return countryNameList;

    }
    [WebMethod]
    public List<StateClass> GetState(string countryCode)
    {
        StateClass stateClass = new StateClass();
        List<StateClass> stateNameList = new List<StateClass>();

        if (countryCode.Length == 0)
            countryCode = "ALL";

        stateNameList = stateClass.GetState(countryCode);

        return stateNameList;

    }
    [WebMethod]
    public List<InstituteClass> GetInstitute(string instituteID)
    {
        InstituteClass Inst = new InstituteClass();
        List<InstituteClass> InstList = new List<InstituteClass>();

        int id = 0;
        bool b = int.TryParse(instituteID, out id);

        Inst.InstituteID = id;
        InstList = Inst.GetInstitute();

        return InstList;

    }
   
   

    [WebMethod]
    public MessageClass UpdateDepartment(DepartmentClass dept, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = dept.UpdateDepartment(action);

        return rm;

    }
    [WebMethod]
    public MessageClass UpdateInstitute(InstituteClass Inst, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = Inst.UpdateInstitute(action);

        return rm;

    }

}
