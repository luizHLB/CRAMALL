using CRMALL.Teste.Domain.Base;
using CRMALL.Teste.Domain.Configurations;
using CRMALL.Teste.Domain.Exceptions;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMALL.Teste.Repository.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly Configuration configuration;

        public BaseRepository(IOptions<Configuration> options)
        {
            configuration = options.Value;
        }

        public virtual DbContext GetContext()
        {
            return new DataContext(configuration);
        }

        public virtual IEnumerable<T> All()
        {
            using (var context = GetContext())
            {
                return ExtractFromContext(context.Set<T>().ToList());
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

        public T Find(int id, DbContext context, bool extractFromContext = true)
        {
            var response = context.Set<T>().Find(id);
            if (extractFromContext)
                return ExtractFromContext(response);

            return response;
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
            var model = Find(id, context, false);
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

            return ExtractFromContext(dto);
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

        protected TE ExtractFromContext<TE>(TE dto)
        {
            var temp = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<TE>(temp);
        }

        protected List<TE> ExtractFromContext<TE>(List<TE> dto)
        {
            var temp = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<List<TE>>(temp);
        }

        protected List<TE> ExtractFromContext<TE>(IEnumerable<TE> dto)
        {
            return ExtractFromContext(dto.ToList());
        }
    }
}
