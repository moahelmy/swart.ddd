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
        where TKey : IComparable
    {
        #region Basic
        public virtual IUnitOfWork UnitOfWork { get; protected set; }

        public abstract IQueryable<TEntity> List();

        public abstract TEntity Get(TKey id);
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
                
        public abstract void Add(TEntity item);

        public virtual void Add(IEnumerable<TEntity> item)
        {
            throw new NotImplementedException();
        }

        public abstract void Delete(TEntity item);

        public virtual void Delete(IEnumerable<TEntity> item)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Delete(TKey id)
        {
            var item = Get(id);
            if (item == null)
                throw new RecordNotFoundException();
            Delete(item);
            return item;
        }

        public abstract void Update(TEntity item);
        #endregion

        #region IDisposal
        public abstract void Dispose();
        #endregion       
    }
}
