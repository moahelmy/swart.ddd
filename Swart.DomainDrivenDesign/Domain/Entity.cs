using System;

namespace Swart.DomainDrivenDesign.Domain
{
    public class Entity<TKey> : AbstractEntity, IEntity<TKey> 
        where TKey : IComparable
    {
        private TKey _id;
        public virtual TKey Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException("Id", "The id property cannot be set to null.");
                }
                _id = value;
            }
        }

        public override IComparable GetId()
        {
            return _id;
        }

        public override bool IsTransient()
        {
            return ReferenceEquals(_id, null) || _id.CompareTo(default(TKey)) == 0;
        }
    }
}
