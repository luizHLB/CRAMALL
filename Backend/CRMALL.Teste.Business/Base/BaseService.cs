using CRMALL.Teste.Domain.Base;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRMALL.Teste.Business.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual IEnumerable<T> All()
        {
            return repository.All();
        }

        public int Create(T model)
        {
            return repository.Create(model);
        }

        public int Create(T model, DbContext context)
        {
            return repository.Create(model, context);
        }

        public T Find(int id)
        {
            return repository.Find(id);
        }

        public T Find(int id, DbContext context)
        {
            return repository.Find(id, context);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public void Remove(int id, DbContext context)
        {
            repository.Remove(id, context);
        }

        public T Update(T model)
        {
            return repository.Update(model);
        }

        public T Update(T model, DbContext context)
        {
            return repository.Update(model, context);
        }
    }
}
