﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPConnection;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

/// <summary>
/// Summary description for SemesterClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class StateClass:CountryClass
    {
       private int _StateID=0;
        private string _StateCode;
        private string _CountryCode;
      

        bool b = false;
        int x = 0; 

        public string StateID { get { return _StateID.ToString(); }
            set {
                b = int.TryParse(value, out _StateID);
                if (x < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
             
            } }
        public string StateCode { get; set; }
        public string StateName { get; set; }
      
        public string ErrorMessage { get; set; }

        public List<StateClass> GetState()
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            List<StateClass> stateList = new List<StateClass>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetState", conn);
                    sqlComm.Parameters.AddWithValue("@state_id", StateID);


                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    stateList.Add(new StateClass
                    {

                        StateID = dr["State_id"].ToString(),
                        StateCode = dr["countrycode"].ToString(),
                        StateName = dr["countryname"].ToString()

                    });


                }
            }
            catch (Exception er)
            {
                stateList.Add(new StateClass { ErrorMessage = er.Message.ToString() });
            }
            return stateList;


        }
        public StateClass GetState(string StateName)
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();

            StateClass State = new StateClass();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = erpconn.OpenConnection())
                {
                    string sql = "select * from tbl_state where stateName=@StateName";
                    SqlCommand sqlComm = new SqlCommand("Proc_GetState", conn);
                    sqlComm.Parameters.AddWithValue("@StateName", StateName);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    State.StateID = dr["State_id"].ToString();
                    State.StateCode = dr["Statecode"].ToString();
                    State.StateName = dr["Statename"].ToString();
                }
            }
            catch (Exception er)
            {
                State.ErrorMessage = er.Message.ToString();
            }
            return State;


        }
        public List<StateClass> GetStateName(string CCode="ALL")
        {

            List<StateClass> states = new List<StateClass>();
            try
            {
                states.Add(new StateClass { StateCode = "AD", StateName = "Andhra Pradesh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "AR", StateName = "Arunachal Pradesh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "AS", StateName = "Assam", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "BR", StateName = "Bihar", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "CG", StateName = "Chhattisgarh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "DL", StateName = "Delhi", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "GA", StateName = "Goa", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "GJ", StateName = "Gujarat", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "HR", StateName = "Haryana", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "HP", StateName = "Himachal Pradesh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "JK", StateName = "Jammu and Kashmir", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "JH", StateName = "Jharkhand", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "KA", StateName = "Karnataka", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "KL", StateName = "Kerala", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "LD", StateName = "Lakshadweep", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "MP", StateName = "Madhya Pradesh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "MH", StateName = "Maharashtra", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "MN", StateName = "Manipur", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "ML", StateName = "Meghalaya", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "MZ", StateName = "Mizoram", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "NL", StateName = "Nagaland", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "OD", StateName = "Odisha", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "PY", StateName = "Pondicherry", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "PB", StateName = "Punjab", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "RJ", StateName = "Rajasthan", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "SK", StateName = "Sikkim", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "TN", StateName = "Tamil Nadu", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "TS", StateName = "Telangana", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "TR", StateName = "Tripura", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "UP", StateName = "Uttar Pradesh", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "UK", StateName = "Uttarakhand", CountryCode = "IND" });
                states.Add(new StateClass { StateCode = "WB", StateName = "West Bengal", CountryCode = "IND" });


                if (!String.IsNullOrEmpty(CCode) && !CCode.Equals("ALL"))
                    states.Find(x => x.CountryCode == CCode);
            }
            catch(Exception er) {
                states.Add(new StateClass { ErrorMessage=er.Message.ToString() });
            }
            

            return states;
        }



    }
}