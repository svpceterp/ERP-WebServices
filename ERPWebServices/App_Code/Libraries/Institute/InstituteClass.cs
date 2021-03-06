﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DepartmentClass
/// </summary>

namespace  nsManageInstitute
{
    public class clsInstitute : clsUniversity
    {

        public int InstituteID { get; set; }
        public string InstituteCode { get; set; }
        public string InstituteName { get; set; }
        public string InstituteStreet { get; set; }
        public string InstituteCity { get; set; }
        public string InstituteDistrict { get; set; }
        public string InstituteState { get; set; }
        public string InstituteCountry { get; set; }
        public string InstitutePinCode { get; set; }
        public string AcademicYear { get; set; }


        public clsInstitute()
        {
            InstituteID = 0;
            InstituteCode = "ALL";

        }


        public List<clsInstitute> getInstitutes()
        {
            List<clsInstitute> Instlist = new List<clsInstitute>();


            DataTable ds = new DataTable();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetInstitute", conn);


                sqlComm.Parameters.AddWithValue("@Instituteid", InstituteID);



                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                Instlist.Add(new clsInstitute
                {
                    InstituteID = int.Parse(dr["Institueid"].ToString()),
                    InstituteCode = dr["Instituecode"].ToString(),
                    InstituteName = dr["Instituename"].ToString(),
                    InstituteStreet = dr["InstitueStreet"].ToString(),
                    InstituteCity = dr["InstitueCity"].ToString(),
                    InstituteDistrict = dr["InstitueDistrict"].ToString(),
                    InstituteState = dr["InstitueState"].ToString(),
                    InstituteCountry = dr["InstitueCountry"].ToString(),
                    InstitutePinCode = dr["InstituePinCode"].ToString()

                });

            }

            return Instlist;
        }

        public clsMessage updateInstitute(string action = "insert")
        {
            clsMessage rm = new clsMessage();
            try
            {

                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdateInstitute", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InstitueID", InstituteID);
                    cmd.Parameters.AddWithValue("@InstitueCode", InstituteCode);
                    cmd.Parameters.AddWithValue("@InstitueName", InstituteName);
                    cmd.Parameters.AddWithValue("@InstitueStreet", InstituteStreet);
                    cmd.Parameters.AddWithValue("@InstitueCity", InstituteCity);
                    cmd.Parameters.AddWithValue("@InstitueDistrict", InstituteDistrict);
                    cmd.Parameters.AddWithValue("@InstitueState", InstituteState);
                    cmd.Parameters.AddWithValue("@InstitueCountry", InstituteCountry);
                    cmd.Parameters.AddWithValue("@InstituePinCode", InstitutePinCode);



                    cmd.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    cmd.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    rm.SuccessMessage = (string)cmd.Parameters["@rvalue"].Value;
                    rm.StatusMessage = "success";
                }
            }
            catch (Exception er)
            {
                rm.ErrorMessage = er.Message.ToString();
                rm.StatusMessage = "failed";
            }

            return rm;

        }


    }
}