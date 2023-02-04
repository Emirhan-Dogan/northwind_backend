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
    public class TerritoryManager : ITerritoryService
    {
        public TerritoryManager(ITerritoryDal territoryDal)
        {
            this._territoryDal = territoryDal;
        }

        private readonly ITerritoryDal _territoryDal;


        public IResult Add(Territory entity)
        {
            _territoryDal.Add(entity);
            return new SuccessResult(SuccessMessages.TerritoryAdded);
        }

        public IResult Delete(Territory entity)
        {
            _territoryDal.Delete(entity);
            return new SuccessResult(SuccessMessages.TerritoryDeleted);
        }

        public IDataResult<Territory> GetById(object id)
        {
            return new SuccessDataResult<Territory>(SuccessMessages.TerritoryGet, _territoryDal.Get(O=>O.TerritoryID == id));
        }

        public IDataResult<List<Territory>> GetList()
        {
            return new SuccessDataResult<List<Territory>>(SuccessMessages.TerritoryList, _territoryDal.GetAll().ToList());
        }

        public IResult Update(Territory entity)
        {
            _territoryDal.Update(entity);
            return new SuccessResult(SuccessMessages.TerritoryUpdated);
        }
    }
}
