using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for StudentClass
/// </summary>
/// 
using nsManageInstitute;
using nsManageCourseScheme;

namespace nsManageStudent
{
    public class clsStudentCourseRegistration : clsStudent
    {

        public int RollNo { get; set; }
        public string Batch { get; set; }
        public int StudentCourseRegID { get; set; }
        public string CurrentStatus { get; set; }
        public string RegistrationStatus{ get; set; }
        public int CourseID { get; set; }
       
        // This method returns list of courses registed by student.

        public List<clsCourseScheme> getStudentCourseRegistration()
        {
            List<clsCourseScheme> CourseList = new List<clsCourseScheme>();
            try
            {
                DataTable ds = new DataTable();

                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetStudentCourseRegistration", conn);
                    if (StudentCourseRegID > 0)
                        sqlComm.Parameters.AddWithValue("@StudentCourseRegID",StudentCourseRegID);
                    
                    if (!UID.Equals("ALL"))
                        sqlComm.Parameters.AddWithValue("@UID",UID);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    CourseList.Add(new clsCourseScheme
                    {
                        CourseID = int.Parse(dr["courseid"].ToString()),
                        ProgramName = dr["programname"].ToString(),
                        CourseCode = dr["CourseCode"].ToString(),
                        CourseTitle=dr["CourseTitle"].ToString(),
                        CourseType = dr["Coursetype"].ToString(),
                        
                        
                    });

                }

            }
            catch (Exception er)
            {

                CourseList.Add(new clsCourseScheme { ErrorMessage = er.Message.ToString() });
            }


            return CourseList;

        }

        public clsMessage updateStudentCourseRegistration(string action = "insert")
        {
            clsMessage rm = new clsMessage();
            try
            {

                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateStudentCourseRegistration", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentCourseRegID", StudentCourseRegID);
                    cmd.Parameters.AddWithValue("@UID", UID);
                    cmd.Parameters.AddWithValue("@CourseID",CourseID );



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

        public clsMessage updateStudentCourseRegistrationBulk(clsManageInstitute InstObject,List<string> CourseIDList,string action = "insert")
        {
            clsMessage rm = new clsMessage();
            try
            {
                DataTable CourseTable = new DataTable();
                CourseTable.Columns.Add("CourseID");
                foreach(string course in CourseIDList)
                {
                    CourseTable.Rows.Add(course);

                }

                
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {


                    SqlCommand cmd = new SqlCommand("Proc_UpdateStudentCourseRegistration", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentCourseRegID", StudentCourseRegID);
                    cmd.Parameters.AddWithValue("@UID", UID);
                    cmd.Parameters.AddWithValue("@ACYR", InstObject.AcademicYear);
                    cmd.Parameters.AddWithValue("@DepartmentID",InstObject.DepartmentID);
                    cmd.Parameters.AddWithValue("@SemesterID",InstObject.SemesterID);
                    cmd.Parameters.AddWithValue("@SectionID",InstObject.SectionID);
                    cmd.Parameters.AddWithValue("@RollNo",RollNo);
                    cmd.Parameters.AddWithValue("@ProfEMail", ProfEMailID);
                    cmd.Parameters.AddWithValue("@TyCourse",CourseTable);
                    cmd.Parameters.AddWithValue("@CurrentStatus",CurrentStatus);
                    cmd.Parameters.AddWithValue("@DepartmentID", RegistrationStatus);


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