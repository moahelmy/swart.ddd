using System;
using System.Linq.Expressions;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Domain.Specification;
using Swart.DomainDrivenDesign.Query;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IQueryableRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        IQuery<TEntity> List(Expression<Func<TEntity, bool>> expression);
        IQuery<TEntity> List(ISpecification<TEntity> specification);

        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity Single(ISpecification<TEntity> specification);
    }
}
