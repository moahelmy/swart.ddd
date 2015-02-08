using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Swart.DomainDrivenDesign.Domain
{
    /// <summary>
    /// The values object represents grouped data with entites. A good example is address. Address has no identity
    /// but it group information about address like street, city, country in one object.
    /// All value object must inherit from this class.
    /// </summary>    
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>, IValidatable
        where TValueObject : ValueObject<TValueObject>
    {
        // IEquatable and Override Equals operators

        public bool Equals(TValueObject other)
        {
            if ((object) other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            //compare all public properties
            PropertyInfo[] publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p =>
                    {
                        var left = p.GetValue(this, null);
                        var right = p.GetValue(other, null);


                        if (left is TValueObject)
                        {
                            //check not self-references...
                            return ReferenceEquals(left, right);
                        }
                        return left.Equals(right);
                    });
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = obj as ValueObject<TValueObject>;

            if ((object) item != null)
                return Equals((TValueObject) item);
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            int index = 1;

            //compare all public properties
            PropertyInfo[] publicProperties = GetType().GetProperties();


            if (publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    object value = item.GetValue(this, null);

                    if (value != null)
                    {

                        hashCode = hashCode*((changeMultiplier) ? 59 : 114) + value.GetHashCode();

                        changeMultiplier = !changeMultiplier;
                    }
                    else
                        hashCode = hashCode ^ (index*13); //only for support {"a",null,null,"a"} <> {null,"a","a",null}
                    index++;
                }
            }

            return hashCode;
        }

        public virtual IEnumerable<ValidationResult> Validate()
        {
            return new List<ValidationResult>();
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (Equals(left, null))
                return (Equals(right, null));
            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }
    }
}
