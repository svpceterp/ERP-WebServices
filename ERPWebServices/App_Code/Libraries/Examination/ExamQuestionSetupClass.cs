

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
   public class clsExamQuestion : clsExamCourseSchedule
    {
        public int ECQSID { get; set; }
      
        public int QuestNo { get; set; }
        public int QuestMarks { get; set; }
        public string QuestCO { get; set; }
        public string QuestBTL { get; set; }


        //public List<ExamQuestSetupClass> GetExamQuestionSetup()
        //{
        //    List<ExamQuestSetupClass> Instlist = new List<ExamQuestSetupClass>();


        //    DataTable ds = new DataTable();

        //    using (SqlConnection conn = ConnectionDB.OpenConnection())
        //    {
        //        SqlCommand sqlComm = new SqlCommand("Proc_GetInstitute", conn);
        //        sqlComm.Parameters.AddWithValue("@Instituteid", InstituteID);



        //        sqlComm.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = sqlComm;

        //        da.Fill(ds);
        //    }

        //    foreach (DataRow dr in ds.Rows)
        //    {
        //        Instlist.Add(new InstituteClass
        //        {
        //            InstituteID = int.Parse(dr["Institueid"].ToString()),
        //            InstituteCode = dr["Instituecode"].ToString(),
        //            InstituteName = dr["Instituename"].ToString(),
        //            InstituteStreet = dr["InstitueStreet"].ToString(),
        //            InstituteCity = dr["InstitueCity"].ToString(),
        //            InstituteDistrict = dr["InstitueDistrict"].ToString(),
        //            InstituteState = dr["InstitueState"].ToString(),
        //            InstituteCountry = dr["InstitueCountry"].ToString(),
        //            InstitutePinCode = dr["InstituePinCode"].ToString()

        //        });

        //    }

        //    return Instlist;
        //}

        public clsMessage updateExamQuestionSetup(string action = "insert")
        {
            clsMessage rm = new clsMessage();
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateExamCourseQuestSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ECQSID",ECQSID);
                    cmd.Parameters.AddWithValue("@ExamCourseScheduleID",ExamCourseScheduleID);
                    cmd.Parameters.AddWithValue("@QuestNo",QuestNo);
                    cmd.Parameters.AddWithValue("@QuestMarks",QuestMarks);
                    cmd.Parameters.AddWithValue("@QuestCO",QuestCO);
                    //  cmd.Parameters.AddWithValue("@QuestBTL",InstituteDistrict);
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
