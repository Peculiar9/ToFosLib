﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.EntityModels
{
    public class BranchHours
    {
        public int Id { get; set; }
        public LibraryBranch Branch { get; set; }
        [Range(0, 6)]
        public int DayOfWeek { get; set; }
        [Range(0, 23)]
        public int OpenTIme { get; set; }
        [Range(0, 23)]
        public int CloseTime { get; set; }
    }
}
