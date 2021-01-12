using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERP;

/// <summary>
/// Summary description for StudentRegisteredSubjectClass
/// </summary>
/// 
namespace ERP
{
    public class StudentRegisteredSubjectClass:StudentYearRegistrationClass
    {
      public string StudRegSubjectID { get; set; }
      public string SubjectID { get; set; }
    }
}
