using Core.Utilities.Result;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Business.Constants;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }


        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(Messages.ProductGet, _productDal.Get(O => O.ProductID == id));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(Messages.ProductList, _productDal.GetAll().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(Messages.ProductList, _productDal.GetAll(O => O.CategoryID == categoryId).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
