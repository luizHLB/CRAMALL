using CRMALL.Teste.Domain.Models.Endereco;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Cep;
using CRMALL.Teste.Domain.ViewModels.Pessoa;
using System.Collections.Generic;

namespace CRMALL.Teste.Domain.Interfaces.Service
{
    public interface IPessoaService : IBaseService<PessoaModel>
    {
        CepViewModel ConsultarCep(string cep);
        IEnumerable<PessoaViewModel> GetAll();
        PessoaViewModel GetById(int id);
    }
}
