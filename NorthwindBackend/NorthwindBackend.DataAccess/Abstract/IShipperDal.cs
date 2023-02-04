using Core.DataAccess;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.DataAccess.Abstract
{
    public interface IShipperDal : IEntityRepository<Shipper>
    {
    }
}
