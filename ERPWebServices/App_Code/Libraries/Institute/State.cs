using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace  nsManageInstitute
{
    public  class clsState:clsCountry
    {
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }

      

        public List<clsState> getStates(string CountryCode = "ALL")
        {

            List<clsState> states = new List<clsState>();
            try
            {
                states.Add(new clsState { StateCode = "AD", StateName = "Andhra Pradesh", CountryCode="IND"});
                states.Add(new clsState { StateCode = "AR", StateName = "Arunachal Pradesh", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "AS", StateName = "Assam", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "BR", StateName = "Bihar", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "CG", StateName = "Chhattisgarh", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "DL", StateName = "Delhi", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "GA", StateName = "Goa", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "GJ", StateName = "Gujarat", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "HR", StateName = "Haryana", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "HP", StateName = "Himachal Pradesh", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "JK", StateName = "Jammu and Kashmir", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "JH", StateName = "Jharkhand", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "KA", StateName = "Karnataka", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "KL", StateName = "Kerala", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "LD", StateName = "Lakshadweep", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "MP", StateName = "Madhya Pradesh", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "MH", StateName = "Maharashtra", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "MN", StateName = "Manipur", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "ML", StateName = "Meghalaya", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "MZ", StateName = "Mizoram", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "NL", StateName = "Nagaland", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "OD", StateName = "Odisha", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "PY", StateName = "Pondicherry", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "PB", StateName = "Punjab", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "RJ", StateName = "Rajasthan", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "SK", StateName = "Sikkim", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "TN", StateName = "Tamil Nadu", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "TS", StateName = "Telangana", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "TR", StateName = "Tripura", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "UP", StateName = "Uttar Pradesh", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "UK", StateName = "Uttarakhand", CountryCode = "IND" });
                states.Add(new clsState { StateCode = "WB", StateName = "West Bengal", CountryCode = "IND" });


                if (!String.IsNullOrEmpty(CountryCode) && !CountryCode.Equals("ALL"))
                    states.Find(x => x.CountryCode == CountryCode);
            }
            catch (Exception er)
            {
                states.Add(new clsState { ErrorMessage = er.Message.ToString() });
            }


            return states;
        }


    }
    }
