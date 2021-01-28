using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using ERPConnection;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERP
{
    public class CourseCategoryClass:SemesterClass
    {
        public CourseCategoryClass()
        {
            CourseCategoryID = 0;
            ProgramID = 0;
        }


      
        public int CourseCategoryID { get; set; }
        public string CourseCategoryTitle { get; set; }
        public string CourseCategoryCredit{ get; set; }
        public string AcademicYear { get; set; }   
      

        public List<CourseCategoryClass> GetCourseCategory()
        {
          

            List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCourseCategory", conn);

                    if(CourseCategoryID>0)
                    sqlComm.Parameters.AddWithValue("@CourseCategoryID",CourseCategoryID);

                    if(ProgramID>0)
                    sqlComm.Parameters.AddWithValue("@ProgramID",ProgramID);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CatList.Add(new CourseCategoryClass
                    {
                        CourseCategoryID = int.Parse(dr["CourseCategoryID"].ToString()),
                        CourseCategoryTitle = dr["CourseCategoryTitle"].ToString(),
                        CourseCategoryCredit = dr["CourseCategoryCredit"].ToString()
                        
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
                    cmd.Parameters.AddWithValue("@CourseCategoryID", CourseCategoryID);
                    cmd.Parameters.AddWithValue("@CourseCategoryTitle", CourseCategoryTitle);
                    cmd.Parameters.AddWithValue("@CourseCategoryCredit", CourseCategoryCredit);


                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.SuccessMessage = (string)cmd.Parameters["@rvalue"].Value;
                    rm.StatusMessage = "success";
                }
            }
            catch(Exception er) {
                rm.ErrorMessage = er.Message.ToString();
                rm.StatusMessage = "failed";
            }

            return rm;

        }

    }
}