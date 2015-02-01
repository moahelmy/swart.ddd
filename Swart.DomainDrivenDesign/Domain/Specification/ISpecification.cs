using System;
using System.Linq.Expressions;

namespace Swart.DomainDrivenDesign.Domain.Specification
{
    /// <summary>
    /// Specification is used to identify object that meet some criteria. SatisfiedBy() in original specification pattern returns bool,
    /// In this version it returns linq expression that output true in order to let criteria run on database server if available
    /// </summary>
    /// <typeparam name="TEntity">An Entity</typeparam>

    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
