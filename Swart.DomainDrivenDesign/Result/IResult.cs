using System.Collections.Generic;

namespace Swart.DomainDrivenDesign
{
    public interface IVoidResult
    {
        bool Succeed { get; }
        IList<SystemMessage> Messages { get; }
    }

    public interface IResult<TReturn>:IVoidResult
    {
        TReturn Return { get; }
    }

    public interface IListResult<TReturn>:IResult<IList<TReturn>>
    {        
    }
}
