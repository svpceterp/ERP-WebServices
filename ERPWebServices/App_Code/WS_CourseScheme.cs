using nsManageCourseScheme;
using nsManageInstitute;
using System;
using System.Collections.Generic;
using System.Web.Services;

/// <summary>
/// Summary description for WS_CourseScheme
/// </summary>
[WebService(Namespace = "http://erp.svpcet.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
//[System.Web.Script.Services.ScriptService]
public class WS_CourseScheme : System.Web.Services.WebService
{
    [WebMethod (MessageName ="GetCourseCategoryByID")]
    public List<clsCourseCategory> GetCourseCategory(string CourseCategoryID)
    {
        clsCourseCategory sClass = new clsCourseCategory();
        List<clsCourseCategory> CatList = new List<clsCourseCategory>();
        try
        {

            if (!string.IsNullOrEmpty(CourseCategoryID))
                sClass.CourseCategoryID = int.Parse(CourseCategoryID);
            else
                sClass.CourseCategoryID = 0;

            CatList = sClass.getCourseCategories();
        }
        catch (Exception er)
        {
            CatList.Add(new clsCourseCategory { ErrorMessage = er.Message.ToString() });
        }
        return CatList;

    }


    [WebMethod(MessageName = "GetCourseCategoryWithOutID")]
    public List<clsCourseCategory> GetCourseCategory()
    {
        clsCourseCategory sClass = new clsCourseCategory();
        List<clsCourseCategory> CatList = new List<clsCourseCategory>();
        try
        {
            sClass.CourseCategoryID =0;
            CatList = sClass.getCourseCategories();
        }
        catch (Exception er)
        {
            CatList.Add(new clsCourseCategory { ErrorMessage = er.Message.ToString() });
        }
        return CatList;

    }



    [WebMethod]
    public clsMessage UpdateCourseCategory(clsCourseCategory objCourseCategory, string action = "Insert")
    {

        clsMessage rm = new clsMessage();
        rm = objCourseCategory.updateCourseCategory(action);

        return rm;

    }


    [WebMethod(MessageName = "GetCourseSchemeByID")]
    public List<clsCourseScheme> GetCourseScheme(int CourseID,int ProgramID)
    {

        clsCourseScheme courseClass = new clsCourseScheme();
        List<clsCourseScheme> courseList = new List<clsCourseScheme>();

        try
        {
            courseClass.CourseID = CourseID;
            courseClass.ProgramID = ProgramID;
            courseList = courseClass.getCourseSchemes();
        }
        catch (Exception er)
        {
            courseList.Add(new clsCourseScheme { ErrorMessage = er.Message.ToString() });

        }
        return courseList;

    }

    [WebMethod(MessageName = "GetCourseSchemeWithOutID")]
    public List<clsCourseScheme> GetCourseScheme()
    {

        clsCourseScheme courseClass = new clsCourseScheme();
        List<clsCourseScheme> courseList = new List<clsCourseScheme>();

        try
        {
            courseClass.CourseID = 0;
            courseClass.ProgramID = 0;
            courseList = courseClass.getCourseSchemes();
        }
        catch (Exception er)
        {
            courseList.Add(new clsCourseScheme { ErrorMessage = er.Message.ToString() });

        }
        return courseList;

    }

    [WebMethod]
    public clsMessage UpdateCourseScheme(clsCourseScheme objCourseScheme, string action = "Insert")
    {
        clsMessage rm = new clsMessage();
        rm = objCourseScheme.updateCourseScheme(action);

        return rm;

    }

}
