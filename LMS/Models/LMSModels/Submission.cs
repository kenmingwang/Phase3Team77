﻿using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Submission
    {
        public int AId { get; set; }
        public string UId { get; set; }
        public DateTime Time { get; set; }
        public string Contents { get; set; }
        public int? Score { get; set; }

        public virtual Assignments A { get; set; }
        public virtual Students U { get; set; }
    }
}
