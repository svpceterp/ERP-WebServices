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
namespace ERP
{

    public class ExamFormClass
    {
        string _ExamFormID,_ExamID,_Uid;
        private bool b = false;
        private int x = 0;
        private DateTime DT = DateTime.MinValue;
        public string ExamFormID
        {
            get
            {
                return _ExamFormID;
            }
            set
            {

                b = int.TryParse(value, out x);
                if (x > 0)
                    _ExamFormID= x.ToString();
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
        public string uid {
            get {
                return _Uid;
            }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    _Uid = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            } }
        public string ExamName { get; set; }
        public string StudentStatus { get; set; }
        public string SubjectID1 { get; set; }
        public string SubjectID2 { get; set; }
        public string SubjectID3 { get; set; }
        public string SubjectID4 { get; set; }
        public string SubjectID5 { get; set; }
        public string SubjectID6 { get; set; }
        public string SubjectID7 { get; set; }
        public string SubjectID8 { get; set; }
        public string SubjectID9 { get; set; }
        public string SubjectID10 { get; set; }
        public string SubjectCode1 { get; set; }
        public string SubjectCode2 { get; set; }
        public string SubjectCode3 { get; set; }
        public string SubjectCode4 { get; set; }
        public string SubjectCode5 { get; set; }
        public string SubjectCode6 { get; set; }
        public string SubjectCode7 { get; set; }
        public string SubjectCode8 { get; set; }
        public string SubjectCode9 { get; set; }
        public string SubjectCode10 { get; set; }
        public string SubjectTitle1 { get; set; }
        public string SubjectTitle2 { get; set; }
        public string SubjectTitle3 { get; set; }
        public string SubjectTitle4 { get; set; }
        public string SubjectTitle5 { get; set; }
        public string SubjectTitle6 { get; set; }
        public string SubjectTitle7 { get; set; }
        public string SubjectTitle8 { get; set; }
        public string SubjectTitle9 { get; set; }
        public string SubjectTitle10 { get; set; }
        public string ErrorMessage { get; set; }

        public List<ExamFormClass> GetExamForm(string ExamFormID = null, string ExamID = null,string uid=null)
        {
            List<ExamFormClass>exfrmList = new List<ExamFormClass>();

            ERPConnectionClass erpconn = new ERPConnectionClass();

            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamForm]", conn);
                    sqlComm.Parameters.AddWithValue("@ExamFormID", ExamFormID);
                    if (ExamID != null)
                        sqlComm.Parameters.AddWithValue("@ExamID", ExamID);
                    if (uid != null)
                        sqlComm.Parameters.AddWithValue("@uid", uid);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    exfrmList.Add(new ExamFormClass
                    {

                        ExamFormID = dr["ExamSubject_ID"].ToString(),
                        ExamID = dr["Exam_ID"].ToString(),
                        ExamName = dr["ExamName"].ToString(),
                        StudentStatus = dr["StudentStatus"].ToString(),
                        SubjectID1 = dr["Subject_ID1"].ToString(),
                        SubjectID2 = dr["Subject_ID2"].ToString(),
                        SubjectID3 = dr["Subject_ID3"].ToString(),
                        SubjectID4 = dr["Subject_ID4"].ToString(),
                        SubjectID5 = dr["Subject_ID5"].ToString(),
                        SubjectID6 = dr["Subject_ID6"].ToString(),
                        SubjectID7 = dr["Subject_ID7"].ToString(),
                        SubjectID8 = dr["Subject_ID8"].ToString(),
                        SubjectID9 = dr["Subject_ID9"].ToString(),
                        SubjectID10 = dr["Subject_ID10"].ToString(),
                        SubjectCode1 = dr["Subject_Code1"].ToString(),
                        SubjectCode2 = dr["Subject_Code2"].ToString(),
                        SubjectCode3 = dr["Subject_Code3"].ToString(),
                        SubjectCode4 = dr["Subject_Code4"].ToString(),
                        SubjectCode5 = dr["Subject_Code5"].ToString(),
                        SubjectCode6 = dr["Subject_Code6"].ToString(),
                        SubjectCode7 = dr["Subject_Code7"].ToString(),
                        SubjectCode8 = dr["Subject_Code8"].ToString(),
                        SubjectCode9 = dr["Subject_Code9"].ToString(),
                        SubjectCode10 = dr["Subject_Code10"].ToString(),
                        SubjectTitle1 = dr["Subject_Title1"].ToString(),
                        SubjectTitle2 = dr["Subject_Title2"].ToString(),
                        SubjectTitle3 = dr["Subject_Title3"].ToString(),
                        SubjectTitle4 = dr["Subject_Title4"].ToString(),
                        SubjectTitle5 = dr["Subject_Title5"].ToString(),
                        SubjectTitle6 = dr["Subject_Title6"].ToString(),
                        SubjectTitle7 = dr["Subject_Title7"].ToString(),
                        SubjectTitle8 = dr["Subject_Title8"].ToString(),
                        SubjectTitle9 = dr["Subject_Title9"].ToString(),
                        SubjectTitle10 = dr["Subject_Title10"].ToString(),
                        ErrorMessage = ""
                    });

                }
            }
            catch (Exception er)
            {
                exfrmList.Add(new ExamFormClass {ErrorMessage=er.Message.ToString() });
            }
            return exfrmList;


        }


        public MessageClass UpdateExamForm(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            ERPConnectionClass erpconn = new ERPConnectionClass();

            try
            {

                using (SqlConnection con = erpconn.OpenConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamForm_ID", ExamFormID);
                    cmd.Parameters.AddWithValue("@Exam_ID", ExamID);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@StudentStatus", StudentStatus);
                    cmd.Parameters.AddWithValue("@Subject_ID1", SubjectID1);
                    cmd.Parameters.AddWithValue("@Subject_ID2", SubjectID2);
                    cmd.Parameters.AddWithValue("@Subject_ID3", SubjectID3);
                    cmd.Parameters.AddWithValue("@Subject_ID4", SubjectID4);
                    cmd.Parameters.AddWithValue("@Subject_ID5", SubjectID5);
                    cmd.Parameters.AddWithValue("@Subject_ID6", SubjectID6);
                    cmd.Parameters.AddWithValue("@Subject_ID7", SubjectID7);
                    cmd.Parameters.AddWithValue("@Subject_ID8", SubjectID8);
                    cmd.Parameters.AddWithValue("@Subject_ID9", SubjectID9);
                    cmd.Parameters.AddWithValue("@Subject_ID10", SubjectID10);


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
}