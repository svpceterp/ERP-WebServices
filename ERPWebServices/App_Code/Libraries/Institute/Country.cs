using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace nsManageInstitute
{
    public  class clsCountry : clsMessage
    {


        public int CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public List<clsCountry> getCountries(string CountryCode = "IND")
        {
            List<string> List = new List<string>();
            List<clsCountry> countryList = new List<clsCountry>();
            List<clsCountry> countryListSorted = new List<clsCountry>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            try
            {
                foreach (CultureInfo culture in getCultureInfo)
                {

                    RegionInfo getRegionInfo = new RegionInfo(culture.LCID);
                    clsCountry country = new clsCountry();
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
                countryListSorted.Add(new clsCountry { ErrorMessage = er.Message.ToString() });
            }
            return countryListSorted;


        }

    }
}
