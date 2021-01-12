﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for SubjectSchemeClass
/// </summary>
/// 
namespace ERPNameSpace
{

    public class CourseSchemeClass:CourseCategoryClass
    {
       
        public int CourseID { get; set; }
        public int SemID{get;set;}
        public string SemCode{ get; set; }
        public string SubjectCode{ get; set; }
        public string SubjectTitle{ get; set; }
        public int SubjectLHrPerWeek{ get; set; }
        public int SubjectTHrPerWeek{ get; set; }
        public int SubjectPHrPerWeek{ get; set; }
        public int SubjectCredit{ get; set; }
        public int SubjectCAMaxMarks{ get; set; }
        public int SubjectESEMaxMarks{ get; set; }
        public int SubjectTotalMaxMarks{ get; set; }
        public decimal SubjectESEDuration{ get; set; }
        public string SubjectCompulsory { get; set; }
     

        public List<CourseSchemeClass> GetSubjectScheme()
        {
            List<CourseSchemeClass> SubjectList = new List<CourseSchemeClass>();

           

            DataTable ds = new DataTable();

            try
            {

                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetSubjectScheme]", conn);
                    sqlComm.Parameters.AddWithValue("@Subject_ID", CourseID);
                    sqlComm.Parameters.AddWithValue("@CourseCat_ID", CourseCatID);
                    sqlComm.Parameters.AddWithValue("@Dept_ID", DeptID);
                    sqlComm.Parameters.AddWithValue("@Sem_ID", SemID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }
                int l = 0, t = 0, p = 0, c = 0, ca = 0, ese = 0, tmm = 0, tm = 0, dur = 0;
                bool b = false;
                foreach (DataRow dr in ds.Rows)
                {
                    b = int.TryParse(dr["SubjectLHrPerWeek"].ToString(), out l);
                    b = int.TryParse(dr["SubjectTHrPerWeek"].ToString(), out l);
                    b = int.TryParse(dr["SubjectPHrPerWeek"].ToString(), out l);
                    b = int.TryParse(dr["SubjectCredit"].ToString(), out c);
                    b = int.TryParse(dr["SubjectCAMaxMarks"].ToString(), out ca);
                    b = int.TryParse(dr["SubjectESEMaxMarks"].ToString(), out ese);
                    b = int.TryParse(dr["SubjectTotalMaxMarks"].ToString(), out tmm);
                    b = int.TryParse(dr["SubjectESEDuration"].ToString(), out dur);

                    SubjectList.Add(new CourseSchemeClass
                    {
                        CourseID = int.Parse(dr["Subject_ID"].ToString()),
                        CourseCatID = dr["CourseCat_ID"].ToString(),
                        CourseCategory = dr["CourseCategory"].ToString(),
                        CourseCredit = dr["CourseCredit"].ToString(),
                        DeptID = dr["Dept_ID"].ToString(),
                        DeptCode = dr["DeptCode"].ToString(),
                        DeptName = dr["DeptName"].ToString(),
                        SemID =int.Parse(dr["SemID"].ToString()),
                        SemCode = dr["SemCode"].ToString(),
                        SubjectCode = dr["SubjectCode"].ToString(),
                        SubjectTitle = dr["SubjectTitle"].ToString(),
                        SubjectLHrPerWeek = l,
                        SubjectTHrPerWeek = t,
                        SubjectPHrPerWeek = p,
                        SubjectCredit = c,
                        SubjectCAMaxMarks = ca,
                        SubjectESEMaxMarks = ese,
                        SubjectTotalMaxMarks = tmm,
                        SubjectESEDuration = dur,
                        SubjectCompulsory = dr["SubjectCompulsory"].ToString(),

                    });

                }
            }
            catch(Exception er) {
                SubjectList.Add(new CourseSchemeClass {ErrorMessage=er.Message.ToString() });
            }

            return SubjectList;


        }

        public MessageClass UpdateSubjectScheme(string action = "insert")
        {
            MessageClass rm = new MessageClass();
          

            try
            {
                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateSubjectScheme", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject_ID", CourseID);
                    cmd.Parameters.AddWithValue("@Dept_ID", DeptID);
                    cmd.Parameters.AddWithValue("@Sem_ID", SemID);
                    cmd.Parameters.AddWithValue("@CourseCat_ID", CourseCatID);

                    cmd.Parameters.AddWithValue("@Subjectcode", SubjectCode);
                    cmd.Parameters.AddWithValue("@subjecttitle", SubjectTitle);
                    cmd.Parameters.AddWithValue("@subjectLHrPerWeek", SubjectLHrPerWeek);
                    cmd.Parameters.AddWithValue("@subjectTHrPerWeek", SubjectTHrPerWeek);
                    cmd.Parameters.AddWithValue("@subjectPHrPerWeek", SubjectPHrPerWeek);

                    cmd.Parameters.AddWithValue("@subjectcredit", SubjectCredit);
                    cmd.Parameters.AddWithValue("@subjectcamaxmarks", SubjectCAMaxMarks);
                    cmd.Parameters.AddWithValue("@subjectesemaxmarks", SubjectESEMaxMarks);
                    cmd.Parameters.AddWithValue("@subjecteseduration", SubjectESEDuration);
                    cmd.Parameters.AddWithValue("@subjectCompulsory", SubjectCompulsory);

                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.Message = (string)cmd.Parameters["@rvalue"].Value;
                    rm.Status = "success";
                }
            }
            catch(Exception er) {
                rm.Message = er.Message.ToString();
                rm.Status = "failed";
            }

            return rm;

        }
        
        public string GetSubjectTitleByID(string subjectID)
        {

            string subjectName = "";
            try
            {
             
                string sql = "select subjectTitle from subjectscheme where subject_id=" + subjectID;
                subjectName = ConnectionDB.RunSQL(sql);

            }
            catch
            {
                subjectName = null;
            }
            return subjectName;
        }


    }
}