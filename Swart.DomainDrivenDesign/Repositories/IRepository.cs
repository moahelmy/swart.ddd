using System;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IRepository<TEntity, in TKey> 
        : IQueryableRepository<TEntity, TKey>, IListRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey> 
        where TKey : IComparable
    {
    }
}
