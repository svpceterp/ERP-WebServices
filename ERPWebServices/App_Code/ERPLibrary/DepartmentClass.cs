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

namespace ERP
{
    public class DepartmentClass:InstituteClass
    {
        public int DepartmentID { get; set;}
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
       
      

        public List<DepartmentClass> GetDepartment()
        {
            List<DepartmentClass> deptlist = new List<DepartmentClass>();


            DataTable ds = new DataTable();

            using (SqlConnection conn =ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetDepartment", conn);

                
                sqlComm.Parameters.AddWithValue("@DepartmentID",DepartmentID);
              


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                deptlist.Add(new DepartmentClass
                {
                    DepartmentID = int.Parse(dr["departmentid"].ToString()),
                    DepartmentCode = dr["departmentcode"].ToString(),
                    DepartmentName = dr["departmentname"].ToString(),
                    InstituteID = int.Parse(dr["instituteid"].ToString())
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
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.Parameters.AddWithValue("@DepartmentCode", DepartmentCode);
                    cmd.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    cmd.Parameters.AddWithValue("@InstituteID", InstituteID);
                   

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
}