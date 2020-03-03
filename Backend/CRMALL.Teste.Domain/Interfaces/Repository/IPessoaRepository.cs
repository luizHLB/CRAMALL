using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Pessoa;
using System.Collections.Generic;

namespace CRMALL.Teste.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IBaseRepository<PessoaModel>
    {
        IEnumerable<PessoaViewModel> GetAll();
        PessoaViewModel GetById(int id);
    }
}
