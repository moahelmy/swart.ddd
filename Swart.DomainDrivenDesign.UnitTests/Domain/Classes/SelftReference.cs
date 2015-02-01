using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.UnitTests.Domain.Classes
{    
    class SelfReference
        :ValueObject<SelfReference>
    {
        public SelfReference()
        {
        }
        public SelfReference(SelfReference value)
        {
            Value = value;
        }
        public SelfReference Value { get; set; }
    }
}
