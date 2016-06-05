using System;
using System.Collections.Generic;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IListRepository<TEntity, in TKey> : IBasicRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        IVoidResult Add(TEntity item);

        IVoidResult Add(IEnumerable<TEntity> item);

        IVoidResult Delete(TEntity item);

        void Delete(IEnumerable<TEntity> item);

        IResult<TEntity> Delete(TKey id);

        IVoidResult Update(TEntity item);
    }
}
