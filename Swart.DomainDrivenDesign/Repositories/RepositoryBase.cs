using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Domain.Specification;
using Swart.DomainDrivenDesign.Repositories.Exceptions;

namespace Swart.DomainDrivenDesign.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        protected abstract IQueryable<TEntity> _List();

        #region Basic
        public virtual IUnitOfWork UnitOfWork { get; protected set; }       

        public virtual IQueryable<TEntity> List()
        {
            return _List();
        }

        public virtual TEntity Get(TKey id)
        {
            return _List().FirstOrDefault(e => e.Id.Equals(id));
        }
        #endregion        

        #region Queryable
        public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return _List().Where(expression);
        }

        public virtual IQueryable<TEntity> List(ISpecification<TEntity> specification)
        {
            return List(specification.SatisfiedBy());
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            return _List().FirstOrDefault(expression);
        }

        public virtual TEntity Single(ISpecification<TEntity> specification)
        {
            return Single(specification.SatisfiedBy());
        }

        #endregion

        #region List
                
        protected abstract void AddEntity(TEntity entity);

        public virtual void Add(TEntity entity)
        {
            ValidateObject(entity);
            AddEntity(entity);
        }        

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            var entitiesLst = entities as IList<TEntity> ?? entities.ToList();
            foreach (var entity in entitiesLst)
            {
                ValidateObject(entity);
            }
            foreach (var entity in entitiesLst)
            {
                Add(entity);
            }
        }

        protected abstract void DeleteEntity(TEntity entity);

        public virtual void Delete(TEntity entity)
        {
            DeleteEntity(entity);
        }
        
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            var entitiesLst = entities as IList<TEntity> ?? entities.ToList();
            foreach (var entity in entitiesLst)
            {
                ValidateObject(entity);
            }
            foreach (var entity in entitiesLst)
            {
                Delete(entity);
            }
        }
        
        public virtual TEntity Delete(TKey id)
        {
            var entity = Get(id);
            if (entity == null)
                throw new RecordNotFoundException();
            Delete(entity);
            return entity;
        }

        protected abstract void UpdateEntity(TEntity entity);

        public virtual void Update(TEntity entity)
        {
            ValidateObject(entity);
            UpdateEntity(entity);
        }
        #endregion

        #region IDisposal
        public abstract void Dispose();
        #endregion       

        #region Private Methods
        private static void ValidateObject(TEntity entity)
        {
            var validationResults = entity.Validate().ToList();
            if (validationResults.Any())
                throw new ValidationException(validationResults);
        }
        #endregion
    }
}
