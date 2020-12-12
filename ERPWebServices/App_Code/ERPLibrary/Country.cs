using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class CountryClass:MessageClass
    {
        public string CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
         
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