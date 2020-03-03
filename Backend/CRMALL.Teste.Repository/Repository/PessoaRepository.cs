using CRMALL.Teste.Domain.Configurations;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Models.Endereco;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Pessoa;
using CRMALL.Teste.Repository.Repository.Base;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CRMALL.Teste.Repository.Repository
{
    public class PessoaRepository : BaseRepository<PessoaModel>, IPessoaRepository
    {
        public PessoaRepository(IOptions<Configuration> options) : base(options)
        {
        }

        public IEnumerable<PessoaViewModel> GetAll()
        {
            using (var context = GetContext())
            {
                var response = context.Set<PessoaModel>().Select(s => new PessoaViewModel
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Sexo = s.Sexo,
                    DataNascimento = s.DataNascimento,
                    Cep = s.Endereco.Cep,
                    Cidade = s.Endereco.Cidade,
                    Complemento = s.Endereco.Complemento,
                    Estado = s.Endereco.Complemento,
                    Numero = s.Endereco.Numero,
                    Rua = s.Endereco.Rua
                });

                return response.ToList();
            }
        }

        public PessoaViewModel GetById(int id)
        {
            using (var context = GetContext())
            {
                var pessoa = base.Find(id, context);
                return new PessoaViewModel
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sexo = pessoa.Sexo,
                    DataNascimento = pessoa.DataNascimento,
                    Cep = pessoa.Endereco.Cep,
                    Cidade = pessoa.Endereco.Cidade,
                    Complemento = pessoa.Endereco.Complemento,
                    Estado = pessoa.Endereco.Estado,
                    Numero = pessoa.Endereco.Numero,
                    Rua = pessoa.Endereco.Rua
                };
            }
        }
    }
}
