using Core.Utilities.Result;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IDataResult<Product> GetById(int id);
        IResult Delete(Product product);
        IResult Add(Product product);
        IResult Update(Product product);
    }
}
