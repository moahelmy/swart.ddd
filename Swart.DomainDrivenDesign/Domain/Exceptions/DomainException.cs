using System;

namespace Swart.DomainDrivenDesign.Domain.Exceptions
{
    public class DomainException:ApplicationException
    {        
        public DomainException(string message):base(message)
        {            
        }
    }
}
