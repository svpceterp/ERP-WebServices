using ERPNameSpace;
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
public class WS_ERPMaster : System.Web.Services.WebService
{
    [WebMethod]
    public List<DepartmentClass> GetDepartment(string DeptID)
    {
        MessageClass ec = new MessageClass();
        DepartmentClass dClass = new DepartmentClass();
        List<DepartmentClass> deptList = new List<DepartmentClass>();

        try
        {
            dClass.DeptID = ((String.IsNullOrEmpty(DeptID)) ? "0" : DeptID);
        

            deptList = dClass.GetDepartment();

        }
        catch (Exception er)
        {

            deptList.Add(new DepartmentClass { ErrorMessage = er.Message.ToString() });

        }
        return deptList;

    }
    [WebMethod]
    public List<SemesterClass> GetSemester(string SemID)
    {
        SemesterClass sClass = new SemesterClass();
        List<SemesterClass> semList = new List<SemesterClass>();
        try
        {
            sClass.SemID = String.IsNullOrEmpty(SemID) ? "0" : SemID;

            semList = sClass.GetSemester();
        }
        catch (Exception er)
        {
            semList.Add(new SemesterClass { ErrorMessage = er.Message.ToString() });
        }
        return semList;

    }
    [WebMethod]
    public List<CourseCategoryClass> GetCourseCategory(string CourseCatID = "0")
    {
        CourseCategoryClass sClass = new CourseCategoryClass();
        List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
        try
        {
            sClass.CourseCatID = String.IsNullOrEmpty(CourseCatID) ? "0" : CourseCatID;

            CatList = sClass.GetCourseCategory();
        }
        catch (Exception er)
        {
            CatList.Add(new CourseCategoryClass { ErrorMessage = er.Message.ToString() });
        }
        return CatList;

    }

    [WebMethod]
    public List<DepartmentProgramClass> GetDepartmentProgram(string ProgramID = "0")
    {
        DepartmentProgramClass sClass = new DepartmentProgramClass();
        List<DepartmentProgramClass> CourseList = new List<DepartmentProgramClass>();
        try
        {
            sClass.ProgramID = String.IsNullOrEmpty(ProgramID) ? "0" : ProgramID;

            CourseList = sClass.GetDepartmentProgram();
        }
        catch (Exception er)
        {
            CourseList.Add(new DepartmentProgramClass { ErrorMessage = er.Message.ToString() });
        }
        return CourseList;

    }

    [WebMethod]
    public List<CourseSchemeClass> GetSubjectScheme(string SubjectID, string DeptID, string SemID, string CourseCatID)
    {

        CourseSchemeClass subClass = new CourseSchemeClass();
        List<CourseSchemeClass> subList = new List<CourseSchemeClass>();

        try
        {
            subClass.SubjectID = String.IsNullOrEmpty(SubjectID) ? "0" : SubjectID;
            subClass.DeptID = String.IsNullOrEmpty(DeptID) ? "0" : DeptID;
            subClass.SemID = String.IsNullOrEmpty(SemID) ? "0" : SemID;
            subClass.CourseCatID = String.IsNullOrEmpty(CourseCatID) ? "0" : CourseCatID;
            subList = subClass.GetSubjectScheme();
        }
        catch (Exception er)
        {
            subList.Add(new CourseSchemeClass { ErrorMessage = er.Message.ToString() });

        }
        return subList;

    }

    [WebMethod]
    public List<CountryClass> GetCountry()
    {
        CountryClass countryClass = new CountryClass();
        List<CountryClass> countryNameList = new List<CountryClass>();
        countryNameList = countryClass.GetCountryName();

        return countryNameList;

    }
    [WebMethod]
    public List<StateClass> GetState(string CountryCode = "ALL")
    {
        StateClass stateClass = new StateClass();
        List<StateClass> stateNameList = new List<StateClass>();
        stateNameList = stateClass.GetStateName(CountryCode);

        return stateNameList;

    }
    [WebMethod]
    public List<InstituteClass> GetInstitute(string InstID = "ALL")
    {
        InstituteClass Inst = new InstituteClass();
        List<InstituteClass> InstList = new List<InstituteClass>();
        InstList = Inst.GetInstitute();

        return InstList;

    }
    [WebMethod]
    public MessageClass UpdateCourseCategory(CourseCategoryClass ccat, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = ccat.UpdateCourseCategory(action);

        return rm;

    }
    [WebMethod]
    public MessageClass UpdateSubjectScheme(CourseSchemeClass subjectScheme, string action = "Insert")
    {
        MessageClass rm = new MessageClass();
        rm = subjectScheme.UpdateSubjectScheme(action);

        return rm;

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
