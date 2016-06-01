using System;
using System.Linq.Expressions;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Domain.Specification;
using System.Linq;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IQueryableRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> List(ISpecification<TEntity> specification);

        IQueryable<TEntity> QueryableById(TKey id);

        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity Single(ISpecification<TEntity> specification);
    }
}
