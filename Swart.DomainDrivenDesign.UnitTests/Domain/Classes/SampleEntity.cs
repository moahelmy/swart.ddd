using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.UnitTests.Domain.Classes
{      
    //Sample Entity
    public class SampleEntity
        :Entity<Guid>
    {
        public string SampleProperty { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new Collection<ValidationResult>();
        }
    }
}
