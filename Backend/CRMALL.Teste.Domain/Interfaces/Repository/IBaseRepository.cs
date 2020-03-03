using CRMALL.Teste.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRMALL.Teste.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        int Create(T model);
        int Create(T model, DbContext context);
        T Update(T model);
        T Update(T model, DbContext context);
        void Remove(int id);
        void Remove(int id, DbContext context);
        T Find(int id);
        T Find(int id, DbContext context, bool extractFromContext = true);
        IEnumerable<T> All();
        DbContext GetContext();
    }
}
