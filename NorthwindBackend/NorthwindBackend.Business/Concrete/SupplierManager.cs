using Core.Utilities.Result;
using Microsoft.EntityFrameworkCore.Query;
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
    public class SupplierManager : ISupplierService
    {
        public SupplierManager(ISupplierDal supplierDal)
        {
            this._supplierDal = supplierDal;
        }

        private readonly ISupplierDal _supplierDal;


        public IResult Add(Supplier entity)
        {
            _supplierDal.Add(entity);
            return new SuccessResult(SuccessMessages.SupplierAdded);
        }

        public IResult Delete(Supplier entity)
        {
            _supplierDal.Delete(entity);
            return new SuccessResult(SuccessMessages.SupplierDeleted);
        }

        public IDataResult<Supplier> GetById(object id)
        {
            return new SuccessDataResult<Supplier>(SuccessMessages.SupplierGet, _supplierDal.Get(O=>O.SupplierID == Convert.ToInt32(id)));
        }

        public IDataResult<List<Supplier>> GetList()
        {
            return new SuccessDataResult<List<Supplier>>(SuccessMessages.SupplierList, _supplierDal.GetAll().ToList());
        }

        public IResult Update(Supplier entity)
        {
            _supplierDal.Update(entity);
            return new SuccessResult(SuccessMessages.SupplierUpdated);
        }
    }
}
