using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.UnitTests.Fakes
{    
    class SelfReference
        :ValueObject
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
