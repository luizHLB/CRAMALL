using CRMALL.Teste.Domain.Base;
using CRMALL.Teste.Domain.Helper;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Domain.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRMALL.Api.Controllers.Base
{
    public class BaseController<T, TM, TIm, TUm> : ControllerBase where T : BaseEntity
                                                                            where TM : class
                                                                            where TIm : class
                                                                            where TUm : BaseUpdateViewModel
    {
        protected readonly IBaseService<T> Service;
        protected List<ValidationResult> ValidationResultList = new List<ValidationResult>();

        public BaseController(IBaseService<T> service)
        {
            Service = service;
        }

        protected bool Validate<TTm>(TTm model) where TTm : class
        {
            return !Validator.TryValidateObject(model, new ValidationContext(model), ValidationResultList);
        }

        protected ActionResult GetErrors()
        {
            var response = BadRequest(GetErrors(ValidationResultList));
            ValidationResultList = new List<ValidationResult>();
            return response;
        }

        protected ActionResult Post(TIm model)
        {
            if (Validate(model))
                return GetErrors();

            var response = Insert(model);
            return Created(response);
        }

        protected virtual int Insert(TIm model)
        {
            return Service.Create(MapperHelper.Map<TIm, T>(model));
        }

        protected ActionResult Put(int id, TUm model)
        {
            model.Id = id;

            if (Validate(model))
                return GetErrors();

            var response = Update(model);
            return Ok(MapperHelper.Map<T, TM>(response));
        }

        protected virtual T Update(TUm model)
        {
            return Service.Update(MapperHelper.Map<TUm, T>(model));
        }

        protected ActionResult Delete(int id)
        {
            Service.Remove(id);
            return Ok();
        }

        protected ActionResult Get(int id)
        {
            var response = Service.Find(id);
            if (response == null)
                return NotFound();

            return Ok(MapperHelper.Map<T, TM>(response));
        }

        protected virtual ActionResult Created(int id)
        {
            return Created(string.Empty, id);
        }

        public static ErrorResponseViewModel GetErrors(List<ValidationResult> errors)
        {
            return new ErrorResponseViewModel
            {
                Errors = errors.GroupBy(g => g.MemberNames.FirstOrDefault()).Select(s =>
                    new ItemErrorResponseViewModel(s.Key)
                    {
                        Messages = s.Select(sm => sm.ErrorMessage).ToList()
                    }).ToList()
            };
        }
    }
}
