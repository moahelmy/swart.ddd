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

        public virtual IQueryable<TEntity> QueryableById(TKey id)
        {
            return List(x => x.Id.Equals(id));
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

        public virtual IVoidResult Add(TEntity entity)
        {
            if (entity == null)
                return new VoidResult().AddErrorMessage("Entity cannot be null");
            var result = ValidateObject(entity);
            if(result.Succeed)
                AddEntity(entity);
            return result;
        }        

        public virtual IVoidResult Add(IEnumerable<TEntity> entities)
        {
            var entitiesLst = entities as IList<TEntity> ?? entities.ToList();
            var result = new VoidResult();
            foreach (var entity in entitiesLst)
            {
                var vResult = ValidateObject(entity);
                if (!vResult.Succeed)
                    result.AddMessages(vResult.Messages);
            }
            if(result.Succeed)
                foreach (var entity in entitiesLst)
                {
                    Add(entity);
                }
            return result;
        }

        protected abstract void DeleteEntity(TEntity entity);

        public virtual IVoidResult Delete(TEntity entity)
        {
            if (entity == null)
                return new VoidResult().AddErrorMessage("Entity cannot be null");
            DeleteEntity(entity);
            return new VoidResult();
        }
        
        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            var entitiesLst = entities as IList<TEntity> ?? entities.ToList();
            foreach (var entity in entitiesLst)
            {
                Delete(entity);
            }
        }
        
        public virtual IResult<TEntity> Delete(TKey id)
        {
            var entity = Get(id);
            var result = new Result<TEntity>();
            if (entity == null)
                result.AddErrorMessage("Record not found");
            Delete(entity);
            result.Return = entity;
            return result;
        }

        protected abstract IVoidResult UpdateEntity(TEntity entity);

        public virtual IVoidResult Update(TEntity entity)
        {
            if (entity == null)
                return new VoidResult().AddErrorMessage("Entity cannot be null");
            var result = ValidateObject(entity);
            if(result.Succeed)
                return UpdateEntity(entity);
            return result;
        }
        #endregion

        #region IDisposal
        public abstract void Dispose();
        #endregion       

        #region Private Methods
        private static IVoidResult ValidateObject(TEntity entity)
        {
            var validationResults = entity.Validate().ToList();
            return new VoidResult().AddErrorMessages(validationResults.Select(vr => vr.ErrorMessage).ToList());            
        }
        #endregion
    }
}
