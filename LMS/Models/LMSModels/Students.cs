﻿using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Students
    {
        public Students()
        {
            Submission = new HashSet<Submission>();
        }

        public string UId { get; set; }
        public string Subject { get; set; }

        public virtual Departments SubjectNavigation { get; set; }
        public virtual Users U { get; set; }
        public virtual EnrollmentGrade EnrollmentGrade { get; set; }
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
