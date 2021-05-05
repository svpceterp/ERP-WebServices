using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using nsManageInstitute;
/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace nsManageCourseScheme
{
    public class clsCourseCategory:clsManageInstitute 
    {
       

        public int CourseCategoryID { get; set; }
        public string CourseCategoryTitle { get; set; }
        public string CourseCategoryCredit { get; set; }
        


        public List<clsCourseCategory> getCourseCategories()
        {


            List<clsCourseCategory> CatList = new List<clsCourseCategory>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCourseCategory", conn);

                    if (CourseCategoryID > 0)
                        sqlComm.Parameters.AddWithValue("@CourseCategoryID", CourseCategoryID);

                    if (ProgramID > 0)
                        sqlComm.Parameters.AddWithValue("@ProgramID", ProgramID);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CatList.Add(new clsCourseCategory
                    {
                        ProgramID=int.Parse(dr["ProgramID"].ToString()),
                        AcademicYear=dr["AcademicYear"].ToString(),
                        ProgramName=getPrograms(ProgramID)[0].ProgramName,
                        CourseCategoryID = int.Parse(dr["CourseCategoryID"].ToString()),
                        CourseCategoryTitle = dr["CourseCategoryTitle"].ToString(),
                        CourseCategoryCredit = dr["CourseCategoryCredit"].ToString()

                    });

                }
            }
            catch (Exception er)
            {
                CatList.Add(new clsCourseCategory { ErrorMessage = er.Message.ToString() });
            }
            return CatList;


        }
        public clsMessage updateCourseCategory(string action = "insert")
        {
            clsMessage rm = new clsMessage();

            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateCourseCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseCategoryID", CourseCategoryID);
                    cmd.Parameters.AddWithValue("@ProgramID", ProgramID);
                    cmd.Parameters.AddWithValue("@CourseCategoryTitle", CourseCategoryTitle);
                    cmd.Parameters.AddWithValue("@CourseCategoryCredit", CourseCategoryCredit);
                    cmd.Parameters.AddWithValue("@ACYR",AcademicYear);

                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.StatusMessage = (string)cmd.Parameters["@rvalue"].Value.ToString().Trim();
                    //rm.StatusMessage = "success";
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