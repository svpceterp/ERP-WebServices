using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for StudentRegisteredSubjectClass
/// </summary>
/// 
namespace ERPNameSpace
{
    public class StudentRegisteredSubjectClass:StudentYearRegistrationClass
    {
      public string StudRegSubjectID { get; set; }
      public string SubjectID { get; set; }
    }
}
