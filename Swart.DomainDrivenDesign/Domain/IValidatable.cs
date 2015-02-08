using System.Collections.Generic;

namespace Swart.DomainDrivenDesign.Domain
{
    public interface IValidatable
    {
        IEnumerable<ValidationResult> Validate();
    }
}
