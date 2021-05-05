using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace  nsManageInstitute
{
    public class clsProgram : clsDepartment
    {
        public clsProgram()
        {
            ProgramID = 0;
        }


        public int ProgramID { get; set; }

        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }


        public List<clsProgram> getPrograms(int programID=0)
        {


            List<clsProgram> ProgramList = new List<clsProgram>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetProgram", conn);

                    if (ProgramID > 0)
                        sqlComm.Parameters.AddWithValue("@ProgramID", ProgramID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    ProgramList.Add(new clsProgram
                    {

                        ProgramID = int.Parse(dr["ProgramID"].ToString()),
                        ProgramCode = dr["ProgramCode"].ToString(),
                        ProgramName = dr["ProgramName"].ToString(),
                        ProgramDescription = dr["ProgramDescription"].ToString(),
                        DepartmentID = int.Parse(dr["DepartmentID"].ToString())
                    });

                }
            }
            catch (Exception er)
            {
                ProgramList.Add(new clsProgram { ErrorMessage = er.Message.ToString() });
            }
            return ProgramList;


        }

    }
}
