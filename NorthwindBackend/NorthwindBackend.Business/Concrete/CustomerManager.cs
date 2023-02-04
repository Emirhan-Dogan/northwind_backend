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
    public class CustomerManager : ICustomerService
    {
        public CustomerManager(ICustomerDal customerDal)
        {
            this._customerDal = customerDal;
        }

        private readonly ICustomerDal _customerDal;


        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(SuccessMessages.CustomerAdded);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(SuccessMessages.CustomerDeleted);
        }

        public IDataResult<Customer> GetById(object id) // int olmayabilir
        {
            return new SuccessDataResult<Customer>(SuccessMessages.CustomerGet, _customerDal.Get(O => O.CustomerID == id.ToString()));
        }

        public IDataResult<List<Customer>> GetList()
        {
            return new SuccessDataResult<List<Customer>>(SuccessMessages.CustomerGet, _customerDal.GetAll().ToList());
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }
    }
}
