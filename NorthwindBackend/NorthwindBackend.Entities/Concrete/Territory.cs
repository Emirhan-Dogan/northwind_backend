﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Entities.Concrete
{
    public class Territory : IEntity
    {
        public string TerritoryID {get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }
    }
}
