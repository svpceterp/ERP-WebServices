using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPConnection;
/// <summary>
/// Summary description for DepartmentClass
/// </summary>

namespace ERPNameSpace
{
    public class DepartmentClass:CourseProgramClass
    {
        private string _DeptID;
       
       private bool b = new bool();
        private int x = 0;
        public string DeptID { get { return _DeptID; }
            set {
               
                 b = int.TryParse(value, out x);
                if (x > 0)
                {
                    _DeptID = x.ToString();
                }
                else if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {   }

            } }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
       
        public DateTime DeptStartDate { get; set; }
        public DateTime DeptEndDate { get; set; }
       

        ERPConnectionClass erpconn = new ERPConnectionClass();

        public List<DepartmentClass> GetDepartment()
        {
            List<DepartmentClass> deptlist = new List<DepartmentClass>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = erpconn.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetDepartment", conn);
                sqlComm.Parameters.AddWithValue("@dept_id", DeptID);
                sqlComm.Parameters.AddWithValue("@course_id", CourseID);


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                deptlist.Add(new DepartmentClass
                {
                    DeptID = dr["dept_id"].ToString(),
                    DeptCode = dr["deptcode"].ToString(),
                    DeptName = dr["deptname"].ToString(),
                    CourseID = dr["course_id"].ToString()
                });

            }

            return deptlist;
        }

        public MessageClass UpdateDepartment(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            ERPConnectionClass erpconn = new ERPConnectionClass();
            try
            {

                using (SqlConnection con = erpconn.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dept_ID", DeptID);
                    cmd.Parameters.AddWithValue("@DeptCode", DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName",DeptName);
                    cmd.Parameters.AddWithValue("@Course_ID", CourseID);
                    cmd.Parameters.AddWithValue("@DeptStartDate", DeptStartDate);
                    cmd.Parameters.AddWithValue("@DeptEndDate", DeptEndDate);


                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.Message = (string)cmd.Parameters["@rvalue"].Value;
                    rm.Status = "success";
                }
            }
            catch (Exception er)
            {
                rm.Message = er.Message.ToString();
                rm.Status = "failed";
            }

            return rm;

        }


    }
}