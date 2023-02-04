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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            this._userOperationClaimDal = userOperationClaimDal;
        }

        private readonly IUserOperationClaimDal _userOperationClaimDal;


        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult(SuccessMessages.UserOperationClaimAdded);
        }

        public IResult Delete(UserOperationClaim entity)
        {
            _userOperationClaimDal.Delete(entity);
            return new SuccessResult(SuccessMessages.UserOperationClaimDeleted);
        }

        public IDataResult<UserOperationClaim> GetById(object id)
        {
            return new SuccessDataResult<UserOperationClaim>(SuccessMessages.UserOperationClaimGet, _userOperationClaimDal.Get(O=>O.Id == Convert.ToInt32(id)));
        }

        public IDataResult<List<UserOperationClaim>> GetList()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(SuccessMessages.UserOperationClaimList, _userOperationClaimDal.GetAll().ToList());
        }

        public IResult Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessResult(SuccessMessages.UserOperationClaimUpdated);
        }
    }
}
