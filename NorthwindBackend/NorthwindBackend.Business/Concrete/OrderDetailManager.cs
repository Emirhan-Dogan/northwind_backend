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
            return new S
        }

        public IResult Delete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderDetail> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OrderDetail>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
