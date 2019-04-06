using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class EnrollmentGrade
    {
        public string UId { get; set; }
        public int CId { get; set; }
        public string Grade { get; set; }

        public virtual Classes C { get; set; }
        public virtual Students U { get; set; }
    }
}
