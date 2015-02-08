using System.Collections.Generic;
using System.Collections.ObjectModel;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.UnitTests.Fakes
{     
    /// <summary>
    /// Sample value object
    /// </summary>
    public class Address
        :ValueObject<Address>
    {
        public string StreetLine1 { get; private set; }
        public string StreetLine2 { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string streetLine1, string streetLine2, string city, string zipCode)
        {
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            City = city;
            ZipCode = zipCode;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return new Collection<ValidationResult>();
        }
    }
}
