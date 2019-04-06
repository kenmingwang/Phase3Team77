using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Assignments
    {
        public Assignments()
        {
            Submission = new HashSet<Submission>();
        }

        public int AId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Contents { get; set; }
        public DateTime Due { get; set; }
        public int AcId { get; set; }

        public virtual AssignmentCategories Ac { get; set; }
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
