using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.EntityModels
{
    public class Hold
    {
        public int Id { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryBranch LibraryBranch { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
