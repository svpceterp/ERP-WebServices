﻿using System;
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