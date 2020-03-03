using CRMALL.Teste.Domain.Enum;
using System;

namespace CRMALL.Teste.Domain.ViewModels.Pessoa
{
    public class PessoaInsertViewModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
