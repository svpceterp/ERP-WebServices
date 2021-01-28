
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for SubjectSchemeClass
/// </summary>
/// 

public class CourseSchemeClass : CourseCategoryClass
{
    public CourseSchemeClass()
    {
        CourseID = 0;
        CourseCategoryID = 0;
    }


    public int CourseID { get; set; }
    public string CourseCode { get; set; }
    public string CourseTitle { get; set; }
    public int CourseLHrPerWeek { get; set; }
    public int CourseTHrPerWeek { get; set; }
    public int CoursePHrPerWeek { get; set; }
    public int CourseCredit { get; set; }
    public int CourseCAMaxMarks { get; set; }
    public int CourseESEMaxMarks { get; set; }
    public int CourseTotalMaxMarks { get; set; }
    public decimal CourseESEDuration { get; set; }
    public string CourseType { get; set; }
    public string CourseGroup { get; set; }
    public string CourseTHPR { get; set; }

    public List<CourseSchemeClass> GetCourseScheme()
    {
        List<CourseSchemeClass> SubjectList = new List<CourseSchemeClass>();
        DataTable ds = new DataTable();

        try
        {

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetCourseScheme]", conn);
                if (CourseID > 0)
                    sqlComm.Parameters.AddWithValue("@CourseID", CourseID);

                if (CourseCategoryID > 0)
                    sqlComm.Parameters.AddWithValue("@CourseCategoryID", CourseCategoryID);


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }
            int l = 0, t = 0, p = 0, c = 0, ca = 0, ese = 0, tmm = 0, tm = 0, dur = 0;
            bool b = false;
            foreach (DataRow dr in ds.Rows)
            {
                b = int.TryParse(dr["CourseLHr"].ToString(), out l);
                b = int.TryParse(dr["CourseTHr"].ToString(), out t);
                b = int.TryParse(dr["CoursePHr"].ToString(), out p);
                b = int.TryParse(dr["CourseCredit"].ToString(), out c);
                b = int.TryParse(dr["CourseCAMaxMarks"].ToString(), out ca);
                b = int.TryParse(dr["CourseESEMaxMarks"].ToString(), out ese);
                b = int.TryParse(dr["CourseTotalMaxMarks"].ToString(), out tmm);
                b = int.TryParse(dr["CourseESEDuration"].ToString(), out dur);

                SubjectList.Add(new CourseSchemeClass
                {
                    CourseID = int.Parse(dr["CourseID"].ToString()),
                    CourseCategoryID = int.Parse(dr["CourseCategoryID"].ToString()),

                    ProgramID = int.Parse(dr["programid"].ToString()),
                    SemesterID = int.Parse(dr["SemesterID"].ToString()),
                    CourseCode = dr["SubjectCode"].ToString(),
                    CourseTitle = dr["SubjectTitle"].ToString(),
                    CourseLHrPerWeek = l,
                    CourseTHrPerWeek = t,
                    CoursePHrPerWeek = p,
                    CourseCredit = c,
                    CourseCAMaxMarks = ca,
                    CourseESEMaxMarks = ese,
                    CourseTotalMaxMarks = tmm,
                    CourseESEDuration = dur,
                    CourseType = dr["CourseType"].ToString(),
                    CourseGroup = dr["coursegroup"].ToString(),
                    CourseTHPR = dr["courseTHPR"].ToString()

                });

            }
        }
        catch (Exception er)
        {
            SubjectList.Add(new CourseSchemeClass { ErrorMessage = er.Message.ToString() });
        }

        return SubjectList;


    }

    public MessageClass UpdateCourseScheme(string action = "insert")
    {
        MessageClass rm = new MessageClass();


        try
        {
            using (SqlConnection con = ConnectionDB.OpenConnection())
            {

                SqlCommand cmd = new SqlCommand("Proc_UpdateCourseScheme", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@ProgramID", ProgramID);
                cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                cmd.Parameters.AddWithValue("@CourseCategoryID", CourseCategoryID);

                cmd.Parameters.AddWithValue("@acyr", AcademicYear);
                cmd.Parameters.AddWithValue("@coursecode", CourseCode);
                cmd.Parameters.AddWithValue("@coursetitle", CourseTitle);
                cmd.Parameters.AddWithValue("@courseGroup", CourseGroup);
                cmd.Parameters.AddWithValue("@CourseLHr", CourseLHrPerWeek);
                cmd.Parameters.AddWithValue("@CourseTHr", CourseTHrPerWeek);
                cmd.Parameters.AddWithValue("@CoursePHr", CoursePHrPerWeek);

                cmd.Parameters.AddWithValue("@coursecredit", CourseCredit);
                cmd.Parameters.AddWithValue("@coursecamaxmarks", CourseCAMaxMarks);
                cmd.Parameters.AddWithValue("@courseesemaxmarks", CourseESEMaxMarks);
                cmd.Parameters.AddWithValue("@courseeseduration", CourseESEDuration);
                cmd.Parameters.AddWithValue("@coursetype", CourseType);
                cmd.Parameters.AddWithValue("@courseTHPR", CourseTHPR);


                cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                rm.SuccessMessage = (string)cmd.Parameters["@rvalue"].Value;
                rm.StatusMessage = "success";
            }
        }
        catch (Exception er)
        {
            rm.ErrorMessage = er.Message.ToString();
            rm.StatusMessage = "failed";
        }

        return rm;

    }

}    


