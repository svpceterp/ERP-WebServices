using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 

    public class ProgramClass:DepartmentClass
    {
       public ProgramClass()
        {
            ProgramID = 0;
        }

      
        public int ProgramID {get; set;}
      
        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
           

        public List<ProgramClass> GetProgram()
        {
            

            List<ProgramClass> ProgramList = new List<ProgramClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetProgram", conn);

                    if (ProgramID>0)
                    sqlComm.Parameters.AddWithValue("@ProgramID", ProgramID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    ProgramList.Add(new ProgramClass
                    {

                        ProgramID = int.Parse(dr["ProgramID"].ToString()),
                        ProgramCode = dr["ProgramCode"].ToString(),
                        ProgramName = dr["ProgramName"].ToString(),
                        ProgramDescription = dr["ProgramDescription"].ToString(),
                        DepartmentID = int.Parse(dr["DepartmentID"].ToString())
                    });

                }
            }
            catch(Exception er) {
                ProgramList.Add(new ProgramClass { ErrorMessage = er.Message.ToString() });
            }
            return ProgramList;


        }

    }
