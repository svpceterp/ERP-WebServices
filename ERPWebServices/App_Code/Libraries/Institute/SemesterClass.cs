using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsSemester
/// </summary>
/// 
namespace  nsManageInstitute
{
    public class clsSemester : clsProgram
    {

        public clsSemester()
        {
            SemesterID = 0;

        }

        public int SemesterID { get; set; }
        public string SemesterCode { get; set; }

        public List<clsSemester> getSemesters()
        {


            List<clsSemester> semList = new List<clsSemester>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetSemester", conn);

                    if (SemesterID > 0)
                        sqlComm.Parameters.AddWithValue("@semesterid", SemesterID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    semList.Add(new clsSemester
                    {
                        SemesterID = int.Parse(dr["semesterid"].ToString()),
                        SemesterCode = dr["semestercode"].ToString(),
                    });

                }
            }
            catch (Exception er)
            {
                semList.Add(new clsSemester { ErrorMessage = er.Message.ToString() });
            }
            return semList;


        }

    }
}
