using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GOLTestFullStack.Api.Iinterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GOLTestFullStack.Api.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {/// <summary>
        /// DbContext
        /// </summary>
        public DbContext Context { get; }
        /// <summary>
        /// DbSet
        /// </summary>
        public DbSet<TEntity> DbSet { get; private set; }

        /// <summary>
        /// Primary Key Name
        /// </summary>
        public string PrimaryKeyName { get; private set; }

        internal IEntityType _entityType;
        internal IEnumerable<IProperty> _properties;
        internal IModel _model;

        /// <summary>
        /// Construtor com o RepositoryDbContext
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DbContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();

            _model = Context.Model;
            _entityType = _model.FindEntityType(typeof(TEntity));
            _properties = _entityType.GetProperties();
            PrimaryKeyName = _entityType.FindPrimaryKey().Properties.First().Name;
        }

        /// <summary>
        /// Add Element
        /// </summary>
        /// <param name="entity"></param>
        public async void Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async void DeleteById(long id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
                query = query.Where(filter);

            return orderBy != null ? orderBy(query) : query;
        }

        public IQueryable<TEntity> Get()
        {
            return DbSet.AsNoTracking();
        }

        public TEntity GetById(long id)
        {
            return (DbSet.FirstOrDefault(e => (long)e.GetType().GetProperty(PrimaryKeyName).GetValue(e) == id));
        }

        public async void Update(TEntity entity)
        {
            //pegar o valor da pk do objeto
            var entry = Context.Entry(entity);
            var pkey = entity.GetType().GetProperty(PrimaryKeyName)?.GetValue(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = Context.Set<TEntity>();
                TEntity attachedEntity = set.Find(pkey);  // access the key 
                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // attach the entity 
                }
            }

            await Context.SaveChangesAsync();
        }

        public async void UpdateById(TEntity entity, long id)
        {
            TEntity attachedEntity = GetById(id);  // access the key 
            if (attachedEntity != null)
            {
                var attachedEntry = Context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
                attachedEntry.State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            DbSet = null;
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
