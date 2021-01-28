using ERPConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExamScheduleClass
/// </summary>
/// 

    public class ExamScheduleClass:CourseSchemeClass
    {
       

        public int ExamID { get; set; }
      public string ExamYear { get; set; }
        public string ExamSession { get; set; }
      public string ExamType { get; set; }
      public string ExamName{ get; set; }
      
        public DateTime ExamStartDate{ get; set; }
        public DateTime ExamEndDate{ get; set; }
     
        public List<ExamScheduleClass> GetExamSchedule()
        {
            List<ExamScheduleClass>examList = new List<ExamScheduleClass>();

         
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamSchedule]", conn);
                
                    sqlComm.Parameters.AddWithValue("@ExamID", ExamID);

                //sqlComm.Parameters.AddWithValue("@ExamSession",ExamSession);
                //    sqlComm.Parameters.AddWithValue("@CourseID",CourseID);
                //    sqlComm.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                //    sqlComm.Parameters.AddWithValue("@SemesterID", SemesterID);
                 

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    examList.Add(new ExamScheduleClass
                    {
                        ExamID = int.Parse(dr["ExamID"].ToString()),
                        CourseCode = dr["CourseCode"].ToString(),
                       
                        ExamSession = dr["ExamSession"].ToString(),
                        ExamName = dr["ExamName"].ToString(),
                      
                        ExamStartDate = Convert.ToDateTime(dr["ExamStartDate"].ToString()),
                        ExamEndDate = Convert.ToDateTime(dr["ExamEndDate"].ToString())
                       
                    });

                }

            }
             
            catch (Exception er)
            {
                examList.Add(new ExamScheduleClass {ErrorMessage=er.Message.ToString()});
            }
            return examList;


        }


        public MessageClass UpdateExamSchedule(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            ERPConnectionClass erpconn = new ERPConnectionClass();

            try { 
            using (SqlConnection con = erpconn.OpenConnection())
            {
               
                SqlCommand cmd = new SqlCommand("Proc_UpdateExamSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ExamID", ExamID);
                cmd.Parameters.AddWithValue("@ExamSession", ExamSession);
                cmd.Parameters.AddWithValue("@ExamYear", ExamYear);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);

                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                cmd.Parameters.AddWithValue("@ExamName", ExamName);
                cmd.Parameters.AddWithValue("@ExamType", ExamType);
                  cmd.Parameters.AddWithValue("@examstartdate", ExamStartDate);
                cmd.Parameters.AddWithValue("@examenddate", ExamEndDate);

                cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                rm.SuccessMessage = (string)cmd.Parameters["@rvalue"].Value;
                rm.StatusMessage = "success";
            }
                 }
            catch (Exception er)
            {
                rm.ErrorMessage=er.Message.ToString();
                rm.StatusMessage = "failed";
            }

            return rm;

        }

     

    }
