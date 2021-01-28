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

    public class ExamScheduleClass
    {
        private bool b = false;
        private int x = 0;
        private int Exam_ID;
        private int Exam_Year;
        private int Course_ID;
        private int Dept_ID;
        private int Sem_ID;

        public string ExamID {
            get
            {
               return Exam_ID.ToString();
            }
            set {

                b = int.TryParse(value, out x);
                if (x > 0)
                    Exam_ID = x;
                else if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }
        public string ExamSession { get; set; }
        public string ExamYear{ get { return Exam_Year.ToString(); } set { Exam_Year =int.Parse(value); } }
        public string ExamCourseID { get { return Course_ID.ToString(); } set { Course_ID = int.Parse(value); } }
        public string ExamDeptID { get { return Dept_ID.ToString(); } set { Dept_ID = int.Parse(value); } }
        public string ExamSemID { get { return Sem_ID.ToString(); } set { Sem_ID = int.Parse(value); } }
        public string ExamName{ get; set; }
        public string ExamType{ get; set; }
        public DateTime ExamStartDate{ get; set; }
        public DateTime ExamEndDate{ get; set; }
        public string DeptCode{ get; set; }
        public string DeptName{ get; set; }
        public string SemCode{ get; set; }
        public string CourseCode{ get; set; }
        public string CourseName{ get; set; }
        public string CourseDescription{ get; set; }
        public string CourseDuration{ get; set; }
        public string CourseStatus{ get; set; }
        public string ErrorMessage { get; set; }

        public List<ExamScheduleClass> GetExamSchedule()
        {
            List<ExamScheduleClass>examList = new List<ExamScheduleClass>();

            ERPConnectionClass erpconn = new ERPConnectionClass();

            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamSchedule]", conn);
                    sqlComm.Parameters.AddWithValue("@Exam_ID", Exam_ID);
                    sqlComm.Parameters.AddWithValue("@Dept_ID", Dept_ID);
                    sqlComm.Parameters.AddWithValue("@Sem_ID", Sem_ID);

                    sqlComm.Parameters.AddWithValue("@ExamSession", null);
                    sqlComm.Parameters.AddWithValue("@ExamYear", null);
                    sqlComm.Parameters.AddWithValue("@Course_ID", null);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    examList.Add(new ExamScheduleClass
                    {
                        ExamID = dr["Exam_ID"].ToString(),
                        ExamCourseID = dr["Course_ID"].ToString(),
                        CourseCode = dr["CourseCode"].ToString(),
                        CourseName = dr["CourseName"].ToString(),
                        CourseDescription = dr["CourseDescription"].ToString(),
                        CourseDuration = dr["CourseDuration"].ToString(),
                        CourseStatus = dr["CourseStatus"].ToString(),
                        ExamDeptID = dr["Dept_ID"].ToString(),
                        DeptCode = dr["DeptCode"].ToString(),
                        ExamSemID = dr["Sem_ID"].ToString(),
                        SemCode = dr["SemCode"].ToString(),
                        ExamSession = dr["ExamSession"].ToString(),
                        ExamName = dr["ExamName"].ToString(),
                        ExamYear = dr["ExamYear"].ToString(),
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
                cmd.Parameters.AddWithValue("@Exam_ID", Exam_ID);
                cmd.Parameters.AddWithValue("@ExamSession", ExamDeptID);
                cmd.Parameters.AddWithValue("@ExamYear", Exam_Year);
                cmd.Parameters.AddWithValue("@Course_ID", Course_ID);

                cmd.Parameters.AddWithValue("@Dept_ID", Dept_ID);
                cmd.Parameters.AddWithValue("@Sem_ID", Sem_ID);
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

        public static string GetExamNameByID(string examID)
        {

            string examName = "";
            try
            {
                ERPConnectionClass erpconn = new ERPConnectionClass();
                string sql = "select examname from examschedule where exam_id=" + examID;

                examName = erpconn.ExecuteSingleColumnSelectCommand(sql);
            }
            catch {
                examName = "No Exam Found";
            }
            return examName;
        }


    }
