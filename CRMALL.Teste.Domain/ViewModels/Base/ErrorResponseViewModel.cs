using System.Collections.Generic;

namespace CRMALL.Teste.Domain.ViewModels.Base
{
    public class ErrorResponseViewModel
    {
        public ErrorResponseViewModel()
        {
            Message = "The given model is invalid.";
        }

        public ErrorResponseViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public List<ItemErrorResponseViewModel> Errors { get; set; }
    }
}
