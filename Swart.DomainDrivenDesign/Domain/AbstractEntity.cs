using System;
using System.Collections.Generic;

namespace Swart.DomainDrivenDesign.Domain
{    
    public abstract class AbstractEntity: IValidatable
    {        
        public abstract IComparable GetId();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AbstractEntity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = obj as AbstractEntity;

            if (item.IsTransient() || IsTransient())
                return false;
            return GetId().CompareTo(item.GetId()) == 0;
        }

        public virtual bool IsTransient()
        {
            return ReferenceEquals(GetId(), null);
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                return GetId().GetHashCode() ^ 31;
            }
            return base.GetHashCode();
        }

        public virtual IEnumerable<ValidationResult> Validate()
        {
            return new List<ValidationResult>();
        }

        public static bool operator ==(AbstractEntity left, AbstractEntity right)
        {
            if (Equals(left, null))
                return (Equals(right, null));
            return left.Equals(right);
        }

        public static bool operator !=(AbstractEntity left, AbstractEntity right)
        {
            return !(left == right);
        }
    }
}
