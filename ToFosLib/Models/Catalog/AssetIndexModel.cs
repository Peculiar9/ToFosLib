﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToFosLib.Models.Catalog
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetIndexListingModel> Assets { get; set; }
    }
}
