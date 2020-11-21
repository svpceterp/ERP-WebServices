using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPConnection;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class CourseCategoryClass:DepartmentClass
    {
       private int CatID;

        bool b = false;
        int x = 0;
       int c = 0;
        public string CourseCatID { get { return CatID.ToString(); }
            set {
                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (x > 0)
                {
                   CatID = x;

                }
            } }
        public string CourseCategory { get; set; }
      
        public string CourseCredit
        {
            get { return c.ToString(); }
            set
            {
                b = int.TryParse(value, out c);
                if (c < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
               
            }
        }
      

        public List<CourseCategoryClass> GetCourseCategory()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<CourseCategoryClass> CatList = new List<CourseCategoryClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCourseCategory", conn);
                    sqlComm.Parameters.AddWithValue("@CourseCat_ID", CatID);
                    sqlComm.Parameters.AddWithValue("@dept_ID", DeptID);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CatList.Add(new CourseCategoryClass
                    {
                        CourseCatID = dr["CourseCat_ID"].ToString(),
                        DeptID = dr["Dept_ID"].ToString(),
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
            ERPConnectionClass erpconn = new ERPConnectionClass();
            try
            {

                using (SqlConnection con = erpconn.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateCourseCategory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseCat_ID", CourseCatID);
                    cmd.Parameters.AddWithValue("@CourseCategory", CourseCategory);
                    cmd.Parameters.AddWithValue("@CourseCredit", CourseCredit);


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