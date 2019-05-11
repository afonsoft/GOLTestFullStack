using System;
using System.Linq;
using System.Linq.Expressions;

namespace GOLTestFullStack.Api.Iinterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);        
        IQueryable<TEntity> Get();
        TEntity GetById(long id);
        void Delete(TEntity entity);
        void DeleteById(long id);        
        void Update(TEntity entity);
        void UpdateById(TEntity entity, long id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
