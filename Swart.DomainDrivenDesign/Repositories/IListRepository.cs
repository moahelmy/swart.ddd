using System;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IListRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IComparable
    {
        void Add(TEntity item);

        void Remove(TEntity item);

        TEntity Remove(TKey id);
    }
}
