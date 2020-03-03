using CRMALL.Teste.Domain.Base;
using CRMALL.Teste.Domain.Exceptions;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMALL.Teste.Repository.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public virtual DbContext GetContext()
        {
            return new DataContext();
        }

        public virtual IEnumerable<T> All()
        {
            using (var context = GetContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual int Create(T model)
        {
            using (var context = GetContext())
            {
                return Create(model, context);
            }
        }

        public virtual int Create(T model, DbContext context)
        {
            context.Set<T>().Add(model);
            context.SaveChanges();

            return model.Id;
        }

        public T Find(int id)
        {
            using (var context = GetContext())
            {
                return Find(id, context);
            }
        }

        public T Find(int id, DbContext context)
        {
            return context.Set<T>().Find(id);
        }

        public void Remove(int id)
        {
            using (var context = GetContext())
            {
                Remove(id, context);
            }
        }

        public void Remove(int id, DbContext context)
        {
            var model = Find(id, context);
            if (model is null)
                throw new NotFoundExeption();

            context.Set<T>().Remove(model);
            context.SaveChanges();
        }

        public T Update(T model)
        {
            using (var context = GetContext())
            {
                return Update(model, context);
            }
        }

        public T Update(T model, DbContext context)
        {
            var dto = SetValue(model, context);
            context.SaveChanges();

            return dto;
        }

        private T SetValue(T model, DbContext context)
        {
            var id = model.Id;
            var dto = Find(id, context);

            SetValue(context, model, dto);

            return dto;
        }

        protected virtual void SetValue(DbContext context, T model, T dto)
        {
            context.Entry(dto).CurrentValues.SetValues(model);
        }
    }
}
