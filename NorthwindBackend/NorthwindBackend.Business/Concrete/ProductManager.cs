using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using FluentValidation;
using NorthwindBackend.Business.Abstract;
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


        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessResult(SuccessMessages.AddedEntities("Product"));
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(SuccessMessages.DeletedEntities("Product"));
        }

        public IDataResult<Product> GetById(object id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(O => O.ProductID == Convert.ToInt32(id)), SuccessMessages.GetEntities("Product"));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList(), SuccessMessages.ListEntities("Product"));
        }

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
