using Core.Business;
using Core.Utilities.Result;
using NorthwindBackend.Entities.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Business.Abstract
{
    public interface IUserService : IEntityBaseService<User>
    {
        IDataResult<List<OperationClaim>> GetOperationClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
