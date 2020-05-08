using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.EntityModels
{
    public class LibraryBranch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }
        public virtual IEnumerable<Patron> Patrons { get; set; }

        public string ImageUrl { get; set; }

    }
}
