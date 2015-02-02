using System;
using System.Linq;
using System.Linq.Expressions;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Domain.Specification;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IQueryableRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>        
        where TKey : IComparable
    {
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> List(ISpecification<TEntity> specification);
    }
}
