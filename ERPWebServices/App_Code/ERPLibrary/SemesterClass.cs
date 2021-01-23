using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPConnection;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERP
{
    public class SemesterClass:ProgramClass
    {
     
        public SemesterClass()
        {
            SemesterID = 0;
           
        }

        public int SemesterID { get; set; }
        public string SemesterCode { get; set; }
      
        public List<SemesterClass> GetSemester()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<SemesterClass> semList = new List<SemesterClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetSemester", conn);

                    if(SemesterID>0)
                    sqlComm.Parameters.AddWithValue("@semesterid", SemesterID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    semList.Add(new SemesterClass
                    {
                        SemesterID = int.Parse(dr["semesterid"].ToString()),
                        SemesterCode = dr["semestercode"].ToString(),
                    });

                }
            }
            catch (Exception er)
            {
                semList.Add(new SemesterClass { ErrorMessage = er.Message.ToString() });
            }
                return semList;


        }

    }
}