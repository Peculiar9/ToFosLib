using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.EntityModels
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public int Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
