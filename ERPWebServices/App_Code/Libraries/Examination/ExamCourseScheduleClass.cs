using nsManageInstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for clsExamSchedule
/// </summary>
/// 
namespace nsManageExamination
{
    public class clsExamCourseSchedule : clsExamSchedule
    {


        public int ExamCourseScheduleID { get; set; }
        public DateTime ExamCourseStartDateTime { get; set; }
        public DateTime ExamCourseEndDateTime { get; set; }
        public decimal ExamCourseFees { get; set; }


        public List<clsExamSchedule> GetExamCourseSchedule()
        {
            List<clsExamSchedule> examList = new List<clsExamSchedule>();


            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamSchedule]", conn);

                    if (ExamID > 0)
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
                    examList.Add(new clsExamSchedule
                    {
                        ExamID = int.Parse(dr["ExamID"].ToString()),
                        ProgramID = int.Parse(dr["programID"].ToString()),
                        ProgramName = dr["programName"].ToString(),
                        DepartmentID = int.Parse(dr["DepartmentID"].ToString()),
                        DepartmentName = dr["DepartmentName"].ToString(),
                        SemesterID = int.Parse(dr["SemesterID"].ToString()),
                        SemesterCode = dr["SemesterCode"].ToString(),
                        ExamSession = dr["ExamSession"].ToString(),
                        ExamYear = dr["ExamYear"].ToString(),
                        ExamType = dr["ExamType"].ToString(),
                        ExamName = dr["ExamName"].ToString(),
                        ExamStartDate = Convert.ToDateTime(dr["ExamStartDate"].ToString()),
                        ExamEndDate = Convert.ToDateTime(dr["ExamEndDate"].ToString())

                    });

                }

            }

            catch (Exception er)
            {
                examList.Add(new clsExamSchedule { ErrorMessage = er.Message.ToString() });
            }
            return examList;


        }


        public clsMessage UpdateExamCourseSchedule(string action = "insert")
        {
            clsMessage rm = new clsMessage();


            try
            {
                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamSchedule", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamID", ExamID);
                    cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    cmd.Parameters.AddWithValue("@ProgramID", ProgramID);
                    cmd.Parameters.AddWithValue("@SemesterID", SemesterID);
                    cmd.Parameters.AddWithValue("@ExamSession", ExamSession);
                    cmd.Parameters.AddWithValue("@ExamYear", ExamYear);
                    cmd.Parameters.AddWithValue("@ExamType", ExamType);
                    cmd.Parameters.AddWithValue("@ExamName", ExamName);
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
                rm.ErrorMessage = er.Message.ToString();
                rm.StatusMessage = "failed";
            }

            return rm;

        }


    }
}
