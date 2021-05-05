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
    public class clsDistrict : clsState
    {


        public int DistrictID { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }

        public List<clsDistrict> getDistricts()
        {


            List<clsDistrict> countryList = new List<clsDistrict>();
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
                    countryList.Add(new clsDistrict
                    {
                        DistrictID = int.Parse(dr["districtid"].ToString()),
                        DistrictCode = dr["districtcode"].ToString(),
                        DistrictName = dr["districtname"].ToString()

                    });


                }

            }
            catch (Exception er)
            {
                countryList.Add(new clsDistrict { ErrorMessage = er.Message.ToString() });
            }
            return countryList;


        }

    }
}