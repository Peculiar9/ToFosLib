using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.EntityModels
{
    public class CheckoutHistory
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }
        [Required]
        public LibraryBranch LibraryBranch { get; set; }
        [Required]
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut     { get; set; }
    }
}
