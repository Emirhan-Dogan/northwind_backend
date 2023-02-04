using Core.Entities;
using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IEntityBaseService<TEntity>
        where TEntity : class, IEntity, new()
    {
        IDataResult<List<TEntity>> GetList();
        IDataResult<TEntity> GetById(object id);
        IResult Delete(TEntity entity);
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
    }
}
