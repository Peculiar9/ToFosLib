﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.EntityModels
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryBranch LibraryBranch { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

    }
}
