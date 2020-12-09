
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
namespace ERPNameSpace
{

    public class ExamSubjectsClass
    {
        string _ExamSubjectID,_ExamID,_SubjectID;
        string _ExamStartDateTime, _ExamEndDateTime;
        private bool b = false;
        private int x = 0;
        private DateTime DT = DateTime.MinValue;
        public string ExamSubjectID
        {
            get
            {
                return _ExamSubjectID;
            }
            set
            {

                b = int.TryParse(value, out x);
                if (x > 0)
                    _ExamSubjectID= x.ToString();
                else if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }

        public string ExamID {
            get {
                return _ExamID;
            }
            set {

                b = int.TryParse(value, out x);
                if (x > 0)
                    _ExamID = x.ToString();
                else if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }
        public string SubjectID
        {
            get
            {
                return _SubjectID;
            }
            set
            {

                b = int.TryParse(value, out x);
                if (x > 0)
                    _SubjectID = x.ToString();
                else if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

            }
        }

        public string ExamStartDateTime
        {
            get
            {
                return _ExamStartDateTime;
            }
            set
            {

                b = DateTime.TryParse(value, out DT);
                if (x > 0)
                    _ExamStartDateTime = DT.ToString();
                else if (x < 0)
                {
                    throw new FormatException();
                }

            }
        }
        public string ExamEndDateTime
        {
            get
            {
                return _ExamEndDateTime;
            }
            set
            {

                b = DateTime.TryParse(value, out DT);
                if (x > 0)
                    _ExamEndDateTime = DT.ToString();
                else if (x < 0)
                {
                    throw new FormatException();
                }

            }
        }
        public string ExamName { get; set; }
        public string ExamSubjectDateTime { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectTitle { get; set; }
        public string ExamSubjectFees{ get; set; }
        public string ExamSubjectDuration { get; set; }
        public string SubjectCompulsory { get; set; }
        public string ErrorMessage { get; set; }

        public List<ExamSubjectsClass> GetExamSubject(string uid=null,string option="1")
        {
            List<ExamSubjectsClass>exsubList = new List<ExamSubjectsClass>();

            

            DataTable ds = new DataTable();

            try { 

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamSubject]", conn);
                sqlComm.Parameters.AddWithValue("@Exam_ID", ExamID);

                if (uid!=null)
                sqlComm.Parameters.AddWithValue("@uid", uid);

                if(option!=null)
                sqlComm.Parameters.AddWithValue("@option",option);
                
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                exsubList.Add(new ExamSubjectsClass
                {
                    ExamID = dr["Exam_ID"].ToString(),
                    ExamSubjectID = dr["ExamSubject_ID"].ToString(),
                    ExamName = dr["ExamName"].ToString(),
                    ExamSubjectDateTime = dr["ExamDate"].ToString(),
                    SubjectID = dr["Subject_ID"].ToString(),
                    SubjectCode = dr["SubjectCode"].ToString(),
                    SubjectTitle = dr["SubjectTitle"].ToString(),
                    ExamStartDateTime= dr["ExamStartDatetime"].ToString(),
                    ExamEndDateTime = dr["ExamEndDateTime"].ToString(),
                    ExamSubjectFees = dr["ExamSubjectFees"].ToString(),
                     SubjectCompulsory= dr["SubjectCompulsory"].ToString(),
                    ExamSubjectDuration= dr["TimeInHour"].ToString()
                });

            }

 }
            catch (Exception er)
            {
             exsubList.Add(new ExamSubjectsClass {ErrorMessage=er.Message.ToString()});
            }
            return exsubList;


        }


        public MessageClass UpdateExamSubject(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            

            try
            {
                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamSubject_ID", ExamSubjectID);
                    cmd.Parameters.AddWithValue("@Exam_ID", ExamID);
                    cmd.Parameters.AddWithValue("@Subject_ID", SubjectID);
                    cmd.Parameters.AddWithValue("@ExamStartDateTime", ExamStartDateTime);
                    cmd.Parameters.AddWithValue("@ExamEndDateTime", ExamEndDateTime);
                    cmd.Parameters.AddWithValue("@ExamSubjectFees", ExamSubjectFees);


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
            }

            return rm;

        }




    }
}