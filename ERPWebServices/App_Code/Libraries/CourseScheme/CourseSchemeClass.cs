
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using nsManageInstitute;

/// <summary>
/// Summary description for SubjectSchemeClass
/// </summary>
/// 
namespace nsManageCourseScheme
{
    public class clsCourseScheme : clsCourseCategory
    {
        public clsCourseScheme()
        {
            CourseID = 0;
            CourseCategoryID = 0;
        }


        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string CourseGroup { get; set; }
        public int CourseLHr { get; set; }
        public int CourseTHr { get; set; }
        public int CoursePHr { get; set; }
        public int CourseCredit { get; set; }
        public int CourseCAMaxMarks { get; set; }
        public int CourseESEMaxMarks { get; set; }
        public int CourseTotalMaxMarks { get; set; }
        public decimal CourseESEDuration { get; set; }
        public string CourseType { get; set; }
       
        public string CourseTHPR { get; set; }

        public List<clsCourseScheme> getCourseSchemes()
        {
            List<clsCourseScheme> SubjectList = new List<clsCourseScheme>();
            DataTable ds = new DataTable();

            try
            {

                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetCourseScheme]", conn);
                    if (CourseID > 0)
                        sqlComm.Parameters.AddWithValue("@CourseID", CourseID);

                

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

                    SubjectList.Add(new clsCourseScheme
                    {
                        CourseID = int.Parse(dr["CourseID"].ToString()),
                        CourseCategoryID = int.Parse(dr["CourseCategoryID"].ToString()),

                        ProgramID = int.Parse(dr["programid"].ToString()),
                        SemesterID = int.Parse(dr["SemesterID"].ToString()),
                        CourseCode = dr["CourseCode"].ToString(),
                        CourseTitle = dr["CourseTitle"].ToString(),
                        CourseGroup = dr["coursegroup"].ToString(),
                        AcademicYear =dr["CourseAcademicYear"].ToString(),
                        CourseLHr = l,
                        CourseTHr = t,
                        CoursePHr = p,
                        CourseCredit = c,
                        CourseCAMaxMarks = ca,
                        CourseESEMaxMarks = ese,
                        CourseTotalMaxMarks = tmm,
                        CourseESEDuration = dur,
                        CourseType = dr["CourseType"].ToString(),
                     
                        CourseTHPR = dr["courseTHPR"].ToString()

                    });

                }
            }
            catch (Exception er)
            {
                SubjectList.Add(new clsCourseScheme { ErrorMessage = er.Message.ToString() });
            }

            return SubjectList;


        }

        public clsMessage updateCourseScheme(string action = "insert")
        {
            clsMessage rm = new clsMessage();

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

                    cmd.Parameters.AddWithValue("@CourseAcademicYear", AcademicYear);
                    cmd.Parameters.AddWithValue("@Coursecode", CourseCode);
                    cmd.Parameters.AddWithValue("@Coursetitle", CourseTitle);
                    cmd.Parameters.AddWithValue("@CourseGroup", CourseGroup);
                    cmd.Parameters.AddWithValue("@CourseLHr", CourseLHr);
                    cmd.Parameters.AddWithValue("@CourseTHr", CourseTHr);
                    cmd.Parameters.AddWithValue("@CoursePHr", CoursePHr);

                    cmd.Parameters.AddWithValue("@CourseCredit", CourseCredit);
                    cmd.Parameters.AddWithValue("@CourseCAMaxMarks", CourseCAMaxMarks);
                    cmd.Parameters.AddWithValue("@CourseESEMaxMarks", CourseESEMaxMarks);
                    cmd.Parameters.AddWithValue("@CourseTotalMaxMarks", CourseTotalMaxMarks);
                    cmd.Parameters.AddWithValue("@CourseESEDuration", CourseESEDuration);
                    cmd.Parameters.AddWithValue("@CourseType", CourseType);
                    cmd.Parameters.AddWithValue("@courseTHPR", CourseTHPR);
                    
                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.StatusMessage = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();
                    
                       
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

}


