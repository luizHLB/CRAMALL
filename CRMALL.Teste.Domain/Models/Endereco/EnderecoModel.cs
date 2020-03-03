﻿using CRMALL.Teste.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRMALL.Teste.Domain.Models.Endereco
{
    public class EnderecoModel : BaseEntity
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}
