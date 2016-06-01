using System;
using Swart.DomainDrivenDesign.Domain;
using System.Linq;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IBasicRepository<TEntity, in TKey>: IDisposable 
        where TEntity : IEntity<TKey>
        where TKey : IComparable, IEquatable<TKey>
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> List();

        TEntity Get(TKey id);
    }
}
