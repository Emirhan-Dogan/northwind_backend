using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Entities.Concrete
{
    public class Region : IEntity
    {
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    }
}
