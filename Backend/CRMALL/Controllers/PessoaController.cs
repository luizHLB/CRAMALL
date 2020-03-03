using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMALL.Api.Controllers.Base;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace CRMALL.Controllers
{
    [ApiController]
    [Route("api/v1/pessoas")]
    public class PessoaController : BaseController<PessoaModel, PessoaViewModel, PessoaInsertViewModel, PessoaUpdateViewModel>
    {
        private readonly IPessoaService service;
        public PessoaController(IPessoaService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("consultarCEP")]
        public ActionResult ConsultarCep([FromQuery] string cep)
        {
            return Ok(service.ConsultarCep(cep));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(service.All());
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            return Ok(service.Find(id));
        }
    }
}
