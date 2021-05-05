
using System;
using System.Data;
using System.Data.SqlClient;
using nsManageInstitute;

/// <summary>
/// Summary description for LoginClass
/// </summary>
/// 
namespace nsManageUser
{
    public class clsLogin : clsPersonal
    {
      
    //string UserName { get; set; }
    //   string Password { get; set; }
    //   string NewPassword { get; set; }

        //public clsLogin(string pUserName,string pPassword,string pNewPassword=null)
        // {
        //     UserName = pUserName;
        //     Password = pPassword;
        //     NewPassword = pNewPassword;

        // }


        public clsMessage checkLogin(string uname,string password)
        {
            clsMessage LoginStatus = new clsMessage();

            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_CheckLogin", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@username", uname);
                    sqlComm.Parameters.AddWithValue("@password", password);



                    sqlComm.Parameters.Add("@status", SqlDbType.Char, 50);
                    sqlComm.Parameters["@status"].Direction = ParameterDirection.Output;

                    sqlComm.Parameters.Add("@errormessage", SqlDbType.Char, 500);
                    sqlComm.Parameters["@errormessage"].Direction = ParameterDirection.Output;

                    sqlComm.ExecuteNonQuery();

                    LoginStatus.StatusMessage = sqlComm.Parameters["@status"].Value.ToString().Trim();
                    LoginStatus.ErrorMessage = sqlComm.Parameters["@errormessage"].Value.ToString().Trim();

                }

            }
            catch (Exception er)
            {
                LoginStatus.StatusMessage = "Failed";
                LoginStatus.ErrorMessage = er.Message.ToString().Trim();

            }


            return LoginStatus;

        }

        public clsMessage changePassword(string uname,string oldpassword,string newpassword)
        {


            DataTable dt = new DataTable();
            clsMessage rm = new clsMessage();
            try
            {
                // ERPConnectionClass erpconn = new ERPConnectionClass();

                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_changepassword", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@username", uname);
                    sqlComm.Parameters.AddWithValue("@OldPassword", oldpassword);
                    sqlComm.Parameters.AddWithValue("@NewPassword", newpassword);
                    sqlComm.Parameters.AddWithValue("@action", "Modify");


                    sqlComm.Parameters.Add("@rvalue", SqlDbType.Char, 500);
                    sqlComm.Parameters["@rvalue"].Direction = ParameterDirection.Output;
                    sqlComm.ExecuteNonQuery();
                    rm.StatusMessage = sqlComm.Parameters["@rvalue"].Value.ToString().Trim();
                    if (rm.StatusMessage.Equals("success"))
                        rm.SuccessMessage = "Password Changed Successfull.";
                    else if (rm.StatusMessage.Equals("invalid user"))
                        rm.ErrorMessage = "Authorization Failed";

                }




            }
            catch (Exception er)
            {

                rm.StatusMessage = "failed";
                rm.SuccessMessage = "Password Not Changed.";
                rm.ErrorMessage = er.Message.ToString().Trim();

            }


            return rm;

        }

    }

}