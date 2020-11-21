using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPNameSpace;

/// <summary>
/// Summary description for StudentPastClass
/// </summary>
namespace ERPNameSpace
{
    public class StudentPastClass:UserModuleRoleClass
    {
     
      
     

        public string LastExamPassed { get; set; }
        public decimal LastExamRollNo { get; set; }
        public decimal LastExamPassOutYear { get; set; }
        public string LastExamSession { get; set; }
        public decimal LastExamBoardUniversity { get; set; }
        public decimal LastExamDivision { get; set; }
        public decimal LastExamPercent { get; set; }
        public decimal LastExamMarks { get; set; }
        public decimal LastExamOutOff { get; set; }
        public decimal LastExamGrade { get; set; }

        public decimal LastExamPhysicsMarks { get; set; }
        public decimal LastExamPhysicsMarksOutOff { get; set; }
        public decimal LastExamChemistryMarks { get; set; }
        public decimal LastExamChemistryMarksOutOff { get; set; }
        public decimal LastExamMathsMarks { get; set; }
        public decimal LastExamMathsMarksOutOff { get; set; }

        public decimal LastExamBiologyMarks { get; set; }
        public decimal LastExamBiologyMarksOutOff { get; set; }
        public decimal LastExamVocationalMarks { get; set; }
        public decimal LastExamVocationalMarksOutOff { get; set; }
        public decimal LastExamPBVTotalMarks { get; set; }
        public decimal LastExamPBVMarksOutOff { get; set; }
        public decimal LastExamPBVPercentage { get; set; }
    

     


    }
}