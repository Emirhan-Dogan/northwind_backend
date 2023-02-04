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
    public class RegionManager : IRegionService
    {
        public RegionManager(IRegionDal _regionDal)
        {
            this._regionDal = _regionDal;
        }

        private readonly IRegionDal _regionDal;


        public IResult Add(Region entity)
        {
            _regionDal.Add(entity);
            return new SuccessResult(SuccessMessages.RegionAdded);
        }

        public IResult Delete(Region entity)
        {
            _regionDal.Delete(entity);
            return new SuccessResult(SuccessMessages.RegionDeleted);
        }

        public IDataResult<Region> GetById(object id)
        {
            return new SuccessDataResult<Region>(SuccessMessages.RegionGet, _regionDal.Get(O=>O.RegionID == Convert.ToInt32(id)));
        }

        public IDataResult<List<Region>> GetList()
        {
            return new SuccessDataResult<List<Region>>(SuccessMessages.RegionList, _regionDal.GetAll().ToList());
        }

        public IResult Update(Region entity)
        {
            _regionDal.Update(entity);
            return new SuccessResult(SuccessMessages.RegionUpdated);
        }
    }
}
