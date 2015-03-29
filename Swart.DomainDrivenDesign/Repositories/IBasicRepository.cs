using System;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Query;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IBasicRepository<TEntity, in TKey>: IDisposable 
        where TEntity : IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        IUnitOfWork UnitOfWork { get; }

        IQuery<TEntity> List();

        TEntity Get(TKey id);
    }
}
