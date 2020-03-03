using CRMALL.Teste.Business.Base;
using CRMALL.Teste.Domain.Helper;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Cep;

namespace CRMALL.Teste.Business.Service
{
    public class PessoaService : BaseService<PessoaModel>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository) : base(repository)
        {
        }

        public CepViewModel ConsultarCep(string cep)
        {
            return CepHelper.ConsultarCep<CepViewModel>(cep);
        }

        //public override IEnumerable<PessoaModel> All()
        //{
        //    return new List<PessoaModel> { new PessoaModel { Id = 1, DataNascimento = new DateTime(1991, 11, 8), Nome = "Luiz", Sexo = SexoEnum.Masculino } };
        //}
    }
}
