using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Departments
    {
        public Departments()
        {
            Courses = new HashSet<Courses>();
            Professor = new HashSet<Professor>();
            Students = new HashSet<Students>();
        }

        public string Name { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<Professor> Professor { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
