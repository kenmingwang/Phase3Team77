using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCategories = new HashSet<AssignmentCategories>();
            EnrollmentGrade = new HashSet<EnrollmentGrade>();
        }

        public int CId { get; set; }
        public string UId { get; set; }
        public string CatalogId { get; set; }
        public string Semester { get; set; }
        public string Loc { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public virtual Courses Catalog { get; set; }
        public virtual Professor U { get; set; }
        public virtual ICollection<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual ICollection<EnrollmentGrade> EnrollmentGrade { get; set; }
    }
}
