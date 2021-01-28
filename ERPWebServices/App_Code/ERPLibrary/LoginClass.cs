using ERPConnection;
using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for LoginClass
/// </summary>
public class LoginClass:PersonalClass
{
    string UserName;
    string Password;
    string NewPassword;

    public LoginClass()
    {
     

    }
    public LoginClass(string UName, string Pwd,string NewPwd=null)
    {
        UserName = UName;
        Password = Pwd;
        NewPassword = NewPwd;

    }

    public MessageClass CheckLogin()
    {
      MessageClass LoginStatus=new MessageClass();

        DataTable dt = new DataTable();
        try
        {
          
          
            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_CheckLogin", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@username", UserName);
                sqlComm.Parameters.AddWithValue("@password", Password);



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

    public MessageClass ChangePassword()
    {
        

        DataTable dt = new DataTable();
        MessageClass rm = new MessageClass();
        try
        {
           // ERPConnectionClass erpconn = new ERPConnectionClass();

            using (SqlConnection conn = ConnectionDB.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_changepassword", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.Parameters.AddWithValue("@username", UserName);
                sqlComm.Parameters.AddWithValue("@OldPassword", Password);
                sqlComm.Parameters.AddWithValue("@NewPassword", NewPassword);
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