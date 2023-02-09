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
    public class EfUserDal : IUserDal
    {
        public void Add(User entity)
        {
            using (var context = new DBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (var context = new DBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new DBContext())
            {
                //var value = context.Set<User>().SingleOrDefault(filter);
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        

        public IList<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new DBContext())
            {
                return (filter == null
                ? context.Set<User>().ToList()
                : context.Set<User>().Where(filter).ToList());
            }
        }

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

        public void Update(User entity)
        {
            using (var context = new DBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
