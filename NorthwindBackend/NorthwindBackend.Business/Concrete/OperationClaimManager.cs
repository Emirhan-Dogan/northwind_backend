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
    public class OperationClaimManager : IOperationClaimService
    {
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            this._operationClaimDal = operationClaimDal;
        }

        private readonly IOperationClaimDal _operationClaimDal;


        public IResult Add(OperationClaim entity)
        {
            _operationClaimDal.Add(entity);
            return new SuccessResult(SuccessMessages.OperationClaimAdded);
        }

        public IResult Delete(OperationClaim entity)
        {
            _operationClaimDal.Delete(entity);
            return new SuccessResult(SuccessMessages.OperationClaimDeleted);
        }

        public IDataResult<OperationClaim> GetById(object id)
        {
            return new SuccessDataResult<OperationClaim>(SuccessMessages.OperationClaimGet, _operationClaimDal.Get(O => O.Id == Convert.ToInt32(id)));
        }

        public IDataResult<List<OperationClaim>> GetList()
        {
            return new SuccessDataResult<List<OperationClaim>>(SuccessMessages.OperationClaimList, _operationClaimDal.GetAll().ToList());
        }

        public IResult Update(OperationClaim entity)
        {
            _operationClaimDal.Update(entity);
            return new SuccessResult(SuccessMessages.OperationClaimUpdated);
        }
    }
}
