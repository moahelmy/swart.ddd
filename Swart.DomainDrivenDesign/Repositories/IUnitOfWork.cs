using System;

namespace Swart.DomainDrivenDesign.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        ITransaction BeginTransaction();

        void SaveChanges(); 
    }
}
