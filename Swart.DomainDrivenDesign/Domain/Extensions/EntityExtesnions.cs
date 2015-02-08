using System.Data.Entity;
using System.Linq;
using Swart.Linq;

namespace Swart.DomainDrivenDesign.Domain.Extensions
{
    public static class EntityExtesnions
    {
        public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> queryable)
        {
            var fkProperties = typeof(TEntity).GetAllPropertiesOfType(typeof(AbstractEntity));

            return fkProperties.Aggregate(queryable, (current, propertyInfo) => current.Include(propertyInfo.Name));
        }
    }
}
