using System;
using System.Collections.Generic;
using System.Linq;
using ERPConnection;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 

    public class DistrictClass:StateClass
    {
     

        public int DistrictID { get; set;}
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }

        public List<DistrictClass> GetDistrict()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<DistrictClass> countryList = new List<DistrictClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetDistrict", conn);
                    sqlComm.Parameters.AddWithValue("@Districtid", CountryID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    countryList.Add(new DistrictClass
                    {
                        DistrictID =int.Parse(dr["districtid"].ToString()),
                        DistrictCode = dr["districtcode"].ToString(),
                        DistrictName = dr["districtname"].ToString()

                    });


                }

            }
            catch (Exception er)
            {
                countryList.Add(new DistrictClass { ErrorMessage = er.Message.ToString() });
            }
            return countryList;


        }
      
    }
