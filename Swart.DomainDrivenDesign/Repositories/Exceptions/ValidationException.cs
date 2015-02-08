using System;
using System.Collections.Generic;
using Swart.DomainDrivenDesign.Domain;

namespace Swart.DomainDrivenDesign.Repositories.Exceptions
{
    public class ValidationException: ArgumentException
    {
        public IEnumerable<ValidationResult> ValidationResults { get; private set; }

        public ValidationException(IEnumerable<ValidationResult> validationResults)
            : base("The validation has been failed.")
        {            
            ValidationResults = validationResults;
        }
    }
}
