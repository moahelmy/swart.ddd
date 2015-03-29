using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Swart.DomainDrivenDesign.Query
{
    public class Query<T>:IQuery<T>
    {
        private IQueryable<T> _list;

        public Query(IQueryable<T> list)
        {
            _list = list;
        }

        public IQuery<T> Include<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            _list = _list.Include(expression);
            return this;
        }

        public IList<T> Where(Expression<Func<T, bool>> expression)
        {
            return _list.Where(expression).ToList();
        }

        public IList<T> ToList()
        {
            return _list.ToList();
        }
    }
}
