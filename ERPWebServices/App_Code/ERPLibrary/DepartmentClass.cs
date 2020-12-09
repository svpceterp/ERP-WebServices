using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentClass
/// </summary>

namespace ERPNameSpace
{
    public class DepartmentClass:InstituteClass
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
       

        

        public List<DepartmentClass> GetDepartment()
        {
            List<DepartmentClass> deptlist = new List<DepartmentClass>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetDepartment", conn);
                sqlComm.Parameters.AddWithValue("@deptid", DeptID);
              


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                deptlist.Add(new DepartmentClass
                {
                    DeptID = dr["deptid"].ToString(),
                    DeptCode = dr["deptcode"].ToString(),
                    DeptName = dr["deptname"].ToString()
                   
                });

            }

            return deptlist;
        }

        public MessageClass UpdateDepartment(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateDepartment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DeptID", DeptID);
                    cmd.Parameters.AddWithValue("@DeptCode", DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName",DeptName);
                 
                 


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