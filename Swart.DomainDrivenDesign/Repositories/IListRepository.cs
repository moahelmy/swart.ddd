using System;
using System.Collections.Generic;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IListRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        void Add(TEntity item);

        void Add(IEnumerable<TEntity> item);

        void Delete(TEntity item);

        void Delete(IEnumerable<TEntity> item);

        TEntity Delete(TKey id);

        void Update(TEntity item);
    }
}
