using System;
using System.Collections.Generic;
using System.Linq;
using ERPLocalConnection;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class CountryClass
    {
       private int _CountryID=0;
        private string _CountryCode;
        private string _CountryName;

        bool b = false;
        int x = 0; 

        public string CountryID { get { return _CountryID.ToString(); }
            set {
                b = int.TryParse(value, out _CountryID);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
             
            } }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    
        public string ErrorMessage { get; set; }

        public List<CountryClass> GetCountry()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<CountryClass> countryList = new List<CountryClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetCountry", conn);
                    sqlComm.Parameters.AddWithValue("@sem_id", CountryID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    countryList.Add(new CountryClass
                    {

                        CountryID = dr["Country_id"].ToString(),
                        CountryCode = dr["countrycode"].ToString(),
                        CountryName = dr["countryname"].ToString()

                    });


                }
           
             }
            catch (Exception er)
            {
                countryList.Add(new CountryClass { ErrorMessage = er.Message.ToString() });
            }
            return countryList;


        }
        public CountryClass GetCountry(string CountryName)
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            CountryClass country = new CountryClass();
            DataTable ds = new DataTable();
            try { 
            using (SqlConnection conn = erpconn.OpenConnection())
            {
                string sql = "select * from tbl_country where countryName=@CountryName";
                SqlCommand sqlComm = new SqlCommand("Proc_GetCountry", conn);
                sqlComm.Parameters.AddWithValue("@CountryName", CountryName);
                
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                country.CountryID = dr["Country_id"].ToString();
                    country.CountryCode = dr["countrycode"].ToString();
                    country.CountryName = dr["countryname"].ToString();
           }
            }
            catch (Exception er)
            {
                country.ErrorMessage = er.Message.ToString();
            }
            return country;


        }
        public List<CountryClass> GetCountryName()
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
                    country.CountryID = getRegionInfo.GeoId.ToString();
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