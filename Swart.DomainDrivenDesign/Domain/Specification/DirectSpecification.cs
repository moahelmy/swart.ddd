using System;
using System.Linq.Expressions;

namespace Swart.DomainDrivenDesign.Domain.Specification
{
    public sealed class DirectSpecification<TEntity>
        : Specification<TEntity>
        where TEntity : class
    {
        readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }
        
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return _matchingCriteria;
        }
    }
}
