using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsDepartment
/// </summary>
namespace  nsManageInstitute
{
    public class clsDepartment : clsInstitute
    {
        public int DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

       

        public List<clsDepartment> getDepartments()
        {
            List<clsDepartment> deptlist = new List<clsDepartment>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetDepartment", conn);


                sqlComm.Parameters.AddWithValue("@DepartmentID", DepartmentID);



                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                deptlist.Add(new clsDepartment
                {
                    DepartmentID = int.Parse(dr["departmentid"].ToString()),
                    DepartmentCode = dr["departmentcode"].ToString(),
                    DepartmentName = dr["departmentname"].ToString(),
                    InstituteID = int.Parse(dr["instituteid"].ToString())
                });

            }

            return deptlist;
        }

        public clsMessage updateDepartment(string action = "insert")
        {
            clsMessage rm = new clsMessage();

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