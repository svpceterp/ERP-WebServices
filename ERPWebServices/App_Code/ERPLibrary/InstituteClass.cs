using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentClass
/// </summary>

namespace ERPNameSpace
{
    public class InstituteClass
    {
      
       private bool b = new bool();
        private int x = 0;
        public string InstID { get { return x.ToString(); }
            set {
               
                 b = int.TryParse(value, out x);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                

            } 
        }
        public string InstCode { get; set; }
        public string InstName { get; set; }
        public string InstStreet { get; set; }
        public string InstCity { get; set; }
        public string InstDistrict { get; set; }
        public string InstState { get; set; }
        public string InstCountry { get; set; }
        public string InstPinCode { get; set; }
        public string ErrorMessage { get; set; }

        

        public List<InstituteClass> GetInstitute()
        {
            List<InstituteClass> Instlist = new List<InstituteClass>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetInstitute", conn);
                sqlComm.Parameters.AddWithValue("@Inst_id", InstID);
               


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                Instlist.Add(new InstituteClass
                {
                    InstID = dr["inst_id"].ToString(),
                    InstCode = dr["instcode"].ToString(),
                    InstName = dr["instname"].ToString(),
                    InstStreet = dr["InstStreet"].ToString(),
                    InstCity = dr["InstCity"].ToString(),
                    InstDistrict = dr["InstDistrict"].ToString(),
                    InstState = dr["InstState"].ToString(),
                    InstCountry = dr["InstCountry"].ToString(),
                    InstPinCode = dr["InstPinCode"].ToString(),
                    
                });

            }

            return Instlist;
        }

        public MessageClass UpdateInstitute(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateInstitute", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Inst_ID",InstID);
                    cmd.Parameters.AddWithValue("@InstCode", InstCode);
                    cmd.Parameters.AddWithValue("@InstName",InstName);
                    cmd.Parameters.AddWithValue("@InstStreet", InstStreet);
                    cmd.Parameters.AddWithValue("@InstCity", InstCity);
                    cmd.Parameters.AddWithValue("@InstDistrict", InstDistrict);
                    cmd.Parameters.AddWithValue("@InstState", InstState);
                    cmd.Parameters.AddWithValue("@InstCountry", InstCountry);
                    cmd.Parameters.AddWithValue("@InstPinCode",InstPinCode);



                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.Message = (string)cmd.Parameters["@rvalue"].Value;
                    rm.Status = "success";
                }
            }
            catch (Exception er)
            {
                rm.Message = er.Message.ToString();
                rm.Status = "failed";
            }

            return rm;

        }


    }
}