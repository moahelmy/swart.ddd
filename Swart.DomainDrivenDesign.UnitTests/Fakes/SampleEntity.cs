using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.UnitTests.Fakes
{      
    //Sample Entity
    public class SampleEntity
        :Entity<Guid>
    {
        public string SampleProperty { get; set; }

        public override IEnumerable<ValidationResult> Validate()
        {
            return new Collection<ValidationResult>();
        }
    }
}
