using System.Collections.Generic;

namespace Swart.DomainDrivenDesign
{
    public class ListResult<TListItem> : Result<IList<TListItem>>, IListResult<TListItem>
    {
    }
}
