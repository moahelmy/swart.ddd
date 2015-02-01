using System;
using System.Data;

namespace Swart.DomainDrivenDesign.Repositories.Exceptions
{
    public class DuplicatedRecordException:DataException
    {
        public DuplicatedRecordException()
        { }

        public DuplicatedRecordException(string message)
            : base(message)
        {
        }

        public DuplicatedRecordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
