using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Swart.DomainDrivenDesign.Query
{
    public interface IQuery<T>
    {
        IQuery<T> Include<TProperty>(Expression<Func<T, TProperty>> expression);
        IList<T> Where(Expression<Func<T, bool>> expression);
        IList<T> ToList();
    }
}
