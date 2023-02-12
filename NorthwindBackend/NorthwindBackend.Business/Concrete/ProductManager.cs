using Core.Aspects.Caching;
using Core.Aspects.Logging;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Loging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using FluentValidation;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Business.BusinessAspect;
using NorthwindBackend.Business.Constants;
using NorthwindBackend.Business.ValidationRules.FluentValidation;
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

        [TransactionScopeAspect]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            throw new NotImplementedException();
            return new SuccessResult(SuccessMessages.AddedEntities("Product"));
        }

        [CacheAspect(duration:10)]
        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(SuccessMessages.DeletedEntities("Product"));
        }

        [CacheRemoveAspect(pattern: "IProductService.Delete")]
        public IDataResult<Product> GetById(object id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(O => O.ProductID == Convert.ToInt32(id)), SuccessMessages.GetEntities("Product"));
        }

        //[PerformanceAspect(2)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(), SuccessMessages.ListEntities("Product"));
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(O => O.CategoryID == categoryId).ToList(), SuccessMessages.ListEntities("Product"));
        }

        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(SuccessMessages.UpdatedEntities("Product"));
        }
    }
}
