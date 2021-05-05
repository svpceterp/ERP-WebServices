

using nsManageUser;
/// <summary>
/// Summary description for StudentClass
/// </summary>
/// 
namespace nsManageStudent
{
    public class clsStudent : clsPersonal
    {
       
        public string EnrollmentNo { get; set; }
       public string ProfEMailID { get; set; }
        public string DTEAPPID { get; set; }
        public string DateOfAdmission { get; set; }
        public string DateOfPayment { get; set; }
        public string ProfessionalEmailID { get; set; }

    }
}