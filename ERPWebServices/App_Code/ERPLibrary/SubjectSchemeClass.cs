using ERPConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERP;

/// <summary>
/// Summary description for SubjectSchemeClass
/// </summary>
/// 
namespace ERP
{

    public class SubjectSchemeClass:DepartmentClass
    {
        private int Subject_ID;
        private int CourseCat_ID;
        private int Dept_ID;
        private int Sem_ID;

        bool b = false;
        int x = 0;


        public string SubjectID{ get { return Subject_ID.ToString(); } set {

                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Subject_ID = x;
                }
                
            } }
        public string CourseCatID
        {
            get { return CourseCat_ID.ToString(); }
            set
            {

                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    CourseCat_ID = x;
                }

            }
        }
     
        public string SemID
        {
            get { return Sem_ID.ToString(); }
            set
            {

                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Sem_ID = x;
                }

            }
        }
        public string CourseCredit { get; set; }
        public string CourseCategory{ get; set; }
   
      
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
        public string ErrorMessage { get; set; }

        public List<SubjectSchemeClass> GetSubjectScheme()
        {
            List<SubjectSchemeClass> SubjectList = new List<SubjectSchemeClass>();

            ERPConnectionClass erpconn = new ERPConnectionClass();

            DataTable ds = new DataTable();

            try
            {

                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("[dbo].[Proc_GetSubjectScheme]", conn);
                    sqlComm.Parameters.AddWithValue("@Subject_ID", Subject_ID);
                    sqlComm.Parameters.AddWithValue("@CourseCat_ID", CourseCat_ID);
                    sqlComm.Parameters.AddWithValue("@Dept_ID", Dept_ID);
                    sqlComm.Parameters.AddWithValue("@Sem_ID", Sem_ID);


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

                    SubjectList.Add(new SubjectSchemeClass
                    {
                        SubjectID = dr["Subject_ID"].ToString(),
                        CourseCatID = dr["CourseCat_ID"].ToString(),
                        CourseCategory = dr["CourseCategory"].ToString(),
                        CourseCredit = dr["CourseCredit"].ToString(),
                        DeptID = dr["Dept_ID"].ToString(),
                        DeptCode = dr["DeptCode"].ToString(),
                        DeptName = dr["DeptName"].ToString(),
                        SemID = dr["Sem_ID"].ToString(),
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
                SubjectList.Add(new SubjectSchemeClass {ErrorMessage=er.Message.ToString() });
            }

            return SubjectList;


        }

        public MessageClass UpdateSubjectScheme(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            ERPConnectionClass erpconn = new ERPConnectionClass();

            try
            {
                using (SqlConnection con = erpconn.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateSubjectScheme", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Subject_ID", Subject_ID);
                    cmd.Parameters.AddWithValue("@Dept_ID", Dept_ID);
                    cmd.Parameters.AddWithValue("@Sem_ID", Sem_ID);
                    cmd.Parameters.AddWithValue("@CourseCat_ID", CourseCat_ID);

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
                ERPConnectionClass erpconn = new ERPConnectionClass();
                string sql = "select subjectTitle from subjectscheme where subject_id=" + subjectID;

                subjectName = erpconn.ExecuteSingleColumnSelectCommand(sql);
            }
            catch
            {
                subjectName = null;
            }
            return subjectName;
        }


    }
}