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
namespace ERP
{
    public class CountryClass:MessageClass
    {
     

        public int CountryID { get; set;}
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    
        //public List<CountryClass> GetCountry()
        //{
        //    ERPConnectionClass erpconn = new ERPConnectionClass();

        //    List<CountryClass> countryList = new List<CountryClass>();
        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        using (SqlConnection conn = erpconn.OpenConnection())
        //        {
        //            SqlCommand sqlComm = new SqlCommand("Proc_GetCountry", conn);
        //            sqlComm.Parameters.AddWithValue("@Countryid", CountryID);


        //            sqlComm.CommandType = CommandType.StoredProcedure;

        //            SqlDataAdapter da = new SqlDataAdapter();
        //            da.SelectCommand = sqlComm;

        //            da.Fill(ds);
        //        }

        //        foreach (DataRow dr in ds.Rows)
        //        {
        //            countryList.Add(new CountryClass
        //            {

        //                CountryID = dr["Countryid"].ToString(),
        //                CountryCode = dr["countrycode"].ToString(),
        //                CountryName = dr["countryname"].ToString()

        //            });


        //        }
           
        //     }
        //    catch (Exception er)
        //    {
        //        countryList.Add(new CountryClass { ErrorMessage = er.Message.ToString() });
        //    }
        //    return countryList;


        //}
        //public CountryClass GetCountry(string CountryName)
        //{
        //    ERPConnectionClass erpconn = new ERPConnectionClass();

        //    CountryClass country = new CountryClass();
        //    DataTable ds = new DataTable();
        //    try { 
        //    using (SqlConnection conn = erpconn.OpenConnection())
        //    {
        //        string sql = "select * from tbl_country where countryName=@CountryName";
        //        SqlCommand sqlComm = new SqlCommand("Proc_GetCountry", conn);
        //        sqlComm.Parameters.AddWithValue("@CountryName", CountryName);
                
        //        sqlComm.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter da = new SqlDataAdapter();
        //        da.SelectCommand = sqlComm;

        //        da.Fill(ds);
        //    }

        //    foreach (DataRow dr in ds.Rows)
        //    {
        //        country.CountryID = dr["Country_id"].ToString();
        //            country.CountryCode = dr["countrycode"].ToString();
        //            country.CountryName = dr["countryname"].ToString();
        //   }
        //    }
        //    catch (Exception er)
        //    {
        //        country.ErrorMessage = er.Message.ToString();
        //    }
        //    return country;


        //}
        public List<CountryClass> GetCountry()
        {
            List<string> List = new List<string>();
            List<CountryClass> countryList = new List<CountryClass>();
            List<CountryClass> countryListSorted = new List<CountryClass>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            try
            {
                foreach (CultureInfo culture in getCultureInfo)
                {

                    RegionInfo getRegionInfo = new RegionInfo(culture.LCID);

                    CountryClass country = new CountryClass();
                    country.CountryID = getRegionInfo.GeoId;
                    country.CountryName = getRegionInfo.EnglishName;
                    country.CountryCode = getRegionInfo.ThreeLetterWindowsRegionName;

                    if (!List.Contains(getRegionInfo.EnglishName))
                    {
                        countryList.Add(country);
                        List.Add(getRegionInfo.EnglishName);
                    }



                }

               

                countryListSorted = countryList.OrderBy(x => x.CountryName).ToList();
                // countryList.Sort();
            }
            catch (Exception er)
            {
                countryListSorted.Add(new CountryClass { ErrorMessage = er.Message.ToString() });
            }
            return countryListSorted;


        }
    }
}