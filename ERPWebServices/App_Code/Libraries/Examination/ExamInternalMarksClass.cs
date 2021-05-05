
using nsManageInstitute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsManageExamination
{
    public class clsExamInternalMarks:clsExamCourseSchedule
    {
        public int IMID { get; set; }
        public string UID { get; set; }
        public int MIDSem1Marks { get; set; }
        public int MIDSem2Marks { get; set; }
        public int CAMarks { get; set; }
        public int Total { get; set; }

        public clsMessage UpdateExamInternalMarks(List<clsExamInternalMarks> pIM, string action = "insert")
        {
            clsMessage rm = new clsMessage();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id"); dt.Columns.Add("uid"); dt.Columns.Add("im1"); dt.Columns.Add("m2"); dt.Columns.Add("m3");
                int pExamCourseScheduleID = 0;
                foreach (var x in pIM)
                {
                    pExamCourseScheduleID = x.ExamCourseScheduleID;
                    dt.Rows.Add(x.IMID, x.UID, x.MIDSem1Marks, x.MIDSem2Marks, x.CAMarks);

                }

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamInternalMarks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@ExamCourseScheduleID", pExamCourseScheduleID);
                    cmd.Parameters.AddWithValue("@tyIM", dt);
                    cmd.Parameters.AddWithValue("@action", action);
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
