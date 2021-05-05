
using nsManageCourseScheme;
using nsManageInstitute;
using nsManageStudent;
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
    public class clsExamForm: clsStudentCourseRegistration
    {
        public int ExamFormID { get; set; }
        public int ExamID { get; set; }
        public DateTime ExamFormSubmitDate { get; set; }
        public string ExamFormStatus { get; set; }
       
        //public List<ExamFormClass> GetExamForm(string ExamFormID = null, string ExamID = null, string uid = null)
        //{
        //    List<ExamFormClass> exfrmList = new List<ExamFormClass>();



        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        using (SqlConnection conn = ConnectionDB.OpenConnection())
        //        {
        //            SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetExamForm]", conn);
        //            sqlComm.Parameters.AddWithValue("@ExamFormID", ExamFormID);
        //            if (ExamID != null)
        //                sqlComm.Parameters.AddWithValue("@ExamID", ExamID);
        //            if (uid != null)
        //                sqlComm.Parameters.AddWithValue("@uid", uid);


        //            sqlComm.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = sqlComm;

        //            da.Fill(ds);
        //        }

        //        foreach (DataRow dr in ds.Rows)
        //        {
        //            exfrmList.Add(new ExamFormClass
        //            {

        //                ExamFormID = dr["ExamSubject_ID"].ToString(),
        //                ExamID = dr["Exam_ID"].ToString(),
        //                ExamName = dr["ExamName"].ToString(),
        //                StudentStatus = dr["StudentStatus"].ToString(),
        //                SubjectID1 = dr["Subject_ID1"].ToString(),
        //                SubjectID2 = dr["Subject_ID2"].ToString(),
        //                SubjectID3 = dr["Subject_ID3"].ToString(),
        //                SubjectID4 = dr["Subject_ID4"].ToString(),
        //                SubjectID5 = dr["Subject_ID5"].ToString(),
        //                SubjectID6 = dr["Subject_ID6"].ToString(),
        //                SubjectID7 = dr["Subject_ID7"].ToString(),
        //                SubjectID8 = dr["Subject_ID8"].ToString(),
        //                SubjectID9 = dr["Subject_ID9"].ToString(),
        //                SubjectID10 = dr["Subject_ID10"].ToString(),
        //                SubjectCode1 = dr["Subject_Code1"].ToString(),
        //                SubjectCode2 = dr["Subject_Code2"].ToString(),
        //                SubjectCode3 = dr["Subject_Code3"].ToString(),
        //                SubjectCode4 = dr["Subject_Code4"].ToString(),
        //                SubjectCode5 = dr["Subject_Code5"].ToString(),
        //                SubjectCode6 = dr["Subject_Code6"].ToString(),
        //                SubjectCode7 = dr["Subject_Code7"].ToString(),
        //                SubjectCode8 = dr["Subject_Code8"].ToString(),
        //                SubjectCode9 = dr["Subject_Code9"].ToString(),
        //                SubjectCode10 = dr["Subject_Code10"].ToString(),
        //                SubjectTitle1 = dr["Subject_Title1"].ToString(),
        //                SubjectTitle2 = dr["Subject_Title2"].ToString(),
        //                SubjectTitle3 = dr["Subject_Title3"].ToString(),
        //                SubjectTitle4 = dr["Subject_Title4"].ToString(),
        //                SubjectTitle5 = dr["Subject_Title5"].ToString(),
        //                SubjectTitle6 = dr["Subject_Title6"].ToString(),
        //                SubjectTitle7 = dr["Subject_Title7"].ToString(),
        //                SubjectTitle8 = dr["Subject_Title8"].ToString(),
        //                SubjectTitle9 = dr["Subject_Title9"].ToString(),
        //                SubjectTitle10 = dr["Subject_Title10"].ToString(),
        //                ErrorMessage = ""
        //            });

        //        }
        //    }
        //    catch (Exception er)
        //    {
        //        exfrmList.Add(new ExamFormClass { ErrorMessage = er.Message.ToString() });
        //    }
        //    return exfrmList;


        //}


        public clsMessage updateExamForm(List<clsCourseScheme> pCourseList,string action = "insert")
        {
            clsMessage rm = new clsMessage();

            DataTable dt = new DataTable();
            dt.Columns.Add("CourseID");
            foreach (var v in pCourseList)
            {

                dt.Rows.Add(v.CourseID);
            }
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamFormBulk", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ExamFormID", ExamFormID);
                    cmd.Parameters.AddWithValue("@ExamID", ExamID);
                    cmd.Parameters.AddWithValue("@UID", UID);
                    cmd.Parameters.AddWithValue("@ExamFormStatus","Submit");
                    cmd.Parameters.AddWithValue("@TyCourse",dt);
                    cmd.Parameters.AddWithValue("@action",action);
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

        public DataTable getStudentHallTicketsByExamIDUID(string pExamID, string pUID)
        {
            List<clsStudent> vStudentList = new List<clsStudent>();

            DataSet vds = new DataSet();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetStudentsHallTicket]", conn);

                //sqlComm.Parameters.AddWithValue("@ExamID", ExamFormID);
                sqlComm.Parameters.AddWithValue("@ExamID", pExamID);
                sqlComm.Parameters.AddWithValue("@uid", pUID);


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(vds);
            }
            return vds.Tables[0];
        }


    }
}
