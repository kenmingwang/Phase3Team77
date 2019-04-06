﻿using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Users
    {
        public string UId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Dob { get; set; }

        public virtual Administrators Administrators { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Students Students { get; set; }
    }
}
