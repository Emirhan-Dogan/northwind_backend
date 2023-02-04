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
    public class UserManager : IUserService
    {
        public UserManager(IUserDal userDal)
        {
            this._userDal = userDal;
        }

        private readonly IUserDal _userDal;


        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(SuccessMessages.UserAdded);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(SuccessMessages.UserDeleted);
        }

        public IDataResult<User> GetById(object id)
        {
            return new SuccessDataResult<User>(SuccessMessages.UserGet, _userDal.Get(O => O.Id == Convert.ToInt32(id)));
        }

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(SuccessMessages.UserList, _userDal.GetAll().ToList());
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(SuccessMessages.UserUpdated);
        }
    }
}
