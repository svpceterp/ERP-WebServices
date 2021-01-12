using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPConnection;
/// <summary>
/// Summary description for DepartmentClass
/// </summary>

namespace ERP
{
    public class InstituteClass:UniversityClass
    {
      
       public int InstitueID { get; set; }
       public string InstitueCode { get; set; }
        public string InstitueName { get; set; }
        public string InstitueStreet { get; set; }
        public string InstitueCity { get; set; }
        public string InstitueDistrict { get; set; }
        public string InstitueState { get; set; }
        public string InstitueCountry { get; set; }
        public string InstituePinCode { get; set; }
       

        ERPConnectionClass erpconn = new ERPConnectionClass();

        public List<InstituteClass> GetInstitute()
        {
            List<InstituteClass> Instlist = new List<InstituteClass>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = erpconn.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetInstitute", conn);
                sqlComm.Parameters.AddWithValue("@Instituteid", InstitueID);
               


                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                Instlist.Add(new InstituteClass
                {
                    InstitueID = int.Parse(dr["Institueid"].ToString()),
                    InstitueCode = dr["Instituecode"].ToString(),
                    InstitueName = dr["Instituename"].ToString(),
                    InstitueStreet = dr["InstitueStreet"].ToString(),
                    InstitueCity = dr["InstitueCity"].ToString(),
                    InstitueDistrict = dr["InstitueDistrict"].ToString(),
                    InstitueState = dr["InstitueState"].ToString(),
                    InstitueCountry = dr["InstitueCountry"].ToString(),
                    InstituePinCode = dr["InstituePinCode"].ToString(),
                    
                });

            }

            return Instlist;
        }

        public MessageClass UpdateInstitute(string action = "insert")
        {
            MessageClass rm = new MessageClass();
            ERPConnectionClass erpconn = new ERPConnectionClass();
            try
            {

                using (SqlConnection con = erpconn.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateInstitute", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InstitueID", InstitueID);
                    cmd.Parameters.AddWithValue("@InstitueCode", InstitueCode);
                    cmd.Parameters.AddWithValue("@InstitueName", InstitueName);
                    cmd.Parameters.AddWithValue("@InstitueStreet", InstitueStreet);
                    cmd.Parameters.AddWithValue("@InstitueCity", InstitueCity);
                    cmd.Parameters.AddWithValue("@InstitueDistrict", InstitueDistrict);
                    cmd.Parameters.AddWithValue("@InstitueState", InstitueState);
                    cmd.Parameters.AddWithValue("@InstitueCountry", InstitueCountry);
                    cmd.Parameters.AddWithValue("@InstituePinCode", InstituePinCode);



                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.SuccessMessage = (string)cmd.Parameters["@rvalue"].Value;
                    rm.Status = "success";
                }
            }
            catch (Exception er)
            {
                rm.ErrorMessage = er.Message.ToString();
                rm.Status = "failed";
            }

            return rm;

        }


    }
}