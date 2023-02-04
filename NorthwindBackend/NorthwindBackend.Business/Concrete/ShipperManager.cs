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
    public class ShipperManager : IShipperService
    {
        public ShipperManager(IShipperDal shipperDal)
        {
            this._shipperDal = shipperDal;
        }

        private readonly IShipperDal _shipperDal;


        public IResult Add(Shipper entity)
        {
            _shipperDal.Add(entity);
            return new SuccessResult(SuccessMessages.ShipperAdded);
        }

        public IResult Delete(Shipper entity)
        {
            _shipperDal.Delete(entity);
            return new SuccessResult(SuccessMessages.ShipperDeleted);
        }

        public IDataResult<Shipper> GetById(object id)
        {
            return new SuccessDataResult<Shipper>(SuccessMessages.ShipperGet, _shipperDal.Get(O=>O.ShipperID == Convert.ToUInt32(id)));
        }

        public IDataResult<List<Shipper>> GetList()
        {
            return new SuccessDataResult<List<Shipper>>(SuccessMessages.ShipperList, _shipperDal.GetAll().ToList());
        }

        public IResult Update(Shipper entity)
        {
            _shipperDal.Update(entity);
            return new SuccessResult(SuccessMessages.ShipperUpdated);
        }
    }
}
