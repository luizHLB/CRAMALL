using CRMALL.Teste.Domain.Base;
using CRMALL.Teste.Domain.Enum;
using CRMALL.Teste.Domain.Models.Endereco;
using System;

namespace CRMALL.Teste.Domain.Models.Pessoa
{
    public class PessoaModel : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }

        public int EnderecoId { get; set; }
        public virtual EnderecoModel Endereco { get; set; }
    }
}
