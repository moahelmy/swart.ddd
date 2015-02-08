using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Domain.Extensions;
using Swart.DomainDrivenDesign.Domain.Specification;
using Swart.DomainDrivenDesign.Repositories.Exceptions;

namespace Swart.DomainDrivenDesign.Repositories
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        #region Basic
        public virtual IUnitOfWork UnitOfWork { get; protected set; }

        public abstract IQueryable<TEntity> List();

        public TEntity Get(TKey id)
        {
            return List().IncludeAll().FirstOrDefault(e => e.Id.Equals(id));
        }
        #endregion        

        #region Queryable
        public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return List().Where(expression);
        }

        public virtual IQueryable<TEntity> List(ISpecification<TEntity> specification)
        {
            return List(specification.SatisfiedBy());
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            return List().FirstOrDefault(expression);
        }

        public TEntity Single(ISpecification<TEntity> specification)
        {
            return Single(specification.SatisfiedBy());
        }

        #endregion

        #region List
                
        protected abstract void AddEntity(TEntity entity);

        public void Add(TEntity entity)
        {
            ValidateObject(entity);
            AddEntity(entity);
        }        

        public virtual void Add(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        protected abstract void DeleteEntity(TEntity entity);

        public void Delete(TEntity entity)
        {
            DeleteEntity(entity);
        }
        
        public virtual void Delete(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
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

        public void Update(TEntity entity)
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
