using System.Collections.Generic;
using System.Linq;

namespace Swart.DomainDrivenDesign
{
    public class VoidResult : IVoidResult
    {
        public IList<SystemMessage> Messages { get; set; }

        public bool Succeed
        {
            get
            {
                return Messages == null || !Messages.Any(m => m.Type == MessageType.Error);
            }
        }

        public VoidResult()
        {
            Messages = new List<SystemMessage>();
        }
    }
}
