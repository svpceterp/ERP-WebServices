using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPNameSpace;

/// <summary>
/// Summary description for PersonalClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class PersonalClass:MessageClass
    {
       
        public string Uid { get; set; }
    
        public string AdhaarNo { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
     
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string DOB { get; set; }
        public string CategoryCast { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string HandicapedBlind { get; set; }
      
        public string SubjectOffered { get; set; }

        public string PostalStreet { get; set; }
        public string PostalDistrictName { get; set; }
        public string PostalCityName { get; set; }
        public string PostalStateName { get; set; }
        public string PostalCountryName { get; set; }
        public string PostalPinCode { get; set; }
        public string PostalAddress { get; set; }
        public string PermanantStreet { get; set; }
        public string PermanantDistrictName { get; set; }
        public string PermanantCityName { get; set; }
        public string PermanantStateName { get; set; }
        public string PermanantCountryName { get; set; }
        public string PermanantPinCode { get; set; }
        public string PermanantAddress { get; set; }

    }
}