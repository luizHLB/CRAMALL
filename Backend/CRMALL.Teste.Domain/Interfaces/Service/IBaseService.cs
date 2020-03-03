using CRMALL.Teste.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRMALL.Teste.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        int Create(T model);
        int Create(T model, DbContext context);
        T Update(T model);
        T Update(T model, DbContext context);
        void Remove(int id);
        void Remove(int id, DbContext context);
        T Find(int id);
        T Find(int id, DbContext context);
        IEnumerable<T> All();
    }
}
