using System;

namespace Swart.DomainDrivenDesign.Domain
{
    public interface IEntity<TKey>:IValidatable where TKey: IComparable
    {
        TKey Id { get; set; }
    }
}
