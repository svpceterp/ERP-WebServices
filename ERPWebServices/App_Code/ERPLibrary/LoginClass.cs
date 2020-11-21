﻿using ERPConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPNameSpace;

/// <summary>
/// Summary description for LoginClass
/// </summary>
public class LoginClass
{
    string UserName;
    string Password;
    public LoginClass(string UName, string Pwd)
    {
        UserName = UName;
        Password = Pwd;

    }
    public UserClass CheckLogin()
    {
       UserClass User=new UserClass();

        DataTable dt = new DataTable();
        try
        {
            ERPConnectionClass erpconn = new ERPConnectionClass();
          
            using (SqlConnection conn = erpconn.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_CheckLogin", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@username", UserName);
                sqlComm.Parameters.AddWithValue("@password", Password);
             
                     SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(dt);
                
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                User.Uid = dr["uid"].ToString();
                User.Photo = dr["photo"].ToString();
                User.FirstName = dr["Firstname"].ToString();
                User.MiddleName = dr["middlename"].ToString();
                User.LastName = dr["lastname"].ToString();
                User.urole = dr["urole"].ToString();
                User.ModuleCode = "ERP";
                User.ModuleName = "ERP Home";
                User.MobileNo = dr["mobileno"].ToString();
                User.EmailID = dr["emailid"].ToString();
                User.DOB = dr["Dob"].ToString();
                User.CategoryCast = dr["categorycast"].ToString();
                User.Religion = dr["Religion"].ToString();
                User.Gender = dr["Gender"].ToString();
                User.Nationality = dr["Nationality"].ToString();
                User.HandicapedBlind = dr["HandicapedBlind"].ToString();
                User.PostalAddress = dr["PostalAddress"].ToString();
                User.PermanantAddress = dr["PermanantAddress"].ToString();
                User.Status = "success";
                User.ErrorMessage = null;
            }
            else
            {
                User = null;
                User.Status = "failed";
                User.ErrorMessage = "Invalid User Account.";
            }



        }
        catch (Exception er)
        {

            User.Status = "failed";
            User.ErrorMessage = er.Message.ToString().Trim();

        }


        return User;

    }
}