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
namespace ERPNameSpace
{
    public class SemesterClass
    {
       private int Sem_ID;

        bool b = false;
        int x = 0; 

        public string SemID { get { return Sem_ID.ToString(); }
            set {
                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (x > 0)
                {
                    Sem_ID = x;

                }
            } }
        public string SemCode { get; set; }
        public string ErrorMessage { get; set; }

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
                    sqlComm.Parameters.AddWithValue("@sem_id", Sem_ID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    semList.Add(new SemesterClass
                    {
                        Sem_ID = int.Parse(dr["sem_id"].ToString()),
                        SemCode = dr["semcode"].ToString(),
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