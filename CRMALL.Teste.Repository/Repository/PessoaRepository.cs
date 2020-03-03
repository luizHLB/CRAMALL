using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Repository.Repository.Base;

namespace CRMALL.Teste.Repository.Repository
{
    public class PessoaRepository : BaseRepository<PessoaModel>, IPessoaRepository
    {
    }
}
