using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GOLTestFullStack.Api.Iinterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);
        IQueryable<TEntity> Get();
        TEntity GetById(long id);
        void Delete(TEntity entity);
        void DeleteById(long id);        
        void Update(TEntity entity);
        void UpdateById(TEntity entity, long id);
        IQueryable<TEntity> GetPagination(Expression<Func<TEntity, bool>> filter, int pagina = 1, int qtdRegistros = 10);

        IQueryable<TEntity> GetPagination(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, int pagina = 1, int qtdRegistros = 10);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
