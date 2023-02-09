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
    public class CategoryManager : ICategoryService
    {
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        private readonly ICategoryDal _categoryDal;


        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(SuccessMessages.CategoryAdded);
        }

        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(SuccessMessages.CategoryDeleted);
        }

        public IDataResult<Category> GetById(object id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(O => O.CategoryID == Convert.ToInt32(id)), SuccessMessages.CategoryGet);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList(), SuccessMessages.CategoryList);
        }

        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(SuccessMessages.CategoryUpdated);
        }
    }
}
