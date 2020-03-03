using CRMALL.Teste.Domain.Models.Endereco;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Cep;

namespace CRMALL.Teste.Domain.Interfaces.Service
{
    public interface IPessoaService : IBaseService<PessoaModel>
    {
        CepViewModel ConsultarCep(string cep);
    }
}
