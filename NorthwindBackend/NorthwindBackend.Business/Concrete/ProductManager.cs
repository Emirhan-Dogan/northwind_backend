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
        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }

        private readonly IProductDal _productDal;


        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(SuccessMessages.ProductAdded);
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(SuccessMessages.ProductDeleted);
        }

        public IDataResult<Product> GetById(object id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(O => O.ProductID == Convert.ToInt32(id)), SuccessMessages.ProductGet);
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(), SuccessMessages.ProductList);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(O => O.CategoryID == categoryId).ToList(), SuccessMessages.ProductList);
        }

        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(SuccessMessages.ProductUpdated);
        }
    }
}
