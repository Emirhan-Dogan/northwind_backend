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
    public class OrderManager : IOrderService
    {
        public OrderManager(IOrderDal _orderDal)
        {
            this._orderDal = _orderDal;
        }

        private readonly IOrderDal _orderDal;


        public IResult Add(Order entity)
        {
            _orderDal.Add(entity);
            return new SuccessResult(SuccessMessages.OrderAdded);
        }

        public IResult Delete(Order entity)
        {
            _orderDal.Delete(entity);
            return new SuccessResult(SuccessMessages.OrderDeleted);
        }

        public IDataResult<Order> GetById(object id)
        {
            return new SuccessDataResult<Order>(SuccessMessages.OrderGet, _orderDal.Get(O => O.OrderID == Convert.ToInt32(id)));
        }

        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(SuccessMessages.OrderList, _orderDal.GetAll().ToList()); 
        }

        public IResult Update(Order entity)
        {
            _orderDal.Update(entity);
            return new SuccessResult(SuccessMessages.OrderUpdated);
        }
    }
}
