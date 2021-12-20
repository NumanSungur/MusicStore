using Cores.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cores.DataRepositories.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        TEntity GetByIdFirst(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null,params Expression<Func<TEntity,object>>[]includeProperties);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(Expression<Func<TEntity, bool>> filter);
    }
}
