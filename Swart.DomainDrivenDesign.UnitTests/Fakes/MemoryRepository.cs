using System;
using System.Collections.Generic;
using System.Linq;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Repositories;

namespace Swart.DomainDrivenDesign.UnitTests.Fakes
{
    public class MemoryRepository:RepositoryBase<IEntity<Guid>, Guid>
    {
        private IList<IEntity<Guid>> _list;

        public MemoryRepository(IEnumerable<IEntity<Guid>> list)
        {
            _list = new List<IEntity<Guid>>(list);    
        }

        public MemoryRepository()
            : this(new List<IEntity<Guid>>())
        {            
        }

        protected override IQueryable<IEntity<Guid>> _List()
        {
            return _list.AsQueryable();
        }

        protected override void AddEntity(IEntity<Guid> entity)
        {
            entity.Id = Guid.NewGuid();
            _list.Add(entity);
        }

        protected override void DeleteEntity(IEntity<Guid> entity)
        {
            _list.Remove(entity);
        }

        protected override IVoidResult UpdateEntity(IEntity<Guid> entity)
        {
            var index = _list.IndexOf(entity);
            if (index == -1)
                return new VoidResult().AddErrorMessage("Record not found");
            _list[index] = entity;
            return new VoidResult();
        }

        public override void Dispose()
        {
            _list = null;
        }
    }
}
