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
    public class EmployeeManager : IEmployeeService
    {
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            this._employeeDal = employeeDal;
        }

        private readonly IEmployeeDal _employeeDal;


        public IResult Add(Employee entity)
        {
            _employeeDal.Add(entity);
            return new SuccessResult(SuccessMessages.EmployeeAdded);
        }

        public IResult Delete(Employee entity)
        {
            _employeeDal.Delete(entity);
            return new SuccessResult(SuccessMessages.EmployeeDeleted);
        }

        public IDataResult<Employee> GetById(object id)
        {
            return new SuccessDataResult<Employee>(SuccessMessages.EmployeeGet, _employeeDal.Get(O => O.EmployeeID == Convert.ToInt32(id)));
        }

        public IDataResult<List<Employee>> GetList()
        {
            return new SuccessDataResult<List<Employee>>(SuccessMessages.EmployeeList, _employeeDal.GetAll().ToList());
        }

        public IResult Update(Employee entity)
        {
            _employeeDal.Update(entity);
            return new SuccessResult(SuccessMessages.EmployeeUpdated);
        }
    }
}
