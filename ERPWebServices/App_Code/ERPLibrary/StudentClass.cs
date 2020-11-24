using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPNameSpace;
using ERPLocalConnection;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for StudentClass
/// </summary>
public class StudentClass:UserModuleRoleClass
{
    public string InstID { get; set; }
    public string EnrollmentNo { get; set; }
    public string DTEAPPID { get; set; }
    public string DateOfAdmission { get; set; }
    public string DateOfPayment { get; set; }


    public List<StudentClass> GetStudentDetails(string Uid,string ProfEMail,string Name)
    {
        ERPConnectionClass erpconn = new ERPConnectionClass();

        List<StudentClass> stateList = new List<StudentClass>();
        DataTable ds = new DataTable();
        try
        {
            using (SqlConnection conn = erpconn.OpenConnection())
            {
                SqlCommand sqlComm = new SqlCommand("Proc_GetStudentDetails", conn);

                if (Uid != "ALL")
                    sqlComm.Parameters.AddWithValue("@uid", Uid);
                if (EmailID != "ALL")
                    sqlComm.Parameters.AddWithValue("@email", EmailID);
                if (Name != "ALL")
                    sqlComm.Parameters.AddWithValue("@name", Name);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Rows)
            {
                stateList.Add(new StudentClass
                {

                    Uid = dr["uid"].ToString(),
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
                    PostalStreet = dr["PostalStreet"].ToString(),
                    PostalCityName = dr["PostalCityName"].ToString(),
                    PostalDistrictName = dr["PostalDistrictName"].ToString(),
                    PostalStateName = dr["PostalStateName"].ToString(),
                    PostalCountryName = dr["PostalCountryName"].ToString(),
                    PostalPinCode = dr["PostalPinCode"].ToString(),
                    PostalAddress = dr["PostalAddress"].ToString(),

                    PermanantStreet = dr["PermanantStreet"].ToString(),
                    PermanantCityName = dr["PermanantCityName"].ToString(),
                    PermanantDistrictName = dr["PermanantDistrictName"].ToString(),
                    PermanantStateName = dr["PermanantStateName"].ToString(),
                    PermanantCountryName = dr["PermanantCountryName"].ToString(),
                    PermanantPinCode = dr["PermanantPinCode"].ToString(),
                    PermanantAddress = dr["PermanantAddress"].ToString(),

                    LastExamPassed = dr["LastExamPassed"].ToString(),
                    LastExamRollNo = dr["LastExamRollNo"].ToString(),
                    LastExamPassOutYear = dr["LastExamPassOutYear"].ToString(),
                    LastExamSession = dr["LastExamSession"].ToString(),
                    LastExamBoardUniversity = dr["LastExamBoardUniversity"].ToString(),
                    LastExamDivision = dr["LastExamDivision"].ToString(),
                    LastExamPercent = dr["LastExamPercent"].ToString(),
                    LastExamMarks = dr["LastExamMarks"].ToString(),
                    LastExamOutOff = dr["LastExamOutOff"].ToString(),
                    LastExamGrade = dr["LastExamGrade"].ToString(),
                    LastExamPhysicsMarks = dr["LastExamPhysicsMarks"].ToString(),
                    LastExamPhysicsMarksOutOff = dr["LastExamPhysicsMarksOutOff"].ToString(),
                    LastExamChemistryMarks = dr["LastExamChemistryMarks"].ToString(),
                    LastExamChemistryMarksOutOff = dr["LastExamChemistryMarksOutOff"].ToString(),
                    LastExamMathsMarks = dr["LastExamMathsMarks"].ToString(),
                   LastExamMathsMarksOutOff = dr["LastExamMathsMarksOutOff"].ToString(),
                   LastExamBiologyMarks = dr["LastExamBiologyMarks"].ToString(),
                    LastExamBiologyMarksOutOff = dr["LastExamBiologyMarksOutOff"].ToString(),
                    LastExamVocationalMarks = dr[" LastExamVocationalMarks"].ToString(),
                    LastExamVocationalMarksOutOff = dr["LastExamVocationalMarksOutOff"].ToString(),
                    LastExamPBVTotalMarks = dr["LastExamPBVTotalMarks"].ToString(),
                    LastExamPBVMarksOutOff = dr["LastExamPBVMarksOutOff"].ToString(),
                    LastExamPBVPercentage = dr["LastExamPBVPercentage"].ToString(),
                    InstID = dr["InstID"].ToString(),
                    EnrollmentNo= dr[" EnrollmentNo"].ToString(),
                    DTEAPPID = dr["DTEAPPID"].ToString(),
                    DateOfAdmission = dr["DateOfAdmission"].ToString(),
                    DateOfPayment = dr["DateOfPayment"].ToString(),
                               });


            }
        }
        catch (Exception er)
        {
            stateList.Add(new StudentClass { ErrorMessage = er.Message.ToString() });
        }
        return stateList;


    }


    public MessageClass UpdatePersonalDetails(string action = "Insert")
    {

        MessageClass rm = new MessageClass();
        ERPConnectionClass erpconn = new ERPConnectionClass();

        try
        {
            using (SqlConnection con = erpconn.OpenConnection())
            {

                SqlCommand cmd = new SqlCommand("Proc_UpdatepersonalDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", Uid);
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
                rm.Message = (string)cmd.Parameters["@rvalue"].Value;
                rm.Status = "success";
            }
        }
        catch (Exception er)
        {
            rm.Message = er.Message.ToString();
            rm.Status = "failed";
        }

        return rm;

    }




}