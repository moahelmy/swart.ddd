using System;
using System.Linq.Expressions;

namespace Swart.DomainDrivenDesign.Domain.Specification
{
    public abstract class Specification<TEntity>
         : ISpecification<TEntity>
         where TEntity : class
    {       
        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();

        public static bool operator false(Specification<TEntity> specification)
        {
            return false;
        }

        public static bool operator true(Specification<TEntity> specification)
        {
            return true;
        }
    }
}
