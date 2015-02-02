using System;
using System.Linq;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IBasicRepository<out TEntity, in TKey>: IDisposable 
        where TEntity : IEntity<TKey> 
        where TKey:IComparable
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> List();

        TEntity Get(TKey id);
    }
}
