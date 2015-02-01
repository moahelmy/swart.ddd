using System.Collections.Generic;

namespace Swart.DomainDrivenDesign.Repositories
{
    /// <summary>
    /// This interface is designed to give us the ability to work out of the box and use sql statement directly
    /// instead of allowing ORM tool to construct it
    /// </summary>

    public interface ISqlCommand
    {
        IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters);

        int ExecuteCommand(string sqlCommand, params object[] parameters);
    }
}
