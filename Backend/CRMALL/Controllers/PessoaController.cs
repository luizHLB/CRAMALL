using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CRMALL.Api.Controllers.Base;
using CRMALL.Teste.Domain.Helper;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Domain.Models.Pessoa;
using CRMALL.Teste.Domain.ViewModels.Cep;
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
        [ProducesResponseType(typeof(CepViewModel), (int)HttpStatusCode.OK)]
        public ActionResult ConsultarCep([FromQuery] string cep)
        {
            return Ok(service.ConsultarCep(cep));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<PessoaViewModel>), (int)HttpStatusCode.OK)]

        public ActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PessoaViewModel), (int)HttpStatusCode.OK)]

        public ActionResult GetById([FromRoute] int id)
        {
            return Ok(service.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]

        public ActionResult Post([FromBody] PessoaInsertViewModel viewModel)
        {
            var model = MapperHelper.Map<PessoaInsertViewModel, PessoaModel>(viewModel);
            return Ok(service.Create(model));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PessoaViewModel), (int)HttpStatusCode.OK)]
        public ActionResult Put([FromBody] PessoaUpdateViewModel viewModel, [FromRoute] int id)
        {
            viewModel.Id = id;
            var model = MapperHelper.Map<PessoaUpdateViewModel, PessoaModel>(viewModel);
            service.Update(model);
            return Ok(service.GetById(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public ActionResult Delete(int id)
        {
            service.Remove(id);
            return Ok();
        }
    }
}
