using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPNameSpace;

/// <summary>
/// Summary description for StudentClass
/// </summary>
public class StudentClass:UserModuleRoleClass
{
    public int InstID { get; set; }
    public string EnrollmentNo { get; set; }
    public string DTEAPPID { get; set; }
    public DateTime DateOfAdmission { get; set; }
    public DateTime DateOfPayment { get; set; }
   
}