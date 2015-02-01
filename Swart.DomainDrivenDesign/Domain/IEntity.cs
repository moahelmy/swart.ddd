using System;

namespace Swart.DomainDrivenDesign.Domain
{
    public interface IEntity<TKey> where TKey: IComparable
    {
        TKey Id { get; set; }
    }
}
