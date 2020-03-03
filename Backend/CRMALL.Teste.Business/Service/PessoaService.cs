using CRMALL.Teste.Business.Base;
using CRMALL.Teste.Domain.Helper;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Cep;
using CRMALL.Teste.Domain.ViewModels.Pessoa;
using System.Collections.Generic;

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

        public IEnumerable<PessoaViewModel> GetAll()
        {
            return ((IPessoaRepository)repository).GetAll();
        }

        public PessoaViewModel GetById(int id)
        {
            return ((IPessoaRepository)repository).GetById(id);
        }
    }
}
