using Core.Business;
using Core.Utilities.Result;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Abstract
{
    public interface IProductService : IEntityBaseService<Product>
    {
        IDataResult<List<Product>> GetListByCategory(int categoryId);
    }
}
