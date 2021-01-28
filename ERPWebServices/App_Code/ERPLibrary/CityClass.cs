using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityClass
/// </summary>
public class CityClass:DistrictClass
{
    public int CityID { get; set; }
    public int CityCode { get; set; }
    public int CityName { get; set; }
}