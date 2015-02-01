using System;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface ITransaction:IDisposable
    {
        void Commit();
        void Rollback();
    }
}
