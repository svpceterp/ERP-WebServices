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
namespace ERPNameSpace
{
    public class ProgramClass:DepartmentClass
    {
       

        bool b = false;
        int x = 0;
       int c = 0;
        public string ProgramID {
            get {
                return x.ToString();
            }
            set {
                b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
               
            }
            
        }
      
        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public string ProgramDuration{ get; set; }
        public string ProgramStartDate { get; set; }
        public string ProgramEndDate { get; set; }
        public string ProgramStatus { get; set; }
       

      

        public List<DepartmentProgramClass> GetDepartmentProgram()
        {
            

            List<DepartmentProgramClass> ProgramList = new List<DepartmentProgramClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetDepartmentProgram", conn);
                    sqlComm.Parameters.AddWithValue("@ProgramID", ProgramID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    ProgramList.Add(new DepartmentProgramClass
                    {
                        
                        DeptID = dr["Deptid"].ToString(),
                        DeptCode=dr["DeptCode"].ToString(),
                        DeptName=dr["DeptName"].ToString(),
                        ProgramID = dr["ProgramID"].ToString(),
                        ProgramCode = dr["ProgramCode"].ToString(),
                        ProgramName = dr["ProgramName"].ToString(),
                        ProgramDescription = dr["ProgramDescription"].ToString(),
                        ProgramDuration = dr["Programduration"].ToString(),
                        ProgramStartDate = dr["ProgramStartDate"].ToString(),
                        ProgramEndDate = dr["ProgramEnddate"].ToString(),
                        ProgramStatus = dr["ProgramStatus"].ToString()
                    });

                }
            }
            catch(Exception er) {
                ProgramList.Add(new DepartmentProgramClass { ErrorMessage = er.Message.ToString() });
            }
            return ProgramList;


        }

    }
}