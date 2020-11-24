using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPLocalConnection;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class CourseProgramClass:InstituteClass
    {
       

        bool b = false;
        int x = 0;
       int c = 0;
        public string CourseID {
            get {
                return x.ToString();
            }
            set {
                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
               
            }
            
        }
      
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseDuration{ get; set; }
        public string CourseStartDate { get; set; }
        public string CourseEndDate { get; set; }
        public string CourseStatus { get; set; }
       

      

        public List<CourseProgramClass> GetCourseProgram()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<CourseProgramClass> CourseList = new List<CourseProgramClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCourseProgram", conn);
                    sqlComm.Parameters.AddWithValue("@Course_ID", CourseID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CourseList.Add(new CourseProgramClass
                    {
                        InstID = dr["Inst_id"].ToString(),
                        CourseID = dr["Course_ID"].ToString(),
                        CourseCode = dr["CourseCode"].ToString(),
                        CourseName = dr["CourseName"].ToString(),
                        CourseDescription = dr["CourseDescription"].ToString(),
                        CourseDuration = dr["Courseduration"].ToString(),
                        CourseStartDate = dr["CourseStartDate"].ToString(),
                        CourseEndDate = dr["CourseEnddate"].ToString(),
                        CourseStatus = dr["CourseStatus"].ToString()
                    });

                }
            }
            catch(Exception er) {
                CourseList.Add(new CourseProgramClass { ErrorMessage = er.Message.ToString() });
            }
            return CourseList;


        }

    }
}