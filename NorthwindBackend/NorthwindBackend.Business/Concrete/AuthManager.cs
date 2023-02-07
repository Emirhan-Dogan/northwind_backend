using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Business.Constants;
using NorthwindBackend.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            this._userService = userService;
            this._tokenHelper = tokenHelper;
        }


        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            return new SuccessDataResult<AccessToken>(SuccessMessages.CreateAccessToken, _tokenHelper.CreateToken(user, _userService.GetOperationClaims(user).Data));
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(ErrorMesages.UserNotFound, new User());
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(ErrorMesages.PasswordError, new User());
            }

            return new SuccessDataResult<User>(SuccessMessages.SuccessfulLogin, userToCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User();

            user.Email = userForRegisterDto.Email;
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName = userForRegisterDto.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = true;

            _userService.Add(user);
            return new SuccessDataResult<User>(SuccessMessages.UserRegistered, user);
        }

        public IResult UserExists(string email)
        {
            if (!_userService.GetByMail(email).Success)
            {
                return new ErrorResult(ErrorMesages.UserAlreadyExists);
            }
            return new SuccessResult(SuccessMessages.UserIsNotAvailable);
        }
    }
}
