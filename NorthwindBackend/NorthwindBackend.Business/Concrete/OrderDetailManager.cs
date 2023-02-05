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
    public class OrderDetailManager : IOrderDetailService
    {
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            this._orderDetailDal = orderDetailDal;
        }

        private readonly IOrderDetailDal _orderDetailDal;


        public IResult Add(OrderDetail entity)
        {
            _orderDetailDal.Add(entity);
            return new SuccessResult(SuccessMessages.OrderDetailAdded);
        }

        public IResult Delete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
            return new SuccessResult(SuccessMessages.OrderDetailDeleted);
        }

        public IDataResult<OrderDetail> GetById(object id)
        {
            return new SuccessDataResult<OrderDetail>(SuccessMessages.OrderDetailGet, _orderDetailDal.Get(O => O.OrderID == Convert.ToInt32(id)));
        }

        public IDataResult<List<OrderDetail>> GetList()
        {
            return new SuccessDataResult<List<OrderDetail>>(SuccessMessages.OrderDetailList, _orderDetailDal.GetAll().ToList());
        }

        public IResult Update(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
            return new SuccessResult(SuccessMessages.OrderDetailUpdated);
        }
    }
}
