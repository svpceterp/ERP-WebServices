using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using nsManageCourseScheme;
using nsManageInstitute;
/// <summary>
/// Summary description for clsPersonalal
/// </summary>
/// 
namespace nsManageUser
{
    public class clsPersonal:clsMessage
    {

        public string UID { get; set; }
        public string StudentFullName { get; set; }
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
        public string MemberType { get; set; }
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

     

        public List<clsPersonal> getPersonalDetails()
        {


            List<clsPersonal> stateList = new List<clsPersonal>();
            DataTable ds = new DataTable();
            try
            {
                using (SqlConnection conn = ConnectionDB.OpenConnection())
                {
                    SqlCommand sqlComm = new SqlCommand("Proc_GetPersonalDetails", conn);

                    
                    if (!string.IsNullOrEmpty(UID))
                        sqlComm.Parameters.AddWithValue("@uid", UID);

                    if (!string.IsNullOrEmpty(EmailID))
                        sqlComm.Parameters.AddWithValue("@email", EmailID);

                    if (!string.IsNullOrEmpty(StudentFullName))
                        sqlComm.Parameters.AddWithValue("@name",StudentFullName);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }

                foreach (DataRow dr in ds.Rows)
                {
                    stateList.Add(new clsPersonal
                    {

                        UID = dr["uid"].ToString(),
                        AdhaarNo = dr["adhaarNo"].ToString(),
                        Photo = dr["Photo"].ToString(),
                        FirstName = dr["firstname"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        FathersName = dr["FathersName"].ToString(),
                        MothersName = dr["MothersName"].ToString(),
                        MobileNo = dr["MobileNo"].ToString(),
                        EmailID = dr["EmailID"].ToString(),
                        DOB = dr["dob"].ToString(),
                        CategoryCast = dr["CategoryCast"].ToString(),
                        Religion = dr["Religion"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        Nationality = dr["Nationality"].ToString(),
                        HandicapedBlind = dr["HandicapedBlind"].ToString(),
                        MemberType = dr["MemberType"].ToString(),
                    PostalStreet = dr["PostalStreet"].ToString(),
                        PostalCityName = dr["PostalCityName"].ToString(),
                        PostalDistrictName = dr["PostalDistrictName"].ToString(),
                        PostalStateName = dr["PostalStateName"].ToString(),
                        PostalCountryName = dr["PostalCountryName"].ToString(),
                        PostalPinCode = dr["PostalPinCode"].ToString(),
                      

                        PermanantStreet = dr["PermanantStreet"].ToString(),
                        PermanantCityName = dr["PermanantCityName"].ToString(),
                        PermanantDistrictName = dr["PermanantDistrictName"].ToString(),
                        PermanantStateName = dr["PermanantStateName"].ToString(),
                        PermanantCountryName = dr["PermanantCountryName"].ToString(),
                        PermanantPinCode = dr["PermanantPinCode"].ToString(),
                     







                    });


                }
            }
            catch (Exception er)
            {
                stateList.Add(new clsPersonal { ErrorMessage = er.Message.ToString() });
            }
            return stateList;


        }

        public clsPersonal getPersonalDetails(string pUID)
        {

           return getPersonalDetails()[0];

        }
    
        public clsMessage updatePersonalDetails(string action = "Insert")
        {

            clsMessage rm = new clsMessage();

            try
            {
                using (SqlConnection con = ConnectionDB.OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand("Proc_UpdatepersonalDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", UID);
                    cmd.Parameters.AddWithValue("@AdhaarNo", AdhaarNo);
                    cmd.Parameters.AddWithValue("@Photo", Photo);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);

                    cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@FathersName", FathersName);
                    cmd.Parameters.AddWithValue("@MothersName", MothersName);
                    cmd.Parameters.AddWithValue("@MobileNo", MobileNo);

                    cmd.Parameters.AddWithValue("@EmailID", EmailID);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@CategoryCast", CategoryCast);
                    cmd.Parameters.AddWithValue("@Religion", Religion);
                    cmd.Parameters.AddWithValue("@Gender", Gender);

                    cmd.Parameters.AddWithValue("@Nationality", Nationality);
                    cmd.Parameters.AddWithValue("@HandicapedBlind", HandicapedBlind);
                    cmd.Parameters.AddWithValue("@PostalStreet", PostalStreet);
                    cmd.Parameters.AddWithValue("@PostalCityName", PostalCityName);
                    cmd.Parameters.AddWithValue("@PostalDistrictName", PostalDistrictName);
                    cmd.Parameters.AddWithValue("@PostalCountryName", PostalCountryName);
                    cmd.Parameters.AddWithValue("@PostalPinCode", PostalPinCode);
                    cmd.Parameters.AddWithValue("@PermanantStreet", PermanantStreet);
                    cmd.Parameters.AddWithValue("@PermanantCityName", PermanantCityName);
                    cmd.Parameters.AddWithValue("@PermanantDistrictName", PermanantDistrictName);
                    cmd.Parameters.AddWithValue("@PermanantCountryName", PermanantCountryName);
                    cmd.Parameters.AddWithValue("@PermanantPinCode", PermanantPinCode);
                    cmd.Parameters.AddWithValue("@action", action);



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
