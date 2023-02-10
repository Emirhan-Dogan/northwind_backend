using Core.DataAccess.EntityFramework;
using NorthwindBackend.DataAccess.Abstract;
using NorthwindBackend.DataAccess.Concrete.EntityFramework.Contexts;
using Core.Entities.Concrete;
using NorthwindBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace NorthwindBackend.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DBContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DBContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public List<User> IsEmailAvailable(string email)
        {
            using (var context = new DBContext())
            {
                return context.Set<User>().Where(O=>O.Email == email).ToList();
            }
        }
    }
}
