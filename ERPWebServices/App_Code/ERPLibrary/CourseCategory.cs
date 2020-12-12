using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class CourseCategoryClass:DepartmentProgramClass
    {
       
        public string CourseCatID { get; set; }
        public string CourseCategory { get; set; }
      
        public string CourseCredit{   get;set;  }
      

        public List<CourseCategoryClass> GetCourseCategory()
        {
            

            List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCourseCategory", conn);
                    sqlComm.Parameters.AddWithValue("@CourseCatID", CourseCatID);
                    sqlComm.Parameters.AddWithValue("@programID", ProgramID);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CatList.Add(new CourseCategoryClass
                    {
                        CourseCatID = dr["CourseCatID"].ToString(),
                       ProgramID = dr["ProgramID"].ToString(),
                        CourseCategory = dr["CourseCategory"].ToString(),
                        CourseCredit = dr["CourseCredit"].ToString()
                        
                    });

                }
            }
            catch (Exception er)
            {
                CatList.Add(new CourseCategoryClass { ErrorMessage = er.Message.ToString() });
            }
            return CatList;


        }
        public MessageClass UpdateCourseCategory(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateCourseCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProgramCourseCatID",);
                    cmd.Parameters.AddWithValue("@CourseCatID", CourseCatID);
                    cmd.Parameters.AddWithValue("@ProgramID", CourseCatID);
                    cmd.Parameters.AddWithValue("@CourseCategory", CourseCategory);
                    cmd.Parameters.AddWithValue("@CourseCredit", CourseCredit);
                    cmd.Parameters.AddWithValue("@action", action);

                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.Message = (string)cmd.Parameters["@rvalue"].Value;
                    rm.Status = "success";
                }
            }
            catch(Exception er) {
                rm.Message = er.Message.ToString();
                rm.Status = "failed";
            }

            return rm;

        }

    }
}