using System;
using System.Data;

namespace Swart.DomainDrivenDesign.Repositories.Exceptions
{
    public class RecordNotFoundException:DataException
    {
        public RecordNotFoundException()
        { }

        public RecordNotFoundException(string message)
            : base(message)
        {
        }

        public RecordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
