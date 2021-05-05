
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsManageExamination
{
    public class clsExamESEMarks : clsExamCourseSchedule
    {
        public int ESEMID { get; set; }
        public int ECQSID { get; set; }
        public string Marks { get; set; }

    }
}
