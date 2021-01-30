
using InstituteSetup;
using Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public List<CourseCategoryClass> GetCourseCategory(int CourseCategoryID)
    {
        CourseCategoryClass sClass = new CourseCategoryClass();
        List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
        try
        {
          
            sClass.CourseCategoryID = CourseCategoryID;

            CatList = sClass.GetCourseCategory();
        }
        catch (Exception er)
        {
            CatList.Add(new CourseCategoryClass { ErrorMessage = er.Message.ToString() });
        }
        return CatList;

    }


    [WebMethod(MessageName = "GetCourseCategoryWithOutID")]
    public List<CourseCategoryClass> GetCourseCategory()
    {
        CourseCategoryClass sClass = new CourseCategoryClass();
        List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
        try
        {
            sClass.CourseCategoryID =0;
            CatList = sClass.GetCourseCategory();
        }
        catch (Exception er)
        {
            CatList.Add(new CourseCategoryClass { ErrorMessage = er.Message.ToString() });
        }
        return CatList;

    }



    [WebMethod]
    public MessageClass UpdateCourseCategory(CourseCategoryClass objCourseCategory, string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        rm = objCourseCategory.UpdateCourseCategory(action);

        return rm;

    }


    [WebMethod(MessageName = "GetCourseSchemeByID")]
    public List<CourseSchemeClass> GetCourseScheme(int CourseID,int ProgramID)
    {

        CourseSchemeClass courseClass = new CourseSchemeClass();
        List<CourseSchemeClass> courseList = new List<CourseSchemeClass>();

        try
        {
            courseClass.CourseID = CourseID;
            courseClass.ProgramID = ProgramID;
            courseList = courseClass.GetCourseScheme();
        }
        catch (Exception er)
        {
            courseList.Add(new CourseSchemeClass { ErrorMessage = er.Message.ToString() });

        }
        return courseList;

    }

    [WebMethod(MessageName = "GetCourseSchemeWithOutID")]
    public List<CourseSchemeClass> GetCourseScheme()
    {

        CourseSchemeClass courseClass = new CourseSchemeClass();
        List<CourseSchemeClass> courseList = new List<CourseSchemeClass>();

        try
        {
            courseClass.CourseID = 0;
            courseClass.ProgramID = 0;
            courseList = courseClass.GetCourseScheme();
        }
        catch (Exception er)
        {
            courseList.Add(new CourseSchemeClass { ErrorMessage = er.Message.ToString() });

        }
        return courseList;

    }

    [WebMethod]
    public MessageClass UpdateCourseScheme(CourseSchemeClass objCourseScheme, string action = "Insert")
    {
        MessageClass rm = new MessageClass();
        rm = objCourseScheme.UpdateCourseScheme(action);

        return rm;

    }

}
