using Core.Utilities.Result;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        public OrderManager(IOrderDal _orderDal)
        {
            this._orderDal = _orderDal;
        }

        private readonly IOrderDal _orderDal;


        public IResult Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Order> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
